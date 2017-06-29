using System;
using LamedalCore.domain.Attributes;
using Xunit;

namespace LamdalCoreXunit_Types.other
{
    public partial class xTypes_Other  // Types_DateTimeSpan_Test
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
            Assert.True(10 == ticks | 11 == ticks, $"Ticks ={ticks}");
        }
    }
}