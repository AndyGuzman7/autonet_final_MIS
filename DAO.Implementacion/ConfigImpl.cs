using DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementacion
{
    public class ConfigImpl : IConfig
    {
        public DataTable SelectConfigData()
        {
          
            string query = @"SELECT productImagePath, clientImagePath FROM Config";
            DataTable dt = new DataTable();
            try
            {
               
                SqlCommand command = DataBase.CreateBasicCommand(query);

                dt = DataBase.ExecuteDataTableCommand(command);
               
            }
            catch (Exception ex)
            {
                
            }
            return dt;
        }
    }
}
