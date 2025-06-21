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

        // vertix number, adjacencyList
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

        //walk
        var visitedList = new List<int>();
        visitedList.Add(s);
        int current = s;

        for (int i = 0; i < k; i++)
        {
            //まだ未到達の頂点を選ぶ
            var next = graph[current].FirstOrDefault(neighbor => !visitedList.Contains(neighbor));
            if (next == 0) break; // デフォルト値「０」は頂点番号に存在しない
            current = next;
            visitedList.Add(current);
        }

        Output(visitedList);
    }

    static void Output<T>(IEnumerable<T> list)
    {
        Console.WriteLine(string.Join(' ', list));
    }

    static IEnumerable<int> ReadIntsFromConsole()
    {
        return Console.ReadLine().Split(' ').Select(int.Parse);
    }
}