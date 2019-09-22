using CariHesap.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CariHesap.DAL
{
    static class CustomerHelper
    {
        public static List<Customers> GetCustomersByUserId(int userId)
        {
            using (var che = new CariHesapEntities())
            {
                return che.Customers.Where(cs => cs.userId == userId).ToList();
            }
        }

        public static SaveModel CustomerCUD(Customers customer, EntityState entityState)
        {
            var saveModel = new SaveModel();
            using (var che = new CariHesapEntities())
            {
                che.Entry(customer).State = entityState;

                if (che.SaveChanges() > 0)
                {
                    saveModel.message = "Müşteri verileri güncellendi";
                    saveModel.isSuccess = true;
                }
                else
                {
                    saveModel.message = "Müşteri verileri güncellenmedi";
                    saveModel.isSuccess = false;
                }
            }
            return saveModel;
        }
    }
}
