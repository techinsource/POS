using Microsoft.EntityFrameworkCore;
using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Quotation
{
    public class QuotationssHandler
    {
        public void AddQuotationss(Quotationss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.Suppllierss).State = EntityState.Unchanged;
                    db.Entry(obj.Customerss).State = EntityState.Unchanged;
                    db.Quotationss.Add(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();

                throw;
            }
        }
        public List<Quotationss> GetQuotationss()
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Quotationss.Include("Customerss").Include("Suppllierss").ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public Quotationss FindQuotationss(int id)
        {
            try
            {
                using (Context db = new Context())
                {
                    return db.Quotationss.Where(s => s.Id == id).Include("Customerss").Include("Suppllierss").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }
        }

        public void UpdateQuotationss(Quotationss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Entry(obj.Customerss).State = EntityState.Unchanged;
                    db.Entry(obj.Suppllierss).State = EntityState.Unchanged;
                    db.Quotationss.Update(obj);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();

                throw;
            }
        }
        public void DeleteQuotationss(Quotationss obj)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.Quotationss.Remove(obj);
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
