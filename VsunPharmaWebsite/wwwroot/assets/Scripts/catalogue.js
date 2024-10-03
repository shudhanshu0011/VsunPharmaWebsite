$(document).ready(function () {

    $.ajax({
        url: '/Home/GetAllProducts',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            var productListDiv = $('#productCatalogue');
            productListDiv.empty();

            response.Records.forEach(function (product) {
                var discountPercentage = ((product.RegularPrice - product.DiscountedPrice) / product.RegularPrice * 100).toFixed(2);
                
                var productHtml = `
                <div class="col-md-4 col-sm-6 col-12">
                            <div class="product">
                                <a href="/Home/Product/${product.ProductId}" class="product-img">
                                    <img src="${product.ProductImage}" class="" alt="${product.ProductName}">
                                </a>
                                <div class="product-info">
                                    <div class="product-rating">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                        <i class="fa fa-star-o"></i>
                                        <div class="review-count">4.5 (2,213)</div>
                                    </div>
                                    <h3>
                                        <a href="/Home/Product/${product.ProductId}">
                                            ${product.ProductName}
                                        </a>
                                    </h3>
                                    <div class="product-value">
                                        <div class="d-flex">
                                            <small class="regular-price">MRP <del>₹${product.RegularPrice.toFixed(2)}</del></small>
                                            <div class="off-price">${discountPercentage}% off</div>
                                        </div>
                                        <div class="current-price">₹${product.DiscountedPrice.toFixed(2)}</div>
                                    </div>
                                </div>
                            </div>
                        </div>`;
                        
                productListDiv.append(productHtml);
            });
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });

});
