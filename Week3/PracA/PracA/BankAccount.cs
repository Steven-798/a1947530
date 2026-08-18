namespace PracA;

public class BankAccount
{
    public string AccountName { get; set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string name, decimal startBalance)
    {
        AccountName = name;
        Balance = startBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if(amount > 0)
        {
            Balance += amount;
        }
    }

    public virtual bool Withdraw(decimal amount)
    {
        if(amount >0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine($"Account: {AccountName}");
        Console.WriteLine($"Balance: ${Balance:F2}");
    }
}
