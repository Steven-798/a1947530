using Xunit;
using Prac3B.App;

namespace Prac3B.Tests;

public class EmployeeTests
{
    [Fact]
    public void FullTimeEmployee_CalculatePay_Test()
    {
        var emp = new FullTimeEmployee
        {
            Name = "Bill",
            AnnualSalary = 50000
        };
        var pay = emp.CalculatePay();
        Assert.Equal(40000m, pay);
    }

    [Fact]
    public void Contractor_CalculatePay_Test()
    {
        var c = new Contractor
        {
            Name = "Fred",
            Rate = 100,
            Hours = 200
        };
        var pay = c.CalculatePay();
        Assert.Equal(16000m, pay);
    }

    [Fact]
    public void GenerateReport_ReturnCorrectString()
    {
        var emp = new FullTimeEmployee { Name = "Bill", AnnualSalary = 50000 };
        string report = emp.GenerateReport();
        Assert.Contains("Bill", report);
    }
}
