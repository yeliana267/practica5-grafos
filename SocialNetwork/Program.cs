using System;
using System.Collections.Generic;

class Program
{
    static string[] nombres = { "Ana", "Bob", "Carlos", "Diana", "Elena" };

    static string[][] sprites = {
        new string[] { " ▄▀▄ ", "▐♀.♀▌", " ▀█▀ ", " ███ ", " █ █ " }, // Ana    - rosa
        new string[] { " ▄▄▄ ", "▐o.o▌", " ▀█▀ ", " ███ ", " █ █ " }, // Bob    - azul
        new string[] { " ███ ", "▐-.-▌", " ▀█▀ ", " ███ ", " █ █ " }, // Carlos - verde
        new string[] { " ♦▄♦ ", "▐^.^▌", " ▀█▀ ", " ███ ", " █ █ " }, // Diana  - morado
        new string[] { " ~▄~ ", "▐*.*▌", " ▀█▀ ", " ███ ", " █ █ " }, // Elena  - amarillo
    };

    static ConsoleColor[] colores = {
        ConsoleColor.Magenta,     // Ana
        ConsoleColor.Cyan,        // Bob
        ConsoleColor.Green,       // Carlos
        ConsoleColor.DarkMagenta, // Diana
        ConsoleColor.Yellow       // Elena
    };

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        SocialNetwork network = new SocialNetwork(5);

        network.AddFriendship(0, 1); // Ana   - Bob
        network.AddFriendship(0, 2); // Ana   - Carlos
        network.AddFriendship(1, 2); // Bob   - Carlos
        network.AddFriendship(1, 3); // Bob   - Diana
        network.AddFriendship(3, 4); // Diana - Elena

        int option = -1;

        do
        {
            Menu.MostrarMenu();

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("\n  Entrada invalida.");
                Menu.Pausar();
                continue;
            }

