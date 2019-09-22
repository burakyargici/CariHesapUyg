using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.MODEL
{
    class ProductModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int categoryId { get; set; }
        public int buyPrice { get; set; }
        public int sellPrice { get; set; }
        public int stockCount { get; set; }
        public string description { get; set; }
        public Categories categories { get; set; }


    }
}
