using System;
using KokaarCis.Domain.Entities;

namespace KokaarCis.DataAccess.Repositories.Contracts
{
    public interface IParcelRepository : IBaseRepository<Parcel, int>
    {
        public void Update(Parcel parcel);
        void UpdateStatus(Parcel parcelToUpdate);
    }
}
