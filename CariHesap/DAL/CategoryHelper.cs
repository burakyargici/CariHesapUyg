using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    class CategoryHelper
    {

        public static List<Categories> GetCategories()
        {
            using (var che = new CariHesapEntities())
            {
                return che.Categories.ToList();
            }
        }
        public static List<string> GetCategoryNames()
        {
            using (var che = new CariHesapEntities())
            {
                return che.Categories.Select(c=> c.categoryName).ToList();
            }
        }

        public static Categories GetCategoryByName(string name)
        {
            using (var che = new CariHesapEntities())
            {
                return che.Categories.FirstOrDefault(c=> c.categoryName == name);
            }
        }
        public static bool CategoryCUD(Categories categories, EntityState entityState)
        {
            using (var che = new CariHesapEntities())
            {
                che.Entry(categories).State = entityState;
                return che.SaveChanges() > 0;
            }
        }
    }
}
