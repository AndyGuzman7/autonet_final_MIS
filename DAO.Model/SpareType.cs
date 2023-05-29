using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SpareType : BaseModel
    {
        #region properties
        //public byte IdSpareType { get; set; }
        public byte IdSpareCategory { get; set; }
        public string NameSpareCategory { get; set; }
        #endregion

        #region Constructors
        public SpareType()
        {

        }

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="nameSpareCategory"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="idEmploye"></param>

        public SpareType(byte idSpareCategory, string nameSpareCategory, short idEmploye, byte status, DateTime registrationDate, DateTime dateUpdate )
            :base( status, registrationDate, dateUpdate, idEmploye)
        { 
            IdSpareCategory = idSpareCategory;
            NameSpareCategory = nameSpareCategory;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="nameSpareCategory"></param>
        /// <param name="idEmploye"></param>
        public SpareType(string nameSpareCategory, short idEmploye)
        {
            NameSpareCategory = nameSpareCategory;
            IdEmploye = idEmploye;
        }







        #endregion
        #region Methods
        #endregion

    }
}
