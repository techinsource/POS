using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.ItemGroup
{
    public class ItemGroupHandler
    {

        public void AddItemGroup(ItemGroups ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(ob.LineItemDefinition).State = EntityState.Unchanged;
                    db.ItemGroups.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<ItemGroups> GetItemGroup()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.ItemGroups.Include("LineItemDefinition").ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public ItemGroups FindItemGroup(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.ItemGroups.Where(x => x.Id == id).Include("LineItemDefinition").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateItemGroup(ItemGroups obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.LineItemDefinition).State = EntityState.Unchanged;
                    db.ItemGroups.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteItemGroup(ItemGroups obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.ItemGroups.Remove(obj);
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
