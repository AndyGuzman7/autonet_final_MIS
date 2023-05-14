using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Order:BaseModel
    {
        #region properties
        
        public int IdOrder { get; set; }
       
        public int IdClient { get; set; }
        public double ClientPay { get; set; }


        #endregion


        #region constructor

        public Order()
        {

        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="idOrder"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="total"></param>
        /// <param name="idClient"></param>
        public Order(int idOrder, short idEmployeeAdd, byte status, DateTime registrationDate, DateTime dateUpdate,  int idClient, double clientPay)
             : base(status, registrationDate, dateUpdate, idEmployeeAdd)
        {
            IdOrder = idOrder;
            ClientPay = clientPay;
            IdClient = idClient;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="total"></param>
        /// <param name="idClient"></param>
        public Order(short idEmployeeAdd, int idClient, double clientPay)
        {
            
            IdClient = idClient;
            ClientPay = clientPay;
            IdEmploye = idEmployeeAdd;
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="idOrder"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="total"></param>
        /// <param name="idClient"></param>
        public Order(int idOrder, short idEmployeeAdd, double total, int idClient, double clientPay)
        {
            IdOrder = idOrder;
            ClientPay = clientPay;
            IdClient = idClient;
            IdEmploye = idEmployeeAdd;
        }




        #endregion
    }
}
