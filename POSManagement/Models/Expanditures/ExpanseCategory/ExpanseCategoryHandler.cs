using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures.ExpanseCategory
{
    public class ExpanseCategoryHandler
    {
        public void AddExpanseCategory(ExpanseCategory ob)
        {
            try
            {
                using (Context db = new Context())
                {
                   // db.Entry(ob.ParentCategorys).State = EntityState.Unchanged;
                    db.ExpanseCategory.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<ExpanseCategory> GetExpanseCategory()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.ExpanseCategory.ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public ExpanseCategory FindExpanseCategory(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.ExpanseCategory.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateExpanseCategory(ExpanseCategory obj)
        {
            try
            {
                using (Context db = new Context())
                {
                   // db.Entry(obj.ParentCategorys).State = EntityState.Unchanged;
                    db.ExpanseCategory.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteExpanseCategory(ExpanseCategory obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.ExpanseCategory.Remove(obj);
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
