# 📥 DOCUMENTO DEL MÓDULO DE CAPTURA DE DATOS

**Proyecto:** Sistema de Digitalización y Administración de Asientos de Cine  
**Lenguaje:** C# (.NET 10)  
**Entregable:** Día 4 - Desarrollo del Módulo de Captura (Reserva de Asientos)  

---

## 1. Descripción del Módulo

El Módulo de Captura es responsable de gestionar el proceso de **reserva de asientos** dentro del matriz bidimensional (`char[,]`). Se encarga de solicitar al usuario las coordenadas del asiento (fila y columna), aplicar validaciones de rango y estado, y actualizar la estructura de datos en memoria.

---

## 2. Reglas de Negocio y Validaciones Aplicadas

1. **Validación del Tipo de Dato:** La entrada del usuario se procesa utilizando `int.TryParse` para evitar excepciones por conversión de texto a entero.
2. **Validación de Rangos (Límites de la Matriz):** 
   - Las filas deben ser valores dentro del rango $[0, 4]$.
   - Las columnas deben ser valores dentro del rango $[0, 5]$.
3. **Validación de Estado del Asiento:**
   - Si `sala[fila, columna] == 'L'`, el asiento se modifica a `'O'` y se confirma la reserva.
   - Si `sala[fila, columna] == 'O'`, se deniega la reserva y se emite una advertencia de asiento no disponible.

---

## 3. Fragmento de Código Implementado (`ReservarAsiento`)

```csharp
private static void ReservarAsiento()
{
    Console.WriteLine("====================================================================");
    Console.WriteLine("                       RESERVA DE ASIENTOS                          ");
    Console.WriteLine("====================================================================\n");

    MostrarMatriz();

    int fila = LeerEntero("\n Ingrese el número de Fila (0 - 4): ", 0, FILAS - 1);
    int columna = LeerEntero(" Ingrese el número de Columna (0 - 5): ", 0, COLUMNAS - 1);

    if (sala[fila, columna] == LIBRE)
    {
        sala[fila, columna] = OCUPADO;
        Console.WriteLine($"\n ¡ÉXITO! El asiento en Fila {fila}, Columna {columna} ha sido reservado.");
    }
    else
    {
        Console.WriteLine($"\n ❌ ERROR: El asiento en Fila {fila}, Columna {columna} ya está ocupado.");
    }
}
```

---

## 4. Evidencias de Casos de Prueba

| Caso de Prueba | Fila Ingresada | Columna Ingresada | Estado Previo | Resultado Esperado | Resultado Obtenido |
| :--- | :---: | :---: | :---: | :--- | :--- |
| **Reserva Exitosa** | `2` | `3` | `[ L ]` | Cambia a `[ O ]` y muestra éxito. | PASÓ |
| **Asiento Ocupado** | `2` | `3` | `[ O ]` | Rechaza reserva con mensaje de error. | PASÓ |
| **Fila fuera de rango** | `7` | `1` | N/A | Solicita reingreso dentro de $[0, 4]$. | PASÓ |
| **Dato no numérico** | `abc` | `2` | N/A | Rechaza entrada y exige número válido. | PASÓ |