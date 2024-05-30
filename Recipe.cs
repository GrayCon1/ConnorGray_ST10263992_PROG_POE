using ConnorGray_ST10263992_PROG6221_POE;
using static System.Console;

public class Recipe
{

    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Steps> Steps { get; set; }
    private delegate void CaloriesTooHigh();
    private CaloriesTooHigh caloriesTooHigh;
    /// <summary>
    /// Constructor for Recipe class
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ingredientCount"></param>
    /// <param name="stepCount"></param>
    public Recipe(string name, int ingredientCount, int stepCount)
    {
        Name = name;
        Ingredients = new List<Ingredient>(ingredientCount);
        Steps = new List<Steps>(stepCount);
    }
    /// <summary>
    /// Select Food Group shows the user the different food groups they can select as well as shows examples of each
    /// </summary>
    /// <returns></returns>
    public String SelectFoodGroup()
    {
        WriteLine("\n1. Carbohydrate (Bread)\n2. Protein (Beef)\n3. Fats (Butter)\n4. Vitmins (Oranges-Vitimin C)\n5. Minerals (Spinch-Iron)\n6. Fibre (Oats)\n7. Water");
        String choice = ReadLine();
        return choice;
    }
    /// <summary>
    /// Changes the scale factor based on the choice the user makes
    /// </summary>
    /// <param name="choice"></param>
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
    /// <summary>
    /// Resets the scale factor of the recipe is it was changed
    /// </summary>
    public void ResetScaleFactors()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].ResetScaleFactor();
        }
    }
    /// <summary>
    /// Creates an ingredient with all of the necessary varibles
    /// </summary>
    /// <param name="name"></param>
    /// <param name="quantity"></param>
    /// <param name="unitMeasure"></param>
    /// <param name="calories"></param>
    /// <param name="foodGroup"></param>
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
    /// <summary>
    /// Adds the steps as well as the descriptions
    /// </summary>
    /// <param name="index"></param>
    /// <param name="stepDescription"></param>
    public void CreateStep(int index, string stepDescription)
    {
        Steps.Add(new Steps(index, stepDescription));
    }
    /// <summary>
    /// Displays the full current recipe
    /// </summary>
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
    /// <summary>
    /// Calulates the calories of the of the recipe as well as tells the user if the recipe is high or low in calories
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Method used in the delegate to show the user that the recipe is high in calories.
    /// </summary>
    private void CalorieHigh()
    {
        Util.Header("Warning: This recipe is high in calories!", ConsoleColor.Red, ConsoleColor.White);
        WriteLine();
    }
}
