using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n, s, k;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        k = input[2];

        // 完全グラフ作成
        var graph = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++)
        {
            var adjacencyList = new List<int>();
            for (int j = 1; j <= n; j++)
            {
                if (i == j) continue;
                adjacencyList.Add(j);
            }
            graph.Add(i, adjacencyList);
        }



    }

    static void Output(object value)
    {
        Console.WriteLine(value);
    }

    static void Output<T>(IEnumerable<T> list)
    {
        Console.WriteLine(string.Join(' ', list));
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