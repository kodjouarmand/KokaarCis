using Microsoft.AspNetCore.Mvc;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.BusinessLogic.Enums;
using KokaarCis.Domain.Assemblers;
using KokaarCis.BusinessLogic.Queries.Contracts;
using KokaarCis.BusinessLogic.Commands.Contracts;
using KokaarCis.Mvc;
using KokaarCis.Domain.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using KokaarCis.Utility.Helpers;
using System.Text;
using System;
using KokaarCis.Utility.Enum;
using static KokaarCis.Utility.Helpers.MvcHelper;
using KokaarCis.Domain.Paging;

namespace KokaarCis.Areas.User.Controllers
{
    public class InvoicePaymentController : BaseUserController
    {
        private readonly IInvoicePaymentQuery _invoicePaymentQuery;
        private readonly IInvoicePaymentCommand _invoicePaymentCommand;
        private readonly IInvoiceHeaderQuery _invoiceHeaderQuery;
        private readonly IPaymentModeQuery _paymentModeQuery;

        public InvoicePaymentController(ILoggerService logger, IApplicationUserQuery applicationUserQuery,
            IInvoicePaymentQuery invoicePaymentQuery, IInvoicePaymentCommand invoicePaymentCommand,
            IInvoiceHeaderQuery invoiceHeaderQuery, IPaymentModeQuery paymentModeQuery)
            : base(logger, applicationUserQuery)
        {
            _invoicePaymentQuery = invoicePaymentQuery;
            _invoicePaymentCommand = invoicePaymentCommand;
            _invoiceHeaderQuery = invoiceHeaderQuery;
            _paymentModeQuery = paymentModeQuery;
        }

        #region InvoicePayment

        public IActionResult Index(int page = 1, int pageSize = ConstantHelper.DEFAULT_PAGE_SIZE)
        {
            var invoicePaymentDtos = _invoicePaymentQuery.GetAll().AsQueryable().GetPaged(page, pageSize);
            return View(invoicePaymentDtos);
        }

        public IActionResult Summary(int id)
        {
            InvoicePaymentViewModel invoicePaymentViewModel = GetInvoicePaymentViewModel(id, true);
            return View(invoicePaymentViewModel);
        }

