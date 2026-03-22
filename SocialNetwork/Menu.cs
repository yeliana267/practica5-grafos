using System;

class Menu
{
    public static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n  ╔══════════════════════════════╗");
        Console.WriteLine("  ║   RED SOCIAL — GRAFOS       ║");
        Console.WriteLine("  ╚══════════════════════════════╝");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n  [1] "); Console.ResetColor();
        Console.WriteLine("Agregar amistad");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("  [2] "); Console.ResetColor();
        Console.WriteLine("Eliminar amistad");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("  [3] "); Console.ResetColor();
        Console.WriteLine("Ver amigos en común");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("  [4] "); Console.ResetColor();
        Console.WriteLine("Recorrer con DFS");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("  [5] "); Console.ResetColor();
        Console.WriteLine("Recorrer con BFS");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("  [6] "); Console.ResetColor();
        Console.WriteLine("Ver matriz de adyacencia");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("  [0] "); Console.ResetColor();
        Console.WriteLine("Salir");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n  ──────────────────────────────");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  ► ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Selecciona una opción: ");
        Console.ResetColor();
    }

    public static void MostrarTitulo(string titulo)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n  ╔══ {titulo} ══╗");
        Console.ResetColor();
    }

    public static void Pausar()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n  Presiona Enter para volver...");
        Console.ResetColor();
        Console.ReadLine();
    }
}