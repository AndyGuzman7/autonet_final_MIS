using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Spare(int idSpare, string nameProduct, int currentBalance)
        {
            IdSpare = idSpare;
            NameProduct = nameProduct;
            CurrentBalance = currentBalance;
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
            this.IdSpareCategory = idSpareCategory;
            this.Description = descrirption;
            this.NameProduct = nameProduct;
            this.CurrentBalance = currentBalance;
            this.BasePrice = unitPrice;
            this.Weight = weight;
            this.ProductCode = productCode;
            this.Status = status;
            this.RegistrationDate = registerDate;
            this.DateUpdate = updateDate;
            this.IdEmploye = idEmploye;
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


        Spare FromDataTable(DataRow data)
        {
            List<Spare> spares = new List<Spare>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataRow, Spare>()
                    .ForMember(dest => dest.IdSpare, opt => opt.MapFrom(src => Convert.ToInt32(src["idSpare"].ToString())))
                    .ForMember(dest => dest.IdFactory, opt => opt.MapFrom(src => Convert.ToInt32(src["idFactory"])))
                    .ForMember(dest => dest.IdSpareCategory, opt => opt.MapFrom(src => Convert.ToInt32(src["idSpareCategory"])))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src["description"]))
                    .ForMember(dest => dest.NameProduct, opt => opt.MapFrom(src => src["nameProduct"]))
                    .ForMember(dest => dest.CurrentBalance, opt => opt.MapFrom(src => Convert.ToInt32(src["currentBalance"])))
                    .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => Convert.ToDouble(src["unitPrice"])))
                    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => Convert.ToDouble(src["weight"])))
                    .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src["productCode"]))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Convert.ToInt32(src["status"])))
                    .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => Convert.ToDateTime(src["registerDate"])))
                    .ForMember(dest => dest.DateUpdate, opt => opt.MapFrom(src => Convert.ToDateTime(src["updateDate"])))
                    .ForMember(dest => dest.IdEmploye, opt => opt.MapFrom(src => Convert.ToInt32(src["idEmploye"])));
            });

            IMapper mapper = config.CreateMapper();


            Spare persona = mapper.Map<DataRow, Spare>(data);
            return persona;


        }
    }
}
