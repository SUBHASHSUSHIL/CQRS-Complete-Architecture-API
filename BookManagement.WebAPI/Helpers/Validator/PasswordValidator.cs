using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Helpers.Validator
{
    public class PasswordValidator
    {
        public static bool IsValid(string password)
        {
            return !string.IsNullOrEmpty(password) &&
                   Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}$");
        }
    }
}
