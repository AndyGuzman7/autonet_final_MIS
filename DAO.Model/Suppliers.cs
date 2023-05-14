using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Suppliers:BaseModel
    {
        #region Properties
        public int IdSuppliers { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Nit { get; set; }


        #endregion


        #region Constructor
        /// <summary>
        /// Defecto
        /// </summary>
        public Suppliers()
        {

        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="idSuppliers"></param>
        /// <param name="contactName"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="nit"></param>
        public Suppliers(int idSuppliers, string contactName, string address, int phone, DateTime dateUpdate, short idEmployeeAdd, byte status, DateTime registrationDate, string nit)
         : base(status, registrationDate, dateUpdate, idEmployeeAdd)
        {
            IdSuppliers = idSuppliers;
            ContactName = contactName;
            Address = address;
            Phone = phone;
            Nit = nit;
        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idSuppliers"></param>
        /// <param name="contactName"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="nit"></param>
        public Suppliers( string contactName, string address, int phone, short idEmployeeAdd, string nit)
        {
        
            ContactName = contactName;
            Address = address;
            Phone = phone;
            Nit = nit;
            IdEmploye = idEmployeeAdd;
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="idSuppliers"></param>
        /// <param name="contactName"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="nit"></param>
        public Suppliers(int idSuppliers, string contactName, string address, int phone, short idEmployeeAdd, string nit)

        {
            IdSuppliers = idSuppliers;
            ContactName = contactName;
            Address = address;
            Phone = phone;
            Nit = nit;
            IdEmploye = idEmployeeAdd;
        }








        #endregion
    }
}
