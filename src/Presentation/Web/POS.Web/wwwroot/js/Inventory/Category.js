$(document).ready(function () {
    $('.categoryDelete').on('click', function () {
        const categoryId = $(this).data('category-id');
        $.ajax({
            url: `/Inventory/Category/Delete/${categoryId}`,
            type: 'DELETE',
            success: function (response) {
                debugger;
                //if (response.success) {
                //    $('#bootstrap-confirm-dialog').modal('hide');
                //    alertMessage(response.message, statusEnum.success);
                //} else {
                //    $('#bootstrap-confirm-dialog').modal('hide');
                //    alertMessage(response.errors.join('\r\n'));
                //}
            },
            error: function (error) {
                console.log(error)
            }
        })
    })
});