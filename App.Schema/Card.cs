using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Schema
{
    public class CardRequest
    {
        public int AccountId { get; set; }

        public string CardHolder { get; set; }
        public string Description { get; set; }
        public long CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryDate { get; set; }
        public int? ExpenseLimit { get; set; }
    }
    public class CardResponse
    {
        public int AccountId { get; set; }
        public string CardHolder { get; set; }
        public string Description { get; set; }
        public long CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryDate { get; set; }
        public int? ExpenseLimit { get; set; }
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
    }
}
