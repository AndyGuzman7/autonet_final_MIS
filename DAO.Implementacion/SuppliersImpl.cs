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
    class SuppliersImpl : ISuppliers
    {
        LogWrite logWrite = new LogWrite("ISuppliers", Session.IdSession);
        public int Delete(Suppliers t)
        {
            logWrite.NameMethod = "Delete";
            string query = @"UPDATE Suppliers SET status = 0
                                WHERE idSuppliers = @idSuppliers";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idSuppliers", t.IdSuppliers);
                res =  DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }

        public int Insert(Suppliers t)
        {
            logWrite.NameMethod = "Insert";
            string query = @"INSERT INTO Suppliers (ContactName, Address, Phone, dateUpdate, idEmploye, nit)
                                           VALUES(@ContactName, @Address, @Phone, CURRENT_TIMESTAMP, @idEmploye, @nit";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@ContactName", t.ContactName);
                command.Parameters.AddWithValue("@Address", t.Address).SqlDbType = SqlDbType.VarChar;
                command.Parameters.AddWithValue("@Phone", t.Phone);
                command.Parameters.AddWithValue("@idEmploye", t.IdEmploye);
                command.Parameters.AddWithValue("@nit", t.Nit);


                res =  DataBase.ExecuteBasicCommand(command);
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
            string query = @"SELECT*
                            FROM Suppliers
                            WHERE status = 1";
            DataTable dt = new DataTable();
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt =  DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return dt;
        }

        public int Update(Suppliers t)
        {
            logWrite.NameMethod = "Update";
            string query = @"UPDATE Suppliers SET ContactName = @ContactName,
                            Address = @Address,
                            Phone = @Phone,
                            idEmploye = @idEmploye,
                            nit = @nit,
                            dateUpdate = CURRENT_TIMESTAMP
                            
                            WHERE idSuppliers = @idSuppliers AND status = 1;";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@ContactName", t.ContactName);
                command.Parameters.AddWithValue("@Address", t.Address);
                command.Parameters.AddWithValue("@Phone", t.Phone);
                command.Parameters.AddWithValue("@idEmploye", t.IdEmploye);
                command.Parameters.AddWithValue("@nit", t.Nit);
       
                res =  DataBase.ExecuteBasicCommand(command);

                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }

            return res;
        }

        

        public DataTable GetId(int id)
        {
            logWrite.NameMethod = "GetId";
            string query = @"SELECT*
                            FROM Suppliers
                            WHERE status = 1 AND idSuppliers = @idSuppliers  ";
            DataTable dt = new DataTable();
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idSuppliers", id);
                dt = DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }

            return dt;
        }

        
    }
}
