using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_Report : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["MarketingUser"]) == "" || Session["MarketingUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                LoadAllUser();
                if (Convert.ToString(Session["MarketingUser"]) == "Admin" || Convert.ToString(Session["MarketingUser"]) == "admin")
                {
                    pnlUser.Visible = true;
                }
                else
                {
                    pnlUser.Visible = false;
                    ddlMarketingPerson.SelectedValue = Convert.ToString(Session["User"]);
                    ShowReports();
                }
            }
        }
    }

    private void LoadAllUser()
    {
        string Sql = "SELECT [usrUserId] as UserId,[usrFirstName] +' '+[usrMiddleName]+' '+[usrLastName] as Name " +
                  "  FROM [UserMaster]  where isMarketingPerson='Y' and [usrFirstName] +' '+[usrMiddleName]+' '+[usrLastName] is not null ";
        DataSet ds = cc.ExecuteDataset(Sql);
        ddlMarketingPerson.DataSource = ds.Tables[0];
        ddlMarketingPerson.DataTextField = "Name";
        ddlMarketingPerson.DataValueField = "UserId";
        ddlMarketingPerson.DataBind();
        ddlMarketingPerson.Items.Add("--Select--");
        ddlMarketingPerson.SelectedIndex = ddlMarketingPerson.Items.Count - 1;
    }

    private void ShowReports()
    {
        if (ddlMarketingPerson.SelectedIndex == ddlMarketingPerson.Items.Count - 1)
        {
            //gvAddressBook.DataSource = null;
           // gvAddressBook.DataBind();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz select Marketing Person')", true);
        }
        else
        {
            string Sql = "SELECT isnull(UserMaster.usrFirstName,'')+' '+ isnull(UserMaster.usrMiddleName,'')+' '+ isnull(UserMaster.usrLastName,'') as Name, " +
                " UserMaster.usrMobileNo as MobileNo, cast(DatePart(day,MarketingRecord.RecordDate) as nvarchar(2))+'/'+cast(DatePart(month,MarketingRecord.RecordDate) as nvarchar(2))+'/'+cast(DatePart(year,MarketingRecord.RecordDate) as nvarchar(4)) as RecordDate " +
                " FROM         MarketingRecord INNER JOIN UserMaster ON MarketingRecord.UserId = UserMaster.usrUserId " +
                " where   MarketingRecord.MarketingId='" + ddlMarketingPerson.SelectedValue.ToString() + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            ViewState["Data"] = ds;
            gvAddressBook.DataSource = ds.Tables[0];
            gvAddressBook.DataBind();
            
            lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
            lblttlrecord.Visible = true;
        }
    }
    
    protected void gvAddressBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            gvAddressBook.DataSource = ds.Tables[0];
            gvAddressBook.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnViewAllEntry_Click(object sender, EventArgs e)
    {
        ShowReports();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
}
