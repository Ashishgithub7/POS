
$(function () {
    $(".supplierDelete").each(function () {
        const $this = $(this);
        $this.bootstrap_confirm_delete({
            heading: 'Confirm Delete',
            message: "Are you sure you want to delete ?",

            callback: function (e) {
                debugger;
                const supplierId = $this.data('supplier-id');
                $.ajax({
                    url: `/Purchase/Supplier/Delete/${supplierId}`,
                    type: 'DELETE',
                    success: function (response) {
                        debugger;
                        if (response.status === statusEnum.Success) {
                            $('#bootstrap-confirm-dialog').modal('hide');
                            alertMessage(response.message, statusEnum.Success);
                            location.href = '/Purchase/Supplier/List';
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
    });
});
