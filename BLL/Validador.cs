using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class Validador
    {
        public bool ValidarEmail(string email)
        {
            string patron = "^[a-z]+@+[a-z]+.com$";
            return Regex.IsMatch(email.ToLower(),patron);
        }
    }
}
