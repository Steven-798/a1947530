namespace Topic5PracA;

class Program
{
    static void Main(string[] args)
    {
        // ================================================================
        // Task 1: Using Arrays（数组操作）
        // ================================================================
        Console.WriteLine("========== Task 1: Using Arrays ==========\n");

        // 1. 创建字符串数组，填充 10 个名字
        string[] names = { "Alice", "Bob", "Charlotte", "David", "Emma",
                           "Frank", "Grace", "Henry", "Isabella", "Jack" };

        // 2. 遍历数组，打印所有值
        Console.WriteLine("=== 遍历数组，打印所有名字 ===");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();

        // 3. 找出最长和最短的名字
        string longest = names[0];
        string shortest = names[0];
        foreach (string name in names)
        {
            if (name.Length > longest.Length) longest = name;
            if (name.Length < shortest.Length) shortest = name;
        }
        Console.WriteLine("=== 最长和最短的名字 ===");
        Console.WriteLine($"最长: {longest} (长度: {longest.Length})");
        Console.WriteLine($"最短: {shortest} (长度: {shortest.Length})");
        Console.WriteLine();

        // 4. 排序数组
        Console.WriteLine("=== 排序前 ===");
        foreach (string name in names) Console.WriteLine(name);
        Array.Sort(names);  // Array.Sort() 按字母顺序排序
        Console.WriteLine("\n=== 排序后 (Array.Sort) ===");
        foreach (string name in names) Console.WriteLine(name);
        Console.WriteLine();

        // 5. 反转数组
        Console.WriteLine("=== 反转前 ===");
        foreach (string name in names) Console.WriteLine(name);
        Array.Reverse(names);  // Array.Reverse() 反转顺序
        Console.WriteLine("\n=== 反转后 (Array.Reverse) ===");
        foreach (string name in names) Console.WriteLine(name);
        Console.WriteLine();

        // ================================================================
        // Task 2: Using Lists（列表操作）
        // ================================================================
        Console.WriteLine("\n========== Task 2: Using Lists ==========\n");

        // 1. 创建 List<string> 管理学生名字
        // List 用 <> 声明，大小可变，可以动态增删元素
        List<string> students = new List<string>();

        // 使用 Add() 添加名字
        students.Add("Alice");
        students.Add("Bob");
        students.Add("Charlotte");
        students.Add("David");
        students.Add("Emma");

        Console.WriteLine("=== Add() 添加 5 个名字后 ===");
        foreach (string s in students) Console.WriteLine(s);
        Console.WriteLine();

        // 使用 Remove() 删除名字
        students.Remove("Bob");  // 删除 "Bob"
        Console.WriteLine("=== Remove(\"Bob\") 后 ===");
        foreach (string s in students) Console.WriteLine(s);
        Console.WriteLine();

        // 使用 Insert() 在指定位置插入名字
        students.Insert(1, "Barry");  // 在索引 1 的位置插入 "Barry"
        Console.WriteLine("=== Insert(1, \"Barry\") 后 ===");
        foreach (string s in students) Console.WriteLine(s);
        Console.WriteLine();

        // 使用 AddRange() 批量添加多个名字
        string[] moreNames = { "Frank", "Grace", "Henry", "Isabella", "Jack", "Kate" };
        students.AddRange(moreNames);  // 把数组里的所有元素添加到 List
        Console.WriteLine("=== AddRange() 批量添加后 (共 " + students.Count + " 个) ===");
        foreach (string s in students) Console.WriteLine(s);
        Console.WriteLine();

        // 2. 搜索特定名字，返回其索引
        string searchName = "Grace";
        int index = students.IndexOf(searchName);  // IndexOf() 返回元素的索引，找不到返回 -1
        Console.WriteLine($"=== 搜索 \"{searchName}\" ===");
        if (index != -1)
            Console.WriteLine($"找到 \"{searchName}\"，索引位置: {index}");
        else
            Console.WriteLine($"未找到 \"{searchName}\"");
        Console.WriteLine();

        // 3. 搜索部分名字（用 string.Contains()），返回所有匹配
        string partialName = "ar";
        Console.WriteLine($"=== 搜索包含 \"{partialName}\" 的名字 ===");
        foreach (string s in students)
        {
            if (s.Contains(partialName))  // Contains() 判断字符串是否包含子串
            {
                Console.WriteLine($"- {s} (索引: {students.IndexOf(s)})");
            }
        }
        Console.WriteLine();

        // 4. 计算所有名字长度之和
        int totalLength = 0;
        foreach (string s in students)
        {
            totalLength += s.Length;
        }
        Console.WriteLine("=== 所有名字长度之和 ===");
        Console.WriteLine($"总长度: {totalLength}");
        Console.WriteLine();

        // 5. 把 Task 1 的数组转换成 List，添加到 Task 2 的 List
        // names 数组在 Task 1 中被排序和反转了，这里重新创建一个原始数组
        string[] task1Array = { "Alice", "Bob", "Charlotte", "David", "Emma",
                                 "Frank", "Grace", "Henry", "Isabella", "Jack" };

        // 数组转 List：用 new List<string>(数组) 或 数组.ToList()
        List<string> convertedList = new List<string>(task1Array);
        Console.WriteLine("=== 数组转 List 后 ===");
        foreach (string s in convertedList) Console.WriteLine(s);
        Console.WriteLine($"\n转换后的 List 元素个数: {convertedList.Count}");

        // 把转换后的 List 添加到 students 中
        students.AddRange(convertedList);
        Console.WriteLine($"\n添加后 students 总元素个数: {students.Count}");
    }
}
