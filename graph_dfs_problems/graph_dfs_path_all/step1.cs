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

        for (int i = 1; i <= n; i++)
        {
            SkipLine(); // 不要な入力なのでskip
            if (i != s)
            {
                SkipLine(); // s以外の頂点は不要な入力なのでskip
                continue;
            }

            var adjacencyList = ReadIntsFromConsole().ToList();
            if (adjacencyList.Any())
            {
                Output(adjacencyList);
            }
            else
            {
                Output("-1"); // sの隣接頂点がない場合は-1を出力
            }
            return;
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

    static IEnumerable<int> ReadIntsFromConsole()
    {
        return Console.ReadLine().Split(' ').Select(int.Parse);
    }
}