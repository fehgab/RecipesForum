namespace WF_RecipesClient
{
    partial class RecipeDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeDetailsForm));
            this.lPrepareTimeError = new System.Windows.Forms.Label();
            this.lIngredientsError = new System.Windows.Forms.Label();
            this.lCategoryError = new System.Windows.Forms.Label();
            this.lTitleError = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPrepareTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIngredients = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbHowToPrepare = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lHowToPrepareError = new System.Windows.Forms.Label();
            this.btnUploadPicture = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.lFileMissingError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lPrepareTimeError
            // 
            resources.ApplyResources(this.lPrepareTimeError, "lPrepareTimeError");
            this.lPrepareTimeError.ForeColor = System.Drawing.Color.DarkRed;
            this.lPrepareTimeError.Name = "lPrepareTimeError";
            // 
            // lIngredientsError
            // 
            resources.ApplyResources(this.lIngredientsError, "lIngredientsError");
            this.lIngredientsError.ForeColor = System.Drawing.Color.DarkRed;
            this.lIngredientsError.Name = "lIngredientsError";
            // 
            // lCategoryError
            // 
            resources.ApplyResources(this.lCategoryError, "lCategoryError");
            this.lCategoryError.ForeColor = System.Drawing.Color.DarkRed;
            this.lCategoryError.Name = "lCategoryError";
            // 
            // lTitleError
            // 
            resources.ApplyResources(this.lTitleError, "lTitleError");
            this.lTitleError.ForeColor = System.Drawing.Color.DarkRed;
            this.lTitleError.Name = "lTitleError";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPrepareTime
            // 
            resources.ApplyResources(this.tbPrepareTime, "tbPrepareTime");
            this.tbPrepareTime.Name = "tbPrepareTime";
            this.tbPrepareTime.Validating += new System.ComponentModel.CancelEventHandler(this.tbPrepareTime_Validating);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbIngredients
            // 
            resources.ApplyResources(this.tbIngredients, "tbIngredients");
            this.tbIngredients.Name = "tbIngredients";
            this.tbIngredients.Validating += new System.ComponentModel.CancelEventHandler(this.tbIngredients_Validating);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbTitle
            // 
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Validating += new System.ComponentModel.CancelEventHandler(this.tbTitle_Validating);
            // 
            // cbCategory
            // 
            resources.ApplyResources(this.cbCategory, "cbCategory");
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cbCategory_Validating);
            // 
            // tbHowToPrepare
            // 
            resources.ApplyResources(this.tbHowToPrepare, "tbHowToPrepare");
            this.tbHowToPrepare.Name = "tbHowToPrepare";
            this.tbHowToPrepare.Validating += new System.ComponentModel.CancelEventHandler(this.tbHowToPrepare_Validating);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lHowToPrepareError
            // 
            resources.ApplyResources(this.lHowToPrepareError, "lHowToPrepareError");
            this.lHowToPrepareError.ForeColor = System.Drawing.Color.DarkRed;
            this.lHowToPrepareError.Name = "lHowToPrepareError";
            // 
            // btnUploadPicture
            // 
            resources.ApplyResources(this.btnUploadPicture, "btnUploadPicture");
            this.btnUploadPicture.Name = "btnUploadPicture";
            this.btnUploadPicture.UseVisualStyleBackColor = true;
            this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
            // 
            // tbFilePath
            // 
            resources.ApplyResources(this.tbFilePath, "tbFilePath");
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.tbFilePath_Validating);
            // 
            // lFileMissingError
            // 
            resources.ApplyResources(this.lFileMissingError, "lFileMissingError");
            this.lFileMissingError.ForeColor = System.Drawing.Color.DarkRed;
            this.lFileMissingError.Name = "lFileMissingError";
            // 
            // RecipeDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lFileMissingError);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.btnUploadPicture);
            this.Controls.Add(this.lHowToPrepareError);
            this.Controls.Add(this.tbHowToPrepare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.lPrepareTimeError);
            this.Controls.Add(this.lIngredientsError);
            this.Controls.Add(this.lCategoryError);
            this.Controls.Add(this.lTitleError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbPrepareTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbIngredients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label1);
            this.Name = "RecipeDetailsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecipeDetails_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lPrepareTimeError;
        private System.Windows.Forms.Label lIngredientsError;
        private System.Windows.Forms.Label lCategoryError;
        private System.Windows.Forms.Label lTitleError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPrepareTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIngredients;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbHowToPrepare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lHowToPrepareError;
        private System.Windows.Forms.Button btnUploadPicture;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Label lFileMissingError;
    }
}