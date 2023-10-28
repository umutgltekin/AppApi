using App.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Domain
{
    [Table("Address")]
    public class Address: BaseModel
    {

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
    public class AdressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.InsertUserId).IsRequired();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.InsertDate).IsRequired();

            builder.Property(x => x.CustomerId).IsRequired(true);
            builder.Property(x => x.AdressLine1).IsRequired();
            builder.Property(x => x.AdressLine2).IsRequired().HasMaxLength(50);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.CustomerId);



        }
    }
}
