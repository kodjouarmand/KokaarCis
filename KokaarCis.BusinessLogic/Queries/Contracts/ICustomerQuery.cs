using KokaarCis.BusinessLogic.Queries;
using KokaarCis.Domain.Assemblers;
using System;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface ICustomerQuery : IBaseQuery<CustomerDto, int>
    {

    }
}