using KokaarCis.Domain.Assemblers;
using System.Collections.Generic;
using KokaarCis.BusinessLogic.Enums;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface IBaseQuery<TDto, TEntityKey> where TDto : BaseDto<TEntityKey>
    {
        TDto GetById(TEntityKey id);
        IEnumerable<TDto> GetAll();        
    }
}