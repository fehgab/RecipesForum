﻿using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_RecipesClient
{
    public partial class recipeClientForm : Form
    {
        private ColumnHeader SortingColumn = null;
        public bool isLoggedIn = false;

        public string userName = "";

        public recipeClientForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            WindowState = FormWindowState.Maximized;
        }

        private void recipeClientForm_Load(object sender, EventArgs e)
        {
            loadDB();

            cbCategories.Items.Add("Összes");
            cbCategories.SelectedItem = "Összes";

            cbCategories.Enabled = true;
            tbSearch.Enabled = true;
            lwRecipes.Enabled = true;
            btnNewRecord.Enabled = true;
            btnDeleteRecord.Enabled = true;
        }

        private void cbCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            using (var db = new RecipesModel.RecipesModel())
            {
                if (!((string)cbCategories.SelectedItem).Equals("Összes"))
                {
                    var allRecipesInCategory = db.Recipes.Where(r => r.Categories.DisplayName == (string)cbCategories.SelectedItem).ToList();
                    fillListView(allRecipesInCategory);
                }
                else
                {
                    var allRecipes = db.Recipes.ToList();
                    fillListView(allRecipes);
                }
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchRecipes();
            }
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
            btSearch.Enabled = true;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if(tbSearch.Text.Length > 0)
            {
                searchRecipes();
            }
        }

        private void lwRecipes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader newSortingColumn = lwRecipes.Columns[e.Column];

            SortOrder sortOrder;
            if (SortingColumn == null)
            {
                sortOrder = SortOrder.Ascending;
            }
            else
            {
                if (newSortingColumn == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("-> "))
                    {
                        sortOrder = SortOrder.Descending;
                    }
                    else
                    {
                        sortOrder = SortOrder.Ascending;
                    }
                }
                else
                {
                    sortOrder = SortOrder.Ascending;
                }
                SortingColumn.Text = SortingColumn.Text.Substring(3);
            }
            SortingColumn = newSortingColumn;
            if (sortOrder == SortOrder.Ascending)
            {
                SortingColumn.Text = "-> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "<- " + SortingColumn.Text;
            }
            lwRecipes.ListViewItemSorter =
                new ListViewComparer(e.Column, sortOrder);
            lwRecipes.Sort();
        }

        private async Task<int> deleteRecipes(ListView.SelectedListViewItemCollection recipes)
        {
            using (var db = new RecipesModel.RecipesModel())
            {
                foreach (ListViewItem recipe in recipes)
                {
                    var selectedRecipe = db.Recipes.Where(r => r.ID.ToString().Equals(recipe.Tag)).First();
                    db.Recipes.Remove(selectedRecipe);
                    File.Delete(selectedRecipe.PictureUrl);
                    db.SaveChanges();
                    var selectedRecipeComments = db.Comments.Where(c => c.RecipesId.ToString().Equals(recipe.Tag));
                    foreach (var selectedRecipeComment in selectedRecipeComments)
                    {
                        db.Comments.Remove(selectedRecipeComment);
                        db.SaveChanges();
                    }
                }
            }
            return 1;
        }

        private void lwRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lwRecipes.SelectedItems.Count > 0)
            {
                this.Enabled = false;
                RecipeDetailsForm rd = new RecipeDetailsForm(this, lwRecipes.SelectedItems);
                rd.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void brnDeleteRecord_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Biztosan törlöd a kijelölt recepteket?", "izé", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ListView.SelectedListViewItemCollection recipes = lwRecipes.SelectedItems;
                if (recipes.Count > 0)
                {
                    await deleteRecipes(recipes);
                }
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            RecipeDetailsForm rd = new RecipeDetailsForm(this);
            rd.Show();
        }

        private void recipeClientForm_EnabledChanged(object sender, EventArgs e)
        {
            if(this.Enabled == true)
            {
                loadDB();
            }
        }
    }
}
