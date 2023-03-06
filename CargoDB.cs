using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CargoManagement
{
    public partial class CargoDB : DbContext
    {
        public CargoDB()
            : base("name=CargoDB")
        {
        }

        public virtual DbSet<bookingCargo> bookingCargo { get; set; }
        public virtual DbSet<city> city { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<gatePass> gatePass { get; set; }
        public virtual DbSet<login> login { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<roleMaster> roleMaster { get; set; }
        public virtual DbSet<userRolesMapping> userRolesMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<city>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.Pincode)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Customer_Name)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Customer_Address)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Customer_Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Customer_Email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.ActiveStatus)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Employee_Name)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Employee_Department)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Employee_Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.ActiveStatus)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .HasMany(e => e.userRolesMapping)
                .WithRequired(e => e.login)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Product_Name)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Product_Type)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Shipping_Charge);
                //.IsUnicode(true);

            modelBuilder.Entity<roleMaster>()
                .Property(e => e.RollName)
                .IsUnicode(false);

            modelBuilder.Entity<roleMaster>()
                .HasMany(e => e.login)
                .WithOptional(e => e.roleMaster)
                .HasForeignKey(e => e.UserTypeID);

            modelBuilder.Entity<roleMaster>()
                .HasMany(e => e.userRolesMapping)
                .WithRequired(e => e.roleMaster)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);
        }
    }
}
