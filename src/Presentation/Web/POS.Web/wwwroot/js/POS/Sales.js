$(function () {
    let products = [];
    let salesList = [];
    let updateProductId = 0;
    let discountAmount = 0;
    let discountPercent = 0;
    let netTotal = 0;
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
            else if (quantity < 0)
            {

            }
            const product = products.find(x => x.id === productId);
            const unitPrice = product.sellingPrice;
            const sales = { productId, productName: product.name, quantity: quantity, unitPrice };

            if (updateProductId > 0) {
                const existingProduct = salesList.find(x => x.productId === updateProductId);
                existingProduct.productId = productId;
                existingProduct.quantity = sales.quantity;
                existingProduct.productName = sales.productName;
                existingProduct.unitPrice = sales.unitPrice;
            }
            else {
                const existingProduct = salesList.find(x => x.productId === productId);
                if (existingProduct) {
                    alertMessage(`Product "${product.name}" already exists please update the table.`);
                    return;
                }
                salesList.push(sales);
            }

            loadSalesTable();
        }
    });

    $('#txtDiscount').on('keydown', function (e) {
        if (e.key === 'Enter') {
            if (salesList.length === 0) {
                alertMessage("Sales details is required.");
                $(this).val(0);
                $('#ddlProductName').trigger('focus');
                return;
            }
            let discountText = $(this).val();
            let pattern = /^\d+-?$/;
            let grandTotal = parseFloat($("#hdGrandTotal").text());
            let margin = 10;

            if (!discountText.match(pattern)) {
                alertMessage("Incorrect discount format (Eg: 10 (Percent) or 10- (Amount)).");
                return;
            }

            if (discountText.endsWith('-')) {
                let grandTotalDiscount = (grandTotal * margin) / 100;
                discountAmount = parseInt(discountText.slice(0, -1));
                if (discountAmount > grandTotalDiscount) {
                    alertMessage(`Discount amount shouldn't exceed ${grandTotalDiscount}.`);
                    $("#hdNetTotal").text(grandTotal);
                    $(this).val(0);
                    return;
                }
            } else {
                discountPercent = parseFloat(discountText);
                if (discountPercent > margin) {
                    alertMessage("Discount percent shouldn't exceed 10.");
                    $("#hdNetTotal").text(grandTotal);
                    $(this).val(0);
                    return;
                }
                discountAmount = (grandTotal * discountPercent) / 100;
            }

            netTotal = grandTotal - discountAmount;
            $("#hdNetTotal").text(netTotal);
        }
    });

    function loadSalesTable() {
        let html = '';
        for (let i = 0; i < salesList.length; i++) {
            const element = salesList[i];
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
        $('#tblSalesBody').html(html);
        $('#ddlProductName').val('0');
        $('#txtQuantity').val('');
        $('#ddlProductName').trigger('focus');
        const grandTotal = salesList.reduce((n, { quantity, unitPrice }) => n + (quantity * unitPrice), 0)
        $('#hdGrandTotal').html(grandTotal);
        netTotal = grandTotal
        $('#hdNetTotal').html(grandTotal);
        $('#txtDiscount').val(0);
        updateProductId = 0;
    }

    $('#tblSalesBody').on('click', '.btnItemEdit', function () {
        const productId = $(this).data('product-id');
        const product = salesList.find(x => x.productId === productId);
        if (product) {
            $('#ddlProductName').val(productId);
            $('#txtQuantity').val(product.quantity);
            updateProductId = productId;
        }
    });

    $('#tblSalesBody').on('click', '.btnItemDelete', function () {
        const productId = $(this).data('product-id');
        const productToRemoveIndex = salesList.findIndex(a => a.productId === productId)
        salesList.splice(productToRemoveIndex, 1);
        loadSalesTable();
    });

    $('#btnSalesSave').on('click', function () {
        debugger;
        if (salesList.length === 0) {
            alertMessage('Sales details is required.');
            return;
        }
        const salesRequest = {
            discountPercent,
            discountAmount,
            netAmount: netTotal,
            salesDetails: salesList
        };
        $.ajax({
            url: `/Pos/Sales/Save`,
            type: 'POST',
            data: salesRequest,
            success: function (response) {
                if (response.status === statusEnum.Success) {
                    window.location.href = '/Pos'
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
            url: `/Pos/Product/List`,
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