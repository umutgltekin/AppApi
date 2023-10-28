using App.Data.Domain;
using App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Uow
{
    public interface IUnitOfWork
    {
        void Complate();
        void ComplateTransaction();
        IGenericRepository<Customer> CustomerRepository { get;}
        IGenericRepository<Address> AddressRepository { get; }
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<AccountTransaction> AccountTransactionRepository { get; }
        IGenericRepository<EftTransaction> EftTransactionRepository { get; }
        IGenericRepository<Card> CardRepository { get; }

    }
}
