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

public partial class MarketingAdmin_StaffReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);

    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadGridSAttend();
            LoadGridSAbsenty();
            fillDDLSchoolCode();
        }
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
    protected void btnSerchSP_Click(object sender, EventArgs e)
    {

        fillDDLSchoolCode();
    }
    protected void txtSchoolCodeSP_TextChanged(object sender, EventArgs e)
    {

    }
    public void fillDDLSchoolCode()
    {
        string s = "Select [SchoolCode],[CompanyName] FROM [DBeZeeSchool].[dbo].[CompanyMaster] where (SchoolCode like '" + txtSchoolCodeSP.Text + "%') order by  SchoolCode  asc ";
        SqlCommand cmd = new SqlCommand(s);
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DDLSchoolCodeSP.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            DDLSchoolCodeSP.DataValueField = "SchoolCode";
            DDLSchoolCodeSP.DataTextField = "CompanyName";
        }
        DDLSchoolCodeSP.DataBind();
        DDLSchoolCodeSP.Items.Add("--Select--");
        DDLSchoolCodeSP.SelectedIndex = DDLSchoolCodeSP.Items.Count - 1;
        DDLSchoolCodeSP.Items[DDLSchoolCodeSP.Items.Count - 1].Value = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        LoadGridSAttend();
    }
    protected void btnSubmitT_Click(object sender, EventArgs e)
    {
        LoadGridSAbsenty();
    }
   
    public void LoadGridSAttend()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        if (txtDateSP.Text == "")
        {
            //SqlCommand cmd = new SqlCommand("SELECT [Time],[Date],[Image],[T_Name],[T_MobileNo],[schoolcode],[role],[HM_MobileNo],[OwnerMobNo],[OwnIMEI_No],[currentDate] FROM [DBeZeeSchool].[dbo].[tblStaffAttendance] where schoolcode='" + txtSchoolCodeSP.Text + "' and Date='" + str + "'");
            string str =
                " with Storm as( " +
                " select *from( " +
                " (select [Time] as t,[Date] as d,[Image] as i,[T_Name],[T_MobileNo] as tt,[schoolcode],[role],[HM_MobileNo],[OwnerMobNo],[OwnIMEI_No],[currentDate] as c FROM [DBeZeeSchool].[dbo].[tblStaffAttendance] where [schoolcode]='" + DDLSchoolCodeSP.SelectedValue + "' and [Date]='" + str1 + "' ) as t1" +
                " inner join " +
                " [DBeZeeSchool].[dbo].[tblStoreT_Image] as t2 " +
                " on " +
                " t1.tt=t2.T_MobileNo and t1.d=t2.date " +
                  " ) " +
                " ) ";
            str += "select PID,Time,Date,[Image],[T_Name],tt,[schoolcode],[role],[HM_MobileNo],[OwnerMobNo],[OwnIMEI_No],currentDate from Storm";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds); ;
            
        }
        else
        {
            //SqlCommand cmd = new SqlCommand("SELECT [Time],[Date],[Image],[T_Name],[T_MobileNo],[schoolcode],[role],[HM_MobileNo],[OwnerMobNo],[OwnIMEI_No],[currentDate] FROM [DBeZeeSchool].[dbo].[tblStaffAttendance] where schoolcode='" + txtSchoolCodeSP.Text + "' and Date='" + txtDateSP.Text + "'");
            string str =
                 " with Storm as( " +
                 " select *from( " +
                 " (select [Time] as t,[Date] as d,[Image] as i,[T_Name],[T_MobileNo] as tt,[schoolcode],[role],[HM_MobileNo],[OwnerMobNo],[OwnIMEI_No],[currentDate] as c FROM [DBeZeeSchool].[dbo].[tblStaffAttendance] where [schoolcode]='" + DDLSchoolCodeSP.SelectedValue + "' and [Date]='" + txtDateSP.Text + "' ) as t1" +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[tblStoreT_Image] as t2 " +
                 " on " +
                 " t1.tt=t2.T_MobileNo and t1.d=t2.date " +
                   " ) " +
                 " ) ";
            str += "select PID,Time,Date,[Image],[T_Name],tt,[schoolcode],[role],[HM_MobileNo],[OwnerMobNo],[OwnIMEI_No],currentDate from Storm";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
           
        }
        gvItemSAT.DataSource = ds.Tables[0];
        gvItemSAT.DataBind();
    }
    public void LoadGridSAbsenty()
    {
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
        if (txtDateA.Text == "")
        {
            SqlCommand cmd = new SqlCommand("SELECT [StaffAbsId],[T_Name],[T_MobileNo],[Role],[Remark],[AbsentOption],[Time],[date],[SchoolCode],[currentdate] FROM [DBeZeeSchool].[dbo].[tblStaffAbsentyRpt] where schoolcode='" + txtSchoolCodeA.Text + "' and Date='" + str + "'");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);

        }
        else
        {
            SqlCommand cmd = new SqlCommand("SELECT [StaffAbsId],[T_Name],[T_MobileNo],[Role],[Remark],[AbsentOption],[Time],[date],[SchoolCode],[currentdate] FROM [DBeZeeSchool].[dbo].[tblStaffAbsentyRpt] where schoolcode='" + txtSchoolCodeA.Text + "' and Date='" + txtDateA.Text + "'");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        gvItemT.DataSource = ds.Tables[0];
        gvItemT.DataBind();
    }
    protected void dlFriendRelative_ItemCommand(object source, DataListCommandEventArgs e)
    {
    //    string Id = Convert.ToString(e.CommandArgument);
    //    //lblId.Text = Id;
    //    Response.Redirect("~/html/ViewAddress.aspx?uid=" + Id + "");
    }
    //public void LoadGridImage()
    //{
    //    string st = "select [PID] FROM [DBeZeeSchool].[dbo].[tblStoreT_Image] where [T_MobileNo]='" + txtIMobNo.Text + "' and [date]='"+txtIDate.Text+"'";
    //    SqlCommand cmd = new SqlCommand(st);
    //    cmd.Connection = con;
    //    con.Open();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(ds);
    //    string PID=ds.Tables[0].Rows[0][0].ToString();
        
    //    gvItemImage.DataSource = ds.Tables[0];
    //    gvItemImage.DataBind();
    //}
    protected void lnkStaffAttend_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        //LoadGridLogin();
        
    }
    protected void lnkStaffAbsenty_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        //LoadGridLogin();
    }
    //protected void lnkImage_Click(object sender, EventArgs e)
    //{
    //    MultiView1.SetActiveView(View3);
    //    //LoadGridLogin();
    //}
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {
        //MultiView1.ActiveViewChanged = -1;
    }
    protected void txtDateA_TextChanged(object sender, EventArgs e)
    {
        //LoadGrid();
    }
    protected void txtDateSP_TextChanged(object sender, EventArgs e)
    {
        LoadGridSAttend();
    }

}
