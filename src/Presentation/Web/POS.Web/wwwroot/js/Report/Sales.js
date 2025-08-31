$(function () {
    let report = [];

    $('#reportType').on('change', function () {
        let reportType = $(this).val();

        $.ajax({
            url: `/Report/SalesReport`,
            type: 'GET',
            data: { request: reportType },
            success: function (response) {
                    report = response;
                    loadReportTable();
            },
            error: function (error) {
                console.log(error)
            }
        });
    });

    function loadReportTable() {
        let html = '';
        html += `<tr>
                    <td>${report[0].totalGrossAmount.toLocaleString('en-IN') }</td>
                    <td>${report[0].totalDiscountAmount.toLocaleString('en-IN') }</td>
                    <td>${report[0].totalDiscountPercentage.toLocaleString('en-IN') }</td>
                    <td>${report[0].totalNetAmount.toLocaleString('en-IN') }</td>
                    <td>${report[0].totalRecords.toLocaleString('en-IN') }</td>
                </tr>`;

        $('#salesReportBody').html(html);
    }
});