namespace Project_DSiIS
{
    partial class HomePageForm
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
            tabControlHomePage = new TabControl();
            tabPage1 = new TabPage();
            labelGreetingUser = new Label();
            buttonShowUser = new Button();
            dataGridViewShowUser = new DataGridView();
            tabPage2 = new TabPage();
            tabControlHomePage.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowUser).BeginInit();
            SuspendLayout();
            // 
            // tabControlHomePage
            // 
            tabControlHomePage.Controls.Add(tabPage1);
            tabControlHomePage.Controls.Add(tabPage2);
            tabControlHomePage.Location = new Point(6, 10);
            tabControlHomePage.Name = "tabControlHomePage";
            tabControlHomePage.SelectedIndex = 0;
            tabControlHomePage.Size = new Size(943, 428);
            tabControlHomePage.TabIndex = 1;
            tabControlHomePage.SelectedIndexChanged += tabControlHomePage_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(labelGreetingUser);
            tabPage1.Controls.Add(buttonShowUser);
            tabPage1.Controls.Add(dataGridViewShowUser);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(935, 400);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Xem thông tin user";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelGreetingUser
            // 
            labelGreetingUser.AutoSize = true;
            labelGreetingUser.Location = new Point(530, 21);
            labelGreetingUser.Name = "labelGreetingUser";
            labelGreetingUser.Size = new Size(0, 15);
            labelGreetingUser.TabIndex = 2;
            // 
            // buttonShowUser
            // 
            buttonShowUser.Location = new Point(26, 6);
            buttonShowUser.Name = "buttonShowUser";
            buttonShowUser.Size = new Size(103, 30);
            buttonShowUser.TabIndex = 1;
            buttonShowUser.Text = "Xem User";
            buttonShowUser.UseVisualStyleBackColor = true;
            buttonShowUser.Click += buttonShowUser_Click;
            // 
            // dataGridViewShowUser
            // 
            dataGridViewShowUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShowUser.Location = new Point(14, 45);
            dataGridViewShowUser.Name = "dataGridViewShowUser";
            dataGridViewShowUser.RowTemplate.Height = 25;
            dataGridViewShowUser.Size = new Size(858, 349);
            dataGridViewShowUser.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(935, 400);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Xem thông tin về quyền";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 450);
            Controls.Add(tabControlHomePage);
            Name = "HomePageForm";
            Text = "HomePageForm";
            tabControlHomePage.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlHomePage;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridViewShowUser;
        private Button buttonShowUser;
        private Label labelGreetingUser;
    }
}