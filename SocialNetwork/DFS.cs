using System;
using System.Collections.Generic;

public class DFS
{
    public static List<int> Traverse(int start, int[,] adjacencyMatrix, int numberOfPeople)
    {
        bool[] visited = new bool[numberOfPeople];
        List<int> traversalOrder = new List<int>();

        DFSRecursive(start, adjacencyMatrix, numberOfPeople, visited, traversalOrder);
        return traversalOrder;
    }

    private static void DFSRecursive(int node, int[,] adjacencyMatrix, int numberOfPeople, bool[] visited, List<int> result)
    {
        visited[node] = true;
        result.Add(node);

        for (int neighbor = 0; neighbor < numberOfPeople; neighbor++)
        {
            if (adjacencyMatrix[node, neighbor] == 1 && !visited[neighbor])
            {
                DFSRecursive(neighbor, adjacencyMatrix, numberOfPeople, visited, result);
            }
        }
    }

    public static bool HasPath(int start, int target, int[,] adjacencyMatrix, int numberOfPeople)
    {
        bool[] visited = new bool[numberOfPeople];
        return DFSHasPath(start, target, adjacencyMatrix, numberOfPeople, visited);
    }

    private static bool DFSHasPath(int current, int target, int[,] adjacencyMatrix, int numberOfPeople, bool[] visited)
    {
        if (current == target)
            return true;

        visited[current] = true;

        for (int neighbor = 0; neighbor < numberOfPeople; neighbor++)
        {
            if (adjacencyMatrix[current, neighbor] == 1 && !visited[neighbor])
            {
                if (DFSHasPath(neighbor, target, adjacencyMatrix, numberOfPeople, visited))
                    return true;
            }
        }

        return false;
    }
}