using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    //問題文ではDFSの説明がされているが、最短経路求める問題なのでBFSの方が適している。
    static void Main()
    {
        int n, s, t;
        var input = ReadIntsFromConsole().ToArray();
        n = input[0];
        s = input[1];
        t = input[2];

        // vertix number, adjacencyList
        var graph = new Dictionary<int, List<int>>();

        for (int i = 1; i <= n; i++)
        {
            SkipLine();//不要な入力なのでskip
            var adjacencyList = ReadIntsFromConsole().ToList();
            graph.Add(i, adjacencyList);
        }

        //BFS(幅優先探索)でpath探索
        var cameFrom = new Dictionary<int, int>();//子供, 親
        var queue = new Queue<int>();

        cameFrom[s] = -1;//親いないので「-1」
        queue.Enqueue(s);

        while(queue.Count > 0)
        { 
            int current = queue.Dequeue();

            //頂点tに到達したのでパス（実際に通った道）を出力
            if(current == t)
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

            foreach(var neighbor in graph[current])
            {
                if(cameFrom.ContainsKey(neighbor)) continue;
                cameFrom[neighbor] = current;//BFSはここで予約しておく。
                queue.Enqueue(neighbor);
            }
        }
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