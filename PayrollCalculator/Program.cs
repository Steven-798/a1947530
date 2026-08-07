using System;

namespace PayrollCalculator
{
    class Program
    {
        // 税率常量 TAX_RATE =0.2
        private const double TAX_RATE = 0.2;

        // static方法计算实发工资
        public static double CalculatePay(double hours, double rate)
        {
            if(hours <= 0 || rate <= 0)
            {
                throw new ArgumentException("Hours and rate must be positive.");
            }
            double gross = hours * rate;
            double tax = gross * TAX_RATE;
            double net = gross - tax;
            return net;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter employee name: ");
                string name = Console.ReadLine();

                Console.Write("Hours worked: ");
                double hours = double.Parse(Console.ReadLine());

                Console.Write("Hourly rate: ");
                double rate = double.Parse(Console.ReadLine());

                double netPay = CalculatePay(hours, rate);
                Console.WriteLine($"{name} earned {netPay:F2} after tax.");

                Console.WriteLine("\n--- Person Class Demo ---");
                Person p1 = new Person("Alice", "Smith", 20);
                Person p2 = new Person("Tom", "Lee", 16);
                Console.WriteLine($"FullName: {p1.FullName()}");
                Console.WriteLine($"IsAdult (Alice): {p1.IsAdult()}");
                Console.WriteLine($"FullName: {p2.FullName()}");
                Console.WriteLine($"IsAdult (Tom): {p2.IsAdult()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

