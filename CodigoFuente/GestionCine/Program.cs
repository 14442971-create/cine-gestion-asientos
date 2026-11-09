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
                        Console.WriteLine("\n [Día 5] Módulo de liberación.");
                        Pausar();
                        break;
                    case "4":
                        Console.WriteLine("\n [Día 5] Módulo de consulta de disponibilidad.");
                        Pausar();
                        break;
                    case "5":
                        Console.WriteLine("\n [Día 6] Módulo de estadísticas de ocupación.");
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
            Console.WriteLine("  2. Reservar asiento (Módulo de Captura)");
            Console.WriteLine("  3. Liberar asiento");
            Console.WriteLine("  4. Consultar disponibilidad de asiento");
            Console.WriteLine("  5. Ver estadísticas de ocupación");
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

        /// <summary>
        /// Módulo de Captura (Día 4): Permite reservar un asiento validando coordenadas y estado.
        /// </summary>
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

        /// <summary>
        /// Captura y valida que la entrada del usuario sea un número entero dentro del rango permitido.
        /// </summary>
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