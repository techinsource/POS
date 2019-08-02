using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.ItemTemplate
{
    public class ItemTemplateHandler
    {

        public void AddItemTemplate(Item_Template ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.LineItemDefinition).State = EntityState.Unchanged;
                    db.Item_Templates.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Item_Template> GetItemTemplate()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Item_Templates.Include("LineItemDefinition").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Item_Template FindItemTemplate(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Item_Templates.Where(x => x.Id == id).Include("LineItemDefinition").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateItemTemplate(Item_Template obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.LineItemDefinition).State = EntityState.Unchanged;
                    db.Item_Templates.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteItemTemplate(Item_Template obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Item_Templates.Remove(obj);
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
