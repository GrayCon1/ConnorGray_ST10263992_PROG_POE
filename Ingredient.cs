using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10263992_PROG_WPF
{
    public class Ingredient
    {
       
        public string Name { get; set; }
        public float Quantity { get; set; }
        public string UnitMeasure { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        /// <summary>
        /// Getters and setters being used for each ingredients to get parameters for each ingredient
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Quantity"></param>
        /// <param name="UnitMeasure"></param>

        public Ingredient(string name, float quantity, string measure, int calories, string foodGroup)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.UnitMeasure = measure;
            this.Calories = calories;
            this.FoodGroup = foodGroup;
        }
    }
}
//=========================================================== EndOfProgram ===========================================================//
