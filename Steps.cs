public class Steps
{
    public int StepCount { get; set; }
    public string StepDescription { get; set; }

    public Steps(int stepCount, string stepDescription)
    {
        StepCount = stepCount;
        StepDescription = stepDescription;
    }
}
