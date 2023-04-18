using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProyectData
{
    public static class Validator
    {

        public static bool ValidateNumeric(string Num)
        {
            var myRegex = new Regex(@"^\d+$");
            return myRegex.IsMatch(Num);
        }

        public static bool ValidateAlphabetical(string parameter)
        {
            var myRegex = new Regex(@"^[a-zA-Z]+\s*(,[a-zA-Z]+\s*)*$");

            return myRegex.IsMatch(parameter);
        }

    }
}
