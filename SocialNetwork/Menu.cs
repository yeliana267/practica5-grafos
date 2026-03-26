using System;

class Menu
{
    // ── SPRITES DEL HEADER ────────────────────────────────
    static string[][] headerSprites = {
        new string[] { " ▄▀▄ ", "▐♀.♀▌", " ▀█▀ ", " ███ ", " █ █ " }, // Ana    - rosa
        new string[] { " ▄▄▄ ", "▐o.o▌", " ▀█▀ ", " ███ ", " █ █ " }, // Bob    - azul
        new string[] { " ♦▄♦ ", "▐^.^▌", " ▀█▀ ", " ███ ", " █ █ " }, // Diana  - morado
    };

    static ConsoleColor[] headerColores = {
        ConsoleColor.Magenta,
        ConsoleColor.Cyan,
        ConsoleColor.DarkMagenta,
    };

    // ── SPRITE PAUSAR ─────────────────────────────────────
    static string[] spriteAdios = {
        " ▄▄▄ ",
        "▐o.o▌",
        " ▀█▀ ",
        " ███\\",
        " █ █ "
    };

    public static void MostrarMenu()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        // ── HEADER CON SPRITES ────────────────────────────
        Console.Write("  ");
        for (int i = 0; i < headerSprites.Length; i++)
        {
            Console.ForegroundColor = headerColores[i];
            Console.Write($"  {headerSprites[i][0]}  ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.Write("  ");
        for (int i = 0; i < headerSprites.Length; i++)
        {
            Console.ForegroundColor = headerColores[i];
            Console.Write($"  {headerSprites[i][1]}  ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.Write("  ");
        for (int i = 0; i < headerSprites.Length; i++)
        {
            Console.ForegroundColor = headerColores[i];
            Console.Write($"  {headerSprites[i][2]}  ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.Write("  ");
        for (int i = 0; i < headerSprites.Length; i++)
        {
            Console.ForegroundColor = headerColores[i];
            Console.Write($"  {headerSprites[i][3]}  ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.Write("  ");
        for (int i = 0; i < headerSprites.Length; i++)
        {
            Console.ForegroundColor = headerColores[i];
            Console.Write($"  {headerSprites[i][4]}  ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.ResetColor();

        // ── CAJA ──────────────────────────────────────────
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  ┌─────────────────────────────────────────┐");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  │        *  RED SOCIAL - GRAFOS  *        │");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  ├─────────────────────────────────────────┤");
        Console.WriteLine("  │                                         │");
        Console.ResetColor();

        EscribirOpcion("1", " >>  Agregar amistad             ", ConsoleColor.Yellow);
        EscribirOpcion("2", " >>  Eliminar amistad            ", ConsoleColor.Yellow);
        EscribirOpcion("3", " >>  Ver amigos en comun         ", ConsoleColor.Yellow);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  │  . . . . . . . . . . . . . . . . . .   │");
        Console.ResetColor();

        EscribirOpcion("4", " >>  Recorrer con DFS            ", ConsoleColor.Magenta);
        EscribirOpcion("5", " >>  Recorrer con BFS            ", ConsoleColor.Magenta);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  │  . . . . . . . . . . . . . . . . . .   │");
        Console.ResetColor();

        EscribirOpcion("6", " >>  Ver matriz de adyacencia    ", ConsoleColor.Cyan);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  │                                         │");
        Console.WriteLine("  ├─────────────────────────────────────────┤");
        Console.ResetColor();

        EscribirOpcion("0", " >>  Salir                       ", ConsoleColor.Red);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  │                                         │");
        Console.WriteLine("  └─────────────────────────────────────────┘");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n  > ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Selecciona una opcion: ");
        Console.ResetColor();
    }

    private static void EscribirOpcion(string num, string texto, ConsoleColor color)
    {
        Console.Write("  │  ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = color;
        Console.Write(num);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("]");
        Console.Write(texto);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("│");
        Console.ResetColor();
    }

    public static void MostrarTitulo(string titulo)
    {
        int ancho = titulo.Length + 6;
        string linea = new string('-', ancho);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n  +{linea}+");
        Console.WriteLine($"  |   {titulo}   |");
        Console.WriteLine($"  +{linea}+");
        Console.ResetColor();
    }

    public static void Pausar()
    {
        Console.WriteLine();
        foreach (var linea in spriteAdios)
        {
            Console.Write("  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(linea);
            Console.ResetColor();
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  ------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("  <--  Presiona ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" para volver...");
        Console.ResetColor();
        Console.ReadLine();
    }
}