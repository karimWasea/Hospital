

document.addEventListener('DOMContentLoaded', function () {
        const hospitalDropdown = document.getElementById('hospitalDropdown');
    const validationMessage = document.getElementById('validationMessage');
    const saveButton = document.getElementById('saveButton');
    const removeButton = document.getElementById('removeButton'); // New button
    const doctorsTable = document.getElementById('doctorsTable');
    let selectedDoctorId = null;

    hospitalDropdown.addEventListener('change', function () {
        selectedDoctorId = this.value;
    validationMessage.textContent = selectedDoctorId ? '' : 'Please select a doctor.';

    saveButton.disabled = !selectedDoctorId;
    removeButton.disabled = !selectedDoctorId;
        });

    doctorsTable.addEventListener('change', function (event) {
            if (event.target.classList.contains('shift-checkbox')) {
                const row = event.target.closest('tr');
    const isChecked = event.target.checked;
    const shiftType = event.target.getAttribute('data-shift-type');

    if (shiftType === 'am') {
        row.querySelector('.isam').checked = isChecked;
                } else if (shiftType === 'pm') {
        row.querySelector('.ispm').checked = isChecked;
                }
            }
        });

    saveButton.addEventListener('click', function () {
        // Show SweetAlert confirmation
        Swal.fire({
            title: 'Confirm Save',
            text: 'Are you sure you want to save this data?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, save it',
            cancelButtonText: 'Cancel'
        }).then((result) => {
            if (result.isConfirmed) {
                // Proceed with saving the data
                const data = [];

                const rows = doctorsTable.querySelectorAll('tbody tr');
                rows.forEach(row => {
                    const doctorId = selectedDoctorId;
                    const weekDaystId = row.getAttribute('data-weekday-id');
                    const DoctorDayworkId = row.getAttribute('data-daywork-id');
                    const isam = row.querySelector('.isam').checked;
                    const ispm = row.querySelector('.ispm').checked;

                    const newEntry = {
                        DoctorDayworkId: DoctorDayworkId,
                        doctorId: selectedDoctorId,
                        WeekDaystId: weekDaystId,
                        IsCheckedDay: isam || ispm,
                        IsAM: isam,
                        IsPM: ispm
                    };

                    data.push(newEntry);
                });

                fetch('/Doctor/Daywork/Save', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data)
                })
                    .then(response => response.json())
                    .then(data => {
                        console.log('Response from server:', data);
                        if (data.success) {
                            Swal.fire('Success', 'Data updated successfully!', 'success');
                        } else {
                            Swal.fire('Error', 'An error occurred while updating data.', 'error');
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error);
                        Swal.fire('Success');
                    });
            }
        });
        });


    removeButton.addEventListener('click', function () {
        Swal.fire({
            title: 'Confirm Removal',
            text: 'Are you sure you want to remove all shifts?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, remove all shifts',
            cancelButtonText: 'Cancel'
        }).then((result) => {
            if (result.isConfirmed) {
                const rows = doctorsTable.querySelectorAll('tbody tr');
                const data = [];

                rows.forEach(row => {
                    const doctorId = selectedDoctorId;
                    const weekDaystId = row.getAttribute('data-weekday-id');
                    const DoctorDayworkId = row.getAttribute('data-daywork-id');
                    const isam = false;
                    const ispm = false;

                    const removeShafts = {
                        DoctorDayworkId: DoctorDayworkId,
                        doctorId: doctorId,
                        WeekDaystId: weekDaystId,
                        IsCheckedDay: isam || ispm,
                        IsAM: isam,
                        IsPM: ispm
                    };

                    data.push(removeShafts);
                });

                fetch('/Doctor/Daywork/Save', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data)
                })
                    .then(response => response.json())
                    .then(data => {
                        console.log('Response from server:', data);
                        if (data.success) {
                            Swal.fire('Shifts Removed', 'All shifts have been removed.', 'success');
                        } else {
                            Swal.fire('Error', 'An error occurred while removing shifts.', 'error');
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error);
                        Swal.fire(' removing shifts.');
                    });
            }
        });
        });
    });

