﻿using System;
using System.Windows;
using System.Windows.Forms;
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
using System.Linq;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;


//using System.Collections.Generic;

/// <summary>
/// Summary description for CommonCode
/// </summary>
public class CommonCode
{
    string DateFormat = "";
    string dt = "";
    //public const int FAIL=103,Ok=101,ERROR_WHILE_EXECUTION=102,NO_RECORD_FOUND=105;
    public static int OK1 = 1, INVALID_REQUEST = 9, WRONG_INPUT1 = 2, DATA_NOT_FOUND = 3, FAIL1 = 4, SQL_ERROR = 5, ERROR = 6, PRIMARY_KEY_VIOLATION = 7, USER_NAME_ALREADY_USED = 8;
    public const int WRONG_INPUT = 101, NO_RECORD_FOUND = 102, INVALID_USER = 103, ERROR_OCCUR_WHILE_EXECUTION = 104, OK = 105, RECORDS_NOT_INSERTED = 106, DUBLICATE_RECORD = 107, RECORD_ALREADY_AVAILABLE = 2627, FAIL = 108;
    public CommonCode()
    {
        if (dt != "" || dt != null)
        {
            dt = DateFormatStatus();
        }
    }
    public void storeimageinds(string result)
    {
        DataSet ds = new DataSet();
    }
    DataTable dtCategory = new DataTable();
    Location ll = new Location();
    private static byte[] keys = { };
    private static byte[] IVs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    private static string EncryptionKeys = "!5623a#de";
    PaidSmsDataContext psds = new PaidSmsDataContext();

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

    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 12; //add hours in time
        double m = 35; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss''");
        string ds1 = Convert.ToString(DateFormat);
        return ds1;
    }

    //------------------------------------------------School Connection String---------------------------------------------------------------

    #region SchoolDatasetString
    public DataSet SchoolDataset(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]))
        {

            try
            {
                con.Open();
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
    #endregion SchoolDatasetString

    //------------------------------------------------Myct Quary Execution Code--------------------------------------------------------------

    #region MyctQuaryExecutionCode
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
                // throw ex;
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
    #endregion MyctQuaryExecutionCode

    //-------------------------Transactional Pipe Line of SMS Country-------------------------------------------

    #region TransactionalPipeLine

    public bool TransactionalSMSCountry(string sendFrom, string sendTo, string fwdMessage, int smslength, int SenderCode)
    {
        bool flagMsgSuccess = false;
        string senderid = string.Empty;
        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            string NewSento = sendto.Substring(sendto.Length - 10);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            //fwdMessage += "www.myct.in";
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + NewSento + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            // string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&mtype=N&DR=Y";
            //string url = "http://www.smscountry.com/SMSCwebservice.aspx?";
            string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";

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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            //fwdMessage = fwdMessage.Replace("'", "sssss");
            //fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + SenderCode + ",'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    public string API_SMSTransactional(string sendFrom, string sendTo, string fwdMessage, int smslength, int SenderCode)
    {
        string flagMsgSuccess = string.Empty; string sql = string.Empty;
        try
        {
            string html = string.Empty;
            string url = @"https://www.auruminfo.com/Rest/AIwebservice/Bulk?user=aispl2017&password=msb@0309&mobilenumber=9112019919&message=hiiii&sid=AurumI&mtype=n";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            SmsMsgResponse smsmsg = JsonConvert.DeserializeObject<SmsMsgResponse>(html);
            if (smsmsg.message == "Message Submitted Successfully")
            {
                flagMsgSuccess = "1";

                sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','Ok'," + SenderCode + ",'" + smslength + "','" + dt + "')";
            }
            else
            {
                flagMsgSuccess = "Error";

                sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','Error'," + SenderCode + ",'" + smslength + "','" + dt + "')";
            }
            ExecuteNonQuery(sql);
            // html = html.Replace("\"", "'");
            // List<AddItem> listaddItem = new JavaScriptSerializer().Deserialize<List<AddItem>>(data);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return flagMsgSuccess;
    }

    public string API_PostMethod()
    {
        string returnStr = string.Empty;
        try
        {
            PostAPI order = new PostAPI
            {
                user = "aispl2017",
                password = "msb@0309",
                address = "pune",
                companyName = "aitsolution",
                emailId = "ram.kendre@abhinavitsolutions.como",
                firstName = "rk",
                phoneNumber = "9011177789",
                subuserName = "abhinavIt",
                subuserPassword = "abhinavit@123"

                //address = "mumbai",
                //companyName = "xyz",
                //emailId = "sumeet.bande@gmail.com",
                //firstName = "XYZ",
                //phoneNumber = "9999999999",
                //userName = "SumeetNew"
            };

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PostAPI));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, order);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

            // string urlAddress = "https://www.auruminfo.com/Rest/AIwebservice/RegisterUser";    // Main User

            string urlAddress = "https://www.auruminfo.com/Rest/AIwebservice/subuserCreation";   // Sub User 
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                string pagesource = webClient.UploadString(urlAddress, "POST", data.Replace(@"\", string.Empty));

                SmsMsgResponse smsmsg = JsonConvert.DeserializeObject<SmsMsgResponse>(pagesource);
                if (smsmsg.status == "Success")
                {
                    returnStr = "1";
                }
                else
                {
                    returnStr = "Sub User Not Added";
                }
            }
        }
        catch (Exception ex)
        {
            returnStr = "ERROR";
        }
        return returnStr;
    }

    public string APIAddBalance()
    {
        string returnStr = string.Empty;
        try
        {
            AddBalance order = new AddBalance
            {
                user = "aispl2017",
                password = "msb@0309",
                subuserName = "aispl",
                subuserPassword = "MnY3zk",
                addbalance = "1"
            };

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(AddBalance));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, order);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

            // string urlAddress = "https://www.auruminfo.com/Rest/AIwebservice/subuserCreation";   // Sub User 

            string urlAddress = "https://www.auruminfo.com/Rest/AIwebservice/addBalForsubuserCreation";   // Add Balance

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                string pagesource = webClient.UploadString(urlAddress, "POST", data.Replace(@"\", string.Empty));

                SmsMsgResponse smsmsg = JsonConvert.DeserializeObject<SmsMsgResponse>(pagesource);
                if (smsmsg.status == "Success")
                {
                    returnStr = "1";
                }
                else
                {
                    returnStr = "Sub User Not Added";
                }
            }
        }
        catch (Exception ex)
        {
            returnStr = "ERROR";
        }
        return returnStr;
    }


    #endregion TransactionalPipeLine

    #region TransactionalPipeLine

    public bool TransactionalSMSCountryWari(string sendFrom, string sendTo, string fwdMessage, int smslength, int SenderCode)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.aspx?";

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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            //fwdMessage = fwdMessage.Replace("'", "sssss");
            //fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + SenderCode + ",'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    #endregion TransactionalPipeLine

    //-------------------------Promotional Pipe Line of SMS Country---------------------------------------------

    #region PromotionalPipeLine

    public bool PromotionalSMSCountry(string sendFrom, string sendTo, string fwdMessage, int smslength, int SenderCode)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezzesoft";
            string password = "678931";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.aspx?";

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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            //fwdMessage = fwdMessage.Replace("'", "sssss");
            //fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + SenderCode + ",'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    #endregion PromotionalPipeLine

    //-------------------------Transactional SMS To Senderid JSHAPL---------------------------------------------

    #region JSHAPL

    public bool SendMessageTraBulkJSHAPL(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "JSHAPL";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendTo + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
            //string url = "http://182.18.189.124:8800/sendsms.php?";
            string result = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',4,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    #endregion JSHAPL

    #region MSCIOA
    public bool SendMessageTraBulkMSCIOA(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "MSCIOA";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendTo + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
            //string url = "http://182.18.189.124:8800/sendsms.php?";
            string result = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',4,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    #endregion MSCIOA

    //-------------------------Sender Id and Send SMS to Transactional------------------------------------------

    #region SenderIdCodetrasactional

    public bool SendMessageSenderId(string sendFrom, string sendTo, string senderid, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendTo + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
            //string url = "http://182.18.189.124:8800/sendsms.php?";
            string result = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',4,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    #endregion SenderIdCodetrasactional


    //------------------------------- //*********************************Email sending******

    #region mailSendingSMS
    public void mailSendingSMS(string sendFrom, string sendTo, string fwdMessage)
    {
        string fromMo = sendFrom;
        string sndtoMo = sendTo;
        string sndfrmsql = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + fromMo.ToString() + "'";
        DataSet ds = new DataSet();
        ds = ExecuteDataset(sndfrmsql);
        string name = "", email = "", ct = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            name = Convert.ToString(dr["name"]);
            email = Convert.ToString(dr["usrEmailId"]);
            ct = Convert.ToString(dr["usrCity"]);
        }

        string sndfrmsql1 = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + sndtoMo.ToString() + "'";
        DataSet ds1 = new DataSet();
        ds1 = ExecuteDataset(sndfrmsql1);
        string name1 = "", email1 = "", ct1 = "";
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            name1 = Convert.ToString(dr1["name"]);
            email1 = Convert.ToString(dr1["usrEmailId"]);
            ct1 = Convert.ToString(dr1["usrCity"]);
        }
        string mailBody = "";
        fwdMessage = fwdMessage.Replace("sssss", "'");
        fwdMessage = fwdMessage.Replace("aaaaa", "&");
        if (email1.ToString() != "")
        {
            string sub = "";
            if (name != "")
            {
                sub = "SMS from " + name.ToString() + "......www.myct.in";
                mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " City: " + ct.ToString() + " ..... www.myct.in";
            }
            else
            {
                sub = "SMS from COM2MYCT......www.myct.in";
                mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: www.myct.in";
            }
            //string mailBody = "Message: "+fwdMessage .ToString ()+" \n\nFrom: "+name .ToString ()+" City: "+ct .ToString ()+" ..... www.myct.in";
            ll.sendEmail(email1, sub, mailBody);

        }

    }

    public void mailSendingSMS(string sendFrom, string sendTo, string fwdMessage, string KeyWord)
    {
        string fromMo = sendFrom;
        string sndtoMo = sendTo;
        string sndfrmsql = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + fromMo.ToString() + "'";
        DataSet ds = new DataSet();
        ds = ExecuteDataset(sndfrmsql);
        string name = "", email = "", ct = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            name = Convert.ToString(dr["name"]);
            email = Convert.ToString(dr["usrEmailId"]);
            ct = Convert.ToString(dr["usrCity"]);
        }

        string sndfrmsql1 = "select usrFirstName+' '+usrLastName as name,usrEmailId,usrCity from userMaster where usrMobileNo='" + sndtoMo.ToString() + "'";
        DataSet ds1 = new DataSet();
        ds1 = ExecuteDataset(sndfrmsql1);
        string name1 = "", email1 = "", ct1 = "";
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            name1 = Convert.ToString(dr1["name"]);
            email1 = Convert.ToString(dr1["usrEmailId"]);
            ct1 = Convert.ToString(dr1["usrCity"]);
        }
        string mailBody = "";
        fwdMessage = fwdMessage.Replace("sssss", "'");
        fwdMessage = fwdMessage.Replace("aaaaa", "&");
        if (email1.ToString() != "")
        {
            string sub = "";
            if (name != "")
            {
                sub = "SMS from " + name.ToString() + "......www.myct.in";
                if (KeyWord == "CG")
                    mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " City: " + ct.ToString() + "\n\n आदरणीय मुख्यमंत्री महोदय मा कर्मा जयंती उत्सव के उपलक्ष में आप गुंडरदेही पधारे और छत्तीसगड के तथा साहू समाज के आधुनिक मोबाईल डिरेकट्री की शुरवात आपके हातो हुई इसलिये हम सब साहू समाज की ओरसे आपके आभारी है| बहोत बहोत धन्यवाद |  ..... www.myct.in";
                else
                    mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " City: " + ct.ToString() + " ..... www.myct.in";
            }
            else
            {
                sub = "SMS from COM2MYCT......www.myct.in";
                mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: www.myct.in";
            }
            //string mailBody = "Message: "+fwdMessage .ToString ()+" \n\nFrom: "+name .ToString ()+" City: "+ct .ToString ()+" ..... www.myct.in";
            ll.sendEmail(email1, sub, mailBody);

        }

    }

    public void mailSendingSMSAsEmail(string fwdMessage, string Email, string Name)
    {
        try
        {
            string email = Email;
            string name = Name;


            string mailBody = "";

            string sub = "";
            sub = "SMS from " + name.ToString() + "......www.myct.in";
            mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: " + name.ToString() + " ..... www.myct.in";


            mailBody = "Message: " + fwdMessage.ToString() + " \n\nFrom: www.myct.in";

            ll.sendEmail(email, sub, mailBody);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion mailSendingSMS

    //-------------------------SendMessage_School to tarnsaction -----------------------------------------------

    #region SendMessage_School
    public bool SendMessage_School(string sendFrom, string sendTo, string fwdMessage, string SenderName)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            // mailSendingSMS(sendFrom, sendto, fwdMessage);
            //////string userid = "ezeesoft";
            //////string password = "abhinav313";
            string userid = "ezeesoft";
            string password = "67893";
            //string userid = "come2mycity";
            ////string password = "ezeesoft";
            ////string userid = "come2mycity-priority";
            //string password = "1j837BhZ2";
            ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

            //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

            ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
            //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }


            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',7,'" + dt + "')";
            sql = sql + "insert into come2mycity.sendSMSstatus_school(SendFrom,SendTo,sentMessage,Flag,SchoolDB) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "','" + SenderName.ToString() + "')";

            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    #endregion SendMessage_School

    //-------------------------SendMessageLinkUpload to tarnsaction --------------------------------------------

    #region SendMessageLinkUpload
    public bool SendMessageLinkUpload(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;
        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',12,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            if (resultMsg.Contains("EZEESOFT"))
                if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    #endregion SendMessageLinkUpload

    public bool SendMessage1(string sendFrom, string sendTo, string fwdMessage) ////Not in use
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            mailSendingSMS(sendFrom, sendto, fwdMessage);
            //////string userid = "ezeesoft";
            //////string password = "abhinav313";
            string userid = "ezeesoft";
            string password = "67893";
            //string userid = "come2mycity";
            ////string password = "ezeesoft";
            ////string userid = "come2mycity-priority";
            //string password = "1j837BhZ2";
            ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

            //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

            ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
            //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    public bool SendMessagePaidEnglish(string sendFrom, string sendTo, string fwdMessage)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            mailSendingSMS(sendFrom, sendto, fwdMessage);
            string userid = "ezeesoft";
            string password = "67893";
            //string userid = "ezzesoft";
            //string password = "67893";
            //string userid = "come2mycity";
            ////string password = "ezeesoft";
            ////string userid = "come2mycity-priority";
            //string password = "1j837BhZ2";
            ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

            //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

            ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
            //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            psds.InsertPaidSMs(sendFrom.ToString(), sendTo.ToString(), fwdMessage.ToString(), result.ToString());
            //string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
            //int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }



    public DataSet getLoginDetailsUva(string UserId, string Password)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];

                par[0] = new SqlParameter("@UserId", UserId);
                par[1] = new SqlParameter("@Password", Password);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Authenticate1", par);

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

    public bool SendMessageTraBulk(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendTo + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";
            //string url = "http://182.18.189.124:8800/sendsms.php?";
            string result = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            //objRequest.ContentLength = strRequest.Length;
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',4,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageTraBulkPromotional(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendTo + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";
            //string url = "http://182.18.189.124:8800/sendsms.php?";
            string result = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            //objRequest.ContentLength = strRequest.Length;
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);

            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',3,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageTraBulkNCPJLN(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "NCPJLN";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendTo + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
            //string url = "http://182.18.189.124:8800/sendsms.php?";
            string result = "";
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',4,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageTra(string sendFrom, string sendTo, string fwdMessage)///Not in use
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);

            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',18,'" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageQuickSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',1,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageRegistrationSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            sendFrom = "Website";
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',7,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageGroupSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',2,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessagePromotionalSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',3,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageLongCodeSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.aspx?";

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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            //fwdMessage = fwdMessage.Replace("'", "sssss");
            //fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',4,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }


    public bool SendMessageReminderSMS1(string sendFrom, string sendTo, string fwdMessage, int length, string Date, string Time, string Minutes, string currentdate)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string userid = "ezeesoft";
            string password = "67893";
            string senderid = "myctin";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&SenderName=" + senderid + "&schedulerName=Message&ScheduledDateTime=" + Date + " " + Time + ":" + Minutes + ":00&systemcurrenttime=" + currentdate + "&interval=0";
            string url = "http://www.smscountry.com/APISetReminder.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',13,'" + length + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageCustomizedSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',3,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageMiscalSMS(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "myctin";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',5,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageMiscalSMSbyothersenderid(string sendFrom, string sendTo, string fwdMessage, int smslength)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string senderid = "NCPJLN";
            string userid = "ezeesoft";
            string password = "67893";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',5,'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }
    public bool SendMessageMobileLongCodeSMS(string sendFrom, string sendTo, string fwdMessage, int length)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string userid = "ezeesoft";
            string password = "67893";
            string senderid = "myctin";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + senderid + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into [Come2myCityDB].[come2mycity].[sendSMSstatus](SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "',6,'" + length + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    public bool SendMessageTra_school(string sendFrom, string sendTo, string fwdMessage, string SenderName)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            string userid = "ezeesoft";
            string password = "67893";
            ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
            //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "','" + dt + "')";
            sql = sql + "insert into come2mycity.sendSMSstatus_school(SendFrom,SendTo,sentMessage,Flag,SchoolDB) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "','" + SenderName.ToString() + "')";


            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }



    public bool ReceiveReportTra(string sendFrom, string sendTo, string fwdMessage)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            mailSendingSMS(sendFrom, sendto, fwdMessage);

            string userid = "ezeesoft";
            string password = "67893";
            //string userid = "come2mycity";
            ////string password = "ezeesoft";
            ////string userid = "come2mycity-priority";
            //string password = "1j837BhZ2";
            ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

            //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

            ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
            //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    public bool SendMessageTra(string sendFrom, string sendTo, string fwdMessage, string KeyWord)
    {
        bool flagMsgSuccess = false;

        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage, KeyWord);
            //////string userid = "ezeesoft";
            //////string password = "abhinav313";
            string userid = "ezeesoft";
            string password = "67893";
            //string userid = "come2mycity";
            ////string password = "ezeesoft";
            ////string userid = "come2mycity-priority";
            //string password = "1j837BhZ2";
            ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

            //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

            ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
            //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=N&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://www.smscountry.com/SMSCwebservice.asp?";
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            fwdMessage = fwdMessage.Replace("'", "sssss");
            fwdMessage = fwdMessage.Replace("&", "aaaaa");
            string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }


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

    public bool SendMessageMarathi(string sendFrom, string sendTo, string fwdMessage, string originalSms)
    {
        bool flagMsgSuccess = false;


        try
        {

            string sendto = Convert.ToString(sendTo);
            mailSendingSMS(sendFrom, sendto, originalSms);
            string userid = "ezeesoft";
            string password = "67893";
            //string userid = "ezzesoft";
            //string password = "67893";
            //string userid = "come2mycity";
            ////string password = "ezeesoft";
            ////string userid = "come2mycity-priority";
            //string password = "1j837BhZ2";
            ////// string strRequest = "username=" + userid + "&password=" + password + "&sender=" + gsmSenderId + "&to=" + cntNo + "&message=" + msg + "&priority=" + 1 + "&dnd=" + 1 + "&unicode=" + 0;

            //////string strRequest = "userid=" + userid + "&pwd=" + password + "&msgtype=s&ctype=1" + "&sender=" + sendFrom + "&pno=" + sendTo + "&msgtxt=" + fwdMessage + "&alert=1 ";

            ////string strRequest = "username=" + userid + "&password=" + password + "&message=" + fwdMessage + "&sender=" + sendFrom + "&numbers=" + sendTo + "&type=" + 1 + "";
            //"User=xxxx&passwd=xxxx&mobilenumber=919xxxxxxxxx&message=xxxx&sid=xxxx&mtype=N&DR=Y"
            string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&sid=" + sendFrom + "&mtype=OL&DR=Y";
            //////string url = "http://203.122.58.168/prepaidgetbroadcast/PrepaidGetBroadcast?";
            ////string url = "http://smsblaster.info/pushsms.php?";
            string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";
            //string url = "http://182.18.189.124:8800/sendsms.php?";
            string result = "";
            StreamWriter myWriter = null;
            string urlmarathi = url + strRequest;
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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }
            psds.InsertPaidSMs(sendFrom.ToString(), sendTo.ToString(), originalSms.ToString(), result.ToString());
            //string sql = "insert into come2mycity.sendSMSstatus(SendFrom,SendTo,sentMessage,Flag) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "')";
            //int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
            //throw ex;
            flagMsgSuccess = true;
            return flagMsgSuccess;
        }
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
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
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

    public string DTGet_LocalEvent(string Date1)//2013-16-01
    {

        string Date = "";
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('-');

            Date = tmp[2].ToString() + "/" + tmp[1].ToString() + "/" + tmp[0].ToString() + "";
        }
        catch (Exception ex)
        { }
        return Date;

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

    public string ChangeDatenewformat(string dt)//02/14/2013  
    {
        string[] tmpdt = dt.Split('/');
        if (tmpdt[0] == "01")
        {
            tmpdt[0] = "Jan";
        }
        else if (tmpdt[0] == "02")
        {
            tmpdt[0] = "Feb";
        }
        else if (tmpdt[0] == "03")
        {
            tmpdt[0] = "Mar";
        }
        else if (tmpdt[0] == "04")
        {
            tmpdt[0] = "Apr";
        }
        else if (tmpdt[0] == "05")
        {
            tmpdt[0] = "May";
        }
        else if (tmpdt[0] == "06")
        {
            tmpdt[0] = "Jun";
        }
        else if (tmpdt[0] == "07")
        {
            tmpdt[0] = "Jul";
        }
        else if (tmpdt[0] == "08")
        {
            tmpdt[0] = "Aug";
        }
        else if (tmpdt[0] == "09")
        {
            tmpdt[0] = "Sep";
        }
        else if (tmpdt[0] == "10")
        {
            tmpdt[0] = "Oct";
        }
        else if (tmpdt[0] == "11")
        {
            tmpdt[0] = "Nov";
        }
        else if (tmpdt[0] == "12")
        {
            tmpdt[0] = "Dec";
        }
        dt = tmpdt[1] + " " + tmpdt[0] + " " + tmpdt[2];
        return dt;
    }
    public string ChangeDatenewformat1(string dt)//14/02/2013
    {
        string[] tmpdt = dt.Split('/');
        if (tmpdt[1] == "01")
        {
            tmpdt[1] = "Jan";
        }
        else if (tmpdt[1] == "02")
        {
            tmpdt[1] = "Feb";
        }
        else if (tmpdt[1] == "03")
        {
            tmpdt[1] = "Mar";
        }
        else if (tmpdt[1] == "04")
        {
            tmpdt[1] = "Apr";
        }
        else if (tmpdt[1] == "05")
        {
            tmpdt[1] = "May";
        }
        else if (tmpdt[1] == "06")
        {
            tmpdt[1] = "Jun";
        }
        else if (tmpdt[1] == "07")
        {
            tmpdt[1] = "Jul";
        }
        else if (tmpdt[1] == "08")
        {
            tmpdt[1] = "Aug";
        }
        else if (tmpdt[1] == "09")
        {
            tmpdt[1] = "Sep";
        }
        else if (tmpdt[1] == "10")
        {
            tmpdt[1] = "Oct";
        }
        else if (tmpdt[1] == "11")
        {
            tmpdt[1] = "Nov";
        }
        else if (tmpdt[1] == "12")
        {
            tmpdt[1] = "Dec";
        }
        dt = tmpdt[0] + " " + tmpdt[1] + " " + tmpdt[2];
        return dt;
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
    public string ChangeDtnew(string Date1)//07-11-2012//07/11/2012
    {
        string Date = "";
        try
        {
            string[] tmp = Date1.Split(' ');

            Date = tmp[0].ToString();
        }
        catch (Exception ex)
        { }
        return Date;
    }
    public string ChangeDt1(string Date1)//2013-01-18
    //2013-01-19 4:31:53 PM
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

    public string ChangeDt2(string Date1)//2013-1-18
    {
        string Date = "";
        string new1 = "";
        string time = System.DateTime.Now.ToString();
        string[] tm = time.Split(' ');
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('/');
            int count = tmp[0].Length;
            string dd = tmp[0];
            if (dd.StartsWith("0"))
            {
                int length = dd.Length;
                new1 = dd.Substring(1, length - 1);
                // dd = dd.Substring(1,0);
                //  dd.Remove(0, 1);
            }
            string a = dd;

            Date = tmp[2].ToString() + "-" + new1 + "-" + tmp[1].ToString();
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
            str = " www.myct.in";
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
    public string ShowCityName(CityBLL ct)
    {
        string currLocnCity;
        try
        {
            CityBLL cityBLLObj = new CityBLL();
            if (ct.cityId != 0)
            {
                DataTable dtCitySelectForSearch = cityBLLObj.BLLGetSelectedCityForSearch(ct);

                DataRow dRowCity = dtCitySelectForSearch.Rows[0];

                currLocnCity = Convert.ToString(dRowCity["cityName"] + ", Dist.:" + dRowCity["distName"] + "(" + dRowCity["stateName"]) + ")";
            }
            else
            {
                currLocnCity = "Please Select";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return currLocnCity;
    }

    public DataSet LoadMonthYear()
    {
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn("intMonth");
        dt.Columns.Add(dc);
        dc = new DataColumn("strMonth");
        dt.Columns.Add(dc);

        DataRow dr = dt.NewRow();

        dr["intMonth"] = "1";
        dr["strMonth"] = "January";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "2";
        dr["strMonth"] = "February";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "3";
        dr["strMonth"] = "March";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "4";
        dr["strMonth"] = "April";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "5";
        dr["strMonth"] = "May";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "6";
        dr["strMonth"] = "June";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "7";
        dr["strMonth"] = "July";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "8";
        dr["strMonth"] = "August";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "9";
        dr["strMonth"] = "September";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "10";
        dr["strMonth"] = "October";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "11";
        dr["strMonth"] = "November";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "12";
        dr["strMonth"] = "December";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr["intMonth"] = "";
        dr["strMonth"] = "--Select--";
        dt.Rows.Add(dr);


        DataSet ds = new DataSet();
        ds.Tables.Add(dt);


        dt = new DataTable();
        dc = new DataColumn("intYear");
        dt.Columns.Add(dc);
        dc = new DataColumn("strYear");
        dt.Columns.Add(dc);

        int Year = System.DateTime.Now.Year;

        for (int i = Year - 5; i <= Year + 5; i++)
        {
            dr = dt.NewRow();
            dr["intYear"] = i.ToString();
            dr["strYear"] = i.ToString();
            dt.Rows.Add(dr);
        }
        dr = dt.NewRow();
        dr["intYear"] = "";
        dr["strYear"] = "--Select--";
        dt.Rows.Add(dr);
        ds.Tables.Add(dt);
        return ds;
    }
    public int ExecuteNonQueryEzeeTest(string Sql)
    {
        int flag = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ezeeTestConnectionString"].ConnectionString)) //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringEzeeTest"]
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
    public string ExecuteScalarEzeeTest(string Sql)
    {
        string Data = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ezeeTestConnectionString"].ConnectionString))
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
    public DataSet ExecuteDatasetEzeeTest(string Sql)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ezeeTestConnectionString"].ConnectionString))
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


    #region MAHARASHTRA SMS

    //private string aid = "639250";
    //private string pin = "M@h123";

    private WebProxy objProxy1 = null;

    public bool TransactionalSMSCountryWari_SEC(string sendFrom, string sendTo, string fwdMessage, int smslength, int SenderCode)
    {
        bool flagMsgSuccess = false;
        string senderid = string.Empty;
        try
        {
            fwdMessage = fwdMessage.Replace("&", "and");
            string sendto = Convert.ToString(sendTo);
            fwdMessage = fwdMessage.Replace("sssss", "'");
            fwdMessage = fwdMessage.Replace("aaaaa", "&");
            //mailSendingSMS(sendFrom, sendto, fwdMessage);
            senderid = "MAHSEC";
            string userid = "639250";
            string password = "M@h123";
            fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
            // fwdMessage += "www.myct.in";
            string strRequest = "aid=" + userid + "&pin=" + password + "&mnumber=" + sendTo + "&message=" + fwdMessage + "&signature=MAHSEC";
            // string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&mtype=N&DR=Y";
            //string url = "http://www.smscountry.com/SMSCwebservice.aspx?";
            //string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";

            string url = "http://otp.zone:7501/failsafe/HttpLink?";

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
            if (result.ToString() == "As Per Trai Regulations we are unable to Process SMS's between 9 PM to 9 AM.")
            {
                result = "unable to Process SMS between 9 PM to 9 AM.";
            }

            //fwdMessage = fwdMessage.Replace("'", "sssss");
            //fwdMessage = fwdMessage.Replace("&", "aaaaa");
            fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + SenderCode + ",'" + smslength + "','" + dt + "')";
            int d = ExecuteNonQuery(sql);
            string resultMsg = result;
            //if (resultMsg.Contains("EZEESOFT"))
            if (resultMsg.Contains("203179963"))
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
        flagMsgSuccess = true;
        return flagMsgSuccess;
    }

    //public bool TransactionalSMSCountry_SEC(string sendTo, string fwdMessage)
    //{
    //    bool flagMsgSuccess = false;
    //    string senderid = string.Empty;
    //    try
    //    {
    //        fwdMessage = fwdMessage.Replace("&", "and");
    //        string sendto = Convert.ToString(sendTo);
    //        fwdMessage = fwdMessage.Replace("sssss", "'");
    //        fwdMessage = fwdMessage.Replace("aaaaa", "&");
    //        //mailSendingSMS(sendFrom, sendto, fwdMessage);
    //        senderid = "MAHSEC";
    //        string userid = "639250";
    //        string password = "M@h123";
    //        fwdMessage = System.Web.HttpUtility.UrlEncode(fwdMessage);
    //        // fwdMessage += "www.myct.in";
    //        string strRequest = "aid=" + userid + "&pin=" + password + "&mnumber=" + sendTo + "&message=" + fwdMessage + "&signature=MAHSEC";
    //        // string strRequest = "User=" + userid + "&passwd=" + password + "&mobilenumber=" + sendto + "&message=" + fwdMessage + "&mtype=N&DR=Y";
    //        //string url = "http://www.smscountry.com/SMSCwebservice.aspx?";
    //        //string url = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?";

    //        string url = "http://otp.zone:7501/failsafe/HttpLink?";

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



    //        //fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
    //        //string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + SenderCode + ",'" + smslength + "','" + dt + "')";
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

    //public string TransactionalSMSCountryWari_SEC(string Mobile_Number, string Message)
    //{
    //    Mobile_Number = "91" + Mobile_Number;
    //    System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";


    //    HttpWebRequest objWebRequest = null;
    //    HttpWebResponse objWebResponse = null;
    //    StreamWriter objStreamWriter = null;
    //    StreamReader objStreamReader = null;

    //    try
    //    {
    //        string stringResult = null;
    //        //objWebRequest = (HttpWebRequest)WebRequest.Create(" http://otp.zone:7501/failsafe/HttpLink?aid=639128&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MAHSEC");
    //        objWebRequest = (HttpWebRequest)WebRequest.Create("http://otp.zone:7501/failsafe/HttpLink?");

    //        objWebRequest.Method = "POST";

    //        if ((objProxy1 != null))
    //        {
    //            objWebRequest.Proxy = objProxy1;
    //        }
    //        objWebRequest.ContentType = "application/x-www-form-urlencoded";
    //        objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
    //        objStreamWriter.Write(stringpost);
    //        objStreamWriter.Flush();
    //        objStreamWriter.Close();
    //        objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
    //        objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
    //        stringResult = objStreamReader.ReadToEnd();
    //        objStreamReader.Close();
    //        return (stringResult);
    //    }
    //    catch (Exception ex)
    //    {
    //        return (ex.Message);
    //    }
    //    finally
    //    {

    //        if ((objStreamWriter != null))
    //        {
    //            objStreamWriter.Close();
    //        }
    //        if ((objStreamReader != null))
    //        {
    //            objStreamReader.Close();
    //        }
    //        objWebRequest = null;
    //        objWebResponse = null;
    //        objProxy1 = null;
    //    }
    //}


    #endregion



}
