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
using System.IO;

public partial class html_CustomizedSMS : System.Web.UI.Page
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
                    txtCustMessage.Text = loginfrm + " www.myct.in";
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

            lblCustpaidbal.Text = Convert.ToString(bal) + " SMS";

        }
        else
        {

            lblCustpaidbal.Text = "0 SMS";

        }
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
    protected void btnCustSend_Click(object sender, EventArgs e)
    {


        if (txtCustMessage.Text != "")
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

}
