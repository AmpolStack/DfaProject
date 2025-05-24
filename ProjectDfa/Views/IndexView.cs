namespace ProjectDfa.Views;

public class IndexView
{
    public static string Build()
    {
        const string stylesOne = """
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
                                 
                                 section {
                                     display: flex;
                                     flex-wrap: wrap;
                                     flex-direction: row;
                                     justify-content: center;
                                     align-items: center;
                                     gap: 1rem;
                                     width: 100%;
                                     padding: 0 1rem;
                                 }
                                 
                                 section > * {
                                     flex: 1 1 300px;
                                     display: flex;
                                     flex-direction: column;
                                     justify-content: center;
                                     align-items: center;
                                 }
                                 
                                 div > p {
                                     max-width: 100%;
                                     text-align: center;
                                     margin: 0 auto;
                                     padding: 0 1rem;
                                     font-size: clamp(1rem, 2vw, 1.2rem);
                                 }
                                 
                                 div {
                                     margin: 0;
                                     display: flex;
                                     flex-direction: column;
                                     text-align: center;
                                     justify-content: center;
                                     gap: 1.5rem;
                                     width: 100%;
                                 }
                                 
                                 footer {
                                     display: flex;
                                     flex-direction: column;
                                     justify-content: center;
                                     align-items: center;
                                     width: 100%;
                                     padding: 1rem;
                                     margin-top: 2rem;
                                 }
                                 
                                 /* Media Queries */
                                 @media screen and (max-width: 768px) {
                                     body {
                                         border-width: 1rem;
                                     }
                                 
                                     .main-container {
                                         gap: 2rem;
                                     }
                                 
                                     section {
                                         flex-direction: column;
                                     }
                                 
                                     section > * {
                                         flex: 1 1 auto;
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
                                 
                                     input {
                                         padding: .3rem .8rem;
                                     }
                                 
                                     .go-button {
                                         padding: .3rem 1.5rem;
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
        var html = $"""
                   <!DOCTYPE html>
                   <html lang="en">
                   <head>
                       <meta charset="UTF-8">
                       <meta name="viewport" content="width=device-width, initial-scale=1.0">
                       <link rel="stylesheet" href="style.css">
                       <link rel="preconnect" href="https://fonts.googleapis.com">
                       <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
                       <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&family=Pixelify+Sans:wght@400..700&display=swap" rel="stylesheet">
                       <title>DProj</title>
                   </head>
                   <body>
                       <style>{stylesOne}</style>
                       <style>{stylesTwo}</style>
                       <div class="main-container">
                           <h1>DFA PROJECT</h1>
                       <section>        <div>
                               <h2>Regex Evaluator</h2>
                               <p>Evalúa una entrada de texto y analiza si esta es parte del lenguaje regular</p>
                               <a href="https://localhost:7225/regex" class="go-button">Go</a>
                           </div>
                           <div>
                               <h2>Vending Machine</h2>
                               <p>Emula el comportamiento de una maquina expendedora</p>
                               <a href="VendingMachine/vending.html" class="go-button">Go</a>
                           </div>
                       </section>    <footer>
                               <a class="repo-link" href="https://github.com/AmpolStack/DfaProject.git" target="_blank" rel="noopener noreferrer">Ir al repositorio</a>
                               <p>@2024 Amapola</p>
                       </footer>
                       </div>
                       
                   </body>
                   </body>
                   </html>
                   """;
        return html;
    }
}