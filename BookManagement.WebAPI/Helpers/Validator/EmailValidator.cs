using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Helpers.Validator
{
    public class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) &&
               Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
