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
using System.Net;
using System.Security.Cryptography;
 

public partial class Html_UpldxlofCustomSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    private WebProxy objProxy1 = null;
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
                    // string loginfrm = Session["Mobile"].ToString();
                    txtCustMessage.Text = " www.myct.in";
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
                string tempmsg = "";
                do
                {
                    readdata = sr.ReadLine();
                    if (readdata != null)
                    {
                        string[] data = readdata.Split(',');
                        string mobileno = data[0].ToString();
                        string content1 = data[1].ToString();
                        string content2 = data[2].ToString();
                        string content3 = data[3].ToString();
                        temp += mobileno + ",";
                        tempmsg += content1 + " " + content2 + " " + content3 + ",";

                    }
                    //readdata = sr.ReadLine();

                    i++;
                }

                while (readdata != null);
                if (temp.Length > 1)
                {
                    temp = temp.Substring(0);
                    tempmsg = tempmsg.Substring(0);
                    divMobile.Visible = true;

                }
                if (temp.EndsWith(","))
                {
                    temp = temp.Remove(temp.Length - 1);
                    tempmsg = tempmsg.Remove(tempmsg.Length - 1);
                }

                txtCustMobile.Text = temp;
                txtCustMessage.Text = tempmsg;
                string[] arrsplit = temp.Split(',');
                string[] arrsplit1 = tempmsg.Split(',');
                lblttlCustSMS.Text = "Total MobileNo here:" + Convert.ToString(arrsplit.Length);
                lblMessage.Text = "Total Messages here:" + Convert.ToString(arrsplit1.Length);

            }


        }
        catch (Exception ex)
        {
        }
    }
    private void CustomSMS()
    {
        try
        {
            
           
            string msgSndFrom = Convert.ToString(Session["Mobile"]);
            string usrIdSn = Convert.ToString(Session["User"]);
            string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
            int bal = Convert.ToInt32(cc.ExecuteScalar(paidBal));
            if (bal >= 1)
            {
                int smsLength;
                string sendToMoNo = txtCustMobile.Text;
                string sendToMsg = txtCustMessage.Text;
                sendToMoNo += ","+msgSndFrom;

                
                string[] arrsplit = sendToMoNo.Split(',');
                string[] arrsplit1 = sendToMsg.Split(',');
                int mobilecnt = arrsplit.Length;
                for (int i = 0; i < arrsplit.Length; i++)
                {  
                    String mobileNo = arrsplit[i].ToString();
                    string msgToSend = null;
                    if (i == (arrsplit.Length - 1))
                    {
                         msgToSend = "Dear Total " + arrsplit.Length + " Customized SMS sent successfully www.myct.in";
                    }
                    else
                    {
                         msgToSend = arrsplit1[i].ToString();
                    }
                    if (arrsplit.Length <= bal)
                    {
                        //sendSMS(mobileNo, msgToSend, bal, msgSndFrom);
                        //string Message = txtCustMessage.Text;
                        msgToSend += "www.myct.in";
                        smsLength = msgToSend.Length;
                        string[] msg = null;
                        int smsBalCutCount = 0;

                        if (smsLength >= 0 && smsLength <= 160)
                        {
                            smsBalCutCount = 1;

                        }
                        else if (smsLength >= 161 && smsLength <= 306)
                        {
                            smsBalCutCount = 2;

                        }
                        else if (smsLength >= 307 && smsLength <= 459)
                        {
                            smsBalCutCount = 3;


                        }
                        else if (smsLength >= 460 && smsLength <= 612)
                        {
                            smsBalCutCount = 4;


                        }
                        else if (smsLength >= 613 && smsLength <= 765)
                        {
                            smsBalCutCount = 5;
                        }
                        else if (smsLength >= 766 && smsLength <= 918)
                        {
                            smsBalCutCount = 6;

                        }
                        else if (smsLength >= 919 && smsLength <= 1071)
                        {
                            smsBalCutCount = 7;

                        }
                        else if (smsLength >= 1072 && smsLength <= 1224)
                        {
                            smsBalCutCount = 8;
                        }
                        else if (smsLength >= 1225 && smsLength <= 1377)
                        {
                            smsBalCutCount = 9;

                        }
                        else if (smsLength >= 1378 && smsLength <= 1530)
                        {
                            smsBalCutCount = 10;
                        }
                        else { }

                        if (smsBalCutCount < bal && smsLength <= 1683)
                        {
                            //bool b=  cc.SendMessageCustomizedSMS(smsFrom, mobileNo, msgToSend, smsLength);
                            
                            //if (msgToSend.Length < 160)
                            //{
                            //    sendSMS(mobileNo, msgToSend);
                            //}
                            //else
                            //{
                            //    System.Collections.Generic.List<string> m = getMeesage(msgToSend);
                            //    for (int count = 0; count < m.Count; count++)
                            //        sendSMS(mobileNo, m[count].ToString());
                            //}
                            sendSMS(mobileNo, msgToSend);


                            //---------------------------Ketan Code-------------------------
                            
                            string balance = Convert.ToString(bal - smsBalCutCount);
                            bal = Convert.ToInt32(balance);

                            string sqlCutBalQuery = "update userMaster set paidCount = " + balance + " where usrMobileNo='" + msgSndFrom.ToString() + "'";
                            int SmsSndSuccess = Convert.ToInt32(cc.ExecuteNonQuery(sqlCutBalQuery));
                            if (SmsSndSuccess > 0)
                            {
                                int TotalSmsCount = smsBalCutCount;

                                string Sql = "Insert Into PromotionalSendSMSReport(SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,balance,EntryDate)" +
                                    " Values('" + msgSndFrom + "','" + mobileNo + "','" + msgToSend + "'," + TotalSmsCount + "," + smsLength + "," + (smsBalCutCount) + "," + balance + ",'" + DateFormat + "')";
                                int k = cc.ExecuteNonQuery(Sql);
                                if (k == 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully.')", true);
                                    clearCustomized();

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
                LoadPaidBal();
                
               

                //int mobilelength = arrsplit.Length;
                //int msglength = arrsplit1.Length;
                //string Message = arrsplit1.ToString();


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
    private void sendSMS(string mobileNo, string msgToSend,int bal,string smsFrom)
    {

  


    }
    private System.Collections.Generic.List<string>  getMeesage(string message)
    {
        int i = 0;
        
        System.Collections.Generic.List<string> msg = new System.Collections.Generic.List<string>();
       
        do
        {
            if ((i + 160) < message.Length)
            {
                msg.Add(message.Substring(i, 160));
            }
            else
            {
                msg.Add(message.Substring(i));
            }
            i+=160;
        }
        while(i<=message.Length);
        return msg;
    }
    private string sendSMS( string Mobile_Number, string Message)
    {
        string User = "ezeesoft", password = "67893";

        Mobile_Number = "91" + Mobile_Number;
        System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&mtype=N&DR=Y";

        //string functionReturnValue = null;
        //functionReturnValue = "";

        HttpWebRequest objWebRequest = null;
        HttpWebResponse objWebResponse = null;
        StreamWriter objStreamWriter = null;
        StreamReader objStreamReader = null;

        try
        {
            string stringResult = null;
            //http://api.smscountry.com/SMSCwebservice_bulk.aspx
            objWebRequest = (HttpWebRequest)WebRequest.Create("http://api.smscountry.com/SMSCwebservice_bulk.aspx?");
            objWebRequest.Method = "POST";

            if ((objProxy1 != null))
            {
                objWebRequest.Proxy = objProxy1;
            }

            // Use below code if you want to SETUP PROXY.
            //Parameters to pass: 1. ProxyAddress 2. Port
            //You can find both the parameters in Connection settings of your internet explorer.

            //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
            //myProxy.BypassProxyOnLocal = true;
            //wrGETURL.Proxy = myProxy;

            objWebRequest.ContentType = "application/x-www-form-urlencoded";

            objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
            objStreamWriter.Write(stringpost);
            objStreamWriter.Flush();
            objStreamWriter.Close();

            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
            objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
            stringResult = objStreamReader.ReadToEnd();

            objStreamReader.Close();
            return (stringResult);
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
        finally
        {

            if ((objStreamWriter != null))
            {
                objStreamWriter.Close();
            }
            if ((objStreamReader != null))
            {
                objStreamReader.Close();
            }
            objWebRequest = null;
            objWebResponse = null;
            objProxy1 = null;
        }
    }


    private void clearCustomized()
    {
        txtCustMobile.Text = "";
        divMobile.Visible = false;
        txtCustMessage.Text = "";
        txtchrcount.Text = "";
        //string loginfrm = Session["Mobile"].ToString();
        txtCustMessage.Text = "" + " www.myct.in";
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        UploadExcel();
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
}
