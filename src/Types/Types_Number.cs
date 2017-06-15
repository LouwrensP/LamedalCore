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
        [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
        public IEnumerable<string> ToStrRanges(params int[] numbers)
        {
            return _lamed.Types.List.Convert.Int_ToStrRanges(numbers);
        }

        /// <summary>Get Alfa value from number.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string Alfa_FromNumber(int value)
        {
            string result = string.Empty;
            while (--value >= 0)
            {
                result = (char)('A' + value % 26) + result;
                value /= 26;
            }
            return result;
        }

        /// <summary>Convert Alfas to a number.</summary>
        /// <param name="alfa">The alfa.</param>
        /// <returns></returns>
        public int Alfa_2Number(string alfa)
        {
            int retVal = 0;
            string col = alfa.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }


    }
}
