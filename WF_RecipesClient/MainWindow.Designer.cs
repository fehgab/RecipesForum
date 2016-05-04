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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(recipeClientForm));
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.btChangeLanguage = new System.Windows.Forms.Button();
            this.btnNewRecord = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.lRecord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.lwRecipes = new System.Windows.Forms.ListView();
            this.chPicture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrepareTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIngredients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lBottomLogo = new System.Windows.Forms.Label();
            this.gbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMenu
            // 
            resources.ApplyResources(this.gbMenu, "gbMenu");
            this.gbMenu.Controls.Add(this.btChangeLanguage);
            this.gbMenu.Controls.Add(this.btnNewRecord);
            this.gbMenu.Controls.Add(this.btnDeleteRecord);
            this.gbMenu.Controls.Add(this.lRecord);
            this.gbMenu.Controls.Add(this.label1);
            this.gbMenu.Controls.Add(this.btSearch);
            this.gbMenu.Controls.Add(this.tbSearch);
            this.gbMenu.Controls.Add(this.cbCategories);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.TabStop = false;
            // 
            // btChangeLanguage
            // 
            resources.ApplyResources(this.btChangeLanguage, "btChangeLanguage");
            this.btChangeLanguage.Name = "btChangeLanguage";
            this.btChangeLanguage.UseVisualStyleBackColor = true;
            this.btChangeLanguage.Click += new System.EventHandler(this.btChangeLanguage_Click);
            // 
            // btnNewRecord
            // 
            resources.ApplyResources(this.btnNewRecord, "btnNewRecord");
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.UseVisualStyleBackColor = true;
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // btnDeleteRecord
            // 
            resources.ApplyResources(this.btnDeleteRecord, "btnDeleteRecord");
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.brnDeleteRecord_Click);
            // 
            // lRecord
            // 
            resources.ApplyResources(this.lRecord, "lRecord");
            this.lRecord.Name = "lRecord";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btSearch
            // 
            resources.ApplyResources(this.btSearch, "btSearch");
            this.btSearch.Name = "btSearch";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbSearch
            // 
            resources.ApplyResources(this.tbSearch, "tbSearch");
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // cbCategories
            // 
            resources.ApplyResources(this.cbCategories, "cbCategories");
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.SelectedValueChanged += new System.EventHandler(this.cbCategories_SelectedValueChanged);
            // 
            // lwRecipes
            // 
            resources.ApplyResources(this.lwRecipes, "lwRecipes");
            this.lwRecipes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPicture,
            this.chTitle,
            this.chPrepareTime,
            this.chIngredients});
            this.lwRecipes.FullRowSelect = true;
            this.lwRecipes.Name = "lwRecipes";
            this.lwRecipes.UseCompatibleStateImageBehavior = false;
            this.lwRecipes.View = System.Windows.Forms.View.Details;
            this.lwRecipes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lwRecipes_ColumnClick);
            this.lwRecipes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lwRecipes_MouseDoubleClick);
            // 
            // chPicture
            // 
            resources.ApplyResources(this.chPicture, "chPicture");
            // 
            // chTitle
            // 
            resources.ApplyResources(this.chTitle, "chTitle");
            // 
            // chPrepareTime
            // 
            resources.ApplyResources(this.chPrepareTime, "chPrepareTime");
            // 
            // chIngredients
            // 
            resources.ApplyResources(this.chIngredients, "chIngredients");
            // 
            // lBottomLogo
            // 
            resources.ApplyResources(this.lBottomLogo, "lBottomLogo");
            this.lBottomLogo.Name = "lBottomLogo";
            // 
            // recipeClientForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lBottomLogo);
            this.Controls.Add(this.lwRecipes);
            this.Controls.Add(this.gbMenu);
            this.Name = "recipeClientForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.recipeClientForm_Load);
            this.EnabledChanged += new System.EventHandler(this.recipeClientForm_EnabledChanged);
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Label lBottomLogo;
        private System.Windows.Forms.ListView lwRecipes;
        private System.Windows.Forms.ColumnHeader chPicture;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chPrepareTime;
        private System.Windows.Forms.ColumnHeader chIngredients;
        private System.Windows.Forms.Label lRecord;
        private System.Windows.Forms.Button btnNewRecord;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btChangeLanguage;
    }
}

