using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;

public partial class Html_SendSMS : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLObj = new FriendGroupBLL();
    CommonCode cc = new CommonCode();
    string quickContactNo;
    DataTable dtFriendRelList;
    DataClassesDataContext ds = new DataClassesDataContext();
    PaidSmsDataContext psdc = new PaidSmsDataContext();
    LongCodeBLL objSMS = new LongCodeBLL();

    string DateFormat = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DateFormatStatus();
        string UserIdSession = Convert.ToString(Session["User"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                //LoadFriendRelative();
                try
                {

                    //LoadFriendGroup();
                    LoadPaidBal();
                    LoadGenaralBal();

                    rbtnEnglish.Checked = true;
                    string loginfrm = Session["Mobile"].ToString();
                    txtSendMsg.Text = "" + loginfrm + " www.myct.in";
                    txtMsgBox.Text = "" + loginfrm + " www.myct.in";
                    txtGroupSMSMsg.Text = "" + loginfrm + " www.myct.in";
                    txtCustMessage.Text = "" + loginfrm + " www.myct.in";
                    txtRemindMsg.Text = "" + loginfrm + " www.myct.in";
                    string TodaysDate = System.DateTime.Now.ToShortDateString();
                   

                }
                catch (Exception rrr)
                {
                    throw rrr;
                }

            }
        }

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




    //--------------------------------------Send SMS Report----------------------------------------------

    #region NewBalenceReportTab
    public void LoadGenaralBal()
    {
        string usrIdSn = Convert.ToString(Session["User"]);
        string paidBal = "select SMSbal from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
        string balValue = cc.ExecuteScalar(paidBal);
        if (balValue != "")
        {
            int bal = Convert.ToInt32(balValue);
            lblQuickGeneralBalance.Text = "SMS Balance is: " + Convert.ToString(bal) + " SMS";
            lblGroupGeneralBalance.Text = "SMS Balance is: " + Convert.ToString(bal) + " SMS";
        }
        else
        {
            lblQuickGeneralBalance.Text = "SMS Balance is: 0 SMS";
            lblGroupGeneralBalance.Text = "SMS Balance is: 0 SMS";
        }
    }
    public void LoadPaidBal()
    {
        string usrIdSn = Convert.ToString(Session["User"]);
        string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
        string balVal = cc.ExecuteScalar(paidBal);
        if (balVal != "")
        {
            int bal = Convert.ToInt32(balVal);
            lblPaidBal.Text = Convert.ToString(bal) + " SMS";
            lblCustpaidbal.Text = Convert.ToString(bal) + " SMS";
            lblremindbal.Text = Convert.ToString(bal) + " SMS";
        }
        else
        {
            lblPaidBal.Text = "0 SMS";
            lblCustpaidbal.Text = "0 SMS";
            lblremindbal.Text = "0 SMS";
        }
    }
    //Show All Friend & Relative In Your Profile
    public void LoadFriendRelative()
    {
        try
        {
            //urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            //dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);

            gvFriendContact.DataSource = dtFriendRelList;
            ViewState["QuickFriendList"] = dtFriendRelList;
            gvFriendContact.DataBind();


            // gvAddressBook.DataSource = dtFriendRelList;
            ViewState["AddressBook"] = dtFriendRelList;
            //gvAddressBook.DataBind();

            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            DataTable dtFriendGroup = fgBLLObj.BLLShowFriendGroupForUser(urUserRegBLLObj);

            string SQl = "Select GroupName from UserMaster where UserId='" + Convert.ToString(Session["User"]) + "' ";
            string GroupName = Convert.ToString(cc.ExecuteScalar(SQl));
            string[] tmpGroupName = GroupName.Split(',');
            foreach (DataRow dr in dtFriendGroup.Rows)
            {
                try
                {
                    int Index = Convert.ToInt32(dr["friendGroupId"]);
                    dr["friendGroupName"] = tmpGroupName[Index - 1].ToString();
                }
                catch (Exception ex)
                { }

            }


            // ddlMyFriendGroup.DataSource = dtFriendGroup;
            //ddlMyFriendGroup.DataTextField = "friendGroupName";
            // ddlMyFriendGroup.DataValueField = "friendGroupId";
            // ddlMyFriendGroup.DataBind();

            ddlMyFriendGroupSMS.DataSource = dtFriendGroup;
            ddlMyFriendGroupSMS.DataTextField = "friendGroupName";
            ddlMyFriendGroupSMS.DataValueField = "friendGroupId";
            ddlMyFriendGroupSMS.DataBind();




        }
        catch (Exception ex)
        {
            // throw ex;

        }
    }
    
    #endregion NewBalenceReportTab

    //-------------------------------------Quick SMS------------------------------------------------

    #region QuickSMS

    protected void btnSendSMS_Click(object sender, EventArgs e)
    {
        string loginfrm = Session["Mobile"].ToString();
        string stringcontain = loginfrm + " www.myct.in";
        if (txtSendMsg.Text.Contains(stringcontain))
        {
            QuickSMSToFriend();
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz add in message ur MobileNo space www.myct.in')", true);
        }

    }

    public void QuickSMSToFriend()
    {

        string tmpContact = "";
        string totalContact = "";
        string chkContact = "chkSelectFriend";
        string sysdate = "";
        int SMSbal = 0, totalCountBal = 0, smsLen = 0;
        string sender = "";
        ArrayList selecteItem = GetCheckedItems(chkContact, gvFriendContact);

        if (selecteItem.Count > 0)
        {
            try
            {
                bool flag = false;
                string Sql = "", SmsSend = "";
                string sendFrom = Convert.ToString(Session["Mobile"]);
                string sqlBal = "select SMSbal,usrFirstName from userMaster where usrMobileNo='" + sendFrom.ToString() + "'";
                DataSet ds = cc.ExecuteDataset(sqlBal);
                SMSbal = Convert.ToInt32(ds.Tables[0].Rows[0]["SMSbal"]);
                sender = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                SmsSend = txtSendMsg.Text;
                string sendMessage1 = txtSendMsg.Text;
                smsLen = sendMessage1.Length;
                if (smsLen >= 1 && smsLen <= 160)
                {
                    totalCountBal = 1 * selecteItem.Count;
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
                    string Message = "Dear Total " + selecteItem.Count + " Quick sms send successfully www.myct.in";
                    int length = Message.Length;
                    flag = cc.SendMessageQuickSMS("QuickSMS", sendFrom, Message, length);
                    foreach (string contactNo in selecteItem)
                    {

                        string sendMessage = txtSendMsg.Text;
                        int smslength = sendMessage.Length;
                        tmpContact = contactNo + ",";
                        totalContact = totalContact + tmpContact;
                        flag = cc.SendMessageQuickSMS(sendFrom, contactNo, sendMessage, smslength);

                    }
                    SMSbal = SMSbal - totalCountBal;


                    string sqlBalUpdate = "update userMaster set SMSbal=" + SMSbal.ToString() + " where usrMobileNo='" + sendFrom.ToString() + "'";
                    int i = cc.ExecuteNonQuery(sqlBalUpdate);
                }
                else
                {


                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry, You dont have sufficient balance to send SMS.')", true);
                    //Response.Write("<script>(alert)('Sorry, You dont have sufficient balance to send SMS.')</script>");

                }
                if (flag == true)
                {
                    txtSendMsg.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS Sent Successfully')", true);
                    //Response.Write("<script>(alert)('SMS Sent Successfully')</script>");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry, You dont have sufficient balance to send SMS.')", true);
                    //Response.Write("<script>(alert)('Sorry, You dont have sufficient balance to send SMS.')</script>");


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select the Friend from your contact')", true);
            //Response.Write("<script>(alert)('Select the Friend from your contact')</script>");

        }
        LoadGenaralBal();
        Clear();
    }

    private void Clear()
    {
        string loginfrm = Session["Mobile"].ToString();
        txtSendMsg.Text = "" + loginfrm + " www.myct.in";
        txtCharCount1.Text = "";

    }

    protected void chkAllContact_CheckedChanged(object sender, EventArgs e)
    {
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

    #endregion QuickSMS


    //--------------------------------------Group SMS----------------------------------------------

    #region GroupSMS
    protected void chkContact_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk;
        foreach (GridViewRow rowItem in gvGroupSMSContact.Rows)
        {
            chk = (CheckBox)(rowItem.Cells[0].FindControl("chkContact"));
            if (chk.Checked)
            {
                rowItem.BackColor = System.Drawing.Color.FromName("#D1DDF1");
            }
            else
            {
                rowItem.BackColor = System.Drawing.Color.FromName("#FFFFFF");
            }
        }
    }
    protected void btnSubmitSMSGroup_Click(object sender, EventArgs e)
    {
        string loginfrm = Session["Mobile"].ToString();
        string messagecontain = loginfrm + " www.myct.in";
        if (txtGroupSMSMsg.Text.Contains(messagecontain))
        {
            GroupSMSDetails();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz add in message ur MobileNo space www.myct.in')", true);

        }

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

        //Get the Id to be sent sms
        ArrayList selecteItem = GetCheckedItems(chkContact, gvGroupSMSContact);

        if (selecteItem.Count > 0)
        {
            try
            {
                bool flag = false;
                string Sql = "", SmsSend = "";
                string sendFrom = Convert.ToString(Session["Mobile"]);
                string sqlBal = "select SMSbal,usrFirstName,usrLastName from userMaster where usrMobileNo='" + sendFrom.ToString() + "'";
                DataSet ds = cc.ExecuteDataset(sqlBal);
                SMSbal = Convert.ToInt32(ds.Tables[0].Rows[0]["SMSbal"]);
                fname = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                lname = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
                SmsSend = txtGroupSMSMsg.Text;
                string sendMessage1 = txtGroupSMSMsg.Text;
                smsLen = sendMessage1.Length;
                if (smsLen <= 160)
                {
                    totalCountBal = 1 * selecteItem.Count;
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
                    cc.SendMessageGroupSMS("GroupSMS", sendFrom, message, smslength);
                    string sysdate = DateTime.Now.ToString("MM/dd/yyyy");
                    foreach (string contactNo in selecteItem)
                    {
                        string sendMessage = txtGroupSMSMsg.Text;
                        tmpContact = contactNo + ",";
                        totalContact = totalContact + tmpContact;
                        flag = cc.SendMessageGroupSMS(sendFrom, contactNo, sendMessage, smsLen);
                    }

                    SMSbal = SMSbal - totalCountBal - 1;

                    string sqlBalUpdate = "update userMaster set SMSbal=" + SMSbal.ToString() + " where usrMobileNo='" + sendFrom.ToString() + "'";
                    int i = cc.ExecuteNonQuery(sqlBalUpdate);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry, You have not sufficient balance to send SMS.')", true);
                }
                if (flag == true)
                {
                    string loginfrm = Session["Mobile"].ToString();
                    txtGroupSMSMsg.Text = "" + loginfrm + " www.myct.in";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS Sent Successfully')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry, You have not sufficient balance to send SMS.')", true);


                }
                txtCharCount2.Text = "";
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


    protected void gvGroupSMSContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGroupSMSContact.PageIndex = e.NewPageIndex;
        viewsendgroup();
    }
    protected void gvFriendContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFriendContact.PageIndex = e.NewPageIndex;
        int grId = Convert.ToInt32(ddlMyFriendGroupSMS.SelectedValue);
        string s4 = Convert.ToString(grId + 1);
        //var v = ds.spRetrieveGroupMemberSendSms(txtGroupSMSLast.Text.ToString(), txtGroupSMSFirst.Text.ToString(), Convert.ToString(Session["User"]), s4).ToList();
        //gvFriendContact.DataSource = v.ToList();
        //gvFriendContact.DataBind();
    }
    #endregion GroupSMS

    //--------------------------------------- Group SMS ---------------------------------------

    #region GroupSms

    protected void btnViewSendGroupSMS_Click(object sender, EventArgs e)
    {

        chkAllContact.Visible = true;
        viewsendgroup();
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Search1(gvFriendContact, ddlQuickGroup, txtFirstName, txtLastName);

        string usrIdSn = Convert.ToString(Session["User"]);
        string sql = "select usrFirstName+' '+usrLastName as usrFullName,usrMobileNo " +
     " from  FriendRelationMaster Right Outer JOIN  UserMaster " +
    "ON  UserMaster.usrUserId = FriendRelationMaster.FriendId " +
    " where friendrelationmaster.userid='" + usrIdSn + "'" +
    " and usrFirstName like '" + txtFirstName.Text + "'+'%' and usrLastName like '" + txtLastName.Text + "'+'%' and usrMobileNo='" + txtMobileNo.Text + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        gvFriendContact.DataSource = ds;
        gvFriendContact.DataBind();



    }
    private void Search1(GridView g, DropDownList ddl, TextBox First, TextBox Last)
    {

        DataSet ds = new DataSet();
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);

            urUserRegBLLObj.usrFirstName = txtFirstName.Text;
            urUserRegBLLObj.usrLastName = txtLastName.Text;
            ds = urUserRegBLLObj.BLLSendSmsByName(urUserRegBLLObj);
            gvFriendContact.DataSource = ds;
            gvFriendContact.DataBind();
        }
        catch (Exception ex)
        {
        }



    }
    private void Search(GridView g, DropDownList ddl, TextBox First, TextBox Last)
    {
        try
        {
            string s4 = ddl.SelectedValue;
            //var v = ds.spRetrieveGroupMemberSendSms(Last.Text.ToString(), First.Text.ToString(), Convert.ToString(Session["User"]), s4).ToList();
            //g.DataSource = v.ToList();
            //g.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion GroupSms

    //----------------------------------Promotional SMS Code--------------------------------

    #region PromotionalSMSCode

    protected void btnSendPaidSms_Click(object sender, EventArgs e)
    {
        string loginfrm = Session["Mobile"].ToString();
        string messagecont = loginfrm + " www.myct.in";
        if (txtMsgBox.Text.Contains(messagecont))
        {
            PromotionalSMS();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz add in message ur MobileNo space www.myct.in')", true);
        }
    }

    private void PromotionalSMS()
    {
        int smslength;
        int smsBalCutCount = 0;
        string msgSndFrom = Convert.ToString(Session["Mobile"]);
        string usrIdSn = Convert.ToString(Session["User"]);
        string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
        int bal = Convert.ToInt32(cc.ExecuteScalar(paidBal));
        if (bal >= 1)
        {
            string sendToMoNo = txtMoNo.Text;
            int txtSmsLength = sendToMoNo.Length;
            string[] sndMoNoCount = { };
            if (txtSmsLength > 10)
            {
                sndMoNoCount = sendToMoNo.Split(',');
                if (sndMoNoCount.Length > 1)
                {

                }
                else
                {
                    sndMoNoCount = sendToMoNo.Split('\n');
                }
            }
            else
            {
                sndMoNoCount = sendToMoNo.Split(',');
            }

            if (sndMoNoCount.Length <= bal)
            {
                if (sndMoNoCount.Length != 0 && txtMsgBox.Text.Trim() != "")
                {
                    string mess = txtMsgBox.Text;
                    int smsLength = mess.Length;

                    if (smsLength >= 0 && smsLength <= 160)
                    {
                        smsBalCutCount = sndMoNoCount.Length;
                    }
                    else if (smsLength >= 161 && smsLength <= 306)
                    {
                        smsBalCutCount = 2 * sndMoNoCount.Length;
                    }
                    else if (smsLength >= 307 && smsLength <= 459)
                    {
                        smsBalCutCount = 3 * sndMoNoCount.Length;

                    }
                    else if (smsLength >= 460 && smsLength <= 612)
                    {
                        smsBalCutCount = 4 * sndMoNoCount.Length;

                    }
                    else if (smsLength >= 613 && smsLength <= 765)
                    {
                        smsBalCutCount = 5 * sndMoNoCount.Length;
                    }
                    else if (smsLength >= 766 && smsLength <= 918)
                    {
                        smsBalCutCount = 6 * sndMoNoCount.Length;

                    }
                    else if (smsLength >= 919 && smsLength <= 1071)
                    {
                        smsBalCutCount = 7 * sndMoNoCount.Length;

                    }
                    else if (smsLength >= 1072 && smsLength <= 1224)
                    {
                        smsBalCutCount = 8 * sndMoNoCount.Length;
                    }
                    else if (smsLength >= 1225 && smsLength <= 1377)
                    {
                        smsBalCutCount = 9 * sndMoNoCount.Length;

                    }
                    else if (smsLength >= 1378 && smsLength <= 1530)
                    {
                        smsBalCutCount = 10 * sndMoNoCount.Length;
                    }
                    else { }
                   
                    if (smsBalCutCount < bal && smsLength <= 1280)
                    {

                        string Message = "Dear Total " + sndMoNoCount.Length + " Promotional  message sent successfully www.myct.in ";
                        smslength = Message.Length;
                        cc.SendMessagePromotionalSMS("PromotionalSMS", msgSndFrom, Message, smslength);
                        string msgSnd = "", msgSndTo = "";
                        msgSnd = txtMsgBox.Text;
                        smslength = msgSnd.Length;

                        if (rbtnMarathi.Checked == true)
                        {

                            // cc.SendMessageMarathi(msgSndFrom, msgSndTo, txtUnicoded.Text.ToString(), msgSnd);
                        }
                        else
                        {
                            sendToMoNo = sendToMoNo.Replace("\n", string.Empty);
                            sendToMoNo = sendToMoNo.Replace("\t", string.Empty);
                            cc.SendMessageTraBulkPromotional(msgSndFrom, sendToMoNo, msgSnd, smslength);

                            //---------------------------Ketan Code-------------------------

                            string balance = Convert.ToString(bal - smsBalCutCount - 1);

                            string sqlCutBalQuery = "update userMaster set paidCount = " + balance + " where usrMobileNo='" + msgSndFrom.ToString() + "'";
                            int SmsSndSuccess = Convert.ToInt32(cc.ExecuteNonQuery(sqlCutBalQuery));
                            if (SmsSndSuccess > 0)
                            {
                                int TotalSmsCount = Convert.ToInt16(sndMoNoCount.Length);

                                string Sql = "Insert Into PromotionalSendSMSReport(SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,Balance,EntryDate)" +
                                    " Values('" + msgSndFrom + "','" + sendToMoNo + "','" + msgSnd + "'," + TotalSmsCount + "," + smslength + "," + (smsBalCutCount + 1) + "," + balance + ",'" + DateFormat + "')";
                                int k = cc.ExecuteNonQuery(Sql);
                                if (k == 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully.')", true);
                                    //ClearPaidSms();
                                    string loginfrm = Session["Mobile"].ToString();
                                    txtMsgBox.Text = "" + loginfrm + " www.myct.in";
                                    LoadPaidBal();
                                    txtMoNo.Text = "";
                                    txtCharCount.Text = "";
                                }
                            }
                            //===========================
                        }

                        //string sqlCutBalQuery = "update userMaster set paidCount = " + (bal - smsBalCutCount - 1) + " where usrMobileNo='" + msgSndFrom.ToString() + "'";
                        //int SmsSndSuccess = Convert.ToInt32(cc.ExecuteNonQuery(sqlCutBalQuery));
                        //if (SmsSndSuccess > 0)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully.')", true);
                        //    //ClearPaidSms();
                        //    string loginfrm = Session["Mobile"].ToString();
                        //    txtMsgBox.Text = "" + loginfrm + " www.myct.in";
                        //    LoadPaidBal();
                        //    txtMoNo.Text = "";
                        //}

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry,You have 1280 character sms allow only.')", true);
                        ClearPaidSms();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Msg & Senders valid mobile numbers.')", true);
                    ClearPaidSms();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have insufficient Promotional Balance,Please recharge it.')", true);
                ClearPaidSms();
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have insufficient Promotional Balance,Please recharge it.')", true);
            ClearPaidSms();
        }
    }



    public string ChangeDate(string dt)
    {
        string[] tmpdt;

        string dt1 = "0";
        try
        {
            tmpdt = dt.Split('/');
            if (tmpdt[0].Length == 1)
                tmpdt[0] = "0" + tmpdt[0];
            if (tmpdt[1].Length == 1)
                tmpdt[1] = "0" + tmpdt[1];

            dt1 = tmpdt[2] + "/" + tmpdt[0] + "/" + tmpdt[1];

        }
        catch (Exception ex)
        {
            string msg = ex.Message;


        }
        return dt1;
    }

    public void ClearPaidSms()
    {
        txtMoNo.Text = "";
        txtMsgBox.Text = "";
        txtCharCount.Text = "";
        txtUnicoded.Text = "";
        rbtnEnglish.Checked = true;
        rbtnMarathi.Checked = false;
        LoadPaidBal();

    }
    public static byte[] StrToByteArray(string str)
    {
        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        return encoding.GetBytes(str);
    }
    public string ConvertToHexa(string str)
    {
        char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        //tr byte[] bytes = new byte[3];
        // bytes[0] = StrToByteArray(s );
        Byte[] bytes = StrToByteArray(str);
        //bytes[0] = color.R;
        //bytes[1] = color.G;
        //bytes[2] = color.B;
        char[] chars = new char[bytes.Length * 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            int b = bytes[i];
            chars[i * 2] = hexDigits[b >> 4];
            chars[i * 2 + 1] = hexDigits[b & 0xF];
        }
        return new string(chars);

    }

    protected void rbtnMarathi_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnEnglish.Checked == true)
        {
            rbtnEnglish.Checked = false;
        }
    }
    protected void rbtnEnglish_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnMarathi.Checked == true)
        {
            rbtnMarathi.Checked = false;
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaidGroup.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var var = psdc.SearchPaidSMs(txtFromDate.Text, txtToDate.Text, Session["Mobile"].ToString()).ToList();

        GridView1.DataSource = var.ToList();
        GridView1.DataBind();
        //OutBoxPopUp.Focus();
        //OutBoxPopUp.Visible = true;
        ModalPopupExtender1.Show();
    }
    #endregion PromotionalSMSCode

    #region OtherReport

   
   
    protected void txtGroupSMSMsg_TextChanged(object sender, EventArgs e)
    {

    }
    
    protected void btnOutbox_Click(object sender, EventArgs e)
    {

    }
  
   
   
    protected void gvItem_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        UploadExcel();
    }
    private void UploadExcel()
    {
        try
        {
            if (fileupload.HasFile)
            {
                string path = "";
                string readdata = "";
                int i = 0;
                path = Server.MapPath("File_upload");
                path = path + "\\" + fileupload.FileName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                    fileupload.SaveAs(path);
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                StreamReader sr = new StreamReader(path);
                string temp = "";
                do
                {
                    if (readdata != null)
                    {
                        temp += readdata + ",";

                    }
                    readdata = sr.ReadLine();


                    i++;

                }

                while (readdata != null);
                if (temp.Length > 1)
                {
                    temp = temp.Substring(1);
                    divMobile.Visible = true;

                }
                if (temp.EndsWith(","))
                {
                    temp = temp.Remove(temp.Length - 1);
                }

                txtCustMobile.Text = temp;
                string[] arrsplit = temp.Split(',');
                lblttlCustSMS.Text = "Total MobileNo here:" + Convert.ToString(arrsplit.Length);


            }


        }
        catch (Exception ex)
        {
        }
    }

    #endregion OtherReport

    //-----------------------------------------Custom SMS code--------------------------------------------------------

    #region CustomSMsCode

    protected void btnCustSend_Click(object sender, EventArgs e)
    {
        string loginfrm = Session["Mobile"].ToString();
        string messagecont = loginfrm + " www.myct.in";
        if (txtMsgBox.Text.Contains(messagecont))
        {
            CustomSMS();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz add in message ur MobileNo space www.myct.in')", true);
        }


    }

    private void CustomSMS()
    {
        try
        {
            int smsLength;
            int smsBalCutCount = 0;
            string msgSndFrom = Convert.ToString(Session["Mobile"]);
            string usrIdSn = Convert.ToString(Session["User"]);
            string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
            int bal = Convert.ToInt32(cc.ExecuteScalar(paidBal));
            if (bal >= 1)
            {
                string sendToMoNo = txtCustMobile.Text;
                string[] arrsplit = sendToMoNo.Split(',');
                int mobilelength = arrsplit.Length;
                if (mobilelength <= bal)
                {
                    string Message = txtCustMessage.Text;
                    smsLength = Message.Length;

                    if (smsLength >= 0 && smsLength <= 160)
                    {
                        smsBalCutCount = arrsplit.Length;
                    }
                    else if (smsLength >= 161 && smsLength <= 306)
                    {
                        smsBalCutCount = 2 * arrsplit.Length;
                    }
                    else if (smsLength >= 307 && smsLength <= 459)
                    {
                        smsBalCutCount = 3 * arrsplit.Length;

                    }
                    else if (smsLength >= 460 && smsLength <= 612)
                    {
                        smsBalCutCount = 4 * arrsplit.Length;

                    }
                    else if (smsLength >= 613 && smsLength <= 765)
                    {
                        smsBalCutCount = 5 * arrsplit.Length;
                    }
                    else if (smsLength >= 766 && smsLength <= 918)
                    {
                        smsBalCutCount = 6 * arrsplit.Length;

                    }
                    else if (smsLength >= 919 && smsLength <= 1071)
                    {
                        smsBalCutCount = 7 * arrsplit.Length;

                    }
                    else if (smsLength >= 1072 && smsLength <= 1224)
                    {
                        smsBalCutCount = 8 * arrsplit.Length;
                    }
                    else if (smsLength >= 1225 && smsLength <= 1377)
                    {
                        smsBalCutCount = 9 * arrsplit.Length;

                    }
                    else if (smsLength >= 1378 && smsLength <= 1530)
                    {
                        smsBalCutCount = 10 * arrsplit.Length;
                    }
                    else { }
                    
                    if (smsBalCutCount < bal && smsLength <= 1683)
                    {
                        string UsrMessage = "Dear Total " + mobilelength + " Customized SMS sent successfully www.myct.in";
                        smsLength = UsrMessage.Length;
                        cc.SendMessageCustomizedSMS("Customized", msgSndFrom, UsrMessage, smsLength);
                        string smsto = txtCustMobile.Text;
                        smsLength = Message.Length;
                        cc.SendMessageCustomizedSMS(msgSndFrom, smsto, Message, smsLength);


                        //---------------------------Ketan Code-------------------------
                        string balance = Convert.ToString(bal - smsBalCutCount - 1);

                        string sqlCutBalQuery = "update userMaster set paidCount = " + balance + " where usrMobileNo='" + msgSndFrom.ToString() + "'";
                        int SmsSndSuccess = Convert.ToInt32(cc.ExecuteNonQuery(sqlCutBalQuery));
                        if (SmsSndSuccess > 0)
                        {
                            int TotalSmsCount = Convert.ToInt16(arrsplit.Length);

                            string Sql = "Insert Into PromotionalSendSMSReport(SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,balance,EntryDate)" +
                                " Values('" + msgSndFrom + "','" + smsto + "','" + Message + "'," + TotalSmsCount + "," + smsLength + "," + (smsBalCutCount + 1) + "," + balance + ",'" + DateFormat + "')";
                            int k = cc.ExecuteNonQuery(Sql);
                            if (k == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully.')", true);
                                clearCustomized();
                                LoadPaidBal();
                            }

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry,You have 1683 character sms allow only.')", true);

                        //clearCustomized();
                        LoadPaidBal();
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have insufficient Promotional Balance,Please recharge it.')", true);
                    clearCustomized();
                    LoadPaidBal();

                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have insufficient Promotional Balance,Please recharge it.')", true);
                clearCustomized();
                LoadPaidBal();
            }


        }
        catch (Exception ex)
        { }


    }

    private void clearCustomized()
    {
        txtCustMobile.Text = "";
        divMobile.Visible = false;
        txtCustMessage.Text = "";
        txtchrcount.Text = "";
        string loginfrm = Session["Mobile"].ToString();
        txtCustMessage.Text = "" + loginfrm + " www.myct.in";
    }


    #endregion CustomSMsCode

    //-----------------------------------------Reminder SMS -------------------------------------------

    #region ReminderSMSCode



    protected void Button4_Click(object sender, EventArgs e)
    {
        ReminderSMS();
    }

    private void ReminderSMS()
    {
        try
        {
            string currentdate;// = Convert.ToString(System.DateTime.Now.ToLongDateString());
            //currentdate = cc.ChangeDate(currentdate);
            currentdate = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string date = txtDate.Text;
            date = cc.ChangeDate(date);
            string time = ddlTime.SelectedItem.Text;
            string minutes = ddlMinutes.SelectedItem.Text;
            int smsLength;
            int smsBalCutCount = 0;
            string msgSndFrom = Convert.ToString(Session["Mobile"]);
            string usrIdSn = Convert.ToString(Session["User"]);
            string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
            int bal = Convert.ToInt32(cc.ExecuteScalar(paidBal));
            if (bal >= 1)
            {
                string sendToMoNo = txtReminMobileno.Text;
                string[] arrsplit = sendToMoNo.Split(',');
                int mobilelength = arrsplit.Length;
                if (mobilelength <= bal)
                {
                    string Message = txtRemindMsg.Text;
                    smsLength = Message.Length;

                    if (smsLength >= 0 && smsLength <= 160)
                    {
                        smsBalCutCount = arrsplit.Length;
                    }
                    else if (smsLength >= 161 && smsLength <= 306)
                    {
                        smsBalCutCount = 2 * arrsplit.Length;
                    }
                    else if (smsLength >= 307 && smsLength <= 459)
                    {
                        smsBalCutCount = 3 * arrsplit.Length;

                    }
                    else if (smsLength >= 460 && smsLength <= 612)
                    {
                        smsBalCutCount = 4 * arrsplit.Length;

                    }
                    else if (smsLength >= 613 && smsLength <= 765)
                    {
                        smsBalCutCount = 5 * arrsplit.Length;
                    }
                    else if (smsLength >= 766 && smsLength <= 918)
                    {
                        smsBalCutCount = 6 * arrsplit.Length;

                    }
                    else if (smsLength >= 919 && smsLength <= 1071)
                    {
                        smsBalCutCount = 7 * arrsplit.Length;

                    }
                    else if (smsLength >= 1072 && smsLength <= 1224)
                    {
                        smsBalCutCount = 8 * arrsplit.Length;
                    }
                    else if (smsLength >= 1225 && smsLength <= 1377)
                    {
                        smsBalCutCount = 9 * arrsplit.Length;

                    }
                    else if (smsLength >= 1378 && smsLength <= 1530)
                    {
                        smsBalCutCount = 10 * arrsplit.Length;
                    }
                    else { }

                    if (smsBalCutCount < bal && smsLength <= 1683)
                    {
                        string UsrMessage = "Dear Total " + mobilelength + " Customized SMS sent successfully www.myct.in";
                        smsLength = UsrMessage.Length;
                        cc.SendMessageReminderSMS1("Customized", msgSndFrom, Message, smsLength, date, time, minutes, currentdate);
                        string smsto = txtReminMobileno.Text;
                        smsLength = Message.Length;
                        cc.SendMessageReminderSMS1(msgSndFrom, smsto, Message, smsLength, date, time, minutes, currentdate);

                        //---------------------------Ketan Code-------------------------
                        string balance = Convert.ToString(bal - smsBalCutCount - 1);

                        string sqlCutBalQuery = "update userMaster set paidCount = " + balance + " where usrMobileNo='" + msgSndFrom.ToString() + "'";
                        int SmsSndSuccess = Convert.ToInt32(cc.ExecuteNonQuery(sqlCutBalQuery));
                        if (SmsSndSuccess > 0)
                        {
                            int TotalSmsCount = Convert.ToInt16(arrsplit.Length);

                            string Sql = "Insert Into PromotionalSendSMSReport(SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,balance,EntryDate)" +
                                " Values('" + msgSndFrom + "','" + smsto + "','" + Message + "'," + TotalSmsCount + "," + smsLength + "," + (smsBalCutCount + 1) + "," + balance + ",'" + DateFormat + "')";
                            int k = cc.ExecuteNonQuery(Sql);
                            if (k == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully.')", true);
                                clearReminder();
                                LoadPaidBal();
                            }


                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry,You have 1683 character sms allow only.')", true);

                        //clearCustomized();
                        LoadPaidBal();

                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have insufficient Promotional Balance,Please recharge it.')", true);
                    //clearCustomized();
                    clearReminder();
                    LoadPaidBal();

                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have insufficient Promotional Balance,Please recharge it.')", true);
                //clearCustomized();
                clearReminder();
                LoadPaidBal();


            }

        }


        catch (Exception ex)
        { }
    }

    private void clearReminder()
    {
        txtReminMobileno.Text = "";
        txtRemindCharcount.Text = "";
        txtRemindMsg.Text = "";
        string loginfrm = Session["Mobile"].ToString();
        txtRemindMsg.Text = "" + loginfrm + " www.myct.in";
        txtDate.Text = "";
        ddlTime.ClearSelection();
        ddlMinutes.ClearSelection();


    }

    #endregion ReminderSMSCode



    //--------------------------------------Balence Report----------------------------------------------


}


