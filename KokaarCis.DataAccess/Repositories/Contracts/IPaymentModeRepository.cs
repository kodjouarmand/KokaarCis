using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IPaymentModeRepository : IBaseRepository<PaymentMode, int>
    {
        public void Update(PaymentMode city);        
    }
}
