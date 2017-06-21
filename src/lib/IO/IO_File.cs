/*
 * // Create a new FileSystemWatcher and set its properties.
FileSystemWatcher watcher = new FileSystemWatcher();
watcher.Path = args[1];

// Watch for changes in LastAccess and LastWrite times, and
//   the renaming of files or directories. 
watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
   | NotifyFilters.FileName | NotifyFilters.DirectoryName;

// Only watch text files.
watcher.Filter = "*.txt";

// Add event handlers.
watcher.Changed += new FileSystemEventHandler(OnChanged);
watcher.Created += new FileSystemEventHandler(OnChanged);
watcher.Deleted += new FileSystemEventHandler(OnChanged);
watcher.Renamed += new RenamedEventHandler(OnRenamed);
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass;
using LamedalCore.zz;

namespace LamedalCore.lib.IO
{
    /// <summary>
    ///  Input Outpuf file methods
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, GroupName = "File")]
    public sealed class IO_File
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        private readonly IO_ _io = LamedalCore_.Instance.lib.IO;

        /// <summary>
        /// Gets the <see cref="T:System.IO.FileAttributes" /> of the file on the path.
        /// </summary>
        /// <param name="fileName">The path to the file.</param>
        /// <param name="hasAttribute">The has attribute.</param>
        /// <returns>The <see cref="T:System.IO.FileAttributes" /> of the file on the path.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="fileName" /> is empty, contains only white spaces, or contains invalid characters.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="fileName" /> is in an invalid format.</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="fileName" /> represents a file and is invalid, such as being on an unmapped drive, or the file cannot be found.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException"><paramref name="fileName" /> represents a directory and is invalid, such as being on an unmapped drive, or the directory cannot be found.</exception>
        /// <exception cref="T:System.IO.IOException">This file is being used by another process.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Pure]
        public bool Attributes_Check(string fileName, FileAttributes hasAttribute = FileAttributes.Normal)
        {
            FileAttributes att = Attributes_Get(fileName);
            return ((att & hasAttribute) == hasAttribute);
        }


        /// <summary>
        /// Gets the <see cref="T:System.IO.FileAttributes" /> of the file on the path.
        /// </summary>
        /// <param name="fileName">The path to the file.</param>
        [Pure]
        public FileAttributes Attributes_Get(string fileName)
        {
            FileAttributes att = File.GetAttributes(fileName);
            return att;
        }

        /// <summary>
        /// Sets the specified <see cref="T:System.IO.FileAttributes" /> of the file on the specified path.
        /// </summary>
        /// <param name="filename">The path to the file.</param>
        /// <param name="setAttributes">A bitwise combination of the enumeration values.</param>
        /// <exception cref="T:System.ArgumentException"><paramref name="filename" /> is empty, contains only white spaces, contains invalid characters, or the file attribute is invalid.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="filename" /> is in an invalid format.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive).</exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file cannot be found.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException"><paramref name="filename" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="filename" /> specified a directory.-or- The caller does not have the required permission.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Attributes_Set(string filename, FileAttributes setAttributes)
        {
            File.SetAttributes(filename, setAttributes);
        }

        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is allowed.
        /// </summary>
        /// <param name="sourceFile">The file to copy.</param>
        /// <param name="destinationFile">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">if set to <c>true</c> [over write].</param>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission. -or-<paramref name="destinationFile" /> is read-only.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="sourceFile" /> or <paramref name="destinationFile" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.-or- <paramref name="sourceFile" /> or <paramref name="destinationFile" /> specifies a directory.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="sourceFile" /> or <paramref name="destinationFile" /> is null.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path specified in <paramref name="sourceFile" /> or <paramref name="destinationFile" /> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="T:System.IO.FileNotFoundException"><paramref name="sourceFile" /> was not found.</exception>
        /// <exception cref="T:System.IO.IOException"><paramref name="sourceFile" /> exists and <paramref name="overwrite" /> is false.-or- An I/O error has occurred.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="sourceFile" /> or <paramref name="destinationFile" /> is in an invalid format.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Copy(string sourceFile, string destinationFile, bool overwrite = false)
        {
            File.Copy(sourceFile, destinationFile, overwrite);

        }

        #region Config
        /// <summary>Calculate the Configuration filename.</summary>
        /// <param name="file">The config filename. Leave blank to use the default one.</param>
        /// <returns></returns>
        public string Filename_Config(string file = "")
        {
            if (file == "")
            {
              var folder = _io.Folder.Path_Application();
              file = folder + "Config.json";
            }
            return file;
        }

        /// <summary>Return the Configuration filename as string.</summary>
        /// <returns></returns>
        public string Config_Load(string file = "")
        {
            file = _io.File.Filename_Config(file);
            var jsonStr = _io.RW.File_Read2Str(file, false);
            return jsonStr;
        }

        /// <summary>Return the Configuration filename as object of type T.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file">The file.</param>
        /// <param name="autoSave">if set to <c>true</c> [automatic save].</param>
        /// <returns></returns>
        public T Config_Load<T>(string file = "", bool autoSave = true)
        {
            T result;
            var jsonStr = _lamed.lib.IO.File.Config_Load(file);
            if (jsonStr == "")
                 result = _lamed.Types.Object.Create<T>(); // Create the object with default values
            else result = _lamed.lib.IO.Json.Convert_ToType<T>(jsonStr);

            if (autoSave) Config_Save(result, file);  // The config specification might have changed. This will ensure new properties are streamed to the config file.
            return result;
        }

        /// <summary>Saves the configuration file.</summary>
        /// <param name="lines">The lines.</param>
        public void Config_Save(string lines, string file = "")
        {
            if (file == "") file = _io.File.Filename_Config();
            _io.RW.File_Write(file, lines, enIO_WriteAction.OverWriteFile);
        }
        /// <summary>Saves the Object to the configuration file.</summary>
        public void Config_Save<T>(T Object, string file = "")
        {
            var jsonStr = _lamed.lib.IO.Json.Convert_FromObject(Object);
            _io.File.Config_Save(jsonStr, file);
        }
        private Object configLock = new Object();

        /// <summary>Configuration file for unit tests.</summary>
        /// <param name="folderApplication">The folder application.</param>
        /// <param name="folderTestCases">The folder where test cases are located.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="configFile">The configuration file.</param>
        /// <returns></returns>
        [Test_IgnoreCoverage(enCode_TestIgnore.CodeIsUsedForTesting)]
        public bool Config_UnitTests(out string folderApplication, out string folderTestCases, out pcTest_Configuration config, out string configFile)
        {
            // Protected area
            var result = true;
            lock (configLock)
            {
                configFile = _lamed.lib.IO.File.Filename_Config();
                config = _lamed.lib.IO.File.Config_Load<pcTest_Configuration>();
                folderTestCases = config.Folder_TestCase;

                // Check if values are filled in
                result = (config.Folder_TestCase.zIsNullOrEmpty() == false);
                if (result) if (_lamed.lib.IO.Folder.Exists(folderTestCases) == false) result = false;

                // Following will test if the config file can be loaded
                // ===========================================================
                folderApplication = _lamed.lib.IO.Folder.Path_Application();
                if (result == false)  
                {
                    // Unit tests
                    // The following code will not be tested by unit tests. It will only execute the first time tests are run on a new computer.
                    if (_firstRun == false) return false; // Only run this check once for all test cases
                    _firstRun = false;
                    _lamed.lib.IO.File.Config_Save(config); // Save the file to ensure new properties are available 
                    _lamed.lib.Command.Execute_Explorer(folderApplication);
                    _lamed.lib.Command.Sleep(1500);
                    _lamed.lib.Command.Execute_Notepad("Config.json", folderApplication, true);
                }
            }
            return result;
        }
        private bool _firstRun = true;  // Make sure the config is opened only once.
        #endregion

        /// <summary>
        /// Deletes the specified file if it exists. Return false if file does not exist.
        /// </summary>
        /// <param name="fileName">The name of the file to be deleted. Wildcard characters are not supported.</param>
        /// <exception cref="T:System.ArgumentException"><paramref name="fileName" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="fileName" /> is null.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="T:System.IO.IOException">The specified file is in use. -or-There is an open handle on the file, and the operating system is Windows XP or earlier. This open handle can result from enumerating directories and files. For more information, see How to: Enumerate Directories and Files.</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="fileName" /> is in an invalid format.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool Delete(string fileName)
        {
            // Test if folder exists
            var folder = _io.Parts.Folder(fileName);
            if (_io.Folder.Exists(folder) == false) return false;

            // Test if file exists
            if (Exists(ref fileName) == false) return false;

            File.Delete(fileName);
            return true;
        }

        /// <summary>Deletes the files in the folder.</summary>
        /// <param name="folder">The folder</param>
        /// <param name="searchPattern">The search pattern setting. Default value = "*".</param>
        /// <param name="searchOption">The search option setting. Default value = SearchOption.TopDirectoryOnly.</param>
        public int DeleteFiles(string folder, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            IList<string> files = _io.Search.Files(folder, searchPattern, searchOption);
            return DeleteFiles(files);
        }

        /// <summary>Deletes the files in the folder.</summary>
        /// <param name="fileList">The file list.</param>
        public int DeleteFiles(IList<string> fileList)
        {
            var result = 0;
            foreach (var file in fileList)
            {
                if (Delete(file)) result++;
            }
            return result;
        }

        /// <summary>Check if the specified file Exists.</summary>
        /// <param name="file">The file or folder. #path/#</param>
        /// <param name="extention">The extention. if this extention is not part of the file it will be added before the test.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Pure]
        public bool Exists([NotNull]ref string file, string extention = "")
        {
            file = _io.Parts.Ext_Change(file,extention);
            bool result = File.Exists(file);

            return result;
        }

        /// <summary>Check if the specified file Exists.</summary>
        /// <param name="file">The file or folder. #path/#</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Pure]
        public bool Exists([NotNull]string file)
        {
            bool result = File.Exists(file);
            return result;
        }


        /// <summary>If file exists, gets the next available no for the filename. Method is optimised for many files</summary>
        /// <param name="file">The file path</param>
        /// <param name="numberWidth">Width of the number.</param>
        /// <param name="jumpFactor">The jump factor.</param>
        /// <returns>string</returns>
        /// <exception cref="System.ArgumentException">
        /// The pattern must include an index place-holder.
        /// or
        /// The jump factor must be 2 or greater.
        /// </exception>
        [MustUseReturnValue("Use the return value to for a new unique name.")]
        public string Exists_GetNextNo(string file, int numberWidth = 4, int jumpFactor = 2)
        {
            // Short-cut if already available
            if (Exists(ref file) == false) return file;
            if (jumpFactor < 2) throw new ArgumentException("The jump factor must be 2 or greater.", nameof(jumpFactor));

            int countSlow = 1, countFast = 2;
            while (Exists(_FormatNo(file, countFast, numberWidth))) // With every loop we jump faster forward
            {
                countSlow = countFast;
                countFast *= 2;
            }

            // We have found a unigue name range with the fast counter, now let us work backwords to ensure it is the next available number.
            while (countFast != countSlow + 1)
            {
                int testNo = (countFast + countSlow) / 2;
                if (Exists(_FormatNo(file, testNo, numberWidth))) countSlow = testNo;
                else countFast = testNo;
            }
            return _FormatNo(file, countFast, numberWidth);
        }

        /// <summary>Formats the file no with leading '0'. This method is used internally</summary>
        /// <param name="pathAndFile">The path and file.</param>
        /// <param name="no">The no.</param>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public string _FormatNo(string pathAndFile, int no, int width = 4)
        {
            var ext = _lamed.lib.IO.Parts.Ext(pathAndFile);
            var file = _lamed.lib.IO.Parts.FolderAndFile(pathAndFile);
            var result = file + "_" + _lamed.Types.Convert.Str_FromInt(no, width) + ext;
            return result;
        }

        //private string Exists_GetNextNoSearch(string pattern = "_{0}", int jumpFactor = 2)
        //{
        //    // Test parameters
        //    string tmp = string.Format(pattern, 1);
        //    if (tmp == pattern) throw new ArgumentException("The pattern must include an index place-holder.", nameof(pattern));
        //    if (jumpFactor < 2) throw new ArgumentException("The jump factor must be 2 or greater.", nameof(jumpFactor));

        //    if (!Exists(tmp)) return tmp; // <--------------------------------

        //    int countSlow = 1, countFast = 2; 
        //    while (Exists(string.Format(pattern, countFast))) // With every loop we jump faster forward
        //    {
        //        countSlow = countFast;
        //        countFast *= 2;
        //    }

        //    // We have found a unigue name range with the fast counter, now let us work backwords to ensure it is the next available number.
        //    while (countFast != countSlow + 1)
        //    {
        //        int testNo = (countFast + countSlow) / 2;
        //        if (Exists(string.Format(pattern, testNo))) countSlow = testNo;
        //        else countFast = testNo;
        //    }
        //    return string.Format(pattern, countFast);
        //}

        ///// <summary>
        ///// Function to get assembly path.
        ///// </summary>
        ///// <param name="name">The assembly name</param>
        ///// <returns>string</returns>
        //[Pure]
        //public string FilePath_Assembly(AssemblyName name)
        //{
        //    string result = "";
        //    {
        //        result = Assembly.Load(name).Location;
        //    }
        //    return _io.Parts._Format2Slash(result);
        //}

        /// <summary>
        /// Creates a uniquely named, zero-byte temporary file on disk and returns the full path of that file.
        /// </summary>
        /// <returns>The full path of the temporary file.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs, such as no unique temporary file name is available.- or -This method was unable to create a temporary file.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public string FilePath_Temporary()
        {
            return _io.Parts._Format2Slash(Path.GetTempFileName());
        }

        /// <summary>
        /// Informations about the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        [Pure]
        public FileInfo FileInfo(string filename)
        {
            FileInfo result = null;
            if (Exists(filename)) result = new FileInfo(filename);
            return result;
        }

        /// <summary>
        /// Moves a specified file to a new location, providing the option to specify a new file name.
        /// </summary>
        /// <param name="sourceFile">The source file.</param>
        /// <param name="destinationFile">The destination file.</param>
        /// <exception cref="T:System.IO.IOException">The destination file already exists.-or-<paramref name="sourceFile" /> was not found.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="sourceFile" /> or <paramref name="destinationFile" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="sourceFile" /> or <paramref name="destinationFile" /> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="F:System.IO.Path.InvalidPathChars" />.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="T:System.IO.DirectoryNotFoundException">The path specified in <paramref name="destinationFile" /> or <paramref name="destinationFile" /> is invalid, (for example, it is on an unmapped drive).</exception>
        /// <exception cref="T:System.NotSupportedException"><paramref name="sourceFile" /> or <paramref name="destinationFile" /> is in an invalid format.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Move(string sourceFile, string destinationFile)
        {
            File.Move(sourceFile, destinationFile);
        }

        /// <summary>Return the timers of the specified file name.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileTime">The file time.</param>
        /// <param name="trim">The trim.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        [Pure]
        public DateTime Time(string fileName, enIO_FileActionTime fileTime = enIO_FileActionTime.Creation, enDateTimeTrim trim = enDateTimeTrim.Trim2Second)
        {
            DateTime result = _lamed.Types.DateTime.null_;
            var _time = _lamed.Types.DateTime;
            switch (fileTime)
            {
                case enIO_FileActionTime.Creation:   result = _time.Trim(File.GetCreationTime(fileName), trim); break;
                case enIO_FileActionTime.LastAccess: result = _time.Trim(File.GetLastAccessTime(fileName), trim); break;
                case enIO_FileActionTime.LastWrite: result = _time.Trim(File.GetLastWriteTime(fileName), trim); break;
                default: throw new Exception($"Argument '{nameof(fileTime)}' error.");
            }
            return result;
        }

        /// <summary>
        /// Calculates the file hash.
        /// </summary>
        /// <param name="filename">Name of the file.</param>
        /// <returns></returns>
        [Pure]
        private byte[] Hash_MD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }

        public string Hash_ToStr(string filename)
        {
            byte[] hash = Hash_MD5(filename);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (var bt in hash)
            {
                sb.Append(bt.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Determines whether the specified local path is a file.
        /// </summary>
        /// <param name="localPathOrFile">The local path or file.</param>
        /// <returns></returns>
        public bool IsFile(string localPathOrFile)
        {
            var attr = Attributes_Get(localPathOrFile);
            return ((attr & FileAttributes.Directory) != FileAttributes.Directory);
        }
    }
}
