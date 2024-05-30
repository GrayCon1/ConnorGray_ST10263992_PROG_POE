using ConnorGray_ST10263992_PROG6221_POE;
using static System.Console;

public class Recipe
{

    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Steps> Steps { get; set; }
    private delegate void CaloriesTooHigh();
    private CaloriesTooHigh caloriesTooHigh;

    public Recipe(string name, int ingredientCount, int stepCount)
    {
        Name = name;
        Ingredients = new List<Ingredient>(ingredientCount);
        Steps = new List<Steps>(stepCount);
    }
    public String SelectFoodGroup()
    {
        WriteLine("\n1. Carbohydrate (Bread)\n2. Protein (Beef)\n3. Fats (Butter)\n4. Vitmins (Oranges-Vitimin C)\n5. Minerals (Spinch-Iron)\n6. Fibre (Oats)\n7. Water");
        String choice = ReadLine();
        return choice;
    }

    public void ChangeScaleFactor(string choice)
    {
        choice = choice.ToLower();
        float Scale = 0;
        if (choice == "a")
        {
            Scale = 0.5f;
        }
        else if (choice == "b")
        {
            Scale = 2;
        }
        else if (choice == "c")
        {
            Scale = 3;
        }
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].ChangeScaleFactor(Scale);
        }
    }

    public void ResetScaleFactors()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].ResetScaleFactor();
        }
    }

    public void CreateIngredient(
        string name,
        float quantity,
        string unitMeasure,
        int calories,
        string foodGroup
    )
    {
        Ingredients.Add(new Ingredient(name, quantity, unitMeasure, calories, foodGroup));
    }

    public void CreateStep(int index, string stepDescription)
    {
        Steps.Add(new Steps(index, stepDescription));
    }

    public void DisplayRecipe()
    {
        WriteLine($"Recipe: {Name}");
        WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            WriteLine(
                $"- {ingredient.Name}\t{ingredient.Quantity} {ingredient.UnitMeasure}\t{ingredient.Calories}cals"
            );
        }
        WriteLine("Steps:");
        foreach (var step in Steps)
        {
            WriteLine($"- {step.StepCount + 1}. {step.StepDescription}");
        }
        WriteLine(CalorieCalculate());
    }

    public string CalorieCalculate()
    {
        int calTotal = 0;
        foreach (var calories in Ingredients)
        {
            calTotal += calories.Calories;
        }
        string calReturn;
        if (calTotal <= 300)
        {
            ForegroundColor = ConsoleColor.Green;
            calReturn = "This recipe is low in calories: " + calTotal + " cal";
            ForegroundColor = ConsoleColor.White;
        }
        else if (calTotal > 300 && calTotal < 700)
        {
            calReturn = "This recipe is high in calories: " + calTotal + " cal";
            caloriesTooHigh = CalorieHigh;
            caloriesTooHigh();
        }
        else
        {
            calReturn = "This recipe is extremly high in calories: " + calTotal + " cal";
            caloriesTooHigh();
        }
        return calReturn;
    }

    private void CalorieHigh()
    {
        Util.Header("Warning: This recipe is high in calories!", ConsoleColor.Red, ConsoleColor.White);
        WriteLine();
    }
}
