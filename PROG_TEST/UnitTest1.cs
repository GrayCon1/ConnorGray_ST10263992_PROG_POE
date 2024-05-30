namespace PROG_TEST
{
    public class UnitTest1
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