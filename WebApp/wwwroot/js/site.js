

//var loadMoreButton = document.getElementById("load-more");

//// Attach a click event listener to the Load More button
//loadMoreButton.addEventListener("click", function () {
//    // Increment the number of products to display
//    productsToDisplay += 4;

//    // Re-render the products with the updated number of products to display
//    // You can use your preferred way of doing this, for example with AJAX or by submitting a form
//});


const footer = document.querySelector('footer')

if (document.body.scrollHeight >= window.innerHeight)
{
    footer.classList.remove('position')
}
else
{
    footer.classList.add('position')
}

//$(document).ready(function () {
//    var $loadMore = $('#load-more');
//    var $productsContainer = $('.products');

//    $loadMore.on('click', function () {
//        var $products = $('.filter-item');
//        var productsToDisplay = $products.length + 4; // Calculate the new number of products to display

//        $.ajax({
//            url: '/Home/LoadMoreProducts', // Replace with the actual endpoint to fetch the updated section HTML
//            type: 'GET',
//            data: { productsToDisplay: productsToDisplay }, // Pass the updated number of products as data
//            success: function (response) {
//                $productsContainer.html(response); // Replace the existing products with the updated section HTML
//            },
//            error: function (error) {
//                console.log('Error:', error);
//            }
//        });

//        console.log(productsToDisplay);
//    });
//});

$(document).ready(function () {
    var $loadMore = $('#load-more');
    var $productsContainer = $('.filter-container.products');
    var productsToDisplay = 8; // Initial number of products to display

    $loadMore.on('click', function () {
        productsToDisplay += 1; // Increment the number of products to display

        //var $products = $('.filter-item');
        //$products.hide();

        //$products.slice(0, productsToDisplay).show();

        $.ajax({
            url: '/Home/LoadMoreProducts', // Replace with the actual endpoint to fetch the updated product data
            type: 'GET',
            data: { productsToDisplay: productsToDisplay }, // Pass the updated number of products to display as data
            success: function (response) {
                // Append the new product data to the existing products in the container
                $productsContainer.append(response);

                // Hide the "Load More" button if there are no more products to display
                if (response.length === 0) {
                    $loadMore.hide();
                }
            },
            error: function (error) {
                console.log('Error:', error);
            }
        });

        console.log(productsToDisplay);
    });
});


$(document).ready(function () {
    $('.owl-carousel').owlCarousel({
        items: 6, // Number of items to show at a time
        loop: true, // Infinite loop
        margin: 10, // Space between items
        nav: true, // Navigation arrows
        responsive: {
            0: {
                items: 1 // Number of items to show on small screens
            },
            600: {
                items: 2 // Number of items to show on medium screens
            },
            870: {
                items: 3 // Number of items to show on medium screens
            },
            1170: {
                items: 4 // Number of items to show on large screens
            },
            1470: {
                items: 5 // Number of items to show on medium screens
            },
            1770: {
                items: 6 // Number of items to show on medium screens
            }
        }
    });
});

$(document).ready(function () {
    var $isotopeContainer = $('.filter-container');
    var $filterItems = $isotopeContainer.find('.filter-item');
    var $filterButtons = $('ul li');

    $isotopeContainer.isotope({
        itemSelector: '.filter-item',
        layoutMode: 'fitRows'
    });

    $filterButtons.on('click', function () {       

        var filterKey = $(this).data('filter');

        console.log(filterKey)

        if (filterKey === '*') {
            $isotopeContainer.isotope({ filter: '*' });
        } else {
            $isotopeContainer.isotope({ filter: '.' + filterKey });
        }
    });
});