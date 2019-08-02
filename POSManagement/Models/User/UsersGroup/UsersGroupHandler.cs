using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.User.UsersGroup
{
    public class UsersGroupHandler
    {

        public void AddUsersGroup(UserssGroup ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.UserssGroup.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<UserssGroup> GetUsersGroup()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.UserssGroup.ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public UserssGroup FindUsersGroup(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.UserssGroup.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateUsersGroup(UserssGroup obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.UserssGroup.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteUsersGroup(UserssGroup obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.UserssGroup.Remove(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }
    }
}
