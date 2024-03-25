using static System.Console;

namespace ConnorGray_ST10263992_PROG6221_POE;

public class Program
{
    private static Ingredient[] arrIngredients;

    private static void Main()
    {
        Write("Enter the name for the recipe: ");
        string RecName = ReadLine();
        Write("How many different ingredients are used?: ");
        int IngNum = int.Parse(ReadLine());

        arrIngredients = new Ingredient[IngNum];
        for (int i = 0; i < IngNum; i++)
        {
            Write("Enter the Name of ingredient number " + (i + 1) + ":");
            string Name = ReadLine();

            Write("Enter the Quantity of ingredient number " + (i + 1) + ":");
            float Quantity = float.Parse(ReadLine());

            Write("Enter the Unit of Measure of ingredient number " + (i + 1) + ":");
            string Measure = ReadLine();

            arrIngredients[i] = new Ingredient(Name, Quantity, Measure);
        }
        Write("How many steps are in the " + RecName + " recipe?");
        int NumSteps = int.Parse(ReadLine());

        string[] arrSteps = new string[NumSteps];
        for (int i = 0; i < NumSteps; i++)
        {
            Write("Enter the Description of step number " + (i + 1) + ":");
            arrSteps[i] = ReadLine();
        }
        RecOutput(RecName, arrSteps);

        WriteLine("Would you like the scale of the recipe?:\tY/N");
        char Response = char.Parse(ReadLine());

        if (Response=='Y')
        {
            WriteLine("Do you want it to be:\na) Halved\tb) Doubled\tc) Tripled\nplease select 'a' or 'b' or 'c'");
            char ScaleFactor=char.Parse(ReadLine());
            int f=2;
            for (int i = 0; i < arrIngredients.Length; i++)
            {
                arrIngredients[f]
            }
        }else{
            EndOfProgram();
        }
        
    }
    public static void EndOfProgram()
    {
        WriteLine("Enter any key to terminate appliaction");
        ReadKey();
    }
    public static void RecOutput(string RecName, string[] Steps)
    {
        string Name="";
        float Quantity=0;
        string Measure="";

        WriteLine(RecName + ":" + "\n==========================================================================" + "\nIngredients: (" + arrIngredients.Length
        + ")" + "\t\tSteps: (" + Steps.Length + ")");
        int length = Math.Max(arrIngredients.Length, Steps.Length);
        
            for (int i = 0; i < length; i++)
            {
            //change
                if (i>arrIngredients.Length)
                {
                  arrIngredients[i]= new Ingredient(Name,Quantity,Measure);  
                }

                WriteLine(i + 1 + ")" + arrIngredients[i].Name + "\t" + 
                arrIngredients[i].Quantity + "\t" + 
                arrIngredients[i].Measure + "\t\t" +i+1+ ")" + Steps[i]);
            }
        

        WriteLine("\n==========================================================================");
    }
}
