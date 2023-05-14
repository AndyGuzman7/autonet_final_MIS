using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using System.Data;

namespace DAO.Interfaces
{
    public interface IEmployee:IDao<Employeee>
    {
        DataTable Login(string userName, string password);
        DataTable GetId(int id);
        DataTable CompareEmail(string email);
        int UpdateRestorePassword(string email, string password);
        int UpdatePassword(string password, int id);
    }
}
