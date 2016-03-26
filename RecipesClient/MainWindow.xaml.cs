using RecipesClient.DAL;
using RecipesClient.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipesClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void lwRecipes_Loaded(object sender, RoutedEventArgs e)
        {     
            using (var db = new RecipesModel())
            {
                var allRecipes = db.Recipes.ToList();
                foreach (var recipe in allRecipes)
                {
                    var picturePath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", recipe.PictureUrl);
                    lwRecipes.Items.Add(new RecipesHeaderData { PictureFullPath = picturePath, Title = recipe.Title, Ingredients = recipe.Ingredients, PrepareTime = recipe.PrepareTime });
                }
            }
        }

        private void lwRecipes_LayoutUpdated(object sender, EventArgs e)
        {
            double lwSize = gvcPicture.ActualWidth + gvcTitle.ActualWidth + gvcPrepareTime.ActualWidth + gvcIngredients.ActualWidth;
            double size = (this.ActualWidth - lwSize) / 2;
            if(lwSize < this.ActualWidth)
            {
                lwRecipes.Padding = new Thickness(size, 0, 0, 0);
            }               
        }
    }
}
