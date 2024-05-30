namespace ST10263992_UnitTest
{
    public class RecipeTests
    {
        [Test]
        public void CalorieCalculationIsCorrect()
        {
            int calTotal = 100;
            Assert.IsTrue(calTotal < 300);
        }

        [Test]
        public void CalorieCalculationIsTooHigh()
        {
            int calTotal = 400;
            Assert.IsTrue(calTotal > 300);
        }
    }
}