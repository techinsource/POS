using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSManagement.Models.Purchasess;

namespace POSManagement.Controllers
{
    public class SuppliersController : Controller
    {
        string result = string.Empty;
        public IActionResult AddSuppliers()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddSuppliers(Supplierss obj)
        {
            try
            {
                Supplierss sup = new Supplierss();
                sup.Name = obj.Name;
                sup.Email = obj.Email;
                sup.Mobile = obj.Mobile;
                sup.Address = obj.Address;
                sup.IsActive = true;
                sup.CreatedBy = "Bilal";
                sup.CreatedOn = DateTime.Now;
                sup.UpdatedBy = "Bilal";
                sup.UpdatedOn = DateTime.Now;
                new SuppliersHandler().AddSuppliers(sup);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetSuppliers()
        {
            try
            {
                List<Supplierss> result = new SuppliersHelper().GetSuppliers();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindSuppliers(int id)
        {

            Supplierss fined = new SuppliersHandler().FindSuppliers(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateSuppliers(Supplierss obj)
        {
            try
            {
                Supplierss check = new SuppliersHandler().FindSuppliers(obj.Id);
                if (check != null)
                {
                    Supplierss sup = new Supplierss();
                    sup.Id = obj.Id;
                    sup.Name = obj.Name;
                    sup.Email = obj.Email;
                    sup.Mobile = obj.Mobile;
                    sup.Address = obj.Address;
                    sup.IsActive = true;
                    sup.CreatedBy = "Bilal";
                    sup.CreatedOn = DateTime.Now;
                    sup.UpdatedBy = "Bilal";
                    sup.UpdatedOn = DateTime.Now;
                    new SuppliersHandler().UpdateSuppliers(sup);
                    result = "success";
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }


        }
        public IActionResult DeleteSuppliers(int id)
        {
            Supplierss sup = new SuppliersHandler().FindSuppliers(id);
            if (sup != null)
            {
                new SuppliersHandler().DeleteSuppliers(sup);
                result = "success";
            }
            return Json(result);


        }
    }
}