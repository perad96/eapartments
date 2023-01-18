using EApartments.DB;
using EApartments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EApartments.Services
{
    public class AuthService
    {
        AppDbContext appDbContext = new AppDbContext();

        public User LogIn(string username, string password)
        {
            appDbContext = new AppDbContext();
            password = this.Md5Hash(password);
            var user = appDbContext.User.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }


        private string Md5Hash(string password)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
        }
    }
}
