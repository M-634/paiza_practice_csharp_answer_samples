using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // vertex number, adjacencyList
    static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    // 出力パス
    static List<int> outPutPath = new List<int>();

    static void Main()
    {
        int n, s, k;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        k = input[2];

        // 完全グラフ作成
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

        // DFS開始
        var trail = new List<int>();
        var useEdges = new HashSet<(int, int)>();
        DfsRecursive(s, trail, useEdges, k);
        Output(outPutPath);
    }


   static void DfsRecursive(int current, List<int> trail, HashSet<(int, int)> useEdges, int k)
   { 
        //既にパスがあるなら早期リターン
        if (outPutPath.Any()) return;
 
        trail.Add(current);
            
        if (k == 0)
        {
            outPutPath = new List<int>(trail);
            return;
        }

        foreach (var neighbor in graph[current])
        {
            //経路チェック:完全無向グラフなので例えば（１，２）（２，１）経路を同じ扱いにする
            var edge = (Math.Min(current, neighbor), Math.Max(current, neighbor));
            if (useEdges.Add(edge))
            {
                DfsRecursive(neighbor, trail, useEdges, k - 1);
                useEdges.Remove(edge);
            }
        }

        trail.RemoveAt(trail.Count - 1);
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