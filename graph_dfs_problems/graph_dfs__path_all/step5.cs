using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // vertex number, adjacencyList
    static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    // 出力パス
    static List<List<int>> allPaths = new List<List<int>>();

    static void Main()
    {
        int n, s, t, p;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        t = input[2];
        p = input[3];

        // グラフ構築
        for (int i = 1; i <= n; i++)
        {
            SkipLine(); // ラベル行をスキップ
            var adjacencyList = ReadIntsFromConsole().ToList();
            graph.Add(i, adjacencyList);
        }

        // DFS開始
        var walk = new List<int>();
        var visited = new HashSet<int>();
        DfsRecursive(s, walk, visited, t, p);

        // 出力
        Output(allPaths.Count);
        foreach (var path in allPaths)
        {
            Output(path);
        }
    }

    static void DfsRecursive(int current, List<int> walk, HashSet<int> visited, int t, int p)
    {
        walk.Add(current);
        visited.Add(current);

        if (current == t)
        {
            if (walk.Contains(p))
            {
                allPaths.Add(new List<int>(walk));
            }
            walk.RemoveAt(walk.Count - 1);
            visited.Remove(current);
            return;
        }

        foreach (var neighbor in graph[current])
        {
            if (!visited.Contains(neighbor))
            {
                DfsRecursive(neighbor, walk, visited, t, p);
            }
        }

        walk.RemoveAt(walk.Count - 1);
        visited.Remove(current);
    }

    static void Output(object value)
    {
        Console.WriteLine(value);
    }

    static void Output<T>(IEnumerable<T> list)
    {
        Console.WriteLine(string.Join(" ", list));
    }

    static void SkipLine()
    {
        Console.ReadLine();
    }

    static IEnumerable<int> ReadIntsFromConsole()
    {
        return Console.ReadLine().Split().Select(int.Parse);
    }
}
