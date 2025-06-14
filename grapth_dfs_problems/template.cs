using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        
    }

    static int ConsoleReadLineToInt()
    {
        return int.Parse(ConsoleReadLine());
    }

    static int[] ConsoleReadLineToIntArray()
    {
        return ConsoleReadLine().Sprit(' ').Select(int.Parse).ToArray();
    }
}