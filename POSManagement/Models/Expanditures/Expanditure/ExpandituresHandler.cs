using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures
{
    public class ExpandituresHandler
    {
        public void AddExpanditures(Expanditures ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.Categorys).State = EntityState.Unchanged;
                    db.Expanditures.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Expanditures> GetExpanditures()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Expanditures.Include("Categorys").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Expanditures FindExpanditures(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Expanditures.Where(x => x.Id == id).Include("Categorys").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateExpanditures(Expanditures obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.Categorys).State = EntityState.Unchanged;
                    db.Expanditures.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteExpanditures(Expanditures obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Expanditures.Remove(obj);
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
