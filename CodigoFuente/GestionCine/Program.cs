using System;

namespace GestionCine
{
    internal class Program
    {
        private const int FILAS = 5;
        private const int COLUMNAS = 6;
        private const char LIBRE = 'L';
        private const char OCUPADO = 'O';

        private static char[,] sala = new char[FILAS, COLUMNAS];

        static void Main(string[] args)
        {
            InicializarSala();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                MostrarEncabezado();
                MostrarMenu();

                Console.Write(" Seleccione una opción (1-6): ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        MostrarEncabezado();
                        MostrarMatriz();
                        Pausar();
                        break;
                    case "2":
                        Console.Clear();
                        MostrarEncabezado();
                        ReservarAsiento();
                        Pausar();
                        break;
                    case "3":
                        Console.Clear();
                        MostrarEncabezado();
                        LiberarAsiento();
                        Pausar();
                        break;
                    case "4":
                        Console.Clear();
                        MostrarEncabezado();
                        ConsultarDisponibilidad();
                        Pausar();
                        break;
                    case "5":
                        Console.Clear();
                        MostrarEncabezado();
                        MostrarEstadisticas();
                        Pausar();
                        break;
                    case "6":
                        salir = true;
                        Console.WriteLine("\n Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("\n Opción no válida. Intente de nuevo.");
                        Pausar();
                        break;
                }
            }
        }

        private static void InicializarSala()
        {
            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COLUMNAS; j++)
                {
                    sala[i, j] = LIBRE;
                }
            }
        }

        private static void MostrarEncabezado()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("               SISTEMA DE GESTIÓN DE SALA DE CINE                   ");
            Console.WriteLine("====================================================================");
            Console.WriteLine(" [L] = Asiento Libre (Disponible)    [O] = Asiento Ocupado (Reservado)  ");
            Console.WriteLine("====================================================================\n");
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("                         MENÚ PRINCIPAL                             ");
            Console.WriteLine("====================================================================");
            Console.WriteLine("  1. Mostrar matriz de asientos");
            Console.WriteLine("  2. Reservar asiento");
            Console.WriteLine("  3. Liberar asiento");
            Console.WriteLine("  4. Consultar disponibilidad de asiento");
            Console.WriteLine("  5. Ver estadísticas de ocupación (Módulo Día 6)");
            Console.WriteLine("  6. Salir");
            Console.WriteLine("====================================================================");
        }

        public static void MostrarMatriz()
        {
            Console.WriteLine("                      PANTALLA DE PROYECCIÓN                        ");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.Write("       ");
            for (int j = 0; j < COLUMNAS; j++)
            {
                Console.Write($"C{j}     ");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < FILAS; i++)
            {
                Console.Write($" F{i}:  ");
                for (int j = 0; j < COLUMNAS; j++)
                {
                    Console.Write($"[ {sala[i, j]} ]  ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

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
                Console.WriteLine($"\n ¡ÉXITO! El asiento en Fila {fila}, Columna {columna} ha sido reservado correctamente.");
            }
            else
            {
                Console.WriteLine($"\n ❌ ERROR: El asiento en Fila {fila}, Columna {columna} ya se encuentra OCUPADO.");
            }
        }

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
                Console.WriteLine($"\n ⚠️ ADVERTENCIA: El asiento en Fila {fila}, Columna {columna} ya se encuentra LIBRE.");
            }
        }

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

        // Módulo Día 6: Recorre la matriz, cuenta ocupados/disponibles y calcula el % de ocupación.
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

        private static int LeerEntero(string mensaje, int min, int max)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine() ?? "";

                if (int.TryParse(entrada, out valor) && valor >= min && valor <= max)
                {
                    return valor;
                }

                Console.WriteLine($"   ⚠️ Entrada inválida. Debe ingresar un número entero entre {min} y {max}.");
            }
        }

        private static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}