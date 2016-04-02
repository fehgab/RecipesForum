namespace WF_RecipesClient
{
    partial class recipeClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.lwRecipes = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.chPicture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrepareTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIngredients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMenu
            // 
            this.gbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMenu.Controls.Add(this.label2);
            this.gbMenu.Controls.Add(this.label1);
            this.gbMenu.Controls.Add(this.cbUser);
            this.gbMenu.Controls.Add(this.btSearch);
            this.gbMenu.Controls.Add(this.tbSearch);
            this.gbMenu.Controls.Add(this.cbCategories);
            this.gbMenu.Location = new System.Drawing.Point(12, 12);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(560, 61);
            this.gbMenu.TabIndex = 0;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Menü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Felhasználó:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategóriák:";
            // 
            // cbUser
            // 
            this.cbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(433, 32);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(121, 21);
            this.cbUser.TabIndex = 3;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(305, 31);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "Keresés";
            this.btSearch.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(134, 32);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(164, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Text = "Étel neve";
            // 
            // cbCategories
            // 
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(7, 32);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(121, 21);
            this.cbCategories.TabIndex = 0;
            // 
            // lwRecipes
            // 
            this.lwRecipes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwRecipes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPicture,
            this.chTitle,
            this.chPrepareTime,
            this.chIngredients});
            this.lwRecipes.Location = new System.Drawing.Point(12, 79);
            this.lwRecipes.Name = "lwRecipes";
            this.lwRecipes.Size = new System.Drawing.Size(560, 256);
            this.lwRecipes.TabIndex = 1;
            this.lwRecipes.UseCompatibleStateImageBehavior = false;
            this.lwRecipes.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // chPicture
            // 
            this.chPicture.Text = "Kép";
            this.chPicture.Width = 150;
            // 
            // chTitle
            // 
            this.chTitle.Text = "Étel neve";
            this.chTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTitle.Width = 100;
            // 
            // chPrepareTime
            // 
            this.chPrepareTime.Text = "Elkészítési idő";
            this.chPrepareTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPrepareTime.Width = 120;
            // 
            // chIngredients
            // 
            this.chIngredients.Text = "Hozzávalók";
            this.chIngredients.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chIngredients.Width = 110;
            // 
            // recipeClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lwRecipes);
            this.Controls.Add(this.gbMenu);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "recipeClientForm";
            this.Text = "Recept kliens";
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lwRecipes;
        private System.Windows.Forms.ColumnHeader chPicture;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chPrepareTime;
        private System.Windows.Forms.ColumnHeader chIngredients;
    }
}

