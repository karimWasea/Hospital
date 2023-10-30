
    function saveStudent() {
        var studentForm = document.getElementById("saveform");

    if (studentForm.checkValidity()) {
        Swal.fire({
            title: "Are you sure?",
            text: "You are about to update the room's information.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, update it!",
            cancelButtonText: "No, cancel",
        }).then((result) => {
            if (result.isConfirmed) {
                var formData = new FormData(studentForm);

                fetch("/Admin/Contact/Save", {
                    method: "POST",
                    body: formData
                })
                    .then(response => response.text())
                    .then(response => {
                        Swal.fire({
                            title: "Success!",
                            text: Success,
                            icon: "success"
                        });
                    })
                    .catch(error => {
                        console.error("Error:", error);
                        Swal.fire({
                            title: "Error!",
                            text: "An error occurred while saving the data.",
                            icon: "error"
                        });
                    });
            }
        });
        } else {
        studentForm.reportValidity();
        }
    }
