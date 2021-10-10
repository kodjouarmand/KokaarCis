using AutoMapper;
using KokaarCis.Domain.Entities;
using KokaarCis.BusinessLogic.Exceptions;
using System;
using System.Text;
using KokaarCis.BusinessLogic.Enums;
using KokaarCis.Domain.Assemblers;
using KokaarCis.DataAccess.Repositories.Contracts;
using KokaarCis.BusinessLogic.Queries.Contracts;
using KokaarCis.Utility.Helpers;
using KokaarCis.Utility.Enum;
using Microsoft.AspNetCore.Hosting;

namespace KokaarCis.BusinessLogic.Commands.Contracts
{
    public class ParcelDocumentCommand : BaseCommand<ParcelDocumentDto, ParcelDocument, int>, IParcelDocumentCommand
    {
        private readonly IParcelDocumentQuery _parcelDocumentQuery;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ParcelDocumentCommand(IUnitOfWork unitOfWork, IMapper mapper,
            IParcelDocumentQuery parcelDocumentQuery, IWebHostEnvironment hostEnvironment) : base(unitOfWork, mapper)
        {
            _parcelDocumentQuery = parcelDocumentQuery;
            _hostEnvironment = hostEnvironment;
        }

        protected override StringBuilder ValidateAdd(ParcelDocumentDto parcelDocumentDto)
        {
            StringBuilder validationErrors = new();

            if (!parcelDocumentDto.IsNew())
            {
                validationErrors.Append("L'enregistrement que vous souhaitez ajouter existe déjà;\n");
                return validationErrors;
            }

            var validationResult = new ParcelDocumentValidator().Validate(parcelDocumentDto);
            validationErrors.Append(validationResult.ToString());

            if (_parcelDocumentQuery.GetByDocumentUrl(parcelDocumentDto.DocumentUrl) != null)
            {
                validationErrors.Append("Un document avec ce nom existe déjà;\n");
                return validationErrors;
            }
            return validationErrors;
        }

        public override int Add(ParcelDocumentDto parcelDocumentDto)
        {
            var parcelDocument = BuildEntity(parcelDocumentDto);
            var parcelDocumentId = _unitOfWork.ParcelDocument.Add(parcelDocument);
            FileHelper.CreateFile(parcelDocumentDto.Document, DocumentOwnerEnum.Parcel, _hostEnvironment.WebRootPath);
            return parcelDocumentId;
        }

        protected override StringBuilder ValidateUpdate(ParcelDocumentDto parcelDocumentDto)
        {
            StringBuilder validationErrors = new();

            if (parcelDocumentDto.IsNew())
            {
                validationErrors.Append("L'enregistrement que vous souhaitez mettre à jour n'existe pas.");
                return validationErrors;
            }
            var validationResult = new ParcelDocumentValidator().Validate(parcelDocumentDto);
            validationErrors.Append(validationResult.ToString());

            return validationErrors;
        }

        public override void Update(ParcelDocumentDto parcelDocumentDto)
        {
            ParcelDocumentDto originalParcelDocumentDto = _parcelDocumentQuery.GetById(parcelDocumentDto.Id);
            if (parcelDocumentDto.Document == null)
            {
                parcelDocumentDto.DocumentUrl = originalParcelDocumentDto.DocumentUrl;
            }

            var parcelDocument = BuildEntity(parcelDocumentDto);
            _unitOfWork.ParcelDocument.Update(parcelDocument);
            FileHelper.CreateFile(parcelDocumentDto.Document, DocumentOwnerEnum.Parcel, _hostEnvironment.WebRootPath,
                originalParcelDocumentDto.DocumentUrl);
        }

        protected override StringBuilder ValidateDelete(ParcelDocumentDto parcelDocumentDto = null)
        {
            StringBuilder validationErrors = base.ValidateDelete(parcelDocumentDto);
            return validationErrors;
        }

        public override void Delete(int parcelDocumentId)
        {
            var parcelDocumentDto = _parcelDocumentQuery.GetById(parcelDocumentId);
            StringBuilder validationErrors = ValidateDelete(parcelDocumentDto);
            if (validationErrors.Length != 0)
            {
                throw new BllValidationException(validationErrors.ToString());
            }
            _unitOfWork.ParcelDocument.Delete(parcelDocumentId);
        }

        public override void Save()
        {
            _unitOfWork.Save();
        }
    }
}
