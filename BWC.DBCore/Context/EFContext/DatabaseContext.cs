using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BWC.Models.Entities;
using BWC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BWC.DBCore.Context.EFContext
{
    public partial class DatabaseContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }



        #region Table Models
        //public DbSet<TestTable> TestTables { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        #endregion Table Models






        #region Sp Models
        //public DbSet<DriverListDto> driverList { get; set; }
        //public DbSet<PetDto> petList { get; set; }

        #endregion Sp Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
