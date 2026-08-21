using System;

namespace Prac3B.App  // 加上这一行！
{
    // 接口
    public interface IReportable
    {
        string GenerateReport();
    }

    // 抽象父类
    public abstract class Employee : IReportable
    {
        public string Name { get; set; }
        public const decimal TaxRate = 0.2m;

        public abstract decimal CalculatePay();
        public abstract string GenerateReport();
    }

    // 全职员工
    public class FullTimeEmployee : Employee
    {
        public decimal AnnualSalary { get; set; }

        public override decimal CalculatePay()
        {
            return AnnualSalary - TaxRate * AnnualSalary;
        }

        public override string GenerateReport()
        {
            decimal pay = CalculatePay();
            decimal tax = AnnualSalary * TaxRate;
            return $"{Name}: Pay ${pay}, Tax ${tax}.";
        }
    }

    // 合同工
    public class Contractor : Employee
    {
        public decimal Rate { get; set; }
        public decimal Hours { get; set; }

        public override decimal CalculatePay()
        {
            return Rate * Hours - (Rate * Hours) * TaxRate;
        }

        public override string GenerateReport()
        {
            decimal gross = Rate * Hours;
            decimal pay = CalculatePay();
            decimal tax = gross * TaxRate;
            return $"{Name}: Pay ${pay}, Tax ${tax}.";
        }
    }
}
