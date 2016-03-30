using RecipesClient.DAL;
using RecipesClient.DTO;
using RecipesClient.WindowManagers;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;


namespace RecipesClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool lwRecipesLoaded = false;

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        private ResizeListViewColums resizeLwColumns = new ResizeListViewColums();

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
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
            lwRecipesLoaded = true;
        }

        private void lwRecipes_LayoutUpdated(object sender, EventArgs e)
        {
            if(lwRecipesLoaded)
            {
                double lwSize = gvcPicture.ActualWidth + gvcTitle.ActualWidth + gvcPrepareTime.ActualWidth + gvcIngredients.ActualWidth;
                double size = (this.ActualWidth - lwSize) / 2;
                lwRecipes.Padding = new Thickness(0, 0, 0, 0);
                if (lwSize < this.ActualWidth)
                {
                    lwRecipes.Padding = new Thickness(size, 0, 0, 0);
                }
                resizeLwColumns.SetMinColumsWidth(this);
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            {
                GridViewColumnHeader column = (sender as GridViewColumnHeader);
                string sortBy = column.Tag.ToString();
                if (listViewSortCol != null)
                {
                    AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                    lwRecipes.Items.SortDescriptions.Clear();
                }

                ListSortDirection newDir = ListSortDirection.Ascending;
                if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                    newDir = ListSortDirection.Descending;

                listViewSortCol = column;
                listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
                AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
                lwRecipes.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
            }
        }

        private void GridViewColumnHeader_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            gvcPicture.Width = gvcPicture.ActualWidth;
        }
    }
}
