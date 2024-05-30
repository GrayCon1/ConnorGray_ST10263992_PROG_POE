using static System.Console;

namespace ConnorGray_ST10263992_PROG6221_POE;

public class Program
{
    private static Recipe currentRecipe;
    private static List<Recipe> Recipes = new List<Recipe>();

    private static void Main()
    {
        while (true)
        {
            UI();
        }
    }

    private static void UI()
    {
        Util.Header("\tRecipe Creator\n\n", ConsoleColor.Magenta, ConsoleColor.White);
        WriteLine(
            "1. Create Recipe\n2. Display Recipe\n3. Change Scale Factor\n4. Reset Scale Factor\n5. Display Saved Recipes\n6. End Program"
        );
        string input = ReadLine();
        bool success = int.TryParse(input, out int choice);
        if (!success)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Invalid input!");
            ForegroundColor = ConsoleColor.White;
            UI();
            return;
        }

        switch (choice)
        {
            case 1:
                CreateRecipe();
                break;
            case 2:
                DisplayRecipe();
                break;
            case 3:
                ChangeScaleFactor();
                break;
            case 4:
                ResetScaleFactor();
                break;
            case 5:
                DisplayAll();
                break;
            default:
            case 6:
                EndOfProgram();
                break;
        }
        WriteLine("\n");
    }

    private static void ResetScaleFactor()
    {
        currentRecipe.ResetScaleFactors();
        currentRecipe.DisplayRecipe();
    }

    private static void ChangeScaleFactor()
    {
        try
        {
            WriteLine("a) Halved\nb) Double\nc) Tripled");
            string choice = ReadLine();
            currentRecipe.ChangeScaleFactor(choice);
            currentRecipe.DisplayRecipe();
        }
        catch (Exception e)
        {
            WriteLine("Entered value not valid" + e.Message);
        }
    }

    private static void DisplayRecipe()
    {
        currentRecipe.DisplayRecipe();
    }

    private static void CreateRecipe()
    {
        WriteLine("Enter recipe name:");
        string name = ReadLine();
        WriteLine("Enter number of ingredients:");
        int ingredientCountInput = int.Parse(ReadLine());
        WriteLine("Enter number of steps:");
        int stepCountInput = int.Parse(ReadLine());
        currentRecipe = new Recipe(name, ingredientCountInput, stepCountInput);
        Recipes.Add(currentRecipe);
        for (int i = 0; i < ingredientCountInput; i++)
        {
            WriteLine("Enter ingredient name:");
            string ingredientName = ReadLine();
            WriteLine("Enter the quantity:");
            float quantity = float.Parse(ReadLine());
            WriteLine("Enter the unit of measure:");
            string unitMeasure = ReadLine();
            WriteLine("Enter the calories for this ingrdient:");
            int calories = int.Parse(ReadLine());
            WriteLine("Enter the food group of the ingredient:");
            string foodGroup = currentRecipe.SelectFoodGroup();
            currentRecipe.CreateIngredient(
                ingredientName,
                quantity,
                unitMeasure,
                calories,
                foodGroup
            );
        }

        for (int i = 0; i < stepCountInput; i++)
        {
            WriteLine("Enter step " + (i + 1) + " description:");
            string stepDescription = ReadLine();
            currentRecipe.CreateStep(i, stepDescription);
        }
        Util.Header("Recipe Created and Saved!\n\n", ConsoleColor.Green, ConsoleColor.White);
        UI();
    }

    private static void DisplayAll()
    {
        if (Recipes.Count <= 0)
        {
            WriteLine("No recipes saved");
            return;
        }

        string[] names = new string[Recipes.Count];
        for (int i = 0; i < names.Length; i++)
        {
            names[i] = Recipes[i].Name;
        }

        for (int i = 0; i < names.Length; i++)
        {
            for (int j = i + 1; j < names.Length; j++)
            {
                if (names[i].CompareTo(names[j]) > 0)
                {
                    string tempNane = names[i];
                    names[i] = names[j];
                    names[j] = tempNane;

                    Recipe tempRecipe = Recipes[i];
                    Recipes[i] = Recipes[j];
                    Recipes[j] = tempRecipe;
                }
            }
        }

        WriteLine("Recipe Names:\n");
        for (int i = 0; i < Recipes.Count; i++)
        {
            WriteLine(i + 1 + ". " + Recipes[i].Name);
        }

        WriteLine("Select a saved recipe to view:");
        int recipeSelectedIndex = int.Parse(ReadLine());
        Recipe recipeSelected = Recipes[recipeSelectedIndex - 1];
        recipeSelected.DisplayRecipe();
        currentRecipe = recipeSelected;
        Util.Header(currentRecipe.Name + " is now the current recipe", ConsoleColor.Green, ConsoleColor.White);
    }

    /// <summary>
    /// EndOfProgram method used to terminate program
    /// </summary>
    private static void EndOfProgram()
    {
        WriteLine("Enter any key to terminate application");
        ReadKey();
        Environment.Exit(0);
    }
}
#region Reference List
/*
Troelsen, A.and Japikse, P. 2024. Pro C# 9 with .NET 5.
         New York: Apress.
StackOverFlow. 2015. What does question mark and dot operator ?. mean in C# 6.0?, 16 February 2015. [Online]. Available at: https://stackoverflow.com/questions/28352072/what-does-question-mark-and-dot-operator-mean-in-c-sharp-6-0 [Accessed 22 March 2024]
*/
#endregion
//=========================================================== EndOfProgram ===========================================================//
