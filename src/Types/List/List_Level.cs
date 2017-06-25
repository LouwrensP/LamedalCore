using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.List
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class List_Level
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Query string list items.
        /// </summary>
        /// <param name="strList">The string list</param>
        /// <param name="level">The level</param>
        /// <param name="delimiter">The delimiter setting. Default value = &quot;.&quot;.</param>
        /// <param name="filter">The filter setting. Default value = &quot;&quot;.</param>
        /// <returns>List<string/></returns>
        public IList<string> Query(IList<string> strList, int level = 1, string delimiter = ".", string filter = "")
        {
            if (strList == null) throw new ArgumentNullException(nameof(strList));
            if (level < 1)
            {
                var ex = new ArgumentException("Error: Level parameter must always be > 0", nameof(level));
                ex.zLogLibraryMsg();
                throw  ex;
            }
            var result = new List<string>();
            foreach (var nspace in strList)
            {
                if (filter != "")
                {
                    if (nspace.Contains(filter) == false) continue;  // Filter the results
                }

                var spaces = nspace.zConvert_Array_FromStr(delimiter);
                if (level <= spaces.Count)
                {
                    var value = spaces[level - 1];
                    result.Add(value);
                }
            }
            return _lamed.Types.List.Action.Unique(result);
        }

        /// <summary>
        /// Return root level from the tree list.
        /// </summary>
        /// <param name="tree">The tree list</param>
        /// <param name="delimiter">The delimiter setting. Default value = &quot;.&quot;.</param>
        /// <returns>string</returns>
        public string Level1(IList<string> tree, string delimiter = ".")
        {
            var root1 = Query(tree, 1, delimiter);
            return root1[0];
        }

        /// <summary>
        /// Return root level from the tree list.
        /// </summary>
        /// <param name="tree">The tree list</param>
        /// <param name="delimiter">The delimiter setting. Default value = &quot;.&quot;.</param>
        /// <returns>string</returns>
        public string Level2(IList<string> tree, string delimiter = ".")
        {
            var root2 = Query(tree, 2, delimiter);
            return root2[0];
        }

        /// <summary>
        /// Return root level from the tree list.
        /// </summary>
        /// <param name="tree">The tree list</param>
        /// <param name="delimiter">The delimiter setting. Default value = &quot;.&quot;.</param>
        /// <returns>string</returns>
        public string Level1and2(IList<string> tree, string delimiter = ".")
        {
            var root1 = Level1(tree, delimiter);
            var root2 = Level2(tree, delimiter);
            var root = root1 + delimiter + root2;
            return root;
        }

        /// <summary>
        /// Return root level from the tree list.
        /// </summary>
        /// <param name="tree">The tree list</param>
        /// <param name="levels">The number of levels</param>
        /// <param name="delimiter">The delimiter setting. Default value = &quot;.&quot;.</param>
        /// <returns>string</returns>
        public string Levels(IList<string> tree, int levels = 1, string delimiter = ".")
        {
            if (levels < 1) return "";
            var root = Query(tree, 1, delimiter)[0];

            for (int ii = 2; ii <= levels; ii++)
            {
                var root1 = Query(tree, ii, delimiter)[0];
                root += delimiter + root1;
            }
            return root;
        }
    }
}
