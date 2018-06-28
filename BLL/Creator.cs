using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public static class GenericParams
    {
        public static string SetName(string Name)
        {
            if (Name == null || Name.Length == 0)
                throw new ArgumentNullException();
            Name = Name.ToLower();
            Name = Name[0].ToString().ToUpper() + Name.Remove(0, 1);
            return Name;
        }
        public static string SetEmail(string email)
        {
            if (email == null || email.Length == 0)
                throw new ArgumentNullException();
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                return email;
            }
            else
            {
                throw new FormatException();
            }
        }

        public static string SetPassword(string password)
        {
            if (password == null || password.Length == 0)
                throw new ArgumentNullException();

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
            if (isValidated)
                return password;
            else
                throw new FormatException();
        }
    }
}
