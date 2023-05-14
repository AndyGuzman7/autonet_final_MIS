using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Strategys;

namespace DAO.Implementacion
{
    class DataBase
    {

        private static string connectionString = @"data source = (local); initial catalog = BDDAUTONET; user id= autoNet; password=Univalle";

        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }
        
        public static SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query);
            command.Connection = connection;
            return command;
        }

        /// <summary>
        /// Insert, Update, Delete
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            finally
            {
                command.Connection.Close();
            }
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            DataTable res = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return res;
            //DADTA READER LEE LOS DATOS, APUTNA AL SELECT, VA FILA POR FILA, SE VA APODER VE ROS CAMBIOS
        }





        /// <summary>
        /// SELECT CON DATAREADER
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>

        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand sqlCommand)
        {
            SqlDataReader dr = null; // esto retornamos
            try
            {
                sqlCommand.Connection.Open();
                dr = sqlCommand.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //no nesecita un finally porque lee uno por uno
            return dr;
        }


        public static void ExecutenBasicCommand(List<SqlCommand> commands)
        {
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand1 = commands[0];

            try
            {
                sqlCommand1.Connection.Open();
                sqlTransaction = sqlCommand1.Connection.BeginTransaction();

                foreach (SqlCommand item in commands)
                {
                    item.Transaction = sqlTransaction;
                    item.ExecuteNonQuery();
                }
                sqlTransaction.Commit();

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw ex;
            }
        }
        public static string GetGenerateIDTable(string tableName)
        {
            string res;
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                string query = $@"SELECT IDENT_CURRENT('{tableName}') + IDENT_INCR('{tableName}')";
                sqlCommand = CreateBasicCommand(query);
                sqlCommand.Connection.Open();
                res = sqlCommand.ExecuteScalar().ToString();
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Connection.Close();
            }

            return res;
        }


        public static List<SqlCommand> CreateBasciComand(int n)
        {
            List<SqlCommand> res = new List<SqlCommand>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            for (int i = 0; i < n; i++)
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                res.Add(sqlCommand);
            }
            return res;


        }

    }
}
