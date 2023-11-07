


    document.addEventListener("DOMContentLoaded", function () {
        var saveForm = document.getElementById("registerForm");

    saveForm.addEventListener("submit", function (event) {
        event.preventDefault();

    Swal.fire({
        title: "Are you sure?",
    text: "You are about to update the patient's information.",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Yes, update it!",
    cancelButtonText: "No, cancel",
            }).then((result) => {
                if (result.isConfirmed) {
        // You can add AJAX submission or simply let the form submit normally
        saveForm.submit();
                }
            });
        });

    var urlParams = new URLSearchParams(window.location.search);
    var successParam = urlParams.get("success");
    if (successParam === "true") {
        Swal.fire({
            title: "Success!",
            text: "Patient's information has been updated.",
            icon: "success"
        });
        }
    });


