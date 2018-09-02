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

public partial class MarketingAdmin_HirachyReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
        }
    }
    public void LoadGrid()//'" + Convert.ToString(Session["MarketingUser"]) + "'
    {
        string SqlEo = "Select roleid from AdminSubMarketingSubUser where AdminSubMarketingSubUser.friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";
        string EoUserId = Convert.ToString(cc.ExecuteScalar(SqlEo));
        if (EoUserId == "18")
        {
            string Sql = "Select UserMaster.usrFirstName, UserMaster.usrLastName ,UserMaster.usrMobileNo, AdminSubMarketingSubUser.rolename from UserMaster inner join AdminSubMarketingSubUser " +
                        "on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid " +
                        "where AdminSubMarketingSubUser.reference_id6='" + Convert.ToString(Session["MarketingUser"]) + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
        else if (EoUserId=="76")
        {
            string Sql = "Select UserMaster.usrFirstName, UserMaster.usrLastName ,UserMaster.usrMobileNo, AdminSubMarketingSubUser.rolename from UserMaster inner join AdminSubMarketingSubUser " +
                            "on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid " +
                            "where AdminSubMarketingSubUser.reference_id11='" + Convert.ToString(Session["MarketingUser"]) + "'";

            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
        else if (Session["RoleName"]== "Administrator")
        {
            string Sql = "Select UserMaster.usrFirstName, UserMaster.usrLastName ,UserMaster.usrMobileNo, AdminSubMarketingSubUser.rolename from UserMaster inner join AdminSubMarketingSubUser " +
                            "on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid " +
                            "where AdminSubMarketingSubUser.reference_id1='6dde8c3d-1895-4904-b332-764f63206fc0'and AdminSubMarketingSubUser.roleid=77 or AdminSubMarketingSubUser.roleid=76 or "+
                            "AdminSubMarketingSubUser.roleid=75 or AdminSubMarketingSubUser.roleid=18 or AdminSubMarketingSubUser.roleid=19 "+
                            "and AdminSubMarketingSubUser.roleid=17 or AdminSubMarketingSubUser.roleid=20 or AdminSubMarketingSubUser.roleid=21";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
    }

    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
}
