
$(function () {
    $(".categoryDelete").each(function () {
        const $this = $(this);
        $this.bootstrap_confirm_delete({
            heading: 'Confirm Delete',
            message: " Are you sure you want to delete ?",
            success: function (e) {
                const categoryId = $(this).data('category-id');
                $.ajax({
                    url: `/Inventory/Category/Delete/${categoryId}`,
                    type: 'DELETE',
                    success: function (response) {
                        if (response.success) {
                            $('#bootstrap-confirm-dialog').modal('hide');
                            alertMessage(response.message, statusEnum.success);
                        } else {
                            $('#bootstrap-confirm-dialog').modal('hide');
                            alertMessage(response.errors.join('\r\n'));
                        }
                    },
                    error: function (error) {
                        console.log(error)
                    }
                })
            },
            cancel_callback: function (e) {
                $('#bootstrap-confirm-dialog').modal('hide');
            }
        });
        $(document).on('click', '#bootstrap-confirm-dialog .close', function () {
            $('#bootstrap-confirm-dialog').modal('hide')
        });
        //$('.categoryDelete').on('click', function () {
        //    const categoryId = $(this).data('category-id');
        //    $.ajax({
        //        url: `/Inventory/Category/Delete/${categoryId}`,
        //        type: 'DELETE',
        //        success: function (response) {
        //            debugger;
        //            //if (response.success) {
        //            //    $('#bootstrap-confirm-dialog').modal('hide');
        //            //    alertMessage(response.message, statusEnum.success);
        //            //} else {
        //            //    $('#bootstrap-confirm-dialog').modal('hide');
        //            //    alertMessage(response.errors.join('\r\n'));
        //            //}
        //        },
        //        error: function (error) {
        //            console.log(error)
        //        }
        //    })
        //})
    });
});
