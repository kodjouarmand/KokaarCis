using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface ICommissionPaymentRepository : IBaseRepository<CommissionPayment, int>
    {
        public void Update(CommissionPayment commissionPayment);
    }
}
