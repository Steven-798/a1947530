namespace PayrollApp;

public class Payroll
{
    // Task2：带校验的自动属性
    public double Hours
    {
        get;
        set
        {
            if(value >= 0)
                field = value;
            else
                field = 0;
        }
    }

    public decimal Rate
    {
        get;
        set
        {
            if(value >=0)
                field = value;
            else
                field = 0;
        }
    }

    public decimal TaxRate
    {
        get;
        set
        {
            if(value >=0)
                field = value;
            else
                field = 0;
        }
    }

    // 构造函数，现在给属性赋值
    public Payroll(double hours, decimal rate, decimal taxRate)
    {
        Hours = hours;
        Rate = rate;
        TaxRate = taxRate;
    }

    public decimal CalculateNetPay()
    {
        decimal gross = (decimal)Hours * Rate;
        decimal tax = gross * TaxRate;
        return gross - tax;
    }

    public void ChangeTaxRate(decimal newTaxRate)
{
    // 只有>=0才赋值，负数直接跳过，不修改
    if(newTaxRate >= 0)
    {
        TaxRate = newTaxRate;
    }
}
}
