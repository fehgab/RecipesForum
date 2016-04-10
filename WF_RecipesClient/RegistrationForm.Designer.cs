namespace WF_RecipesClient
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbDisplayName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lDisplayNameError = new System.Windows.Forms.Label();
            this.lEmailError = new System.Windows.Forms.Label();
            this.lPasswordError = new System.Windows.Forms.Label();
            this.lConfirmPasswordError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Név";
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDisplayName.Location = new System.Drawing.Point(147, 78);
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.Size = new System.Drawing.Size(169, 20);
            this.tbDisplayName.TabIndex = 1;
            // 
            // tbEmail
            // 
            this.tbEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbEmail.Location = new System.Drawing.Point(147, 104);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(169, 20);
            this.tbEmail.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-mail";
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPassword.Location = new System.Drawing.Point(147, 130);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(169, 20);
            this.tbPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Jelszó";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbConfirmPassword.Location = new System.Drawing.Point(147, 156);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(169, 20);
            this.tbConfirmPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Jelszó újra";
            // 
            // btnRegistration
            // 
            this.btnRegistration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistration.Location = new System.Drawing.Point(241, 182);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(75, 23);
            this.btnRegistration.TabIndex = 8;
            this.btnRegistration.Text = "Regisztráció";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(38, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(356, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Regisztárció a recept alkalmazásba";
            // 
            // lDisplayNameError
            // 
            this.lDisplayNameError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lDisplayNameError.AutoSize = true;
            this.lDisplayNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDisplayNameError.ForeColor = System.Drawing.Color.DarkRed;
            this.lDisplayNameError.Location = new System.Drawing.Point(322, 81);
            this.lDisplayNameError.Name = "lDisplayNameError";
            this.lDisplayNameError.Size = new System.Drawing.Size(0, 13);
            this.lDisplayNameError.TabIndex = 10;
            // 
            // lEmailError
            // 
            this.lEmailError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lEmailError.AutoSize = true;
            this.lEmailError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lEmailError.ForeColor = System.Drawing.Color.DarkRed;
            this.lEmailError.Location = new System.Drawing.Point(322, 107);
            this.lEmailError.Name = "lEmailError";
            this.lEmailError.Size = new System.Drawing.Size(0, 13);
            this.lEmailError.TabIndex = 11;
            // 
            // lPasswordError
            // 
            this.lPasswordError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lPasswordError.AutoSize = true;
            this.lPasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPasswordError.ForeColor = System.Drawing.Color.DarkRed;
            this.lPasswordError.Location = new System.Drawing.Point(322, 133);
            this.lPasswordError.Name = "lPasswordError";
            this.lPasswordError.Size = new System.Drawing.Size(0, 13);
            this.lPasswordError.TabIndex = 12;
            // 
            // lConfirmPasswordError
            // 
            this.lConfirmPasswordError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lConfirmPasswordError.AutoSize = true;
            this.lConfirmPasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lConfirmPasswordError.ForeColor = System.Drawing.Color.DarkRed;
            this.lConfirmPasswordError.Location = new System.Drawing.Point(322, 159);
            this.lConfirmPasswordError.Name = "lConfirmPasswordError";
            this.lConfirmPasswordError.Size = new System.Drawing.Size(0, 13);
            this.lConfirmPasswordError.TabIndex = 13;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.lConfirmPasswordError);
            this.Controls.Add(this.lPasswordError);
            this.Controls.Add(this.lEmailError);
            this.Controls.Add(this.lDisplayNameError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDisplayName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.Text = "Regisztráció";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistrationForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDisplayName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lDisplayNameError;
        private System.Windows.Forms.Label lEmailError;
        private System.Windows.Forms.Label lPasswordError;
        private System.Windows.Forms.Label lConfirmPasswordError;
    }
}