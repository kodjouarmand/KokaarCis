using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IBusinessPartnerRepository : IBaseRepository<BusinessPartner, int>
    {
        public void Update(BusinessPartner businessPartner);        
    }
}
