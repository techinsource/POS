using Microsoft.EntityFrameworkCore;
using POSAnventory.Models.Items;
using POSManagement.Models.Customer;
using POSManagement.Models.Expanditures;
using POSManagement.Models.Expanditures.ExpanseCategory;
using POSManagement.Models.Expanditures.ParentCategory;
using POSManagement.Models.Purchase.PurchaseItem;
using POSManagement.Models.Purchasess;
using POSManagement.Models.Quotation;
using POSManagement.Models.System.Store;
using POSManagement.Models.User;
using POSManagement.Models.User.UsersGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSAnventory.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //naqi
            optionsBuilder.UseSqlServer(@"Server=MUNIRPC\MUNIR;Database=POSManagements;Trusted_Connection=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(@"Server=.;Database=UNEEKDB;Trusted_Connection=True;");
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public Context()
        {
            Database.SetCommandTimeout(150000);
        }

        public DbSet<LineItemDefinition> LineItemDefinitions { get; set; }
        public DbSet<Itemd> Itemds { get; set; }
        public DbSet<ItemGroups>ItemGroups { get; set; }
        public DbSet<Item_Template> Item_Templates { get; set; }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Sub_Categorys> Sub_Categorys { get; set; }
        public DbSet<Supplierss> Supplierss { get; set; }
        public DbSet<Purchasess> Purchasess { get; set; }
        public DbSet<UserssGroup> UserssGroup { get; set; }
        public DbSet<Userss> Userss { get; set; }
        public DbSet<Customerss> Customerss { get; set; }
        public DbSet<Quotationss> Quotationss { get; set; }
        public DbSet<Expanditures> Expanditures { get; set; }
        public DbSet<ParentCategorys> ParentCategorys { get; set; }
        public DbSet<ExpanseCategory> ExpanseCategory { get; set; }
        public DbSet<Storess> Storess { get; set; }
    }
}
