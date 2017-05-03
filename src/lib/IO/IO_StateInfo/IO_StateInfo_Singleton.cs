namespace LamedalCore.lib.IO.IO_StateInfo
{
    public sealed class IO_StateInfo_Singleton
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        private IO_StateInfo_RW1 _info1;
        private IO_StateInfo_RW2 _info2;

        #region Singleton of StateInfo_IO_1lvl
        private static readonly IO_StateInfo_Singleton _StateInfo_IO_1lvl = new IO_StateInfo_Singleton();  // This is the only instance of this class

        private IO_StateInfo_Singleton()
        {
            // Private constructor prevents creation by external clients
        }

        /// <summary>
        /// Return Instance of StateInfo_4Forms
        /// </summary>
        public static IO_StateInfo_Singleton Instance
        {
            get { return _StateInfo_IO_1lvl; }
        }

        #endregion

        /// <summary>Returns the level state information.</summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        public IO_StateInfo_RW Level(int level=1)
        {
            if (level == 1) return _info1 ?? (_info1 = new IO_StateInfo_RW1());

            // Assume level = 2
            return _info2 ?? (_info2 = new IO_StateInfo_RW2());
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
