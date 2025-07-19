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
        int n, s, t;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        t = input[2];

        // グラフ作成
        for (int i = 1; i <= n; i++)
        {
            SkipLine();//不要な入力をスキップ
            var adjacencyList = ReadIntsFromConsole().ToList();
            graph.Add(i, adjacencyList);
        }

        // DFS開始
        var trail = new List<int>();
        var useEdges = new HashSet<(int, int)>();
        DfsRecursive(s, s, trail, useEdges, t);
        Output(outPutPath);
    }


    static void DfsRecursive(int s, int current, List<int> trail, HashSet<(int, int)> useEdges, int t)
    {
        trail.Add(current);

        if (current == t)
        {
            //途中で頂点s, tが含んでいる場合は無効
            bool isInvaild = trail.Skip(1).SkipLast(1).Any(v => v == s || v == t);

            //最長トレイル更新
            if (!isInvaild && outPutPath.Count < trail.Count)
            {
                outPutPath = new List<int>(trail);
            }

            trail.RemoveAt(trail.Count - 1);
            return;
        }

        foreach (var neighbor in graph[current])
        {
            //経路チェック:完全無向グラフなので例えば（１，２）（２，１）経路を同じ扱いにする
            var edge = (Math.Min(current, neighbor), Math.Max(current, neighbor));
            if (useEdges.Add(edge))
            {
                DfsRecursive(s, neighbor, trail, useEdges, t);
                useEdges.Remove(edge);
            }
        }

        trail.RemoveAt(trail.Count - 1);
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