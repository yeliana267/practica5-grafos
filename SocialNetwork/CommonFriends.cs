using System;
using System.Collections.Generic;

public class CommonFriends
{
    public static List<int> FindCommonFriends(int[,] matrix, int person1, int person2)
    {
        List<int> common = new List<int>();

        int size = matrix.GetLength(0);

        //VALIDACIÓN
        if (person1 < 0 || person2 < 0 || person1 >= size || person2 >= size)
        {
            Console.WriteLine("Error: Persona fuera de rango.");
            return common;
        }

        if (person1 == person2)
        {
            Console.WriteLine("Error: Debes ingresar dos personas diferentes.");
            return common;
        }

        //RECORRIDO CON FOR
        for (int i = 0; i < size; i++)
        {
            if (matrix[person1, i] == 1 && matrix[person2, i] == 1)
            {
                common.Add(i);
            }
        }

        return common;
    }
}