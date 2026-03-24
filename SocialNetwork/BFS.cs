using System;
using System.Collections.Generic;

public class BFS
{
    public static List<int> Traverse(int start, int[,] adjacencyMatrix, int numberOfPeople)
    {
        bool[] visited = new bool[numberOfPeople];
        Queue<int> queue = new Queue<int>();
        List<int> traversalOrder = new List<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();
            traversalOrder.Add(currentNode);

            for (int neighbor = 0; neighbor < numberOfPeople; neighbor++)
            {
                if (adjacencyMatrix[currentNode, neighbor] == 1 && !visited[neighbor])
                {
                    visited[neighbor] = true;  
                    queue.Enqueue(neighbor);    
                }
            }
        }

        return traversalOrder;
    }

    public static bool HasPath(int start, int target, int[,] adjacencyMatrix, int numberOfPeople)
    {
        bool[] visited = new bool[numberOfPeople];
        Queue<int> queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == target)
                return true;

            for (int neighbor = 0; neighbor < numberOfPeople; neighbor++)
            {
                if (adjacencyMatrix[current, neighbor] == 1 && !visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    public static int ShortestPathLength(int start, int target, int[,] adjacencyMatrix, int numberOfPeople)
    {
        if (start == target) return 0;

        bool[] visited = new bool[numberOfPeople];
        Queue<int> queue = new Queue<int>();
        int[] distance = new int[numberOfPeople];  

        visited[start] = true;
        queue.Enqueue(start);
        distance[start] = 0;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            for (int neighbor = 0; neighbor < numberOfPeople; neighbor++)
            {
                if (adjacencyMatrix[current, neighbor] == 1 && !visited[neighbor])
                {
                    visited[neighbor] = true;
                    distance[neighbor] = distance[current] + 1;
                    queue.Enqueue(neighbor);

                    if (neighbor == target)
                        return distance[neighbor];
                }
            }
        }

        return -1;
    }
}