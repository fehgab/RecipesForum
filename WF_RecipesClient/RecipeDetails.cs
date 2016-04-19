using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebPPublished.Helpers;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    public partial class RecipeDetailsForm : Form
    {
        recipeClientForm mainWindow;
        ListView.SelectedListViewItemCollection selectedRecipe;

        Recipes currentRecipe = null;

        public RecipeDetailsForm(recipeClientForm mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();

            using (var db = new RecipesModel.RecipesModel())
            {
                var allCategories = db.Categories.ToList();
                foreach (var category in allCategories)
                {
                    cbCategory.Items.Add(category.DisplayName);
                }
            }
        }

        public RecipeDetailsForm(recipeClientForm mainWindow, ListView.SelectedListViewItemCollection selectedRecipe)
        {
            this.mainWindow = mainWindow;
            this.selectedRecipe = selectedRecipe;
            InitializeComponent();

            foreach (ListViewItem recipe in selectedRecipe)
            {
                string title = recipe.SubItems[1].Text;
                string recipeId = recipe.Tag.ToString();
                tbTitle.Text = title;
                tbFilePath.Text = recipe.SubItems[0].Text;
                tbPrepareTime.Text = recipe.SubItems[3].Text;
                tbIngredients.Text = recipe.SubItems[2].Text;

                using (var db = new RecipesModel.RecipesModel())
                {
                    var allCategories = db.Categories.ToList();
                    foreach (var category in allCategories)
                    {
                        cbCategory.Items.Add(category.DisplayName);
                    }
                    currentRecipe = db.Recipes.Where(r => r.ID.ToString() == recipeId).First();
                    var CurrentCategory = currentRecipe.Categories.DisplayName as string;
                    cbCategory.SelectedItem = CurrentCategory;
                    tbHowToPrepare.Text = currentRecipe.HowToPrepare;
                }
            }
        }

        private void RecipeDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (RecipeValidation())
            {
                using (var db = new RecipesModel.RecipesModel())
                {
                    if(currentRecipe != null)
                    {
                        currentRecipe.Title = tbTitle.Text;
                        db.Recipes.Attach(currentRecipe);
                        currentRecipe.Ingredients = tbIngredients.Text;
                        db.Recipes.Attach(currentRecipe);
                        currentRecipe.PrepareTime = tbPrepareTime.Text;
                        db.Recipes.Attach(currentRecipe);
                        currentRecipe.CategoryID = db.Categories.Where(c => c.DisplayName == cbCategory.SelectedItem.ToString()).First().Id;
                        db.Recipes.Attach(currentRecipe);
                        currentRecipe.HowToPrepare = tbHowToPrepare.Text;
                        db.Recipes.Attach(currentRecipe);
                    }
                    else
                    {
                        currentRecipe = new Recipes();
                        currentRecipe.Title = tbTitle.Text;
                        currentRecipe.Ingredients = tbIngredients.Text;
                        currentRecipe.PrepareTime = tbPrepareTime.Text;
                        currentRecipe.CategoryID = db.Categories.Where(c => c.DisplayName == cbCategory.SelectedItem.ToString()).First().Id;
                        currentRecipe.HowToPrepare = tbHowToPrepare.Text;
                        currentRecipe.UserID = db.AspNetUsers.Where(u => u.UserName == "Admin").First().Id;
                        currentRecipe.FriendlyUrl = FriendlyUrlHelper.RemoveDiacritics(tbTitle.Text);
                        currentRecipe.PictureUrl = "";
                        db.Recipes.Add(currentRecipe);
                    }
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException err)
                    {
                        foreach (var eve in err.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                    ve.PropertyName,
                                    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                    ve.ErrorMessage);
                            }
                        }
                    }
                }
                this.Close();
            }
            else
            {
                this.Size = new Size(800, this.Height);
                this.Enabled = true;
            }
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Kép kereső";
            fileDialog.Filter = "Képek|*.png; *.jpg; *.bmp; *.gif";
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                tbFilePath.Text = fileDialog.FileName;
            }
        }
    }
}
