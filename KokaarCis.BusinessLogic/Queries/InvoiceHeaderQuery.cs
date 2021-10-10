using AutoMapper;
using KokaarCis.Domain.Entities;
using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using System.Linq;
using KokaarCis.Utility.Helpers;
using KokaarCis.Utility.Enum;

namespace KokaarCis.BusinessLogic.Queries
{
    public class InvoiceHeaderQuery : BaseQuery<InvoiceHeaderDto, InvoiceHeader, int>, IInvoiceHeaderQuery
    {
        private readonly string _includeProperties = $"{nameof(Customer)},{nameof(BusinessPartner)}";

        public InvoiceHeaderQuery(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override IEnumerable<InvoiceHeaderDto> GetAll()
        {
            var invoiceHeaders = _unitOfWork.InvoiceHeader.GetAll(includeProperties: _includeProperties)
                .OrderByDescending(u => u.Date);
            return MapEntitiesToDto(invoiceHeaders);
        }

        public override InvoiceHeaderDto GetById(int invoiceHeaderId)
        {
            var invoiceHeader = _unitOfWork.InvoiceHeader.GetAll(u => u.Id == invoiceHeaderId,
                includeProperties: _includeProperties).FirstOrDefault();
            return MapEntityToDto(invoiceHeader);
        }

        public InvoiceHeaderDto GetByNumber(string number)
        {
            var invoiceHeader = _unitOfWork.InvoiceHeader.GetAll(u => u.Id == int.Parse(number),
                includeProperties: _includeProperties).FirstOrDefault();
            return MapEntityToDto(invoiceHeader);
        }

        public IEnumerable<InvoiceHeaderDto> GetByStatus(string status)
        {
            var parcels = _unitOfWork.InvoiceHeader.GetAll(includeProperties: $"{_includeProperties}");
            return MapEntitiesToDto(parcels).Where(s => s.Status.ToLower() == status.ToLower()).ToList();
        }

        public IEnumerable<InvoiceHeaderDto> GetCommissions()
        {
            var invoiceHeaders = _unitOfWork.InvoiceHeader.GetAll(u => u.CommissionToPay > 0, 
                includeProperties: _includeProperties)
                .OrderByDescending(u => u.Date);
            return MapEntitiesToDto(invoiceHeaders);
        }

        public IEnumerable<InvoiceHeaderDto> GetUnpaidCommissions()
        {
            var invoiceHeaders = _unitOfWork.InvoiceHeader.GetAll(u => u.CommissionToPay > 0,
                includeProperties: nameof(BusinessPartner))
                .Where(u => u.CommissionStatus != EnumHelper.ToString(StatusEnum.Paid))
                .OrderByDescending(u => u.Date);
            return MapEntitiesToDto(invoiceHeaders);
        }
    }
}
