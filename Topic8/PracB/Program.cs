using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

class Program
{
    public static void FileWriter<T>(string path, T objectToWrite) where T : class
    {
        string json = JsonSerializer.Serialize(objectToWrite, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public static T FileReader<T>(string path) where T : class
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json)!;
    }

    static void Main()
    {
        // ===== List 测试 =====
        Console.WriteLine("=== List<Player> 10000个 ===");
        List<Player> list = new List<Player>();
        for (int i = 0; i < 10_000; i++)
        {
            list.Add(new Player($"Player{i}"));
        }
        FileWriter("./list_10000.json", list);
        List<Player> loadedList = FileReader<List<Player>>("./list_10000.json");

        GC.Collect();
        long listHeap = GC.GetGCMemoryInfo().HeapSizeBytes;
        long listPeak = Process.GetCurrentProcess().PeakWorkingSet64;
        Console.WriteLine($"HeapSizeBytes: {listHeap}");
        Console.WriteLine($"PeakWorkingSet64: {listPeak}");

        // 清空，释放内存
        list.Clear();
        loadedList.Clear();
        GC.Collect();

        // ===== LinkedList 测试 =====
        Console.WriteLine("\n=== LinkedList<Player> 10000个 ===");
        LinkedList<Player> linked = new LinkedList<Player>();
        for (int i = 0; i < 10_000; i++)
        {
            linked.AddLast(new Player($"Player{i}"));
        }
        FileWriter("./linked_10000.json", linked);
        LinkedList<Player> loadedLinked = FileReader<LinkedList<Player>>("./linked_10000.json");

        GC.Collect();
        long linkedHeap = GC.GetGCMemoryInfo().HeapSizeBytes;
        long linkedPeak = Process.GetCurrentProcess().PeakWorkingSet64;
        Console.WriteLine($"HeapSizeBytes: {linkedHeap}");
        Console.WriteLine($"PeakWorkingSet64: {linkedPeak}");
    }
}
