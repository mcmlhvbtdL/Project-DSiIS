using Oracle.ManagedDataAccess.Client;
using Project_DSiIS.Project_DSiIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DSiIS
{
    public partial class HomePageUser : Form
    {

        private OracleConnection _conn;
        private OracleSQLHandle _orl;

        public HomePageUser(OracleConnection conn)
        {
            InitializeComponent();
            _conn = conn;
            _orl = new OracleSQLHandle(_conn);

        }

        private void buttonSlectNV_Click(object sender, EventArgs e)
        {

            DataTable dt = _orl.GetUserDataFromQuery("SELECT * FROM NHANVIEN");
            dataGridViewInfor.DataSource = dt;


        }

        private void buttonSelectPC_Click(object sender, EventArgs e)
        {
            DataTable dt = _orl.GetUserDataFromQuery("SELECT * FROM PHANCONG");
            dataGridViewInfor.DataSource = dt;
        }

        private void buttonSelectDA_Click(object sender, EventArgs e)
        {
            DataTable dt = _orl.GetUserDataFromQuery("SELECT * FROM DEAN");
            dataGridViewInfor.DataSource = dt;

        }

        private void buttonSelectPB_Click(object sender, EventArgs e)
        {
            DataTable dt = _orl.GetUserDataFromQuery("SELECT * FROM PHONGBAN");
            dataGridViewInfor.DataSource = dt;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridViewInfor.DataSource = null;
        }
    }
}
