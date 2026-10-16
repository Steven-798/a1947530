public class Player
{
    public Player(string name, int health = 100, int attack = 10, int defence = 5)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defence = defence;
    }

    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, HP={Health}, ATK={Attack}, DEF={Defence}";
    }
}
