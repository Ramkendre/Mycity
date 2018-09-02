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

public partial class MarketingAdmin_AgentReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAgent();
        }

    }

    private void BindAgent()
    {
        try
        {
            string sql = "select Id,friendid,usrFirstName+' '+usrLastName as usrName from AdminSubMarketingSubUser  right outer join usermaster on AdminSubMarketingSubUser.friendid=usermaster.usrUserid where roleid=9 order by id desc ";
            DataSet ds = cc.ExecuteDataset(sql);
            ddlselectAgent.DataTextField = "usrName";
            ddlselectAgent.DataValueField = "friendid";
            ddlselectAgent.DataSource = ds.Tables[0];
            ddlselectAgent.DataBind();
        }
        catch (Exception ex)
        { }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlselectAgent.SelectedIndex.ToString() == "")
        {
            Response.Write("<scrip>(alert)('Plz select Agent..')</script>");
        }
        else
        {
            clear();
            BindGrid();
        }
    }

    private void BindGrid()
    {
        try
        {
            string sql = "select customer_name,mobileno,customer_contact from LongCodeRegistration where UsrUserid='" + ddlselectAgent.SelectedItem.Value + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            lblName.Text ="Name:"+ Convert.ToString(ds.Tables[0].Rows[0]["customer_name"]);
            lblContactNo.Text ="Contact No: "+ Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
            lblMiscalNo.Text ="Miscal No: "+ Convert.ToString(ds.Tables[0].Rows[0]["customer_contact"]);
             sql = "select id,ResponseMsg,MsgDate from MiscalResponse where userid='" + ddlselectAgent.SelectedItem.Value + "' order by id desc";
            DataSet ds1 = cc.ExecuteDataset(sql);
            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();
        }
        catch (Exception ex)
        { }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblId.Text = Convert.ToString(e.CommandArgument);
        string id = lblId.Text;
        string command = Convert.ToString(e.CommandName);
        if (command == "Calculate")
        {
            string sql = "select MsgCharCount,msgcount from MiscalResponse where id='" + id + "'";
            DataSet ds = cc.ExecuteDataset(sql);

            string count = Convert.ToString(ds.Tables[0].Rows[0]["MsgCharCount"]);
            if (count == "" || count == null)
            {
                count = "0";
            }
            string msgtotalcount = Convert.ToString(ds.Tables[0].Rows[0]["msgcount"]);
            if (msgtotalcount == "" || msgtotalcount == null)
            {
                msgtotalcount = "0";
            }
            lblMsgttlcount.Text = "Total Message Count: " + msgtotalcount;
            
            lblCount.Text = "Message Length: " + count;
            sql = "select count(*) from MiscalResponseCounter where Message_id='" + id + "'";
            string usercount = cc.ExecuteScalar(sql);
            lblusercount.Text = "No. of user: " + usercount;
            int count1 = Convert.ToInt32(count);
            int usrCount = Convert.ToInt32(usercount);
            int msgtotalcount1 = Convert.ToInt32(msgtotalcount);
            int calulation = msgtotalcount1 * usrCount;
            lblCalculation.Text = "Total Calculation :" + calulation;


        }

    }

    private void clear()
    {
        lblMsgttlcount.Text = "";
        lblusercount.Text = "";
        lblCount.Text = "";
        lblCalculation.Text = "";
    }
}
