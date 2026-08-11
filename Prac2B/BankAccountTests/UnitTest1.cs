using BankApp;

namespace BankAccountTests;

public class BankAccountTests
{
    [Fact]
    public void Constructor_NegativeInitialBalance_SetZero()
    {
        BankAccount acc = new BankAccount("Bob", -200m);
        Assert.Equal(0m, acc.Balance);
    }

    [Fact]
    public void Deposit_Decimal_IncreasesBalance()
    {
        BankAccount acc = new BankAccount("Bob", 100m);
        acc.Deposit(50m);
        Assert.Equal(150m, acc.Balance);
    }

    [Fact]
    public void Deposit_IntOverload_Works()
    {
        BankAccount acc = new BankAccount("Bob", 100m);
        acc.Deposit(30);
        Assert.Equal(130m, acc.Balance);
    }

    [Fact]
    public void Deposit_DoubleOverload_Works()
    {
        BankAccount acc = new BankAccount("Bob", 100m);
        acc.Deposit(25.5);
        Assert.Equal(125.5m, acc.Balance);
    }

    [Fact]
    public void Withdraw_SufficientBalance_ReduceBalance()
    {
        BankAccount acc = new BankAccount("Bob", 100m);
        acc.Withdraw(40m);
        Assert.Equal(60m, acc.Balance);
    }

    [Fact]
    public void Withdraw_BalanceTooLow_ThrowsException()
    {
        BankAccount acc = new BankAccount("Bob", 50m);
        Assert.Throws<InvalidOperationException>(() => acc.Withdraw(100m));
    }
}

