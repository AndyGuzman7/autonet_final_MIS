using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public static class UserName
    {
        public static string GenerarNameUser(string firstName, string firstLastName, string secondLastName)
        {
            string[] nombre = firstName.Split(' ');
            string apellido1 = firstLastName;
            string apellido2 = secondLastName;
            string userName = $"{nombre[0][0]+apellido1+apellido2[0]}"; 
            return userName;
        }
    }
}
