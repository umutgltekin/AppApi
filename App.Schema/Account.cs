using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Schema
{
    public class AccountRequest
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? CardId { get; set; }
    }
    public class AccountResponse
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? CardId { get; set; }
        public virtual List<EftTransactionResponse> EftTransactionList { get; set; }
        public virtual List<AccountTransactionResponse> AccountTransactionList { get; set; }
    }

}
