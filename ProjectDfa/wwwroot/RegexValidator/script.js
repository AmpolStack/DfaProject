document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');

    const emailCheckbox = form.querySelector('input[name="allowEmail"]');
    const otherCheckboxes = form.querySelectorAll('input[type="checkbox"]:not([name="allowEmail"])');

    // Función para manejar el cambio en el checkbox de email
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

            if (response.ok) {
                showPopup('success', '¡Validación exitosa! La entrada cumple con los criterios.');
            } else {
                showPopup('error', 'La entrada no cumple con los criterios especificados.');
            }
        } catch (error) {
            showPopup('error', 'Error al procesar la validación. Por favor, intente nuevamente.');
        }
    });
});

function showPopup(type, message) {
    // Remover popup anterior si existe
    const existingPopup = document.querySelector('.popup');
    if (existingPopup) {
        existingPopup.remove();
    }

    // Crear nuevo popup
    const popup = document.createElement('div');
    popup.className = `popup ${type}`;
    popup.innerHTML = `
        <div class="popup-content">
            <p>${message}</p>
            <button onclick="this.parentElement.parentElement.remove()">Cerrar</button>
        </div>
    `;

    document.body.appendChild(popup);

    // Remover automáticamente después de 5 segundos
    setTimeout(() => {
        if (popup && document.body.contains(popup)) {
            popup.remove();
        }
    }, 5000);
}
