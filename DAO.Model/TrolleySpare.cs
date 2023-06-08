using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class TrolleySpare
    {

        public int Quantity { get; set; }
        public double Total { get; set; }
        public string NameProduct { get; set; }
        public Spare Spare { get; set; }
        public double BasePrice { get; set; }
        public string ProductCode { get; set; }

        public TrolleySpare() { }

        public TrolleySpare(Spare spare)
        {
            this.NameProduct = spare.NameProduct;
            this.Quantity = 1;
            this.BasePrice = spare.BasePrice;
            this.ProductCode = spare.ProductCode;

            this.Total = spare.BasePrice;
            this.Spare = spare;
        } 


        public void ChangeQuantity(int quantity)
        {
            this.Quantity = quantity;
        }

        public void MasCantidad()
        {
            this.Quantity++;
            this.Total = this.Quantity * this.BasePrice;
        }

        public void MenosCantidad()
        {
            this.Quantity--;
            this.Total = this.Quantity * this.BasePrice;
        }
    }
}
