
$(function () {
    $(".subCategoryDelete").each(function () {
        const $this = $(this);
        $this.bootstrap_confirm_delete({
            heading: 'Confirm Delete',
            message: `Are you sure you want to delete ${$this.data('name')}?`,

            callback: function (e) {
                debugger;
                const subCategoryId = $this.data('sub-category-id');
                $.ajax({
                    url: `/Inventory/SubCategory/Delete/${subCategoryId}`,
                    type: 'DELETE',
                    success: function (response) {
                        debugger;
                        if (response.status === statusEnum.Success) {
                            $('#bootstrap-confirm-dialog').modal('hide');
                            alertMessage(response.message, statusEnum.Success);
                            setTimeout(() => { location.href = '/Inventory/SubCategory/List'; }, 2000);
                            
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
