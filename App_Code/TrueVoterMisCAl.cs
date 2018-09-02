using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json.Linq;

/// <summary>
/// Summary description for TrueVoterMisCAl
/// </summary>
public class TrueVoterMisCAl
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    WebClient proxy = new WebClient(); 
    string dataString = string.Empty;  string returnStr = string.Empty;

    public TrueVoterMisCAl()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string SingleMissCall_SECNEW(string mobilenumber, string deviceid, string simserial, string operatorname, string appno, string date, string custid)
    {
        int result; string returnString = string.Empty;

        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@mobilenumber", mobilenumber);
        cmd.Parameters.AddWithValue("@mimenumber", deviceid);
        cmd.Parameters.AddWithValue("@P1", simserial);
        cmd.Parameters.AddWithValue("@P2", operatorname);
        cmd.Parameters.AddWithValue("@P3", appno);
        cmd.Parameters.AddWithValue("@P4", date);
        cmd.Parameters.AddWithValue("@P5", custid);

        cmd.Connection = con;
        cmd.CommandText = "uspMYCTInsertConnection";
        cmd.CommandType = CommandType.StoredProcedure;
        //if (cmd.Connection.State == ConnectionState.Closed)
        //    cmd.Connection.Open();
        con.Open();
        result = cmd.ExecuteNonQuery();
        con.Close();

        string sql = "select max([cid]) from [Come2myCityDB].[come2mycity].[connection1]";
        string Maxid = cc.ExecuteScalar(sql);
        returnString += Maxid.ToString() + "*" + custid.ToString() + "#";


        string sql1 = "select id,ResponseMsg from [Come2myCityDB].[come2mycity].MiscalResponse where mobileno='" + simserial + "' and [Msg_Status]='Active' order by [id] DESC";
        DataSet ds = cc.ExecuteDataset(sql1);

        string sql12 = "select id from [Come2myCityDB].[come2mycity].MiscalResponseCounter where MobileNumber='" + mobilenumber + "' and [Message_id]='" + ds.Tables[0].Rows[0]["id"].ToString() + "'";
        string checkid = cc.ExecuteScalar(sql12);
        if (checkid != "")
        {
            //string OnMiscalNo = string.Empty;
            //OnMiscalNo = mobilenumber.Substring(mobilenumber.Length - 10);
            //string SQL = "select EpicId,[MobNo],[MobNo_Entered] from [tblPledgeMsg] where MobNo='" + OnMiscalNo + "'";
            //DataSet Ds = cc.ExecuteDataset(SQL);

            //if (Ds.Tables[0].Rows.Count > 0)
            //{
            //    SQL = "select EpicId,[MobNo],[MobNo_Entered] from [tblPledgeMsg] where MobNo_Entered='" + OnMiscalNo + "'";
            //    DataSet DS = cc.ExecuteDataset(SQL);

            //    CommanSendMsgForTrueVoter(DS);
            //}
            //else
            //{
            //    CommanSendMsgForTrueVoter(Ds);
            //}
        }
        else
        {
            DateTime date1 = DateTime.Now;
            string todaysDate = date1.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
            TransactionalSMSCountry_SECNew(mobilenumber, ds.Tables[0].Rows[0]["ResponseMsg"].ToString());
            string sqlinsert = "insert into [Come2myCityDB].[come2mycity].MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "',N'" + ds.Tables[0].Rows[0]["ResponseMsg"].ToString() + "','" + ds.Tables[0].Rows[0]["id"].ToString() + "')";
            string a = cc.ExecuteScalar(sqlinsert);
            CheckStatus(mobilenumber);
        }
        return returnString;
    }

    public void CheckStatus(string mobilenumber)
    {
        string sql = "update [Come2myCityDB].[come2mycity].[connection1] set Status=1 where [mobileNumber]='" + mobilenumber + "'";
        cc.ExecuteNonQuery(sql);
    }

    public void CommanSendMsgForTrueVoter(DataSet dataset)
    {

        string Epic_Id = string.Empty; string Mobno = string.Empty; string mobno_entered = string.Empty;

        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        {
            Epic_Id = Convert.ToString(dataset.Tables[0].Rows[i]["EpicId"]);
            Mobno = Convert.ToString(dataset.Tables[0].Rows[i]["MobNo"]);
            mobno_entered = Convert.ToString(dataset.Tables[0].Rows[i]["MobNo_Entered"]);

            if (Mobno != "")
            {
                if (Epic_Id != "")
                {
                    byte[] data = proxy.DownloadData("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadEPICIdWiseData?EpicId=" + Epic_Id.ToString() + "");
                    Stream stream = new MemoryStream(data);

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataString = reader.ReadToEnd();
                    }
                    dataString = dataString.Replace("\"", "'");

                    JObject results = JObject.Parse(dataString);
                    foreach (var result1 in results["DownloadEPICIdWiseDataResult"])
                    {
                        string MessageString = "Name " + result1["FM_NAMEEN"] + " " + result1["LASTNAMEEN"] + ". Epic ID " + result1["IDCARD_NO"] + ". Ward No " + result1["WardNo"] + ". Booth No " + result1["BoothNumber"] + "";
                        TransactionalSMSCountry_SECNew(Mobno, MessageString);
                    }
                }

            }
            else
            {
                byte[] data = proxy.DownloadData("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadEPICIdWiseData?EpicId=" + Epic_Id.ToString() + "");
                Stream stream = new MemoryStream(data);

                using (StreamReader reader = new StreamReader(stream))
                {
                    dataString = reader.ReadToEnd();
                }
                dataString = dataString.Replace("\"", "'");

                JObject results = JObject.Parse(dataString);
                foreach (var result1 in results["DownloadEPICIdWiseDataResult"])
                {
                    string MessageString = "Name " + result1["FM_NAMEEN"] + " " + result1["LASTNAMEEN"] + ". Epic ID " + result1["IDCARD_NO"] + ". Ward No " + result1["WardNo"] + ". Booth No " + result1["BoothNumber"] + ".";
                    TransactionalSMSCountry_SECNew(mobno_entered, MessageString);
                }
            }
        }

    }

    public bool TransactionalSMSCountry_SECNew(string sendTo, string fwdMessage)
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

            //fwdMessage = System.Web.HttpUtility.UrlDecode(fwdMessage);
            //string sql = "insert into sendSMSstatus(SendFrom,SendTo,sentMessage,Flag,sendercode,smslength,EntryDate) values('" + sendFrom.ToString() + "','" + sendTo.ToString() + "','" + fwdMessage.ToString() + "','" + result.ToString() + "'," + SenderCode + ",'" + smslength + "','" + dt + "')";
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


    public string InsertEPICNoForNanded(string msgBody, string mobileNo)
    {
        string epic = string.Empty; string epicId = string.Empty;
        try
        {
            Match m = Regex.Match(msgBody.ToUpper(), @"H.*");
            Match m0 = Regex.Match(msgBody.ToUpper(), @"HL.*");
            Match m1 = Regex.Match(msgBody.ToUpper(), @"AH.*");
            Match m2 = Regex.Match(msgBody.ToUpper(), @"CF.*");
            Match m3 = Regex.Match(msgBody.ToUpper(), @"MT.*");
            Match m4 = Regex.Match(msgBody.ToUpper(), @"TI.*");
            if (m0.Success)
            {
                epic = m0.Value.ToString();
                epicId = epic.Substring(0, 10);
            }
            else if (m1.Success)
            {
                epic = m1.Value.ToString();
                epicId = epic.Substring(0, 10);
            }
            else if (m2.Success)
            {
                epic = m2.Value.ToString();
                epicId = epic.Substring(0, 10);
            }
            else if (m3.Success)
            {
                epic = m3.Value.ToString();
                epicId = epic.Substring(0, 17);
            }
            else if (m4.Success)
            {
                epic = m4.Value.ToString();
                epicId = epic.Substring(0, 10);
            }

            string sql = "Insert into [Come2myCityDB].[come2mycity].[tblPledgeMsg]([EpicId],[MobNo])" +
                                   "Values('" + epicId.ToString() + "','" + mobileNo.ToString() + "')";
            int status = cc.ExecuteNonQuery(sql);

            returnStr = epicId;
        }
        catch (Exception ex)
        {
            throw;
        }
        return returnStr;
    }

    public void SendingMsgForNandedCorporation(string epicNo, string mobileNo)
    {
        try
        {
            byte[] data = proxy.DownloadData("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/DownloadEPICIdWiseData?EpicId=" + epicNo.ToString() + "");
            Stream stream = new MemoryStream(data);

            using (StreamReader reader = new StreamReader(stream))
            {
                dataString = reader.ReadToEnd();
            }
            dataString = dataString.Replace("\"", "'");

            JObject results = JObject.Parse(dataString);
            foreach (var result in results["DownloadEPICIdWiseDataResult"])
            {
                // string MessageString = "Name " + result1["FM_NAMEEN"] + " " + result1["LASTNAMEEN"] + ". Epic ID " + result1["IDCARD_NO"] + ". Ward No " + result1["WardNo"] + ". Booth No " + result1["BoothNumber"] + "";
                string MessageString = "Dear voter " + result["FM_NAMEEN"] + " " + result["LASTNAMEEN"] + " for NWCMC elections 2017 ur ward no: " + result["WardNo"] + " Booth no: " + result["BoothNumber"] + " serial no: " + result["SerialNoInBooth"] + " booth addr: " + result["BoothAddress"] + " " +
                                     " polling day: 11/10/17 frm 7:30 A.M to 5:30 P.M use TRUE VOTER app for candidate details and both locations";
                TransactionalSMSCountry_SECNew(mobileNo, MessageString);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}