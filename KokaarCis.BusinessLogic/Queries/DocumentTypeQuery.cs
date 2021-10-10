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
    public class DocumentTypeQuery : BaseQuery<DocumentTypeDto, DocumentType, int>, IDocumentTypeQuery
    {
        public DocumentTypeQuery(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public override IEnumerable<DocumentTypeDto> GetAll()
        {
            var companies = _unitOfWork.DocumentType.GetAll()
                .OrderBy(c => c.Name);
            return MapEntitiesToDto(companies);
        }

        public override DocumentTypeDto GetById(int documentTypeId)
        {
            var documentType = _unitOfWork.DocumentType.GetById(documentTypeId);
            return MapEntityToDto(documentType);
        }
    }
}
