using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.User
{
    public class UserssHandler
    {
        public void AddUserss(Userss ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.UserssGroups).State = EntityState.Unchanged;
                    db.Userss.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Userss> GetUserss()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Userss.Include("UserssGroups").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Userss FindUserss(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Userss.Where(x => x.Id == id).Include("UserssGroups").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateUserss(Userss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.UserssGroups).State = EntityState.Unchanged;
                    db.Userss.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteUserss(Userss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Userss.Remove(obj);
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
