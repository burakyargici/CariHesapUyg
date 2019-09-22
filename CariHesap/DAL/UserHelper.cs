using CariHesap.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    static class UserHelper
    {
        public static Users activeUser;
        public static SaveModel SingIn(string userName, string userPassword)
        {
            var saveModel = new SaveModel();

            using (var che = new CariHesapEntities())
            {
                var user = che.Users.FirstOrDefault(usr => usr.userName == userName && usr.userPassword == userPassword);
                if (user != null)
                {
                    saveModel.message = "Hoşgeldiniz";
                    saveModel.isSuccess = true;

                    activeUser = user;
                }
                else
                {
                    saveModel.message = "Böyle bir kullanıcı yok!";
                    saveModel.isSuccess = false;
                }
            }
            return saveModel;
        }
        public static SaveModel UserCUD(Users user, EntityState entityState)
        {
            var saveModel = new SaveModel();
            using (var che = new CariHesapEntities())
            {
                che.Entry(user).State = entityState;

                if (che.SaveChanges() > 0)
                {
                    saveModel.message = "Şifre değişikliği başarı ile gerçekleştirildi";
                    saveModel.isSuccess = true;
                }
                else
                {
                    saveModel.message = "Şifre değişikliği gerçekleşmedi";
                    saveModel.isSuccess = false;
                }
            }
            return saveModel;
        }

    }
}
