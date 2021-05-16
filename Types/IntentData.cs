using Anki.Vector.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Anki.Vector.Types
{
    internal class IntentComparer : IComparer<IntentData>
    {
        internal IntentData.Property compareProperty;

        public IntentComparer(IntentData.Property compareProperty)
        {
            this.compareProperty = compareProperty;
        }

        public int Compare(IntentData x, IntentData y)
        {
            switch (this.compareProperty)
            {
                case IntentData.Property.SdkId: return ((x.IntentSDKId != null) ? (int)x.IntentSDKId : -1).CompareTo(((y.IntentSDKId != null) ? (int)y.IntentSDKId : -1));
                case IntentData.Property.IntentType: return (x.IntentType).CompareTo(y.IntentType);
                case IntentData.Property.IntentName: return (x.IntentName).CompareTo(y.IntentName);
                case IntentData.Property.IntentLabel: return (x.IntentLabel).CompareTo(y.IntentLabel);
                case IntentData.Property.MinimumVersion:
                default: return x.MinVersion.CompareTo(y.MinVersion);
            }
        }
    }

    public class IntentData
    {
        public enum Property
        {
            SdkId,
            IntentType,
            IntentName,
            IntentLabel,
            MinimumVersion
        }

        private static readonly Version defaultVersion = new Version("0.0.0.0");

        [JsonProperty("sdk_id")]
        public uint? IntentSDKId { get; set; }

        [JsonProperty("sdk_type")]
        public string IntentType { get; set; }

        [JsonProperty("intent_name")]
        public string IntentName { get; set; }

        [JsonProperty("description")]
        public string IntentLabel { get; set; }

        [JsonProperty("min_version")]
        public string MinVersion { get; set; }

        [JsonIgnore]
        public Version Version
        {
            get
            {
                if ((!string.IsNullOrEmpty(MinVersion)) && (Version.TryParse(this.MinVersion, out Version result)))
                    return result;
                return defaultVersion;
            }
        }

        [JsonIgnore]
        public bool IsDefault { get; private set; }

        public IntentData() { }
        public IntentData(uint? id, string type, string label, string name = null, string version = null, bool isDefault = false)
        {
            this.IntentSDKId = id;
            this.IntentType = type;
            this.IntentName = name;
            this.IntentLabel = label;
            this.MinVersion = version;
            this.IsDefault = isDefault;
        }

        public override string ToString()
        {
            return this.IntentName;
        }
    }


    public class Intents : List<IntentData>
    {
        private static Intents _defaultIntents;
        public static Intents DefaultIntents
        {
            get
            {
                if (_defaultIntents == null)
                    _defaultIntents = GetDefaultIntents();
                return _defaultIntents;
            }
        }

        public void Add(uint? id, string type, string label, string name, string version = null)
        {
            this.Add(new IntentData(id, type, label, name, version, false));
        }

        public static Intents LoadFromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Intents>(jsonData, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore });
        }

        public string SaveToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Include });
        }

        public static Intents GetDefaultIntents()
        {
            Intents result = new Intents();

            result.Add(new IntentData(00, "character_age", "What is your Age?", "intent_character_age", "1.3.0.2510", true));
            result.Add(new IntentData(01, "check_timer", "Check the Timer", "intent_clock_checktimer", null, true));
            result.Add(new IntentData(02, "explore_start", "Go Explore", "intent_explore_start", null, true));
            result.Add(new IntentData(03, "global_stop", "Stop the Timer", "intent_global_stop_extend", null, true));
            result.Add(new IntentData(04, "greeting_goodbye", "Greeting Goodbye", "intent_greeting_goodbye", null, true));
            result.Add(new IntentData(05, "greeting_goodmorning", "Greeting Good Morning", "intent_greeting_goodmorning", null, true));
            result.Add(new IntentData(06, "greeting_hello", "Greeting Hello", "intent_greeting_hello", null, true));
            result.Add(new IntentData(07, "imperative_abuse", "I Hate You", "intent_imperative_abuse", null, true));
            result.Add(new IntentData(08, "imperative_affirmative", "Yes!", "intent_imperative_affirmative", null, true));
            result.Add(new IntentData(09, "imperative_apology", "I'm Sorry", "intent_imperative_apologize", null, true));
            result.Add(new IntentData(10, "imperative_come", "Come Here", "intent_imperative_come", null, true));
            result.Add(new IntentData(11, "imperative_dance", "Dance", "intent_imperative_dance", null, true));
            result.Add(new IntentData(12, "imperative_fetchcube", "Fetch Your Cube", "intent_imperative_fetchcube", "1.1.0.2106", true));
            result.Add(new IntentData(13, "imperative_findcube", "Find Your Cube", "intent_imperative_findcube", "1.1.0.2106", true));
            result.Add(new IntentData(14, "imperative_lookatme", "Look At Me", "intent_imperative_lookatme", null, true));
            result.Add(new IntentData(15, "imperative_love", "I love You", "intent_imperative_love", null, true));
            result.Add(new IntentData(16, "imperative_praise", "Good Robot", "intent_imperative_praise", null, true));
            result.Add(new IntentData(17, "imperative_negative", "No!", "intent_imperative_negative", null, true));
            result.Add(new IntentData(18, "imperative_scold", "Bad Robot", "intent_imperative_scold", null, true));
            result.Add(new IntentData(19, "imperative_volumelevel", "Set Volume to...", "intent_imperative_volumelevel_extend", "1.2.1.2343", true));
            result.Add(new IntentData(20, "imperative_volumeup", "Volume Up", "intent_imperative_volumeup", "1.2.1.2343", true));
            result.Add(new IntentData(21, "imperative_volumedown", "Volume Down", "intent_imperative_volumedown", "1.2.1.2343", true));
            result.Add(new IntentData(22, "movement_forward", "Go Forward", "intent_imperative_forward", "1.2.1.2343", true));
            result.Add(new IntentData(23, "movement_backward", "Go Backward", "intent_imperative_backup", "1.2.1.2343", true));
            result.Add(new IntentData(24, "movement_turnleft", "Turn Left", "intent_imperative_turnleft", "1.2.1.2343", true));
            result.Add(new IntentData(25, "movement_turnright", "Turn Right", "intent_imperative_turnright", "1.2.1.2343", true));
            result.Add(new IntentData(26, "movement_turnaround", "Turn Around", "intent_imperative_turnaround", "1.2.1.2343", true));
            result.Add(new IntentData(27, "knowledge_question", "I have a Question", "intent_play_cantdo", null, true));
            result.Add(new IntentData(28, "names_ask", "What's my name?", "intent_names_ask", null, true));
            result.Add(new IntentData(29, "play_anygame", "Play a Game", "intent_play_anygame", null, true));
            result.Add(new IntentData(30, "play_anytrick", "Play a Trick", "intent_play_anytrick", null, true));
            result.Add(new IntentData(31, "play_blackjack", "Play Blackjack", "intent_play_blackjack", null, true));
            result.Add(new IntentData(32, "play_fistbump", "Fist Bump", "intent_play_fistbump", null, true));
            result.Add(new IntentData(33, "play_pickupcube", "Pick up Your Cube", "intent_play_pickupcube", "1.1.0.2106", true));
            result.Add(new IntentData(34, "play_popawheelie", "Pop a Wheelie", "intent_play_popawheelie", "1.1.0.2106", true));
            result.Add(new IntentData(35, "play_rollcube", "Roll Your Cube", "intent_play_rollcube", "1.1.0.2106", true));
            result.Add(new IntentData(36, "seasonal_happyholidays", "Happy Holidays", "intent_seasonal_happyholidays", "1.2.1.2343", true));
            result.Add(new IntentData(37, "seasonal_happynewyear", "Happy New Year", "intent_seasonal_happynewyear", "1.2.1.2343", true));
            result.Add(new IntentData(38, "set_timer", "Set Timer for...", "intent_clock_settimer_extend", null, true));
            result.Add(new IntentData(39, "show_clock", "What Time Is It?", "intent_clock_time", null, true));
            result.Add(new IntentData(40, "take_a_photo", "Take a Selfie", "intent_photo_take_extend", null, true));
            result.Add(new IntentData(41, "weather_response", "What is the Weather?", "intent_weather_extend", null, true));

            return result;
        }

        public void SortIntents(IntentData.Property sortProperty = IntentData.Property.IntentName)
        {
            this.Sort(new IntentComparer(sortProperty));
        }

        public int IndexOf(IntentData.Property property, object propertyValue)
        {
            for (int i = 0; i < this.Count; i++)
            {
                switch (property)
                {
                    case IntentData.Property.SdkId: if (this[i].IntentSDKId == (uint?)propertyValue) return i; else continue;
                    case IntentData.Property.IntentType: if (this[i].IntentType.ToLower() == propertyValue.ToString().ToLower().Trim()) return i; else continue;
                    case IntentData.Property.IntentName: if (this[i].IntentName.ToLower() == propertyValue.ToString().ToLower().Trim()) return i; else continue;
                    case IntentData.Property.IntentLabel: if (this[i].IntentLabel.ToLower() == propertyValue.ToString().ToLower().Trim()) return i; else continue;
                    case IntentData.Property.MinimumVersion:
                    default: if (this[i].MinVersion.ToLower() == propertyValue.ToString().ToLower().Trim()) return i; else continue;
                }
            }
            return -1;
        }
        public bool Contains(IntentData.Property property, object propertyValue)
        {
            return this.IndexOf(property, propertyValue) != -1;
        }
        public IntentData GetIntentBy(IntentData.Property property, object propertyValue)
        {
            int index = this.IndexOf(property, propertyValue);
            return (index != -1) ? this[index] : null;
        }

        public List<string> ListAll(IntentData.Property property)
        {
            List<string> result = new List<string>();
            foreach (IntentData intent in this)
            {
                switch (property)
                {
                    case IntentData.Property.SdkId:
                        if ((intent.IntentSDKId != null) && (!result.Contains(intent.IntentSDKId.ToString()))) result.Add(intent.IntentSDKId.ToString());
                        break;
                    case IntentData.Property.IntentType:
                        if ((!string.IsNullOrEmpty(intent.IntentType)) && (!result.Contains(intent.IntentType.Sanitize()))) result.Add(intent.IntentType.Sanitize());
                        break;
                    case IntentData.Property.IntentName:
                        if ((!string.IsNullOrEmpty(intent.IntentName)) && (!result.Contains(intent.IntentName.Sanitize()))) result.Add(intent.IntentName.Sanitize());
                        break;
                    case IntentData.Property.IntentLabel:
                        if ((!string.IsNullOrEmpty(intent.IntentLabel)) && (!result.Contains(intent.IntentLabel.Sanitize()))) result.Add(intent.IntentLabel.Sanitize());
                        break;
                    case IntentData.Property.MinimumVersion:
                    default:
                        if ((!string.IsNullOrEmpty(intent.MinVersion)) && (!result.Contains(intent.MinVersion.Trim()))) result.Add(intent.MinVersion.Trim());
                        break;
                }
            }
            return result;
        }
    }

    internal static class StringExtensions
    {
        public static string Sanitize(this string text)
        {
            return Regex.Replace(text.Trim(), @"['’`<>{}&$]+", "");
        }
    }
}