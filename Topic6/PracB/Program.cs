namespace Topic6PracB;

class Program
{
    static void Main(string[] args)
    {
        // Task 1: OrderBy 排序字符串 
        Console.WriteLine(" Task 1: OrderBy \n");

        List<string> names = new List<string>
        {
            "Charlie", "Alice", "David", "Bob", "Eve",
            "Frank", "Grace", "Henry", "Ivy", "Jack"
        };

        Console.WriteLine("排序前:");
        foreach (string n in names) Console.WriteLine(n);

        List<string> sortedNames = names.OrderBy(x => x).ToList();

        Console.WriteLine("\n排序后:");
        foreach (string n in sortedNames) Console.WriteLine(n);

        // Task 2: Select 从 Stack/Queue 选择数据 
        Console.WriteLine("\n\n Task 2: Select + OrderBy \n");

        // 创建 10 个银行账户
        List<BankAccount> accounts = new List<BankAccount>
        {
            new BankAccount("Alice", 5000),
            new BankAccount("Bob", 3000),
            new BankAccount("Charlie", 8000),
            new BankAccount("David", 1000),
            new BankAccount("Eve", 6000),
            new BankAccount("Frank", 2000),
            new BankAccount("Grace", 9000),
            new BankAccount("Henry", 4000),
            new BankAccount("Ivy", 7000),
            new BankAccount("Jack", 500)
        };

        // 创建 Stack 和 Queue，各放入 10 个账户
        Stack<BankAccount> accountStack = new Stack<BankAccount>(accounts);
        Queue<BankAccount> accountQueue = new Queue<BankAccount>(accounts);

        // Stack: Select 选择 Owner，OrderBy 排序
        Console.WriteLine(" Stack: 按 Owner 排序 ");
        var stackOwners = accountStack.Select(a => a.Owner).OrderBy(o => o).ToList();
        foreach (string owner in stackOwners) Console.WriteLine(owner);

        // Queue: Select 选择 Owner，OrderBy 排序
        Console.WriteLine("\n Queue: 按 Owner 排序 ");
        var queueOwners = accountQueue.Select(a => a.Owner).OrderBy(o => o).ToList();
        foreach (string owner in queueOwners) Console.WriteLine(owner);

        // Task 3: Where 过滤 + Select + OrderBy
        Console.WriteLine("\n\n Task 3: Where + Select + OrderBy \n");

        // Stack: Where 过滤 Owner 包含 "e"，Select 选择 Owner 和 Balance，OrderBy 按 Balance 排序
        Console.WriteLine("Stack: Owner 包含 'e'，按 Balance 排序 ");
        var stackFiltered = accountStack
            .Where(a => a.Owner.Contains("e"))
            .Select(a => new { a.Owner, a.Balance })
            .OrderBy(a => a.Balance)
            .ToList();

        foreach (var acc in stackFiltered)
        {
            Console.WriteLine($"{acc.Owner}: ${acc.Balance}");
        }

        // Queue: 同样的过滤和排序
        Console.WriteLine("\n Queue: Owner 包含 'e'，按 Balance 排序 ");
        var queueFiltered = accountQueue
            .Where(a => a.Owner.Contains("e"))
            .Select(a => new { a.Owner, a.Balance })
            .OrderBy(a => a.Balance)
            .ToList();

        foreach (var acc in queueFiltered)
        {
            Console.WriteLine($"{acc.Owner}: ${acc.Balance}");
        }
    }
}
