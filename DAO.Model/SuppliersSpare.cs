using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class SuppliersSpare:BaseModel
    {
        #region Atributes
        public int IdSpare { get; set; }
        public int IdSuppliers { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public double AcquiredPrice { get; set; }

        #endregion
        #region Constructors

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="idSpare"></param>
        /// <param name="idSuppliers"></param>
        /// <param name="quantity"></param>
        /// <param name="total"></param>
        /// <param name="acquiredprice"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="idEmploye"></param>
        public SuppliersSpare(int idSpare, int idSuppliers, int quantity, double total, double acquiredprice, short idEmploye, byte status, DateTime registrationDate, DateTime dateUpdate)
        :base(status, registrationDate,dateUpdate,idEmploye)
        {
            IdSpare = idSpare;
            IdSuppliers = idSuppliers;
            Quantity = quantity;
            AcquiredPrice = acquiredprice;
            Total = total;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idSpare"></param>
        /// <param name="idSuppliers"></param>
        /// <param name="quantity"></param>
        /// <param name="total"></param>
        /// <param name="acquiredprice"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="idEmploye"></param>

        public SuppliersSpare(int idSpare, int idSuppliers, int quantity, double total, double acquiredprice, short idEmployeeAdd)
        {
            IdSpare = idSpare;
            IdSuppliers = idSuppliers;
            Quantity = quantity;
            AcquiredPrice = acquiredprice;
            Total = total;
            IdEmploye = idEmployeeAdd;
        }
        #endregion

    }
}
