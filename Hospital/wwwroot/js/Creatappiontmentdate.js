
    document.addEventListener('DOMContentLoaded', function () {
         const saveForm = document.getElementById('saveform');

    saveForm.addEventListener('submit', function (event) {
        event.preventDefault(); // Prevent the default form submission

    Swal.fire({
        title: 'Confirm Appointment',
    text: 'Are you sure you want to confirm this appointment?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Yes',
    cancelButtonText: 'No',
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    customClass: {
        confirmButton: 'custom-yes-button-class',
    cancelButton: 'custom-no-button-class'
                 },
    buttonsStyling: false
             }).then((result) => {
                 if (result.isConfirmed) {
        // Submit the form if the user confirms
        saveForm.submit();
                 }
             });
         });
     });

