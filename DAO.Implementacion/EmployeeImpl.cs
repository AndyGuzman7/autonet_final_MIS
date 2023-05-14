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
    public class EmployeeImpl : IEmployee
    {
        LogWrite logWrite = new LogWrite("EmployeeImpl", Session.IdSession);
        
        public int Delete(Employeee t)
        {
            logWrite.NameMethod = "Delete";
            int res = 0;
            string query = @"UPDATE Employee SET status = 0
                                WHERE idEmployee = @idEmployye";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idEmployye", t.IdEmployee);
                res = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }

        public int Insert(Employeee t)
        {
            logWrite.NameMethod = "Insert";
            string query = @"INSERT INTO Employee(nameUser, password, UserType, idEmployeAdd, firstName, lastName, birthDate, [Address], phone, gender, dateUpdate, email, ci)
                                           VALUES(@nameUser, HASHBYTES('md5',@password), @UserType, @idEmployeAdd, @firstName, @lastName, @birthDate, @Address, @phone, @gender, CURRENT_TIMESTAMP, @email, @ci)";
            int res = 0;
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@nameUser", t.NameUser);
                command.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
                command.Parameters.AddWithValue("@UserType", t.UserType);
                command.Parameters.AddWithValue("@idEmployeAdd", t.IdEmploye);
                command.Parameters.AddWithValue("@firstName", t.FirstName);
                command.Parameters.AddWithValue("@lastName", t.LastName);
                command.Parameters.AddWithValue("@birthDate", t.BirthDate);
                command.Parameters.AddWithValue("@Address", t.Address);
                command.Parameters.AddWithValue("@phone", t.Phone);
                command.Parameters.AddWithValue("@gender", t.Gender);
                command.Parameters.AddWithValue("@email", t.Email);
                command.Parameters.AddWithValue("@ci", t.Ci);


                res = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }

        public DataTable Login(string userName, string password)
        {
            logWrite.NameMethod = "Login";
            DataTable dt = new DataTable();
            try
            {
                logWrite.MensajeInicio();
                string query = @"SELECT idEmployee, nameUser, UserType, registrationDate, dateUpdate
                            FROM Employee
                            WHERE status = 1 AND nameUser = @nameUser AND password = HASHBYTES('md5',@password)";

                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@nameUser", userName);
                command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                dt = DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return dt;
        }

        public DataTable CompareEmail(string email)
        {
            logWrite.NameMethod = "CompareEmail";
            string query = @"SELECT*
                            FROM Employee
                            WHERE status = 1 AND email = @email";
            DataTable dt = new DataTable();
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@email", email);

                dt = DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return dt;
        }

        public DataTable Select()
        {
            logWrite.NameMethod = "Select";
            string query = @"SELECT*
                            FROM Employee
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

        public int Update(Employeee t)
        {
            logWrite.NameMethod = "Update";
            int res = 0;
            string query = @"UPDATE Employee SET nameUser = @nameUser,
                            password =  HASHBYTES('md5',@password),
                            UserType = @UserType,
                            idEmployeAdd = @idEmployeAdd,
                            firstName = @firstName,
                            lastName = @lastName,
                            birthDate = @birthDate, 
                            [Address] =  @Address,
                            phone = @phone,
                            gender = @gender,
                            dateUpdate = CURRENT_TIMESTAMP,
                            email = @email,
                            ci = @ci
                            WHERE idEmployee = @idEmployee AND status = 1;";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@nameUser", t.NameUser);
                command.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
                command.Parameters.AddWithValue("@UserType", t.UserType);
                command.Parameters.AddWithValue("@idEmployeAdd", t.IdEmploye);
                command.Parameters.AddWithValue("@firstName", t.FirstName);
                command.Parameters.AddWithValue("@lastName", t.LastName);
                command.Parameters.AddWithValue("@birthDate", t.BirthDate);
                command.Parameters.AddWithValue("@Address", t.Address);
                command.Parameters.AddWithValue("@phone", t.Phone);
                command.Parameters.AddWithValue("@gender", t.Gender);
                command.Parameters.AddWithValue("@email", t.Email);
                command.Parameters.AddWithValue("@idEmployee", t.IdEmployee);
                command.Parameters.AddWithValue("@ci", t.Ci);
                res =  DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();

            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return res;
        }

        public int UpdateRestorePassword(string email, string password)
        {
            logWrite.NameMethod = "UpdateRestorePassword";
            int res = 0;
            string query = @"UPDATE Employee SET password = HASHBYTES('md5',@password)
                            WHERE email = @email AND status = 1;";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
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
            string query = @"SELECT registrationDate, dateUpdate
                            FROM Employee
                            WHERE status = 1 AND idEmployee = @idEmployee  ";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idEmployee", id);
                dt = DataBase.ExecuteDataTableCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return dt;
        }

        public int UpdatePassword(string password, int id)
        {
            logWrite.NameMethod = "UpdatePassword";
            int res = 0;
            string query = @"UPDATE Employee SET password = HASHBYTES('md5',@password), dateUpdate = CURRENT_TIMESTAMP
                            WHERE idEmployee = @idEmployee AND status = 1";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idEmployee", id);
                command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
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
