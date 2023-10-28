using App.Base.Response;
using App.Data.Context;
using App.Data.Domain;
using App.Schema;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Operation.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.Query
{
    public class CustomerQueryHandler :
        IRequestHandler<GetAllCustomerQuery, ApiResponse<List<CustomerResponse>>>,
        IRequestHandler<GetCustomerByIdQuery, ApiResponse<CustomerResponse>>
    {
        private readonly ApContext _apContext;
        private readonly IMapper _mapper;
        public  CustomerQueryHandler(ApContext apContext, IMapper mapper)
        {
            _apContext = apContext;
            _mapper = mapper;
        }
        public async Task<ApiResponse<CustomerResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var list = _apContext.Set<Customer>().Include(x => x.Accounts).Include(x => x.Addresses).FirstOrDefault(x=>x.CustomerNumber == request.id);
            var mapped = _mapper.Map<CustomerResponse>(list);

            return new ApiResponse<CustomerResponse>(mapped);

        }

        public async Task<ApiResponse<List<CustomerResponse>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var list = _apContext.Set<Customer>().Include(x => x.Accounts).Include(x => x.Addresses).ToList();
            var mapped=_mapper.Map<List<CustomerResponse>>(list);

            return new ApiResponse<List<CustomerResponse>>(mapped);
        }
    }
}
