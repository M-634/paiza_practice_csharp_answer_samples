using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n, s, t;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        t = input[2];

        SkipLine(); // 不要な入力なのでskip

        // 集合S
        var invalidVertices = ReadIntsFromConsole().ToList();

        // 集合Sに頂点s,tが含まれている場合は、到達不可能なので-1を出力
        if (invalidVertices.Contains(s) || invalidVertices.Contains(t))
        {
            Console.WriteLine("-1");
            return;
        }

        // vertex number, adjacencyList
        var graph = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++)
        {
            SkipLine(); // 不要な入力なのでskip
            var adjacencyList = ReadIntsFromConsole().ToList();
            // 集合Sに含まれる頂点は予め除外しておく
            adjacencyList = adjacencyList.Where(v => !invalidVertices.Contains(v)).ToList();
            graph.Add(i, adjacencyList);
        }

        // BFS(幅優先探索)で最短経路探索
        var cameFrom = new Dictionary<int, int>(); // 子供, 親
        var queue = new Queue<int>();
        cameFrom[s] = -1; // 親いないので「-1」
        queue.Enqueue(s);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            // 頂点tに到達したのでパス（実際に通った道）を出力
            if (current == t)
            {
                var path = new Stack<int>();
                int next = t;
                while (next != -1)
                {
                    path.Push(next);
                    next = cameFrom[next];
                }
                Output(path);
                return;
            }

            foreach (var neighbor in graph[current])
            {
                if (cameFrom.ContainsKey(neighbor)) continue;
                cameFrom[neighbor] = current; // BFSはここで予約しておく。
                queue.Enqueue(neighbor);
            }
        }

        // 頂点tに到達できなかった場合
        Console.WriteLine("-1");
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