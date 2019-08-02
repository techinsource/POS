using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.User.Users
{
    public class UserssHelper
    {
        public List<Userss> GetUserss()
        {
            List<Userss> result = new UserssHandler().GetUserss();
            return result;
        }
    }
}
