using AutoMapper;
using KokaarCis.Domain.Entities;
using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using System.Linq;

namespace KokaarCis.BusinessLogic.Queries
{
    public class CommissionPaymentQuery : BaseQuery<CommissionPaymentDto, CommissionPayment, int>, ICommissionPaymentQuery
    {
        private string _includeProperties = $"{nameof(InvoiceHeader)},{nameof(PaymentMode)}";
        public CommissionPaymentQuery(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override IEnumerable<CommissionPaymentDto> GetAll()
        {
            var commissionPayments = _unitOfWork.CommissionPayment.GetAll(includeProperties: _includeProperties)
                .OrderByDescending(u => u.Date);
            foreach (var commissionPayment in commissionPayments)
            {
                var customer = _unitOfWork.Customer.GetById(commissionPayment.InvoiceHeader.CustomerId);
                commissionPayment.InvoiceHeader.Customer = customer;
            }
            return MapEntitiesToDto(commissionPayments);
        }

        public override CommissionPaymentDto GetById(int commissionPaymentId)
        {
            var commissionPayment = _unitOfWork.CommissionPayment.GetAll(u => u.Id == commissionPaymentId,
                includeProperties: _includeProperties).FirstOrDefault();

            if (commissionPayment != null)
            {
                var customer = _unitOfWork.Customer.GetById(commissionPayment.InvoiceHeader.CustomerId);
                commissionPayment.InvoiceHeader.Customer = customer;
            }
            return MapEntityToDto(commissionPayment);
        }


        public IEnumerable<CommissionPaymentDto> GetByInvoiceHeaderId(int invoiceHeaderId)
        {
            var commissionPayments = _unitOfWork.CommissionPayment.GetAll(u => u.InvoiceHeaderId == invoiceHeaderId,
                includeProperties: _includeProperties).ToList();
            foreach (var commissionPayment in commissionPayments)
            {
                var customer = _unitOfWork.Customer.GetById(commissionPayment.InvoiceHeader.CustomerId);
                commissionPayment.InvoiceHeader.Customer = customer;
            }
            return MapEntitiesToDto(commissionPayments);
        }

    }
}
