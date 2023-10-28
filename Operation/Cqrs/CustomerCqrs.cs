using App.Base.Response;
using App.Schema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.Cqrs
{

    public record CreateCustomerCommand(CustomerRequest model) : IRequest<ApiResponse<CustomerResponse>>;
    public record UpdateCustomerCommand(CustomerRequest model,int id) : IRequest<ApiResponse>;
    public record DeleteCustomerCommand(int id) : IRequest<ApiResponse>;



    public record GetAllCustomerQuery() : IRequest<ApiResponse<List<CustomerResponse>>>;
    public record GetCustomerByIdQuery(int id) : IRequest<ApiResponse<CustomerResponse>>;

}
