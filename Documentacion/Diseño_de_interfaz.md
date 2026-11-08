# 🎨 DOCUMENTO DE DISEÑO DE INTERFAZ DE USUARIO

**Proyecto:** Sistema de Digitalización y Administración de Asientos de Cine  
**Lenguaje:** C# (.NET 10) - Aplicación de Consola  
**Entregable:** Día 3 - Diseño de Interfaz y Maquetación Visual  

---

## 1. Esquema General de la Interfaz (Consola)

La interfaz de usuario está diseñada en consola de texto estructurada con encuadre de líneas en caracteres ASCII para garantizar claridad visual y facilidad de uso.

```text
====================================================================
               SISTEMA DE GESTIÓN DE SALA DE CINE
====================================================================
 [L] = Asiento Libre (Disponible)    [O] = Asiento Ocupado (Reservado)
====================================================================
```

---

## 2. Convención de Símbolos y Leyenda

| Elemento | Simbología | Significado Visual |
| :--- | :---: | :--- |
| Asiento Libre | `[ L ]` | Representa una butaca disponible para venta/reserva. |
| Asiento Ocupado | `[ O ]` | Representa una butaca ya vendida u ocupada. |
| Encabezado Columnas | `C0  C1  C2 ...` | Indicador numérico de columna (0 a 5). |
| Encabezado Filas | `F0:`, `F1:`, ... | Indicador numérico de fila (0 a 4). |

---

## 3. Maquetación Visual de Pantallas (Wireframes ASCII)

### 3.1 Vista de Matriz de Asientos (Mapa de la Sala)

```text
====================================================================
                      PANTALLA DE PROYECCIÓN
====================================================================

        C0     C1     C2     C3     C4     C5
 F0:  [ L ]  [ L ]  [ L ]  [ L ]  [ L ]  [ L ]
 F1:  [ L ]  [ L ]  [ O ]  [ O ]  [ L ]  [ L ]
 F2:  [ L ]  [ L ]  [ L ]  [ L ]  [ L ]  [ L ]
 F3:  [ O ]  [ O ]  [ L ]  [ L ]  [ L ]  [ L ]
 F4:  [ L ]  [ L ]  [ L ]  [ L ]  [ L ]  [ L ]

====================================================================
```

### 3.2 Menú Principal de Navegación

```text
====================================================================
                         MENÚ PRINCIPAL
====================================================================
  1. Mostrar matriz de asientos
  2. Reservar asiento
  3. Liberar asiento
  4. Consultar disponibilidad de asiento
  5. Ver estadísticas de ocupación
  6. Salir
====================================================================
 Seleccione una opción (1-6): _
```

### 3.3 Plantilla de Formulario de Captura de Datos

```text
--------------------------------------------------------------------
  >>> MÓDULO DE REQUERIMIENTO
--------------------------------------------------------------------
 Ingrese el número de Fila (0 - 4): _
 Ingrese el número de Columna (0 - 5): _
--------------------------------------------------------------------
 [MENSAJE DE RETROALIMENTACIÓN / CONFIRMACIÓN O ERROR]
--------------------------------------------------------------------
```

---

## 4. Flujo de Navegación del Usuario

1. **Pantalla de Bienvenida:** Muestra encabezado del sistema e inicializa la matriz.
2. **Despliegue de Menú:** Ofrece las 6 opciones del sistema de forma limpia y recurrente.
3. **Solicitud de Datos:** Pide coordenadas `[Fila, Columna]` según la acción seleccionada.
4. **Mensaje de Retroalimentación:** Informa el resultado de la acción (Éxito, Error de rango o Conflicto de estado).
5. **Pausa / Retorno:** Espera confirmación del usuario para presionar una tecla y regresar al Menú Principal.