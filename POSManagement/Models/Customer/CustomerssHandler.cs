using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Customer
{
    public class CustomerssHandler
    {
        public void AddCustomerss(Customerss ob)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Customerss.Add(ob);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public List<Customerss> GetCustomerss()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Customerss.ToList();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();
                throw;
            }
        }
        public Customerss FindCustomerss(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Customerss.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string result = ex.ToString();

                throw;
            }
        }
        public void UpdateCustomerss(Customerss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Customerss.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void DeleteCustomerss(Customerss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Customerss.Remove(obj);
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
