using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MarketingAdmin_SMSPushingList : System.Web.UI.Page
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
            string Sql = "Select Id, Name,Msg,TotalMsg,Sent from SMSPushing where Balance>0 order by Id";
            DataSet ds = cc.ExecuteDataset(Sql);
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

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("SMSPushing.aspx");
    }
}
