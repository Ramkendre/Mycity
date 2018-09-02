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
using System.Text;
using System.Collections.Generic;
using System.Web.Mail;

public partial class html_receiveMobileLongCodeSms : System.Web.UI.Page
{
    KeywordSyntax key = new KeywordSyntax();
    CommonCode cc = new CommonCode();
    DataCollectionBLL objBLLdatacollection = new DataCollectionBLL();
    UserRegistrationBLL urRegistBll = new UserRegistrationBLL();
    Location ll = new Location();
    int status;
    string mmmsg0;
    string mmmsg1;
    string mmmsg2;
    string Pinmsg1 = "";
    string[] arr;
    string[] arr1;
    string shortcode = "";
    string a = "", b = "", c = "", aa = "", bb = "";
    int JoinGr = 0;
    string PinMessage = "", PinMobile = "";
    private string pinMessage;
    string pin = "";
    string[] newpin;
    string newnewpin;
    string prefix = "", infix = "", postfix = "", senderid = "";
    string[] mKeyword;
    string mkeyword1 = "";
    string message1 = "", message = "", mobile = "";
    int iii;
    string userId = "";
    string[] mesgName;
    int GrNameId;
    string GrMembers = "";
    string WholeMsg = "";
    int lenght1;
    string subject = "", NewSmsResp = "", emlBody = "", emlTo = "", backUsrResponse = "", usrMoNo = "", sender = "";
    string receiverMoNo = "", senderMobileNo = "", smsBody = "", receivedDate = "", p1 = "", p2 = "", p3 = "", p4 = "", p5 = "";
    string messageJM = "", myKeyword = "";
    bool check = false;
    string KeywordName = "";
    string keywordfor = "";

