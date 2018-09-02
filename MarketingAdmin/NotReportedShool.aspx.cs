using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class MarketingAdmin_NotReportedShool : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    int NotReportedCount = 0, NotReportedstaffCount = 0, NotReportedClasscount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //fillDDLSchoolCode();
        }
    }

    //[System.Web.Script.Services.ScriptMethod()]
    //[System.Web.Services.WebMethod]
    //public static List<string> SchoolCode(string prefixText)
    //{
    //    string conn = ConfigurationManager.AppSettings["ConnectionString"];
    //    SqlConnection con = new SqlConnection(conn);
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("Select [SchoolCode] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where SchoolCode like @SchoolCode+'%'", con);
    //    cmd.Parameters.AddWithValue("@SchoolCode", prefixText);
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    //da.Fill(dr);
    //    List<string> CountryNames = new List<string>();
    //    while (dr.Read())
    //    {
    //        CountryNames.Add(dr["SchoolCode"].ToString());
    //    }
    //    return CountryNames;
    //    //for (int i = 0; i < dt.Rows.Count; i++)
    //    //{
    //    //    CountryNames.Add(dt.Columns["mobileNo"]..ToString());
    //    //}
    //    //return CountryNames;
    //}
    //public void fillDDLSchoolCode()
    //{
    //    string s = "Select [SchoolCode],[CompanyName] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where (SchoolCode like '" + txtSchoolCodeSP.Text + "%') order by  SchoolCode  asc ";
    //    SqlCommand cmd = new SqlCommand(s);
    //    cmd.Connection = con;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(ds);
    //    DDLSchoolCodeSP.DataSource = ds.Tables[0];
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        DDLSchoolCodeSP.DataValueField = "SchoolCode";
    //        DDLSchoolCodeSP.DataTextField = "CompanyName";
    //    }
    //    DDLSchoolCodeSP.DataBind();
    //    DDLSchoolCodeSP.Items.Add("--Select--");
    //    DDLSchoolCodeSP.SelectedIndex = DDLSchoolCodeSP.Items.Count - 1;
    //    DDLSchoolCodeSP.Items[DDLSchoolCodeSP.Items.Count - 1].Value = "";
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadgrid();
    }
    protected void btnSerchSP_Click(object sender, EventArgs e)
    {
        //fillDDLSchoolCode();
    }
    protected void txtSchoolCodeSP_TextChanged(object sender, EventArgs e)
    {

    }

    public void loadgrid()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        DataTable dt = new DataTable();

        //string sc = "select Distinct Qualification,[mobileNo] from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [typeOfUse_Id]='5' and Qualification like '" + txtSchoolCodeSP.Text + "%'";
        string sc = "select SchoolCode from [DBeZeeSchool].[dbo].[CompanyMaster] where  SchoolCode like '" + txtSchoolCodeSP.Text + "%'";
        DataSet ds1 = cc.SchoolDataset(sc);
                  
        
        dt.Columns.Add("schoolcode", typeof(string));
        //dt.Columns.Add("HMNO",typeof(string));
        dt.Columns.Add("SPR",typeof(string));
        dt.Columns.Add("SAR",typeof(string));
        dt.Columns.Add("ClassRpt",typeof(string));

        for (int i = 0; i < ds1.Tables[0].Rows.Count;i++ )
        {
            string schoolcode = ds1.Tables[0].Rows[i]["SchoolCode"].ToString();

            string sql = "select * from [DBeZeeSchool].[dbo].[tblStaffAttendance] where [schoolcode] ='" + schoolcode + "' and [Date]='" + txtDateSP.Text + "'";
            sql += "select * from [DBeZeeSchool].[dbo].[tblStaffAbsentyRpt] where [SchoolCode] = '" + schoolcode + "' and date='" + txtDateSP.Text + "'";
            sql += "select * from [DBeZeeSchool].[dbo].[tblStudentAttendanceRpt] where [SchoolCode]= '" + schoolcode + "' and Date='" + txtDateSP.Text + "'";
            
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            //string HMNO = ds1.Tables[0].Rows[i]["mobileNo"].ToString();
            
            if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0 && ds.Tables[2].Rows.Count == 0)
            { NotReportedCount++; }
            else if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0 && ds.Tables[2].Rows.Count != 0)
            { NotReportedstaffCount++; }
            else if (ds.Tables[0].Rows.Count != 0 && ds.Tables[1].Rows.Count != 0 && ds.Tables[2].Rows.Count == 0)
            { NotReportedClasscount++; }

            dt.Rows.Add(schoolcode, ds.Tables[0].Rows.Count, ds.Tables[1].Rows.Count, ds.Tables[2].Rows.Count);
            ds.Clear();
        }
        lblnotreportedcount.Text = NotReportedCount.ToString();
        lblnotreportedstaff.Text = NotReportedstaffCount.ToString();
        lblnotreportedclass.Text = NotReportedClasscount.ToString();

        gvItem.DataSource = dt;
        gvItem.DataBind();
        
    }
}
