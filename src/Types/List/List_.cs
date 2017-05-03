using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types.List
{
    /// <summary>
    /// List Types methods
    /// </summary>
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Link)]
    [Test_IgnoreCoverage(enTestIgnore.ClassIsNodeLink)]
    public sealed class List_
    {
        #region Action
        /// <summary>
        /// Gets the Action library methods.
        /// </summary>
        public List_Action Action
        {
            get { return _Action ?? (_Action = new List_Action()); }
        }
        private List_Action _Action;
        #endregion

        #region Convert
        public List_Convert Convert
        {
            get { return _Convert ?? (_Convert = new List_Convert()); }
        }
        private List_Convert _Convert;
        #endregion

        #region Dictionary
        /// <summary>
        /// Gets the Dictionary library methods.
        /// </summary>
        public Types_Dictionary Dictionary
        {
            get { return _typesDictionary ?? (_typesDictionary = new Types_Dictionary()); }
        }
        private Types_Dictionary _typesDictionary;
        #endregion

        #region Find
        /// <summary>
        /// List find methods.
        /// </summary>
        public List_Find Find
        {
            get { return _find ?? (_find = new List_Find()); }
        }
        private List_Find _find;
        #endregion

        #region Level
        /// <summary>
        /// Gets the Level library methods.
        /// </summary>
        public List_Level Level
        {
            get { return _Level ?? (_Level = new List_Level()); }
        }
        private List_Level _Level;
        #endregion

        #region Queue
        /// <summary>
        /// Gets the Queue library methods.
        /// </summary>
        public List_Queue Queue
        {
            get { return _Queue ?? (_Queue = new List_Queue()); }
        }
        private List_Queue _Queue;
        #endregion

        #region Stack
        /// <summary>
        /// Gets the Stack library methods.
        /// </summary>
        public List_Stack Stack
        {
            get { return _Stack ?? (_Stack = new List_Stack()); }
        }
        private List_Stack _Stack;
        #endregion

        #region String
        /// <summary>
        /// Gets the String library methods.
        /// </summary>
        public List_String String
        {
            get { return _String ?? (_String = new List_String()); }
        }
        private List_String _String;
        #endregion
    }
}
