# 🔍 DOCUMENTO DEL MÓDULO DE CONSULTAS Y LIBERACIÓN DE ASIENTOS

**Proyecto:** Sistema de Digitalización y Administración de Asientos de Cine  
**Lenguaje:** C# (.NET 10)  
**Entregable:** Día 5 - Desarrollo de Consultas y Liberación de Asientos  

---

## 1. Descripción del Módulo

El Módulo de Consultas y Liberación completa las operaciones de consulta puntual e interacción con el estado de la matriz (`char[,]`). Permite:
1. **Consultar disponibilidad:** Verificar si una posición `[fila, columna]` específica se encuentra Libre (`'L'`) u Ocupada (`'O'`) sin alterar su estado en memoria.
2. **Liberar asiento:** Cambiar el estado de una posición ocupada (`'O'`) de nuevo a libre (`'L'`) para habilitarla a nuevas reservaciones.

---

## 2. Reglas de Negocio y Validaciones

1. **Consulta de Disponibilidad (`ConsultarDisponibilidad`):**
   - Valida el rango de coordenadas ingresado ($0 \le f < 5$ y $0 \le c < 6$).
   - Evalúa el valor `sala[fila, columna]` e imprime en pantalla la disponibilidad de la butaca.

2. **Liberación de Asiento (`LiberarAsiento`):**
   - Si `sala[fila, columna] == 'O'`, cambia el valor a `'L'` y confirma la liberación.
   - Si `sala[fila, columna] == 'L'`, notifica al usuario que el asiento ya se encuentra disponible sin realizar modificaciones innecesarias.

---

## 3. Fragmentos de Código Implementados

### 3.1 Método `LiberarAsiento`
```csharp
private static void LiberarAsiento()
{
    Console.WriteLine("====================================================================");
    Console.WriteLine("                       LIBERACIÓN DE ASIENTOS                       ");
    Console.WriteLine("====================================================================\n");

    MostrarMatriz();

    int fila = LeerEntero("\n Ingrese el número de Fila (0 - 4): ", 0, FILAS - 1);
    int columna = LeerEntero(" Ingrese el número de Columna (0 - 5): ", 0, COLUMNAS - 1);

    if (sala[fila, columna] == OCUPADO)
    {
        sala[fila, columna] = LIBRE;
        Console.WriteLine($"\n ¡ÉXITO! El asiento en Fila {fila}, Columna {columna} ha sido liberado.");
    }
    else
    {
        Console.WriteLine($"\n ⚠️ ADVERTENCIA: El asiento en Fila {fila}, Columna {columna} ya está LIBRE.");
    }
}
```

### 3.2 Método `ConsultarDisponibilidad`
```csharp
private static void ConsultarDisponibilidad()
{
    Console.WriteLine("====================================================================");
    Console.WriteLine("                    CONSULTA DE DISPONIBILIDAD                      ");
    Console.WriteLine("====================================================================\n");

    int fila = LeerEntero(" Ingrese el número de Fila (0 - 4): ", 0, FILAS - 1);
    int columna = LeerEntero(" Ingrese el número de Columna (0 - 5): ", 0, COLUMNAS - 1);

    char estado = sala[fila, columna];
    string textoEstado = (estado == LIBRE) ? "LIBRE (Disponible)" : "OCUPADO (Reservado)";

    Console.WriteLine($"\n 📌 Estado del Asiento [Fila {fila}, Columna {columna}]: {textoEstado}");
}
```

---

## 4. Evidencias de Casos de Prueba

| Caso de Prueba | Módulo | Fila | Columna | Estado Previo | Resultado Obtenido |
| :--- | :--- | :---: | :---: | :---: | :--- |
| **Consulta Asiento Libre** | Consultar | `1` | `2` | `[ L ]` | Muestra: "LIBRE (Disponible)". |
| **Consulta Asiento Ocupado** | Consultar | `0` | `0` | `[ O ]` | Muestra: "OCUPADO (Reservado)". |
| **Liberación Exitosa** | Liberar | `0` | `0` | `[ O ]` | Cambia a `[ L ]` y confirma éxito. |
| **Liberación Redundante** | Liberar | `1` | `2` | `[ L ]` | Muestra advertencia: "ya está LIBRE". |