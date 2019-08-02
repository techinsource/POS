using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.Sub_Category
{
    public class Sub_CategoryHandler
    {
        public void AddSubCategory(Sub_Categorys ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.Category).State = EntityState.Unchanged;
                    db.Sub_Categorys.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Sub_Categorys> GetSubCategory()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Sub_Categorys.Include("Category").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Sub_Categorys FindSubCategory(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Sub_Categorys.Where(x => x.Id == id).Include("Category").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateSubCategory(Sub_Categorys obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.Category).State = EntityState.Unchanged;
                    db.Sub_Categorys.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteSubCategory(Sub_Categorys obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Sub_Categorys.Remove(obj);
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
