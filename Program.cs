using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CommandLineReport;

class Program
{


    static void Main(string[] args)
    {
        Console.WriteLine($"^^^^^^^^^{Directory.Exists(@"D:\me\Extentions")}");




        // Menu loop
        Menu menu = new Menu();
        menu.RunMenu();
    }
}
