using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using System.IO;
namespace MathLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("目前專案目錄: " + Directory.GetCurrentDirectory());
            
            MathOperations math = new MathOperations();

            Console.WriteLine($"5 + 3 = {math.Add(5, 3)}");
            Console.WriteLine($"10 - 4 = {math.Subtract(10, 4)}");

            double result = math.Divide(10, 2);
            Console.WriteLine($"10 / 2 = {result}");

            result = math.Divide(10, 0);
            Console.WriteLine($"10 / 0 = {result} (查看 log.txt in {Directory.GetCurrentDirectory()})");

            Console.ReadLine();
        }
    }
}
