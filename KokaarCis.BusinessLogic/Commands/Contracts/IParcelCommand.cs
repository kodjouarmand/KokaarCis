using KokaarCis.BusinessLogic.Queries;
using KokaarCis.Domain.Assemblers;
using System;

namespace KokaarCis.BusinessLogic.Commands.Contracts
{
    public interface IParcelCommand : IBaseCommand<ParcelDto, int>
    {

    }
}