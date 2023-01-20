using EApartments.DB;
using EApartments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Services
{
    public class AuthService
    {
        AppDbContext appDbContext = new AppDbContext();
        UserService _userService = new UserService();
        OccupantService _occupantService = new OccupantService();

        /// <summary>
        ///    User Login function
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
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
        
        
        /// <summary>
        ///    Customer registration function
        /// </summary>
        /// <param name="occupant"></param>
        /// <param name="user"></param>
        public User Register(Occupant occupant, User user)
        {
            var transaction = this.appDbContext.Database.BeginTransaction();
            try 
            {
                if (this._userService.IsExistUsername(user))
                {
                    MessageBox.Show("Username already taken!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                user.Password = this.Md5Hash(user.Password);
                user.RoleId = 3; // Occupant
                var result = this.appDbContext.User.Add(user);
                this.appDbContext.SaveChanges();

                if (result != null)
                {
                    occupant.UserId = result.Id;
                    this._occupantService.AddOccupant(occupant);
                    this.appDbContext.SaveChanges();
                    transaction.Commit();
                    return user;
                }

                transaction.Rollback();
                MessageBox.Show("Registration failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        ///    Password hash function
        /// </summary>
        /// <param name="password"></param>
        private string Md5Hash(string password)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
        }
    }
}
