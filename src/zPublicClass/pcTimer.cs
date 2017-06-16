using System;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zPublicClass
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.StandardClass)]
    public sealed class pcTimer
    {
        public bool Enabled;
        private readonly TimeSpan interval;
        private readonly Action _onTickAction;
        private readonly bool runOnce;

        public pcTimer(TimeSpan interval, Action onTickAction, bool start = false, bool runOnce = false)
        {
            this.interval = interval;
            this._onTickAction = onTickAction;
            this.runOnce = runOnce;
            if (start) Start();
        }

        public void Start()
        {
            if (!Enabled)
            {
                Enabled = true;
                RunTimerLoop();
            }
        }

        public void Stop()
        {
            Enabled = false;
        }

        private async Task RunTimerLoop()
        {
            while (Enabled)
            {
                await Task.Delay(interval);

                if (Enabled)
                {
                    _onTickAction();

                    if (runOnce)
                    {
                        Stop();
                    }
                }
            }
        }
    }
}
