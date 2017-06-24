using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LamdalCoreXunit_Types
{
    [Collection("Types")]
    [Trait("Category", "Types_General")]
    public class Types_Test1 : Types_Convert_Test
    {
        public Types_Convert_Test test1 = new Types_Convert_Test();
        public Types_DateTime_Test test2;
        public Types_DateTimeSpan_Test test3;
    }
}
