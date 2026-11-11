# 📊 DOCUMENTO DEL MÓDULO DE ESTADÍSTICAS DE OCUPACIÓN

**Proyecto:** Sistema de Digitalización y Administración de Asientos de Cine  
**Lenguaje:** C# (.NET 10)  
**Entregable:** Día 6 - Implementación de Estadísticas y Conteo de Asientos  

---

## 1. Descripción del Módulo

El Módulo de Estadísticas realiza un recorrido completo ($O(N \times M)$) de la matriz bidimensional (`char[5, 6]`) para calcular en tiempo real los métricos de ocupación de la sala de cine. 

Permite visualizar de manera consolidada:
- Cantidad total de asientos en la sala.
- Número total de asientos reservados/ocupados (`'O'`).
- Número total de asientos disponibles/libres (`'L'`).
- Porcentaje de ocupación respecto a la capacidad máxima.

---

## 2. Fórmulas y Lógica Algorítmica

1. **Capacidad Total ($T$):**  
   $$T = \text{FILAS} \times \text{COLUMNAS} = 5 \times 6 = 30 \text{ asientos}$$

2. **Conteo de Ocupados ($O$) y Disponibles ($D$):**  
   Recorrido mediante doble ciclo `for`:
   - Si `sala[i, j] == 'O'` $\rightarrow$ `ocupados++`
   - Si `sala[i, j] == 'L'` $\rightarrow$ `disponibles++`

3. **Porcentaje de Ocupación ($P$):**  
   $$P = \left( \frac{\text{ocupados}}{\text{totalAsientos}} \right) \times 100$$

---

## 3. Fragmento de Código Implementado (`MostrarEstadisticas`)

```csharp
private static void MostrarEstadisticas()
{
    Console.WriteLine("====================================================================");
    Console.WriteLine("                     ESTADÍSTICAS DE OCUPACIÓN                      ");
    Console.WriteLine("====================================================================\n");

    int ocupados = 0;
    int disponibles = 0;
    int totalAsientos = FILAS * COLUMNAS;

    for (int i = 0; i < FILAS; i++)
    {
        for (int j = 0; j < COLUMNAS; j++)
        {
            if (sala[i, j] == OCUPADO)
                ocupados++;
            else
                disponibles++;
        }
    }

    double porcentajeOcupacion = ((double)ocupados / totalAsientos) * 100;
    double porcentajeDisponibilidad = ((double)disponibles / totalAsientos) * 100;

    Console.WriteLine($"  Total de Asientos en Sala: {totalAsientos}");
    Console.WriteLine($"  ------------------------------------------------------------------");
    Console.WriteLine($"  🔴 Asientos Ocupados:      {ocupados,-3} ({porcentajeOcupacion,6:F2}%)");
    Console.WriteLine($"  🟢 Asientos Disponibles:   {disponibles,-3} ({porcentajeDisponibilidad,6:F2}%)");
    Console.WriteLine($"  ------------------------------------------------------------------");
}
```

---

## 4. Evidencias de Casos de Prueba

| Estado de la Sala (Asientos Ocupados) | Ocupados Calculados | Disponibles Calculados | Porcentaje Ocupación Esperado | Resultado Obtenido |
| :--- | :---: | :---: | :---: | :--- |
| **Sala Vacía (0 reservados)** | `0` | `30` | `0.00%` | PASÓ |
| **Reserva parcial (6 reservados)** | `6` | `24` | `20.00%` | PASÓ |
| **Reserva media (15 reservados)** | `15` | `15` | `50.00%` | PASÓ |
| **Sala Llena (30 reservados)** | `30` | `0` | `100.00%` | PASÓ |