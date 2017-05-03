using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.zz;

namespace LamedalCore.lib.IO
{
    public sealed class IO_Search
    {
        private readonly IO_ _io = LamedalCore_.Instance.lib.IO;

        /// <summary>
        /// Determines whether file exist in the search subfolders.
        /// </summary>
        /// <param name="searchFolders">The search folders</param>
        /// <param name="filename">The filename</param>
        /// <param name="folderAndFileFound">Return the folder + file found.</param>
        /// <returns>bool</returns>
        [BlueprintRule_MethodAliasDef(MirrorClass = typeof(IO_File), MirrorParameter1 = "filename")]
        public bool FileInSubFolders(IList<string> searchFolders, string filename, out string folderAndFileFound)
        {
            if (filename.zIsNullOrEmpty()) throw new ArgumentNullException(nameof(filename));

            foreach (var folder in searchFolders)
            {
                folderAndFileFound = folder + filename;
                if (_io.File.Exists(folderAndFileFound)) return true;
            }
            folderAndFileFound = "";
            return false;
        }

        /// <summary>
        /// Function to sub files from the path.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="searchPattern">The search pattern setting. Default value = &quot;*&quot;.</param>
        /// <param name="searchOption">The search option setting. Default value = SearchOption.TopDirectoryOnly.</param>
        /// <returns>IEnumerable<string/></returns>
        public IList<string> Files(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var result = Directory.GetFiles(path, searchPattern, searchOption).ToList();
            return result;
        }
        /// <summary>
        /// Function to sub folders from the path.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="searchPattern">The search pattern setting. Default value = &quot;*&quot;.</param>
        /// <param name="searchOption">The search option setting. Default value = SearchOption.TopDirectoryOnly.</param>
        /// <returns>IEnumerable<string/></returns>
        public IList<string> Folders(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var result = Directory.GetDirectories(path, searchPattern, searchOption);
            return result.Select(Format2Slash_InList()).ToList();
        }

        /// <summary>Formats the list and change all to '/'.</summary>
        /// <returns></returns>
        private Func<string, string> Format2Slash_InList()
        {
            //return x => IO.Parts._Format2Slash(x);  // This do not work
            return x => x.Replace(@"\", "/") + "/";
        }
    }
}
