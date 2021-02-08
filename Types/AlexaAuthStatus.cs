// <copyright file="AlexaAuthStates.cs" company="Wayne Venables">
//     Copyright (c) 2020 cyb3rdog. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Anki.Vector.Types
{
    /// <summary>
    /// Alexa authorization state
    /// </summary>
    public enum AlexaAuthState
    {
        /// <summary>
        /// Invalid/error/versioning issue
        /// </summary>
        AuthorizationInvalid = 0,
        /// <summary>
        /// Not opted in, or opt-in attempted but failed
        /// </summary>
        NotAuthenticated = 1,
        /// <summary>
        /// Opted in, and attempting to authorize
        /// </summary>
        RequestingAuthorization = 2,
        /// <summary>
        /// Opted in, and waiting on the user to enter a code
        /// </summary>
        WaitingForCode = 3,
        /// <summary>
        /// Opted in, and authorized / in use
        /// </summary>
        Authorized = 4,
    }

    /// <summary>
    /// Alexa authorization event args
    /// </summary>
    /// <seealso cref="Anki.Vector.Events.RobotEventArgs" />
    [Serializable]
    public class AlexaAuthStatus
    {
        /// <summary>
        /// Gets the state of the alexa authentication.
        /// </summary>
        public AlexaAuthState AuthState { get; }

        /// <summary>
        /// Gets the extra data associated with this event.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2235:Mark all non-serializable fields", Justification = "Invalid")]
        public string Extra { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlexaAuthStates"/> class.
        /// </summary>
        /// <param name="e">The e.</param>
        internal AlexaAuthStatus(ExternalInterface.AlexaAuthStateResponse alexaAuthStateResponse)
        {
            AuthState = (AlexaAuthState)alexaAuthStateResponse.AuthState;
            Extra = alexaAuthStateResponse.Extra;
        }
    }
}