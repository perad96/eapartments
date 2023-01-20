using EApartments.DB;
using EApartments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EApartments.Services
{
    public class OccupantService
    {
        AppDbContext appDbContext = new AppDbContext();


        /// <summary>
        ///    Get all occupant
        /// </summary>
        public List<Occupant> GetAllOccupants()
        {
            return this.appDbContext.Occupant.ToList();
        }


        /// <summary>
        ///    Add occupant
        /// </summary>
        /// <param name="occupant"></param>
        public bool AddOccupant(Occupant occupant)
        {
            try
            {
                var result = this.appDbContext.Occupant.Add(occupant);
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
        ///    Update occupant
        /// </summary>
        /// <param name="occupant"></param>
        public bool UpdateOccupant(Occupant occupant)
        {
            try
            {
                Occupant updateObj = this.appDbContext.Occupant.Where(obj => obj.Id == occupant.Id).FirstOrDefault();
                updateObj.ChiefOccupantId = occupant.ChiefOccupantId;
                updateObj.RelationshipToChiefOccupant = occupant.RelationshipToChiefOccupant;
                updateObj.FirstName = occupant.FirstName;
                updateObj.LastName = occupant.LastName;
                updateObj.Address = occupant.Address;
                updateObj.Nic = occupant.Nic;
                updateObj.Email = occupant.Email;
                updateObj.Phone = occupant.Phone;
                updateObj.EmergencyContact = occupant.EmergencyContact;

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
        ///    Delete occupant
        /// </summary>
        /// <param name="occupant"></param>
        public bool DeleteOccupant(Occupant occupant)
        {
            try
            {
                this.appDbContext.Occupant.Attach(occupant);
                var result = this.appDbContext.Occupant.Remove(occupant);
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

    }
}
