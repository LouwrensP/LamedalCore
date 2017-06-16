namespace LamedalCore.lib.IO.ioStateInfo
{
    public sealed class ioStateInfo_
    {
        #region Level1
        /// <summary>
        /// Gets the IO for level 1 state information.
        /// </summary>
        public ioStateInfo_RW1 Level1
        {
            get { return ioStateInfo_Singleton.Instance.Level(1) as ioStateInfo_RW1; }
        }
        #endregion


        #region Level2
        /// <summary>
        /// Gets the IO for level 1 state information.
        /// </summary>
        public ioStateInfo_RW2 Level2
        {
            get { return ioStateInfo_Singleton.Instance.Level(2) as ioStateInfo_RW2; }
        }

        /// <summary>Resets the state information.</summary>
        public void Reset()
        {
            ioStateInfo_Singleton.Instance.Reset();
        }

        /// <summary>Resets the state information.</summary>
        public void Reset(int level)
        {
            ioStateInfo_Singleton.Instance.Reset(level);
        }

        #endregion

    }
}
