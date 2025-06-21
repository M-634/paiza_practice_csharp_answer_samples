using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

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