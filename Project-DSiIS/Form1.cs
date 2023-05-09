using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
namespace Project_DSiIS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public static string GetUserRole(string username)
        {
            int userNumber = Convert.ToInt32(username.Substring(2));

            if (userNumber >= 1 && userNumber <= 20)
                return "S_QL_NHANVIEN";
            else if (userNumber >= 31 && userNumber <= 40)
                return "S_NHANVIEN";
            else if (userNumber >= 21 && userNumber <= 28)
                return "S_TRUONGPHONG";
            else if (userNumber >= 41 && userNumber <= 45)
                return "S_TAICHINH";
            else if (userNumber >= 46 && userNumber <= 50)
                return "S_NHANSU";
            else if (userNumber >= 51 && userNumber <= 53)
                return "S_TRUONGDEAN";
            else
                return "Invalid username";
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            //Tạo kết nối với Oracle Database
            string baseConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XEPDB1)));";
            string connectionString = $"{baseConnectionString} User Id={textBoxUserName.Text};Password={textBoxPassword.Text};";
            bool isSysUser = textBoxUserName.Text.ToUpper() == "SYS" ? true : false;
            string role = "";
            if (isSysUser) { connectionString += "DBA Privilege=SYSDBA;"; } else
            {
                 role = GetUserRole(textBoxUserName.Text);
            }

            OracleConnection conn = new OracleConnection(connectionString);

            try
            {
                conn.Open();
                MessageBox.Show(text: "Kết nối thành công", "Tình trạng kết nối");
                if(isSysUser)
                {
                    var homePageForm = new HomePageForm(conn);
                    this.Hide();
                    homePageForm.ShowDialog();
                    homePageForm.Close();
                    this.Show();
                } else
                {
                    var homePageUser = new HomePageUser(conn, role);
                    this.Hide();
                    homePageUser.ShowDialog();
                    homePageUser.Close();
                    this.Show();
                }
             
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Kết nối tới Oracle Database thất bại: {ex.Message}", "Tình trạng kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
        }
    }
}