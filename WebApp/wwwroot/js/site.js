// Carousel Auto-Cycle
  $(document).ready(function() {
    $('.carousel').carousel({
      interval: 6000
    })
  });

var loadMoreButton = document.getElementById("load-more");

// Attach a click event listener to the Load More button
loadMoreButton.addEventListener("click", function () {
    // Increment the number of products to display
    productsToDisplay += 4;

    // Re-render the products with the updated number of products to display
    // You can use your preferred way of doing this, for example with AJAX or by submitting a form
});