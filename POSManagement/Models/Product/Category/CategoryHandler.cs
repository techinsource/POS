using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.Category
{
    public class CategoryHandler
    {
        public void AddCategory(Categorys ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.LineItemDefinition).State = EntityState.Unchanged;
                    db.Categorys.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Categorys> GetCategory()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Categorys.Include("LineItemDefinition").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Categorys FindCategory(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Categorys.Where(x => x.Id == id).Include("LineItemDefinition").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateCategory(Categorys obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.LineItemDefinition).State = EntityState.Unchanged;
                    db.Categorys.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteCategory(Categorys obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Categorys.Remove(obj);
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
