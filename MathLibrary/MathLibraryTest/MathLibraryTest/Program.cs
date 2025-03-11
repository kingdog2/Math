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
            Console.Write("請輸入第一個數字(a): ");
            string input1 = Console.ReadLine();
            Console.Write("請輸入第二個數字(b): ");
            string input2 = Console.ReadLine();
            if (int.TryParse(input1, out int num1) && int.TryParse(input2, out int num2))
            {
                MathOperations math = new MathOperations();

                Console.WriteLine($"{num1} + {num2} = {math.Add(num1, num2)}");
                Console.WriteLine($"{num1} - {num2} = {math.Subtract(num1, num2)}");

                double result = math.Divide(num1, num2);
                Console.WriteLine($"{num1} / {num2} = {result}");

                result = math.Divide(num1, 0);
                Console.WriteLine($"{num1} / 0 = {result} (查看 log.txt in {Directory.GetCurrentDirectory()})");
                
            } else {
                Console.WriteLine("輸入無效，請輸入有效的數字(Int)。"); 
            }
            Console.WriteLine("結束!!!!!!!");
            Console.ReadLine();
        }
    }
}
