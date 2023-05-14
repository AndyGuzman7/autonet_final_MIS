using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class BaseModel
    {

        #region Properties


        public byte Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DateUpdate { get; set; }
        public short IdEmploye { get; set; }
        #endregion

        #region Contructors

        public BaseModel()
        {

        }

        public BaseModel(byte status, DateTime registrationDate, DateTime dateUpdate, short idEmploye)
        {
            Status = status;
            RegistrationDate = registrationDate;
            DateUpdate = dateUpdate;
            IdEmploye = idEmploye;
        }

        #endregion
    }
}
