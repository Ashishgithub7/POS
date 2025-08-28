
$(function () {
    $(".productDelete").each(function () {
        const $this = $(this);
        $this.bootstrap_confirm_delete({
            heading: 'Confirm Delete',
            message: `Are you sure you want to delete ${$this.data('name')}?`,

            callback: function (e) {
                debugger;
                const productId = $this.data('product-id');
                $.ajax({
                    url: `/Inventory/Product/Delete/${productId}`,
                    type: 'DELETE',
                    success: function (response) {
                        debugger;
                        if (response.status === statusEnum.Success) {
                            $('#bootstrap-confirm-dialog').modal('hide');
                            alertMessage(response.message, statusEnum.Success);
                            setTimeout(() => { location.href = '/Inventory/Product/List'; }, 2000);

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

    $('#ddlCategory').on('change', function () {
        debugger;
        var categoryId = $(this).val();
        loadSubCategories(categoryId);
    });

    function loadSubCategories(categoryId) {
        var option = '<option value="">Please select a sub category</option>';
        if (!categoryId || categoryId == 0) {
            $('#ddlSubCategory').html(option);
            return;
        }
        $.ajax({
            url: `/Inventory/SubCategory/Category/${categoryId}`,
            success: function (response) {
                    for (let i = 0; i < response.length; i++) {
                        var element = response[i];
                        option += `<option value="${element.id}">${element.name}</option>`;
                    }
                    $('#ddlSubCategory').html(option);
                    var selectedId = $('#ddlSubCategory').data('selected-id');
                    $('#ddlSubCategory').val(selectedId);
            },
            error: function (error) {
                console.log(error);
            }
        });
    };

});
