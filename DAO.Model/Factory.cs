using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Factory:BaseModel
    {
        #region Properties

        public int IdFactory { get; set; }
        public string NameFactory { get; set; }
        public string NameCityOrCountry { get; set; }



        #endregion

        #region Constructor

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="idFactory"></param>
        /// <param name="nameFactory"></param>
        /// <param name="nameCityOrCountry"></param>
        /// <param name="idEmployeeAdd"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        public Factory(int idFactory, string nameFactory, string nameCityOrCountry, short idEmployeeAdd, byte status, DateTime registrationDate, DateTime dateUpdate)
        : base(status, registrationDate, dateUpdate, idEmployeeAdd)
        {
            IdFactory = idFactory;
            NameFactory = nameFactory;
            NameCityOrCountry = nameCityOrCountry;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="nameFactory"></param>
        /// <param name="nameCityOrCountry"></param>
        /// <param name="idEmployeeAdd"></param>
        public Factory(string nameFactory, string nameCityOrCountry, short idEmployeeAdd)
        {
            NameFactory = nameFactory;
            NameCityOrCountry = nameCityOrCountry;
            IdEmploye = idEmployeeAdd;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="idFactory"></param>
        /// <param name="nameFactory"></param>
        /// <param name="nameCityOrCountry"></param>
        /// <param name="idEmployeeAdd"></param>
        public Factory(int idFactory, string nameFactory, string nameCityOrCountry, short idEmployeeAdd)
        {
            IdFactory = idFactory;
            NameFactory = nameFactory;
            NameCityOrCountry = nameCityOrCountry;
            IdEmploye = idEmployeeAdd;
        }





        #endregion
    }
}
