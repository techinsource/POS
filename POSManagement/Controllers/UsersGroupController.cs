using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSManagement.Models.User.UsersGroup;

namespace POSManagement.Controllers
{
    public class UsersGroupController : Controller
    {
        string result = string.Empty;
        public IActionResult AddUsersGroup()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddUsersGroup(UserssGroup obj)
        {
            try
            {
                UserssGroup userg = new UserssGroup();
                userg.Name = obj.Name;
                userg.Totaluser = obj.Totaluser;
               
                userg.IsActive = true;
                userg.CreatedBy = "Bilal";
                userg.CreatedOn = DateTime.Now;
                userg.UpdatedBy = "Bilal";
                userg.UpdatedOn = DateTime.Now;
                new UsersGroupHandler().AddUsersGroup(userg);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetUsersGroup()
        {
            try
            {
                List<UserssGroup> result = new UsersGroupHelper().GetUsersGroup();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindUsersGroup(int id)
        {

            UserssGroup fined = new UsersGroupHandler().FindUsersGroup(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateUsersGroup(UserssGroup obj)
        {
            try
            {
                UserssGroup check = new UsersGroupHandler().FindUsersGroup(obj.Id);
                if (check != null)
                {
                    UserssGroup userg = new UserssGroup();
                    userg.Id = obj.Id;
                    userg.Name = obj.Name;
                    userg.Totaluser = obj.Totaluser;

                    userg.IsActive = true;
                    userg.CreatedBy = "Bilal";
                    userg.CreatedOn = DateTime.Now;
                    userg.UpdatedBy = "Bilal";
                    userg.UpdatedOn = DateTime.Now;
                    
                    new UsersGroupHandler().UpdateUsersGroup(userg);
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
        public IActionResult DeleteUsersGroup(int id)
        {
            UserssGroup cat = new UsersGroupHandler().FindUsersGroup(id);
            if (cat != null)
            {
                new UsersGroupHandler().DeleteUsersGroup(cat);
                result = "success";
            }
            return Json(result);


        }
    }
    
}