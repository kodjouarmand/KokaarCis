using KokaarCis.BusinessLogic.Queries;
using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface IParcelQuery : IBaseQuery<ParcelDto, int>
    {
        IEnumerable<ParcelDto> GetByLandTitleId(int landTitleId);
        IEnumerable<ParcelDto> GetByStatus(string status);
    }
}