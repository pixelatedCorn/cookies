namespace Cookie;

public class Ingredient
{
    public readonly string Name;
    public readonly string[] Units;
    public Ingredient(string name, string[] units)
    {
        Name = name;
        Units = units;
    }
}