            switch (option)
            {
                case 1:
                    Menu.MostrarTitulo("Agregar Amistad");
                    int[] add = LeerDosPersonas(network.GetSize());
                    if (add != null)
                    {
                        MostrarDuo(add[0], add[1], "+");
                        network.AddFriendship(add[0], add[1]);
                    }
                    Menu.Pausar();
                    break;

                case 2:
                    Menu.MostrarTitulo("Eliminar Amistad");
                    int[] rem = LeerDosPersonas(network.GetSize());
                    if (rem != null)
                    {
                        MostrarDuo(rem[0], rem[1], "X");
                        network.RemoveFriendship(rem[0], rem[1]);
                    }
                    Menu.Pausar();
                    break;

                case 3:
                    Menu.MostrarTitulo("Amigos en Comun");
                    int[] cf = LeerDosPersonas(network.GetSize());
                    if (cf != null)
                    {
                        List<int> comunes = CommonFriends.FindCommonFriends(network.GetMatrix(), cf[0], cf[1]);
                        MostrarDuo(cf[0], cf[1], "?");
                        if (comunes.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n  {Nombre(cf[0])} y {Nombre(cf[1])} no tienen amigos en comun.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\n  Amigos en comun entre {Nombre(cf[0])} y {Nombre(cf[1])}:\n");
                            Console.ResetColor();
                            foreach (var f in comunes)
                                MostrarPersonaje(f, "  <-- amigo en comun");
                        }
                    }
                    Menu.Pausar();
                    break;

                case 4:
                    Menu.MostrarTitulo("Recorrido DFS");
                    int dfsStart = LeerPersona("  Nodo de inicio", network.GetSize());
                    if (dfsStart >= 0)
                    {
                        List<int> dfsResult = DFS.Traverse(dfsStart, network.GetMatrix(), network.GetSize());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n  DFS — orden de visita:\n");
                        Console.ResetColor();
                        MostrarCadena(dfsResult);
                    }
                    Menu.Pausar();
                    break;

                case 5:
                    Menu.MostrarTitulo("Recorrido BFS");
                    int bfsStart = LeerPersona("  Nodo de inicio", network.GetSize());
                    if (bfsStart >= 0)
                    {
                        List<int> bfsResult = BFS.Traverse(bfsStart, network.GetMatrix(), network.GetSize());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n  BFS — orden de visita:\n");
                        Console.ResetColor();
                        MostrarCadena(bfsResult);
                    }
                    Menu.Pausar();
                    break;

                case 6:
                    Menu.MostrarTitulo("Matriz de Adyacencia");
                    PrintMatrix(network.GetMatrix(), network.GetSize());
                    Menu.Pausar();
                    break;

                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n  Hasta luego!\n");
                    Console.ResetColor();
                    break;

                default:
                    Console.WriteLine("\n  Opcion no valida.");
                    Menu.Pausar();
                    break;
            }

        } while (option != 0);
    }

    // ── SPRITES ───────────────────────────────────────────
    static void MostrarPersonaje(int index, string etiqueta)
    {
        Console.WriteLine();
        foreach (var linea in sprites[index])
        {
            Console.Write("    ");
            Console.ForegroundColor = colores[index];
            Console.WriteLine(linea);
            Console.ResetColor();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"    {nombres[index],-10}{etiqueta}");
        Console.ResetColor();
    }

    static void MostrarDuo(int p1, int p2, string icono)
    {
        Console.WriteLine();
        for (int l = 0; l < sprites[p1].Length; l++)
        {
            Console.Write("  ");
            Console.ForegroundColor = colores[p1];
            Console.Write(sprites[p1][l]);
            Console.ResetColor();
            Console.Write(l == 2 ? $"  [{icono}]  " : "        ");
            Console.ForegroundColor = colores[p2];
            Console.WriteLine(sprites[p2][l]);
            Console.ResetColor();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"  {nombres[p1],-16}{nombres[p2]}");
        Console.ResetColor();
    }

    static void MostrarCadena(List<int> lista)
    {
        for (int l = 0; l < sprites[0].Length; l++)
        {
            Console.Write("  ");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.ForegroundColor = colores[lista[i]];
                Console.Write(sprites[lista[i]][l]);
                Console.ResetColor();
                if (i < lista.Count - 1)
                    Console.Write(l == 2 ? "-" : " ");
            }
            Console.WriteLine();
        }
        Console.Write("  ");
        for (int i = 0; i < lista.Count; i++)
        {
            Console.ForegroundColor = colores[lista[i]];
            Console.Write($"{nombres[lista[i]],-8}");
            Console.ResetColor();
        }
        Console.WriteLine();
    }

    // ── HELPERS ───────────────────────────────────────────
    static string Nombre(int index) => $"P{index} ({nombres[index]})";

    static int LeerPersona(string mensaje, int size)
    {
        Console.WriteLine();
        for (int i = 0; i < size; i++)
        {
            Console.Write("  ");
            Console.ForegroundColor = colores[i];
            Console.Write(sprites[i][1]); // solo la fila de la cara
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" [{i}] {nombres[i]}");
            Console.ResetColor();
        }
        Console.Write($"\n{mensaje} (0-{size - 1}): ");
        if (!int.TryParse(Console.ReadLine(), out int p) || p < 0 || p >= size)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  X Entrada invalida.");
            Console.ResetColor();
            return -1;
        }
        return p;
    }

    static int[] LeerDosPersonas(int size)
    {
        int p1 = LeerPersona("  Persona 1", size);
        if (p1 < 0) return null;
        int p2 = LeerPersona("  Persona 2", size);
        if (p2 < 0) return null;
        return new int[] { p1, p2 };
    }

    static void PrintMatrix(int[,] matrix, int size)
    {
        Console.WriteLine();
        Console.Write("               ");
        for (int i = 0; i < size; i++)
        {
            Console.ForegroundColor = colores[i];
            Console.Write($"{nombres[i],9}");
            Console.ResetColor();
        }
        Console.WriteLine();

        for (int i = 0; i < size; i++)
        {
            Console.ForegroundColor = colores[i];
            Console.Write($"  {sprites[i][1]} "); 
            Console.Write($"{nombres[i],5} ");
            Console.ResetColor();
            for (int j = 0; j < size; j++)
            {
                Console.ForegroundColor = matrix[i, j] == 1 ? ConsoleColor.Green : ConsoleColor.DarkGray;
                Console.Write($"{matrix[i, j],9}");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}