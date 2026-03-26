using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[5, 5];

        // Datos de prueba
        matrix[0, 1] = matrix[1, 0] = 1;
        matrix[0, 2] = matrix[2, 0] = 1;
        matrix[1, 2] = matrix[2, 1] = 1;
        matrix[1, 3] = matrix[3, 1] = 1;

        int option = 0;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Ver amigos en común");
            Console.WriteLine("2. Mostrar matriz");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            //VALIDACIÓN DE INPUT
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            switch (option)
            {
                case 1:
                    int p1, p2;

                    Console.Write("Ingrese persona 1: ");
                    if (!int.TryParse(Console.ReadLine(), out p1))
                    {
                        Console.WriteLine("Entrada inválida.");
                        break;
                    }

                    Console.Write("Ingrese persona 2: ");
                    if (!int.TryParse(Console.ReadLine(), out p2))
                    {
                        Console.WriteLine("Entrada inválida.");
                        break;
                    }

                    List<int> result = CommonFriends.FindCommonFriends(matrix, p1, p2);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No tienen amigos en común.");
                    }
                    else
                    {
                        Console.WriteLine("Amigos en común:");
                        foreach (var friend in result)
                        {
                            Console.WriteLine(friend);
                        }
                    }
                    break;

                case 2:
                    PrintMatrix(matrix);
                    break;

                case 3:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (option != 3);
    }

    
    static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        Console.WriteLine("\nMatriz de Adyacencia:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}