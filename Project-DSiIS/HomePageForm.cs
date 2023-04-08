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

        /*
         * Cac phan xy ly LOGIC
         */
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

        private DataTable GetUserDataFromProcedure(string procedureName, List<OracleParameter> parameters)
        {
            DataTable datatable = new DataTable();
            try
            {
                using (OracleCommand command = new OracleCommand(procedureName, _conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (OracleParameter param in parameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }

                    OracleParameter cursorParam = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    command.Parameters.Add(cursorParam);

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Có lỗi khi truy suất: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datatable;
        }

        private void ExecuteProcedureWithNoQuery(string procedureName, Dictionary<string, object> parameterDict)
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            foreach (var entry in parameterDict)
            {
                parameters.Add(new OracleParameter(entry.Key, OracleDbType.Varchar2, ParameterDirection.Input) { Value = entry.Value });
            }

            using (OracleCommand cmd = new OracleCommand(procedureName, _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                cmd.ExecuteNonQuery();
            }
        }

        private void GetUserandRole(string procedureName, DataGridView dataGridViewName, string searchString = null)
        {
            List<OracleParameter> parameters = null;
            if (searchString != null)
            {
                parameters = new List<OracleParameter>
                {
                    new OracleParameter("p_username", OracleDbType.Varchar2, ParameterDirection.Input)
                    { Value = searchString }
                };
            }
            DataTable datatable = GetUserDataFromProcedure(procedureName, parameters);
            dataGridViewName.DataSource = datatable;
        }

        /*
         * Cac phan lien quan den giao dien
        */
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
                buttonListUserCreateUser_Click(sender, e);
                buttonListUser_Click(sender, e);
            }
            // Xử lý TabPage về Role
            else if (tabControlHomePage.SelectedIndex == tabPageAboutRole)
            {
                buttonListRole_Click(sender, e);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                buttonListUserCreateUser_Click(sender, e);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                buttonListUser_Click(sender, e);
            }
        }

        //Xử lý Event khi click vào button Xem danh sách user
        private void buttonShowUser_Click(object sender, EventArgs e)
        {
            string sp_name = "sp_get_all_users";
            GetUserandRole(sp_name, dataGridViewShowUser);
        }

        private void textBoxSearchUserName_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxSearchUserName.Clear();
        }

        private void textBoxSearchUserName_TextChanged(object sender, EventArgs e)
        {
            string sp_name = "sp_get_user_by_username";
            GetUserandRole(sp_name, dataGridViewShowUser, textBoxSearchUserName.Text);
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
            string sp_name = "sp_create_user";
            string username = textBoxCreateUserUsername.Text;

            if (textBoxCreateUserPassword.Text == textBoxCreateUsernameConfirmPassword.Text)
            {
                string password = textBoxCreateUserPassword.Text;
                var parameterDict = new Dictionary<string, object>
                {
                    {"p_username", username },
                    {"p_password", password },
                    {"p_create_session", checkBoxGrantCreateSession.Checked ? 1 : 0}
                };
                try
                {
                    ExecuteProcedureWithNoQuery(sp_name, parameterDict);
                    if (checkBoxGrantCreateSession.Checked)
                    {
                        MessageBox.Show(text: $"User {username} đã được tạo thành công và cấp quyền CREATE SESSION privilege.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"User {username} đã được tạo thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    //Refesh dataGridViewCreateUser
                    buttonListUserCreateUser_Click(sender, e);
                    //Add user vừa tạo vào dataGridViewCreateUser
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
            string sp_name = "sp_drop_user";
            string username = textBoxDropUser.Text;
            DialogResult dr = MessageBox.Show($"Bạn có chắc là muốn xoá user: {username} ? ", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                var parameterDict = new Dictionary<string, object>
                {
                    { "p_username", username },
                    { "p_cascade", checkBoxDropUser.Checked ? 1 : 0}
                };
                try
                {
                    ExecuteProcedureWithNoQuery(sp_name, parameterDict);
                    MessageBox.Show($"User {username} đã được xoá thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonListUser_Click(sender, e);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Có lỗi khi thực hiện việc xoá User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            string sp_name = "sp_get_all_users";
            GetUserandRole(sp_name, dataGridViewListUser);
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
            string sp_name = "sp_get_user_by_username";
            GetUserandRole(sp_name, dataGridViewListUser, textBoxDropUser2.Text);
        }

        private void buttonListRole_Click(object sender, EventArgs e)
        {
            string sp_name = "sp_get_all_role";
            GetUserandRole(sp_name, dataGridViewListRole);
        }

        private void textBoxSreachListRole_TextChanged(object sender, EventArgs e)
        {

            string sp_name = "sp_get_role_by_rolename";
            GetUserandRole(sp_name, dataGridViewListRole, textBoxSreachListRole.Text);
        }

        private void buttonCreateRole_Click(object sender, EventArgs e)
        {
            string sp_name = "sp_create_role";
            string roleName = textBoxRolename.Text;
            string password = textBoxRolenamePassword.Text;
            Dictionary<string, object> parameterDict;

            if (String.IsNullOrWhiteSpace(password) == false)
            {
                parameterDict = new Dictionary<string, object>
                {
                    { "p_role_name", roleName },
                    { "p_password_optional", password },
                    { "p_password_optional_checked", 1 }
                };
            }
            else
            {
                parameterDict = new Dictionary<string, object>
                {
                    { "p_role_name", roleName },
                    { "p_password_optional", null },
                    { "p_password_optional_checked", 0 }
                };
            }

            try
            {
                ExecuteProcedureWithNoQuery(sp_name, parameterDict);
                MessageBox.Show($"Role {roleName} đã được tạo thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonListRole_Click(sender, e);
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Có lỗi khi thực hiện việc tạo Role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxListUserCreateUser_TextChanged(object sender, EventArgs e)
        {
            string sp_name = "sp_get_user_by_username";
            GetUserandRole(sp_name, dataGridViewListUserCreateUser, textBoxListUserCreateUser.Text);
        }

        private void buttonListUserCreateUser_Click(object sender, EventArgs e)
        {
            string sp_name = "sp_get_all_users";
            GetUserandRole(sp_name, dataGridViewListUserCreateUser);
        }

        private void buttonDropRole_Click(object sender, EventArgs e)
        {
            string sp_name = "sp_drop_role";
            string rolename = textBoxDropRole.Text;
            DialogResult dr = MessageBox.Show($"Bạn có chắc là muốn xoá role: {rolename} ? ", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                var parameterDict = new Dictionary<string, object>
                {
                    { "p_role_name", rolename }
                };
                try
                {
                    ExecuteProcedureWithNoQuery(sp_name, parameterDict);
                    MessageBox.Show($"User {rolename} đã được xoá thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonViewRoleInDropRoleTab_Click(sender, e);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Có lỗi khi thực hiện việc xoá role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonViewRoleInDropRoleTab_Click(object sender, EventArgs e)
        {
            string sp_name = "sp_get_all_role";
            GetUserandRole(sp_name, dataGridViewDropRole);
        }

        private void textBoxViewRoleInDropRoleTab_TextChanged(object sender, EventArgs e)
        {
            string sp_name = "sp_get_role_by_rolename";
            GetUserandRole(sp_name, dataGridViewDropRole, textBoxViewRoleInDropRoleTab.Text);
        }
    }
}
