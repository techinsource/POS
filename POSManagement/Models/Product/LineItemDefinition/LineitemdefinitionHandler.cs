using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSAnventory.Models.Items
{
    public class LineitemdefinitionHandler
    {
        public void AddLineitemdefinition(LineItemDefinition ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.LineItemDefinitions.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<LineItemDefinition> GetLineitemdefinition()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.LineItemDefinitions.ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public LineItemDefinition FindLineitemdefinition(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.LineItemDefinitions.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateLineitemdefinition(LineItemDefinition obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.LineItemDefinitions.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteLineitemdefinition(LineItemDefinition obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.LineItemDefinitions.Remove(obj);
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
