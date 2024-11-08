$(document).ready(function () {
    $('.btn-editt, .btn-deletee').on('click', function () {
        var button = $(this);
        var productId = button.data('id'); 
        var action = button.data('action');

        var productData = {
            ProductId: productId,
            ProductName: $("input[name='ProductName_" + productId + "']").val(),
            Brand: $("input[name='Brand_" + productId + "']").val(),
            Category: $("input[name='Category_" + productId + "']").val(),
            RegularPrice: $("input[name='RegularPrice_" + productId + "']").val(),
            DiscountedPrice: $("input[name='DiscountedPrice_" + productId + "']").val(),
            Quantity: $("input[name='Quantity_" + productId + "']").val(),
            SKU: $("input[name='SKU_" + productId + "']").val(),
            ProductDescription: $("textarea[name='Description_" + productId + "']").val()
        };

        if (action === 'Edit') {
            $.ajax({
                url: '/Home/SaveChanges', 
                type: 'POST',
                data: {
                    product: productData,
                    action: 'Edit_' + productId
                },
                success: function (response) {
                    if (response.success) {
                        alert("Product updated successfully!");
                    } else {
                        alert("Failed to update the product.");
                    }
                },
                error: function () {
                    alert("An error occurred while updating the product.");
                }
            });
        }

        else if (action === 'Delete') {
            if (confirm('Are you sure you want to delete this product?')) {
                $.ajax({
                    url: '@Url.Action("SaveChanges")', 
                    type: 'POST',
                    data: {
                        product: { ProductId: productId },
                        action: 'Delete_' + productId
                    },
                    success: function (response) {
                        if (response.success) {
                            button.closest('tr').remove();
                            alert("Product deleted successfully.");
                        } else {
                            alert("Failed to delete the product.");
                        }
                    },
                    error: function () {
                        alert("An error occurred while deleting the product.");
                    }
                });
            }
        }
    });
});
