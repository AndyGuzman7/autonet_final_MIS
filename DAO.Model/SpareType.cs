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
        public byte IdSpareType { get; set; }
        public byte IdSpareCategory { get; set; }
        public string NameSpareType { get; set; }
        #endregion

        #region Constructors
        public SpareType()
        {

        }

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="idSpareType"></param>
        /// <param name="nameSpareType"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="idEmploye"></param>

        public SpareType(byte idSpareType, string nameSpareType, byte idSpareCategory, short idEmploye, byte status, DateTime registrationDate, DateTime dateUpdate )
            :base( status, registrationDate, dateUpdate, idEmploye)
        { 
            IdSpareType = idSpareType;
            IdSpareCategory = idSpareCategory;
            NameSpareType = nameSpareType;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="nameSpareType"></param>
        /// <param name="idSpareCategory"></param>
        /// <param name="idEmploye"></param>
        public SpareType(string nameSpareType, byte idSpareCategory, short idEmploye)
        {
            NameSpareType = nameSpareType;
            IdSpareCategory = idSpareCategory;
            IdEmploye = idEmploye;
        }







        #endregion
        #region Methods
        #endregion

    }
}
