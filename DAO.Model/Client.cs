using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Client:BaseModel
    {
        #region

        public int IdClient { get; set; }
        public string Nit { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }





        #endregion


        #region Constructor
        public Client()
        {

        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="fistName"></param>
        /// <param name="lastName"></param>
        public Client(int idClient, string nit, short idEmployeeAdd, byte status, DateTime registrationDate, DateTime dateUpdate, string fistName, string lastName)
             : base(status, registrationDate, dateUpdate, idEmployeeAdd)
        {
            IdClient = idClient;
            Nit = nit;
            FistName = fistName;
            LastName = lastName;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="fistName"></param>
        /// <param name="lastName"></param>
        public Client(string nit,string fistName, string lastName, short idEmploye)  
        {
            Nit = nit;
            FistName = fistName;
            LastName = lastName;
            IdEmploye = idEmploye;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="nit"></param>
        /// <param name="fistName"></param>
        /// <param name="lastName"></param>
        /// <param name="idEmploye"></param>
        public Client(int idClient, string nit, string fistName, string lastName, short idEmploye)
        {
            IdClient = idClient;
            Nit = nit;
            FistName = fistName;
            LastName = lastName;
            IdEmploye = idEmploye;
        }
    }





        #endregion
    }

