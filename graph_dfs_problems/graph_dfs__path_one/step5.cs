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
        int n, s, t, p;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        t = input[2];
        p = input[3];


        for (int i = 1; i <= n; i++)
        {
            SkipLine(); // 不要な入力なのでskip
            var adjacencyList = ReadIntsFromConsole().ToList();
            graph.Add(i, adjacencyList);
        }

        // DFS (深さ優先探索) で s-tパスを全探索する。
        var path = new List<int>();
        var visited = new HashSet<int>();
        DfsRecursive(s, t, path, visited);

        // 頂点pを通るパスの内、最短経路のパスを求める
        var shortestPath = allPaths
            .Where(item => item.Contains(p))
            .OrderBy(item => item.Count)
            .FirstOrDefault();

        if (shortestPath != null)
        {
            Output(shortestPath);
        }
        else
        {
            Console.WriteLine("-1");
        }
    }

    // DFS(深さ優先探索)の再起関数
    static void DfsRecursive(int current, int target, List<int> path, HashSet<int> visited)
    {
        path.Add(current);
        visited.Add(current);

        // 目的地に到達したら現在のパスを保存
        if (current == target)
        {
            allPaths.Add(new List<int>(path));// パスを保存
            path.RemoveAt(path.Count - 1); // 戻る
            visited.Remove(current); // 戻るので訪問済みを解除
            return;
        }

        // 隣接頂点を探索
        foreach (var neighbor in graph[current])
        {
            if (visited.Contains(neighbor)) continue;
            DfsRecursive(neighbor, target, path, visited);
        }

        path.RemoveAt(path.Count - 1); // 戻る
        visited.Remove(current); // 戻るので訪問済みを解除
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