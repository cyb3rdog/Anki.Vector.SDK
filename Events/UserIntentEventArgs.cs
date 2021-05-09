// <copyright file="UserIntentEventArgs.cs" company="Wayne Venables">
//     Copyright (c) 2020 Wayne Venables. All rights reserved.
// </copyright>

using Anki.Vector.Types;

namespace Anki.Vector.Events
{
    /// <summary>
    /// User intent event args.
    /// <para>Contains the voice command information from the event stream.  The <see cref="UserIntent"/> enumeration includes all of the voice
    /// commands that the SDK can intercept.</para>
    /// <para>Some UserIntents include information returned from the cloud and used when evaluating the voice commands.
    /// This information is available in the <see cref="IntentData"/> JSON formatted string.</para>
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class UserIntentEventArgs : RobotEventArgs
    {
        /// <summary>
        /// Gets the voice command user intent type
        /// </summary>
        public IntentData Intent { get; }

        /// <summary>
        /// Gets the  voice command specific data in JSON format.
        /// <para>Some voice commands contain information from processing.  For example, asking Vector "Hey Vector, what is the weather?" will
        /// return the current location and the weather forecast.</para>
        /// <para>This value will be empty for voice commands without additional information.</para>
        /// </summary>
        public string IntentData { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIntentEventArgs"/> class.
        /// </summary>
        /// <param name="e">The event.</param>
        internal UserIntentEventArgs(ExternalInterface.Event e) : base(e)
        {
            IntentData = e.UserIntent.JsonData;
            Intent = Intents.DefaultIntents.GetIntentBy(Types.IntentData.Property.SdkId, e.UserIntent.IntentId);
        }
    }
}
