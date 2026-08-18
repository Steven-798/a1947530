using PracA;

// SavingsAccount演示
SavingsAccount sa = new SavingsAccount("Jordan", 1500, 3.5);
sa.DisplayAccountInfo();
sa.ApplyInterest();
Console.WriteLine("---After interest---");
sa.DisplayAccountInfo();

Console.WriteLine("\n=====================\n");

// CheckingAccount演示
CheckingAccount ca = new CheckingAccount("Alice", 1000, 2.50m);
ca.DisplayAccountInfo();
ca.Withdraw(100);
Console.WriteLine("---After withdraw $100 (fee deducted)---");
ca.DisplayAccountInfo();
