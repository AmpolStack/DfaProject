class VendingMachineAPI {
    constructor() {
        this.baseUrl = '/machine';
        this.setupEventListeners();
        this.updateState();
    }

    setupEventListeners() {
        document.getElementById('insert-coin').addEventListener('click', () => this.insertCoin());
        document.getElementById('select-product').addEventListener('click', () => this.selectProduct());
        document.getElementById('dispense').addEventListener('click', () => this.dispense());
        document.getElementById('return-money').addEventListener('click', () => this.returnMoney());
    }

    async updateState() {
        try {
            const response = await fetch(`${this.baseUrl}/wait`);
            const data = await response.json();
            console.log(data);
            document.getElementById('current-state').textContent = data.state;
            document.getElementById('current-credit').textContent = data.credit.toFixed(2);

            // Habilitar/deshabilitar botones según el estado
            this.updateButtons(data.state);
        } catch (error) {
            showPopup('error', 'Error al actualizar el estado');
        }
    }

    updateButtons(state) {
        const insertBtn = document.getElementById('insert-coin');
        const selectBtn = document.getElementById('select-product');
        const dispenseBtn = document.getElementById('dispense');
        const returnBtn = document.getElementById('return-money');

        switch (state) {
            case 'ESPERANDO':
                insertBtn.disabled = false;
                selectBtn.disabled = true;
                dispenseBtn.disabled = true;
                returnBtn.disabled = true;
                break;
            case 'CON_CREDITO':
                insertBtn.disabled = false;
                selectBtn.disabled = false;
                dispenseBtn.disabled = true;
                returnBtn.disabled = false;
                break;
            case 'PRODUCTO_SELECCIONADO':
                insertBtn.disabled = true;
                selectBtn.disabled = true;
                dispenseBtn.disabled = false;
                returnBtn.disabled = false;
                break;
            case 'DISPENSANDO':
                insertBtn.disabled = true;
                selectBtn.disabled = true;
                dispenseBtn.disabled = true;
                returnBtn.disabled = true;
                break;
        }
    }

    async insertCoin() {
        try {
            const response = await fetch(`${this.baseUrl}/insertCoin`, { method: 'GET' });
            const data = await response.json();

            if (response.ok) {
                showPopup('success', 'Moneda insertada correctamente');
            } else {
                showPopup('error', data.message || 'Error al insertar moneda');
            }

            this.updateState();
        } catch (error) {
            showPopup('error', 'Error al procesar la operación');
        }
    }

    async selectProduct() {
        try {
            const response = await fetch(`${this.baseUrl}/selectProduct`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
                // body: JSON.stringify({ productCode: 'A1' })
            });
            const data = await response.json();

            if (response.ok) {
                showPopup('success', 'Producto seleccionado');
            } else {
                showPopup('error', data.message || 'Error al seleccionar producto');
            }

            this.updateState();
        } catch (error) {
            showPopup('error', 'Error al procesar la operación');
        }
    }

    async dispense() {
        try {
            const response = await fetch(`${this.baseUrl}/wait`, { method: 'GET' });
            const data = await response.json();

            if (response.ok) {
                showPopup('success', '¡Producto dispensado! Por favor retire su producto.');
            } else {
                showPopup('error', data.message || 'Error al dispensar producto');
            }

            this.updateState();
        } catch (error) {
            showPopup('error', 'Error al procesar la operación');
        }
    }

    async returnMoney() {
        try {
            const response = await fetch(`${this.baseUrl}/requestChange`, { method: 'GET' });
            const data = await response.json();

            if (response.ok) {
                showPopup('info', `Se han devuelto $${data.amount.toFixed(2)}`);
            } else {
                showPopup('error', data.message || 'Error al devolver dinero');
            }

            this.updateState();
        } catch (error) {
            showPopup('error', 'Error al procesar la operación');
        }
    }
}

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

// Inicializar la máquina expendedora cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', () => {
    new VendingMachineAPI();
});