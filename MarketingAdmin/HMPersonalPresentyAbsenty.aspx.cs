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

public partial class MarketingAdmin_HMPersonalPresentyAbsenty : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void loadgrid()
    {
        DataSet ds = new DataSet();
        string str = "select [SAID],[Time],[Date],[Image],[T_Name],[T_MobileNo],[Latitude],[longitude],[schoolcode],[role],[HM_MobileNo],[OwnerMobNo],[OwnIMEI_No],[currentDate] from [DBeZeeSchool].[dbo].[tblStaffAttendance] where T_MobileNo='" + txtMobileNoP.Text + "' and [Date] >= '" + txtFrmDateP.Text + "' and [Date] <= '" + txtToDateP.Text + "'";
        SqlCommand cmd = new SqlCommand(str);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Connection = con;
        con.Open();
        da.Fill(ds);
        gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();

    }

    public void loadgridA()
    {
        DataSet ds = new DataSet();
        string str = "select [StaffAbsId],[T_Name],[T_MobileNo],[Role],[Remark],[AbsentOption],[Time],[date],[SchoolCode],[currentdate] from [DBeZeeSchool].[dbo].[tblStaffAbsentyRpt] where T_MobileNo='" + txtMobileNoA.Text + "' and [date] >= '" + txtFrmDateA.Text + "' and [date] <= '" + txtToDateA.Text + "'";
        SqlCommand cmd = new SqlCommand(str);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Connection = con;
        con.Open();
        da.Fill(ds);
        gvItemT.DataSource = ds.Tables[0];
        gvItemT.DataBind();
    }
    protected void lnkHMPresenty_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        //LoadGridLogin();

    }
    protected void lnkHMAbsenty_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        //LoadGridLogin();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadgrid();
    }
    protected void btnSubmitT_Click(object sender, EventArgs e)
    {
        //LoadGridT();
        loadgridA();
    }


}
