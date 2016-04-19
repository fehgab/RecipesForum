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
            this.lPrepareTimeError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lPrepareTimeError.AutoSize = true;
            this.lPrepareTimeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrepareTimeError.ForeColor = System.Drawing.Color.DarkRed;
            this.lPrepareTimeError.Location = new System.Drawing.Point(339, 153);
            this.lPrepareTimeError.Name = "lPrepareTimeError";
            this.lPrepareTimeError.Size = new System.Drawing.Size(0, 13);
            this.lPrepareTimeError.TabIndex = 27;
            // 
            // lIngredientsError
            // 
            this.lIngredientsError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lIngredientsError.AutoSize = true;
            this.lIngredientsError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lIngredientsError.ForeColor = System.Drawing.Color.DarkRed;
            this.lIngredientsError.Location = new System.Drawing.Point(339, 127);
            this.lIngredientsError.Name = "lIngredientsError";
            this.lIngredientsError.Size = new System.Drawing.Size(0, 13);
            this.lIngredientsError.TabIndex = 26;
            // 
            // lCategoryError
            // 
            this.lCategoryError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lCategoryError.AutoSize = true;
            this.lCategoryError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCategoryError.ForeColor = System.Drawing.Color.DarkRed;
            this.lCategoryError.Location = new System.Drawing.Point(339, 101);
            this.lCategoryError.Name = "lCategoryError";
            this.lCategoryError.Size = new System.Drawing.Size(0, 13);
            this.lCategoryError.TabIndex = 25;
            // 
            // lTitleError
            // 
            this.lTitleError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lTitleError.AutoSize = true;
            this.lTitleError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTitleError.ForeColor = System.Drawing.Color.DarkRed;
            this.lTitleError.Location = new System.Drawing.Point(339, 75);
            this.lTitleError.Name = "lTitleError";
            this.lTitleError.Size = new System.Drawing.Size(0, 13);
            this.lTitleError.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(128, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 26);
            this.label5.TabIndex = 23;
            this.label5.Text = "A recept módosítása";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(258, 268);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Mentés";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbPrepareTime
            // 
            this.tbPrepareTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPrepareTime.Location = new System.Drawing.Point(164, 150);
            this.tbPrepareTime.Name = "tbPrepareTime";
            this.tbPrepareTime.Size = new System.Drawing.Size(169, 20);
            this.tbPrepareTime.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Elkészítési idő";
            // 
            // tbIngredients
            // 
            this.tbIngredients.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbIngredients.Location = new System.Drawing.Point(164, 124);
            this.tbIngredients.Name = "tbIngredients";
            this.tbIngredients.Size = new System.Drawing.Size(169, 20);
            this.tbIngredients.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Hozzávalók";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Kategória";
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbTitle.Location = new System.Drawing.Point(164, 72);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(169, 20);
            this.tbTitle.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Étel neve";
            // 
            // cbCategory
            // 
            this.cbCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(165, 98);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(168, 21);
            this.cbCategory.TabIndex = 28;
            // 
            // tbHowToPrepare
            // 
            this.tbHowToPrepare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbHowToPrepare.Location = new System.Drawing.Point(164, 176);
            this.tbHowToPrepare.Multiline = true;
            this.tbHowToPrepare.Name = "tbHowToPrepare";
            this.tbHowToPrepare.Size = new System.Drawing.Size(169, 60);
            this.tbHowToPrepare.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Elkészítés";
            // 
            // lHowToPrepareError
            // 
            this.lHowToPrepareError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lHowToPrepareError.AutoSize = true;
            this.lHowToPrepareError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHowToPrepareError.ForeColor = System.Drawing.Color.DarkRed;
            this.lHowToPrepareError.Location = new System.Drawing.Point(339, 199);
            this.lHowToPrepareError.Name = "lHowToPrepareError";
            this.lHowToPrepareError.Size = new System.Drawing.Size(0, 13);
            this.lHowToPrepareError.TabIndex = 31;
            // 
            // btnUploadPicture
            // 
            this.btnUploadPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUploadPicture.Location = new System.Drawing.Point(164, 268);
            this.btnUploadPicture.Name = "btnUploadPicture";
            this.btnUploadPicture.Size = new System.Drawing.Size(87, 23);
            this.btnUploadPicture.TabIndex = 32;
            this.btnUploadPicture.Text = "Kép csatolása";
            this.btnUploadPicture.UseVisualStyleBackColor = true;
            this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbFilePath.Enabled = false;
            this.tbFilePath.Location = new System.Drawing.Point(164, 242);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(169, 20);
            this.tbFilePath.TabIndex = 33;
            // 
            // lFileMissingError
            // 
            this.lFileMissingError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lFileMissingError.AutoSize = true;
            this.lFileMissingError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFileMissingError.ForeColor = System.Drawing.Color.DarkRed;
            this.lFileMissingError.Location = new System.Drawing.Point(339, 248);
            this.lFileMissingError.Name = "lFileMissingError";
            this.lFileMissingError.Size = new System.Drawing.Size(0, 13);
            this.lFileMissingError.TabIndex = 35;
            // 
            // RecipeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 359);
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
            this.Text = "RecipeDetails";
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