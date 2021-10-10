$('#form-modal').on('shown.bs.modal', function () {
    RegisterEvents();
})

function RegisterEvents() {

    $('#ddlInvoiceHeaders').on("change", function () {
        GetInvoiceHeader();
    });
}

function SetFocus() {
    $('#txtAmountPaid').trigger('focus');
}

function GetInvoiceHeader() {
    $.ajax({
        type: "GET",
        url: "/User/CommissionPayment/GetInvoiceHeader",
        data: { "invoiceHeaderId": $('#ddlInvoiceHeaders').val() },
        success: function (response) {
            UpdateTextBoxes(response);
            SetFocus();
        }
    });
}

function UpdateTextBoxes(response) {
    $('#txtInvoiceHeaderCommissionToPay').val(formatNumber(response.commissionToPay));
    $('#txtInvoiceHeaderCommissionPaid').val(formatNumber(response.commissionPaid));
    $('#txtInvoiceHeaderCommissionRemainingToPay').val(formatNumber(response.commissionRemainingToPay));
}