    //@in.myct.telisamaj.GetRecordMyct teli = new @in.myct.telisamaj.GetRecordMyct();
    //localhost.GetRecordMyct tel1 = new localhost.GetRecordMyct();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LongCodeRegister();
        }
        catch (Exception ex)
        {
        }

    }

    private void LongCodeRegister()
    {
        try
        {

            receiverMoNo = Convert.ToString(Request.QueryString["receiverMobileNo"]);
            //receiverMoNo = Get(receiverMoNo);
            senderMobileNo = Convert.ToString(Request.QueryString["senderMobileNo"]);
            //senderMobileNo = Get(senderMobileNo);
            smsBody = Convert.ToString(Request.QueryString["receivedSmsBody"]);
            smsBody = Get(smsBody);
            DateTime date = DateTime.Now;
            date = date.AddHours(11);
            date = date.AddMinutes(90);
            receivedDate = date.ToString();
            p1 = Convert.ToString(Request.QueryString["p1"]);
            //p1 = Get(p1);
            p2 = Convert.ToString(Request.QueryString["p2"]);
            //p2 = Get(p2);
            p3 = Convert.ToString(Request.QueryString["p3"]);
            //p3 = Get(p3);
            p4 = Convert.ToString(Request.QueryString["p4"]);
            //p4 = Get(p4);
            p5 = Convert.ToString(Request.QueryString["p5"]);
            //p5 = Get(p5);
            check = IsAllDigits(senderMobileNo);
            if (check == true)
            {
                if (senderMobileNo.Length == 12)
                {
                    if (receiverMoNo != "" && senderMobileNo != "")
                    {
                        //string[] InsertedValue = new string[] { "EZEETEST","899052100092288", "911990022699992323","Santosh","Gurude","Abhinav","9421364622","Ezee","pqr@gmail.com","P1","410503","p2","0.0","0.5","27","613","25","p3","p4","898","SMS","1" };
                        string sql = "insert into longCodeSmsReceve(receiverMobileNo,senderMobileNo,receivedSmsBody,receivedDateTime,p1,p2,p3,p4,p5) values('" + receiverMoNo + "','" + senderMobileNo + "','" + smsBody + "','" + receivedDate + "','" + p1 + "','" + p2 + "','" + p3 + "','" + p4 + "','" + p5 + "')";
                        int i = cc.ExecuteNonQuery(sql);

                    }
                    WholeMsg = smsBody;

                    string[] StrSep = smsBody.Split('*');
                    for (iii = 0; iii < 1; iii++)
                    {
                        message = StrSep[iii].ToString();
                        if (StrSep.Length > 1)
                            messageJM = StrSep[iii + 1].ToString();

                        mKeyword = message.Split(' ');
                        if (mKeyword[0].ToString() != "")
                        {
                            mkeyword1 = mKeyword[0].ToUpper();
                        }
                        else
                        {
                            mkeyword1 = mKeyword[1].ToUpper();
                        }
                    }
                    if (senderMobileNo.Length > 10)
                        senderMobileNo = senderMobileNo.Substring(2);//to remove 91 from mobile
                    urRegistBll.usrMobileNo = senderMobileNo;
                    PinMobile = senderMobileNo;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {

                        NormalKeyword();
                    }
                    else
                    {
                        UserRegister();
                    }

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    bool IsAllDigits(string s)
    {
        foreach (char c in s)
        {
            if (!Char.IsDigit(c))
                return false;
        }
        return true;
    }
    public void NormalKeyword()
    {
        try
        {
            string KeywordName = "";
            status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
            if (status == 0)
            {


                for (int i = 1; i < mKeyword.Length; i++)
                {
                    if (mKeyword[i].ToString() == "")
                    {
                        if (mKeyword[i].ToString() == "")
                        {
                        }
                        else
                        {
                            message1 += mKeyword[i].ToString() + " ";
                        }

                    }
                    else
                    {
                        message1 += mKeyword[i].ToString() + " ";
                    }
                }
                mkeyword1 = mkeyword1.ToUpper();
                string sqlfetch = "select * from PersonalLongCodekeywords where IMEINO='" + p2 + "' and simno='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sqlfetch);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    KeywordName = Convert.ToString(dr["KeywordName"]);
                    if (mkeyword1 == KeywordName)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                //////////////////Start Keywords/////////////////////////////////////////////////
                if (mkeyword1 == KeywordName)
                {
                    string sql = "select keywordfor from PersonalLongCodekeywords where IMEINO='" + p2 + "' and simno='" + p1 + "' and KeywordName='" + KeywordName + "' ";
                    keywordfor = cc.ExecuteScalar(sql);
                    if (keywordfor == "1")
                    {
                        Personalkeyword();
                    }
                    //else if (keywordfor == "2")
                    //{
                    //    Registrationkeyword();
                    //}
                    else if (keywordfor == "3")
                    {
                        Datakeyword();
                    }

                }
                else
                {
                    Reservedkeyword();


                }





            }

        }
        catch (Exception ex)
        {
        }
    }

    private void Reservedkeyword()
    {
        if (WholeMsg.Contains("*"))
        {

            int smslength;
            if ((mkeyword1 == "set-group0-missed-call-sms-to" || mkeyword1 == "Set-group0-missed-call-sms-to" || mkeyword1 == "SET-GROUP0-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=0";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=0";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + receivedDate + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',0)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group1-missed-call-sms-to" || mkeyword1 == "set-group1-missed-call-sms-to" || mkeyword1 == "SET-GROUP1-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }
                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=1";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=1";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + receivedDate + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',1)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group2-missed-call-sms-to" || mkeyword1 == "Set-group2-missed-call-sms-to" || mkeyword1 == "SET-GROUP2-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=2";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=2";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',2)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group3-missed-call-sms-to" || mkeyword1 == "Set-group3-missed-call-sms-to" || mkeyword1 == "SET-GROUP3-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=3";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=3";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',3)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group4-missed-call-sms-to" || mkeyword1 == "set-group4-missed-call-sms-to" || mkeyword1 == "SET-GROUP4-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=4";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=4";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',4)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group5-missed-call-sms-to" || mkeyword1 == "Set-group5-missed-call-sms-to" || mkeyword1 == "SET-GROUP5-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=5";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=5";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',5)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group6-missed-call-sms-to" || mkeyword1 == "Set-group6-missed-call-sms-to" || mkeyword1 == "SET-GROUP6-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=6";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=6";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',6)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group7-missed-call-sms-to" || mkeyword1 == "set-group7-missed-call-sms-to" || mkeyword1 == "SET-GROUP7-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=7";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=7";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',7)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group8-missed-call-sms-to" || mkeyword1 == "Set-group8-missed-call-sms-to" || mkeyword1 == "SET-GROUP8-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=8";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=8";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',8)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if ((mkeyword1 == "set-group9-missed-call-sms-to" || mkeyword1 == "Set-group9-missed-call-sms-to" || mkeyword1 == "SET-GROUP9-MISSED-CALL-SMS-TO"))
            {
                String date = System.DateTime.Now.ToString();
                int count = 0;
                string[] msg = WholeMsg.Split('*');
                KeywordName = msg[0];
                KeywordName = KeywordName.ToUpper();
                string sql12 = "select mobileno,reg_id from LongCodeRegistration where IMEINO='" + p2 + "' and Sim_no='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sql12);
                string id = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
                string contactno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                if (contactno == senderMobileNo)
                {
                    string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                    string userid = cc.ExecuteScalar(query);
                    string newmsg = "Shri/Smt " + msg[1] + " Thanks via www.myct.in";
                    int messagecount = newmsg.Length;
                    if (messagecount <= 160)
                    {
                        count = 1;
                    }
                    else if (messagecount >= 160)
                    {
                        count = 2;
                    }
                    else if (messagecount >= 320)
                    {
                        count = 3;
                    }
                    else if (messagecount >= 480)
                    {
                        count = 4;
                    }
                    else
                    {

                    }

                    query = "select * from MiscalResponse where userid='" + userid + "' and LongCodeId='" + id + "' and GroupNo=9";
                    DataSet ds1 = cc.ExecuteDataset(query);

                    string simno = Convert.ToString(ds1.Tables[0].Rows[0]["mobileno"]);
                    string MsgStatus = "Active";
                    string sqlupdate = "update MiscalResponse set Msg_Status='Deactive' where LongCodeId='" + id + "' and GroupNo=9";
                    int a = cc.ExecuteScalar1(sqlupdate);
                    query = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,MsgCharCount,LongCodeId,msgcount,GroupNo)" +
                        " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',9)";
                    int exe = cc.ExecuteNonQuery(query);
                    string message = "Shri/Smt Message Updated Successfully Thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }


            }
            else if (checkGroupSMSCode(mkeyword1) == 1)
            {

                urRegistBll.usrMobileNo = senderMobileNo;
                string[] smsLongCode = message1.Split(' ');
                if (smsLongCode[0].ToString() == mkeyword1.ToString())
                {
                    urRegistBll.longCodegrSMS = message1.ToString();
                }
                else
                {
                    urRegistBll.longCodegrSMS = mkeyword1 + " " + message1.ToString();
                }

                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {

                   // SendMessagetoAllLongCode(urRegistBll);

                }


            }
            else if ((mkeyword1 == "DATA1" || mkeyword1 == "DATA2" || mkeyword1 == "DATA3" || mkeyword1 == "DATA4" || mkeyword1 == "DATA5" || mkeyword1 == "DATA6" || mkeyword1 == "DATA7" || mkeyword1 == "DATA8" || mkeyword1 == "DATA9" || mkeyword1 == "DATA10"))
            {
                Datakeyword();
            }
            else if ((mkeyword1 == "Getrecord" || mkeyword1 == "getrecord" || mkeyword1 == "GETRECORD" || mkeyword1 == "GetRecord"))
            {


                string sql = "select roleid from AdminSubMarketingSubUser inner join UserMaster on friendid=usrUserId where usrMobileNo='" + senderMobileNo + "'";
                string roleid = cc.ExecuteScalar(sql);
                if (roleid == "2" || roleid == "42")
                {
                    GetRecord();
                }
            }
            else if (mkeyword1 == "CMNO" || mkeyword1 == "Cmno" || mkeyword1 == "C.M.N." || mkeyword1 == "cmno" || mkeyword1 == "CMN" || mkeyword1 == "Cmn" || mkeyword1 == "cmn")
            {
                if (message1.Length >= 10)
                {
                    urRegistBll.usrAltMobileNo = mobile;
                    urRegistBll.usrMobileNo = message1;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLIsExistUserRegistrationInitialByLc(urRegistBll);
                    if (status == 0)
                    {
                        changeMobileNoByLongCode(urRegistBll);

                    }
                }

            }
            else if ((mkeyword1 == "HEAD" || mkeyword1 == "SON" || mkeyword1 == "WIFE" || mkeyword1 == "DAUGHTER" || mkeyword1 == "FRIEND" || mkeyword1 == "FAMILY"))
            {
                telisamaj();

            }

            else if (mkeyword1 == "CHANELSMS")
            {
                string[] wholemsgsplit = WholeMsg.Split('*');
                string message = wholemsgsplit[1];
                string sql = "select friendid  from AdminSubMarketingSubUser right outer join UserMaster " +
                        " on UserMaster.usrUserId = AdminSubMarketingSubUser.userid " +
                        " where usrMobileNo='" + senderMobileNo + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string user = Convert.ToString(dr["friendid"]);
                    sql = "select usrMobileNo from usermaster where usrUserid='" + user + "'";
                    string mob = cc.ExecuteScalar(sql);
                    string smstoAll = "" + message + " www.myct.in";
                    smslength = smstoAll.Length;
                    cc.SendMessageMobileLongCodeSMS("LongCode", mob, smstoAll, smslength);

                }


            }
            else if (mkeyword1 == "Chainsms")
            {
                string[] wholemsgsplit = WholeMsg.Split('*');
                string message = wholemsgsplit[1];



            }
            else if (mkeyword1 == "REPORT")
            {
                string[] wholemsgsplit = WholeMsg.Split('*');
                string message = wholemsgsplit[1].ToString();
                string date = receivedDate;
                string sql = "insert into dailyreport(Report,DateTime,MobileNo)values('" + message + "','" + date + "','" + senderMobileNo + "')";
                string a = cc.ExecuteScalar(sql);
                message = "Your Daily Report got updated successfully Thanks via www.myct.in";
                smslength = message.Length;
                cc.SendMessageMobileLongCodeSMS("LongCode", senderMobileNo, message, smslength);
            }

            else if ((mkeyword1 == "LEADER" || mkeyword1 == "JUNIOR" || mkeyword1 == "WORKER"))
            {
                string fname = "", mname = "", lname = "", pincode = "", emailid = "", mobileno = "";
                string[] namesplit;
                string name = "", address = "";
                string[] arrplit = WholeMsg.Split('*');
                mobileno = arrplit[1].ToString();
                urRegistBll.usrMobileNo = senderMobileNo;
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {
                    string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                    userId = cc.ExecuteScalar(sqluser);
                    AddJuniors(userId, mobileno);
                }
                else
                {
                    if (arrplit.Length > 5)
                    {
                        mobileno = arrplit[1].ToString();
                        name = arrplit[2].ToString();
                        namesplit = name.Split(' ');
                        if (namesplit.Length > 2)
                        {
                            fname = namesplit[0];
                            mname = namesplit[1];
                            lname = namesplit[2];


                        }
                        else if (namesplit.Length > 1)
                        {
                            fname = namesplit[0];
                            lname = namesplit[1];
                        }
                        else
                        {
                        }
                        address = arrplit[3];
                        pincode = arrplit[4];
                        emailid = arrplit[5];
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        urRegistBll.usrMobileNo = senderMobileNo;
                        urRegistBll.usrPIN = pincode;
                        urRegistBll.usrFirstName = fname;
                        urRegistBll.usrLastName = lname;
                        urRegistBll.usrAddress = address;
                        urRegistBll.usrEmailId = emailid;
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myMobileNo = urRegistBll.usrMobileNo;
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string myName = urRegistBll.usrFirstName;
                            string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                            smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("MobileLongCode", senderMobileNo, passwordMessage, smslength);
                        }
                        string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                        userId = cc.ExecuteScalar(sqluser);
                        AddJuniors(userId,mobileno);


                    }
                    else if (arrplit.Length > 4)
                    {
                        mobileno = arrplit[1].ToString();
                        name = arrplit[2].ToString();
                        namesplit = name.Split(' ');
                        if (namesplit.Length > 2)
                        {
                            fname = namesplit[0];
                            mname = namesplit[1];
                            lname = namesplit[2];


                        }
                        else if (namesplit.Length > 1)
                        {
                            fname = namesplit[0];
                            lname = namesplit[1];
                        }
                        else
                        {
                        }
                        address = arrplit[3];
                        pincode = arrplit[4];
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        urRegistBll.usrMobileNo = senderMobileNo;
                        urRegistBll.usrPIN = pincode;
                        urRegistBll.usrFirstName = fname;
                        urRegistBll.usrLastName = lname;
                        urRegistBll.usrAddress = address;
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myMobileNo = urRegistBll.usrMobileNo;
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string myName = urRegistBll.usrFirstName;
                            string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                            smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                        }
                        string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                        userId = cc.ExecuteScalar(sqluser);
                        AddJuniors(userId,mobileno);
                    }
                    else if (arrplit.Length > 3)
                    {
                        mobileno = arrplit[1].ToString();
                        name = arrplit[2].ToString();
                        namesplit = name.Split(' ');
                        if (namesplit.Length > 2)
                        {
                            fname = namesplit[0];
                            mname = namesplit[1];
                            lname = namesplit[2];


                        }
                        else if (namesplit.Length > 1)
                        {
                            fname = namesplit[0];
                            lname = namesplit[1];
                        }
                        else
                        {
                        }
                        address = arrplit[3];
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        urRegistBll.usrMobileNo = senderMobileNo;
                        urRegistBll.usrPIN = pincode;
                        urRegistBll.usrAddress = address;
                        urRegistBll.usrFirstName = fname;
                        urRegistBll.usrLastName = lname;
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myMobileNo = urRegistBll.usrMobileNo;
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string myName = urRegistBll.usrFirstName;
                            string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                            smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                        }
                        string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                        userId = cc.ExecuteScalar(sqluser);
                        AddJuniors(userId,mobileno);
                        
                    }
                    else if (arrplit.Length > 2)
                    {
                        mobileno = arrplit[1].ToString();
                        name = arrplit[2].ToString();
                        namesplit = name.Split(' ');
                        if (namesplit.Length > 2)
                        {
                            fname = namesplit[0];
                            mname = namesplit[1];
                            lname = namesplit[2];


                        }
                        else if (namesplit.Length > 1)
                        {
                            fname = namesplit[0];
                            lname = namesplit[1];
                        }
                        else
                        {
                        }
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        urRegistBll.usrMobileNo = senderMobileNo;
                        urRegistBll.usrPIN = pincode;
                        urRegistBll.usrFirstName = fname;
                        urRegistBll.usrLastName = lname;
                        urRegistBll.usrAddress = address;
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myMobileNo = urRegistBll.usrMobileNo;
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string myName = urRegistBll.usrFirstName;
                            string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                            smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                        }
                        string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                        userId = cc.ExecuteScalar(sqluser);
                        AddJuniors(userId,mobileno);
                       
                    }
                    else if (arrplit.Length > 1)
                    {
                        mobileno = arrplit[1].ToString();
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        urRegistBll.usrMobileNo = mobileno;
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myMobileNo = urRegistBll.usrMobileNo;
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string myName = urRegistBll.usrFirstName;
                            string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                            smslength = passwordMessage.Length;
                            cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                        }
                        string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                        userId = cc.ExecuteScalar(sqluser);
                        AddJuniors(userId,mobileno);
                        
                    }

                }


            }
        }
        else
        {
            key.SendKeywordSyntax(mkeyword1, senderMobileNo);
            
        }
    }

    public void SendMessagetoAllLongCode(UserRegistrationBLL ur)
    
    {
        try
          {
            DateTime date = DateTime.Now;
            string todaysDate = date.ToShortDateString();
            int smsBal = 0, smsLength = 0, totalSms = 0, smsCharge = 0, firstnamelen = 0, lastnamelen = 0;
            string sysdate = "";
            string FirstName = "";
            string LastName = "";
            string LCsms = ur.longCodegrSMS;
            string[] smsArr = LCsms.Split(' ');
            string ActualSMS = "";
            int smsCode = Convert.ToInt32(smsArr[0]);
            for (int i = 1; i < smsArr.Length - 1; i++)
            {
                ActualSMS += smsArr[i].ToString() + " ";
            }
            string sql = "select usrFirstName,usrLastName,smsbal,usrUserid from usermaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet dset = cc.ExecuteDataset(sql);
            smsBal = Convert.ToInt32(dset.Tables[0].Rows[0]["smsbal"]);
            FirstName = Convert.ToString(dset.Tables[0].Rows[0]["usrFirstName"]);
            LastName = Convert.ToString(dset.Tables[0].Rows[0]["usrLastName"]);
            userId = Convert.ToString(dset.Tables[0].Rows[0]["usrUserid"]);
            GrNameId = Convert.ToInt32(smsCode);
            grpsmsbylongcode();
            string mobileforsms = cc.ExecuteScalar(GrMembers);
            if (mobileforsms.Length > 1)
            {
                mobileforsms = mobileforsms.Substring(1);
            }
            string[] arrcount = mobileforsms.Split(',');
            totalSms = arrcount.Length;
            string sender = ur.usrMobileNo;
            string sms = ActualSMS.ToString();
            smsLength = sms.Length;
            firstnamelen = FirstName.Length;
            lastnamelen = LastName.Length;
            smsLength = 44 + smsLength;
            if (smsLength <= 120)
            {
                smsCharge = 1 * totalSms;
            }
            else if (smsLength <= 240)
            {
                smsCharge = 2 * totalSms;
            }
            else if (smsLength <= 360)
            {
                smsCharge = 3 * totalSms;
            }
            else
            {
                smsCharge = 4 * totalSms;
            }
            int smsBalance = smsBal - smsCharge - 1;
            string sqlinsert = "insert into SMSBalanceReport(userid,MobileNo,Message,No_smssent,SMSLength,smscount,Pre_SMSbal,New_SMSbal,SendDate)" +
                 "values('" + userId + "','" + senderMobileNo + "','" + WholeMsg + "','" + totalSms.ToString() + "','" + smsLength + "','" + smsCharge + "','" + smsBal + "','" + smsBalance + "','" + todaysDate + "')";
            string b = cc.ExecuteScalar(sqlinsert);
            string ResponceMsg = "Dear " + FirstName + " Total " + totalSms.ToString() + " messages sent to " + smsCode.ToString() + " group members thanks.via www.myct.in";
            int len = ResponceMsg.Length;
            cc.SendMessageLongCodeSMS("LongCode", ur.usrMobileNo, ResponceMsg, len);
            if ((smsCharge <= smsBal))
            {
                sms = "" + sms + "From(" + ur.usrMobileNo + ")thanks via.www.myct.in";
                if (userId == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                {
                    cc.SendMessageTraBulkNCPJLN(senderMobileNo, mobileforsms, sms, smsLength);
                }
                else
                {
                    cc.SendMessageTraBulk(senderMobileNo, mobileforsms, sms, smsLength);
                }
                string sqlBalUpdate1 = "update userMaster set SMSbal=" + smsBalance.ToString() + " where usrMobileNo='" + ur.usrMobileNo + "'";
                int i1 = cc.ExecuteNonQuery(sqlBalUpdate1);

                string qq = "update test set no_sentmessage='" + totalSms + "', FlagStatus = 0 where PK='" + urRegistBll.usrPKval + "'";
                int a = cc.ExecuteNonQuery(qq);


            }
            else
            {
                string smsResponse = "Dear " + FirstName + ", You dont have sufficient balance " + cc.AddSMS(sender);
                int len1 = smsResponse.Length;
                cc.SendMessageLongCodeSMS("LongCode", sender, smsResponse, len1);
            }
        }
        catch (Exception ex)
        { }
    }

    public void grpsmsbylongcode()
    {
        UserRegistrationBLL ur = new UserRegistrationBLL();
        try
        {
            //string userid = Convert.ToString(Session["User"]);
            string sql = "select usrUserid from usermaster where usrMobileno='" + senderMobileNo + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            string userid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);



            if (GrNameId == 1)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and FR1=1";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR1=1";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR1=1) select @mobile ";
            }
            else if (GrNameId == 2)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and FR2=2";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR2=2";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR2=2) select @mobile ";

            }
            else if (GrNameId == 3)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR3=3";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR3=3";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR3=3) select @mobile ";
            }
            else if (GrNameId == 4)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR4=4";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR4=4";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR4=4) select @mobile ";
            }
            else if (GrNameId == 5)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR5=5";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR5=5";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR5=5) select @mobile ";
            }
            else if (GrNameId == 6)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR6=6";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR6=6";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR6=6) select @mobile ";
            }
            else if (GrNameId == 7)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR7=7";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR7=7";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR7=7) select @mobile ";
            }
            else if (GrNameId == 8)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR8=8";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR8=8";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR8=8) select @mobile ";
            }
            else if (GrNameId == 9)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR9=9";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR9=9";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR9=9) select @mobile ";
            }
            else if (GrNameId == 10)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR10=10";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR10=10";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR10=10) select @mobile ";
            }
            else if (GrNameId == 11)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR11=11";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR11=11";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR11=11) select @mobile ";
            }
            else if (GrNameId == 12)
            {
                // GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR12=12";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR12=12";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR12=12) select @mobile ";
            }
            else if (GrNameId == 13)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR13=13";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR13=13";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR13=13) select @mobile ";
            }
            else if (GrNameId == 14)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR14=14";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR14=14";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR14=14) select @mobile ";
            }
            else if (GrNameId == 15)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR15=15";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR15=15";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR15=15) select @mobile ";
            }
            else if (GrNameId == 16)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR16=16";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR16=16";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR16=16) select @mobile ";
            }
            else if (GrNameId == 17)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR17=17";
                //GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR17=17";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR17=17) select @mobile ";
            }
            else if (GrNameId == 18)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR18=18";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR18=18";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR18=18) select @mobile ";
            }
            else if (GrNameId == 19)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR19=19";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR19=19";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR19=19) select @mobile ";
            }
            else if (GrNameId == 20)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR20=20";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR20=20";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR20=20) select @mobile ";
            }
            else if (GrNameId == 21)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR21=21";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR21=21";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR21=21) select @mobile ";
            }
            else if (GrNameId == 22)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR22=22";
                //  GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR22=22";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR22=22) select @mobile ";
            }
            else if (GrNameId == 23)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR23=23";
                //  GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR23=23";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR23=23) select @mobile ";
            }
            else if (GrNameId == 24)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR24=24";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR24=24";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR24=24) select @mobile ";
            }
            else if (GrNameId == 25)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR25=25";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR25=25";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR25=25) select @mobile ";
            }
            else if (GrNameId == 26)
            {
                // GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR26=26";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR26=26";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR26=26) select @mobile ";

            }
            else if (GrNameId == 27)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR27=27";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR27=27";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR27=27) select @mobile ";
            }
            else if (GrNameId == 28)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR28=28";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR28=28";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR28=28) select @mobile ";
            }
            else if (GrNameId == 29)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR29=29";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR29=29";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR29=29) select @mobile ";
            }
            else if (GrNameId == 30)
            {
                //GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR30=30";
                // GrMembers = "select UserMaster.usrMobileNo from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId =FriendRelationMaster.FriendId where FriendRelationMaster.UserId='" + userid + "' and FR30=30";
                GrMembers = "Declare @Mobile varchar(max)='' select @Mobile =@Mobile + ',' +  usrMobileNo  from usermaster with(nolock) where usruserid in(select distinct friendid  from friendrelationmaster  where UserId='" + userid + "' and FR30=30) select @mobile ";
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void telisamaj()
    {
        if (mobile.Length > 10)
            mobile = mobile.Substring(2);//to remove 91 from mobile
        string sql = "select usrUserid from UserMaster where usrMobileNo='" + mobile + "'";

        string ID = cc.ExecuteScalar(sql);
        sql = "select RoeId from MartketingSubuser where Uid1='" + ID + "'";
        string roleid = cc.ExecuteScalar(sql);
        if (roleid == "" || roleid == null)
        {
        }
        else
        {
            telimyct();
        }
       // teli.GetMessage(mobile, ID, WholeMsg); //Server
        //tel1.GetMessage(mobile, ID, WholeMsg);  //Local




    }


    private void telimyct()
    {
        string mob = "", fname = "", mname = "", lname = "", pincode = "", emailid = "", mobileno = "", job = "", dob = "", edu = "", age = "", name = "", mobile1 = "", UID = "", VID = "",add="";
        int smslength=0;
        string[] messsplit;
        string[] starsplit;
        string[] starsplit1;
        string[] arr;
        if (WholeMsg.Contains('$'))
        {
            messsplit = WholeMsg.Split('$');
            int messagelength = messsplit.Length;
            //length 6
            if (messagelength > 5)
            {
                string newmessage = messsplit[0];
                starsplit = newmessage.Split('*');
                mobileno = starsplit[1];
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urRegistBll.usrDOB = dob;
                        job = starsplit[11];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);


                            }
                        }

                    }


                }
                //End//

                newmessage = messsplit[1];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];

                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }

                //End
                newmessage = messsplit[2];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }


                    }


                }
                ////End
                newmessage = messsplit[3];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }


                    }


                }
                ///End
                ///
                newmessage = messsplit[4];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }


                    }


                }

                ////End

                newmessage = messsplit[5];
                starsplit1 = newmessage.Split('*');
                smslength = starsplit1.Length;
                if (smslength > 3)
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }

                    }
                    mobile1 = starsplit1[3];
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[5];
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }



                }
                else if (smslength > 2)
                {
                    mobile1 = starsplit1[1];
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];

                    mobile1 = starsplit1[1];
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }



            }
            //Length 5
            ////////////////////////////////////////////////////////
            else if (messagelength > 4)
            {
                string newmessage = messsplit[0];
                starsplit = newmessage.Split('*');
                mobileno = starsplit[1];
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urRegistBll.usrDOB = dob;
                        job = starsplit[11];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }                                                                                                                                                                                  
                //End//

                newmessage = messsplit[1];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];

                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;
                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }

                //End
                newmessage = messsplit[2];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }
                ////End
                newmessage = messsplit[3];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }
                ///End
                ///
                newmessage = messsplit[4];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }

                ////End


                newmessage = messsplit[5];
                starsplit1 = newmessage.Split('*');
                smslength = starsplit1.Length;
                if (smslength > 3)
                {

                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }
                    }
                    mobile1 = starsplit1[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[5];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }

                    }



                }
                else if (smslength > 2)
                {

                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }



            }
            /// length 4
            /// 

                ////////////////////////////////////////////////////////////////////////////////////////

            else if (messagelength > 3)
            {
                string newmessage = messsplit[0];
                starsplit = newmessage.Split('*');
                mobileno = starsplit[1];
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urRegistBll.usrDOB = dob;
                        job = starsplit[11];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }
                //End//

                newmessage = messsplit[1];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }

                //End
                newmessage = messsplit[2];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }
                ////End
                newmessage = messsplit[3];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {

                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }
                ///End
                ///
                newmessage = messsplit[4];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }

                ////End

                newmessage = messsplit[5];
                starsplit1 = newmessage.Split('*');
                smslength = starsplit1.Length;
                if (smslength > 3)
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }
                    }
                    mobile1 = starsplit1[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[5];
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }



                }
                else if (smslength > 2)
                {


                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];

                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];

                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }



            }
            /// Length 3
            /// 
            else if (messagelength > 2)
            {
                string newmessage = messsplit[0];
                starsplit = newmessage.Split('*');
                mobileno = starsplit[1];
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urRegistBll.usrDOB = dob;
                        job = starsplit[11];
                        urRegistBll.usrCarrerInterest = job;
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }

                    }


                }
                //End//

                newmessage = messsplit[1];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }

                //End
                newmessage = messsplit[2];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }


                }
                ////End
                newmessage = messsplit[3];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }
                ///End
                ///
                newmessage = messsplit[4];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }

                ////End

                newmessage = messsplit[4];
                starsplit1 = newmessage.Split('*');
                smslength = starsplit1.Length;
                if (smslength > 3)
                {
                    mobile1 = starsplit1[1];

                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];

                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[5];

                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }



                }
                else if (smslength > 2)
                {
                    mobile1 = starsplit1[1];

                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];

                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }



            }

            //// Length 2

            else if (messagelength > 1)
            {
                string newmessage = messsplit[0];
                starsplit = newmessage.Split('*');
                mobileno = starsplit[1];
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;
                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urRegistBll.usrDOB = dob;
                        job = starsplit[11];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }
                //End//

                newmessage = messsplit[1];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;
                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }

                //End
                newmessage = messsplit[2];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }
                ////End
                newmessage = messsplit[3];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }
                ///End
                ///
                newmessage = messsplit[4];
                starsplit1 = newmessage.Split('*');
                mobileno = starsplit[1];
                sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urRegistBll.usrFirstName = fname;
                            lname = arr[1];
                            urRegistBll.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urRegistBll.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urRegistBll.usrDOB = dob;
                        job = starsplit1[9];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }

                        }

                    }


                }

                ////End

                newmessage = messsplit[4];
                starsplit1 = newmessage.Split('*');
                smslength = starsplit1.Length;
                if (smslength > 3)
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }
                    }
                    mobile1 = starsplit1[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }
                    }
                    mobile1 = starsplit1[5];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }



                }
                else if (smslength > 2)
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);
                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }



            }



        }
        else if (mkeyword1 == "HEAD" || mkeyword1 == "JUNIOR" || mkeyword1 == "LEADER" || mkeyword1 == "WORKER" || mkeyword1 == "MAIN")
        {
            messsplit = WholeMsg.Split('*');
            if (messsplit.Length > 16)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urRegistBll.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    mname = arrsp[1];
                    urRegistBll.usrMiddleName = mname;
                    lname = arrsp[2];
                    urRegistBll.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    lname = arrsp[1];
                    urRegistBll.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                }
                add = messsplit[5];
                urRegistBll.usrAddress = add;
                pincode = messsplit[7];
                urRegistBll.usrPIN = pincode;
                emailid = messsplit[9];
                urRegistBll.usrEmailId = emailid;
                UID = messsplit[11];
                urRegistBll.usrBestFeature = UID;
                VID = messsplit[13];
                urRegistBll.usrBuild = VID;
                if (messsplit[14] == "DOB" || messsplit[14] == "D.O.B" || messsplit[14] == "dob")
                {
                    dob = messsplit[15];
                    urRegistBll.usrDOB = dob;
                }
                else if (messsplit[14] == "AGE" || messsplit[14] == "age" || messsplit[14] == "Age")
                {
                    age = messsplit[15];
                    urRegistBll.UsrAge = Convert.ToInt32(age);
                }
                job = messsplit[17];
                urRegistBll.usrCarrerInterest = job;
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 14)
            {

                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urRegistBll.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    mname = arrsp[1];
                    urRegistBll.usrMiddleName = mname;
                    lname = arrsp[2];
                    urRegistBll.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    lname = arrsp[1];
                    urRegistBll.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                }
                add = messsplit[5];
                urRegistBll.usrAddress = add;
                pincode = messsplit[7];
                urRegistBll.usrPIN = pincode;
                emailid = messsplit[9];
                urRegistBll.usrEmailId = emailid;
                UID = messsplit[11];
                urRegistBll.usrIdealMatch = UID;
                VID = messsplit[13];
                urRegistBll.usrBuild = VID;
                if (messsplit[14] == "DOB" || messsplit[14] == "D.O.B" || messsplit[14] == "dob")
                {
                    dob = messsplit[15];
                    urRegistBll.usrDOB = dob;
                }
                else if (messsplit[14] == "AGE" || messsplit[14] == "age" || messsplit[14] == "Age")
                {
                    age = messsplit[15];
                    urRegistBll.UsrAge = Convert.ToInt32(age);
                }
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }
                }


            }
            else if (messsplit.Length > 12)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urRegistBll.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    mname = arrsp[1];
                    urRegistBll.usrMiddleName = mname;
                    lname = arrsp[2];
                    urRegistBll.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    lname = arrsp[1];
                    urRegistBll.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                }
                add = messsplit[5];
                urRegistBll.usrAddress = add;
                pincode = messsplit[7];
                urRegistBll.usrPIN = pincode;
                emailid = messsplit[9];
                urRegistBll.usrEmailId = emailid;
                UID = messsplit[11];
                urRegistBll.usrIdealMatch = UID;
                VID = messsplit[13];
                urRegistBll.usrBuild = VID;
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 10)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urRegistBll.usrMobileNo = mob;
                string fullname = messsplit[2].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    mname = arrsp[1];
                    urRegistBll.usrMiddleName = mname;
                    lname = arrsp[2];
                    urRegistBll.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    lname = arrsp[1];
                    urRegistBll.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                }
                add = messsplit[4];
                urRegistBll.usrAddress = add;
                pincode = messsplit[6];
                urRegistBll.usrPIN = pincode;
                emailid = messsplit[8];
                urRegistBll.usrEmailId = emailid;
                UID = messsplit[11];
                urRegistBll.usrIdealMatch = UID;

                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 8)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urRegistBll.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    mname = arrsp[1];
                    urRegistBll.usrMiddleName = mname;
                    lname = arrsp[2];
                    urRegistBll.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    lname = arrsp[1];
                    urRegistBll.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                }
                add = messsplit[5];
                urRegistBll.usrAddress = add;
                pincode = messsplit[7];
                urRegistBll.usrPIN = pincode;
                emailid = messsplit[8];
                urRegistBll.usrEmailId = emailid;
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 6)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urRegistBll.usrMobileNo = mob;
                string fullname = messsplit[2].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    mname = arrsp[1];
                    urRegistBll.usrMiddleName = mname;
                    lname = arrsp[2];
                    urRegistBll.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                    lname = arrsp[1];
                    urRegistBll.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urRegistBll.usrFirstName = fname;
                }
                add = messsplit[4];
                urRegistBll.usrAddress = add;
                pincode = messsplit[7];
                urRegistBll.usrPIN = pincode;
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if ((mkeyword1 == "SON" || mkeyword1 == "DAUGHTER" || mkeyword1 == "WIFE" || mkeyword1 == "FATHER" || mkeyword1 == "MOTHER"))
            {
                messsplit = WholeMsg.Split('*');
                if (messsplit.Length > 9)
                {
                    mob = messsplit[1];
                    urRegistBll.usrMobileNo = mob;
                    name = messsplit[3];
                    string[] arr1 = name.Split(' ');
                    if (arr1.Length > 2)
                    {
                        fname = arr1[0];
                        urRegistBll.usrFirstName = fname;
                        mname = arr1[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = arr1[2];
                        urRegistBll.usrLastName = lname;

                    }
                    add = messsplit[5];
                    urRegistBll.usrAddress = add;
                    dob = messsplit[7];
                    urRegistBll.usrDOB = dob;
                    job = messsplit[9];
                    urRegistBll.usrCarrerInterest = job;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }

                    }


                }
                else if (messsplit.Length > 7)
                {
                    mob = messsplit[1];
                    urRegistBll.usrMobileNo = mob;
                    name = messsplit[3];
                    string[] arr1 = name.Split(' ');
                    if (arr1.Length > 2)
                    {
                        fname = arr1[0];
                        urRegistBll.usrFirstName = fname;
                        mname = arr1[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = arr1[2];
                        urRegistBll.usrLastName = lname;

                    }
                    add = messsplit[5];
                    urRegistBll.usrAddress = add;
                    dob = messsplit[7];
                    urRegistBll.usrDOB = dob;

                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }

                    }


                }
                else if (messsplit.Length > 5)
                {
                    mob = messsplit[1];
                    urRegistBll.usrMobileNo = mob;
                    name = messsplit[3];
                    string[] arr1 = name.Split(' ');
                    if (arr1.Length > 2)
                    {
                        fname = arr1[0];
                        urRegistBll.usrFirstName = fname;
                        mname = arr1[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = arr1[2];
                        urRegistBll.usrLastName = lname;

                    }
                    add = messsplit[5];
                    urRegistBll.usrAddress = add;

                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }

                    }


                }


            }


        }
        ////
        else if (mkeyword1 == "FAMILY" || mkeyword1 == "MEMBER")
        {

            string[] arrmsg = WholeMsg.Split('*');
            if (arrmsg.Length > 18)
            {
                mobileno = arrmsg[1].ToString();
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = arrmsg[3].ToString();
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = arrmsg[5];
                        if (name.Contains(' '))
                        {
                            string[] space = name.Split(' ');
                            if (space.Length > 2)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                mname = space[1];
                                urRegistBll.usrMiddleName = mname;
                                lname = space[2];
                                urRegistBll.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                lname = space[1];
                                urRegistBll.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                            }
                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urRegistBll.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urRegistBll.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urRegistBll.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urRegistBll.usrBestFeature = UID;
                        VID = arrmsg[15];
                        urRegistBll.usrBuild = VID;
                        string key = arrmsg[16];
                        if (key == "Age")
                        {
                            age = arrmsg[17];
                            urRegistBll.Age = Convert.ToInt32(age);

                        }
                        else
                        {
                            dob = arrmsg[17];
                            urRegistBll.usrDOB = dob;
                        }
                        job = arrmsg[19];
                        urRegistBll.usrCarrerInterest = job;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }
                }
            }


                ////////////////////////////////////////////////
            else if (arrmsg.Length > 16)
            {
                mobileno = arrmsg[1].ToString();
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = arrmsg[3].ToString();
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = arrmsg[5];
                        if (name.Contains(' '))
                        {
                            string[] space = name.Split(' ');
                            if (space.Length > 2)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                mname = space[1];
                                urRegistBll.usrMiddleName = mname;
                                lname = space[2];
                                urRegistBll.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                lname = space[1];
                                urRegistBll.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urRegistBll.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urRegistBll.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urRegistBll.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urRegistBll.usrBestFeature = UID;
                        VID = arrmsg[15];
                        urRegistBll.usrBuild = VID;
                        string key = arrmsg[16];
                        if (key == "Age")
                        {
                            age = arrmsg[17];
                            urRegistBll.Age = Convert.ToInt32(age);

                        }
                        else
                        {
                            dob = arrmsg[17];
                            urRegistBll.usrDOB = dob;
                        }

                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }
                }
            }
            ////////////////////////////
            else if (arrmsg.Length > 15)
            {
                mobileno = arrmsg[1].ToString();
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = arrmsg[3].ToString();
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = arrmsg[5];
                        if (name.Contains(' '))
                        {
                            string[] space = name.Split(' ');
                            if (space.Length > 2)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                mname = space[1];
                                urRegistBll.usrMiddleName = mname;
                                lname = space[2];
                                urRegistBll.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                lname = space[1];
                                urRegistBll.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urRegistBll.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urRegistBll.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urRegistBll.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urRegistBll.usrBestFeature = UID;
                        VID = arrmsg[15];
                        urRegistBll.usrBuild = VID;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }
                }
            }
            ///////////////////////////////////////////////
            else if (arrmsg.Length > 13)
            {
                mobileno = arrmsg[1].ToString();
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = arrmsg[3].ToString();
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = arrmsg[5];
                        if (name.Contains(' '))
                        {
                            string[] space = name.Split(' ');
                            if (space.Length > 2)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                mname = space[1];
                                urRegistBll.usrMiddleName = mname;
                                lname = space[2];
                                urRegistBll.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                lname = space[1];
                                urRegistBll.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urRegistBll.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urRegistBll.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urRegistBll.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urRegistBll.usrBestFeature = UID;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }
                }
            }
            ////////////////////////////////////////////
            else if (arrmsg.Length > 11)
            {
                mobileno = arrmsg[1].ToString();
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = arrmsg[3].ToString();
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = arrmsg[5];
                        if (name.Contains(' '))
                        {
                            string[] space = name.Split(' ');
                            if (space.Length > 2)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                mname = space[1];
                                urRegistBll.usrMiddleName = mname;
                                lname = space[2];
                                urRegistBll.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                lname = space[1];
                                urRegistBll.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urRegistBll.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urRegistBll.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urRegistBll.usrEmailId = emailid;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }
                }
            }
            //////////////////////////
            else if (arrmsg.Length > 9)
            {
                mobileno = arrmsg[1].ToString();
                string sql = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";  //bhut
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                }
                else
                {
                    mobile1 = arrmsg[3].ToString();
                    urRegistBll.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = arrmsg[5];
                        if (name.Contains(' '))
                        {
                            string[] space = name.Split(' ');
                            if (space.Length > 2)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                mname = space[1];
                                urRegistBll.usrMiddleName = mname;
                                lname = space[2];
                                urRegistBll.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                                lname = space[1];
                                urRegistBll.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urRegistBll.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urRegistBll.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urRegistBll.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urRegistBll.usrPIN = pincode;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status > 0)
                        {
                            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urRegistBll.BLLInsertSpecificUserRegistrationInitial(urRegistBll);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }
                }
            }
            ////////////////////////////////////

        }
    }
    public void changeMobileNoByLongCode(UserRegistrationBLL ur)
    {
        int smslength;
        string smsStatus = "";
        try
        {

            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                string mobileNo = ur.usrAltMobileNo;
                string Message = "Dear Given number is already registered with www.myct.in" + cc.AddSMS(mobileNo);
                smslength = Message.Length;
                cc.SendMessageLongCodeSMS("MobileLongCode", mobileNo, Message, smslength);
                smsStatus = "Y";
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
            else
            {

                status = urRegistBll.BLLChangeMobileNoByLongCode(ur);
                if (status > 0)
                {

                    string mobileNo = ur.usrMobileNo;
                    string altMobileNo = ur.usrAltMobileNo;
                    string myPassword = cc.DESDecrypt(ur.usrPassword);

                    string message = "Dear,Password for ur Login with your New Registered Mobile No is:" + myPassword + " " + cc.AddSMS(mobileNo);
                    smslength = message.Length;
                    cc.SendMessageLongCodeSMS("LongCode", mobileNo, message, smslength);
                    cc.SendMessageLongCodeSMS("LongCode", altMobileNo, message, smslength);
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }

        }
        catch (Exception ex)
        {

        }
    }



    private void AddJuniors(string usr,string juniorMobile)
    {
        try
        {
            info12(usr, juniorMobile);

        }
        catch (Exception ex)
        { }
    }


    private void info12(string usr,string juniorMobile)
    {
        try
        {
            string usrRole = "", userid = "", RoleId = "", friendid = "", reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", initialreference = "";
            string sqlfetch = "select userid,roleid,rolename,reference_id2,reference_id3,reference_id4,reference_id5,friendid from AdminSubMarketingSubUser " +
            " inner join UserMaster on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid where UserMaster.usrMobileNo='" + senderMobileNo + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlfetch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
                userid = Convert.ToString(ds1.Tables[0].Rows[0]["userid"]);
                RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
                friendid = Convert.ToString(ds1.Tables[0].Rows[0]["friendid"]);
                reference_id2 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id2"]);
                if (reference_id2 == "")
                {
                    reference_id2 = userid;
                    break;
                }

                reference_id3 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id3"]);
                if (reference_id3 == "")
                {
                    reference_id3 = userid;
                    break;
                }

                reference_id4 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id4"]);
                if (reference_id4 == "")
                {
                    reference_id4 = userid;
                    break;
                }
                reference_id5 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id5"]);
                if (reference_id5 == "")
                {
                    reference_id5 = userid;
                    break;
                }



            }

            initialreference = "6dde8c3d-1895-4904-b332-764f63206fc0";
            //Actual Code//
            string date_ofJoin = DateTime.Now.Date.ToString();
            string role = RoleId;
            string rolename = usrRole;
            string reference_id1 = initialreference;
            string sql12 = "select id from AdminSubMarketingSubUser where userid='" + friendid + "'";
            string id = cc.ExecuteScalar(sql12);
            int roleinc = 0;
            if (id == "")
            {
                string sql1 = "select roleid from SubMenuPermission where UnderRole='" + role + "'";
                id = cc.ExecuteScalar(sql1);
                if (id != "")
                {
                    sql1 = "select Roleid,RoleName from SubMenuPermission where UnderRole='" + role + "'";
                    DataSet ds = cc.ExecuteDataset(sql1);
                    roleinc = Convert.ToInt32(ds.Tables[0].Rows[0]["Roleid"]);
                    role = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);

                    string sqlinsert = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5)" +
                        " values('" + friendid + "','" + usr + "','" + date_ofJoin + "','" + roleinc + "','" + role + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "')";
                    string exe = cc.ExecuteScalar(sqlinsert);
                    string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + usr + "'";
                    string a = cc.ExecuteScalar(sqlupdate);
                    if (roleinc.ToString() == "1")
                    {
                        string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "',0)";
                        string b = cc.ExecuteScalar(sqlinserttree);
                    }
                    else
                    {
                        string sql = "select id from TreeDemo where userid='" + friendid + "' ";
                        string c = cc.ExecuteScalar(sql);
                        string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "','" + c + "')";
                        string b = cc.ExecuteScalar(sqlinserttree);
                    }
                    string msg = "Number " + juniorMobile + " Added Successfully in your chain www.myct.in";
                    int smslength = msg.Length;
                    cc.SendMessageLongCodeSMS("MobileLongCode", senderMobileNo, msg, smslength);

                }
                else
                {
                    string sqlinsert = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5)" +
                          " values('" + friendid + "','" + usr + "','" + date_ofJoin + "','" + role + "','" + rolename + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "')";
                    string exe = cc.ExecuteScalar(sqlinsert);
                    string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + usr + "'";
                    string a = cc.ExecuteScalar(sqlupdate);
                    if (roleinc.ToString() == "1")
                    {
                        string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "',0)";
                        string b = cc.ExecuteScalar(sqlinserttree);
                    }
                    else
                    {
                        string sql = "select id from TreeDemo where userid='" + friendid + "' ";
                        string c = cc.ExecuteScalar(sql);
                        string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "','" + c + "')";
                        string b = cc.ExecuteScalar(sqlinserttree);
                    }
                    string msg = "Number " + juniorMobile + " Added Successfully in your chain www.myct.in";
                    int smslength = msg.Length;
                    cc.SendMessageLongCodeSMS("MobileLongCode", senderMobileNo, msg, smslength);
                }
            }
            else
            {
                string id1 = "";
                string sql = "select id from AdminSubMarketingSubUser where friendid='" + usr + "'";//Userid
                id1 = cc.ExecuteScalar(sql);
                if (!(id1 == null || id1 == ""))
                {

                    string message = "Sorry,This User is already subuser of other, You cannot assign www.myctin";
                    int smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS("LongCode", senderMobileNo, message, smslength);
                }


                else
                {
                    string sql121 = "select reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where id='" + id + "'";
                    DataSet ds11 = cc.ExecuteDataset(sql121);
                    reference_id2 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id2"]);
                    if (reference_id2 == "")
                    {
                        reference_id2 = "";
                    }
                    reference_id3 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id3"]);
                    if (reference_id3 == "")
                    {
                        reference_id3 = "";
                    }
                    reference_id4 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id4"]);
                    if (reference_id4 == "")
                    {
                        reference_id4 = "";
                    }
                    reference_id5 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id5"]);
                    if (reference_id5 == "")
                    {
                        reference_id5 = "";
                    }
                    string sql1 = "select roleid from SubMenuPermission where UnderRole='" + role + "'";
                    id = cc.ExecuteScalar(sql1);
                    if (id != "")
                    {
                        sql1 = "select Roleid,RoleName from SubMenuPermission where UnderRole='" + role + "'";
                        DataSet ds = cc.ExecuteDataset(sql1);
                        roleinc = Convert.ToInt32(ds.Tables[0].Rows[0]["Roleid"]);
                        role = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
                        string sqlinsert = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5)" +
                            " values('" + friendid + "','" + usr + "','" + date_ofJoin + "','" + roleinc + "','" + role + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "')";
                        string exe = cc.ExecuteScalar(sqlinsert);
                        string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + friendid + "'";
                        string a = cc.ExecuteScalar(sqlupdate);
                        string query = "select id from TreeDemo where userid='" + userid + "' ";
                        string c12 = cc.ExecuteScalar(query);
                        string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + friendid + "','" + c12 + "')";
                        string b = cc.ExecuteScalar(sqlinserttree);
                        string msg = "Number " + juniorMobile + " Added Successfully in your chain www.myct.in";
                       int smslength = msg.Length;
                        cc.SendMessageLongCodeSMS("MobileLongCode", senderMobileNo, msg, smslength);

                    }

                }
            }
        }
        catch (Exception ex)
        { }

    }

    public void UserRegister()
    {
        try
        {
            string KeywordName = "";
            status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
            if (status > 0)
            {


                for (int i = 1; i < mKeyword.Length; i++)
                {
                    if (mKeyword[i].ToString() == "")
                    {
                        if (mKeyword[i].ToString() == "")
                        {
                        }
                        else
                        {
                            message1 += mKeyword[i].ToString() + " ";
                        }

                    }
                    else
                    {
                        message1 += mKeyword[i].ToString() + " ";
                    }
                }
                mkeyword1 = mkeyword1.ToUpper();
                string sqlfetch = "select * from PersonalLongCodekeywords where IMEINO='" + p2 + "' and simno='" + p1 + "'";
                DataSet ds = cc.ExecuteDataset(sqlfetch);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    KeywordName = Convert.ToString(dr["KeywordName"]);
                    if (mkeyword1 == KeywordName)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                //////////////////Start Keywords/////////////////////////////////////////////////
                if (mkeyword1 == KeywordName)
                {
                    string sql = "select keywordfor from PersonalLongCodekeywords where IMEINO='" + p2 + "' and simno='" + p1 + "' and KeywordName='" + KeywordName + "' ";
                    keywordfor = cc.ExecuteScalar(sql);
                    if (keywordfor == "2")
                    {
                        Registrationkeyword();
                    }


                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    private void Personalkeyword()
    {
        int smslength;
        try
        {
            string sqlmessage = "select ResponseMessage,EmailAddress,EmailSubject from PersonalLongCodekeywords where IMEINO='" + p2 + "' and simno='" + p1 + "' and KeywordName='" + mkeyword1 + "' ";
            DataSet dset = cc.ExecuteDataset(sqlmessage);
            string ResponseMessage = Convert.ToString(dset.Tables[0].Rows[0]["ResponseMessage"]);
            string message = "" + ResponseMessage + " www.myct.in";
            smslength = message.Length;
            cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);
            //cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message,smslength);
            splitmobileno();
            splitemail();

        }
        catch (Exception ex)
        {
        }
    }
    private void Registrationkeyword()
    {
        string Fname = "", Mname = "", Lname = "", Address = "", PinCode = "", EmailId = "", regKey = "";
        try
        {
            mobile = senderMobileNo;
            string[] arrsplit = WholeMsg.Split('*');
            if (arrsplit.Length > 4)
            {
                regKey = arrsplit[0];
                regKey = regKey.ToUpper();

                string Fullname = arrsplit[1];
                string[] Fullnamesplit = Fullname.Split(' ');
                if (Fullnamesplit.Length > 2)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Mname = Fullnamesplit[1];
                    urRegistBll.usrMiddleName = Mname;
                    Lname = Fullnamesplit[2];
                    urRegistBll.usrLastName = Lname;
                }
                else if (Fullnamesplit.Length > 1)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Lname = Fullnamesplit[1];
                    urRegistBll.usrLastName = Lname;
                }
                else
                {
                    Fname = arrsplit[1];
                    urRegistBll.usrFirstName = Fname;

                }
                Address = arrsplit[2];
                urRegistBll.usrAddress = Address;
                PinCode = arrsplit[3];
                urRegistBll.usrPIN = PinCode;
                EmailId = arrsplit[4];
                urRegistBll.usrEmailId = EmailId;
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string sql = "select ResponseMessage from PersonalLongCodekeywords where keywordName='" + regKey + "'";
                    string response = cc.ExecuteScalar(sql);
                    string PasswordMsg = "Password for First Login is " + myPassword;
                    response = PasswordMsg + " " + response + " www.myct.in";
                    int smslength = response.Length;
                    cc.SendMessageMobileLongCodeSMS("MobileLongCode", myMobileNo, response, smslength);

                }


            }
            //Length 3
            else if (arrsplit.Length > 3)
            {
                regKey = arrsplit[0];
                regKey = regKey.ToUpper();

                string Fullname = arrsplit[1];
                string[] Fullnamesplit = Fullname.Split(' ');
                if (Fullnamesplit.Length > 2)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Mname = Fullnamesplit[1];
                    urRegistBll.usrMiddleName = Mname;
                    Lname = Fullnamesplit[2];
                    urRegistBll.usrLastName = Lname;
                }
                else if (Fullnamesplit.Length > 1)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Lname = Fullnamesplit[1];
                    urRegistBll.usrLastName = Lname;
                }
                else
                {
                    Fname = arrsplit[1];
                    urRegistBll.usrFirstName = Fname;

                }
                Address = arrsplit[2];
                urRegistBll.usrAddress = Address;
                PinCode = arrsplit[3];
                urRegistBll.usrPIN = PinCode;
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string sql = "select ResponseMessage from PersonalLongCodekeywords where keywordName='" + regKey + "'";
                    string response = cc.ExecuteScalar(sql);
                    string PasswordMsg = "Password for First Login is " + myPassword;
                    response = PasswordMsg + " " + response + " www.myct.in";
                    int smslength = response.Length;
                    cc.SendMessageMobileLongCodeSMS("MobileLongCode", myMobileNo, response, smslength);

                }


            }
            //Length 2
            else if (arrsplit.Length > 2)
            {
                regKey = arrsplit[0];
                regKey = regKey.ToUpper();

                string Fullname = arrsplit[1];
                string[] Fullnamesplit = Fullname.Split(' ');
                if (Fullnamesplit.Length > 2)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Mname = Fullnamesplit[1];
                    urRegistBll.usrMiddleName = Mname;
                    Lname = Fullnamesplit[2];
                    urRegistBll.usrLastName = Lname;
                }
                else if (Fullnamesplit.Length > 1)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Lname = Fullnamesplit[1];
                    urRegistBll.usrLastName = Lname;
                }
                else
                {
                    Fname = arrsplit[1];
                    urRegistBll.usrFirstName = Fname;

                }
                Address = arrsplit[2];
                urRegistBll.usrAddress = Address;
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string sql = "select ResponseMessage from PersonalLongCodekeywords where keywordName='" + regKey + "'";
                    string response = cc.ExecuteScalar(sql);
                    string PasswordMsg = "Password for First Login is " + myPassword;
                    response = PasswordMsg + " " + response + " www.myct.in";
                    int smslength = response.Length;
                    cc.SendMessageMobileLongCodeSMS("MobileLongCode", myMobileNo, response, smslength);

                }


            }

            ///////////Length 1
            else if (arrsplit.Length > 1)
            {
                regKey = arrsplit[0];
                regKey = regKey.ToUpper();

                string Fullname = arrsplit[1];
                string[] Fullnamesplit = Fullname.Split(' ');
                if (Fullnamesplit.Length > 2)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Mname = Fullnamesplit[1];
                    urRegistBll.usrMiddleName = Mname;
                    Lname = Fullnamesplit[2];
                    urRegistBll.usrLastName = Lname;
                }
                else if (Fullnamesplit.Length > 1)
                {
                    Fname = Fullnamesplit[0];
                    urRegistBll.usrFirstName = Fname;
                    Lname = Fullnamesplit[1];
                    urRegistBll.usrLastName = Lname;
                }
                else
                {
                    Fname = arrsplit[1];
                    urRegistBll.usrFirstName = Fname;

                }

                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string sql = "select ResponseMessage from PersonalLongCodekeywords where keywordName='" + regKey + "'";
                    string response = cc.ExecuteScalar(sql);
                    string PasswordMsg = "Password for First Login is " + myPassword;
                    response = PasswordMsg + " " + response + " www.myct.in";
                    int smslength = response.Length;
                    cc.SendMessageMobileLongCodeSMS("MobileLongCode", myMobileNo, response, smslength);

                }


            }




        }
        catch (Exception ex)
        {
        }
    }
    private void Datakeyword()
    {
        mkeyword1 = mkeyword1.ToUpper();
        if ((mkeyword1 == "DATA1" || mkeyword1 == "DATA2" || mkeyword1 == "DATA3" || mkeyword1 == "DATA4" || mkeyword1 == "DATA5" || mkeyword1 == "DATA6" || mkeyword1 == "DATA7" || mkeyword1 == "DATA8" || mkeyword1 == "DATA9" || mkeyword1 == "DATA10"))
        {
            int smslength;
            string mainref = "";
            DateTime date = DateTime.Now;
            string todaysDate = date.ToShortDateString();
            senderid = "myctin";
            string[] mmsg = WholeMsg.Split('*');
            mobile = senderMobileNo;
            urRegistBll.usrMobileNo = mobile;

            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + mobile + "'";
            string usruserid = cc.ExecuteScalar(sqlget);
            urRegistBll.usrKeyWord = mkeyword1.ToString();
            lenght1 = mmsg.Length;
            string sqlcheck = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "' or userid='" + usruserid + "'";
            string checkfrnd = cc.ExecuteScalar(sqlcheck);
            if (checkfrnd == "" || checkfrnd == null)
            {
            }
            else
            {
                string sql = "select reference_id3 from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                mainref = cc.ExecuteScalar(sql);
                string sql12 = "insert into DataCollection1(sender_mobileno,send_date,main_ref)" +
                        " values('" + usruserid + "','" + todaysDate + "','" + mainref + "')";
                string exe = cc.ExecuteScalar(sql12);
                message = "Ur Data Updated Successfully Thanks via www.myct.in";
                smslength = message.Length;
                string sql11 = "select top 1 data_id from DataCollection1 order by data_id desc ";
                string id = cc.ExecuteScalar(sql11);
                if (lenght1 == 1)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS("MobileLongCode", senderMobileNo, message, smslength);

                }
                else if (lenght1 == 2)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS("MobileLongCode", senderMobileNo, message, smslength);
                }
                else if (lenght1 == 3)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);
                }
                else if (lenght1 == 4)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }

                else if (lenght1 == 5)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "' ,ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 6)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 7)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 8)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 9)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',,ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }

                else if (lenght1 == 10)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 11)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 12)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                        " p12='" + mmsg[11] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 13)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                       " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 14)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                       " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 15)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                       " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 16)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                       " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "' ,p16='" + mmsg[15] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 17)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                      " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 18)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                      " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "',p18='" + mmsg[17] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 19)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                      " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "'" +
                    " ,p18='" + mmsg[17] + "',p19='" + mmsg[18] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
                else if (lenght1 == 20)
                {
                    string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                    string refrence = cc.ExecuteScalar(query);
                    string sql1 = "update DataCollection1 set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                      " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "'" +
                    " ,p18='" + mmsg[17] + "',p19='" + mmsg[18] + "',p20='" + mmsg[19] + "' ,ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                    string execute = cc.ExecuteScalar(sql1);
                    cc.SendMessageMobileLongCodeSMS(senderMobileNo, senderMobileNo, message, smslength);

                }
            }
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        else if ((mkeyword1 == "GETRECORD" || mkeyword1 == "GetRecord" || mkeyword1 == "Getrecord" || mkeyword1 == "getrecord"))
        {
            GetRecord();

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        else
        {
            //Personalkeyword();
        }
    }
    public void splitmobileno()
    {
        int smslength;
        string sender = "myctin";
        string sqlmessage = "select Fwdmobileno from PersonalLongCodekeywords where IMEINO='" + p2 + "' and simno='" + p1 + "' and KeywordName='" + mkeyword1 + "' ";
        string FwdmobileNo = cc.ExecuteScalar(sqlmessage);
        string[] arr = FwdmobileNo.Split(',');
        foreach (string str in arr)
        {
            FwdmobileNo = str;
            string Message = smsBody;
            string sms = "Dear user,Message:" + Message + " From:" + senderMobileNo + " Thanks via www.myct.in";
            smslength = sms.Length;
            cc.SendMessageMobileLongCodeSMS(senderMobileNo, FwdmobileNo, sms, smslength);

        }

    }

    public void splitemail()
    {
        string sqlmessage = "select EmailAddress,EmailSubject from PersonalLongCodekeywords where IMEINO='" + p2 + "' and simno='" + p1 + "' and KeywordName='" + mkeyword1 + "' ";
        DataSet ds = cc.ExecuteDataset(sqlmessage);
        string EmailSubject = Convert.ToString(ds.Tables[0].Rows[0]["EmailSubject"]);
        string EmailAddress = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]);
        smsBody = "Dear User Message: " + smsBody + "From " + senderMobileNo;
        string[] arr = EmailAddress.Split(',');
        foreach (string str in arr)
        {
            EmailAddress = str;
            //ll.sendEmail(EmailAddress, EmailSubject, smsBody);
            string from = "myctsms@gmail.com";
            string to = EmailAddress;
            string subject = EmailSubject;
            string body = smsBody;
            SmtpMail.SmtpServer = "smtp.gmail.com";
            SmtpMail.Send(from, to, subject, body);
            


        }


    }

    private void GetRecord()
    {
        try
        {
            string[] arrsplit = smsBody.Split('*');
            string keyword = arrsplit[1];
            int smslength;
            string sql20 = "";
            string mobileno = "";
            string messagesend = "";
            string id = "";
            mobile = senderMobileNo;
            DateTime date = DateTime.Now;
            string todaysDate = date.ToShortDateString();
            int r3 = 0, r5 = 0, r7 = 0, r9 = 0, r11 = 0, r13 = 0, r15 = 0, r17 = 0, r19 = 0, r21 = 0, r23 = 0, r25 = 0, r27 = 0, r29 = 0;
            string query = "select usrUserid from usermaster where usrMobileNo='" + mobile + "'";
            string userid = cc.ExecuteScalar(query);
            string sq1 = "select friendid from AdminSubMarketingSubUser where userid='" + userid + "'";
            DataSet ds = cc.ExecuteDataset(sq1);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                r3 = 0;
                r5 = 0;
                r7 = 0;
                r9 = 0;
                r11 = 0;
                r13 = 0;
                r15 = 0;
                r17 = 0;
                r19 = 0;
                r21 = 0;
                r23 = 0;
                r25 = 0;
                r27 = 0;
                r29 = 0;

                string f1 = Convert.ToString(dr["friendid"]);
                string sql2 = "select friendid from AdminSubMarketingSubUser where userid='" + f1 + "'";
                DataSet ds2 = cc.ExecuteDataset(sql2);
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    r3 = 0;
                    r5 = 0;
                    r7 = 0;
                    r9 = 0;
                    r11 = 0;
                    r13 = 0;
                    r15 = 0;
                    r17 = 0;
                    r19 = 0;
                    r21 = 0;
                    r23 = 0;
                    r25 = 0;
                    r27 = 0;
                    r29 = 0;

                    string f2 = Convert.ToString(dr2["friendid"]);
                    string sql3 = "select friendid from AdminSubMarketingSubUser where userid='" + f2 + "'";
                    DataSet ds3 = cc.ExecuteDataset(sql3);
                    ////////////////////start with calulation JE/////////////////////////
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        r3 = 0;
                        r5 = 0;
                        r7 = 0;
                        r9 = 0;
                        r11 = 0;
                        r13 = 0;
                        r15 = 0;
                        r17 = 0;
                        r19 = 0;
                        r21 = 0;
                        r23 = 0;
                        r25 = 0;
                        r27 = 0;
                        r29 = 0;

                        string f3 = Convert.ToString(dr3["friendid"]);
                        string sql4 = "select friendid from AdminSubMarketingSubUser where userid='" + f3 + "'";
                        DataSet ds4 = cc.ExecuteDataset(sql4);
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            string f4 = Convert.ToString(dr4["friendid"]);
                            string sql6 = "select * from DataCollection1 where sender_mobileno='" + f4 + "' and send_date='" + todaysDate + "'";
                            DataSet ds6 = cc.ExecuteDataset(sql6);
                            foreach (DataRow dr6 in ds6.Tables[0].Rows)
                            {
                                //string sql5 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23 from DataCollection1 where sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                string sql5 = "select SUM(CAST(p3  AS INT))as p3 from DataCollection1 where ISNUMERIC(p3) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p4  AS INT))as p4 from DataCollection1 where ISNUMERIC(p4) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p5  AS INT))as p5 from DataCollection1 where ISNUMERIC(p5) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p6  AS INT))as p6 from DataCollection1 where ISNUMERIC(p6) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p7  AS INT))as p7 from DataCollection1 where ISNUMERIC(p7) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p8  AS INT))as p8 from DataCollection1 where ISNUMERIC(p8) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p9  AS INT))as p9 from DataCollection1 where ISNUMERIC(p9) = 1 and p2='" + keyword + "' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p10  AS INT))as p10 from DataCollection1 where ISNUMERIC(p10) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p11  AS INT))as p11 from DataCollection1 where ISNUMERIC(p11) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p12  AS INT))as p12 from DataCollection1 where ISNUMERIC(p12) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p13  AS INT))as p13 from DataCollection1 where ISNUMERIC(p13) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p14  AS INT))as p14 from DataCollection1 where ISNUMERIC(p14) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                sql5 = sql5 + "select SUM(CAST(p15  AS INT))as p15 from DataCollection1 where ISNUMERIC(p15) = 1 and p2 like '" + keyword + "%' and sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                                DataSet ds5 = cc.ExecuteDataset(sql5);
                                foreach (DataRow dr5 in ds5.Tables[0].Rows)
                                {
                                    string p3 = Convert.ToString(ds5.Tables[0].Rows[0]["p3"]);
                                    if (p3 == "")
                                    {
                                        p3 = "0";
                                    }
                                    string p4 = Convert.ToString(ds5.Tables[1].Rows[0]["p4"]);
                                    if (p4 == "")
                                    {
                                        p4 = "0";
                                    }
                                    string p5 = Convert.ToString(ds5.Tables[2].Rows[0]["p5"]);
                                    if (p5 == "")
                                    {
                                        p5 = "0";
                                    }
                                    string p6 = Convert.ToString(ds5.Tables[3].Rows[0]["p6"]);
                                    if (p6 == "")
                                    {
                                        p6 = "0";
                                    }
                                    string p7 = Convert.ToString(ds5.Tables[4].Rows[0]["p7"]);
                                    if (p7 == "")
                                    {
                                        p7 = "0";
                                    }
                                    string p8 = Convert.ToString(ds5.Tables[5].Rows[0]["p8"]);
                                    if (p8 == "")
                                    {
                                        p8 = "0";
                                    }
                                    string p9 = Convert.ToString(ds5.Tables[6].Rows[0]["p9"]);
                                    if (p9 == "")
                                    {
                                        p9 = "0";
                                    }
                                    string p10 = Convert.ToString(ds5.Tables[7].Rows[0]["p10"]);
                                    if (p10 == "")
                                    {
                                        p10 = "0";
                                    }
                                    string p11 = Convert.ToString(ds5.Tables[8].Rows[0]["p11"]);
                                    if (p11 == "")
                                    {
                                        p11 = "0";
                                    }
                                    string p12 = Convert.ToString(ds5.Tables[9].Rows[0]["p12"]);
                                    if (p12 == "")
                                    {
                                        p12 = "0";
                                    }
                                    string p13 = Convert.ToString(ds5.Tables[10].Rows[0]["p13"]);
                                    if (p13 == "")
                                    {
                                        p13 = "0";
                                    }
                                    string p14 = Convert.ToString(ds5.Tables[11].Rows[0]["p14"]);
                                    if (p14 == "")
                                    {
                                        p14 = "0";
                                    }
                                    string p15 = Convert.ToString(ds5.Tables[12].Rows[0]["p15"]);
                                    if (p15 == "")
                                    {
                                        p15 = "0";
                                    }
                                    r3 = r3 + Convert.ToInt32(p3);
                                    r5 = r5 + Convert.ToInt32(p4);
                                    r7 = r7 + Convert.ToInt32(p5);
                                    r9 = r9 + Convert.ToInt32(p6);
                                    r11 = r11 + Convert.ToInt32(p7);
                                    r13 = r13 + Convert.ToInt32(p8);
                                    r15 = r15 + Convert.ToInt32(p9);
                                    r17 = r17 + Convert.ToInt32(p10);
                                    r19 = r19 + Convert.ToInt32(p11);
                                    r21 = r21 + Convert.ToInt32(p12);
                                    r23 = r23 + Convert.ToInt32(p13);
                                    r25 = r25 + Convert.ToInt32(p14);
                                    r27 = r27 + Convert.ToInt32(p15);



                                }


                            }



                        }

                        string sql7 = "insert into AELevel41(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,ref_id,send_date)values('" + f3 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + r25 + "','" + r27 + "','" + f2 + "','" + todaysDate + "')";
                        int a = cc.ExecuteNonQuery(sql7);
                        sql20 = "select usrMobileNo from usermaster where usrUserid='" + f3 + "'";
                        mobileno = cc.ExecuteScalar(sql20);
                        string query1 = "select friendid from AdminSubMarketingSubUser where userid='" + f3 + "'";
                        string urfriend = cc.ExecuteScalar(query1);
                        if (urfriend == "" || urfriend == null)
                        {

                        }
                        else
                        {
                            /////Message to AE level
                            messagesend = "Dear user calulation of Junior is Data*P3=" + r3 + "*P4=" + r5 + "*P5=" + r7 + "*P6=" + r9 + "*P7=" + r11 + "*P8=" + r13 + "*P9=" + r15 + "*p10=" + r17 + "*P11=" + r19 + "*P12=" + r21 + "*P13=" + r23 + "*P14=" + r25 + "*P15=" + r27 + " thanks via www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageMobileLongCodeSMS(mobileno, mobileno, messagesend, smslength);
                        }
                        string sql131 = "select * from DataCollection1 where sender_mobileno='" + f3 + "' and send_date='" + todaysDate + "'";
                        DataSet ds141 = cc.ExecuteDataset(sql131);
                        foreach (DataRow dr14 in ds141.Tables[0].Rows)
                        {
                            string p3 = Convert.ToString(ds141.Tables[0].Rows[0]["P3"]);
                            string p5 = Convert.ToString(ds141.Tables[0].Rows[0]["P4"]);
                            string p7 = Convert.ToString(ds141.Tables[0].Rows[0]["P5"]);
                            string p9 = Convert.ToString(ds141.Tables[0].Rows[0]["p6"]);
                            string p11 = Convert.ToString(ds141.Tables[0].Rows[0]["p7"]);
                            string p13 = Convert.ToString(ds141.Tables[0].Rows[0]["p8"]);
                            string p15 = Convert.ToString(ds141.Tables[0].Rows[0]["p9"]);
                            string p17 = Convert.ToString(ds141.Tables[0].Rows[0]["p10"]);
                            string p19 = Convert.ToString(ds141.Tables[0].Rows[0]["p11"]);
                            string p21 = Convert.ToString(ds141.Tables[0].Rows[0]["p12"]);
                            string p23 = Convert.ToString(ds141.Tables[0].Rows[0]["p13"]);
                            string p25 = Convert.ToString(ds141.Tables[0].Rows[0]["p14"]);
                            string p27 = Convert.ToString(ds141.Tables[0].Rows[0]["p15"]);

                            string sql141 = "insert into AELevel41(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,ref_id,send_date)values('" + f3 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + p25 + "','" + p27 + "','" + f2 + "','" + todaysDate + "')";
                            int aa1 = cc.ExecuteNonQuery(sql141);

                        }

                    }
                    ////////////////Finish calculation of JE and insert into AE or End of JE/////////////////////

                    string sql19 = "select * from AELevel41 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";

                    DataSet ds19 = cc.ExecuteDataset(sql19);
                    foreach (DataRow dr19 in ds19.Tables[0].Rows)
                    {

                        id = Convert.ToString(dr19["sender_mobileno"]);
                        //string sql8 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23  from AELevel41 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        string sql8 = "select SUM(CAST(p3  AS INT))as p3 from AELevel41 where ISNUMERIC(p3) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p4  AS INT))as p4 from AELevel41 where ISNUMERIC(p4) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p5  AS INT))as p5 from AELevel41 where ISNUMERIC(p5) = 1 and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p6  AS INT))as p6 from AELevel41 where ISNUMERIC(p6) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p7  AS INT))as p7 from AELevel41 where ISNUMERIC(p7) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p8  AS INT))as p8 from AELevel41 where ISNUMERIC(p8) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p9  AS INT))as p9 from AELevel41 where ISNUMERIC(p9) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p10  AS INT))as p10 from AELevel41 where ISNUMERIC(p10) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p11  AS INT))as p11 from AELevel41 where ISNUMERIC(p11) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p12  AS INT))as p12 from AELevel41 where ISNUMERIC(p12) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p13  AS INT))as p13 from AELevel41 where ISNUMERIC(p13) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p14  AS INT))as p14 from AELevel41 where ISNUMERIC(p14) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        sql8 = sql8 + "select SUM(CAST(p15  AS INT))as p15 from AELevel41 where ISNUMERIC(p15) = 1  and  ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                        DataSet ds7 = cc.ExecuteDataset(sql8);
                        foreach (DataRow dr7 in ds7.Tables[0].Rows)
                        {

                            r3 = 0;
                            r5 = 0;
                            r7 = 0;
                            r9 = 0;
                            r11 = 0;
                            r13 = 0;
                            r15 = 0;
                            r17 = 0;
                            r19 = 0;
                            r21 = 0;
                            r23 = 0;
                            r25 = 0;
                            r27 = 0;
                            string p3 = Convert.ToString(ds7.Tables[0].Rows[0]["p3"]);
                            if (p3 == "")
                            {
                                p3 = "0";
                            }
                            string p4 = Convert.ToString(ds7.Tables[1].Rows[0]["p4"]);
                            if (p4 == "")
                            {
                                p4 = "0";
                            }
                            string p5 = Convert.ToString(ds7.Tables[2].Rows[0]["p5"]);
                            if (p5 == "")
                            {
                                p5 = "0";
                            }
                            string p6 = Convert.ToString(ds7.Tables[3].Rows[0]["p6"]);
                            if (p6 == "")
                            {
                                p6 = "0";
                            }
                            string p7 = Convert.ToString(ds7.Tables[4].Rows[0]["p7"]);
                            if (p7 == "")
                            {
                                p7 = "0";
                            }
                            string p8 = Convert.ToString(ds7.Tables[5].Rows[0]["p8"]);
                            if (p8 == "")
                            {
                                p8 = "0";
                            }
                            string p9 = Convert.ToString(ds7.Tables[6].Rows[0]["p9"]);
                            if (p9 == "")
                            {
                                p9 = "0";
                            }
                            string p10 = Convert.ToString(ds7.Tables[7].Rows[0]["p10"]);
                            if (p10 == "")
                            {
                                p10 = "0";
                            }
                            string p11 = Convert.ToString(ds7.Tables[8].Rows[0]["p11"]);
                            if (p11 == "")
                            {
                                p11 = "0";
                            }
                            string p12 = Convert.ToString(ds7.Tables[9].Rows[0]["p12"]);
                            if (p12 == "")
                            {
                                p12 = "0";
                            }
                            string p13 = Convert.ToString(ds7.Tables[10].Rows[0]["p13"]);
                            if (p13 == "")
                            {
                                p13 = "0";
                            }
                            string p14 = Convert.ToString(ds7.Tables[11].Rows[0]["p14"]);
                            if (p14 == "")
                            {
                                p14 = "0";
                            }
                            string p15 = Convert.ToString(ds7.Tables[12].Rows[0]["p15"]);
                            if (p15 == "")
                            {
                                p15 = "0";
                            }
                            r3 = r3 + Convert.ToInt32(p3);
                            r5 = r5 + Convert.ToInt32(p4);
                            r7 = r7 + Convert.ToInt32(p5);
                            r9 = r9 + Convert.ToInt32(p6);
                            r11 = r11 + Convert.ToInt32(p7);
                            r13 = r13 + Convert.ToInt32(p8);
                            r15 = r15 + Convert.ToInt32(p9);
                            r17 = r17 + Convert.ToInt32(p10);
                            r19 = r19 + Convert.ToInt32(p11);
                            r21 = r21 + Convert.ToInt32(p12);
                            r23 = r23 + Convert.ToInt32(p13);
                            r25 = r25 + Convert.ToInt32(p14);
                            r27 = r27 + Convert.ToInt32(p15);

                        }

                    }

                    string sql10 = "insert into EELevel31(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,ref_id,send_date)values('" + f2 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + r25 + "','" + r27 + "','" + f1 + "','" + todaysDate + "')";
                    int c = cc.ExecuteNonQuery(sql10);
                    sql20 = "select usrMobileNo from usermaster where usrUserid='" + f2 + "'";
                    mobileno = cc.ExecuteScalar(sql20);
                    string query2 = "select friendid from AdminSubMarketingSubUser where userid='" + f2 + "'";
                    string urfriend1 = cc.ExecuteScalar(query2);
                    if (urfriend1 == "" || urfriend1 == null)
                    {
                    }
                    else
                    {
                        //////////Msg to EE level
                        messagesend = "Dear user calulation of Junior is Data*P3=" + r3 + "*P4=" + r5 + "*P5=" + r7 + "*P6='" + r9 + "*P7=" + r11 + "*P8=" + r13 + "*P9=" + r15 + "*P10=" + r17 + "*P11=" + r19 + "*P12=" + r21 + "*P13=" + r23 + "*P14=" + r25 + "*P15=" + r27 + " thanks via www.myct.in";
                        //messagesend = "Dear user calulation of Junior is Data*P3='" + r3 + "'*P5='" + r5 + "'*P7='" + r7 + "'*P9='" + r9 + "'*P11='" + r11 + "'*P13='" + r13 + "'*P15='" + r15 + "'*P17='" + r17 + "'*P19='" + r19 + "'*P21='" + r21 + "'*P23='" + r23 + "' thanks via www.myct.in";
                        smslength = message.Length;
                        cc.SendMessageMobileLongCodeSMS(mobileno, mobileno, messagesend, smslength);
                    }
                    string sql1311 = "select * from DataCollection1 where sender_mobileno='" + f2 + "' and send_date='" + todaysDate + "'";
                    DataSet ds1411 = cc.ExecuteDataset(sql1311);
                    foreach (DataRow dr141 in ds1411.Tables[0].Rows)
                    {
                        string p3 = Convert.ToString(ds1411.Tables[0].Rows[0]["P3"]);
                        string p5 = Convert.ToString(ds1411.Tables[0].Rows[0]["P4"]);
                        string p7 = Convert.ToString(ds1411.Tables[0].Rows[0]["P5"]);
                        string p9 = Convert.ToString(ds1411.Tables[0].Rows[0]["p6"]);
                        string p11 = Convert.ToString(ds1411.Tables[0].Rows[0]["p7"]);
                        string p13 = Convert.ToString(ds1411.Tables[0].Rows[0]["p8"]);
                        string p15 = Convert.ToString(ds1411.Tables[0].Rows[0]["p9"]);
                        string p17 = Convert.ToString(ds1411.Tables[0].Rows[0]["p10"]);
                        string p19 = Convert.ToString(ds1411.Tables[0].Rows[0]["p11"]);
                        string p21 = Convert.ToString(ds1411.Tables[0].Rows[0]["p12"]);
                        string p23 = Convert.ToString(ds1411.Tables[0].Rows[0]["p13"]);
                        string p25 = Convert.ToString(ds1411.Tables[0].Rows[0]["p14"]);
                        string p27 = Convert.ToString(ds1411.Tables[0].Rows[0]["p15"]);




                        string sql141 = "insert into EELevel31(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,ref_id,send_date)values('" + f2 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + p25 + "','" + p27 + "','" + f1 + "','" + todaysDate + "')";
                        int aa1 = cc.ExecuteNonQuery(sql141);
                    }



                }
                ///////////////////End of EE//////////////////////////////
                string sql12 = "select * from EELevel31 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                DataSet ds13 = cc.ExecuteDataset(sql12);

                foreach (DataRow dr12 in ds13.Tables[0].Rows)
                {

                    id = Convert.ToString(dr12["sender_mobileno"]);
                    //string sql11 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23 from EELevel31 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    string sql11 = "select SUM(CAST(p3 AS INT))as p3 from EELevel31 where ISNUMERIC(p3) = 1  and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p4 AS INT))as p4 from EELevel31 where ISNUMERIC(p4) = 1   and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p5 AS INT))as p5 from EELevel31 where ISNUMERIC(p5) = 1  and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p6 AS INT))as p6 from EELevel31 where ISNUMERIC(p6) = 1  and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p7 AS INT))as p7 from EELevel31 where ISNUMERIC(p7) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p8 AS INT))as p8 from EELevel31 where ISNUMERIC(p8) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p9 AS INT))as p9 from EELevel31 where ISNUMERIC(p9) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p10 AS INT))as p10 from EELevel31 where ISNUMERIC(p10) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p11 AS INT))as p11 from EELevel31 where ISNUMERIC(p11) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p12 AS INT))as p12 from EELevel31 where ISNUMERIC(p12) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p13 AS INT))as p13 from EELevel31 where ISNUMERIC(p13) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p14 AS INT))as p14 from EELevel31 where ISNUMERIC(p14) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    sql11 = sql11 + "select SUM(CAST(p15 AS INT))as p15 from EELevel31 where ISNUMERIC(p15) = 1 and ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                    DataSet ds11 = cc.ExecuteDataset(sql11);
                    foreach (DataRow dr11 in ds11.Tables[0].Rows)
                    {
                        r3 = 0;
                        r5 = 0;
                        r7 = 0;
                        r9 = 0;
                        r11 = 0;
                        r13 = 0;
                        r15 = 0;
                        r17 = 0;
                        r19 = 0;
                        r21 = 0;
                        r23 = 0;
                        r25 = 0;
                        r27 = 0;
                        r29 = 0;

                        string p3 = Convert.ToString(ds11.Tables[0].Rows[0]["P3"]);
                        if (p3 == "")
                        {
                            p3 = "0";
                        }
                        string p5 = Convert.ToString(ds11.Tables[1].Rows[0]["P4"]);
                        if (p5 == "")
                        {
                            p5 = "0";
                        }
                        string p7 = Convert.ToString(ds11.Tables[2].Rows[0]["P5"]);
                        if (p7 == "")
                        {
                            p7 = "0";
                        }
                        string p9 = Convert.ToString(ds11.Tables[3].Rows[0]["p6"]);
                        if (p9 == "")
                        {
                            p9 = "0";
                        }
                        string p11 = Convert.ToString(ds11.Tables[4].Rows[0]["p7"]);
                        if (p11 == "")
                        {
                            p11 = "0";
                        }
                        string p13 = Convert.ToString(ds11.Tables[5].Rows[0]["p8"]);
                        if (p13 == "")
                        {
                            p13 = "0";
                        }
                        string p15 = Convert.ToString(ds11.Tables[6].Rows[0]["p9"]);
                        if (p15 == "")
                        {
                            p15 = "0";
                        }
                        string p17 = Convert.ToString(ds11.Tables[7].Rows[0]["p10"]);
                        if (p17 == "")
                        {
                            p17 = "0";
                        }
                        string p19 = Convert.ToString(ds11.Tables[8].Rows[0]["p11"]);
                        if (p19 == "")
                        {
                            p19 = "0";
                        }
                        string p21 = Convert.ToString(ds11.Tables[9].Rows[0]["p12"]);
                        if (p21 == "")
                        {
                            p21 = "0";
                        }
                        string p23 = Convert.ToString(ds11.Tables[10].Rows[0]["p13"]);
                        if (p23 == "")
                        {
                            p23 = "0";
                        }
                        string p25 = Convert.ToString(ds11.Tables[11].Rows[0]["p14"]);
                        if (p25 == "")
                        {
                            p25 = "0";
                        }
                        string p27 = Convert.ToString(ds11.Tables[12].Rows[0]["p15"]);
                        if (p27 == "")
                        {
                            p27 = "0";
                        }
                        r3 = r3 + Convert.ToInt32(p3);
                        r5 = r5 + Convert.ToInt32(p5);
                        r7 = r7 + Convert.ToInt32(p7);
                        r9 = r9 + Convert.ToInt32(p9);
                        r11 = r11 + Convert.ToInt32(p11);
                        r13 = r13 + Convert.ToInt32(p13);
                        r15 = r15 + Convert.ToInt32(p15);
                        r17 = r17 + Convert.ToInt32(p17);
                        r19 = r19 + Convert.ToInt32(p19);
                        r21 = r21 + Convert.ToInt32(p21);
                        r23 = r23 + Convert.ToInt32(p23);
                        r25 = r25 + Convert.ToInt32(p25);
                        r27 = r27 + Convert.ToInt32(p27);


                    }
                }

                string sql9 = "insert into SELevel21(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,ref_id,send_date)values('" + f1 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + r25 + "','" + r27 + "','" + userid + "','" + todaysDate + "')";
                int d = cc.ExecuteNonQuery(sql9);
                sql20 = "select usrMobileNo from usermaster where usrUserid='" + f1 + "'";
                mobileno = cc.ExecuteScalar(sql20);
                string query3 = "select friendid from AdminSubMarketingSubUser where userid='" + f1 + "'";
                string urfriend2 = cc.ExecuteScalar(query3);
                if (urfriend2 == "" || urfriend2 == null)
                {
                }
                else
                {
                    ////Msg to SE Level
                    messagesend = "Dear user calulation of Junior is Data*P3=" + r3 + "*P4=" + r5 + "*P5=" + r7 + "*P6='" + r9 + "*P7=" + r11 + "*P8=" + r13 + "*P9=" + r15 + "*P10=" + r17 + "*P11=" + r19 + "*P12=" + r21 + "*P13=" + r23 + "*P14=" + r25 + "*P15=" + r27 + " thanks via www.myct.in";
                    //messagesend = "Dear user calulation of Junior is Data*P3='" + r3 + "'*P5='" + r5 + "'*P7='" + r7 + "'*P9='" + r9 + "'*P11='" + r11 + "'*P13='" + r13 + "'*P15='" + r15 + "'*P17='" + r17 + "'*P19='" + r19 + "'*P21='" + r21 + "'*P23='" + r23 + "' thanks via www.myct.in";
                    smslength = message.Length;
                    cc.SendMessageMobileLongCodeSMS(mobileno, mobileno, messagesend, smslength);
                }
                string sql13112 = "select * from DataCollection1 where sender_mobileno='" + f1 + "' and send_date='" + todaysDate + "'";
                DataSet ds14112 = cc.ExecuteDataset(sql13112);
                foreach (DataRow dr141 in ds14112.Tables[0].Rows)
                {
                    string p3 = Convert.ToString(ds14112.Tables[0].Rows[0]["P3"]);
                    string p5 = Convert.ToString(ds14112.Tables[0].Rows[0]["P4"]);
                    string p7 = Convert.ToString(ds14112.Tables[0].Rows[0]["P5"]);
                    string p9 = Convert.ToString(ds14112.Tables[0].Rows[0]["p6"]);
                    string p11 = Convert.ToString(ds14112.Tables[0].Rows[0]["p7"]);
                    string p13 = Convert.ToString(ds14112.Tables[0].Rows[0]["p8"]);
                    string p15 = Convert.ToString(ds14112.Tables[0].Rows[0]["p9"]);
                    string p17 = Convert.ToString(ds14112.Tables[0].Rows[0]["p10"]);
                    string p19 = Convert.ToString(ds14112.Tables[0].Rows[0]["p11"]);
                    string p21 = Convert.ToString(ds14112.Tables[0].Rows[0]["p12"]);
                    string p23 = Convert.ToString(ds14112.Tables[0].Rows[0]["p13"]);
                    string p25 = Convert.ToString(ds14112.Tables[0].Rows[0]["p14"]);
                    string p27 = Convert.ToString(ds14112.Tables[0].Rows[0]["p15"]);

                    string sql141 = "insert into SELevel21(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,ref_id,send_date)values('" + f1 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + p25 + "','" + p27 + "','" + userid + "','" + todaysDate + "')";
                    int aa1 = cc.ExecuteNonQuery(sql141);

                }

            }
            string sql16 = "select * from DataCollection1 where sender_mobileno='" + userid + "' and send_date='" + todaysDate + "'";
            DataSet ds16 = cc.ExecuteDataset(sql16);
            foreach (DataRow dr16 in ds16.Tables[0].Rows)
            {
                string p3 = Convert.ToString(ds16.Tables[0].Rows[0]["P3"]);
                string p5 = Convert.ToString(ds16.Tables[0].Rows[0]["P4"]);
                string p7 = Convert.ToString(ds16.Tables[0].Rows[0]["P5"]);
                string p9 = Convert.ToString(ds16.Tables[0].Rows[0]["p6"]);
                string p11 = Convert.ToString(ds16.Tables[0].Rows[0]["p7"]);
                string p13 = Convert.ToString(ds16.Tables[0].Rows[0]["p8"]);
                string p15 = Convert.ToString(ds16.Tables[0].Rows[0]["p9"]);
                string p17 = Convert.ToString(ds16.Tables[0].Rows[0]["p10"]);
                string p19 = Convert.ToString(ds16.Tables[0].Rows[0]["p11"]);
                string p21 = Convert.ToString(ds16.Tables[0].Rows[0]["p12"]);
                string p23 = Convert.ToString(ds16.Tables[0].Rows[0]["p13"]);
                string p25 = Convert.ToString(ds16.Tables[0].Rows[0]["p14"]);
                string p27 = Convert.ToString(ds16.Tables[0].Rows[0]["p15"]);

                string sql141 = "insert into SELevel21(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,ref_id,send_date)values('" + userid + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + p25 + "','" + p27 + "','" + userid + "','" + todaysDate + "')";
                int aa1 = cc.ExecuteNonQuery(sql141);


            }

            /////////////////////////////////End of SE//////////////////////

            string sql13 = "select * from SELevel21 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
            DataSet ds14 = cc.ExecuteDataset(sql13);
            foreach (DataRow dr13 in ds14.Tables[0].Rows)
            {

                id = Convert.ToString(dr13["sender_mobileno"]);
                // string sqlfinal = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23  from SELevel21 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                string sqlfinal = "select SUM(CAST(p3  AS INT))as p3 from SELevel21 where ISNUMERIC(p3) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p4  AS INT))as p4 from SELevel21 where ISNUMERIC(p4) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p5  AS INT))as p5 from SELevel21 where ISNUMERIC(p5) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p6  AS INT))as p6 from SELevel21 where ISNUMERIC(p6) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p7  AS INT))as p7 from SELevel21 where ISNUMERIC(p7) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p8  AS INT))as p8 from SELevel21 where ISNUMERIC(p8) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p9  AS INT))as p9 from SELevel21 where ISNUMERIC(p9) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p10  AS INT))as p10 from SELevel21 where ISNUMERIC(p10) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p11  AS INT))as p11 from SELevel21 where ISNUMERIC(p11) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p12  AS INT))as p12 from SELevel21 where ISNUMERIC(p12) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p13  AS INT))as p13 from SELevel21 where ISNUMERIC(p13) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p14  AS INT))as p14 from SELevel21 where ISNUMERIC(p14) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                sqlfinal = sqlfinal + "select SUM(CAST(p15  AS INT))as p15 from SELevel21 where ISNUMERIC(p15) = 1  and ref_id='" + userid + "' and send_date='" + todaysDate + "'";
                DataSet dsfinal = cc.ExecuteDataset(sqlfinal);
                string p3 = Convert.ToString(dsfinal.Tables[0].Rows[0]["P3"]);
                if (p3 == "")
                {
                    p3 = "0";
                }
                string p5 = Convert.ToString(dsfinal.Tables[1].Rows[0]["P4"]);
                if (p5 == "")
                {
                    p5 = "0";
                }
                string p7 = Convert.ToString(dsfinal.Tables[2].Rows[0]["P5"]);
                if (p7 == "")
                {
                    p7 = "0";
                }
                string p9 = Convert.ToString(dsfinal.Tables[3].Rows[0]["p6"]);
                if (p9 == "")
                {
                    p9 = "0";
                }
                string p11 = Convert.ToString(dsfinal.Tables[4].Rows[0]["p7"]);
                if (p11 == "")
                {
                    p11 = "0";
                }
                string p13 = Convert.ToString(dsfinal.Tables[5].Rows[0]["p8"]);
                if (p13 == "")
                {
                    p13 = "0";
                }
                string p15 = Convert.ToString(dsfinal.Tables[6].Rows[0]["p9"]);
                if (p15 == "")
                {
                    p15 = "0";
                }
                string p17 = Convert.ToString(dsfinal.Tables[7].Rows[0]["p10"]);
                if (p17 == "")
                {
                    p17 = "0";
                }
                string p19 = Convert.ToString(dsfinal.Tables[8].Rows[0]["p11"]);
                if (p19 == "")
                {
                    p19 = "0";
                }
                string p21 = Convert.ToString(dsfinal.Tables[9].Rows[0]["p12"]);
                if (p21 == "")
                {
                    p21 = "0";
                }
                string p23 = Convert.ToString(dsfinal.Tables[10].Rows[0]["p13"]);
                if (p23 == "")
                {
                    p23 = "0";
                }
                string p25 = Convert.ToString(dsfinal.Tables[11].Rows[0]["p14"]);
                if (p25 == "")
                {
                    p25 = "0";
                }
                string p27 = Convert.ToString(dsfinal.Tables[12].Rows[0]["p15"]);
                if (p27 == "")
                {
                    p27 = "0";
                }



                r3 = Convert.ToInt32(p3);
                r5 = Convert.ToInt32(p5);
                r7 = Convert.ToInt32(p7);
                r9 = Convert.ToInt32(p9);
                r11 = Convert.ToInt32(p11);
                r13 = Convert.ToInt32(p13);
                r15 = Convert.ToInt32(p15);
                r17 = Convert.ToInt32(p17);
                r19 = Convert.ToInt32(p19);
                r21 = Convert.ToInt32(p21);
                r23 = Convert.ToInt32(p23);
                r25 = Convert.ToInt32(p25);
                r27 = Convert.ToInt32(p27);

            }

            string sql14 = "insert into CELevel1(sender_mobileno,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,send_date)values('" + userid + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + r25 + "','" + r27 + "','" + todaysDate + "')";
            int finaltotal = cc.ExecuteNonQuery(sql14);
            sql20 = "select usrMobileNo from usermaster where usrUserid='" + userid + "'";
            mobileno = cc.ExecuteScalar(sql20);
            string query4 = "select friendid from AdminSubMarketingSubUser where userid='" + userid + "'";
            string urfriend3 = cc.ExecuteScalar(query4);
            if (urfriend3 == "" || urfriend3 == null)
            {
            }
            else
            {
                //Msg to CE Level
                messagesend = "Dear user calulation of Junior is Data*P3=" + r3 + "*P4=" + r5 + "*P5=" + r7 + "*P6='" + r9 + "*P7=" + r11 + "*P8=" + r13 + "*P9=" + r15 + "*P10=" + r17 + "*p11=" + r19 + "*p12=" + r21 + "*p13=" + r23 + "*p14=" + r25 + "*p14=" + r27 + "*p15=" + r29 + " thanks via www.myct.in";
                // messagesend = "Dear user  calulation of Junior is Data*P3='" + r3 + "'*P5='" + r5 + "'*P7='" + r7 + "'*P9='" + r9 + "'*P11='" + r11 + "'*P13='" + r13 + "'*P15='" + r15 + "'*P17='" + r17 + "'*P19='" + r19 + "'*P21='" + r21 + "'*P23='" + r23 + "' thanks via www.myct.in";
                smslength = message.Length;
                cc.SendMessageMobileLongCodeSMS(mobileno, mobileno, messagesend, smslength);
            }





        }
        catch (Exception ex)
        { }

    }

    public int checkGroupSMSCode(string smsCode)
    {


        int flag = 0;
        try
        {

            char[] arr = smsCode.ToCharArray();
            int i = 0;
            while (i < arr.Length && arr.Length < 3)
            {
                if (arr[i] >= 48 && arr[i] <= 57)
                {
                    flag = 1;
                    i++;
                }
                else
                {
                    flag = 0;
                    break;
                }
            }

        }
        catch (Exception e)
        {
            flag = 0;
            return flag;
        }

        return flag;


    }
    private string Get(string url)
    {

        string text = "";
        List<string> myCollection = new List<string>();
        int a1;
        char character;
        string[] a = url.Split(',');

        for (int i = 0; i < a.Length; i++)
        {

            a1 = Convert.ToInt32(a[i]);
            //a1 = Convert.ToInt64(a[i]);
            character = (char)a1;
            text = character.ToString();
            myCollection.Add(text);
        }
        string resulr = String.Join("", myCollection.ToArray());
        return resulr;

    }


}