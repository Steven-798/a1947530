using System;
using System.Collections.Generic;
using Prac3B.App;

// 创建员工列表
List<Employee> staff = new List<Employee>();

staff.Add(new FullTimeEmployee
{
    Name = "Bill",
    AnnualSalary = 50000
});

staff.Add(new Contractor
{
    Name = "Fred",
    Rate = 100,
    Hours = 200
});

// foreach多态循环
foreach (var emp in staff)
{
    Console.WriteLine(emp.GenerateReport());
}
