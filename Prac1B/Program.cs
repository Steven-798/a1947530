using System;
using System.Collections.Generic;

namespace Prac1B
{
    class TodoApp
    {
        private static List<string> todoItems = new List<string>();
        private static Dictionary<string, List<int>> tagsDict = new Dictionary<string, List<int>>();

        static void Main(string[] args)
        {
            Console.WriteLine("==== Todo Manager ====");
            Console.WriteLine("Commands: add [item], show, remove [index], clear, tag [index] [tagname], get-tagged [tagname]");
            Console.WriteLine("Type 'exit' to quit\n");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: empty input!");
                    continue;
                }
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0].ToLower();

                switch (command)
                {
                    case "exit":
                        Console.WriteLine("Bye!");
                        return;

                    case "add":
                        HandleAdd(parts);
                        break;

                    case "show":
                        HandleShow();
                        break;

                    case "remove":
                        HandleRemove(parts);
                        break;

                    case "clear":
                        HandleClear();
                        break;

                    case "tag":
                        HandleTag(parts);
                        break;
                    case "get-tagged":
                        HandleGetTagged(parts);
                        break;

                    default:
                        Console.WriteLine($"Error: unknown command '{command}'");
                        break;
                }
            }
        }

        private static void HandleAdd(string[] parts)
        {
            if (parts.Length < 2)
            {
                Console.WriteLine("Error: Usage: add [item text]");
                return;
            }
            string item = string.Join(" ", parts[1..]);
            todoItems.Add(item);
            Console.WriteLine($"Added: {item}");
        }

        private static void HandleShow()
        {
            if (todoItems.Count == 0)
            {
                Console.WriteLine("Todo list is empty.");
                return;
            }
            Console.WriteLine("----- Todo List -----");
            for (int i = 0; i < todoItems.Count; i++)
            {
                Console.WriteLine($"[{i}] {todoItems[i]}");
            }
        }

        private static void HandleRemove(string[] parts)
        {
            if (parts.Length < 2)
            {
                Console.WriteLine("Error: Usage: remove [index]");
                return;
            }
            if (!int.TryParse(parts[1], out int idx))
            {
                Console.WriteLine("Error: index must be integer number");
                return;
            }
            if (idx < 0 || idx >= todoItems.Count)
            {
                Console.WriteLine($"Error: index {idx} out of range. Valid range: 0~{todoItems.Count-1}");
                return;
            }
            string removed = todoItems[idx];
            todoItems.RemoveAt(idx);
            Console.WriteLine($"Removed: [{idx}] {removed}");
        }

        private static void HandleClear()
        {
            todoItems.Clear();
            tagsDict.Clear();
            Console.WriteLine("All todos cleared.");
        }

        private static void HandleTag(string[] parts)
        {
            try
            {
                if (parts.Length < 3)
                {
                    Console.WriteLine("Error: Usage: tag [index] [tagname]");
                    return;
                }
                if (!int.TryParse(parts[1], out int index))
                {
                    Console.WriteLine("Error: index must be integer");
                    return;
                }
                if (index < 0 || index >= todoItems.Count)
                {
                    Console.WriteLine($"Error: index {index} out‑of‑range");
                    return;
                }
                string tagName = parts[2].ToLower();

                if (!tagsDict.ContainsKey(tagName))
                {
                    tagsDict[tagName] = new List<int>();
                }
                var tagList = tagsDict[tagName];
                if (!tagList.Contains(index))
                {
                    tagList.Add(index);
                    Console.WriteLine($"Tagged item [{index}] with '{tagName}'");
                }
                else
                {
                    Console.WriteLine($"Item [{index}] already has tag '{tagName}'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tag error: {ex.Message}");
            }
        }

        private static void HandleGetTagged(string[] parts)
        {
            try
            {
                if (parts.Length < 2)
                {
                    Console.WriteLine("Error: Usage: get‑tagged [tagname]");
                    return;
                }
                string tag = parts[1].ToLower();
                if (!tagsDict.TryGetValue(tag, out List<int> itemIndices))
                {
                    Console.WriteLine($"Tag '{tag}' does not exist.");
                    return;
                }
                Console.WriteLine($"\n--- Items tagged '{tag}' ---");
                foreach (int i in itemIndices)
                {
                    if(i >=0 && i < todoItems.Count)
                        Console.WriteLine($"[{i}] {todoItems[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get‑tagged error: {ex.Message}");
            }
        }
    }
}