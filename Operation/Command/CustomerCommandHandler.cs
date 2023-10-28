using App.Base.Response;
using App.Data.Context;
using App.Data.Domain;
using App.Schema;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Operation.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.Command
{
    public class CustomerCommandHandler :
        IRequestHandler<CreateCustomerCommand, ApiResponse<CustomerResponse>>,
        IRequestHandler<UpdateCustomerCommand, ApiResponse>,
        IRequestHandler<DeleteCustomerCommand, ApiResponse>
    {
        private readonly ApContext _apContext;
        private readonly IMapper _mapper;
        public CustomerCommandHandler(ApContext apContext, IMapper mapper)
        {
            _apContext = apContext;
            _mapper = mapper;
        }
         public async Task<ApiResponse<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer entity = _mapper.Map<Customer>(request.model);

            var customer = _apContext.Set<Customer>().Add(entity);
            _apContext.SaveChanges();

            var response = _mapper.Map<CustomerResponse>(customer);
            return new ApiResponse<CustomerResponse>(response);
        }

         async Task<ApiResponse> IRequestHandler<UpdateCustomerCommand, ApiResponse>.Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer=_apContext.Set<Customer>().FirstOrDefault(x=> x.Id == request.id);
            customer.FirstNAme = request.model.FirstNAme;
            customer.LastName = request.model.LastName;
            customer.Email = request.model.Email;

           await _apContext.SaveChangesAsync(cancellationToken);

            return new ApiResponse();
        }

         async Task<ApiResponse> IRequestHandler<DeleteCustomerCommand, ApiResponse>.Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _apContext.Set<Customer>().FirstOrDefault(x => x.Id == request.id);
            if(customer == null)
            {
                return new ApiResponse("Recor Not found");
            }
            customer.IsActive = false;
            await _apContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }
}
