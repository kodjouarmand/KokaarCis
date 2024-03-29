﻿using KokaarCis.Domain.Entities;
using KokaarCis.Domain.Contexts;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.DataAccess.Repositories
{
    public class InvoiceDetailRepository : BaseRepository<InvoiceDetail, int>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(ApplicationDbContext dbContext) : base(dbContext) 
        { 
        }

        public virtual void Update(InvoiceDetail invoiceDetailToUpdate)
        {
            var originalEntity = GetById(invoiceDetailToUpdate.Id);

            originalEntity.ParcelId = invoiceDetailToUpdate.ParcelId;
            originalEntity.InvoiceHeaderId = invoiceDetailToUpdate.InvoiceHeaderId;
            originalEntity.UnitPrice = invoiceDetailToUpdate.UnitPrice;
            originalEntity.Surface = invoiceDetailToUpdate.Surface;
            originalEntity.Total = invoiceDetailToUpdate.Total;
            originalEntity.LastModificationDate = invoiceDetailToUpdate.LastModificationDate;
            originalEntity.LastModificationUser = invoiceDetailToUpdate.LastModificationUser;

            dbSet.Update(originalEntity);
        }
    }

}
