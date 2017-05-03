using System.Resources;

namespace LamedalCore.lib.IO.IO_StateInfo
{
    public sealed class IO_StateInfo_
    {
        #region Level1
        /// <summary>
        /// Gets the IO for level 1 state information.
        /// </summary>
        public IO_StateInfo_RW1 Level1
        {
            get { return IO_StateInfo_Singleton.Instance.Level(1) as IO_StateInfo_RW1; }
        }
        #endregion


        #region Level2
        /// <summary>
        /// Gets the IO for level 1 state information.
        /// </summary>
        public IO_StateInfo_RW2 Level2
        {
            get { return IO_StateInfo_Singleton.Instance.Level(2) as IO_StateInfo_RW2; }
        }

        /// <summary>Resets the state information.</summary>
        public void Reset()
        {
            IO_StateInfo_Singleton.Instance.Reset();
        }

        /// <summary>Resets the state information.</summary>
        public void Reset(int level)
        {
            IO_StateInfo_Singleton.Instance.Reset(level);
        }

        #endregion

    }
}
