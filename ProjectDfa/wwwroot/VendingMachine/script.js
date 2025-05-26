class VendingMachineAPI {
    constructor() {
        this.baseUrl = '/machine';
        this.setupEventListeners();
    }

    setupEventListeners() {
        document.getElementById('insert-coin').addEventListener('click', () => this.executeAction('insertCoin', 'COIN INSERTED',this.IncreaseCredit(1)));
        document.getElementById('select-product').addEventListener('click', () => this.executeAction('selectProduct?name=A1', 'PRODUCT SELECTED'));
        document.getElementById('dispense').addEventListener('click', () => this.executeAction('dispense', 'DELIVERED'));
        document.getElementById('return-money').addEventListener('click', () => this.executeAction('requestChange', 'WAITING FOR COIN', this.RestartCredit(), 'info'));
    }
    async executeAction(subPath, changeState, OkCallback, popupType ){
        try {
            const response = await fetch(`${this.baseUrl}/${subPath}`, {
                method: 'GET',
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
                
                this.ChangeState(changeState);
                
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