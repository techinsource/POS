using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.User.UsersGroup
{
    public class UsersGroupHelper
    {
        public List<UserssGroup> GetUsersGroup()
        {
            List<UserssGroup> result = new UsersGroupHandler().GetUsersGroup();
            return result;
        }
    }
}
