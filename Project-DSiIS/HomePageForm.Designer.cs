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
            labelSearchByUserName = new Label();
            textBoxSearchUserName = new TextBox();
            labelGreetingUser = new Label();
            buttonShowUser = new Button();
            dataGridViewShowUser = new DataGridView();
            tabPage2 = new TabPage();
            tabControlPrivileges = new TabControl();
            tabPageUser = new TabPage();
            dataGridViewPrivilUser = new DataGridView();
            tabPageRole = new TabPage();
            dataGridViewRoles = new DataGridView();
            tabPage3 = new TabPage();
            tabControl1 = new TabControl();
            tabPageCreateUser = new TabPage();
            panel2 = new Panel();
            buttonClearDataCreateUser = new Button();
            label2 = new Label();
            dataGridViewCreateUser = new DataGridView();
            panel1 = new Panel();
            textBoxCreateUsernameConfirmPassword = new TextBox();
            labelConfirmPassword = new Label();
            buttionCreateUser = new Button();
            checkBoxGrantCreateSession = new CheckBox();
            textBoxCreateUserPassword = new TextBox();
            labelCreateUserPassword = new Label();
            label1 = new Label();
            textBoxCreateUserUsername = new TextBox();
            labelUsernameCreateUser = new Label();
            tabPageDeleteUser = new TabPage();
            label4 = new Label();
            textBoxDropUser2 = new TextBox();
            label3 = new Label();
            buttonListUser = new Button();
            dataGridViewListUser = new DataGridView();
            panelRemoveUser = new Panel();
            buttonDropUser = new Button();
            checkBoxDropUser = new CheckBox();
            label5 = new Label();
            textBoxDropUser = new TextBox();
            labelDropUser = new Label();
            tabPageUpdateUser = new TabPage();
            tabPageGrantUser = new TabPage();
            tabPageRevokeUser = new TabPage();
            tabPageEditUser = new TabPage();
            tabPage4 = new TabPage();
            tabControl2 = new TabControl();
            tabPageCreateRole = new TabPage();
            tabPageDeleteRole = new TabPage();
            tabPageUpdateRole = new TabPage();
            tabPageGrantRole = new TabPage();
            tabPageRevokeRole = new TabPage();
            tabPageEditRole = new TabPage();
            tabControlHomePage.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowUser).BeginInit();
            tabPage2.SuspendLayout();
            tabControlPrivileges.SuspendLayout();
            tabPageUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrivilUser).BeginInit();
            tabPageRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).BeginInit();
            tabPage3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageCreateUser.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCreateUser).BeginInit();
            panel1.SuspendLayout();
            tabPageDeleteUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListUser).BeginInit();
            panelRemoveUser.SuspendLayout();
            tabPage4.SuspendLayout();
            tabControl2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlHomePage
            // 
            tabControlHomePage.Controls.Add(tabPage1);
            tabControlHomePage.Controls.Add(tabPage2);
            tabControlHomePage.Controls.Add(tabPage3);
            tabControlHomePage.Controls.Add(tabPage4);
            tabControlHomePage.Location = new Point(6, 10);
            tabControlHomePage.Name = "tabControlHomePage";
            tabControlHomePage.SelectedIndex = 0;
            tabControlHomePage.Size = new Size(943, 428);
            tabControlHomePage.TabIndex = 1;
            tabControlHomePage.SelectedIndexChanged += tabControlHomePage_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(labelSearchByUserName);
            tabPage1.Controls.Add(textBoxSearchUserName);
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
            // labelSearchByUserName
            // 
            labelSearchByUserName.AutoSize = true;
            labelSearchByUserName.Location = new Point(145, 14);
            labelSearchByUserName.Margin = new Padding(2, 0, 2, 0);
            labelSearchByUserName.Name = "labelSearchByUserName";
            labelSearchByUserName.Size = new Size(114, 15);
            labelSearchByUserName.TabIndex = 4;
            labelSearchByUserName.Text = "Search by Username";
            // 
            // textBoxSearchUserName
            // 
            textBoxSearchUserName.Location = new Point(270, 12);
            textBoxSearchUserName.Margin = new Padding(2);
            textBoxSearchUserName.Name = "textBoxSearchUserName";
            textBoxSearchUserName.Size = new Size(171, 23);
            textBoxSearchUserName.TabIndex = 3;
            textBoxSearchUserName.MouseClick += textBoxSearchUserName_MouseClick;
            textBoxSearchUserName.TextChanged += textBoxSearchUserName_TextChanged;
            // 
            // labelGreetingUser
            // 
            labelGreetingUser.AutoSize = true;
            labelGreetingUser.Location = new Point(531, 21);
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
            dataGridViewShowUser.RowHeadersWidth = 62;
            dataGridViewShowUser.RowTemplate.Height = 25;
            dataGridViewShowUser.Size = new Size(858, 349);
            dataGridViewShowUser.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tabControlPrivileges);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(935, 400);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Xem thông tin về quyền";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControlPrivileges
            // 
            tabControlPrivileges.Controls.Add(tabPageUser);
            tabControlPrivileges.Controls.Add(tabPageRole);
            tabControlPrivileges.Location = new Point(0, 0);
            tabControlPrivileges.Margin = new Padding(2);
            tabControlPrivileges.Name = "tabControlPrivileges";
            tabControlPrivileges.SelectedIndex = 0;
            tabControlPrivileges.Size = new Size(932, 400);
            tabControlPrivileges.TabIndex = 0;
            // 
            // tabPageUser
            // 
            tabPageUser.Controls.Add(dataGridViewPrivilUser);
            tabPageUser.Location = new Point(4, 24);
            tabPageUser.Margin = new Padding(2);
            tabPageUser.Name = "tabPageUser";
            tabPageUser.Padding = new Padding(2);
            tabPageUser.Size = new Size(924, 372);
            tabPageUser.TabIndex = 0;
            tabPageUser.Text = "Theo User";
            tabPageUser.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPrivilUser
            // 
            dataGridViewPrivilUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrivilUser.Location = new Point(4, 38);
            dataGridViewPrivilUser.Margin = new Padding(2);
            dataGridViewPrivilUser.Name = "dataGridViewPrivilUser";
            dataGridViewPrivilUser.RowHeadersWidth = 62;
            dataGridViewPrivilUser.RowTemplate.Height = 33;
            dataGridViewPrivilUser.Size = new Size(884, 332);
            dataGridViewPrivilUser.TabIndex = 0;
            // 
            // tabPageRole
            // 
            tabPageRole.Controls.Add(dataGridViewRoles);
            tabPageRole.Location = new Point(4, 24);
            tabPageRole.Margin = new Padding(2);
            tabPageRole.Name = "tabPageRole";
            tabPageRole.Padding = new Padding(2);
            tabPageRole.Size = new Size(924, 372);
            tabPageRole.TabIndex = 1;
            tabPageRole.Text = "Theo Role";
            tabPageRole.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRoles
            // 
            dataGridViewRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoles.Location = new Point(4, 38);
            dataGridViewRoles.Margin = new Padding(2);
            dataGridViewRoles.Name = "dataGridViewRoles";
            dataGridViewRoles.RowHeadersWidth = 62;
            dataGridViewRoles.RowTemplate.Height = 33;
            dataGridViewRoles.Size = new Size(884, 332);
            dataGridViewRoles.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tabControl1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(935, 400);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Users";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageCreateUser);
            tabControl1.Controls.Add(tabPageDeleteUser);
            tabControl1.Controls.Add(tabPageUpdateUser);
            tabControl1.Controls.Add(tabPageGrantUser);
            tabControl1.Controls.Add(tabPageRevokeUser);
            tabControl1.Controls.Add(tabPageEditUser);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(929, 394);
            tabControl1.TabIndex = 0;
            // 
            // tabPageCreateUser
            // 
            tabPageCreateUser.Controls.Add(panel2);
            tabPageCreateUser.Controls.Add(panel1);
            tabPageCreateUser.Location = new Point(4, 24);
            tabPageCreateUser.Name = "tabPageCreateUser";
            tabPageCreateUser.Padding = new Padding(3);
            tabPageCreateUser.Size = new Size(921, 366);
            tabPageCreateUser.TabIndex = 0;
            tabPageCreateUser.Text = "Tạo User";
            tabPageCreateUser.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonClearDataCreateUser);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dataGridViewCreateUser);
            panel2.Location = new Point(6, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(603, 360);
            panel2.TabIndex = 9;
            // 
            // buttonClearDataCreateUser
            // 
            buttonClearDataCreateUser.Location = new Point(464, 327);
            buttonClearDataCreateUser.Name = "buttonClearDataCreateUser";
            buttonClearDataCreateUser.Size = new Size(125, 24);
            buttonClearDataCreateUser.TabIndex = 9;
            buttonClearDataCreateUser.Text = "Clear";
            buttonClearDataCreateUser.UseVisualStyleBackColor = true;
            buttonClearDataCreateUser.Click += buttonClearDataCreateUser_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(114, 17);
            label2.Name = "label2";
            label2.Size = new Size(347, 32);
            label2.TabIndex = 8;
            label2.Text = "Danh sách User vừa được tạo";
            // 
            // dataGridViewCreateUser
            // 
            dataGridViewCreateUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCreateUser.Location = new Point(3, 72);
            dataGridViewCreateUser.Name = "dataGridViewCreateUser";
            dataGridViewCreateUser.RowTemplate.Height = 25;
            dataGridViewCreateUser.Size = new Size(597, 249);
            dataGridViewCreateUser.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxCreateUsernameConfirmPassword);
            panel1.Controls.Add(labelConfirmPassword);
            panel1.Controls.Add(buttionCreateUser);
            panel1.Controls.Add(checkBoxGrantCreateSession);
            panel1.Controls.Add(textBoxCreateUserPassword);
            panel1.Controls.Add(labelCreateUserPassword);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxCreateUserUsername);
            panel1.Controls.Add(labelUsernameCreateUser);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(610, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(308, 360);
            panel1.TabIndex = 7;
            // 
            // textBoxCreateUsernameConfirmPassword
            // 
            textBoxCreateUsernameConfirmPassword.Location = new Point(122, 149);
            textBoxCreateUsernameConfirmPassword.Name = "textBoxCreateUsernameConfirmPassword";
            textBoxCreateUsernameConfirmPassword.Size = new Size(166, 23);
            textBoxCreateUsernameConfirmPassword.TabIndex = 3;
            textBoxCreateUsernameConfirmPassword.UseSystemPasswordChar = true;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelConfirmPassword.Location = new Point(19, 149);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(70, 68);
            labelConfirmPassword.TabIndex = 7;
            labelConfirmPassword.Text = "Confirm Password";
            // 
            // buttionCreateUser
            // 
            buttionCreateUser.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttionCreateUser.Location = new Point(140, 231);
            buttionCreateUser.Name = "buttionCreateUser";
            buttionCreateUser.Size = new Size(123, 36);
            buttionCreateUser.TabIndex = 5;
            buttionCreateUser.Text = "Tạo User";
            buttionCreateUser.UseVisualStyleBackColor = true;
            buttionCreateUser.Click += buttionCreateUser_Click;
            // 
            // checkBoxGrantCreateSession
            // 
            checkBoxGrantCreateSession.AutoSize = true;
            checkBoxGrantCreateSession.Location = new Point(122, 197);
            checkBoxGrantCreateSession.Name = "checkBoxGrantCreateSession";
            checkBoxGrantCreateSession.Size = new Size(155, 19);
            checkBoxGrantCreateSession.TabIndex = 4;
            checkBoxGrantCreateSession.Text = "GRANT CREATE SESSION";
            checkBoxGrantCreateSession.UseVisualStyleBackColor = true;
            // 
            // textBoxCreateUserPassword
            // 
            textBoxCreateUserPassword.Location = new Point(122, 113);
            textBoxCreateUserPassword.Name = "textBoxCreateUserPassword";
            textBoxCreateUserPassword.Size = new Size(166, 23);
            textBoxCreateUserPassword.TabIndex = 2;
            textBoxCreateUserPassword.UseSystemPasswordChar = true;
            // 
            // labelCreateUserPassword
            // 
            labelCreateUserPassword.AutoSize = true;
            labelCreateUserPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCreateUserPassword.Location = new Point(19, 116);
            labelCreateUserPassword.Name = "labelCreateUserPassword";
            labelCreateUserPassword.Size = new Size(70, 20);
            labelCreateUserPassword.TabIndex = 3;
            labelCreateUserPassword.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(67, 8);
            label1.Name = "label1";
            label1.Size = new Size(163, 32);
            label1.TabIndex = 2;
            label1.Text = "Tạo user mới";
            // 
            // textBoxCreateUserUsername
            // 
            textBoxCreateUserUsername.Location = new Point(122, 74);
            textBoxCreateUserUsername.Name = "textBoxCreateUserUsername";
            textBoxCreateUserUsername.Size = new Size(166, 23);
            textBoxCreateUserUsername.TabIndex = 1;
            // 
            // labelUsernameCreateUser
            // 
            labelUsernameCreateUser.AutoSize = true;
            labelUsernameCreateUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelUsernameCreateUser.Location = new Point(14, 77);
            labelUsernameCreateUser.Name = "labelUsernameCreateUser";
            labelUsernameCreateUser.Size = new Size(75, 20);
            labelUsernameCreateUser.TabIndex = 0;
            labelUsernameCreateUser.Text = "Username";
            // 
            // tabPageDeleteUser
            // 
            tabPageDeleteUser.Controls.Add(label4);
            tabPageDeleteUser.Controls.Add(textBoxDropUser2);
            tabPageDeleteUser.Controls.Add(label3);
            tabPageDeleteUser.Controls.Add(buttonListUser);
            tabPageDeleteUser.Controls.Add(dataGridViewListUser);
            tabPageDeleteUser.Controls.Add(panelRemoveUser);
            tabPageDeleteUser.Location = new Point(4, 24);
            tabPageDeleteUser.Name = "tabPageDeleteUser";
            tabPageDeleteUser.Padding = new Padding(3);
            tabPageDeleteUser.Size = new Size(921, 366);
            tabPageDeleteUser.TabIndex = 1;
            tabPageDeleteUser.Text = "Xoá User";
            tabPageDeleteUser.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(474, 24);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 13;
            label4.Text = "Search by Username";
            // 
            // textBoxDropUser2
            // 
            textBoxDropUser2.Location = new Point(308, 16);
            textBoxDropUser2.Name = "textBoxDropUser2";
            textBoxDropUser2.Size = new Size(160, 23);
            textBoxDropUser2.TabIndex = 12;
            textBoxDropUser2.TextChanged += textBoxDropUser2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.MenuHighlight;
            label3.Location = new Point(16, 7);
            label3.Name = "label3";
            label3.Size = new Size(187, 32);
            label3.TabIndex = 11;
            label3.Text = "Danh sách user";
            // 
            // buttonListUser
            // 
            buttonListUser.Location = new Point(209, 16);
            buttonListUser.Name = "buttonListUser";
            buttonListUser.Size = new Size(79, 23);
            buttonListUser.TabIndex = 10;
            buttonListUser.Text = "Xem User";
            buttonListUser.UseVisualStyleBackColor = true;
            buttonListUser.Click += buttonListUser_Click;
            // 
            // dataGridViewListUser
            // 
            dataGridViewListUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewListUser.Location = new Point(6, 47);
            dataGridViewListUser.Name = "dataGridViewListUser";
            dataGridViewListUser.RowTemplate.Height = 25;
            dataGridViewListUser.Size = new Size(598, 180);
            dataGridViewListUser.TabIndex = 9;
            dataGridViewListUser.CellClick += dataGridViewListUser_CellClick;
            dataGridViewListUser.SelectionChanged += dataGridViewListUser_SelectionChanged;
            // 
            // panelRemoveUser
            // 
            panelRemoveUser.Controls.Add(buttonDropUser);
            panelRemoveUser.Controls.Add(checkBoxDropUser);
            panelRemoveUser.Controls.Add(label5);
            panelRemoveUser.Controls.Add(textBoxDropUser);
            panelRemoveUser.Controls.Add(labelDropUser);
            panelRemoveUser.Dock = DockStyle.Right;
            panelRemoveUser.Location = new Point(610, 3);
            panelRemoveUser.Name = "panelRemoveUser";
            panelRemoveUser.Size = new Size(308, 360);
            panelRemoveUser.TabIndex = 8;
            // 
            // buttonDropUser
            // 
            buttonDropUser.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDropUser.Location = new Point(122, 138);
            buttonDropUser.Name = "buttonDropUser";
            buttonDropUser.Size = new Size(123, 36);
            buttonDropUser.TabIndex = 5;
            buttonDropUser.Text = "Xoá User";
            buttonDropUser.UseVisualStyleBackColor = true;
            buttonDropUser.Click += buttonDropUser_Click;
            // 
            // checkBoxDropUser
            // 
            checkBoxDropUser.AutoSize = true;
            checkBoxDropUser.Location = new Point(122, 113);
            checkBoxDropUser.Name = "checkBoxDropUser";
            checkBoxDropUser.Size = new Size(78, 19);
            checkBoxDropUser.TabIndex = 4;
            checkBoxDropUser.Text = "CASCADE";
            checkBoxDropUser.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.MenuHighlight;
            label5.Location = new Point(84, 14);
            label5.Name = "label5";
            label5.Size = new Size(116, 32);
            label5.TabIndex = 2;
            label5.Text = "Xoá User";
            // 
            // textBoxDropUser
            // 
            textBoxDropUser.Location = new Point(122, 74);
            textBoxDropUser.Name = "textBoxDropUser";
            textBoxDropUser.Size = new Size(166, 23);
            textBoxDropUser.TabIndex = 1;
            // 
            // labelDropUser
            // 
            labelDropUser.AutoSize = true;
            labelDropUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelDropUser.Location = new Point(22, 77);
            labelDropUser.Name = "labelDropUser";
            labelDropUser.Size = new Size(75, 20);
            labelDropUser.TabIndex = 0;
            labelDropUser.Text = "Username";
            // 
            // tabPageUpdateUser
            // 
            tabPageUpdateUser.Location = new Point(4, 24);
            tabPageUpdateUser.Name = "tabPageUpdateUser";
            tabPageUpdateUser.Size = new Size(921, 366);
            tabPageUpdateUser.TabIndex = 2;
            tabPageUpdateUser.Text = "Sửa User";
            tabPageUpdateUser.UseVisualStyleBackColor = true;
            // 
            // tabPageGrantUser
            // 
            tabPageGrantUser.Location = new Point(4, 24);
            tabPageGrantUser.Name = "tabPageGrantUser";
            tabPageGrantUser.Size = new Size(921, 366);
            tabPageGrantUser.TabIndex = 3;
            tabPageGrantUser.Text = "Cấp quyền cho User";
            tabPageGrantUser.UseVisualStyleBackColor = true;
            // 
            // tabPageRevokeUser
            // 
            tabPageRevokeUser.Location = new Point(4, 24);
            tabPageRevokeUser.Name = "tabPageRevokeUser";
            tabPageRevokeUser.Size = new Size(921, 366);
            tabPageRevokeUser.TabIndex = 4;
            tabPageRevokeUser.Text = "Thu hồi quyền của User";
            tabPageRevokeUser.UseVisualStyleBackColor = true;
            // 
            // tabPageEditUser
            // 
            tabPageEditUser.Location = new Point(4, 24);
            tabPageEditUser.Name = "tabPageEditUser";
            tabPageEditUser.Size = new Size(921, 366);
            tabPageEditUser.TabIndex = 5;
            tabPageEditUser.Text = "Chỉnh sửa quyền của User";
            tabPageEditUser.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(tabControl2);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(935, 400);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Roles";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPageCreateRole);
            tabControl2.Controls.Add(tabPageDeleteRole);
            tabControl2.Controls.Add(tabPageUpdateRole);
            tabControl2.Controls.Add(tabPageGrantRole);
            tabControl2.Controls.Add(tabPageRevokeRole);
            tabControl2.Controls.Add(tabPageEditRole);
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(929, 394);
            tabControl2.TabIndex = 0;
            // 
            // tabPageCreateRole
            // 
            tabPageCreateRole.Location = new Point(4, 24);
            tabPageCreateRole.Name = "tabPageCreateRole";
            tabPageCreateRole.Padding = new Padding(3);
            tabPageCreateRole.Size = new Size(921, 366);
            tabPageCreateRole.TabIndex = 0;
            tabPageCreateRole.Text = "Tạo Role";
            tabPageCreateRole.UseVisualStyleBackColor = true;
            // 
            // tabPageDeleteRole
            // 
            tabPageDeleteRole.Location = new Point(4, 24);
            tabPageDeleteRole.Name = "tabPageDeleteRole";
            tabPageDeleteRole.Padding = new Padding(3);
            tabPageDeleteRole.Size = new Size(921, 366);
            tabPageDeleteRole.TabIndex = 1;
            tabPageDeleteRole.Text = "Xoá Role";
            tabPageDeleteRole.UseVisualStyleBackColor = true;
            // 
            // tabPageUpdateRole
            // 
            tabPageUpdateRole.Location = new Point(4, 24);
            tabPageUpdateRole.Name = "tabPageUpdateRole";
            tabPageUpdateRole.Size = new Size(921, 366);
            tabPageUpdateRole.TabIndex = 2;
            tabPageUpdateRole.Text = "Sửa Role";
            tabPageUpdateRole.UseVisualStyleBackColor = true;
            // 
            // tabPageGrantRole
            // 
            tabPageGrantRole.Location = new Point(4, 24);
            tabPageGrantRole.Name = "tabPageGrantRole";
            tabPageGrantRole.Size = new Size(921, 366);
            tabPageGrantRole.TabIndex = 3;
            tabPageGrantRole.Text = "Cấp quyền Role";
            tabPageGrantRole.UseVisualStyleBackColor = true;
            // 
            // tabPageRevokeRole
            // 
            tabPageRevokeRole.Location = new Point(4, 24);
            tabPageRevokeRole.Name = "tabPageRevokeRole";
            tabPageRevokeRole.Size = new Size(921, 366);
            tabPageRevokeRole.TabIndex = 4;
            tabPageRevokeRole.Text = "Thu hồi quyền Role";
            tabPageRevokeRole.UseVisualStyleBackColor = true;
            // 
            // tabPageEditRole
            // 
            tabPageEditRole.Location = new Point(4, 24);
            tabPageEditRole.Name = "tabPageEditRole";
            tabPageEditRole.Size = new Size(921, 366);
            tabPageEditRole.TabIndex = 5;
            tabPageEditRole.Text = "Chỉnh sửa quyền Role";
            tabPageEditRole.UseVisualStyleBackColor = true;
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
            tabPage2.ResumeLayout(false);
            tabControlPrivileges.ResumeLayout(false);
            tabPageUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrivilUser).EndInit();
            tabPageRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).EndInit();
            tabPage3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageCreateUser.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCreateUser).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageDeleteUser.ResumeLayout(false);
            tabPageDeleteUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListUser).EndInit();
            panelRemoveUser.ResumeLayout(false);
            panelRemoveUser.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlHomePage;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridViewShowUser;
        private Button buttonShowUser;
        private Label labelGreetingUser;
        private TextBox textBoxSearchUserName;
        private Label labelSearchByUserName;
        private TabControl tabControlPrivileges;
        private TabPage tabPageUser;
        private DataGridView dataGridViewPrivilUser;
        private TabPage tabPageRole;
        private DataGridView dataGridViewRoles;
        private TabPage tabPage3;
        private TabControl tabControl1;
        private TabPage tabPageCreateUser;
        private Panel panel1;
        private TextBox textBoxCreateUsernameConfirmPassword;
        private Button buttionCreateUser;
        private CheckBox checkBoxGrantCreateSession;
        private TextBox textBoxCreateUserPassword;
        private Label labelCreateUserPassword;
        private Label label1;
        private TextBox textBoxCreateUserUsername;
        private Label labelUsernameCreateUser;
        private Label labelConfirmPassword;
        private TabPage tabPageDeleteUser;
        private TabPage tabPageUpdateUser;
        private TabPage tabPageGrantUser;
        private TabPage tabPageRevokeUser;
        private TabPage tabPageEditUser;
        private TabPage tabPage4;
        private TabControl tabControl2;
        private TabPage tabPageCreateRole;
        private TabPage tabPageDeleteRole;
        private TabPage tabPageUpdateRole;
        private TabPage tabPageGrantRole;
        private TabPage tabPageRevokeRole;
        private TabPage tabPageEditRole;
        private DataGridView dataGridViewCreateUser;
        private Panel panel2;
        private Button buttonClearDataCreateUser;
        private Label label2;
        private Panel panelRemoveUser;
        private Button buttonDropUser;
        private CheckBox checkBoxDropUser;
        private Label label5;
        private TextBox textBoxDropUser;
        private Label labelDropUser;
        private Button buttonListUser;
        private DataGridView dataGridViewListUser;
        private Label label4;
        private TextBox textBoxDropUser2;
        private Label label3;
    }
}