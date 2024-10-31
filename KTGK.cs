using KTGK_VoHungQuyet.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTGK_VoHungQuyet
{
    public partial class KTGK : Form
    {
        public KTGK()
        {
            InitializeComponent();
        }

        void LoadStudentList()
        {
            string query = "EXEC USP_GetStudentList";
            dgvStudent.DataSource = DataProvider.Instance.ExecuteQuery(query);
            dgvStudent.Columns[0].Width = 50;
            dgvStudent.Columns[0].HeaderText = "ID";
            dgvStudent.Columns[1].Width = 165;
            dgvStudent.Columns[1].HeaderText = "Tên";
            dgvStudent.Columns[2].Width = 200;
            dgvStudent.Columns[2].HeaderText = "Email";
            dgvStudent.Columns[3].Width = 180;
            dgvStudent.Columns[3].HeaderText = "SĐT";
        }
        private void KTGK_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudentList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "Name", "*" + txtSearch.Text + "*");
            (dgvStudent.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

        }
    }
}
