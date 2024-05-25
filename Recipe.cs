using static System.Console;

public class Recipe
{
    public string Name { get; set; }
    public Ingredient[] Ingredients { get; set; }
    public Steps[] Steps { get; set; }

    public Recipe(string name, int ingredientCount, int stepCount)
    {
        Name = name;
        Ingredients = new Ingredient[ingredientCount];
        Steps = new Steps[stepCount];
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
        for (int i = 0; i < Ingredients.Length; i++)
        {
            Ingredients[i].ChangeScaleFactor(Scale);
        }

    }
    public void ResetScaleFactors()
    {
        for (int i = 0; i < Ingredients.Length; i++)
        {
            Ingredients[i].ResetScaleFactor();
        }
    }

    public void CreateIngredient(int index, string name, float quantity, string unitMeasure, int calories, string foodGroup)
    {
        Ingredients[index] = new Ingredient(name, quantity, unitMeasure, calories, foodGroup);
    }

    public void CreateStep(int index, string stepDescription)
    {
        Steps[index] = new Steps(index, stepDescription);
    }

    public void DisplayRecipe()
    {
        WriteLine($"Recipe: {Name}");
        WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            WriteLine($"- {ingredient.Name}\t{ingredient.Quantity} {ingredient.UnitMeasure}\t{ingredient.Calories}cals");
        }
        WriteLine("Steps:");
        foreach (var step in Steps)
        {
            WriteLine($"- {step.StepCount + 1}. {step.StepDescription}");
        }
        WriteLine("Total Calories for recipe:\n" + CalorieCalculate() + " cal");

    }
    public int CalorieCalculate()
    {
        int calTotal = 0;
        foreach (var calories in Ingredients)
        {
            calTotal += calories.Calories;
        }

        if (calTotal > 300)
        {
            //throw execption
        }
        return calTotal;
    }

}
