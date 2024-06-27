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
    /// Interaction logic for CurrentRecipe.xaml
    /// </summary>
    public partial class CurrentRecipe : Window
    {
        private float previousScale = 1;
        public CurrentRecipe()
        {
            InitializeComponent();
            btnResetScale.IsEnabled = false;
            tblockSavedRecipe.Text = "Current Recipe\n===============\n";
            Recipe currentRecipe = MainWindow.Recipes[0];
            tblockSavedRecipe.Text += "\n" + currentRecipe.DisplayRecipe();
            lblCount.Content = sldScaleFactor.Value.ToString("0.##");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnConfimScale_Click(object sender, RoutedEventArgs e)
        {
            if (sldScaleFactor.Value == 0)
            {
                MessageBox.Show("Please select a scale factor");
            }
            else
            {
                ScaleRecipe();

            }
            btnConfimScale.IsEnabled = false;
            btnResetScale.IsEnabled = true;
        }
        public void ResetScaleRecipe()
        {
            Recipe currentRecipe = MainWindow.Recipes[0];
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                ingredient.Quantity /= previousScale;
                ingredient.Calories /= (int)previousScale;
            }
            tblockSavedRecipe.Text = "Current Recipe\n===============\n";
            tblockSavedRecipe.Text += "\n" + currentRecipe.DisplayRecipe();
        }
        public void ScaleRecipe()
        {
            int ScaleFactor = Convert.ToInt32(sldScaleFactor.Value);
            Recipe currentRecipe = MainWindow.Recipes[0];
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                ingredient.Quantity *= ScaleFactor;
                ingredient.Calories *= ScaleFactor;
            }
            previousScale = ScaleFactor;
            tblockSavedRecipe.Text = "Current Recipe\n===============\n";
            tblockSavedRecipe.Text += "\n" + currentRecipe.DisplayRecipe();
        }

        private void btnResetScale_Click(object sender, RoutedEventArgs e)
        {
            ResetScaleRecipe();
            btnConfimScale.IsEnabled = true;
            btnResetScale.IsEnabled = false;
        }

        private void sldScaleFactor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lblCount != null)
            {
                lblCount.Content = e.NewValue.ToString("0.##");
            }

        }
    }
}