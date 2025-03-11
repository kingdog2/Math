# Math
C#my Math's DLL
# MathLibrary

## 簡介

`MathLibrary` 是一個簡單的數學計算函式庫 (DLL)，提供基本的加法、減法和除法功能，並包含錯誤處理。

## 功能列表

| 方法名稱       | 參數             | 回傳類型     | 功能描述                                      |
| ---------- | -------------- | -------- | ----------------------------------------- |
| `Add`      | `int a, int b` | `int`    | 回傳兩數相加的結果                                 |
| `Subtract` | `int a, int b` | `int`    | 回傳兩數相減的結果                                 |
| `Divide`   | `int a, int b` | `double` | 回傳 `a / b`，b=0 時回傳 `NaN`，並記錄錯誤至 `log.txt` |

## 安裝與使用

### **1. 編譯 MathLibrary DLL**

1. 使用 Visual Studio 開啟專案。
2. 在 `MathLibrary` 專案中建立 `MathOperations.cs`。
3. 新增以下程式碼並編譯為 DLL：

```csharp
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

```

4. 在 `MathLibrary` 專案中 **Build**，生成 `MathLibrary.dll`。

### **2. 使用 MathLibrary DLL**

1. 在 `MathLibraryTest` 專案中新增 `Program.cs`。
2. 引入 `MathLibrary.dll`。
3. 新增以下程式碼：

```csharp
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

```

### **3. 編譯與執行**

在 Visual Studio 中：

1. **Build Solution**。
2. 執行 `MathLibraryTest.exe`(MathLibraryTest\bin\Release目錄下)。

**範例輸出：**

```
請輸入第一個數字: 5
請輸入第二個數字: 3
5 + 3 = 8
5 - 3 = 2
5 / 3 = 1.66666666666667
5 / 0 = 無效 (請查看 log.txt) ------>>>這行不管b是多少皆以0為測試
```

```
請輸入第一個數字: 10
請輸入第二個數字: 0
10 + 0 = 10
10 - 0 = 10
10 / 0 = 無效 (請查看 log.txt) ------>>>這行不管b是多少皆以0為測試
```

## 錯誤處理與日誌

- 除數為 0 時，`Divide` 方法會回傳 `NaN`，並將錯誤記錄到 `log.txt`。
- `log.txt` 會儲存在執行目錄下。
- 若寫入 `log.txt` 失敗，將顯示錯誤訊息。



