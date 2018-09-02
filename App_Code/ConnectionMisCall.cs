using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Configuration;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using okclsms;
using Newtonsoft.Json.Linq;


/// <summary>
/// Summary description for ConnectionMisCall
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ConnectionMisCall : System.Web.Services.WebService
{
    CommonCode cc = new CommonCode();
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    TrueVoterMisCAl TvMiscal = new TrueVoterMisCAl();
    string id = "";
    string mobilenumber = "", mimenumber = "", P1 = "", P2 = "", p3 = "", p4 = "", p5 = "";
    string message_id = "";
    int smslength; int status;
    string todaysDate = "";
    int sendercode = 5;
    string Testting = "";

    public ConnectionMisCall()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    /// <summary>
    /// Misscall function new method in JSON 
    /// </summary>
    /// <param name="jsondata"></param>
    /// <returns></returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string JsonLoadData(string jsondata)
    {
        int result; string returnString = string.Empty;
        try
        {
            List<Miscal> lstmiscal = new JavaScriptSerializer().Deserialize<List<Miscal>>(jsondata);

            foreach (Miscal miscal in lstmiscal)
            {
                if (miscal.deviceid == "356489057554433")  //For meera-Bhahindar Corporation Imei No
                {
                    returnString = TvMiscal.SingleMissCall_SECNEW(miscal.mobilenumber, miscal.deviceid, miscal.simserial, miscal.operatorname, miscal.appno, miscal.date, miscal.custid);
                }
                else if (miscal.deviceid == "353202066628327")
                {
                    returnString = TvMiscal.SingleMissCall_SECNEW(miscal.mobilenumber, miscal.deviceid, miscal.simserial, miscal.operatorname, miscal.appno, miscal.date, miscal.custid);
                }
                else
                {
                    cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@mobilenumber", miscal.mobilenumber);
                    cmd.Parameters.AddWithValue("@mimenumber", miscal.deviceid); //imeino
                    cmd.Parameters.AddWithValue("@P1", miscal.simserial);  //p1
                    cmd.Parameters.AddWithValue("@P2", miscal.operatorname); //p2 
                    cmd.Parameters.AddWithValue("@P3", miscal.appno);    //p3
                    cmd.Parameters.AddWithValue("@P4", miscal.date);     //p4
                    cmd.Parameters.AddWithValue("@P5", miscal.custid);  //p5

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
                    returnString += Maxid.ToString() + "*" + miscal.custid.ToString() + "#";


                    string sqll = "select reg_id from LongCodeRegistration where Sim_no='" + miscal.simserial + "' and IMEINO='" + miscal.deviceid + "'";
                    string regid = cc.ExecuteScalar(sqll);

                    if (regid == "" || regid == null)
                    {
                        sql = "select id from Non_LongCodeRegister where IMEINO='" + miscal.deviceid + "' and SIMNO='" + miscal.simserial + "'";
                        string id1 = cc.ExecuteScalar(sql);
                        if (id1 == "" || id1 == null)
                        {
                            string status = "Deactive";
                            sql = "insert into Non_LongCodeRegister(IMEINO,SIMNO,Miscal_Date,Status,misscallcounter)values('" + miscal.deviceid + "','" + miscal.simserial + "','" + miscal.date + "','" + status + "',0)";
                            int a = cc.ExecuteNonQuery(sql);

                        }
                        string Sqlk = "Select id , misscallcounter from Non_LongCodeRegister where SIMNO='" + miscal.simserial + "' and IMEINO='" + miscal.deviceid + "'";
                        DataSet dds = cc.ExecuteDataset(Sqlk);
                        if (dds.Tables[0].Rows.Count > 0)
                        {
                            int id12 = Convert.ToInt16(dds.Tables[0].Rows[0]["id"]);
                            int Miscalltype = Convert.ToInt16(dds.Tables[0].Rows[0]["misscallcounter"]);
                            if (Miscalltype == 3)
                            { }
                            else
                            {
                                Miscalltype = Miscalltype + 1;
                                string Sqlup = "update Non_LongCodeRegister set misscallcounter=" + Miscalltype + " where SIMNO='" + miscal.simserial + "' and IMEINO='" + miscal.deviceid + "' and id =" + id12 + "";
                                int jk = cc.ExecuteNonQuery(Sqlup);
                                if (jk == 1)
                                {
                                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                    smslength = msg1.Length;
                                    if (miscal.deviceid.ToString() == "354338051597603")
                                    {
                                        //cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    }
                                }
                            }
                        }
                    }
                    ///////////////////////////////////////////////////////////////////////////////
                    else
                    {
                        sql = "select send_data, reg_id,UsrUserid,MissCallType,customer_contact1,customer_contact2,customer_contact3,customer_contact4,[IMEINO] from LongCodeRegistration where Sim_no='" + miscal.simserial + "' and IMEINO='" + miscal.deviceid + "'";
                        DataSet dset = cc.ExecuteDataset(sql);
                        regid = Convert.ToString(dset.Tables[0].Rows[0]["reg_id"]);
                        string userid12 = Convert.ToString(dset.Tables[0].Rows[0]["UsrUserid"]);
                        string Miscalltype = Convert.ToString(dset.Tables[0].Rows[0]["MissCallType"]);
                        string send_data = Convert.ToString(dset.Tables[0].Rows[0]["send_data"]);
                        string Contact1 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact1"]);
                        string Contact2 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact2"]);
                        string Contact3 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact3"]);
                        string Contact4 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact4"]);
                        string imei_no = Convert.ToString(dset.Tables[0].Rows[0]["IMEINO"]);

                        //if (imei_no == "356489057554433")                                                  //
                        //{                                                                                  //
                        //    // if (Miscalltype == "Multiple")
                        //    // {
                        //    // MultipleMissCall(userid12);
                        //    // }
                        //    // else 
                        //    if (Miscalltype == "Single")
                        //    {
                        //        SingleMissCall_SEC(userid12, miscal.mobilenumber, miscal.simserial);
                        //    }
                        //    //-------------Emergency---------------------------
                        //    if (Testting == "AlreadySent")
                        //    {
                        //        //By ram kendre  
                        //        //string OnMiscalNo = string.Empty;
                        //        // OnMiscalNo=miscal.mobilenumber.Substring(miscal.mobilenumber.Length -10);
                        //        // string SQL = "select EpicId,[MobNo],[MobNo_Entered] from [tblPledgeMsg] where MobNo='" + OnMiscalNo + "'";
                        //        //DataSet Ds = cc.ExecuteDataset(SQL);

                        //        //if (Ds.Tables[0].Rows.Count > 0)
                        //        //{
                        //        //    SQL = "select EpicId,[MobNo],[MobNo_Entered] from [tblPledgeMsg] where MobNo_Entered='" + OnMiscalNo + "'";
                        //        //    DataSet DS = cc.ExecuteDataset(SQL);

                        //        //    CommanSendMsgForTrueVoter(DS);
                        //        //}
                        //        //else
                        //        //{
                        //        //    CommanSendMsgForTrueVoter(Ds);
                        //        //}
                        //    }
                        //    else
                        //    {
                        //        if (send_data == "3")
                        //        {
                        //            string AllContact = Contact1 + "," + Contact2 + "," + Contact3 + "," + Contact4;
                        //            string Sql = "Select id, EmergencyMgs from MiscalResponse  where  Msg_Status='Active' and mobileno='" + miscal.simserial + "' ";
                        //            DataSet ds = cc.ExecuteDataset(Sql);
                        //            if (ds.Tables[0].Rows.Count > 0)
                        //            {
                        //                string id = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                        //                string EmergencyMgs = Convert.ToString(ds.Tables[0].Rows[0]["EmergencyMgs"]);
                        //                string SedMgs = mobilenumber + " " + EmergencyMgs;
                        //                smslength = EmergencyMgs.Length;
                        //                string[] sentmgs = AllContact.Split(',');

                        //                if (EmergencyMgs == "" || EmergencyMgs == null)
                        //                { }
                        //                else
                        //                {
                        //                    for (int p = 0; p < sentmgs.Length; p++)
                        //                    {
                        //                        string SentmgsEmg = sentmgs[p].ToString();
                        //                        if (SentmgsEmg == "" || SentmgsEmg == null)
                        //                        { }
                        //                        else
                        //                        {
                        //                            if (mimenumber.ToString() == "354338051597603")
                        //                            {
                        //                                bool chk = cc.TransactionalSMSCountryWari_SEC("Miscal", SentmgsEmg, SedMgs, smslength, sendercode);
                        //                            }
                        //                            else
                        //                            {
                        //                                bool chk = cc.TransactionalSMSCountry_SEC(mobilenumber, SentmgsEmg);
                        //                            }


                        //                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + SentmgsEmg + "','" + miscal.date + "','" + EmergencyMgs + "'," + id + ")";
                        //                            string c = cc.ExecuteScalar(sqlinsert);
                        //                                     }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}                        //
                        //else
                        //{                           }

                        if (Miscalltype == "Multiple")
                        {
                            // MultipleMissCall(userid12);
                        }
                        else if (Miscalltype == "Single")
                        {
                            SingleMissCall(userid12, miscal.mobilenumber, miscal.simserial);
                        }
                        //-------------Emergency---------------------------
                        if (Testting == "AlreadySent")
                        {


                        }
                        else
                        {
                            if (send_data == "3")
                            {
                                string AllContact = Contact1 + "," + Contact2 + "," + Contact3 + "," + Contact4;
                                string Sql = "Select id, EmergencyMgs from MiscalResponse  where  Msg_Status='Active' and mobileno='" + miscal.simserial + "' ";
                                DataSet ds = cc.ExecuteDataset(Sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    string id = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                                    string EmergencyMgs = Convert.ToString(ds.Tables[0].Rows[0]["EmergencyMgs"]);
                                    string SedMgs = mobilenumber + " " + EmergencyMgs;
                                    smslength = EmergencyMgs.Length;
                                    string[] sentmgs = AllContact.Split(',');

                                    if (EmergencyMgs == "" || EmergencyMgs == null)
                                    { }
                                    else
                                    {
                                        for (int p = 0; p < sentmgs.Length; p++)
                                        {
                                            string SentmgsEmg = sentmgs[p].ToString();
                                            if (SentmgsEmg == "" || SentmgsEmg == null)
                                            { }
                                            else
                                            {
                                                if (mimenumber.ToString() == "354338051597603")
                                                {
                                                    bool chk = cc.TransactionalSMSCountryWari("Miscal", SentmgsEmg, SedMgs, smslength, sendercode);
                                                }
                                                else
                                                {
                                                    bool chk = cc.TransactionalSMSCountry("Miscal", mobilenumber, SentmgsEmg, smslength, sendercode);
                                                }


                                                string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + SentmgsEmg + "','" + miscal.date + "','" + EmergencyMgs + "'," + id + ")";
                                                string c = cc.ExecuteScalar(sqlinsert);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // }          //
                }
            }
        }
        catch
        {
            return "108";
        }
        return returnString;
    }

    public void CommanSendMsgForTrueVoter(DataSet dataset)
    {
        WebClient proxy = new WebClient(); string dataString = string.Empty;
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
                        cc.TransactionalSMSCountry("Miscal", mobilenumber, MessageString, smslength, sendercode);
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
                    cc.TransactionalSMSCountry("Miscal", mobilenumber, MessageString, smslength, sendercode);
                }
            }
        }

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<MisCallReg> DownloadMisCalReg(string simno, string imeino)
    {
        List<MisCallReg> miscalList = new List<MisCallReg>();
        MisCallReg miscal = new MisCallReg();
        int result; string sql = string.Empty;
        try
        {
            sql = "select [reg_id],[customer_name],[address],[mobileno],[Sim_no],[reg_date],[IMEINO],[customer_contact],[UsrUserid] from [Come2myCityDB].[come2mycity].[LongCodeRegistration] where [Sim_no]='" + simno + "' and [IMEINO]='" + imeino + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    miscal = new MisCallReg();
                    miscal.regid = ds.Tables[0].Rows[i]["reg_id"].ToString();
                    miscal.customername = ds.Tables[0].Rows[i]["customer_name"].ToString();
                    miscal.address = ds.Tables[0].Rows[i]["address"].ToString();
                    miscal.mobileno = ds.Tables[0].Rows[i]["mobileno"].ToString();
                    miscal.Sim_no = ds.Tables[0].Rows[i]["Sim_no"].ToString();
                    miscal.regdate = ds.Tables[0].Rows[i]["reg_date"].ToString();
                    miscal.imeino = ds.Tables[0].Rows[i]["IMEINO"].ToString();
                    miscal.customercontactno = ds.Tables[0].Rows[i]["customer_contact"].ToString();
                    miscal.UsrUserid = ds.Tables[0].Rows[i]["UsrUserid"].ToString();
                    miscalList.Add(miscal);
                }

            }
            else
            {
                miscal = new MisCallReg();
                miscal.error = "106";
                miscalList.Add(miscal);
            }
        }
        catch
        {
            miscal = new MisCallReg();
            miscal.error = "105";
            miscalList.Add(miscal);
        }
        return miscalList.ToList();
    }

    #region miscal app through Insert and upload message on miscal app registration mobile no  //By ram kendre
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string InsertMsgReport(string jsonMsgReport)
    {
        int result; string returnString = string.Empty; string Serverid = string.Empty;
        try
        {
            List<MsgReport> lsrmsgreport = new JavaScriptSerializer().Deserialize<List<MsgReport>>(jsonMsgReport);

            foreach (MsgReport msgreport in lsrmsgreport)
            {
                string sql2 = "select Sim_no,reg_id from [Come2myCityDB].[come2mycity].LongCodeRegistration where usrUserid='" + msgreport.userid + "'";
                DataSet ds = cc.ExecuteDataset(sql2);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string sim = Convert.ToString(ds.Tables[0].Rows[0]["sim_no"]);
                    string LongCodeid = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);

                    string sql1 = "update [Come2myCityDB].[come2mycity].MiscalResponse set Msg_Status='Deactive' where userid='" + msgreport.userid + "' and mobileno='" + sim + "' and GroupNo='" + msgreport.groupNo + "'";
                    int b = cc.ExecuteNonQuery(sql1);
                    if (b >= 0)
                    {
                        string sql = "insert into [Come2myCityDB].[come2mycity].MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,GroupNo,LongCodeId,MsgCharCount,msgcount)values(N'" + msgreport.userid + "',N'" + sim + "',N'" + msgreport.responseMsg + "',N'" + msgreport.msgDate + "',N'" + msgreport.msg_Status + "',N'" + msgreport.groupNo + "',N'" + msgreport.longCodeId + "',N'" + msgreport.msgCharCount + "',N'" + msgreport.msgcount + "') ";
                        string a = cc.ExecuteScalar(sql);
                    }
                    string SQL = "select max(id) from [Come2myCityDB].[come2mycity].MiscalResponse where userid='" + msgreport.userid + "' and mobileno='" + sim + "' and GroupNo='" + msgreport.groupNo + "'";
                    Serverid = cc.ExecuteScalar(SQL);
                }
                returnString = Serverid + "*" + msgreport.custid + "#";
            }
        }
        catch
        {
            returnString = "105";
        }
        return returnString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateMsgReport(string jsonMsgReport)
    {
        int result; string Serverid = string.Empty;
        try
        {
            List<MsgReport> lsrmsgreport = new JavaScriptSerializer().Deserialize<List<MsgReport>>(jsonMsgReport);

            foreach (MsgReport msgreport in lsrmsgreport)
            {
                string sql1 = "update [Come2myCityDB].[come2mycity].MiscalResponse set [ResponseMsg]=N'" + msgreport.responseMsg + "',[MsgDate]='" + msgreport.msgDate + "',[Msg_Status]='" + msgreport.msg_Status + "',[GroupNo]='" + msgreport.groupNo + "',[MsgCharCount]='" + msgreport.msgCharCount + "',[msgcount]='" + msgreport.msgcount + "' where [id]=" + msgreport.custid + "";
                int b = cc.ExecuteNonQuery(sql1);

                // string SQL = "select id from MiscalResponse where [id]=" + msgreport.custid + "";
                Serverid = msgreport.custid;  //cc.ExecuteScalar(SQL);
            }
        }
        catch
        {
            Serverid = "105";
        }
        return Serverid;
    }
    #endregion

    #region Classes use for Miscal app
    public class MisCallReg
    {
        public string regid { get; set; }
        public string customername { get; set; }
        public string address { get; set; }
        public string mobileno { get; set; }
        public string Sim_no { get; set; }
        public string regdate { get; set; }
        public string imeino { get; set; }
        public string customercontactno { get; set; }
        public string UsrUserid { get; set; }
        public string error { get; set; }

        public string nodata { get; set; }
    }

    public class MsgReport
    {
        public string userid { get; set; }
        public string responseMsg { get; set; }
        public string msgDate { get; set; }
        public string msg_Status { get; set; }
        public string groupNo { get; set; }
        public string msgCharCount { get; set; }
        public string longCodeId { get; set; }
        public string msgcount { get; set; }
        public string simno { get; set; }
        public string imeino { get; set; }
        public string custid { get; set; }
    }

    public class Miscal
    {
        public string mobilenumber { get; set; }
        public string deviceid { get; set; }
        public string simserial { get; set; }
        public string operatorname { get; set; }
        public string appno { get; set; }
        public string date { get; set; }
        public string custid { get; set; }
    }

    public class OkclSms
    {
        public string receiverMoNo { get; set; }
        public string senderMobileNo { get; set; }
        public string smsBody { get; set; }
        public string receivedDate { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string p3 { get; set; }
        public string p4 { get; set; }
        public string p5 { get; set; }
        public string MobileNo { get; set; }
        public string custid { get; set; }
    }
    #endregion

    public string InsertEPIC_MsgReport(string msgString, string senderMobNo)
    {
        TrueVoterMisCAl TvMiscalSms=new TrueVoterMisCAl();
        string returnStr = string.Empty; string sql = string.Empty;
        try
        {
            string Newmsgformat = msgString.Trim(new Char[] { '*', '.', ',', '&', '$', '!', '@' });
            // string TempStr = "Epic xxxxxxx MOBNO 1234567890";
            //string[] ArryTempStr = TempStr.Split(' ');
            string[] msgformat = msgString.Split(' ');
            string StrArry = msgformat[0].ToString();
            string StrArry1 = msgformat[1].ToString();
            string StrArry2 = msgformat[2].ToString();
            string Mobno = msgformat[3].ToString();
            string StrArry4 = msgformat[4].ToString();
            string strNewArry_Epic = StrArry1.Trim(new Char[] { '*', '.', ',', '&', '$', '!', '@' });
            string aadharNo = Newmsgformat.Substring(Newmsgformat.Length - 12);
            //string msgStringNew="Incorrect Format string plz send EPIC xxxxxxxx Mobile xxxxxxxxxx AadharNo xxxxxxxxxx";
            if (msgString.ElementAt(4).Equals(' '))
            {
                if (StrArry1.ToString() == "No" || StrArry1.ToString() == "NO" || StrArry1.ToString() == "nO")
                {
                    if (StrArry4.ToString() == "No" || StrArry4.ToString() == "NO" || StrArry4.ToString() == "nO")
                    {
                        
                       // TvMiscalSms.TransactionalSMSCountry_SECNew(senderMobNo, msgStringNew);
                        returnStr = "Incorrect Format string";
                    }
                    else
                    {
                        if (StrArry == "Epic" || StrArry == "EPic" || StrArry == "EPIc" || StrArry == "EPIC" || StrArry == "epic")
                        {
                            sql = "Insert into [tblPledgeMsg]([EpicId],[MobNo_Entered],[MobNo],[AadharNo])" +    //[AadharNo]
                                   "Values('" + strNewArry_Epic.ToString() + "','" + senderMobNo.ToString() + "','" + Mobno.ToString() + "','"+ aadharNo.ToString() +"')";   //'"+ aadharNo +"'
                            status = cc.ExecuteNonQuery(sql);

                            returnStr = "Success";
                        }
                    }
                }
                else
                {
                    if (StrArry == "Epic" || StrArry == "EPic" || StrArry == "EPIc" || StrArry == "EPIC" || StrArry == "epic")
                    {
                        sql = "Insert into [tblPledgeMsg]([EpicId],[MobNo_Entered],[MobNo],[AadharNo])" +    //[AadharNo]
                               "Values('" + strNewArry_Epic.ToString() + "','" + senderMobNo.ToString() + "','" + Mobno.ToString() + "','" + aadharNo.ToString() + "')"; //'"+ aadharNo +"'
                        status = cc.ExecuteNonQuery(sql);

                        returnStr = "Success";
                    }
                }
            }
            else
            {
                // TvMiscalSms.TransactionalSMSCountry_SECNew(senderMobNo, msgStringNew);
                returnStr = "Incorrect Format string";
            }

            ////string SQL = "select EpicId from [tblPledgeMsg] where EpicId='" + strNewArry_Epic + "'";
            ////string Epic_Id = cc.ExecuteScalar(SQL);

            ////if (Epic_Id != "")
            ////{
            ////    byte[] data = proxy.DownloadData("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/Download_EPICIdWiseData?EpicId='" + strNewArry_Epic.ToString() + "'");
            ////    Stream stream = new MemoryStream(data);

            ////    using (StreamReader reader = new StreamReader(stream))
            ////    {
            ////        dataString = reader.ReadToEnd();
            ////    }
            ////    dataString = dataString.Replace("\"", "'");

            ////    JObject results = JObject.Parse(dataString);
            ////    foreach (var result in results["Download_EPICIdWiseDataResult"])
            ////    {
            ////        string MessageString = "Name '" + result["FM_NAMEEN"] + "' ' ' '" + result["LASTNAMEEN"] + "'. Epic ID '" + result["IDCARD_NO"] + "'. Ward No '" + result["WardNo"] + "'. Booth No '" + result["BoothNumber"] + "'";
            ////        cc.TransactionalSMSCountry_SEC("Miscal", Mobno, MessageString, "1", "17");
            ////    }

            ////}
            ////else
            ////{


            ////}


            return returnStr;
        }
        catch
        {

            //////string SQL = "select EpicId from [tblPledgeMsg] where EpicId='" + strNewArry_Epic + "'";
            //////string Epic_Id = cc.ExecuteScalar(SQL);

            //////if (Epic_Id != "")
            //////{
            //////    byte[] data = proxy.DownloadData("https://truevoters.maharashtra.gov.in/WCFVoterSearchWS.svc/Download_EPICIdWiseData?EpicId='" + strNewArry_Epic.ToString() + "'");
            //////    Stream stream = new MemoryStream(data);

            //////    using (StreamReader reader = new StreamReader(stream))
            //////    {
            //////        dataString = reader.ReadToEnd();
            //////    }
            //////    dataString = dataString.Replace("\"", "'");

            //////    JObject results = JObject.Parse(dataString);
            //////    foreach (var result in results["Download_EPICIdWiseDataResult"])
            //////    {
            //////        //string MessageString = "Name '" + result["FM_NAMEEN"] + "' ' ' '" + result["LASTNAMEEN"] + "'. Epic ID '" + result["IDCARD_NO"] + "'. Ward No '" + result["WardNo"] + "'. Booth No '" + result["BoothNumber"] + "'";
            //////        //cc.TransactionalSMSCountry_SEC("Miscal", senderMobNo, MessageString, "1", "17");
            //////    }

            //////}
            //////else
            //////{
            //////    string sql = "Insert into [tblPledgeMsg]([EpicId],[MobNo_Entered],[MobNo])" +
            //////                  "Values('" + strNewArry_Epic.ToString() + "','" + senderMobNo.ToString() + "','" + senderMobNo.ToString() + "')";
            //////    status = cc.ExecuteNonQuery(sql);
            //////}
            return returnStr = "error";
        }

    }

    #region send text message on miscal app registration mobile no   //By ram kendre
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string JsonsmsData(string jsondata)
    {
        string result; string returnString = string.Empty;
        try
        {
            List<OkclSms> lstokclsms = new JavaScriptSerializer().Deserialize<List<OkclSms>>(jsondata);
            foreach (OkclSms okclsms in lstokclsms)
            {
               // result = InsertEPIC_MsgReport(okclsms.smsBody, okclsms.senderMobileNo);   // For Meera-Bhahindar Corporation 
                result = TvMiscal.InsertEPICNoForNanded(okclsms.smsBody, okclsms.senderMobileNo);
                if (result == string.Empty)
                {
                }
                else
                {
                    string sql = "insert into longCodeasciiSmsReceve(receiverMobileNo,senderMobileNo,receivedSmsBody,receivedDateTime,p1,p2,p3,p4,p5) values('" + okclsms.receiverMoNo + "','" + okclsms.senderMobileNo + "',N'" + okclsms.smsBody.Replace("'", "") + "','" + okclsms.receivedDate + "','" + okclsms.p1 + "','" + okclsms.p2 + "','" + okclsms.p3 + "','" + okclsms.p4 + "','" + okclsms.p5 + "')";
                    int i = cc.ExecuteNonQuery(sql);

                    string sql1 = "select max([id]) from [Come2myCityDB].[dbo].[longCodeasciiSmsReceve]";
                    string Maxid = cc.ExecuteScalar(sql1);
                    returnString += Maxid.ToString() + "*" + okclsms.custid.ToString() + "#";
                }
                if (returnString != string.Empty)
                {
                    TvMiscal.SendingMsgForNandedCorporation(result, okclsms.senderMobileNo);
                }
            }
        }
        catch
        {
            return "108"; //Error
        }
        return returnString;
    }
    #endregion

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string JsonOKCLsmsData(string jsondata)
    {
        int result; string returnString = string.Empty;
        try
        {
            List<OkclSms> lstokclsms = new JavaScriptSerializer().Deserialize<List<OkclSms>>(jsondata);
            foreach (OkclSms okclsms in lstokclsms)
            {
                if (okclsms.smsBody.Contains("39"))
                {
                    okclsms.smsBody = okclsms.smsBody.Replace("39", "34");
                }
                //okclsms.smsBody = Get(okclsms.smsBody);

                string sql = "insert into longCodeasciiSmsReceve(receiverMobileNo,senderMobileNo,receivedSmsBody,receivedDateTime,p1,p2,p3,p4,p5) values('" + okclsms.receiverMoNo + "','" + okclsms.senderMobileNo + "','" + okclsms.smsBody + "','" + okclsms.receivedDate + "','" + okclsms.p1 + "','" + okclsms.p2 + "','" + okclsms.p3 + "','" + okclsms.p4 + "','" + okclsms.p5 + "')";
                int i = cc.ExecuteNonQuery(sql);

                string[] InsertedValue = okclsms.smsBody.Split('*');
                string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                if (InsertedValue[0] == "evidyalaya" || InsertedValue[0] == "EVIDYALAYA" || InsertedValue[0] == "eVidyalaya" || InsertedValue[0] == "Evidyalaya")
                {
                    okclsms.InsertDataToOkcl okcl = new okclsms.InsertDataToOkcl();
                    okcl.InsertDataToOkclTable(okclsms.senderMobileNo.ToString(), InsertedValue[1]);
                }

                string sql1 = "select max([id]) from [Come2myCityDB].[dbo].[longCodeasciiSmsReceve]";
                string Maxid = cc.ExecuteScalar(sql1);
                returnString += Maxid.ToString() + "*" + okclsms.custid.ToString() + "#";
            }
        }
        catch
        {
            return "108";
        }
        return returnString;
    }

    #region GetAscii
    private string Get(string url)
    {

        string text = "";
        List<string> myCollection = new List<string>();
        int a1;
        char character;
        string[] a = url.Split('*');

        for (int i = 0; i < a.Length; i++)
        {
            a1 = Convert.ToInt32(a[i]);
            character = (char)a1;
            text = character.ToString();
            myCollection.Add(text);
        }
        string resulr = String.Join("", myCollection.ToArray());
        return resulr;

    }
    #endregion GetAscii

    [WebMethod]
    public string LoadData(string mobilenumber, string mimenumber, string P1, string P2, string P3, string P4, string P5)
    {
        //string[] stringArray = EString.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;

        cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

        if (mobilenumber != "" && mobilenumber != null)
        {
            //mobilenumber = mobilenumber.Substring(0, 3);
            if (mobilenumber.Contains("911"))
            {

            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@mobilenumber", mobilenumber));
                cmd.Parameters.Add(new SqlParameter("@mimenumber", mimenumber));
                cmd.Parameters.Add(new SqlParameter("@P1", P1));
                cmd.Parameters.Add(new SqlParameter("@P2", P2));
                cmd.Parameters.Add(new SqlParameter("@P3", P3));
                cmd.Parameters.Add(new SqlParameter("@P4", P4));
                cmd.Parameters.Add(new SqlParameter("@P5", P5));

                cmd.CommandText = "uspMYCTInsertConnection";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();

                //if (string.IsNullOrEmpty(nonInsertedValues))
                //{
                //    string sql = CommonCode.OK.ToString();
                //    return sql + nonInsertedValues1;
                //}
                //else
                //    return nonInsertedValues;


                string sql = "select reg_id from LongCodeRegistration where Sim_no='" + P1 + "' and IMEINO='" + mimenumber + "'";
                string regid = cc.ExecuteScalar(sql);
                if (regid == "" || regid == null)
                {
                    sql = "select id from Non_LongCodeRegister where IMEINO='" + mimenumber + "' and SIMNO='" + P1 + "'";
                    string id1 = cc.ExecuteScalar(sql);
                    if (id1 == "" || id1 == null)
                    {
                        string status = "Deactive";
                        sql = "insert into Non_LongCodeRegister(IMEINO,SIMNO,Miscal_Date,Status,misscallcounter)values('" + mimenumber + "','" + P1 + "','" + todaysDate + "','" + status + "',0)";
                        int a = cc.ExecuteNonQuery(sql);

                    }
                    string Sqlk = "Select id , misscallcounter from Non_LongCodeRegister where SIMNO='" + P1 + "' and IMEINO='" + mimenumber + "'";
                    DataSet dds = cc.ExecuteDataset(Sqlk);
                    if (dds.Tables[0].Rows.Count > 0)
                    {
                        int id12 = Convert.ToInt16(dds.Tables[0].Rows[0]["id"]);
                        int Miscalltype = Convert.ToInt16(dds.Tables[0].Rows[0]["misscallcounter"]);
                        if (Miscalltype == 3)
                        { }
                        else
                        {
                            Miscalltype = Miscalltype + 1;
                            string Sqlup = "update Non_LongCodeRegister set misscallcounter=" + Miscalltype + " where SIMNO='" + P1 + "' and IMEINO='" + mimenumber + "' and id =" + id12 + "";
                            int jk = cc.ExecuteNonQuery(Sqlup);
                            if (jk == 1)
                            {
                                string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                smslength = msg1.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    //cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                else
                                {
                                    //cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                            }
                        }
                    }
                }
                ///////////////////////////////////////////////////////////////////////////////
                else
                {
                    sql = "select send_data, reg_id,UsrUserid,MissCallType,customer_contact1,customer_contact2,customer_contact3,customer_contact4 from LongCodeRegistration where Sim_no='" + P1 + "' and IMEINO='" + mimenumber + "'";
                    DataSet dset = cc.ExecuteDataset(sql);
                    regid = Convert.ToString(dset.Tables[0].Rows[0]["reg_id"]);
                    string userid12 = Convert.ToString(dset.Tables[0].Rows[0]["UsrUserid"]);
                    string Miscalltype = Convert.ToString(dset.Tables[0].Rows[0]["MissCallType"]);
                    string send_data = Convert.ToString(dset.Tables[0].Rows[0]["send_data"]);
                    string Contact1 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact1"]);
                    string Contact2 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact2"]);
                    string Contact3 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact3"]);
                    string Contact4 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact4"]);

                    if (Miscalltype == "Multiple")
                    {
                        // MultipleMissCall(userid12);
                    }
                    else if (Miscalltype == "Single")
                    {
                        SingleMissCall(userid12, mobilenumber, P1);
                    }
                    //-------------Emergency---------------------------
                    if (Testting == "AlreadySent")
                    { }
                    else
                    {
                        if (send_data == "3")
                        {
                            string AllContact = Contact1 + "," + Contact2 + "," + Contact3 + "," + Contact4;
                            string Sql = "Select id, EmergencyMgs from MiscalResponse  where  Msg_Status='Active' and mobileno='" + P1 + "' ";
                            DataSet ds = cc.ExecuteDataset(Sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string id = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                                string EmergencyMgs = Convert.ToString(ds.Tables[0].Rows[0]["EmergencyMgs"]);
                                string SedMgs = mobilenumber + " " + EmergencyMgs;
                                smslength = EmergencyMgs.Length;
                                string[] sentmgs = AllContact.Split(',');

                                if (EmergencyMgs == "" || EmergencyMgs == null)
                                { }
                                else
                                {
                                    for (int p = 0; p < sentmgs.Length; p++)
                                    {
                                        string SentmgsEmg = sentmgs[p].ToString();
                                        if (SentmgsEmg == "" || SentmgsEmg == null)
                                        { }
                                        else
                                        {
                                            if (mimenumber.ToString() == "354338051597603")
                                            {
                                                bool chk = cc.TransactionalSMSCountryWari("Miscal", SentmgsEmg, SedMgs, smslength, sendercode);
                                            }
                                            else
                                            {
                                                bool chk = cc.TransactionalSMSCountry("Miscal", SentmgsEmg, SedMgs, smslength, sendercode);
                                            }


                                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + SentmgsEmg + "','" + todaysDate + "','" + EmergencyMgs + "'," + id + ")";
                                            string c = cc.ExecuteScalar(sqlinsert);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString();
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
        //}
        //else
        //{

        //}
    }

    #region SingleMissCallFuncation

    public void SingleMissCall(string userid12, string mobilenumber, string P1)
    {
        DateTime date = DateTime.Now;
        todaysDate = date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
        string mono1 = "";
        if (mobilenumber.Length > 10)
        {
            mono1 = mobilenumber.Substring(2);
        }
        else
        {
            mono1 = mobilenumber;
        }
        string query = "select usrUserid from usermaster where usrMobileNo='" + mono1 + "'";
        string userid1 = cc.ExecuteScalar(query);
        if (userid1 != "" || userid1 != null)
        {
            string query1 = "select groupno from MiscalFriends where friendid='" + userid1 + "' and userid='" + userid12 + "'";
            string groupno = cc.ExecuteScalar(query1);
            if (groupno == "")
            {
                groupno = "0";
                string sqlcheck = "select id from MiscalResponse where mobileno='" + P1 + "'";
                string testid = cc.ExecuteScalar(sqlcheck);
                if (testid == "" || testid == null)
                {
                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                    smslength = msg1.Length;
                    if (mimenumber.ToString() == "354338051597603")
                    {
                        cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    else
                    {
                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                }
                else
                {
                    string sql1 = "select userid,id,ResponseMsg from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "' order by id DESC";
                    DataSet ds = cc.ExecuteDataset(sql1);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                        smslength = msg1.Length;
                        if (mimenumber.ToString() == "354338051597603")
                        {
                            cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                        else
                        {
                            cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                    }
                    else
                    {

                        string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                        string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);
                        string mid = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                        string sql12 = "select id from MiscalResponseCounter where MobileNumber='" + mobilenumber + "'";
                        string checkid = cc.ExecuteScalar(sql12);
                        if (checkid == null || checkid == "")
                        {
                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                            string a = cc.ExecuteScalar(sqlinsert);
                            string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "'";
                            id = cc.ExecuteScalar(sqltop);
                            if (message == "" || message == null)
                            {
                                string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                smslength = msg1.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    //cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                else
                                {
                                    //cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                int mess = 0;
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);

                            }
                            if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                            {

                                string msg = message;
                                smslength = msg.Length;

                                cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                            else
                            {
                                string msg = message;
                                smslength = msg.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                    CheckStatus(mobilenumber);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                        }
                        else
                        {
                            string sqlserach = "select Message_id from MiscalResponseCounter where mobileNumber='" + mobilenumber + "'";
                            DataSet ds1 = cc.ExecuteDataset(sqlserach);
                            foreach (DataRow dr in ds1.Tables[0].Rows)
                            {
                                message_id = Convert.ToString(dr["Message_id"]);
                                if (message_id == mid)
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (message_id != mid)
                            {
                                Testting = "";
                                string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                                string a = cc.ExecuteScalar(sqlinsert);
                                string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "' and Date='" + todaysDate + "'";
                                id = cc.ExecuteScalar(sqltop);
                                if (message == "" || message == null)
                                {
                                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                    smslength = msg1.Length;
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    int mess = 0;
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                                {

                                    string msg = message;
                                    smslength = msg.Length;
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                else
                                {
                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                        CheckStatus(mobilenumber);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                    Testting = "";
                                }
                            }
                            else
                            {
                                Testting = "AlreadySent";
                            }
                        }

                    }

                }
            }
            //else for not commom group 
            else
            {
                string sqlcheck = "select id from MiscalResponse where mobileno='" + P1 + "'";
                string testid = cc.ExecuteScalar(sqlcheck);
                if (testid == "" || testid == null)
                {
                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                    smslength = msg1.Length;
                    if (mimenumber.ToString() == "354338051597603")
                    {
                        //cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    else
                    {
                        //cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                }
                else
                {
                    query = "select id from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                    string mid1 = cc.ExecuteScalar(query);
                    if (mid1 == "" || mid1 == null)
                    {
                        //string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                        string qry = "select ResponseMsg from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo=0";
                        string msg1 = cc.ExecuteScalar(qry);
                        smslength = msg1.Length;
                        if (mimenumber.ToString() == "354338051597603")
                        {
                            ////cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                        else
                        {
                            //cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                        //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                    }
                    else
                    {
                        string sql1 = "select userid,id,ResponseMsg from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                        DataSet ds = cc.ExecuteDataset(sql1);
                        string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                        string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);
                        string mid = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                        string sql12 = "select id from MiscalResponseCounter where MobileNumber='" + mobilenumber + "'";
                        string checkid = cc.ExecuteScalar(sql12);
                        if (checkid == null || checkid == "")
                        {
                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                            string a = cc.ExecuteScalar(sqlinsert);
                            string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "'";
                            id = cc.ExecuteScalar(sqltop);
                            if (message == "" || message == null)
                            {
                                string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                smslength = msg1.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                int mess = 0;
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);

                            }
                            if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                            {

                                string msg = message;
                                smslength = msg.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                    CheckStatus(mobilenumber);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                            else
                            {
                                string msg = message;
                                smslength = msg.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                        }
                        else
                        {
                            string sqlserach = "select Message_id from MiscalResponseCounter where mobileNumber='" + mobilenumber + "'";
                            DataSet ds1 = cc.ExecuteDataset(sqlserach);
                            foreach (DataRow dr in ds1.Tables[0].Rows)
                            {
                                message_id = Convert.ToString(dr["Message_id"]);
                                if (message_id == mid)
                                {

                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (message_id != mid)
                            {
                                Testting = "";
                                string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                                string a = cc.ExecuteScalar(sqlinsert);
                                string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "' and Date='" + todaysDate + "'";
                                id = cc.ExecuteScalar(sqltop);
                                if (message == "" || message == null)
                                {
                                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                    smslength = msg1.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                    int mess = 0;
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                                {

                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                else
                                {
                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                    Testting = "";
                                }
                            }
                            else
                            {
                                Testting = "AlreadySent";
                            }
                        }
                    }
                }
            }
        }//--
    }

    public void SingleMissCall_SEC(string userid12, string mobilenumber, string P1)
    {
        DateTime date = DateTime.Now;
        todaysDate = date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
        string mono1 = "";
        if (mobilenumber.Length > 10)
        {
            mono1 = mobilenumber.Substring(2);
        }
        else
        {
            mono1 = mobilenumber;
        }
        string query = "select usrUserid from usermaster where usrMobileNo='" + mono1 + "'";
        string userid1 = cc.ExecuteScalar(query);

        if (userid1 != "" || userid1 != null)
        {
            string query1 = "select groupno from MiscalFriends where friendid='" + userid1 + "' and userid='" + userid12 + "'";
            string groupno = cc.ExecuteScalar(query1);
            if (groupno == "")
            {
                groupno = "0";
                string sqlcheck = "select id from MiscalResponse where mobileno='" + P1 + "'";
                string testid = cc.ExecuteScalar(sqlcheck);
                if (testid == "" || testid == null)
                {
                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                    smslength = msg1.Length;
                    if (mimenumber.ToString() == "354338051597603")
                    {
                        cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    else
                    {
                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                }
                else
                {
                    string sql1 = "select userid,id,ResponseMsg from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                    DataSet ds = cc.ExecuteDataset(sql1);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                        smslength = msg1.Length;
                        if (mimenumber.ToString() == "354338051597603")
                        {
                            cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                        else
                        {
                            cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                    }
                    else
                    {

                        string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                        string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);
                        string mid = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                        string sql12 = "select id from MiscalResponseCounter where MobileNumber='" + mobilenumber + "'";
                        string checkid = cc.ExecuteScalar(sql12);
                        if (checkid == null || checkid == "")
                        {
                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                            string a = cc.ExecuteScalar(sqlinsert);
                            string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "'";
                            id = cc.ExecuteScalar(sqltop);
                            if (message == "" || message == null)
                            {
                                string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                smslength = msg1.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    //cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                else
                                {
                                    //cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                int mess = 0;
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);

                            }
                            if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                            {

                                string msg = message;
                                smslength = msg.Length;

                                cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                            else
                            {
                                string msg = message;
                                smslength = msg.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                        }
                        else
                        {
                            string sqlserach = "select Message_id from MiscalResponseCounter where mobileNumber='" + mobilenumber + "'";
                            DataSet ds1 = cc.ExecuteDataset(sqlserach);
                            ///////////for at a time one message on miss call //////////////////////
                            //foreach (DataRow dr in ds1.Tables[0].Rows)
                            //{
                            //    message_id = Convert.ToString(dr["Message_id"]);
                            //    if (message_id == mid)
                            //    {
                            //        break;
                            //    }
                            //    else
                            //    {
                            //        continue;
                            //    }
                            //}
                            if (message_id != mid)
                            {
                                Testting = "";
                                string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                                string a = cc.ExecuteScalar(sqlinsert);
                                string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "' and Date='" + todaysDate + "'";
                                id = cc.ExecuteScalar(sqltop);
                                if (message == "" || message == null)
                                {
                                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                    smslength = msg1.Length;
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    int mess = 0;
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                                {

                                    string msg = message;
                                    smslength = msg.Length;
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                else
                                {
                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);

                                        CheckStatus(mobilenumber);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                    Testting = "";
                                }
                            }
                            else
                            {
                                Testting = "AlreadySent";
                            }
                        }

                    }

                }
            }
            //else for not commom group 
            else
            {
                string sqlcheck = "select id from MiscalResponse where mobileno='" + P1 + "'";
                string testid = cc.ExecuteScalar(sqlcheck);
                if (testid == "" || testid == null)
                {
                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                    smslength = msg1.Length;
                    if (mimenumber.ToString() == "354338051597603")
                    {
                        //cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    else
                    {
                        //cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                    }
                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                }
                else
                {
                    query = "select id from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                    string mid1 = cc.ExecuteScalar(query);
                    if (mid1 == "" || mid1 == null)
                    {
                        //string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                        string qry = "select ResponseMsg from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo=0";
                        string msg1 = cc.ExecuteScalar(qry);
                        smslength = msg1.Length;
                        if (mimenumber.ToString() == "354338051597603")
                        {
                            ////cc.TransactionalSMSCountryWari("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                        else
                        {
                            //cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                        }
                        //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                    }
                    else
                    {
                        string sql1 = "select userid,id,ResponseMsg from MiscalResponse where mobileno='" + P1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                        DataSet ds = cc.ExecuteDataset(sql1);
                        string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                        string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);
                        string mid = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                        string sql12 = "select id from MiscalResponseCounter where MobileNumber='" + mobilenumber + "'";
                        string checkid = cc.ExecuteScalar(sql12);
                        if (checkid == null || checkid == "")
                        {
                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                            string a = cc.ExecuteScalar(sqlinsert);
                            string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "'";
                            id = cc.ExecuteScalar(sqltop);
                            if (message == "" || message == null)
                            {
                                string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                smslength = msg1.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                int mess = 0;
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);

                            }
                            if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                            {

                                string msg = message;
                                smslength = msg.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                            else
                            {
                                string msg = message;
                                smslength = msg.Length;
                                if (mimenumber.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                        }
                        else
                        {
                            string sqlserach = "select Message_id from MiscalResponseCounter where mobileNumber='" + mobilenumber + "'";
                            DataSet ds1 = cc.ExecuteDataset(sqlserach);
                            foreach (DataRow dr in ds1.Tables[0].Rows)
                            {
                                message_id = Convert.ToString(dr["Message_id"]);
                                if (message_id == mid)
                                {

                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (message_id != mid)
                            {
                                Testting = "";
                                string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mobilenumber + "','" + todaysDate + "','','')";
                                string a = cc.ExecuteScalar(sqlinsert);
                                string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mobilenumber + "' and Date='" + todaysDate + "'";
                                id = cc.ExecuteScalar(sqltop);
                                if (message == "" || message == null)
                                {
                                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                    smslength = msg1.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg1, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                    int mess = 0;
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                                {

                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                else
                                {
                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mimenumber.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari_SEC("Miscal", mobilenumber, msg, smslength, sendercode);
                                        CheckStatus(mobilenumber);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mobilenumber, msg, smslength, sendercode);
                                        CheckStatus(mobilenumber);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mobilenumber + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                    Testting = "";
                                }
                            }
                            else
                            {
                                Testting = "AlreadySent";
                            }
                        }
                    }
                }
            }
        }//--
    }

    #endregion SingleMissCallFuncation

    public void CheckStatus(string mobilenumber)
    {
        string sql = "update [Come2myCityDB].[come2mycity].[connection1] set Status=1 where [mobileNumber]='" + mobilenumber + "'";
        cc.ExecuteNonQuery(sql);
    }
    //------------------------------------Multiple miss call Funcation--------------------------------------------------

    //#region MultiMissCallFuncation

    //public void MultipleMissCall(string userid12)
    //{
    //    DateTime date = DateTime.Now;
    //    todaysDate = date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
    //    string sqlcheck = "select id from MiscalResponse where mobileno='" + p1 + "'";
    //    string testid = cc.ExecuteScalar(sqlcheck);
    //    if (testid == "" || testid == null)
    //    {
    //        string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
    //        smslength = msg1.Length;
    //        if (mime.ToString() == "354338051597603")
    //        {
    //            cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
    //        }
    //        else
    //        {
    //            cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
    //        }
    //        //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
    //    }
    //    else
    //    {
    //        string mono1 = "";
    //        if (mono.Length > 10)
    //        {
    //            mono1 = mono.Substring(2);
    //        }
    //        else
    //        {
    //            mono1 = mono;
    //        }
    //        string query = "select usrUserid from usermaster where usrMobileNo='" + mono1 + "'";
    //        string userid1 = cc.ExecuteScalar(query);
    //        if (userid1 != "" || userid1 != null)
    //        {
    //            string groupno = "", mid = "";
    //            string query1 = "select id, groupno from MiscalResponse where mobileno='" + p1 + "' and userid='" + userid12 + "' And Msg_Status='Active'";
    //            DataSet ds = cc.ExecuteDataset(query1);
    //            foreach (DataRow dr in ds.Tables[0].Rows)
    //            {
    //                string MgsId = Convert.ToString(dr["id"]);
    //                groupno = Convert.ToString(dr["groupno"]);

    //                query1 = "Select Message_id from MiscalResponseCounter where MobileNumber='" + mono + "' and Message_id='" + MgsId + "'";
    //                mid = Convert.ToString(cc.ExecuteScalar(query1));
    //                if (mid == "")
    //                {
    //                    Testting = "";
    //                    string sql1 = "select userid,ResponseMsg from MiscalResponse where mobileno='" + p1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
    //                    ds = cc.ExecuteDataset(sql1);
    //                    string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
    //                    string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);


    //                    string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mono + "','" + todaysDate + "','','')";
    //                    string a = cc.ExecuteScalar(sqlinsert);
    //                    string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mono + "'";
    //                    id = cc.ExecuteScalar(sqltop);
    //                    if (message == "" || message == null)
    //                    {
    //                        string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
    //                        smslength = msg1.Length;
    //                        if (mime.ToString() == "354338051597603")
    //                        {
    //                            cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
    //                        }
    //                        else
    //                        {
    //                            cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
    //                        }
    //                        //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
    //                        int mess = 0;
    //                        string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
    //                        string b = cc.ExecuteScalar(sqlinst);

    //                    }

    //                    else
    //                    {
    //                        string msg = message;
    //                        smslength = msg.Length;
    //                        if (mime.ToString() == "354338051597603")
    //                        {
    //                            cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
    //                        }
    //                        else
    //                        {
    //                            cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
    //                        }
    //                        //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
    //                        string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + MgsId + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
    //                        string b = cc.ExecuteScalar(sqlinst);
    //                    }
    //                }
    //                else
    //                {
    //                    Testting = "AlreadySent";
    //                }
    //                break;
    //            }
    //        }
    //    }
    //}

    //#endregion MultiMissCallFuncation

    //}
    //------------------------------------Single miss call Funcation----------------------------------------------------



    //------------------------------------Multiple miss call Funcation--------------------------------------------------
}

