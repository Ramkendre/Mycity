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

public partial class html_PromotionalSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    PaidSmsDataContext psdc = new PaidSmsDataContext();

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
                    txtMsgBox.Text = "" + loginfrm + " www.myct.in";
                    LoadPaidBal();


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

    public void LoadPaidBal()
    {
        string usrIdSn = Convert.ToString(Session["User"]);
        string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
        string balVal = cc.ExecuteScalar(paidBal);
        if (balVal != "")
        {
            int bal = Convert.ToInt32(balVal);
            lblPaidBal.Text = Convert.ToString(bal) + " SMS";

        }
        else
        {
            lblPaidBal.Text = "0 SMS";

        }
    }
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

                            if (msgSnd.Contains("" + msgSndFrom + " www.myct.in"))
                            {

                                if (usrIdSn == "65889cc5-601d-4baf-943f-3ef68ccf9016")
                                {
                                    cc.SendMessageTraBulkJSHAPL(msgSndFrom, sendToMoNo, msgSnd, smslength);
                                }
                                else if (usrIdSn == "f417cf88-aeca-4249-b750-809335561584")
                                {
                                    string senderid = "SDHAPL";
                                    cc.SendMessageSenderId(msgSndFrom, sendToMoNo, senderid, msgSnd, smslength);
                                }
                                else if (usrIdSn == "a5d5d9c9-acf5-433c-8fc7-c634468089e0")
                                {
                                    string senderid = "MSCIOA";
                                    cc.SendMessageTraBulkMSCIOA(msgSndFrom, sendToMoNo, msgSnd, smslength);
                                }
                                else
                                {
                                    cc.SendMessageTraBulkPromotional(msgSndFrom, sendToMoNo, msgSnd, smslength);
                                }
                            }
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

    protected void btnOutbox_Click(object sender, EventArgs e)
    {

    }
    #endregion PromotionalSMSCode
}
