using Core.Entities;
using Core.Entities.Abstract;
using DietProject.WisejWeb.Entities;
using System.Data.Entity;

namespace DietProject.WisejWeb.DataAccess
{
    public class DietProjectContext : DbContext
    {
        //public DietProjectContext(DbContextOptions<DietProjectContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer(this.BuilderConnectionString());
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Comment>().ToTable("Comments");
        //    modelBuilder.Entity<Contract>().ToTable("Contracts");
        //    modelBuilder.Entity<Customer>().ToTable("Customers");
        //    modelBuilder.Entity<DietDetail>().ToTable("DietDetails");
        //    modelBuilder.Entity<Dietitian>().ToTable("Dietitians");
        //    modelBuilder.Entity<Food>().ToTable("Foods");
        //    modelBuilder.Entity<Message>().ToTable("Messages");
        //    modelBuilder.Entity<User>().ToTable("Users");
        //    modelBuilder.Entity<MeasureUnit>().ToTable("MeasureUnits");
        //}

        // @"Server=.\SQLEXPRESS;Database=DietSystem;Trusted_Connection=True;"

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DietDetail> DietDetails { get; set; }
        public DbSet<Dietitian> Dietitians { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<DietitianViewData> DietitianViewData { get; set; }
    }
}
