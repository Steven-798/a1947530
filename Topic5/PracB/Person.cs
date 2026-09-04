namespace Topic5PracB;

/// <summary>
/// Person 类表示一个人，包含名、姓、年龄，以及一些辅助方法。
/// </summary>
public class Person
{
    // 自动属性：FirstName 和 LastName 只能在类内部设置（private set）
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    // 私有字段：存储年龄
    private double _age;

    // Age 属性：带验证的属性，年龄不能小于等于 0
    public double Age
    {
        get { return _age; }
        set
        {
            if (value <= 0.0)
            {
                throw new ArgumentException("Age can't be less than 0");
            }
            else
            {
                _age = value;
            }
        }
    }

    // 只读计算属性：返回 "姓, 名" 格式的全名
    public string FullName => $"{FirstName}, {LastName}";

    // 构造函数：初始化 FirstName、LastName、Age
    public Person(string firstName, string lastName, double age)
    {
        FirstName = firstName;
        LastName = lastName;
        if (age <= 0.01)
        {
            throw new ArgumentException("Age should be greater than zero");
        }
        Age = age;
    }

    // 方法：判断是否成年（年龄 >= 18）
    public bool IsAdult()
    {
        return Age >= 18;
    }
}
