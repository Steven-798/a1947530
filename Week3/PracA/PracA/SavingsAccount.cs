namespace PracA;

public class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingsAccount(string name, decimal startBalance, double rate)
        : base(name, startBalance)
    {
        InterestRate = rate;
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * (decimal)InterestRate / 100;
        Deposit(interest);
    }

    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Interest rate: {InterestRate}%");
    }
}
