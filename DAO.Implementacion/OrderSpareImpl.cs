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
    public class OrderSpareImpl : IOrderSpare    
    {
        LogWrite logWrite = new LogWrite("OrderSpareImpl", Session.IdSession);
        public int Delete(OrderSpare t)
        {
            logWrite.NameMethod = "Delete";
            int res = 0;
            string query = @"UPDATE OrderSpare SET status = 0
                                WHERE idOrder = @idOrder AND idSpare = @idSpare ";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idOrder", t.IdOrder);
                command.Parameters.AddWithValue("@idSpare", t.IdSpare);
                res = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }


        
        public int DeleteForId(int idSpare, int idOrder)
        {
            logWrite.NameMethod = "DeleteForId";
            int res = 0;
            string query = @"UPDATE OrderSpare SET status = 0
                                WHERE idOrder = @idOrder AND idSpare = @idSpare ";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idSpare", idSpare);
                command.Parameters.AddWithValue("@idOrder", idOrder);
                res = DataBase.ExecuteBasicCommand(command);
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
            DataTable dt = new DataTable();
            string query = @"SELECT idSpare, nit, firstName, lastName
                            FROM Client
                            WHERE status = 1 AND idClient = @idClient";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idClient", id);

                dt = DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }

            return dt;
        }

        public int Insert(OrderSpare t)
        {
            logWrite.NameMethod = "Insert";
            int res = 0;
            string query = @"INSERT INTO OrderSpare(idOrder, idSpare, quantity, unitPrice, idEmploye, dateUpdate, total)
                                           VALUES(@idOrder, @idSpare, @quantity, @unitPrice, @idEmploye,  CURRENT_TIMESTAMP,@total)";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idOrder", t.IdOrder);
                command.Parameters.AddWithValue("@idSpare", t.IdSpare);
                command.Parameters.AddWithValue("@quantity", t.Quantity);
                command.Parameters.AddWithValue("@unitPrice", t.UnitPrice);
                command.Parameters.AddWithValue("@idEmploye", t.IdEmploye);
                command.Parameters.AddWithValue("@total", t.Total);
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
                            FROM OrderSpare
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

        public DataTable SelectDetails()
        {
            logWrite.NameMethod = "SelectDetails";
            DataTable dt = new DataTable();
            string query = @"SELECT * FROM view_detalle_venta;";
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

        public int Update(OrderSpare t)
        {
            logWrite.NameMethod = "Update";
            string query = @"UPDATE OrderSpare SET 
                            idOrder = @idOrder,
                            idSpare = @idSpare,
                            idEmployee= @idEmployeAdd,
                            quantity = @quantity,
                            unitPrice = @unitPrice,  
                            dateUpdate = CURRENT_TIMESTAMP
                            total = @total,
                            WHERE idSpare = @idSpare AND idOrder = @idOrder AND status = 1;";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idOrder", t.IdOrder);
                command.Parameters.AddWithValue("@idSpare", t.IdSpare);
                command.Parameters.AddWithValue("@quantity", t.Quantity);
                command.Parameters.AddWithValue("@unitPrice", t.UnitPrice);
                command.Parameters.AddWithValue("@idEmploye", t.IdEmploye);
                command.Parameters.AddWithValue("@total", t.Total);

                res =  DataBase.ExecuteBasicCommand(command);

                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }
    }
}
