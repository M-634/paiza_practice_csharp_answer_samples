using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // vertex number, adjacencyList 
    static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    static List<List<int>> allPaths = new List<List<int>>();

    static void Main()
    {
        int n, s, k;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        k = input[2];

        for (int i = 1; i <= n; i++)
        {
            SkipLine(); // 不要な入力なのでskip
            var adjacencyList = ReadIntsFromConsole().ToList();
            graph.Add(i, adjacencyList);
        }

        // DFS (深さ優先探索) で sからｋ回移動できるパスを全探索する。
        var walk = new List<int>();
        DfsRecursive(s, walk, k);

        //出力
        Output(allPaths.Count());
        foreach (var path in allPaths)
        {
            Output(path);
        }
    }


     // DFS(深さ優先探索)の再起関数
    static void DfsRecursive(int current, List<int> walk, int k)
    {
        walk.Add(current);

        if (k == 0)
        {
            allPaths.Add(new List<int>(walk));
            walk.RemoveAt(walk.Count - 1); // 戻る
            return;
        }

        // 隣接頂点を探索
        foreach (var neighbor in graph[current])
        {
            DfsRecursive(neighbor, walk, k-1);
        }

        walk.RemoveAt(walk.Count - 1); // 戻る
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

    static IEnumerable<int> ReadIntsFromConsole()
    {
        return Console.ReadLine().Split(' ').Select(int.Parse);
    }
}