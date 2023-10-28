using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Schema
{
    public class EftTransactionREquest
    {
        public int AccountId { get; set; }
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
    public class EftTransactionResponse
    {
        public int AccountId { get; set; }
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
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
    }
}
