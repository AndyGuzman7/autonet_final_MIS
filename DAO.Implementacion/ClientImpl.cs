using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using DAO.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Strategys;

namespace DAO.Implementacion
{
    
    public class ClientImpl : IClient
    {
        LogWrite logWrite = new LogWrite("ClientImpl", Session.IdSession);
        public int Delete(Client t)
        {
            logWrite.NameMethod = "Delete";
            string query = @"UPDATE Client SET status = 0
                                WHERE idClient = @idClient";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idEmployye", t.IdClient);
                res = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }
        public int DeleteForId(int idClient)
        {
            logWrite.NameMethod = "DeleteForId";
            string query = @"UPDATE Client SET status = 0
                                WHERE idClient = @idClient";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idClient", idClient);
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
            logWrite.NameMethod = "Getid";
            DataTable dt = new DataTable();
            string query = @"SELECT idClient, nit, firstName, lastName
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

        public DataTable SelectLike(string cadenaBuscar)
        {
            logWrite.NameMethod = "SelectLike";
            string query = @"SELECT*
                            FROM Client
                            WHERE status = 1 AND firstName LIKE @cadenaBuscar";
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

        public int Insert(Client t)
        {
            logWrite.NameMethod = "Insert";
            string query = @"INSERT INTO Client(nit, idEmployee, dateUpdate, firstName, lastName)
                                           VALUES(@nit, @idEmployeAdd, CURRENT_TIMESTAMP,@firstName, @lastName)";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@nit", t.Nit);
                command.Parameters.AddWithValue("@idEmployeAdd", t.IdEmploye);
                command.Parameters.AddWithValue("@firstName", t.FistName);
                command.Parameters.AddWithValue("@lastName", t.LastName);
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
            string query = @"SELECT*
                            FROM Client
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

        public int Update(Client t)
        {
            logWrite.NameMethod = "Update";
            int res = 0;
            string query = @"UPDATE Client SET 
                            nit = @nit,                   
                            idEmployee= @idEmployeAdd,
                            firstName = @firstName,
                            lastName = @lastName,  
                            dateUpdate = CURRENT_TIMESTAMP                
                            WHERE idClient = @idClient AND status = 1;";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idClient", t.IdClient);
                command.Parameters.AddWithValue("@nit", t.Nit);
                command.Parameters.AddWithValue("@idEmployeAdd", t.IdEmploye);
                command.Parameters.AddWithValue("@firstName", t.FistName);
                command.Parameters.AddWithValue("@lastName", t.LastName);
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
