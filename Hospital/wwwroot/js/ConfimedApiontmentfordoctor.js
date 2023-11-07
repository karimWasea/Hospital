
     // Add event listeners to the "not confirmed" buttons
    document.querySelectorAll('.not-confirmed-btn').forEach(button => {
        button.addEventListener('click', function () {
            // Find the closest row to the clicked button
            const row = this.closest('.appointment-row');

            // Toggle a CSS class to make the row red
            row.classList.toggle('not-confirmed-row');
        });
    });

    // Simulate a confirmation and change row color back
    document.querySelectorAll('.confirm-btn').forEach(button => {
        button.addEventListener('click', function () {
            // Find the closest row to the clicked button
            const row = this.closest('.appointment-row');

            // Remove the "not-confirmed-row" class to change the row color back
            row.classList.remove('not-confirmed-row');
        });
    });
