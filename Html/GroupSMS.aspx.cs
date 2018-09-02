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

public partial class html_GroupSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    DataSet ds2 = new DataSet();



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
                DateFormatStatus();
                if (!IsPostBack)
                {
                    //LoadValue();
                    string loginfrm = Session["Mobile"].ToString();
                    txtCustMessage.Text = "" + loginfrm + " www.myct.in";

                    LoadGenaralBal();


                }
            }
        }
        catch (Exception ex)
        { }
    }
    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    public void LoadGenaralBal()
    {
        string usrIdSn = Convert.ToString(Session["User"]);
        string paidBal = "select SMSbal from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
        string balValue = cc.ExecuteScalar(paidBal);
        if (balValue != "")
        {
            int bal = Convert.ToInt32(balValue);
            lblGroupGeneralBalance.Text = "SMS Balance is: " + Convert.ToString(bal) + " SMS";
        }
        else
        {
            lblGroupGeneralBalance.Text = "SMS Balance is: 0 SMS";
        }
    }

    protected void btnViewSendGroupSMS_Click(object sender, EventArgs e)
    {

        chkAllContact.Visible = true;
        viewsendgroup();
        ChkbxAllGroupcnt.Visible = true;
        gvGroupSMSContact.Visible = true;
    }
    public void viewsendgroup()
    {
        try
        {

            string usrIdSn = Convert.ToString(Session["User"]);

            if (ddlMyFriendGroupSMS.SelectedIndex == 1)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR1='1' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds.Tables[0];
                gvGroupSMSContact.DataBind();
                // gvGroupSMSContact.Visible = true;
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 2)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR2='2' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 3)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR3='3' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }

            else if (ddlMyFriendGroupSMS.SelectedIndex == 4)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR4='4' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 5)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR5='5' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 6)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR6='6' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 7)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR7='7' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 8)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR8='8' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 9)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR9='9' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 10)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR10='10' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 11)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR11='11' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 12)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR12='12' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 13)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR13='13' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 14)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR14='14' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 15)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR15='15' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 16)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR16='16' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 17)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR17='17' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 18)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR18='18' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 19)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR19='19' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 20)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR20='20' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 21)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR21='21' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 22)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR22='22' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 23)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR23='23' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 24)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR24='24' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 25)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR25='25' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 26)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR26='26' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 27)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR27='27' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 28)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR28='28' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 29)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR29='29' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 30)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR30='30' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds;
                gvGroupSMSContact.DataBind();
            }
            else { }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSubmitSMSGroup_Click(object sender, EventArgs e)
    {

        string loginfrm = Session["Mobile"].ToString();
        string messagecontain = loginfrm + " www.myct.in";
        if (txtCustMessage.Text.Contains(messagecontain))
        {
            if (chkAllContact.Checked || ChkbxAllGroupcnt.Checked)
            {
                GroupSMSDetails();
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz add in message ur MobileNo space www.myct.in')", true);

        }

    }
    private ArrayList GetCheckedItems(string crtl, GridView grdView)
    {
        ArrayList checkedItems = new ArrayList();
        CheckBox chk;
        string chkBoxIndex = string.Empty;
        try
        {
            foreach (GridViewRow row in grdView.Rows)
            {
                chkBoxIndex = (string)grdView.DataKeys[row.RowIndex].Value.ToString();
                chk = (CheckBox)row.FindControl("chkSelectFriend");

                if (chk.Checked)
                {
                    if (!(checkedItems.Contains(chkBoxIndex)))
                    {
                        checkedItems.Add(chkBoxIndex);
                    }
                    else
                    {
                        checkedItems.Remove(chkBoxIndex);
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
        return checkedItems;
    }


    private void GroupSMSDetails()
    {
        string tmpContact = "";
        string totalContact = "";
        string chkContact = "chkContact";
        string fname = "";
        string lname = "";
        int smsLen = 0;
        int totalCountBal = 0, SMSbal = 0;
        int smslength;
        ArrayList selecteItem = new ArrayList();
        //Get the Id to be sent sms
        if (chkAllContact.Checked)
        {
            selecteItem = GetCheckedItems(chkContact, gvGroupSMSContact);
        }
        else if (ChkbxAllGroupcnt.Checked)
        {
            SendAllSMS();

            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                selecteItem.Add(row["usrMobileNo"]);

            }



        }

        if (selecteItem.Count > 0)
        {
            try
            {
                int smsLength;
                bool flag = false;
                string Sql = "", SmsSend = "";
                string sendFrom = Convert.ToString(Session["Mobile"]);
                string sqlBal = "select SMSbal,usrFirstName,usrLastName from userMaster where usrMobileNo='" + sendFrom.ToString() + "'";
                DataSet ds = cc.ExecuteDataset(sqlBal);
                SMSbal = Convert.ToInt32(ds.Tables[0].Rows[0]["SMSbal"]);
                int SMSbalPre = Convert.ToInt32(ds.Tables[0].Rows[0]["SMSbal"]);
                fname = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                lname = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
                SmsSend = txtCustMessage.Text;
                string[] arrsplit = totalContact.Split(',');
                string sendMessage1 = txtCustMessage.Text;
                smsLen = sendMessage1.Length;
                if (smsLen <= 160)
                {
                    totalCountBal = 1 * selecteItem.Count;
                }
                else if (smsLen >= 161 && smsLen <= 306)
                {
                    totalCountBal = 2 * selecteItem.Count;
                }
                else if (smsLen >= 306 && smsLen <= 459)
                {
                    totalCountBal = 2 * selecteItem.Count;

                }
                else if (smsLen >= 459 && smsLen <= 612)
                {
                    totalCountBal = 3 * selecteItem.Count;

                }
                else if (smsLen >= 612 && smsLen <= 765)
                {
                    totalCountBal = 4 * selecteItem.Count;
                }
                else if (smsLen >= 765 && smsLen <= 918)
                {
                    totalCountBal = 5 * selecteItem.Count;

                }
                else if (smsLen >= 918 && smsLen <= 1071)
                {
                    totalCountBal = 6 * selecteItem.Count;

                }
                else if (smsLen >= 1071 && smsLen <= 1224)
                {
                    totalCountBal = 7 * selecteItem.Count;
                }
                else if (smsLen >= 1224 && smsLen <= 1377)
                {
                    totalCountBal = 8 * selecteItem.Count;

                }
                else if (smsLen >= 1377 && smsLen <= 1530)
                {
                    totalCountBal = 9 * selecteItem.Count;
                }
                else if (smsLen >= 1530 && smsLen <= 1683)
                {
                    totalCountBal = 10 * selecteItem.Count;
                }
                else
                { }

                if (totalCountBal <= SMSbal)
                {

                    int dndFales = 0;
                    int smsFail = 0;
                    string message = "Dear Total " + selecteItem.Count + " Group message sent successfully www.myct.in";
                    smslength = message.Length;
                    //cc.SendMessageGroupSMS("GroupSMS", sendFrom, message, smslength);
                    // string sysdate = DateTime.Now.ToString("MM/dd/yyyy");
                    foreach (string contactNo in selecteItem)
                    {
                        string sendMessage = txtCustMessage.Text;
                        tmpContact = contactNo + ",";
                        totalContact = totalContact + tmpContact;
                        flag = cc.SendMessageGroupSMS(sendFrom, contactNo, sendMessage, smsLen);
                    }

                    SMSbal = SMSbal - totalCountBal - 1;

                    string sqlBalUpdate = "update userMaster set SMSbal=" + SMSbal.ToString() + " where usrMobileNo='" + sendFrom.ToString() + "'";
                    int i = cc.ExecuteNonQuery(sqlBalUpdate);
                    if (i >= 1)
                    {
                        string[] tlsms = totalContact.Split(',');
                        int smsc = Convert.ToInt16(tlsms.Length);
                        int TotalSmsCount = Convert.ToInt16(arrsplit.Length);
                        int TotalSMSSent = smsc - 1;

                        string sqlinsert = "insert into [Come2myCityDB].[come2mycity].[SMSBalanceReport](userid,MobileNo,Message,SMSLength,smscount,Pre_SMSbal,New_SMSbal,SendDate,No_smssent)" +
                                           "values('" + Convert.ToString(Session["User"]) + "','" + sendFrom + "','" + sendMessage1 + "','" +
                                           smsLen + "','" + totalCountBal + "','" + SMSbalPre + "','" + SMSbal + "','" + DateFormat + "','" + TotalSMSSent + "')";
                        //string b = cc.ExecuteScalar(sqlinsert);

                        int b = cc.ExecuteNonQuery(sqlinsert);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry, You have not sufficient balance to send SMS.')", true);
                }
                if (flag == true)
                {
                    string loginfrm = Session["Mobile"].ToString();
                    txtCustMessage.Text = "" + loginfrm + " www.myct.in";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS Sent Successfully')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry, You have not sufficient balance to send SMS.')", true);


                }
                txtchrcount.Text = "";
                LoadGenaralBal();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select the Friend from your contact')", true);

        }

    }

    protected void gvGroupSMSContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGroupSMSContact.PageIndex = e.NewPageIndex;
        viewsendgroup();
    }

    protected void chkAllContact_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkbxAllGroupcnt.Checked)
        {
            ChkbxAllGroupcnt.Checked = false;

        }


        CheckBox chk;

        foreach (GridViewRow rowItem in gvGroupSMSContact.Rows)
        {
            chk = (CheckBox)(rowItem.Cells[0].FindControl("chkSelectFriend"));
            chk.Checked = ((CheckBox)sender).Checked;

            if (((CheckBox)sender).Checked)
            {
                rowItem.BackColor = System.Drawing.Color.FromName("#D1DDF1");
            }
            else
            {
                rowItem.BackColor = System.Drawing.Color.FromName("#FFFFFF");
            }
        }
    }


    protected void txtGroupSMSMsg_TextChanged(object sender, EventArgs e)
    {


    }

    protected void ChkbxAllGroupcnt_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllContact.Checked)
        {
            chkAllContact.Checked = false;
            chkAllContact.Visible = false;
            gvGroupSMSContact.Visible = false;
        }
        else
        {
            chkAllContact.Visible = false;
            gvGroupSMSContact.Visible = false;
        }
    }

    public void SendAllSMS()
    {
        try
        {

            string usrIdSn = Convert.ToString(Session["User"]);

            if (ddlMyFriendGroupSMS.SelectedIndex == 1)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR1='1' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2.Tables[0];
                gvGroupSMSContact.DataBind();
                // gvGroupSMSContact.Visible = true;
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 2)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR2='2' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 3)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR3='3' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }

            else if (ddlMyFriendGroupSMS.SelectedIndex == 4)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR4='4' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 5)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR5='5' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 6)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR6='6' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 7)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR7='7' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 8)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR8='8' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 9)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR9='9' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 10)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR10='10' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 11)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR11='11' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 12)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR12='12' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 13)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR13='13' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 14)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR14='14' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 15)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR15='15' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 16)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR16='16' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 17)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR17='17' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 18)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR18='18' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 19)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR19='19' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 20)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR20='20' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 21)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR21='21' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 22)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR22='22' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 23)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR23='23' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 24)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR24='24' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 25)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR25='25' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 26)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR26='26' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 27)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR27='27' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 28)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR28='28' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 29)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR29='29' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else if (ddlMyFriendGroupSMS.SelectedIndex == 30)
            {
                string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
         " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
        "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
        " where  friendrelationmaster.FR30='30' and friendrelationmaster.userid='" + usrIdSn + "'" +
        " and usrFirstName like '" + txtGroupSMSFirst.Text + "'+'%' and usrLastName like '" + txtGroupSMSLast.Text + "'+'%'";
                ds2 = cc.ExecuteDataset(sql);
                gvGroupSMSContact.DataSource = ds2;
                gvGroupSMSContact.DataBind();
            }
            else { }
        }
        catch (Exception ex)
        {

        }


    }
    protected void ddlMyFriendGroupSMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChkbxAllGroupcnt.Visible = true;
    }
}
