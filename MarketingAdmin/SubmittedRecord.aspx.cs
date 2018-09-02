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

public partial class MarketingAdmin_SubmittedRecord : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridshow();
        }
    }
    private void gridshow()
    {
        string UserName = Convert.ToString(Session["MarketingUser"]);
        string sql = " select data_id,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,usrMobileNo,send_date from Datacollection1 " +
        " inner join AdminSubMarketingSubUser on friendid = sender_mobileno inner join UserMaster on usrUserId = sender_mobileno "+
        " where userid='" + UserName + "' order by send_date desc ";
        DataSet ds = cc.ExecuteDataset(sql);
        gvdisplay.DataSource = ds.Tables[0];
        gvdisplay.DataBind();
        
    }
    protected void gvdisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdisplay.PageIndex = e.NewPageIndex;
        gridshow();
    }
    protected void gvdisplay_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = Convert.ToString(e.CommandArgument);
        if (e.CommandName == "Delete")
        {
            string sql = "delete from datacollection1 where data_id='" + id + "'";
            string a = cc.ExecuteScalar(sql);
            Response.Write("<script>(alert)('Record Deleted Successfully')</script>");
        }
        

        
    }
    protected void gvdisplay_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gvdisplay_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}
