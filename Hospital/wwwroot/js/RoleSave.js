
    document.addEventListener("DOMContentLoaded", function () {
        var saveButton = document.getElementById("savedata");

    saveButton.addEventListener("click", function (event) {
        event.preventDefault();

    Swal.fire({
        title: "Are you sure?",
    text:  "e are about to update the patient's information.",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Yes, update it!",
    cancelButtonText: "No, cancel",
            }).then((result) => {
                if (result.isConfirmed) {
        // Proceed with the AJAX submission
        SaveStudent();
                }
            });
        });
    });

    function SaveStudent() {
        var name = document.getElementById("name").value;
    var roleid = document.getElementById("Roleid").value;

    var data = {
        Name: name,
    Id: roleid
        };

    fetch('/Admin/Role/Save', {
        method: 'POST',
    headers: {
        'Content-Type': 'application/json'
            },
    body: JSON.stringify(data)
        })
            .then(response => response.text())
            .then(response => {
        Swal.fire({
            title: "Success!",
            text: name,
            icon: "success"
        });
    document.getElementById("saveform").reset(); // Reset the form after successful submission
            })
            .catch(error => {
        Swal.fire({
            title: "Error!",
            text: "An error occurred while sending data.",
            icon: "error"
        });
            });
    }