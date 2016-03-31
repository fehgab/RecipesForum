using RecipesClient.DAL;
using RecipesClient.DTO;
using RecipesClient.WindowManagers;
using System.Collections.Generic;
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
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        private ResizeListViewColums resizeLwColumns = new ResizeListViewColums();

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void fillListView(List<Recipes> recipes)
        {
            lwRecipes.Items.Clear();
            foreach (var recipe in recipes)
            {
                var picturePath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", recipe.PictureUrl);
                lwRecipes.Items.Add(new RecipesHeaderData { PictureFullPath = picturePath, Title = recipe.Title, Ingredients = recipe.Ingredients, PrepareTime = recipe.PrepareTime });
            }
        }

        private void lwRecipes_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RecipesModel())
            {
                var allRecipes = db.Recipes.ToList();
                fillListView(allRecipes);
                
            }
            tbSearch.IsEnabled = true;
            lwRecipes.IsEnabled = true;
        }

        private void lwRecipes_LayoutUpdated(object sender, EventArgs e)
        {
            if(lwRecipes.IsEnabled)
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

        private void cbCategories_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RecipesModel())
            {
                var allCategories = db.Categories.ToList();
                foreach (var category in allCategories)
                {
                    cbCategories.Items.Add(category.DisplayName);
                }
            }
            cbCategories.Items.Add("Összes");
            cbCategories.SelectedItem = "Összes";
            cbCategories.IsEnabled = true;
        }

        private void cbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(var db = new RecipesModel())
            {
                if(!((string)cbCategories.SelectedItem).Equals("Összes"))
                {
                    var allRecipesInCategory = db.Recipes.Where(r => r.Categories.DisplayName == (string)cbCategories.SelectedItem).ToList();
                    fillListView(allRecipesInCategory);
                }
                else
                {
                    lwRecipes.RaiseEvent(new RoutedEventArgs(ListView.LoadedEvent));
                }
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                using (var db = new RecipesModel())
                {
                    List<Recipes> searchedRecipes = null;
                    if (tbSearch.Text.Length > 0 && !((string)cbCategories.SelectedItem).Equals("Összes"))
                    {
                        searchedRecipes = db.Recipes.Where(r => r.Categories.DisplayName.Equals((string)cbCategories.SelectedItem)
                                                     && r.Title.Contains(tbSearch.Text)).ToList();
                    }
                    else if(tbSearch.Text.Length > 0)
                    {
                        searchedRecipes = db.Recipes.Where(r => r.Title.Contains(tbSearch.Text)).ToList();
                    }
                    else
                    {
                        searchedRecipes = db.Recipes.ToList();
                    }
                    fillListView(searchedRecipes);
                }
            }
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbSearch.Clear();
            btSearch.IsEnabled = true;
        }

        private void tbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbSearch.Text.Length == 0 && !btSearch.IsMouseOver)
            {
                tbSearch.Text = "Étel neve";
                btSearch.IsEnabled = false;
            }
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual(tbSearch), 0, Key.Enter)
            { RoutedEvent = TextBox.KeyDownEvent });
        }
    }
}
