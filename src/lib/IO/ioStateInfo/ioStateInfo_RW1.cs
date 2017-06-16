namespace LamedalCore.lib.IO.ioStateInfo
{
    public sealed class ioStateInfo_RW1 : ioStateInfo_RW
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        private ioStateInfo_lvl1 _state;

        /// <summary>Gets the state.</summary>
        public ioStateInfo_lvl1 State
        {
            get { return _state; }
        }

        /// <summary>Gets or sets the name of the file. When file is set and it exists, contents will be loaded.</summary>
        public override string FileName
        {
            set
            {
                base.FileName = value;
                if (_jsonStr == "") _state = new ioStateInfo_lvl1();   // This line need unit testing
                else _state = _lamed.lib.IO.Json.Convert_ToType<ioStateInfo_lvl1>(_jsonStr);
            }
        }

        /// <summary>Sync an object with the data</summary>
        /// <param name="keyName">The key name. If the key is not found, nothing will be set.</param>
        /// <param name="Object">The object.</param>
        /// <param name="defaultFile">The default file.</param>
        public void Data_Load(string keyName, object Object, string defaultFile = "StateInfo_lvl1.json")
        {
            var info = this;
            if (info.FileName == "") info.InitialiseFile(defaultFile);
            var personStr = info.State.Data_Get(keyName);
            if (personStr != "") _lamed.lib.IO.Json.Object_Set(Object, personStr);  // Name & Surname
        }

        /// <summary>Save the data to file.</summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="person">The person.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public void Data_Save(string keyName, object person, bool overwrite = false)
        {
            var info = this;
            var personStr = _lamed.lib.IO.Json.Convert_FromObject(person);
            info.State.Data_Add(keyName, personStr);
            info.Save(overwrite);
        }

        public override string ToString()
        {
            string json = _state.ToString();
            return json;
        }
    }
}
