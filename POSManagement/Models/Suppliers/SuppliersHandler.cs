using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Purchasess
{
    public class SuppliersHandler
    {

        public void AddSuppliers(Supplierss ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Supplierss.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Supplierss> GetSuppliers()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Supplierss.ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Supplierss FindSuppliers(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Supplierss.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateSuppliers(Supplierss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Supplierss.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteSuppliers(Supplierss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Supplierss.Remove(obj);
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
