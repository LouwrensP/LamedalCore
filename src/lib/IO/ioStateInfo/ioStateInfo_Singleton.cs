namespace LamedalCore.lib.IO.ioStateInfo
{
    public sealed class ioStateInfo_Singleton
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        private ioStateInfo_RW1 _info1;
        private ioStateInfo_RW2 _info2;

        #region Singleton of StateInfo_IO_1lvl
        private static readonly ioStateInfo_Singleton _StateInfo_IO_1lvl = new ioStateInfo_Singleton();  // This is the only instance of this class

        private ioStateInfo_Singleton()
        {
            // Private constructor prevents creation by external clients
        }

        /// <summary>
        /// Return Instance of StateInfo_4Forms
        /// </summary>
        public static ioStateInfo_Singleton Instance
        {
            get { return _StateInfo_IO_1lvl; }
        }

        #endregion

        /// <summary>Returns the level state information.</summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        public ioStateInfo_RW Level(int level=1)
        {
            if (level == 1) return _info1 ?? (_info1 = new ioStateInfo_RW1());

            // Assume level = 2
            return _info2 ?? (_info2 = new ioStateInfo_RW2());
        }

        /// <summary>Resets state memory.</summary>
        public void Reset()
        {
            Reset(1);
            Reset(2);
        }
        /// <summary>Resets state memory.</summary>
        public void Reset(int level)
        {
            Level(level).Delete();
            if (level == 1) _info1 = null;
            if (level == 2) _info2 = null;
        }

    }
}
