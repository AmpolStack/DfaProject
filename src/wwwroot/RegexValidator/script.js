
//Just executed when the page is totally loaded
document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');

    const emailCheckbox = form.querySelector('input[name="allowEmail"]');
    const otherCheckboxes = form.querySelectorAll('input[type="checkbox"]:not([name="allowEmail"])');

    // Function to handle the value changes in email checkbox 
    emailCheckbox.addEventListener('change', () => {
        otherCheckboxes.forEach(checkbox => {
            checkbox.disabled = emailCheckbox.checked;
            if (emailCheckbox.checked) {
                checkbox.checked = false;
            }
        });
    });
    
    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        const formData = new FormData(form);
        const input = formData.get('input');
        const allowNumbers = formData.get('allowNumbers') === 'on';
        const allowLetters = formData.get('allowLetters') === 'on';
        const allowSpecials = formData.get('allowSpecials') === 'on';
        const allowEmail = formData.get('allowEmail') === 'on';

        try {
            const response = await fetch('/validate', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    input,
                    allowNumbers,
                    allowLetters,
                    allowSpecials,
                    allowEmail
                })
            });
            
            var data = await response.json();
            if (response.ok) {
                showPopup('success', data.message);
            } else {
                showPopup('error', data.message);
            }
        } catch (error) {
            showPopup('error', 'Error al procesar la validación. Por favor, intente nuevamente.');
        }
    });
});
