namespace Project_DSiIS
{
    partial class HomePageUser
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
            panel1 = new Panel();
            buttonSelectPB = new Button();
            buttonSelectDA = new Button();
            buttonSelectPC = new Button();
            buttonSlectNV = new Button();
            dataGridViewInfor = new DataGridView();
            tabPage2 = new TabPage();
            buttonClear = new Button();
            tabControlHomePage.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInfor).BeginInit();
            SuspendLayout();
            // 
            // tabControlHomePage
            // 
            tabControlHomePage.Controls.Add(tabPage1);
            tabControlHomePage.Controls.Add(tabPage2);
            tabControlHomePage.Location = new Point(0, 0);
            tabControlHomePage.Name = "tabControlHomePage";
            tabControlHomePage.SelectedIndex = 0;
            tabControlHomePage.Size = new Size(798, 448);
            tabControlHomePage.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(dataGridViewInfor);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(790, 420);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonClear);
            panel1.Controls.Add(buttonSelectPB);
            panel1.Controls.Add(buttonSelectDA);
            panel1.Controls.Add(buttonSelectPC);
            panel1.Controls.Add(buttonSlectNV);
            panel1.Location = new Point(8, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(658, 39);
            panel1.TabIndex = 2;
            // 
            // buttonSelectPB
            // 
            buttonSelectPB.Location = new Point(327, 0);
            buttonSelectPB.Name = "buttonSelectPB";
            buttonSelectPB.Size = new Size(84, 39);
            buttonSelectPB.TabIndex = 4;
            buttonSelectPB.Text = "Thông tin  phòng ban";
            buttonSelectPB.UseVisualStyleBackColor = true;
            buttonSelectPB.Click += buttonSelectPB_Click;
            // 
            // buttonSelectDA
            // 
            buttonSelectDA.Location = new Point(218, 0);
            buttonSelectDA.Name = "buttonSelectDA";
            buttonSelectDA.Size = new Size(84, 39);
            buttonSelectDA.TabIndex = 3;
            buttonSelectDA.Text = "Thông tin  đề án";
            buttonSelectDA.UseVisualStyleBackColor = true;
            buttonSelectDA.Click += buttonSelectDA_Click;
            // 
            // buttonSelectPC
            // 
            buttonSelectPC.Location = new Point(109, 0);
            buttonSelectPC.Name = "buttonSelectPC";
            buttonSelectPC.Size = new Size(84, 39);
            buttonSelectPC.TabIndex = 2;
            buttonSelectPC.Text = "Thông tin phân công\r\n";
            buttonSelectPC.UseVisualStyleBackColor = true;
            buttonSelectPC.Click += buttonSelectPC_Click;
            // 
            // buttonSlectNV
            // 
            buttonSlectNV.Location = new Point(5, 0);
            buttonSlectNV.Name = "buttonSlectNV";
            buttonSlectNV.Size = new Size(84, 39);
            buttonSlectNV.TabIndex = 1;
            buttonSlectNV.Text = "Thông tin nhân viên\r\n";
            buttonSlectNV.UseVisualStyleBackColor = true;
            buttonSlectNV.Click += buttonSlectNV_Click;
            // 
            // dataGridViewInfor
            // 
            dataGridViewInfor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInfor.Location = new Point(6, 88);
            dataGridViewInfor.Name = "dataGridViewInfor";
            dataGridViewInfor.RowTemplate.Height = 25;
            dataGridViewInfor.Size = new Size(655, 326);
            dataGridViewInfor.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(790, 420);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(433, 0);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(93, 39);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // HomePageUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlHomePage);
            Name = "HomePageUser";
            Text = "Trang chủ";
            tabControlHomePage.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewInfor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlHomePage;
        private TabPage tabPage1;
        private Button buttonSlectNV;
        private DataGridView dataGridViewInfor;
        private TabPage tabPage2;
        private Panel panel1;
        private Button buttonSelectPB;
        private Button buttonSelectDA;
        private Button buttonSelectPC;
        private Button buttonClear;
    }
}