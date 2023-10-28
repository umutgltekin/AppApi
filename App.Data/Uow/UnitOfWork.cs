using App.Data.Context;
using App.Data.Domain;
using App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApContext _aContext;

        public UnitOfWork(ApContext aContext)
        {
            _aContext = aContext;
            CustomerRepository =new GenericRepository<Customer>(aContext);
            AddressRepository = new GenericRepository<Address>(aContext);
            AccountRepository = new GenericRepository<Account>(aContext);
            AccountTransactionRepository = new GenericRepository<AccountTransaction>(aContext);
            EftTransactionRepository = new GenericRepository<EftTransaction>(aContext);
            CardRepository = new GenericRepository<Card>(aContext);
        }

        public IGenericRepository<Customer> CustomerRepository { get; private set; }

        public IGenericRepository<Address> AddressRepository { get; private set; }

        public IGenericRepository<Account> AccountRepository { get; private set; }

        public IGenericRepository<AccountTransaction> AccountTransactionRepository { get; private set; }

        public IGenericRepository<EftTransaction> EftTransactionRepository { get; private set; }

        public IGenericRepository<Card> CardRepository { get; private set; }

        public void Complate()
        {
            _aContext.SaveChanges();
        }
        public void ComplateTransaction()
        { 
            using (var transaction=_aContext.Database.BeginTransaction()) {
                try
                {
                    _aContext.SaveChanges();
                    transaction.Commit();


                }
                catch(Exception ex) { 
                transaction.Rollback();
                    //log
                
                }
                        
            }
            _aContext.SaveChanges();
        }
    }
}
