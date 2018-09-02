using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.IO;

public partial class MethodInvokeWithJQuery : System.Web.UI.Page
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _mobileNo;
        private string _relation;
        private string _photoPath;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Relation
        {
            get { return _relation; }
            set { _relation = value; }
        }
        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }

        public string PhotoPath
        {
            get { return _photoPath; }
            set { _photoPath = value; }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string MethodWithNoParameter()
    {
        return "Message from server.";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strParam"></param>
    /// <returns></returns>
    [WebMethod]
    public static void deletePerson(string strParam)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        string sql = "delete from heritagePerson where mobileNo='" + strParam + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsonParam"></param>
    /// <returns></returns>
    [WebMethod]
    public static string addPerson(object jsonParam)
    {
        Person objPerson = GetPerson(jsonParam);
        string oldPath = objPerson.PhotoPath.ToString();
        string path = oldPath.Replace("\\", "/");
        string[] pathArr = path.Split('/');
        string finalPath = "../personImg/" + pathArr[pathArr.Length - 1];
        if (MethodInvokeWithJQuery.checkMobileUnique(objPerson.MobileNo.ToString()))
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            con.Open();
            string sql = "insert into heritagePerson(mobileNo,relation,firstName,lastName,photoPath) values('" + objPerson.MobileNo + "','" + objPerson.Relation + "','" + objPerson.FirstName + "','" + objPerson.LastName + "','" + objPerson.PhotoPath + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                return "Parameter sent to server from client side as follows:<br/>First Name => " +
                    objPerson.FirstName + "<br/>Last Name => " + objPerson.LastName + "<br/>Mobile No: => " + objPerson.MobileNo + "<br/> Relation:" + objPerson.Relation + "<br/>Photo Path:" + finalPath;
            }
            else
            {
                return "Error in storing record.";
            }
        }
        else
        {
            return "Error in storing record.";
        }
        return "";
    }

    [WebMethod]
    public static string updatePerson(object jsonParam)
    {
        Person objPerson = GetPerson(jsonParam);
        string oldPath = objPerson.PhotoPath.ToString();
        string path = oldPath.Replace("\\", "/");
        string[] pathArr = path.Split('/');
        string finalPath = "../personImg/" + pathArr[pathArr.Length - 1];
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        string sql = "update heritagePerson set relation='" + objPerson.Relation + "',firstName='" + objPerson.FirstName + "',lastName='" + objPerson.LastName + "',photoPath='" + objPerson.PhotoPath + "' where mobileNo='" + objPerson.MobileNo + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result > 0)
        {
            return "Parameter sent to server from client side as follows:<br/>First Name => " +
                objPerson.FirstName + "<br/>Last Name => " + objPerson.LastName + "<br/>Mobile No: => " + objPerson.MobileNo + "<br/> Relation:" + objPerson.Relation + "<br/>Photo Path:" + finalPath;
        }
        else
        {
            return "Error in storing record.";
        }
    }

    public static bool checkMobileUnique(string mobileNo)
    {
        bool flag = false;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        string sql = "select mobileNo from heritagePerson where mobileNo='" + mobileNo + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        string result = (string)cmd.ExecuteScalar();
        if (result == null)
        {
            return true;
        }
        con.Close();
        return flag;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Person"></param>
    /// <returns></returns>
    public static Person GetPerson(object Person)
    {
        Person objPerson = new Person();
        Dictionary<string, object> tmp = (Dictionary<string, object>)Person;

        object objFirstName = null;
        object objLastName = null;
        object objRelation = null;
        object objMobileNo = null;
        object objPhotoPath = null;

        tmp.TryGetValue("FirstName", out objFirstName);
        tmp.TryGetValue("LastName", out objLastName);
        tmp.TryGetValue("Relation", out objRelation);
        tmp.TryGetValue("MobileNo", out objMobileNo);
        tmp.TryGetValue("PhotoPath", out objPhotoPath);

        objPerson.FirstName = objFirstName.ToString();
        objPerson.LastName = objLastName.ToString();
        objPerson.Relation = objRelation.ToString();
        objPerson.MobileNo = objMobileNo.ToString();
        objPerson.PhotoPath = objPhotoPath.ToString();

        return objPerson;
    }
}
