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
    [Table("AccountTransaction")]
    public class AccountTransaction:BaseModel
    {
        public string ReferenceNumber { get; set; }
        public int AccountId { get; set;}
        public virtual Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionCode { get; set; }

    }
    public class AccountTransactionConfiguration : IEntityTypeConfiguration<AccountTransaction>
    {
        public void Configure(EntityTypeBuilder<AccountTransaction> builder)
        {
            builder.Property(x => x.InsertUserId).IsRequired();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.InsertDate).IsRequired();

            builder.Property(x => x.AccountId).IsRequired(true);
            builder.Property(x => x.ReferenceNumber).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DebitAmount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.CreditAmount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.TransactionCode).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.AccountId);



        }
    }
}
