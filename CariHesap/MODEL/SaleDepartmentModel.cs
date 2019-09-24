using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.MODEL
{
    class SaleDepartmentModel
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public System.DateTime SellDate { get; set; }
        public int CustomerId { get; set; }

        public Customers Customers { get; set; }
        public Products Products { get; set; }
    }
}
