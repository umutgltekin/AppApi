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
    [Table("EftTransaction")]
    public class EftTransaction: BaseModel
    {
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public string ReferenceNumber { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string AdressType { get; set; }
        public decimal Amount { get; set; }
        public decimal ChargeAmount { get; set; }
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
    public class EftTransactionConfiguration : IEntityTypeConfiguration<EftTransaction>
    {
        public void Configure(EntityTypeBuilder<EftTransaction> builder)
        {
            builder.Property(x => x.InsertUserId).IsRequired();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.InsertDate).IsRequired();


            builder.Property(x => x.AccountId).IsRequired(true);
            builder.Property(x => x.ReferenceNumber).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ReceiverName).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.ReceiverAddress).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.AdressType).IsRequired();
            builder.Property(x => x.ChargeAmount).IsRequired();
            builder.Property(x => x.TransactionCode).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(0);

            builder.HasIndex(x => x.AccountId);



        }
    }
}
