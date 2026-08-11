using PayrollApp;

namespace PayrollTests;

public class PayrollTests
{
    [Fact]
    public void Constructor_NegativeHours_SetsToZero()
    {
        Payroll p = new Payroll(-5, 20m, 0.1m);
        Assert.Equal(0, p.Hours);
    }

    [Fact]
    public void Constructor_NegativeRate_SetsToZero()
    {
        Payroll p = new Payroll(40, -10m, 0.1m);
        Assert.Equal(0m, p.Rate);
    }

    [Fact]
    public void Constructor_NegativeTaxRate_SetsToZero()
    {
        Payroll p = new Payroll(40,20m,-0.2m);
        Assert.Equal(0m, p.TaxRate);
    }

    [Fact]
    public void CalculateNetPay_CorrectCalculation()
    {
        Payroll p = new Payroll(40, 25m,0.2m);
        // 40*25 =1000，扣20%税 → 800
        Assert.Equal(800m, p.CalculateNetPay());
    }

    [Fact]
    public void ChangeTaxRate_ValidValue_UpdatesTax()
    {
        Payroll p = new Payroll(40,25m,0.1m);
        p.ChangeTaxRate(0.3m);
        Assert.Equal(0.3m,p.TaxRate);
    }

    [Fact]
    public void ChangeTaxRate_Negative_DoNotChange()
    {
        Payroll p = new Payroll(40,25m,0.1m);
        p.ChangeTaxRate(-0.5m);
        Assert.Equal(0.1m,p.TaxRate);
    }
}
