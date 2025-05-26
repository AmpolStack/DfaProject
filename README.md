# Implementación de Autómatas Finitos Deterministas (DFA)

Este proyecto implementa tres diferentes Autómatas Finitos Deterministas (DFA) para resolver distintos problemas de validación y control de estados. Cada autómata está diseñado para resolver un problema específico utilizando la teoría de autómatas finitos.

## 1. Validador de Correos Electrónicos (EmailValidator)

El validador de correos electrónicos es un autómata que verifica la estructura correcta de una dirección de correo electrónico siguiendo las siguientes reglas:

- La parte local (antes del @) puede contener letras, números y caracteres especiales
- Debe contener exactamente un símbolo @
- El dominio debe contener al menos un punto (.)
- El dominio debe terminar con una extensión válida

### Tabla de Transiciones del EmailValidator

| Estado Actual | Entrada (char) | Estado Siguiente | Descripción |
|--------------|----------------|------------------|-------------|
| Init | [a-zA-Z0-9] | LocalBaseChar | Primer carácter válido de la parte local |
| LocalBaseChar | [a-zA-Z0-9] | LocalBaseChar | Continúa la parte local con caracteres válidos |
| LocalBaseChar | [._-] | LocalSpecialChar | Carácter especial en la parte local |
| LocalSpecialChar | [a-zA-Z0-9] | LocalBaseChar | Después de especial, vuelve a carácter normal |
| LocalBaseChar | @ | AtSign | Separador de parte local y dominio |
| AtSign | [a-zA-Z0-9] | DomainBaseChar | Primer carácter del dominio |
| DomainBaseChar | [a-zA-Z0-9] | DomainBaseChar | Continúa el dominio |
| DomainBaseChar | . | DomainDot | Punto en el dominio |
| DomainDot | [a-zA-Z] | Accepted | Extensión del dominio (.com, .org, etc.) |

### Diagrama del EmailValidator
![Diagrama del Validador de Correos](img/EmailValidatorDiagram.png)

### Ejemplos de Validación de Emails

| Entrada | Resultado | Explicación |
|---------|-----------|-------------|
| usuario@dominio.com | ✅ Válido | Formato correcto de email |
| usuario.nombre@dominio.com | ✅ Válido | Permite punto en parte local |
| usuario@sub.dominio.com | ✅ Válido | Permite múltiples puntos en dominio |
| usuario@dominio | ❌ Inválido | Falta el TLD (.com, .org, etc.) |
| @dominio.com | ❌ Inválido | Falta la parte local |
| usuario..nombre@dominio.com | ❌ Inválido | Puntos consecutivos no permitidos |

## 2. Máquina Expendedora (VendingMachine)

La máquina expendedora simula un sistema real de venta de productos utilizando un autómata para controlar el flujo de operaciones y garantizar que las transiciones entre estados sean válidas.

### Tabla de Transiciones Completa de la Máquina Expendedora

| Estado Actual | Entrada | Estado Siguiente | Descripción |
|--------------|---------|------------------|-------------|
| WaitingForCoin | InsertCoin | CoinInserted | Se inserta una moneda |
| CoinInserted | SelectProduct | ProductSelected | Se selecciona un producto |
| CoinInserted | RequestChange | WaitingForCoin | Se solicita devolución |
| ProductSelected | Dispense | ProductDelivered | Se entrega el producto |
| ProductDelivered | * | WaitingForCoin | Vuelve al estado inicial |

### Diagrama de la Máquina Expendedora
![Diagrama de la Máquina Expendedora](img/VendingMachineDiagram.png)

### Estados y sus Significados

1. **WaitingForCoin**: Estado inicial, esperando inserción de moneda
2. **CoinInserted**: Moneda insertada, esperando selección o devolución
3. **ProductSelected**: Producto seleccionado, listo para dispensar
4. **ProductDelivered**: Producto entregado, finalizando transacción

## 3. Validador de Expresiones Regulares (RegexValidator)

El RegexValidator es un autómata configurable que valida cadenas contra patrones específicos definidos por el usuario. A diferencia de los otros dos autómatas, este es más flexible ya que construye su tabla de transiciones dinámicamente basándose en el patrón proporcionado.

### Ejemplos de Validación de Expresiones Regulares

| Entrada | Patrón | Resultado | Explicación |
|---------|---------|-----------|-------------|
| "abc123" | ^[a-z0-9]+$ | ✅ Válido | Contiene solo letras minúsculas y números |
| "ABC123" | ^[a-z0-9]+$ | ❌ Inválido | Contiene letras mayúsculas |
| "123" | ^[0-9]+$ | ✅ Válido | Contiene solo números |
| "test@" | ^[a-z]+@$ | ✅ Válido | Termina con @ |
| "123.456" | ^\d+\.\d+$ | ✅ Válido | Número decimal válido |

## Arquitectura e Implementación

La implementación sigue un patrón de diseño que separa claramente las responsabilidades:

1. **Estados (States)**
   - Enumeraciones que definen los posibles estados del autómata
   - Cada estado representa una situación específica en el flujo de proceso

2. **Entradas (Inputs)**
   - Tipos de entrada que el autómata puede procesar
   - Pueden ser caracteres (para validadores) o eventos (para la máquina expendedora)

3. **Transiciones (Transitions)**
   - Lógica que determina cómo el autómata cambia de estado
   - Implementada como un diccionario de tuplas (Estado actual, Entrada) → Nuevo estado

4. **Servicios (Services)**
   - Capa de abstracción para la interacción con los autómatas
   - Manejo de errores y validaciones adicionales
   - Conversión entre tipos de datos y estados

## Interfaz Base IDfa

Todos los autómatas implementan la interfaz `IDfa<TState, TInput>`, que define el comportamiento básico:

```csharp
public interface IDfa<TState, TInput> where TState : Enum
{
    DfaBase<TState, TInput> BuildDfa();
}
```

Esta interfaz asegura que todos los autómatas:
- Sean tipados fuertemente con sus estados y entradas
- Puedan construir su tabla de transiciones
- Mantengan consistencia en su implementación

## Tecnologías Utilizadas

ASP.NET Core (Minimal API), C# 9.0, HTML/CSS, Javascript
