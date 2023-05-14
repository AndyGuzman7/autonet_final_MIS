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
    public class OrderImpl : IOrder
    {
        LogWrite logWrite = new LogWrite("OrderImpl", Session.IdSession);


        public int Delete(Order t)
        {
            logWrite.NameMethod = "Delete";
            int rest = 0;
            string query = @"UPDATE Order SET status = 0
                                WHERE idOrder = @idOrder";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idOrder", t.IdOrder);
                rest = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return rest;
        }

        public int Insert(Order t)
        {
            logWrite.NameMethod = "Insert";
            int rest = 0;
            string query = @"INSERT INTO Order (idEmployee, dateUpdate, idClient, clientPay)
                                            VALUES (@idEmployee,CURRENT_TIMESTAMP ,@idClient, @clientPay)";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idEmployee", t.IdEmploye);
                command.Parameters.AddWithValue("@idClient", t.IdClient);
                command.Parameters.AddWithValue("@clientPay", t.ClientPay);
        

                rest = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return rest;
        }

        public int InsertAvanced(Order t, List<OrderSpare> sp)
        {
            logWrite.NameMethod = "InsertAvancedTransaction";

            List<SqlCommand> commands = new List<SqlCommand>();
            
            string queryOrder = @"INSERT INTO [Order](idEmployee, dateUpdate,  idClient, clientPay)
                                                VALUES(@idEmployee, CURRENT_TIMESTAMP, @idClient, @ClientPay);";

            string queryOrderSpare = @"INSERT INTO [OrderSpare] (idOrder, idSpare, quantity, unitPrice, idEmploye, dateUpdate, total)
		                               VALUES(@idOrder, @idSpare, @quantity, @unitPrice, @idEmploye,CURRENT_TIMESTAMP, @total)";
            int id = int.Parse(DataBase.GetGenerateIDTable("Order"));
            try
            {
                logWrite.MensajeInicio();

                commands = DataBase.CreateBasciComand(sp.Count + 1);

                for (int i = 0; i < commands.Count; i++)
                {
                    if(i == 0)
                    {
                        //Order
                        commands[i].CommandText = queryOrder;
                        commands[i].Parameters.AddWithValue("@idEmployee", t.IdEmploye);
                        commands[i].Parameters.AddWithValue("@idClient", t.IdClient);
                        commands[i].Parameters.AddWithValue("@clientPay", t.ClientPay);
                    }
                    else
                    {
                        commands[i].CommandText = queryOrderSpare;
                        commands[i].Parameters.AddWithValue("@idOrder", id);
                        commands[i].Parameters.AddWithValue("@idSpare", sp[i -1].IdSpare);
                        commands[i].Parameters.AddWithValue("@quantity", sp[i - 1].Quantity);
                        commands[i].Parameters.AddWithValue("@unitPrice", sp[i - 1].UnitPrice);
                        commands[i].Parameters.AddWithValue("@idEmploye", sp[i - 1].IdEmploye);
                        commands[i].Parameters.AddWithValue("@total", sp[i - 1].Total);

                    }
                }
                //Ejecutamos la transaccion
                DataBase.ExecutenBasicCommand(commands);

                
                
                logWrite.MensajeFinalizado();
                
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return id;
        }

        public DataTable Select()
        {
            logWrite.NameMethod = "Select";
            string query = @"SELECT*
                            FROM Order
                            WHERE status = 1";
            DataTable dt = new DataTable();
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

        public DataTable SelectLike(string cadenaBuscar)
        {
            logWrite.NameMethod = "SelectLike";
            string query = @"SELECT*
                            FROM Order
                            WHERE status = 1 AND nameProduct LIKE @cadenaBuscar";
            // WHERE status = 1 AND ((SELECT CHARINDEX( @cadenaBuscar, nameProduct)) >= 1 OR @cadenaBuscar = ' ')";
            DataTable dt = new DataTable();
            //SELECT CHARINDEX ('ZUR', primerApellido)) >= 1
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@cadenaBuscar", $"%{cadenaBuscar}%");

                dt = DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();

            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return dt;
        }

 

        public int Update(Order t)
        {
            logWrite.NameMethod = "Update";
            int rest = 0;
            string query = @"UPDATE Order SET  idEmployee = @idEmployee, dateUpdate = CURRENT_TIMESTAMP, idClient = @idClient, clientPay = @clientPay 
                                WHERE idOrder = @idOrder";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idOrder", t.IdOrder);
                command.Parameters.AddWithValue("@idEmployee", t.IdEmploye);
                command.Parameters.AddWithValue("@idClient", t.IdClient);
                command.Parameters.AddWithValue("@clientPay", t.ClientPay);
                rest = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return rest;
        }
    }
}
