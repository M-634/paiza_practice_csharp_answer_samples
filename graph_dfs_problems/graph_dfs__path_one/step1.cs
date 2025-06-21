using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n, s;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];

        // vertex number, adjacencyList
        var graph = new Dictionary<int, List<int>>();

        for (int i = 1; i <= n; i++)
        {
            SkipLine();//不要な入力なのでskip
            var adjacencyList = ReadIntsFromConsole().ToList();
            graph.Add(i, adjacencyList);
        }

        var result = graph[s].Max();
        Output(result);
    }

    static void Output(object value)
    {
        Console.WriteLine(value);
    }

    static void SkipLine()
    {
        Console.ReadLine();
    }

    static int ReadLineToInt()
    {
        return int.Parse(Console.ReadLine());
    }

    static IEnumerable<int> ReadIntsFromConsole()
    {
        return Console.ReadLine().Split(' ').Select(int.Parse);
    }
}