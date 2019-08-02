using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.User.UsersGroup
{
    public class UserssGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Totaluser { get; set; }
     
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
