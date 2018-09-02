using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolCollegeInformationSystem.Main
{
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        App_Code.Connection conObj = new App_Code.Connection();
        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            loadAdmissionNo();
        }

        public void loadAdmissionNo()
        {
            OleDbConnection con = new OleDbConnection(conObj.getConPath());
            con.Open();
            string sql = "select AdmissionNo from studentInfo";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("admissionNo", typeof(int));
            cnbAdmissionNo.Items.Clear();
            while (da.Read())
            {
                cnbAdmissionNo.Items.Add(Convert.ToString(da[0]));
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(conObj.getConPath());
            con.Open();
            string sql = "delete from studentInfo where AdmissionNo = " + Convert.ToInt32(cnbAdmissionNo.SelectedItem);
            OleDbCommand cmd = new OleDbCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                MessageBox.Show("Student deleted successfully.");
            else
                MessageBox.Show("Student can't deleted.");
            this.Close();
            con.Close();
        }

        private void DeleteStudent_Leave(object sender, EventArgs e)
        {
            Main.schoolInfo school = new schoolInfo();
            school.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.schoolInfo school = new schoolInfo();
            school.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
