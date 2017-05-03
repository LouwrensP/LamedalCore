using System.IO;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.IO
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action, GroupName = "Parts")]
    public sealed class IO_Parts
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Return the drive letter for a file path.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public string Drive(string filePath)
        {
            FileInfo fileInfo = _lamed.lib.IO.File.FileInfo(filePath);
            string drive = Path.GetPathRoot(fileInfo.FullName);
            return _Format2Slash(drive);
        }

        /// <summary>
        /// Returns the directory information for the specified path string.
        /// </summary>
        /// <param name="folderOrFile">The path of a file or directory.</param>
        /// <returns>Directory information for <paramref name="folderOrFile" />, or null if <paramref name="folderOrFile" /> denotes a root directory or is null. Returns <see cref="F:System.String.Empty" /> if <paramref name="folderOrFile" /> does not contain directory information.</returns>
        /// <exception cref="T:System.ArgumentException">The <paramref name="folderOrFile" /> parameter contains invalid characters, is empty, or contains only white spaces.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">NoteIn the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.The <paramref name="folderOrFile" /> parameter is longer than the system-defined maximum length.</exception>
        [Pure]
        public string Folder(string folderOrFile)
        {
            // If there is no extension -> presume it is a folder
            string result;
            if (folderOrFile.Contains(".") == false) result = folderOrFile;
            else result = Path.GetDirectoryName(folderOrFile);
            return _Format2Slash(result);
        }

        /// <summary>Formats the path for easier usage (convert all backslashes to '/'). Used internally</summary>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        public string _Format2Slash(string folder, int maxExtLength = 4)
        {
            var result = folder.Replace(@"\", "/");                 // Convert all '\' to '/' because it is less problematic
            var index = result.LastIndexOf('.');
            if (index + maxExtLength+1 < result.Length)
            {
                if (result.zSubStr_Right(1) != "/") result += "/"; // All folders should end with '/'. This makes it simple to add to it/
            }
            return result;
        }

        /// <summary>
        /// Returns the file name and and path without the extension
        /// </summary>
        /// <param name="folderFileAndExt">The path string from which to obtain the file name and extension.</param>
        /// <returns>The characters after the last directory character in <paramref name="folderFileAndExt" />. If the last character of <paramref name="folderFileAndExt" /> is a directory or volume separator character, this method returns <see cref="F:System.String.Empty" />. If <paramref name="folderFileAndExt" /> is null, this method returns null.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="folderFileAndExt" /> contains one or more of the invalid characters defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.</exception>
        [Pure]
        public string FolderAndFile(string folderFileAndExt)
        {
            return Folder(folderFileAndExt) + File_RemoveExtention(folderFileAndExt);
        }

        /// <summary>
        /// Retrun the file part of the specified folderAndFile.
        /// </summary>
        /// <param name="folderAndFile">The folderAndFile.</param>
        /// <returns></returns>
        [Pure]
        public string File(string folderAndFile)
        {
            if (folderAndFile.Contains(".") == false) return "";   // All files must have extentions. If there is none then assume it is a folder

            return Path.GetFileName(folderAndFile);
        }

        /// <summary>
        /// Function to return the file without the extention.
        /// </summary>
        /// <param name="filename">The folderAndFile</param>
        /// <returns>string</returns>
        [Pure]
        public string File_RemoveExtention(string filename)
        {
            if (filename.Contains(".") == false) return "";   // All files must have extentions. If there is none then assume it is a folder

            return Path.GetFileNameWithoutExtension(filename);
        }

        /// <summary>
        /// Changes the folderAndFile if a URL.
        /// </summary>
        /// <param name="folderAndFile">The folder and file.</param>
        /// <param name="newFileName">New name of the file.</param>
        /// <returns></returns>
        [Pure]
        public string File_Change(string folderAndFile, string newFileName)
        {
            var folder = Folder(folderAndFile);
            return folder + newFileName;
        }

        /// <summary>
        /// Function to add string to file name.
        /// </summary>
        /// <param name="folderAndFile">The folder and file</param>
        /// <param name="addThis2Name">The add this2 name</param>
        /// <returns>string</returns>
        public string File_Add2Name(string folderAndFile, string addThis2Name)
        {
            string folder, file, ext;
            FolderFileAndExt(folderAndFile, out folder, out file, out ext);

            return folder + file + addThis2Name + ext;
        }



        /// <summary>
        /// Returns the extension of the specified path string.
        /// </summary>
        /// <param name="folderAndFile">The path string from which to get the extension.</param>
        /// <returns>The extension of the specified path (including the period "."), or null, or <see cref="F:System.String.Empty" />. If <paramref name="folderAndFile" /> is null, <see cref="M:System.IO.Path.GetExtension(System.IsString)" /> returns null. If <paramref name="folderAndFile" /> does not have extension information, <see cref="M:System.IO.Path.GetExtension(System.IsString)" /> returns <see cref="F:System.IsString.Empty" />.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="folderAndFile" /> contains one or more of the invalid characters defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.</exception>
        public string Ext(string folderAndFile)
        {
            return Path.GetExtension(folderAndFile);
        }
        
        /// <summary>
        /// Changes the extension of a path string.
        /// </summary>
        /// <param name="folderAndFile">The path information to modify. The path cannot contain any of the characters defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.</param>
        /// <param name="newExt">The new ext.</param>
        /// <returns>The modified path information.On Windows-based desktop platforms, if <paramref name="folderAndFile" /> is null or an empty string (""), the path information is returned unmodified. If <paramref name="newExt" /> is null, the returned string contains the specified path with its extension removed. If <paramref name="folderAndFile" /> has no extension, and <paramref name="newExt" /> is not null, the returned path string contains <paramref name="newExt" /> appended to the end of <paramref name="folderAndFile" />.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="folderAndFile" /> contains one or more of the invalid characters defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.</exception>
        public string Ext_Change(string folderAndFile, string newExt = "xml")
        {
            if (newExt == "") return folderAndFile;
            return Path.ChangeExtension(folderAndFile, newExt);
        }

        /// <summary>
        /// Return the different Parts the specified folder and file.
        /// </summary>
        /// <param name="folderAndFile">The folder and file.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="file">The file.</param>
        /// <param name="ext">The ext.</param>
        public void FolderFileAndExt(string folderAndFile, out string folder, out string file, out string ext)
        {
            folder = Folder(folderAndFile);
            file = File_RemoveExtention(folderAndFile);
            ext = Ext(folderAndFile);
        }

        

    }
}
