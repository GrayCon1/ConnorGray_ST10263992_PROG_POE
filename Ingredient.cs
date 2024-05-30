using static System.Console;
public class Ingredient
{
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string UnitMeasure { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }
    private float previousScale = 1;

    /// <summary>
    /// Getters and setters being used for each ingredients to get parameters for each ingredient
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Quantity"></param>
    /// <param name="Measure"></param>
    public Ingredient(string name, float quantity, string measure, int calories, string foodGroup)
    {
        this.Name = name;
        this.Quantity = quantity;
        this.UnitMeasure = measure;
        this.Calories = calories;
        this.FoodGroup = foodGroup;
    }

    /// <summary>
    /// ResetScaleFactor a method to set the scale factor of the ingredients back to their original quantities
    /// </summary>
    public void ResetScaleFactor()
    {
        Quantity /= previousScale;
        Calories /= (int)previousScale;
    }

    /// <summary>
    /// ScaleFactor method is used to change the scale factor of the quantity of the ingredients. This method also includes an exception, used if the user does not input the correct data type or inncorrect char value.
    /// </summary>
    /// <param name="ScaleFactor"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public void ChangeScaleFactor(float scale)
    {
        Quantity *= scale;
        Calories *= (int)scale;
        previousScale = scale;
    }

}
//=========================================================== EndOfProgram ===========================================================//
