namespace Cookie;

public static class Program
{
    public static void Main()
    {
        RecipeGenerator generator = new();
        generator.Generate();
        
        Console.WriteLine("--- Recipe ---");
        Console.WriteLine("Perfect Chocolate Chip Cookie by John F President");

        Console.WriteLine("--- Ingredients ---");
        generator.PrintIngredients();

        Console.WriteLine("\n--- Method ---");
        generator.PrintMethod();
    }
}