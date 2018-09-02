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

public partial class MarketingAdmin_ComplaintReply : System.Web.UI.Page
{
    int status;
    KeywordBLL keywordBLLObj = new KeywordBLL();
    DataTable dtkeywordList = new DataTable();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDLGroup();
            //LoadKeyword();
            //clearItems();
        }
    }
    public void FillDDLGroup()
    {
        try
        {
            dtkeywordList = keywordBLLObj.BLLSelectAllGroup();

            ddlGroupName.DataSource = dtkeywordList;
            ddlGroupName.DataTextField = "GroupName";
            ddlGroupName.DataValueField = "GroupId";
            ddlGroupName.DataBind();
            ddlGroupName.Items.Add("---Select---");
            ddlSubGroupName.Items.Add("---Select---");
            ddlSubGroupName.Items[ddlSubGroupName.Items.Count - 1].Value = "";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int groupId = Convert.ToInt32(ddlGroupName.SelectedValue);
            fillDDLSubGroup(groupId);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void fillDDLSubGroup(int GroupId)
    {
        try
        {
            dtkeywordList = keywordBLLObj.BLLSelectSubGroupById(GroupId);
            ddlSubGroupName.DataSource = dtkeywordList;
            ddlSubGroupName.DataTextField = "GroupValueName";
            ddlSubGroupName.DataValueField = "GroupValueId";
            ddlSubGroupName.DataBind();
            ddlSubGroupName.Items.Add("---Select---");
            ddlSubGroupName.SelectedIndex = ddlSubGroupName.Items.Count - 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void loadGrid(string keyName)
    {
        string[] Arr = keyName.Split(' ');
        string sql = "select Message,mobile from test where Message like '" + Arr[0].ToString() + "%'";
        GridView1.DataSource = cc.ExecuteDataset(sql);
        GridView1.DataBind();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        string KeyName = ddlSubGroupName.SelectedItem.ToString();
        loadGrid(KeyName);
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        string KeyName = ddlSubGroupName.SelectedItem.ToString();
        loadGrid(KeyName);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            //int groupId = Convert.ToInt32(ddlSubGroupName.SelectedValue);
            GridView1.PageIndex = e.NewPageIndex;
            string KeyName = ddlSubGroupName.SelectedItem.ToString();

            loadGrid(KeyName);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtBackReply = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtReply");
        Label lblMobile = (Label)GridView1.Rows[e.RowIndex].FindControl("lblMobileNo");
        string sendTo = lblMobile.Text.ToString().Substring(2, 10);
        string sql = "select usrFirstName from userMaster where usrMobileNo='" + sendTo.ToString() + "'";
        string reply = "";
        string returnName = "";
        returnName = cc.ExecuteScalar(sql);
        if (returnName != "")
            reply = "Dear " + returnName.ToString() + "," + txtBackReply.Text.ToString() + " Thanks.via www.myct.in";
        else
            reply = "Dear customer," + txtBackReply.Text.ToString() + " Thanks.via www.myct.in";
        string senderByCT = "myctin";

        cc.SendMessageTra(senderByCT, sendTo, reply);
        GridView1.EditIndex = -1;
        string KeyName = ddlSubGroupName.SelectedItem.ToString();
        loadGrid(KeyName);
    }
    protected void ddlSubGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int groupId = Convert.ToInt32(ddlSubGroupName.SelectedValue);
        string KeyName = ddlSubGroupName.SelectedItem.ToString();
        loadGrid(KeyName);
    }
    protected void btnComplaintAssignEmailPerson_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComplaintMonitoring.aspx");
    }
}
