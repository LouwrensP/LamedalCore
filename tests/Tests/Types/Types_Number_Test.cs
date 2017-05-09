using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using Xunit;

namespace LamedalCore.Test.Tests.Types
{
    public sealed class Types_Number_Test
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        [Fact]
        [Test_Method("ToRoman()")]
        [Test_Method("ToInt()")]
        [Test_Method("IsValid()")]
        public void ToRoman()
        {
            // intRomanNumbers
            Assert.Equal("MDXXXIV", _lamed.Types.intRomanNumbers.ToRoman(1534));
            Assert.Equal(1534, _lamed.Types.intRomanNumbers.ToInt("MDXXXIV"));
            Assert.Equal(true, _lamed.Types.intRomanNumbers.IsValid("MDXXXIV"));
            // Exceptions
            Assert.Throws<ArgumentOutOfRangeException>(() => _lamed.Types.intRomanNumbers.ToRoman(0));
            Assert.Throws<ArgumentNullException>(() => _lamed.Types.intRomanNumbers.ToInt(null));
        }

        [Fact]
        [Test_Method("Alfa_FromNumber()")]
        [Test_Method("Alfa_2Number()")]
        public void Number_2Afla_Test()
        {
            Assert.Equal("A", _lamed.Types.Number.Alfa_FromNumber(1));
            Assert.Equal("B", _lamed.Types.Number.Alfa_FromNumber(2));
            Assert.Equal("C", _lamed.Types.Number.Alfa_FromNumber(3));
            Assert.Equal("Z", _lamed.Types.Number.Alfa_FromNumber(26));
            Assert.Equal("AA", _lamed.Types.Number.Alfa_FromNumber(27));
            Assert.Equal("AB", _lamed.Types.Number.Alfa_FromNumber(28));
            Assert.Equal("AC", _lamed.Types.Number.Alfa_FromNumber(29));

            Assert.Equal(1, _lamed.Types.Number.Alfa_2Number("A"));
            Assert.Equal(1, _lamed.Types.Number.Alfa_2Number("a"));
            Assert.Equal(2, _lamed.Types.Number.Alfa_2Number("B"));
            Assert.Equal(3, _lamed.Types.Number.Alfa_2Number("C"));
            Assert.Equal(26, _lamed.Types.Number.Alfa_2Number("Z"));
            Assert.Equal(27, _lamed.Types.Number.Alfa_2Number("AA"));
            Assert.Equal(28, _lamed.Types.Number.Alfa_2Number("AB"));
            Assert.Equal(29, _lamed.Types.Number.Alfa_2Number("AC"));
            Assert.Equal(29, _lamed.Types.Number.Alfa_2Number("ac"));
        }
    }
}
