using AutoMapper;
using KokaarCis.Domain.Entities;
using System;
using System.Collections.Generic;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using System.Linq;

namespace KokaarCis.BusinessLogic.Queries
{
    public class CityQuery : BaseQuery<CityDto, City, int>, ICityQuery
    {
        public CityQuery(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public override IEnumerable<CityDto> GetAll()
        {
            var cities = _unitOfWork.City.GetAll()
                .OrderBy(c => c.Name);
            return MapEntitiesToDto(cities);
        }

        public override CityDto GetById(int cityId)
        {
            var city = _unitOfWork.City.GetById(cityId);
            return MapEntityToDto(city);
        }
    }
}
