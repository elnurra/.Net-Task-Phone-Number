using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstDataApp.Validation
{
    internal class Validation
    {

        public static bool NameUser(string name)
        {
            if (name.Length > 0)
            {
                return true;
            }
            return false;
        }
        public static bool SurNameUser(string surname)
        {

            if (surname.Length > 0)
            {

                return true;
            }
            return false;
        }

        public static bool PhoneNumber(string number)
        {

            if (number.Length==12 && HasDigits(number))
            {
                return true;
            }
            return false;
        }

        public static bool Email(string email)
        {
            if (email.Length > 0)
            {
            Regex rg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return rg.IsMatch(email);
            }
            return false;
        }

        private static bool HasDigits(string hasdigits)
        {

            foreach (char item in hasdigits)
            {
                if (char.IsDigit(item))
                {
                    return true;
                }

            }

            return false;
        }

        public static bool CheckerId(int ID)
        {
            UsersContext db = new();
            var updateUser = db.Users.Find(ID);
            if (updateUser is null)
            {
                return true;
            } 
                return false;         
        }

        
        
    }
}
