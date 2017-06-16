using System.Diagnostics;
using LamedalCore.zz;

namespace LamedalCore.lib.IO.ioStateInfo
{
    /// <summary>
    /// Saves and load the 2 lvl string lookup key value data. This class should not be used directly.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public abstract class ioStateInfo_RW
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        protected string _FileName = "";
        protected string _jsonStr;


        /// <summary>Initialises the default file to save and load info from.</summary>
        /// <returns></returns>
        public bool InitialiseFile(string defaultFilename = "StateInfo_Classes.json")
        {
            if (_FileName == "")
            {
                if (defaultFilename == "") defaultFilename = "StateInfo_Classes.json";
                string folder = _lamed.lib.IO.Folder.Path_Application();
                FileName = folder + defaultFilename;
                return true;
            }
            return false;
        }

        /// <summary>Gets or sets the name of the file. When file is set and it exists, contents will be loaded.</summary>
        public virtual string FileName
        {
            get { return _FileName; }
            set
            {
                if (_FileName != "")
                {
                    "Error! You can set the file name only once. Call Dispose() first to set another file name".zException_Show();
                }
                _FileName = value;
                if (_lamed.lib.IO.File.Exists(value) == false)
                     Debug.WriteLine($"StateInfo file '{value}' does not exists!");
                else Debug.WriteLine($"StateInfo file '{value}' initialised.");

                // Read the state information if file exists
                _jsonStr = _lamed.lib.IO.RW.File_Read2Str(value, false);
            }
        }


        /// <summary>Saves the state info.</summary>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public void Save(bool overwrite = false)
        {
            if (_FileName == "")
            {
                // $"Error! FileName was not assigned to 'StateInfo_ClassesIO'.".zException_Show();
                Debug.WriteLine("Filename not assigned to IO_StateInfo_RW.");
                return;  // We will ignore the non-saving for now.
            }

            string state = this.ToString();
            _lamed.lib.IO.RW.File_Write(_FileName, state, overwrite);
        }

        /// <summary>Deletes the state information.</summary>
        public void Delete()
        {
            if (_FileName == "")
            {
                // $"Error! FileName was not assigned to 'StateInfo_ClassesIO'.".zException_Show();
                Debug.WriteLine("Filename not assigned to IO_StateInfo_RW.");
                return;  // We will ignore the non-saving for now.
            }
            _lamed.lib.IO.File.Delete(_FileName);
        }
    }
}
