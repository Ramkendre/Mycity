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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class MarketingAdmin_MyctProjects : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadGrid();
    }
    protected void lnkRegUser_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        LoadGrid();
        //LoadGridLogin();

    }
    protected void lnkApp_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        LoadGridApp();
        //LoadGridLogin();

    }
    protected void lnkBack_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View3);
        LoadGridBack();
        //LoadGridLogin();

    }
    public void LoadGrid()
    {
        string str = "select [ProjectName],[ProjectType] FROM [Come2myCityDB].[come2mycity].[tbl_AbhinavITProjects] where ProjectType='WebSite'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();
    }
    public void LoadGridApp()
    {
        string str = "select [ProjectName],[ProjectType] FROM [Come2myCityDB].[come2mycity].[tbl_AbhinavITProjects] where ProjectType='App'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        gvItemApp.DataSource = ds.Tables[0];
        gvItemApp.DataBind();
    }
    public void LoadGridBack()
    {
        string str = "select [ProjectName],[ProjectType] FROM [Come2myCityDB].[come2mycity].[tbl_AbhinavITProjects] where ProjectType='BackOffice'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        gvItemBack.DataSource = ds.Tables[0];
        gvItemBack.DataBind();
    }
}
