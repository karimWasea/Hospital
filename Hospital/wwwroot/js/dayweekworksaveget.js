

    function saveData() {
        const rows = document.querySelectorAll('tr');
    const data = [];

        rows.forEach(row => {
            const doctorId = row.querySelector('input[type="hidden"]').value;
    const ischekedday = row.querySelector('input#ischekedday').checked;
    const isam = row.querySelector('input#isam').checked;
    const ispm = row.querySelector('input#ispm').checked;

    data.push({
        DoctorId: doctorId,
    ischekedday: ischekedday,
    isam: isam,
    ispm: ispm
            });
        });

    const formData = JSON.stringify(data);

    // Send data using AJAX
    fetch('/Doctor/Daywork/Save', {
        method: 'POST',
    headers: {
        'Content-Type': 'application/json'
            },
    body: formData
        })
            .then(response => response.json())
            .then(data => {
        console.log('Response from server:', data);
    alert('Data saved successfully!');
            })
            .catch(error => {
        console.error('Error:', error);
    alert('An error occurred while saving data.');
            });
    }
