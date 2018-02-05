using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    /// <summary>
    /// 1 = I, 5 = V, 10 = X, 50 = L, 100 = C, 500 = D, 1000 = M
    /// </summary>
    public class KataRomanNumeral
    {
        Dictionary<int, string> romanNumerals = new Dictionary<int, string>()
        {
            {1, "I" }, {2, "II"}, { 3, "III" }, {4, "IV" }, {5, "V" }, {6, "VI" }, {7, "VII" }, {8, "VIII" }, {9, "IX" },
            { 10, "X" }, {40, "XL"},
            { 50, "L" }, {90, "XC" },
            { 100, "C" }, {400, "CD" },
            { 500, "D" }, {900, "CM" },
            { 1000, "M" }
        };

        public string GetRomanNumeral(int number)
        {
            string result = "";

            // Add up all of the M's
            IEnumerable<int> places = romanNumerals.Keys.Reverse();

            foreach (int place in places)
            {
                while (number >= place)
                {
                    result += romanNumerals[place];
                    number -= place;
                }
            }

            return result;

            #region Don't look here
            /*
            //int[] places = { 1000, 900, 500, 400, 100, 90, 50, 40, 10 };
  
             
            Refactor 2
                        //while (number >= 1000)
            //{
            //    result += romanNumerals[1000];
            //    number -= 1000;
            //}
            //while (number >= 500)
            //{
            //    result += romanNumerals[500];
            //    number -= 500;
            //}

             
            REFACTOR 1
            if (number == 1)
            {
                result = "I";
            }
            else if (number == 5)
            {
                result = "V";
            }
            else if (number == 10)
            {
                result = "X";
            }
            else if (number == 50)
            {
                result = "L";
            }
            else if (number == 100)
            {
                result = "C";
            }
            else if (number == 500)
            {
                result = "D";
            }
            else
            {
                result = "M";
            }


             Refactor 0
            if (number == 1)
            {
                return "I";
            }
            else
            {
                return "V";
            }  
            */
            #endregion
        }
    }
}
