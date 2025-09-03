$(function () {
    let report = [];
    let reportTypeText;
    $('#reportType').on('change', function () {
        let reportType = $(this).val();
        if (reportType == "0") { $('#reportBody').addClass('d-none'); }
        let reportTypeText = $(this).find("option:selected").text();
        debugger;

        switch (reportTypeText)
        {
            case ("Daily"):
                {
                    $('#reportBody').removeClass('d-none');
                    $('.reportTypeInfo').html(`For this Day`);
                    break;
                }
            case ("Weekly"):
                {
                    $('#reportBody').removeClass('d-none');
                    $('.reportTypeInfo').html(`For this Week`);
                    break;
                }
            case ("Monthly"):
                {
                    $('#reportBody').removeClass('d-none');
                    $('.reportTypeInfo').html(`For this Month`);
                    break;
                }
            case ("Yearly"):
                {
                    $('#reportBody').removeClass('d-none');
                    $('.reportTypeInfo').html(`For this Year`);
                    break;
                }
            default:
                { $('.reportTypeInfo').html(``); }
        }


        $.ajax({
            url: `/Report/RevenueReport`,
            type: 'GET',
            data: { request: reportType },
            success: function (response) {
                report = response;
                loadReport();
            },
            error: function (error) {
                console.log(error)
            }
        });
    });

    function loadReport() {
        debugger;

        $('#gross').html(`NRs ${report[0].totalGrossAmount.toLocaleString('en-IN') }`);
        $('#net').html(`NRs ${report[0].totalNetAmount.toLocaleString('en-IN') }`);
        $('#profit').html(`NRs ${report[0].totalProfitAmount.toLocaleString('en-IN')}`);

       
    }
});