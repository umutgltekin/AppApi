using App.Data.Context;
using App.Data.Domain;
using App.Data.Uow;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ApContext _dbContext;
        private readonly IUnitOfWork _unitofWork;
      public CustomersController(ApContext dbContext, IUnitOfWork unitofWork) 
        {
            _dbContext = dbContext;
            _unitofWork = unitofWork;
        }

        [HttpGet]
        public void Get() 
        { 
            var result = _unitofWork.CustomerRepository.GetAll();
            var list =_dbContext.Set<Customer>().ToList();
            var list1 = _dbContext.Set<Customer>().Include(x=> x.Addresses).ToList();
            var list2 = _dbContext.Set<Customer>().Include(x=> x.Accounts).ThenInclude(y=> y.Card).ToList();
            var list4 = _dbContext.Set<Customer>().Include(x => x.Accounts).Include(x=> x.Addresses).ToList();
            var list3 = _dbContext.Set<Customer>().Include(x => x.Accounts).ToList();
            var list5 = _dbContext.Set<Customer>()
                .Include(x => x.Accounts).ThenInclude(x=> x.AccountTransactionList)
                .Include(x=>x.Accounts).ThenInclude(x=> x.EftTransactionList)
                .Include(x=>x.Accounts).ThenInclude(x=> x.Card)
                .Include(x=> x.Addresses).ToList();

        }
    }
}
