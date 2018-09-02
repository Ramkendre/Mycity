using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;


//using System.Collections.Generic;

/// <summary>
/// Summary description for CommonCode
/// </summary>
public class CommonCode
{
    public CommonCode()
    {
    }
    DataTable dtCategory = new DataTable();
    private static byte[] keys = { };
    private static byte[] IVs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    private static string EncryptionKeys = "!5623a#de";

    const string DESKey = "AQWSEDRF";
    const string DESIV = "HGFEDCBA";


    /// <summary>
    ///  Check the extension of image
    /// </summary>
    /// <param name="imageName">file name of Image</param>
    /// <returns>true if file  is  image type</returns>
    public bool CheckImageExtension(string imageName)
    {
        bool imageOk = false;

        string fileExtension = Path.GetExtension(imageName.ToString()).ToLower();
        string[] allowExtensions = { ".png", ".jpeg", ".jpg", ".gif", ".PNG", ".JPEG", ".JPG", ".GIF" };

        for (int i = 0; i < allowExtensions.Length; i++)
        {
            if (fileExtension == allowExtensions[i])
            {
                imageOk = true;
            }
        }

        return imageOk;
    }

    public DataSet ExecuteDataset(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, Sql);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }

    public int ExecuteScalar1(string Sql)
    {
        int Data = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                Data = Convert.ToInt32(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }
    public string ExecuteScalar(string Sql)
    {
        string Data = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                Data = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, Sql));

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return Data;
    }

    public int ExecuteNonQuery(string Sql)
    {
        int flag = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                flag = SqlHelper.ExecuteNonQuery(con, CommandType.Text, Sql);

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }
        }
        return flag;
    }
    //public bool SendMessageGroupSMSbyLongCode(string sendFrom, string sendTo, string fwdMessage)
    //public bool SendMessageImp1(string sendFrom, string sendTo, string fwdMessage)
    //    {
    //       bool flagMsgSuccess = false;

    //       try
    //       {
    //           string userid = "ezeesoft";
    //           string password = "come2mycity";
    //           fwdMessage = fwdMessage + "...";
    //           //string send_id = "ezeesoft";
    //           ////string userid = "ezee-temp1";
    //           ////string password = "come2mycity";
    //           // string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;
    //           //string strRequest = "username=" + userid + "&password=" + password + "&sender=" + sendFrom + "&numbers=" + sendTo + "&message=" + fwdMessage + "";
    //           //string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
    //           string strRequest = "username=" + userid + "&password=" + password + "&sender=" + sendFrom + "&mobile=" + sendTo + "&type=1&message=" + fwdMessage + "";
    //           //string url = "http://smsigma.com/sendsms.php?";
    //           //string url = "http://smsigma.com";
    //           string url = "http://www.smsigma.com/sendsms.php?";
    //           string result = "";
    //           StreamWriter myWriter = null;
    //           HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
    //           objRequest.Method = "POST";
    //           objRequest.ContentLength = strRequest.Length;
    //           objRequest.ContentType = "application/x-www-form-urlencoded";

    //           myWriter = new StreamWriter(objRequest.GetRequestStream());
    //           myWriter.Write(strRequest);

    //           myWriter.Close();
    //           HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //           using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //           {
    //               result = sr.ReadToEnd();
    //               sr.Close();
    //           }
    //           string resultMsg = result;
    //           string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
    //           int d = ExecuteNonQuery(sql);
    //           if (resultMsg.Contains("SMS Sent Successfully"))
    //           {

    //               flagMsgSuccess = true;
    //           }
    //           else
    //           {
    //               flagMsgSuccess = false;
    //           }

    //       }
    //       catch (Exception ex)
    //       {
    //           throw ex;
    //       }
    //       flagMsgSuccess = true;
    //       return flagMsgSuccess;
    //   }


    /* public bool SendMessage1(string sendFrom, string sendTo, string fwdMessage)
       {
           bool flagMsgSuccess = false;

           try
           {
               string userid = "ezeesoft";
               string password = "come2mycity";
               //string send_id = "ezeesoft";
               ////string userid = "ezee-temp1";
               ////string password = "come2mycity";
               // string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;
               //string strRequest = "username=" + userid + "&password=" + password + "&sender=" + sendFrom + "&numbers=" + sendTo + "&message=" + fwdMessage + "";
               //string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
               string strRequest = "username=" + userid + "&password=" + password + "&sender=" + sendFrom + "&mobile=" + sendTo + "&type=1&message=" + fwdMessage + "";
               //string url = "http://smsigma.com/sendsms.php?";
               //string url = "http://smsigma.com";
               string url = "http://www.smsigma.com/sendsms.php?";
               string result = "";
               StreamWriter myWriter = null;
               HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
               objRequest.Method = "POST";
               objRequest.ContentLength = strRequest.Length;
               objRequest.ContentType = "application/x-www-form-urlencoded";

               myWriter = new StreamWriter(objRequest.GetRequestStream());
               myWriter.Write(strRequest);

               myWriter.Close();
               HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
               using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
               {
                   result = sr.ReadToEnd();
                   sr.Close();
               }
               string resultMsg = result;
               if (resultMsg.Contains("SMS Sent Successfully"))
               //if (resultMsg.Contains("SMS Sent Successfully"))
               {

                   flagMsgSuccess = true;
               }
               else
               {
                   flagMsgSuccess = false;
               }

           }
           catch (Exception ex)
           {
               throw ex;
           }

           return flagMsgSuccess;
       }*/


    //public void mailSendingSMS(string sendFrom, string sendTo, string fwdMessage)
    //{
    //    string fromMo = sendFrom;
    //    string sndtoMo = sendTo;
    //    string sndfrmsql = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + fromMo.ToString() + "'";
    //    DataSet ds = new DataSet();
    //    ds = ExecuteDataset(sndfrmsql);
    //    string name = "", email = "", ct = "";
    //    foreach (DataRow dr in ds.Tables[0].Rows)
    //    {
    //        name = Convert.ToString(dr["name"]);
    //        email = Convert.ToString(dr["usrEmailId"]);
    //        ct = Convert.ToString(dr["usrCity"]);
    //    }

    //    string sndfrmsql1 = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + sndtoMo.ToString() + "'";
    //    DataSet ds1 = new DataSet();
    //    ds1 = ExecuteDataset(sndfrmsql1);
    //    string name1 = "", email1 = "", ct1 = "";
    //    foreach (DataRow dr1 in ds1.Tables[0].Rows)
    //    {
    //        name1 = Convert.ToString(dr1["name"]);
    //        email1 = Convert.ToString(dr1["usrEmailId"]);
    //        ct1 = Convert.ToString(dr1["usrCity"]);
    //    }
    //    string mailBody = "";
    //    fwdMessage = fwdMessage.Replace("sssss", "'");
    //    fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //    if (email1.ToString() != "")
    //    {
    //        string sub = "";
    //        if (name != "")
    //        {
    //            sub = "SMS from " + name.ToString() + "......www.myct.in";
    //            mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " City: " + ct.ToString() + " ..... www.myct.in";
    //        }
    //        else
    //        {
    //            sub = "SMS from COM2MYCT......www.myct.in";
    //            mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: www.myct.in";
    //        }
    //        //string mailBody = "Message: "+fwdMessage .ToString ()+" \n\nFrom: "+name .ToString ()+" City: "+ct .ToString ()+" ..... www.myct.in";
    //        ll.sendEmail(email1, sub, mailBody);

    //    }

    //}

    //public void mailSendingSMS(string sendFrom, string sendTo, string fwdMessage, string KeyWord)
    //{
    //    string fromMo = sendFrom;
    //    string sndtoMo = sendTo;
    //    string sndfrmsql = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + fromMo.ToString() + "'";
    //    DataSet ds = new DataSet();
    //    ds = ExecuteDataset(sndfrmsql);
    //    string name = "", email = "", ct = "";
    //    foreach (DataRow dr in ds.Tables[0].Rows)
    //    {
    //        name = Convert.ToString(dr["name"]);
    //        email = Convert.ToString(dr["usrEmailId"]);
    //        ct = Convert.ToString(dr["usrCity"]);
    //    }

    //    string sndfrmsql1 = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + sndtoMo.ToString() + "'";
    //    DataSet ds1 = new DataSet();
    //    ds1 = ExecuteDataset(sndfrmsql1);
    //    string name1 = "", email1 = "", ct1 = "";
    //    foreach (DataRow dr1 in ds1.Tables[0].Rows)
    //    {
    //        name1 = Convert.ToString(dr1["name"]);
    //        email1 = Convert.ToString(dr1["usrEmailId"]);
    //        ct1 = Convert.ToString(dr1["usrCity"]);
    //    }
    //    string mailBody = "";
    //    fwdMessage = fwdMessage.Replace("sssss", "'");
    //    fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //    if (email1.ToString() != "")
    //    {
    //        string sub = "";
    //        if (name != "")
    //        {
    //            sub = "SMS from " + name.ToString() + "......www.myct.in";
    //            if (KeyWord == "CG")
    //                mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " City: " + ct.ToString() + "\n\n आदरणीय मुख्यमंत्री महोदय मा कर्मा जयंती उत्सव के उपलक्ष में आप गुंडरदेही पधारे और छत्तीसगड के तथा साहू समाज के आधुनिक मोबाईल डिरेकट्री की शुरवात आपके हातो हुई इसलिये हम सब साहू समाज की ओरसे आपके आभारी है| बहोत बहोत धन्यवाद |  ..... www.myct.in";
    //            else
    //                mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " City: " + ct.ToString() + " ..... www.myct.in";
    //        }
    //        else
    //        {
    //            sub = "SMS from COM2MYCT......www.myct.in";
    //            mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: www.myct.in";
    //        }
    //        //string mailBody = "Message: "+fwdMessage .ToString ()+" \n\nFrom: "+name .ToString ()+" City: "+ct .ToString ()+" ..... www.myct.in";
    //        ll.sendEmail(email1, sub, mailBody);

    //    }

    //}
    //*********************************Email sending******


    //public void mailSendingSMSAsEmail(string fwdMessage, string Email, string Name)
    //{
    //    try
    //    {
    //        string email = Email;
    //        string name = Name;


    //        string mailBody = "";

    //        string sub = "";
    //        sub = "SMS from " + name.ToString() + "......www.myct.in";
    //        mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " ..... www.myct.in";


    //        mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: www.myct.in";

    //        ll.sendEmail(email, sub, mailBody);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}







    //public bool SendMessage1(string sendFrom, string sendTo, string fwdMessage)
    //{
    //    bool flagMsgSuccess = false;

    //    try
    //    {
    //        fwdMessage = fwdMessage.Replace("&", "and");
    //        string sendto = Convert.ToString(sendTo);
    //        fwdMessage = fwdMessage.Replace("sssss", "'");
    //        fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //        mailSendingSMS(sendFrom, sendto, fwdMessage);
    //        //////string userid = "ezeesoft";
    //        //////string password = "abhinav313";
    //        string userid = "ezeesoft";
    //        string password = "67893";
    //        //string userid = "come2mycity";
    //        ////string password = "ezeesoft";
    //        ////string userid = "come2mycity-priority";
    //        //string password = "1j837BhZ2";
    //        ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

    //        //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

    //        ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
    //        //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
    //        string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
    //        //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
    //        ////string url = "http://smsblaster.info/pushsms.php?";
    //        string url = "http://www.smscountry.com/SMSCwebservice.asp?";
    //        //string url = "http://182.18.189.124:8800/sendsms.php?";
    //        string result = "";
    //        StreamWriter myWriter = null;
    //        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
    //        objRequest.Method = "POST";
    //        objRequest.ContentLength = strRequest.Length;
    //        objRequest.ContentType = "application/x-www-form-urlencoded";
    //        myWriter = new StreamWriter(objRequest.GetRequestStream());
    //        myWriter.Write(strRequest);
    //        myWriter.Close();
    //        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //        {
    //            result = sr.ReadToEnd();
    //            sr.Close();
    //        }
    //        if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
    //        {
    //            result = "unable to Process SMS between 9 PM to 9 AM.";
    //        }

    //        fwdMessage = fwdMessage.Replace("'", "sssss");
    //        fwdMessage = fwdMessage.Replace("&", "aaaaa");
    //        string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
    //        int d = ExecuteNonQuery(sql);
    //        string resultMsg = result;
    //        //if (resultMsg.Contains("EZEESOFT"))
    //        if (resultMsg.Contains("203179963"))
    //        {

    //            flagMsgSuccess = true;
    //        }
    //        else
    //        {
    //            flagMsgSuccess = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    flagMsgSuccess = true;
    //    return flagMsgSuccess;
    //}

    //public bool SendMessagePaidEnglish(string sendFrom, string sendTo, string fwdMessage)
    //{
    //    bool flagMsgSuccess = false;

    //    try
    //    {
    //        fwdMessage = fwdMessage.Replace("&", "and");
    //        string sendto = Convert.ToString(sendTo);
    //        fwdMessage = fwdMessage.Replace("sssss", "'");
    //        fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //        mailSendingSMS(sendFrom, sendto, fwdMessage);
    //        string userid = "ezeesoft";
    //        string password = "67893";
    //        //string userid = "ezzesoft";
    //        //string password = "67893";
    //        //string userid = "come2mycity";
    //        ////string password = "ezeesoft";
    //        ////string userid = "come2mycity-priority";
    //        //string password = "1j837BhZ2";
    //        ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

    //        //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

    //        ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
    //        //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
    //        string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
    //        //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
    //        ////string url = "http://smsblaster.info/pushsms.php?";
    //        string url = "http://www.smscountry.com/SMSCwebservice.asp?";
    //        //string url = "http://182.18.189.124:8800/sendsms.php?";
    //        string result = "";
    //        StreamWriter myWriter = null;
    //        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
    //        objRequest.Method = "POST";
    //        objRequest.ContentLength = strRequest.Length;
    //        objRequest.ContentType = "application/x-www-form-urlencoded";
    //        myWriter = new StreamWriter(objRequest.GetRequestStream());
    //        myWriter.Write(strRequest);
    //        myWriter.Close();
    //        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //        {
    //            result = sr.ReadToEnd();
    //            sr.Close();
    //        }
    //        if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
    //        {
    //            result = "unable to Process SMS between 9 PM to 9 AM.";
    //        }

    //        fwdMessage = fwdMessage.Replace("'", "sssss");
    //        fwdMessage = fwdMessage.Replace("&", "aaaaa");
    //        psds.InsertPaidSMs(sendFrom.ToString(), sendTo.ToString(), fwdMessage.ToString(), result.ToString());
    //        //string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
    //        //int d = ExecuteNonQuery(sql);
    //        string resultMsg = result;
    //        //if (resultMsg.Contains("EZEESOFT"))
    //        if (resultMsg.Contains("203179963"))
    //        {

    //            flagMsgSuccess = true;
    //        }
    //        else
    //        {
    //            flagMsgSuccess = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    flagMsgSuccess = true;
    //    return flagMsgSuccess;
    //}

    //public bool SendMessageDelivered(string sendFrom, string sendTo, string fwdMessage, string shortcode)
    //{
    //    bool flagMsgSuccess = false;

    //    try
    //    {
    //        fwdMessage = fwdMessage.Replace("&", "and");
    //        string sendto = Convert.ToString(sendTo);
    //        fwdMessage = fwdMessage.Replace("sssss", "'");
    //        fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //        mailSendingSMS(sendFrom, sendto, fwdMessage);

    //        string userid = "ezeesoft";
    //        string password = "67893";
    //        //string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
    //        string url = "http://www.smscountry.com/SMSCwebservice.asp?";
    //        //string url1 = " http://api.smscountry.com/smscwebservices_bulk_reports.aspx?";
    //        string srereq = "user=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&fromdate=" + shortcode + "&todate=" + shortcode + "&sid=";
    //        string result = "";
    //        StreamWriter myWriter = null;
    //        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + srereq);
    //        objRequest.Method = "POST";
    //        objRequest.ContentLength = srereq.Length;
    //        objRequest.ContentType = "application/x-www-form-urlencoded";
    //        myWriter = new StreamWriter(objRequest.GetRequestStream());
    //        myWriter.Write(srereq);
    //        myWriter.Close();
    //        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //        {
    //            result = sr.ReadToEnd();
    //            sr.Close();
    //        }
    //        if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
    //        {
    //            result = "unable to Process SMS between 9 PM to 9 AM.";
    //        }

    //        fwdMessage = fwdMessage.Replace("'", "sssss");
    //        fwdMessage = fwdMessage.Replace("&", "aaaaa");
    //        string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
    //        int d = ExecuteNonQuery(sql);
    //        string resultMsg = result;
    //        //if (resultMsg.Contains("EZEESOFT"))
    //        if (resultMsg.Contains("203179963"))
    //        {

    //            flagMsgSuccess = true;
    //        }
    //        else
    //        {
    //            flagMsgSuccess = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    flagMsgSuccess = true;
    //    return flagMsgSuccess;
    //}

    //public bool SendMessageTra(string sendFrom, string sendTo, string fwdMessage)
    //{
    //    bool flagMsgSuccess = false;

    //    try
    //    {
    //        fwdMessage = fwdMessage.Replace("&", "and");
    //        string sendto = Convert.ToString(sendTo);
    //        fwdMessage = fwdMessage.Replace("sssss", "'");
    //        fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //        //mailSendingSMS(sendFrom, sendto, fwdMessage);

    //        string userid = "ezeesoft";
    //        string password = "67893";
    //        //string userid = "come2mycity";
    //        ////string password = "ezeesoft";
    //        ////string userid = "come2mycity-priority";
    //        //string password = "1j837BhZ2";
    //        ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

    //        //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

    //        ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
    //        //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
    //        string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
    //        //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
    //        ////string url = "http://smsblaster.info/pushsms.php?";
    //        string url = "http://www.smscountry.com/SMSCwebservice.asp?";
    //        //string url = "http://182.18.189.124:8800/sendsms.php?";
    //        string result = "";
    //        StreamWriter myWriter = null;
    //        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
    //        objRequest.Method = "POST";
    //        objRequest.ContentLength = strRequest.Length;
    //        objRequest.ContentType = "application/x-www-form-urlencoded";
    //        myWriter = new StreamWriter(objRequest.GetRequestStream());
    //        myWriter.Write(strRequest);
    //        myWriter.Close();
    //        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //        {
    //            result = sr.ReadToEnd();
    //            sr.Close();
    //        }
    //        if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
    //        {
    //            result = "unable to Process SMS between 9 PM to 9 AM.";
    //        }

    //        fwdMessage = fwdMessage.Replace("'", "sssss");
    //        fwdMessage = fwdMessage.Replace("&", "aaaaa");
    //        string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
    //        int d = ExecuteNonQuery(sql);
    //        string resultMsg = result;
    //        //if (resultMsg.Contains("EZEESOFT"))
    //        if (resultMsg.Contains("203179963"))
    //        {

    //            flagMsgSuccess = true;
    //        }
    //        else
    //        {
    //            flagMsgSuccess = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    flagMsgSuccess = true;
    //    return flagMsgSuccess;
    //}

    //public bool ReceiveReportTra(string sendFrom, string sendTo, string fwdMessage)
    //{
    //    bool flagMsgSuccess = false;

    //    try
    //    {
    //        fwdMessage = fwdMessage.Replace("&", "and");
    //        string sendto = Convert.ToString(sendTo);
    //        fwdMessage = fwdMessage.Replace("sssss", "'");
    //        fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //        mailSendingSMS(sendFrom, sendto, fwdMessage);

    //        string userid = "ezeesoft";
    //        string password = "67893";
    //        //string userid = "come2mycity";
    //        ////string password = "ezeesoft";
    //        ////string userid = "come2mycity-priority";
    //        //string password = "1j837BhZ2";
    //        ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

    //        //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

    //        ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
    //        //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
    //        string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
    //        //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
    //        ////string url = "http://smsblaster.info/pushsms.php?";
    //        string url = "http://www.smscountry.com/SMSCwebservice.asp?";
    //        //string url = "http://182.18.189.124:8800/sendsms.php?";
    //        string result = "";
    //        StreamWriter myWriter = null;
    //        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
    //        objRequest.Method = "POST";
    //        objRequest.ContentLength = strRequest.Length;
    //        objRequest.ContentType = "application/x-www-form-urlencoded";
    //        myWriter = new StreamWriter(objRequest.GetRequestStream());
    //        myWriter.Write(strRequest);
    //        myWriter.Close();
    //        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //        {
    //            result = sr.ReadToEnd();
    //            sr.Close();
    //        }
    //        if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
    //        {
    //            result = "unable to Process SMS between 9 PM to 9 AM.";
    //        }

    //        fwdMessage = fwdMessage.Replace("'", "sssss");
    //        fwdMessage = fwdMessage.Replace("&", "aaaaa");
    //        string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
    //        int d = ExecuteNonQuery(sql);
    //        string resultMsg = result;
    //        //if (resultMsg.Contains("EZEESOFT"))
    //        if (resultMsg.Contains("203179963"))
    //        {

    //            flagMsgSuccess = true;
    //        }
    //        else
    //        {
    //            flagMsgSuccess = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    flagMsgSuccess = true;
    //    return flagMsgSuccess;
    //}

    //public bool SendMessageTra(string sendFrom, string sendTo, string fwdMessage, string KeyWord)
    //{
    //    bool flagMsgSuccess = false;

    //    try
    //    {
    //        fwdMessage = fwdMessage.Replace("&", "and");
    //        string sendto = Convert.ToString(sendTo);
    //        fwdMessage = fwdMessage.Replace("sssss", "'");
    //        fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //        mailSendingSMS(sendFrom, sendto, fwdMessage, KeyWord);
    //        //////string userid = "ezeesoft";
    //        //////string password = "abhinav313";
    //        string userid = "ezeesoft";
    //        string password = "67893";
    //        //string userid = "come2mycity";
    //        ////string password = "ezeesoft";
    //        ////string userid = "come2mycity-priority";
    //        //string password = "1j837BhZ2";
    //        ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

    //        //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

    //        ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
    //        //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
    //        string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
    //        //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
    //        ////string url = "http://smsblaster.info/pushsms.php?";
    //        string url = "http://www.smscountry.com/SMSCwebservice.asp?";
    //        //string url = "http://182.18.189.124:8800/sendsms.php?";
    //        string result = "";
    //        StreamWriter myWriter = null;
    //        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
    //        objRequest.Method = "POST";
    //        objRequest.ContentLength = strRequest.Length;
    //        objRequest.ContentType = "application/x-www-form-urlencoded";
    //        myWriter = new StreamWriter(objRequest.GetRequestStream());
    //        myWriter.Write(strRequest);
    //        myWriter.Close();
    //        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
    //        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
    //        {
    //            result = sr.ReadToEnd();
    //            sr.Close();
    //        }
    //        if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
    //        {
    //            result = "unable to Process SMS between 9 PM to 9 AM.";
    //        }

    //        fwdMessage = fwdMessage.Replace("'", "sssss");
    //        fwdMessage = fwdMessage.Replace("&", "aaaaa");
    //        string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
    //        int d = ExecuteNonQuery(sql);
    //        string resultMsg = result;
    //        //if (resultMsg.Contains("EZEESOFT"))
    //        if (resultMsg.Contains("203179963"))
    //        {

    //            flagMsgSuccess = true;
    //        }
    //        else
    //        {
    //            flagMsgSuccess = false;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    flagMsgSuccess = true;
    //    return flagMsgSuccess;
    //}


    public bool SendMessageImp1(string sendFrom, string sendTo, string fwdMessage)
    {
        bool flagMsgSuccess = false;

        //try
        //{
        //    fwdMessage = fwdMessage.Replace("&", "and");
        //    string sendto = Convert.ToString(sendTo);
        //    fwdMessage = fwdMessage.Replace("sssss", "'");
        //    fwdMessage = fwdMessage.Replace("aaaaa", "&");
        //    mailSendingSMS(sendFrom, sendto, fwdMessage);
        //    //////string userid = "ezeesoft";
        //    //////string password = "abhinav313";
        //    string userid = "ezeesoft";
        //    string password = "67893";
        //    //string userid = "come2mycity";
        //    ////string password = "ezeesoft";
        //    ////string userid = "come2mycity-priority";
        //    //string password = "1j837BhZ2";
        //    ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

        //    //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

        //    ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
        //    //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
        //    string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
        //    //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
        //    ////string url = "http://smsblaster.info/pushsms.php?";
        //    string url = "http://www.smscountry.com/SMSCwebservice.asp?";
        //    //string url = "http://182.18.189.124:8800/sendsms.php?";
        //    string result = "";
        //    StreamWriter myWriter = null;
        //    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
        //    objRequest.Method = "POST";
        //    objRequest.ContentLength = strRequest.Length;
        //    objRequest.ContentType = "application/x-www-form-urlencoded";
        //    myWriter = new StreamWriter(objRequest.GetRequestStream());
        //    myWriter.Write(strRequest);
        //    myWriter.Close();
        //    HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //    using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        //    {
        //        result = sr.ReadToEnd();
        //        sr.Close();
        //    }
        //    if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
        //    {
        //        result = "unable to Process SMS between 9 PM to 9 AM.";
        //    }

        //    fwdMessage = fwdMessage.Replace("'", "sssss");
        //    fwdMessage = fwdMessage.Replace("&", "aaaaa");
        //    string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
        //    int d = ExecuteNonQuery(sql);
        //    string resultMsg = result;
        //    //if (resultMsg.Contains("EZEESOFT"))
        //    if (resultMsg.Contains("203179963"))
        //    {

        //        flagMsgSuccess = true;
        //    }
        //    else
        //    {
        //        flagMsgSuccess = false;
        //    }

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }


    public bool SendMessage(string sendFrom, string sendTo, string fwdMessage)
    {
        bool flagMsgSuccess = false;

        /*    try
            {
                string userid = "come2mycity";
                string password = "ezeesoft";
                //string send_id = "ezeesoft";
                ////string userid = "ezee-temp1";
                ////string password = "come2mycity";
                // string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;
                //string strRequest = "username=" + userid + "&password=" + password + "&sender=" + sendFrom + "&numbers=" + sendTo + "&message=" + fwdMessage + "";
                //string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
                string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
                //string url = "http://smsigma.com/sendsms.php?";
                //string url = "http://smsigma.com";
                string url = "http://smsblaster.info/pushsms.php?";
                string result = "";
                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
                objRequest.Method = "POST";
                objRequest.ContentLength = strRequest.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";

                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strRequest);
           
                myWriter.Close();
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
                string resultMsg = result;
                string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
                int d = ExecuteNonQuery(sql);
                if (resultMsg.Contains("SMS successfully sent."))
                    //if (resultMsg.Contains("SMS Sent Successfully"))
                {
                
                    flagMsgSuccess = true;
                }
                else
                {
                    flagMsgSuccess = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }            */
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }


    public bool SendMessageImp(string sendFrom, string sendTo, string fwdMessage)
    {
        bool flagMsgSuccess = false;

        /*      try
              {

                  string sendto = Convert.ToString(sendTo);
                  //////string userid = "ezeesoft";
                  //////string password = "abhinav313";
                  string userid = "ezeesoft2";
                  string password = "come2mycity";
                  fwdMessage = fwdMessage + "...";
                  //string userid = "come2mycity";
                  ////string password = "ezeesoft";
                  ////string userid = "come2mycity-priority";
                  //string password = "1j837BhZ2";
                  ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

                  //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

                  ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
                  string strRequest = "username=" + userid + "&password=" + password + "&Sender=" + sendFrom + "&phonenumber=" + sendto + "&msgtype=text&ReceiptRequested=Yes&text=" + fwdMessage + "";
                  //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
                  ////string url = "http://smsblaster.info/pushsms.php?";
                  string url = "http://www.smsigma.com?";
                  //string url = "http://182.18.189.124:8800/sendsms.php?";
                  string result = "";
                  StreamWriter myWriter = null;
                  HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strRequest);
                  objRequest.Method = "POST";
                  objRequest.ContentLength = strRequest.Length;
                  objRequest.ContentType = "application/x-www-form-urlencoded";
                  myWriter = new StreamWriter(objRequest.GetRequestStream());
                  myWriter.Write(strRequest);
                  myWriter.Close();
                  HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                  using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                  {
                      result = sr.ReadToEnd();
                      sr.Close();
                  }
                  string resultMsg = result;
                  string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
                  int d = ExecuteNonQuery(sql);
                  //if (resultMsg.Contains("EZEESOFT"))
                  if (resultMsg.Contains("Message Submitted"))
                  {

                      flagMsgSuccess = true;
                  }
                  else
                  {
                      flagMsgSuccess = false;
                  }

              }
              catch (Exception ex)
              {
                  throw ex;
              }                         */
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }




    public string Decryption(string sInput)
    {
        Byte[] inputArray = new Byte[sInput.Length];
        try
        {
            keys = System.Text.Encoding.UTF8.GetBytes(EncryptionKeys.Substring(0, 8));
            DESCryptoServiceProvider description = new DESCryptoServiceProvider();
            inputArray = Convert.FromBase64String(sInput);
            MemoryStream mstream = new MemoryStream();
            CryptoStream cstream = new CryptoStream
            (mstream, description.CreateDecryptor(keys, IVs), CryptoStreamMode.Write);
            cstream.Write(inputArray, 0, inputArray.Length);
            cstream.FlushFinalBlock();

            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(mstream.ToArray());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string Encrypt(string sInput)
    {
        try
        {
            keys = System.Text.Encoding.UTF8.GetBytes
            (EncryptionKeys.Substring(0, 8));
            DESCryptoServiceProvider description = new DESCryptoServiceProvider();
            Byte[] inputArray = Encoding.UTF8.GetBytes(sInput);
            MemoryStream mstream = new MemoryStream();
            CryptoStream cstream = new CryptoStream
            (mstream, description.CreateEncryptor(keys, IVs), CryptoStreamMode.Write);
            cstream.Write(inputArray, 0, inputArray.Length);
            cstream.FlushFinalBlock();
            return Convert.ToBase64String(mstream.ToArray());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    ///  Decrypt the Encrypted String with DES to normal string
    /// </summary>
    /// <param name="stringToDecrypt">Encrypted String to Decrypt</param>
    /// <returns>Decrypted string </returns>
    public string DESDecrypt(string stringToDecrypt)//Decrypt the content
    {

        byte[] key;
        byte[] IV;

        byte[] inputByteArray;
        try
        {

            key = Convert2ByteArray(DESKey);
            IV = Convert2ByteArray(DESIV);

            stringToDecrypt = stringToDecrypt.Replace(" ", "+");

            int len = stringToDecrypt.Length;
            inputByteArray = Convert.FromBase64String(stringToDecrypt);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }



    /// <summary>
    /// Encrypt the normal string with the DES to Encrypted string 
    /// </summary>
    /// <param name="stringToEncrypt">Normal String  to Encrypt</param>
    /// <returns></returns>
    public string DESEncrypt(string stringToEncrypt)// Encrypt the content
    {

        byte[] key;
        byte[] IV;

        byte[] inputByteArray;
        try
        {

            key = Convert2ByteArray(DESKey);
            IV = Convert2ByteArray(DESIV);
            inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        catch (System.Exception ex)
        {
            throw ex;
        }

    }

    static byte[] Convert2ByteArray(string strInput)
    {

        int intCounter; char[] arrChar;
        arrChar = strInput.ToCharArray();

        byte[] arrByte = new byte[arrChar.Length];

        for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
            arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

        return arrByte;
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

            dt1 = tmpdt[1] + "/" + tmpdt[0] + "/" + tmpdt[2];

        }
        catch (Exception ex)
        {
            string msg = ex.Message;


        }
        return dt1;
    }

    public string ChangeDt(string Date1)//07-11-2012//07/11/2012
    {
        string Date = "";
        string time = System.DateTime.Now.ToString();
        string[] tm = time.Split(' ');
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('/');
            Date = tmp[2].ToString() + "-" + tmp[0].ToString() + "-" + tmp[1].ToString() + " " + tm[1] + " " + tm[2];
        }
        catch (Exception ex)
        { }
        return Date;
    }
    public string ChangeDt1(string Date1)//07-11-2012//07/11/2012
    {
        string Date = "";
        string time = System.DateTime.Now.ToString();
        string[] tm = time.Split(' ');
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('/');
            Date = tmp[2].ToString() + "-" + tmp[0].ToString() + "-" + tmp[1].ToString();
        }
        catch (Exception ex)
        { }
        return Date;
    }
    public string ChangeDate1(string dt)
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

            dt1 = tmpdt[2] + "-" + tmpdt[1] + "-" + tmpdt[0];

        }
        catch (Exception ex)
        {
            string msg = ex.Message;


        }
        return dt1;
    }

    public string ChangeDate2(string dt)
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

            dt1 = tmpdt[2] + "-" + tmpdt[0] + "-" + tmpdt[1];

        }
        catch (Exception ex)
        {
            string msg = ex.Message;


        }
        return dt1;
    }

    public string DTGet_Local(string Date1)//2013-16-01
    {

        string Date = "";
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('-');

            Date = tmp[1].ToString() + "/" + tmp[2].ToString() + "/" + tmp[0].ToString() + "";
        }
        catch (Exception ex)
        { }
        return Date;

    }


    public string DTInsert_Local(string Date1)//06/21/2012
    {


        string Date = "";
        string time = System.DateTime.Now.ToString();
        string[] tm = time.Split(' ');
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('/');

            Date = tmp[2].ToString() + "-" + tmp[1].ToString() + "-" + tmp[0].ToString();
        }
        catch (Exception ex)
        { }
        return Date;
        //string time = System.DateTime.Now.ToString();
        //string[] tm = time.Split(' ');
        //string Date = "";
        //try
        //{
        //    string[] tmp = Date1.Split(' ');
        //    string tm = tmp[1];
        //    tmp = tmp[0].Split('/');
        //    Date = tmp[2].ToString() + "-" + tmp[0].ToString() + "-" + tmp[1].ToString() + " " + tmp[1];
        //}
        //catch (Exception ex)
        //{ }
        //return Date;
    }

    /// <summary>
    ///  Show the city Name according to the  cityId
    /// </summary>
    /// <param name="ct">City Id through the property</param>
    /// <returns>State---->District---->City</returns>




    public string AdvMessage()
    {

        string advMsg = "Ad: Join All India Mobile Directory Users Association on come2mycity.com";
        return advMsg;
    }

    public string AddSMS(string usrMoNo)
    {
        string str = "";
        string SqlAdd = "select SP.Id as ID,SP.Msg as sms, SP.Sent as sentsms from SMSPushingCity SPC Inner Join UserMaster UM on SPC.CityId=UM.usrCityId Inner Join SMSPushing SP on SP.Id=SPC.SmsPushingId where usrMobileNo='" + usrMoNo.ToString() + "' and SP.TotalMsg > SP.Sent and CONVERT(DATETIME ,SP.StartDate)<= SYSDATETIME() and not CONVERT(DATETIME ,SP.StartDate)>= GETDATE()+SP.Days";
        DataSet ds = ExecuteDataset(SqlAdd);
        string sms = "";
        int id = 0, sendSms = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            id = Convert.ToInt32(dr["ID"]);
            sms = Convert.ToString(dr["sms"]);
            sendSms = Convert.ToInt32(dr["sentsms"]);
        }
        if (sms == "")
        {
            str = " Thanks Via www.myct.in";
        }
        else
        {
            str = "Ad: " + sms.ToString();
            string SqlUpdate = "Update SMSPushing set Sent=" + (sendSms + 1).ToString() + " where Id=" + id.ToString() + "";
            int ff = ExecuteNonQuery(SqlUpdate);
        }


        return str;
    }

    public DataSet getLoginDetails(string UserId, string Password)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];

                par[0] = new SqlParameter("@UserId", UserId);
                par[1] = new SqlParameter("@Password", Password);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Authenticate", par);

            }
            catch (SqlException ex)
            {
                ds = null;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }
    //SqlParameter[] par = new SqlParameter[12];

    //           par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
    //           par[1] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
    //           par[2] = new SqlParameter("@usrAddress", ur.usrAddress);
    //           par[3] = new SqlParameter("@usrPassword", ur.usrPassword);
    //           par[4] = new SqlParameter("@usrFirstName", ur.usrFirstName);
    //           par[5] = new SqlParameter("@usrLastName", ur.usrLastName);
    //           par[6] = new SqlParameter("@usrGender", ur.usrGender);
    //           par[7] = new SqlParameter("@usrCityId", ur.usrCityId);
    //           par[8] = new SqlParameter("@usrFriendGroup", ur.frnrelGroup);
    //           par[9] = new SqlParameter("@Status", 11);
    //           par[9].Direction = ParameterDirection.Output;

    //           SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUserRegistrationIntialInsert", par);
    //           status = (int)par[9].Value;
}
