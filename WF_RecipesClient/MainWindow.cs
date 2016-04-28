using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
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

        private async void recipeClientForm_Load(object sender, EventArgs e)
        {
            await loadDB();

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

        private void lwRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void brnDeleteRecord_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Biztosan törlöd a kijelölt recepteket?", "izé", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ListView.SelectedListViewItemCollection recipes = lwRecipes.SelectedItems;
                if (recipes.Count > 0)
                {
                    deleteRecipes(recipes);
                }
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            RecipeDetailsForm rd = new RecipeDetailsForm(this);
            rd.Show();
        }

        private async void recipeClientForm_EnabledChanged(object sender, EventArgs e)
        {
            if(this.Enabled == true)
            {
                await loadDB();
            }
        }

        private void lwRecipes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lwRecipes.SelectedItems.Count > 0)
            {
                this.Enabled = false;
                RecipeDetailsForm rd = new RecipeDetailsForm(this, lwRecipes.SelectedItems);
                rd.Show();
            }
        }
    }
}
