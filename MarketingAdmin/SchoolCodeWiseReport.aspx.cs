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

public partial class MarketingAdmin_SchoolCodeWiseReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);

    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadGrid();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }
    protected void btnSubmitT_Click(object sender, EventArgs e)
    {
        LoadGridT();
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SchoolCode(string prefixText)
    {
        string conn = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select [SchoolCode] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where SchoolCode like @SchoolCode+'%'", con);
        cmd.Parameters.AddWithValue("@SchoolCode", prefixText);
        SqlDataReader dr = cmd.ExecuteReader();
        //da.Fill(dr);
        List<string> CountryNames = new List<string>();
        while (dr.Read())
        {
            CountryNames.Add(dr["SchoolCode"].ToString());
        }
        return CountryNames;
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    CountryNames.Add(dt.Columns["mobileNo"]..ToString());
        //}
        //return CountryNames;

    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SchoolCodeT(string prefixText)
    {
        string conn = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select [SchoolCode] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where SchoolCode like @SchoolCode+'%'", con);
        cmd.Parameters.AddWithValue("@SchoolCode", prefixText);
        SqlDataReader dr = cmd.ExecuteReader();
        //da.Fill(dr);
        List<string> CountryNames = new List<string>();
        while (dr.Read())
        {
            CountryNames.Add(dr["SchoolCode"].ToString());
        }
        return CountryNames;
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    CountryNames.Add(dt.Columns["mobileNo"]..ToString());
        //}
        //return CountryNames;

    }

    protected void btnSerch_Click(object sender, EventArgs e)
    {
        fillDDLSchoolCode();
    }
    protected void btnSearchT_Click(object sender, EventArgs e)
    {
        fillDDLSchoolCodeT();
    }
    protected void txtSchoolCode_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void lnkSchoolCodeWiseReport_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        //LoadGridLogin();

    }
    protected void lnkSchoolCodeTimeWiseReport_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        //LoadGridLogin();
    }
    public void fillDDLSchoolCode()
    {
        string s = "Select [SchoolCode],[CompanyName] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where (SchoolCode like '" + txtSchoolCode.Text + "%') order by  SchoolCode  asc ";
        SqlCommand cmd = new SqlCommand(s);
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DDLSchoolCode.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            DDLSchoolCode.DataValueField = "SchoolCode";
            DDLSchoolCode.DataTextField = "CompanyName";
        }
        DDLSchoolCode.DataBind();
        DDLSchoolCode.Items.Add("--Select--");
        DDLSchoolCode.SelectedIndex = DDLSchoolCode.Items.Count - 1;
        DDLSchoolCode.Items[DDLSchoolCode.Items.Count - 1].Value = "";
    }
    public void fillDDLSchoolCodeT()
    {
        string s = "Select [SchoolCode],[CompanyName] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where (SchoolCode like '" + txtSCode.Text + "%') order by  SchoolCode  asc ";
        SqlCommand cmd = new SqlCommand(s);
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlSCode.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSCode.DataValueField = "SchoolCode";
            ddlSCode.DataTextField = "CompanyName";
        }
        ddlSCode.DataBind();
        ddlSCode.Items.Add("--Select--");
        ddlSCode.SelectedIndex = ddlSCode.Items.Count - 1;
        ddlSCode.Items[ddlSCode.Items.Count - 1].Value = "";
    }
    public void LoadGrid()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        DataTable dt = new DataTable();
        if (txtDate.Text == "")
        {
            string str =
                   " with Event as( " +
                   " select [SchoolCode],CompanyName,[TeacherMobNo],Name,Division,[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from( " +
                   " ( Select [TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[SchoolCode] as s,[TeacherMobNo],[Class] as c,Division as d,[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from [DBeZeeSchool].[dbo].[tblStudentAttendanceRpt] where [Date]='" + str1 + "' and [SchoolCode]='" + DDLSchoolCode.SelectedValue + "') as t1" +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[CompanyMaster] as t2 " +
                   " on " +
                   " t1.s=t2.SchoolCode " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[ItemValue] as t3 " +
                   " on " +
                   " t1.c=t3.ItemValueId " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[tblRole]  as t4 " +
                   " on " +
                   " t1.d=t4.roleId " +
                     " ) " +
                   " ) ";
            str += "select CompanyName,Name,Division,[TeacherMobNo],[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from Event";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            con.Open();
            da.Fill(ds);
            
        }
        else
        {
            string str =
                   " with Event as( " +
                   " select [SchoolCode],CompanyName,[TeacherMobNo],Name,Division,[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from( " +
                   " ( Select [TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[SchoolCode] as s,[TeacherMobNo],[Class] as c,Division as d,[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from [DBeZeeSchool].[dbo].[tblStudentAttendanceRpt] where [Date]='" + txtDate.Text + "' and [SchoolCode]='" + DDLSchoolCode.SelectedValue + "') as t1" +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[CompanyMaster] as t2 " +
                   " on " +
                   " t1.s=t2.SchoolCode " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[ItemValue] as t3 " +
                   " on " +
                   " t1.c=t3.ItemValueId " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[tblRole]  as t4 " +
                   " on " +
                   " t1.d=t4.roleId " +
                     " ) " +
                   " ) ";
            str += "select CompanyName,Name,Division,[TeacherMobNo],[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from Event";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            con.Open();
            da.Fill(ds);

        //    dt.Columns.Add("SchoolCode", typeof(string));
        //    dt.Columns.Add("Class", typeof(string));
        //    dt.Columns.Add("Division", typeof(string));
        //    dt.Columns.Add("TotalBoys", typeof(string));
        //    dt.Columns.Add("TotalGirls", typeof(string));
        //    dt.Columns.Add("PresentBoys", typeof(string));
        //    dt.Columns.Add("PresentGirls", typeof(string));
        //    dt.Columns.Add("AbsentBoys", typeof(string));
        //    dt.Columns.Add("AbsentGirls", typeof(string));
        //    dt.Columns.Add("Date", typeof(string));
        //    dt.Columns.Add("Time", typeof(string));
        //    dt.Columns.Add("TeacherMobNo", typeof(string));
        //    dt.Columns.Add("TotalStudent", typeof(string));
        //    dt.Columns.Add("TotalPresentStudent", typeof(string));
        //    dt.Columns.Add("CurrrentDate", typeof(string));
        //    dt.Columns.Add("HM_Mobileno", typeof(string));
        //    dt.Columns.Add("OwnerMobileNo", typeof(string));

        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //            string cl = ds.Tables[0].Rows[i]["Class"].ToString();
        //            string c = "select [Name] FROM [DBeZeeSchool].[dbo].[ItemValue] where [ItemValueId]='"+cl+"'";
        //            DataSet ds1 = cc.SchoolDataset(c);
        //            string Class = ds1.Tables[0].Rows[i]["Name"].ToString();

        //            string di = ds.Tables[0].Rows[i]["Division"].ToString();
        //            string d = "select [Name] FROM [DBeZeeSchool].[dbo].[ItemValue] where [ItemValueId]='" + di + "'";
        //            DataSet ds2 = cc.SchoolDataset(d);
        //            string Division = ds2.Tables[0].Rows[i]["Name"].ToString();

        //            string sc = ds.Tables[0].Rows[i]["SchoolCode"].ToString();
        //            string s = "select [CompanyName] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where [SchoolCode]='" + sc + "'";
        //            DataSet ds3 = cc.SchoolDataset(s);
        //            string SchoolCode = ds3.Tables[0].Rows[i]["CompanyName"].ToString();

        //            //dt.Rows.Add(ds3.Tables[0].Rows[i][0], ds1.Tables[0].Rows[i][1], ds2.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ds.Tables[0].Rows[i][7], ds.Tables[0].Rows[i][8], ds.Tables[0].Rows[i][9], ds.Tables[0].Rows[i][10], ds.Tables[0].Rows[i][11], ds.Tables[0].Rows[i][12], ds.Tables[0].Rows[i][13], ds.Tables[0].Rows[i][14], ds.Tables[0].Rows[i][15]);

        //            //dt.Rows.Add(ds3.Tables[0].Rows[i]["CompanyName"], ds1.Tables[0].Rows[i]["Name"], ds2.Tables[0].Rows[i]["Name"], ds.Tables[0].Rows[i]["TotalBoys"], ds.Tables[0].Rows[i]["TotalGirls"], ds.Tables[0].Rows[i]["PresentBoys"], ds.Tables[0].Rows[i]["PresentGirls"], ds.Tables[0].Rows[i]["AbsentBoys"], ds.Tables[0].Rows[i]["AbsentGirls"], ds.Tables[0].Rows[i]["Date"], ds.Tables[0].Rows[i]["Time"], ds.Tables[0].Rows[i]["TeacherMobNo"], ds.Tables[0].Rows[i]["TotalStudent"], ds.Tables[0].Rows[i]["TotalPresentStudent"], ds.Tables[0].Rows[i]["CurrrentDate"], ds.Tables[0].Rows[i]["HM_Mobileno"]);

        //            dt.Rows.Add(SchoolCode,Class, Division, ds.Tables[0].Rows[i]["TotalBoys"], ds.Tables[0].Rows[i]["TotalGirls"], ds.Tables[0].Rows[i]["PresentBoys"], ds.Tables[0].Rows[i]["PresentGirls"], ds.Tables[0].Rows[i]["AbsentBoys"], ds.Tables[0].Rows[i]["AbsentGirls"], ds.Tables[0].Rows[i]["Date"], ds.Tables[0].Rows[i]["Time"], ds.Tables[0].Rows[i]["TeacherMobNo"], ds.Tables[0].Rows[i]["TotalStudent"], ds.Tables[0].Rows[i]["TotalPresentStudent"], ds.Tables[0].Rows[i]["CurrrentDate"], ds.Tables[0].Rows[i]["HM_Mobileno"]);
        //        }




        }
        gvItem.DataSource = ds;

        gvItem.DataBind();
      
    }

    public void LoadGridT()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        DataTable dt = new DataTable();
        if (txtDateT.Text == "")
        {
            string str =
                   " with Event as( " +
                   " select [SchoolCode],CompanyName,[TeacherMobNo],Name,Division,[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from( " +
                   " ( Select [TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[SchoolCode] as s,[TeacherMobNo],[Class] as c,Division as d,[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from [DBeZeeSchool].[dbo].[tblStudentAttendanceRpt] where [Date]='" + str1 + "' and [SchoolCode]='" + ddlSCode.SelectedValue + "' and (Time>='" + txtTime.Text + "' and Time<='" + txtTime2.Text + "' )) as t1" +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[CompanyMaster] as t2 " +
                   " on " +
                   " t1.s=t2.SchoolCode " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[ItemValue] as t3 " +
                   " on " +
                   " t1.c=t3.ItemValueId " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[tblRole]  as t4 " +
                   " on " +
                   " t1.d=t4.roleId " +
                     " ) " +
                   " ) ";
            str += "select CompanyName,Name,Division,[TeacherMobNo],[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from Event";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            con.Open();
            da.Fill(ds);

        }
        else
        {
            string str =
                   " with Event as( " +
                   " select [SchoolCode],CompanyName,[TeacherMobNo],Name,Division,[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from( " +
                   " ( Select [TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[SchoolCode] as s,[TeacherMobNo],[Class] as c,Division as d,[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from [DBeZeeSchool].[dbo].[tblStudentAttendanceRpt] where [Date]='" + txtDateT.Text + "'  and [SchoolCode]='" + ddlSCode.SelectedValue + "' and (Time>='" + txtTime.Text + "' and Time<='" + txtTime2.Text + "' )) as t1" +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[CompanyMaster] as t2 " +
                   " on " +
                   " t1.s=t2.SchoolCode " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[ItemValue] as t3 " +
                   " on " +
                   " t1.c=t3.ItemValueId " +
                   " inner join " +
                   " [DBeZeeSchool].[dbo].[tblRole]  as t4 " +
                   " on " +
                   " t1.d=t4.roleId " +
                     " ) " +
                   " ) ";
            str += "select CompanyName,Name,Division,[TeacherMobNo],[TotalBoys],[TotalGirls],[PresentBoys],[PresentGirls],[AbsentBoys],[AbsentGirls],[Date],[Time],[TotalStudent],[TotalPresentStudent],[CurrrentDate],[HM_Mobileno],[OwnerMobileNo] from Event";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            con.Open();
            da.Fill(ds);

        }
        gvItemT.DataSource = ds;

        gvItemT.DataBind();

    }
}
