using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Schema
{
    public class AccountTransactionRequest
    {
        public string ReferenceNumber { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionCode { get; set; }
    }
    public class AccountTransactionResponse
    {
        public string ReferenceNumber { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionCode { get; set; }
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }

    }
}
