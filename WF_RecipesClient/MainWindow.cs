using System;
using System.Data;
using System.Linq;
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
            if (!isLoggedIn)
            {
                notLoggedIn();
            }
            else
            {
                loggedIn();
            }

            loadDB();

            cbRecord.Items.Add("Rekordok törlése");
            cbRecord.Items.Add("Rekord módosítása");
            cbRecord.SelectedIndex = -1;
            cbCategories.Items.Add("Összes");
            cbCategories.SelectedItem = "Összes";

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

        private void cbUser_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedText = cbUser.SelectedItem as string;
            if(cbUser.SelectedIndex != -1)
            {
                if (selectedText.Equals("Regisztráció"))
                {
                    this.Enabled = false;
                    RegistrationForm rf = new RegistrationForm(this);
                    rf.Show();
                }

                else if (selectedText.Equals("Bejelentkezés"))
                {
                    this.Enabled = false;
                    LoginForm lf = new LoginForm(this);
                    lf.Show();
                }

                else if (selectedText.Equals("Kijelentkezés"))
                {
                    notLoggedIn();
                }
            }
            cbUser.SelectedIndex = -1;
        }

        private void recipeClientForm_EnabledChanged(object sender, EventArgs e)
        {
            if (lwRecipes.Enabled)
            {
                if (!isLoggedIn)
                {
                    notLoggedIn();
                }
                else
                {
                    loggedIn();
                }
            }
        }

        private void cbRecord_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedText = cbRecord.SelectedItem as string;
            if (cbRecord.SelectedIndex != -1)
            {
                if (selectedText.Equals("Rekordok törlése"))
                {
                    DialogResult dialogResult = MessageBox.Show("Biztosan törlöd a kijelölt recepteket?", "izé", MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.Yes)
                    {
                        ListView.SelectedListViewItemCollection recipes = lwRecipes.SelectedItems;
                        if (recipes.Count > 0)
                        {
                            using (var db = new RecipesModel.RecipesModel())
                            {
                                var user = db.AspNetUsers.Where(u => u.UserName.Equals(userName)).First();
                                var userID = user.Id;
                                foreach (ListViewItem recipe in recipes)
                                {
                                    if (recipe.Tag.Equals(userID))
                                    {
                                        var userRecipe = db.Recipes.Where(r => r.UserID.Equals(userID) && r.PictureUrl.Equals(recipe.SubItems[0])).First();
                                        db.Recipes.Remove(userRecipe);
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }

                else if (selectedText.Equals("Bejelentkezés"))
                {
                    this.Enabled = false;
                    LoginForm lf = new LoginForm(this);
                    lf.Show();
                }
            }
            cbRecord.SelectedIndex = -1;
        }

        private void lwRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lwRecipes.SelectedItems.Count > 0)
            {
                this.Enabled = false;
                RecipeDetails rd = new RecipeDetails(this, lwRecipes.SelectedItems);
                rd.Show();
            }
        }
    }
}
