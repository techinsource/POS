using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSManagement.Models.Customer;

namespace POSManagement.Controllers
{
    public class CustomerssController : Controller
    {
        string result = string.Empty;
        public IActionResult AddCustomerss()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCustomerss(Customerss obj)
        {
            try
            {
                Customerss cus = new Customerss();
                cus.Name = obj.Name;
                cus.Creditbalance = obj.Creditbalance;
                cus.Phone = obj.Phone;
                cus.Email = obj.Email;
                cus.Sex = obj.Sex;
                cus.Age = obj.Age;
                cus.Address = obj.Address;
                cus.City = obj.City;
                cus.Country = obj.Country;
                cus.Order = obj.Order;
                cus.IsActive = true;
                cus.CreatedBy = "Bilal";
                cus.CreatedOn = DateTime.Now;
                cus.UpdatedBy = "Bilal";
                cus.UpdatedOn = DateTime.Now;
                new CustomerssHandler().AddCustomerss(cus);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetCustomerss()
        {
            try
            {
                List<Customerss> result = new CustomerssHelper().GetCustomerss();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindCustomerss(int id)
        {

            Customerss fined = new CustomerssHandler().FindCustomerss(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateCustomerss(Customerss obj)
        {
            try
            {
                Customerss check = new CustomerssHandler().FindCustomerss(obj.Id);
                if (check != null)
                {
                    Customerss cus = new Customerss();
                    cus.Id = obj.Id;
                    cus.Name = obj.Name;
                    cus.Creditbalance = obj.Creditbalance;
                    cus.Phone = obj.Phone;
                    cus.Email = obj.Email;
                    cus.Sex = obj.Sex;
                    cus.Age = obj.Age;
                    cus.Address = obj.Address;
                    cus.City = obj.City;
                    cus.Country = obj.Country;
                    cus.Order = obj.Order;
                    cus.IsActive = true;
                    cus.CreatedBy = "Bilal";
                    cus.CreatedOn = DateTime.Now;
                    cus.UpdatedBy = "Bilal";
                    cus.UpdatedOn = DateTime.Now;

                    new CustomerssHandler().UpdateCustomerss(cus);
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
        public IActionResult DeleteCustomerss(int id)
        {
            Customerss cat = new CustomerssHandler().FindCustomerss(id);
            if (cat != null)
            {
                new CustomerssHandler().DeleteCustomerss(cat);
                result = "success";
            }
            return Json(result);


        }
    }
}