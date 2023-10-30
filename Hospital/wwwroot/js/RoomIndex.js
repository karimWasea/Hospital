
    async function executeInitialAction(url) {
        try {
            const response = await fetch(url, {method: 'POST' });

    if (response.ok) {
        showEditConfirmation(url);
            } else {
        console.error('Initial action failed');
            }
        } catch (error) {
        console.error('Error:', error);
        }
    }

    async function showEditConfirmation(url) {
        const confirmed = await showConfirmation('Edit', 'Are you sure you want to edit?');
    if (confirmed) {
        window.location.href = url;
        }
    }

    async function DeletEditConfirmation(url) {
        const confirmed = await showConfirmation('Delete', 'Are you sure you want to delete?');
    if (confirmed) {
        window.location.href = url;
        }
    }

    async function showConfirmation(action, message) {
        const result = await Swal.fire({
        title: `Confirm ${action}`,
    text: message,
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: `Yes, ${action} it!`,
    cancelButtonText: 'No, cancel',
        });
    return result.isConfirmed;
    }

