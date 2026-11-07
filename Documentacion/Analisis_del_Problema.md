# 📄 DOCUMENTO DE ANÁLISIS DEL PROBLEMA

**Proyecto:** Sistema de Digitalización y Administración de Asientos de Cine  
**Tecnología:** C# (.NET 10)  
**Entregable:** Día 1 - Análisis, Requerimientos y Casos de Uso  

---

## 1. Identificación del Problema

### 1.1 Contexto
En los cines tradicionales, la asignación y venta de boletos mediante registros manuales o deficientes genera problemas recurrentes como la duplicidad en las reservas (*overbooking*), la asignación de asientos inexistentes y la falta de información instantánea sobre el estado de la sala.

### 1.2 Planteamiento del Problema
Se requiere desarrollar un sistema en consola desarrollado en C# (.NET 10) que administre mediante una **matriz bidimensional** la ocupación de una sala de cine de capacidad fija. El sistema debe controlar las reservas, liberaciones, consultas de disponibilidad y el reporte estadístico de ocupación en tiempo real para eliminar errores operacionales.

---

## 2. Identificación de Entradas, Procesos y Salidas (EPS)

| Componente | Descripción | Detalle Técnico en C# |
| :--- | :--- | :--- |
| **Entradas** | Datos solicitados al usuario desde la consola. | • Selección de opción del menú (`int opc`).<br>• Número de fila (`int fila`).<br>• Número de columna/asiento (`int columna`). |
| **Procesos** | Lógica de negocio y transformaciones de datos. | • **Inicialización:** Llenado inicial del arreglo bidimensional `char[,]` con el carácter `'L'` (Libre).<br>• **Validación de Rangos:** Comprobación de índices ($0 \le \text{fila} < N$ y $0 \le \text{columna} < M$).<br>• **Validación de Ocupación:** Verificación del estado del asiento antes de reservar (`'L'`) o liberar (`'O'`).<br>• **Modificación de Estado:** Asignación directa en matriz (`asientos[i, j] = 'O'` o `'L'`).<br>• **Conteo y Recorrido:** Recorrido con bucles `for` anidados para sumar asientos libres/ocupados.<br>• **Cálculo Porcentual:** Aplicación de fórmula: $\text{Porcentaje} = \left( \frac{\text{Ocupados}}{\text{Total}} \right) \times 100.0$. |
| **Salidas** | Información renderizada en pantalla. | • Visualización gráfica en matriz de la sala.<br>• Mensajes de éxito y error de validación.<br>• Reporte numérico de asientos ocupados, disponibles y porcentaje de ocupación. |

---

## 3. Justificación de la Estructura de Datos

Para este sistema se eligió un **arreglo bidimensional de tipo `char` (`char[,]`)**.

1. **Modelado Geométrico Directo:** Una sala de cine posee un diseño de cuadrícula física (filas y columnas). Un arreglo de dos dimensiones representa fielmente esta disposición espacial.
2. **Eficiencia Temporal O(1):** El acceso, reserva y liberación de un asiento a partir de sus coordenadas (i, j) se realiza en tiempo constante O(1), sin necesidad de realizar búsquedas secuenciales.
3. **Eficiencia de Memoria:** Al tener una sala con capacidad fija, el uso de memoria es contiguo y predecible, evitando la sobrecarga de punteros o referencias dinámicas innecesarias.

---

## 4. Alcance y Limitaciones

### 4.1 Alcance
* Administración completa de 1 sala de cine fija.
* Visualización gráfica simplificada en la consola.
* Funcionalidades operativas: Reserva, Liberación, Consulta individual y Estadísticas generales.
* Control estricto de excepciones (prevención de `IndexOutOfRangeException` y `FormatException`).

### 4.2 Limitaciones
* Persistencia en memoria RAM: Los datos no se guardan en base de datos ni archivos externos al cerrar la aplicación.
* Monousuario / Monosala: Diseñado para ser ejecutado localmente en una sola consola interactiva.

---

## 5. Descripción de Requerimientos

### 5.1 Requerimientos Funcionales (RF)
* **RF-01 Mostrar Matriz:** Mostrar la cuadrícula completa indicando con `'L'` los asientos libres y con `'O'` los ocupados.
* **RF-02 Reservar Asiento:** Permitir al usuario seleccionar fila y columna para cambiar el estado de `'L'` a `'O'`.
* **RF-03 Liberar Asiento:** Permitir cambiar el estado de un asiento de `'O'` a `'L'`.
* **RF-04 Consultar Disponibilidad:** Indicar el estado actual (Libre u Ocupado) de una coordenada específica sin alterarlo.
* **RF-05 Contar Ocupados y Disponibles:** Calcular y desplegar el total exacto de asientos ocupados y libres.
* **RF-06 Indicar Porcentaje de Ocupación:** Calcular y mostrar el porcentaje de ocupación global con precisión decimal.

### 5.2 Requerimientos No Funcionales (RNF)
* **RNF-01 Robustez:** El sistema no debe pausarse ni cerrarse ante entradas numéricas o coordenadas fuera de límite.
* **RNF-02 Modularidad:** El código fuente en C# debe estar dividido en métodos con responsabilidades únicas.

---

## 6. Casos de Uso (Especificaciones)

### 📄 UC-01: Reservar Asiento
* **Actor:** Administrador / Cliente.
* **Precondiciones:** Matriz cargada en memoria.
* **Flujo Principal:**
  1. El usuario elige la opción de reservar.
  2. El sistema solicita la fila y la columna.
  3. El usuario ingresa las coordenadas.
  4. El sistema valida que las coordenadas existan dentro de los límites de la matriz.
  5. El sistema verifica que el asiento esté marcado como `'L'`.
  6. El sistema cambia el valor a `'O'` y confirma la reserva.
* **Flujos Alternos:**
  * **Coordenada Inválida:** El sistema informa que la fila o columna está fuera de rango y cancela la operación.
  * **Asiento Ocupado:** El sistema informa que el asiento ya está reservado (`'O'`) y sugiere elegir otro.

### 📄 UC-02: Generar Estadísticas de la Sala
* **Actor:** Administrador.
* **Precondiciones:** Matriz inicializada.
* **Flujo Principal:**
  1. El usuario elige la opción de consultar estadísticas.
  2. El sistema recorre la matriz con dos ciclos `for` anidados.
  3. El sistema incrementa los contadores de asientos libres y ocupados.
  4. El sistema calcula el porcentaje de ocupación.
  5. El sistema imprime en pantalla los 3 valores resultantes.
