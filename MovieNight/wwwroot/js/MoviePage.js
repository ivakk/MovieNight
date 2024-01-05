document.addEventListener('DOMContentLoaded', function () {
    // Add to Watchlist Button
    var watchlistBtn = document.querySelector('.watchlist-button');
    var watchlistAdded = false;
    watchlistBtn.addEventListener('click', function () {
        watchlistAdded = !watchlistAdded;
        watchlistBtn.textContent = watchlistAdded ? 'Remove from Watchlist' : '+ Add to Watchlist';
    });

    // User Rating
    var rateButton = document.querySelector('.rate-button');
    rateButton.addEventListener('click', function () {
        var userRating = prompt('Enter your rating (1-10)');
        if (userRating) {
            // Implement rating logic, e.g., send to server or display on page
            alert('You rated this movie: ' + userRating + '/10');
        }
    });
});
