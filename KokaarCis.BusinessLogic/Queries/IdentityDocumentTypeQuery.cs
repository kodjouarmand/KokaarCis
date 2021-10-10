using AutoMapper;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using System.Linq;

namespace KokaarCis.BusinessLogic.Queries
{
    public class IdentityDocumentTypeQuery : BaseQuery<IdentityDocumentTypeDto, IdentityDocumentType, int>, IIdentityDocumentTypeQuery
    {
        public IdentityDocumentTypeQuery(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public override IEnumerable<IdentityDocumentTypeDto> GetAll()
        {
            var companies = _unitOfWork.IdentityDocumentType.GetAll()
                .OrderBy(c => c.Name);
            return MapEntitiesToDto(companies);
        }

        public override IdentityDocumentTypeDto GetById(int cityId)
        {
            var city = _unitOfWork.IdentityDocumentType.GetById(cityId);
            return MapEntityToDto(city);
        }
    }
}
