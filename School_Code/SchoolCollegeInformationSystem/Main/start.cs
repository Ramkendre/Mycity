using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SchoolCollegeInformationSystem.Main
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        App_Code.Connection conObj = new App_Code.Connection();

        private void start_Load(object sender, EventArgs e)
        {

            string allDbPath = conObj.getAllDatabaseFiles();
            string[] filePaths = Directory.GetFiles(allDbPath, "*.accdb");
            schoolList.Items.Clear();
            schoolList.Items.Add("Add New");
            for (int count = 0; count < filePaths.Length; count++)
            {
                char[] schoolDbPath = filePaths[count].ToCharArray();
                string schoolId = string.Empty;
                for (int scid = schoolDbPath.Length - 7; scid >= schoolDbPath.Length - 17; scid--)
                {
                    schoolId += schoolDbPath[scid].ToString();
                }
                schoolList.Items.Add(reverseString(schoolId));
            }
        }

        public string reverseString(string source)
        {
            char[] sourceArr = source.ToCharArray();
            string destination = string.Empty;
            for (int count = sourceArr.Length - 1; count >= 0; count--)
            {
                destination += sourceArr[count].ToString();
            }
            return destination;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (schoolList.SelectedItem.ToString() == "Add New")
            {
                Main.AddSchool addSchoolObj = new AddSchool();
                addSchoolObj.Show();
                this.Close();
            }
            else
            {
                conObj.setDatabase(schoolList.SelectedItem.ToString());
                Main.schoolInfo schoolInfoObj = new schoolInfo();
                this.Close();
                schoolInfoObj.Show();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
