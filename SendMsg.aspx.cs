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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using ClassCommon;

using System.Text.RegularExpressions;

public partial class SendMsg : System.Web.UI.Page
{
    UserRegistrationBLL urRegistBll = new UserRegistrationBLL();

    int status;
     CommonCode cc = new CommonCode();
    Location ll = new Location();
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



    come2myschool.ConnectToCT scID = new come2myschool.ConnectToCT();

    // localhost.ConnectToCT sc = new localhost.ConnectToCT();
    public string nm = "", add = "", SchCode = "", emailID = "", uvaStr = "";    
    public static string remainMsg = "";
    public const string MatchEmailPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            numflag = false; emailFlag = false;

            string messageJM = "";
            string strMyUrl = System.Web.HttpContext.Current.Request.Url.ToString();
            string[] arrUrlSplt = strMyUrl.Split('&');
            if (arrUrlSplt.Length > 3)
            {

                string sstr2 = "http://www.come2mycity.com/sendMsg.aspx?message=";
                //string sstr2 = "http://localhost:1504/www.myct.in_25_01_2012/sendMsg.aspx?message=";
                int indCut = sstr2.Length;
                int ind1 = 0;
                ind1 = strMyUrl.IndexOf("&mobilenumber=");
                int ind2 = ind1 - indCut;
                message = strMyUrl.Substring(indCut, ind2);
            }
            else
            {
                message = Convert.ToString(Request.QueryString["message"]);
            }
            message = message.Replace('<', ' ');
            message = message.Replace('>', ' ');
            PinMessage = message;
            mobile = Convert.ToString(Request.QueryString["mobilenumber"]);
            shortcode = Convert.ToString(Request.QueryString["receivedon"]);
            string Data = "New";
            message = message.Replace("'", "sssss");
            message = message.Replace("&", "aaaaa");

            string Sql = "Insert into come2mycity.test(message, mobile, shortcode, data, SendDate) values " +
                " ('" + message + "','" + mobile + "','" + shortcode + "','" + Data + "','" + Convert.ToDateTime(shortcode).ToString("dd/MMM/yyyy") + "' )";
            int w = cc.ExecuteNonQuery(Sql);
            string NewSqlRecord = "Select PK from come2mycity.test where message='" + message + "' and mobile='" + mobile + "' and shortcode='" + shortcode + "' and data='" + Data + "'";
            string PK = cc.ExecuteScalar(NewSqlRecord);
            urRegistBll.usrPKval = Convert.ToInt32(PK);
            WholeMsg = message;

            if (message.StartsWith("*") || message.StartsWith(" "))
            {
                int id_rem = 1;
                foreach(char a in message.Trim().ToCharArray())
                {
                    if (a != ' ' && a != '*')
                    {
                        break;
                    }
                    else if (a == ' ' || a == '*')
                    {
                        message = message.Substring(id_rem, message.Length - id_rem);         //.Remove(id_rem);
                        id_rem++;
                    }
                }
            }

            if (message.StartsWith("*"))
            {
                message = message.Substring(1, message.Length - 1);         //.Remove(id_rem);
                message = message.Trim();
            }
            else
            {
                message = message.Trim();
            }            
          
            string[] StrSep = message.Split('*');
            string[] sp=new string[3];
            int index = 0, indexstart = 0;           

                            WholeMsg = message;
                            string str = StrSep[0].Trim();
                            index = 0;
                            index = UVACheck(str);
                            uvaStr = WholeMsg.Substring(indexstart, index);
                            remainMsg = WholeMsg.Substring(index, WholeMsg.Length - (index));

                            if (uvaStr.ToUpper().Trim() == "UVA")
                            {
                                PinMessage = remainMsg;                           
                                // mkeyword1 = uvaStr.Trim().ToUpper();

                                mKeyword = remainMsg.Split('*');              // mKeyword = message.Split('*');
                                string[] key1 = uvaStr.Split('*');
                                foreach (string k in key1)
                                {
                                    if (k != "")
                                        mkeyword1 = k.Trim();
                                }
                            }
                            else
                            {
                                //Uva murlidhar bhutada * chikhli * 11111 last trial
                                for (iii = 0; iii < 1; iii++)
                                {
                                    message = StrSep[iii].ToString();
                                    if (StrSep.Length > 1)
                                        messageJM = StrSep[iii + 1].ToString();

                                    mKeyword = message.Split(' ');
                                    if (mKeyword[0].ToString() != "")
                                    {
                                        mkeyword1 = mKeyword[0].ToUpper();
                                        //mkeyword1 = message.ToUpper();
                                    }
                                    else
                                    {
                                        mkeyword1 = mKeyword[1].ToUpper();
                                        //mkeyword1 = messageJM.ToUpper();
                                    }
                                }
                            }
               
            

            if (mkeyword1.Contains("Class") || mkeyword1.Contains("CLASS") || mkeyword1.Contains("Ab") || mkeyword1.Contains("AB") || mkeyword1.Contains("PR") || mkeyword1.Contains("Pr") || mkeyword1.Contains("Allstu") || mkeyword1.Contains("Allpar") || mkeyword1.Contains("ALLSTU") || mkeyword1.Contains("ALLPAR"))
            {
                schoolkeywords();
            }
            else if (mkeyword1.Contains("DM") || mkeyword1.Contains("dm") || mkeyword1.Contains("Dm") || mkeyword1.Contains("dM"))
            {
                colletorKeyword();

            }

            else
            {
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                urRegistBll.usrMobileNo = mobile;
                PinMobile = mobile;
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {

                    NormalKeyword();
                }
                else
                {
                    string s = "";
                    if (mkeyword1.Trim().ToUpper() == "UVA".Trim() || mkeyword1.Trim().ToUpper() == "YUVA".Trim())
                    {
                        s = mkeyword1; 
                    }
                    else { s = CheckNCP(WholeMsg); }

                    if (s == "NCP*" || s == "MPSC*" || s == "REG*" || s == "OM*" || s == "TTD*" || s == "ANNA*" || s == "RAVIDASSIA*" || s == "AGRO*" || s == "WSSD*" || s == "AMC*" || s == "DIDIMA*" || s == "DIDIMAA*" || s == "JAIN*" || s == "JANGID*" || s == "JB*" || s == "JM*" || s == "JNS*" || s == "MALI*" || s == "MHMSM*" || s == "MSS*" || s == "SAHU*" || s == "TELI*" || s.ToUpper().Trim() == "YUVA" || s.ToUpper().Trim() == "UVA")
                    {
                        RegisteredKeywordwithstar();
                    }
                    else if (s == "NCP " || s == "MPSC " || s == "REG " || s == "OM " || s == "TTD " || s == "ANNA " || s == "RAVIDASSIA " || s == "AGRO " || s == "WSSD " || s == "AMC " || s == "DIDIMA " || s == "DIDIMAA " || s == "JAIN " || s == "JANGID " || s == "JB " || s == "JM " || s == "JNS " || s == "MALI " || s == "MHMSM " || s == "MSS " || s == "SAHU " || s == "TELI " || s == "YUVA " || s == "UVA ")
                    {
                        //RegisteredKeywordwithstar1();          //temp
                    }
                    // string[] arrnew = PinMessage.Split(' ');
                    //if (arrnew[2].IndexOf('*') != -1)
                    //{

                    //}
                    //else if (PinMessage.IndexOf('*') != -1)
                    //{

                    //}
                    else
                    {

                        //RegisteredKeyword();            //temp
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static bool numflag = false, emailFlag = false;
    public string FormCode(string str)
    {
       
        int pinflag = 0, index1 = 0;        
        string[] space = str.Split(' ');
        for (int i = 0; i < space.Length; i++)
        {
            char[] pinsrch = space[i].ToCharArray();
            foreach (char a in pinsrch)
            {
                int ascii = a;
                if (ascii > 47 && ascii < 58 || ascii == 32)
                {
                    pinflag++;
                    if (pinflag == 5)
                    {
                        numflag = true;
                        index1 = i;                        
                    }
                    else if (pinflag > 5)
                    {
                        numflag = false;
                    }
                }
                else pinflag = 0;
            }
        }
        if (numflag == true)
        {
            SchCode = space[index1];
            //numflag = false;
            return SchCode;
        }
        else
            return "null";
    }

    public bool emailMsg(string str)
    {
        Regex regx = new Regex(MatchEmailPattern);
        
        if (regx.IsMatch(str))
        {
            //return str;
            return true;
        }
        else
        {
            //return "@";
            return false;
        }
    }


    public int UVACheck(string wholemsg)
    {
        string classNo = string.Empty;
        char[] strArr = wholemsg.ToCharArray();
        string s="";
        int i = 0;
        try
        {
            for (i = 0; i < 5; i++)
            {
                 //|| s.ToUpper().Trim() != "YUVA"
                if (s.ToUpper().Trim() != "UVA")
                {
                    if (strArr[i].ToString() != "")
                    {
                        classNo += strArr[i].ToString();
                        s += strArr[i];
                    }
                }
                else { break; }
            }
            
        }
        catch (Exception ex) { }
        finally
        {
           
        }
        return i;
    }

    private void GetRecord()
    {
        string sql20 = "";
        string mobileno = "";
        string messagesend = "";
        string id = "";

        DateTime date = DateTime.Now;
        string todaysDate = date.ToShortDateString();
        int r3 = 0, r5 = 0, r7 = 0;
        string senderid = "myct.in";
        string query = "select usrUserid from usermaster where usrMobileNo='" + mobile + "'";
        string userid = cc.ExecuteScalar(query);
        string sq1 = "select friendid from AdminSubMarketingSubUser where userid='" + userid + "'";
        DataSet ds = cc.ExecuteDataset(sq1);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            r3 = 0;
            r5 = 0;
            r7 = 0;
            string f1 = Convert.ToString(dr["friendid"]);
            string sql2 = "select friendid from AdminSubMarketingSubUser where userid='" + f1 + "'";
            DataSet ds2 = cc.ExecuteDataset(sql2);
            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                r3 = 0;
                r5 = 0;
                r7 = 0;
                string f2 = Convert.ToString(dr2["friendid"]);
                string sql3 = "select friendid from AdminSubMarketingSubUser where userid='" + f2 + "'";
                DataSet ds3 = cc.ExecuteDataset(sql3);
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    r3 = 0;
                    r5 = 0;
                    r7 = 0;
                    string f3 = Convert.ToString(dr3["friendid"]);
                    string sql4 = "select friendid from AdminSubMarketingSubUser where userid='" + f3 + "'";
                    DataSet ds4 = cc.ExecuteDataset(sql4);
                    foreach (DataRow dr4 in ds4.Tables[0].Rows)
                    {
                        string f4 = Convert.ToString(dr4["friendid"]);
                        string sql6 = "select * from DataCollection where sender_mobileno='" + f4 + "' and send_date='" + todaysDate + "'";
                        DataSet ds6 = cc.ExecuteDataset(sql6);
                        foreach (DataRow dr6 in ds6.Tables[0].Rows)
                        {
                            string sql5 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7 from DataCollection where sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                            DataSet ds5 = cc.ExecuteDataset(sql5);
                            foreach (DataRow dr5 in ds5.Tables[0].Rows)
                            {
                                int p3 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P3"]);
                                int p5 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P5"]);
                                int p7 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P7"]);
                                r3 = r3 + p3;
                                r5 = r5 + p5;
                                r7 = r7 + p7;


                            }


                        }



                    }

                    string sql7 = "insert into AELevel4(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f3 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + f2 + "','" + todaysDate + "')";
                    int a = cc.ExecuteNonQuery(sql7);
                    sql20 = "select usrMobileNo from usermaster where usrUserid='" + f3 + "'";
                    mobileno = cc.ExecuteScalar(sql20);
                    messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
                    //cc.SendMessageTra(senderid, mobileno, messagesend);

                    string sql131 = "select * from DataCollection where sender_mobileno='" + f3 + "' and send_date='" + todaysDate + "'";
                    DataSet ds141 = cc.ExecuteDataset(sql131);
                    foreach (DataRow dr14 in ds141.Tables[0].Rows)
                    {
                        int p3 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P3"]);
                        int p5 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P5"]);
                        int p7 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P7"]);

                        string sql141 = "insert into AELevel4(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f3 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + f2 + "','" + todaysDate + "')";
                        int aa1 = cc.ExecuteNonQuery(sql141);

                    }

                }
                ////////////////Finish calculation of JE and insert into AE or End of JE/////////////////////

                string sql19 = "select * from AELevel4 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                DataSet ds19 = cc.ExecuteDataset(sql19);
                foreach (DataRow dr19 in ds19.Tables[0].Rows)
                {
                    id = Convert.ToString(dr19["sender_mobileno"]);
                    string sql8 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7  from AELevel4 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                    DataSet ds7 = cc.ExecuteDataset(sql8);
                    foreach (DataRow dr7 in ds7.Tables[0].Rows)
                    {
                        r3 = 0;
                        r5 = 0;
                        r7 = 0;
                        int p3 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P3"]);
                        int p5 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P5"]);
                        int p7 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P7"]);
                        r3 = r3 + p3;
                        r5 = r5 + p5;
                        r7 = r7 + p7;
                    }

                }

                string sql10 = "insert into EELevel3(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f2 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + f1 + "','" + todaysDate + "')";
                int c = cc.ExecuteNonQuery(sql10);
                sql20 = "select usrMobileNo from usermaster where usrUserid='" + f2 + "'";
                mobileno = cc.ExecuteScalar(sql20);
                messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
                //cc.SendMessageTra(senderid, mobileno, messagesend);
                string sql1311 = "select * from DataCollection where sender_mobileno='" + f2 + "' and send_date='" + todaysDate + "'";
                DataSet ds1411 = cc.ExecuteDataset(sql1311);
                foreach (DataRow dr141 in ds1411.Tables[0].Rows)
                {
                    int p3 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P3"]);
                    int p5 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P5"]);
                    int p7 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P7"]);

                    string sql141 = "insert into EELevel3(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f2 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + f1 + "','" + todaysDate + "')";
                    int aa1 = cc.ExecuteNonQuery(sql141);
                }



            }
            ///////////////////End of EE//////////////////////////////
            string sql12 = "select * from EELevel3 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
            DataSet ds13 = cc.ExecuteDataset(sql12);
            foreach (DataRow dr12 in ds13.Tables[0].Rows)
            {
                id = Convert.ToString(dr12["sender_mobileno"]);
                string sql11 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7  from EELevel3 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                DataSet ds11 = cc.ExecuteDataset(sql11);
                foreach (DataRow dr11 in ds11.Tables[0].Rows)
                {
                    r3 = 0;
                    r5 = 0;
                    r7 = 0;
                    int p3 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P3"]);
                    int p5 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P5"]);
                    int p7 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P7"]);
                    r3 = r3 + p3;
                    r5 = r5 + p5;
                    r7 = r7 + p7;
                }
            }

            string sql9 = "insert into SELevel2(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f1 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + userid + "','" + todaysDate + "')";
            int d = cc.ExecuteNonQuery(sql9);
            sql20 = "select usrMobileNo from usermaster where usrUserid='" + f1 + "'";
            mobileno = cc.ExecuteScalar(sql20);
            messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
            //cc.SendMessageTra(senderid, mobileno, messagesend);
            string sql13112 = "select * from DataCollection where sender_mobileno='" + f1 + "' and send_date='" + todaysDate + "'";
            DataSet ds14112 = cc.ExecuteDataset(sql13112);
            foreach (DataRow dr141 in ds14112.Tables[0].Rows)
            {
                int p3 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P3"]);
                int p5 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P5"]);
                int p7 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P7"]);

                string sql141 = "insert into SELevel2(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f1 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + userid + "','" + todaysDate + "')";
                int aa1 = cc.ExecuteNonQuery(sql141);

            }

        }
        string sql16 = "select * from DataCollection where sender_mobileno='" + userid + "' and send_date='" + todaysDate + "'";
        DataSet ds16 = cc.ExecuteDataset(sql16);
        foreach (DataRow dr16 in ds16.Tables[0].Rows)
        {
            int p3 = Convert.ToInt32(ds16.Tables[0].Rows[0]["P3"]);
            int p5 = Convert.ToInt32(ds16.Tables[0].Rows[0]["P5"]);
            int p7 = Convert.ToInt32(ds16.Tables[0].Rows[0]["P7"]);
            string sql141 = "insert into SELevel2(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + userid + "','" + p3 + "','" + p5 + "','" + p7 + "','" + userid + "','" + todaysDate + "')";
            int aa1 = cc.ExecuteNonQuery(sql141);


        }

        /////////////////////////////////End of SE//////////////////////

        string sql13 = "select * from SELevel2 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
        DataSet ds14 = cc.ExecuteDataset(sql13);
        foreach (DataRow dr13 in ds14.Tables[0].Rows)
        {
            id = Convert.ToString(dr13["sender_mobileno"]);
            string sqlfinal = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7  from SELevel2 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
            DataSet dsfinal = cc.ExecuteDataset(sqlfinal);
            int p3 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P3"]);
            int p5 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P5"]);
            int p7 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P7"]);
            r3 = p3;
            r5 = p5;
            r7 = p7;

        }

        string sql14 = "insert into CELevel1(sender_mobileno,P3,P5,P7,send_date)values('" + userid + "','" + r3 + "','" + r5 + "','" + r7 + "','" + todaysDate + "')";
        int finaltotal = cc.ExecuteNonQuery(sql14);
        sql20 = "select usrMobileNo from usermaster where usrUserid='" + userid + "'";
        mobileno = cc.ExecuteScalar(sql20);
        messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
        cc.SendMessageTra(senderid, mobileno, messagesend);




    }

