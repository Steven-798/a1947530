// 引入全球化命名空间，用于指定文化信息（修复 CA1305）
using System.Globalization;

// 修复 CA1050：把类放在命名空间里
namespace PracA;

// 修复 CA1515：应用程序中的类通常不需要 public，用 internal 即可
internal sealed class BrokenProgram
{
    static void Main(string[] args)
    {
        // 原始字符串字面量：用三个双引号包裹多行文本，C# 11+ 支持
        string input = """
            23
            +
            77
            *
            3
            +
            457
            *
            2
            """;

        // total 保存最终计算结果
        int total = 0;

        // items 存所有数字，symbols 存所有运算符
        List<int> items = [];
        List<char> symbols = [];

        // 提前 Split，避免循环中重复调用
        // 偶数索引(0,2,4,6,8)是数字，奇数索引(1,3,5,7)是符号
        string[] lines = input.Split("\n");

        for (int i = 0; i < lines.Length; i += 2)
        {
            // 修复 CA1305：指定 InvariantCulture，避免不同地区的数字格式差异
            items.Add(int.Parse(lines[i], CultureInfo.InvariantCulture));

            // 每个数字后面跟着一个符号（除了最后一个数字）
            if (i + 1 < lines.Length)
            {
                symbols.Add(lines[i + 1][0]);
            }
        }

        // 第一个数字是起始值
        total = items[0];

        // 从第二个数字开始，每个数字对应一个符号进行运算
        for (int i = 0; i < symbols.Count; i++)
        {
            char op = symbols[i];       // 当前运算符
            int value = items[i + 1];   // 当前要运算的数字

            if (op == '+')
            {
                // 加法
                total += value;
            }
            else if (op == '*')
            {
                // 乘法
                total *= value;
            }
        }

        // 输出结果
        // CA1303 警告：硬编码字符串应使用资源文件。
        // 对于本作业的简单控制台程序，这属于过度设计，故保留原样。
        Console.WriteLine("Total was " + total);
        Console.WriteLine("Expected total was 1514");
        Console.WriteLine($"Answer was: {(total == 1514 ? "Your answer was RIGHT!" : "Your answer was WRONG! Go back and fix it.")}");
    }
}
