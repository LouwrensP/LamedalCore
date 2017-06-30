using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace LamedalCore.domain.Attributes
{
    /// <summary>
    /// Change [Fact] to [Theory] and add [Test_Repeat(5)] to repeat the test 5 times.
    /// </summary>
    /// <seealso cref="Xunit.Sdk.DataAttribute" />
    public class Test_RepeatAttribute : DataAttribute
    {
        private readonly int _count;

        public Test_RepeatAttribute(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Repeat count must be greater than 0.");
            }
            _count = count;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return Enumerable.Repeat(new object[0], _count);
        }
    }
}