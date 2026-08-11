using BankApp;

BankAccount account = new BankAccount("Alice", 100m);
Console.WriteLine($"Owner: {account.Owner}, Balance: {account.Balance:C}");

account.Deposit(50m);   // decimal
account.Deposit(20);     // int overload
account.Deposit(10.5);   // double overload

Console.WriteLine($"After multiple deposits: {account.Balance:C}");

