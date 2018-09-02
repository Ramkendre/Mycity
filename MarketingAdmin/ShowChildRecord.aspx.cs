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

public partial class MarketingAdmin_ShowChildRecord : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    SqlConnection conSchool = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadGridApp();
    }
    protected void btnSubmitT_Click(object sender, EventArgs e)
    {
        LoadGridCTeacher();
    }
    protected void btnSubmitL_Click(object sender, EventArgs e)
    {
        LoadGridLogin();
    }
    public void loadGridApp()
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand("select [firstName],[lastName],[firmName],Qualification,[mobileNo],[RefMobileNo],[EntryDate] from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + txtMobNo.Text + "' and [keyword]='Ezeestorm'");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Connection = con;
        con.Open();
        da.Fill(ds);
        gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();
        
    }

    public void LoadGridCTeacher()
    {
        DataSet ds = new DataSet();
        string s = string.Empty;
       //string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
       //if (txtDateT.Text == "")
       //{

       //    SqlCommand cmd = new SqlCommand("Select [SchoolCode],[SessionID],[SectionID],[Classcode],[T_MobileNo],[T_FullName],[T_emailID],[ReferenceMobileNo],[CurrentDate] from [DBeZeeSchool].[dbo].[tblClass_Setting] where [ReferenceMobileNo]='" + txtMobNoT.Text + "' ");
       //    SqlDataAdapter da = new SqlDataAdapter(cmd);
       //    cmd.Connection = conSchool;
       //    conSchool.Open();
       //    da.Fill(ds);
       //}
       //else
       //{
        string st = "select [SchoolCode] from [DBeZeeSchool].[dbo].[tblClass_Setting] where [ReferenceMobileNo]='" + txtMobNoT.Text + "' ";
        DataSet ds0 = cc.SchoolDataset(st);
        if (ds0.Tables[0].Rows.Count > 0)
        {
            s = ds0.Tables[0].Rows[0][0].ToString();
        }
        else
        { 
        
        }

        string str =
                 " with Storm as( " +
                 " select CompanyName,Name,Session,Division,[T_MobileNo],[T_FullName],[T_emailID],[ReferenceMobileNo],[CurrentDate]  from( " +
                 " (select [SchoolCode] as s,SessionID as sid,[SectionID] as d,[Classcode],[T_MobileNo],[T_FullName],[T_emailID],[ReferenceMobileNo],[CurrentDate] from [DBeZeeSchool].[dbo].[tblClass_Setting] where SchoolCode='" + s + "') as t1 " +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[CompanyMaster] as t2  " +
                 " on " +
                 " t1.s=t2.SchoolCode " +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[ItemValue] as t3 " +
                 " on " +
                 " t1.Classcode=t3.ItemValueId " +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[tblRole] as t4 " +
                 " on " +
                 " t1.d=t4.roleId   " +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[session] as t5 " +
                 " on " +
                 " t1.sid=t5.ID   " +
                 " ) " +
                 " ) ";
        str += "select CompanyName,Name,Session,Division,[T_MobileNo],[T_FullName],[T_emailID],[ReferenceMobileNo],[CurrentDate] from Storm";
        SqlCommand cmd = new SqlCommand(str);
           //SqlCommand cmd = new SqlCommand("Select [SchoolCode],[SessionID],[SectionID],[Classcode],[T_MobileNo],[T_FullName],[T_emailID],[ReferenceMobileNo],[CurrentDate] from [DBeZeeSchool].[dbo].[tblClass_Setting] where [ReferenceMobileNo]='" + txtMobNoT.Text + "' ");
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           cmd.Connection = conSchool;
           conSchool.Open();
           da.Fill(ds);
       //}
        gvItemT.DataSource = ds.Tables[0];
        gvItemT.DataBind();
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
    protected void btnSerch_Click(object sender, EventArgs e)
    {

        fillDDLSchoolCode();
    }
    protected void txtSchoolCode_TextChanged(object sender, EventArgs e)
    {

    }
    public void fillDDLSchoolCode()
    {
        DataSet ds = new DataSet();
        string s = "Select [SchoolCode],[CompanyName] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where (SchoolCode like '" + txtSchoolCode.Text + "%') order by  SchoolCode  asc ";
        SqlCommand cmd = new SqlCommand(s);
        cmd.Connection = conSchool;
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
    public void LoadGridLogin()
    {
        DataSet ds = new DataSet();
        string str = "select [CompanyId] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where [SchoolCode]='" + DDLSchoolCode.SelectedValue + "'";
        SqlCommand cmd1 = new SqlCommand(str);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        cmd1.Connection = conSchool;
        if (cmd1.Connection.State == ConnectionState.Closed)
            cmd1.Connection.Open();
        //conSchool.Open();
        da1.Fill(ds);
        string st = ds.Tables[0].Rows[0][0].ToString();

        string str2 =
                 " with Storm as( " +
                 " select CompanyName,RoleName,[LoginId],[UserName],[ContactNo],[Address],[Role],[CompanyId],a  from( " +
                 " (select [LoginId],[UserName],[ContactNo],[Address],[Role],[CompanyId] as s,[Active] as a from [DBeZeeSchool].[dbo].[Login] where [CompanyId]='"+st+"') as t1 " +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[CompanyMaster] as t2  " +
                 " on " +
                 " t1.s=t2.CompanyId " +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[tblRole] as t3 " +
                 " on " +
                 " t1.Role=t3.RoleSubId " +
                 " ) " +
                 " ) ";
        str2 += "select CompanyName,RoleName,[LoginId],[UserName],[ContactNo],[Address],[Role],a from Storm";
        SqlCommand cmd = new SqlCommand(str2);
        //SqlCommand cmd = new SqlCommand("Select [LoginId],[UserName],[ContactNo],[Address],[Role],[CompanyId],[Active]  FROM [DBeZeeSchool].[dbo].[Login] where [CompanyId]='" + st + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Connection = conSchool;
        //conSchool.Open();
        da.Fill(ds);
        //}
        gvItemL.DataSource = ds.Tables[0];
        gvItemL.DataBind();
    }
    protected void lnkAppReg_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        loadGridApp();
    }
    protected void lnkCTeacher_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        //LoadGridInst();

        //LoadGridCTeacher();
    }
    protected void lnkHMTeacher_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View3);
        //LoadGridLogin();
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {
        //MultiView1.ActiveViewChanged = -1;
    }
}
