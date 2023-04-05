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

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            //Tạo kết nối với Oracle Database
            string baseConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XEPDB1)));";
            string connectionString = $"{baseConnectionString} User Id={textBoxUserName.Text};Password={textBoxPassword.Text};DBA Privilege=SYSDBA;";

            OracleConnection conn = new OracleConnection(connectionString);

            try
            {
                conn.Open();
                MessageBox.Show(text: "Kết nối thành công", "Tình trạng kết nối");
                var homePageForm = new HomePageForm(conn);
                this.Hide();
                homePageForm.ShowDialog();
                homePageForm.Close();
                this.Show();
            }
            catch (Exception ex)
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