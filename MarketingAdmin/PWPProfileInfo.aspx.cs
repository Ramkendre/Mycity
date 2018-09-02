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

public partial class MarketingAdmin_PWPProfileInfo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void LoadGrid()
    {
        string str = "Select * from [Come2myCityDB].[come2mycity].[PWP_tblPlayerInfo]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        gvItem.DataSource = ds;
        gvItem.DataBind();
    }
    public void LoadGridClub()
    {
        string str = "Select * from [Come2myCityDB].[come2mycity].[PWP_tblClub]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemClub.DataSource = ds;
        gvItemClub.DataBind();
    }
    public void LoadGridCoach()
    {
        string str = "Select * from [Come2myCityDB].[come2mycity].[PWP_tblCoachInfo]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemCoach.DataSource = ds;
        gvItemCoach.DataBind();
    }
    public void LoadGridInfra()
    {
        string str = "Select * from [Come2myCityDB].[come2mycity].[PWP_tblInfrastructure]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemInfra.DataSource = ds;
        gvItemInfra.DataBind();
    }
    public void LoadGridSpe()
    {
        string str = "Select * from [Come2myCityDB].[come2mycity].[PWP_tblSpecialist]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemSpec.DataSource = ds;
        gvItemSpec.DataBind();
    }
    protected void lnkPlayert_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        LoadGrid();
    }
    protected void lnkClub_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        LoadGridClub();
    }
    protected void lnkCoach_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View3);
        LoadGridCoach();
    }
    protected void lnkInfrast_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View4);
        LoadGridInfra();
    }
    protected void lnkSpecialist_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View5);
        LoadGridSpe();
    }
    //protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvItem.PageIndex = e.NewPageIndex;
    //    gvItem.DataBind();
    //    LoadGrid();
    //}
    protected void  gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        gvItem.DataBind();
        LoadGrid();
    }
    protected void gvItemClub_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemClub.PageIndex = e.NewPageIndex;
        gvItemClub.DataBind();
        LoadGridClub();
    }
    protected void gvItemCoach_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemCoach.PageIndex = e.NewPageIndex;
        gvItemCoach.DataBind();
        LoadGridCoach();
    }
    protected void gvItemInfra_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemInfra.PageIndex = e.NewPageIndex;
        gvItemInfra.DataBind();
        LoadGridInfra();
    }
    protected void gvItemSpec_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemSpec.PageIndex = e.NewPageIndex;
        gvItemSpec.DataBind();
        LoadGridSpe();
    }
}
