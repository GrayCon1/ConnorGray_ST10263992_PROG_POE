using static System.Console;

namespace ConnorGray_ST10263992_PROG6221_POE;

public class Program
{
    private static Recipe currentRecipe;
    private static List<Recipe> Recipes = new List<Recipe>();

    private static void Main()
    {
        while (true) // loop that allows the user to keep using the program until they decide to end it
        {
            UI();
        }
    }

    private static void UI()
    {
        //Menu that allows user to enter a number corresonding to different actions of the program
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
            case 6:
                EndOfProgram();
                break;
            default:
                WriteLine("Invalid Choice");// if the user enters anything other than the options
                break;
        }
        WriteLine("\n");
    }

    /// <summary>
    /// Calls the method in Recipe to rest the scale factor of the current recipe
    /// </summary>
    private static void ResetScaleFactor()
    {
        currentRecipe.ResetScaleFactors();
        currentRecipe.DisplayRecipe();
    }
    /// <summary>
    /// Calls the method in Recipe to change the scale factor of the current recipe
    /// </summary>
    private static void ChangeScaleFactor()
    {
        try
        {
            WriteLine("a) Halved\nb) Double\nc) Tripled");
            string choice = ReadLine();
            currentRecipe.ChangeScaleFactor(choice);
            currentRecipe.DisplayRecipe();
        }
        catch (Exception e)// catches any exceptions that may occur
        {
            WriteLine("Entered value not valid" + e.Message);
        }
    }
    /// <summary>
    /// Calls the method in Recipe To dispaly the made recipe
    /// </summary>
    private static void DisplayRecipe()
    {
        currentRecipe.DisplayRecipe();
    }
    /// <summary>
    /// Calls the method in Recipe to create a Recipe allowing the user to enter all necessary information
    /// </summary>
    private static void CreateRecipe()
    {
        WriteLine("Enter recipe name:"); // user enters the name of the recipe
        string name = ReadLine();
        WriteLine("Enter number of ingredients:"); // user enters the number of ingredients
        int ingredientCountInput = int.Parse(ReadLine());
        WriteLine("Enter number of steps:"); // user enters the number of steps
        int stepCountInput = int.Parse(ReadLine());
        currentRecipe = new Recipe(name, ingredientCountInput, stepCountInput); // adds to current recipe so that it can be used to display current recipe
        Recipes.Add(currentRecipe);// adds to list of recipes
        for (int i = 0; i < ingredientCountInput; i++)
        {
            WriteLine("Enter ingredient name:"); // enters the name of the ingredient
            string ingredientName = ReadLine();
            WriteLine("Enter the quantity:"); // enters the quantity of the ingredient
            float quantity = float.Parse(ReadLine());
            WriteLine("Enter the unit of measure:"); // enters the unit of measure of the ingredient
            string unitMeasure = ReadLine();
            WriteLine("Enter the calories for this ingrdient:"); // enters the calories of the ingredient
            int calories = int.Parse(ReadLine());
            WriteLine("Enter the food group of the ingredient:"); // enters the food group of the ingredient
            string foodGroup = currentRecipe.SelectFoodGroup();
            currentRecipe.CreateIngredient(
                ingredientName,
                quantity,
                unitMeasure,
                calories,
                foodGroup
            ); // information used to create a new recipe and adds to list
        }

        for (int i = 0; i < stepCountInput; i++)
        {
            WriteLine("Enter step " + (i + 1) + " description:");
            string stepDescription = ReadLine();
            currentRecipe.CreateStep(i, stepDescription);// information used to create a new recipe
        }
        Util.Header("Recipe Created and Saved!\n\n", ConsoleColor.Green, ConsoleColor.White);
        UI();
    }
    /// <summary>
    /// Method to display all of the different recipes that are stored in the List as well as all of their ingredients, steps , food groups and calories
    /// </summary>
    private static void DisplayAll()
    {   
        if (Recipes.Count <= 0)// if no recipes are found in the list
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

        WriteLine("Recipe Names:\n");// displays the names of the recipes
        for (int i = 0; i < Recipes.Count; i++)
        {
            WriteLine(i + 1 + ". " + Recipes[i].Name);
        }

        WriteLine("Select a saved recipe to view:");
        int recipeSelectedIndex = int.Parse(ReadLine());
        Recipe recipeSelected = Recipes[recipeSelectedIndex - 1];
        recipeSelected.DisplayRecipe();
        currentRecipe = recipeSelected;
        Util.Header(currentRecipe.Name + " is now the current recipe", ConsoleColor.Green, ConsoleColor.White); // if a recipe is selected in the list becomes current recipe
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
