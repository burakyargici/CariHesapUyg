using CariHesap.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    
    static class ProductHelper
    {
        public static List<ProductModel> GetProducts()
        {
            using (var che = new CariHesapEntities())
            {
                return che.Products.Select(p => new ProductModel
                {
                    productId = p.productId,
                    productName = p.productName,
                    categoryId = p.categoryId,
                    categories = p.Categories,
                    buyPrice = p.buyPrice,
                    sellPrice = p.sellPrice,
                    stockCount = p.stockCount,
                    description = p.description

                }).ToList();
            }
        }
        public static SaveModel ProductCUD(Products product, EntityState entityState)
        {
            var saveModel = new SaveModel();
            
            using (var che = new CariHesapEntities())
            {
                che.Entry(product).State = entityState;

                if (che.SaveChanges() > 0)
                {
                    saveModel.message = "Ürün işlemi başarıyla yapıldı";
                    saveModel.isSuccess = true;
                }
                else
                {
                    saveModel.message = "Ürün işlemi yapılamadı";
                    saveModel.isSuccess = false;
                }
            }
            return saveModel;
        }
    }
}
