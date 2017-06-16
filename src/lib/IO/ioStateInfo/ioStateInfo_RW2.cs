namespace LamedalCore.lib.IO.ioStateInfo
{
    public sealed class ioStateInfo_RW2 : ioStateInfo_RW
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        private ioStateInfo_lvl2 _state;

        /// <summary>Gets the state.</summary>
        public ioStateInfo_lvl2 State
        {
            get { return _state; }
        }

        /// <summary>Gets or sets the name of the file. When file is set and it exists, contents will be loaded.</summary>
        public override string FileName
        {
            set
            {
                base.FileName = value;
                if (_jsonStr == "") _state = new ioStateInfo_lvl2();  // This line need unit testing
                else _state = _lamed.lib.IO.Json.Convert_ToType<ioStateInfo_lvl2>(_jsonStr);
            }
        }

        /// <summary>Sync an object with the data</summary>
        /// <param name="keyName1">The key name1.</param>
        /// <param name="keyName2">The key name2.</param>
        /// <param name="Object">The object.</param>
        /// <param name="defaultFile">The default file.</param>
        public void Data_Load(string keyName1, string keyName2, object Object, string defaultFile = "StateInfo_lvl2.json")
        {
            // This method need to be improved in a way that will save a ref to Object to be updated when everyhting is saved to disk.
            // This need to happen automatically.
            // =====================================================================
            var info = this;
            if (info.FileName == "") info.InitialiseFile(defaultFile);
            var personStr = info.State.Data_Get(keyName1, keyName2);
            if (personStr != "") _lamed.lib.IO.Json.Object_Set(Object, personStr); // Name & Surname
        }

        /// <summary>Save the data to file.</summary>
        /// <param name="keyName1">Name of the key.</param>
        /// <param name="keyName2">The key name2.</param>
        /// <param name="person">The person.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public void Data_Save(string keyName1, string keyName2, object person, bool overwrite = false)
        {
            // This method need to be improved to have no parameters. 
            // It need update the referenced objects and save the new values to disk.
            // ========================================================================
            var info = this;
            var personStr = _lamed.lib.IO.Json.Convert_FromObject(person);
            info.State.Data_Add(keyName1, keyName2, personStr);
            info.Save(overwrite);
        }

        public override string ToString()
        {
            string json = _state.ToString();
            return json;
        }
    }
}
