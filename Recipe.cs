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
        else
        {
            WriteLine("Did not enter a valid scale factor");
            return;
        }
        for (int i = 0; i < Ingredients.Length; i++)
        {
            Ingredients[i].ChangeScaleFactor(Scale);
        }
    }
    public void ResetScaleFactors(){
        for (int i = 0; i < Ingredients.Length; i++)
        {
            Ingredients[i].ResetScaleFactor();
        }
    }

    public void CreateIngredient(int index, string name, float quantity, string unitMeasure)
    {
        Ingredients[index] = new Ingredient(name, quantity, unitMeasure);
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
            WriteLine($"- {ingredient.Name}\t{ingredient.Quantity} {ingredient.UnitMeasure}");
        }
        WriteLine("Steps:");
        foreach (var step in Steps)
        {
            WriteLine($"- {step.StepCount + 1}. {step.StepDescription}");
        }
    }
}
