using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SchoolCollegeInformationSystem.Main
{
    public partial class schoolInfo : Form
    {
        public schoolInfo()
        {
            InitializeComponent();
        }

        App_Code.Connection conObj = new App_Code.Connection();
        private void schoolInfo_Load(object sender, EventArgs e)
        {
            //OleDbConnection con = new OleDbConnection(conObj.getConPath());
            //con.Open();
            //MessageBox.Show("open");
            //con.Close();
            loadCombos();
            loadSchoolInfo();
        }

        private void txtDoB_Validating(object sender, CancelEventArgs e)
        {
            DateTime Test;
            if (DateTime.TryParseExact(txtDoB.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) == true)
                // MessageBox.Show("Date OK");
                txtDOA.Focus();
            else
                MessageBox.Show("Invalid date.");
        }

        private void txtDOA_Validating(object sender, CancelEventArgs e)
        {
            DateTime Test;
            if (DateTime.TryParseExact(txtDOA.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) == true)
                // MessageBox.Show("Date OK");
                txtAdmissionNo.Focus();
            else
                MessageBox.Show("Invalid date.");
        }

        public void loadSchoolInfo()
        {
            OleDbConnection con = new OleDbConnection(conObj.getConPath());
            con.Open();
            string sql = "select schoolName,schoolCode from school";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                lblSchoolName.Text = da[0].ToString();
                txtSchoolNo.Text = da[1].ToString();
            }

            con.Close();
        }


        public void loadCombos()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.Add("1.Boy");
            cmbGender.Items.Add("2.Girl");

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("1.General");
            cmbCategory.Items.Add("2.SC");
            cmbCategory.Items.Add("3.ST");
            cmbCategory.Items.Add("4.OBC");

            cmbReligion.Items.Clear();
            cmbReligion.Items.Add("1.Hindu");
            cmbReligion.Items.Add("2.Muslim");
            cmbReligion.Items.Add("3.Christian");
            cmbReligion.Items.Add("4.Sikh");
            cmbReligion.Items.Add("5.Buddhist");
            cmbReligion.Items.Add("6.Jain");
            cmbReligion.Items.Add("7 .Others");

            cmbWeakerSection.Items.Clear();
            cmbWeakerSection.Items.Add("1.Yes");
            cmbWeakerSection.Items.Add("2.No");

            cmbDisadvantageGroup.Items.Clear();
            cmbDisadvantageGroup.Items.Add("0.NA");
            cmbDisadvantageGroup.Items.Add("1.Yes");
            cmbDisadvantageGroup.Items.Add("2.No");

            cmbClass.Items.Clear();
            cmbClass.Items.Add("0.Pre Primary");
            cmbClass.Items.Add("1.1");
            cmbClass.Items.Add("2.2");
            cmbClass.Items.Add("3.3");
            cmbClass.Items.Add("4.4");
            cmbClass.Items.Add("5.5");
            cmbClass.Items.Add("6.6");
            cmbClass.Items.Add("7.7");
            cmbClass.Items.Add("8.8");
            cmbClass.Items.Add("9.9");
            cmbClass.Items.Add("10.SSC");


            cmbPreviousClass.Items.Clear();
            cmbPreviousClass.Items.Add("99.None");
            cmbPreviousClass.Items.Add("0.Pre Primary");
            cmbPreviousClass.Items.Add("1.1");
            cmbPreviousClass.Items.Add("2.2");
            cmbPreviousClass.Items.Add("3.3");
            cmbPreviousClass.Items.Add("4.4");
            cmbPreviousClass.Items.Add("5.5");
            cmbPreviousClass.Items.Add("6.6");
            cmbPreviousClass.Items.Add("7.7");
            cmbPreviousClass.Items.Add("8.8");
            cmbPreviousClass.Items.Add("9.9");
            cmbPreviousClass.Items.Add("10.SSC");

            cmbPreviouYearStatus.Items.Clear();
            cmbPreviouYearStatus.Items.Add("1.None");
            cmbPreviouYearStatus.Items.Add("2.Same School");
            cmbPreviouYearStatus.Items.Add("3.Another School");
            cmbPreviouYearStatus.Items.Add("4.Anganwadi-ECCE");

            cmbMediumOfInstruction.Items.Clear();
            cmbMediumOfInstruction.Items.Add("4.Hindi");
            cmbMediumOfInstruction.Items.Add("18.Urdu");
            cmbMediumOfInstruction.Items.Add("19.English");
            cmbMediumOfInstruction.Items.Add("99.Others");


            cmbDisability.Items.Clear();
            cmbDisability.Items.Add("0.NA");
            cmbDisability.Items.Add("1.Visual (Blindness)");
            cmbDisability.Items.Add("2.(Visual Low –vision)");
            cmbDisability.Items.Add("3.Hearing impaired");
            cmbDisability.Items.Add("4.Speech");
            cmbDisability.Items.Add("5.Loco motor");
            cmbDisability.Items.Add("6.Mental Retardation");
            cmbDisability.Items.Add("7.Learning disability");
            cmbDisability.Items.Add("8.Cerebral Palsy");
            cmbDisability.Items.Add("9.Autism");
            cmbDisability.Items.Add("10.Multiple Disability");

            cmbRetAct.Items.Clear();
            cmbRetAct.Items.Add("0.NA");
            cmbRetAct.Items.Add("1.Yes");
            cmbRetAct.Items.Add("2.No");

            cmbFacility.Items.Clear();
            cmbFacility.Items.Add("0.NA");
            cmbFacility.Items.Add("1.Braille books");
            cmbFacility.Items.Add("2.Braille kit");
            cmbFacility.Items.Add("3.Low vision kit");
            cmbFacility.Items.Add("4.Hearing aid");
            cmbFacility.Items.Add("5.Braces");
            cmbFacility.Items.Add("6.Crutches");
            cmbFacility.Items.Add("7.Wheel chair");
            cmbFacility.Items.Add("8.Tricycle");
            cmbFacility.Items.Add("9.Calliper");
            cmbFacility.Items.Add("10.Others");

            cmbSetOfTextbook.Items.Clear();
            cmbSetOfTextbook.Items.Add("0.NA");
            cmbSetOfTextbook.Items.Add("1.Yes");
            cmbSetOfTextbook.Items.Add("2.No");

            cmbUniformSet.Items.Clear();
            cmbUniformSet.Items.Add("0.None");
            cmbUniformSet.Items.Add("1.One Set");
            cmbUniformSet.Items.Add("2.Two Set");
            cmbUniformSet.Items.Add("99.NA");

            cmbTransportFacility.Items.Clear();
            cmbTransportFacility.Items.Add("0.NA");
            cmbTransportFacility.Items.Add("1.Yes");
            cmbTransportFacility.Items.Add("2.No");

            cmbEscortFacility.Items.Clear();
            cmbEscortFacility.Items.Add("0.NA");
            cmbEscortFacility.Items.Add("1.Yes");
            cmbEscortFacility.Items.Add("2.No");

            cmbHostelFacility.Items.Clear();
            cmbHostelFacility.Items.Add("0.NA");
            cmbHostelFacility.Items.Add("1.KGBV");
            cmbHostelFacility.Items.Add("2.Non KGBV (Government)");
            cmbHostelFacility.Items.Add("3.Others");


            cmbSpacialTraining.Items.Clear();
            cmbSpacialTraining.Items.Add("0.NA");
            cmbSpacialTraining.Items.Add("1.Residential");
            cmbSpacialTraining.Items.Add("2.Non-Residential");

            cmbHomeless.Items.Clear();
            cmbHomeless.Items.Add("0.NA");
            cmbHomeless.Items.Add("1.With Parents");
            cmbHomeless.Items.Add("2.Without adult protection");
        }


        public void clear()
        {
            //cmbGender.SelectedItem = null;
            //cmbCategory.SelectedItem = null;
            //cmbReligion.SelectedItem = null;
            //cmbWeakerSection.SelectedItem = null;
            //cmbDisadvantageGroup.SelectedItem = null;
            //cmbClass.SelectedItem = null;
            //cmbPreviousClass.SelectedItem = null;
            //cmbPreviouYearStatus.SelectedItem = null;
            //cmbMediumOfInstruction.SelectedItem = null;
            //cmbDisability.SelectedItem = null;
            //cmbRetAct.SelectedItem = null;
            //cmbFacility.SelectedItem = null;
            //cmbSetOfTextbook.SelectedItem = null;
            //cmbUniformSet.SelectedItem = null;
            //cmbTransportFacility.SelectedItem = null;
            //cmbEscortFacility.SelectedItem = null;
            //cmbHostelFacility.SelectedItem = null;
            //cmbSpacialTraining.SelectedItem = null;
            //cmbHomeless.SelectedItem = null;

            txtStudentName.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtHabitation.Text = "";
            txtAdharNo.Text = "";
            txtDOA.Text = "";
            txtDoB.Text = "";
            txtAdmissionNo.Text = "";
            txtAttendance.Text = "";

        }


        public int selectGender(string gender)
        {
            if (gender.ToString() == "1.Boy")
                return 1;
            else
                return 2;
        }

        public int selectCategory(string category)
        {
            if (category.ToString() == "1.General")
                return 1;
            else if (category.ToString() == "2.SC")
                return 2;
            else if (category.ToString() == "3.ST")
                return 3;
            else
                return 4;
        }

        public int selectReligion(string rel)
        {
            if (rel.ToString() == "1.Hindu")
                return 1;
            else if (rel.ToString() == "2.Muslim")
                return 2;
            else if (rel.ToString() == "3.Christian")
                return 3;
            else if (rel.ToString() == "4.Sikh")
                return 4;
            else if (rel.ToString() == "5.Buddhist")
                return 5;
            else if (rel.ToString() == "6.Jain")
                return 6;
            else return 7;
        }

        public int selectWeekerSection(string weak)
        {
            if (weak.ToString() == "1.Yes")
                return 1;
            else
                return 2;
        }

        public int selectDisadvantage(string disadvantage)
        {
            if (disadvantage.ToString() == "0.NA")
                return 0;
            else if (disadvantage.ToString() == "1.Yes")
                return 1;
            else return 2;
        }

        public int selectClass(string cls)
        {
            if (cls.ToString() == "0.Pre Primary")
                return 0;
            else if (cls.ToString() == "1.1")
                return 1;
            else if (cls.ToString() == "2.2")
                return 2;
            else if (cls.ToString() == "3.3")
                return 3;
            else if (cls.ToString() == "4.4")
                return 4;
            else if (cls.ToString() == "5.5")
                return 5;
            else if (cls.ToString() == "6.6")
                return 6;
            else if (cls.ToString() == "7.7")
                return 7;
            else if (cls.ToString() == "8.8")
                return 8;
            else if (cls.ToString() == "9.9")
                return 9;
            else if (cls.ToString() == "10.SSC")
                return 10;
            else return 99;
        }

        public int selectPrevYearStatus(string status)
        {
            if (status.ToString() == "1.None")
                return 1;
            else if (status.ToString() == "2.Same School")
                return 2;
            else if (status.ToString() == "3.Another School")
                return 3;
            else return 4;
        }

        public int selectMedium(string medium)
        {
            if (medium.ToString() == "4.Hindi")
                return 4;
            else if (medium.ToString() == "18.Urdu")
                return 18;
            else if (medium.ToString() == "19.English")
                return 19;
            else return 99;
        }

        public int selectNaYesNo(string opt)
        {
            if (opt.ToString() == "0.NA")
                return 0;
            else if (opt.ToString() == "1.Yes")
                return 1;
            else return 2;
        }

        public int selectDisability(string disability)
        {
            if (disability.ToString() == "0.NA")
                return 0;
            else if (disability.ToString() == "1.Visual (Blindness)")
                return 1;
            else if (disability.ToString() == "2.(Visual Low –vision)")
                return 2;
            else if (disability.ToString() == "3.Hearing impaired")
                return 3;
            else if (disability.ToString() == "4.Speech")
                return 4;
            else if (disability.ToString() == "5.Loco motor")
                return 5;
            else if (disability.ToString() == "6.Mental Retardation")
                return 6;
            else if (disability.ToString() == "7.Learning disability")
                return 7;
            else if (disability.ToString() == "8.Cerebral Palsy")
                return 8;
            else if (disability.ToString() == "9.Autism")
                return 9;
            else return 10;
        }

        public int selectFacility(string facility)
        {
            if (facility.ToString() == "0.NA")
                return 0;
            else if (facility.ToString() == "1.Braille books")
                return 1;
            else if (facility.ToString() == "2.Braille kit")
                return 2;
            else if (facility.ToString() == "3.Low vision kit")
                return 3;
            else if (facility.ToString() == "4.Hearing aid")
                return 4;
            else if (facility.ToString() == "5.Braces")
                return 5;
            else if (facility.ToString() == "6.Crutches")
                return 6;
            else if (facility.ToString() == "7.Wheel chair")
                return 7;
            else if (facility.ToString() == "8.Tricycle")
                return 8;
            else if (facility.ToString() == "9.Calliper")
                return 9;
            else return 10;
        }

        public int selectUniform(string uniform)
        {
            if (uniform.ToString() == "0.None")
                return 0;
            else if (uniform.ToString() == "1.One Set")
                return 1;
            else if (uniform.ToString() == "2.Two Set")
                return 2;
            else return 99;
        }

        public int selectHostel(string hostel)
        {
            if (hostel.ToString() == "0.NA")
                return 0;
            else if (hostel.ToString() == "1.KGBV")
                return 1;
            else if (hostel.ToString() == "2.Non KGBV (Government)")
                return 2;
            else return 3;
        }

        public int selectTraining(string training)
        {
            if (training.ToString() == "0.NA")
                return 0;
            else if (training.ToString() == "1.Residential")
                return 1;
            else return 2;
        }

        public int selectHomeless(string home)
        {
            if (home.ToString() == "0.NA")
                return 0;
            else if (home.ToString() == "1.With Parents")
                return 1;
            else return 2;
        }

        public bool Validate()
        {
            bool valid = false;
            if (cmbGender.SelectedItem != null && cmbCategory.SelectedItem != null && cmbReligion.SelectedItem != null && cmbWeakerSection.SelectedItem != null && cmbDisadvantageGroup.SelectedItem != null && cmbClass.SelectedItem != null && cmbPreviousClass.SelectedItem != null && cmbPreviouYearStatus.SelectedItem != null && cmbMediumOfInstruction.SelectedItem != null && cmbDisability.SelectedItem != null && cmbRetAct.SelectedItem != null && cmbFacility.SelectedItem != null && cmbSetOfTextbook.SelectedItem != null && cmbUniformSet.SelectedItem != null && cmbTransportFacility.SelectedItem != null && cmbEscortFacility.SelectedItem != null && cmbHostelFacility.SelectedItem != null && cmbSpacialTraining.SelectedItem != null && cmbHomeless.SelectedItem != null && txtStudentName.Text != "" && txtFatherName.Text != "" && txtMotherName.Text != "" && txtHabitation.Text != "" && txtAdharNo.Text != "" && txtDOA.Text != "" && txtDoB.Text != "" && txtAdmissionNo.Text != "" && txtAttendance.Text != "")
                valid = true;
            else
                valid = false;
            return valid;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                OleDbConnection con = new OleDbConnection(conObj.getConPath());
                con.Open();
                string sql = "insert into studentInfo(AdmissionNo,stuName,fatherName,motherName,habitation,adharNo,dob,doa,gender,category,religion,bpl,disadvantageGroup,class,previousClass,previousSchoolStatus,previousAttendance,medium,disability,rte,facility,textBook,uniform,transportation,escort,hostel,training,homeless)" +
                    " values(" + Convert.ToInt32(txtAdmissionNo.Text) + ",'" + txtStudentName.Text.ToString() + "','" + txtFatherName.Text.ToString() + "','" + txtMotherName.Text.ToString() + "','" + txtHabitation.Text.ToString() + "','" + txtAdharNo.Text.ToString() + "'," +
                     "'" + txtDoB.Text.ToString() + "','" + txtDOA.Text.ToString() + "'," + Convert.ToInt32(selectGender(cmbGender.SelectedItem.ToString())) + "," + Convert.ToInt32(selectCategory(cmbCategory.SelectedItem.ToString())) + "," + Convert.ToInt32(selectReligion(cmbReligion.SelectedItem.ToString())) + "," + Convert.ToInt32(selectWeekerSection(cmbWeakerSection.SelectedItem.ToString())) + "," +
                     "" + Convert.ToInt32(selectDisadvantage(cmbDisadvantageGroup.SelectedItem.ToString())) + "," + Convert.ToInt32(selectClass(cmbClass.SelectedItem.ToString())) + "," + Convert.ToInt32(selectClass(cmbPreviousClass.SelectedItem.ToString())) + "," + Convert.ToInt32(selectPrevYearStatus(cmbPreviouYearStatus.SelectedItem.ToString())) + ",'" + txtAttendance.Text.ToString() + "'," + Convert.ToInt32(selectMedium(cmbMediumOfInstruction.SelectedItem.ToString())) + "," +
                     "" + Convert.ToInt32(selectDisability(cmbDisability.SelectedItem.ToString())) + "," + Convert.ToInt32(selectNaYesNo(cmbRetAct.SelectedItem.ToString())) + "," + Convert.ToInt32(selectFacility(cmbFacility.SelectedItem.ToString())) + "," + Convert.ToInt32(selectNaYesNo(cmbSetOfTextbook.SelectedItem.ToString())) + "," + Convert.ToInt32(selectUniform(cmbUniformSet.SelectedItem.ToString())) + "," + Convert.ToInt32(selectNaYesNo(cmbTransportFacility.SelectedItem.ToString())) + "," + Convert.ToInt32(selectNaYesNo(cmbEscortFacility.SelectedItem.ToString())) + "," +
                    "" + Convert.ToInt32(selectHostel(cmbHostelFacility.SelectedItem.ToString())) + "," + Convert.ToInt32(selectTraining(cmbSpacialTraining.SelectedItem.ToString())) + "," + Convert.ToInt32(selectHomeless(cmbHomeless.SelectedItem.ToString())) + ")";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Student inserted successfully.");
                else
                    MessageBox.Show("Student can't inserted.");
                con.Close();
                // loadStudents();
                clear();
            }
            else
            {
                MessageBox.Show("Please fill whole form.");
            }
        }


        private void studentGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Main.DeleteStudent del = new DeleteStudent();
            del.Show();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //loadStudents();
            Main.showStudents showStu = new showStudents();
            showStu.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Main.Modify modify = new Modify();
            modify.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        public bool TestRange(string numberToCheck)
        {
            char[] number = numberToCheck.ToCharArray();
            if (number.Length <= 10)
                return true;
            else return false;
        }

        private void txtAdmissionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122))
            {
                e.Handled = true;
                MessageBox.Show("Invalid Input");
            }
            else if (e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                if (TestRange(txtAdmissionNo.Text.ToString()))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
