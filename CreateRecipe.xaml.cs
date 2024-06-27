using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Window
    {
        private Recipe currentRecipe;
        private  List<Recipe> Recipes = new List<Recipe>();
        public CreateRecipe()
        {
            InitializeComponent();
            btnAddDescription.IsEnabled = true;
            btnAddIngredient.IsEnabled = true;
            btnSaveRecipe.IsEnabled = true;
            cmbFoodGroup.Items.Add("Carbohydrate (Bread)");
            cmbFoodGroup.Items.Add("Protein (Meat)");
            cmbFoodGroup.Items.Add("Fats (Butter)");
            cmbFoodGroup.Items.Add("Vitmins (Oranges)");
            cmbFoodGroup.Items.Add("Minerals (Salt)");
            cmbFoodGroup.Items.Add("Fibre (Oats)");
            cmbFoodGroup.Items.Add("Water");
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentRecipe == null)
            {
                currentRecipe = new Recipe(edtRecipeName.Text);
            }
            string IngName = edtIngredentName.Text;
            string IngQuantity = edtQuantity.Text;
            string IngMeasure = edtMeasure.Text;
            string IngCalories = edtCalories.Text;
            string IngFoodGroup = cmbFoodGroup.Items[cmbFoodGroup.SelectedIndex].ToString();
            currentRecipe.CreateIngredient(IngName, float.Parse(IngQuantity), IngMeasure, int.Parse(IngCalories), IngFoodGroup);
            tblockOutput.Text = currentRecipe.DisplayRecipe();
            edtQuantity.Text = "";
            edtIngredentName.Text = "";
            edtMeasure.Text = "";
            edtCalories.Text = "";
            cmbFoodGroup.SelectedIndex = -1;
        }

        private void btnAddDescription_Click(object sender, RoutedEventArgs e)
        {  
            if (currentRecipe == null )
            {
                currentRecipe = new Recipe(edtRecipeName.Text);
            }
            string Description = edtDescription.Text;
            currentRecipe.CreateStep(Description);
            tblockOutput.Text = currentRecipe.DisplayRecipe();
            tblockOut.Text = "";
            edtDescription.Text = "";
        }

        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            btnAddDescription.IsEnabled = false;
            btnAddIngredient.IsEnabled = false;
            btnSaveRecipe.IsEnabled = false;
            MainWindow.Recipes.Add(currentRecipe);
            MessageBox.Show("Your recipe has been saved");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
