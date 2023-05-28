using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Spare : BaseModel
    {

        #region Properties

        //public int Quantity { get; set; } //Esto quitar
        //public double Total { get; set; } //Esto quitar
        public int IdSpare { get; set; }
        public string Description { get; set; }
        public string NameProduct { get; set; }
        public int CurrentBalance { get; set; }
        public double BasePrice { get; set; }
        public double Weight { get; set; }
        public string ProductCode { get; set; }
        public int IdFactory { get; set; }
        public int IdSpareCategory { get; set; }
        public List<string> ListaString { get; set; }

        #endregion

        #region Constructors
        public Spare()
        {

        }

        public Spare(int idSpare, string nameProduct)
        {
            IdSpare = idSpare;
            NameProduct = nameProduct;
        }


        /// <summary>
        /// SelectExt
        /// </summary>
        /// <param name="idSpare"></param>
        /// <param name="description"></param>
        /// <param name="nameProduct"></param>
        /// <param name="currentBalance"></param>
        /// <param name="basePrice"></param>
        /// <param name="weight"></param>
        /// <param name="productCode"></param>
        /// <param name="idFactory"></param>
        /// <param name="idSpareCategory"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="idEmploye"></param>
        public Spare(int idSpare, string description, string nameProduct, int currentBalance, double basePrice, double weight, string productCode, int idFactory, int idSpareCategory, byte status, DateTime registrationDate, DateTime dateUpdate, short idEmploye, List<string> listString)
                     : base(status, registrationDate, dateUpdate, idEmploye)
        {
            IdSpare = idSpare;
            Description = description;
            NameProduct = nameProduct;
            CurrentBalance = currentBalance;
            BasePrice = basePrice;
            Weight = weight;
            ProductCode = productCode;
            IdFactory = idFactory;
            IdSpareCategory = idSpareCategory;
            
            ListaString = listString;
        }



        /// <summary>
        /// Select
        /// </summary>
        /// <param name="idSpare"></param>
        /// <param name="description"></param>
        /// <param name="nameProduct"></param>
        /// <param name="currentBalance"></param>
        /// <param name="basePrice"></param>
        /// <param name="weight"></param>
        /// <param name="productCode"></param>
        /// <param name="idFactory"></param>
        /// <param name="idSpareCategory"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="idEmploye"></param>
        public Spare(int idSpare, string description, string nameProduct, int currentBalance, double basePrice, double weight, string productCode, int idFactory, int idSpareCategory, byte status, DateTime registrationDate, DateTime dateUpdate, short idEmploye)
                     :base(status, registrationDate, dateUpdate, idEmploye)
        {
            IdSpare = idSpare;
            Description = description;
            NameProduct = nameProduct;
            CurrentBalance = currentBalance;
            BasePrice = basePrice;
            Weight = weight;
            ProductCode = productCode;
            IdFactory = idFactory;
            IdSpareCategory = idSpareCategory;
            
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="description"></param>
        /// <param name="nameProduct"></param>
        /// <param name="currentBalance"></param>
        /// <param name="basePrice"></param>
        /// <param name="weight"></param>
        /// <param name="productCode"></param>
        /// <param name="idFactory"></param>
        /// <param name="idSpareCategory"></param>
        /// <param name="idEmploye"></param>
        public Spare(string description, string nameProduct, int currentBalance, double basePrice, double weight, string productCode, int idFactory, int idSpareCategory, short idEmploye)
        {
            Description = description;
            NameProduct = nameProduct;
            CurrentBalance = currentBalance;
            BasePrice = basePrice;
            Weight = weight;
            ProductCode = productCode;
            IdFactory = idFactory;
            IdSpareCategory = idSpareCategory;
            IdEmploye = idEmploye;
        }


        public Spare(int quantity, double total, int idSpare, string description, string nameProduct, int currentBalance, double basePrice, double weight, string productCode, int idFactory, int idSpareType, List<string> listaString)
        {
            Quantity = quantity;
            Total = total;
            IdSpare = idSpare;
            Description = description;
            NameProduct = nameProduct;
            CurrentBalance = currentBalance;
            BasePrice = basePrice;
            Weight = weight;
            ProductCode = productCode;
            IdFactory = idFactory;
            IdSpareType = idSpareType;
            ListaString = listaString;
        }




        public Spare(int idSpare, 
                        int idFactory, 
                        int idSpareCategory,
                        string descrirption,
                        string nameProduct,
                        int currentBalance,
                        double unitPrice,
                        double weight,
                        string productCode,
                        byte status,
                        DateTime registerDate,
                        DateTime updateDate,
                        short idEmploye)
        {
            this.IdSpare = idSpare;
            this.IdFactory = idFactory;
            this.IdSpareType = idSpareCategory;
            this.Description= descrirption; 
            this.NameProduct= nameProduct;
            this.CurrentBalance = currentBalance;
            this.BasePrice= unitPrice;
            this.Weight = weight;
            this.ProductCode = productCode;
            this.Status = status;
            this.RegistrationDate= registerDate;
            this.DateUpdate= updateDate;
            this.IdEmploye= idEmploye;
        }

        #endregion

        #region Methods

        /*public void MasCantidad()
        {
            Quantity++;
            Total = Quantity * BasePrice;
        }
        public void MenosCantidad()
        {
            Quantity--;
            Total = Quantity * BasePrice;
        }
        */
        #endregion
    }
}
