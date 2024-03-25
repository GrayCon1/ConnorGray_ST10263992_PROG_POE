public class Ingredient
{
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string Measure { get; set; }


    public Ingredient(string Name, float Quantity, string Measure)
    {
        this.Name = Name;
        this.Quantity=Quantity;
        this.Measure=Measure;
    }

public static float ScaleFactor(char ScaleFactor,float Quantity)
{
    double Scale;
    if (ScaleFactor=='a')
    {
        Scale=0.5;
    }else if(ScaleFactor=='b'){
        Scale=2;
    }else{ //add exception
        Scale=3;
    }
    float scaleFactor=(float)Scale*Quantity;
    return scaleFactor;
}
}