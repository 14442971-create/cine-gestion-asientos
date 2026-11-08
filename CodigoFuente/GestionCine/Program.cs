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
                        Console.WriteLine("\n [Día 4] Módulo de captura (Reserva).");
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
            Console.WriteLine("  2. Reservar asiento");
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

        private static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}