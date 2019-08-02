using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures.ParentCategory
{
    public class ParentCategoryHandler
    {
        public void AddParentCategory(ParentCategorys ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    
                    db.ParentCategorys.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<ParentCategorys> GetParentCategory()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.ParentCategorys.ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public ParentCategorys FindParentCategory(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.ParentCategorys.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateParentCategory(ParentCategorys obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    //db.Entry(obj.LineItemDefinition).State = EntityState.Unchanged;
                    db.ParentCategorys.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteParentCategory(ParentCategorys obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.ParentCategorys.Remove(obj);
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
