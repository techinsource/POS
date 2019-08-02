using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSManagement.Models.User;
using POSManagement.Models.User.Users;
using POSManagement.Models.User.UsersGroup;

namespace POSManagement.Controllers
{
    public class UserssController : Controller
    {
        string result = string.Empty;
        public IActionResult AddUserss()
        {
            ViewBag.UsersGroup = new UsersGroupHandler().GetUsersGroup();


            return View();
        }
        [HttpPost]
        public IActionResult AddUserss(Userss obj, int userg)
        {
            try
            {
                Userss user = new Userss();
                user.Name = obj.Name;
                user.Email = obj.Email;
                user.Mobile = obj.Mobile;
                user.Address = obj.Address;
                user.Password = obj.Password;
                 user.IsActive = obj.IsActive;
                user.CreatedBy = "Bilal";
                user.CreatedOn = DateTime.Now;
                user.UpdatedBy = "Bilal";
                user.UpdatedOn = DateTime.Now;
                user.UserssGroups = new UserssGroup { Id = userg };
                new UserssHandler().AddUserss(user);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult Getuserss()
        {
            try
            {
                List<Userss> result = new UserssHelper().GetUserss();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindUserss(int id)
        {

            Userss fined = new UserssHandler().FindUserss(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateUserss(Userss obj, int userg)
        {
            try
            {
                Userss check = new UserssHandler().FindUserss(obj.Id);
                if (check != null)
                {
                    Userss user = new Userss();
                    user.Id = obj.Id;
                    user.Name = obj.Name;
                    user.Email = obj.Email;
                    user.Mobile = obj.Mobile;
                    user.Address = obj.Address;
                    user.Password = obj.Password;
                    user.IsActive = obj.IsActive;
                    user.CreatedBy = "Bilal";
                    user.CreatedOn = DateTime.Now;
                    user.UpdatedBy = "Bilal";
                    user.UpdatedOn = DateTime.Now;
                    user.UserssGroups = new UserssGroup { Id = userg };
                    new UserssHandler().UpdateUserss(user);
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
        public IActionResult DeleteUserss(int id)
        {
            Userss user = new UserssHandler().FindUserss(id);
            if (user != null)
            {
                new UserssHandler().DeleteUserss(user);
                result = "success";
            }
            return Json(result);


        }
    }
}