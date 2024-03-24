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
}