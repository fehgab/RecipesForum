using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WF_RecipesClient
{
    public partial class recipeClientForm : Form
    {
        private ColumnHeader SortingColumn = null;

        public recipeClientForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            WindowState = FormWindowState.Maximized;
        }

        private void recipeClientForm_Load(object sender, EventArgs e)
        {
            using (var db = new RecipesModel.RecipesModel())
            {
                var allRecipes = db.Recipes.ToList();
                fillListView(allRecipes);

                var allCategories = db.Categories.ToList();
                foreach (var category in allCategories)
                {
                    cbCategories.Items.Add(category.DisplayName);
                }
            }

            cbCategories.Items.Add("Összes");
            cbCategories.SelectedItem = "Összes";

            cbUser.Items.Add("Bejelntkezés");
            cbUser.Items.Add("Regisztráció");
            cbUser.SelectedIndex = -1;

            cbCategories.Enabled = true;
            tbSearch.Enabled = true;
            lwRecipes.Enabled = true;
            cbUser.Enabled = true;
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
            searchRecipes();
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

        private void cbUser_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedText = cbUser.SelectedItem as string;
            if(selectedText.Equals("Regisztráció"))
            {
                this.Enabled = false;
                RegistrationForm rf = new RegistrationForm(this);
                rf.Show();
            }

            if (selectedText.Equals("Bejelentkezés"))
            {
                this.Enabled = false;
                RegistrationForm rf = new RegistrationForm(this);
                rf.Show();
            }
        }
    }
}
