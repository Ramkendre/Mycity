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

public partial class html_InboxSms : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string UserIdSession = Convert.ToString(Session["User"]);
            if (UserIdSession == "")
            {
                Response.Redirect("../default.aspx");
            }
            else
            {

                if (!IsPostBack)
                {
                    LoadValue();
                }
            }
        }
        catch (Exception ex)
        { }

    }
    private void LoadValue()
    {
        try
        {
            string Sql = "select top(15)SendFrom,SendTo,sentMessage,SendDateTime from sendSMSstatus where SendTo='" + Session["MobileNo"].ToString() + "' order by id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadValue();
    }
}
