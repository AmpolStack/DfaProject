let STATE = 'WaitingForCoin'
class VendingMachineAPI {
    constructor() {
        this.baseUrl = '/machine';
        this.setupEventListeners();
    }

    setupEventListeners() {
        document.getElementById('insert-coin').addEventListener('click', () => this.executeAction('insertCoin',this.IncreaseCredit(1)));
        document.getElementById('select-product').addEventListener('click', () => this.executeAction('selectProduct/A1',));
        document.getElementById('dispense').addEventListener('click', () => this.executeAction('dispense'));
        document.getElementById('return-money').addEventListener('click', () => this.executeAction('requestChange', this.RestartCredit(), 'info'));
    }
    async executeAction(subPath, OkCallback, popupType ){
        try {
            const response = await fetch(`${this.baseUrl}/${subPath}/${STATE}`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
            });
            const data = await response.json();

            if (response.ok) {
                if(OkCallback != null){
                    OkCallback();
                }
                
                if(popupType != null){
                    showPopup(popupType, data.message);
                }
                else{
                    showPopup('success', data.message);
                }
                
                STATE = data.data;
                this.ChangeState(STATE);
                
            } else {
                showPopup('error', data.message);
            }
        } catch (error) {
            showPopup('error', 'Error al procesar la operación');
        }
    }
    IncreaseCredit(value){
        const credit = document.getElementById('current-credit');
        credit.textContent = (parseFloat(credit.textContent) + value).toFixed(2);
    }

    RestartCredit(){
        const credit = document.getElementById('current-credit');
        credit.textContent = (0).toFixed(2);
    }
    
    ChangeState(value){
        const state = document.getElementById('current-state');
        state.textContent = value;
    }
}

// Init the process when the page are loaded
document.addEventListener('DOMContentLoaded', () => {
    new VendingMachineAPI();
});