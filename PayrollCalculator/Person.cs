namespace PayrollCalculator
{
    public class Person
    {
        // 自动属性
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        // 构造函数
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        // 返回 "LastName, FirstName"
        public string FullName()
        {
            return $"{LastName}, {FirstName}";
        }

        // IsAdult 返回bool
        public bool IsAdult()
        {
            return Age >= 18;
        }
    }
}

