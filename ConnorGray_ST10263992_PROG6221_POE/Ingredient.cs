public class Ingredient
{
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string Measure { get; set; }
    private float ResetScale=0;


    public Ingredient(string Name, float Quantity, string Measure)
    {
        this.Name = Name;
        this.Quantity = Quantity;
        this.Measure = Measure;
    }
    public void ResetScaleFactor()
    {
        Quantity/=ResetScale;
    }

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