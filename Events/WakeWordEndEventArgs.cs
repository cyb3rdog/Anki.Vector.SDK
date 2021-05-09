// <copyright file="WakeWordEndEventArgs.cs" company="Wayne Venables">
//     Copyright (c) 2020 Wayne Venables. All rights reserved.
// </copyright>

using Anki.Vector.Types;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Anki.Vector.Events
{
    /// <summary>
    /// Wake word end event args.
    /// This is sent when the response (and potential intent) is received from the cloud.  This is sent before the UserIntent event (if any).
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WakeWordEndEventArgs : WakeWordEventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the intent was heard.
        /// True if a sentence was recognized with an associated intent; false otherwise.
        /// </summary>
        public bool IntentHeard { get; }

        /// <summary>
        /// Gets the intent and parameters as a JSON formatted string.
        /// This is empty if an intent was not heard (IntentHeard is false), or if the client does not have control.
        /// In the later case, a UserIntent event with the intent JSON data will be sent.
        /// </summary>
        public string IntentJson { get; }


        public IntentData Intent { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WakeWordEndEventArgs" /> class.
        /// </summary>
        /// <param name="e">The event.</param>
        internal WakeWordEndEventArgs(ExternalInterface.Event e) : base(e)
        {
            IntentHeard = e.WakeWord.WakeWordEnd.IntentHeard;
            IntentJson = e.WakeWord.WakeWordEnd.IntentJson;
            Intent = ParseUserIntent(e.WakeWord.WakeWordEnd.IntentJson);
        }

        public static IntentData ParseUserIntent(string intentJson)
        {
            if (string.IsNullOrEmpty(intentJson)) return null;
            try
            {
                JObject json = JObject.Parse(intentJson);
                JToken token = json.SelectToken("type");
                if (token == null) return null;

                return Intents.DefaultIntents.GetIntentBy(IntentData.Property.IntentType, token.ToString().ToLower());
            }
            catch
            {
                return null;
            }
        }
    }
}