        [NoDirectAccess]
        public IActionResult AddOrEdit(int? id, bool returnToDetailView = false)
        {
            InvoicePaymentViewModel invoicePaymentViewModel = GetInvoicePaymentViewModel(id, returnToDetailView: returnToDetailView);
            return View(invoicePaymentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(InvoicePaymentViewModel invoicePaymentViewModel)
        {
            InvoicePaymentDto invoicePaymentDto = invoicePaymentViewModel.InvoicePayment;
            try
            {
                if (ModelState.IsValid)
                {
                    _invoicePaymentCommand.CurrentUser = CurrentUser.UserName;
                    if (invoicePaymentDto.Id == 0)
                    {
                        invoicePaymentDto.Id = _invoicePaymentCommand.Add(invoicePaymentDto);

                        invoicePaymentViewModel = GetInvoicePaymentViewModel(invoicePaymentDto.Id);
                        return Json(new
                        {
                            isValid = true,
                            message = "Opération effectuée avec succès.",
                            html = MvcHelper.RenderRazorViewToString(this, "Print", invoicePaymentViewModel)
                        });
                    }
                    else
                    {
                        _invoicePaymentCommand.Update(invoicePaymentDto);
                        _invoicePaymentCommand.Save();

                        string returnHtml;
                        if (invoicePaymentViewModel.ReturnToDetailView)
                        {
                            invoicePaymentViewModel = GetInvoicePaymentViewModel(invoicePaymentDto.Id,
                                returnToDetailView: invoicePaymentViewModel.ReturnToDetailView);
                            returnHtml = MvcHelper.RenderRazorViewToString(this, "_Detail", invoicePaymentViewModel);
                        }
                        else
                        {
                            var invoicePaymentDtos = _invoicePaymentQuery.GetAll().AsQueryable().GetPaged(1, ConstantHelper.DEFAULT_PAGE_SIZE);
                            returnHtml = MvcHelper.RenderRazorViewToString(this, "_List", invoicePaymentDtos);
                        }
                        return Json(new
                        {
                            isValid = true,
                            message = "Opération effectuée avec succès.",
                            html = returnHtml
                        });
                    }
                }
                else
                {
                    throw new Exception(MvcHelper.GetErrorMessages(ModelState));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);

                invoicePaymentViewModel = GetInvoicePaymentViewModel(invoicePaymentDto.Id);
                return Json(new
                {
                    isValid = false,
                    message = ex.Message,
                    html = MvcHelper.RenderRazorViewToString(this, "AddOrEdit", invoicePaymentViewModel)
                });
            }
        }

        public IActionResult Print(int id)
        {
            InvoicePaymentViewModel invoiceHeaderViewModel = GetInvoicePaymentViewModel(id);
            return View(invoiceHeaderViewModel);
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                CheckActionAuthorization();

                _invoicePaymentCommand.DbAction = DataBaseActionEnum.Delete;
                _invoicePaymentCommand.Delete(id);
                _invoicePaymentCommand.Save();
                return Json(new { success = true, message = "Opération effectuée avec succès" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return Json(new { success = false, message = $"Echec lors de l'exécution de l'opération : {ex.Message}" });
            }
        }

        public IActionResult Cancel(int id)
        {
            var invoicePaymentViewModel = new InvoicePaymentViewModel
            {
                InvoicePayment = new InvoicePaymentDto() { Id = id }
            };
            return View(invoicePaymentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(InvoicePaymentViewModel invoicePaymentViewModel)
        {
            try
            {
                CheckActionAuthorization();
                int id = invoicePaymentViewModel.InvoicePayment.Id;
                _invoicePaymentCommand.DbAction = DataBaseActionEnum.Cancel;
                _invoicePaymentCommand.Cancel(id, invoicePaymentViewModel.InvoicePayment.CancelationReason);
                _invoicePaymentCommand.Save();

                var invoicePaymentDtos = _invoicePaymentQuery.GetAll().AsQueryable().GetPaged(1, ConstantHelper.DEFAULT_PAGE_SIZE);
                return Json(new
                {
                    isValid = true,
                    message = "Opération effectuée avec succès.",
                    html = MvcHelper.RenderRazorViewToString(this, "_List", invoicePaymentDtos)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);

                return Json(new
                {
                    isValid = false,
                    message = ex.Message,
                    html = MvcHelper.RenderRazorViewToString(this, "Cancel", invoicePaymentViewModel)
                });
            }
        }

        private InvoicePaymentViewModel GetInvoicePaymentViewModel(int? invoicePaymentId = null,
            bool returnToDetailView = false)
        {
            InvoicePaymentDto invoicePayment = new();
            if (invoicePaymentId != null && invoicePaymentId != 0)
            {
                invoicePayment = _invoicePaymentQuery.GetById(invoicePaymentId.GetValueOrDefault());
            }
            else
            {
                invoicePayment.Date = DateTime.Today.Date;
            }

            IEnumerable<SelectListItem> invoiceHeaders = _invoiceHeaderQuery.GetAll()
                .Where(u => u.Status != EnumHelper.ToString(StatusEnum.Paid))
                .Select(i => new SelectListItem
                {
                    Text = i.DisplayText,
                    Value = i.Id.ToString()
                });

            IEnumerable<SelectListItem> paymentModes = _paymentModeQuery.GetAll().Select(i => new SelectListItem
            {
                Text = i.DisplayText,
                Value = i.Id.ToString()
            });

            InvoicePaymentViewModel invoicePaymentViewModel = new()
            {
                InvoicePayment = invoicePayment,
                InvoiceHeaderList = invoiceHeaders,
                PaymentModeList = paymentModes,
                ReturnToDetailView = returnToDetailView
            };
            return invoicePaymentViewModel;
        }

        [HttpGet]
        public IActionResult GetInvoiceHeader(int invoiceHeaderId)
        {
            InvoiceHeaderDto invoiceHeaderDto = _invoiceHeaderQuery.GetById(invoiceHeaderId);
            if (invoiceHeaderDto == null)
            {
                invoiceHeaderDto = new InvoiceHeaderDto();
            }
            return Json(invoiceHeaderDto);
        }

        #endregion

    }

}