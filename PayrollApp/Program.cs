using PayrollApp;

// 演示使用Payroll类
Payroll pay = new Payroll(40, 25.50m, 0.2m);
Console.WriteLine($"Net Pay: {pay.CalculateNetPay():C}");

pay.ChangeTaxRate(0.25m);
Console.WriteLine($"After tax change Net Pay: {pay.CalculateNetPay():C}");

