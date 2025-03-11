using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MathLibrary {
    public class MathOperations{
        public int Add(int a, int b){
            return a + b;
        }
        public int Subtract(int a, int b){
            return a - b;
        }
        public double Divide(int a, int b){
            if(b == 0){
                Error_print();
                return double.NaN;
            }
            return (double)a / b;
        } 
        private void Error_print(){
            //Console.WriteLine("1233123123131231");
            try
            {
                if (!File.Exists("log.txt"))
                {
                    File.WriteAllText("log.txt", "==== 日誌開始 ====\n");
                }
                File.AppendAllText("log.txt", $"{DateTime.Now}: {"除法錯誤 b=0"}{Environment.NewLine}");
            }
            catch(Exception ex){
                Console.WriteLine($"File 寫入錯誤: { ex.Message}");
            }
        }
    }
}
