using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSAnventory.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace POSManagement.Models.Item
{
    public class ItemHandler
    {
        public void AddItem(Itemd ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.LineItemDefinition).State = EntityState.Unchanged;
                    db.Itemds.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Itemd> GetItem()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Itemds.Include("LineItemDefinition").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Itemd FindItem(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Itemds.Where(x => x.Id == id).Include("LineItemDefinition").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateItem(Itemd obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.LineItemDefinition).State = EntityState.Unchanged;
                    db.Itemds.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteItem(Itemd obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Itemds.Remove(obj);
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
