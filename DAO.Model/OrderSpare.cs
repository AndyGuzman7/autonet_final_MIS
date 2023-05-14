using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class OrderSpare:BaseModel
    {
        #region Atributes
        public int IdOrder { get; set; }
        public int IdSpare { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }


        #endregion

        #region Cosntructors
        public OrderSpare()
        {

        }
        /// <summary>
        /// Select
        /// </summary>
        /// <param name="idOrder"></param>
        /// <param name="idSpare"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="total"></param>
        public OrderSpare(int idOrder, int idSpare, int quantity, double unitPrice, short idEmployeeAdd, byte status, DateTime registrationDate, DateTime dateUpdate, double total)
        : base(status, registrationDate, dateUpdate, idEmployeeAdd)
        {
            IdOrder = idOrder;
            IdSpare = idSpare;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Total = total;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idSpare"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="total"></param>

        public OrderSpare(int idSpare, int quantity, double unitPrice, short idEmployeeAdd, double total)
        {
            
            IdSpare = idSpare;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Total = total;
            IdEmploye = idEmployeeAdd;
        }




        #endregion


    }
}
