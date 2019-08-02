using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Purchase.PurchaseItem
{
    public class PurchasessHandler
    {
        public void AddPurchasess(Purchasess obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.Suppliers).State = EntityState.Unchanged;
                    db.Entry(obj.Item).State = EntityState.Unchanged;
                    db.Purchasess.Add(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();

                throw;
            }
        }
        public List<Purchasess> GetPurchasess()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Purchasess.Include("Item").Include("Suppliers").ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public Purchasess FindPurchasess(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Purchasess.Where(s => s.Id == id).Include("Item").Include("Suppliers").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void UpdatePurchasess(Purchasess obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.Suppliers).State = EntityState.Unchanged;
                    db.Entry(obj.Item).State = EntityState.Unchanged;
                    db.Purchasess.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();

                throw;
            }
        }
        public void DeletePurchasess(Purchasess obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Purchasess.Remove(obj);
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
