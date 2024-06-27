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
            btnReset.IsEnabled = false;
            cmbFilters.Items.Add("Name of Ingredients");
            cmbFilters.Items.Add("Food Groups");
            cmbFilters.Items.Add("Max Calories");
            Reset();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

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
                    string foodGroup = edtSearch.Text;
                    FilterByFoodGroup(foodGroup);
                    break;
                case 2:
                    // MessageBox.Show("Enter Max Calories in the Search Bar");
                    int maxCalories = int.Parse(edtSearch.Text);
                    FindRecipeByClosestCalories(maxCalories);
                    break;


            }
            edtSearch.Text = "Search...";
            btnReset.IsEnabled = true;
            btnFilter.IsEnabled = false;

        }
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

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            btnReset.IsEnabled = false;
            btnFilter.IsEnabled = true;
        }
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
    }
}
