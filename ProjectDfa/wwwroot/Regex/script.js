document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');

    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        const formData = new FormData(form);
        const input = formData.get('input');
        const allowNumbers = formData.get('allowNumbers') === 'on';
        const allowLetters = formData.get('allowLetters') === 'on';
        const allowSpecials = formData.get('allowSpecials') === 'on';

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
                    allowSpecials
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
