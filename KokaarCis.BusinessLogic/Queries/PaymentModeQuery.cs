using AutoMapper;
using KokaarCis.Domain.Entities;
using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using System.Linq;

namespace KokaarCis.BusinessLogic.Queries
{
    public class PaymentModeQuery : BaseQuery<PaymentModeDto, PaymentMode, int>, IPaymentModeQuery
    {
        public PaymentModeQuery(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public override IEnumerable<PaymentModeDto> GetAll()
        {
            var cities = _unitOfWork.PaymentMode.GetAll()
                .OrderBy(c => c.Name);
            return MapEntitiesToDto(cities);
        }

        public override PaymentModeDto GetById(int cityId)
        {
            var city = _unitOfWork.PaymentMode.GetById(cityId);
            return MapEntityToDto(city);
        }
    }
}
