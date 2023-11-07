
    document.addEventListener("DOMContentLoaded", function () {
                                var saveForm = document.getElementById("saveform");

    saveForm.addEventListener("submit", function (event) {
        event.preventDefault();

    Swal.fire({
        title: "Are you sure?",
    text: "You are about to update the shift information.",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Yes, update it!",
    cancelButtonText: "No, cancel",
                                }).then((result) => {
                                if (result.isConfirmed) {
        saveForm.submit();
                                }
                                }); 
                                });
                                });

    document.addEventListener('DOMContentLoaded', function () {
                                var startShiftInput = document.querySelector('#startshift');
    var endsifitInput = document.querySelector('#Endsifit');
    var durationInput = document.querySelector('#durationInput');

    function updateDuration() {
var startShiftValue = new Date(startShiftInput.value);
    var endsifitValue = new Date(endsifitInput.value);
    var durationMilliseconds = endsifitValue - startShiftValue;
    var durationHours = durationMilliseconds / (1000 * 60 * 60);
    durationInput.value = durationHours.toFixed(2);
}

    startShiftInput.addEventListener('change', updateDuration);
    endsifitInput.addEventListener('change', updateDuration);
});

