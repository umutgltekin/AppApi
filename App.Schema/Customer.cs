using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Schema
{
    public class CustomerRequest
    {
        public int CustomerNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstNAme { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }


    }
    public class CustomerResponse
    {
        public int CustomerNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstNAme { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public virtual List<AddressResponse> Addresses { get; set; }
        public virtual List<AccountResponse> Accounts { get; set; }
    }
}
