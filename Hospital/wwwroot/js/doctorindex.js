
        // Function to perform the front-end search
    function updateSearchResults() {
            const searchText = $('#search-input').val().toLowerCase();
    $('.patient').each(function () {
                const rowText = $(this).text().toLowerCase();
    $(this).toggle(rowText.includes(searchText));
            });
        }

    $(document).ready(function () {
        // Add an event listener to the search input to listen for input changes
        $('#search-input').on('input', function () {
            updateSearchResults();
        });

    // Initial call to populate search results
    updateSearchResults();
        });
