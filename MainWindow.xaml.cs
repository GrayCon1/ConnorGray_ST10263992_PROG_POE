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
            if (Recipes.Count > 0 ) 
            { 
                btnSelectedRecipe.IsEnabled = true;
                btnSelectedRecipe.Content = Recipes[0].Name; 
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            CreateRecipe createRecipe = new CreateRecipe();
            createRecipe.Show();
            this.Close();
            /*Results results = new Results();
            results.Show();
            this.Close();*/
        }

        private void btnDisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
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
        {
            CurrentRecipe currentRecipe = new CurrentRecipe();
            currentRecipe.Show();
            this.Close();
        }

    }
}