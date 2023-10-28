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
    [Table("Account")]
    public class Account: BaseModel
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? CardId { get; set; }
        public virtual List<EftTransaction> EftTransactionList { get; set; }
        public virtual List<AccountTransaction> AccountTransactionList { get; set; }
        public virtual Card Card { get; set; }
    }

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.InsertUserId).IsRequired();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.InsertDate).IsRequired();

            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.AccountNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IBAN).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Balance).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.CurrencyCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.OpenDate).IsRequired();
            builder.Property(x => x.CloseDate).IsRequired(false);
            builder.Property(x => x.CardId).IsRequired(true);


            builder.HasIndex(x => x.CustomerId).IsUnique(true);

            builder.HasMany(x => x.EftTransactionList)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId)
                .IsRequired(true);

            builder.HasMany(x => x.AccountTransactionList)
                .WithOne(x => x.Account).
                HasForeignKey(x => x.AccountId).
                IsRequired(true);

            builder.HasOne(x => x.Card)
                .WithOne(x => x.Account)
                .HasForeignKey<Card>().
                IsRequired(true);

           


        }
    }

}
