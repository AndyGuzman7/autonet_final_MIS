﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using DAO.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Strategys;
using System.Windows.Forms;
using System.Windows.Controls;

namespace DAO.Implementacion
{

    public class SpareImpl : ISpare
    {
        LogWrite logWrite = new LogWrite("Spare", Session.IdSession);


        public int Delete(Spare t)
        {
            logWrite.NameMethod = "Delete";
            int rest = 0;
            string query = @"UPDATE Spare SET status = 0
                                WHERE idSpare = @idSpare";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@idSpare", t.IdSpare);
                rest = DataBase.ExecuteBasicCommand(command);
                logWrite.MensajeFinalizado();
            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return rest;
        }

        public int GetGenerateId()
        {
            int id = 0;
            try
            {
                id = int.Parse(DataBase.GetGenerateIDTable("Spare"));
            }
            catch (Exception ex)
            {

                throw;
            }
            return id;
        }

        public int Insert(Spare t)
        {
            logWrite.NameMethod = "Insert";
            int rest = 0;
            string query = @"INSERT INTO Spare (description, nameProduct, currentBalance, unitPrice, weight, productCode, idFactory, idSpareCategory, idEmploye, updateDate)
                                            VALUES (@description, @nameProduct, @currentBalance, @unitPrice, @weight, @productCode, @idFactory ,@idSpareCategory, @idEmployee, CURRENT_TIMESTAMP )";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@description", t.Description);
                command.Parameters.AddWithValue("@nameProduct", t.NameProduct);
                command.Parameters.AddWithValue("@currentBalance", t.CurrentBalance);
                command.Parameters.AddWithValue("@unitPrice", t.BasePrice);
                command.Parameters.AddWithValue("@weight", t.Weight);
                command.Parameters.AddWithValue("@productCode", t.ProductCode);
                command.Parameters.AddWithValue("@idFactory", t.IdFactory);
                command.Parameters.AddWithValue("@idSpareCategory", t.IdSpareCategory);
                command.Parameters.AddWithValue("@idEmployee", t.IdEmploye);

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


            // Variables para las columnas y las filas
            DataColumn column;
            DataRow row;



            logWrite.NameMethod = "Select";
            string query = @"SELECT*
                            FROM Spare
                            WHERE status = 1";
            DataTable dt = new DataTable();

            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);

                dt = DataBase.ExecuteDataTableCommand(command);

                // Se tiene que crear primero la columna asignandole Nombre y Tipo de datos    
                column = new DataColumn();
                column.ColumnName = "Codigo";

                dt.Columns.Add(column);


                int count = dt.Rows.Count;
                int countColumn = dt.Columns.Count;

                logWrite.MensajeFinalizado();

            }
            catch (Exception ex)
            {
                logWrite.MensajeError(ex);
            }
            return dt;
        }

        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        public DataTable SelectLike(string cadenaBuscar)
        {
            logWrite.NameMethod = "SelectLike";
            string query = @"SELECT*
                            FROM Spare
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

        public int Update(Spare t)
        {
            logWrite.NameMethod = "Update";
            int rest = 0;
            string query = @"UPDATE Spare SET  description = @description, nameProduct = @nameProduct, currentBalance = @currentBalance, unitPrice = @unitPrice,    weight = @weight, productCode = @productCode, idFactory = @idFactory, idSpareCategory = @idSpareCategory, idEmploye = @idEmployee, updateDate = CURRENT_TIMESTAMP
                                WHERE idSpare = @idSpare";
            try
            {
                logWrite.MensajeInicio();
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@description", t.Description);
                command.Parameters.AddWithValue("@nameProduct", t.NameProduct);
                command.Parameters.AddWithValue("@currentBalance", t.CurrentBalance);
                command.Parameters.AddWithValue("@unitPrice", t.BasePrice);
                command.Parameters.AddWithValue("@weight", t.Weight);
                command.Parameters.AddWithValue("@productCode", t.ProductCode);
                command.Parameters.AddWithValue("@idFactory", t.IdFactory);
                command.Parameters.AddWithValue("@idSpareCategory", t.IdSpareCategory);
                command.Parameters.AddWithValue("@idEmployee", t.IdEmploye);
                command.Parameters.AddWithValue("@idSpare", t.IdSpare);
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
