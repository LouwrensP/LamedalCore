using System.Collections.Generic;
using LamedalCore.zz;

namespace LamedalCore.lib.IO.IO_StateInfo
{
    /// <summary>
    /// Lookup for string key value pairs in memory. This class should not be used directly.
    /// </summary>
    public sealed class IO_StateInfo_lvl1
    {
        public readonly Dictionary<string, string> DataDic = new Dictionary<string, string>();
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Adds a name value pair.</summary>
        /// <param name="lvl1Name">Name of the LVL1.</param>
        /// <param name="jsonStr">The json string.</param>
        public void Data_Add(string lvl1Name, string jsonStr)
        {
            DataDic[lvl1Name] = jsonStr;
        }

        /// <summary>Gets the name value pair for this level</summary>
        /// <param name="lvl1Name">Name of the LVL1.</param>
        /// <returns></returns>
        public string Data_Get(string lvl1Name)
        {
            string value;
            if (DataDic.TryGetValue(lvl1Name, out value)) return value;
            return "";
        }

        /// <summary>Remove the level name.</summary>
        /// <param name="lvl1Name">Name of the LVL1.</param>
        public void Data_Remove(string lvl1Name)
        {
            DataDic.Remove(lvl1Name);
        }

        public List<string> lvl1_Names()
        {
            List<string> keys, values;
            DataDic.zDictionary_KeysAndValues(out keys, out values);
            return keys;
        }

        public override string ToString()
        {
            string json = _lamed.lib.IO.Json.Convert_FromObject(this, true);
            return json;
        }
    }
}
