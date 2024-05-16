﻿using static System.Console;

namespace ConnorGray_ST10263992_PROG6221_POE;

public class Program
{
    private static Recipe recipe;


    private static void Main()
    {
        UI();
    }

    private static void UI()
    {
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("Recipe Creator");
        ForegroundColor = ConsoleColor.White;
        WriteLine(
            "1. Create Recipe\n2. Display Recipe\n3. Change Scale Factor\n4. Reset Scale Factor\n5. End Program"
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
            default:
            case 5:
                EndOfProgram();
                break;
        }
        WriteLine("\n");
    }

    private static void ResetScaleFactor()
    {
        recipe.ResetScaleFactors();
        recipe.DisplayRecipe();
    }

    private static void ChangeScaleFactor()
    {
        try
        {
            WriteLine("a) Halved\nb) Double\nc) Tripled");
            string choice = ReadLine();
            recipe.ChangeScaleFactor(choice);
            recipe.DisplayRecipe();
        }
        catch (Exception e)
        {
            WriteLine("Entered value not valid" + e.Message);
        }
    }

    private static void DisplayRecipe()
    {
        recipe.DisplayRecipe();
    }

    private static void CreateRecipe()
    {
        WriteLine("Enter recipe name:");
        string name = ReadLine();
        WriteLine("Enter number of ingredients:");
        int ingredientCountInput = int.Parse(ReadLine());
        WriteLine("Enter number of steps:");
        int stepCountInput = int.Parse(ReadLine());

        recipe = new Recipe(name, ingredientCountInput, stepCountInput);
        for (int i = 0; i < ingredientCountInput; i++)
        {
            WriteLine("Enter ingredient name:");
            string ingredientName = ReadLine();
            WriteLine("Enter the quantity:");
            float quantity = float.Parse(ReadLine());
            WriteLine("Enter the unit of measure:");
            string unitMeasure = ReadLine();
            recipe.CreateIngredient(i, ingredientName, quantity, unitMeasure);
        }

        for (int i = 0; i < stepCountInput; i++)
        {
            WriteLine("Enter step " + (i + 1) + " description:");
            string stepDescription = ReadLine();
            recipe.CreateStep(i, stepDescription);
        }
        ForegroundColor = ConsoleColor.Green;
        WriteLine("Recipe Created");
        ForegroundColor = ConsoleColor.White;
        UI();
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
