using System;
using System.IO;
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
    public partial class AddSchool : Form
    {
        public AddSchool()
        {
            InitializeComponent();
        }

        App_Code.Connection conObj = new App_Code.Connection();

        public bool insertSchool()
        {
            bool output = false;
            string filepath = conObj.getAllDatabaseFiles();
            string dbCopyPath = filepath.Replace("schoolDatabase", "Database");
            string newFilePath = filepath + txtSchoolCode.Text.ToString() + ".accdb";
            dbCopyPath += "NewSchool.accdb";
            if (File.Exists(dbCopyPath))
            {
                File.Copy(dbCopyPath, newFilePath);
                if (insertRecord(txtSchoolCode.Text.ToString()))
                {
                    output = true;
                }
                else
                {
                    output = false;
                }
            }
            else
            {
                MessageBox.Show("Database file proble. Contact to support team.");
                output = false;
            }
            return output;
        }

        public bool insertRecord(string dbpath)
        {
            bool inserted = false;
            conObj.setDatabase(dbpath.ToString());
            OleDbConnection con = new OleDbConnection(conObj.getConPath());
            con.Open();
            string sql = "insert into school(schoolName,schoolCode) values('" + txtSchoolName.Text.ToString() + "','" + txtSchoolCode.Text.ToString() + "')";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
                inserted = true;
            else inserted = false;
            return inserted;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtSchoolCode.Text = "";
            txtSchoolName.Text = "";
            this.Close();
            Main.start startObj = new start();
            startObj.Show();
        }

        private void txtSchoolCode_KeyPress(object sender, KeyPressEventArgs e)
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
                if (TestRange(txtSchoolCode.Text.ToString()))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        public bool TestRange(string numberToCheck)
        {
            char[] number = numberToCheck.ToCharArray();
            if (number.Length <= 10)
                return true;
            else return false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtSchoolCode.Text != "")
            {
                if (txtSchoolName.Text != "")
                {
                    if (insertSchool())
                    {
                        MessageBox.Show("School/College Successfully Inserted.");
                        this.Close();
                        Main.schoolInfo schoolInfoObj = new schoolInfo();
                        schoolInfoObj.Show();
                    }
                    else
                    {
                        MessageBox.Show("Problem is database. Contact to support team.");
                    }

                }
                else
                {
                    MessageBox.Show("Please fill school name.");
                }
            }
            else
            {
                MessageBox.Show("Please fill numeric 11 digit school code.");
            }
        }

        private void AddSchool_Load(object sender, EventArgs e)
        {

        }
    }
}
