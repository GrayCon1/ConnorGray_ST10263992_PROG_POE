public class Ingredient
{
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string Measure { get; set; }


    public Ingredient(string Name, float Quantity, string Measure)
    {
        this.Name = Name;
        this.Quantity = Quantity;
        this.Measure = Measure;
    }

    public float ScaleFactor(char ScaleFactor, float Quantity)
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
        float scaleFactor = Scale * Quantity;
        return scaleFactor;
    }
}