using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.IO
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, GroupName = "Folder")]
    public sealed class IO_Folder
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        private readonly IO_ _io = LamedalCore_.Instance.lib.IO;

        /// <summary>
        /// Creates the path if it does not exists.
        /// </summary>
        /// <param name="path">The path. #path/#</param>
        public void Create(string path)
        {
            path = FixFolderName(path);
            if (Exists(path)) return;

            string[] folders = path.Split('/');

            var pathTest = "";
            foreach (string folder in folders)
            {
                if (pathTest != "") pathTest += "/";
                pathTest += folder;
                if (!Exists(pathTest))
                {
                    Directory.CreateDirectory(pathTest);
                }
            }
        }

        private string FixFolderName(string path)
        {
            if (path.Contains('\\')) path = path.Replace("\\", "/");
            if (_lamed.Types.String.Edit.SubStr_Right(path, 1) != "/") path += "/";
            return path;
        }

        /// <summary>
        /// Deletes an empty directory from a specified path.
        /// </summary>
        /// <param name="folder">The name of the empty directory to remove. This directory must be writable and empty.</param>
        /// <param name="recursive">if true delete sub-folders too</param>
        /// <exception cref="T:System.IO.IOException">A file with the same name and location specified by <paramref name="folder" /> exists.-or-The directory is the application's current working directory.-or-The directory specified by <paramref name="folder" /> is not empty.-or-The directory is read-only or contains a read-only file.-or-The directory is being used by another process.-or-There is an open handle on the directory, and the operating system is Windows XP or earlier. This open handle can result from directories. For more information, see How to: Enumerate Directories and Files.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="folder" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="folder" /> is null.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="folder" /> does not exist or could not be found.-or-<paramref name="folder" /> refers to a file instead of a directory.-or-The specified path is invalid (for example, it is on an unmapped drive).</exception>
        public void Delete(string folder, bool recursive = false)
        {
            if (Exists(folder) == false) return;

            Directory.Delete(folder, recursive);
        }

        /// <summary>
        /// Check if the specified folder Exists.
        /// </summary>
        /// <param name="folderOrFile">The file or folder. #path/#</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Pure]
        public bool Exists(string folderOrFile)
        {
            if (folderOrFile.zIsNullOrEmpty()) return false;
            string folder = _io.Parts.Folder(folderOrFile);
            var result = Directory.Exists(folder);
            return result;
        }

        /// <summary>
        /// Determines whether the specified local path is a folder.
        /// </summary>
        /// <param name="localPathOrFile">The local path or file.</param>
        /// <returns></returns>
        public bool IsFolder(string localPathOrFile)
        {
            var attr = _io.File.Attributes_Get(localPathOrFile);  // get the file attributes for file or directory
            return ((attr & FileAttributes.Directory) == FileAttributes.Directory);  //detect whether its a directory or file
        }

        /// <summary>
        /// Moves a file or a directory and its contents to a new location.
        /// </summary>
        /// <param name="sourceDirName">The path of the file or directory to move.</param>
        /// <param name="destDirName">The path to the new location for <paramref name="sourceDirName" />. If <paramref name="sourceDirName" /> is a file, then <paramref name="destDirName" /> must also be a file name.</param>
        /// <exception cref="T:System.IO.IOException">An attempt was made to move a directory to a different volume. -or- <paramref name="destDirName" /> already exists. -or- The <paramref name="sourceDirName" /> and <paramref name="destDirName" /> parameters refer to the same file or directory.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="sourceDirName" /> or <paramref name="destDirName" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="sourceDirName" /> or <paramref name="destDirName" /> is null.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path specified by <paramref name="sourceDirName" /> is invalid (for example, it is on an unmapped drive).</exception>
        public void Move(string sourceDirName, string destDirName)
        {
            Directory.Move(sourceDirName, destDirName);
        }

        /// <summary>Returns the absolute path for the specified path string.</summary>
        /// <param name="baseFolder">The file or directory for which to obtain absolute path information.</param>
        /// <param name="relativeFolder">The relative folder.</param>
        /// <returns>The fully qualified location of <paramref name="baseFolder" />, such as "C:\MyFile.txt".</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="baseFolder" /> is a zero-length string, contains only white space, or contains one or more of the invalid characters defined in <see cref="M:System.IO.Path.GetInvalidPathChars" />.-or- The system could not retrieve the absolute path.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permissions.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="baseFolder" /> is null.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="baseFolder" /> contains a colon (":") that is not part of a volume identifier (for example, "c:\").</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*" /></PermissionSet>
        [Pure]
        public string Path_Absolute(string baseFolder = "c:/folder1/folder2/", string relativeFolder = "../filename.txt")
        {
            var result = Path.GetFullPath(baseFolder + relativeFolder);
            return _io.Parts._Format2Slash(result);
        }

        /// <summary>
        /// Application folder
        /// </summary>
        /// <returns></returns>
        public string Path_Application()
        {
            string result = "";
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly == null) result = Directory.GetCurrentDirectory() +"/";   // This will give the folder for xunit tests
            else result = Path.GetDirectoryName(assembly.Location) + "/";  // This code is covered on .Net core environment

            return _io.Parts._Format2Slash(result);  // Change all '\' to '/'
        }

        ///// <summary>
        ///// Function to get assembly path.
        ///// </summary>
        ///// <param name="name">The assembly name</param>
        ///// <returns>string</returns>
        //[Pure]
        //public string Path_Assembly(AssemblyName name)
        //{
        //    return _lamed.Types.Assembly.To_FilePath(name); 
        //}

        /// <summary>
        /// Returns the path of the current user's temporary folder.
        /// </summary>
        /// <returns>The path to the temporary folder, ending with a backslash.</returns>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permissions.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public string Path_Temporary()
        {
            return _io.Parts._Format2Slash(Path.GetTempPath());
        }

    }
}
