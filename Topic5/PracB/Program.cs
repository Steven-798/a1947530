using System.Collections.Generic;
using System.Text;

namespace Topic5PracB;

class Program
{
    static void Main(string[] args)
    {
        // ================================================================
        // Task 1: Working with the Built-in LinkedList<T> Class
        // ================================================================
        Console.WriteLine("========== Task 1: LinkedList<int> ==========\n");

        LinkedList<int> numbers = new LinkedList<int>();

        // 插入操作
        numbers.AddLast(10);
        numbers.AddLast(20);
        numbers.AddLast(30);
        numbers.AddFirst(5);
        numbers.AddFirst(1);

        LinkedListNode<int>? node10 = numbers.Find(10);
        if (node10 != null) numbers.AddAfter(node10, 15);

        LinkedListNode<int>? node20 = numbers.Find(20);
        if (node20 != null) numbers.AddBefore(node20, 18);

        numbers.AddLast(40);
        numbers.AddLast(50);
        Console.WriteLine($"插入后（共 {numbers.Count} 个）:");
        PrintLinkedList(numbers);

        // 删除操作
        numbers.RemoveFirst();
        numbers.RemoveLast();
        numbers.Remove(15);
        Console.WriteLine("\n删除后:");
        PrintLinkedList(numbers);

        // 删除第 5 个元素
        if (numbers.Count >= 5)
        {
            LinkedListNode<int>? current = numbers.First;
            for (int i = 0; i < 4; i++) current = current?.Next;
            if (current != null)
            {
                Console.WriteLine($"\n删除第 5 个元素: {current.Value}");
                numbers.Remove(current);
            }
        }
        Console.WriteLine("最终:");
        PrintLinkedList(numbers);

        // ================================================================
        // Task 2: Collections of classes
        // ================================================================
        Console.WriteLine("\n\n========== Task 2: Collections of Person ==========\n");

        // 1. 创建 10 个随机的人（名字和年龄有多样性）
        List<Person> peopleList = new List<Person>
        {
            new Person("Fred", "Smith", 21),
            new Person("Abby", "Johnson", 18),
            new Person("Charlie", "Brown", 25),
            new Person("Diana", "Williams", 30),
            new Person("Eve", "Davis", 17),
            new Person("George", "Miller", 22),
            new Person("Hannah", "Wilson", 19),
            new Person("Ivan", "Moore", 28),
            new Person("Julia", "Taylor", 16),
            new Person("Kevin", "Anderson", 24)
        };

        Console.WriteLine("=== 原始 List<Person> ===");
        foreach (Person p in peopleList)
        {
            Console.WriteLine($"{p.FullName}, Age: {p.Age}");
        }

        // 4. List 转 LinkedList
        LinkedList<Person> peopleLinked = ToLinkedList(peopleList);
        Console.WriteLine($"\n=== ToLinkedList 后（共 {peopleLinked.Count} 人）===");

        // 5. 打印所有人
        string peopleInfo = PrintPeople(peopleLinked);
        Console.WriteLine(peopleInfo);

        // 6. 按年龄排序
        LinkedList<Person> sortedPeople = SortPeople(peopleLinked);
        Console.WriteLine("=== SortPeople 后（按年龄从小到大）===");
        Console.WriteLine(PrintPeople(sortedPeople));

        // 7. 验证排序是否正确
        Console.WriteLine("=== 验证排序 ===");
        double prevAge = 0;
        bool sortedCorrectly = true;
        foreach (Person p in sortedPeople)
        {
            if (p.Age < prevAge)
            {
                sortedCorrectly = false;
                break;
            }
            prevAge = p.Age;
        }
        Console.WriteLine(sortedCorrectly ? "排序正确！" : "排序有误！");
    }

    // 辅助方法：打印 LinkedList<int>
    static void PrintLinkedList(LinkedList<int> list)
    {
        foreach (int num in list) Console.Write(num + " ");
        Console.WriteLine();
    }

    // 4. ToLinkedList：将 List<Person> 转换为 LinkedList<Person>
    public static LinkedList<Person> ToLinkedList(List<Person> people)
    {
        LinkedList<Person> result = new LinkedList<Person>();
        foreach (Person p in people)
        {
            result.AddLast(p);  // 逐个添加到链表末尾
        }
        return result;
    }

    // 5. PrintPeople：返回包含每个人 FullName 和 Age 的字符串
    public static string PrintPeople(LinkedList<Person> people)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Person p in people)
        {
            sb.AppendLine($"{p.FullName}, Age: {p.Age}");
        }
        return sb.ToString();
    }

    // 6. SortPeople：按年龄从小到大排序（选择排序算法）
    public static LinkedList<Person> SortPeople(LinkedList<Person> people)
    {
        // 创建输出链表
        LinkedList<Person> sorted = new LinkedList<Person>();

        // 复制输入链表，避免修改原数据
        LinkedList<Person> remaining = new LinkedList<Person>(people);

        // 循环：每次找到最年轻的人，移到输出链表
        while (remaining.Count > 0)
        {
            // 找到 remaining 中年龄最小的人
            LinkedListNode<Person>? youngestNode = remaining.First;
            LinkedListNode<Person>? current = remaining.First;

            while (current != null)
            {
                if (current.Value.Age < youngestNode!.Value.Age)
                {
                    youngestNode = current;
                }
                current = current.Next;
            }

            // 添加到输出链表，并从 remaining 中移除
            sorted.AddLast(youngestNode!.Value);
            remaining.Remove(youngestNode);
        }

        return sorted;
    }
}

