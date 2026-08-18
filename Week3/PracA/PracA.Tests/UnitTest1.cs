using PracA;

namespace PracA.Tests;

public class UnitTest1
{
    [Fact]
    public void SavingsAccount_ApplyInterest_AddsInterest()
    {
        var acc = new SavingsAccount("Test", 1000, 5.0);
        acc.ApplyInterest();
        Assert.Equal(1050, acc.Balance);
    }

    [Fact]
    public void CheckingAccount_Withdraw_DeductsFee()
    {
        var acc = new CheckingAccount("Test", 500, 2m);
        acc.Withdraw(100);
        //取100 +扣手续费2，剩余 398
        Assert.Equal(398, acc.Balance);
    }

    [Fact]
    public void BankAccount_Deposit_IncreasesBalance()
    {
        var acc = new BankAccount("Test",100);
        acc.Deposit(50);
        Assert.Equal(150, acc.Balance);
    }

    [Fact]
    public void BankAccount_Withdraw_FailIfNotEnoughMoney()
    {
        var acc = new BankAccount("Test",100);
        var res = acc.Withdraw(200);
        Assert.False(res);
        Assert.Equal(100, acc.Balance);
    }
}

