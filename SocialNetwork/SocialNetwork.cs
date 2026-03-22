using System;

class SocialNetwork
{
    private int[,] adjacencyMatrix;
    private int numberOfPeople;

    public SocialNetwork(int size)
    {
        numberOfPeople = size;
        adjacencyMatrix = new int[size, size];
    }

    public int GetSize() => numberOfPeople;
    public int[,] GetMatrix() => adjacencyMatrix;

    public void AddFriendship(int person1, int person2)
    {
        if (person1 < numberOfPeople && person2 < numberOfPeople)
        {
            adjacencyMatrix[person1, person2] = 1;
            adjacencyMatrix[person2, person1] = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ✔ Amistad agregada entre P{person1} y P{person2}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  ✘ Persona no válida.");
            Console.ResetColor();
        }
    }

    public void RemoveFriendship(int person1, int person2)
    {
        if (person1 < numberOfPeople && person2 < numberOfPeople)
        {
            adjacencyMatrix[person1, person2] = 0;
            adjacencyMatrix[person2, person1] = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  ✔ Amistad eliminada entre P{person1} y P{person2}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  ✘ Persona no válida.");
            Console.ResetColor();
        }
    }
}