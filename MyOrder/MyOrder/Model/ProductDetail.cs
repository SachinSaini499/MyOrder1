using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Model
{
   public class ProductDetail
    {
        public ProductDetail()
        {

        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductCategary { get; set; }

        public string ProductCost { get; set; }

        public byte[] ProductImage { get; set; }
        public string ManufacteringDate { get; set; }

    }
}
