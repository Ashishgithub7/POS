$(function () {
    let products = [];
    let purchases = [];
    let updateProductId = 0;
    getAllProducts();

    $('#ddlProductName').on('change', function () {
        const productId = parseInt($(this).val());
        if (productId > 0) {
            $('#ddlProductNameError').addClass('d-none');
            $('#txtQuantity').trigger('focus');
        }
        else {
            $('#ddlProductNameError').removeClass('d-none');
        }
    });

    $('#txtQuantity').on('keydown', function (e) {
        if (e.key === 'Enter') {
            const productId = parseInt($('#ddlProductName').val());
            if (productId === 0) {
                $('#ddlProductNameError').removeClass('d-none');
                return;
            }

            let quantity = parseInt($(this).val());
            if (!quantity || quantity === 0) {
                quantity = 1;
            }
            const product = products.find(x => x.id === productId);
            const unitPrice = product.purchasePrice;
            const purchase = { productId, productName: product.name, quantity, unitPrice };

            if (updateProductId > 0) {
                const existingProduct = purchases.find(x => x.productId === updateProductId);
                existingProduct.productId = productId;
                existingProduct.quantity = purchase.quantity;
                existingProduct.productName = purchase.productName;
                existingProduct.unitPrice = purchase.unitPrice;
            }
            else {
                const existingProduct = purchases.find(x => x.productId === productId);
                if (existingProduct) {
                    alertMessage(`Product "${product.name}" already exists please update the table.`);
                    return;
                }
                purchases.push(purchase);
            }

            loadPurchaseTable();
        }
    });

    function loadPurchaseTable() {
        let html = '';
        for (let i = 0; i < purchases.length; i++) {
            const element = purchases[i];
            html += `<tr>
                    <td>${i + 1}</td>
                    <td>${element.productName}</td>
                    <td>${element.unitPrice}</td>
                    <td>${element.quantity}</td>
                    <td>${element.unitPrice * element.quantity}</td>
                     <td>
                    <a data-product-id="${element.productId}" class="btn btn-warning btn-sm btnItemEdit">Edit</a>
                    <a data-product-id="${element.productId}" href="#" class="btn btn-danger btn-sm btnItemDelete">Delete</a>
                </td>
                </tr>`;
        }
        $('#tblPurchaseBody').html(html);
        $('#ddlProductName').val('0');
        $('#txtQuantity').val('');
        $('#ddlProductName').trigger('focus');
        const grandTotal = purchases.reduce((n, { quantity, unitPrice }) => n + (quantity * unitPrice), 0)
        $('#txtGrandTotal').html(grandTotal);
        updateProductId = 0;
    }

    $('#tblPurchaseBody').on('click', '.btnItemEdit', function () {
        const productId = $(this).data('product-id');
        const product = purchases.find(x => x.productId === productId);
        if (product) {
            $('#ddlProductName').val(productId);
            $('#txtQuantity').val(product.quantity);
            updateProductId = productId;
        }
    });

    $('#tblPurchaseBody').on('click', '.btnItemDelete', function () {
        const productId = $(this).data('product-id');
        const productToRemoveIndex = purchases.findIndex(a => a.productId === productId)
        purchases.splice(productToRemoveIndex, 1);
        loadPurchaseTable();
    });

    $('#ddlSupplierId').on('change', function () {
        const supplierId = parseInt($(this).val());
        if (supplierId || supplierId > 0) {
            $('#supplierIdErrorMsg').addClass('d-none');
            return;
        }
    });

    $('#btnPurchaseSave').on('click', function () {
        debugger;
        const supplierId = parseInt($('#ddlSupplierId').val());
        if (!supplierId || supplierId === 0) {
            $('#supplierIdErrorMsg').removeClass('d-none');
            return;
        }

        if (purchases.length === 0) {
            alertMessage('Purchase details is required.');
            return;
        }
        const purchaseRequest = {
            supplierId,
            purchaseDetails: purchases
        };
        $.ajax({
            url: `/Purchase/Save`,
            type: 'POST',
            data: purchaseRequest,
            success: function (response) {
                if (response.status === statusEnum.Success) {
                    window.location.href = '/Purchase'
                }
                else {
                    alertMessage(response.error);
                }
            },
            error: function (error) {
                console.log(error)
            }
        });
    });

    function getAllProducts() {
        $.ajax({
            url: `/Purchase/Product/List`,
            type: 'GET',
            success: function (response) {
                products = response;
            },
            error: function (error) {
                console.log(error)
            }
        });
    }
});