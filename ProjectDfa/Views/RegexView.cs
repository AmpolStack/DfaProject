namespace ProjectDfa.Views;

public class RegexView
{
    public static string Build()
    {
        const string stylesOne = """
                                 form {
                                     display: flex;
                                     flex-direction: column;
                                     gap: 1.5rem;
                                     background-color: var(--bg-color);
                                     padding: 2rem;
                                     border-radius: 8px;
                                     width: 100%;
                                     max-width: 500px;
                                 }

                                 label {
                                     display: flex;
                                     align-items: center;
                                     gap: 0.5rem;
                                     font-size: 1rem;
                                     color: var(--text-color);
                                     cursor: pointer;
                                 }

                                 input[type="text"] {
                                     width: 100%;
                                     padding: 0.8rem;
                                     border: 2px solid var(--primary-color);
                                     background-color: transparent;
                                     border-radius: 4px;
                                     font-size: 1rem;
                                     transition: border-color 0.3s ease;
                                 }

                                 input[type="text"]:focus {
                                     outline: none;
                                     border-color: var(--primary-color);
                                     box-shadow: 0 0 0 2px rgba(0, 0, 238, 0.1);
                                 }

                                 input[type="checkbox"] {
                                     width: 1.2rem;
                                     height: 1.2rem;
                                     cursor: pointer;
                                     accent-color: var(--primary-color);
                                     background-color: var(--bg-color);
                                     border: 2px solid var(--primary-color);
                                     appearance: none;
                                     -webkit-appearance: none;
                                     border-radius: 3px;
                                 }

                                 input[type="checkbox"]:checked {
                                     background-color: var(--primary-color);
                                     position: relative;
                                 }

                                 input[type="checkbox"]:checked::after {
                                     content: "X";
                                     color: var(--bg-color);
                                     position: absolute;
                                     left: 50%;
                                     top: 50%;
                                     transform: translate(-50%, -50%);
                                     font-size: 0.8rem;
                                 }

                                 button[type="submit"] {
                                     align-self: center;
                                     margin-top: 1rem;
                                 }

                                 /* Popup Styles */
                                 .popup {
                                     position: fixed;
                                     top: 20px;
                                     right: 20px;
                                     padding: 1rem;
                                     border-radius: 8px;
                                     animation: slideIn 0.3s ease-out;
                                     z-index: 1000;
                                 }

                                 .popup-content {
                                     display: flex;
                                     align-items: center;
                                     gap: 1rem;
                                 }

                                 .popup.success {
                                     background-color: #4CAF50;
                                     color: white;
                                     border: 2px solid #45a049;
                                 }

                                 .popup.error {
                                     background-color: #f44336;
                                     color: white;
                                     border: 2px solid #da190b;
                                 }

                                 .popup button {
                                     background: transparent;
                                     border: 1px solid white;
                                     color: white;
                                     padding: 0.3rem 0.8rem;
                                     border-radius: 4px;
                                     cursor: pointer;
                                     font-family: "Pixelify Sans";
                                     transition: all 0.3s ease;
                                 }

                                 .popup button:hover {
                                     background-color: white;
                                     color: var(--primary-color);
                                 }

                                 @keyframes slideIn {
                                     from {
                                         transform: translateX(100%);
                                         opacity: 0;
                                     }
                                     to {
                                         transform: translateX(0);
                                         opacity: 1;
                                     }
                                 }

                                 /* Media Queries */
                                 @media screen and (max-width: 768px) {
                                     form {
                                         padding: 1.5rem;
                                     }
                                 }

                                 @media screen and (max-width: 480px) {
                                     form {
                                         padding: 1rem;
                                     }
                                 }

                                 """;
        const string stylesTwo = """
                        /* Common styles for DFA Project */
                        * {
                            box-sizing: border-box;
                            font-family: "Pixelify Sans";
                        }
                        
                        :root {
                            --primary-color: #0000ee;
                            --bg-color: #ddd;
                            --text-color: #222;
                        }
                        
                        body {
                            margin: 0;
                            padding: 0;
                            text-align: center;
                            background-color: var(--bg-color);
                            border: 1.5rem solid var(--primary-color);
                            color: var(--text-color);
                            min-height: 100vh;
                            height: 100vh;
                            box-sizing: border-box;
                            display: flex;
                            flex-direction: column;
                            justify-content: space-between;
                            align-items: center;
                            padding: 2rem 1rem;
                        }
                        
                        .main-container {
                            flex: 1;
                            display: flex;
                            flex-direction: column;
                            justify-content: center;
                            align-items: center;
                            gap: 3rem;
                            width: 100%;
                            max-width: 1200px;
                        }
                        
                        h1 {
                            color: var(--primary-color);
                            margin: 0;
                            font-size: clamp(2rem, 5vw, 3rem);
                            word-wrap: break-word;
                            max-width: 100%;
                            text-align: center;
                        }
                        
                        footer {
                            display: flex;
                            flex-direction: column;
                            justify-content: center;
                            align-items: center;
                            width: 100%;
                            padding: 1rem;
                            margin-top: 2rem;
                            gap: 0.5rem;
                        }
                        
                        footer a {
                            color: var(--primary-color);
                            text-decoration: none;
                            transition: opacity 0.3s ease;
                        }
                        
                        footer a:hover {
                            opacity: 0.8;
                        }
                        
                        /* Botones comunes */
                        .go-button, 
                        button[type="submit"] {
                            background-color: var(--primary-color);
                            color: var(--bg-color);
                            border: 2px solid var(--primary-color);
                            padding: .5rem 2rem;
                            font-size: 1rem;
                            border-radius: 4px;
                            cursor: pointer;
                            transition: all 0.3s ease;
                            font-family: "Pixelify Sans";
                            text-decoration: none;
                            display: inline-block;
                        }
                        
                        .go-button:hover,
                        .go-button:focus,
                        button[type="submit"]:hover,
                        button[type="submit"]:focus {
                            background-color: var(--bg-color);
                            color: var(--primary-color);
                            outline: none;
                        }
                        
                        .repo-link{
                            text-decoration: underline;
                        }
                        
                        /* Media Queries */
                        @media screen and (max-width: 768px) {
                            body {
                                border-width: 1rem;
                            }
                        
                            .main-container {
                                gap: 2rem;
                            }
                        }
                        
                        @media screen and (max-width: 480px) {
                            body {
                                border-width: 0.5rem;
                                padding: 1rem;
                            }
                        
                            .main-container {
                                gap: 1.5rem;
                            }
                        }
                        
                        """;
        const string script = """
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
                                const response = await fetch('https://localhost:7225/validate', {
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
                    """;
        
        var html = $""""
                    <!DOCTYPE html>
                    <html lang="en">
                    <head>
                        <meta charset="UTF-8">
                        <meta name="viewport" content="width=device-width, initial-scale=1.0">
                        <link rel="stylesheet" href="regex.css">
                        <link rel="preconnect" href="https://fonts.googleapis.com">
                        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
                        <link href="https://fonts.googleapis.com/css2?family=Pixelify+Sans:wght@400..700&display=swap" rel="stylesheet">    <title>DProj | Regex Evaluator</title>
                        <script src="regex.js" defer></script>
                    </head>
                    <body>
                        <style>{stylesOne}</style>
                        <style>{stylesTwo}</style>
                        <div class="main-container">
                            <h1>Regex Evaluator</h1>
                            <form method="post" action="/validate">
                                <label for="input">Entrada:</label>
                                <input type="text" id="input" name="input" required placeholder="Ingresa el texto a evaluar...">
                                <label>
                                    <input type="checkbox" name="allowNumbers" checked>
                                    Permitir números (0–9)
                                </label>
                                <label>
                                    <input type="checkbox" name="allowLetters" checked>
                                    Permitir letras (A–Z, a–z)
                                </label>
                                <label>
                                    <input type="checkbox" name="allowSpecials">
                                    Permitir caracteres especiales
                                </label>
                                <button type="submit">Validar</button>
                            </form>
                        </div>    
                        <footer>
                            <a class="repo-link" href="https://github.com/AmpolStack/DfaProject.git" target="_blank" rel="noopener noreferrer">Ir al repositorio</a>
                            <a class="repo-link" href="https://localhost:7225/">Volver</a>
                            <p>@2024 Amapola</p>
                        </footer>
                        <script>{script}</script>
                    </body>
                    </html>
                    """";
        return html;
    }
}