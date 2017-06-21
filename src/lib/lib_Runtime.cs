using System;
using System.Threading;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public class lib_Runtime
    {

        /// <summary>
        /// Collects the garbage in the environment.
        /// </summary>
        public void GarbageEngine_Collect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        /// Tests the memory by using the Garbage Collector to add memory pressure.
        /// </summary>
        public void GarbageEngine_MemoryPressure_Add()
        {
            var memory = 0x7fffffffL;
            GC.AddMemoryPressure(memory);
        }

        /// <summary>
        /// Tests the memory by using the Garbage Collector to remove the memory pressure.
        /// </summary>
        public void GarbageEngine_MemoryPressure_Remove()
        {
            var memory = 0x7fffffffL;
            GC.RemoveMemoryPressure(memory);
        }

        /// <summary>Determines whether the unique application name is running.</summary>
        /// <param name="mutex">The mutex variable to use</param>
        /// <param name="uniqueAppName">The unique application name</param>
        /// <param name="showMsg">Show msg indicator. Default value = true.</param>
        /// <returns>bool</returns>
        public virtual bool Application_IsRunning(out Mutex mutex, string uniqueAppName = "", bool showMsg = true)
        {
            mutex = new Mutex(false, uniqueAppName);
            if (mutex.WaitOne(0)) return false;
            return true;
        }

    }
}
