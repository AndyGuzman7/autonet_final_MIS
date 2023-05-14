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
    public class SpareTypeImpl : ISpareType
    {
        //AQUI AHCEMOS LOS CRUDS SON INDEPEDIENTES DEL UI
        LogWrite logWrite = new LogWrite("SpareTypeImpl", Session.IdSession);
        public int Delete(SpareType t)
        {
            logWrite.NameMethod = "Delete";
            int res = 0;

            string query = @"UPDATE SpareType SET status = 0
                                WHERE idSpareType = @idSpareType";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idSpareType", t.IdSpareType);
                res = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }

            return res;
        }

        public SpareType Get(int id)
        {
            logWrite.NameMethod = "Get";

            SpareType spareType = null;
            string query = @"SELECT*FROM SpareType WHERE idSpareType = @idSpareType";
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;
            try
            {
                logWrite.MensajeInicio();
                //UTILIZANDO UN DATA READER
                sqlCommand = DataBase.CreateBasicCommand(query);
                sqlCommand.Parameters.AddWithValue("@idSpareType", id);
                sqlDataReader =  DataBase.ExecuteDataReaderCommand(sqlCommand);

                while(sqlDataReader.Read())
                {   
                    spareType = new SpareType(byte.Parse(sqlDataReader[0].ToString()), sqlDataReader[1].ToString(), byte.Parse(sqlDataReader[2].ToString()), short.Parse(sqlDataReader[2].ToString()), byte.Parse(sqlDataReader[3].ToString()), DateTime.Parse(sqlDataReader[4].ToString()), DateTime.Parse(sqlDataReader[5].ToString()));
                }
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            finally
            {
                sqlCommand.Clone();
                sqlDataReader.Close();
            }

            return spareType;
        }

        public int Insert(SpareType t)
        {
            logWrite.NameMethod = "Insert";
            int res = 0;
            string query = @"INSERT INTO SpareType (nameSpareType, idSpareCategory, idEmployee, dateUpdate)
                            VALUES (@nameSpareType, @idSpareCategory, @idEmployee, CURRENT_TIMESTAMP )";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@nameSpareType", t.NameSpareType);
                command.Parameters.AddWithValue("@idSpareCategory", t.IdSpareCategory);
                command.Parameters.AddWithValue("@idEmployee", t.IdEmploye);
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
            DataTable dt = new DataTable();
            string query = @"SELECT*
                            FROM SpareType
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

        public int Update(SpareType t)
        {
            logWrite.NameMethod = "Update";
            int res = 0;
            string query = @"UPDATE SpareType SET  nameSpareType = @nameSpareType, idSpareCategory = @idSpareCategory, idEmployee =@idEmployee, dateUpdate = CURRENT_TIMESTAMP
                                WHERE idSpareType = @idSpareType";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@nameSpareType", t.NameSpareType);
                command.Parameters.AddWithValue("@idSpareCategory", t.IdSpareCategory);
                command.Parameters.AddWithValue("@idEmployee", t.IdEmploye);
                command.Parameters.AddWithValue("@dateUpdate", t.DateUpdate);
                command.Parameters.AddWithValue("@idSpareType", t.IdSpareType);
                res = DataBase.ExecuteBasicCommand(command);
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
