using App.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Domain
{
    [Table("Customer")]
    public class Customer : BaseModel
    {
        public int CustomerNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstNAme { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int PasswordRetryCount { get; set; }
        public DateTime LastActivityDate { get; set; }
        public int Status { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public virtual List<Account> Accounts { get; set; }

    }
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.InsertUserId).IsRequired();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.InsertDate).IsRequired();


            builder.Property(x => x.CustomerNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstNAme).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Role).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastActivityDate).IsRequired();
            builder.Property(x => x.PasswordRetryCount).IsRequired().HasDefaultValue(0);

            builder.HasIndex(x => x.CustomerNumber).IsUnique(true);
            builder.HasMany(x=>x.Accounts).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).IsRequired(true);
            
            builder.HasMany(x => x.Addresses).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).IsRequired(true);
    

        }
    }
}
