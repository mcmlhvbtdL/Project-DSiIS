using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_DSiIS
{
    public partial class HomePageForm : Form
    {
        // Khai báo các TabPage
        const int tabPageShowUser = 0;
        const int tabPageShowPrivileges = 1;
        const int tabPageAboutUser = 2;
        const int tabPageAboutRole = 3;
        // Khởi tạo HomePageForm
        private OracleConnection _conn;
        public HomePageForm(OracleConnection conn)
        {
            InitializeComponent();
            _conn = conn;
            InitializeCreateUserDataGridView();
            tabControlHomePage_SelectedIndexChanged(tabControlHomePage, EventArgs.Empty);
            dataGridViewListUser.CellClick -= dataGridViewListUser_CellClick;
            dataGridViewListUser.SelectionChanged += dataGridViewListUser_SelectionChanged;

        }

        private DataTable GetUserData(string queryString)
        {
            OracleDataAdapter adapter = new OracleDataAdapter(queryString, _conn);
            DataTable datatable = new DataTable();
            try
            {
                adapter.Fill(datatable);
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Có lỗi khi truy suất: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datatable;
        }

        // Xử lý TabPage
        private void tabControlHomePage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý TabPage Xem thông tin User
            if (tabControlHomePage.SelectedIndex == tabPageShowUser)
            {
                buttonShowUser_Click(sender, e);
                string queryStringGetDBName = "SELECT SYS_CONTEXT('USERENV', 'CON_NAME') FROM DUAL";
                string queryStringGetUserName = "SELECT SYS_CONTEXT('USERENV', 'CURRENT_USER') FROM DUAL";

                using (OracleCommand getUserNameCmd = new OracleCommand(queryStringGetUserName, _conn))
                using (OracleCommand getDBNameCmd = new OracleCommand(queryStringGetDBName, _conn))
                {
                    try
                    {
                        using (OracleDataReader userNameReader = getUserNameCmd.ExecuteReader())
                        using (OracleDataReader dbNameReader = getDBNameCmd.ExecuteReader())
                        {
                            userNameReader.Read();
                            dbNameReader.Read();
                            labelGreetingUser.Text = $"Xin chào user: {userNameReader.GetString(0)}, tên DB đang kết nối: {dbNameReader.GetString(0)}";
                        }
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show($"Error occurred while retrieving user and database information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Xử lý TabPage Xem thông tin về quyền
            else if (tabControlHomePage.SelectedIndex == tabPageShowPrivileges)
            {
                //TODO: 
            }
            // Xử lý TabPage về User
            else if (tabControlHomePage.SelectedIndex == tabPageAboutUser)
            {

                buttonListUser_Click(sender, e);

            }
            // Xử lý TabPage về Role
            else if (tabControlHomePage.SelectedIndex == tabPageAboutRole)
            {
                buttonListRole_Click(sender, e);
            }
        }

        //Xử lý Event khi click vào button Xem danh sách user
        private void buttonShowUser_Click(object sender, EventArgs e)
        {
            //1>  Xem danh sach user trong he thong
            string queryStringShowUser = "SELECT * FROM dba_users ORDER BY CREATED DESC";
            DataTable datatable = GetUserData(queryStringShowUser);
            dataGridViewShowUser.DataSource = datatable;
        }

        private void textBoxSearchUserName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxSearchUserName.Clear();
        }

        private void textBoxSearchUserName_TextChanged(object sender, EventArgs e)
        {
            string queryStringShowUser = $"SELECT * FROM dba_users WHERE USERNAME like '{textBoxSearchUserName.Text}%'";
            DataTable datatable = GetUserData(queryStringShowUser);
            dataGridViewShowUser.DataSource = datatable;
        }

        private void InitializeCreateUserDataGridView()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("USERNAME");
            dataGridViewCreateUser.DataSource = datatable;
        }

        //Xử lý event khi click vào buttion Tạo User
        private void buttionCreateUser_Click(object sender, EventArgs e)
        {
            string username = textBoxCreateUserUsername.Text;

            if (textBoxCreateUserPassword.Text == textBoxCreateUsernameConfirmPassword.Text)
            {
                string password = textBoxCreateUserPassword.Text;
                string queryStringCreateUser = $"CREATE USER {username} IDENTIFIED BY {password}";

                try
                {
                    using (OracleCommand cmd1 = new OracleCommand(queryStringCreateUser, _conn))
                    {
                        cmd1.ExecuteNonQuery();
                    }

                    if (checkBoxGrantCreateSession.Checked)
                    {
                        string opt = $"GRANT CREATE SESSION TO {username}";

                        using (OracleCommand cmd2 = new OracleCommand(opt, _conn))
                        {
                            cmd2.ExecuteNonQuery();
                        }

                        MessageBox.Show(text: $"User {username} đã được tạo thành công và cấp quyền CREATE SESSION privilege.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"User {username} đã được tạo thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    DataTable datatable = dataGridViewCreateUser.DataSource as DataTable;
                    DataRow newRow = datatable.NewRow();
                    newRow["USERNAME"] = username;
                    datatable.Rows.Add(newRow);
                    datatable.AcceptChanges();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Có lỗi khi thực hiện việc tạo User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu và mật khẩu xác nhận không chính xác, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCreateUserUsername.Clear();
                textBoxCreateUserPassword.Clear();
                textBoxCreateUsernameConfirmPassword.Clear();
            }
        }

        private void buttonClearDataCreateUser_Click(object sender, EventArgs e)
        {
            InitializeCreateUserDataGridView();

        }

        private void buttonDropUser_Click(object sender, EventArgs e)
        {
            string username = textBoxDropUser.Text;
            string opt = "";
            string queryStringCreateUser = $"DROP USER \"{username}\" {opt}";
            if (checkBoxDropUser.Checked)
            {
                opt = "CASCADE";
            }
            DialogResult dr = MessageBox.Show($"Bạn có chắc là muốn xoá user: {username} ? ", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (OracleCommand cmd1 = new OracleCommand(queryStringCreateUser, _conn))
                    {
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show($"User {username} đã được xoá thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonListUser_Click(sender, e);
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Có lỗi khi thực hiện việc xoá User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            string queryStringShowUser = "SELECT * FROM dba_users ORDER BY CREATED DESC";
            DataTable datatable = GetUserData(queryStringShowUser);
            dataGridViewListUser.DataSource = datatable;
        }


        private void dataGridViewListUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string userName = dataGridViewListUser.CurrentRow.Cells[0].Value.ToString();
            textBoxDropUser.Text = userName;

        }

        private void dataGridViewListUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewListUser.CurrentRow != null)
            {
                string userName = dataGridViewListUser.CurrentRow.Cells[0].Value.ToString();
                textBoxDropUser.Text = userName;
            }
        }

        private void textBoxDropUser2_TextChanged(object sender, EventArgs e)
        {
            string queryStringShowUser = $"SELECT * FROM dba_users WHERE USERNAME like '{textBoxDropUser2.Text}%'";
            DataTable datatable = GetUserData(queryStringShowUser);
            dataGridViewListUser.DataSource = datatable;
        }

        private void buttonListRole_Click(object sender, EventArgs e)
        {
            string queryStringShowListRole = "SELECT * FROM DBA_ROLES";
            DataTable datatable = GetUserData(queryStringShowListRole);
            dataGridViewListRole.DataSource = datatable;

        }

        private void textBoxSreachListRole_TextChanged(object sender, EventArgs e)
        {
            string queryStringShowListRole = $"SELECT * FROM DBA_ROLES WHERE ROLE like '{textBoxSreachListRole.Text}%'";
            DataTable datatable = GetUserData(queryStringShowListRole);
            dataGridViewListRole.DataSource = datatable;
        }

        private void buttonCreateRole_Click(object sender, EventArgs e)
        {
            string rolemame = textBoxRolename.Text;
            string password = textBoxRolenamePassword.Text;
            string queryStringCreateRole = "";
            if(String.IsNullOrWhiteSpace(password) == false)
            {
                queryStringCreateRole = $"CREATE ROLE {rolemame} IDENTIFIED BY {password}";
            } else {
                queryStringCreateRole = $"CREATE ROLE {rolemame}";
            }
            try
            {
                using (OracleCommand cmd1 = new OracleCommand(queryStringCreateRole, _conn))
                {
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show($"Role {rolemame} đã được tạo thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonListRole_Click(sender,e);
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Có lỗi khi thực hiện việc tạo Role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
