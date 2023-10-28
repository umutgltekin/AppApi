using App.Data.Domain;
using Microsoft.EntityFrameworkCore;


namespace App.Data.Context
{
    public class ApContext : DbContext
    {
        public ApContext(DbContextOptions<ApContext> options):base(options) {


        }
       public DbSet<Customer>Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdressConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new EftTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
