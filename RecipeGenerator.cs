namespace Cookie;

public class RecipeGenerator
{
    private List<Ingredient> possibleIngredients;
    private List<string> ingredients;
    private List<string> method;
    private Random random;
    public RecipeGenerator()
    {
        ingredients = new();
        method = new();
        random = new();

        string[] standardUnits = 
        {
            "cups",
            "ounces",
            "tablespoons",
            "teaspoons",
        };

        possibleIngredients = new()
        {
            new("flour", standardUnits),
            new("sugar", standardUnits),
            new("brown sugar", standardUnits),
            new("chocolate chips", standardUnits),
            new("baking powder", standardUnits),
            new("butter", new string[] {"sticks"}),
            new("salt", standardUnits),
            new("eggs", new string[] {""}),
        };
    }

    public void Generate()
    {
        GenerateIngredients();
        GenerateMethod();
    }

    private void GenerateIngredients()
    {
        foreach (var ing in possibleIngredients)
        {
            if (ing.Name == "eggs")
            {
                int num = random.Next(1, 13);
                ingredients.Add($"{num} eggs");
            }
            else
            {
                float num = MathF.Round(random.NextSingle() * 10, 2);
                string unit = ing.Units[random.Next(ing.Units.Length)];
                ingredients.Add($"{num} {unit}(s) of {ing.Name}");
            }
        }
    }

    private void GenerateMethod()
    {
        List<Ingredient> remaining = new(possibleIngredients);

        int index = random.Next(remaining.Count());
        Ingredient first = remaining[index];
        remaining.RemoveAt(index);
        index = random.Next(remaining.Count());
        Ingredient second = remaining[index];
        remaining.RemoveAt(index);

        method.Add($"Add {first.Name} to bowl");
        method.Add($"Add {second.Name} to bowl");
        method.Add($"Cream {first.Name} and {second.Name}");

        while (remaining.Count() > 0)
        {
            int selection = random.Next(3);
            if (selection == 2)
            {
                method.Add("Mix contents of bowl well");
            }
            else
            {
                index = random.Next(remaining.Count());
                Ingredient ing = remaining[index];
                remaining.RemoveAt(index);
                method.Add($"Add {ing.Name} to bowl");
            }
        }

        method.Add("Mix contents of bowl well");
        method.Add("Shape dough into balls and place on baking sheet");
        method.Add($"Let rest for {MathF.Round(random.NextSingle() * 4, 2)} minute(s)");
        method.Add($"Bake for {random.Next(46)} minute(s)");
        method.Add("Enjoy!");
    }

    public void PrintIngredients()
    {
        int l = ingredients.Count();
        for (int i = 0; i < l; i++)
        {
            Console.WriteLine($"{i+1}: {ingredients[i]}");
        }
    }
    
    public void PrintMethod()
    {
        int l = method.Count();
        for (int i = 0; i < l; i++)
        {
            Console.WriteLine($"{i+1}: {method[i]}");
        }
    }
}