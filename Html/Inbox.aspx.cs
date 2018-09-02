using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Html_Inboxaspx : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadValue();
        }
    }
    private void LoadValue()
    {
        try
        {
            //string Sql = "Select SenderMobile,Msg, Date from SMSStoring where ReceiverMobile='" + Convert.ToString(Session["Mobile"]) + "' order by Date desc";
            //string Sql = "Select SenderMobile,Msg,sendDateTime,usrFirstName+' '+usrLastName as FullName,Date from SMSStoring  inner join UserMaster  on SenderMobile=usrMobileNo where ReceiverMobile='" + Convert.ToString(Session["Mobile"]) + "' order by sendDateTime desc";
            string  Sql = "Select TOP 15 ss.SendFrom,ss.sentMessage as Msg,ss.sendDateTime as Date,um.usrFirstName+' '+um.usrLastName as FullName from sendSMSstatus ss  inner join UserMaster um on ss.SendFrom=um.usrMobileNo where SendTo='" + Convert.ToString(Session["Mobile"]) + "' order by ss.sendDateTime desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            //string mob = Convert.ToString(ds.Tables[0].Rows[0]["SenderMobile"]);
            
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    //Paging for the Item Grid
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadValue();
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../html/SendSMS.aspx");
    }
}
