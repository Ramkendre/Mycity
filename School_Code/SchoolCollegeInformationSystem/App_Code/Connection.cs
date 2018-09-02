using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolCollegeInformationSystem.App_Code
{
    class Connection
    {
        public static string databaseName;

        public void setDatabase(string dbname)
        {
            databaseName = dbname.ToString() + ".accdb";
        }

        public string getDatabase()
        {
            return databaseName;
        }

        public string getConPath()
        {
            string ConnPath = "";
            string dbPath = string.Empty;
            string path1 = Application.ExecutablePath;
            string path2 = path1.Substring(0, path1.Length - 34);
            dbPath = path2 + "schoolDatabase\\" + getDatabase();
            ConnPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath + ";Persist Security Info=True;Jet OLEDB:Database Password=mahesh";
            return ConnPath;
        }

        public string getAllDatabaseFiles()
        {
            string dbPath = string.Empty;
            string path1 = Application.ExecutablePath;
            string path2 = path1.Substring(0, path1.Length - 34);
            dbPath = path2 + "schoolDatabase\\";
            return dbPath;
        }
    }

}
