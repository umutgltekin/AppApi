using App.Data.Domain;
using App.Schema;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, CustomerResponse>();


            CreateMap<AddressRequest, Address>();
            CreateMap<Address, AddressResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstNAme + " " + src.Customer.LastName));

            CreateMap<AccountRequest, Account>();
            CreateMap<Account, AccountResponse>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstNAme + " " + src.Customer.LastName));

            CreateMap<CardRequest, Card>();
            CreateMap<Card, CardResponse>()
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Account.AccountNumber));

            CreateMap<EftTransactionREquest, EftTransaction>();
            CreateMap<EftTransaction, EftTransactionResponse>().ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Account.AccountNumber))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Account.Customer.FirstNAme + " " + src.Account.Customer.LastName))
                .ForMember(dest => dest.CustomerNumber, opt => opt.MapFrom(src => src.Account.Customer.CustomerNumber));

            CreateMap<AccountTransactionRequest, AccountTransaction>();
            CreateMap<AccountTransaction, AccountTransactionResponse>().ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Account.AccountNumber))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Account.Customer.FirstNAme + " " + src.Account.Customer.LastName))
                .ForMember(dest => dest.CustomerNumber, opt => opt.MapFrom(src => src.Account.Customer.CustomerNumber));


        }
    }
}
