using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

class Program
{
    // 写文件方法，T是泛型，什么类都能存
    public static void FileWriter<T>(string path, T obj) where T : class
    {
        string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    // 读文件方法
    public static T FileReader<T>(string path) where T : class
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json)!;
    }

    static void Main(string[] args)
    {
        // ===== 测 List =====
        Console.WriteLine("=== List 10000个玩家 ===");
        
        List<Player> list = new List<Player>();
        for (int i = 0; i < 10000; i++)
        {
            list.Add(new Player("Player" + i));
        }
        
        FileWriter("./list.json", list);
        List<Player> list2 = FileReader<List<Player>>("./list.json");
        Console.WriteLine("读回来了 " + list2.Count + " 个");
        
        GC.Collect();
        Console.WriteLine("HeapSize: " + GC.GetGCMemoryInfo().HeapSizeBytes);
        Console.WriteLine("PeakMemory: " + Process.GetCurrentProcess().PeakWorkingSet64);
        
        // 清掉，给下面LinkedList腾地方
        list.Clear();
        list2.Clear();
        GC.Collect();
        
        // ===== 测 LinkedList =====
        Console.WriteLine("\n=== LinkedList 10000个玩家 ===");
        
        LinkedList<Player> link = new LinkedList<Player>();
        for (int i = 0; i < 10000; i++)
        {
            link.AddLast(new Player("Player" + i));
        }
        
        FileWriter("./link.json", link);
        LinkedList<Player> link2 = FileReader<LinkedList<Player>>("./link.json");
        Console.WriteLine("读回来了 " + link2.Count + " 个");
        
        GC.Collect();
        Console.WriteLine("HeapSize: " + GC.GetGCMemoryInfo().HeapSizeBytes);
        Console.WriteLine("PeakMemory: " + Process.GetCurrentProcess().PeakWorkingSet64);
    }
}
