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
    [Table("Card")]
    public class Card : BaseModel
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string CardHolder { get; set; }
        public string Description { get; set; }
        public long CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryDate { get; set; }
        public int? ExpenseLimit { get; set; }
    }
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.InsertUserId).IsRequired();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.InsertDate).IsRequired();

            builder.Property(x => x.AccountId).IsRequired(true);
            builder.Property(x => x.CardHolder).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.CardNumber).IsRequired();
            builder.Property(x => x.CVV).IsRequired().HasMaxLength(3);
            builder.Property(x => x.ExpiryDate).IsRequired().HasMaxLength(4);
            builder.Property(x => x.ExpenseLimit).IsRequired(false);

            builder.HasIndex(x => x.AccountId);



        }
    }
}
