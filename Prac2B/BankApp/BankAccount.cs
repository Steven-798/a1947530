namespace BankApp;

public class BankAccount
{
    // Task1 auto‑properties
    public string Owner { get; set; }
    public decimal Balance { get; private set; }

    // 构造函数
    public BankAccount(string owner, decimal initialBalance)
    {
        Owner = owner;
        // 初始余额不能负数
        Balance = initialBalance < 0 ? 0 : initialBalance;
    }

    // 存款方法
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public void Deposit(int amount)
    {
        Deposit((decimal)amount);
    }

    public void Deposit(double amount)
    {
        Deposit((decimal)amount);
    }

    // 取款：余额太低抛出异常
    public void Withdraw(decimal amount)
    {
        if (Balance < amount)
        {
            throw new InvalidOperationException("Balance too low, cannot withdraw.");
        }
        if(amount > 0)
        {
            Balance -= amount;
        }
    }
}
