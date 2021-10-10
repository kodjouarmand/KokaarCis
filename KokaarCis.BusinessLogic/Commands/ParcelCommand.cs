﻿using AutoMapper;
using KokaarCis.Domain.Entities;
using KokaarCis.BusinessLogic.Exceptions;
using System;
using System.Text;
using KokaarCis.BusinessLogic.Enums;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using System.Linq;
using KokaarCis.Utility.Enum;
using KokaarCis.Utility.Helpers;

namespace KokaarCis.BusinessLogic.Commands.Contracts
{
    public class ParcelCommand : BaseCommand<ParcelDto, Parcel, int>, IParcelCommand
    {

        private readonly IParcelQuery _parcelQuery;
        public ParcelCommand(IUnitOfWork unitOfWork, IMapper mapper,
            IParcelQuery parcelQuery) : base(unitOfWork, mapper)
        {
            _parcelQuery = parcelQuery;
        }

        protected override StringBuilder ValidateAdd(ParcelDto parcelDto)
        {
            StringBuilder validationErrors = new();

            if (!parcelDto.IsNew())
            {
                validationErrors.Append("L'enregistrement que vous souhaitez ajouter existe déjà;\n");
                return validationErrors;
            }
            var validationResult = new ParcelValidator(_unitOfWork, parcelDto.LandTitleId).Validate(parcelDto);
            validationErrors.Append(validationResult.ToString());

            if (_parcelQuery.GetByLandTitleId(parcelDto.LandTitleId.GetValueOrDefault())
                .Any(u => u.Number == parcelDto.Number))
            {
                validationErrors.Append($"Une parcelle avec ce numéro existe déjà pour ce titre foncier;\n");
            }

            return validationErrors;
        }

        public override int Add(ParcelDto parcelDto)
        {
            parcelDto.Status = EnumHelper.ToString(StatusEnum.Available);
            var parcel = BuildEntity(parcelDto);
            _unitOfWork.Parcel.Add(parcel);
            _unitOfWork.Save();
            return parcel.Id;
        }

        protected override StringBuilder ValidateUpdate(ParcelDto parcelDto)
        {
            StringBuilder validationErrors = new();

            if (parcelDto.IsNew())
            {
                validationErrors.Append("L'enregistrement que vous souhaitez mettre à jour n'existe pas.");
                return validationErrors;
            }
            var validationResult = new ParcelValidator(_unitOfWork, parcelDto.LandTitleId).Validate(parcelDto);
            validationErrors.Append(validationResult.ToString());

            return validationErrors;
        }

        public override void Update(ParcelDto parcelDto)
        {
            var parcel = BuildEntity(parcelDto);
            _unitOfWork.Parcel.Update(parcel);
        }

        protected override StringBuilder ValidateDelete(ParcelDto parcelDto = null)
        {
            StringBuilder validationErrors = base.ValidateDelete(parcelDto);
            return validationErrors;
        }

        public override void Delete(int parcelId)
        {
            var parcelDto = _parcelQuery.GetById(parcelId);
            StringBuilder validationErrors = ValidateDelete(parcelDto);
            if (validationErrors.Length != 0)
            {
                throw new BllValidationException(validationErrors.ToString());
            }
            _unitOfWork.Parcel.Delete(parcelId);
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
