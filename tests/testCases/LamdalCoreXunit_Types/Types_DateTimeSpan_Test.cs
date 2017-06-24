using System;
using LamedalCore;
using LamedalCore.domain.Attributes;
using Xunit;

namespace LamdalCoreXunit_Types
{
    // Types_DateTimeSpan_Test
    public partial class xTypes_General 
    {
        [Fact]
        [Test_Method("Sleep()")]
        [Test_Method("Elapsed()")]
        public void Elapsed_Test()
        {
            var now = DateTime.UtcNow;
            _lamed.lib.Command.Sleep(1000);
            var span = _lamed.Types.DateTimeSpan.Elapsed(now);
            int ticks = (int)span.TotalMilliseconds/100;
            Assert.True(10 == ticks | 11 == ticks);
        }
    }
}