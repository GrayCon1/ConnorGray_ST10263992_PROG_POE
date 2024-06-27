using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10263992_PROG_WPF
{
    /// <summary>
    /// Interaction logic for SavedRecipes.xaml
    /// </summary>
    public partial class SavedRecipes : Window
    {

        public SavedRecipes()
        {
            InitializeComponent();
            //Combo Box Items being added
            cmbFoodGroup.Items.Add("Carbohydrate (Bread)");
            cmbFoodGroup.Items.Add("Protein (Meat)");
            cmbFoodGroup.Items.Add("Fats (Butter)");
            cmbFoodGroup.Items.Add("Vitmins (Oranges)");
            cmbFoodGroup.Items.Add("Minerals (Salt)");
            cmbFoodGroup.Items.Add("Fibre (Oats)");
            cmbFoodGroup.Items.Add("Water");

            cmbFoodGroup.Visibility = Visibility.Hidden;//Combo Box is hidden as search by food group is not selected

            btnReset.IsEnabled = false;//Reset Button is disabled

            //Combo Box Items being added
            cmbFilters.Items.Add("Name of Ingredients");
            cmbFilters.Items.Add("Food Groups");
            cmbFilters.Items.Add("Max Calories");
            cmbFilters.Items.Add("Display alphabatically");
            cmbFilters.Items.Add("Select Recipe");
            Reset();
        }
        /// <summary>
        /// Back button taking user back to mainwindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        /// <summary>
        /// When the filter button is click will do various actions based on the selected filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbFilters.SelectedIndex)
            {
                default:
                case 0:
                    //MessageBox.Show("Enter Name of desired ingredient in the Search Bar");
                    
                    string ingName = edtSearch.Text;
                    FilterByIngredient(ingName);
                    break;
                case 1:
                    // MessageBox.Show("Enter Food Group in the Search Bar");
                    
                    string foodGroup = cmbFoodGroup.Items[cmbFoodGroup.SelectedIndex].ToString();
                    FilterByFoodGroup(foodGroup);
                    break;
                case 2:
                    // MessageBox.Show("Enter Max Calories in the Search Bar");
                    
                    int maxCalories = int.Parse(edtSearch.Text);
                    FindRecipeByClosestCalories(maxCalories);
                    break;
                case 3:
                    // MessageBox.Show("Displaying Recipes in Alphabetical Order");
                    SortAlphetically();
                    break;
                case 4:
                    // MessageBox.Show("Select Recipe");
                    FilterByRecipe(edtSearch.Text);
                    break;

            }
            edtSearch.Text = "Search...";
            btnReset.IsEnabled = true;
            btnFilter.IsEnabled = false;

        }
        /// <summary>
        /// Function to search recipes by recipe name
        /// </summary>
        /// <param name="recipeName"></param>
        public void FilterByRecipe(string recipeName)
        {
            int count = 0;
            tBoxSavedRecipes.Text = "Saved Recipes";
            foreach (Recipe recipe in MainWindow.Recipes)
            {
                if (recipe.Name == recipeName)
                {
                    count++;
                    tBoxSavedRecipes.Text += "\n" + count + ")" + recipe.DisplayRecipe() + "\n";
                }
            }
        }
        /// <summary>
        /// Fucntion to filter recipes by ingredient
        /// </summary>
        /// <param name="ingName"></param>
        public void FilterByIngredient(string ingName)
        {
            int count = 0;
            tBoxSavedRecipes.Text = "Saved Recipes";
            foreach (Recipe recipe in MainWindow.Recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingredient.Name == ingName)
                    {
                        count++;
                        tBoxSavedRecipes.Text += "\n" + count + ")" + recipe.DisplayRecipe() + "\n";
                    }
                }
            }
        }
        /// <summary>
        /// Function to sort recipes by name Alphetically
        /// </summary>
        public void SortAlphetically()
        {
            Recipe[] Recipe = new Recipe[MainWindow.Recipes.Count];
            Array.Copy(MainWindow.Recipes.ToArray(),Recipe,MainWindow.Recipes.Count);
            Array.Sort(Recipe, (firstRec, SecondRec) => string.Compare(firstRec.Name, SecondRec.Name));
            int count = 0;
            tBoxSavedRecipes.Text = "Saved Recipes";
            foreach (Recipe recipe in Recipe)
            {
                count++;
                tBoxSavedRecipes.Text += "\n" + count + ")" + recipe.DisplayRecipe() + "\n";
            }
        }
        /// <summary>
        /// Function to filter recipes by food group
        /// </summary>
        /// <param name="foodGroup"></param>
        public void FilterByFoodGroup(string foodGroup)
        {
            int count = 0;
            tBoxSavedRecipes.Text = "Saved Recipes";
            foreach (Recipe recipe in MainWindow.Recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (ingredient.FoodGroup == foodGroup)
                    {
                        count++;
                        tBoxSavedRecipes.Text += "\n" + count + ")" + recipe.DisplayRecipe() + "\n";
                    }
                }
            }
        }
        /// <summary>
        /// Function to find recipe by closest calories
        /// </summary>
        /// <param name="targetCalories"></param>
        public void FindRecipeByClosestCalories(int targetCalories)
        {
            Recipe closestRecipe = null;
            int closestDifference = int.MaxValue;

            foreach (Recipe recipe in MainWindow.Recipes)
            {
                int difference = Math.Abs(recipe.CalorieTotal() - targetCalories);
                if (difference < closestDifference)
                {
                    closestDifference = difference;
                    closestRecipe = recipe;
                }
            }

            tBoxSavedRecipes.Text = closestRecipe.DisplayRecipe();
        }

        private void edtSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            edtSearch.Text = "";
        }
        /// <summary>
        /// Reset button to reset the search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            btnReset.IsEnabled = false;
            btnFilter.IsEnabled = true;
        }
        /// <summary>
        /// Reset function to reset the search
        /// </summary>
        private void Reset()
        {
            int count = 0;
            tBoxSavedRecipes.Text = "Saved Recipes";
            foreach (Recipe recipe in MainWindow.Recipes)
            {
                count++;
                tBoxSavedRecipes.Text += "\n" + count + ")" + recipe.DisplayRecipe() + "\n";
            }
        }

        private void edtSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            edtSearch.Text = "";
        }

        /// <summary>
        /// Used to enable cmbFoodGroups if the filter is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbFilters.SelectedIndex) 
            {
                default:
                case 0:
                    edtSearch.Visibility = Visibility.Visible;
                    cmbFoodGroup.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    edtSearch.Visibility = Visibility.Hidden;
                    cmbFoodGroup.Visibility = Visibility.Visible;
                    break;
                case 2:
                    edtSearch.Visibility = Visibility.Visible;
                    cmbFoodGroup.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    edtSearch.Visibility = Visibility.Visible;
                    cmbFoodGroup.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    edtSearch.Visibility = Visibility.Visible;
                    cmbFoodGroup.Visibility = Visibility.Hidden;
                    break;
            }
        }


    }
}
//=========================================================== EndOfProgram ===========================================================//
