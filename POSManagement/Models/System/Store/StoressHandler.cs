using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.System.Store
{
    public class StoressHandler
    {
        public void AddStoress(Storess ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.Userss).State = EntityState.Unchanged;
                    db.Storess.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Storess> GetStoress()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Storess.Include("Userss").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Storess FindStoress(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Storess.Where(x => x.Id == id).Include("Userss").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateStoress(Storess obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.Userss).State = EntityState.Unchanged;
                    db.Storess.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteStoress(Storess obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Storess.Remove(obj);
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
