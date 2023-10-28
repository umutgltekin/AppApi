using App.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Domain
{
    [Table("MoneyTransferTransaction")]
    public class MoneyTransferTransaction:BaseModel
    {
        public string ReferenceNumber {  get; set; }    
        public int FromAccountId { get; set; }
        public virtual Account FromAccount { get; set; }
        public virtual Account ToAccount { get; set; }
        public int ToAccountId { get; set;}
        public decimal Amount {  get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate  { get; set; }
        public string TransactionCode { get; set; }
    }
}
