

//var loadMoreButton = document.getElementById("load-more");

//// Attach a click event listener to the Load More button
//loadMoreButton.addEventListener("click", function () {
//    // Increment the number of products to display
//    productsToDisplay += 4;

//    // Re-render the products with the updated number of products to display
//    // You can use your preferred way of doing this, for example with AJAX or by submitting a form
//});

//function footerPosition(element, scrollHeight, innerHeight) {
//    try {
//        const _element = document.querSelector(element)
//        const isTallerThanScreen = scrollHeight >= innerHeight

//        _element.classList.footer('position-fixed-bottom', !isTallerThanScreen)
//        _element.classList.footer('position-static', isTallerThanScreen)


//        console.log(element, scrollHeight, innerHeight)

//    } catch { }

//}

const footer = document.querySelector('footer')
//console.log("footers totala höjd: " + footer.scrollHeight)
//console.log("Hemsidans totala höjd: " + document.body.scrollHeight)

if (document.body.scrollHeight >= window.innerHeight)
{
    footer.classList.remove('position')
}
else
{
    footer.classList.add('position')
}


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

