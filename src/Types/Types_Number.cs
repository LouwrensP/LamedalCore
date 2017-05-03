using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Types
{
    public sealed class Types_Number
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Ensure that number will always be betweens the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="minNumber">The minimum number.</param>
        /// <param name="maxNumber">The maximum number.</param>
        /// <returns></returns>
        public bool IsBetween(int number, int minNumber, int maxNumber)
        {
            if (number <= minNumber) return false;
            if (number >= maxNumber) return false;
            return true;
        }

        /// <summary>
        ///     A Double extension method that converts the @this to a money.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a Double.</returns>
        public Double ToMoney(Double @this)
        {
            return Math.Round(@this, 2);
        }

        /// <summary>Conver Int list values to string ranges.</summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns></returns>
        [Test_IgnoreCoverage(enTestIgnore.MethodIsShortCut)]
        public IEnumerable<string> ToStrRanges(params int[] numbers)
        {
            return _lamed.Types.List.Convert.Int_ToStrRanges(numbers);
        }
    }
}
