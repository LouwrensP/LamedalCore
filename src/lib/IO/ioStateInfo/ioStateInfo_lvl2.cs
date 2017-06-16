using System.Collections.Generic;

namespace LamedalCore.lib.IO.ioStateInfo
{
    /// <summary>
    /// Lookup for 2 level string key and values to memory. This class should not be used directly.
    /// </summary>
    public sealed class ioStateInfo_lvl2
    {
        // This is not a singleton because this class must be generated from json strings

        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        //public string FileName;
        public readonly Dictionary<string,ioStateInfo_lvl1> ClassDic = new Dictionary<string, ioStateInfo_lvl1>();

        /// <summary>Add data to the structure.</summary>
        /// <param name="Heading">The heading.</param>
        /// <param name="lvl1Name">Name of the LVL1.</param>
        /// <param name="jsonStr">The json string.</param>
        public void Data_Add(string Heading, string lvl1Name, string jsonStr)
        {
            ioStateInfo_lvl1 state;
            if (ClassDic.TryGetValue(Heading, out state) == false)
            {
                // Need unit testing. (Difficult to test next two lines because the state is saved).
                state = new ioStateInfo_lvl1();
                ClassDic[Heading] = state;
            }
            state.Data_Add(lvl1Name, jsonStr);
        }

        /// <summary>Get data from the structure</summary>
        /// <param name="Heading">The heading.</param>
        /// <param name="lvl1Name">Name of the LVL1.</param>
        /// <returns></returns>
        public string Data_Get(string Heading, string lvl1Name)
        {
            ioStateInfo_lvl1 state;
            if (ClassDic.TryGetValue(Heading, out state) == false) return "";

            var json = state.Data_Get(lvl1Name);
            return json;
        }

        /// <summary>Return level 1 names.</summary>
        /// <param name="Heading">The heading.</param>
        /// <returns></returns>
        public List<string> lvl1_Names(string Heading)
        {
            ioStateInfo_lvl1 state;
            if (ClassDic.TryGetValue(Heading, out state) == false) return new List<string>();
            return state.lvl1_Names();
        }

        public override string ToString()
        {
            string json = _lamed.lib.IO.Json.Convert_FromObject(this, true);
            return json;
        }
    }
}