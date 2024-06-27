using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10263992_PROG_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public static List<Recipe> Recipes = new List<Recipe>();
        public MainWindow()
        {
            InitializeComponent();
            btnSelectedRecipe.IsEnabled = false;
            //Displays the last recipe created if there isnt one button is blank
            if (Recipes.Count > 0 ) 
            { 
                btnSelectedRecipe.IsEnabled = true;
                btnSelectedRecipe.Content = Recipes[^1].Name; 
            }
            
        }
        /// <summary>
        /// Exits application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)
        {//Opens create recipe window
            CreateRecipe createRecipe = new CreateRecipe();
            createRecipe.Show();
            this.Close();
            /*Results results = new Results();
            results.Show();
            this.Close();*/
        }

        private void btnDisplayRecipe_Click(object sender, RoutedEventArgs e)
        {//Opens saved recipes window
            if (Recipes.Count > 0)
            {
                SavedRecipes savedRecipes = new SavedRecipes();
                savedRecipes.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No recipes to display");
            }

        }

        private void btnSelectedRecipe_Click(object sender, RoutedEventArgs e)
        {//Opens the last created recipe
            CurrentRecipe currentRecipe = new CurrentRecipe();
            currentRecipe.Show();
            this.Close();
        }

    }
}
#region Reference List
/*
Troelsen, A.and Japikse, P. 2024. Pro C# 9 with .NET 5.
         New York: Apress.
StackOverFlow. 2015. What does question mark and dot operator ?. mean in C# 6.0?, 16 February 2015. [Online]. Available at: https://stackoverflow.com/questions/28352072/what-does-question-mark-and-dot-operator-mean-in-c-sharp-6-0 [Accessed 22 March 2024]
Mariko. 2011. Sort a list alphabetically, 06 August 2011. [Online]. Available at: https://stackoverflow.com/questions/6965337/sort-a-list-alphabetically [Accessed 27 June 2024]
PROG6221 - Building a WPF Application (with binding). 2021. YouTube video, added by IIEVC School of Computer Science . [Online]. Available at: https://www.youtube.com/watch?v=NZmaU4n7Hdo&list=PL480DYS-b_keHacwHfXhHmHpWSI1n3Ff9&index=13 [Accessed 27 June 2024]
user310291. 2011. How to set value of C# slider without triggering slider1_ValueChanged, 24 April 2011. [Online]. Available at: https://stackoverflow.com/questions/5769273/how-to-set-value-of-c-sharp-slider-without-triggering-slider1-valuechanged [Accessed 27 June 2024]
 */
#endregion
//=========================================================== EndOfProgram ===========================================================//