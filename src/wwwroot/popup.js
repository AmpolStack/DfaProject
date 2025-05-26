function showPopup(type, message) {
    // Remove existing popup if it exists
    const existingPopup = document.querySelector('.popup');
    if (existingPopup) {
        existingPopup.remove();
    }

    // Create new popup
    const popup = document.createElement('div');
    popup.className = `popup ${type}`;
    popup.innerHTML = `
        <div class="popup-content">
            <p>${message}</p>
            <button onclick="this.parentElement.parentElement.remove()">Cerrar</button>
        </div>
    `;

    document.body.appendChild(popup);

    // Remove automatically after 5 seconds
    setTimeout(() => {
        if (popup && document.body.contains(popup)) {
            popup.remove();
        }
    }, 5000);
}