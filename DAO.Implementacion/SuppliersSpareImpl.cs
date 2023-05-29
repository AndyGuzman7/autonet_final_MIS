using DAO.Interfaces;
using DAO.Model;
using Strategys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementacion
{
    internal class SuppliersSpareImpl : ISuppliersSpare
    {
        LogWrite logWrite = new LogWrite("SpareTypeImpl", Session.IdSession);

        public int Delete(SuppliersSpare t)
        {
            throw new NotImplementedException();
        }

        public int Insert(SuppliersSpare t)
        {
            logWrite.NameMethod = "Insert";
            int res = 0;
            string query = @"INSERT INTO SuppliersSpare([idSpare],[idSuppliers],[quantity],[total],[acquiredPrice],[idEmploye])
                            VALUES @idSpare, @idSuppliers, @quantity, @total, @acquiredPrice, @idEmploye";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idSpare", t.IdSpare);
                command.Parameters.AddWithValue("@idSuppliers", t.IdSuppliers);
                command.Parameters.AddWithValue("@quantity", t.Quantity);
                command.Parameters.AddWithValue("@total", t.Total);
                command.Parameters.AddWithValue("@acquiredPrice", t.AcquiredPrice);
                command.Parameters.AddWithValue("@idEmploye", Session.IdSession);

                res = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }

        public DataTable Select()
        {
            logWrite.NameMethod = "Select";
            DataTable dt = new DataTable();
            string query = @"SELECT*
                            FROM SuppliersSpare
                            WHERE status = 1";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);

                dt = DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return dt;
        }

        public int Update(SuppliersSpare t)
        {
            throw new NotImplementedException();
        }
    }
}
