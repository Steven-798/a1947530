namespace PracA;

public class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }

    public CheckingAccount(string name, decimal startBalance, decimal fee)
        : base(name, startBalance)
    {
        TransactionFee = fee;
    }

    public override bool Withdraw(decimal amount)
    {
        bool ok = base.Withdraw(amount);
        if(ok)
        {
            base.Withdraw(TransactionFee);
        }
        return ok;
    }

    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();
        Console.WriteLine($"Transaction fee: ${TransactionFee:F2}");
    }
}
