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
        private String _role;
        public HomePageUser(OracleConnection conn, String role)
        {
            InitializeComponent();
            _conn = conn;
            _role = role;
            _orl = new OracleSQLHandle(_conn);

        }

        private void buttonSlectNV_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (_role == "S_NHANVIEN" || _role == "S_NHANSU" || _role == "S_TRUONGDEAN")
            {
                 dt = _orl.GetUserDataFromQuery("select * from EM.TT_NHANVIEN");
            }
            else if (_role == "S_QL_NHANVIEN")
            {
                dt = _orl.GetUserDataFromQuery("SELECT * FROM EM.TT_NVQL");

            } 
            else if (_role == "S_TRUONGPHONG")
            {
                dt = _orl.GetUserDataFromQuery("SELECT * FROM EM.TT_NVPHG");
            }
            else if (_role == "S_TAICHINH")
            {
                dt = _orl.GetUserDataFromQuery("select * from EM.NHANVIEN");

            }
            dataGridViewInfor.DataSource = dt;


        }

        private void buttonSelectPC_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (_role == "S_NHANVIEN" || _role == "S_NHANSU" || _role == "S_TRUONGDEAN")
            {
                dt = _orl.GetUserDataFromQuery("select * from EM.TT_PHANCONG");
            }
            else if (_role == "S_QL_NHANVIEN")
            {
                dt = _orl.GetUserDataFromQuery("SELECT * FROM EM.TT_PCNVQL");
            }
            else if (_role == "S_TRUONGPHONG")
            {
                dt = _orl.GetUserDataFromQuery("SELECT * FROM EM.TT_PCNVPHG");

            }
            else if (_role == "S_TAICHINH")
            {
                dt = _orl.GetUserDataFromQuery("select * from EM.PHANCONG");
            }
            dataGridViewInfor.DataSource = dt;
        }

        private void buttonSelectDA_Click(object sender, EventArgs e)
        {
            DataTable dt = _orl.GetUserDataFromQuery("SELECT * FROM EM.TT_DEAN");
            dataGridViewInfor.DataSource = dt;

        }

        private void buttonSelectPB_Click(object sender, EventArgs e)
        {
            DataTable dt = _orl.GetUserDataFromQuery("SELECT * FROM EM.TT_PHONGBAN");
            dataGridViewInfor.DataSource = dt;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridViewInfor.DataSource = null;
        }
    }
}
