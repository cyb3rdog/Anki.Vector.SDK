// <copyright file="NavMapComponent.cs" company="Wayne Venables">
//     Copyright (c) 2020 Wayne Venables. All rights reserved.
// </copyright>

namespace Anki.Vector
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Anki.Vector.Events;
    using Anki.Vector.ExternalInterface;
    using Anki.Vector.GrpcUtil;
    using Anki.Vector.Types;

    /// <summary>
    /// Represents Vector's navigation memory map.
    /// <para>The NavMapComponent object subscribes for nav memory map updates from the robot to store and dispatch.</para>
    /// </summary>
    /// <seealso cref="Anki.Vector.Component" />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "Component is disposed by Teardown method.")]
    public class NavMapComponent : Component
    {
        /// <summary>
        /// The camera event loop
        /// </summary>
        private readonly IAsyncEventLoop navMapFeed;

        /// <summary>
        /// Gets the map frequency.
        /// </summary>
        public float Frequency { get; private set; } = 1f;

        /// <summary>
        /// The cancellation token source for terminating the feed loop
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = null;

        /// <summary>
        /// Gets the latest nav map.
        /// </summary>
        public NavMapGrid LatestNavMap { get => _latestNavMap; private set => SetProperty(ref _latestNavMap, value); }
        private NavMapGrid _latestNavMap = null;

        private long _internalLastTimestamp = 0;

        /// <summary>
        /// Occurs when nav map updated
        /// </summary>
        public event EventHandler<NavMapUpdateEventArgs> NavMapUpdate;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavMapComponent" /> class.
        /// </summary>
        /// <param name="robot">The robot.</param>
        internal NavMapComponent(Robot robot) : base(robot)
        {
            this.navMapFeed = new AsyncEventLoop<NavMapFeedResponse>(
                (token) => robot.StartStream(client => client.NavMapFeed(new NavMapFeedRequest() { Frequency = Frequency }, cancellationToken: token)),
                (response) =>
                {
                    var navMapUpdateEventArgs = new NavMapUpdateEventArgs(response);
                    LatestNavMap = navMapUpdateEventArgs.NavMap;
                    _internalLastTimestamp = DateTime.Now.Ticks;
                    NavMapUpdate?.Invoke(this, navMapUpdateEventArgs);
                },
                () => { return; },
                //() => OnPropertyChanged(nameof(IsFeedActive)),
                robot.PropagateException
             );
        }

        /// <summary>
        /// Gets a value indicating whether the nav map feed is active.
        /// </summary>
        public bool IsFeedActive => navMapFeed.IsActive || cancellationTokenSource != null;

        /// <summary>
        /// Starts the nav map feed.  The feed will run in a background thread and raise the <see cref="LatestNavMap" /> event for each map change.  It will
        /// also update the <see cref="LatestNavMap" /> property.
        /// </summary>
        /// <param name="frequency">The navmap polling frequency.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task StartFeed(float frequency = 1f)
        {
            Frequency = frequency;
            if (navMapFeed.IsActive)
                await this.StopFeed().ConfigureAwait(true);

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            try
            {
                await Task.Run(() =>
                {
                    _internalLastTimestamp = DateTime.Now.Ticks;
                    navMapFeed.Start().Wait();

                    OnPropertyChanged(nameof(IsFeedActive));
                    while ((!token.IsCancellationRequested && cancellationTokenSource != null))
                    {
                        Thread.Sleep(500);
                        if (!this.Robot.IsConnected) break;
                        if ((this.Robot.Status.IsInCalmPowerMode) || (this.Robot.Status.IsOnCharger))
                            _internalLastTimestamp = DateTime.Now.Ticks;

                        if ((DateTime.Now.Ticks - this._internalLastTimestamp) > (Frequency * 1000 * 10000))
                        {
                            navMapFeed.End().Wait();
                            Thread.Sleep(500);
                            if (!token.IsCancellationRequested && cancellationTokenSource != null)
                            {
                                _internalLastTimestamp = DateTime.Now.Ticks;
                                navMapFeed.Start().Wait();
                            }
                        }
                    }
                }).ConfigureAwait(false);
            }
            catch (Exception error)
            {
            }
            finally
            {
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
            OnPropertyChanged(nameof(IsFeedActive));
        }

        /// <summary>
        /// Stops the nav map feed.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task StopFeed()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();
            cancellationTokenSource = null;

            if (this.navMapFeed.IsActive)
                await navMapFeed.End().ConfigureAwait(false);

            OnPropertyChanged(nameof(IsFeedActive));
        }

        /// <summary>
        /// Called when disconnecting
        /// </summary>
        /// <param name="forced">if set to <c>true</c> the shutdown is forced due to lost connection.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        internal override Task Teardown(bool forced)
        {
            return StopFeed();
        }
    }
}