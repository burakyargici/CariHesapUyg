using System;
using System.Collections.Generic;
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

        public static Categories GetCategoryByName(string name)
        {
            using (var che = new CariHesapEntities())
            {
                return che.Categories.FirstOrDefault(c=> c.categoryName == name);
            }
        }
    }
}
