using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface ILandTitleDocumentQuery : IBaseQuery<LandTitleDocumentDto, int>
    {
        LandTitleDocumentDto GetByDocumentUrl(string documentUrld);
        IEnumerable<LandTitleDocumentDto> GetByLandTitleId(int landTitleId);
    }
}