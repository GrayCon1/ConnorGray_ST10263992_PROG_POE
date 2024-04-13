public class Ingredient
{
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string Measure { get; set; }
    private float ResetScale=0;

/// <summary>
/// Getters and setters being used for each ingredients to get parameters for each ingredient
/// </summary>
/// <param name="Name"></param>
/// <param name="Quantity"></param>
/// <param name="Measure"></param>
    public Ingredient(string Name, float Quantity, string Measure)
    {
        this.Name = Name;
        this.Quantity = Quantity;
        this.Measure = Measure;
    }
    /// <summary>
    /// ResetScaleFactor a method to set the scale factor of the ingredients back to their original quantities
    /// </summary>
    public void ResetScaleFactor()
    {
        Quantity/=ResetScale;
    }
/// <summary>
/// ScaleFactor method is used to change the scale factor of the quantity of the ingredients. This method also includes an exception, used if the user does not input the correct data type or inncorrect char value.
/// </summary>
/// <param name="ScaleFactor"></param>
/// <returns></returns>
/// <exception cref="Exception"></exception>
    public float ScaleFactor(char ScaleFactor)
    {
        float Scale;
        if (ScaleFactor == 'a')
        {
            Scale = 0.5f;
        }
        else if (ScaleFactor == 'b')
        {
            Scale = 2;
        }
        else if (ScaleFactor == 'c')
        {
            Scale = 3;
        }
        else
        {
            throw new Exception("User did not enter a valid scale factor");
        }
        ResetScale=Scale;
        float scaleFactor = Scale * Quantity;
        return scaleFactor;
    }
}
//=========================================================== EndOfProgram ===========================================================//