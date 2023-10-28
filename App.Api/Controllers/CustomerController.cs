using App.Data.Context;
using App.Data.Domain;
using App.Data.Uow;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("/CustomerController")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApContext _context;
        private readonly IUnitOfWork _unitOfWork;


        public CustomerController(IUnitOfWork unitOfWork, ApContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;

        }

        [HttpGet]
        public List<Customer> Get()
        {
            return _unitOfWork.CustomerRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _unitOfWork.CustomerRepository.GetById(id);
        }
        [HttpPost]
        public void Post(Customer customer)
        {
            _unitOfWork.CustomerRepository.Insert(customer);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer) 
        {
            _unitOfWork.CustomerRepository.Update(customer);        
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.CustomerRepository.DeleteById(id);
        }


    }
}
