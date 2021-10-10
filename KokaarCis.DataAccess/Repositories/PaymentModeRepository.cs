using KokaarCis.Domain.Entities;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class PaymentModeRepository : BaseRepository<PaymentMode, int>, IPaymentModeRepository
    {
        public PaymentModeRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(PaymentMode cityToUpdate)
        {
            var originalEntity = GetById(cityToUpdate.Id);

            if (!string.IsNullOrWhiteSpace(cityToUpdate.Name)) originalEntity.Name = cityToUpdate.Name;
            originalEntity.LastModificationDate = cityToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = cityToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
