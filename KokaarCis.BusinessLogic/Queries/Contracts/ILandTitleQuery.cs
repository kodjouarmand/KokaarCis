using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface ILandTitleQuery : IBaseQuery<LandTitleDto, int>
    {
        IEnumerable<LandTitleDto> GetByLocalityId(int cityId);
        LandTitleDto GetByNumber(string number);
    }
}