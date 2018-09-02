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

public partial class html_QuickSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";

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
                    txtSendMsg.Text = "" + loginfrm + " www.myct.in";

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
            lblQuickGeneralBalance.Text = "SMS Balance is: " + Convert.ToString(bal) + " SMS";

        }
        else
        {
            lblQuickGeneralBalance.Text = "SMS Balance is: 0 SMS";

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

                int SMSbalPre = Convert.ToInt32(ds.Tables[0].Rows[0]["SMSbal"]);
                sender = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                SmsSend = txtSendMsg.Text;
                string sendMessage1 = txtSendMsg.Text;
                smsLen = sendMessage1.Length;

                if (smsLen >= 0 && smsLen <= 160)
                {
                    totalCountBal = 1 * selecteItem.Count;
                }
                else if (smsLen >= 161 && smsLen <= 306)
                {
                    totalCountBal = 2 * selecteItem.Count;
                }
                else if (smsLen >= 307 && smsLen <= 459)
                {
                    totalCountBal = 3 * selecteItem.Count;

                }
                else if (smsLen >= 460 && smsLen <= 612)
                {
                    totalCountBal = 4 * selecteItem.Count;

                }
                else if (smsLen >= 613 && smsLen <= 765)
                {
                    totalCountBal = 5 * selecteItem.Count;
                }
                else if (smsLen >= 766 && smsLen <= 918)
                {
                    totalCountBal = 6 * selecteItem.Count;

                }
                else if (smsLen >= 919 && smsLen <= 1071)
                {
                    totalCountBal = 7 * selecteItem.Count;

                }
                else if (smsLen >= 1072 && smsLen <= 1224)
                {
                    totalCountBal = 8 * selecteItem.Count;
                }
                else if (smsLen >= 1225 && smsLen <= 1377)
                {
                    totalCountBal = 9 * selecteItem.Count;

                }
                else if (smsLen >= 1378 && smsLen <= 1530)
                {
                    totalCountBal = 10 * selecteItem.Count;
                }
                else { }


                if (totalCountBal <= SMSbal)
                {
                    string Message = "Dear Total " + selecteItem.Count + " Quick sms send successfully www.myct.in";
                    int length = Message.Length;
                    flag = cc.SendMessageQuickSMS("QuickSMS", sendFrom, Message, length);

                    sysdate = DateTime.Now.ToString("yyyy-MM-dd");
                    foreach (string contactNo in selecteItem)
                    {

                        string sendMessage = txtSendMsg.Text;
                        int smslength = sendMessage.Length;
                        tmpContact = contactNo + ",";
                        totalContact = totalContact + tmpContact;

                        if (sendMessage.Contains("" + sendFrom + " www.myct.in"))
                        {
                            flag = cc.SendMessageQuickSMS(sendFrom, contactNo, sendMessage, smslength);
                        }

                    }
                    SMSbal = SMSbal - totalCountBal - 1;


                    string sqlBalUpdate = "update userMaster set SMSbal=" + SMSbal.ToString() + " where usrMobileNo='" + sendFrom.ToString() + "'";
                    int i = cc.ExecuteNonQuery(sqlBalUpdate);

                    if (i >= 1)
                    {
                        string[] tlsms = totalContact.Split(',');
                        int smsc = Convert.ToInt16(tlsms.Length);
                        int TotalSMSSent = smsc - 1;
                        string sqlinsert = "insert into SMSBalanceReport(userid,MobileNo,Message,SMSLength,smscount,Pre_SMSbal,New_SMSbal,SendDate,No_smssent)" +
                                           "values('" + Convert.ToString(Session["User"]) + "','" + sendFrom + "','" + sendMessage1 + "','" +
                                           smsLen + "','" + totalCountBal + "','" + SMSbalPre + "','" + SMSbal + "','" + sysdate + "','" + TotalSMSSent + "')";
                        string b = cc.ExecuteScalar(sqlinsert);

                    }


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
        txtMobileNo.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";


    }
    protected void gvFriendContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvFriendContact.PageIndex = e.NewPageIndex;
        //int grId = Convert.ToInt32(ddlMyFriendGroupSMS.SelectedValue);
        //  string s4 = Convert.ToString(grId + 1);

        //var v = ds.spRetrieveGroupMemberSendSms(txtGroupSMSLast.Text.ToString(), txtGroupSMSFirst.Text.ToString(), Convert.ToString(Session["User"]), s4).ToList();
        //gvFriendContact.DataSource = v.ToList();
        //gvFriendContact.DataBind();
    }
}



//if (smsLen >= 1 && smsLen <= 160)
//               {
//                   totalCountBal = 1 * selecteItem.Count;
//               }

//               else if (smsLen >= 306 && smsLen <= 459)
//               {
//                   totalCountBal = 2 * selecteItem.Count;
//               }
//               else if (smsLen >= 459 && smsLen <= 612)
//               {
//                   totalCountBal = 3 * selecteItem.Count;
//               }
//               else if (smsLen >= 612 && smsLen <= 765)
//               {
//                   totalCountBal = 4 * selecteItem.Count;
//               }
//               else if (smsLen >= 765 && smsLen <= 918)
//               {
//                   totalCountBal = 5 * selecteItem.Count;

//               }
//               else if (smsLen >= 918 && smsLen <= 1071)
//               {
//                   totalCountBal = 6 * selecteItem.Count;

//               }
//               else if (smsLen >= 1071 && smsLen <= 1224)
//               {
//                   totalCountBal = 7 * selecteItem.Count;
//               }
//               else if (smsLen >= 1224 && smsLen <= 1377)
//               {
//                   totalCountBal = 8 * selecteItem.Count;

//               }
//               else if (smsLen >= 1377 && smsLen <= 1530)
//               {
//                   totalCountBal = 9 * selecteItem.Count;
//               }
//               else if (smsLen >= 1530 && smsLen <= 1683)
//               {
//                   totalCountBal = 10 * selecteItem.Count;
//               }
//               else
//               { }
