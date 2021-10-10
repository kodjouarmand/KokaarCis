using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface ILocalityQuery : IBaseQuery<LocalityDto, int>
    {
        IEnumerable<LocalityDto> GetByCityId(int cityId);
        LocalityDto GetByNumber(string number);
    }
}