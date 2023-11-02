// Get the search input element
const searchInput = document.getElementById('search-input');

// Get the doctor cards
const doctorCards = document.querySelectorAll('.doctor-card');

// Function to update the search results
function updateSearchResults() {
    const searchText = searchInput.value.toLowerCase();

    doctorCards.forEach(doctorCard => {
        const doctorInfo = doctorCard.textContent.toLowerCase();
        if (doctorInfo.includes(searchText)) {
            doctorCard.style.display = 'block';
        } else {
            doctorCard.style.display = 'none';
        }
    });
}

// Add an event listener to the search input to listen for input changes
searchInput.addEventListener('input', function () {
    updateSearchResults();
});

// Initial call to populate search results
updateSearchResults();
