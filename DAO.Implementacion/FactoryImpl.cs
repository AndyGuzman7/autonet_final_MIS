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
    public class FactoryImpl : IFactory
    {
        LogWrite logWrite = new LogWrite("FactoryImpl", Session.IdSession);


        public int Delete(Factory t)
        {
            logWrite.NameMethod = "Delete";
            int rest = 0;
            string query = @"UPDATE Factory SET status = 0
                                WHERE idFactory = @idFactory";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idFactory", t.IdFactory);
                rest = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return rest;
        }

        public int Insert(Factory t)
        {
            logWrite.NameMethod = "Insert";
            int rest = 0;
            string query = @"INSERT INTO Factory (nameFactory, nameCityOrCountry, idEmploye, dateUpdate)
                                            VALUES (@nameFactory, @nameCityOrCountry,@idEmploye, CURRENT_TIMESTAMP )";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@nameFactory", t.NameFactory);
                command.Parameters.AddWithValue("@nameCityOrCountry", t.NameCityOrCountry);
                command.Parameters.AddWithValue("@idEmploye", t.IdEmploye);


                rest = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return rest;
        }

        public DataTable Select()
        {
            logWrite.NameMethod = "Select";
            string query = @"SELECT*
                            FROM Factory
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

        

        public int Update(Factory t)
        {
            logWrite.NameMethod = "Update";
            int rest = 0;
            string query = @"UPDATE Factory SET  nameFactory = @nameFactory, nameCityOrCountry = @nameCityOrCountry, idEmploye = @idEmploye, dateUpdate = CURRENT_TIMESTAMP
                                WHERE idFactory = @idFactory";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idFactory", t.IdFactory);
                command.Parameters.AddWithValue("@nameFactory", t.NameFactory);
                command.Parameters.AddWithValue("@nameCityOrCountry", t.NameCityOrCountry);
                command.Parameters.AddWithValue("@idEmploye", t.IdEmploye);
                
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
