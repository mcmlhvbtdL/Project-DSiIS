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

namespace Project_DSiIS
{
    public partial class HomePageForm : Form
    {
        // Khai báo các TabPage
        const int tabPageShowUser = 0;
        const int tabPageShowPrivileges = 1;

        // Khởi tạo HomePageForm
        private OracleConnection _conn;
        public HomePageForm(OracleConnection conn)
        {
            InitializeComponent();
            _conn = conn;
            tabControlHomePage_SelectedIndexChanged(tabControlHomePage, EventArgs.Empty);

        }

        // Xử lý TabIndex
        private void tabControlHomePage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý TabIndex Xem thông tin User
            if (tabControlHomePage.SelectedIndex == tabPageShowUser)
            {
                string queryStringGetDBName = "SELECT SYS_CONTEXT('USERENV', 'CON_NAME') FROM DUAL";
                string queryStringGetUserName = "SELECT SYS_CONTEXT('USERENV', 'CURRENT_USER') FROM DUAL";
                OracleCommand cmd1 = new OracleCommand(queryStringGetUserName, _conn);
                OracleCommand cmd2 = new OracleCommand(queryStringGetDBName, _conn);

                OracleDataReader reader1 = cmd1.ExecuteReader();
                OracleDataReader reader2 = cmd2.ExecuteReader();
                try
                {
                    reader1.Read();
                    reader2.Read();
                    labelGreetingUser.Text = $"Xin chào user: {reader1.GetString(0)}, tên PDB đang sử dụng: {reader2.GetString(0)}";
                }
                finally
                {
                    reader1.Close();
                    reader2.Close();
                }

            }
            // Xử lý TabIndex Xem thông tin về quyền
            else if (tabControlHomePage.SelectedIndex == tabPageShowPrivileges)
            {
                //TODO: 
            }
        }

        //Xử lý Event khi click vào button Xem danh sách user
        private void buttonShowUser_Click(object sender, EventArgs e)
        {
            //1>  Xem danh sach user trong he thong
            string queryStringShowUser = "SELECT * FROM dba_users";
            OracleDataAdapter adapter = new OracleDataAdapter(queryStringShowUser, _conn);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            dataGridViewShowUser.DataSource = datatable;
        }


    }
}