    private void updateMsg(string Message)
    {
        try
        {

            string userid = "", simno = "";
            string senderid = "myctin";
            string sql = "select usruserid,Sim_no from LongCodeRegistration where mobileno='" + mobile + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                userid = Convert.ToString(ds.Tables[0].Rows[0]["usruserid"]);
                simno = Convert.ToString(ds.Tables[0].Rows[0]["Sim_no"]);
            }
            if (userid != "")
            {
                string sql1 = "update MiscalResponse set Msg_Status='Deactive' where userid='" + userid + "'";
                string b = cc.ExecuteScalar(sql1);
                string Msg_Status = "Active";
                DateTime date = DateTime.Now;
                string sql2 = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status)values('" + userid + "','" + mobile + "','" + Message + "','" + date + "','" + Msg_Status + "')";
                string a = cc.ExecuteScalar(sql2);
                string response = "Dear User Message inserted successfully and this Message is Active thanks via www.myct.in";
                cc.SendMessageTra(senderid, mobile, response);

            }
            else
            {
                string resp = "Dear User You cannot insert Message thanks via www.myct.in";
                cc.SendMessageTra(senderid, mobile, resp);
            }


        }
        catch (Exception ex)
        { }
    }


    public string CheckNCP(string mkeyword1)
    {
        mkeyword1 = mkeyword1.ToUpper();
        string classNo = string.Empty;
        char[] strArr = mkeyword1.ToCharArray();
        string s = string.Empty;

        for (int i = 0; i < strArr.Length; i++)
        {

            if (i <= 15)
            {
                if (strArr[i].ToString() != "")
                    // classNo += strArr[i].ToString();
                    s += strArr[i].ToString();
            }
            else
            {
                break;
            }
            if (s == "NCP*" || s == "MPSC*" || s == "REG*" || s == "OM*" || s == "TTD*" || s == "ANNA*" || s == "RAVIDASSIA*" || s == "AGRO*" || s == "WSSD*" || s == "AMC*" || s == "DIDIMA*" || s == "DIDIMAA*" || s == "JAIN*" || s == "JANGID*" || s == "JB*" || s == "JM*" || s == "JNS*" || s == "MALI*" || s == "MHMSM*" || s == "MSS*" || s == "SAHU*" || s == "TELI*")
            {
                break;
            }
            else if (s == "NCP " || s == "MPSC " || s == "REG " || s == "OM " || s == "TTD " || s == "ANNA " || s == "RAVIDASSIA " || s == "AGRO " || s == "WSSD " || s == "AMC " || s == "DIDIMA " || s == "DIDIMAA " || s == "JAIN " || s == "JANGID " || s == "JB " || s == "JM " || s == "JNS " || s == "MALI " || s == "MHMSM " || s == "MSS " || s == "SAHU " || s == "TELI ")
            {
                break;
            }
            else if (s == "*YUVA" || s == "*UVA")
            {
                break;
            }
        }
        return s;
    }
    public string CheckLokmat(string mkeyword1)
    {
        string classNo = string.Empty;
        char[] strArr = mkeyword1.ToCharArray();
        string s = string.Empty;

        for (int i = 0; i < strArr.Length; i++)
        {

            if (i <= 15)
            {
                if (strArr[i].ToString() != "")
                    // classNo += strArr[i].ToString();
                    s += strArr[i].ToString();
            }
            else
            {
                break;
            }
            if ((s == "LOKMAT*" || s == "MATA*" || s == "DESHONNATI*" || s == "NBP*" || s == "SAKAL*" || s == "YUVANXT*"))
            {
                break;
            }
            else if ((s == "LOKMAT " || s == "MATA " || s == "DESHONNATI " || s == "NBP " || s == "SAKAL " || s == "YUVANXT "))
            {
                break;
            }
        }
        return s;
    }
    public string CheckChar(string mkeyword1)
    {
        string classNo = string.Empty;
        char[] strArr = mkeyword1.ToCharArray();
        for (int i = 0; i < strArr.Length; i++)
        {
            if (i <= 1)
            {
                if (strArr[i].ToString() != "")
                    classNo += strArr[i].ToString();
            }
            else
            {
                break;
            }
        }
        return classNo;
    }

    public void colletorKeyword()
    {
        try
        {
            Pinmsg1 = WholeMsg;
            string complaintmessage = Pinmsg1.Substring(2);
            if (mobile.Length > 10)
                mobile = mobile.Substring(2);
        }
        catch { }
    }
    //All come2myschool keyword
    public void schoolkeywords()
    {

        try
        {

            Pinmsg1 = WholeMsg.Replace(mkeyword1 + " ", " ");
            string s = CheckChar(WholeMsg);


            if (s == "Ab" || s == "AB")
            {

                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSms(ID, mobile, Pinmsg1, dt);
            }
            else if (s == "Pr" || s == "PR")
            {
                Pinmsg1 = WholeMsg;
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSms(ID, mobile, Pinmsg1, dt);
            }
            else if (mkeyword1 == "Allstu" || mkeyword1 == "ALLSTU")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");

                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonMobile(ID, mobile, Pinmsg1, dt, mkeyword1);
            }
            else if (mkeyword1 == "Allpar" || mkeyword1 == "ALLPAR")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonMobile(ID1, mobile, Pinmsg1, dt, mkeyword1);


            }
            else if (mkeyword1 == "Class1" || mkeyword1 == "CLASS1")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                //  mobile="9970574255";
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

                //scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class2" || mkeyword1 == "CLASS2")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class3" || mkeyword1 == "CLASS3")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class4" || mkeyword1 == "CLASS4")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class5" || mkeyword1 == "CLASS5")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class6" || mkeyword1 == "CLASS6")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class7" || mkeyword1 == "CLASS7")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class8" || mkeyword1 == "CLASS8")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class9" || mkeyword1 == "CLASS9")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class10" || mkeyword1 == "CLASS10")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class11" || mkeyword1 == "CLASS11")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class12" || mkeyword1 == "CLASS12")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class13" || mkeyword1 == "CLASS13")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class14" || mkeyword1 == "CLASS14")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class15" || mkeyword1 == "CLASS15")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class16" || mkeyword1 == "CLASS16")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class17" || mkeyword1 == "CLASS17")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class18" || mkeyword1 == "CLASS18")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class19" || mkeyword1 == "CLASS19")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }
            else if (mkeyword1 == "Class20" || mkeyword1 == "CLASS20")
            {
                Pinmsg1 = WholeMsg.Replace(WholeMsg.Split(' ')[0].ToString() + " ", " ");
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + mobile + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string ID1 = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);

                string dt = shortcode;
                scID.getLongCodeSmsCommonClass(ID1, mobile, Pinmsg1, dt, mkeyword1);

            }

            else
            { }





        }

        catch (Exception ex)
        {
        }
    }
    public string ClassCheck(string wholemsg)
    {
        string classNo = string.Empty;
        char[] strArr = wholemsg.ToCharArray();
        for (int i = 6; i < strArr.Length; i++)
        {
            if (strArr[i].ToString() != "")
                classNo += strArr[i].ToString();
        }
        return classNo;
    }

    public void RegisteredKeywordwithstar()
    {
        try
        {
            ///////////////////////////////////////////REG*Pooja k*Pune*411037//////////////////////////
            if (mkeyword1.Contains("Reg") || mkeyword1.Contains("reg") || mkeyword1.Contains("REG"))
            {
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split('*');
                //string keyword = arr[0];
                //a = arr[1];
                //b = arr[2];
                //c = arr[3];
                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = a;
                //urRegistBll.usrLastName = b;
                //urRegistBll.usrCityId = 37;
                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;
                //    string myName = urRegistBll.usrFirstName;
                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");
                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");
                //        }
                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                string senderId = "COM2MYCT";
                try
                {
                    string fname = "", mname = "", lname = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    string keyword = mmsg[0];
                    string[] namesplit = mmsg[1].Split(' ');
                    int namelength = namesplit.Length;
                    if (namelength > 2)
                    {
                        fname = namesplit[0];
                        mname = namesplit[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = namesplit[2];

                    }
                    else if (namelength > 1)
                    {
                        fname = namesplit[0];
                        lname = namesplit[1];
                    }
                    else
                    {
                    }
                    string address = mmsg[2];
                    string pincode = mmsg[3];
                    string emailid = mmsg[4];
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrPIN = pincode;
                    urRegistBll.usrFirstName = fname;
                    urRegistBll.usrLastName = lname;
                    urRegistBll.usrEmailId = emailid;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax REG*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);

                }
                //        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //        int pkchange = 0;
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //        if (pkchange == 0)
                //        {
                //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //        }
                //    }
                //}
            }

                //////////////////////////////////////////////////////*YUVA*Pooja k* 5digit*Pune//////////////////////////////////////
                //if mob not registered
            else if (mkeyword1.Trim().ToUpper().Equals("YUVA") || mkeyword1.Trim().ToUpper().Equals("UVA"))
            {
                string senderId = "COM2MYCT";
                try
                {
                   string fname = "", mname = "", lname = "";
                   string[] nm = new string[5];
                    string memberName = "", schoolcode = "", email = "", memberAddress = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string Mobile = mobile.ToString();
                    string[] mmsg = PinMessage.Split('*');

                    foreach (string str in mmsg)
                    {
                        if (str != "" && str != " " && memberName.Trim() == "")
                        {
                            memberName = str;

                            //if (memberName.Contains('.'))
                            //{
                            //    nm = memberName.Split('.');
                            //}
                            //else
                            //{
                            //    nm = memberName.Split(' ');
                            //}

                            //if (nm.Length > 3)
                            //{
                            //    if (nm[0].ToString() != "")
                            //        fname = nm[0].ToString();
                            //    else
                            //        fname = nm[1].ToString();
                            //    if (nm[1].ToString() != "" && nm[1].ToString() != fname)
                            //    mname = nm[2].ToString();
                            //    lname = nm[2].ToString();
                            //}

                            //else if (nm.Length < 3 && nm.Length > 2)
                            //{
                            //    fname = nm[0].ToString();                                
                            //    lname = nm[1].ToString();
                            //}
                            //else if (nm.Length == 1)
                            //{
                            //    fname = nm[0].ToString();
                            //}
                            break;
                        }
                    }

                    foreach (string str in mmsg)
                    {
                        if (str != "" && str != " " && memberName.Trim() != "")
                        {
                            schoolcode = FormCode(str);
                            if (numflag == true)
                                break;
                        }
                    }

                    foreach (string str in mmsg)
                    {
                        if (str != "" && str != " " && memberName.Trim() != "")
                        {
                            if (emailMsg(str) == true)
                            {
                                email = str;
                                break;
                            }
                        }
                    }

                    foreach (string str in mmsg)
                    {
                        if (str != "" && str != " " && memberName.Trim() != str.Trim() && schoolcode.Trim() != str.Trim() && email.Trim() != str.Trim())
                        {
                            memberAddress = str;
                            break;
                        }
                    }

                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;

                    urRegistBll.usrFirstName = memberName;
                    //urRegistBll.usrLastName = lname;
                    //urRegistBll.usrMiddleName = mname;

                    urRegistBll.usrAddress = memberAddress;
                    urRegistBll.usrEmailId = email;
                    

     //////////////               ////////////////////////////////////////////////////////////
                    //string fname = "", mname = "", lname = "";
                    //mkeyword1 = mkeyword1.ToUpper();
                    //string[] mmsg = PinMessage.Split('*');
                    
                    //string keyword = mmsg[1];
                    //string[] namesplit = mmsg[2].Split(' ');
                    //int namelength = namesplit.Length;
                    //if (namelength > 2)
                    //{
                    //    fname = namesplit[0];
                    //    mname = namesplit[1];
                    //    urRegistBll.usrMiddleName = mname;
                    //    lname = namesplit[2];

                    //}
                    //else if (namelength > 1)
                    //{
                    //    fname = namesplit[0];
                    //    lname = namesplit[1];
                    //}
                    //else
                    //{
                    //}
                    //string schoolcode = mmsg[3];
                    //string address = mmsg[4];

                    //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    //urRegistBll.usrMobileNo = mobile;

                    //urRegistBll.usrFirstName = fname;
                    //urRegistBll.usrLastName = lname;


//////////////////////////////////////////////////////////////change util here///////

                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {

                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        // string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "Dear std thanks to join uva jagar Pl register on www.mitsc.co.in with ur Mob No & Pswd " + myPassword + " fr all courses.Use same pswd to update u via www.myct.in fr jobs";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        string sqlinsert = "insert into collegecode(userid,collegecode)values('" + urRegistBll.usrUserId + "','" + schoolcode + "')";
                        string a = cc.ExecuteScalar(sqlinsert);
                        if (mkeyword1 == "YUVA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',93)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "UVA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',93)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                               ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                //int pkchange = 0;
                                //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                //if (pkchange == 0)
                                //{
                                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                //}
                            }
                        }
                        else
                        {
                            try
                            {

                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (mkeyword1 == "YUVA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax *YUVA*FirstName LastName*SchoolCode*Address Thanks Via www.myct.in";
                             cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "UVA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax *UVA*FirstName LastName*SchoolCode*Address Thanks Via www.myct.in";
                           cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }

                }



            }

            ////////////////////////////////////////////////////////OM*Pooja k*Pune*411037//////////////////////////////////////////////////////
            else if (mkeyword1.Contains("Om") || mkeyword1.Contains("om") || mkeyword1.Contains("OM") || mkeyword1.Contains("TTD") || mkeyword1.Contains("Ttd"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split('*');
                //string keyword = arr[0];
                //a = arr[1];
                //b = arr[2];
                //c = arr[3];
                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = a;
                //urRegistBll.usrLastName = b;
                //urRegistBll.usrCityId = 37;
                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;
                //    string myName = urRegistBll.usrFirstName;
                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");
                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");
                //        }
                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                string senderId = "COM2MYCT";
                try
                {
                    string fname = "", mname = "", lname = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    string keyword = mmsg[0];
                    string[] namesplit = mmsg[1].Split(' ');
                    int namelength = namesplit.Length;
                    if (namelength > 2)
                    {
                        fname = namesplit[0];
                        mname = namesplit[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = namesplit[2];

                    }
                    else if (namelength > 1)
                    {
                        fname = namesplit[0];
                        lname = namesplit[1];
                    }
                    else
                    {
                    }
                    string address = mmsg[2];
                    string pincode = mmsg[3];
                    string emailid = mmsg[4];
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrPIN = pincode;
                    urRegistBll.usrFirstName = fname;
                    urRegistBll.usrLastName = lname;
                    urRegistBll.usrEmailId = emailid;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "OM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',34)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TTD")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',79)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {

                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    if (mkeyword1 == "OM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax OM*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "TTD")
                    {
                        string NewSmsResp = "Dear User,Use Syntax TTD*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }

                }

                //        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //        int pkchange = 0;
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //        if (pkchange == 0)
                //        {
                //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //        }

                //    }
                //}

            }
            //////////////////////////////////////////ANNA*Pooja k*Pune*411037/////////////////////////////////////////////////////
            else if (mkeyword1.Contains("ANNA") || mkeyword1.Contains("Anna") || mkeyword1.Contains("anna"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split('*');
                //string keyword = arr[0];
                //a = arr[1];
                //b = arr[2];
                //c = arr[3];
                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = a;
                //urRegistBll.usrLastName = b;
                //urRegistBll.usrCityId = 37;

                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;
                //    string myName = urRegistBll.usrFirstName;
                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");
                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");
                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                string senderId = "COM2MYCT";
                try
                {
                    string fname = "", mname = "", lname = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    string keyword = mmsg[0];
                    string[] namesplit = mmsg[1].Split(' ');
                    int namelength = namesplit.Length;
                    if (namelength > 2)
                    {
                        fname = namesplit[0];
                        mname = namesplit[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = namesplit[2];

                    }
                    else if (namelength > 1)
                    {
                        fname = namesplit[0];
                        lname = namesplit[1];
                    }
                    else
                    {
                    }
                    string address = mmsg[2];
                    string pincode = mmsg[3];
                    string emailid = mmsg[4];
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrPIN = pincode;
                    urRegistBll.usrFirstName = fname;
                    urRegistBll.usrLastName = lname;
                    urRegistBll.usrEmailId = emailid;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "ANNA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',9)";
                            string a1 = cc.ExecuteScalar(sql);
                        }

                        //        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //        int pkchange = 0;
                        //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //        if (pkchange == 0)
                        //        {
                        //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //        }

                        //    }
                        //}
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch
                            { }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax ANNA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);

                }

            }
            ///////////////////////////////////NCP*Pooja K*Pune*411037////////////////////
            else if (mkeyword1.Contains("NCP") || mkeyword1.Contains("Ncp") || mkeyword1.Contains("ncp"))
            {
                string senderId = "COM2MYCT";
                try
                {
                    string fname = "", mname = "", lname = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    string keyword = mmsg[0];
                    string[] namesplit = mmsg[1].Split(' ');
                    int namelength = namesplit.Length;
                    if (namelength > 2)
                    {
                        fname = namesplit[0];
                        mname = namesplit[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = namesplit[2];

                    }
                    else if (namelength > 1)
                    {
                        fname = namesplit[0];
                        lname = namesplit[1];
                    }
                    else
                    {
                    }
                    string address = mmsg[2];
                    string pincode = mmsg[3];
                    string emailid = mmsg[4];
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrPIN = pincode;
                    urRegistBll.usrFirstName = fname;
                    urRegistBll.usrLastName = lname;
                    urRegistBll.usrEmailId = emailid;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            { }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }

                            }

                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax NCP*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);

                }

            }
            //////////////////////////////////////MPSC*Pooja K*Pune*411037//////////////////////////////////////////
            else if (mkeyword1.Contains("MPSC") || mkeyword1.Contains("Mpsc") || mkeyword1.Contains("mpsc"))
            {
                string senderId = "COM2MYCT";
                try
                {
                    string fname = "", mname = "", lname = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    string keyword = mmsg[0];
                    string[] namesplit = mmsg[1].Split(' ');
                    int namelength = namesplit.Length;
                    if (namelength > 2)
                    {
                        fname = namesplit[0];
                        mname = namesplit[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = namesplit[2];

                    }
                    else if (namelength > 1)
                    {
                        fname = namesplit[0];
                        lname = namesplit[1];
                    }
                    else
                    {
                    }
                    string address = mmsg[2];
                    string pincode = mmsg[3];
                    string emailid = mmsg[4];
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrPIN = pincode;
                    urRegistBll.usrFirstName = fname;
                    urRegistBll.usrLastName = lname;
                    urRegistBll.usrEmailId = emailid;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/MPSC.aspx?crtevnt http://www.myct.in/MPSC.aspx?ict http://www.myct.in/MPSC.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            { }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }

                            }

                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax MPSC*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);

                }

            }
            //////////////////////////////////RAVIDASSIA*Pooja k*Pune*411037////////////////////////////////////////////////
            else if (mkeyword1.Contains("RAVIDASSIA") || mkeyword1.Contains("Ravidassia") || mkeyword1.Contains("ravidassia"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split('*');
                //string keyword = arr[0];
                //a = arr[1];
                //b = arr[2];
                //c = arr[3];
                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = a;
                //urRegistBll.usrLastName = b;
                //urRegistBll.usrCityId = 37;
                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;
                //    string myName = urRegistBll.usrFirstName;
                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);

                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                string senderId = "COM2MYCT";
                try
                {
                    string fname = "", mname = "", lname = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    string keyword = mmsg[0];
                    string[] namesplit = mmsg[1].Split(' ');
                    int namelength = namesplit.Length;
                    if (namelength > 2)
                    {
                        fname = namesplit[0];
                        mname = namesplit[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = namesplit[2];

                    }
                    else if (namelength > 1)
                    {
                        fname = namesplit[0];
                        lname = namesplit[1];
                    }
                    else
                    {
                    }
                    string address = mmsg[2];
                    string pincode = mmsg[3];
                    string emailid = mmsg[4];
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrPIN = pincode;
                    urRegistBll.usrFirstName = fname;
                    urRegistBll.usrLastName = lname;
                    urRegistBll.usrEmailId = emailid;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "RAVIDASSIA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                            string a1 = cc.ExecuteScalar(sql);
                        }

                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax RAVIDASSIA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);

                }
                //        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //        int pkchange = 0;
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //        if (pkchange == 0)
                //        {
                //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //        }

                //    }
                //}
            }
            //////////////////////////////////////////////////////////////////AGRO*Pooja k*Pune*411037////////////////////////////////////////////

            else if (mkeyword1.Contains("AGRO") || mkeyword1.Contains("WSSD") || mkeyword1.Contains("Agro") || mkeyword1.Contains("agro") || mkeyword1.Contains("AMC") || mkeyword1.Contains("Amc") || mkeyword1.Contains("amc") || mkeyword1.Contains("DIDIMA") || mkeyword1.Contains("Didima") || mkeyword1.Contains("didima") || mkeyword1.Contains("DIDIMAA") || mkeyword1.Contains("Didimaa") || mkeyword1.Contains("didimaa") || mkeyword1.Contains("JAIN") || mkeyword1.Contains("jain") || mkeyword1.Contains("Jain") || mkeyword1.Contains("JANGID") || mkeyword1.Contains("Jangid") || mkeyword1.Contains("jangid") || mkeyword1.Contains("JB") || mkeyword1.Contains("jb") || mkeyword1.Contains("Jb") || mkeyword1.Contains("JM") || mkeyword1.Contains("Jm") || mkeyword1.Contains("jm") || mkeyword1.Contains("JNS") || mkeyword1.Contains("Jns") || mkeyword1.Contains("jns") || mkeyword1.Contains("MALI") || mkeyword1.Contains("Mali") || mkeyword1.Contains("mali") || mkeyword1.Contains("MHMSM") || mkeyword1.Contains("Mhmsm") || mkeyword1.Contains("mhmsm") || mkeyword1.Contains("MSS") || mkeyword1.Contains("Mss") || mkeyword1.Contains("mss") || mkeyword1.Contains("SAHU") || mkeyword1.Contains("Sahu") || mkeyword1.Contains("sahu") || mkeyword1.Contains("TELI") || mkeyword1.Contains("Teli") || mkeyword1.Contains("teli"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split('*');
                //string keyword = arr[0];
                //a = arr[1];
                //b = arr[2];
                //c = arr[3];

                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = a;
                //urRegistBll.usrLastName = b;
                //urRegistBll.usrCityId = 37;

                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;
                //    string myName = urRegistBll.usrFirstName;
                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)      
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        if (mkeyword1 == "JM" || mkeyword1 == "jm")
                //            mkeyword1 = "Maheshwari";
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                string senderId = "COM2MYCT";
                try
                {
                    string fname = "", mname = "", lname = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    string keyword = mmsg[0];
                    string[] namesplit = mmsg[1].Split(' ');
                    int namelength = namesplit.Length;
                    if (namelength > 2)
                    {
                        fname = namesplit[0];
                        mname = namesplit[1];
                        urRegistBll.usrMiddleName = mname;
                        lname = namesplit[2];

                    }
                    else if (namelength > 1)
                    {
                        fname = namesplit[0];
                        lname = namesplit[1];
                    }
                    else
                    {
                    }
                    string address = mmsg[2];
                    string pincode = mmsg[3];
                    string emailid = mmsg[4];
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrPIN = pincode;
                    urRegistBll.usrFirstName = fname;
                    urRegistBll.usrLastName = lname;
                    urRegistBll.usrEmailId = emailid;
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "DIDIMA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',66)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        //else if (mkeyword1 == "AGRO")
                        //{
                        //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                        //    string a1 = cc.ExecuteScalar(sql);
                        //}
                        //else if (mkeyword1 == "WSSD")
                        //{
                        //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                        //    string a1 = cc.ExecuteScalar(sql);
                        //}
                        //else if (mkeyword1 == "AMC")
                        //{
                        //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                        //    string a1 = cc.ExecuteScalar(sql);
                        //}

                        else if (mkeyword1 == "DIDIMAA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',77)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JAIN")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',28)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JANGID")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',31)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JB")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',38)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',22)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JNS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',25)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MALI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',32)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MHMSM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',30)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MSS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',29)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "SAHU")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',41)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TELI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',39)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }

                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }

                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    if (mkeyword1 == "DIDIMA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax DIDIMA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "AGRO")
                    {
                        string NewSmsResp = "Dear User,Use Syntax AGRO*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "WSSD")
                    {
                        string NewSmsResp = "Dear User,Use Syntax WSSD*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "AMC")
                    {
                        string NewSmsResp = "Dear User,Use Syntax AMC*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "DIDIMAA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax DIDIMAA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JAIN")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JAIN*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JANGID")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JANGID*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JB")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JB*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JM*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JNS")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JNS*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "MALI")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MALI*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "MHMSM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MHMSM*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "MSS")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MSS*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "SAHU")
                    {
                        string NewSmsResp = "Dear User,Use Syntax SAHU*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "TELI")
                    {
                        string NewSmsResp = "Dear User,Use Syntax TELI*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else
                    {
                    }


                }
            }
            //            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            //            int pkchange = 0;
            //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            if (pkchange == 0)
            //            {
            //                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            }

            //        }
            //    }
            //}

        }

        catch { }
    }
    /// <summary>
    /// /////////////////////////////////////////End of Keyword*Name*Address*Pincode////////////////////////////////////////////////
    /// </summary>
    public void RegisteredKeywordwithstar1()
    {
        try
        {
            ///////////////////////////////////////REG Pooja k*Pune*41037/////////////////////////////////////
            if (mkeyword1.Contains("Reg") || mkeyword1.Contains("reg") || mkeyword1.Contains("REG"))
            {
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split(' ');
                //aa = arr[1];
                //bb = arr[2];
                //arr1 = Pinmsg1.Split('*');
                //b = arr1[1];
                //c = arr1[2];
                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = aa;
                //urRegistBll.usrLastName = bb;
                //urRegistBll.usrCityId = 37;

                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;

                //    string myName = urRegistBll.usrFirstName;


                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);


                //        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                string senderId = "COM2MYCT";

                try
                {

                    string fname = "", mname = "", lname = "", address = "", pincode = "", emailid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    int pinmessagelength = mmsg.Length;
                    if (pinmessagelength > 3)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = mmsg[3];
                        urRegistBll.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urRegistBll.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urRegistBll.usrMiddleName = mname;
                        lname = mmsg1[3];
                    }
                    else if (namelength > 2)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        lname = mmsg1[2];
                    }
                    else if (namelength > 1)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                    }
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
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
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);

                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {

                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax REG FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                 // comment by me   cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }

            //            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            //            int pkchange = 0;
            //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            if (pkchange == 0)
            //            {
            //                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            }

            //        }
            //    }
            //}

//////////////////////////////////////////////////////////////////////OM Pooja k*Pune*41037/////////////////////////////////////
            else if (mkeyword1.Contains("Om") || mkeyword1.Contains("om") || mkeyword1.Contains("OM") || mkeyword1.Contains("TTD") || mkeyword1.Contains("Ttd"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split(' ');
                //aa = arr[1];
                //bb = arr[2];
                //arr1 = Pinmsg1.Split('*');

                //b = arr1[1];
                //c = arr1[2];

                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = aa;
                //urRegistBll.usrLastName = bb;
                //urRegistBll.usrCityId = 37;

                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;

                //    string myName = urRegistBll.usrFirstName;


                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);

                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);

                string senderId = "COM2MYCT";

                try
                {

                    string fname = "", mname = "", lname = "", address = "", pincode = "", emailid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    int pinmessagelength = mmsg.Length;
                    if (pinmessagelength > 3)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = mmsg[3];
                        urRegistBll.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urRegistBll.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    //int namelength = mmsg[0].Length;
                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urRegistBll.usrMiddleName = mname;
                        lname = mmsg1[3];
                    }
                    else if (namelength > 2)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        lname = mmsg1[2];
                    }
                    else if (namelength > 1)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                    }
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
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
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                       //Commented by me cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "OM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',34)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TTD")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',79)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }

                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    if (mkeyword1 == "OM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax OM FirstName*LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "TTD")
                    {
                        string NewSmsResp = "Dear User,Use Syntax TTD FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                }


            }

            //            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            //            int pkchange = 0;
            //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            if (pkchange == 0)
            //            {
            //                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            }

            //        }
            //    }
            //}
            ////////////////////////////////////////////NCP Pooja*Pune*411037//////////////////////////////////////////////////////////////////////////
            else if (mkeyword1.Contains("NCP") || mkeyword1.Contains("Ncp") || mkeyword1.Contains("ncp"))
            {
                string senderId = "COM2MYCT";

                try
                {

                    string fname = "", mname = "", lname = "", address = "", pincode = "", emailid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    int pinmessagelength = mmsg.Length;
                    if (pinmessagelength > 3)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = mmsg[3];
                        urRegistBll.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urRegistBll.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');

                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urRegistBll.usrMiddleName = mname;
                        lname = mmsg1[3];
                    }
                    else if (namelength > 2)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        lname = mmsg1[2];
                    }
                    else if (namelength > 1)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                    }
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
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
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {

                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {


                            }
                            finally
                            {
                                string changeFlagSql = "";
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }

                        }

                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                string changeFlagSql = "";
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }

                        }

                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax NCP FirstName LastName*Address*Pincode*Emailid Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }
            ////////////////////////////MPSC Pooja k*Pune*411037//////////////////////////////////////////////////////////////////////////////
            else if (mkeyword1.Contains("MPSC") || mkeyword1.Contains("Mpsc") || mkeyword1.Contains("mpsc"))
            {
                string senderId = "COM2MYCT";

                try
                {

                    string fname = "", mname = "", lname = "", address = "", pincode = "", emailid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    int pinmessagelength = mmsg.Length;
                    if (pinmessagelength > 3)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = mmsg[3];
                        urRegistBll.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urRegistBll.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');

                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urRegistBll.usrMiddleName = mname;
                        lname = mmsg1[3];
                    }
                    else if (namelength > 2)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        lname = mmsg1[2];
                    }
                    else if (namelength > 1)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                    }
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
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
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/MPSC.aspx?crtevnt http://www.myct.in/MPSC.aspx?ict http://www.myct.in/MPSC.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {

                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {


                            }
                            finally
                            {
                                string changeFlagSql = "";
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }

                        }

                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                string changeFlagSql = "";
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }

                        }

                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax MPSC FirstName LastName*Address*Pincode*Emailid Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }



