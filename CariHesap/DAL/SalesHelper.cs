using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CariHesap.MODEL;

namespace CariHesap.DAL
{
    static class SalesHelper
    {

        public static List<SaleDepartmentModel> GetSales()
        {
            using (var che = new CariHesapEntities())
            {
                return che.SaleDapertment.Select(sl => new SaleDepartmentModel
                {
                    SalesId = sl.salesId,
                    ProductId = sl.productId,
                    CustomerId = sl.customerId,
                    Products = sl.Products,
                    Customers = sl.Customers,
                    SellDate = sl.sellDate
                }).ToList();
            }
        }

        public static List<SaleDepartmentModel> FilterSales(string saleType, string queryText, DateTime start, DateTime end)
        {
            using (var che = new CariHesapEntities())
            {
                if (saleType == "Müşteri")
                    //return GetSales().Where(sl => sl.Customers.customerName.Contains(queryText)).Where(sl => sl.SellDate >= start && sl.SellDate <= end).ToList();
                return GetSales().Where(sl => sl.Customers.customerName.StartsWith(queryText) && sl.SellDate >= start && sl.SellDate <= end).ToList();
                else if (saleType == "Ürün Adı")
                    return GetSales().Where(sl => sl.Products.productName.StartsWith(queryText) && sl.SellDate >= start && sl.SellDate <= end).ToList();
                else
                    return GetSales().Where(sl => sl.Products.Categories.categoryName.StartsWith(queryText) && sl.SellDate >= start && sl.SellDate <= end).ToList();
            }
        }
        public static void AddSale(SaleDapertment newSale)
        {
            using (var che = new CariHesapEntities())
            {
                che.Entry(newSale).State = System.Data.Entity.EntityState.Added;
                che.SaveChanges();
            }
        }
    }
}
