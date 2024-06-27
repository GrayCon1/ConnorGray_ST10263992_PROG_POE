using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10263992_PROG_WPF
{
    public class Recipe
    {
        public string Name { get; set; }
        private static Ingredient currentIng;
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Steps> Steps { get; set; } = new List<Steps>();

        public Recipe(string name)
        {
            Name = name;
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
        public void CreateStep( string stepDescription)
        {
            int index = Steps.Count;
            Steps.Add(new Steps(index, stepDescription));
        }
        public string DisplayRecipe()
        {
            string Out = "\t\t"+ Name + "\n"+"Ingredients:\n";
            foreach (var ingredient in Ingredients)
            {
                Out += $"- {ingredient.Name}\t{ingredient.Quantity} {ingredient.UnitMeasure}\t{ingredient.Calories}cals\t\t {ingredient.FoodGroup}\n";
            }
            Out += "\n"+CalorieCalculate();
            Out +="\n\nSteps:\n";
            foreach (var step in Steps)
            {
               Out+= $"- {step.StepCount + 1}. {step.StepDescription}\n";
            }
            
            return Out;
        }

        public string CalorieCalculate()
        {
            int calTotal=CalorieTotal();
            string calReturn;
            if (calTotal <= 300)
            {
                calReturn = "This recipe is low in calories: " + calTotal + " cal";
            }
            else if (calTotal > 300 && calTotal < 700)
            {
                calReturn = "This recipe is high in calories: " + calTotal + " cal";
            }
            else
            {
                calReturn = "This recipe is extremly high in calories: " + calTotal + " cal";
            }
            return calReturn;
        }
        public int CalorieTotal()
        {
            int calTotal = 0;
            foreach (var calories in Ingredients)
            {
                calTotal += calories.Calories;
            }
            return calTotal;
        }
    }
}
