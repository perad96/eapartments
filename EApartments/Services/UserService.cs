using EApartments.DB;
using EApartments.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Services
{
    public class UserService
    {
        AppDbContext appDbContext = new AppDbContext();


        /// <summary>
        ///    Get all users list
        /// </summary>
        public IList All()
        {
            var result = this.appDbContext.User.Join(appDbContext.Role,
                user => user.RoleId,
                role => role.Id,
                (user, role) => new {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    RoleName = role.Name
                })
                .Select(r => new
                {
                    r.Id,
                    r.FirstName,
                    r.LastName,
                    r.RoleName
                }).ToList();

            return result;
        }


        /// <summary>
        ///    Add new user
        /// </summary>
        /// <param name="user"></param>
        public bool Add(User user)
        {
            try
            {
                if(this.IsExistUsername(user))
                {
                    MessageBox.Show("Username already taken!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                user.Password = this.Md5Hash(user.Password);
                var result = this.appDbContext.User.Add(user);
                this.appDbContext.SaveChanges();

                if (result != null)
                {
                    return true;
                }

                MessageBox.Show("User add failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        ///    Update user info 
        /// </summary>
        /// <param name="user"></param>
        public bool Update(User user)
        {
            try
            {
                User updateObj = this.appDbContext.User.Where(obj => obj.Id == user.Id).FirstOrDefault();
                updateObj.FirstName = user.FirstName;
                updateObj.LastName = user.LastName;
                updateObj.Username = user.Username;
                updateObj.Password = this.Md5Hash(user.Password);
                updateObj.RoleId = user.RoleId;

                this.appDbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        ///    Delete user
        /// </summary>
        /// <param name="user"></param>
        public bool Delete(User user)
        {
            try
            {
                this.appDbContext.User.Attach(user);
                var result = this.appDbContext.User.Remove(user);
                this.appDbContext.SaveChanges();

                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        ///    Check is exist username
        /// </summary>
        /// <param name="user"></param>
        public bool IsExistUsername(User user)
        {
            try
            {
                User userObj = this.appDbContext.User.Where(obj => obj.Username == user.Username).FirstOrDefault();
                
                if (userObj != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        ///    Password hash
        /// </summary>
        /// <param name="password"></param>
        private string Md5Hash(string password)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
        }
    }
}
