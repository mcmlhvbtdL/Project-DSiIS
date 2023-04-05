namespace Project_DSiIS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelLogin = new Panel();
            checkBoxShowPassword = new CheckBox();
            buttonSignIn = new Button();
            textBoxPassword = new TextBox();
            labelPassword = new Label();
            textBoxUserName = new TextBox();
            labelUserName = new Label();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(checkBoxShowPassword);
            panelLogin.Controls.Add(buttonSignIn);
            panelLogin.Controls.Add(textBoxPassword);
            panelLogin.Controls.Add(labelPassword);
            panelLogin.Controls.Add(textBoxUserName);
            panelLogin.Controls.Add(labelUserName);
            panelLogin.Location = new Point(12, 12);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(470, 302);
            panelLogin.TabIndex = 0;
            // 
            // checkBoxShowPassword
            // 
            checkBoxShowPassword.AutoSize = true;
            checkBoxShowPassword.Location = new Point(360, 157);
            checkBoxShowPassword.Name = "checkBoxShowPassword";
            checkBoxShowPassword.Size = new Size(108, 19);
            checkBoxShowPassword.TabIndex = 4;
            checkBoxShowPassword.Text = "Show Password";
            checkBoxShowPassword.UseVisualStyleBackColor = true;
            checkBoxShowPassword.CheckedChanged += checkBoxShowPassword_CheckedChanged;
            // 
            // buttonSignIn
            // 
            buttonSignIn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonSignIn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonSignIn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSignIn.Location = new Point(157, 213);
            buttonSignIn.Name = "buttonSignIn";
            buttonSignIn.Size = new Size(122, 34);
            buttonSignIn.TabIndex = 3;
            buttonSignIn.Text = "Sign In";
            buttonSignIn.UseVisualStyleBackColor = true;
            buttonSignIn.Click += buttonSignIn_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(157, 155);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(196, 23);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.Location = new Point(54, 155);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(91, 25);
            labelPassword.TabIndex = 0;
            labelPassword.Text = "Password";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(157, 116);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(196, 23);
            textBoxUserName.TabIndex = 1;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelUserName.Location = new Point(54, 116);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(97, 25);
            labelUserName.TabIndex = 0;
            labelUserName.Text = "Username";
            // 
            // Form1
            // 
            AcceptButton = buttonSignIn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(489, 321);
            Controls.Add(panelLogin);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private Label labelUserName;
        private TextBox textBoxPassword;
        private Label labelPassword;
        private TextBox textBoxUserName;
        private Button buttonSignIn;
        private CheckBox checkBoxShowPassword;
    }
}