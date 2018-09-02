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

public partial class MarketingAdmin_StormAbsentyReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);

    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

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

        //fillDDLSchoolCode();
    }
    protected void txtSchoolCodeSP_TextChanged(object sender, EventArgs e)
    {

    }
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
    public void loadgrid()
    {
        string str =
                " with Storm as( " +
                " select *from( " +
                " (SELECT [StaffAbsId],[T_Name],[T_MobileNo],[Role],[Remark],[AbsentOption],[Time],[date],[SchoolCode] as s,[currentdate] FROM [DBeZeeSchool].[dbo].[tblStaffAbsentyRpt] where schoolcode like ('" + txtSchoolCodeSP.Text + "%') and Date='" + txtDateSP.Text + "' and AbsentOption='" + ddlActiveOption.SelectedValue + "' ) as t1" +
                " inner join " +
                " [DBeZeeSchool].[dbo].[CompanyMaster] as t2 " +
                " on " +
                " t1.s=t2.SchoolCode " +
                  " ) " +
                " ) ";
        str += "select CompanyName,[StaffAbsId],[T_Name],[T_MobileNo],[Role],[Remark],[AbsentOption],[Time],[date],s,[currentdate] from Storm";
        SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        
        gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();
    }
}
