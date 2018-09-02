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
    public partial class showStudents : Form
    {
        public showStudents()
        {
            InitializeComponent();
        }

        App_Code.Connection conObj = new App_Code.Connection();
        private void showStudents_Load(object sender, EventArgs e)
        {
            loadStudents();
        }

        public void loadStudents()
        {
            string sql = "select AdmissionNo,stuName,fatherName,motherName,habitation,adharNo,dob,doa,gender,category,religion,bpl,disadvantageGroup,class,previousClass,previousSchoolStatus,previousAttendance,medium,disability,rte,facility,textBook,uniform,transportation,escort,hostel,training,homeless from studentInfo";
            OleDbConnection con = new OleDbConnection(conObj.getConPath());
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader da = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Admission No", typeof(int));
            dt.Columns.Add("Student Name", typeof(string));
            dt.Columns.Add("Father Name", typeof(string));
            dt.Columns.Add("Mother Name", typeof(string));
            dt.Columns.Add("Habitation Name", typeof(string));

            dt.Columns.Add("Aadhaar UID  No.", typeof(string));
            dt.Columns.Add("Date of Birth(dd/mm/yy)", typeof(string));
            dt.Columns.Add("Date of admission (dd/mm/yy)", typeof(string));
            dt.Columns.Add("Gender", typeof(int));
            dt.Columns.Add("Social Category", typeof(int));

            dt.Columns.Add("Religion", typeof(int));
            dt.Columns.Add("Whether belong to Weaker section", typeof(int));
            dt.Columns.Add("Disadvantaged group", typeof(int));
            dt.Columns.Add("Studying in class", typeof(int));
            dt.Columns.Add("Class studied previous year", typeof(int));

            dt.Columns.Add("If studying in class –I, give status of previous year", typeof(int));
            dt.Columns.Add("No. of days child attended school in previous year", typeof(string));
            dt.Columns.Add("Medium of instruction", typeof(int));
            dt.Columns.Add("Disability", typeof(int));
            dt.Columns.Add("Whether the child is getting free education in unaided school as per RTE Act.", typeof(int));

            dt.Columns.Add("Facilities provided to CWSN", typeof(int));
            dt.Columns.Add("Complete set of free Textbook", typeof(int));
            dt.Columns.Add("No. of Uniform sets provided", typeof(int));
            dt.Columns.Add("Free transport facility", typeof(int));
            dt.Columns.Add("Free escort facility", typeof(int));


            dt.Columns.Add("Free hostel facility", typeof(int));
            dt.Columns.Add("Whether child attended special training", typeof(int));
            dt.Columns.Add("Whether the child is Homeless. ", typeof(int));
            while (da.Read())
            {
                dt.Rows.Add(Convert.ToInt32(da[0]), da[1].ToString(), da[2].ToString(), da[3].ToString(), da[4].ToString(), da[5].ToString(), da[6].ToString(), da[7].ToString(), Convert.ToInt32(da[8]), Convert.ToInt32(da[9]), Convert.ToInt32(da[10]), Convert.ToInt32(da[11]), Convert.ToInt32(da[12]), Convert.ToInt32(da[13]), Convert.ToInt32(da[14]), Convert.ToInt32(da[15]), Convert.ToString(da[16]), Convert.ToInt32(da[17]), Convert.ToInt32(da[18]), Convert.ToInt32(da[19]), Convert.ToInt32(da[20]), Convert.ToInt32(da[21]), Convert.ToInt32(da[22]), Convert.ToInt32(da[23]), Convert.ToInt32(da[24]), Convert.ToInt32(da[25]), Convert.ToInt32(da[26]), Convert.ToInt32(da[27]));
            }

            studentGrid.DataSource = dt;
            con.Close();
        }

    }
}
