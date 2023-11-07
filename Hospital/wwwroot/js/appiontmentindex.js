

    function addstyle(button) {
            const row = button.closest(".row-style");
    const isArriveButton = button.classList.contains("arrive-button");
    const bgColorClass = isArriveButton ? "green-bg" : "red-bg";

    row.classList.toggle(bgColorClass, true);
    row.querySelector(".visit-status-cell").classList.toggle(bgColorClass, true);

    const oppositeButton = row.querySelector(isArriveButton ? ".cancel-button" : ".arrive-button");
    const currentButton = row.querySelector(isArriveButton ? ".arrive-button" : ".cancel-button");

    currentButton.style.display = "none";
    oppositeButton.style.display = "block";

    const bgColor = isArriveButton ? "aquamarine" : "red";
    localStorage.setItem(`background_color_${row.id}`, bgColor);
        }

    // On page load
    document.addEventListener("DOMContentLoaded", function () {
            const rows = document.querySelectorAll(".row-style");
            rows.forEach(row => {
                const storedColor = localStorage.getItem(`background_color_${row.id}`);
    if (storedColor) {
        row.style.backgroundColor = storedColor;
    row.querySelector(".visit-status-cell").style.backgroundColor = storedColor;
                }

    const arriveButton = row.querySelector(".arrive-button");
    const cancelButton = row.querySelector(".cancel-button");

    if (arriveButton.style.display === "none") {
        cancelButton.style.display = "none";
                } else if (cancelButton.style.display === "none") {
        arriveButton.style.display = "none";
                }
            });
        });

    // Update table visibility based on search input
    function updateTableVisibility(searchTerm) {
            const rows = document.querySelectorAll(".row-style");
            rows.forEach(row => {
                const doctorNameCell = row.querySelector("td:nth-child(2)"); // Adjust this selector as needed
    if (doctorNameCell.textContent.toLowerCase().includes(searchTerm.toLowerCase()) || doctorNameCell.textContent.toUpperCase().includes(searchTerm.toUpperCase())) {
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



