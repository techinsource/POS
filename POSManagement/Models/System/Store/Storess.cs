using POSManagement.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.System.Store
{
    public class Storess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
        public int Zipcode { get; set; }
        public string Address { get; set; }
        public string VantRegno { get; set; }
        public TimeSpan Timezo { get; set; }
        public string Aftersellp { get; set; }
        public int Text { get; set; }
        public int Stockalertq { get; set; }
        public int Itemlimit { get; set; }
        public string Soundeffect { get; set; }
        public virtual Userss   Userss { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
