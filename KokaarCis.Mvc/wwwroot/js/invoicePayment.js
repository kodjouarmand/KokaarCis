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
        url: "/User/InvoicePayment/GetInvoiceHeader",
        data: { "invoiceHeaderId": $('#ddlInvoiceHeaders').val() },
        success: function (response) {
            UpdateTextBoxes(response);
            SetFocus();
        }
    });
}

function UpdateTextBoxes(response) {
    $('#txtInvoiceHeaderNetAmountToPay').val(formatNumber(response.netAmountToPay));
    $('#txtInvoiceHeaderAdvancedAmount').val(formatNumber(response.advancedAmount));
    $('#txtInvoiceHeaderRemainingAmountToPay').val(formatNumber(response.remainingAmountToPay));
}

