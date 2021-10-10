using KokaarCis.Domain.Assemblers;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries.Contracts
{
    public interface IParcelDocumentQuery : IBaseQuery<ParcelDocumentDto, int>
    {
        ParcelDocumentDto GetByDocumentUrl(string documentUrld);
        IEnumerable<ParcelDocumentDto> GetByParcelId(int parcelId);
    }
}