/////////////////////////////////////////////ANNA Pooja k*Pune*41037////////////////////////////////////////////////////////////////////////////////////////////
            else if (mkeyword1.Contains("ANNA") || mkeyword1.Contains("Anna") || mkeyword1.Contains("anna"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split(' ');
                //aa = arr[1];
                //bb = arr[2];
                //arr1 = Pinmsg1.Split('*');

                //b = arr1[1];
                //c = arr1[2];

                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = aa;
                //urRegistBll.usrLastName = bb;
                //urRegistBll.usrCityId = 37;

                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;

                //    string myName = urRegistBll.usrFirstName;


                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                string senderId = "COM2MYCT";

                try
                {

                    string fname = "", mname = "", lname = "", address = "", pincode = "", emailid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    int pinmessagelength = mmsg.Length;
                    if (pinmessagelength > 3)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = mmsg[3];
                        urRegistBll.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urRegistBll.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    //int namelength = mmsg[0].Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urRegistBll.usrMiddleName = mname;
                        lname = mmsg1[3];
                    }
                    else if (namelength > 2)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        lname = mmsg1[2];
                    }
                    else if (namelength > 1)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                    }
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
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
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + fname + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);

                        if (mkeyword1 == "ANNA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',9)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            { }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }


                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax ANNA FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }


            //            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            //            int pkchange = 0;
            //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            if (pkchange == 0)
            //            {
            //                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            }

            //        }
            //    }
            //}
            /////////////////////////////////////////RAVIDASSIA Pooja k*Pune*41037/////////////////////////////////////

            else if (mkeyword1.Contains("RAVIDASSIA") || mkeyword1.Contains("Ravidassia") || mkeyword1.Contains("ravidassia"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split('*');

                //string keyword = arr[0];
                //a = arr[1];
                //b = arr[2];
                //c = arr[3];

                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = a;
                //urRegistBll.usrLastName = b;
                //urRegistBll.usrCityId = 37;

                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;

                //    string myName = urRegistBll.usrFirstName;


                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);


                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                string senderId = "COM2MYCT";

                try
                {

                    string fname = "", mname = "", lname = "", address = "", pincode = "", emailid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    int pinmessagelength = mmsg.Length;
                    if (pinmessagelength > 3)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = mmsg[3];
                        urRegistBll.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urRegistBll.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    //int namelength = mmsg[0].Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urRegistBll.usrMiddleName = mname;
                        lname = mmsg1[3];
                    }
                    else if (namelength > 2)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        lname = mmsg1[2];
                    }
                    else if (namelength > 1)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                    }
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
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
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "RAVIDASSIA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax RAVIDASSIA FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }
            //            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            //            int pkchange = 0;
            //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            if (pkchange == 0)
            //            {
            //                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            }

            //        }
            //    }
            //}
            ////////////////////////////////////////////////////////////AGRO Pooja k*Pune*41037/////////////////////////////////////


            else if (mkeyword1.Contains("AGRO") || mkeyword1.Contains("WSSD") || mkeyword1.Contains("Agro") || mkeyword1.Contains("agro") || mkeyword1.Contains("AMC") || mkeyword1.Contains("Amc") || mkeyword1.Contains("amc") || mkeyword1.Contains("DIDIMA") || mkeyword1.Contains("Didima") || mkeyword1.Contains("didima") || mkeyword1.Contains("DIDIMAA") || mkeyword1.Contains("Didimaa") || mkeyword1.Contains("didimaa") || mkeyword1.Contains("JAIN") || mkeyword1.Contains("jain") || mkeyword1.Contains("Jain") || mkeyword1.Contains("JANGID") || mkeyword1.Contains("Jangid") || mkeyword1.Contains("jangid") || mkeyword1.Contains("JB") || mkeyword1.Contains("jb") || mkeyword1.Contains("Jb") || mkeyword1.Contains("JM") || mkeyword1.Contains("Jm") || mkeyword1.Contains("jm") || mkeyword1.Contains("JNS") || mkeyword1.Contains("Jns") || mkeyword1.Contains("jns") || mkeyword1.Contains("MALI") || mkeyword1.Contains("Mali") || mkeyword1.Contains("mali") || mkeyword1.Contains("MHMSM") || mkeyword1.Contains("Mhmsm") || mkeyword1.Contains("mhmsm") || mkeyword1.Contains("MSS") || mkeyword1.Contains("Mss") || mkeyword1.Contains("mss") || mkeyword1.Contains("SAHU") || mkeyword1.Contains("Sahu") || mkeyword1.Contains("sahu") || mkeyword1.Contains("TELI") || mkeyword1.Contains("Teli") || mkeyword1.Contains("teli"))
            {
                //mkeyword1 = mkeyword1.ToUpper();
                //Pinmsg1 = PinMessage;
                //arr = Pinmsg1.Split(' ');
                //aa = arr[1];
                //bb = arr[2];
                //arr1 = Pinmsg1.Split('*');

                //b = arr1[1];
                //c = arr1[2];

                //urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                //urRegistBll.usrMobileNo = mobile;
                //urRegistBll.usrPIN = newnewpin;
                //mesgName = a.Split(' ');
                //lenght1 = mesgName.Length;
                //if (lenght1 > 1)
                //{
                //    a = mesgName[0];
                //    b = mesgName[1];
                //}
                //urRegistBll.usrFirstName = aa;
                //urRegistBll.usrLastName = bb;
                //urRegistBll.usrCityId = 37;

                //status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //if (status == 0)
                //{
                //    string senderId = "COM2MYCT";
                //    string myMobileNo = urRegistBll.usrMobileNo;

                //    string myName = urRegistBll.usrFirstName;


                //    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);

                //    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                //    int pkchange = 0;
                //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    if (pkchange == 0)
                //    {
                //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                //    }
                //}
                //else
                //{
                //    Random rnd = new Random();
                //    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                //    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                //    if (status > 0)
                //    {
                //        string senderId = "COM2MYCT";
                //        string myMobileNo = urRegistBll.usrMobileNo;
                //        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                //        string myName = urRegistBll.usrFirstName;
                //        string thisDir = Server.MapPath("~");
                //        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                //        {
                //            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                //            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //        }

                //        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                //        if (mkeyword1 == "JM" || mkeyword1 == "jm")
                //            mkeyword1 = "Maheshwari";
                //        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);

                //        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                string senderId = "COM2MYCT";

                try
                {

                    string fname = "", mname = "", lname = "", address = "", pincode = "", emailid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string[] mmsg = PinMessage.Split('*');
                    int pinmessagelength = mmsg.Length;
                    if (pinmessagelength > 3)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = mmsg[3];
                        urRegistBll.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urRegistBll.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    //int namelength = mmsg[0].Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urRegistBll.usrMiddleName = mname;
                        lname = mmsg1[3];
                    }
                    else if (namelength > 2)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        lname = mmsg1[2];
                    }
                    else if (namelength > 1)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                    }
                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                    urRegistBll.usrMobileNo = mobile;
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
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + fname + ", Password for ur First Login is " + myPassword + " ";
                        if (mkeyword1 == "JM" || mkeyword1 == "jm")
                            mkeyword1 = "Maheshwari";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        if (mkeyword1 == "DIDIMA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',66)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        //else if (mkeyword1 == "AGRO")
                        //{
                        //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                        //    string a1 = cc.ExecuteScalar(sql);
                        //}
                        //else if (mkeyword1 == "WSSD")
                        //{
                        //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                        //    string a1 = cc.ExecuteScalar(sql);
                        //}
                        //else if (mkeyword1 == "AMC")
                        //{
                        //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                        //    string a1 = cc.ExecuteScalar(sql);
                        //}

                        else if (mkeyword1 == "DIDIMAA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',77)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JAIN")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',28)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JANGID")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',31)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JB")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',38)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',22)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JNS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',25)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MALI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',32)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MHMSM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',30)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MSS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',29)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "SAHU")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',41)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TELI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',39)";
                            string a1 = cc.ExecuteScalar(sql);
                        }

                        emlTo = urRegistBll.usrEmailId;
                        if (emlTo == "" || emlTo == null)
                        {
                            try
                            {
                                emlTo = "smsofmyct@gmail.com";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            { }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                            }
                        }
                        //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        //int pkchange = 0;
                        //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //if (pkchange == 0)
                        //{
                        //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        //}

                    }
                }
                catch (Exception ex)
                {
                    if (mkeyword1 == "DIDIMA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax DIDIMA FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "AGRO")
                    {
                        string NewSmsResp = "Dear User,Use Syntax AGRO FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "WSSD")
                    {
                        string NewSmsResp = "Dear User,Use Syntax WSSD FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "AMC")
                    {
                        string NewSmsResp = "Dear User,Use Syntax AMC FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "DIDIMAA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax DIDIMAA FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JAIN")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JAIN FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JANGID")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JANGID FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JB")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JB FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JM FirstName*LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "JNS")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JNS FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "MALI")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MALI FirstName*LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "MHMSM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MHMSM FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "MSS")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MSS FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "SAHU")
                    {
                        string NewSmsResp = "Dear User,Use Syntax SAHU FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else if (mkeyword1 == "TELI")
                    {
                        string NewSmsResp = "Dear User,Use Syntax TELI FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        cc.SendMessageTra(senderId, mobile, NewSmsResp);
                    }
                    else
                    {
                    }

                }


            }


            //            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            //            int pkchange = 0;
            //            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            if (pkchange == 0)
            //            {
            //                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //            }

            //        }
            //    }
            //}

        }

        catch { }
    }
    /// <summary>
    /// //////////////////////////////////////End of Keyword space Name*Address*Pincode//////////////////////////////////////////
    /// </summary>

    public void RegisteredKeyword()
    {
        try
        {

            if (mkeyword1.Contains("Reg") || mkeyword1.Contains("reg") || mkeyword1.Contains("REG"))
            {
                string[] mmsg = PinMessage.Split('*');

                if (PinMessage != "*")
                {
                    mmsg = message.Split(' ');
                }

                int length = mmsg.Length;
                if (length >= 3)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = mmsg[2];
                }
                else if (length >= 2)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = "";

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                urRegistBll.usrPIN = newnewpin;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urRegistBll.usrFirstName = mmmsg1;
                urRegistBll.usrLastName = mmmsg2;
                urRegistBll.usrCityId = 37;

                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;

                    string myName = urRegistBll.usrFirstName;


                    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }
                }
                else
                {
                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {
                        string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = urRegistBll.usrFirstName;
                        //string myprefix = urRegistBll.UsrPrefix;
                        //string mypostfix = urRegistBll.UsrPostfix;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);


                        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);

                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }

                    }
                }
            }
            //////////////////////////////////////////////////////////////OM Pooja K pune 411037//////////////////////////////////

            else if (mkeyword1.Contains("Om") || mkeyword1.Contains("om") || mkeyword1.Contains("OM") || mkeyword1.Contains("TTD") || mkeyword1.Contains("ttd") || mkeyword1.Contains("Ttd") || mkeyword1.Contains("WSSD") || mkeyword1.Contains("Wssd"))
            {
                mkeyword1 = mkeyword1.ToUpper();
                string[] mmsg = PinMessage.Split('*');

                if (PinMessage != "*")
                {
                    mmsg = message.Split(' ');
                }

                int length = mmsg.Length;
                if (length >= 4)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = mmsg[2];


                }
                else if (length >= 2)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = "";

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                urRegistBll.usrPIN = newnewpin;
                urRegistBll.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urRegistBll.usrFirstName = mmmsg1;
                urRegistBll.usrLastName = mmmsg2;
                urRegistBll.usrCityId = 37;


                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "OM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',34)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "TTD")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',79)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    emlTo = urRegistBll.usrEmailId;
                    if (emlTo == "" || emlTo == null)
                    {
                        emlTo = "smsofmyct@gmail.com";
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    else
                    {
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }

                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }
            else if (mkeyword1.Contains("NCP") || mkeyword1.Contains("Ncp") || mkeyword1.Contains("ncp"))
            {
                mkeyword1 = mkeyword1.ToUpper();
                string[] mmsg = PinMessage.Split('*');


                //if (PinMessage != "*")
                //{
                //    mmsg = message.Split(' ');
                //}

                int length = mmsg.Length;
                if (length >= 4)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = mmsg[2];


                }
                else if (length >= 2)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = "";

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                urRegistBll.usrPIN = newnewpin;
                urRegistBll.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urRegistBll.usrFirstName = mmmsg1;
                urRegistBll.usrLastName = mmmsg2;
                urRegistBll.usrCityId = 37;


                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 & ur login pswd fr www.myct.in is " + myPassword + " ";
                    string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "NCP")
                    {
                        string sql11 = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',6)";
                        string a = cc.ExecuteScalar(sql11);
                    }
                    emlTo = urRegistBll.usrEmailId;
                    if (emlTo == "" || emlTo == null)
                    {
                        emlTo = "smsofmyct@gmail.com";
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    else
                    {
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }
                    string sql = "update usermaster set JoinGroup='" + mkeyword1 + "' where usrMobileNo='" + myMobileNo + "'";
                    string eze = cc.ExecuteScalar(sql);


                }
            }
            ///////////////////////////////////////////////////////
            else if (mkeyword1.Contains("ANNA") || mkeyword1.Contains("Anna") || mkeyword1.Contains("anna"))
            {
                mkeyword1 = mkeyword1.ToUpper();
                string[] mmsg = PinMessage.Split('*');


                if (PinMessage != "*")
                {
                    mmsg = message.Split(' ');
                }

                int length = mmsg.Length;
                if (length >= 4)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = mmsg[2];


                }
                else if (length >= 2)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = "";

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                urRegistBll.usrPIN = newnewpin;
                urRegistBll.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urRegistBll.usrFirstName = mmmsg1;
                urRegistBll.usrLastName = mmmsg2;
                urRegistBll.usrCityId = 37;


                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "ANNA")
                    {
                        string sql11 = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',9)";
                        string a = cc.ExecuteScalar(sql11);
                    }
                    emlTo = urRegistBll.usrEmailId;

                    if (emlTo == "" || emlTo == null)
                    {
                        emlTo = "smsofmyct@gmail.com";
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    else
                    {
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }
            else if (mkeyword1.Contains("RAVIDASSIA") || mkeyword1.Contains("Ravidassia") || mkeyword1.Contains("ravidassia"))
            {
                mkeyword1 = mkeyword1.ToUpper();
                string[] mmsg = PinMessage.Split('*');


                if (PinMessage != "*")
                {
                    mmsg = message.Split(' ');
                }

                int length = mmsg.Length;
                if (length >= 4)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = mmsg[2];


                }
                else if (length >= 2)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = "";

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                urRegistBll.usrPIN = newnewpin;
                urRegistBll.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urRegistBll.usrFirstName = mmmsg1;
                urRegistBll.usrLastName = mmmsg2;
                urRegistBll.usrCityId = 37;


                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "RAVIDASSIA")
                    {
                        string sql11 = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                        string a = cc.ExecuteScalar(sql11);
                    }
                    emlTo = urRegistBll.usrEmailId;
                    if (emlTo == "" || emlTo == null)
                    {
                        emlTo = "smsofmyct@gmail.com";
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    else
                    {
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }
            else if (mkeyword1.Contains("AGRO") || mkeyword1.Contains("Agro") || mkeyword1.Contains("agro") || mkeyword1.Contains("AMC") || mkeyword1.Contains("Amc") || mkeyword1.Contains("amc") || mkeyword1.Contains("DIDIMA") || mkeyword1.Contains("Didima") || mkeyword1.Contains("didima") || mkeyword1.Contains("DIDIMAA") || mkeyword1.Contains("Didimaa") || mkeyword1.Contains("didimaa") || mkeyword1.Contains("JAIN") || mkeyword1.Contains("jain") || mkeyword1.Contains("Jain") || mkeyword1.Contains("JANGID") || mkeyword1.Contains("Jangid") || mkeyword1.Contains("jangid") || mkeyword1.Contains("JB") || mkeyword1.Contains("jb") || mkeyword1.Contains("Jb") || mkeyword1.Contains("JM") || mkeyword1.Contains("Jm") || mkeyword1.Contains("jm") || mkeyword1.Contains("JNS") || mkeyword1.Contains("Jns") || mkeyword1.Contains("jns") || mkeyword1.Contains("MALI") || mkeyword1.Contains("Mali") || mkeyword1.Contains("mali") || mkeyword1.Contains("MHMSM") || mkeyword1.Contains("Mhmsm") || mkeyword1.Contains("mhmsm") || mkeyword1.Contains("MSS") || mkeyword1.Contains("Mss") || mkeyword1.Contains("mss") || mkeyword1.Contains("SAHU") || mkeyword1.Contains("Sahu") || mkeyword1.Contains("sahu") || mkeyword1.Contains("TELI") || mkeyword1.Contains("Teli") || mkeyword1.Contains("teli"))
            {
                mkeyword1 = mkeyword1.ToUpper();

                string[] mmsg = PinMessage.Split('*');


                if (PinMessage != "*")
                {
                    mmsg = message.Split(' ');
                }

                int length = mmsg.Length;
                if (length >= 4)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = mmsg[2];


                }
                else if (length >= 2)
                {
                    mmmsg0 = mmsg[0];
                    mmmsg1 = mmsg[1];
                    mmmsg2 = "";

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();
                urRegistBll.usrMobileNo = mobile;
                urRegistBll.usrPIN = newnewpin;
                urRegistBll.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urRegistBll.usrFirstName = mmmsg1;
                urRegistBll.usrLastName = mmmsg2;
                urRegistBll.usrCityId = 37;


                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                    string myName = urRegistBll.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urRegistBll.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    if (mkeyword1 == "JM" || mkeyword1 == "jm")
                        mkeyword1 = "Maheshwari";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "DIDIMA")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',66)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    //else if (mkeyword1 == "AGRO")
                    //{
                    //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                    //    string a1 = cc.ExecuteScalar(sql);
                    //}
                    //else if (mkeyword1 == "WSSD")
                    //{
                    //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                    //    string a1 = cc.ExecuteScalar(sql);
                    //}
                    //else if (mkeyword1 == "AMC")
                    //{
                    //    string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',27)";
                    //    string a1 = cc.ExecuteScalar(sql);
                    //}

                    else if (mkeyword1 == "DIDIMAA")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',77)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JAIN")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',28)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JANGID")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',31)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JB")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',38)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',22)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JNS")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',25)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MALI")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',32)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MHMSM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',30)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MSS")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',29)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "SAHU")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',41)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "TELI")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',39)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    emlTo = urRegistBll.usrEmailId;
                    if (emlTo == "" || emlTo == null)
                    {
                        emlTo = "smsofmyct@gmail.com";
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    else
                    {
                        subject = "Mail From " + myName;
                        emlBody = "\n\n...www.myct.in";
                        ll.sendEmail(emlTo, subject, NewSmsResp);
                    }
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }
            else
            {
                string senderId = "COM2MYCT";
                string myMobileNo = urRegistBll.usrMobileNo;
                string NewSmsResp = "Dear please use proper Syntax " + cc.AddSMS(myMobileNo);
                cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //////////////////////////////////////End of Keyword space Name space Address space Pincode//////////////////////////////////////

    //Keyword which is already registered
    public void NormalKeyword()
    {
        // string ctnm = "", dtnm = "", stnm = "";

        try
        {
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


                if (mkeyword1 == "COPY" || mkeyword1 == "Copy" || mkeyword1 == "copy")
                {
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrMessageString = message1;
                    CopyGroupByKeyWord(urRegistBll);

                }
                //////////End////

                else if (mkeyword1 == "REMOVE" || mkeyword1 == "Remove" || mkeyword1 == "remove")
                {
                    string[] mmsg = message1.Split(' ');
                    int length = mmsg.Length;
                    string frmobile = "";
                    if (length > 1)
                    {
                        frmobile = mmsg[0].ToString();
                    }
                    else
                    {
                        frmobile = mmsg[0].ToString();
                    }
                    removeKewWord(mobile, frmobile, urRegistBll);
                }
                ////////End/////////

                else if (mkeyword1 == "BLOG" || mkeyword1 == "Blog" || mkeyword1 == "blog")
                {
                    string[] msg = message.Split(' ');
                    string kwdBlog = "";
                    string blog = "";
                    if (msg[0].ToUpper() == "BLOG")
                    {
                        kwdBlog = Convert.ToString(msg[1].ToUpper());
                        for (int s = 2; s < msg.Length; s++)
                        {
                            blog += msg[s].ToString() + " ";
                        }
                        SaveBlog(kwdBlog, mobile, blog, urRegistBll);
                    }
                }

               /////End////

                else if (mkeyword1 == "NAME" || mkeyword1 == "Name" || mkeyword1 == "name")
                {
                    string[] mmsg = message1.Split(' ');
                    int length = mmsg.Length;
                    if (length >= 2)
                    {
                        mmmsg0 = mmsg[0];
                        mmmsg1 = mmsg[1];

                    }
                    else if (length == 1)
                    {
                        mmmsg0 = mmsg[0];
                        mmmsg1 = "";
                    }
                    if (mmmsg1 != "")
                    {
                        urRegistBll.usrMobileNo = mobile;
                        urRegistBll.usrFirstName = mmmsg0;
                        urRegistBll.usrLastName = mmmsg1;
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status == 0)
                        {
                            UpdateName(urRegistBll);
                        }
                    }
                    else
                    {
                        urRegistBll.usrMobileNo = mobile;
                        urRegistBll.usrFirstName = mmmsg0;

                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status == 0)
                        {
                            UpdateFirstName(urRegistBll);
                        }
                    }
                }
                //////////////End//////////////

                else if (mkeyword1 == "BAL" || mkeyword1 == "Bal" || mkeyword1 == "bal")
                {
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    urRegistBll.usrMobileNo = mobile;
                    if (status == 0)
                    {
                        smsBalKeyword(urRegistBll);
                    }
                }
                //////////////End//////////////
                ////oldchanges
                //else if (mkeyword1 == "BALANCE" || mkeyword1 == "Balance" || mkeyword1 == "balance")
                //{
                //    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                //    urRegistBll.usrMobileNo = mobile;
                //    if (status == 0)
                //    {
                //        string fromMo = "", toMo = "";
                //        int amt = 0;
                //        fromMo = mobile;
                //        string[] arr = message1.Split(' ');
                //        if (arr.Length >= 2)
                //        {
                //            toMo = Convert.ToString(arr[0]);
                //            char[] aaa = arr[1].ToCharArray();
                //            if (aaa[0] >= 48 && aaa[0] <= 57)
                //            {
                //                amt = Convert.ToInt32(arr[1].ToString());
                //            }
                //        }
                //        FillBalKeyword(fromMo, toMo, amt, urRegistBll);
                //    }

                //}


                    /////////////////////////////////////////////////////////////////////////////////////////////
                ////newchanges
                else if (mkeyword1 == "BALANCE" || mkeyword1 == "Balance" || mkeyword1 == "balance")
                {
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    urRegistBll.usrMobileNo = mobile;
                    if (status == 0)
                    {
                        string fromMo = "", toMo = "";
                        int transamt = 0, promoamt = 0;
                        fromMo = mobile;
                        //int aa = Convert.ToString(message1);
                        string[] arr = message1.Split(' ');
                        toMo = Convert.ToString(arr[0]);
                        transamt = Convert.ToInt32(arr[1]);
                        promoamt = Convert.ToInt32(arr[2]);
                        FillBalKeyword1(fromMo, toMo, transamt, promoamt, urRegistBll);
                    }

                }
                ////////////////////////////////////////////////////////////
                else if (mkeyword1 == "DND" || mkeyword1 == "dnd" || mkeyword1 == "Dnd")
                {
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    string[] arr = message1.Split(' ');
                    urRegistBll.usrMobileNo = mobile;
                    string dnd = arr[0].ToString();
                    if (dnd == "0" || dnd == "1" || dnd == "2" || dnd == "3" || dnd == "4" || dnd == "5" || dnd == "6" || dnd == "7")
                    {
                        urRegistBll.usrDND = Convert.ToInt32(dnd.ToString());
                    }
                    if (status == 0)
                    {
                        setDNDbyLongCode(urRegistBll);
                    }

                }
                //////////////////////////////////////////////////////////////////////////////////////

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
                            string ID, category, userId;
                            string sql = "select  usrUserId,School_CollegeID,PersonCategory from UserMaster where usrMobileNo='" + urRegistBll.usrMobileNo + "'";
                            DataSet ds = cc.ExecuteDataset(sql);
                            ID = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);
                            category = Convert.ToString(ds.Tables[0].Rows[0]["PersonCategory"]);
                            userId = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                            scID.getChangeMobileNo(ID, urRegistBll.usrMobileNo, urRegistBll.usrAltMobileNo, category, userId);
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "ADDRESS" || mkeyword1 == "Address" || mkeyword1 == "address" || mkeyword1 == "add" || mkeyword1 == "Add" || mkeyword1 == "ADD")
                {
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrAddress = message1;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        UpdateAddressByLongCode(urRegistBll, iii);
                    }

                }
                /////////////////////////////////////////////////////////////////////////
                else if (mkeyword1 == "V" || mkeyword1 == "P" || mkeyword1 == "G")
                {
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrCategory = message1;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        UpdateAddressByLongCode(urRegistBll, iii);
                    }

                }
                /////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "M" || mkeyword1 == "F")
                {
                    if (mkeyword1 == "M")
                    {
                        mkeyword1 = "Male";
                    }
                    else
                    {

                        mkeyword1 = "Female";
                    }
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrGender = message1;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        UpdateAddressByLongCode(urRegistBll, iii);
                    }

                }
                //////////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "DOB" || mkeyword1 == "Dob" || mkeyword1 == "dob")
                {
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrDOB = message1;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        UpdateDOBByLongCode(urRegistBll);
                    }

                }
                //////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "@" || mkeyword1 == "EMAIL" || mkeyword1 == "email" || mkeyword1 == "Email" || mkeyword1 == "E-MAIL" || mkeyword1 == "e-mail" || mkeyword1 == "E-mail")
                {
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrEmailId = message1;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        UpdateEmailByLongCode(urRegistBll);
                        //RecoverPasswordByLongCode(urRegistBll);
                    }

                }
                ///////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "AREA" || mkeyword1 == "Area" || mkeyword1 == "area" || mkeyword1 == "VILLAGE" || mkeyword1 == "Village" || mkeyword1 == "village")
                {
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrArea = message1;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        UpdateAreaByLongCode(urRegistBll);
                    }

                }
                ///////////////////////////////////////////////////////////////

                else if (mkeyword1 == "Pin" || mkeyword1 == "pin" || mkeyword1 == "PIN" || mkeyword1 == "PINCODE" || mkeyword1 == "Pincode" || mkeyword1 == "pincode")
                {
                    urRegistBll.usrMobileNo = mobile;
                    string[] arrPin = message1.Split(' ');
                    if (arrPin.Length >= 0)
                    {
                        urRegistBll.usrPIN = arrPin[0].ToString();
                        urRegistBll.usrFirstName = "";
                        urRegistBll.usrLastName = "";
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status == 0)
                        {
                            UpdatePinByLongCode(urRegistBll);
                        }
                        else
                        {
                            string mobileNo = urRegistBll.usrMobileNo;
                            string smsString = "Dear user first register on www.come2myCity.com." + cc.AddSMS(mobileNo);
                            string senderId = "COM2MYCT";

                            cc.SendMessage1(senderId, mobileNo, smsString);
                            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                            int pkchange = 0;
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                            if (pkchange == 0)
                            {
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                            }
                        }
                    }
                    else
                    {
                        string mobileNo = urRegistBll.usrMobileNo;
                        string smsErrString = "Dear user please send SMS as PIN/Pin/pin <SPACE> VALID SIX DIGIT PIN CODE." + cc.AddSMS(mobileNo);
                        string senderId = "COM2MYCT";

                        cc.SendMessage1(senderId, mobileNo, smsErrString);
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }
                    }



                }
                ///////////////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "JOIN ALL" || mkeyword1 == "Join All" || mkeyword1 == "join all")
                {
                    urRegistBll.usrMobileNo = mobile;
                    JoinAllKeyword(urRegistBll);


                }
                ////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "JOIN" || mkeyword1 == "Join" || mkeyword1 == "join") && JoinGr != 1)
                {
                    urRegistBll.usrMobileNo = mobile;
                    JoinGrKeyword(urRegistBll, JoinGr);


                }
                ///////////////////////////////////////////////////////////////////////////
                else if (mkeyword1 == "DELETE ME" || mkeyword1 == "Delete Me" || mkeyword1 == "delete me")
                {
                    urRegistBll.usrMobileNo = mobile;
                    DeleteUserKeyWord(urRegistBll);
                }
                ///////////////////////////////////////////////////////////

                else if (mkeyword1.Contains("FRIEND") || mkeyword1.Contains("Friend") || mkeyword1.Contains("friend") || mkeyword1.Contains("RELATIVE") || mkeyword1.Contains("Relative") || mkeyword1.Contains("relative") || mkeyword1.Contains("frnd") || mkeyword1.Contains("Frnd") || mkeyword1.Contains("FRND") || mkeyword1.Contains("FRIENDS") || mkeyword1.Contains("friends") || mkeyword1.Contains("Friends"))
                {
                    string[] msgSplits = message1.Split(' ');
                    urRegistBll.usrMobileNo = mobile;
                    if (msgSplits.Length > 2)
                    {
                        urRegistBll.usrAltMobileNo = msgSplits[0];
                        urRegistBll.frnrelFrnRelName = msgSplits[1];
                        urRegistBll.usrLastName = msgSplits[2];
                    }
                    else if (msgSplits.Length > 1)
                    {
                        urRegistBll.usrAltMobileNo = msgSplits[0];
                        urRegistBll.frnrelFrnRelName = msgSplits[1];

                    }
                    else if (msgSplits.Length > 0)
                    {
                        urRegistBll.usrAltMobileNo = msgSplits[0];
                    }
                    if (urRegistBll.usrAltMobileNo.Length == 10)
                    {
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status == 0)
                        {   //Mahesh: Send second parameter for only send sms only, because at run time mobile number of sender change.
                            AddFriendByLongCode(urRegistBll, mobile);
                        }
                    }
                    else
                    {
                        string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string passwordMessage = "Dear user please enter valid mobile number." + cc.AddSMS(myMobileNo);
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }
                    }
                }
                /////////////////////////////////////////////////////////////////////////
                else if (mkeyword1 == "MSEB" || mkeyword1 == "Mseb" || mkeyword1 == "mseb")
                {


                    string sql11 = "select usrUserId from UserMaster where usrMobileNo='" + mobile + "'";
                    string UserId = cc.ExecuteScalar(sql11);

                    if (UserId != null && UserId != "")
                    {
                        sql11 = "Insert into UserConsumer (UserID,ConsumerNo) values('" + UserId + "','" + message1 + "')";
                        cc.ExecuteNonQuery(sql11);
                        string senderId = "MYCT.IN";
                        string myMobileNo = mobile.ToString();
                        //string myName = urRegistBll.usrFirstName;
                        string sqlquery = "select usrFirstName +' '+ usrLastName as name from UserMaster where usrMobileNo='" + mobile + "'";
                        string UserName = cc.ExecuteScalar(sqlquery);

                        string passwordMessage = "Dear " + UserName + " your consumer number is updated successfully. " + cc.AddSMS(myMobileNo);
                        string NewMscbRespMsg = "Dear " + UserName.ToString() + " ur electric meter con no. is updated successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderId, myMobileNo, NewMscbRespMsg);
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }

                    }


                }
                ///////////////////////////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "PASSWORD" || mkeyword1 == "Password" || mkeyword1 == "password" || mkeyword1 == "PASS" || mkeyword1 == "Pass" || mkeyword1 == "pass"))
                {
                    urRegistBll.usrMobileNo = mobile;
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        RecoverPasswordByLongCode(urRegistBll);
                    }
                }


                ////////////////////////////////////////////////////////////////////////////////////////////////


                else if ((mkeyword1 == "PASSWORD" || mkeyword1 == "Password" || mkeyword1 == "password" || mkeyword1 == "PASS" || mkeyword1 == "Pass" || mkeyword1 == "pass") && (message1 != ""))
                {
                    urRegistBll.usrMobileNo = mobile;
                    int pln = message1.Length;
                    message1 = message1.Remove(pln - 1);
                    urRegistBll.usrMessageString = message1.ToString();
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        ReeSetPass(urRegistBll);
                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "UpdateMsg" || mkeyword1 == "UPDATEMSG" || mkeyword1 == "updatemsg" || mkeyword1 == "Updatemsg"))
                {

                    string Message = message1;

                    updateMsg(Message);

                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////



                else if ((mkeyword1 == "GETRECORD" || mkeyword1 == "GetRecord" || mkeyword1 == "Getrecord" || mkeyword1 == "getrecord"))
                {
                    GetRecord();

                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "DATA" || mkeyword1 == "Data" || mkeyword1 == "data"))
                {
                    DateTime date = DateTime.Now;
                    string todaysDate = date.ToShortDateString();
                    senderid = "myctin";
                    string[] mmsg = WholeMsg.Split('*');

                    urRegistBll.usrMobileNo = mobile;
                    string sqlget = "select usrUserid from usermaster where usrMobileNo='" + mobile + "'";
                    string usruserid = cc.ExecuteScalar(sqlget);
                    urRegistBll.usrKeyWord = mkeyword1.ToString();
                    lenght1 = mmsg.Length;
                    string sql = "insert into DataCollection(sender_mobileno,send_date)" +
                    " values('" + usruserid + "','" + todaysDate + "')";
                    string exe = cc.ExecuteScalar(sql);

                    string sql11 = "select top 1 data_id from DataCollection order by data_id desc ";
                    string id = cc.ExecuteScalar(sql11);
                    if (lenght1 == 1)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);

                    }
                    else if (lenght1 == 2)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                    }
                    else if (lenght1 == 3)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                    }
                    else if (lenght1 == 4)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);

                    }

                    else if (lenght1 == 5)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "' ,ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);

                    }
                    else if (lenght1 == 6)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 7)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 8)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 9)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',,ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }

                    else if (lenght1 == 10)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 11)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 12)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                            " p12='" + mmsg[11] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 13)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                           " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 14)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                           " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 15)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                           " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);

                    }
                    else if (lenght1 == 16)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                           " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "' ,p16='" + mmsg[15] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 17)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                          " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 18)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                          " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "',p18='" + mmsg[17] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 19)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                          " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "'" +
                        " ,p18='" + mmsg[17] + "',p19='" + mmsg[18] + "',ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);
                        //newtotal();
                    }
                    else if (lenght1 == 20)
                    {
                        string query = "select userid from AdminSubMarketingSubUser where friendid='" + usruserid + "'";
                        string refrence = cc.ExecuteScalar(query);
                        string sql1 = "update DataCollection set p1='" + mmsg[0] + "',p2='" + mmsg[1] + "',p3='" + mmsg[2] + "',p4='" + mmsg[3] + "',p5='" + mmsg[4] + "',p6='" + mmsg[5] + "',p7='" + mmsg[6] + "',p8='" + mmsg[7] + "',p9='" + mmsg[8] + "',p10='" + mmsg[9] + "',p11='" + mmsg[10] + "'," +
                          " p12='" + mmsg[11] + "',p13='" + mmsg[12] + "',p14='" + mmsg[13] + "',p15='" + mmsg[14] + "',p16='" + mmsg[15] + "',p17='" + mmsg[16] + "'" +
                        " ,p18='" + mmsg[17] + "',p19='" + mmsg[18] + "',p20='" + mmsg[19] + "' ,ref_id='" + refrence + "' where data_id='" + id + "' and sender_mobileno='" + usruserid + "' ";
                        string execute = cc.ExecuteScalar(sql1);
                        string message = "Dear ur message stored successfully thanks.via www.myct.in";
                        cc.SendMessageTra(senderid, mobile, message);

                    }


                }

                ////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "GetRecord" || mkeyword1 == "GETRECORD" || mkeyword1 == "getrecord"))
                {

                    string rolename = "";

                    int p3, p5, p7;
                    int r3 = 0, r5 = 0, r7 = 0;
                    string getid = "select usrUserid from usermaster where usrMobileNo='" + mobile + "'";
                    string UserName = cc.ExecuteScalar(getid);
                    string sql11 = "select rolename from AdminSubMarketingSubUser where userid='" + UserName + "' ";
                    rolename = cc.ExecuteScalar(sql11);
                    if (rolename == "")
                    {
                        sql11 = "select rolename from AdminSubMarketingSubUser where friendid='" + UserName + "' ";
                        rolename = cc.ExecuteScalar(sql11);
                    }
                    if (rolename == "SE")
                    {
                        string sql = "  select friendid from AdminSubMarketingSubUser " +
                          " where userid='" + UserName + "' or reference_id3='" + UserName + "'";
                        DataSet ds = cc.ExecuteDataset(sql);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            string userid = Convert.ToString(dr["friendid"]);
                            string sql1 = "select SUM(p3)as P3,sum(p5) as P5, sum(p7)as P7 from DataCollection where sender_mobileno='" + userid + "'";
                            DataSet ds1 = cc.ExecuteDataset(sql1);

                            p3 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P3"]);
                            p5 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P5"]);
                            p7 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P7"]);
                            r3 = r3 + p3;
                            r5 = r5 + p5;
                            r7 = r7 + p7;
                        }
                        string sql12 = "select SUM(p3)as P3,sum(p5) as P5, sum(p7)as P7 from DataCollection where sender_mobileno='" + UserName + "'";
                        DataSet ds12 = cc.ExecuteDataset(sql12);

                        p3 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P3"]);
                        p5 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P5"]);
                        p7 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P7"]);
                        r3 = r3 + p3;
                        r5 = r5 + p5;
                        r7 = r7 + p7;

                        //totalP3.Text = Convert.ToString(r3);
                        //totalP5.Text = Convert.ToString(r5);
                        //totalP7.Text = Convert.ToString(r7);


                    }
                    else if (rolename == "EE")
                    {


                        string sql = "  select friendid from AdminSubMarketingSubUser " +
                          " where userid='" + UserName + "' or reference_id4='" + UserName + "'";
                        DataSet ds = cc.ExecuteDataset(sql);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            string userid = Convert.ToString(dr["friendid"]);
                            string sql1 = "select SUM(p3)as P3,sum(p5) as P5, sum(p7)as P7 from DataCollection where sender_mobileno='" + userid + "'";
                            DataSet ds1 = cc.ExecuteDataset(sql1);

                            p3 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P3"]);
                            p5 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P5"]);
                            p7 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P7"]);
                            r3 = r3 + p3;
                            r5 = r5 + p5;
                            r7 = r7 + p7;
                        }
                        string sql12 = "select SUM(p3)as P3,sum(p5) as P5, sum(p7)as P7 from DataCollection where sender_mobileno='" + UserName + "'";
                        DataSet ds12 = cc.ExecuteDataset(sql12);

                        p3 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P3"]);
                        p5 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P5"]);
                        p7 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P7"]);
                        r3 = r3 + p3;
                        r5 = r5 + p5;
                        r7 = r7 + p7;

                        //totalP3.Text = Convert.ToString(r3);
                        //totalP5.Text = Convert.ToString(r5);
                        //totalP7.Text = Convert.ToString(r7);


                    }
                    else if (rolename == "AE")
                    {


                        string sql = "  select friendid from AdminSubMarketingSubUser " +
                          " where userid='" + UserName + "' or reference_id6='" + UserName + "'";
                        DataSet ds = cc.ExecuteDataset(sql);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            string userid = Convert.ToString(dr["friendid"]);
                            string sql1 = "select SUM(p3)as P3,sum(p5) as P5, sum(p7)as P7 from DataCollection where sender_mobileno='" + userid + "'";
                            DataSet ds1 = cc.ExecuteDataset(sql1);

                            p3 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P3"]);
                            p5 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P5"]);
                            p7 = Convert.ToInt32(ds1.Tables[0].Rows[0]["P7"]);
                            r3 = r3 + p3;
                            r5 = r5 + p5;
                            r7 = r7 + p7;
                        }
                        string sql12 = "select SUM(p3)as P3,sum(p5) as P5, sum(p7)as P7 from DataCollection where sender_mobileno='" + UserName + "'";
                        DataSet ds12 = cc.ExecuteDataset(sql12);

                        p3 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P3"]);
                        p5 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P5"]);
                        p7 = Convert.ToInt32(ds12.Tables[0].Rows[0]["P7"]);
                        r3 = r3 + p3;
                        r5 = r5 + p5;
                        r7 = r7 + p7;

                        //totalP3.Text = Convert.ToString(r3);
                        //totalP5.Text = Convert.ToString(r5);
                        //totalP7.Text = Convert.ToString(r7);



                    }
                }
                //////////////////////////////////////////////////
                else if (checkGroupSMSCode(mkeyword1) == 1)
                {

                    urRegistBll.usrMobileNo = mobile;
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

                        SendMessagetoAllLongCode(urRegistBll);
                      
                   }


                }

                   //////////////////////////////////////////////////////////////////////


                else if (checPGr(mkeyword1.ToString()))
                {
                    string APSTR = "";
                    urRegistBll.usrMobileNo = mobile;

                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {   //Mahesh: Send second parameter for only send sms only, because at run time mobile number of sender change.
                        int grId = 0;
                        char[] rr = mkeyword1.ToCharArray();
                        if (rr[0] == 'p' || rr[0] == 'P')
                        {
                            if (rr[1] == 'R' || rr[1] == 'r')
                            {
                                APSTR = "PRESENT";
                                if (checkDigit(rr[2]) >= 48 && checkDigit(rr[2]) <= 57)
                                {
                                    int len = rr.Length;
                                    if (len > 3)
                                    {
                                        if (checkDigit(rr[3]) >= 48 && checkDigit(rr[2]) <= 57)
                                        {
                                            string id = Convert.ToString(rr[2]) + Convert.ToString(rr[3]);
                                            grId = Convert.ToInt32(id);
                                        }
                                        else
                                        {
                                            string id = Convert.ToString(rr[2]);
                                            grId = Convert.ToInt32(id);
                                        }
                                    }
                                    else
                                    {
                                        string id = Convert.ToString(rr[2]);
                                        grId = Convert.ToInt32(id);
                                    }

                                }
                            }


                        }
                        else if (rr[0] == 'a' || rr[0] == 'A')
                        {
                            if (rr[1] == 'p' || rr[1] == 'P' || rr[1] == 'B' || rr[1] == 'b')
                            {
                                APSTR = "APSENT";
                                if (checkDigit(rr[2]) >= 48 && checkDigit(rr[2]) <= 57)
                                {
                                    int len = rr.Length;
                                    if (len > 3)
                                    {
                                        if (checkDigit(rr[3]) >= 48 && checkDigit(rr[2]) <= 57)
                                        {
                                            string id = Convert.ToString(rr[2]) + Convert.ToString(rr[3]);
                                            grId = Convert.ToInt32(id);
                                        }
                                        else
                                        {
                                            string id = Convert.ToString(rr[2]);
                                            grId = Convert.ToInt32(id);
                                        }
                                    }
                                    else
                                    {
                                        string id = Convert.ToString(rr[2]);
                                        grId = Convert.ToInt32(id);
                                    }

                                }
                            }

                            //AddFriendByLongCodeF(urRegistBll, mobile, grId);
                        }
                        urRegistBll.longCodegrSMS = grId + " " + message1;
                        SendMessageToAllStuPAByLongCode(urRegistBll, mobile, grId, APSTR);
                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////////

                else if (checkGr(mkeyword1.ToString()))
                {
                    string[] msgSplits = message1.Split(' ');

                    urRegistBll.usrMobileNo = mobile;
                    if (msgSplits.Length > 2)
                    {
                        urRegistBll.usrAltMobileNo = msgSplits[0];
                        urRegistBll.frnrelFrnRelName = msgSplits[1];
                        urRegistBll.usrLastName = msgSplits[2];
                    }
                    else if (msgSplits.Length > 1)
                    {
                        urRegistBll.usrAltMobileNo = msgSplits[0];
                        urRegistBll.frnrelFrnRelName = msgSplits[1];
                    }
                    else if (msgSplits.Length > 0)
                    {
                        urRegistBll.usrAltMobileNo = msgSplits[0];
                    }
                    if (urRegistBll.usrAltMobileNo.Length == 10)
                    {
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status == 0)
                        {   //Mahesh: Send second parameter for only send sms only, because at run time mobile number of sender change.
                            int grId = 0;
                            char[] rr = mkeyword1.ToCharArray();
                            if (rr[0] == 'f' || rr[0] == 'F' || rr[0] == 'R' || rr[0] == 'r')
                            {
                                if (rr[1] == 'R' || rr[1] == 'r' || rr[0] == 'f' || rr[0] == 'F')
                                {

                                    if (checkDigit(rr[2]) >= 48 && checkDigit(rr[2]) <= 57)
                                    {
                                        int len = rr.Length;
                                        if (len > 3)
                                        {
                                            if (checkDigit(rr[3]) >= 48 && checkDigit(rr[2]) <= 57)
                                            {
                                                string id = Convert.ToString(rr[2]) + Convert.ToString(rr[3]);
                                                grId = Convert.ToInt32(id);
                                            }
                                            else
                                            {
                                                string id = Convert.ToString(rr[2]);
                                                grId = Convert.ToInt32(id);
                                            }
                                        }
                                        else
                                        {
                                            string id = Convert.ToString(rr[2]);
                                            grId = Convert.ToInt32(id);
                                        }

                                    }
                                }
                            }
                            AddFriendByLongCodeF(urRegistBll, mobile, grId);
                        }
                    }
                    else
                    {

                        string senderId = "COM2MYCT";
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string passwordMessage = "Dear user please enter valid mobile number." + cc.AddSMS(myMobileNo);
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if ((mkeyword1 == "NCP" || mkeyword1 == "Ncp" || mkeyword1 == "ncp "))
                {
                    try
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        string Mobile = mobile.ToString();

                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status < 1)
                        {
                            string sql = "select * from userMaster where usrMobileNo='" + mobile.ToString() + "'";

                            DataSet ds = new DataSet();
                            ds = cc.ExecuteDataset(sql);
                            string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                            backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
                            subject = "Mail From " + myName.ToString();
                            //emlBody = "\nMail: " + urRegistBll.longCodegrSMS.ToString() + "\n\nFROM: " + urRegistBll.usrFullName.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                            emlBody = "\n\n...www.myct.in";

                            //NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                            urRegistBll.usrMessageString = NewSmsResp.ToString();
                            //ll.sendEmail(emlTo, subject, emlBody);

                            status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                            if (status == 0)
                            {
                                string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
                                string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                                // NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                                NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + passDec.ToString() + " ";
                                cc.SendMessageTra(sender, Mobile, NewSmsResp);
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                                string sqlupdate = "update usermaster set JoinGroup='" + mkeyword1 + "' where usrMobileNo='" + Mobile + "'";
                                string execute = cc.ExecuteScalar(sqlupdate);
                            }
                        }
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }



                }
                    //reach here 
                //////////////////////////////////////////////////////////////////////////////////YUVA///////////////
                else if ((mkeyword1 == "YUVA" || mkeyword1 == "Yuva" || mkeyword1 == "yuva" || mkeyword1 == "UVA" || mkeyword1 == "Uva" || mkeyword1 == "uva"))
                {
                    int flg = 1;
                    try
                    {
                        string usrUserid = "";
                        string memberName = "",schoolcode = "", email = "",memberAddress="";
                        mkeyword1 = mkeyword1.ToUpper();
                        string Mobile = mobile.ToString();
                        string[] mmsg = PinMessage.Split('*');

                        foreach (string str in mmsg)
                        {

                            if (str != "" && str != " " && memberName.Trim() == "")
                            {
                                memberName = str;
                                break;
                            }
                        }

                        foreach (string str in mmsg)
                        {
                            if (str != "" && str != " " && memberName.Trim() != "")
                            {
                                schoolcode = FormCode(str);
                                if (numflag == true)
                                    break;                                                         
                            }
                        }

                        foreach (string str in mmsg)
                        {
                            if (str != "" && str != " " && memberName.Trim() != "")
                            {
                                if (emailMsg(str) == true)
                                {
                                    email = str;
                                    break;     
                                }
                            }
                        }
                        
                        foreach (string str in mmsg)
                        {
                            if (str != "" && str != " " && memberName.Trim() != str.Trim() && schoolcode.Trim() != str.Trim() && email.Trim() != str.Trim())
                            {
                                memberAddress = str;
                                break;     
                            }
                        }
                                                                        //string schoolcode = mmsg[3];
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);


                        if (status < 1)
                        {
                            string sql = "select * from userMaster where usrMobileNo='" + mobile.ToString() + "'";

                            DataSet ds = new DataSet();
                            ds = cc.ExecuteDataset(sql);
                            string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                            usrUserid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
                            backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
                            subject = "Mail From " + myName.ToString();

                            emlBody = "\n\n...www.myct.in";


                            urRegistBll.usrMessageString = NewSmsResp.ToString();


                            status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                            if (status == 0)
                            {
                                string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
                                string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));

                                NewSmsResp = "Dear std thanks to join uva jagar Pl register on www.mitsc.co.in with ur Mob No & Pswd " + passDec.ToString() + " fr all courses.Use same pswd to update u via www.myct.in fr jobs";
                                cc.SendMessageTra(sender, Mobile, NewSmsResp);
                                string sqlinsert = "insert into collegecode(userid,collegecode)values('" + usrUserid + "','" + schoolcode + "')";
                                string a = cc.ExecuteScalar(sqlinsert);
                                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                                string sqlupdate = "update usermaster set JoinGroup='" + mkeyword1 + "' where usrMobileNo='" + Mobile + "'";
                                string execute = cc.ExecuteScalar(sqlupdate);
                            }
                        }
                        if (mkeyword1 == "YUVA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',93)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "UVA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',93)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "MPSC" || mkeyword1 == "Mpsc" || mkeyword1 == "mpsc"))
                {
                    try
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        string Mobile = mobile.ToString();

                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status < 1)
                        {
                            string sql = "select * from userMaster where usrMobileNo='" + mobile.ToString() + "'";

                            DataSet ds = new DataSet();
                            ds = cc.ExecuteDataset(sql);
                            string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                            backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
                            subject = "Mail From " + myName.ToString();
                            //emlBody = "\nMail: " + urRegistBll.longCodegrSMS.ToString() + "\n\nFROM: " + urRegistBll.usrFullName.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                            emlBody = "\n\n...www.myct.in";

                            //NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                            urRegistBll.usrMessageString = NewSmsResp.ToString();
                            //ll.sendEmail(emlTo, subject, emlBody);

                            status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                            if (status == 0)
                            {
                                string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
                                string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                                // NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                                NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/MPSC.aspx?crtevnt http://www.myct.in/MPSC.aspx?ict http://www.myct.in/MPSC.aspx?w7o10 ur login pswd fr www.myct.in is " + passDec.ToString() + " ";
                                cc.SendMessageTra(sender, Mobile, NewSmsResp);
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                                string sqlupdate = "update usermaster set JoinGroup='" + mkeyword1 + "' where usrMobileNo='" + Mobile + "'";
                                string execute = cc.ExecuteScalar(sqlupdate);
                            }
                        }
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urRegistBll.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }



                }


                ///////////////////////////////////////////////////////////////////////////////////////
                else if ((mkeyword1 == "OM" || mkeyword1 == "WSSD" || mkeyword1 == "TTD" || mkeyword1 == "Ttd" || mkeyword1 == "BJP" || mkeyword1 == "BSP" || mkeyword1 == "ANNA" || mkeyword1 == "RAVIDASSIA" || mkeyword1 == "TELI" || mkeyword1 == "CG" || mkeyword1 == "JANGID" || mkeyword1 == "JB" || mkeyword1 == "JM" || mkeyword1 == "MALI" || mkeyword1 == "MSCIT" || mkeyword1 == "SAHU" || mkeyword1 == "DIDIMA" || mkeyword1 == "MSSD" || mkeyword1 == "JAIN" || mkeyword1 == "MSS"))
                {
                    string usrUserid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string Mobile = mobile.ToString();
                    // string m=urRegistBll.
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status < 1)
                    {
                        string sql = "select * from userMaster where usrMobileNo='" + mobile.ToString() + "'";

                        DataSet ds = new DataSet();
                        ds = cc.ExecuteDataset(sql);
                        string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                        usrUserid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
                        backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
                        subject = "Mail From " + myName.ToString();
                        //emlBody = "\nMail: " + urRegistBll.longCodegrSMS.ToString() + "\n\nFROM: " + urRegistBll.usrFullName.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody = "\n\n...www.myct.in";
                        if (mkeyword1 == "JM" || mkeyword1 == "jm")
                            mkeyword1 = "Maheshwari";
                        NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                        urRegistBll.usrMessageString = NewSmsResp.ToString();
                        //ll.sendEmail(emlTo, subject, emlBody);

                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status == 0)
                        {
                            string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
                            string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                            NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            cc.SendMessageTra(sender, Mobile, NewSmsResp);
                            ///////////////////////////////////////////////////////////////////
                            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                            int pkchange = 0;
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                            if (pkchange == 0)
                            {
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                            }
                        }
                    }

                    if (mkeyword1 == "OM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',34)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    //else if (mkeyword1 == "WSSD")
                    //{
                    //    string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',9)";
                    //    string a1 = cc.ExecuteScalar(sql);
                    //}
                    else if (mkeyword1 == "TTD")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',79)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "BJP")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',2)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "BSP")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',78)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "ANNA")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',9)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "RAVIDASSIA")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',27)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "TELI")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',39)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "CG")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',42)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JANGID")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',31)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JB")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',38)";
                        string a1 = cc.ExecuteScalar(sql);
                    }

                    else if (mkeyword1 == "JM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',22)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MALI")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',32)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MSCIT")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',35)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "SAHU")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',41)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "DIDIMA")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',66)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MSSD")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',9)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JAIN")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',28)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    //else if (mkeyword1 == "MSS")
                    //{
                    //    string sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',9)";
                    //    string a1 = cc.ExecuteScalar(sql);
                    //}
                    else
                    { }


                }
                ///////////////////////////////////////////////////////////////////Newspaper Keyword///////////////////////////////////////////////

                else if ((mkeyword1 == "LOKMAT" || mkeyword1 == "MATA" || mkeyword1 == "DESHONNATI" || mkeyword1 == "NBP" || mkeyword1 == "SAKAL" || mkeyword1 == "YUVANXT"))
                {
                    string s = CheckLokmat(WholeMsg);
                    if ((s == "LOKMAT*" || s == "MATA*" || s == "DESHONNATI*" || s == "NBP*" || s == "SAKAL*" || s == "YUVANXT*"))
                    {

                        string[] mmsg = WholeMsg.Split('*');

                        string ss = mmsg[1].ToString();
                        urRegistBll.usrMobileNo = mobile;
                        urRegistBll.usrKeyWord = mkeyword1.ToString();
                        urRegistBll.longCodegrSMS = mmsg[1].ToString();
                        string[] arr = ss.Split(' ');
                        string statusSTR = checkSMSstr(ss);
                        if (statusSTR == "TRUE")
                        {
                            saveNewsSMS(mobile, ss, mkeyword1);
                            sendMailSMS(urRegistBll);
                        }
                    }
                    else if ((s == "LOKMAT " || s == "MATA " || s == "DESHONNATI " || s == "NBP " || s == "SAKAL " || s == "YUVANXT "))
                    {
                        string[] mmsg = WholeMsg.Split(' ');
                        string newkeyword = mmsg[0];
                        int length = Convert.ToInt32(newkeyword.Length);
                        WholeMsg = WholeMsg.Remove(0, length);
                        urRegistBll.usrKeyWord = mkeyword1.ToString();
                        urRegistBll.usrMobileNo = mobile;
                        urRegistBll.longCodegrSMS = WholeMsg;
                        string statusSTR = checkSMSstr(WholeMsg);
                        if (statusSTR == "TRUE")
                        {
                            saveNewsSMS(mobile, WholeMsg, mkeyword1);
                            sendMailSMS(urRegistBll);
                        }
                    }


                }

                ////////////////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "LBTV" || mkeyword1 == "YASHADA" || mkeyword1 == "BJS" || mkeyword1 == "BMC" || mkeyword1 == "CG" || mkeyword1 == "COLLECTOR" || mkeyword1 == "CP" || mkeyword1 == "EO" || mkeyword1 == "MJP" || mkeyword1 == "Mjp" || mkeyword1 == "NMC" || mkeyword1 == "NREGA" || mkeyword1 == "PCMC" || mkeyword1 == "PMC" || mkeyword1 == "RTO" || mkeyword1 == "SP" || mkeyword1 == "ZP" || mkeyword1 == "BJP" || mkeyword1 == "BSP" || mkeyword1 == "DIDIMAA" || mkeyword1 == "DIDIMA"))
                {

                    //string[] mmsg = WholeMsg.Split('*');
                    string[] mmsg1 = PinMessage.Split('*');

                    //if (mmsg1[1] != "*")
                    //{
                    //    mmsg1 = PinMessage.Split(' ');
                    //}

                    string ss = mmsg1[1].ToString();
                    urRegistBll.usrMobileNo = mobile;
                    urRegistBll.usrKeyWord = mkeyword1.ToString();
                    urRegistBll.longCodegrSMS = mmsg1[1].ToString();
                    string[] arr = ss.Split(' ');
                    string statusSTR = checkSMSstr(ss);
                    if (statusSTR == "TRUE")
                    {
                        //saveNewsSMS(mobile, ss, mkeyword1);
                        sendMailSMS(urRegistBll);
                    }
                }

                    //////////////////////////////////////////////////////////////////////////////

                else
                {


                    //string mobileNo = urRegistBll.usrMobileNo;
                    //string smsString = "Dear Plz use proper keyword and check the spelling write in capital letters Thanks Via www.myct.in";
                    //string senderId = "MYCT.IN";

                    //cc.SendMessageTra(senderId, mobileNo, smsString); //Transactional SMS

                    //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    //int pkchange = 0;
                    //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    //if (pkchange == 0)
                    //{
                    //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    //}
                }
            }


        }

        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "Main Calling Function()", "Error: " + ex.ToString() + ex.StackTrace);
            string message = Convert.ToString(Request.QueryString["message"]);
            string mobile = Convert.ToString(Request.QueryString["mobilenumber"]);
            string shortcode = Convert.ToString(Request.QueryString["receivedon"]);
            string Data = ex.Message;

            string Sql = "Insert into come2mycity.test(message, mobile, shortcode, data) values " +
                " ('" + message + "','" + mobile + "','" + shortcode + "','" + Data + "' )";
            //CommonCode cc = new CommonCode();
            cc.ExecuteNonQuery(Sql);
            Response.Write(ex.Message);
        }
        /////////////////////////////////////End of RegisteredKeyword/////////////////////////////////////////////////////////////////

    }//Page Load



    public string checkPinExist(string pinMsg)
    {
        string pinCode = "";
        char[] PinArr = pinMsg.ToCharArray();
        for (int i = 0; i < PinArr.Length; i++)
        {
            if (PinArr[i] >= 48 && PinArr[i] <= 57)
            {
                if (PinArr[i + 1] >= 48 && PinArr[i + 1] <= 57)
                {
                    if (PinArr[i + 2] >= 48 && PinArr[i + 2] <= 57)
                    {
                        if (PinArr[i + 3] >= 48 && PinArr[i + 3] <= 57)
                        {
                            if (PinArr[i + 4] >= 48 && PinArr[i + 4] <= 57)
                            {
                                if (PinArr[i + 5] >= 48 && PinArr[i + 5] <= 57)
                                {
                                    pinCode = PinArr[i].ToString() + PinArr[i + 1].ToString() + PinArr[i + 2].ToString() + PinArr[i + 3].ToString() + PinArr[i + 4].ToString() + PinArr[i + 5].ToString();
                                    return pinCode;
                                }
                            }
                        }
                    }
                }
            }
        }
        return pinCode;

    }

    public void ReeSetPass(UserRegistrationBLL ur)
    {
        try
        {
            string updatePass = cc.DESEncrypt(ur.usrMessageString);
            string sqlUpdate = "update userMaster set usrPassword='" + updatePass.ToString() + "' where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            int i = cc.ExecuteNonQuery(sqlUpdate);
            if (i > 0)
            {
                string nameSql = "select usrFirstName+' '+usrLastName from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";

                string name = "";
                name = cc.ExecuteScalar(nameSql);
                string responseMsg = "Dear " + name.ToString() + ", Your Password :: '" + ur.usrMessageString.ToString() + "' is updated. thanks. Via www.myct.in";
                cc.SendMessageTra("MYCT.IN", ur.usrMobileNo, responseMsg);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "ReeSetPass()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }


    public void CopyGroupByKeyWord(UserRegistrationBLL ur)
    {
        try
        {
            string message = "", from = "", to = "", grf = "", grt = "";
            int grFrom = 0, grTo = 0;
            message = ur.usrMessageString;
            string[] mss = message.Split(' ');
            from = ur.usrMobileNo;
            if (mss.Length >= 3)
            {
                grf = Convert.ToString(mss[0].ToString());
                to = Convert.ToString(mss[1]);
                grt = Convert.ToString(mss[2].ToString());
            }
            else if (mss.Length >= 2)
            {
                grf = Convert.ToString(mss[0].ToString());
                to = Convert.ToString(mss[1]);
                grt = "FR1";
            }
            ur.usrMobileNo = to.ToString();
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            string ToNameSql1 = "select usrFirstName from userMaster where usrMObileNo='" + to.ToString() + "'";
            string ToNameVal1 = cc.ExecuteScalar(ToNameSql1);
            if (ToNameVal1.ToString() != "")
                if (status == 0)
                {
                    grFrom = Convert.ToInt32(grf.Substring(2));
                    grTo = Convert.ToInt32(grt.Substring(2));
                    int DbGroupNo = Convert.ToInt32(grFrom) + 1;
                    string sqlToUserId = "select usrUserId from userMaster where usrMObileNo='" + to.ToString() + "'";
                    string toUsrId = Convert.ToString(cc.ExecuteScalar(sqlToUserId));
                    string sqlFrUi = "select fr.FriendId from FriendRelationMaster fr inner join userMaster um on fr.UserId = um.usrUserId";
                    sqlFrUi += " where um.usrMobileNo='" + from.ToString() + "' and friendGroup='" + DbGroupNo.ToString() + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sqlFrUi);
                    int NoOfFriends = ds.Tables[0].Rows.Count;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string sqlInsert = "insert into FriendRelationMaster(UserId ,FriendId,FriRelName,friendGroup) values('" + toUsrId.ToString() + "','" + dr["FriendId"].ToString() + "','Friend','" + grTo.ToString() + "')";
                        int jjj = cc.ExecuteNonQuery(sqlInsert);

                    }
                    string FromNameSql = "select usrFirstName from userMaster where usrMObileNo='" + from.ToString() + "'";
                    string FromNameVal = cc.ExecuteScalar(FromNameSql);
                    string ToNameSql = "select usrFirstName from userMaster where usrMObileNo='" + to.ToString() + "'";
                    string ToNameVal = cc.ExecuteScalar(ToNameSql);
                    string RespMsg = "Dear " + FromNameVal.ToString() + " ur " + NoOfFriends.ToString() + " friend of FR" + grFrom.ToString() + " group copied to " + ToNameVal.ToString() + " thanks. Via www.myct.in";
                    cc.SendMessageTra("MYCT.IN", from.ToString(), RespMsg);
                    string ResponceToRecever = "";
                    if (grt.ToString() != "")
                        ResponceToRecever = "Dear " + ToNameVal.ToString() + " " + NoOfFriends.ToString() + " friend added in group FR" + grt.ToString() + " frm " + FromNameVal.ToString() + " thanks. Via www.myct.in";
                    else
                        ResponceToRecever = "Dear " + ToNameVal.ToString() + " " + NoOfFriends.ToString() + " friend added in group FR1 frm " + FromNameVal.ToString() + " thanks. Via www.myct.in";
                    cc.SendMessageTra("MYCT.IN", to.ToString(), ResponceToRecever);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }
                }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "CopyGroupByKeyWord()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public bool checkPinKeyWordByVal(string kwd)
    {
        bool flg = true;
        char[] arrPin = kwd.ToCharArray();
        for (int i1 = 0; i1 < arrPin.Length; i1++)
        {
            if (arrPin[i1] >= 48 && arrPin[i1] <= 57)
            {

            }
            else
            {
                flg = false;
                break;
            }
        }
        if (flg == true)
        {
            if (Convert.ToInt32(kwd) >= 099999 && Convert.ToInt32(kwd) <= 999999)
            {
                flg = true;
                return flg;
            }
            else
            {
                flg = false;
                return flg;
            }
        }


        return flg;
    }

    public int CheckPin(string pinCode)
    {
        int flag = 0;
        try
        {
            int pin = Convert.ToInt32(pinCode);
            if (pin <= 999999 && pin >= 099999)
            {
                flag = 1;
            }

        }
        catch (Exception e)
        {
            flag = 0;
            return flag;
        }

        return flag;
    }

    public void setDNDbyLongCode(UserRegistrationBLL ur)
    {
        try
        {
            string DND0 = "Fully blocked";
            string DND1 = "Receiving SMS relating to Banking / Insurance / Financial Products / Credit Cards";
            string DND2 = "Receiving SMS relating to Real Estate";
            string DND3 = "Receiving SMS relating to Education";
            string DND4 = "Receiving SMS relating to Health";
            string DND5 = "Receiving SMS relating to Consumer goods and automobiles";
            string DND6 = "Receiving SMS relating to Communication / Broadcasting / Entertainment / IT";
            string DND7 = "Receiving SMS relating to Tourism and Leisure";
            string response = "Dear ";
            DataSet ds = new DataSet();
            string sqlnm = "select usrFirstName+' '+usrLastName as Name from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            response += cc.ExecuteScalar(sqlnm.ToString()) + " your DND Status: ";
            if (ur.usrDND == 0)
            {
                response += DND0;
            }
            else if (ur.usrDND == 1)
            {
                response += DND1;
            }
            else if (ur.usrDND == 2)
            {
                response += DND2;
            }
            else if (ur.usrDND == 3)
            {
                response += DND3;
            }
            else if (ur.usrDND == 4)
            {
                response += DND4;
            }
            else if (ur.usrDND == 5)
            {
                response += DND5;
            }
            else if (ur.usrDND == 6)
            {
                response += DND6;
            }
            else if (ur.usrDND == 7)
            {
                response += DND7;
            }
            response += " registered with www.myct.in successfully.";

            string DNDAct = "update userMaster set DND=" + ur.usrDND + " where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            int iii = cc.ExecuteNonQuery(DNDAct);
            if (iii > 0)
            {
                cc.SendMessage1("www.myct.in", ur.usrMobileNo, response);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "setDNDbyLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public string checkSMSstr(string sms)
    {
        string status = "TRUE";
        string[] arr = sms.Split(' ');
        if (arr.Length > 1)
        {
            status = "TRUE";
            return status;
        }
        else
        {
            status = "FALSE";
        }
        try
        {
            string sss = Convert.ToString(arr[0]);
            char[] charArr = sss.ToCharArray();
            if (charArr[0] >= 48 && charArr[0] <= 57)
            {
                if (charArr[1] >= 48 && charArr[1] <= 57)
                {
                    status = "FALSE";
                }
            }
        }
        catch (Exception rr)
        {
            status = "TRUE";
            throw rr;

        }


        return status;
    }

    public void saveNewsSMS(string mobile, string message1, string keyword)
    {
        try
        {
            string citySQL = "Select usrCityId from UserMaster Where usrMobileNo='" + mobile.ToString() + "'";
            int cid = Convert.ToInt32(cc.ExecuteScalar(citySQL));
            string sql1 = "select usrFirstName+' '+usrLastName as name from userMaster where usrMobileNo='" + mobile.ToString() + "'";
            string Name = cc.ExecuteScalar(sql1);
            string GrNameVal = keyword.ToString();
            string grnmword = "", GroupTypeName = "";
            if (GrNameVal == "ANNA")
            {
                grnmword = "Anna Group";
                GroupTypeName = "Social Group";
            }
            else if (GrNameVal == "LOKMAT")
            {
                grnmword = "Lokmat Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "SAKAL")
            {
                grnmword = "Sakal Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
            {
                grnmword = "Mata Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "DESHONNATI")
            {
                grnmword = "Deshonnati";
                GroupTypeName = "Favorite News Papers Group";
            }


            string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
            string groupId = cc.ExecuteScalar(groupName);
            string missingval = "set IDENTITY_INSERT News_Update ON  DECLARE @next int  DECLARE @min int select @min = MIN($IDENTITY) from News_Update  IF @min = IDENT_SEED('News_Update')  select @next = MIN($IDENTITY) + IDENT_INCR('News_Update')   FROM News_Update t1 Where $IDENTITY BETWEEN IDENT_SEED('News_Update') AND 32767 AND NOT EXISTS( select * from News_Update t2  where t2.$IDENTITY = t1.$IDENTITY+IDENT_INCR('News_Update'))  ELSE select @next = IDENT_SEED('News_Update') ";
            missingval += "Insert into News_Update(id,NewsFrom,News,GroupValId,CityId) Values(@next,'" + Name.ToString() + "','" + message1.ToString() + "'," + Convert.ToInt32(groupId) + "," + cid + ")";
            int i = cc.ExecuteNonQuery(missingval);

            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "saveNewsSMS()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public int checkGroupSMSCode(string smsCode)
    {


        int flag = 0;
        try
        {
            //int pin = Convert.ToInt32(smsCode);
            //if (pin <= 30 && pin >= 01)
            //{
            //    flag = 1;
            //}
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

    public void UpdateName(UserRegistrationBLL urRegistBll1)
    {
        try
        {
            status = urRegistBll.BLLUpdateUserNameByLongCode(urRegistBll1);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = urRegistBll1.usrMobileNo;
                string Name = urRegistBll1.usrFirstName + " " + urRegistBll1.usrLastName;
                string Message = "Dear " + Name + ", Your Name is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessageTra(senderId, mobileNo, Message);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateName()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void UpdateFirstName(UserRegistrationBLL urRegistBll2)
    {
        try
        {
            status = urRegistBll.BLLUpdateFirstNameByLongCode(urRegistBll2);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = urRegistBll2.usrMobileNo;
                string Name = urRegistBll2.usrFirstName;
                string Message = "Dear " + Name + ", Your Name is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessageTra(senderId, mobileNo, Message);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateFirstName()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void changeMobileNoByLongCode(UserRegistrationBLL ur)
    {
        try
        {

            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrAltMobileNo;
                string Message = "Dear Given number is already registered with come2mycity.com." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
                    string senderId = "COM2MYCT";
                    string mobileNo = ur.usrMobileNo;
                    string altMobileNo = ur.usrAltMobileNo;
                    string myPassword = cc.DESDecrypt(ur.usrPassword);
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string message = "Dear,Password for ur Login with your New Registered Mobile No is:" + myPassword + " " + cc.AddSMS(mobileNo);
                    cc.SendMessage1(senderId, mobileNo, message);
                    cc.SendMessageImp1(senderId, altMobileNo, message);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "changeMobileNoByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void UpdateAddressByLongCode(UserRegistrationBLL ur, int SmsSendFlag)
    {
        try
        {
            status = urRegistBll.BLLUpdateUserAddressByLongCode(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear Your Address is Updated Successfully." + cc.AddSMS(mobileNo);
                if (SmsSendFlag < 1)
                    cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }

        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateAddressByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void addGroupByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                //DataTable dt1 = new DataTable();
                string sql = "select usrUserId, usrFirstName,usrLastName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql);
                //dt1 = ds.Tables[0];
                string userId;
                string usrFName = "", usrLName = "";
                int cityId;
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    userId = Convert.ToString(dr1["usrUserId"]);
                    usrFName = Convert.ToString(dr1["usrFirstName"]);
                    usrLName = Convert.ToString(dr1["usrLastName"]);
                    cityId = Convert.ToInt32(dr1["usrCityId"]);
                    ur.usrUserId = Convert.ToString(userId);
                    ur.usrFirstName = Convert.ToString(usrFName);
                    ur.usrLastName = Convert.ToString(usrLName);

                    //ur.frnrelFrnRelName = usrName;
                    //ur.frnrelRelation = "friend";
                    //ur.frnrelGroup = "1";

                }

                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);
                string cid = "", cName = "", did = "", sid = "";
                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityName = Convert.ToString(cName);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }

                if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
                {
                    cid = "37";
                    cName = "Pune City";
                    did = "300";
                    sid = "15";
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
                string GrNameVal = ur.usrKeyWord;
                string grnmword = "", GroupTypeName = "";
                if (GrNameVal == "ANNA")
                {
                    grnmword = "Anna Group";
                    GroupTypeName = "Social Group";
                }
                else if (GrNameVal == "LOKMAT")
                {
                    grnmword = "Lokmat Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "SAKAL")
                {
                    grnmword = "Sakal Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
                {
                    grnmword = "Mata Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "DESHONNATI")
                {
                    grnmword = "Deshonnati";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "YUVANXT")
                {
                    grnmword = "Yuvanxt Group";
                    GroupTypeName = "Favorite News Papers Group";
                }


                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
                storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
                int groupFlag = 0, UsrMastFlag = 0;
                string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                string uID = "";
                uID = cc.ExecuteScalar(checkPrevGrReg);
                if (uID.ToString() == "")
                {
                    groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                }
                UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
                if (groupFlag > 0 && UsrMastFlag > 0)
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "";
                    if (GrNameVal == "YUVANXT")
                    {
                        grnmword = "Lokmat Yuvanxt Group";
                        GroupTypeName = "Favorite News Papers Group";
                        smsString = "Thanks " + ur.usrFirstName + " 2 join " + grnmword.ToString() + ". U will get regular updates by sms/mail " + cc.AddSMS(mobileNo);
                    }
                    else
                    {
                        smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                    }
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }
                }
                else
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + GroupTypeName.ToString() + " as " + grnmword.ToString() + "." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }
                }
            }
            else
            {


                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);
                string cid = "", cName = "", did = "", sid = "";
                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityName = Convert.ToString(cName);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
                if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
                {
                    cid = "37";
                    cName = "Pune City";
                    did = "300";
                    sid = "15";
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);


                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);

                    //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                    string passwordMessage = "Dear " + ur.usrFirstName + " registered you " + cName + " city in come2mycity.com. U use it to send SMS.Dear " + ur.usrFirstName + ",Password for ur First Login is " + myPassword + " for come2myCity.com";
                    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                    string thisDir = Server.MapPath("~");
                    //if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                    //{
                    //    System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    //    File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    //}

                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
                string GrNameVal = ur.usrKeyWord;
                string grnmword = "", GroupTypeName = "";
                if (GrNameVal == "ANNA")
                {
                    grnmword = "Anna Group";
                    GroupTypeName = "Social Group";
                }
                else if (GrNameVal == "LOKMAT")
                {
                    grnmword = "Lokmat Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "SAKAL")
                {
                    grnmword = "Sakal Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
                {
                    grnmword = "Mata Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "DESHONNATI")
                {
                    grnmword = "Deshonnati";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "YUVANXT")
                {
                    grnmword = "Yuvanxt Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToUInt32(groupId) + ")";
                string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
                storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
                int groupFlag = 0, UsrMastFlag = 0;
                groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
                if (groupFlag > 0 && UsrMastFlag > 0)
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "";
                    if (GrNameVal == "YUVANXT")
                    {
                        grnmword = "Lokmat Yuvanxt Group";
                        GroupTypeName = "Favorite News Papers Group";
                        smsString = "Thanks " + ur.usrFirstName + " 2 join " + grnmword.ToString() + ". U will get regular updates by sms/mail " + cc.AddSMS(mobileNo);
                    }
                    else
                    {
                        smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                    }
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "addGroupByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public bool CheckPaidSmsGroup(string key)
    {
        bool flag = false;
        char[] keyArr = key.ToCharArray();
        if (keyArr[0] == 'P' || keyArr[0] == 'P')
        {
            if (keyArr[1] >= 48 && keyArr[1] <= 57)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

        }
        else
        {
            flag = false;
        }

        return flag;
    }

    public void sendPaidGroupSms(UserRegistrationBLL ur, int GrId)
    {
        try
        {
            int smsCount = 0;
            string keyWord = ur.usrKeyWord;
            string msg = ur.usrMessageString;
            string usrMobileNo = ur.usrMobileNo;
            string usrSql = "select usrFirstName,usrUserId,paidCount from userMaster where usrMobileNo='" + usrMobileNo.ToString() + "'";
            string unm = "", UserId = "";
            int pdBal = 0;
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(usrSql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                unm = Convert.ToString(dr["usrFirstName"]);
                UserId = Convert.ToString(dr["usrUserId"]);
                pdBal = Convert.ToInt32(dr["paidCount"]);
            }
            string sqlGroupMem = "select GM.MemMoNo from tblGroupSmsMember GM inner join tblPaidSmsGroup GID on GM.GrIdRf = GID.GrId where GM.GroupId='2' AND GID.UserId='" + UserId.ToString() + "'";
            DataSet ds1 = new DataSet();
            ds1 = cc.ExecuteDataset(sqlGroupMem);
            if (msg.Length <= 140)
            {
                smsCount = ds1.Tables[0].Rows.Count;
            }
            else if (msg.Length <= 300)
            {
                smsCount = 2 * ds1.Tables[0].Rows.Count;
            }
            else if (msg.Length <= 460)
            {
                smsCount = 3 * ds1.Tables[0].Rows.Count;
            }
            if (pdBal >= smsCount)
            {
                string smsSendStr = msg + " -www.myct.in";
                string mono = "";
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    mono = Convert.ToString(dr["MemMoNo"]);
                    cc.SendMessage1(mono, mono, smsSendStr);

                }
                string SqlUpdateBal = "update UserMaster set paidCount=" + (pdBal - smsCount) + " where usrMobileNo='" + usrMobileNo.ToString() + "'";
                int ijk = cc.ExecuteNonQuery(SqlUpdateBal);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }
            else
            {
                string ResStr = "Dear " + unm.ToString() + ", You dont have PAID sufficiant balance to send SMS.";
                cc.SendMessage1(usrMobileNo, usrMobileNo, ResStr);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "sendPaidGroupSms()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void addGroupByLongCodeJNS(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                //DataTable dt1 = new DataTable();
                string sql = "select usrUserId, usrFirstName,usrLastName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql);
                //dt1 = ds.Tables[0];
                string userId;
                string usrFName = "", usrLName = "";
                int cityId;
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    userId = Convert.ToString(dr1["usrUserId"]);
                    usrFName = Convert.ToString(dr1["usrFirstName"]);
                    usrLName = Convert.ToString(dr1["usrLastName"]);
                    cityId = Convert.ToInt32(dr1["usrCityId"]);
                    ur.usrUserId = Convert.ToString(userId);
                    ur.usrFirstName = Convert.ToString(usrFName);
                    ur.usrLastName = Convert.ToString(usrLName);

                    //ur.frnrelFrnRelName = usrName;
                    //ur.frnrelRelation = "friend";
                    //ur.frnrelGroup = "1";

                }

                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);
                string cid = "", cName = "", did = "", sid = "";
                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityName = Convert.ToString(cName);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }

                if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
                {
                    cid = "37";
                    cName = "Pune City";
                    did = "300";
                    sid = "15";
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
                string GrNameVal = ur.usrKeyWord;
                string grnmword = "", GroupTypeName = "";
                if (GrNameVal == "ANNA")
                {
                    grnmword = "Anna Group";
                    GroupTypeName = "Social Group";
                }
                else if (GrNameVal == "LOKMAT")
                {
                    grnmword = "Lokmat Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "SAKAL")
                {
                    grnmword = "Sakal Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
                {
                    grnmword = "Mata Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "DESHONNATI")
                {
                    grnmword = "Deshonnati";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "JNS")
                {
                    grnmword = "Jest Nagarik Sangh";
                    GroupTypeName = "Social Group";
                }


                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
                storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
                int groupFlag = 0, UsrMastFlag = 0;
                string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                string uID = "";
                uID = cc.ExecuteScalar(checkPrevGrReg);
                if (uID.ToString() == "")
                {
                    groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                }
                UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
                if (groupFlag > 0 && UsrMastFlag > 0)
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }
                }
                else
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + GroupTypeName.ToString() + " as " + grnmword.ToString() + "." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }
                }
            }
            else
            {


                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);
                string cid = "", cName = "", did = "", sid = "";
                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityName = Convert.ToString(cName);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
                if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
                {
                    cid = "37";
                    cName = "Pune City";
                    did = "300";
                    sid = "15";
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
                urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

                Random rnd = new Random();
                urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);


                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urRegistBll.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);

                    //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                    string passwordMessage = "Dear " + ur.usrFirstName + " registered you " + cName + " city in come2mycity.com. U use it to send SMS.Dear " + ur.usrFirstName + ",Password for ur First Login is " + myPassword + " for come2myCity.com";
                    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
                string GrNameVal = ur.usrKeyWord;
                string grnmword = "", GroupTypeName = "";
                if (GrNameVal == "ANNA")
                {
                    grnmword = "Anna Group";
                    GroupTypeName = "Social Group";
                }
                else if (GrNameVal == "LOKMAT")
                {
                    grnmword = "Lokmat Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "SAKAL")
                {
                    grnmword = "Sakal Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
                {
                    grnmword = "Mata Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "DESHONNATI")
                {
                    grnmword = "Deshonnati";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "JNS")
                {
                    grnmword = "Jest Nagarik Sangh";
                    GroupTypeName = "Social Group";
                }
                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToUInt32(groupId) + ")";
                string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
                storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
                int groupFlag = 0, UsrMastFlag = 0;
                groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
                if (groupFlag > 0 && UsrMastFlag > 0)
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "addGroupByLongCodeJNS()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void JoinGroupByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                //DataTable dt1 = new DataTable();
                string sql = "select usrUserId, usrFirstName,usrLastName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql);
                //dt1 = ds.Tables[0];
                string userId;
                string usrFName = "", usrLName = "";
                int cityId;
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    userId = Convert.ToString(dr1["usrUserId"]);
                    usrFName = Convert.ToString(dr1["usrFirstName"]);
                    usrLName = Convert.ToString(dr1["usrLastName"]);
                    cityId = Convert.ToInt32(dr1["usrCityId"]);
                    ur.usrUserId = Convert.ToString(userId);
                    ur.usrFirstName = Convert.ToString(usrFName);
                    ur.usrLastName = Convert.ToString(usrLName);

                }
                string GrNameVal = ur.usrKeyWord.ToUpper();
                string grnmword = "", GroupTypeName = "";
                if (GrNameVal == "ANNA ")
                {
                    grnmword = "Anna Group";
                    GroupTypeName = "Social Group";
                }
                else if (GrNameVal.ToString() == "LOKMAT ")
                {
                    grnmword = "Lokmat Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "SAKAL ")
                {
                    grnmword = "Sakal Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "MATA " || GrNameVal == "MATAA ")
                {
                    grnmword = "Mata Group";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "DESHONNATI ")
                {
                    grnmword = "Deshonnati";
                    GroupTypeName = "Favorite News Papers Group";
                }
                else if (GrNameVal == "I Congress ")
                {
                    grnmword = "I Congress grop";
                    GroupTypeName = "Favorite Political Group";

                }
                else if (GrNameVal == "NCP ")
                {
                    grnmword = "NCP group";
                    GroupTypeName = "Favorite Political Group";
                }
                else if (GrNameVal == "BJP ")
                {
                    grnmword = "BJP Group";
                    GroupTypeName = "Favorite Political Group";
                }
                else if (GrNameVal == "NCP YOUTH ")
                {
                    grnmword = "NCP youth group";
                    GroupTypeName = "Favorite Political Group";
                }
                else
                {
                    grnmword = "Complaint Group";
                    GroupTypeName = "Favorite Complaint Group";
                }

                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                int groupFlag = 0;
                string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                string uID = "";
                uID = cc.ExecuteScalar(checkPrevGrReg);
                if (uID.ToString() == "")
                {
                    groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                }
                string groupItemId = "select GroupItemId from GroupValue where GroupValueId=" + Convert.ToInt32(groupId);
                string groupItemIdVal = cc.ExecuteScalar(groupItemId);
                string GroupName = "Select GroupName from GroupItem where GroupId=" + Convert.ToInt32(groupItemIdVal);
                string GroupNameVal = cc.ExecuteScalar(GroupName);
                if (groupFlag > 0)
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + Convert.ToString(GroupNameVal) + " as " + ur.usrKeyWord + " is updated succefully." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                }
                else
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + Convert.ToString(GroupNameVal) + " as " + ur.usrKeyWord + "." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "JoinGroupByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void UpdateAreaByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLUpdateAreaByLongCode(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear Your Area is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateAreaByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void UpdateByLongCodePIN(UserRegistrationBLL ur)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);


            }

            status = urRegistBll.BLLUpdatePinByLongCodePIN(ur);
            //if (status > 0)
            //{
            //    string senderId = "COM2MYCT";
            //    string mobileNo = ur.usrMobileNo;
            //    string Message = "Dear user your PIN code is Updated Successfully." + cc.AddSMS(mobileNo);
            //    cc.SendMessage1(senderId, mobileNo, Message);
            //    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            //    int pkchange = 0;
            //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //    if (pkchange == 0)
            //    {
            //        pkchange = cc.ExecuteNonQuery(changeFlagSql);
            //    }
            //}
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateByLongCodePIN()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void UpdatePINbyFindingPIN(UserRegistrationBLL ur)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);


            }

            status = urRegistBll.BLLUpdatePinByLongCodePIN(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear user your PIN code is Updated Successfully." + cc.AddSMS(mobileNo);
                //cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdatePINbyFindingPIN()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void RegisterByLongCodePINNewOm(UserRegistrationBLL ur, string KeyWord, string myKeyWd)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);


            }



            ur.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            ur.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            status = urRegistBll.BLLInsertUserRegistrationInitial(ur);


            if (status > 0)
            {
                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + KeyWord.ToString() + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                int groupFlag = 0;
                string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                string uID = "";
                uID = cc.ExecuteScalar(checkPrevGrReg);
                if (uID.ToString() == "")
                {
                    groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                }
                string senderId = "MYCT.IN";
                string myMobileNo = urRegistBll.usrMobileNo;
                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                string passwordMessage = ur.usrMessageString;
                //passwordMessage += "Ur login pswd fr myct.in is "+myPassword .ToString ()+" Via: www.myct.in";
                passwordMessage += " Ur login pswd fr myct.in is " + myPassword.ToString() + ".Via: www.myct.in";
                string passMsgNew = "JAY Jijau Welcome by Maratha Seva Sangh(MSS) Update ur profile on www.myct.in Ur paswrd of login " + myPassword.ToString() + " Tell to do the same to all MSS members for comunication";
                //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                //string passwordMessage = "Dear " + ur.usrFirstName + " registered you in city " + cName + " on come2mycity.com. U use it to send SMS.Password for ur First Login is " + myPassword + " for come2myCity.com";
                //cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                cc.SendMessageTra(senderId, myMobileNo, passwordMessage, KeyWord);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    //System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    //File.Copy(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }

                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }



        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RegisterByLongCodePINNew()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void RegisterByLongCodeNew(UserRegistrationBLL ur)
    {

        string NewMessage = "Select Message from come2mycity.test where mobile='91" + ur.usrMobileNo + "' and PK='" + ur.usrPKval + "'";

        string Message = cc.ExecuteScalar(NewMessage);
        string msg1 = Convert.ToString(Message);
        string WholeMsg = msg1;
        string messageJM;

        messageJM = msg1.Replace("'", "sssss");
        messageJM = msg1.Replace("&", "aaaaa");
        string[] StrSep = messageJM.Split('*');
        for (int i = 0; i < StrSep.Length; i++)
        {
            msg1 = StrSep[i].Trim();
            if (StrSep.Length > 1)
            {
                //messageJM = StrSep[i + 1].ToString();


                if (StrSep[i].Trim() == "P" || StrSep[i].Trim() == "V" || StrSep[i].Trim() == "G")
                {
                    if (StrSep[i].Trim() == "P")
                    {

                        StrSep[i] = "Professional";

                    }
                    else if (StrSep[i].Trim() == "G")
                    {
                        StrSep[i] = "Guest";

                    }

                    else if (StrSep[i].Trim() == "V")
                    {
                        StrSep[i] = "Volunteer";

                    }

                    ur.usrCategory = StrSep[i].Trim();
                }
                else if (StrSep[i].Trim() == "M" || StrSep[i].Trim() == "F")
                {


                    if (StrSep[i].Trim() == "M")
                    {
                        StrSep[i] = "Male";
                    }
                    else if (StrSep[i].Trim() == "F")
                    {
                        StrSep[i] = "Female";
                    }
                    ur.usrGender = StrSep[i].Trim();

                }



                else if (StrSep[i].Contains("@"))
                {
                    ur.usrEmailId = Convert.ToString(StrSep[i].Trim());


                }
                else if (StrSep[6].Length > 1)
                {
                    ur.Age = Convert.ToInt32(StrSep[6].Trim());



                }




            }

            string aa = "Insert into UserMaster(usrEmailId,usrGender,Age,usrCategory)values('" + ur.usrEmailId + "','" + ur.usrGender + "'," + ur.Age + ",'" + ur.usrCategory + "') where mobile='91" + ur.usrMobileNo + "' ";

            status = urRegistBll.BLLInsertUserRegistrationInitialNew(ur);

        }
    }
    public void RegisterByLongCodePINNew(UserRegistrationBLL ur, string KeyWord)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);
            }

            ur.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            ur.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            string strmessage = "select Message from test where PK='" + urRegistBll.usrPKval + "'" + urRegistBll.usrMobileNo;
            string msg = "";
            msg = cc.ExecuteScalar(strmessage);



            status = urRegistBll.BLLInsertUserRegistrationInitial(ur);


            if (status > 0)
            {
                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + KeyWord.ToString() + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                int groupFlag = 0;
                string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                string uID = "";
                uID = cc.ExecuteScalar(checkPrevGrReg);
                if (uID.ToString() == "")
                {
                    groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                }
                string senderId = "MYCT.IN";
                string myMobileNo = urRegistBll.usrMobileNo;
                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                string passwordMessage = ur.usrMessageString;
                //passwordMessage += "Ur login pswd fr myct.in is "+myPassword .ToString ()+" Via: www.myct.in";
                passwordMessage += " Ur login pswd fr myct.in is " + myPassword.ToString() + ".Via: www.myct.in";
                string passMsgNew = "JAY Jijau Welcome by Maratha Seva Sangh(MSS) Update ur profile on www.myct.in Ur paswrd of login " + myPassword.ToString() + " Tell to do the same to all MSS members for comunication";
                //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                //string passwordMessage = "Dear " + ur.usrFirstName + " registered you in city " + cName + " on come2mycity.com. U use it to send SMS.Password for ur First Login is " + myPassword + " for come2myCity.com";
                //cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                cc.SendMessageTra(senderId, myMobileNo, passwordMessage, KeyWord);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    //System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    //File.Copy(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }

                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }



        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RegisterByLongCodePINNew()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void RegisterByLongCodePIN(UserRegistrationBLL ur)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);


            }



            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);


            if (status > 0)
            {
                string senderId = "MYCT.IN";
                string myMobileNo = urRegistBll.usrMobileNo;
                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);

                //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                string passwordMessage = "Dear " + ur.usrFirstName + " registered you in city " + cName + " on come2mycity.com. U use it to send SMS.Password for ur First Login is " + myPassword + " for come2myCity.com";
                string NewPassTraMsg = "Dear " + ur.usrFirstName.ToString() + " ur registered on www.myct.in your password for login " + myPassword.ToString() + " thanks.via www.myct.in";

                cc.SendMessageTra(senderId, myMobileNo, NewPassTraMsg);
                //cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }

                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }



        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RegisterByLongCodePIN()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void RecoverPasswordByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            DataTable dtUserInfoList;
            string mobileNo = ur.usrMobileNo; ;
            urRegistBll.BLLUserPasswordRecovery(mobileNo, out dtUserInfoList, out status);

            if (status > 0)
            {
                DataTable dtUserSMSInfoList = dtUserInfoList;
                DataRow dRowUserInfo = dtUserSMSInfoList.Rows[0];
                //string myMobileNo = "91"+Convert.ToString(dRowUserInfo["usrMobileNo"]);
                string myMobileNo = Convert.ToString(dRowUserInfo["usrMobileNo"]);
                string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfo["usrPassword"]));
                string myName = Convert.ToString(dRowUserInfo["usrFullName"]);


                string sendFrom = "COM2MYCT";
                //string passwordMessage = "Dear " + myName + ", Your Password For Login is :: " + myPassword + " " + cc.AdvMessage();
                string passwordMessage = "Dear " + myName + ", Your Password For Login is :: '" + myPassword + "'. " + cc.AddSMS(myMobileNo);
                string strPassTra = "THANKS to join group in all India mobile directory on www.myct.in to receive imp sms. Ur login pswd fr myct.in is '" + myPassword.ToString() + "'. Via: www.myct.in";
                string newPasswordMsg = "Dear " + myName.ToString() + " ur password for www.myct.in is " + myPassword.ToString() + " thanks.Via www.myct.in";
                cc.SendMessageTra(sendFrom, myMobileNo, newPasswordMsg);
                //cc.SendMessageImp1(sendFrom, myMobileNo, strPassTra);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }


        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RecoverPasswordByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

   
    public void SendMessagetoAllLongCode(UserRegistrationBLL ur)
    {
        try
        {
            DateTime date = DateTime.Now;
            string todaysDate = date.ToShortDateString();
            int smsBal = 0, smsLength = 0, totalSms = 0, smsCharge = 0;
            string sysdate = "";
            string FirstName = "";
            string LCsms = ur.longCodegrSMS;
            string[] smsArr = LCsms.Split(' ');
            string ActualSMS = "";
            int smsCode = Convert.ToInt32(smsArr[0]);
            for (int i = 1; i < smsArr.Length - 1; i++)
            {
                ActualSMS += smsArr[i].ToString() + " ";
            }
            string sql = "select usrFirstName,smsbal,usrUserid from usermaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet dset = cc.ExecuteDataset(sql);
            smsBal = Convert.ToInt32(dset.Tables[0].Rows[0]["smsbal"]);
            FirstName = Convert.ToString(dset.Tables[0].Rows[0]["usrFirstName"]);
            userId = Convert.ToString(dset.Tables[0].Rows[0]["usrUserid"]);
            GrNameId = Convert.ToInt32(smsCode);
            grpsmsbylongcode();
            DataSet ds111 = new DataSet();
            ds111 = cc.ExecuteDataset(GrMembers);
            string GrMemberId = "";
            string GrMemMoNoSQL = "", GrMemMoNo = "";
            string sender = ur.usrMobileNo;
            string sms = ActualSMS.ToString();
            smsLength = sms.Length;
            smsLength = 60 + smsLength;
            totalSms = ds111.Tables[0].Rows.Count;
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
                 "values('" + userId + "','" + mobile + "','"+ActualSMS+"','" + totalSms.ToString() + "','"+smsLength+"','" + smsCharge + "','" + smsBal + "','" + smsBalance + "','" + todaysDate + "')";
            string b = cc.ExecuteScalar(sqlinsert);
            string ResponceMsg = "Dear " + FirstName + " Total " + totalSms.ToString() + " messages sent to " + smsCode.ToString() + " group members thanks.via www.myct.in";
            cc.SendMessageTra("MYCT.IN", ur.usrMobileNo, ResponceMsg);
            if ((smsCharge <= smsBal))
            {
                string dndSql = "";
                int dndFales = 0;

                foreach (DataRow dr123 in ds111.Tables[0].Rows)
                {

                    sender = "myct.in";
                    string SenderMobile = ur.usrMobileNo;
                    GrMemberId = Convert.ToString(dr123["FriendId"]);
                    prefix = Convert.ToString(dr123["FriendPrefix"]);
                    infix = Convert.ToString(dr123["FriendInfix"]);
                    postfix = Convert.ToString(dr123["FriendPostfix"]);
                    senderid = Convert.ToString(dr123["Senderid"]);

                    GrMemMoNoSQL = "Select usrMobileNo from UserMaster where usrUserId='" + GrMemberId + "'";
                    GrMemMoNo = cc.ExecuteScalar(GrMemMoNoSQL);
                    dndSql = "Select DND from UserMaster where usrUserId='" + GrMemberId + "'"; ;
                    string MydndFlg = cc.ExecuteScalar(dndSql);
                    if (MydndFlg == "")
                    {

                        dndFales = 0;
                    }
                    else
                    {

                        dndFales = 0;
                    }
                    if (dndFales == 0)
                    {
                        string dndName = "Select usrFirstName from UserMaster where usrUserId='" + GrMemberId + "'";
                        string MyFriendName = cc.ExecuteScalar(dndName);
                        if (MyFriendName != "")
                        {
                            if (infix != "")
                            {

                                sms = " " + prefix + " " + infix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
                            }
                            else
                            {
                                sms = " " + prefix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
                            }


                            cc.SendMessageTra(senderid, GrMemMoNo, sms);

                            sysdate = DateTime.Now.ToString("MM/dd/yyyy");


                            string sql12 = "insert into ReportData(msgFrom,msgTo,msgDate,sendername,Msg,FlagStatus)" +
                                "values('" + ur.usrMobileNo + "','" + GrMemMoNo + "','" + sysdate + "','" + senderid + "','" + sms + "','0')";
                            int a12 = cc.ExecuteNonQuery(sql12);
                        }
                        else
                        {
                            string dndNameAlternate = "Select usrFirstName from UserMaster where usrUserId='" + GrMemberId + "'";
                            string MyFriendNameAlternate = cc.ExecuteScalar(dndNameAlternate);


                            if (infix != "")
                            {

                                sms = " " + prefix + " " + infix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
                            }
                            else
                            {
                                sms = " " + prefix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
                            }

                            cc.SendMessageTra(senderid, GrMemMoNo, sms);
                            sysdate = DateTime.Now.ToString("MM/dd/yyyy");


                            string sql122 = "insert into ReportData(msgFrom,msgTo,msgDate,sendername,Msg,FlagStatus)" +
                                "values('" + ur.usrMobileNo + "','" + GrMemMoNo + "','" + sysdate + "','" + senderid + "','" + sms + "','0')";
                            int a121 = cc.ExecuteNonQuery(sql122);

                        }
                    }
                    else
                    {
                        smsCharge--;
                    }

                    sms = "";
                    sms = ActualSMS.ToString();

                }

                string sqlBalUpdate1 = "update userMaster set SMSbal=" + smsBalance.ToString() + " where usrMobileNo='" + ur.usrMobileNo + "'";
                int i1 = cc.ExecuteNonQuery(sqlBalUpdate1);
               
                string qq = "update test set no_sentmessage='" + totalSms + "', FlagStatus = 0 where PK='" + urRegistBll.usrPKval + "'";
                int a = cc.ExecuteNonQuery(qq);


            }
            else
            {
                string smsResponse = "Dear " + FirstName + ", You dont have sufficient balance " + cc.AddSMS(sender);
                cc.SendMessageTra(sender, sender, smsResponse);
 
            }
        }
        catch (Exception ex)
        { }
    }
    //public void SendMessageToAllByLongCode1(UserRegistrationBLL ur)
    //{

    //    try
    //    {
    //        DateTime date = DateTime.Now;
    //        string todaysDate = date.ToShortDateString();
    //        int smsBal = 0, dBal = 0, mBal = 0, smsLength = 0, totalSms = 0, smsCharge = 0, smsbalcut = 0;
    //        string sysdate = "", dd1 = "";

    //        string LCsms = ur.longCodegrSMS;
    //        string[] smsArr = LCsms.Split(' ');
    //        string ActualSMS = "";
    //        int smsCode = Convert.ToInt32(smsArr[0]);
    //        for (int i = 1; i < smsArr.Length - 1; i++)
    //        {
    //            ActualSMS += smsArr[i].ToString() + " ";
    //        }
    //        string sql = "select SMSbal,mCount,dCount,usrUserId, usrFirstName,usrLastName,usrCityId ,GroupName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
    //        DataSet ds = new DataSet();
    //        ds = cc.ExecuteDataset(sql);


    //        string usrFName = "", usrLName = "", UserGroupsNames = "";
    //        int cityId;
    //        foreach (DataRow dr1 in ds.Tables[0].Rows)
    //        {
    //            userId = Convert.ToString(dr1["usrUserId"]);
    //            usrFName = Convert.ToString(dr1["usrFirstName"]);
    //            usrLName = Convert.ToString(dr1["usrLastName"]);
    //            cityId = Convert.ToInt32(dr1["usrCityId"]);
    //            UserGroupsNames = Convert.ToString(dr1["GroupName"]);
    //            smsBal = Convert.ToInt32(dr1["SMSbal"]);
    //            dBal = Convert.ToInt32(dr1["dCount"]);
    //            mBal = Convert.ToInt32(dr1["mCount"]);
    //            ur.usrUserId = Convert.ToString(userId);
    //            ur.usrFirstName = Convert.ToString(usrFName);
    //            ur.usrLastName = Convert.ToString(usrLName);
    //            ur.UsrGroupNames = Convert.ToString(UserGroupsNames);

    //        }
    //        string[] arrUrGrNames = UserGroupsNames.Split(',');
    //        GrNameId = Convert.ToInt32(smsCode);


    //        grpsmsbylongcode();




    //        DataSet ds111 = new DataSet();
    //        ds111 = cc.ExecuteDataset(GrMembers);
    //        string GrMemberId = "";
    //        string GrMemMoNoSQL = "", GrMemMoNo = "";
    //        string sender = ur.usrMobileNo;
    //        string sms = ActualSMS.ToString();
    //        smsLength = sms.Length;
    //        totalSms = ds111.Tables[0].Rows.Count;
    //        if (smsLength <= 80)
    //        {
    //            smsCharge = 1 * totalSms;
    //        }
    //        else if (smsLength <= 240)
    //        {
    //            smsCharge = 2 * totalSms;
    //        }
    //        else
    //        {
    //            smsCharge = 3 * totalSms;
    //        }
    //        string ResponceMsg = "Dear " + usrFName.ToString() + " Total " + totalSms.ToString() + " messages sent to " + smsCode.ToString() + " group members thanks.via www.myct.in";
    //        cc.SendMessageTra("MYCT.IN", ur.usrMobileNo, ResponceMsg);
    //        string qq = "update test set no_sentmessage='" + totalSms + "', FlagStatus = 0 where PK='" + urRegistBll.usrPKval + "'";
    //        int a = cc.ExecuteNonQuery(qq);


    //        smsBal = smsBal - 1;
    //        string sq = "update usermaster set smsBal='" + smsBal + "' where usrMobileNo='" + ur.usrMobileNo + "'";
    //        int flag = cc.ExecuteNonQuery(sq);


    //        sysdate = DateTime.Now.ToString("MM/dd/yyyy");

    //        string sql121 = "insert into ReportData(msgFrom,msgTo,msgDate,sendername,Msg,FlagStatus)" +
    //            "values('" + ur.usrMobileNo + "','" + ur.usrMobileNo + "','" + sysdate + "','myctin','" + ResponceMsg + "','0')";
    //        int a1 = cc.ExecuteNonQuery(sql121);




    //        if ((smsCharge <= ((50 - dBal) + smsBal)) && (smsCharge <= (mBal + smsBal)))
    //        {
    //            string dndSql = "";
    //            int dndFales = 0;

    //            foreach (DataRow dr123 in ds111.Tables[0].Rows)
    //            {

    //                sender = "myct.in";
    //                string SenderMobile = ur.usrMobileNo;
    //                GrMemberId = Convert.ToString(dr123["FriendId"]);
    //                prefix = Convert.ToString(dr123["FriendPrefix"]);
    //                infix = Convert.ToString(dr123["FriendInfix"]);
    //                postfix = Convert.ToString(dr123["FriendPostfix"]);
    //                senderid = Convert.ToString(dr123["Senderid"]);

    //                GrMemMoNoSQL = "Select usrMobileNo from UserMaster where usrUserId='" + GrMemberId + "'";
    //                GrMemMoNo = cc.ExecuteScalar(GrMemMoNoSQL);
    //                dndSql = "Select DND from UserMaster where usrUserId='" + GrMemberId + "'"; ;
    //                string MydndFlg = cc.ExecuteScalar(dndSql);
    //                if (MydndFlg == "")
    //                {

    //                    dndFales = 0;
    //                }
    //                else
    //                {

    //                    dndFales = 0;
    //                }
    //                if (dndFales == 0)
    //                {
    //                    string dndName = "Select usrFirstName from UserMaster where usrUserId='" + GrMemberId + "'";
    //                    string MyFriendName = cc.ExecuteScalar(dndName);
    //                    if (MyFriendName != "")
    //                    {
    //                        if (infix != "")
    //                        {

    //                            sms = " " + prefix + " " + infix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
    //                        }
    //                        else
    //                        {
    //                            sms = " " + prefix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
    //                        }


    //                        cc.SendMessageTra(senderid, GrMemMoNo, sms);

    //                        sysdate = DateTime.Now.ToString("MM/dd/yyyy");


    //                        string sql12 = "insert into ReportData(msgFrom,msgTo,msgDate,sendername,Msg,FlagStatus)" +
    //                            "values('" + ur.usrMobileNo + "','" + GrMemMoNo + "','" + sysdate + "','" + senderid + "','" + sms + "','0')";
    //                        int a12 = cc.ExecuteNonQuery(sql12);
    //                    }
    //                    else
    //                    {
    //                        string dndNameAlternate = "Select usrFirstName from UserMaster where usrUserId='" + GrMemberId + "'";
    //                        string MyFriendNameAlternate = cc.ExecuteScalar(dndNameAlternate);


    //                        if (infix != "")
    //                        {

    //                            sms = " " + prefix + " " + infix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
    //                        }
    //                        else
    //                        {
    //                            sms = " " + prefix + " " + sms + "From " + ur.usrFirstName + " " + ur.usrLastName + "(" + SenderMobile.ToString() + ") thanks via www.myct.in";// +cc.AddSMS(GrMemMoNo);
    //                        }

    //                        cc.SendMessageTra(senderid, GrMemMoNo, sms);
    //                        sysdate = DateTime.Now.ToString("MM/dd/yyyy");


    //                        string sql122 = "insert into ReportData(msgFrom,msgTo,msgDate,sendername,Msg,FlagStatus)" +
    //                            "values('" + ur.usrMobileNo + "','" + GrMemMoNo + "','" + sysdate + "','" + senderid + "','" + sms + "','0')";
    //                        int a121 = cc.ExecuteNonQuery(sql122);

    //                    }
    //                }
    //                else
    //                {
    //                    smsCharge--;
    //                }

    //                sms = "";
    //                sms = ActualSMS.ToString();

    //            }

    //            if (smsCharge >= (50 - dBal))
    //            {
    //                smsBal = smsBal - (smsCharge - (50 - dBal));
    //                mBal = mBal - (50 - dBal);
    //                dBal += (50 - dBal);
    //                string sqlBalUpdate = "update userMaster set SMSbal=" + smsBal.ToString() + ",mCount=" + mBal.ToString() + ",dCount=" + dBal.ToString() + " where usrMobileNo='" + ur.usrMobileNo + "'";
    //                int i = cc.ExecuteNonQuery(sqlBalUpdate);

    //            }
    //            else
    //            {

    //                dBal = dBal + smsCharge;
    //                mBal = mBal - smsCharge;

    //                smsBal--;


    //            }

    //            string sqlBalUpdate1 = "update userMaster set SMSbal=" + smsBal.ToString() + ",mCount=" + mBal.ToString() + ",dCount=" + dBal.ToString() + " where usrMobileNo='" + ur.usrMobileNo + "'";
    //            int i1 = cc.ExecuteNonQuery(sqlBalUpdate1);

    //        }
    //        ///////////
    //        else
    //        {
    //            string smsResponse = "Dear " + ur.usrFirstName + ", You dont have sufficient bal. Your Daily Free Bal=" + (50 - dBal).ToString() + ",Monthly Free Bal=" + mBal.ToString() + ",Paid Bal=" + smsBal.ToString() + "." + cc.AddSMS(sender);
    //            cc.SendMessageTra(sender, sender, smsResponse);
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        ClsCommon.WriteLine(this.ToString(), "SendMessageToAllByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
    //    }
    //}
    public void grpsmsbylongcode()
    {
        UserRegistrationBLL ur = new UserRegistrationBLL();
        try
        {
            //string userid = Convert.ToString(Session["User"]);
            string sql = "select usrUserid from usermaster where usrMobileno='" + mobile + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            string userid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);



            if (GrNameId == 1)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and FR1=1";
            }
            else if (GrNameId == 2)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and FR2=2";
            }
            else if (GrNameId == 3)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR3=3";
            }
            else if (GrNameId == 4)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR4=4";
            }
            else if (GrNameId == 5)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR5=5";
            }
            else if (GrNameId == 6)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR6=6";
            }
            else if (GrNameId == 7)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR7=7";
            }
            else if (GrNameId == 8)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR8=8";
            }
            else if (GrNameId == 9)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR9=9";
            }
            else if (GrNameId == 10)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR10=10";
            }
            else if (GrNameId == 11)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR11=11";
            }
            else if (GrNameId == 12)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR12=12";
            }
            else if (GrNameId == 13)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR13=13";
            }
            else if (GrNameId == 14)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR14=14";
            }
            else if (GrNameId == 15)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR15=15";
            }
            else if (GrNameId == 16)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR16=16";
            }
            else if (GrNameId == 17)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR17=17";
            }
            else if (GrNameId == 18)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR18=18";
            }
            else if (GrNameId == 19)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR19=19";
            }
            else if (GrNameId == 20)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR20=20";
            }
            else if (GrNameId == 21)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR21=21";
            }
            else if (GrNameId == 22)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR22=22";
            }
            else if (GrNameId == 23)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR23=23";
            }
            else if (GrNameId == 24)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR24=24";
            }
            else if (GrNameId == 25)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR25=25";
            }
            else if (GrNameId == 26)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR26=26";
            }
            else if (GrNameId == 27)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR27=27";
            }
            else if (GrNameId == 28)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR28=28";
            }
            else if (GrNameId == 29)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR29=29";
            }
            else if (GrNameId == 30)
            {
                GrMembers = "Select * from friendrelationmaster where UserId='" + userid + "' and  FR30=30";
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void SendMessageToAllStuPAByLongCode(UserRegistrationBLL ur, string mobile, int grId, string smsAP)
    {
        try
        {
            int smsBal = 0, dBal = 0, mBal = 0, smsLength = 0, totalSms = 0, smsCharge = 0;
            string LCsms = ur.longCodegrSMS;
            string[] smsArr = LCsms.Split(' ');
            string ActualSMS = "";
            string smsCode = smsArr[0].ToString();
            for (int i = 1; i < smsArr.Length - 1; i++)
            {
                ActualSMS += smsArr[i].ToString() + " ";
            }
            string sql = "select SMSbal,mCount,dCount,usrUserId, usrFirstName,usrLastName,usrCityId ,GroupName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            //dt1 = ds.Tables[0];
            string userId;
            string usrFName = "", usrLName = "", UserGroupsNames = "";
            int cityId;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                userId = Convert.ToString(dr1["usrUserId"]);
                usrFName = Convert.ToString(dr1["usrFirstName"]);
                usrLName = Convert.ToString(dr1["usrLastName"]);
                cityId = Convert.ToInt32(dr1["usrCityId"]);
                UserGroupsNames = Convert.ToString(dr1["GroupName"]);
                smsBal = Convert.ToInt32(dr1["SMSbal"]);
                dBal = Convert.ToInt32(dr1["dCount"]);
                mBal = Convert.ToInt32(dr1["mCount"]);
                ur.usrUserId = Convert.ToString(userId);
                ur.usrFirstName = Convert.ToString(usrFName);
                ur.usrLastName = Convert.ToString(usrLName);
                ur.UsrGroupNames = Convert.ToString(UserGroupsNames);

            }
            string[] arrUrGrNames = UserGroupsNames.Split(',');
            int GrNameId = Convert.ToInt32(smsCode);
            GrNameId = GrNameId + 1;
            string GrNameIs = arrUrGrNames[GrNameId].ToString();
            string GrMembers = "";
            if (GrNameId >= 2)
            {
                GrMembers = "Select FriendId from FriendRelationMaster where UserId='" + ur.usrUserId + "' AND friendGroup='" + GrNameId.ToString() + "'";
            }
            else
            {
                GrMembers = "Select FriendId from FriendRelationMaster where UserId='" + ur.usrUserId + "'";
            }
            DataSet ds111 = new DataSet();
            ds111 = cc.ExecuteDataset(GrMembers);
            string GrMemberId = "";
            string GrMemMoNoSQL = "", GrMemMoNo = "";
            string sender = ur.usrMobileNo;
            string sms = ActualSMS.ToString();
            smsLength = sms.Length;
            totalSms = ds111.Tables[0].Rows.Count;
            if (smsLength <= 80)
            {
                smsCharge = 1 * totalSms;
            }
            else if (smsLength <= 240)
            {
                smsCharge = 2 * totalSms;
            }
            else
            {
                smsCharge = 3 * totalSms;
            }
            if ((smsCharge <= ((50 - dBal) + smsBal)) && (smsCharge <= (mBal + smsBal)))
            {
                string dndSql = "";
                int dndFales = 0;
                string SchoolId = "", ClassId = "";
                string[] RollNo = ActualSMS.Split(',');
                string nonSendSmsUser = "";
                foreach (DataRow dr123 in ds111.Tables[0].Rows)
                {
                    bool PAflag = false;
                    string StuPAname = "", StuPAschoolName = "";
                    GrMemberId = Convert.ToString(dr123["FriendId"]);
                    bool sendPAsmsFlag = false;
                    for (int mr = 0; mr < RollNo.Length && sendPAsmsFlag == false; mr++)
                    {
                        string lowLoop = "select usrUserId from tblFamilyInfoMaster where usrUserId='" + GrMemberId.ToString() + "' and (usrFIrollNo1='" + RollNo[mr].ToString() + "' or usrFIrollNo2='" + RollNo[mr].ToString() + "' or usrFIrollNo3='" + RollNo[mr].ToString() + "')";
                        string LowLoopId = cc.ExecuteScalar(lowLoop);
                        if (LowLoopId.ToString() != "")
                        {
                            DataSet mrpa1 = new DataSet();
                            DataSet mrpa2 = new DataSet();
                            DataSet mrpa3 = new DataSet();
                            string sqlPA1 = "select fi.usrFiname1,sm.SchoolName ,fi.usrFIschool1,fi.usrFIclass1 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool1=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo1='" + RollNo[mr].ToString() + "'";
                            string sqlPA2 = "select fi.usrFiname2,sm.SchoolName ,fi.usrFIschool2,fi.usrFIclass2 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool2=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo2='" + RollNo[mr].ToString() + "'";
                            string sqlPA3 = "select fi.usrFiname3,sm.SchoolName ,fi.usrFIschool3,fi.usrFIclass3 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool3=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo3='" + RollNo[mr].ToString() + "'";
                            mrpa1 = cc.ExecuteDataset(sqlPA1);
                            mrpa2 = cc.ExecuteDataset(sqlPA2);
                            mrpa3 = cc.ExecuteDataset(sqlPA3);
                            if (mrpa1.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow drr in mrpa1.Tables[0].Rows)
                                {
                                    StuPAname = drr["usrFiname1"].ToString();
                                    StuPAschoolName = drr["SchoolName"].ToString();
                                    if (SchoolId.ToString() == "" && ClassId.ToString() == "")
                                    {
                                        SchoolId = Convert.ToString(drr["usrFIschool1"].ToString());
                                        ClassId = Convert.ToString(drr["usrFIclass1"].ToString());
                                    }
                                    PAflag = true;
                                }

                            }
                            else if (mrpa2.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow drr in mrpa2.Tables[0].Rows)
                                {
                                    StuPAname = drr["usrFiname2"].ToString();
                                    StuPAschoolName = drr["SchoolName"].ToString();
                                    if (SchoolId.ToString() == "" && ClassId.ToString() == "")
                                    {
                                        SchoolId = Convert.ToString(drr["usrFIschool2"].ToString());
                                        ClassId = Convert.ToString(drr["usrFIclass2"].ToString());
                                    }
                                    PAflag = true;
                                }
                            }
                            else if (mrpa3.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow drr in mrpa3.Tables[0].Rows)
                                {
                                    StuPAname = drr["usrFiname3"].ToString();
                                    StuPAschoolName = drr["SchoolName"].ToString();
                                    {
                                        SchoolId = Convert.ToString(drr["usrFIschool3"].ToString());
                                        ClassId = Convert.ToString(drr["usrFIclass3"].ToString());
                                    }
                                    PAflag = true;
                                }
                            }

                            if (PAflag == true)
                            {
                                sendPAsmsFlag = true;
                                sender = ur.usrMobileNo;
                                GrMemberId = Convert.ToString(dr123["FriendId"]);
                                GrMemMoNoSQL = "Select usrMobileNo from UserMaster where usrUserId='" + GrMemberId + "'";
                                GrMemMoNo = cc.ExecuteScalar(GrMemMoNoSQL);
                                dndSql = "Select DND from UserMaster where usrUserId='" + GrMemberId + "'"; ;
                                string MydndFlg = cc.ExecuteScalar(dndSql);
                                if (MydndFlg == "")
                                {
                                    dndFales = 1;
                                }
                                else
                                {
                                    dndFales = Convert.ToInt32(MydndFlg);
                                }
                                if (dndFales == 0)
                                {
                                    sms = "";
                                    string nerSmsTra = "";
                                    string FatherSql = "select usrFirstName from userMaster where usrMobileNo='" + GrMemMoNo.ToString() + "'";
                                    string FatherName = cc.ExecuteScalar(FatherSql);
                                    sms = "Dear " + FatherName.ToString() + " your " + StuPAname.ToString() + " is " + smsAP.ToString() + " today in " + StuPAschoolName.ToString() + "";
                                    sms = sms + " By-" + ur.usrFirstName + "(" + sender.ToString() + ") " + cc.AddSMS(GrMemMoNo);
                                    DateTime today = System.DateTime.Now;
                                    string dateSplite = today.ToString();
                                    string[] dateArr = dateSplite.Split(' ');
                                    nerSmsTra = "Dear " + FatherName.ToString() + ",Your child " + StuPAname.ToString() + " is " + smsAP.ToString() + " on " + dateConvertDDMMYYYY(dateArr[0].ToString()) + "";
                                    nerSmsTra += "-" + ur.usrFirstName + "(" + sender.ToString() + "). Please ensure his regular attendance for his optimum performance. Via: www.myct.in";
                                    string NewTraRespMsg = "Dear " + FatherName.ToString() + " ur child " + StuPAname.ToString() + " is " + smsAP.ToString() + " in the " + StuPAschoolName.ToString() + " on Dt. " + dateConvertDDMMYYYY(dateArr[0].ToString()) + " thanks. Via www.myct.in";
                                    //cc.SendMessage1(sender, GrMemMoNo, nerSmsTra);
                                    cc.SendMessageTra("MYCT.IN", GrMemMoNo, NewTraRespMsg);
                                }
                                else
                                {
                                    smsCharge--;
                                }
                            }
                            else
                            {
                                sendPAsmsFlag = false;
                            }
                        }
                    }


                    if (sendPAsmsFlag == false)
                    {
                        nonSendSmsUser += Convert.ToString(dr123["FriendId"]) + ",";
                    }

                    if (SchoolId.ToString() == "" && ClassId.ToString() == "")
                    {
                        DataSet mrpa1 = new DataSet();
                        DataSet mrpa2 = new DataSet();
                        DataSet mrpa3 = new DataSet();
                        string sqlPA1 = "select sm.SchoolName ,fi.usrFIschool1,fi.usrFIclass1 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool1=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' ";
                        string sqlPA2 = "select sm.SchoolName ,fi.usrFIschool2,fi.usrFIclass2 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool2=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' ";
                        string sqlPA3 = "select sm.SchoolName ,fi.usrFIschool3,fi.usrFIclass3 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool3=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' ";
                        mrpa1 = cc.ExecuteDataset(sqlPA1);
                        mrpa2 = cc.ExecuteDataset(sqlPA2);
                        mrpa3 = cc.ExecuteDataset(sqlPA3);
                        if (mrpa1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drr in mrpa1.Tables[0].Rows)
                            {
                                //StuPAname = drr["usrFiname1"].ToString();
                                StuPAschoolName = drr["SchoolName"].ToString();
                                if (SchoolId.ToString() == "" && ClassId.ToString() == "")
                                {
                                    SchoolId = Convert.ToString(drr["usrFIschool1"].ToString());
                                    ClassId = Convert.ToString(drr["usrFIclass1"].ToString());
                                }
                                //PAflag = true;
                            }

                        }
                        else if (mrpa2.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drr in mrpa2.Tables[0].Rows)
                            {
                                //StuPAname = drr["usrFiname2"].ToString();
                                StuPAschoolName = drr["SchoolName"].ToString();
                                if (SchoolId.ToString() == "" && ClassId.ToString() == "")
                                {
                                    SchoolId = Convert.ToString(drr["usrFIschool2"].ToString());
                                    ClassId = Convert.ToString(drr["usrFIclass2"].ToString());
                                }
                                //PAflag = true;
                            }
                        }
                        else if (mrpa3.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drr in mrpa3.Tables[0].Rows)
                            {
                                //StuPAname = drr["usrFiname3"].ToString();
                                StuPAschoolName = drr["SchoolName"].ToString();
                                {
                                    SchoolId = Convert.ToString(drr["usrFIschool3"].ToString());
                                    ClassId = Convert.ToString(drr["usrFIclass3"].ToString());
                                }
                                //PAflag = true;
                            }
                        }
                    }
                }
                // Non Entry Roll Number Students.

                if (SchoolId.ToString() != "" && ClassId.ToString() != "")
                {
                    string TotalRollNumbers = "";
                    string remRollSql1 = "select usrFIrollNo1 from tblFamilyInfoMaster where usrFIschool1='" + SchoolId.ToString() + "' AND usrFIClass1='" + ClassId.ToString() + "'";
                    string remRollSql2 = "select usrFIrollNo2 from tblFamilyInfoMaster where usrFIschool2='" + SchoolId.ToString() + "' AND usrFIClass2='" + ClassId.ToString() + "'";
                    string remRollSql3 = "select usrFIrollNo3 from tblFamilyInfoMaster where usrFIschool3='" + SchoolId.ToString() + "' AND usrFIClass3='" + ClassId.ToString() + "'";
                    DataSet dsr1 = new DataSet();
                    DataSet dsr2 = new DataSet();
                    DataSet dsr3 = new DataSet();
                    dsr1 = cc.ExecuteDataset(remRollSql1);
                    dsr2 = cc.ExecuteDataset(remRollSql2);
                    dsr3 = cc.ExecuteDataset(remRollSql3);
                    foreach (DataRow dr in dsr1.Tables[0].Rows)
                    {
                        TotalRollNumbers += Convert.ToString(dr["usrFIrollNo1"]) + ",";
                    }
                    foreach (DataRow dr in dsr2.Tables[0].Rows)
                    {
                        TotalRollNumbers += Convert.ToString(dr["usrFIrollNo2"]) + ",";
                    }
                    foreach (DataRow dr in dsr3.Tables[0].Rows)
                    {
                        TotalRollNumbers += Convert.ToString(dr["usrFIrollNo3"]) + ",";
                    }
                    string[] totRNo = TotalRollNumbers.Split(',');
                    string[] sendSmsRno = ActualSMS.Split(',');
                    string[] nonSendUser = nonSendSmsUser.Split(',');
                    for (int m = 0; m < totRNo.Length; m++)
                    {
                        bool nsflagNew = false;
                        for (int r = 0; r < sendSmsRno.Length; r++)
                        {
                            if (totRNo[m].ToString() == sendSmsRno[r].ToString())
                            {
                                nsflagNew = true;
                                break;
                            }
                            else
                            {
                            }
                        }

                        if (nsflagNew == false)
                        {
                            for (int stu = 0; stu < nonSendUser.Length; stu++)
                            {
                                bool PAflag = false;
                                string StuPAname = "", StuPAschoolName = "";
                                GrMemberId = Convert.ToString(nonSendUser[stu]);
                                bool sendPAsmsFlag = false;
                                //for (int mr = 0; mr < RollNo.Length && sendPAsmsFlag == false ; mr++)
                                //{
                                string lowLoop = "select usrUserId from tblFamilyInfoMaster where usrUserId='" + GrMemberId.ToString() + "' and (usrFIrollNo1='" + totRNo[m].ToString() + "' or usrFIrollNo2='" + totRNo[m].ToString() + "' or usrFIrollNo3='" + totRNo[m].ToString() + "')";
                                string LowLoopId = cc.ExecuteScalar(lowLoop);
                                if (LowLoopId.ToString() != "")
                                {
                                    DataSet mrpa1 = new DataSet();
                                    DataSet mrpa2 = new DataSet();
                                    DataSet mrpa3 = new DataSet();
                                    string sqlPA1 = "select fi.usrFiname1,sm.SchoolName from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool1=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo1='" + totRNo[m].ToString() + "'";
                                    string sqlPA2 = "select fi.usrFiname2,sm.SchoolName from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool2=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo2='" + totRNo[m].ToString() + "'";
                                    string sqlPA3 = "select fi.usrFiname3,sm.SchoolName from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool3=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo3='" + totRNo[m].ToString() + "'";
                                    mrpa1 = cc.ExecuteDataset(sqlPA1);
                                    mrpa2 = cc.ExecuteDataset(sqlPA2);
                                    mrpa3 = cc.ExecuteDataset(sqlPA3);
                                    if (mrpa1.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa1.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname1"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();
                                            //SchoolId = Convert.ToString(drr["usrFIschool1"].ToString());
                                            //ClassId = Convert.ToString(drr["usrFIclass1"].ToString());
                                            PAflag = true;
                                        }

                                    }
                                    else if (mrpa2.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa2.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname2"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();
                                            //SchoolId = Convert.ToString(drr["usrFIschool2"].ToString());
                                            //ClassId = Convert.ToString(drr["usrFIclass2"].ToString());
                                            PAflag = true;
                                        }
                                    }
                                    else if (mrpa3.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa3.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname3"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();
                                            //SchoolId = Convert.ToString(drr["usrFIschool3"].ToString());
                                            //ClassId = Convert.ToString(drr["usrFIclass3"].ToString());
                                            PAflag = true;
                                        }
                                    }
                                    if (PAflag == true)
                                    {
                                        sendPAsmsFlag = true;
                                        sender = ur.usrMobileNo;
                                        GrMemberId = Convert.ToString(nonSendUser[stu]);
                                        GrMemMoNoSQL = "Select usrMobileNo from UserMaster where usrUserId='" + GrMemberId + "'";
                                        GrMemMoNo = cc.ExecuteScalar(GrMemMoNoSQL);
                                        dndSql = "Select DND from UserMaster where usrUserId='" + GrMemberId + "'"; ;
                                        string MydndFlg = cc.ExecuteScalar(dndSql);
                                        if (MydndFlg == "")
                                        {
                                            dndFales = 1;
                                        }
                                        else
                                        {
                                            dndFales = Convert.ToInt32(MydndFlg);
                                        }
                                        string nerSmsTra = "";

                                        if (dndFales == 0)
                                        {
                                            if (smsAP.ToString() == "PRESENT")
                                            {
                                                smsAP = "APSENT";
                                                sms = "";
                                                string FatherSql = "select usrFirstName from userMaster where usrMobileNo='" + GrMemMoNo.ToString() + "'";
                                                string FatherName = cc.ExecuteScalar(FatherSql);
                                                sms = "Dear " + FatherName.ToString() + " your " + StuPAname.ToString() + " is " + smsAP.ToString() + " today in " + StuPAschoolName.ToString() + "";
                                                DateTime today = System.DateTime.Now;
                                                string dateSplite = today.ToString();
                                                string[] dateArr = dateSplite.Split(' ');
                                                nerSmsTra = "Dear " + FatherName.ToString() + ",Your child " + StuPAname.ToString() + " is " + smsAP.ToString() + " on " + dateConvertDDMMYYYY(dateArr[0].ToString()) + "";
                                            }
                                            else if (smsAP.ToString() == "APSENT")
                                            {
                                                smsAP = "PRESENT";
                                                sms = "";
                                                string FatherSql = "select usrFirstName from userMaster where usrMobileNo='" + GrMemMoNo.ToString() + "'";
                                                string FatherName = cc.ExecuteScalar(FatherSql);
                                                sms = "Dear " + FatherName.ToString() + " your " + StuPAname.ToString() + " is " + smsAP.ToString() + " today in " + StuPAschoolName.ToString() + "";
                                                DateTime today = System.DateTime.Now;
                                                string dateSplite = today.ToString();
                                                string[] dateArr = dateSplite.Split(' ');
                                                nerSmsTra = "Dear " + FatherName.ToString() + ",Your child " + StuPAname.ToString() + " is " + smsAP.ToString() + " on " + dateConvertDDMMYYYY(dateArr[0].ToString()) + "";
                                                string NewTraRespMsg = "";
                                                if (smsAP.ToString() == "APSENT")
                                                    NewTraRespMsg = "Dear " + FatherName.ToString() + " ur child " + StuPAname.ToString() + " is " + smsAP.ToString() + " in the " + StuPAschoolName.ToString() + " on Dt. " + dateConvertDDMMYYYY(dateArr[0].ToString()) + " thanks. Via www.myct.in";
                                                else
                                                    NewTraRespMsg = "Dear " + FatherName.ToString() + " ur child " + StuPAname.ToString() + " is " + smsAP.ToString() + " in the school. Pl take care about regularity of student, thanks. Via www.myct.in";
                                                cc.SendMessageTra("MYCT.IN", GrMemMoNo, NewTraRespMsg);
                                            }
                                            nerSmsTra += "-" + ur.usrFirstName + "(" + sender.ToString() + "). Please ensure his regular attendance for his optimum performance. Via: www.myct.in";
                                            sms = sms + " By-" + ur.usrFirstName + "(" + sender.ToString() + ") " + cc.AddSMS(GrMemMoNo);
                                            //cc.SendMessage1(sender, GrMemMoNo, nerSmsTra);

                                        }
                                        else
                                        {
                                            smsCharge--;
                                        }

                                    }
                                    //}
                                }
                                //}




                            }

                        }

                    }

                }




                if (smsCharge >= (50 - dBal))
                {
                    smsBal = smsBal - (smsCharge - (50 - dBal));
                    mBal = mBal - (50 - dBal);
                    dBal += (50 - dBal);
                }
                else
                {

                    dBal = dBal + smsCharge;
                    mBal = mBal - smsCharge;


                }
                string sqlBalUpdate = "update userMaster set SMSbal=" + smsBal.ToString() + ",mCount=" + mBal.ToString() + ",dCount=" + dBal.ToString() + " where usrMobileNo='" + ur.usrMobileNo + "'";
                int i = cc.ExecuteNonQuery(sqlBalUpdate);

            }
            else
            {
                string smsResponse = "Dear " + ur.usrFirstName + ", You dont have sufficient bal. Your Daily Free Bal=" + (50 - dBal).ToString() + ",Monthly Free Bal=" + mBal.ToString() + ",Paid Bal=" + smsBal.ToString() + "." + cc.AddSMS(sender);
                cc.SendMessage1(sender, sender, smsResponse);
            }
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }



        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "SendMessageToAllStuPAByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public string dateConvertDDMMYYYY(string dateMMDDYYYY)
    {

        string[] DateArr = dateMMDDYYYY.Split('/');
        return (DateArr[1].ToString() + "/" + DateArr[0].ToString() + "/" + DateArr[2].ToString());

    }

    public void UpdatePinByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);
            }
            string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
            storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
            int UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
            string usrNm = "";
            if (ur.usrFirstName == "" && ur.usrLastName == "")
            {
                string str = "select usrFirstName+' '+usrLastName as name from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                usrNm = cc.ExecuteScalar(str);
            }

            if (UsrMastFlag > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "";
                if (ur.usrFirstName == "")
                {
                    smsString = "Dear " + usrNm.ToString() + " your City,District,State and PIN code is updated succefully." + cc.AddSMS(mobileNo);
                }
                else
                {
                    smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your City,District,State and PIN code is updated succefully." + cc.AddSMS(mobileNo);
                }
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }

        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdatePinByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }



    }

    public void AddFriendByLongCode(UserRegistrationBLL ur, string userMobileWhoSendFriendReq)
    {//Mahesh: Use second parameter mobile for only send sms only, because at run time mobile number of sender change.
        try
        {
            string sender = "";
            string joiner = "";
            bool JoinAll = false;
            string flagMob = ur.usrAltMobileNo;
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);

            if (status == 0)
            {
                status = urRegistBll.BLLIsExistUserRegistrationInitialByLc(ur);
                if (status == 0)
                {
                    string sqlFlagStr = "select JoinFlag from userMaster where usrMobileNo='" + flagMob.ToString() + "'";
                    int jof = Convert.ToInt32(cc.ExecuteScalar(sqlFlagStr));
                    if (jof >= 1)
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = "1";
                    }

                    //DataTable dt1 = new DataTable();
                    string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql);
                    //dt1 = ds.Tables[0];
                    string userId;
                    string usrName = "";
                    int cityId;
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        ur.frnrelUserId = userId;
                        ur.usrCityId = cityId;
                        joiner = Convert.ToString(usrName);
                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }
                    string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + ur.usrAltMobileNo + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = cc.ExecuteDataset(sql1);
                    //dt1 = ds.Tables[0];
                    string FriId;
                    string FriName;
                    foreach (DataRow dr2 in ds1.Tables[0].Rows)
                    {
                        FriId = Convert.ToString(dr2["usrUserId"]);
                        FriName = Convert.ToString(dr2["usrFirstName"]);
                        ur.frnrelFriendId = FriId;
                        ur.frnrelFrnRelName = FriName;
                        ur.frnrelRelation = "friend";
                        string JoinFlagSQL = "select JoinFlag from userMaster where usrMobileNo='" + ur.usrAltMobileNo.ToString() + "'";
                        string jf = cc.ExecuteScalar(JoinFlagSQL);
                        //ur.frnrelGroup = jf.ToString();
                        //ur.frnrelGroup = "1";
                        sender = Convert.ToString(FriName);
                    }

                    status = ur.BLLInsertUserFriendRelative(ur);
                    if (status > 0)
                    {
                        string SendTo = ur.usrAltMobileNo;
                        string sendFrom = ur.usrMobileNo;
                        string message = "I " + usrName + " (" + sendFrom.ToString() + ") added u in come2myCity.com to send SMS." + cc.AddSMS(SendTo);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "(" + SendTo.ToString() + ") also added u on www.myct.in " + cc.AddSMS(sendFrom);
                            cc.SendMessage1(SendTo, sendFrom, resJoinAll);
                        }
                        cc.SendMessage1(sendFrom, SendTo, message);
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }
                    }
                }
                else
                {
                    string sql3 = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql3);
                    //dt1 = ds.Tables[0];
                    string userId;
                    string usrName = "";
                    int cityId = 0;
                    string cityName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        ur.frnrelUserId = userId;
                        ur.usrCityId = cityId;
                        joiner = Convert.ToString(usrName);

                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }

                    string sqlFlagStr = "select JoinFlag from userMaster where usrMobileNo='" + flagMob.ToString() + "'";
                    string jof = Convert.ToString(cc.ExecuteScalar(sqlFlagStr));
                    if (jof == "True")
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = "1";
                    }
                    string sqlquery = "select cityName from CityMaster where cityId='" + Convert.ToString(cityId) + "'";
                    cityName = cc.ExecuteScalar(sqlquery);

                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

                    ur.usrMobileNo = ur.usrAltMobileNo;

                    ur.usrFirstName = ur.frnrelFrnRelName;

                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {

                        string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + ur.usrAltMobileNo + "'";
                        DataSet ds1 = new DataSet();
                        ds1 = cc.ExecuteDataset(sql1);
                        //dt1 = ds.Tables[0];
                        string FriId;
                        string FriName;
                        foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        {
                            FriId = Convert.ToString(dr2["usrUserId"]);
                            FriName = Convert.ToString(dr2["usrFirstName"]);
                            ur.frnrelFriendId = FriId;
                            ur.frnrelFrnRelName = FriName;
                            ur.frnrelRelation = "friend";
                            string JoinFlagSQL = "select JoinFlag from userMaster where usrMobileNo='" + ur.usrAltMobileNo.ToString() + "'";
                            string jf = cc.ExecuteScalar(JoinFlagSQL);
                            ur.frnrelGroup = jf.ToString();
                            //ur.frnrelGroup = "1";
                            sender = Convert.ToString(FriName);
                        }

                        status = ur.BLLInsertUserFriendRelative(ur);
                        if (status > 0)
                        {

                        }
                        string senderId = userMobileWhoSendFriendReq.ToString();
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = ur.frnrelFrnRelName;


                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u in come2mycity.com. U use it to send SMS.Dear " + myName + ",Password for ur First Login is " + myPassword + " for come2myCity.com";
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + myMobileNo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(senderId);
                            cc.SendMessage1(myMobileNo, senderId, resJoinAll);
                        }
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }


                    }

                }
            }
            else
            {
                //NotRegisterMessageForLongCode(urRegistBll);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "AddFriendByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public bool checkGr(string keyword)
    {
        bool s = false;
        char[] arr = keyword.ToCharArray();
        if (arr[0] == 'f' || arr[0] == 'F' || arr[0] == 'R' || arr[0] == 'r')
        {
            if (arr[1] == 'R' || arr[1] == 'r' || arr[0] == 'F' || arr[0] == 'f')
            {
                if (checkDigit(arr[2]) >= 48 && checkDigit(arr[2]) <= 57)
                {
                    int len = arr.Length;
                    if (len > 3)
                    {
                        if (checkDigit(arr[3]) >= 48 && checkDigit(arr[2]) <= 57)
                        {
                            s = true;
                        }
                        else
                        {
                            s = true;
                        }
                    }
                    else
                    {
                        s = true;
                    }

                }
            }
        }
        return s;
    }

    public bool checPGr(string keyword)
    {
        bool s = false;
        char[] arr = keyword.ToCharArray();
        if (arr[0] == 'p' || arr[0] == 'P' || arr[0] == 'a' || arr[0] == 'A')
        {
            if (arr[1] == 'R' || arr[1] == 'r' || arr[1] == 'p' || arr[1] == 'P' || arr[1] == 'b' || arr[1] == 'B')
            {
                if (checkDigit(arr[2]) >= 48 && checkDigit(arr[2]) <= 57)
                {
                    int len = arr.Length;
                    if (len > 3)
                    {
                        if (checkDigit(arr[3]) >= 48 && checkDigit(arr[2]) <= 57)
                        {
                            s = true;
                        }
                        else
                        {
                            s = true;
                        }
                    }
                    else
                    {
                        s = true;
                    }

                }
            }
        }
        return s;
    }

    public void AddFriendByLongCodeF(UserRegistrationBLL ur, string userMobileWhoSendFriendReq, int grid)
    {//Mahesh: Use second parameter mobile for only send sms only, because at run time mobile number of sender change.
        try
        {
            string sender = "";
            string joiner = "";
            bool JoinAll = false;
            string flagMob = ur.usrAltMobileNo;
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                status = urRegistBll.BLLIsExistUserRegistrationInitialByLc(ur);
                if (status == 0)
                {
                    string sqlFlagStr = "select JoinFlag from userMaster where usrMobileNo='" + flagMob.ToString() + "'";
                    string kk = cc.ExecuteScalar(sqlFlagStr);
                    int jof = Convert.ToInt32(kk);
                    if (jof >= 1)
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = Convert.ToString(jof);
                    }
                    //DataTable dt1 = new DataTable();
                    string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql);
                    //dt1 = ds.Tables[0];
                    string userId;
                    string usrName = "";
                    int cityId;
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        ur.frnrelFriendId = userId;
                        ur.usrCityId = cityId;
                        joiner = Convert.ToString(usrName);
                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }
                    string sql1 = "select usrUserId, usrFirstName,usrPassword from UserMaster where usrMobileNo='" + ur.usrAltMobileNo + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = cc.ExecuteDataset(sql1);
                    //dt1 = ds.Tables[0];
                    string FriId;
                    string FriName = "";
                    string PassWordMsg = "";
                    foreach (DataRow dr2 in ds1.Tables[0].Rows)
                    {
                        FriId = Convert.ToString(dr2["usrUserId"]);
                        FriName = Convert.ToString(dr2["usrFirstName"]);
                        PassWordMsg = cc.DESDecrypt(Convert.ToString(dr2["usrPassword"]));
                        ur.frnrelUserId = FriId;
                        ur.frnrelFrnRelName = FriName;
                        ur.frnrelRelation = "friend";
                        sender = Convert.ToString(FriName);
                        //ur.frnrelGroup = "1";
                        //status = ur.BLLInsertUserFriendRelative(ur);
                        ur.frnrelGroup = Convert.ToString(grid);

                    }

                    status = ur.BLLInsertUserFriendRelative(ur);
                    if (status > 0)
                    {
                        string SendTo = ur.usrAltMobileNo;
                        string sendFrom = ur.usrMobileNo;
                        //string message = "I " + usrName + "(" + sendFrom.ToString() + ") added u in come2myCity.com to send SMS." + cc.AddSMS(SendTo);
                        string newRespMsg = "Dear " + FriName.ToString() + " I " + usrName.ToString() + "(" + sendFrom.ToString() + ") added  u on www.myct.in as a friend to send imp messages. Ur login password is " + PassWordMsg.ToString() + " thanks.Via www.myct.in";
                        cc.SendMessageTra(sendFrom, SendTo, newRespMsg);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + SendTo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(sendFrom);
                            cc.SendMessage1(SendTo, sendFrom, resJoinAll);
                        }
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }
                    }
                    else
                    {
                        string SendTo = ur.usrAltMobileNo;
                        string sendFrom = ur.usrMobileNo;
                        string message = "Dear " + joiner.ToString() + " u already added " + sender.ToString() + " in come2myCity.com to send SMS." + cc.AddSMS(sendFrom);

                        cc.SendMessage1(SendTo, sendFrom, message);

                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }

                    }
                }
                else
                {
                    string sql3 = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql3);
                    //dt1 = ds.Tables[0];
                    string userId;
                    flagMob = ur.usrAltMobileNo;
                    string usrName = "";
                    int cityId = 0;
                    string cityName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        ur.frnrelUserId = userId;
                        ur.usrCityId = cityId;
                        joiner = Convert.ToString(usrName);
                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }
                    string sqlFlagStr = "select JoinFlag from userMaster where usrMobileNo='" + flagMob.ToString() + "'";
                    string kk = cc.ExecuteScalar(sqlFlagStr);
                    int jof = 0;
                    if (kk != "")
                        jof = Convert.ToInt32(kk);
                    if (jof >= 1)
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = Convert.ToString(jof);
                    }
                    string sqlquery = "select cityName from CityMaster where cityId='" + Convert.ToString(cityId) + "'";
                    cityName = cc.ExecuteScalar(sqlquery);

                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

                    ur.usrMobileNo = ur.usrAltMobileNo;

                    ur.usrFirstName = ur.frnrelFrnRelName;

                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {

                        string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + ur.usrAltMobileNo + "'";
                        DataSet ds1 = new DataSet();
                        ds1 = cc.ExecuteDataset(sql1);
                        //dt1 = ds.Tables[0];
                        string FriId;
                        string FriName;
                        foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        {
                            FriId = Convert.ToString(dr2["usrUserId"]);
                            FriName = Convert.ToString(dr2["usrFirstName"]);
                            ur.frnrelFriendId = FriId;
                            ur.frnrelFrnRelName = FriName;
                            ur.frnrelRelation = "friend";
                            //ur.frnrelGroup = Convert.ToString(grid);
                            sender = Convert.ToString(FriName);
                        }

                        status = ur.BLLInsertUserFriendRelative(ur);
                        if (status > 0)
                        {

                        }
                        string senderId = userMobileWhoSendFriendReq.ToString();
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = ur.frnrelFrnRelName;
                        string thisDir = Server.MapPath("~");

                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                        //string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u in come2mycity.com. U use it to send SMS.Dear " + myName + ",Password for ur First Login is " + myPassword + " for come2myCity.com";
                        string newRespMsg = "Dear " + myName.ToString() + " I " + usrName.ToString() + "(" + senderId.ToString() + ") added  u on www.myct.in as a friend to send imp messages. Ur login password is " + myPassword.ToString() + " thanks.Via www.myct.in";
                        cc.SendMessageTra(senderId, myMobileNo, newRespMsg);
                        //cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        //cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + myMobileNo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(senderId);
                            cc.SendMessage1(myMobileNo, senderId, resJoinAll);
                        }
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }


                    }

                }
            }
            else
            {
                //NotRegisterMessageForLongCode(urRegistBll);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "AddFriendByLongCodeF()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public void UpdateDOBByLongCode(UserRegistrationBLL ur)
    {
        try
        {

            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                string updateDOB = "Update UserMaster set usrDOB='" + ur.usrDOB + "' where usrMobileNo='" + ur.usrMobileNo + "'";
                int statusDOB = cc.ExecuteNonQuery(updateDOB);
                if (statusDOB > 0)
                {
                    string sql = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql);
                    string usrFName = "", usrLName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        usrFName = Convert.ToString(dr1["usrFirstName"]);
                        usrLName = Convert.ToString(dr1["usrLastName"]);
                    }
                    string mobileNo = ur.usrMobileNo;
                    string smsDOB = "Dear " + usrFName + " " + usrLName + " your Date of Birth is updated successfully. " + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsDOB);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "UpdateDOBByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }


    }

    public void DeleteUserKeyWord(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                string sql1 = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql1);
                string usrFName = "", usrLName = "";
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    usrFName = Convert.ToString(dr1["usrFirstName"]);
                    usrLName = Convert.ToString(dr1["usrLastName"]);
                }

                string sql = "delete UserMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                int i = cc.ExecuteNonQuery(sql);
                if (i > 0)
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsDOB = "Dear " + usrFName + " " + usrLName + " you deleted successfully from come2myCity.com . " + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsDOB);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "DeleteUserKeyWord()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void JoinAllKeyword(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                string sql = "update UserMaster set JoinFlag = 1 where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                int i = cc.ExecuteNonQuery(sql);
                if (i > 0)
                {
                    string sql1 = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql1);
                    string usrFName = "", usrLName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        usrFName = Convert.ToString(dr1["usrFirstName"]);
                        usrLName = Convert.ToString(dr1["usrLastName"]);
                    }
                    string mobileNo = ur.usrMobileNo;
                    string smsDOB = "Dear " + usrFName + " " + usrLName + ", now persons who add u as a frnd will also b in ur frnd book" + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsDOB);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "JoinAllKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void JoinGrKeyword(UserRegistrationBLL ur, int grNo)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                string sql = "update UserMaster set JoinFlag = " + (grNo + 1) + " where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                int i = cc.ExecuteNonQuery(sql);
                if (i > 0)
                {
                    string sql1 = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql1);
                    string usrFName = "", usrLName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        usrFName = Convert.ToString(dr1["usrFirstName"]);
                        usrLName = Convert.ToString(dr1["usrLastName"]);
                    }
                    string GrNames = "select GroupName from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                    string GrNames1 = cc.ExecuteScalar(GrNames);
                    string[] GrArr = GrNames1.Split(',');
                    string GrNm = Convert.ToString(GrArr[grNo + 1]);
                    string mobileNo = ur.usrMobileNo;
                    string smsDOB = "Dear " + usrFName + " " + usrLName + ", now ur friends add in group " + GrNm.ToString() + " " + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsDOB);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "JoinGrKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void removeKewWord(string urMo, string frMo, UserRegistrationBLL ur)
    {
        try
        {
            ur.usrMobileNo = urMo;
            ur.usrAltMobileNo = frMo;
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                status = urRegistBll.BLLIsExistUserRegistrationInitialByLc(ur);
                if (status == 0)
                {
                    string sql1 = "", sql2 = "", delSql1 = "", delSql2 = "";
                    string usrId = "", frId = "";
                    sql1 = "select usrUserId from userMaster where usrMobileNo='" + urMo.ToString() + "'";
                    sql2 = "select usrUserId from userMaster where usrMobileNo='" + frMo.ToString() + "'";
                    usrId = cc.ExecuteScalar(sql1);
                    frId = cc.ExecuteScalar(sql2);
                    delSql1 = "delete FriendRelationMaster where UserId='" + usrId.ToString() + "' and FriendId='" + frId.ToString() + "'";
                    delSql2 = "delete FriendRelationMaster where UserId='" + frId.ToString() + "' and FriendId='" + usrId.ToString() + "'";
                    int s = cc.ExecuteNonQuery(delSql1);
                    int t = cc.ExecuteNonQuery(delSql2);
                }
                string usr = "", fr = "", usrQury = "", frQuery = "";
                usrQury = "select usrFirstName from userMaster where usrMobileNo='" + urMo.ToString() + "'";
                frQuery = "select usrFirstName from userMaster where usrMobileNo='" + frMo.ToString() + "'";
                usr = cc.ExecuteScalar(usrQury);
                fr = cc.ExecuteScalar(frQuery);
                string sms = "Dear " + usr.ToString() + ", You removed " + fr.ToString() + " friend successfully. " + cc.AddSMS(urMo);
                string senderId = "MYCT.IN";
                string NewRespMsg = "Dear " + usr.ToString() + " " + fr.ToString() + " is removed from ur list thanks.via www.myct.in";
                cc.SendMessageTra(senderId, urMo, NewRespMsg);
            }
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "removeKewWord()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public int checkDigit(char s)
    {
        int d = 10;
        try
        {
            d = Convert.ToInt32(s);
        }
        catch (Exception ff)
        {
            return d;
        }
        return d;
    }

    public void UpdateEmailByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                string sql = "update userMaster set usrEmailId='" + ur.usrEmailId.ToString() + "' where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                int i = cc.ExecuteNonQuery(sql);
                string sqlName = "select usrFirstName+' '+usrLastName as MyName from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                string MyName = cc.ExecuteScalar(sqlName);

                string senderId = "COM2MYCT";
                string urMo = ur.usrMobileNo;
                string passSql = "select usrPassword from userMaster where usrMobileNo='" + urMo.ToString() + "'";
                string pass1 = cc.ExecuteScalar(passSql);
                string FinPass = cc.DESDecrypt(pass1);
                // Dear Murlidhar Bhutada ur password 12345 sent to ur updated E-Mail
                string sms = "Dear " + MyName.ToString() + " ur password: " + FinPass.ToString() + " sent to ur updated E-Mail " + cc.AddSMS(urMo);
                cc.SendMessage1(senderId, urMo, sms);

            }
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateEmailByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }

    public bool checkGroupKeyword(string kwd)
    {
        bool flag = false;
        try
        {
            if (kwd == "RAVIDASIA" || kwd == "RAVIDASSIA" || kwd == "RAVIDASIYA")
                kwd = "RAVIDASSIA";
            int i = 0;
            string sql = "select Active from KeywordDefinition where KeywordName='" + kwd.ToString() + "'";
            string strFlag = cc.ExecuteScalar(sql);
            if (strFlag != "")
            {
                i = Convert.ToInt32(strFlag);
                if (i >= 0)
                {
                    flag = true;
                    return flag;
                }
                else
                {
                    flag = false;
                    return flag;
                }

            }
            else
            {
                flag = false;
                return flag;
            }


        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "FillBalKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
            flag = false;
            return flag;

        }

    }

    //public void FillBalKeyword(string from, string to, int amtOfsms, UserRegistrationBLL ur)
    //{
    //    try
    //    {
    //        ur.usrMobileNo = from;
    //        string SmsTransactionUpdate = "insert into BalTransaction(FromUsr,ToUsr,SmsAmt) values ('" + from + "','" + to + "'," + amtOfsms + ")";
    //        status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
    //        if (status == 0)
    //        {
    //            ur.usrMobileNo = to;
    //            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
    //            if (status == 0)
    //            {
    //                string checkFromBal = "select SMSbal from UserMaster where usrMobileNo ='" + from.ToString() + "'";
    //                int fromBal = Convert.ToInt32(cc.ExecuteScalar(checkFromBal));
    //                if (fromBal >= amtOfsms)
    //                {
    //                    string tobal = "select SMSbal from UserMaster where usrMobileNo ='" + to.ToString() + "'";
    //                    int toBalAdd = Convert.ToInt32(cc.ExecuteScalar(tobal));
    //                    string remBal = "update UserMaster set SMSbal =" + (fromBal - amtOfsms) + " where usrMobileNo ='" + from.ToString() + "'";
    //                    int i = cc.ExecuteNonQuery(remBal);
    //                    if (i > 0)
    //                    {
    //                        string addBal = "update UserMaster set SMSbal =" + (toBalAdd + amtOfsms) + " where usrMobileNo ='" + to.ToString() + "'";
    //                        int j = cc.ExecuteNonQuery(addBal);
    //                        if (j > 0)
    //                        {
    //                            string fromResp = "Dear user your transaction is successfully updated. Your Current Balance:" + (fromBal - amtOfsms) + " SMS." + cc.AddSMS(from);
    //                            string toResp = "Dear user your recharge is successfully complited. Your current Balance:" + (toBalAdd + amtOfsms) + " SMS." + cc.AddSMS(to);
    //                            string sendfrom = "myct.in";
    //                            cc.SendMessage1(sendfrom, from, fromResp);
    //                            cc.SendMessage1(sendfrom, to, toResp);
    //                            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
    //                            int pkchange = 0;
    //                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
    //                            if (pkchange == 0)
    //                            {
    //                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
    //                            }
    //                            int balUp = cc.ExecuteNonQuery(SmsTransactionUpdate);

    //                        }
    //                    }
    //                }

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ClsCommon.WriteLine(this.ToString(), "FillBalKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
    //    }

    //}

    public void FillBalKeyword1(string from, string to, int tranamt, int promoamt, UserRegistrationBLL ur)
    {
        string validfrom = "", validto = "";
        DateTime currentdate;


        try
        {
            ur.usrMobileNo = from;
            if (ur.usrMobileNo == "9422325020")
            {
                currentdate = System.DateTime.Now;
                validfrom = currentdate.ToString();

                validto = currentdate.AddMonths(12).ToString();

            }

            else
            {
                currentdate = System.DateTime.Now;
                validfrom = currentdate.ToString();

                validto = currentdate.AddMonths(1).ToString();
            }
            string query = "select usrFirstName+' '+usrLastName as FullName from usermaster where usrMobileNo='" + to + "'";
            string toname = Convert.ToString(cc.ExecuteScalar(query));
            string SmsTransactionUpdate = "insert into transferbalance(customername,mobileno,transferdate,transbal,prombal,validfrom,validupto,FromMobileno)values('" + toname + "','" + to + "','" + validfrom + "','" + tranamt + "','" + promoamt + "','" + validfrom + "','" + validto + "','" + from + "')";

            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                ur.usrMobileNo = to;
                status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
                if (status == 0)
                {
                    string checkFromBal = "select SMSbal,paidCount from UserMaster where usrMobileNo ='" + from.ToString() + "'";
                    DataSet ds = cc.ExecuteDataset(checkFromBal);
                    int fromBal = Convert.ToInt32(ds.Tables[0].Rows[0]["SMSbal"]);
                    int fromPromoBal = Convert.ToInt32(ds.Tables[0].Rows[0]["paidCount"]);
                    if (fromBal >= tranamt && fromPromoBal >= promoamt)
                    {
                        string tobal = "select SMSbal,paidCount from UserMaster where usrMobileNo ='" + to.ToString() + "'";
                        DataSet ds1 = cc.ExecuteDataset(tobal);
                        int toBalAdd = Convert.ToInt32(ds1.Tables[0].Rows[0]["SMSbal"]);
                        int toProBalAdd = Convert.ToInt32(ds1.Tables[0].Rows[0]["paidCount"]);
                        string remBal = "update UserMaster set SMSbal = " + (fromBal - tranamt) + ", paidCount= " + (fromPromoBal - promoamt) + " where usrMobileNo ='" + from.ToString() + "'";
                        int i = cc.ExecuteNonQuery(remBal);
                        if (i > 0)
                        {
                            string addBal = "update UserMaster set SMSbal =" + (toBalAdd + tranamt) + ", paidCount= " + (toProBalAdd + promoamt) + " where usrMobileNo ='" + to.ToString() + "'";
                            int j = cc.ExecuteNonQuery(addBal);
                            if (j > 0)
                            {
                                string fromResp = "Dear user your transaction is successfully updated. Your Trans Balance:" + (fromBal - tranamt) + " and Promo Balance:" + (fromPromoBal - promoamt) + "" + cc.AddSMS(from);
                                string toResp = "Dear user your recharge is successfully completed. Your current Balance:" + (toBalAdd + tranamt) + " and Promo Balance:" + (toProBalAdd + promoamt) + "" + cc.AddSMS(to);
                                string sendfrom = "myct.in";
                                // cc.SendMessage1(sendfrom, from, fromResp);
                                cc.SendMessageTra(sendfrom, from, fromResp);
                                //cc.SendMessage1(sendfrom, to, toResp);
                                cc.SendMessageTra(sendfrom, to, toResp);
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                                int pkchange = 0;
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                if (pkchange == 0)
                                {
                                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                                }
                                int balUp = cc.ExecuteNonQuery(SmsTransactionUpdate);

                            }
                        }
                    }

                    else
                    {
                        string sendfrom = "myct.in";
                        string fromResp1 = "Dear your transaction cannot update, Ur Trans Balance:" + (fromBal - tranamt) + " and Promo Balance:" + (fromBal - tranamt) + "is low" + cc.AddSMS(from);
                        cc.SendMessage1(sendfrom, from, fromResp1);

                    }

                }
                else
                {
                    string sendfrom = "myct.in";
                    string fromResp12 = "Dear user " + to + " number is not registered in myct.in. So cannot update ur balance" + cc.AddSMS(from) + "";
                    cc.SendMessage1(sendfrom, from, fromResp12);
                }
            }


        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "FillBalKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void smsBalKeyword(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                string balSql = "select SMSbal from UserMaster where usrMobileNo ='" + ur.usrMobileNo.ToString() + "'";
                string bal = Convert.ToString(cc.ExecuteScalar(balSql));
                string balSqlName = "select usrFirstName from UserMaster where usrMobileNo ='" + ur.usrMobileNo.ToString() + "'";
                string balName = Convert.ToString(cc.ExecuteScalar(balSqlName));
                string balSqlPaid = "select PaidCount from UserMaster where usrMobileNo ='" + ur.usrMobileNo.ToString() + "'";
                string balPaid = Convert.ToString(cc.ExecuteScalar(balSqlPaid));
                string resp = "Dear user your current sms balance:" + bal.ToString() + "" + cc.AddSMS(ur.usrMobileNo);
                string newBalSmsTra = "Dear " + balName.ToString() + " ur Regular SMS a/c balance is " + bal.ToString() + ". Nd/& ur Promotional SMS balance is " + balPaid.ToString() + " thanks. Via www.myct.in";
                cc.SendMessageTra(ur.usrMobileNo, ur.usrMobileNo, newBalSmsTra);
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "smsBalKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void sendMailSMS(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                DataSet ds = new DataSet();
                string sqlFetch = "select ur.usrUserId, ur.usrFirstName+' '+ur.usrLastName as name,ur.usrCityId as ctid,ct.cityName,dt.distName as distName, stt.stateName as stName from userMaster ur inner join CityMaster ct on ur.usrCityId=ct.cityId inner join DistrictMaster dt on ct.distId = dt.distId inner join StateMaster stt on stt.stateId = dt.stateId where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";

                ds = cc.ExecuteDataset(sqlFetch);
                string Name = "";
                int CityId = 0, KeyWordId = 0;
                string ctnm = "", dtnm = "", stnm = "", NewSmsResp = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Name = Convert.ToString(dr["name"]);
                    CityId = Convert.ToInt32(dr["ctid"]);
                    ctnm = Convert.ToString(dr["cityName"]);
                    dtnm = Convert.ToString(dr["distName"]);
                    stnm = Convert.ToString(dr["stName"]);
                    ur.usrUserId = Convert.ToString(dr["usrUserId"]);

                }
                string kwidSql = "select keywordId from KeywordDefinition where keywordName ='" + ur.usrKeyWord.ToString() + "'";
                KeyWordId = Convert.ToInt32(cc.ExecuteScalar(kwidSql));
                string sqlSaveComp = "insert into come2mycity.CompMaster(CompKeyWdId,CompSMS,CompMaker,CityId) values(" + KeyWordId + ",'" + ur.longCodegrSMS.ToString() + "','" + Name.ToString() + "'," + CityId + ")";
                int statusFlag = cc.ExecuteNonQuery(sqlSaveComp);
                if (statusFlag > 0)
                {

                    string subject = "", emlBody = "", emlTo = "", backUsrResponse = "", usrMoNo = "", sender = "";
                    usrMoNo = ur.usrMobileNo.ToString();
                    sender = "myctin";
                    string emlSql = "select email from KeywordDefinition where KeywordName='" + ur.usrKeyWord.ToString() + "'";
                    emlTo = Convert.ToString(cc.ExecuteScalar(emlSql));
                    if (ur.usrKeyWord == "SAKAL" || ur.usrKeyWord == "NBP" || ur.usrKeyWord == "MATA" || ur.usrKeyWord == "DESHONNATI" || ur.usrKeyWord == "LOKMAT")
                    {
                        string paper = "";
                        if (ur.usrKeyWord == "NBP")
                        {
                            paper = "Navbharat";
                        }
                        else
                        {
                            paper = ur.usrKeyWord;
                        }
                        backUsrResponse = "Thank's dear " + Name.ToString() + ", Your news send to ur favourite news paper " + paper.ToString() + " " + cc.AddSMS(usrMoNo);
                        subject = "Updated News From " + Name.ToString();
                        emlBody = "\nNEWS: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody += "\n\n.............www.myct.in";
                        ll.sendEmail(emlTo, subject, emlBody);
                        // cc.SendMessage1(sender, usrMoNo, backUsrResponse);
                        cc.SendMessageTra(sender, usrMoNo, backUsrResponse);

                    }

                    else if (ur.usrKeyWord == "MJP" || ur.usrKeyWord == "LBTV" || ur.usrKeyWord == "Mjp" || ur.usrKeyWord == "mjp" || ur.usrKeyWord == "NREGA" || ur.usrKeyWord == "Nrega" || ur.usrKeyWord == "nrega" || ur.usrKeyWord == "BJS")
                    {
                        if (ur.usrKeyWord == "MJP")
                        {
                            sender = "myctin";
                            backUsrResponse = "Dear " + Name.ToString() + ",ur complaint for Maharashtra Jivan Pradhikaran(MJP) is received,It is forwarded to concern department. Thanks.via www.myct.in ";
                            subject = "Mail From " + Name.ToString();
                            emlBody = "Mail: " + ur.longCodegrSMS.ToString() + " FROM: " + Name.ToString() + " City: " + ctnm.ToString() + " District:" + dtnm.ToString() + " State:" + stnm.ToString();
                            emlBody += ".............www.myct.in";
                            NewSmsResp = "Welcome to Maharashtra state madhyamik shala shikshetar sanghatnanche mahamandal(www.mhmsm.org) Via:www.myct.in";
                            ur.usrMessageString = NewSmsResp.ToString();
                            ll.sendEmail(emlTo, subject, emlBody);
                            cc.SendMessageTra(sender, usrMoNo, backUsrResponse);
                        }
                        else if (ur.usrKeyWord == "BJS")
                        {
                            sender = "myctin";
                            backUsrResponse = "Dear " + Name.ToString() + ",Thanks to contact Bharat Jain Sanghatana, We will give follow up soon. thanks.via www.myct.in ";
                            subject = "Mail From " + Name.ToString();
                            emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nMobile No: " + ur.usrMobileNo + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                            emlBody += "\n\n.............www.myct.in";
                            NewSmsResp = "Welcome to Bharat Jain Sanghatana Via:www.myct.in";
                            ur.usrMessageString = NewSmsResp.ToString();
                            ll.sendEmail(emlTo, subject, emlBody);
                            cc.SendMessageTra(sender, usrMoNo, backUsrResponse);
                        }
                        else if (ur.usrKeyWord == "NREGA")
                        {
                            sender = "myctin";
                            backUsrResponse = "Dear " + Name.ToString() + ",ur complaint for NREGA is received,It is forwarded to concern department. Thanks.via www.myct.in ";
                            subject = "Mail From " + Name.ToString();
                            emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                            emlBody += "\n\n.............www.myct.in";
                            NewSmsResp = "Welcome to Maharashtra state madhyamik shala shikshetar sanghatnanche mahamandal(www.mhmsm.org) Via:www.myct.in";
                            ur.usrMessageString = NewSmsResp.ToString();
                            ll.sendEmail(emlTo, subject, emlBody);
                            cc.SendMessageTra(sender, usrMoNo, backUsrResponse);
                        }
                        else if (ur.usrKeyWord == "LBTV")
                        {
                            sender = "myctin";
                            backUsrResponse = "Dear " + Name.ToString() + ",ur complaint for LBTV is received,It is forwarded to concern department. Thanks.via www.myct.in ";
                            subject = "Mail From " + Name.ToString();
                            emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                            emlBody += "\n\n.............www.myct.in";
                            NewSmsResp = "Welcome to Maharashtra state madhyamik shala shikshetar sanghatnanche mahamandal(www.mhmsm.org) Via:www.myct.in";
                            ur.usrMessageString = NewSmsResp.ToString();
                            ll.sendEmail(emlTo, subject, emlBody);
                            cc.SendMessageTra(sender, usrMoNo, backUsrResponse);
                        }
                    }
                    else if (ur.usrKeyWord == "MHMSM" || ur.usrKeyWord == "MhMsm" || ur.usrKeyWord == "mhmsm")
                    {
                        backUsrResponse = "Thank's dear " + Name.ToString() + ", Your Mail send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                        subject = "Mail From " + Name.ToString();
                        emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody += "\n\n.............www.myct.in";
                        NewSmsResp = "Welcome to Maharashtra state madhyamik shala shikshetar sanghatnanche mahamandal(www.mhmsm.org) Via:www.myct.in";
                        ur.usrMessageString = NewSmsResp.ToString();
                        ll.sendEmail(emlTo, subject, emlBody);
                        cc.SendMessageTra(sender, usrMoNo, NewSmsResp);
                    }
                    else if (ur.usrKeyWord == "MSS" || ur.usrKeyWord == "SAHU" || ur.usrKeyWord == "CG" || ur.usrKeyWord == "TELI" || ur.usrKeyWord == "JANGID" || ur.usrKeyWord == "JB" || ur.usrKeyWord == "ALLAH" || ur.usrKeyWord == "JM" || ur.usrKeyWord == "MALI" || ur.usrKeyWord == "MSCIT" || ur.usrKeyWord == "OM" || ur.usrKeyWord == "WSSD" || ur.usrKeyWord == "DIDIMA")
                    {
                        string MyKey = ur.usrKeyWord.ToString();
                        string MyKeyResp = "";
                        if (MyKey == "JM")
                        {
                            MyKeyResp = "Maheshwari";
                        }
                        else if (MyKey == "JB")
                        {
                            MyKeyResp = "Jai Bhim";
                        }
                        else if (MyKey == "ALLAH")
                        {
                            MyKeyResp = "Muslim";
                        }
                        else if (MyKey == "OM")
                        {
                            MyKeyResp = "BHARAT SWABHIMAN";
                        }

                        else if (MyKey == "WSSD")
                        {
                            MyKeyResp = "WATER SUPPLY DEPARTMENT";
                        }

                        else if (MyKey == "SAHU")
                        {
                            MyKeyResp = "SAHU SAMAJ";
                        }
                        else if (MyKey == "CG")
                        {
                            MyKeyResp = "SAHU SAMAJ";
                        }
                        else if (MyKey == "MSS")
                        {
                            MyKeyResp = "Maratha";
                        }
                        else
                        {
                            MyKeyResp = MyKey.ToString();
                        }

                        backUsrResponse = "Thank's dear " + Name.ToString() + ", Your Mail send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                        if (MyKey == "CG")
                            subject = "welcome to ma karma jayanti programme...........By-" + Name.ToString();
                        else
                            subject = "Mail From " + Name.ToString();

                        emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody += "\n\n.............www.myct.in";
                        NewSmsResp = "THANKS to join " + MyKeyResp.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                        ur.usrMessageString = NewSmsResp.ToString();
                        ll.sendEmail(emlTo, subject, emlBody, MyKey);
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                        if (status == 0)
                        {
                            string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                            string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                            if (MyKey == "CG")
                                NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            else
                                NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            //cc.mailSendingSMS(emlTo, subject, emlBody,MyKey );
                            //ll.sendEmail(emlTo, subject, emlBody);
                            cc.SendMessageTra(sender, usrMoNo, NewSmsResp, MyKey);
                        }
                        else
                        {
                            //string MyKey = "RAVIDASSIA";
                            RegisterByLongCodePINNew(ur, MyKey);
                        }
                    }

                    else if (ur.usrKeyWord == "JAIN")
                    {

                        string MyKey = ur.usrKeyWord.ToString();
                        string MyKeyResp = "";
                        if (MyKey == "JAIN")
                        {
                            MyKeyResp = "Bharat Jain Samaj";
                        }
                        backUsrResponse = "Thank's dear " + Name.ToString() + ", Your Mail send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);

                        subject = "Mail From " + Name.ToString();

                        emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody += "\n\n.............www.myct.in";
                        NewSmsResp = "THANKS to join " + MyKeyResp.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                        ur.usrMessageString = NewSmsResp.ToString();
                        ll.sendEmail(emlTo, subject, emlBody, MyKey);
                        status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);


                        if (status == 0)
                        {
                            string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                            string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                            if (MyKey == "CG")
                                NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            else
                                NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            cc.SendMessageTra(sender, usrMoNo, NewSmsResp, MyKey);
                            RegisterByLongCodeNew(ur);

                        }
                        else
                        {

                            RegisterByLongCodeNew(ur);
                            RegisterByLongCodePINNew(ur, MyKey);
                        }
                    }










                    else if (ur.usrKeyWord == "RAVIDASSIA" || ur.usrKeyWord == "RAVIDASIA" || ur.usrKeyWord == "RAVIDASIYA" || ur.usrKeyWord == "RAVIDASIA" || ur.usrKeyWord == "Ravidassia" || ur.usrKeyWord == "ravidassia")
                    {
                        ur.usrKeyWord = "RAVIDASSIA";
                        string groupName = "select GroupValueId from GroupValue where GroupValueName='RAVIDASSIA'";
                        string groupId = cc.ExecuteScalar(groupName);
                        string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                        int groupFlag = 0;
                        string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                        string uID = "";
                        uID = cc.ExecuteScalar(checkPrevGrReg);
                        if (uID.ToString() == "")
                        {
                            groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                        }
                        //Thanks to join |A| group all India mobile directory. u r registered on www.myct.in to receive important messages concern to u. Via: www.myct.in
                        string[] nm = Name.Split(' ');
                        backUsrResponse = "THANKS to join RAVIDASSIA group in all India mobile directory on www.myct.in to receive imp sms.";
                        subject = "Complaint From " + Name.ToString();
                        emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody += "\n\n.............www.myct.in";
                        string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                        string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                        backUsrResponse += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                        ll.sendEmail(emlTo, subject, emlBody);
                        cc.SendMessageTra(sender, usrMoNo, backUsrResponse);

                    }
                    //else if (ur.usrKeyWord == "YASHADA" || ur.usrKeyWord == "YASHADA")
                    //{
                    //    ur.usrKeyWord = "YASHADA";
                    //    string groupName = "select GroupValueId from GroupValue where GroupValueName='CG'";
                    //    string groupId = cc.ExecuteScalar(groupName);
                    //    string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                    //    int groupFlag = 0;
                    //    string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                    //    string uID = "";
                    //    uID = cc.ExecuteScalar(checkPrevGrReg);
                    //    if (uID.ToString() == "")
                    //    {
                    //        groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                    //    }
                    //    //Thanks to join |A| group all India mobile directory. u r registered on www.myct.in to receive important messages concern to u. Via: www.myct.in
                    //    string[] nm = Name.Split(' ');
                    //    backUsrResponse = "THANKS to join BJP group in all India mobile directory on www.myct.in to receive imp sms.";
                    //    subject = "Mail From " + Name.ToString();
                    //    emlBody = "Mail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                    //    emlBody += "\n\n.............www.myct.in";
                    //    string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                    //    string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                    //    backUsrResponse += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                    //    ll.sendEmail(emlTo, subject, emlBody);
                    //    cc.SendMessageTra(sender, usrMoNo, backUsrResponse);

                    //}

                        //////////    add new keyword 'BJP'-------pooja.  25/6/2012.
                    else if (ur.usrKeyWord == "BJP" || ur.usrKeyWord == "bjp" || ur.usrKeyWord == "Bjp" || ur.usrKeyWord == "BjP" || ur.usrKeyWord == "bJP")
                    {
                        ur.usrKeyWord = "BJP";
                        string groupName = "select GroupValueId from GroupValue where GroupValueName='BJP Group'";
                        string groupId = cc.ExecuteScalar(groupName);
                        string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                        int groupFlag = 0;
                        string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                        string uID = "";
                        uID = cc.ExecuteScalar(checkPrevGrReg);
                        if (uID.ToString() == "")
                        {
                            groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                        }
                        //Thanks to join |A| group all India mobile directory. u r registered on www.myct.in to receive important messages concern to u. Via: www.myct.in
                        string[] nm = Name.Split(' ');
                        backUsrResponse = "THANKS to join BJP group in all India mobile directory on www.myct.in to receive imp sms.";
                        subject = "Mail From " + Name.ToString();
                        emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody += "\n\n.............www.myct.in";
                        string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                        string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                        backUsrResponse += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                        ll.sendEmail(emlTo, subject, emlBody);
                        cc.SendMessageTra(sender, usrMoNo, backUsrResponse);

                    }
                    else if (ur.usrKeyWord == "XYZ" || ur.usrKeyWord == "xyz" || ur.usrKeyWord == "Xyz" || ur.usrKeyWord == "XyZ" || ur.usrKeyWord == "xYZ")
                    {
                        ur.usrKeyWord = "XYZ";
                        string groupName = "select GroupValueId from GroupValue where GroupValueName='BJP Group'";
                        string groupId = cc.ExecuteScalar(groupName);
                        string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                        int groupFlag = 0;
                        string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                        string uID = "";
                        uID = cc.ExecuteScalar(checkPrevGrReg);
                        if (uID.ToString() == "")
                        {
                            groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                        }
                        //Thanks to join |A| group all India mobile directory. u r registered on www.myct.in to receive important messages concern to u. Via: www.myct.in
                        string[] nm = Name.Split(' ');
                        backUsrResponse = "THANKS to join XYZ group in all India mobile directory on www.myct.in to receive imp sms.";
                        subject = "Mail From " + Name.ToString();
                        emlBody = "\nMail: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody += "\n\n.............www.myct.in";
                        string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                        string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                        backUsrResponse += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                        ll.sendEmail(emlTo, subject, emlBody);
                        cc.SendMessageTra(sender, usrMoNo, backUsrResponse);

                    }
                    else
                    {
                        backUsrResponse = "Dear user" + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ".Thanks " + cc.AddSMS(usrMoNo);
                        subject = "Complaint From " + Name.ToString();
                        emlBody = " Dear COMPLAINT: " + ur.longCodegrSMS.ToString() + " FROM: " + Name.ToString() + " Mobile No: " + ur.usrMobileNo + " City: " + ctnm.ToString() + " District:" + dtnm.ToString() + " State:" + stnm.ToString();
                        emlBody += "\n\n....Thanks.www.myct.in";

                        cc.SendMessage1(sender, usrMoNo, backUsrResponse);
                        //ll.sendEmail(emlTo, subject, emlBody);
                        cc.mailSendingSMSAsEmail(emlBody, emlTo, subject);

                    }



                }

            }
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "sendMailSMS()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }

    public void SaveBlog(string kwd, string mono, string blog, UserRegistrationBLL ur)
    {
        try
        {
            string sqlSubGrNm = "select SubGroupName from KeywordDefinition where KeywordName='" + kwd.ToString() + "'";
            string subGrNm = Convert.ToString(cc.ExecuteScalar(sqlSubGrNm));
            string sqlGrId = "select GroupValueId from GroupValue where GroupValueName='" + subGrNm.ToString() + "'";
            int GrId = Convert.ToInt32(cc.ExecuteScalar(sqlGrId));
            //string sqlWriter = "select usrFirstName+' '+usrLastName from UserMaster where usrMobileNo='"+mono .ToString ()+"'";
            //string BgWriter = Convert.ToString(cc .ExecuteScalar (sqlWriter));
            string sqlBlogInsert = "insert into tblBlog(bgGrId,BgWriter,Bg) values (" + GrId + ",'" + mono.ToString() + "','" + blog.ToString() + "')";
            int i = cc.ExecuteNonQuery(sqlBlogInsert.ToString());
            if (i >= 0)
            {
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "SaveBlog()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }



}
