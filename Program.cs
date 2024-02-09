using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CommandLineReport;

class Program
{
    static void Main(string[] args)
    {
        // Menu loop
        Menu menu = new Menu();
        while (true)
        {
            menu.RunMenu();
            
        }
    }
}
