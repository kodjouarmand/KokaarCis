using Microsoft.AspNetCore.Mvc;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.Domain.Assemblers;
using KokaarCis.BusinessLogic.Queries.Contracts;
using KokaarCis.Mvc;
using KokaarCis.Domain.ViewModels;
using System.Linq;
using System.Collections.Generic;
using KokaarCis.Utility.Helpers;
using KokaarCis.Domain.Paging;

namespace KokaarCis.Areas.User.Controllers
{
    public class CommissionController : BaseUserController
    {
        private readonly IInvoiceHeaderQuery _invoiceHeaderQuery;
        private readonly IInvoiceDetailQuery _invoiceDetailQuery;

        public CommissionController(ILoggerService logger, IApplicationUserQuery applicationUserQuery,
            IInvoiceHeaderQuery invoiceHeaderQuery, IInvoiceDetailQuery invoiceDetailQuery)
            : base(logger, applicationUserQuery)
        {
            _invoiceHeaderQuery = invoiceHeaderQuery;
            _invoiceDetailQuery = invoiceDetailQuery;
        }

        public IActionResult Index(int page = 1, int pageSize = ConstantHelper.DEFAULT_PAGE_SIZE)
        {
            var commissions = _invoiceHeaderQuery.GetCommissions().AsQueryable().GetPaged(page, pageSize);
            return View(commissions);
        }


        public IActionResult Summary(int id)
        {
            InvoiceHeaderViewModel invoiceHeaderViewModel = GetInvoiceHeaderViewModel(id);
            return View(invoiceHeaderViewModel);
        }        

        private InvoiceHeaderViewModel GetInvoiceHeaderViewModel(int? invoiceHeaderId = null)
        {
            InvoiceHeaderDto invoiceHeaderDto = new();
            List<InvoiceDetailDto> invoiceDetailDtos = new();
            if (invoiceHeaderId != null && invoiceHeaderId != 0)
            {
                invoiceHeaderDto = _invoiceHeaderQuery.GetById(invoiceHeaderId.GetValueOrDefault());
                invoiceDetailDtos = _invoiceDetailQuery.GetByInvoiceHeaderId(invoiceHeaderId.GetValueOrDefault()).ToList();
            }

            InvoiceHeaderViewModel invoiceHeaderViewModel = new()
            {
                InvoiceHeader = invoiceHeaderDto,
                InvoiceDetails = invoiceDetailDtos
            };
            return invoiceHeaderViewModel;
        }
    }

}