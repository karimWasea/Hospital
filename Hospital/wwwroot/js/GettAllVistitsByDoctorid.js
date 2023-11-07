
        // Update table visibility based on search input
    function updateTableVisibility(searchTerm) {
            const rows = document.querySelectorAll(".row-style");
            rows.forEach(row => {
                const doctorNameCell = row.querySelector("td:nth-child(2)"); // Adjust this selector as needed
    if (doctorNameCell.textContent.toLowerCase().includes(searchTerm.toLowerCase())) {
        row.style.display = "table-row";
                } else {
        row.style.display = "none";
                }
            });
        }

    const searchInput = document.getElementById("search-input");
    searchInput.addEventListener("input", function () {
        updateTableVisibility(this.value);
        });
