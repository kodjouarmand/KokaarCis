using AutoMapper;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using System.Linq;
using System.Text;

namespace KokaarCis.BusinessLogic.Queries
{
    public class BusinessPartnerQuery : BaseQuery<BusinessPartnerDto, BusinessPartner, int>, IBusinessPartnerQuery
    {
        public BusinessPartnerQuery(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override IEnumerable<BusinessPartnerDto> GetAll()
        {
            var businessPartners = _unitOfWork.BusinessPartner.GetAll()
                .OrderBy(u => u.Name);
            return MapEntitiesToDto(businessPartners);
        }

        public override BusinessPartnerDto GetById(int businessPartnerId)
        {
            var businessPartner = _unitOfWork.BusinessPartner.GetAll(u => u.Id == businessPartnerId).FirstOrDefault();
            return MapEntityToDto(businessPartner);
        }
    }
}
