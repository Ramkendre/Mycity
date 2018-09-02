#region NameSpaces

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
using System.Net.Mail;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mime;
using ClassCommon;
using System.Text;
using System.Text.RegularExpressions;
using okclsms;

#endregion NameSpaces

public partial class html_MobileASCIIsms : System.Web.UI.Page
{
    #region Datatype
    CommonCode cc = new CommonCode();
    Location ll = new Location();
    AsciiSubPage asp = new AsciiSubPage();

    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    UDISE_AddSubUser udise_addsub = new UDISE_AddSubUser();
    KeywordSyntax key = new KeywordSyntax();

    string removeDotinSMSBody = "", Attendence = "", getKeyword = "", UpperKeword = "", Data = "New", CurrenctDate = "";
    string[] SplitMsg, mKeyword;
    string receiverMoNo = "", senderMobileNo = "", smsBody = "", receivedDate = "", p1 = "", p2 = "", p3 = "", p4 = "", p5 = "", MobileNo = "";

    string LeaderRoleId = "", LLeaderNo_usrID = "", Leader_UserID = "", schoolcode = "", schoolName = "", HM_MobileNo = "";
    string initialreference = "", Leader_RoleName = "", Leader_RoleID = "", Leader_Leader;
    string reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "";
    string reference_id6 = "", reference_id7 = "", reference_id8 = "", reference_id9 = "", reference_id10 = "", reference_id11 = "";
    string UserName = "", LeaderNo, fname = "", lname = "", usrclass = "", section = "";

    //----------------------------------------------------- Booth Data-------------------------------------------

    // localhost.GetVoterDetails SendBoothDetails = new localhost.GetVoterDetails();
    public string nm = "", add = "", SchCode = "", emailID = "", uvaStr = "";
    public static string remainMsg = "";
    public const string MatchEmailPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

    string mmmsg0, mmmsg1, mmmsg2, Pinmsg1 = "", GrMembers = "", WholeMsg = "", smsStatus = "N", emlBody = "", newnewpin = "";
    string PinMessage = "", PinMobile = "", shortcode = "", mkeyword1 = "", message1 = "", message = "", mobile = "", userId = "";
    int iii, GrNameId, smslength, status;
    string subject = "", NewSmsResp = "", emlTo = "", backUsrResponse = "", receivedon = "";
    #endregion Datatype

    #region WebserviceCbject

    ezeedrug.DrugApps drug = new ezeedrug.DrugApps();
    myctDrug.DrugApps drugmyct = new myctDrug.DrugApps();
    come2myschool.ConnectToCT scID = new come2myschool.ConnectToCT();
    onlineExam.ClassApp OnExam = new onlineExam.ClassApp();

    #endregion WebserviceCbject

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            firstPostBack();
        }
    }

    #region firstPostBack
    public void firstPostBack()
    {
        try
        {
            receiverMoNo = Convert.ToString(Request.QueryString["receiverMobileNo"]);
            senderMobileNo = Convert.ToString(Request.QueryString["senderMobileNo"]);
            smsBody = Convert.ToString(Request.QueryString["receivedSmsBody"]);

            //smsBody = "68,65,82,42,50,42,82,66,42,49,49,42,82,71,42,49,56,42,80,66,42,49,49,42,80,71,42,49,50,46";

            DateTime date = DateTime.Now;
            receivedDate = Convert.ToString(Request.QueryString["receivedDateTime"]);

            if (smsBody.Contains("39"))
            {
                smsBody = smsBody.Replace("39", "34");
            }
            smsBody = Get(smsBody);  //Uncomment this when upload

            //smsBody = "REPLACEJR*9423627574*9822960039*Abhinav Bhutada";

            MobileNo = senderMobileNo.Substring(2, 10); //Uncomment this when upload
            //MobileNo = senderMobileNo; //Comment this when upload
            //  MobileNo = "9420218388";
            HM_MobileNo = MobileNo;
            if (MobileNo.Length == 10)
            {
                p1 = Convert.ToString(Request.QueryString["p1"]);
                p2 = Convert.ToString(Request.QueryString["p2"]);
                p3 = Convert.ToString(Request.QueryString["p3"]);
                p4 = Convert.ToString(Request.QueryString["p4"]);
                p5 = Convert.ToString(Request.QueryString["p5"]);
                string sql = "insert into longCodeasciiSmsReceve(receiverMobileNo,senderMobileNo,receivedSmsBody,receivedDateTime,p1,p2,p3,p4,p5) values('" + receiverMoNo + "','" + MobileNo + "','" + smsBody + "','" + receivedDate + "','" + p1 + "','" + p2 + "','" + p3 + "','" + p4 + "','" + p5 + "')";
                int i = cc.ExecuteNonQuery(sql);

                string[] InsertedValue = smsBody.Split('*');
                string currentDate = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                //string[] InsertedValue = new string[] { "EZEETEST","899052100092288", "911990022699992323","Santosh","Gurude","Abhinav","9421364622","Ezee","pqr@gmail.com","P1","410503","p2","0.0","0.5","27","613","25","p3","p4","898","SMS","1" };
                if (InsertedValue[0] == "evidyalaya" || InsertedValue[0] == "EVIDYALAYA" || InsertedValue[0] == "eVidyalaya" || InsertedValue[0] == "Evidyalaya")
                {
                    okclsms.InsertDataToOkcl okcl = new okclsms.InsertDataToOkcl();
                    okcl.InsertDataToOkclTable(MobileNo, InsertedValue[1]);

                    //SendDataToOkcl objOkcl = new SendDataToOkcl();
                    //int codval = objOkcl.InsertDataToOkclTable(MobileNo, InsertedValue[1]);
                }
                else
                {
                    string sql2 = "select * from IMEI_SMS_WSData where IMEI_NO='" + InsertedValue[1] + "'";
                    DataSet ds = cc.ExecuteDataset(sql2);
                    string imeino = string.Empty;
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        string sql1 = "insert into [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData]([ProjName],[IMEI_NO],[SimSerialNo],[FirstName],[LastName],[FirmName],[SMSMobileNo],[WSMobileNo],[TestName],[EmailID],[P1],[Pincode],[p2],[Latitude],[Longitude],[StateId],[DistrictId],[TalukaId],[p3],[p4],[ExamId],[SMS_WS],[Status],[ReceivedDateTime])values " +
                            "('" + (InsertedValue[0]) + "','" + InsertedValue[1] + "','" + InsertedValue[2] + "','" + InsertedValue[3] + "','" + InsertedValue[4] + "','" + InsertedValue[5] + "','" + senderMobileNo + "','" + InsertedValue[6] + "','" + InsertedValue[7] + "','" + InsertedValue[8] + "','" + InsertedValue[9] + "','" + InsertedValue[10] + "','" + InsertedValue[11] + "','" + InsertedValue[12] + "','" + InsertedValue[13] + "','" + InsertedValue[14] + "','" + InsertedValue[15] + "','" + InsertedValue[16] + "','" + InsertedValue[17] + "','" + InsertedValue[18] + "','" + InsertedValue[19] + "','SMS','1','" + currentDate + "')";
                        int j = cc.ExecuteNonQuery(sql1);
                    }
                    else
                    {
                        if (senderMobileNo == "91" + Convert.ToString(ds.Tables[0].Rows[0]["WSMobileNo"]))
                        {
                            string str = "update [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData] set [SMSMobileNo]='" + senderMobileNo + "',[SMS_WS]='SMS',[Status]='1',[ReceivedDateTime]='" + currentDate + "' where [IMEI_NO]='" + InsertedValue[1] + "' and [ProjName]='" + InsertedValue[0] + "'";
                            int k = cc.ExecuteNonQuery(str);
                        }
                        else
                        {
                            string str = "update [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData] set [SMSMobileNo]='" + senderMobileNo + "',[SMS_WS]='SMS',[Status]='0',[ReceivedDateTime]='" + currentDate + "' where [IMEI_NO]='" + InsertedValue[1] + "' and [ProjName]='" + InsertedValue[0] + "'";
                            int k = cc.ExecuteNonQuery(str);
                        }
                    }
                }

                if (i == 1)
                {
                    // Attendence();
                    ////string AllSyntax = Convert.ToString(smsBody);
                    ////smsBody = AllSyntax.Replace(".", "");
                    ////string Attendence = Convert.ToString(smsBody);
                    ////string[] Attend = Attendence.Split('*');
                    ////string Syntax = Convert.ToString(Attend[0]);
                    ////string UpperSyntax = Syntax.ToUpper();

                    ////if (UpperSyntax == "DAR" || UpperSyntax == "STAFF" || UpperSyntax == "CAR")
                    ////{

                    ////    //URL = "http://www.come2mycity.com/sendMsg.aspx?message=" + Convert.ToString(smsBody) + "&mobilenumber=" + Convert.ToString(MobileNo) + "&receivedon=" + Convert.ToString(date) + "&SIMNO=" + Convert.ToString(p1) + "&IMEINO=" + Convert.ToString(p2) + "";
                    ////    //// URL = "http://localhost:1688/myctin/sendMsg.aspx?message=" + Convert.ToString(smsBody) + "&mobilenumber=" + Convert.ToString(MobileNo) + "&receivedon=" + Convert.ToString(date) + "&SIMNO=" + Convert.ToString(p1) + "&IMEINO=" + Convert.ToString(p2) + "";
                    ////    //Response.Redirect(URL);

                    ////}
                    DateTime dt = DateTime.Now; // get current date
                    double d = 5; //add hours in time
                    double m = 48; //add min in time
                    DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
                    SystemDate = SystemDate.AddMinutes(m);
                    CurrenctDate = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");

                    removeDotinSMSBody = smsBody;
                    Attendence = Convert.ToString(removeDotinSMSBody);
                    // rtertert ret ert
                    SplitMsg = Attendence.Split('*');

                    getKeyword = Convert.ToString(SplitMsg[0].Trim());
                    UpperKeword = getKeyword.ToUpper();
                    if (UpperKeword == "DAR" || UpperKeword == "STAFF" || UpperKeword == "CAR" || UpperKeword == "TEACHER" || UpperKeword == "REPLACEJR" || UpperKeword == "CMN" || UpperKeword == "HM" || UpperKeword == "CH" ||
                        UpperKeword == "JRLIST" || UpperKeword == "EZEEMEMBERAPP130" || UpperKeword == "LEADER" || UpperKeword == "REPLACE" || UpperKeword == "BOOTH" || UpperKeword == "EZEEDRUG" || UpperKeword == "EZEECLASS" || UpperKeword == "ADM" || UpperKeword == "MDM" || UpperKeword == "UDISE" || UpperKeword == "ADMISSION" || UpperKeword == "EZEESCHOOLAPP")
                    {
                        if (UpperKeword == "DAR")
                        {
                            Udise_StudentAttendance();
                        }
                        else if (UpperKeword == "CAR")
                        {
                            Udise_StudentAttendanceCAR();
                        }
                        else if (UpperKeword == "STAFF")
                        {
                            Udise_TeacherAttendance();
                        }
                        else if (UpperKeword == "TEACHER")
                        {
                            Udise_AddTeachar();
                        }
                        else if (UpperKeword == "REPLACEJR")
                        {
                            Replace_JR();
                        }
                        else if (UpperKeword == "CMN")
                        {
                            Udise_ChngMobNo();
                        }
                        else if (UpperKeword == "HM" || UpperKeword == "CH")
                        {
                            Udise_AddChHm();
                        }
                        else if (UpperKeword == "JRLIST")
                        {
                            Udise_JrList();
                        }
                        else if (UpperKeword == "EZEEMEMBERAPP130")
                        {
                            Apart_RegEzeeDevice();
                        }
                        else if (UpperKeword == "EZEEDRUG" || UpperKeword == "EZEECLASS" || UpperKeword == "EZEESCHOOLAPP")
                        {
                            EzeeDrugs_RegDevice();
                        }
                        else if (UpperKeword == "ADM" || UpperKeword == "MDM" || UpperKeword == "ADMISSION" || UpperKeword == "UDISE")
                        {
                            Mdmadm();
                        }
                        else if (UpperKeword == "LEADER" || UpperKeword == "REPLACE" || UpperKeword == "BOOTH")
                        {
                            if (UpperKeword == "LEADER")
                            {
                                AddLeaderBooth();
                            }
                            else if (UpperKeword == "REPLACE")
                            {
                                //ReplaceBoothMem();
                            }
                            else if (UpperKeword == "BOOTH")
                            {
                                Booth();
                            }
                        }
                        else if (SplitMsg.Length != 11 || SplitMsg.Length != 9)
                        {
                            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                               " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
                            int b = cc.ExecuteNonQuery(Sql);
                        }
                    }
                    else if (UpperKeword == "BJSS" || UpperKeword == "BJSE")
                    {
                        asp.BJSSBJSE(smsBody, MobileNo, CurrenctDate, p1, p2);
                    }
                    else if (UpperKeword == "SMS2EO" || UpperKeword == "SMS2DEO" || UpperKeword == "SMS2BEO" || UpperKeword == "SMS2EXTO" || UpperKeword == "SMS2CH" || UpperKeword == "SMS2HM" || UpperKeword == "SMS2CT")
                    {
                        SendSMSToLevel();
                    }
                    else if (UpperKeword == "SMS2CLASS1" || UpperKeword == "SMS2CLASS2" || UpperKeword == "SMS2CLASS3" || UpperKeword == "SMS2CLASS4" || UpperKeword == "SMS2CLASS5" || UpperKeword == "SMS2CLASS6" || UpperKeword == "SMS2CLASS7"
                             || UpperKeword == "SMS2CLASS8" || UpperKeword == "SMS2CLASS9" || UpperKeword == "SMS2CLASS10" || UpperKeword == "SMS2CLASS11" || UpperKeword == "SMS2CLASS12")
                    {
                        SendTeacherSms();
                    }
                    else
                    {
                        LongCode();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                         " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }
    #endregion firstPostBack

    //--------------------------------------------------Ascii Message Convert to string-------------------------------------------------------------------

    #region GetAscii
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
            character = (char)a1;
            text = character.ToString();
            myCollection.Add(text);
        }
        string resulr = String.Join("", myCollection.ToArray());
        return resulr;

    }
    #endregion GetAscii

    //--------------------------------------------------ADM And MDM--------------------------------------------------------------------------------------

    #region mdmAdm

    public void Mdmadm()
    {
        string sender = "myctin";
        string senderid = "myctin";
        if (UpperKeword == "ADM" || UpperKeword == "Adm" || UpperKeword == "ADMISSION")
        {
            if (smsBody.Contains('*'))
            {
                asp.UdiseAdm(MobileNo, smsBody, CurrenctDate, p1, p2);
            }
            else
            {
                backUsrResponse = "Adm*1*A*RB*45*RG*20# 2*A*RB*45*RG*20# 3*A*RB*45*RG*20# 4*A*RB*45*RG*20# 5*A*RB*45*RG*20# 6*A*RB*45*RG*20# 7*A*RB*45*RG*20# 8*A*RB*45*RG*20 www.myct.in";
                cc.SendMessageTra(sender, MobileNo, backUsrResponse);
            }
        }
        else if (UpperKeword == "MDM")
        {
            if (smsBody.Contains('*'))
            {
                string Whlm = smsBody.ToUpper();
                asp.UdiseMDM(MobileNo, Whlm, CurrenctDate, p1, p2);
            }
            else
            {
                backUsrResponse = "MDM*MENU1#DAR*1*A*PB*45*PG*20*M*65# 2*A*PB*45*PG*20*M*65# 3*A*PB*45*PG*20*M*65# 4*A*PB*45*PG*20*M*65# 5*A*PB*45*PG*20*M*65# 6*A*PB*45*PG*20*M*65# 7*A*PB*45*PG*20*M*65# 8*A*PB*45*PG*20*M*65 www.myct.in";
                cc.SendMessageTra(sender, MobileNo, backUsrResponse);
            }
        }
        else if (UpperKeword == "UDISE")
        {
            if (smsBody.Contains('*'))
            {
                //string Whlm = smsBody.ToUpper();
                //asp.UdiseMDM(MobileNo, Whlm, CurrenctDate, p1, p2);
            }
            else
            {
                backUsrResponse = "Udise*27040400115*HM*murlidhar*bhutada*CH*7766443355*Exto*8866346766*BEO*8765698767*DEO*9758764563*EO*9765574422 www.myct.in";
                cc.SendMessageTra(sender, MobileNo, backUsrResponse);
            }
        }
        else
        {
            string[] splitarr = WholeMsg.Split('*');

            string sql = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string userid = cc.ExecuteScalar(sql);
            sql = "insert into DataCollection(sender_mobileno,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,send_date)" +
                   " values('" + userid + "','" + splitarr[0] + "','" + splitarr[1] + "','" + splitarr[2] + "','" + splitarr[3] + "' " +
                   " ,'" + splitarr[4] + "','" + splitarr[5] + "','" + splitarr[6] + "','" + splitarr[7] + "','" + splitarr[8] + "' " +
                   " ,'" + splitarr[9] + "','" + splitarr[10] + "','" + splitarr[11] + "','" + CurrenctDate + "')";
            string execute = cc.ExecuteScalar(sql);
            backUsrResponse = "Dear user your record updated successfully thanks via www.myct.in";
            cc.SendMessageTra(senderid, mobile, backUsrResponse);

        }
    }

    #endregion mdmAdm

    //--------------------------------------------------Send SMS To Udise Level SMS-----------------------------------------------------------------------

    #region SendSms2UdisecceHirarchy
    public void SendSMSToLevel()
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select Roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' and Active=1 and mainrole=1 ";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "" || GetRoleID == null)
                { }
                else
                {

                    string sql = "";
                    string To = UpperKeword;
                    string RoleIdChk = "";

                    if (UpperKeword == "SMS2DEO")
                    {
                        RoleIdChk = "19";
                    }
                    else if (UpperKeword == "SMS2BEO")
                    {
                        RoleIdChk = "20";
                    }
                    else if (UpperKeword == "SMS2EXTO")
                    {
                        RoleIdChk = "21";
                    }
                    else if (UpperKeword == "SMS2CH")
                    {
                        RoleIdChk = "75";
                    }
                    else if (UpperKeword == "SMS2HM")
                    {
                        RoleIdChk = "76";
                    }
                    else if (UpperKeword == "SMS2CT")
                    {
                        RoleIdChk = "77";
                    }
                    if (RoleIdChk == "" || RoleIdChk == null)
                    {
                    }
                    else
                    {
                        sql = sql + "select rolename,usrFirstName+' '+usrLastName  as name,usrMobileNo,TScode.schoolcode from AdminSubMarketingSubUser as asm " +
                                    " inner join UserMaster on UserMaster.usruserid=asm.friendid " +
                                    " left outer  join UDISE_TeacherMaster as TScode on TScode.junior_id=asm.userid where";
                        if (GetRoleID == "18")
                        {
                            sql = sql + "   reference_id6 ='" + getuserID + "' and asm.roleid=" + RoleIdChk + "";
                        }
                        else if (GetRoleID == "19")
                        {
                            sql = sql + "   reference_id7 ='" + getuserID + "' and asm.roleid=" + RoleIdChk + "";
                        }
                        else if (GetRoleID == "20")
                        {
                            sql = sql + "   reference_id8 ='" + getuserID + "' and asm.roleid=" + RoleIdChk + "";
                        }
                        else if (GetRoleID == "21")
                        {
                            sql = sql + "   reference_id9 ='" + getuserID + "' and asm.roleid=" + RoleIdChk + "";
                        }
                        else if (GetRoleID == "75")
                        {
                            sql = sql + "   reference_id10 ='" + getuserID + "' and asm.roleid=" + RoleIdChk + "";
                        }
                        else if (GetRoleID == "76")
                        {
                            sql = sql + "   reference_id11 ='" + getuserID + "' and asm.roleid=" + RoleIdChk + "";
                        }

                        DataSet ds = cc.ExecuteDataset(sql);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int totalsms = ds.Tables[0].Rows.Count;
                            string Mgs = "Dear sir/Madam Total " + totalsms + " message sent successfully www.udisecce.myct.in & www.myct.in ";
                            int leg = Mgs.Length;
                            cc.TransactionalSMSCountry("UDISE", MobileNo, Mgs, leg, 15);

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                string SetMobileno = "";
                                SetMobileno = Convert.ToString(ds.Tables[0].Rows[i]["usrMobileNo"]);
                                if (SetMobileno != "" || SetMobileno != null)
                                {
                                    string Message = SplitMsg[1].ToString() + cc.AddSMS(SetMobileno);
                                    smslength = Message.Length;

                                    cc.TransactionalSMSCountry(MobileNo, SetMobileno, Message, smslength, 15);

                                    string Sql1 = "Insert Into UDISE_SendSMSReport(SendFrom ,SendTo,sentMessage,smslength,sendercode,EntryDate)" +
                                                 "values('" + MobileNo + "','" + SetMobileno + "','" + Message + "','" + smslength + "',15,'" + CurrenctDate + "')";
                                    int k = cc.ExecuteNonQuery(Sql1);
                                    if (k == 1)
                                    {
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion SendSms2UdisecceHirarchy

    #region HMSendMessageToClassTeachar
    public void SendTeacherSms()
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select Roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' and Active=1 and mainrole=1 ";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "76")
                {
                    string checkschoolcode = "select sm.SchoolCode from UDISE_SchoolMaster as sm inner join UDISE_TeacherMaster as Tm on Tm.SchoolCode=sm.SchoolCode  where Tm.junior_id='" + getuserID + "' and Tm.Active=1";
                    string Getschoolcode = cc.ExecuteScalar(checkschoolcode);
                    if (Getschoolcode == "" || Getschoolcode == null)
                    { }
                    else
                    {
                        DataSet Dstech = new DataSet();
                        Dstech = null;
                        string Sql = "SELECT usrMobileNo,junior_id,Class,Section  FROM UDISE_TeacherMaster inner join UserMaster on UDISE_TeacherMaster.junior_id=UserMaster.usrUSerId where ";
                        switch (UpperKeword)
                        {

                            case "SMS2CLASS1":
                                Sql = Sql + " class=1 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS2":
                                Sql = Sql + " class=2 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS3":
                                Sql = Sql + " class=3 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS4":
                                Sql = Sql + " class=4 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS5":
                                Sql = Sql + " class=5 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS6":
                                Sql = Sql + " class=6 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS7":
                                Sql = Sql + " class=7 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS8":
                                Sql = Sql + " class=8 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS9":
                                Sql = Sql + " class=9 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS10":
                                Sql = Sql + " class=10 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS11":
                                Sql = Sql + " class=11 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            case "SMS2CLASS12":
                                Sql = Sql + " class=12 and Schoolcode='" + Getschoolcode + "' and Roleid=77 and Active=1 ";
                                break;

                            default:

                                break;
                        }
                        Dstech = cc.ExecuteDataset(Sql);
                        if (Dstech.Tables[0].Rows.Count > 0)
                        {
                            int totalsms = Dstech.Tables[0].Rows.Count;
                            string Mgs = "Dear sir/Madam Total " + totalsms + " message sent successfully www.udisecce.myct.in & www.myct.in ";
                            int leg = Mgs.Length;
                            cc.TransactionalSMSCountry("UDISE", MobileNo, Mgs, leg, 15);

                            for (int i = 0; i < Dstech.Tables[0].Rows.Count; i++)
                            {
                                string SetMobileno = "";
                                SetMobileno = Convert.ToString(Dstech.Tables[0].Rows[i]["usrMobileNo"]);
                                if (SetMobileno != "" || SetMobileno != null)
                                {
                                    string Message = SplitMsg[1].ToString() + cc.AddSMS(SetMobileno);
                                    smslength = Message.Length;
                                    cc.TransactionalSMSCountry(MobileNo, SetMobileno, Message, smslength, 15);

                                    string Sql1 = "Insert Into UDISE_SendSMSReport(SendFrom ,SendTo,sentMessage,smslength,sendercode,EntryDate)" +
                                                "values('" + MobileNo + "','" + SetMobileno + "','" + Message + "','" + smslength + "',15,'" + CurrenctDate + "')";
                                    int k = cc.ExecuteNonQuery(Sql1);
                                    if (k == 1)
                                    {
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion HMSendMessageToClassTeachar

    //--------------------------------------------------Adding Booth Leader and Keyword-------------------------------------------------------------------
    //Leader...Booth....

    #region BoothLeader
    public void AddLeaderBooth()//Leader*9422325020*murlidhar bhutada
    {
        try
        {
            string Sql = "Insert into Booth_AllMessage (Message,mobile,Keword,Date) " +
                         " values('" + Attendence + "','" + MobileNo + "','LEADER','" + Convert.ToString(CurrenctDate) + "')";
            int k = cc.ExecuteNonQuery(Sql);
            if (k > 0)
            {
                string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
                string getuserID = cc.ExecuteScalar(sqlget);
                if (getuserID == "" || getuserID == null)
                {
                    Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                                         " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    sqlget = "Select Roleid from AdminSubMarketingSubUser where Active=1 and mainrole=1 and friendid='" + getuserID + "'";
                    string Roleid = Convert.ToString(cc.ExecuteScalar(sqlget));
                    if (Roleid == "" || Roleid == null)
                    {
                        Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                       " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);
                    }
                    else
                    {
                        string LeaderMobile = SplitMsg[1].ToString();
                        string[] FullName = SplitMsg[2].Split(' ');
                        fname = FullName[0].ToString();
                        lname = FullName[1].ToString();

                        string SQL = "select UserMaster.usrMobileNo from AdminSubMarketingSubUser inner join UserMaster on AdminSubMarketingSubUser.userid=UserMaster.usrUserId " +
                                     " where AdminSubMarketingSubUser.friendid='" + getuserID + "' and active=1 and mainrole=1";
                        string LLeadermobileNo = cc.ExecuteScalar(SQL);

                        if (LeaderMobile.Length == 10)
                        {
                            if (LLeadermobileNo != "" || LLeadermobileNo != null)
                            {
                                if (Roleid == "82")
                                {
                                    AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 82);  //Constituency Admin

                                }
                                else if (Roleid == "83")
                                {
                                    AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 83);  //Zone incharge

                                }
                                else if (Roleid == "84")
                                {
                                    AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 84);  //City/village incharge

                                }
                                else if (Roleid == "85")
                                {
                                    AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 85);  //Area incharge

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                      " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }
    #endregion BoothLeader

    #region Boothkeyword
    //Attendence MobileNo
    public void Booth()
    {
        try
        {
            string Sql = "Insert into Booth_AllMessage (Message,mobile,Keword,Date) " +
                        " values('" + Attendence + "','" + MobileNo + "','BOOTH','" + Convert.ToString(CurrenctDate) + "')";
            int k = cc.ExecuteNonQuery(Sql);

            string BoothKeyword = Convert.ToString(SplitMsg[0]).ToUpper();
            string BoothNo = SplitMsg[1].ToString();
            string vote = Convert.ToString(SplitMsg[2]).ToUpper();

            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID == "" || getuserID == null)
            {
                Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                             " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
            else
            {
                sqlget = "Select Roleid from AdminSubMarketingSubUser where Active=1 and mainrole=1 and friendid='" + getuserID + "'";
                string Roleid = Convert.ToString(cc.ExecuteScalar(sqlget));
                if (Roleid == "" || Roleid == null)
                {
                    Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                   " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    if (Roleid == "86" || Roleid == "85" || Roleid == "84" || Roleid == "83" || Roleid == "82")
                    {
                        if (BoothKeyword.ToUpper() == "BOOTH" && vote == "VOTE")
                        {
                            Sql = "Insert into Booth_AllMessage (BoothNo,Message,mobile,Keword,Date) " +
                                        " values('" + BoothNo + "','" + Attendence + "','" + MobileNo + "','" + BoothKeyword.ToUpper() + "','" + Convert.ToString(CurrenctDate) + "')";
                            int k1 = cc.ExecuteNonQuery(Sql);
                            if (k1 > 0)
                            {
                                // SendBoothDetails.VoterDetails(MobileNo, Attendence);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                 " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }
    #endregion Boothkeyword

    #region ReplaceBoothMem
    //public void ReplaceBoothMem()//Replace*9422325020*984567866*ketan shinde
    //{
    //    try
    //    {
    //        string LLeadermobileNo = SplitMsg[1].ToString();
    //        string LeaderMobile = SplitMsg[2].ToString();
    //        string[] FullName = SplitMsg[3].Split(' ');
    //        fname = FullName[0].ToString();
    //        lname = FullName[1].ToString();

    //        string sqlget = "select usrUserid from usermaster where usrMobileNo='" + LLeadermobileNo + "'";
    //        string getuserID = cc.ExecuteScalar(sqlget);
    //        if (getuserID == "" || getuserID == null)
    //        {
    //            // UserRegistration();
    //        }
    //        else
    //        {
    //            sqlget = "Select Roleid from AdminSubMarketingSubUser where Active=1 and mainrole=1 and friendid='" + getuserID + "'";
    //            string Roleid = Convert.ToString(cc.ExecuteScalar(sqlget));
    //            if (Roleid == "" || Roleid == null)
    //            { }
    //            else
    //            {
    //                if (LLeadermobileNo != "" || LLeadermobileNo != null)
    //                {
    //                    if (Roleid == "82")
    //                    {
    //                        AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 82);  //For EO
    //                    }
    //                    else if (Roleid == "83")
    //                    {
    //                        AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 83);  //For EO
    //                    }
    //                    else if (Roleid == "84")
    //                    {
    //                        AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 84);  //For EO
    //                    }
    //                    else if (Roleid == "85")
    //                    {
    //                        AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 85);  //For EO
    //                    }
    //                    else if (Roleid == "86")
    //                    {
    //                        AddSubUser_EO1(LeaderMobile, fname, lname, MobileNo, LLeadermobileNo, 85);  //For EO
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    #endregion ReplaceBoothMem

    //--------------------------------------------------Ezee Apartment Mobile Apps and Registration Code and EzeeDrugApp----------------------------------

    #region Apart_RegEzeeDevice
    public void Apart_RegEzeeDevice()
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID == "" || getuserID == null)
            {
                UserRegistration();
                //eZeeMemberApp13.0*Name: m s bhutada*Purpose: Personal*PartyName: abhinav apartment*MobNo: 9422325020*ImeiNo: 356150056818332*SimNo: 89916645153774751027*PassCode: 1234567
            }
            else
            {
                string[] FullName = SplitMsg[1].Split(':');
                string FULLName = Convert.ToString(FullName[1].Trim());
                string[] PartyName = SplitMsg[3].Split(':');
                string Apartment = Convert.ToString(PartyName[1].Trim());
                string[] Purpose = SplitMsg[2].Split(':');
                string ApartPurpose = Convert.ToString(Purpose[1].Trim());
                string[] MobNo = SplitMsg[4].Split(':');
                string MemMobileNo = Convert.ToString(MobNo[1].Trim());
                string[] ImeiNo = SplitMsg[5].Split(':');
                string IMEINo = Convert.ToString(ImeiNo[1].Trim());
                string[] SimNo = SplitMsg[6].Split(':');
                string SIMNo = Convert.ToString(SimNo[1].Trim());
                string[] PASSCode = SplitMsg[7].Split(':');
                string PassCode = Convert.ToString(PASSCode[1].Trim());

                string Sqlchk = "Select EzeeApp_Id from Apart_RegEzeeDevice where  IMEINo='" + IMEINo + "' and Active=1";
                string chkEzeeAppId = Convert.ToString(cc.ExecuteScalar(Sqlchk));
                if (chkEzeeAppId == "" || chkEzeeAppId == null)
                {
                    string Sql = "Insert Into Apart_RegEzeeDevice(IMEINo,SIMNo,MyctUserId,MemberName,AppMobileNo,Purpose,RefMobileNo,PartyName,PassCode,KeyVersion,Active,RegDate)" +
                                 "Values('" + IMEINo + "','" + SIMNo + "','" + getuserID + "','" + FULLName + "','" + MobileNo + "'," + ApartPurpose + ",'" + MemMobileNo + "','" + Apartment + "','" + PassCode + "','" + SplitMsg[0] + "',1,'" + Convert.ToString(CurrenctDate) + "')";
                    int i = cc.ExecuteNonQuery(Sql);
                    if (i == 1)
                    {

                    }
                }
                else
                {
                    string Sql = "Update Apart_RegEzeeDevice set SIMNo='" + SIMNo + "',MyctUserId='" + getuserID + "',MemberName='" + FULLName + "',AppMobileNo='" + MobileNo + "',Purpose=" + ApartPurpose + ",RefMobileNo='" + MemMobileNo + "',PartyName='" + Apartment + "',PassCode='" + PassCode + "',KeyVersion='" + SplitMsg[0] + "',RegDate='" + Convert.ToString(CurrenctDate) + "'" +
                        " where EzeeApp_Id=" + chkEzeeAppId + "";
                    int j = cc.ExecuteNonQuery(Sql);
                    if (j == 1)
                    {

                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion Apart_RegEzeeDevice

    #region ezeedrugs
    public void EzeeDrugs_RegDevice()
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID == "" || getuserID == null)
            {
                try
                {
                    string firstName = Convert.ToString(SplitMsg[3]);
                    string lastName = Convert.ToString(SplitMsg[4]);
                    string address = Convert.ToString(SplitMsg[7]);
                    string eMailId = Convert.ToString(SplitMsg[8]);
                    string pincode = Convert.ToString(SplitMsg[10]);
                    string userid = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    string pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword,usrAddress,usrEmailId,usrPIN)" +
                             " values('" + userid + "','" + firstName + "','" + lastName + "','" + MobileNo + "','" + pwd + "','" + address + "','" + eMailId + "','" + pincode + "')";
                    int ID = cc.ExecuteNonQuery(Sql);
                    if (ID == 1)
                    {
                        EzeeDrugs_RegDevice();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                string keyword = Convert.ToString(SplitMsg[0]);
                string strDevId = Convert.ToString(SplitMsg[1]);
                string strSimSerialNo = Convert.ToString(SplitMsg[2]);
                string firstName = Convert.ToString(SplitMsg[3]);
                string lastName = Convert.ToString(SplitMsg[4]);
                string firmName = Convert.ToString(SplitMsg[5]);
                string mobileNo = Convert.ToString(SplitMsg[6]);
                string address = Convert.ToString(SplitMsg[7]);
                string eMailId = Convert.ToString(SplitMsg[8]);
                string typeOfUse_Id = Convert.ToString(SplitMsg[9]);
                string pincode = Convert.ToString(SplitMsg[10]);
                string passcode = Convert.ToString(SplitMsg[11]);
                string latitude = Convert.ToString(SplitMsg[12]);
                string longitude = Convert.ToString(SplitMsg[13]);
                string state = Convert.ToString(SplitMsg[14]);
                string district = Convert.ToString(SplitMsg[15]);
                string userType = Convert.ToString(SplitMsg[16]);
                string LadlineNo = Convert.ToString(SplitMsg[17]);
                string Favorite = Convert.ToString(SplitMsg[18]);
                string Qualification = Convert.ToString(SplitMsg[19]);
                string Spatialization = Convert.ToString(SplitMsg[20]);
                string Village = Convert.ToString(SplitMsg[21]);


                string Sqlchk = "Select EzeeDrugAppId from EzeeDrugsAppDetail where  mobileNo='" + MobileNo + "' and strSimSerialNo='" + strSimSerialNo + "' and strDevId='" + strDevId + "' and keyword='" + keyword + "'";
                string chkEzeeAppId = Convert.ToString(cc.ExecuteScalar(Sqlchk));

                if (chkEzeeAppId == "" || chkEzeeAppId == null)
                {
                    string Sql = "Insert Into EzeeDrugsAppDetail(keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Qualification,LadlineNo,Favorite,Village,Spatialization)" +
                                 "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "'," + MobileNo + ",'" + address + "','" + eMailId + "','" +
                                 typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + mobileNo + "','" + state + "','" + district + "','" + userType + "','" + Qualification + "','" + LadlineNo + "','" + Favorite + "','" + Village + "','" + Spatialization + "')";
                    int i = cc.ExecuteNonQuery(Sql);
                    if (i == 1)
                    {
                        if (UpperKeword == "EZEEDRUG")
                        {
                            //drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                            drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, MobileNo, eMailId, typeOfUse_Id, pincode, mobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
                            //drugmyct.FirmRegistration(strSimSerialNo, firmName, firstName, lastName, MobileNo, eMailId, typeOfUse_Id, pincode, mobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                        }
                        else if (UpperKeword == "EZEECLASS")
                        {
                            OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, MobileNo, eMailId, address, pincode, mobileNo);
                        }
                        else if (UpperKeword == "EZEESCHOOLAPP")
                        {
                            string FullName = firstName + " " + lastName;
                            scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, MobileNo, getuserID);
                        }
                    }
                }
                else
                {
                    string Sql = "Update EzeeDrugsAppDetail set firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id=" +
                        typeOfUse_Id + ",pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" +
                        getuserID + "',RefMobileNo='" + mobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Qualification = '" + Qualification + "',LadlineNo = '" + LadlineNo + "',Favorite = '" + Favorite + "',Village = '" + Village + "',Spatialization= '" + Spatialization + "' where  EzeeDrugAppId=" + chkEzeeAppId + "";
                    int i = cc.ExecuteNonQuery(Sql);
                    if (i == 1)
                    {
                        if (UpperKeword == "EZEEDRUG")
                        {
                            // drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                            drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, MobileNo, eMailId, typeOfUse_Id, pincode, mobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
                            //drugmyct.FirmRegistration(strSimSerialNo, firmName, firstName, lastName, MobileNo, eMailId, typeOfUse_Id, pincode, mobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                        }
                        else if (UpperKeword == "EZEECLASS")
                        {
                            OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, MobileNo, eMailId, address, pincode, mobileNo);
                        }
                        else if (UpperKeword == "EZEESCHOOLAPP")
                        {
                            string FullName = firstName + " " + lastName;
                            scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, MobileNo, getuserID);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion ezeedrugs

    #region UserRegistration
    public void UserRegistration()
    {
        try
        {
            string[] FullName = SplitMsg[1].Split(':');
            string FULLName = Convert.ToString(FullName[1].Trim());

            string userid = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            string pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword)" +
                     " values('" + userid + "','" + FULLName + "','" + lname + "','" + MobileNo + "','" + pwd + "')";
            int ID = cc.ExecuteNonQuery(Sql);
            if (ID == 1)
            {
                Apart_RegEzeeDevice();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion UserRegistration

    //--------------------------------------------------------------- Student Attendence -----------------------------------------------------------------

    #region Udise_StudentAttendance
    public void Udise_StudentAttendance()
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' or userid='" + getuserID + "' and Active=1 and mainrole=1 ";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "" || GetRoleID == null)
                {
                    // Hm/texcaher not define
                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {

                    // if (GetRoleID == "41" || GetRoleID == "42" || GetRoleID == "76" || GetRoleID == "77")//76 is HM and 77 is Class Teacher checkfrnd == "41" || checkfrnd == "40" ||
                    if (GetRoleID == "76" || GetRoleID == "77")
                    {
                        string checkschoolcode = "select sm.SchoolCode from UDISE_SchoolMaster as sm inner join UDISE_TeacherMaster as Tm on Tm.SchoolCode=sm.SchoolCode  where Tm.junior_id='" + getuserID + "' and Tm.Class='" + SplitMsg[1].Trim() + "' and  Tm.Section='" + SplitMsg[2].Trim() + "' and Tm.Active=1";
                        string Getschoolcode = cc.ExecuteScalar(checkschoolcode);
                        if (Getschoolcode == "" || Getschoolcode == null)
                        {
                            //get teacher/Hm Not define School 
                            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                   " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                            int b = cc.ExecuteNonQuery(Sql);
                        }
                        else
                        {
                            string GetDate = "Select EntryDate from UDISE_StudentPresenty where EntryDate='" + Convert.ToString(CurrenctDate) + "' and Class='" + SplitMsg[1].Trim() + "' and Division='" + SplitMsg[2].Trim() + "' and SchoolCode='" + Getschoolcode + "'";
                            string FindDate = Convert.ToString(cc.ExecuteScalar(GetDate));
                            if (FindDate == "" || FindDate == null)
                            {

                                string AddStudPre = "insert into UDISE_StudentPresenty(usrUserId,Keyword,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls,Present_B,Present_G,Created)" +
                                      "values('" + getuserID + "','" + UpperKeword + "','" + Getschoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + SplitMsg[1].Trim() + "','" + SplitMsg[2].Trim() + "','" + SplitMsg[4].Trim() + "','" + SplitMsg[6].Trim() + "','" + SplitMsg[8].Trim() + "','" + SplitMsg[10].Trim() + "','Myct')";
                                int a = cc.ExecuteNonQuery(AddStudPre);
                                if (a == 1)
                                {
                                    asp.UdiseAddstudRegister(getuserID, Getschoolcode, SplitMsg[1].Trim(), SplitMsg[2].Trim(), SplitMsg[4].Trim(), SplitMsg[6].Trim(), CurrenctDate);
                                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                " ('" + Attendence.Trim() + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','Y','" + p1 + "','" + p2 + "' )";
                                    int b = cc.ExecuteNonQuery(Sql);
                                }
                            }
                            else
                            {
                                string UpdateStudPre = "update UDISE_StudentPresenty set usrUserId='" + getuserID + "',Keyword='" + UpperKeword + "',SchoolCode='" + Getschoolcode + "',Class='" + SplitMsg[1].Trim() + "',Division='" + SplitMsg[2].Trim() + "',RegBoys='" +
                                    SplitMsg[4].Trim() + "',RegGirls='" + SplitMsg[6].Trim() + "',Present_B='" + SplitMsg[8].Trim() + "',Present_G='" + SplitMsg[10].Trim() + "' where EntryDate='" + Convert.ToString(CurrenctDate) + "' and SchoolCode='" + Getschoolcode + "' and Class='" + SplitMsg[1].Trim() + "' and Division='" + SplitMsg[2].Trim() + "'";
                                int a = cc.ExecuteNonQuery(UpdateStudPre);
                                if (a == 1)
                                {
                                    asp.UdiseAddstudRegister(getuserID, Getschoolcode, SplitMsg[1].Trim(), SplitMsg[2].Trim(), SplitMsg[4].Trim(), SplitMsg[6].Trim(), CurrenctDate);
                                }
                            }
                            string AllDiseMsg = " insert into UDISE_AllMessage(SchoolCode,Message,mobile,Keword,Date)" +
                               "values('" + Getschoolcode + "','" + Attendence.Trim() + "','" + MobileNo + "','" + UpperKeword + "','" + Convert.ToString(CurrenctDate) + "')";
                            int aa = cc.ExecuteNonQuery(AllDiseMsg);
                        }

                    }
                    else
                    {
                        //not assign techaer/hm role perticular user
                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                  " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);
                    }
                }
            }
            else
            {
                //not registered
                string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                             " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                      " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }

    }
    #endregion Udise_StudentAttendance

    #region Udise_StudentAttendanceCAR
    public void Udise_StudentAttendanceCAR()
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' and Roleid=76 and Active=1 and mainrole=1 ";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "" || GetRoleID == null)
                {
                    // Hm/texcaher not define
                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    // if (GetRoleID == "41" || GetRoleID == "42" || GetRoleID == "76" || GetRoleID == "77")//76 is HM and 77 is Class Teacher checkfrnd == "41" || checkfrnd == "40" ||
                    if (GetRoleID == "76")
                    {
                        string checkschoolcode = "select sm.SchoolCode from UDISE_SchoolMaster as sm inner join UDISE_TeacherMaster as Tm on Tm.SchoolCode=sm.SchoolCode  where Tm.junior_id='" + getuserID + "' and Tm.Active=1";
                        string Getschoolcode = cc.ExecuteScalar(checkschoolcode);
                        if (Getschoolcode == "" || Getschoolcode == null)
                        {
                            //get teacher/Hm Not define School 
                            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                   " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                            int b = cc.ExecuteNonQuery(Sql);
                        }
                        else
                        {
                            //-----------------------------------------
                            string[] WholeMgs = removeDotinSMSBody.Split('#');

                            for (int k = 0; k < WholeMgs.Length; k++)
                            {
                                Attendence = WholeMgs[k];
                                SplitMsg = Attendence.Split('*');
                                getKeyword = Convert.ToString(SplitMsg[0]);
                                UpperKeword = getKeyword.ToUpper();

                                string GetDate = "Select EntryDate from UDISE_StudentPresenty where EntryDate='" + Convert.ToString(CurrenctDate) + "' and Class='" + SplitMsg[1].Trim() + "' and Division='" + SplitMsg[2].Trim() + "' and SchoolCode='" + Getschoolcode + "'";
                                string FindDate = Convert.ToString(cc.ExecuteScalar(GetDate));
                                if (FindDate == "" || FindDate == null)
                                {

                                    string AddStudPre = "insert into UDISE_StudentPresenty(usrUserId,Keyword,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls,Present_B,Present_G,Created)" +
                                          "values('" + getuserID + "','" + UpperKeword + "','" + Getschoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + SplitMsg[1].Trim() + "','" + SplitMsg[2].Trim() + "','" + SplitMsg[4].Trim() + "','" + SplitMsg[6].Trim() + "','" + SplitMsg[8].Trim() + "','" + SplitMsg[10].Trim() + "','Myct')";
                                    int a = cc.ExecuteNonQuery(AddStudPre);
                                    if (a == 1)
                                    {
                                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                    " ('" + Attendence.Trim() + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','Y','" + p1 + "','" + p2 + "' )";
                                        int b = cc.ExecuteNonQuery(Sql);
                                    }
                                }
                                else
                                {
                                    string UpdateStudPre = "update UDISE_StudentPresenty set usrUserId='" + getuserID + "',Keyword='" + UpperKeword + "',SchoolCode='" + Getschoolcode + "',Class='" + SplitMsg[1].Trim() + "',Division='" + SplitMsg[2].Trim() + "',RegBoys='" +
                                        SplitMsg[4].Trim() + "',RegGirls='" + SplitMsg[6].Trim() + "',Present_B='" + SplitMsg[8].Trim() + "',Present_G='" + SplitMsg[10].Trim() + "' where EntryDate='" + Convert.ToString(CurrenctDate) + "' and SchoolCode='" + Getschoolcode + "' and Class='" + SplitMsg[1].Trim() + "' and Division='" + SplitMsg[2].Trim() + "'";
                                    int a = cc.ExecuteNonQuery(UpdateStudPre);
                                    if (a == 1)
                                    {
                                    }
                                }
                                string AllDiseMsg = " insert into UDISE_AllMessage(SchoolCode,Message,mobile,Keword,Date)" +
                                   "values('" + Getschoolcode + "','" + Attendence.Trim() + "','" + MobileNo + "','" + UpperKeword + "','" + Convert.ToString(CurrenctDate) + "')";
                                int aa = cc.ExecuteNonQuery(AllDiseMsg);
                            }
                        }

                    }
                    else
                    {
                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                  " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);
                    }
                }
            }
            else
            {
                //not registered
                string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                             " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                      " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }

    }
    #endregion Udise_StudentAttendanceCAR

    //--------------------------------------------------------------Staff Atendence-----------------------------------------------------------------------

    #region Udise_TeacherAttendance
    public void Udise_TeacherAttendance()
    {

        try
        {
            //7/24/2013 2:59:39 PM Send SMS format server
            //DateTime dt = DateTime.Now; // get current date
            //double d = 5; //add hours in time
            //double m = 48; //add min in time
            //DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
            //SystemDate = SystemDate.AddMinutes(m);
            //CurrenctDate = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");

            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' or userid='" + getuserID + "' and Active=1 and mainrole=1";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "" || GetRoleID == null)
                {
                    // Hm/texcaher not define
                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    if (GetRoleID == "76")//76 is HM 
                    {
                        string checkschoolcode = "select sm.SchoolCode from UDISE_SchoolMaster as sm inner join UDISE_TeacherMaster as Tm on Tm.SchoolCode=sm.SchoolCode  where junior_id='" + getuserID + "' and Tm.Class='' and  Tm.Section='' and Tm.Active=1";
                        string Getschoolcode = cc.ExecuteScalar(checkschoolcode);
                        if (Getschoolcode == "" || Getschoolcode == null)
                        {
                            //get teacher/Hm Not define School 
                            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                   " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                            int b = cc.ExecuteNonQuery(Sql);
                        }
                        else
                        {
                            string GetDate = "Select EntryDate from UDISE_TeacherPresenty where EntryDate='" + Convert.ToString(CurrenctDate) + "' and SchoolCode='" + Getschoolcode + "'";
                            string FindDate = Convert.ToString(cc.ExecuteScalar(GetDate));
                            if (FindDate == "" || FindDate == null)
                            {

                                string AddStudPre = "insert into UDISE_TeacherPresenty(usrUserId,Keyword,SchoolCode,EntryDate,RegMale,RegFemale,Present_M,Present_F,Created)" +
                                       "values('" + getuserID + "','" + UpperKeword + "','" + Getschoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + SplitMsg[2].Trim() + "','" + SplitMsg[4].Trim() + "','" + SplitMsg[6].Trim() + "','" + SplitMsg[8].Trim() + "','Myct')";


                                //"values('" + getuserID + "','" + UpperKeword + "','" + Getschoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + SplitMsg[1] + "','" + SplitMsg[2] + "','" + SplitMsg[4] + "','" + SplitMsg[6] + "','" + SplitMsg[8] + "','" + SplitMsg[10] + "','Myct')";
                                int a = cc.ExecuteNonQuery(AddStudPre);
                                if (a == 1)
                                {

                                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                 " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','Y','" + p1 + "','" + p2 + "' )";
                                    int b = cc.ExecuteNonQuery(Sql);
                                }
                            }
                            else
                            {
                                string UpdateStudPre = "update  UDISE_TeacherPresenty set Keyword='" + UpperKeword + "',RegMale='" + SplitMsg[2].Trim() + "',RegFemale='" + SplitMsg[4].Trim() + "',Present_M='" +
                                    SplitMsg[6].Trim() + "',Present_F='" + SplitMsg[8].Trim() + "' where SchoolCode='" + Getschoolcode + "' and usrUserId='" + getuserID + "' and EntryDate='" + Convert.ToString(CurrenctDate) + "'";

                                int a = cc.ExecuteNonQuery(UpdateStudPre);
                                //    if (a == 1)
                                //    {

                                //        string Sql = " Insert into test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                //                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','Y','" + p1 + "','" + p2 + "' )";
                                //        int b = cc.ExecuteNonQuery(Sql);
                                //    }
                            }
                            string AllDiseMsg = " insert into UDISE_AllMessage(SchoolCode,Message,mobile,Keword,Date)" +
                               "values('" + Getschoolcode + "','" + Attendence + "','" + MobileNo + "','" + UpperKeword + "','" + Convert.ToString(CurrenctDate) + "')";
                            int aa = cc.ExecuteNonQuery(AllDiseMsg);
                        }
                    }
                    else
                    {
                        //not assign techaer/hm role perticular user
                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                  " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);
                    }
                }
            }
            else
            {
                //not registered
                string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                             " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                      " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }
    #endregion Udise_TeacherAttendance

    //--------------------------------------------------------------Add Teachar---------------------------------------------------------------------------

    #region Udise_AddTeachar
    public void Udise_AddTeachar()
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);

            if (getuserID == "" || getuserID == null)
            {
                // not register
                string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                             " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
            else
            {
                string ChkUserIdAdmin = "Select AdminSubMarketingSubUser.friendid from AdminSubMarketingSubUser where AdminSubMarketingSubUser.roleid=76 " +
                                        "and AdminSubMarketingSubUser.friendid='" + getuserID + "' and Active=1 and mainrole=1 ";
                string FindUserId = Convert.ToString(cc.ExecuteScalar(ChkUserIdAdmin));
                if (FindUserId == "" || FindUserId == null)
                {
                    //Check role are already exit
                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    string FindSchoolCode = " Select distinct(SchoolCode) from [UDISE_TeacherMaster] inner join dbo.AdminSubMarketingSubUser " +
                                            "on AdminSubMarketingSubUser.friendid=[UDISE_TeacherMaster].junior_id " +
                                            "where AdminSubMarketingSubUser.roleid=76 and AdminSubMarketingSubUser.Active=1 and AdminSubMarketingSubUser.mainrole=1 and  [UDISE_TeacherMaster].junior_id='" + getuserID + "'";
                    string SchoolCodeChk = cc.ExecuteScalar(FindSchoolCode);
                    if (SchoolCodeChk == "" || SchoolCodeChk == null)
                    {
                        // not school Code
                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                  " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);
                    }
                    else
                    {
                        string TechMobileNo = Convert.ToString(SplitMsg[1]);
                        string FullName = Convert.ToString(SplitMsg[2]);
                        usrclass = Convert.ToString(SplitMsg[3]);
                        section = Convert.ToString(SplitMsg[4]);

                        string[] Name = FullName.Split(' ');
                        fname = Convert.ToString(Name[0]);
                        lname = Convert.ToString(Name[1]);
                        schoolcode = Convert.ToString(SchoolCodeChk);
                        string Hm_usrID = Convert.ToString(getuserID);

                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                     " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);

                        string SQL = "select usrmobileno from UserMaster " +
                                     " inner join AdminSubMarketingSubUser on AdminSubMarketingSubUser.friendid=UserMaster.usrUserId " +
                                     " where AdminSubMarketingSubUser.friendid in (   " +
                                     " select userid from AdminSubMarketingSubUser inner join UserMaster on AdminSubMarketingSubUser.friendid=UserMaster.usrUserId " +
                                     " where UserMaster.usrMobileNo='" + HM_MobileNo + "' and active=1 and mainrole=1)  ";
                        string LLeadermobileNo = cc.ExecuteScalar(SQL);

                        if (LLeadermobileNo != "")
                        {
                            AddSubUser_EO1(TechMobileNo, fname, lname, HM_MobileNo, LLeadermobileNo, 76);//For Teacher
                        }

                        //  AddSubUser_EO1(TechMobileNo, fname, lname, HM_MobileNo);//For Teacher
                        // AddTech.AddSubUser(TechMobileNo, FristName, LastName, schoolcode, TechClass, TechSection, getuserID);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                     " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }
    #endregion Udise_AddTeachar

    //-----------------------------------Create Hirarchy--------------------------------------------------------------------------------------------------

    #region CreateHirarchy
    public void AddSubUser_EO1(string EO_Mob, string Fname, string Lname, string leaderno, string LeaderLeaderNo, int LeaderRoleNo)
    {

        urUserRegBLLObj.Customermobileno = EO_Mob;
        fname = Fname;
        lname = Lname;
        status = urUserRegBLLObj.BLLSearchUserExist(urUserRegBLLObj); // Check Mobile register  or Not
        if (status > 0)
        {
            AddNewUser1(EO_Mob, leaderno, LeaderLeaderNo, LeaderRoleNo);

        }
        else
        {
            int Status = Addnew(Fname, Lname, EO_Mob);
            if (Status == 1)
            {
                AddSubUser_EO1(EO_Mob, Fname, Lname, leaderno, LeaderLeaderNo, LeaderRoleNo);
            }
        }

    }

    public int Addnew(string fname, string lname, string mobileno)
    {
        try
        {
            string userid = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            string pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword)" +
                     " values('" + userid + "','" + fname + "','" + lname + "','" + mobileno + "','" + pwd + "')";
            int ID = cc.ExecuteNonQuery(Sql);

            return ID;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void AddNewUser1(string JuniorNo, string leader_no, string LeaderLeaderNo, int LeaderRoleNo)
    {
        try
        {
            LeaderNo = leader_no; // use for common All code
            string getuserID_Leader = "select usrUserid from usermaster where usrMobileNo='" + LeaderNo + "'";
            Leader_UserID = cc.ExecuteScalar(getuserID_Leader); // get Leader usruserID
            string LeaderNo_usrID = Leader_UserID;// get Leader usruserID
            if (Leader_UserID == "Admin")
            {
                string sql = "select MobileNo from Marketinguser1 where UserId='" + UserName + "'";
                string mobileno = cc.ExecuteScalar(sql);
                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                Leader_UserID = cc.ExecuteScalar(sql1);
            }
            else
            {
                string LLeaderID = "select usruserid , Roleid from usermaster inner join AdminSubMarketingSubUser on UserMaster.usrUserId=AdminSubMarketingSubUser.userid where usrMobileNo='" + LeaderLeaderNo + "' and Roleid=" + LeaderRoleNo + " and Friendid='" + LeaderNo_usrID + "'";
                DataSet ds1 = cc.ExecuteDataset(LLeaderID); // get juniour RoleID & Role Name
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    LLeaderNo_usrID = Convert.ToString(ds1.Tables[0].Rows[0]["usruserid"]);
                    LeaderRoleId = Convert.ToString(ds1.Tables[0].Rows[0]["Roleid"]);
                }

                info13();
            }
            string JusrID = "select usruserid from usermaster where usrMobileNo='" + JuniorNo + "'";
            string JuniorNo_usrID = cc.ExecuteScalar(JusrID); // get juniour usrUserID
            string date_ofJoin = "", JuniorRoleID = "", JuniorRoleName = "", reference_id1 = "";
            date_ofJoin = DateTime.Now.Date.ToString(); // get current date
            reference_id1 = initialreference; // add Administrator reference 

            string GetJRoleID = "select Roleid ,RoleName from SubMenuPermission where UnderRole='" + Leader_RoleID + "'";
            DataSet ds = cc.ExecuteDataset(GetJRoleID); // get juniour RoleID & Role Name
            if (ds.Tables[0].Rows.Count > 0)
            {
                JuniorRoleID = Convert.ToString(ds.Tables[0].Rows[0]["Roleid"]);
                JuniorRoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            }
            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and roleid='" + JuniorRoleID + "' and userid='" + Leader_UserID + "' ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                if (JuniorRoleID == "77")
                {

                    string sql = "select SchoolId from UDISE_SchoolMaster  inner join UDISE_TeacherMaster on UDISE_TeacherMaster.SchoolCode=UDISE_SchoolMaster.SchoolCode   where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' and UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' ";
                    string id = cc.ExecuteScalar(sql);// check Hm Registered Or Not
                    if (id == "" || id == null)
                    {
                        string Management = "", SchoolType = "", Classes = "";
                        string sql1 = "select SchoolId from UDISE_SchoolMaster  where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' ";
                        int Data1 = 0;
                        Data1 = cc.ExecuteScalar1(sql1); // check school code registered or not.
                        if (Data1 != null && Data1 <= 1)
                        {
                            sql = "insert into UDISE_SchoolMaster(SchoolCode,SchoolName,Management,SchoolType,Classes) values('" + schoolcode + "','" + schoolName + "','" + Management + "','" + SchoolType + "','" + Classes + "')";
                            int a1 = cc.ExecuteNonQuery(sql);// insert new school code
                        }

                        udise_addsub.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                        sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(HM_MobileNo) + "' ,Ref_Ways='ASCIIPage' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                        int ad = cc.ExecuteNonQuery(sql);

                    }
                    else
                    {

                        udise_addsub.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                        sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(HM_MobileNo) + "' ,Ref_Ways='ASCIIPage' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                        int ad = cc.ExecuteNonQuery(sql);
                    }
                }
                else
                {
                }
            }
            else
            {
                string SqlChkActive = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and Active=1 and Mainrole=1";
                string ChkActive = cc.ExecuteScalar(SqlChkActive); // check juniour already assign
                if (ChkActive == "" || ChkActive == null)
                {

                    string SqlChkActiveRole = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and roleid='" + JuniorRoleID + "'";
                    string ChkActiveRole = cc.ExecuteScalar(SqlChkActiveRole); // check juniour already assign
                    if (ChkActive == "" || ChkActive == null)
                    {
                        string AddJunior = "update AdminSubMarketingSubUser set Mainrole=0 where friendid='" + JuniorNo_usrID + "' ";
                        int Data1 = 0;
                        Data1 = cc.ExecuteNonQuery(AddJunior); // check school code registered or not.
                        if (Data1 >= 1)
                        {
                            Replacereference(JuniorRoleID, JuniorNo_usrID, reference_id1, Leader_UserID); // chnage reference 
                        }
                        string Junior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Mainrole)" +
                                    " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','ASCIIPage','1','1' )";
                        string exe = cc.ExecuteScalar(Junior); // Add Juniour  Under his Leader

                    }
                    else
                    {
                        string AddJunior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Mainrole)" +
                                        " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','ASCIIPage','0' ,'0')";
                        string exe = cc.ExecuteScalar(AddJunior); // Add Juniour  Under his Leader
                    }
                }
                else
                {
                    string AddJunior = "update AdminSubMarketingSubUser set Mainrole=0 where friendid='" + JuniorNo_usrID + "' ";
                    int Data1 = 0;
                    Data1 = cc.ExecuteNonQuery(AddJunior); // check school code registered or not.
                    if (Data1 >= 1)
                    {
                        Replacereference(JuniorRoleID, JuniorNo_usrID, reference_id1, Leader_UserID); // chnage reference 
                    }
                    string Junior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Mainrole)" +
                                       " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','ASCIIPage','1','1' )";
                    string exe = cc.ExecuteScalar(Junior); // Add Juniour  Under his Leader

                }
                string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + JuniorNo_usrID + "'";
                string a = cc.ExecuteScalar(sqlupdate); // allow permission is Marketing person i.e allow go to admin side.

                string query = "select id from TreeDemo where userid='" + Leader_UserID + "' and Roleid=" + LeaderRoleId + "";
                string CheckTree = cc.ExecuteScalar(query); // Get leader ID already add in tree digrame
                if (!(CheckTree == null || CheckTree == ""))
                {
                    LeaderRoleId = "";
                    // string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' and id=" + CheckTree + " ";
                    string check_Available = "select parentid from TreeDemo where userid='" + JuniorNo_usrID + "' and Roleid=" + JuniorRoleID + "";

                    string GetID = cc.ExecuteScalar(check_Available); // check leader ID & Juniour Is already define or Not
                    if (!(GetID == null || GetID == ""))
                    {
                        if (CheckTree == GetID)
                        {
                            //Not 
                        }
                        else
                        {
                            string Addtree = "insert into TreeDemo(userid,parentid,RoleId)values('" + JuniorNo_usrID + "','" + CheckTree + "'," + JuniorRoleID + ")";
                            string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                        }
                    }
                    else
                    {
                        string Addtree = "insert into TreeDemo(userid,parentid,RoleId)values('" + JuniorNo_usrID + "','" + CheckTree + "'," + JuniorRoleID + ")";
                        string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                    }
                }
                else
                {

                    // if leader not add in tree diagram
                    //string Addtree = "insert into TreeDemo(userid,parentid)values('" + Leader_UserID + "','" + CheckTree + "')";
                    //string b = cc.ExecuteScalar(Addtree);


                }

            }
            // if (JuniorRoleID == "15" || JuniorRoleID == "16" || JuniorRoleID == "17" || JuniorRoleID == "18" || JuniorRoleID == "19" || JuniorRoleID == "20" || JuniorRoleID == "21" || JuniorRoleID == "75" || JuniorRoleID == "76")
            if (JuniorRoleID == "77")
            {

                string sql = "select SchoolId from UDISE_SchoolMaster  inner join UDISE_TeacherMaster on UDISE_TeacherMaster.SchoolCode=UDISE_SchoolMaster.SchoolCode   where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' and UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' ";
                string id = cc.ExecuteScalar(sql);// check Hm Registered Or Not
                if (id == "" || id == null)
                {
                    string Management = "", SchoolType = "", Classes = "";
                    string sql1 = "select SchoolId from UDISE_SchoolMaster  where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' ";
                    int Data1 = 0;
                    Data1 = cc.ExecuteScalar1(sql1); // check school code registered or not.
                    if (Data1 != null && Data1 <= 1)
                    {
                        sql = "insert into UDISE_SchoolMaster(SchoolCode,SchoolName,Management,SchoolType,Classes) values('" + schoolcode + "','" + schoolName + "','" + Management + "','" + SchoolType + "','" + Classes + "')";
                        int a1 = cc.ExecuteNonQuery(sql);// insert new school code
                    }

                    udise_addsub.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                    sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(HM_MobileNo) + "' ,Ref_Ways='ASCIIPage' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                    int ad = cc.ExecuteNonQuery(sql);

                }
                else
                {

                    udise_addsub.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                    sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(HM_MobileNo) + "' ,Ref_Ways='ASCIIPage' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                    int ad = cc.ExecuteNonQuery(sql);
                }

            }
            else
            {


            }
        }
        catch (Exception ex)
        {


        }

    }

    public void Replacereference(string JuniorRoleID, string JuniorNo_usrID, string reference_id1, string Leader_UserID)
    {
        try
        {
            string cref = "";
            string Checkref = "";

            cref = "select userid from AdminSubMarketingSubUser where roleid=" + JuniorRoleID + " and   friendid ='" + JuniorNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and MainRole=0";
            Checkref = cc.ExecuteScalar(cref); // check juniour already assign
            if (!(Checkref == null || Checkref == ""))
            {

                string JJuniorRole_SQL = "select Roleid from SubMenuPermission  where UnderRole='" + JuniorRoleID + "' ";
                string JJuniorRoleID = cc.ExecuteScalar(JJuniorRole_SQL);// check Hm Registered Or Not

                if (Checkref != Leader_UserID)
                {
                    string qry = "";
                    if (reference_id2 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id1='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and   reference_id1='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);

                    }
                    if (reference_id3 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id2='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and   reference_id1='" + reference_id2 + "' and reference_id2='" + Checkref + "'and roleid='" + JJuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id4 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) "; // 75 


                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id5 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))))) "; // 76

                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id6 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in(select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in(select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) ";


                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id7 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  "; // 21
                        qry = qry + "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in(select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) ";

                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id8 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id7='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id7='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75
                        qry = qry + "update AdminSubMarketingSubUser set reference_id7='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76


                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id9 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id8='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'  and  reference_id8='" + Checkref + "'  and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + " update AdminSubMarketingSubUser set reference_id8='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'  and  reference_id8='" + Checkref + "'  and roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75

                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id10 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id9='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and reference_id9='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  "; //75
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id11 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id10='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST' where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "'  and reference_id10='" + Convert.ToString(Checkref) + "'  and roleid='" + JJuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void clearref()
    {
        reference_id10 = "";
        reference_id11 = "";
        reference_id2 = "";
        reference_id3 = "";
        reference_id4 = "";
        reference_id5 = "";
        reference_id6 = "";
        reference_id7 = "";
        reference_id8 = "";
        reference_id9 = "";
        Leader_RoleName = "";
        Leader_Leader = "";
        Leader_RoleID = "";
        // Leader_UserID = "";
        LLeaderNo_usrID = "";
        //LeaderRoleId = "";
    }

    private void info13()
    {
        try
        {


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + Leader_UserID + "' and userid='" + LLeaderNo_usrID + "' and Roleid='" + LeaderRoleId + "' and  active=1";

            DataSet ds1 = cc.ExecuteDataset(Getreference);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                clearref();
                Leader_RoleName = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
                Leader_Leader = Convert.ToString(ds1.Tables[0].Rows[0]["userid"]);
                Leader_RoleID = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
                Leader_UserID = Convert.ToString(ds1.Tables[0].Rows[0]["friendid"]);

                reference_id2 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id2"]);
                if (reference_id2 == "")
                {
                    reference_id2 = Leader_UserID;
                    break;
                }

                reference_id3 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id3"]);
                if (reference_id3 == "")
                {
                    reference_id3 = Leader_UserID;
                    break;
                }

                reference_id4 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id4"]);
                if (reference_id4 == "")
                {
                    reference_id4 = Leader_UserID;
                    break;
                }
                reference_id5 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id5"]);
                if (reference_id5 == "")
                {
                    reference_id5 = Leader_UserID;
                    break;
                }
                reference_id6 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id6"]);
                if (reference_id6 == "")
                {
                    reference_id6 = Leader_UserID;
                    break;
                }
                reference_id7 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id7"]);
                if (reference_id7 == "")
                {
                    reference_id7 = Leader_UserID;
                    break;
                }
                reference_id8 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id8"]);
                if (reference_id8 == "")
                {
                    reference_id8 = Leader_UserID;
                    break;
                }
                reference_id9 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id9"]);
                if (reference_id9 == "")
                {
                    reference_id9 = Leader_UserID;
                    break;
                }
                reference_id10 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id10"]);
                if (reference_id10 == "")
                {
                    reference_id10 = Leader_UserID;
                    break;
                }
                reference_id11 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id11"]);
                if (reference_id11 == "")
                {
                    reference_id11 = Leader_UserID;
                    break;
                }

            }

            initialreference = "6dde8c3d-1895-4904-b332-764f63206fc0";
        }
        catch (Exception ex)
        {
        }
    }
    #endregion CreateHirarchy

    //--------------------------------------------------------------- Change The MobileNo ----------------------------------------------------------------

    #region Udise_ChngMobNo
    public void Udise_ChngMobNo()
    {
        try
        {
            string KeywordUdise = Convert.ToString(SplitMsg[2]);
            if (KeywordUdise.ToUpper() == "UDISE")
            {
                string OldMobileNo = Convert.ToString(SplitMsg[1]);
                schoolcode = Convert.ToString(SplitMsg[3]);
                string sqlget = "select usrUserid from usermaster where usrMobileNo='" + OldMobileNo + "'";
                string getuserID = cc.ExecuteScalar(sqlget);
                if (getuserID == "" || getuserID == null)
                {
                    //Not Register
                }
                else
                {
                    string GetRoleId = "select roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' and Active=1 and mainrole=1";
                    string RoleId = cc.ExecuteScalar(GetRoleId);
                    //if (RoleId == "41" || RoleId == "42")
                    if (RoleId == "76" || RoleId == "77")
                    {
                        string NewMobile = "Select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
                        string NewMobileRead = (cc.ExecuteScalar(NewMobile));
                        if (NewMobileRead != "" || NewMobileRead != null)
                        { }
                        else
                        {
                            string UpdateMobileNo = "Update UserMaster set usrMobileNo='" + MobileNo + "' where usrUserId='" + getuserID + "' and usrMobileNo='" + OldMobileNo + "'";
                            int a = cc.ExecuteNonQuery(UpdateMobileNo);
                            if (a == 1)
                            {
                                string SqlData = "select usrPassword,usrFirstName,usrLastName,usrMobileNo from usermaster where usrMobileNo='" + MobileNo + "'";
                                DataSet ds = cc.ExecuteDataset(SqlData);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    string FName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                                    string LName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
                                    string Password = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));

                                    string passwordMessage = "Dear " + FName + " " + LName + ", Sir Your Password  is " + Password + " " + cc.AddSMS(MobileNo);
                                    int smslength = passwordMessage.Length;
                                    cc.SendMessageLongCodeSMS("ASCIIPage", MobileNo, passwordMessage, smslength);

                                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                            " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','N','" + p1 + "','" + p2 + "' )";
                                    int b = cc.ExecuteNonQuery(Sql);
                                }
                            }
                        }
                    }
                    else
                    {
                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);
                    }
                    string AllDiseMsg = " insert into UDISE_AllMessage(SchoolCode,Message,mobile,Keword,Date)" +
                               "values('" + schoolcode + "','" + Attendence + "','" + MobileNo + "','" + UpperKeword + "','" + Convert.ToString(CurrenctDate) + "')";
                    int aa = cc.ExecuteNonQuery(AllDiseMsg);
                }
            }
            else
            {
                string OldMobileNo = Convert.ToString(SplitMsg[1]);
                string NewMobileNo = Convert.ToString(SplitMsg[3]);
                string sqlget = "select usrUserid from usermaster where usrMobileNo='" + OldMobileNo + "'";
                string getuserID = cc.ExecuteScalar(sqlget);
                if (getuserID == "" || getuserID == null)
                {
                    //Not Register
                }
                else
                {
                    string NewMobilechk = "Select usrUserid from usermaster where usrMobileNo='" + NewMobileNo + "'";
                    string NewMobileRead = (cc.ExecuteScalar(NewMobilechk));
                    if (NewMobileRead != "" || NewMobileRead != null)
                    { }
                    else
                    {
                        string UpdateMobileNo = "Update UserMaster set usrMobileNo='" + NewMobileNo + "' where usrUserId='" + getuserID + "' and usrMobileNo='" + OldMobileNo + "'";
                        int a = cc.ExecuteNonQuery(UpdateMobileNo);
                        if (a == 1)
                        {
                            string SqlData = "select usrPassword,usrFirstName,usrLastName,usrMobileNo from usermaster where usrMobileNo='" + NewMobileNo + "'";
                            DataSet ds = cc.ExecuteDataset(SqlData);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string FName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                                string LName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
                                string Password = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));

                                string passwordMessage = "Dear " + FName + " " + LName + ", Sir Your Password  is " + Password + " " + cc.AddSMS(NewMobileNo);
                                int smslength = passwordMessage.Length;
                                cc.SendMessageLongCodeSMS("ASCIIPage", NewMobileNo, passwordMessage, smslength);

                                string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                        " ('" + Attendence + "','" + NewMobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','N','" + p1 + "','" + p2 + "' )";
                                int b = cc.ExecuteNonQuery(Sql);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                   " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }
    #endregion Udise_ChngMobNo

    //---------------------------------------------------------------Add Head Master And Cluster Head ----------------------------------------------------

    #region Udise_AddChHm
    public void Udise_AddChHm()
    {
        try
        {
            string KeyHmCh = "";
            KeyHmCh = Convert.ToString(SplitMsg[0]);
            if (KeyHmCh == "HM")
            {
                string HmMobileNo = Convert.ToString(SplitMsg[1]);
                string FullName = Convert.ToString(SplitMsg[2]);

                string[] Name = FullName.Split(' ');
                string FristName = Convert.ToString(Name[0]);
                string LastName = Convert.ToString(Name[1]);
                schoolcode = Convert.ToString(SplitMsg[3]);

                string SQl = "select U2.usrMobileNo as LeadermobileNo " +
                                        " from TreeDemo e2 " +
                                        " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                                        " join TreeDemo e3 on e2.id=e3.parentid " +
                                        " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                                        " where U3.usrMobileNo='" + Convert.ToString(MobileNo) + "'";

                SQl = SQl + "select U2.usrMobileNo as LLeadermobileNo " +
                          " from TreeDemo e2 " +
                          " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                          " join TreeDemo e3 on e2.id=e3.parentid " +
                          " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                          " where U3.usrMobileNo in(" + SQl + ")";

                string Deputy, Director = "";//= cc.ExecuteScalar(SQl);
                DataSet ds = cc.ExecuteDataset(SQl);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Deputy = Convert.ToString(ds.Tables[0].Rows[0]["LeadermobileNo"]);
                    Director = Convert.ToString(ds.Tables[1].Rows[0]["LLeadermobileNo"]);
                    AddSubUser_EO1(HmMobileNo, FristName, LastName, Deputy, Director, 75);  //For EO
                }
                // AddSubUser_EO1(HmMobileNo, FristName, LastName, MobileNo);
            }
            else if (KeyHmCh == "CH")
            {
                string ChMobileNo = Convert.ToString(SplitMsg[1]);
                string FullName = Convert.ToString(SplitMsg[2]);

                string[] Name = FullName.Split(' ');
                string FristName = Convert.ToString(Name[0]);
                string LastName = Convert.ToString(Name[1]);
                string ClusterArea = Convert.ToString(SplitMsg[3]);

                string SQl = "select U2.usrMobileNo as LeadermobileNo " +
                                       " from TreeDemo e2 " +
                                       " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                                       " join TreeDemo e3 on e2.id=e3.parentid " +
                                       " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                                       " where U3.usrMobileNo='" + Convert.ToString(MobileNo) + "'";

                SQl = SQl + "select U2.usrMobileNo as LLeadermobileNo " +
                          " from TreeDemo e2 " +
                          " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                          " join TreeDemo e3 on e2.id=e3.parentid " +
                          " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                          " where U3.usrMobileNo in(" + SQl + ")";

                string Deputy, Director = "";//= cc.ExecuteScalar(SQl);
                DataSet ds = cc.ExecuteDataset(SQl);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Deputy = Convert.ToString(ds.Tables[0].Rows[0]["LeadermobileNo"]);
                    Director = Convert.ToString(ds.Tables[1].Rows[0]["LLeadermobileNo"]);
                    AddSubUser_EO1(ChMobileNo, FristName, LastName, Deputy, Director, 21);  //For EO
                }
                //AddSubUser_EO1(ChMobileNo, FristName, LastName, MobileNo);

                string Sql = "select usrUserid from usermaster where usrMobileNo='" + ChMobileNo + "'";
                string ChUserId = cc.ExecuteScalar(Sql);
                if (ChUserId == "" || ChUserId == null)
                {
                }
                else
                {
                    string UpdateMobileNo = "Update UserMaster set usrAddress='" + ClusterArea + "' where usrUserId='" + ChUserId + "' and usrMobileNo='" + ChMobileNo + "'";
                    int a = cc.ExecuteNonQuery(UpdateMobileNo);
                }
            }
            else
            {
                string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                     " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }
    #endregion Udise_AddChHm

    //--------------------------------------------------------------- User User List ---------------------------------------------------------------------

    #region Udise_JrList
    public void Udise_JrList()
    {
        try
        {
            string JrList = "";
            string Sql = "Select usrUserId from UserMaster where usrMobileNo='" + MobileNo + "'";
            string UserId = Convert.ToString(cc.ExecuteScalar(Sql));
            if (UserId == "" || UserId == null)
            {
            }
            else
            {
                string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + UserId + "' and Active=1 and mainrole=1";
                string GetRoleID = Convert.ToString(cc.ExecuteScalar(sqlcheck));
                //if (GetRoleID == "41" || GetRoleID == "75")//GetRoleID == "77" ||
                if (GetRoleID == "76" || GetRoleID == "75")//GetRoleID == "77" ||
                {
                    string SqlRole = "select rolename from AdminSubMarketingSubUser where userid='" + UserId + "' and Active=1 and mainrole=1";
                    string RoleName = Convert.ToString(cc.ExecuteScalar(SqlRole));
                    if (RoleName == "" || RoleName == null)
                    { }
                    else
                    {
                        string SubIdSql = "Select id from TreeDemo where userid='" + UserId + "' and RoleId=" + GetRoleID + "";
                        string SubUserAutoId = Convert.ToString(cc.ExecuteScalar(SubIdSql));
                        if (SubUserAutoId == "" || SubUserAutoId == null)
                        {
                        }
                        else
                        {
                            string ParentId = "Select distinct(usrMobileNo),usrFirstName, usrLastName from UserMaster inner join [TreeDemo] " +
                                              " on UserMaster.usrUserId=[TreeDemo].userid where parentid='" + SubUserAutoId + "'";
                            DataSet ds1 = cc.ExecuteDataset(ParentId);
                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                string UsrMobileNo = Convert.ToString(ds1.Tables[0].Rows[i]["usrMobileNo"]);
                                string userFirstName = Convert.ToString(ds1.Tables[0].Rows[i]["usrFirstName"]);
                                string userLastName = Convert.ToString(ds1.Tables[0].Rows[i]["usrLastName"]);
                                JrList += "" + UsrMobileNo + " " + userFirstName + " " + userLastName + ",\n";

                            }
                            if (JrList == "" || JrList == null)
                            { }
                            else
                            {
                                JrList = JrList.Replace(",", "," + System.Environment.NewLine);
                                string SqlLastName = "Select usrLastName, usrEmailId from UserMaster where usrMobileNo='" + MobileNo + "'";
                                DataSet ds = cc.ExecuteDataset(SqlLastName);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    //string EmailId = "ketan.s.shinde@gmail.com";
                                    string EmailId = Convert.ToString(ds.Tables[0].Rows[0]["usrEmailId"]);
                                    string LastName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
                                    string SendJrList = "Dear " + LastName + " Sir/Madam Under You " + JrList + " Are " + RoleName + "" + cc.AddSMS(MobileNo);
                                    if (EmailId == "" || EmailId == null)
                                    { }
                                    else
                                    {
                                        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                                        msg.From = new MailAddress("ezeesoftindia@gmail.com");
                                        msg.To.Add(EmailId);//Text for To Address  
                                        msg.Subject = "List Of Under Role Name"; //Text for subject  
                                        msg.IsBodyHtml = true;
                                        msg.Body = SendJrList;//Text for body  
                                        msg.Priority = MailPriority.High;
                                        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                                        client.UseDefaultCredentials = false;
                                        client.Credentials = new System.Net.NetworkCredential("ezeesoftindia@gmail.com", "abhinavitsoft14");
                                        client.Port = 587;
                                        client.Host = "smtp.gmail.com";
                                        client.EnableSsl = true;
                                        object userstate = msg;
                                        client.Send(msg);
                                        string EmailText = "Dear " + LastName + " Sir/Madam We Have been Sent Mail On your Account,List of " + RoleName + "" + cc.AddSMS(MobileNo);
                                        //cc.SendMessageLongCodeSMS("UDISE", MobileNo, SendJrList, smslength);
                                        int smslength = EmailText.Length;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    string SqlRole = "select rolename from AdminSubMarketingSubUser where userid='" + UserId + "' and Active=1 and mainrole=1";
                    string RoleName = Convert.ToString(cc.ExecuteScalar(SqlRole));
                    if (RoleName == "" || RoleName == null)
                    { }
                    else
                    {
                        string SubIdSql = "Select id from TreeDemo where userid='" + UserId + "' and RoleId=" + GetRoleID + "";
                        string SubUserAutoId = Convert.ToString(cc.ExecuteScalar(SubIdSql));
                        if (SubUserAutoId == "" || SubUserAutoId == null)
                        {
                        }
                        else
                        {
                            string ParentId = "Select distinct(usrMobileNo), usrLastName from UserMaster inner join [TreeDemo] " +
                                              " on UserMaster.usrUserId=[TreeDemo].userid where parentid='" + SubUserAutoId + "'";
                            DataSet ds1 = cc.ExecuteDataset(ParentId);
                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                string UsrMobileNo = Convert.ToString(ds1.Tables[0].Rows[i]["usrMobileNo"]);
                                string userLastName = Convert.ToString(ds1.Tables[0].Rows[i]["usrLastName"]);
                                JrList += "" + UsrMobileNo + " " + userLastName + ",";
                            }
                            if (JrList == "" || JrList == null)
                            { }
                            else
                            {
                                string SqlLastName = "Select usrLastName from UserMaster where usrMobileNo='" + MobileNo + "'";
                                string LastName = Convert.ToString(cc.ExecuteScalar(SqlLastName));
                                if (LastName == "" || LastName == null)
                                {
                                }
                                else
                                {
                                    string SendJrList = "Dear " + LastName + " Sir under u " + JrList + " r " + RoleName + "" + cc.AddSMS(MobileNo);
                                    int smslength = SendJrList.Length;
                                    cc.SendMessageLongCodeSMS("UDISE", MobileNo, SendJrList, smslength);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                         " ('" + Attendence + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }

    }
    #endregion Udise_JrList

    //--------------------------------------------------------------- Replace joinior---------------------------------------------------------------------

    #region Replace_JR
    public void Replace_JR()
    {
        try
        {
            string OldNo = "", NewNo = "", name = "", fname = "", lname = "";
            string[] splitmsg = smsBody.Split('*');
            OldNo = Convert.ToString(splitmsg[1]);
            NewNo = Convert.ToString(splitmsg[2]);
            name = Convert.ToString(splitmsg[3]);

            string[] splitname = name.Split(' ');
            if (splitname.Length >= 2)
            {
                fname = Convert.ToString(splitname[0]);
                lname = Convert.ToString(splitname[1]);
            }

            if (OldNo != NewNo)
            {
                string JusrOldID = "select usruserid from usermaster where usrMobileNo='" + NewNo + "'";
                string JunioroldNo_usrID = cc.ExecuteScalar(JusrOldID); // get Old juniour usrUserID
                if (!(JunioroldNo_usrID == null || JunioroldNo_usrID == ""))
                {
                    Replace_juniors(OldNo, NewNo, MobileNo);
                }
                else
                {
                    Addnew(fname, lname, NewNo);

                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Old Mobile No. & New Mobile No. Not Same' )", true);
                Response.Write("<script>(alert)('Old Mobile No. & New Mobile No. Not Same')</script>");

            }
        }
        catch (Exception ex)
        {

        }
    }

    private void Replace_juniors(string JuniorNoOld, string JuniorNoNew, string leader_no)
    {
        try
        {
            LeaderNo = leader_no; // use for common All code
            string getuserID_Leader = "select usrUserid from usermaster where usrMobileNo='" + LeaderNo + "'";
            Leader_UserID = cc.ExecuteScalar(getuserID_Leader); // get Leader usruserID
            if (Leader_UserID == "Admin")
            {
                string sql = "select MobileNo from Marketinguser1 where UserId='" + UserName + "'";
                string mobileno = cc.ExecuteScalar(sql);
                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                Leader_UserID = cc.ExecuteScalar(sql1);
            }
            else
            {
                info13();
            }
            string JusrID = "select usruserid from usermaster where usrMobileNo='" + JuniorNoNew + "'";
            string JuniorNo_usrID = cc.ExecuteScalar(JusrID); // get juniour usrUserID

            string JusrOldID = "select usruserid from usermaster where usrMobileNo='" + JuniorNoOld + "'";
            string JunioroldNo_usrID = cc.ExecuteScalar(JusrOldID); // get Old juniour usrUserID

            string date_ofJoin = "", JuniorRoleID = "", JuniorRoleName = "", reference_id1 = "";
            date_ofJoin = DateTime.Now.Date.ToString(); // get current date
            reference_id1 = initialreference; // add Administrator reference 

            string GetJRoleID = "select Roleid ,RoleName from SubMenuPermission where UnderRole='" + Leader_RoleID + "'";
            DataSet ds = cc.ExecuteDataset(GetJRoleID); // get juniour RoleID & Role Name
            if (ds.Tables[0].Rows.Count > 0)
            {
                JuniorRoleID = Convert.ToString(ds.Tables[0].Rows[0]["Roleid"]);
                JuniorRoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            }
            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                string SQL = "update AdminSubMarketingSubUser set  Active='0'  where    friendid = '" + JunioroldNo_usrID + "' and userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "'  ";
                // SQL = "update AdminSubMarketingSubUser set  Active='0'  where  friendid='" + JuniorNo_usrID + "' and   userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and friendid = '" + JuniorNo_usrID + "' ";

                int a = cc.ExecuteNonQuery(SQL);
                if (a >= 1)
                {
                    if (JunioroldNo_usrID != JuniorNo_usrID)
                    {
                        string Checkref = JunioroldNo_usrID;

                        int a1;
                        string sq1 = "select id from AdminSubMarketingSubUser where userid='" + JuniorNo_usrID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                        string Chk_Assign = cc.ExecuteScalar(sq1); // check juniour is exit or not
                        if ((Chk_Assign == null || Chk_Assign == ""))
                        {
                            SQL = "delete from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "'";
                            SQL = SQL + "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Active='1'  where  friendid = '" + JunioroldNo_usrID + "' and  userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                            a1 = cc.ExecuteNonQuery(SQL);
                        }
                        else
                        {
                            SQL = SQL + "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Active='1'  where  friendid = '" + JunioroldNo_usrID + "' and  userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                            a1 = cc.ExecuteNonQuery(SQL);

                        }

                        //SQL = SQL + "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Active='1'  where  friendid = '" + JunioroldNo_usrID + "' and  userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                        //a1 = cc.ExecuteNonQuery(SQL);
                        string qry;
                        int status;
                        if (a1 >= 1)
                        {
                            if (reference_id2 == "")
                            {

                                qry = "update AdminSubMarketingSubUser set reference_id2='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and  reference_id1='" + reference_id1 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);

                            }
                            if (reference_id3 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id3='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id4 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id4='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + Checkref + "'";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id5 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id5='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id6 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id6='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id7 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id7='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id8 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id8='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id9 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id9='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id10 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id10='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id11 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(Checkref) + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This User is already subuser Other')", true);
                    Response.Write("<script>(alert)('This User is already subuser Other.')</script>");

                }

            }
            else
            {

                string AddJunior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Active)" +
                       " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','1')";
                string exe = cc.ExecuteScalar(AddJunior); // Add Juniour  Under his Leader
                string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + JuniorNo_usrID + "'";
                string a = cc.ExecuteScalar(sqlupdate); // allow permission is Marketing person i.e allow go to admin side.

                string query = "select id from TreeDemo where userid='" + Leader_UserID + "' ";
                string CheckTree = cc.ExecuteScalar(query); // Get leader ID already add in tree digrame
                if (!(CheckTree == null || CheckTree == ""))
                {

                    string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' and id=" + CheckTree + " ";
                    string GetID = cc.ExecuteScalar(check_Available); // check leader ID & Juniour Is already define or Not
                    if (!(GetID == null || GetID == ""))
                    {
                        //alredy Add in tree
                    }
                    else
                    {
                        string Addtree = "insert into TreeDemo(userid,parentid)values('" + JuniorNo_usrID + "','" + CheckTree + "')";
                        string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                    }
                }
                else
                {
                    // if leader not add in tree diagram
                    //string Addtree = "insert into TreeDemo(userid,parentid)values('" + Leader_UserID + "','" + CheckTree + "')";
                    //string b = cc.ExecuteScalar(Addtree);
                }


                Replace_juniors(JuniorNoOld, JuniorNoNew, leader_no);

            }

            if (Leader_RoleID == "76" || Leader_RoleID == "76")
            //  if (Leader_RoleID == "41" || Leader_RoleID == "41")
            {
                string sql = "select SchoolId from UDISE_SchoolMaster  inner join UDISE_TeacherMaster on UDISE_TeacherMaster.SchoolCode=UDISE_SchoolMaster.SchoolCode   where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' and UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' ";
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                    //string Management = "", SchoolType = "", Classes = "";
                    //sql = "insert into UDISE_SchoolMaster(SchoolCode,SchoolName,Management,SchoolType,Classes) values('" + schoolcode + "','" + schoolName + "','" + Management + "','" + SchoolType + "','" + Classes + "')";
                    //int a1 = cc.ExecuteNonQuery(sql);                      
                }
                else
                {

                    //string SQLA = "select friendid from AdminSubMarketingSubUser where roleid='" + JuniorRoleID + "' and friendid= '" + Leader_UserID + "' ";
                    //string HM_ID = cc.ExecuteScalar(SQLA);
                    string usrclass = "", section = "";
                    //   udise_addsub.AddSubUser(JuniorNo, fname, lname, schoolcode, ClassName, Section, Leader_UserID);

                }
            }
        }
        catch (Exception ex)
        {


        }

    }
    #endregion Replace_JR

    //----------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------***LongCodeCoding***---------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------

    #region LongCodeLoad
    public void LongCode()
    {
        try
        {
            numflag = false; emailFlag = false;
            string messageJM = "";

            message = Convert.ToString(smsBody);
            receivedon = Convert.ToString(CurrenctDate);

            message = message.Replace('<', ' ');
            message = message.Replace('>', ' ');
            PinMessage = message;
            mobile = Convert.ToString(Request.QueryString["senderMobileNo"]);
            shortcode = Convert.ToString(CurrenctDate);

            string Data = "New";
            message = message.Replace("'", "sssss");
            message = message.Replace("&", "aaaaa");

            string mobile_No = mobile.Substring(2, 10);
            string Sql = "Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,smsStatus) values " +
                " ('" + message + "','" + mobile_No + "','" + CurrenctDate + "','" + Data + "','" + CurrenctDate + "','N' )";
            int w = cc.ExecuteNonQuery(Sql);
            // come2mycity.test
            string NewSqlRecord = "Select PK from come2mycity.test where message='" + message + "' and mobile='" + mobile_No + "' and shortcode='" + CurrenctDate + "' and data='" + Data + "'";
            string PK = cc.ExecuteScalar(NewSqlRecord);
            urUserRegBLLObj.usrPKval = Convert.ToInt32(PK);
            WholeMsg = message;

            if (message.StartsWith("*") || message.StartsWith(" "))
            {
                int id_rem = 1;
                foreach (char a in message.Trim().ToCharArray())
                {
                    if (a != ' ' && a != '*')
                    {
                        break;
                    }
                    else if (a == ' ' || a == '*')
                    {
                        message = message.Substring(id_rem, message.Length - id_rem);         //.Remove(id_rem);
                        //id_rem++;
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
            string[] sp = new string[3];
            int index = 0, indexstart = 0;

            WholeMsg = message;
            string str = StrSep[0].Trim();
            index = 0;
            index = UVACheck(str);
            uvaStr = WholeMsg.Substring(indexstart, index);
            remainMsg = WholeMsg.Substring(index, WholeMsg.Length - (index)).Trim();

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




            ///////////Changes by Pooja///////////
            //--------------------------------------------School Keyword Change By Ketan---------------------------------------------------------------
            if (mkeyword1 == "CLASS" || mkeyword1 == "AB" || mkeyword1 == "ABSENT" || mkeyword1 == "PR" || mkeyword1 == "PRESENT" || mkeyword1 == "ALLSTU" || mkeyword1 == "ALLPAR" || mkeyword1 == "CLASS1" || mkeyword1 == "CLASS2" || mkeyword1 == "CLASS3" || mkeyword1 == "CLASS4" || mkeyword1 == "CLASS5"
                    || mkeyword1 == "CLASS6" || mkeyword1 == "CLASS7" || mkeyword1 == "CLASS8" || mkeyword1 == "CLASS9" || mkeyword1 == "CLASS10" || mkeyword1 == "CLASS11" || mkeyword1 == "CLASS12"
                    || mkeyword1 == "STUDENT" || mkeyword1 == "PARENT" || mkeyword1 == "HEADMASTER" || mkeyword1 == "HEAD MASTER" || mkeyword1 == "PRINCIPAL")
            {
                schoolkeywords();
            }
            //--------------------------------------------------------------------------------------------------------

            else if ((mkeyword1 == "HEAD" || mkeyword1 == "SON" || mkeyword1 == "LEADER" || mkeyword1 == "WORKER" || mkeyword1 == "JUNIOR" || mkeyword1 == "WIFE" || mkeyword1 == "DAUGHTER" || mkeyword1 == "FRIEND" || mkeyword1 == "FAMILY"))
            {
                if (WholeMsg.Contains('*'))
                {
                    telisamaj();
                }
                else
                {
                    key.SendKeywordSyntax(mkeyword1, mobile);

                }

            }

            else
            {
                if (mobile.Length > 10)
                    mobile = mobile.Substring(2);//to remove 91 from mobile
                urUserRegBLLObj.usrMobileNo = mobile;
                PinMobile = mobile;
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
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

                    if (s == "NCP*" || s == "MPSC*" || s == "REG*" || s == "OM*" || s == "TTD*" || s == "ANNA*" || s == "RAVIDASSIA*" || s == "AGRO*" || s == "WSSD*" || s == "AMC*" || s == "DIDIMA*" || s == "DIDIMAA*" || s == "JAIN*" || s == "JANGID*" || s == "JB*" || s == "JM*" || s == "JNS*" || s == "MALI*" || s == "MHMSM*" || s == "MSS*" || s == "SAHU*" || s == "TELI*" || s.ToUpper().Trim() == "YUVA" || s.ToUpper().Trim() == "UVA" || s == "NSSPUNE*" || s == "NSSPUNE" || s == "UDISE*")
                    {
                        if (WholeMsg.Contains('*'))
                        {
                            RegisteredKeywordwithstar();
                        }
                        else
                        {
                            key.SendKeywordSyntax(s, mobile);
                        }
                    }
                    else if (s == "NCP " || s == "MPSC " || s == "REG " || s == "OM " || s == "TTD " || s == "ANNA " || s == "RAVIDASSIA " || s == "AGRO " || s == "WSSD " || s == "AMC " || s == "DIDIMA " || s == "DIDIMAA " || s == "JAIN " || s == "JANGID " || s == "JB " || s == "JM " || s == "JNS " || s == "MALI " || s == "MHMSM " || s == "MSS " || s == "SAHU " || s == "TELI " || s == "YUVA " || s == "UVA ")
                    {
                        //RegisteredKeywordwithstar1();          //temp
                    }

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
    #endregion LongCodeLoad

    //------------------------------------------------------------Udise Related Keywords------------------------------------------------------------------

    #region Datakeyword
    private void Datakeyword()
    {
        if ((mkeyword1 == "GETRECORD" || mkeyword1 == "GetRecord" || mkeyword1 == "Getrecord" || mkeyword1 == "getrecord"))
        {
            GetRecord();

        }
    }
    #endregion Datakeyword

    //------------------------------------------------------------ Telisamaj Member-----------------------------------------------------------------------

    #region telimyct
    private void telimyct(string leadermobileno, string leaderid, string wholesms)
    {
        string mob = "", fname = "", mname = "", lname = "", pincode = "", emailid = "", mobileno = "", job = "", dob = "", edu = "", age = "", name = "", mobile1 = "", UID = "", VID = "";
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit[11];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];

                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit[11];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;
                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                        }
                    }
                    mobile1 = starsplit1[3];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);
                        }
                    }
                    mobile1 = starsplit1[5];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);
                        }
                    }
                }
                else if (smslength > 2)
                {

                    mobile1 = starsplit1[1];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);
                        }
                    }
                    mobile1 = starsplit1[3];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);
                        }
                    }
                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }
            }
            /// length 4
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit[11];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {

                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }
                    }
                    mobile1 = starsplit1[3];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }
                else if (smslength > 2)
                {


                    mobile1 = starsplit1[1];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];

                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];

                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit[11];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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

                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];

                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[5];

                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }



                }
                else if (smslength > 2)
                {
                    mobile1 = starsplit1[1];

                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];

                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";//wife
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit[5];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;
                        }
                        add = starsplit[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit[9];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit[11];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;
                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        name = starsplit1[3];
                        if (name.Contains(' '))
                        {
                            arr = name.Split(' ');
                            fname = arr[0];
                            urUserRegBLLObj.usrFirstName = fname;
                            lname = arr[1];
                            urUserRegBLLObj.usrLastName = lname;

                        }
                        add = starsplit1[5];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = starsplit1[5];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        dob = starsplit1[7];
                        urUserRegBLLObj.usrDOB = dob;
                        job = starsplit1[9];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }
                    }
                    mobile1 = starsplit1[3];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                        }
                    }
                    mobile1 = starsplit1[5];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }



                }
                else if (smslength > 2)
                {
                    mobile1 = starsplit1[1];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                    mobile1 = starsplit1[3];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);
                        }
                    }

                }
                else if (smslength > 1)
                {
                    mobile1 = starsplit1[1];
                    urUserRegBLLObj.usrMobileNo = mobile1;
                    sql = "select usrUserid from usermaster where usrMobileNo='" + mobile1 + "'";
                    id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                            smslength = message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                        }
                    }
                }



            }



        }
        else if ((mkeyword1 == "LEADER" || mkeyword1 == "JUNIOR" || mkeyword1 == "WORKER"))
        {

            string[] namesplit;
            string address = "";
            string[] arrplit = WholeMsg.Split('*');
            mobileno = arrplit[1].ToString();
            urUserRegBLLObj.usrMobileNo = mobileno;
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
            if (status == 0)
            {
                string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                userId = cc.ExecuteScalar(sqluser);
                AddJuniors(userId, mobileno, mkeyword1);
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobileno;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        //smslength = passwordMessage.Length;
                        //cc.SendMessageLongCodeSMS("MobileLongCode", mobile, passwordMessage, smslength);
                    }
                    string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                    userId = cc.ExecuteScalar(sqluser);
                    AddJuniors(userId, mobileno, mkeyword1);


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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobileno;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        // smslength = passwordMessage.Length;
                        // cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }
                    string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                    userId = cc.ExecuteScalar(sqluser);
                    AddJuniors(userId, mobileno, mkeyword1);//--
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobileno;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        //smslength = passwordMessage.Length;
                        //cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }
                    string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                    userId = cc.ExecuteScalar(sqluser);
                    AddJuniors(userId, mobileno, mkeyword1);//--

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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobileno;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        //smslength = passwordMessage.Length;
                        //cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }
                    string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                    userId = cc.ExecuteScalar(sqluser);
                    AddJuniors(userId, mobileno, mkeyword1);//--

                }
                else if (arrplit.Length > 1)
                {
                    mobileno = arrplit[1].ToString();

                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobileno;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        // smslength = passwordMessage.Length;
                        // cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }
                    string sqluser = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                    userId = cc.ExecuteScalar(sqluser);
                    AddJuniors(userId, mobileno, mkeyword1);//--

                }

            }
        }
        else if (mkeyword1 == "HEAD" || mkeyword1 == "MAIN")
        {
            messsplit = WholeMsg.Split('*');
            if (messsplit.Length > 16)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urUserRegBLLObj.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    mname = arrsp[1];
                    urUserRegBLLObj.usrMiddleName = mname;
                    lname = arrsp[2];
                    urUserRegBLLObj.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    lname = arrsp[1];
                    urUserRegBLLObj.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                }
                add = messsplit[5];
                urUserRegBLLObj.usrAddress = add;
                pincode = messsplit[7];
                urUserRegBLLObj.usrPIN = pincode;
                emailid = messsplit[9];
                urUserRegBLLObj.usrEmailId = emailid;
                UID = messsplit[11];
                urUserRegBLLObj.usrBestFeature = UID;
                VID = messsplit[13];
                urUserRegBLLObj.usrBuild = VID;
                if (messsplit[14] == "DOB" || messsplit[14] == "D.O.B" || messsplit[14] == "dob")
                {
                    dob = messsplit[15];
                    urUserRegBLLObj.usrDOB = dob;
                }
                else if (messsplit[14] == "AGE" || messsplit[14] == "age" || messsplit[14] == "Age")
                {
                    age = messsplit[15];
                    urUserRegBLLObj.UsrAge = Convert.ToInt32(age);
                }
                job = messsplit[17];
                urUserRegBLLObj.usrCarrerInterest = job;
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 14)
            {

                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urUserRegBLLObj.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    mname = arrsp[1];
                    urUserRegBLLObj.usrMiddleName = mname;
                    lname = arrsp[2];
                    urUserRegBLLObj.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    lname = arrsp[1];
                    urUserRegBLLObj.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                }
                add = messsplit[5];
                urUserRegBLLObj.usrAddress = add;
                pincode = messsplit[7];
                urUserRegBLLObj.usrPIN = pincode;
                emailid = messsplit[9];
                urUserRegBLLObj.usrEmailId = emailid;
                UID = messsplit[11];
                urUserRegBLLObj.usrIdealMatch = UID;
                VID = messsplit[13];
                urUserRegBLLObj.usrBuild = VID;
                if (messsplit[14] == "DOB" || messsplit[14] == "D.O.B" || messsplit[14] == "dob")
                {
                    dob = messsplit[15];
                    urUserRegBLLObj.usrDOB = dob;
                }
                else if (messsplit[14] == "AGE" || messsplit[14] == "age" || messsplit[14] == "Age")
                {
                    age = messsplit[15];
                    urUserRegBLLObj.UsrAge = Convert.ToInt32(age);
                }
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }
                }


            }
            else if (messsplit.Length > 12)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urUserRegBLLObj.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    mname = arrsp[1];
                    urUserRegBLLObj.usrMiddleName = mname;
                    lname = arrsp[2];
                    urUserRegBLLObj.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    lname = arrsp[1];
                    urUserRegBLLObj.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                }
                add = messsplit[5];
                urUserRegBLLObj.usrAddress = add;
                pincode = messsplit[7];
                urUserRegBLLObj.usrPIN = pincode;
                emailid = messsplit[9];
                urUserRegBLLObj.usrEmailId = emailid;
                UID = messsplit[11];
                urUserRegBLLObj.usrIdealMatch = UID;
                VID = messsplit[13];
                urUserRegBLLObj.usrBuild = VID;
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 10)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urUserRegBLLObj.usrMobileNo = mob;
                string fullname = messsplit[2].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    mname = arrsp[1];
                    urUserRegBLLObj.usrMiddleName = mname;
                    lname = arrsp[2];
                    urUserRegBLLObj.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    lname = arrsp[1];
                    urUserRegBLLObj.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                }
                add = messsplit[4];
                urUserRegBLLObj.usrAddress = add;
                pincode = messsplit[6];
                urUserRegBLLObj.usrPIN = pincode;
                emailid = messsplit[8];
                urUserRegBLLObj.usrEmailId = emailid;
                UID = messsplit[11];
                urUserRegBLLObj.usrIdealMatch = UID;

                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 8)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urUserRegBLLObj.usrMobileNo = mob;
                string fullname = messsplit[3].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    mname = arrsp[1];
                    urUserRegBLLObj.usrMiddleName = mname;
                    lname = arrsp[2];
                    urUserRegBLLObj.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    lname = arrsp[1];
                    urUserRegBLLObj.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                }
                add = messsplit[5];
                urUserRegBLLObj.usrAddress = add;
                pincode = messsplit[7];
                urUserRegBLLObj.usrPIN = pincode;
                emailid = messsplit[8];
                urUserRegBLLObj.usrEmailId = emailid;
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }
            else if (messsplit.Length > 6)
            {
                string keyword = messsplit[0].ToString();
                mob = messsplit[1].ToString();
                urUserRegBLLObj.usrMobileNo = mob;
                string fullname = messsplit[2].ToString();
                string[] arrsp = fullname.Split(' ');
                if (arrsp.Length > 2)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    mname = arrsp[1];
                    urUserRegBLLObj.usrMiddleName = mname;
                    lname = arrsp[2];
                    urUserRegBLLObj.usrLastName = lname;

                }
                else if (arrsp.Length > 1)
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                    lname = arrsp[1];
                    urUserRegBLLObj.usrLastName = lname;
                }
                else
                {
                    fname = arrsp[0];
                    urUserRegBLLObj.usrFirstName = fname;
                }
                add = messsplit[4];
                urUserRegBLLObj.usrAddress = add;
                pincode = messsplit[7];
                urUserRegBLLObj.usrPIN = pincode;
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";

                    }

                }
            }

            //teli.GetMessage(leadermobileno, leaderid, wholesms);
            //tel1.GetMessage(leadermobileno, leaderid, wholesms);


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
                    urUserRegBLLObj.usrMobileNo = mobile1;
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
                                urUserRegBLLObj.usrFirstName = fname;
                                mname = space[1];
                                urUserRegBLLObj.usrMiddleName = mname;
                                lname = space[2];
                                urUserRegBLLObj.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                                lname = space[1];
                                urUserRegBLLObj.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                            }
                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urUserRegBLLObj.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urUserRegBLLObj.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urUserRegBLLObj.usrBestFeature = UID;
                        VID = arrmsg[15];
                        urUserRegBLLObj.usrBuild = VID;
                        string key = arrmsg[16];
                        if (key == "Age")
                        {
                            age = arrmsg[17];
                            urUserRegBLLObj.Age = Convert.ToInt32(age);

                        }
                        else
                        {
                            dob = arrmsg[17];
                            urUserRegBLLObj.usrDOB = dob;
                        }
                        job = arrmsg[19];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
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
                                urUserRegBLLObj.usrFirstName = fname;
                                mname = space[1];
                                urUserRegBLLObj.usrMiddleName = mname;
                                lname = space[2];
                                urUserRegBLLObj.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                                lname = space[1];
                                urUserRegBLLObj.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urUserRegBLLObj.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urUserRegBLLObj.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urUserRegBLLObj.usrBestFeature = UID;
                        VID = arrmsg[15];
                        urUserRegBLLObj.usrBuild = VID;
                        string key = arrmsg[16];
                        if (key == "Age")
                        {
                            age = arrmsg[17];
                            urUserRegBLLObj.Age = Convert.ToInt32(age);

                        }
                        else
                        {
                            dob = arrmsg[17];
                            urUserRegBLLObj.usrDOB = dob;
                        }

                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
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
                                urUserRegBLLObj.usrFirstName = fname;
                                mname = space[1];
                                urUserRegBLLObj.usrMiddleName = mname;
                                lname = space[2];
                                urUserRegBLLObj.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                                lname = space[1];
                                urUserRegBLLObj.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urUserRegBLLObj.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urUserRegBLLObj.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urUserRegBLLObj.usrBestFeature = UID;
                        VID = arrmsg[15];
                        urUserRegBLLObj.usrBuild = VID;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
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
                                urUserRegBLLObj.usrFirstName = fname;
                                mname = space[1];
                                urUserRegBLLObj.usrMiddleName = mname;
                                lname = space[2];
                                urUserRegBLLObj.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                                lname = space[1];
                                urUserRegBLLObj.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urUserRegBLLObj.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urUserRegBLLObj.usrEmailId = emailid;
                        UID = arrmsg[13];
                        urUserRegBLLObj.usrBestFeature = UID;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
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
                                urUserRegBLLObj.usrFirstName = fname;
                                mname = space[1];
                                urUserRegBLLObj.usrMiddleName = mname;
                                lname = space[2];
                                urUserRegBLLObj.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                                lname = space[1];
                                urUserRegBLLObj.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urUserRegBLLObj.usrPIN = pincode;
                        emailid = arrmsg[11];
                        urUserRegBLLObj.usrEmailId = emailid;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
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
                    urUserRegBLLObj.usrMobileNo = mobile1;
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
                                urUserRegBLLObj.usrFirstName = fname;
                                mname = space[1];
                                urUserRegBLLObj.usrMiddleName = mname;
                                lname = space[2];
                                urUserRegBLLObj.usrLastName = lname;

                            }
                            else if (space.Length > 1)
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                                lname = space[1];
                                urUserRegBLLObj.usrLastName = lname;
                            }
                            else
                            {
                                fname = space[0];
                                urUserRegBLLObj.usrFirstName = fname;
                            }

                        }
                        add = arrmsg[7];
                        if (add == "do")
                        {
                            sql = "select usrAddress from usermaster where usrMobileNo='" + mobileno + "'";
                            add = cc.ExecuteScalar(sql);
                            urUserRegBLLObj.usrAddress = add;
                        }
                        else
                        {
                            add = arrmsg[7];
                            urUserRegBLLObj.usrAddress = add;

                        }
                        pincode = arrmsg[9];
                        urUserRegBLLObj.usrPIN = pincode;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertSpecificUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                                string message = "Welcome " + name + ", Your Password is " + myPassword + " www.myct.in";
                                cc.SendMessageLongCodeSMS("LongCode", mobile1, message, smslength);

                            }
                        }

                    }
                }
            }
            ////////////////////////////////////
            // teli.GetMessage(leadermobileno, leaderid, wholesms);
            //tel1.GetMessage(leadermobileno, leaderid, wholesms);
        }
    }

    private void telisamaj()
    {
        if (mobile.Length > 10)
            mobile = mobile.Substring(2);//to remove 91 from mobile
        string sql = "select usrUserid from UserMaster where usrMobileNo='" + mobile + "'";

        string ID = cc.ExecuteScalar(sql);
        sql = "select id from AdminSubMarketingSubUser where friendid='" + ID + "'";
        string roleid = cc.ExecuteScalar(sql);
        if (roleid == "" || roleid == null)
        {

        }
        else
        {
            telimyct(mobile, ID, WholeMsg);
            //teli.GetMessage(mobile, ID, WholeMsg); //Server
            //tel1.GetMessage(mobile, ID, WholeMsg);  //Local
        }





    }
    #endregion telimyct

    //------------------------------------------------------------ Ruff Coding----------------------------------------------------------------------------

    #region RuffCoding
    /// <summary>
    /// //////old code////////
    /// </summary>
    /// <param name="usr"></param>
    //private void AddJuniors(string usr)
    //{
    //    try
    //    {
    //        info12(usr);

    //    }
    //    catch (Exception ex)
    //    { }
    //}
    //private void info12(string usr)
    //{
    //    try
    //    {
    //        string usrRole = "", userid = "", RoleId = "", friendid = "", reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", initialreference = "";
    //        string sqlfetch = "select userid,roleid,rolename,reference_id2,reference_id3,reference_id4,reference_id5,friendid from AdminSubMarketingSubUser " +
    //        " inner join UserMaster on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid where UserMaster.usrMobileNo='" + mobile + "'";
    //        DataSet ds1 = cc.ExecuteDataset(sqlfetch);
    //        foreach (DataRow dr1 in ds1.Tables[0].Rows)
    //        {
    //            usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
    //            userid = Convert.ToString(ds1.Tables[0].Rows[0]["userid"]);
    //            RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
    //            friendid = Convert.ToString(ds1.Tables[0].Rows[0]["friendid"]);
    //            reference_id2 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id2"]);
    //            if (reference_id2 == "")
    //            {
    //                reference_id2 = userid;
    //                break;
    //            }

    //            reference_id3 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id3"]);
    //            if (reference_id3 == "")
    //            {
    //                reference_id3 = userid;
    //                break;
    //            }

    //            reference_id4 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id4"]);
    //            if (reference_id4 == "")
    //            {
    //                reference_id4 = userid;
    //                break;
    //            }
    //            reference_id5 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id5"]);
    //            if (reference_id5 == "")
    //            {
    //                reference_id5 = userid;
    //                break;
    //            }



    //        }

    //        initialreference = "6dde8c3d-1895-4904-b332-764f63206fc0";
    //        //Actual Code//
    //        string date_ofJoin = DateTime.Now.Date.ToString();
    //        string role = RoleId;
    //        string rolename = usrRole;
    //        string reference_id1 = initialreference;
    //        string sql12 = "select id from AdminSubMarketingSubUser where userid='" + friendid + "'";
    //        string id = cc.ExecuteScalar(sql12);
    //        int roleinc = 0;
    //        if (id == "")
    //        {
    //            string sql1 = "select roleid from SubMenuPermission where UnderRole='" + role + "'";
    //            id = cc.ExecuteScalar(sql1);
    //            if (id != "")
    //            {
    //                sql1 = "select Roleid,RoleName from SubMenuPermission where UnderRole='" + role + "'";
    //                DataSet ds = cc.ExecuteDataset(sql1);
    //                roleinc = Convert.ToInt32(ds.Tables[0].Rows[0]["Roleid"]);
    //                role = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);

    //                string sqlinsert = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5)" +
    //                    " values('" + friendid + "','" + usr + "','" + date_ofJoin + "','" + roleinc + "','" + role + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "')";
    //                string exe = cc.ExecuteScalar(sqlinsert);
    //                string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + usr + "'";
    //                string a = cc.ExecuteScalar(sqlupdate);
    //                string sqlinsert1 = "insert into datacollection(sender_mobileno)values('" + usr + "')";
    //                string c1 = cc.ExecuteScalar(sqlinsert1);
    //                if (roleinc.ToString() == "1")
    //                {
    //                    string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "',0)";
    //                    string b = cc.ExecuteScalar(sqlinserttree);
    //                }
    //                else
    //                {
    //                    string sql = "select id from TreeDemo where userid='" + friendid + "' ";
    //                    string c = cc.ExecuteScalar(sql);
    //                    string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "','" + c + "')";
    //                    string b = cc.ExecuteScalar(sqlinserttree);
    //                }
    //            }
    //            else
    //            {
    //                string sqlinsert = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5)" +
    //                      " values('" + friendid + "','" + usr + "','" + date_ofJoin + "','" + role + "','" + rolename + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "')";
    //                string exe = cc.ExecuteScalar(sqlinsert);
    //                string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + usr + "'";
    //                string a = cc.ExecuteScalar(sqlupdate);
    //                string sqlinsert1 = "insert into datacollection(sender_mobileno)values('" + usr + "')";
    //                string c1 = cc.ExecuteScalar(sqlinsert1);
    //                if (roleinc.ToString() == "1")
    //                {
    //                    string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "',0)";
    //                    string b = cc.ExecuteScalar(sqlinserttree);
    //                }
    //                else
    //                {
    //                    string sql = "select id from TreeDemo where userid='" + friendid + "' ";
    //                    string c = cc.ExecuteScalar(sql);
    //                    string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + usr + "','" + c + "')";
    //                    string b = cc.ExecuteScalar(sqlinserttree);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            string id1 = "";
    //            string sql = "select id from AdminSubMarketingSubUser where friendid='" + usr + "'";//Userid
    //            id1 = cc.ExecuteScalar(sql);
    //            if (!(id1 == null || id1 == ""))
    //            {

    //                string message = "Sorry,This User is already subuser of other, You cannot assign www.myctin";
    //                int smslength = message.Length;
    //                cc.SendMessageMobileLongCodeSMS("LongCode", mobile, message, smslength);
    //            }


    //            else
    //            {
    //                string sql121 = "select reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where id='" + id + "'";
    //                DataSet ds11 = cc.ExecuteDataset(sql121);
    //                reference_id2 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id2"]);
    //                if (reference_id2 == "")
    //                {
    //                    reference_id2 = "";
    //                }
    //                reference_id3 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id3"]);
    //                if (reference_id3 == "")
    //                {
    //                    reference_id3 = "";
    //                }
    //                reference_id4 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id4"]);
    //                if (reference_id4 == "")
    //                {
    //                    reference_id4 = "";
    //                }
    //                reference_id5 = Convert.ToString(ds11.Tables[0].Rows[0]["reference_id5"]);
    //                if (reference_id5 == "")
    //                {
    //                    reference_id5 = "";
    //                }
    //                string sql1 = "select roleid from SubMenuPermission where UnderRole='" + role + "'";
    //                id = cc.ExecuteScalar(sql1);
    //                if (id != "")
    //                {
    //                    sql1 = "select Roleid,RoleName from SubMenuPermission where UnderRole='" + role + "'";
    //                    DataSet ds = cc.ExecuteDataset(sql1);
    //                    roleinc = Convert.ToInt32(ds.Tables[0].Rows[0]["Roleid"]);
    //                    role = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
    //                    string sqlinsert = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5)" +
    //                        " values('" + friendid + "','" + usr + "','" + date_ofJoin + "','" + roleinc + "','" + role + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "')";
    //                    string exe = cc.ExecuteScalar(sqlinsert);
    //                    string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + friendid + "'";
    //                    string a = cc.ExecuteScalar(sqlupdate);
    //                    string sqlinsert1 = "insert into datacollection(sender_mobileno)values('" + friendid + "')";
    //                   // string c1 = cc.ExecuteScalar(sqlinsert1);
    //                    string query = "select id from TreeDemo where userid='" + userid + "' ";
    //                    string c12 = cc.ExecuteScalar(query);
    //                    string sqlinserttree = "insert into TreeDemo(userid,parentid)values('" + friendid + "','" + c12 + "')";
    //                    string b = cc.ExecuteScalar(sqlinserttree);
    //                }

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    { }

    //}
    /// <summary>
    /// /////////////////////////////
    /// </summary>
    /// <param name="myList"></param>
    /// <param name="Mess"></param>
    /// <param name="userid"></param>
    /// 
    #endregion RuffCoding

    //------------------------------------------------------------ old Hirarchy---------------------------------------------------------------------------

    #region old Hirarchy

    private void AddJuniors(string usr, string juniorMobile, string keyword)
    {
        try
        {
            info12(usr, juniorMobile, keyword);

        }
        catch (Exception ex)
        { }
    }

    private void info12(string usr, string juniorMobile, string keyword)
    {
    }
    #endregion old Hirarchy

    ////------------------------------------------------------------ Uva keywords-------------------------------------------------------------------------

    # region UVA

    private void NotUVA_RegStudent()
    {

        try
        {
            string fname = "", mname = "", lname = "";
            urUserRegBLLObj.usrMiddleName = "";
            string[] nm = new string[5];
            string memberName = "", schoolcode = "", email = "", memberAddress = "";
            mkeyword1 = mkeyword1.ToUpper();
            string Mobile = mobile.ToString();
            string[] mmsg = PinMessage.Split('*');

            int i = 0;
            foreach (string str in mmsg)
            {
                i++;
                if (str != "" && str != " " && memberName.Trim() == "")
                {
                    memberName = str.Trim();

                    if (memberName.Contains('.'))
                    {
                        nm = memberName.Split('.');
                    }
                    else
                    {
                        nm = memberName.Split(' ');
                    }

                    if (nm.Length > 3)
                    {
                        fname = memberName;

                    }

                    if (nm.Length == 3)
                    {
                        if (nm[0].ToString() != "")
                            fname = nm[0].ToString();
                        else
                            fname = nm[1].ToString();

                        if (nm[1].ToString() != "" && nm[1].ToString() != fname)
                            mname = nm[1].ToString();

                        if (nm[2].ToString() != "" && nm[2].ToString() != mname)
                            lname = nm[2].ToString();

                    }

                    else if (nm.Length == 2)
                    {
                        fname = nm[0].ToString();
                        lname = nm[1].ToString();

                    }
                    else if (nm.Length == 1)
                    {
                        fname = nm[0].ToString();

                    }
                    break;
                }
            }

            //foreach (string str in mmsg)
            //{
            if (mmsg[i] != "" && mmsg[i] != " " && memberName.Trim() != "")
            {
                schoolcode = mmsg[i].Trim();
            }
            else if (mmsg[i++] != "" && mmsg[i++] != " " && memberName.Trim() != "")
            {
                schoolcode = mmsg[i++].Trim();
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

            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
            urUserRegBLLObj.usrMobileNo = mobile;
            urUserRegBLLObj.usrFirstName = fname;
            urUserRegBLLObj.usrLastName = mname + " " + lname;
            urUserRegBLLObj.usrMiddleName = mname;
            urUserRegBLLObj.usrAddress = memberAddress;
            urUserRegBLLObj.usrEmailId = email;


            //////////////////////////////////////////////////////////////change util here///////

            Random rnd = new Random();
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            ////////////////////proc///////
            status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);

            ////update///

            string myMobileNo = urUserRegBLLObj.usrMobileNo;
            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
            string myName = urUserRegBLLObj.usrFirstName;

            // string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
            string NewSmsResp = "Dear std thanks to join uva jagar Pl register on www.mitsc.co.in with ur Mob No & Pswd " + myPassword + " fr all courses.Use same pswd to update u via www.myct.in fr jobs";
            smslength = NewSmsResp.Length;
            cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);

            smsStatus = "Y";
            string sqlinsert = "insert into collegecode(userid,collegecode)values('" + urUserRegBLLObj.usrUserId + "','" + schoolcode + "')";
            string a = cc.ExecuteScalar(sqlinsert);

            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',93)";
            string a1 = cc.ExecuteScalar(sql);

            emlTo = urUserRegBLLObj.usrEmailId;
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

                }
            }
        }
        catch (Exception ex)
        {
            //smsStatus = "N";
            if (mkeyword1 == "YUVA" && ex.Message == "Proper Syntax")
            {
                //string NewSmsResp = "Dear User,Use Syntax *YUVA*FirstName LastName*SchoolCode*Address Thanks Via www.myct.in";
                //cc.SendMessageTra(senderId, mobile, NewSmsResp);
            }
            else if (mkeyword1 == "UVA" && ex.Message == "Proper Syntax")
            {
                //string NewSmsResp = "Dear User,Use Syntax *UVA*FirstName LastName*SchoolCode*Address Thanks Via www.myct.in";
                //cc.SendMessageTra(senderId, mobile, NewSmsResp);
            }

        }

        finally
        {
            //come2mycity.test
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }

    }

    private void UVA_RegStudent()
    {
        int flg = 1;
        string senderId = "COM2MYCT";
        try
        {
            string usrUserid = "";
            string memberName = "", schoolcode = "", email = "", memberAddress = "";
            string fname = "", mname = "", lname = "";
            string[] nm = new string[5];
            mkeyword1 = mkeyword1.ToUpper();
            string Mobile = mobile.ToString();
            string[] mmsg = PinMessage.Split('*');


            int i = 0;
            foreach (string str in mmsg)
            {
                i++;
                if (str != "" && str != " " && memberName.Trim() == "")
                {
                    memberName = str.Trim();

                    if (memberName.Contains('.'))
                    {
                        nm = memberName.Split('.');
                    }
                    else
                    {
                        nm = memberName.Split(' ');
                    }

                    if (nm.Length > 3)
                    {
                        fname = memberName;

                    }

                    if (nm.Length == 3)
                    {
                        if (nm[0].ToString() != "")
                            fname = nm[0].ToString();
                        else
                            fname = nm[1].ToString();

                        if (nm[1].ToString() != "" && nm[1].ToString() != fname)
                            mname = nm[1].ToString();

                        if (nm[2].ToString() != "" && nm[2].ToString() != mname)
                            lname = nm[2].ToString();

                    }

                    else if (nm.Length == 2)
                    {
                        fname = nm[0].ToString();
                        lname = nm[1].ToString();

                    }
                    else if (nm.Length == 1)
                    {
                        fname = nm[0].ToString();

                    }
                    break;
                }
            }

            //foreach (string str in mmsg)
            //{
            if (mmsg[i] != "" && mmsg[i] != " " && memberName.Trim() != "")
            {
                schoolcode = mmsg[i].Trim();
            }
            else if (mmsg[i++] != "" && mmsg[i++] != " " && memberName.Trim() != "")
            {
                schoolcode = mmsg[i++].Trim();
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
            string sql = "";

            urUserRegBLLObj.usrMessageString = NewSmsResp.ToString();

            string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
            string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));

            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + mobile + "'";
            usrUserid = cc.ExecuteScalar(sqlget);

            string sqlinsert = "insert into collegecode(userid,collegecode)values('" + usrUserid + "','" + schoolcode + "')";
            string a = cc.ExecuteScalar(sqlinsert);

            NewSmsResp = "Dear std thanks to join uva jagar Pl register on www.mitsc.co.in with ur Mob No & Pswd " + passDec.ToString() + " fr all courses.Use same pswd to update u via www.myct.in fr jobs";
            smslength = NewSmsResp.Length;
            cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
            smsStatus = "Y";

            string sqlupdate = "update usermaster set JoinGroup='" + mkeyword1 + "' where usrMobileNo='" + Mobile + "'";
            string execute = cc.ExecuteScalar(sqlupdate);

            sql = "insert into UserGroup(Userid,GroupId)values('" + usrUserid + "',93)";
            string a1 = cc.ExecuteScalar(sql);

            sql = "select * from userMaster where usrMobileNo='" + Mobile.ToString() + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
            usrUserid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
            backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
            subject = "Mail From " + myName.ToString();

            emlBody = "\n\n...www.myct.in";
        }
        catch (Exception ex)
        {
            //smsStatus = "N";
            if (mkeyword1 == "YUVA" && ex.Message == "Proper Syntax")
            {
                //string NewSmsResp = "Dear User,Use Syntax *YUVA*FirstName LastName*SchoolCode*Address Thanks Via www.myct.in";
                //cc.SendMessageTra(senderId, mobile, NewSmsResp);
            }
            else if (mkeyword1 == "UVA" && ex.Message == "Proper Syntax")
            {
                //string NewSmsResp = "Dear User,Use Syntax *UVA*FirstName LastName*SchoolCode*Address Thanks Via www.myct.in";
                //cc.SendMessageTra(senderId, mobile, NewSmsResp);
            }

        }
        finally
        {
            //come2mycity.test
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
            //,smsStatus='" + smsStatus + "'
        }
    }

    public static bool numflag = false, emailFlag = false;
    public string FormCode(string str)
    {
        numflag = false;
        int pinflag = 0, index1 = 0;
        str = str.Trim();
        string[] space = str.Split(' ');
        for (int i = 0; i < space.Length; i++)
        {
            char[] pinsrch = space[i].ToCharArray();
            foreach (char a in pinsrch)
            {
                int ascii = a;
                if (ascii > 47 && ascii < 58 || ascii == 32 || ascii == 91 || ascii == 93)
                {
                    pinflag++;
                    numflag = true;
                    index1 = i;
                }
                else
                {
                    pinflag = 0;
                    numflag = false;
                }
            }
        }
        if (numflag == true)
        {
            SchCode = space[index1];
            //numflag = false;
            return SchCode;
        }
        else
            return "";
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
        string s = "";
        int i = 0;
        try
        {
            for (i = 0; i < 5; i++)
            {
                //|| s.ToUpper().Trim() != "YUVA"
                if (s.ToUpper().Trim() != "UVA" || s.ToUpper().Trim() != "YUVA")
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

    # endregion

    //------------------------------------------------------------ Data Collection Data keyword-----------------------------------------------------------

    #region DataKeyword
    private void GetRecord()
    {
        string sql20 = "";
        string mobileno = "";
        string messagesend = "";
        string id = "";
        DateTime date = DateTime.Now;
        string todaysDate = date.ToShortDateString();
        int r3 = 0, r5 = 0, r7 = 0, r9 = 0, r11 = 0, r13 = 0, r15 = 0, r17 = 0, r19 = 0, r21 = 0, r23 = 0;
        string senderid = "myct.in";
        string query = "select usrUserid from usermaster where usrMobileNo='" + mobile + "'";
        string userid = cc.ExecuteScalar(query);
        string sq1 = "select friendid from AdminSubMarketingSubUser where userid='" + userid + "'";
        DataSet ds = cc.ExecuteDataset(sq1);
        foreach (DataRow dr in ds.Tables[0].Rows)//1
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

            string f1 = Convert.ToString(dr["friendid"]);
            string sql2 = "select friendid from AdminSubMarketingSubUser where userid='" + f1 + "'";
            DataSet ds2 = cc.ExecuteDataset(sql2);
            foreach (DataRow dr2 in ds2.Tables[0].Rows)//2
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

                string f2 = Convert.ToString(dr2["friendid"]);
                string sql3 = "select friendid from AdminSubMarketingSubUser where userid='" + f2 + "'";
                DataSet ds3 = cc.ExecuteDataset(sql3);
                foreach (DataRow dr3 in ds3.Tables[0].Rows)//3
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

                    string f3 = Convert.ToString(dr3["friendid"]);
                    string sql4 = "select friendid from AdminSubMarketingSubUser where userid='" + f3 + "'";
                    DataSet ds4 = cc.ExecuteDataset(sql4);
                    foreach (DataRow dr4 in ds4.Tables[0].Rows)//4
                    {
                        string f4 = Convert.ToString(dr4["friendid"]);
                        string sql6 = "select * from DataCollection where sender_mobileno='" + f4 + "' and send_date='" + todaysDate + "'";
                        DataSet ds6 = cc.ExecuteDataset(sql6);
                        foreach (DataRow dr6 in ds6.Tables[0].Rows)
                        {
                            string sql5 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23 from DataCollection where sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                            DataSet ds5 = cc.ExecuteDataset(sql5);
                            foreach (DataRow dr5 in ds5.Tables[0].Rows)
                            {
                                int p3 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P3"]);
                                int p5 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P5"]);
                                int p7 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P7"]);
                                int p9 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p9"]);
                                int p11 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p11"]);
                                int p13 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p13"]);
                                int p15 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p15"]);
                                int p17 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p17"]);
                                int p19 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p19"]);
                                int p21 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p21"]);
                                int p23 = Convert.ToInt32(ds5.Tables[0].Rows[0]["p23"]);
                                r3 = r3 + p3;
                                r5 = r5 + p5;
                                r7 = r7 + p7;
                                r9 = r9 + p9;
                                r11 = r11 + p11;
                                r13 = r13 + p13;
                                r15 = r15 + p15;
                                r17 = r17 + p17;
                                r19 = r19 + p19;
                                r21 = r21 + p21;
                                r23 = r23 + p23;



                            }


                        }



                    }

                    string sql7 = "insert into AELevel4(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,ref_id,send_date)values('" + f3 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + f2 + "','" + todaysDate + "')";
                    int a = cc.ExecuteNonQuery(sql7);
                    sql20 = "select usrMobileNo from usermaster where usrUserid='" + f3 + "'";
                    mobileno = cc.ExecuteScalar(sql20);
                    messagesend = "Dear user calulation is Data*P3='" + r3 + "'*P5='" + r5 + "'*P7='" + r7 + "'*P9='" + r9 + "'*P11='" + r11 + "'*P13='" + r13 + "'*P15='" + r15 + "'*P17='" + r17 + "'*P19='" + r19 + "'*P21='" + r21 + "'*P23='" + r23 + "' thanks via www.myct.in";
                    //cc.SendMessageTra(senderid, mobileno, messagesend);

                    string sql131 = "select * from DataCollection where sender_mobileno='" + f3 + "' and send_date='" + todaysDate + "'";
                    DataSet ds141 = cc.ExecuteDataset(sql131);
                    foreach (DataRow dr14 in ds141.Tables[0].Rows)
                    {
                        int p3 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P3"]);
                        int p5 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P5"]);
                        int p7 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P7"]);
                        int p9 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p9"]);
                        int p11 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p11"]);
                        int p13 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p13"]);
                        int p15 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p15"]);
                        int p17 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p17"]);
                        int p19 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p19"]);
                        int p21 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p21"]);
                        int p23 = Convert.ToInt32(ds141.Tables[0].Rows[0]["p23"]);

                        string sql141 = "insert into AELevel4(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,ref_id,send_date)values('" + f3 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + f2 + "','" + todaysDate + "')";
                        int aa1 = cc.ExecuteNonQuery(sql141);

                    }

                }
                ////////////////Finish calculation of JE and insert into AE or End of JE/////////////////////

                string sql19 = "select * from AELevel4 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                DataSet ds19 = cc.ExecuteDataset(sql19);
                foreach (DataRow dr19 in ds19.Tables[0].Rows)
                {
                    id = Convert.ToString(dr19["sender_mobileno"]);
                    string sql8 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23  from AELevel4 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
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
                        int p3 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P3"]);
                        int p5 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P5"]);
                        int p7 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P7"]);
                        int p9 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p9"]);
                        int p11 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p11"]);
                        int p13 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p13"]);
                        int p15 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p15"]);
                        int p17 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p17"]);
                        int p19 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p19"]);
                        int p21 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p21"]);
                        int p23 = Convert.ToInt32(ds7.Tables[0].Rows[0]["p23"]);
                        r3 = r3 + p3;
                        r5 = r5 + p5;
                        r7 = r7 + p7;
                        r9 = r9 + p9;
                        r11 = r11 + p11;
                        r13 = r13 + p13;
                        r15 = r15 + p15;
                        r17 = r17 + p17;
                        r19 = r19 + p19;
                        r21 = r21 + p21;
                        r23 = r23 + p23;
                    }

                }

                string sql10 = "insert into EELevel3(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,ref_id,send_date)values('" + f2 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + f1 + "','" + todaysDate + "')";
                int c = cc.ExecuteNonQuery(sql10);
                sql20 = "select usrMobileNo from usermaster where usrUserid='" + f2 + "'";
                mobileno = cc.ExecuteScalar(sql20);
                messagesend = "Dear user calulation is Data*P3='" + r3 + "'*P5='" + r5 + "'*P7='" + r7 + "'*P9='" + r9 + "'*P11='" + r11 + "'*P13='" + r13 + "'*P15='" + r15 + "'*P17='" + r17 + "'*P19='" + r19 + "'*P21='" + r21 + "'*P23='" + r23 + "' thanks via www.myct.in";
                // cc.SendMessageTra(senderid, mobileno, messagesend);
                string sql1311 = "select * from DataCollection where sender_mobileno='" + f2 + "' and send_date='" + todaysDate + "'";
                DataSet ds1411 = cc.ExecuteDataset(sql1311);
                foreach (DataRow dr141 in ds1411.Tables[0].Rows)
                {
                    int p3 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P3"]);
                    int p5 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P5"]);
                    int p7 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P7"]);
                    int p9 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p9"]);
                    int p11 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p11"]);
                    int p13 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p13"]);
                    int p15 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p15"]);
                    int p17 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p17"]);
                    int p19 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p19"]);
                    int p21 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p21"]);
                    int p23 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["p23"]);

                    string sql141 = "insert into EELevel3(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,ref_id,send_date)values('" + f2 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + f1 + "','" + todaysDate + "')";
                    int aa1 = cc.ExecuteNonQuery(sql141);
                }



            }
            ///////////////////End of EE//////////////////////////////
            string sql12 = "select * from EELevel3 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
            DataSet ds13 = cc.ExecuteDataset(sql12);
            foreach (DataRow dr12 in ds13.Tables[0].Rows)
            {
                id = Convert.ToString(dr12["sender_mobileno"]);
                string sql11 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23 from EELevel3 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
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
                    int p3 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P3"]);
                    int p5 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P5"]);
                    int p7 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P7"]);
                    int p9 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p9"]);
                    int p11 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p11"]);
                    int p13 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p13"]);
                    int p15 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p15"]);
                    int p17 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p17"]);
                    int p19 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p19"]);
                    int p21 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p21"]);
                    int p23 = Convert.ToInt32(ds11.Tables[0].Rows[0]["p23"]);
                    r3 = r3 + p3;
                    r5 = r5 + p5;
                    r7 = r7 + p7;
                    r9 = r9 + p9;
                    r11 = r11 + p11;
                    r13 = r13 + p13;
                    r15 = r15 + p15;
                    r17 = r17 + p17;
                    r19 = r19 + p19;
                    r21 = r21 + p21;
                    r23 = r23 + p23;
                }
            }

            string sql9 = "insert into SELevel2(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,ref_id,send_date)values('" + f1 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + userid + "','" + todaysDate + "')";
            int d = cc.ExecuteNonQuery(sql9);
            sql20 = "select usrMobileNo from usermaster where usrUserid='" + f1 + "'";
            mobileno = cc.ExecuteScalar(sql20);
            messagesend = "Dear user calulation is Data*P3='" + r3 + "'*P5='" + r5 + "'*P7='" + r7 + "'*P9='" + r9 + "'*P11='" + r11 + "'*P13='" + r13 + "'*P15='" + r15 + "'*P17='" + r17 + "'*P19='" + r19 + "'*P21='" + r21 + "'*P23='" + r23 + "' thanks via www.myct.in";
            // cc.SendMessageTra(senderid, mobileno, messagesend);
            string sql13112 = "select * from DataCollection where sender_mobileno='" + f1 + "' and send_date='" + todaysDate + "'";
            DataSet ds14112 = cc.ExecuteDataset(sql13112);
            foreach (DataRow dr141 in ds14112.Tables[0].Rows)
            {
                int p3 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P3"]);
                int p5 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P5"]);
                int p7 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P7"]);
                int p9 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p9"]);
                int p11 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p11"]);
                int p13 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p13"]);
                int p15 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p15"]);
                int p17 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p17"]);
                int p19 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p19"]);
                int p21 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p21"]);
                int p23 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["p23"]);

                string sql141 = "insert into SELevel2(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,ref_id,send_date)values('" + f1 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + userid + "','" + todaysDate + "')";
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
            int p9 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p9"]);
            int p11 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p11"]);
            int p13 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p13"]);
            int p15 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p15"]);
            int p17 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p17"]);
            int p19 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p19"]);
            int p21 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p21"]);
            int p23 = Convert.ToInt32(ds16.Tables[0].Rows[0]["p23"]);
            string sql141 = "insert into SELevel2(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,ref_id,send_date)values('" + userid + "','" + p3 + "','" + p5 + "','" + p7 + "','" + p9 + "','" + p11 + "','" + p13 + "','" + p15 + "','" + p17 + "','" + p19 + "','" + p21 + "','" + p23 + "','" + userid + "','" + todaysDate + "')";
            int aa1 = cc.ExecuteNonQuery(sql141);


        }

        /////////////////////////////////End of SE//////////////////////

        string sql13 = "select * from SELevel2 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
        DataSet ds14 = cc.ExecuteDataset(sql13);
        foreach (DataRow dr13 in ds14.Tables[0].Rows)
        {
            id = Convert.ToString(dr13["sender_mobileno"]);
            string sqlfinal = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7,Sum(P9) as P9,Sum(P11) as P11, Sum(P13) as P13,Sum(P15) as P15,Sum(P17) as P17,Sum(P19) as P19,Sum(P21) as P21,Sum(P23) as P23  from SELevel2 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
            DataSet dsfinal = cc.ExecuteDataset(sqlfinal);
            int p3 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P3"]);
            int p5 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P5"]);
            int p7 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P7"]);
            int p9 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p9"]);
            int p11 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p11"]);
            int p13 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p13"]);
            int p15 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p15"]);
            int p17 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p17"]);
            int p19 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p19"]);
            int p21 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p21"]);
            int p23 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["p23"]);
            r3 = p3;
            r5 = p5;
            r7 = p7;
            r9 = p9;
            r11 = p11;
            r13 = p13;
            r15 = p15;
            r17 = p17;
            r19 = p19;
            r21 = p21;
            r23 = p23;

        }

        string sql14 = "insert into CELevel1(sender_mobileno,P3,P5,P7,P9,P11,P13,P15,P17,P19,P21,P23,send_date)values('" + userid + "','" + r3 + "','" + r5 + "','" + r7 + "','" + r9 + "','" + r11 + "','" + r13 + "','" + r15 + "','" + r17 + "','" + r19 + "','" + r21 + "','" + r23 + "','" + todaysDate + "')";
        int finaltotal = cc.ExecuteNonQuery(sql14);
        sql20 = "select usrMobileNo from usermaster where usrUserid='" + userid + "'";
        mobileno = cc.ExecuteScalar(sql20);
        messagesend = "Dear user calulation is Data*P3='" + r3 + "'*P5='" + r5 + "'*P7='" + r7 + "'*P9='" + r9 + "'*P11='" + r11 + "'*P13='" + r13 + "'*P15='" + r15 + "'*P17='" + r17 + "'*P19='" + r19 + "'*P21='" + r21 + "'*P23='" + r23 + "' thanks via www.myct.in";
        //cc.SendMessageTra(senderid, mobileno, messagesend);

    }
    #endregion DataKeyword

    //-----------------------------------------------------LongCode UpdateMessage To miscall Function-----------------------------------------------------

    #region LongCodeUpdateMessageTomiscall
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
    #endregion LongCodeUpdateMessageTomiscall

    //---------------------------------------------------------Check NCP keyword--------------------------------------------------------------------------

    #region NCPkeyword
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
            if (s == "NCP*" || s == "MPSC*" || s == "REG*" || s == "OM*" || s == "TTD*" || s == "ANNA*" || s == "RAVIDASSIA*" || s == "AGRO*" || s == "WSSD*" || s == "AMC*" || s == "DIDIMA*" || s == "DIDIMAA*" || s == "JAIN*" || s == "JANGID*" || s == "JB*" || s == "JM*" || s == "JNS*" || s == "MALI*" || s == "MHMSM*" || s == "MSS*" || s == "SAHU*" || s == "TELI*" || s == "NSSPUNE*" || s == "UDISE*")
            {
                break;
            }
            else if (s == "NCP " || s == "MPSC " || s == "REG " || s == "OM " || s == "TTD " || s == "ANNA " || s == "RAVIDASSIA " || s == "AGRO " || s == "WSSD " || s == "AMC " || s == "DIDIMA " || s == "DIDIMAA " || s == "JAIN " || s == "JANGID " || s == "JB " || s == "JM " || s == "JNS " || s == "MALI " || s == "MHMSM " || s == "MSS " || s == "SAHU " || s == "TELI " || s == "NSSPUNE")
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
    #endregion NCPkeyword

    //---------------------------------------------------------Check LokMat-------------------------------------------------------------------------------

    #region CheckLokmat
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
    #endregion CheckLokmat

    //---------------------------------------------------------School Keyword----------------------------------------------------------------------------

    #region  SchoolKeyword
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
            if (mkeyword1 == "AB" || mkeyword1 == "ABSENT" || mkeyword1 == "PR" || mkeyword1 == "PRESENT")
            {
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + MobileNo + "'";
                string EzeeSchoolCode = Convert.ToString(cc.ExecuteScalar(sql));
                if (EzeeSchoolCode != "")
                {
                    scID.getLongCodeSms(EzeeSchoolCode, MobileNo, smsBody, CurrenctDate, "");
                }
            }
            else if (mkeyword1 == "ALLSTU" || mkeyword1 == "ALLPAR" || mkeyword1 == "STUDENT" || mkeyword1 == "PARENT" || mkeyword1 == "HEADMASTER" || mkeyword1 == "HEAD MASTER" || mkeyword1 == "PRINCIPAL")
            {
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + MobileNo + "'";
                string EzeeSchoolCode = Convert.ToString(cc.ExecuteScalar(sql));
                if (EzeeSchoolCode != "")
                {
                    scID.getLongCodeSmsCommonMobile(EzeeSchoolCode, MobileNo, smsBody, CurrenctDate, "");
                }
            }
            else if (mkeyword1 == "CLASS1" || mkeyword1 == "CLASS2" || mkeyword1 == "CLASS3" || mkeyword1 == "CLASS4" || mkeyword1 == "CLASS5" || mkeyword1 == "CLASS6" || mkeyword1 == "CLASS7"
                     || mkeyword1 == "CLASS8" || mkeyword1 == "CLASS9" || mkeyword1 == "CLASS10" || mkeyword1 == "CLASS11" || mkeyword1 == "CLASS12")
            {
                string sql = "select School_CollegeID from UserMaster where usrMobileNo='" + MobileNo + "'";
                string EzeeSchoolCode = Convert.ToString(cc.ExecuteScalar(sql));
                if (EzeeSchoolCode != "")
                {
                    scID.getLongCodeSmsCommonClass(EzeeSchoolCode, MobileNo, smsBody, CurrenctDate, "");
                }
            }

        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                                      " ('" + smsBody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
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
    #endregion  SchoolKeyword

    //---------------------------------------------------------Registration REG and ---------------------------------------------------------------------

    ///<summary>
    ///REG ,YUVA, UVA, HEAD, WIFE, SON, DAUGHTER, FATHER, MOTHER, UDISE ,OM ,TTD ,NSSPune ,ANNA ,NCP ,MPSC, RAVIDASSIA 
    ///AGRO,WSSD,Agro,agro AMC,Amc,amc,DIDIMA    Didima,didima,DIDIMAA,Didimaa didimaa,JAIN,jain,Jain JANGID,Jangid,jangidJB jb,Jb,JM,Jm jm,JNS Jns jns
    ///MALI Mali mali MH MSMMhmsmmhmsm MSS Mss  mss SAHU Sahu sahu TELI Teli teli
    ///</summary>

    #region keywords
    public void RegisteredKeywordwithstar()
    {
        try
        {
            /////////////////////////////////////////////REG*Ketan Shinde*Pune*411041//////////////////////////
            if (mkeyword1.Contains("Reg") || mkeyword1.Contains("reg") || mkeyword1.Contains("REG"))
            {
                try
                {
                    string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
                    string getuserID = cc.ExecuteScalar(sqlget);
                    if (getuserID == "" || getuserID == null)
                    {
                        string[] FullName = SplitMsg[1].Split(' ');
                        string FName = Convert.ToString(FullName[0].Trim());
                        string LName = Convert.ToString(FullName[1].Trim());
                        string Address = Convert.ToString(SplitMsg[2]);
                        string PinCode = Convert.ToString(SplitMsg[3]);
                        //string EmailId = Convert.ToString(SplitMsg[3]);
                        string userid = System.Guid.NewGuid().ToString();
                        Random rnd = new Random();
                        string pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                        string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword,usrAddress,usrPIN)" +
                                 " values('" + userid + "','" + FName + "','" + LName + "','" + MobileNo + "','" + pwd + "','" + Address + "','" + PinCode + "')";
                        int ID = cc.ExecuteNonQuery(Sql);
                        if (ID == 1)
                        {
                            string myPassword = cc.DESDecrypt(pwd);
                            string MgsLength = "Dear " + FName + " " + LName + " Password for ur First Login is " + myPassword + " " + cc.AddSMS(MobileNo);
                            int smslength = MgsLength.Length;
                            cc.SendMessageRegistrationSMS("Website", MobileNo, MgsLength, smslength);
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    string NewSmsResp = "Dear User,Use Syntax REG*FirstName LastName*Address*Pincode Thanks Via www.myct.in";
                    smslength = NewSmsResp.Length;
                    cc.SendMessageRegistrationSMS("Website", MobileNo, NewSmsResp, smslength);
                }
            }

                //////////////////////////////////////////////////////*YUVA*Pooja k* 5digit*Pune//////////////////////////////////////
            //if mob not registered
            else if (mkeyword1.ToUpper().Trim() == "YUVA" || mkeyword1.ToUpper().Trim() == "UVA")
            {
                NotUVA_RegStudent();
            }
            ///////////////////////////////////////////////////////////
            else if ((mkeyword1 == "HEAD" || mkeyword1 == "WIFE" || mkeyword1 == "SON" || mkeyword1 == "DAUGHTER" || mkeyword1 == "FATHER" || mkeyword1 == "MOTHER"))
            {
                string fname = "", mname = "", lname = "", pincode = "", emailid = "", mymobile = "";
                string name = "", address = "";
                string[] namesplit;
                string[] arrplit = WholeMsg.Split('*');
                int arrlength = arrplit.Length;
                if (arrlength > 5)
                {
                    mymobile = arrplit[1].ToString();
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mymobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        smslength = passwordMessage.Length;
                        cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }
                }
                else if (arrlength > 4)
                {
                    mymobile = arrplit[1].ToString();
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mymobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        smslength = passwordMessage.Length;
                        cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }


                }
                else if (arrlength > 3)
                {
                    mymobile = arrplit[1].ToString();
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mymobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        smslength = passwordMessage.Length;
                        cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }
                }
                else if (arrlength > 2)
                {
                    mymobile = arrplit[1].ToString();
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mymobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        smslength = passwordMessage.Length;
                        cc.SendMessageLongCodeSMS("MobileLongCode", myMobileNo, passwordMessage, smslength);
                    }

                }
                else
                { }
                telisamaj();
            }
            //////////////////////////UDISE*Pooja katariya*AbhinavSoft Pune*411037
            else if (mkeyword1 == "UDISE" || mkeyword1 == "Udise" || mkeyword1 == "udise")
            {
                if (WholeMsg.Contains('*'))
                {
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
                            urUserRegBLLObj.usrMiddleName = mname;
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
                        //string emailid = mmsg[4];
                        urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.usrPIN = pincode;
                        urUserRegBLLObj.usrFirstName = fname;
                        urUserRegBLLObj.usrLastName = lname;
                        //urUserRegBLLObj.usrEmailId = emailid;
                        Random rnd = new Random();
                        urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                        status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                        if (status > 0)
                        {
                            //string senderId = "COM2MYCT";
                            string myMobileNo = urUserRegBLLObj.usrMobileNo;
                            string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                            string myName = urUserRegBLLObj.usrFirstName;
                            string thisDir = Server.MapPath("~");
                            string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                            string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                            smslength = NewSmsResp.Length;
                            cc.SendMessageLongCodeSMS("Longcode", myMobileNo, NewSmsResp, smslength);
                            // cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                            smsStatus = "Y";
                            emlTo = urUserRegBLLObj.usrEmailId;
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
                                    string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                    string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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


                    }
                }
                else
                {
                    key.SendKeywordSyntax(mkeyword1, mobile);
                }

            }

            ////////////////////////////////////////////////////////OM*Pooja k*Pune*411037//////////////////////////////////////////////////////
            else if (mkeyword1.Contains("Om") || mkeyword1.Contains("om") || mkeyword1.Contains("OM") || mkeyword1.Contains("TTD") || mkeyword1.Contains("Ttd"))
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
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("Longcode", myMobileNo, NewSmsResp, smslength);
                        // cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        smsStatus = "Y";
                        if (mkeyword1 == "OM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',34)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TTD")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',79)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    if (mkeyword1 == "OM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax OM*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("Longcode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "TTD")
                    {
                        string NewSmsResp = "Dear User,Use Syntax TTD*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("Longcode", mobile, NewSmsResp, smslength);
                    }

                }



            }

                /////////////////////////////////////NSSPune*Name*CollegeName Address*Pincode////////////////////////////
            else if (mkeyword1.Contains("NSSPune") || mkeyword1.Contains("NSSPUNE") || mkeyword1.Contains("Nsspune") || mkeyword1.Contains("nsspune"))
            {
                if (WholeMsg.Contains('*'))
                {

                    try
                    {
                        string fname = "", mname = "", lname = "", address = "", pincode = "", keyword = "", myName = "";
                        string[] namesplit;
                        int namelength;
                        mkeyword1 = mkeyword1.ToUpper();
                        string[] mmsg = WholeMsg.Split('*');
                        if (mmsg.Length > 3)
                        {
                            keyword = mmsg[0];
                            namesplit = mmsg[1].Split(' ');
                            namelength = namesplit.Length;
                            if (namelength > 2)
                            {
                                fname = namesplit[0];
                                mname = namesplit[1];
                                urUserRegBLLObj.usrMiddleName = mname;
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
                            address = mmsg[2];
                            pincode = mmsg[3];
                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            urUserRegBLLObj.usrMobileNo = mobile;
                            urUserRegBLLObj.usrAddress = address;
                            urUserRegBLLObj.usrPIN = pincode;
                            urUserRegBLLObj.usrFirstName = fname;
                            urUserRegBLLObj.usrLastName = lname;
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myMobileNo = urUserRegBLLObj.usrMobileNo;
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                                myName = urUserRegBLLObj.usrFirstName;

                                string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                                string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                                smslength = NewSmsResp.Length;
                                cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                                smsStatus = "Y";
                            }
                        }
                        else if (mmsg.Length > 2)
                        {
                            keyword = mmsg[0];
                            namesplit = mmsg[1].Split(' ');
                            namelength = namesplit.Length;
                            if (namelength > 2)
                            {
                                fname = namesplit[0];
                                mname = namesplit[1];
                                urUserRegBLLObj.usrMiddleName = mname;
                                lname = namesplit[2];

                            }
                            if (namelength > 1)
                            {
                                fname = namesplit[0];
                                lname = namesplit[1];
                            }
                            else
                            {
                            }
                            address = mmsg[2];

                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            urUserRegBLLObj.usrMobileNo = mobile;
                            urUserRegBLLObj.usrAddress = address;
                            urUserRegBLLObj.usrFirstName = fname;
                            urUserRegBLLObj.usrLastName = lname;
                            Random rnd1 = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd1.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {

                                string myMobileNo = urUserRegBLLObj.usrMobileNo;
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                                myName = urUserRegBLLObj.usrFirstName;

                                string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                                string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                                smslength = NewSmsResp.Length;
                                cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                                smsStatus = "Y";

                            }
                        }
                        else if (mmsg.Length > 1)
                        {
                            keyword = mmsg[0];
                            namesplit = mmsg[1].Split(' ');
                            namelength = namesplit.Length;
                            if (namelength > 2)
                            {
                                fname = namesplit[0];
                                mname = namesplit[1];
                                urUserRegBLLObj.usrMiddleName = mname;
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

                            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                            urUserRegBLLObj.usrMobileNo = mobile;
                            urUserRegBLLObj.usrFirstName = fname;
                            urUserRegBLLObj.usrLastName = lname;
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string myMobileNo = urUserRegBLLObj.usrMobileNo;
                                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                                myName = urUserRegBLLObj.usrFirstName;

                                string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                                string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                                smslength = NewSmsResp.Length;
                                cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                                smsStatus = "Y";
                            }


                        }
                        else { }



                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                        string NewSmsResp = "Dear User,Use Syntax NSSPUNE*ur Fname Lname*ur college name followed by ur detail address * ur 6 digit PIN code. Note * is must at 3 proper places. Send sms to 9243100142.";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);

                    }
                }
                else
                {
                    key.SendKeywordSyntax(mkeyword1, mobile);
                }

            }
            //////////////////////////////////////////ANNA*Pooja k*Pune*411037/////////////////////////////////////////////////////
            else if (mkeyword1.Contains("ANNA") || mkeyword1.Contains("Anna") || mkeyword1.Contains("anna"))
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
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        smsStatus = "Y";
                        if (mkeyword1 == "ANNA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',9)";
                            string a1 = cc.ExecuteScalar(sql);
                        }

                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax ANNA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    smslength = NewSmsResp.Length;
                    cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);

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
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                        smsStatus = "Y";
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax NCP*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    smslength = NewSmsResp.Length;
                    cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);

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
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");


                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/MPSC.aspx?crtevnt http://www.myct.in/MPSC.aspx?ict http://www.myct.in/MPSC.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                        smsStatus = "Y";
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax MPSC*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    smslength = NewSmsResp.Length;
                    cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);

                }

            }
            //////////////////////////////////RAVIDASSIA*Pooja k*Pune*411037////////////////////////////////////////////////
            else if (mkeyword1.Contains("RAVIDASSIA") || mkeyword1.Contains("Ravidassia") || mkeyword1.Contains("ravidassia"))
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
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                        smsStatus = "Y";
                        if (mkeyword1 == "RAVIDASSIA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',27)";
                            string a1 = cc.ExecuteScalar(sql);
                        }

                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax RAVIDASSIA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    smslength = NewSmsResp.Length;
                    cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);

                }

            }
            //////////////////////////////////////////////////////////////////AGRO*Pooja k*Pune*411037////////////////////////////////////////////

            else if (mkeyword1.Contains("AGRO") || mkeyword1.Contains("WSSD") || mkeyword1.Contains("Agro") || mkeyword1.Contains("agro") || mkeyword1.Contains("AMC") || mkeyword1.Contains("Amc") || mkeyword1.Contains("amc") || mkeyword1.Contains("DIDIMA") || mkeyword1.Contains("Didima") || mkeyword1.Contains("didima") || mkeyword1.Contains("DIDIMAA") || mkeyword1.Contains("Didimaa") || mkeyword1.Contains("didimaa") || mkeyword1.Contains("JAIN") || mkeyword1.Contains("jain") || mkeyword1.Contains("Jain") || mkeyword1.Contains("JANGID") || mkeyword1.Contains("Jangid") || mkeyword1.Contains("jangid") || mkeyword1.Contains("JB") || mkeyword1.Contains("jb") || mkeyword1.Contains("Jb") || mkeyword1.Contains("JM") || mkeyword1.Contains("Jm") || mkeyword1.Contains("jm") || mkeyword1.Contains("JNS") || mkeyword1.Contains("Jns") || mkeyword1.Contains("jns") || mkeyword1.Contains("MALI") || mkeyword1.Contains("Mali") || mkeyword1.Contains("mali") || mkeyword1.Contains("MHMSM") || mkeyword1.Contains("Mhmsm") || mkeyword1.Contains("mhmsm") || mkeyword1.Contains("MSS") || mkeyword1.Contains("Mss") || mkeyword1.Contains("mss") || mkeyword1.Contains("SAHU") || mkeyword1.Contains("Sahu") || mkeyword1.Contains("sahu") || mkeyword1.Contains("TELI") || mkeyword1.Contains("Teli") || mkeyword1.Contains("teli"))
            {
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
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", myMobileNo, NewSmsResp, smslength);
                        smsStatus = "Y";
                        if (mkeyword1 == "DIDIMA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',66)";
                            string a1 = cc.ExecuteScalar(sql);
                        }

                        else if (mkeyword1 == "DIDIMAA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',77)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JAIN")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',28)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JANGID")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',31)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JB")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',38)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',22)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JNS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',25)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MALI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',32)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MHMSM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',30)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MSS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',29)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "SAHU")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',41)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TELI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',39)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    if (mkeyword1 == "DIDIMA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax DIDIMA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "AGRO")
                    {
                        string NewSmsResp = "Dear User,Use Syntax AGRO*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "WSSD")
                    {
                        string NewSmsResp = "Dear User,Use Syntax WSSD*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "AMC")
                    {
                        string NewSmsResp = "Dear User,Use Syntax AMC*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "DIDIMAA")
                    {
                        string NewSmsResp = "Dear User,Use Syntax DIDIMAA*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "JAIN")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JAIN*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "JANGID")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JANGID*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "JB")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JB*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "JM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JM*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "JNS")
                    {
                        string NewSmsResp = "Dear User,Use Syntax JNS*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "MALI")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MALI*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "MHMSM")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MHMSM*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "MSS")
                    {
                        string NewSmsResp = "Dear User,Use Syntax MSS*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "SAHU")
                    {
                        string NewSmsResp = "Dear User,Use Syntax SAHU*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else if (mkeyword1 == "TELI")
                    {
                        string NewSmsResp = "Dear User,Use Syntax TELI*FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                        smslength = NewSmsResp.Length;
                        cc.SendMessageLongCodeSMS("LongCode", mobile, NewSmsResp, smslength);
                    }
                    else
                    {
                    }


                }
            }
        }

        catch { }
    }
    #endregion keywords

    //--------------------------------------------------------- Also Registration REG and ---------------------------------------------------------------

    #region Keyword2

    public void RegisteredKeywordwithstar1()
    {
        try
        {
            ///////////////////////////////////////REG Pooja k*Pune*41037/////////////////////////////////////
            if (mkeyword1.Contains("Reg") || mkeyword1.Contains("reg") || mkeyword1.Contains("REG"))
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
                        urUserRegBLLObj.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urUserRegBLLObj.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                        smsStatus = "Y";
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                smsStatus = "Y";
                                subject = "Mail From " + myName;
                                emlBody = "\n\n...www.myct.in";
                                ll.sendEmail(emlTo, subject, NewSmsResp);
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax REG FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    // comment by me   cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }

            /////////////////////////////////////////////////////////OM Pooja k*Pune*41037/////////////////////////////////////
            else if (mkeyword1.Contains("Om") || mkeyword1.Contains("om") || mkeyword1.Contains("OM") || mkeyword1.Contains("TTD") || mkeyword1.Contains("Ttd"))
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
                        urUserRegBLLObj.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urUserRegBLLObj.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    //int namelength = mmsg[0].Length;
                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");

                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        //Commented by me cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        smsStatus = "Y";
                        if (mkeyword1 == "OM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',34)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TTD")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',79)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                            smsStatus = "Y";
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                        urUserRegBLLObj.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urUserRegBLLObj.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');

                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        smsStatus = "Y";
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                            smsStatus = "Y";
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
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                        urUserRegBLLObj.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urUserRegBLLObj.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');

                    int namelength = mmsg1.Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/MPSC.aspx?crtevnt http://www.myct.in/MPSC.aspx?ict http://www.myct.in/MPSC.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        smsStatus = "Y";
                        if (mkeyword1 == "NCP")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                            smsStatus = "Y";
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
                                changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax MPSC FirstName LastName*Address*Pincode*Emailid Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }
            /////////////////////////////////ANNA Pooja k*Pune*41037////////////////////////////////////////////////////////////////////////////////////////////
            else if (mkeyword1.Contains("ANNA") || mkeyword1.Contains("Anna") || mkeyword1.Contains("anna"))
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
                        urUserRegBLLObj.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urUserRegBLLObj.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    //int namelength = mmsg[0].Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + fname + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        smsStatus = "Y";
                        if (mkeyword1 == "ANNA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',9)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax ANNA FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }
            /////////////////////////////////////////RAVIDASSIA Pooja k*Pune*41037/////////////////////////////////////

            else if (mkeyword1.Contains("RAVIDASSIA") || mkeyword1.Contains("Ravidassia") || mkeyword1.Contains("ravidassia"))
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
                        urUserRegBLLObj.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urUserRegBLLObj.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    //int namelength = mmsg[0].Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        smsStatus = "Y";
                        if (mkeyword1 == "RAVIDASSIA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',27)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    string NewSmsResp = "Dear User,Use Syntax RAVIDASSIA FirstName LastName*Address*Pincode*EmailId Thanks Via www.myct.in";
                    cc.SendMessageTra(senderId, mobile, NewSmsResp);
                }


            }

            ////////////////////////////////////////////////////////////AGRO Pooja k*Pune*41037/////////////////////////////////////


            else if (mkeyword1.Contains("AGRO") || mkeyword1.Contains("WSSD") || mkeyword1.Contains("Agro") || mkeyword1.Contains("agro") || mkeyword1.Contains("AMC") || mkeyword1.Contains("Amc") || mkeyword1.Contains("amc") || mkeyword1.Contains("DIDIMA") || mkeyword1.Contains("Didima") || mkeyword1.Contains("didima") || mkeyword1.Contains("DIDIMAA") || mkeyword1.Contains("Didimaa") || mkeyword1.Contains("didimaa") || mkeyword1.Contains("JAIN") || mkeyword1.Contains("jain") || mkeyword1.Contains("Jain") || mkeyword1.Contains("JANGID") || mkeyword1.Contains("Jangid") || mkeyword1.Contains("jangid") || mkeyword1.Contains("JB") || mkeyword1.Contains("jb") || mkeyword1.Contains("Jb") || mkeyword1.Contains("JM") || mkeyword1.Contains("Jm") || mkeyword1.Contains("jm") || mkeyword1.Contains("JNS") || mkeyword1.Contains("Jns") || mkeyword1.Contains("jns") || mkeyword1.Contains("MALI") || mkeyword1.Contains("Mali") || mkeyword1.Contains("mali") || mkeyword1.Contains("MHMSM") || mkeyword1.Contains("Mhmsm") || mkeyword1.Contains("mhmsm") || mkeyword1.Contains("MSS") || mkeyword1.Contains("Mss") || mkeyword1.Contains("mss") || mkeyword1.Contains("SAHU") || mkeyword1.Contains("Sahu") || mkeyword1.Contains("sahu") || mkeyword1.Contains("TELI") || mkeyword1.Contains("Teli") || mkeyword1.Contains("teli"))
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
                        urUserRegBLLObj.usrEmailId = emailid;
                    }
                    else if (pinmessagelength > 2)
                    {
                        address = mmsg[1];
                        pincode = mmsg[2];
                        emailid = "";
                        urUserRegBLLObj.usrEmailId = emailid;

                    }
                    string[] mmsg1 = mmsg[0].Split(' ');
                    int namelength = mmsg1.Length;
                    //int namelength = mmsg[0].Length;
                    if (namelength > 3)
                    {
                        string key = mmsg1[0];
                        fname = mmsg1[1];
                        mname = mmsg1[2];
                        urUserRegBLLObj.usrMiddleName = mname;
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
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrPIN = pincode;
                    urUserRegBLLObj.usrFirstName = fname;
                    urUserRegBLLObj.usrLastName = lname;
                    urUserRegBLLObj.usrAddress = address;
                    urUserRegBLLObj.usrEmailId = emailid;
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        //string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + fname + ", Password for ur First Login is " + myPassword + " ";
                        if (mkeyword1 == "JM" || mkeyword1 == "jm")
                            mkeyword1 = "Maheshwari";
                        string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                        cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                        smsStatus = "Y";
                        if (mkeyword1 == "DIDIMA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',66)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "DIDIMAA")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',77)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JAIN")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',28)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JANGID")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',31)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JB")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',38)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',22)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "JNS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',25)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MALI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',32)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MHMSM")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',30)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "MSS")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',29)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "SAHU")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',41)";
                            string a1 = cc.ExecuteScalar(sql);
                        }
                        else if (mkeyword1 == "TELI")
                        {
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',39)";
                            string a1 = cc.ExecuteScalar(sql);
                        }

                        emlTo = urUserRegBLLObj.usrEmailId;
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
        }

        catch { }
    }

    #endregion Keyword2

    //--------------------------------------------------------- Also 2 Registration REG and -------------------------------------------------------------

    #region Keyword3
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                urUserRegBLLObj.usrMobileNo = mobile;
                urUserRegBLLObj.usrPIN = newnewpin;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urUserRegBLLObj.usrFirstName = mmmsg1;
                urUserRegBLLObj.usrLastName = mmmsg2;
                urUserRegBLLObj.usrCityId = 37;

                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                if (status == 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;

                    string myName = urUserRegBLLObj.usrFirstName;

                    string passwordMessage = "Dear " + myName + ",  you are already registered with come2mycity " + cc.AddSMS(myMobileNo);
                    cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                    cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        //string myprefix = urUserRegBLLObj.UsrPrefix;
                        //string mypostfix = urUserRegBLLObj.UsrPostfix;
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);


                        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                        smsStatus = "Y";
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                urUserRegBLLObj.usrMobileNo = mobile;
                urUserRegBLLObj.usrPIN = newnewpin;
                urUserRegBLLObj.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urUserRegBLLObj.usrFirstName = mmmsg1;
                urUserRegBLLObj.usrLastName = mmmsg2;
                urUserRegBLLObj.usrCityId = 37;


                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                    string myName = urUserRegBLLObj.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "OM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',34)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "TTD")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',79)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    emlTo = urUserRegBLLObj.usrEmailId;
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
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                urUserRegBLLObj.usrMobileNo = mobile;
                urUserRegBLLObj.usrPIN = newnewpin;
                urUserRegBLLObj.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urUserRegBLLObj.usrFirstName = mmmsg1;
                urUserRegBLLObj.usrLastName = mmmsg2;
                urUserRegBLLObj.usrCityId = 37;


                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                    string myName = urUserRegBLLObj.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    //string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    //string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 & ur login pswd fr www.myct.in is " + myPassword + " ";
                    string NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + myPassword + " ";
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "NCP")
                    {
                        string sql11 = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',6)";
                        string a = cc.ExecuteScalar(sql11);
                    }
                    emlTo = urUserRegBLLObj.usrEmailId;
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
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                urUserRegBLLObj.usrMobileNo = mobile;
                urUserRegBLLObj.usrPIN = newnewpin;
                urUserRegBLLObj.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urUserRegBLLObj.usrFirstName = mmmsg1;
                urUserRegBLLObj.usrLastName = mmmsg2;
                urUserRegBLLObj.usrCityId = 37;


                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                    string myName = urUserRegBLLObj.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "ANNA")
                    {
                        string sql11 = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',9)";
                        string a = cc.ExecuteScalar(sql11);
                    }
                    emlTo = urUserRegBLLObj.usrEmailId;

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
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                urUserRegBLLObj.usrMobileNo = mobile;
                urUserRegBLLObj.usrPIN = newnewpin;
                urUserRegBLLObj.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urUserRegBLLObj.usrFirstName = mmmsg1;
                urUserRegBLLObj.usrLastName = mmmsg2;
                urUserRegBLLObj.usrCityId = 37;


                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                    string myName = urUserRegBLLObj.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "RAVIDASSIA")
                    {
                        string sql11 = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',27)";
                        string a = cc.ExecuteScalar(sql11);
                    }
                    emlTo = urUserRegBLLObj.usrEmailId;
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
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                urUserRegBLLObj.usrMobileNo = mobile;
                urUserRegBLLObj.usrPIN = newnewpin;
                urUserRegBLLObj.usrEmailId = emlTo;
                string[] mesgName = mmmsg1.Split(' ');
                int lenght1 = mesgName.Length;
                if (lenght1 > 1)
                {
                    mmmsg1 = mesgName[0];
                    mmmsg2 = mesgName[1];
                }
                urUserRegBLLObj.usrFirstName = mmmsg1;
                urUserRegBLLObj.usrLastName = mmmsg2;
                urUserRegBLLObj.usrCityId = 37;


                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                    string myName = urUserRegBLLObj.usrFirstName;
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " ";
                    if (mkeyword1 == "JM" || mkeyword1 == "jm")
                        mkeyword1 = "Maheshwari";
                    string NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms." + passwordMessage + cc.AddSMS(myMobileNo);
                    cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
                    if (mkeyword1 == "DIDIMA")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',66)";
                        string a1 = cc.ExecuteScalar(sql);
                    }

                    else if (mkeyword1 == "DIDIMAA")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',77)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JAIN")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',28)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JANGID")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',31)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JB")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',38)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',22)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "JNS")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',25)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MALI")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',32)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MHMSM")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',30)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "MSS")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',29)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "SAHU")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',41)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    else if (mkeyword1 == "TELI")
                    {
                        string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',39)";
                        string a1 = cc.ExecuteScalar(sql);
                    }
                    emlTo = urUserRegBLLObj.usrEmailId;
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
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                string myMobileNo = urUserRegBLLObj.usrMobileNo;
                string NewSmsResp = "Dear please use proper Syntax " + cc.AddSMS(myMobileNo);
                cc.SendMessageTra(senderId, myMobileNo, NewSmsResp);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion Keyword3

    //////////////////////////////////////End of Keyword space Name space Address space Pincode//////////////////////////////////////

    //Keyword which is already registered

    //--------------------------------------------------------- All normal KeyWords-------- -------------------------------------------------------------

    #region normalKeyword
    public void NormalKeyword()
    {
        // string ctnm = "", dtnm = "", stnm = "";

        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
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
                    if (WholeMsg.Contains(' '))
                    {
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.usrMessageString = message1;
                        CopyGroupByKeyWord(urUserRegBLLObj);
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                //////////End////

                else if (mkeyword1 == "REMOVE" || mkeyword1 == "Remove" || mkeyword1 == "remove")
                {
                    if (WholeMsg.Contains(' '))
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
                        removeKewWord(mobile, frmobile, urUserRegBLLObj);
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                ////////End/////////

                else if (mkeyword1 == "BLOG" || mkeyword1 == "Blog" || mkeyword1 == "blog")
                {
                    if (WholeMsg.Contains(' '))
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
                            SaveBlog(kwdBlog, mobile, blog, urUserRegBLLObj);
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }

               /////End////

                else if (mkeyword1 == "NAME" || mkeyword1 == "Name" || mkeyword1 == "name")
                {
                    if (WholeMsg.Contains(' '))
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
                            urUserRegBLLObj.usrMobileNo = mobile;
                            urUserRegBLLObj.usrFirstName = mmmsg0;
                            urUserRegBLLObj.usrLastName = mmmsg1;
                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                            if (status == 0)
                            {
                                UpdateName(urUserRegBLLObj);
                            }
                        }
                        else
                        {
                            urUserRegBLLObj.usrMobileNo = mobile;
                            urUserRegBLLObj.usrFirstName = mmmsg0;

                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                            if (status == 0)
                            {
                                UpdateFirstName(urUserRegBLLObj);
                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                //////////////End//////////////

                else if (mkeyword1 == "BAL" || mkeyword1 == "Bal" || mkeyword1 == "bal")
                {
                    status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                    urUserRegBLLObj.usrMobileNo = mobile;
                    if (status == 0)
                    {
                        smsBalKeyword(urUserRegBLLObj);
                    }
                }
                ////newchanges
                else if (mkeyword1 == "BALANCE" || mkeyword1 == "Balance" || mkeyword1 == "balance")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        urUserRegBLLObj.usrMobileNo = mobile;
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
                            FillBalKeyword1(fromMo, toMo, transamt, promoamt, urUserRegBLLObj);
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                ////////////////////////////////////////////////////////////
                else if (mkeyword1 == "DND" || mkeyword1 == "dnd" || mkeyword1 == "Dnd")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        string[] arr = message1.Split(' ');
                        urUserRegBLLObj.usrMobileNo = mobile;
                        string dnd = arr[0].ToString();
                        if (dnd == "0" || dnd == "1" || dnd == "2" || dnd == "3" || dnd == "4" || dnd == "5" || dnd == "6" || dnd == "7")
                        {
                            urUserRegBLLObj.usrDND = Convert.ToInt32(dnd.ToString());
                        }
                        if (status == 0)
                        {
                            setDNDbyLongCode(urUserRegBLLObj);
                        }
                    }
                    else
                    {
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                //////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "CMNO" || mkeyword1 == "Cmno" || mkeyword1 == "C.M.N." || mkeyword1 == "cmno" || mkeyword1 == "CMN" || mkeyword1 == "Cmn" || mkeyword1 == "cmn")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        if (message1.Length >= 10)
                        {
                            urUserRegBLLObj.usrAltMobileNo = mobile;
                            urUserRegBLLObj.usrMobileNo = message1;
                            Random rnd = new Random();
                            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitialByLc(urUserRegBLLObj);
                            if (status == 0)
                            {
                                changeMobileNoByLongCode(urUserRegBLLObj);
                                string ID, category, userId;
                                string sql = "select  usrUserId,School_CollegeID,PersonCategory from UserMaster where usrMobileNo='" + urUserRegBLLObj.usrMobileNo + "'";
                                DataSet ds = cc.ExecuteDataset(sql);
                                ID = Convert.ToString(ds.Tables[0].Rows[0]["School_CollegeID"]);
                                category = Convert.ToString(ds.Tables[0].Rows[0]["PersonCategory"]);
                                userId = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                                scID.getChangeMobileNo(ID, urUserRegBLLObj.usrMobileNo, urUserRegBLLObj.usrAltMobileNo, category, userId);
                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);

                    }
                }
                //////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "ADDRESS" || mkeyword1 == "Address" || mkeyword1 == "address" || mkeyword1 == "add" || mkeyword1 == "Add" || mkeyword1 == "ADD")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.usrAddress = message1;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            UpdateAddressByLongCode(urUserRegBLLObj, iii);
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                /////////////////////////////////////////////////////////////////////////
                //else if (mkeyword1 == "V" || mkeyword1 == "P" || mkeyword1 == "G")
                //{
                //    urUserRegBLLObj.usrMobileNo = mobile;
                //    urUserRegBLLObj.usrCategory = message1;
                //    status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                //    if (status == 0)
                //    {
                //        UpdateAddressByLongCode(urUserRegBLLObj, iii);
                //    }

                //}
                /////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "M" || mkeyword1 == "F")
                {
                    if (mkeyword1 == "M")
                    {
                        mkeyword1 = "Male";
                        urUserRegBLLObj.usrGender = mkeyword1;
                    }
                    else
                    {

                        mkeyword1 = "Female";
                        urUserRegBLLObj.usrGender = mkeyword1;
                    }
                    urUserRegBLLObj.usrMobileNo = mobile;
                    status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                    if (status == 0)
                    {
                        status = urUserRegBLLObj.BLLInsertGender(urUserRegBLLObj);
                        if (status > 0)
                        {
                            string Message = "Your data got updated successfully www.myct.in";
                            smslength = Message.Length;
                            cc.SendMessageLongCodeSMS("LongCode", mobile, Message, smslength);
                        }

                    }

                }
                ////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "DOB" || mkeyword1 == "Dob" || mkeyword1 == "dob")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.usrDOB = message1;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            UpdateDOBByLongCode(urUserRegBLLObj);
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                //////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "@" || mkeyword1 == "EMAIL" || mkeyword1 == "email" || mkeyword1 == "Email" || mkeyword1 == "E-MAIL" || mkeyword1 == "e-mail" || mkeyword1 == "E-mail")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.usrEmailId = message1;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            UpdateEmailByLongCode(urUserRegBLLObj);
                            //RecoverPasswordByLongCode(urUserRegBLLObj);
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                ///////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "AREA" || mkeyword1 == "Area" || mkeyword1 == "area" || mkeyword1 == "VILLAGE" || mkeyword1 == "Village" || mkeyword1 == "village")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.usrArea = message1;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            UpdateAreaByLongCode(urUserRegBLLObj);
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                ///////////////////////////////////////////////////////////////

                else if (mkeyword1 == "Pin" || mkeyword1 == "pin" || mkeyword1 == "PIN" || mkeyword1 == "PINCODE" || mkeyword1 == "Pincode" || mkeyword1 == "pincode")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        urUserRegBLLObj.usrMobileNo = mobile;
                        string[] arrPin = message1.Split(' ');
                        if (arrPin.Length >= 0)
                        {
                            urUserRegBLLObj.usrPIN = arrPin[0].ToString();
                            urUserRegBLLObj.usrFirstName = "";
                            urUserRegBLLObj.usrLastName = "";
                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                            if (status == 0)
                            {
                                UpdatePinByLongCode(urUserRegBLLObj);
                            }
                            else
                            {
                                string mobileNo = urUserRegBLLObj.usrMobileNo;
                                string smsString = "Dear user first register on www.come2myCity.com." + cc.AddSMS(mobileNo);
                                string senderId = "COM2MYCT";

                                cc.SendMessage1(senderId, mobileNo, smsString);
                                smsStatus = "Y";
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                            string mobileNo = urUserRegBLLObj.usrMobileNo;
                            string smsErrString = "Dear user please send SMS as PIN/Pin/pin <SPACE> VALID SIX DIGIT PIN CODE." + cc.AddSMS(mobileNo);
                            string senderId = "COM2MYCT";

                            cc.SendMessage1(senderId, mobileNo, smsErrString);
                            smsStatus = "Y";
                            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }


                }
                ///////////////////////////////////////////////////////////////////////////
                else if (mkeyword1 == "DELETE ME" || mkeyword1 == "Delete Me" || mkeyword1 == "delete me")
                {
                    urUserRegBLLObj.usrMobileNo = mobile;
                    DeleteUserKeyWord(urUserRegBLLObj);
                }
                ///////////////////////////////////////////////////////////

                else if (mkeyword1.Contains("FRIEND") || mkeyword1.Contains("Friend") || mkeyword1.Contains("friend") || mkeyword1.Contains("RELATIVE") || mkeyword1.Contains("Relative") || mkeyword1.Contains("relative") || mkeyword1.Contains("frnd") || mkeyword1.Contains("Frnd") || mkeyword1.Contains("FRND") || mkeyword1.Contains("FRIENDS") || mkeyword1.Contains("friends") || mkeyword1.Contains("Friends"))
                {
                    if (WholeMsg.Contains(' '))
                    {
                        string[] msgSplits = message1.Split(' ');
                        urUserRegBLLObj.usrMobileNo = mobile;
                        if (msgSplits.Length > 2)
                        {
                            urUserRegBLLObj.usrAltMobileNo = msgSplits[0];
                            urUserRegBLLObj.frnrelFrnRelName = msgSplits[1];
                            urUserRegBLLObj.usrLastName = msgSplits[2];
                        }
                        else if (msgSplits.Length > 1)
                        {
                            urUserRegBLLObj.usrAltMobileNo = msgSplits[0];
                            urUserRegBLLObj.frnrelFrnRelName = msgSplits[1];

                        }
                        else if (msgSplits.Length > 0)
                        {
                            urUserRegBLLObj.usrAltMobileNo = msgSplits[0];
                        }
                        if (urUserRegBLLObj.usrAltMobileNo.Length == 10)
                        {
                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                            if (status == 0)
                            {   //Mahesh: Send second parameter for only send sms only, because at run time mobile number of sender change.
                                AddFriendByLongCode(urUserRegBLLObj, mobile);
                            }
                        }
                        else
                        {
                            string senderId = "COM2MYCT";
                            string myMobileNo = urUserRegBLLObj.usrMobileNo;
                            string passwordMessage = "Dear user please enter valid mobile number." + cc.AddSMS(myMobileNo);
                            cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                            smsStatus = "Y";
                            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                /////////////////////////////////////////////////////////////////////////
                else if (mkeyword1 == "MSEB" || mkeyword1 == "Mseb" || mkeyword1 == "mseb")
                {

                    if (WholeMsg.Contains(' '))
                    {
                        string sql11 = "select usrUserId from UserMaster where usrMobileNo='" + mobile + "'";
                        string UserId = cc.ExecuteScalar(sql11);

                        if (UserId != null && UserId != "")
                        {
                            sql11 = "Insert into UserConsumer (UserID,ConsumerNo) values('" + UserId + "','" + message1 + "')";
                            cc.ExecuteNonQuery(sql11);
                            string senderId = "MYCT.IN";
                            string myMobileNo = mobile.ToString();
                            //string myName = urUserRegBLLObj.usrFirstName;
                            string sqlquery = "select usrFirstName +' '+ usrLastName as name from UserMaster where usrMobileNo='" + mobile + "'";
                            string UserName = cc.ExecuteScalar(sqlquery);

                            string passwordMessage = "Dear " + UserName + " your consumer number is updated successfully. " + cc.AddSMS(myMobileNo);
                            string NewMscbRespMsg = "Dear " + UserName.ToString() + " ur electric meter con no. is updated successfully thanks.via www.myct.in";
                            cc.SendMessageTra(senderId, myMobileNo, NewMscbRespMsg);
                            smsStatus = "Y";
                            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "PASSWORD" || mkeyword1 == "Password" || mkeyword1 == "password" || mkeyword1 == "PASS" || mkeyword1 == "Pass" || mkeyword1 == "pass"))
                {
                    urUserRegBLLObj.usrMobileNo = mobile;
                    status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                    if (status == 0)
                    {
                        RecoverPasswordByLongCode(urUserRegBLLObj);
                    }
                }

                    ////////////////////////////////

                else if (mkeyword1 == "UID")
                {
                    if (WholeMsg.Contains(' '))
                    {

                        string[] arr = WholeMsg.Split(' ');
                        string uid = arr[1];
                        urUserRegBLLObj.usrBestFeature = uid;
                        urUserRegBLLObj.usrMobileNo = mobile;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            status = urUserRegBLLObj.BLLInsertUID(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string message = "Aadhar Card got updated successfully www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                            }
                        }

                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "VID")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        string[] arr = WholeMsg.Split(' ');
                        string uid = arr[1];
                        urUserRegBLLObj.usrBuild = uid;
                        urUserRegBLLObj.usrMobileNo = mobile;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            status = urUserRegBLLObj.BLLInsertVID(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string message = "Voting Card got updated successfully www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                            }
                        }
                    }
                    else
                    {
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "JOB")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        string[] arr = WholeMsg.Split(' ');
                        string job = arr[1];
                        urUserRegBLLObj.usrCarrerInterest = job;
                        urUserRegBLLObj.usrMobileNo = mobile;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            status = urUserRegBLLObj.BLLInsertJob(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string message = "Voting Card got updated successfully www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                            }
                        }
                    }
                    else
                    {
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                //////////////////////////////////////////////////////

                else if (mkeyword1 == "PAN")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        string[] arr = WholeMsg.Split(' ');
                        string job = arr[1];
                        urUserRegBLLObj.usrPoliticalView = job;
                        urUserRegBLLObj.usrMobileNo = mobile;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            status = urUserRegBLLObj.BLLInsertPan(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string message = "PanCard number got updated successfully www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                            }
                        }
                    }
                    else
                    {
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "DLN")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        string[] arr = WholeMsg.Split(' ');
                        string job = arr[1];
                        urUserRegBLLObj.usrIdealMatch = job;
                        urUserRegBLLObj.usrMobileNo = mobile;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            status = urUserRegBLLObj.BLLInsertDrivingLic(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string message = "Driving License number got updated successfully www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                            }
                        }
                    }
                    else
                    {
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ////////////////////////////////////////
                else if (mkeyword1 == "MOBILE2")
                {
                    if (WholeMsg.Contains(' '))
                    {
                        string[] arr = WholeMsg.Split(' ');
                        string job = arr[1];
                        urUserRegBLLObj.usrAltMobileNo = job;
                        urUserRegBLLObj.usrMobileNo = mobile;
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            status = urUserRegBLLObj.BLLInsertAlternateNo(urUserRegBLLObj);
                            if (status > 0)
                            {
                                string message = "Driving License number got updated successfully www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                            }
                        }
                    }
                    else
                    {
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ///////////////////////////////////////////////////////////////////


                else if ((mkeyword1 == "PASSWORD" || mkeyword1 == "Password" || mkeyword1 == "password" || mkeyword1 == "PASS" || mkeyword1 == "Pass" || mkeyword1 == "pass") && (message1 != ""))
                {
                    if (WholeMsg.Contains(' '))
                    {
                        urUserRegBLLObj.usrMobileNo = mobile;
                        int pln = message1.Length;
                        message1 = message1.Remove(pln - 1);
                        urUserRegBLLObj.usrMessageString = message1.ToString();
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            ReeSetPass(urUserRegBLLObj);
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if (mkeyword1 == "REPORT")
                {
                    if (WholeMsg.Contains('*'))
                    {
                        string[] wholemsgsplit = WholeMsg.Split('*');
                        string message = wholemsgsplit[1].ToString();
                        string date = shortcode;
                        string sql = "insert into dailyreport(Report,DateTime)values('" + message + "','" + date + "')";
                        string a = cc.ExecuteScalar(sql);
                        message = "Your Daily Report got updated Thanks via www.myct.in";
                        smslength = message.Length;
                        cc.SendMessageMobileLongCodeSMS("LongCode", mobile, message, smslength);
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                /////////////////////////////////////////////////////////////mkeyword1 == "MDM"
                else if (mkeyword1 == "ATND" || mkeyword1 == "DAR" || mkeyword1 == "CAR" || mkeyword1 == "STAFF" || mkeyword1 == "JRLIST" || mkeyword1 == "TEACHER" || mkeyword1 == "HM" || mkeyword1 == "CH" || mkeyword1 == "CMN")
                {
                    if (WholeMsg.Contains('*'))
                    {
                        Datakeyword();
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                        Datakeyword();
                    }
                }
                else if (mkeyword1 == "GETRECORD" || mkeyword1 == "GETRECORD1")
                {
                    Datakeyword();
                }
                ///////////////////////////////////////////////
                else if (mkeyword1 == "CHANELSMS")
                {
                    if (WholeMsg.Contains('*'))
                    {
                        string[] wholemsgsplit = WholeMsg.Split('*');
                        string message = wholemsgsplit[1];
                        string sql = "select friendid  from AdminSubMarketingSubUser right outer join UserMaster " +
                                " on UserMaster.usrUserId = AdminSubMarketingSubUser.userid " +
                                " where usrMobileNo='" + mobile + "'";
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
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }


                }

                /////////////////////////////////////////////////////////

                else if ((mkeyword1 == "set-group0-missed-call-sms-to" || mkeyword1 == "Set-group0-missed-call-sms-to" || mkeyword1 == "SET-GROUP0-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
                                int messagecount = newmsg.Length;
                                if (messagecount <= 160)
                                {
                                    count = 1;
                                }
                                else if (messagecount >= 160)
                                {
                                    count = 2;
                                }
                                else if (messagecount >= 306)
                                {
                                    count = 3;
                                }
                                else if (messagecount >= 459)
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
                                    " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',0)";
                                int exe = cc.ExecuteNonQuery(query);
                                string message = "Your Message Updated Successfully of Group 0 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo='" + mobile + "'";
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }


                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                /////////////////////////////
                else if ((mkeyword1 == "set-group1-missed-call-sms-to" || mkeyword1 == "Set-group1-missed-call-sms-to" || mkeyword1 == "SET-GROUP1-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                    " values('" + userid + "','" + simno + "','" + newmsg + "','" + date + "','" + MsgStatus + "','" + messagecount + "','" + id + "','" + count + "',1)";
                                int exe = cc.ExecuteNonQuery(query);
                                string message = "Your Message Updated Successfully of Group 1 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                //////////////////////////////
                else if ((mkeyword1 == "set-group2-missed-call-sms-to" || mkeyword1 == "Set-group2-missed-call-sms-to" || mkeyword1 == "SET-GROUP2-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 2 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ///////////////////////////////////////
                else if ((mkeyword1 == "set-group3-missed-call-sms-to" || mkeyword1 == "Set-group3-missed-call-sms-to" || mkeyword1 == "SET-GROUP3-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 3 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ////////////////////////////////////////////////////
                else if ((mkeyword1 == "set-group4-missed-call-sms-to" || mkeyword1 == "Set-group4-missed-call-sms-to" || mkeyword1 == "SET-GROUP4-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 4 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ////////////////////////////////////////////////
                else if ((mkeyword1 == "set-group5-missed-call-sms-to" || mkeyword1 == "Set-group5-missed-call-sms-to" || mkeyword1 == "SET-GROUP5-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 5 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                ///////////////////////////////////////////////////////////////
                else if ((mkeyword1 == "set-group6-missed-call-sms-to" || mkeyword1 == "Set-group6-missed-call-sms-to" || mkeyword1 == "SET-GROUP6-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 6 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                //////////////////////////////////////////
                else if ((mkeyword1 == "set-group7-missed-call-sms-to" || mkeyword1 == "Set-group7-missed-call-sms-to" || mkeyword1 == "SET-GROUP7-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 7 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }

                }
                ///////////////////////////////////////////////
                else if ((mkeyword1 == "set-group8-missed-call-sms-to" || mkeyword1 == "Set-group8-missed-call-sms-to" || mkeyword1 == "SET-GROUP8-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 8 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                //////////////////////////////////////////
                else if ((mkeyword1 == "set-group9-missed-call-sms-to" || mkeyword1 == "Set-group9-missed-call-sms-to" || mkeyword1 == "SET-GROUP9-MISSED-CALL-SMS-TO"))
                {
                    if (WholeMsg.Contains('*'))
                    {
                        String date = System.DateTime.Now.ToString();
                        int count = 0;
                        string[] msg = WholeMsg.Split('*');
                        string KeywordName = msg[0];
                        KeywordName = KeywordName.ToUpper();
                        string sql12 = "select reg_id from LongCodeRegistration where mobileno='" + mobile + "'";
                        string id = cc.ExecuteScalar(sql12);
                        if (id == "" || id == null)
                        {
                        }
                        else
                        {
                            sql12 = "select mobileno from LongCodeRegistration where mobileno='" + mobile + "'";
                            string contactno = cc.ExecuteScalar(sql12);
                            if (contactno == mobile)
                            {
                                string query = "select usrUserid from usermaster where usrMobileNo='" + contactno + "'";
                                string userid = cc.ExecuteScalar(query);
                                string newmsg = "" + msg[1] + " www.myct.in";
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
                                string message = "Your Message Updated Successfully of Group 9 Thanks via www.myct.in";
                                smslength = message.Length;
                                cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                query = "select smsbal from usermaster where usrMobileNo=" + mobile;
                                int balance = cc.ExecuteNonQuery(query);
                                if (balance > 1)
                                {
                                    cc.SendMessageLongCodeSMS("LongCode", mobile, message, smslength);
                                    balance = balance - 1;
                                    query = "update usermaster set smsbal='" + balance + "' where usrMobileNo='" + mobile + "'";
                                    int a1 = cc.ExecuteNonQuery(query);
                                }

                            }
                        }
                    }
                    else
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        key.SendKeywordSyntax(mkeyword1, mobile);
                    }
                }
                //////////////////////////////////////////////////
                else if (checkGroupSMSCode(mkeyword1) == 1)
                {

                    urUserRegBLLObj.usrMobileNo = mobile;
                    string[] smsLongCode = message1.Split(' ');
                    if (smsLongCode[0].ToString() == mkeyword1.ToString())
                    {
                        urUserRegBLLObj.longCodegrSMS = message1.ToString();
                    }
                    else
                    {
                        urUserRegBLLObj.longCodegrSMS = mkeyword1 + " " + message1.ToString();
                    }

                    status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                    if (status == 0)
                    {

                        SendMessagetoAllLongCode(urUserRegBLLObj);

                    }


                }

               //////////////////////////////////////////////////////////////////////


                else if (checPGr(mkeyword1.ToString()))
                {
                    string APSTR = "";
                    urUserRegBLLObj.usrMobileNo = mobile;

                    status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
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

                            //AddFriendByLongCodeF(urUserRegBLLObj, mobile, grId);
                        }
                        urUserRegBLLObj.longCodegrSMS = grId + " " + message1;
                        SendMessageToAllStuPAByLongCode(urUserRegBLLObj, mobile, grId, APSTR);
                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////////
                ////////////// To add friends through longcode
                else if (checkGr(mkeyword1.ToString()))
                {
                    string[] msgSplits = message1.Split(' ');

                    urUserRegBLLObj.usrMobileNo = mobile;
                    if (msgSplits.Length > 2)
                    {
                        urUserRegBLLObj.usrAltMobileNo = msgSplits[0];
                        urUserRegBLLObj.frnrelFrnRelName = msgSplits[1];
                        urUserRegBLLObj.usrLastName = msgSplits[2];
                    }
                    else if (msgSplits.Length > 1)
                    {
                        urUserRegBLLObj.usrAltMobileNo = msgSplits[0];
                        urUserRegBLLObj.frnrelFrnRelName = msgSplits[1];
                    }
                    else if (msgSplits.Length > 0)
                    {
                        urUserRegBLLObj.usrAltMobileNo = msgSplits[0];
                    }
                    if (urUserRegBLLObj.usrAltMobileNo.Length == 10)
                    {
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
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
                            AddFriendByLongCodeF(urUserRegBLLObj, mobile, grId);
                        }
                    }
                    else
                    {

                        string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string passwordMessage = "Dear user please enter valid mobile number." + cc.AddSMS(myMobileNo);
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        smsStatus = "Y";
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }
                    }
                }
                //(mkeyword1 == "CHARA" || mkeyword1 == "Chara" || mkeyword1 == "chara")
                /////////////////////Chara Keyword not in use///////////////////////////////////////////////////////////////////////////////////
                //else if (mkeyword1 == "ADM" || mkeyword1 == "MDM")
                //{
                //    string Mobile = "";
                //    try
                //    {
                //        mkeyword1 = mkeyword1.ToUpper();
                //        Mobile = mobile.ToString();
                //        string sender = "myctin";
                //        string senderid = "myctin";
                //        DateTime date = DateTime.Now;
                //        string todaysDate = date.ToShortDateString();
                //        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                //        if (status < 1)
                //        {
                //            //if (WholeMsg == "Chara" || WholeMsg == "CHARA" || WholeMsg == "chara")
                //            //{
                //            //    backUsrResponse = "Dear Plz use proper syntax CHARA*depo code*kastagar*xxx*small*xxx*big*xxx*ola/suka*xxxx*dhep*xxx Note: 1) use nos only in place of Depo Code & all xxx. If no value then use 0 2)don't change sequence 3) use * as given every where 4) always send message to 9243100142 thanks via www.myct.in";
                //            //    cc.SendMessageTra(sender, Mobile, backUsrResponse);
                //            //}
                //            if (WholeMsg == "ADM" || WholeMsg == "adm" || WholeMsg == "Adm")
                //            {
                //                backUsrResponse = "Adm*1*A*RB*45*RG*20# 2*A*RB*45*RG*20# 3*A*RB*45*RG*20# 4*A*RB*45*RG*20# 5*A*RB*45*RG*20# 6*A*RB*45*RG*20# 7*A*RB*45*RG*20# 8*A*RB*45*RG*20 www.myct.in";
                //                cc.SendMessageTra(sender, Mobile, backUsrResponse);
                //            }
                //            else if (WholeMsg == "MDM" || WholeMsg == "mdm" || WholeMsg == "Mdm")
                //            {
                //                backUsrResponse = "MDM*MENU1#DAR*1*A*RB*45*RG*20# 2*A*PB*45*PG*20# 3*A*PB*45*PG*20# 4*A*PB*45*PG*20# 5*A*PB*45*PG*20# 6*A*PB*45*PG*20# 7*A*PB*45*PG*20# 8*A*PB*45*PG*20 www.myct.in";
                //                cc.SendMessageTra(sender, Mobile, backUsrResponse);
                //            }
                //            else
                //            {
                //                string[] splitarr = WholeMsg.Split('*');

                //                string sql = "select usrUserid from usermaster where usrMobileNo='" + Mobile + "'";
                //                string userid = cc.ExecuteScalar(sql);
                //                sql = "insert into DataCollection(sender_mobileno,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,send_date)" +
                //                       " values('" + userid + "','" + splitarr[0] + "','" + splitarr[1] + "','" + splitarr[2] + "','" + splitarr[3] + "' " +
                //                       " ,'" + splitarr[4] + "','" + splitarr[5] + "','" + splitarr[6] + "','" + splitarr[7] + "','" + splitarr[8] + "' " +
                //                       " ,'" + splitarr[9] + "','" + splitarr[10] + "','" + splitarr[11] + "','" + todaysDate + "')";
                //                string execute = cc.ExecuteScalar(sql);
                //                backUsrResponse = "Dear user your record updated successfully thanks via www.myct.in";
                //                cc.SendMessageTra(senderid, mobile, backUsrResponse);

                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        backUsrResponse = "Dear Plz use proper syntax CHARA*depo code*kastagar*xxx*small*xxx*big*xxx*ola/suka*xxxx*dhep*xxx Note: 1) use nos only in place of Depo Code & all xxx. If no value then use 0 2)don't change sequence 3) use * as given every where 4) always send message to 9243100142 thanks via www.myct.in";
                //        //cc.SendMessageTra(sender, Mobile, backUsrResponse);
                //    }

                //}
                ///////////////////////////////////////////////////////////////////////////////////
                else if ((mkeyword1 == "NCP" || mkeyword1 == "Ncp" || mkeyword1 == "ncp "))
                {
                    try
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        string Mobile = mobile.ToString();

                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status < 1)
                        {
                            string sql = "select * from userMaster where usrMobileNo='" + mobile.ToString() + "'";

                            DataSet ds = new DataSet();
                            ds = cc.ExecuteDataset(sql);
                            string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                            backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
                            subject = "Mail From " + myName.ToString();
                            //emlBody = "\nMail: " + urUserRegBLLObj.longCodegrSMS.ToString() + "\n\nFROM: " + urUserRegBLLObj.usrFullName.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                            emlBody = "\n\n...www.myct.in";

                            //NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                            urUserRegBLLObj.usrMessageString = NewSmsResp.ToString();
                            //ll.sendEmail(emlTo, subject, emlBody);

                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                            if (status == 0)
                            {
                                string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
                                string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                                // NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                                NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/NCP.aspx?crtevnt http://www.myct.in/NCP.aspx?ict http://www.myct.in/NCP.aspx?w7o10 ur login pswd fr www.myct.in is " + passDec.ToString() + " ";
                                smslength = NewSmsResp.Length;
                                cc.SendMessageLongCodeSMS("LongCode", Mobile, NewSmsResp, smslength);
                                //cc.SendMessageTra(sender, Mobile, NewSmsResp);
                                smsStatus = "Y";
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',6)";
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
                else if ((mkeyword1.ToUpper().Trim() == "YUVA" || mkeyword1 == "Yuva" || mkeyword1 == "yuva" || mkeyword1.ToUpper().Trim() == "UVA" || mkeyword1 == "Uva" || mkeyword1 == "uva"))
                {
                    UVA_RegStudent();
                }

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if ((mkeyword1 == "MPSC" || mkeyword1 == "Mpsc" || mkeyword1 == "mpsc"))
                {
                    try
                    {
                        mkeyword1 = mkeyword1.ToUpper();
                        string Mobile = mobile.ToString();

                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status < 1)
                        {
                            string sql = "select * from userMaster where usrMobileNo='" + mobile.ToString() + "'";

                            DataSet ds = new DataSet();
                            ds = cc.ExecuteDataset(sql);
                            string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                            backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
                            subject = "Mail From " + myName.ToString();
                            //emlBody = "\nMail: " + urUserRegBLLObj.longCodegrSMS.ToString() + "\n\nFROM: " + urUserRegBLLObj.usrFullName.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                            emlBody = "\n\n...www.myct.in";

                            //NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                            urUserRegBLLObj.usrMessageString = NewSmsResp.ToString();
                            //ll.sendEmail(emlTo, subject, emlBody);

                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                            if (status == 0)
                            {
                                string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
                                string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                                // NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                                NewSmsResp = "Dwnld 3 ebooks frm http://www.myct.in/MPSC.aspx?crtevnt http://www.myct.in/MPSC.aspx?ict http://www.myct.in/MPSC.aspx?w7o10 ur login pswd fr www.myct.in is " + passDec.ToString() + " ";
                                smslength = NewSmsResp.Length;
                                cc.SendMessageLongCodeSMS("LongCode", Mobile, NewSmsResp, smslength);
                                smsStatus = "Y";
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                            string sql = "insert into UserGroup(Userid,GroupId)values('" + urUserRegBLLObj.usrUserId + "',6)";
                            string a = cc.ExecuteScalar(sql);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }



                }

                    /////////////////////////////////////////
                else if (mkeyword1 == "NSSPUNE")
                {
                    key.SendKeywordSyntax(mkeyword1, mobile);
                }
                //////////////////////////////////////////////
                else if (mkeyword1 == "UDISE")
                {
                    key.SendKeywordSyntax(mkeyword1, mobile);
                }


                ///////////////////////////////////////////////////////////////////////////////////////
                else if ((mkeyword1 == "OM" || mkeyword1 == "WSSD" || mkeyword1 == "TTD" || mkeyword1 == "Ttd" || mkeyword1 == "BJP" || mkeyword1 == "BSP" || mkeyword1 == "ANNA" || mkeyword1 == "RAVIDASSIA" || mkeyword1 == "TELI" || mkeyword1 == "CG" || mkeyword1 == "JANGID" || mkeyword1 == "JB" || mkeyword1 == "JM" || mkeyword1 == "MALI" || mkeyword1 == "MSCIT" || mkeyword1 == "SAHU" || mkeyword1 == "DIDIMA" || mkeyword1 == "MSSD" || mkeyword1 == "JAIN" || mkeyword1 == "MSS"))
                {
                    string usrUserid = "";
                    mkeyword1 = mkeyword1.ToUpper();
                    string Mobile = mobile.ToString();
                    // string m=urUserRegBLLObj.
                    status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                    if (status < 1)
                    {
                        string sql = "select * from userMaster where usrMobileNo='" + mobile.ToString() + "'";

                        DataSet ds = new DataSet();
                        ds = cc.ExecuteDataset(sql);
                        string myName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                        usrUserid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
                        backUsrResponse = "Thank's dear " + myName.ToString() + ", Your Mail send to " + emlTo.ToString() + ". " + cc.AddSMS(Mobile);
                        subject = "Mail From " + myName.ToString();
                        //emlBody = "\nMail: " + urUserRegBLLObj.longCodegrSMS.ToString() + "\n\nFROM: " + urUserRegBLLObj.usrFullName.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                        emlBody = "\n\n...www.myct.in";
                        if (mkeyword1 == "JM" || mkeyword1 == "jm")
                            mkeyword1 = "Maheshwari";
                        NewSmsResp = "THANKS to join " + mkeyword1.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                        urUserRegBLLObj.usrMessageString = NewSmsResp.ToString();
                        //ll.sendEmail(emlTo, subject, emlBody);

                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                        if (status == 0)
                        {
                            string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + Mobile + "'";
                            string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                            NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            smslength = NewSmsResp.Length;
                            cc.SendMessageLongCodeSMS("LongCode", Mobile, NewSmsResp, smslength);
                            ///////////////////////////////////////////////////////////////////
                            smsStatus = "Y";
                            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.usrKeyWord = mkeyword1.ToString();
                        urUserRegBLLObj.longCodegrSMS = mmsg[1].ToString();
                        string[] arr = ss.Split(' ');
                        string statusSTR = checkSMSstr(ss);
                        if (statusSTR == "TRUE")
                        {
                            saveNewsSMS(mobile, ss, mkeyword1);
                            sendMailSMS(urUserRegBLLObj);
                        }
                    }
                    else if ((s == "LOKMAT " || s == "MATA " || s == "DESHONNATI " || s == "NBP " || s == "SAKAL " || s == "YUVANXT "))
                    {
                        string[] mmsg = WholeMsg.Split(' ');
                        string newkeyword = mmsg[0];
                        int length = Convert.ToInt32(newkeyword.Length);
                        WholeMsg = WholeMsg.Remove(0, length);
                        urUserRegBLLObj.usrKeyWord = mkeyword1.ToString();
                        urUserRegBLLObj.usrMobileNo = mobile;
                        urUserRegBLLObj.longCodegrSMS = WholeMsg;
                        string statusSTR = checkSMSstr(WholeMsg);
                        if (statusSTR == "TRUE")
                        {
                            saveNewsSMS(mobile, WholeMsg, mkeyword1);
                            sendMailSMS(urUserRegBLLObj);
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
                    urUserRegBLLObj.usrMobileNo = mobile;
                    urUserRegBLLObj.usrKeyWord = mkeyword1.ToString();
                    urUserRegBLLObj.longCodegrSMS = mmsg1[1].ToString();
                    string[] arr = ss.Split(' ');
                    string statusSTR = checkSMSstr(ss);
                    if (statusSTR == "TRUE")
                    {
                        //saveNewsSMS(mobile, ss, mkeyword1);
                        sendMailSMS(urUserRegBLLObj);
                    }
                }
            }
        }

        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "Main Calling Function()", "Error: " + ex.ToString() + ex.StackTrace);
            string message = Convert.ToString(Request.QueryString["message"]);
            string mobile = Convert.ToString(Request.QueryString["mobilenumber"]);
            string shortcode = Convert.ToString(Request.QueryString["receivedon"]);


            DateTime dt = DateTime.Now;
            double d = 5;
            double m = 48;
            DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
            SystemDate = SystemDate.AddMinutes(m);
            String strDate = "";
            strDate = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss''"); // 2007-07-21 15:17:20Z


            string Data = ex.Message;
            Data = "Incorrect syntax ";
            string Sql = "Insert into come2mycity.test(message, mobile, shortcode, data,FlagStatus) values " +
                " ('" + message + "','" + mobile + "','" + strDate + "','" + Data + "',0 )";
            int a = cc.ExecuteNonQuery(Sql);
            Response.Write(ex.Message);
        }
        /////////////////////////////////////End of RegisteredKeyword/////////////////////////////////////////////////////////////////

    }//Page Load
    #endregion normalKeyword

    //check Pin Code No------------------------------

    #region checkPincode
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
    #endregion checkPincode

    //Reset password---------------------------------

    #region ResetPassword
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
                smslength = responseMsg.Length;
                cc.SendMessageLongCodeSMS("LongCode", ur.usrMobileNo, responseMsg, smslength);

            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "ReeSetPass()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion Resetpassword

    //Copy group-------------------------------------

    #region copyGroup

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
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
                    smslength = ResponceToRecever.Length;
                    cc.SendMessageLongCodeSMS("LongCode", to.ToString(), ResponceToRecever, smslength);
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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

    #endregion copyGroup

    //Check Pin Key By values------------------------

    #region CheckPin
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
    #endregion CheckPin

    //DNDByLongCode----------------------------------

    #region DNDByLongCode
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "setDNDbyLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion DNDByLongCode

    //checkSMSstr------------------------------------

    #region checkSMSstr
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
    #endregion checkSMSstr

    //saveNewsSMS------------------------------------

    #region saveNewsSMS
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
            smsStatus = "Y";
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
    #endregion saveNewsSMS

    //checkGroupSMSCode------------------------------

    #region checkGroupSMSCode
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
    #endregion checkGroupSMSCode

    //UpdateName-------------------------------------

    #region UpdateName
    public void UpdateName(UserRegistrationBLL urUserRegBLLObj1)
    {
        try
        {
            status = urUserRegBLLObj.BLLUpdateUserNameByLongCode(urUserRegBLLObj1);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = urUserRegBLLObj1.usrMobileNo;
                string Name = urUserRegBLLObj1.usrFirstName + " " + urUserRegBLLObj1.usrLastName;
                string Message = "Dear " + Name + ", Your Name is Updated Successfully." + cc.AddSMS(mobileNo);
                smslength = Message.Length;
                cc.SendMessageLongCodeSMS("LongCode", mobileNo, Message, smslength);
                smsStatus = "Y";
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
    #endregion UpdateName

    //UpdateFirstName--------------------------------

    #region UpdateFirstName
    public void UpdateFirstName(UserRegistrationBLL urUserRegBLLObj2)
    {
        try
        {
            status = urUserRegBLLObj.BLLUpdateFirstNameByLongCode(urUserRegBLLObj2);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = urUserRegBLLObj2.usrMobileNo;
                string Name = urUserRegBLLObj2.usrFirstName;
                string Message = "Dear " + Name + ", Your Name is Updated Successfully." + cc.AddSMS(mobileNo);
                smslength = Message.Length;
                cc.SendMessageLongCodeSMS("LongCode", mobileNo, Message, smslength);
                smsStatus = "Y";
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
    #endregion UpdateFirstName

    //changeMobileNoByLongCode-----------------------

    #region changeMobileNoByLongCode
    public void changeMobileNoByLongCode(UserRegistrationBLL ur)
    {
        try
        {

            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrAltMobileNo;
                string Message = "Dear Given number is already registered with come2mycity.com." + cc.AddSMS(mobileNo);
                smslength = Message.Length;
                cc.SendMessageLongCodeSMS("LongCode", mobileNo, Message, smslength);
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

                status = urUserRegBLLObj.BLLChangeMobileNoByLongCode(ur);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
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
            ClsCommon.WriteLine(this.ToString(), "changeMobileNoByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion changeMobileNoByLongCode

    //UpdateAddressByLongCode------------------------

    #region UpdateAddressByLongCode
    public void UpdateAddressByLongCode(UserRegistrationBLL ur, int SmsSendFlag)
    {
        try
        {
            status = urUserRegBLLObj.BLLUpdateUserAddressByLongCode(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear Your Address is Updated Successfully." + cc.AddSMS(mobileNo);
                if (SmsSendFlag < 1)
                {
                    smslength = Message.Length;
                    cc.SendMessageLongCodeSMS("LongCode", mobileNo, Message, smslength);
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
            ClsCommon.WriteLine(this.ToString(), "UpdateAddressByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion UpdateAddressByLongCode

    //addGroupByLongCode-----------------------------

    #region addGroupByLongCode
    public void addGroupByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
                    smslength = smsString.Length;
                    cc.SendMessageLongCodeSMS("LongCode", mobileNo, smsString, smslength);
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
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + GroupTypeName.ToString() + " as " + grnmword.ToString() + "." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();

                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);


                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);

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
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "addGroupByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion addGroupByLongCode

    //CheckPaidSmsGroup------------------------------

    #region CheckPaidSmsGroup
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
    #endregion CheckPaidSmsGroup

    //sendPaidGroupSms-------------------------------

    #region sendPaidGroupSms
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
                string ResStr = "Dear " + unm.ToString() + ", You dont have PAID sufficiant balance to send SMS.";
                cc.SendMessage1(usrMobileNo, usrMobileNo, ResStr);
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "sendPaidGroupSms()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion sendPaidGroupSms

    //addGroupByLongCodeJNS--------------------------

    #region addGroupByLongCodeJNS
    public void addGroupByLongCodeJNS(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + GroupTypeName.ToString() + " as " + grnmword.ToString() + "." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
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
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();

                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);


                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string myMobileNo = urUserRegBLLObj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);

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
                    smsStatus = "Y";
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "addGroupByLongCodeJNS()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion addGroupByLongCodeJNS

    //JoinGroupByLongCode----------------------------

    #region JoinGroupByLongCode
    public void JoinGroupByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
                    smsStatus = "Y";
                }
                else
                {
                    string mobileNo = ur.usrMobileNo;
                    string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + Convert.ToString(GroupNameVal) + " as " + ur.usrKeyWord + "." + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsString);
                    smsStatus = "Y";
                    //smsStatus = "Y";
                    //string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    //int pkchange = 0;
                    //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    //if (pkchange == 0)
                    //{
                    //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    //}
                }

                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
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
            ClsCommon.WriteLine(this.ToString(), "JoinGroupByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion JoinGroupByLongCode

    //UpdateAreaByLongCode---------------------------

    #region UpdateAreaByLongCode
    public void UpdateAreaByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLUpdateAreaByLongCode(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear Your Area is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateAreaByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion UpdateAreaByLongCode

    //UpdateByLongCodePIN----------------------------

    #region UpdateByLongCodePIN
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

            status = urUserRegBLLObj.BLLUpdatePinByLongCodePIN(ur);
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdateByLongCodePIN()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion UpdateByLongCodePIN

    //UpdatePINbyFindingPIN--------------------------

    #region UpdatePINbyFindingPIN
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

            status = urUserRegBLLObj.BLLUpdatePinByLongCodePIN(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear user your PIN code is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdatePINbyFindingPIN()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion UpdatePINbyFindingPIN

    //RegisterByLongCodePINNewOm---------------------

    #region RegisterByLongCodePINNewOm
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

            status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(ur);


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
                string myMobileNo = urUserRegBLLObj.usrMobileNo;
                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                string passwordMessage = ur.usrMessageString;

                passwordMessage += " Ur login pswd fr myct.in is " + myPassword.ToString() + ".Via: www.myct.in";
                string passMsgNew = "JAY Jijau Welcome by Maratha Seva Sangh(MSS) Update ur profile on www.myct.in Ur paswrd of login " + myPassword.ToString() + " Tell to do the same to all MSS members for comunication";

                cc.SendMessageTra(senderId, myMobileNo, passwordMessage, KeyWord);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    //System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    //File.Copy(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RegisterByLongCodePINNew()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion RegisterByLongCodePINNewOm

    //RegisterByLongCodeNew--------------------------

    #region RegisterByLongCodeNew
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

            status = urUserRegBLLObj.BLLInsertUserRegistrationInitialNew(ur);

        }
    }
    #endregion RegisterByLongCodeNew

    //RegisterByLongCodePINNew-----------------------

    #region RegisterByLongCodePINNew
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

            string strmessage = "select Message from test where PK='" + urUserRegBLLObj.usrPKval + "'" + urUserRegBLLObj.usrMobileNo;
            string msg = "";
            msg = cc.ExecuteScalar(strmessage);



            status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(ur);


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
                string myMobileNo = urUserRegBLLObj.usrMobileNo;
                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                string passwordMessage = ur.usrMessageString;

                passwordMessage += " Ur login pswd fr myct.in is " + myPassword.ToString() + ".Via: www.myct.in";
                string passMsgNew = "JAY Jijau Welcome by Maratha Seva Sangh(MSS) Update ur profile on www.myct.in Ur paswrd of login " + myPassword.ToString() + " Tell to do the same to all MSS members for comunication";

                cc.SendMessageTra(senderId, myMobileNo, passwordMessage, KeyWord);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    //System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    //File.Copy(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RegisterByLongCodePINNew()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion RegisterByLongCodePINNew

    //RegisterByLongCodePIN--------------------------

    #region RegisterByLongCodePIN
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



            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);


            if (status > 0)
            {
                string senderId = "MYCT.IN";
                string myMobileNo = urUserRegBLLObj.usrMobileNo;
                string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);

                string passwordMessage = "Dear " + ur.usrFirstName + " registered you in city " + cName + " on come2mycity.com. U use it to send SMS.Password for ur First Login is " + myPassword + " for come2myCity.com";
                string NewPassTraMsg = "Dear " + ur.usrFirstName.ToString() + " ur registered on www.myct.in your password for login " + myPassword.ToString() + " thanks.via www.myct.in";

                cc.SendMessageTra(senderId, myMobileNo, NewPassTraMsg);

                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RegisterByLongCodePIN()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion RegisterByLongCodePIN

    //RecoverPasswordByLongCode----------------------

    #region RecoverPasswordByLongCode
    public void RecoverPasswordByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            DataTable dtUserInfoList;
            string mobileNo = ur.usrMobileNo; ;
            urUserRegBLLObj.BLLUserPasswordRecovery(mobileNo, out dtUserInfoList, out status);

            if (status > 0)
            {
                DataTable dtUserSMSInfoList = dtUserInfoList;
                DataRow dRowUserInfo = dtUserSMSInfoList.Rows[0];
                //string myMobileNo = "91"+Convert.ToString(dRowUserInfo["usrMobileNo"]);
                string myMobileNo = Convert.ToString(dRowUserInfo["usrMobileNo"]);
                string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfo["usrPassword"]));
                string myName = Convert.ToString(dRowUserInfo["usrFullName"]);


                string sendFrom = "COM2MYCT";

                string passwordMessage = "Dear " + myName + ", Your Password For Login is :: '" + myPassword + "'. " + cc.AddSMS(myMobileNo);
                string strPassTra = "THANKS to join group in all India mobile directory on www.myct.in to receive imp sms. Ur login pswd fr myct.in is '" + myPassword.ToString() + "'. Via: www.myct.in";
                string newPasswordMsg = "Dear " + myName.ToString() + " ur password for www.myct.in is " + myPassword.ToString() + " thanks.Via www.myct.in";
                cc.SendMessageTra(sendFrom, myMobileNo, newPasswordMsg);

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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "RecoverPasswordByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion RecoverPasswordByLongCode

    //SendMessagetoAllLongCode-----------------------

    #region SendMessagetoAllLongCode
    public void SendMessagetoAllLongCode(UserRegistrationBLL ur)
    {
        try
        {
            //DateTime date = DateTime.Now;
            //string todaysDate = date.ToShortDateString();
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
                 "values('" + userId + "','" + mobile + "','" + WholeMsg + "','" + totalSms.ToString() + "','" + smsLength + "','" + smsCharge + "','" + smsBal + "','" + smsBalance + "','" + CurrenctDate + "')";
            string b = cc.ExecuteScalar(sqlinsert);

            if ((smsCharge <= smsBal))
            {
                string ResponceMsg = "Dear " + FirstName + " Total " + totalSms.ToString() + " messages sent to " + smsCode.ToString() + " group members thanks.via www.myct.in";
                int len = ResponceMsg.Length;
                cc.SendMessageLongCodeSMS("LongCode", ur.usrMobileNo, ResponceMsg, len);

                sms = "" + sms + "www.myct.in";
                if (userId == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                {
                    cc.SendMessageTraBulkNCPJLN(mobile, mobileforsms, sms, smsLength);
                }
                else if (userId == "65889cc5-601d-4baf-943f-3ef68ccf9016")
                {
                    cc.SendMessageTraBulkJSHAPL(mobile, mobileforsms, sms, smsLength);
                }
                else
                {
                    cc.SendMessageTraBulk(mobile, mobileforsms, sms, smsLength);
                }

                string sqlBalUpdate1 = "update userMaster set SMSbal=" + smsBalance.ToString() + " where usrMobileNo='" + ur.usrMobileNo + "'";
                int i1 = cc.ExecuteNonQuery(sqlBalUpdate1);

                string qq = "update come2mycity.test set no_sentmessage='" + totalSms + "', FlagStatus = 0 where PK='" + urUserRegBLLObj.usrPKval + "'";
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
    #endregion SendMessagetoAllLongCode

    //grpsmsbylongcode-------------------------------

    #region grpsmsbylongcode
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
    #endregion grpsmsbylongcode

    //SendMessageToAllStuPAByLongCode----------------

    #region SendMessageToAllStuPAByLongCode
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

                                            PAflag = true;
                                        }

                                    }
                                    else if (mrpa2.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa2.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname2"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();

                                            PAflag = true;
                                        }
                                    }
                                    else if (mrpa3.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa3.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname3"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();

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
                                                smsStatus = "Y";
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
                smsStatus = "Y";
            }
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
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
    #endregion SendMessageToAllStuPAByLongCode

    //dateConvertDDMMYYYY----------------------------

    #region dateConvertDDMMYYYY
    public string dateConvertDDMMYYYY(string dateMMDDYYYY)
    {

        string[] DateArr = dateMMDDYYYY.Split('/');
        return (DateArr[1].ToString() + "/" + DateArr[0].ToString() + "/" + DateArr[2].ToString());

    }
    #endregion dateConvertDDMMYYYY

    //UpdatePinByLongCode----------------------------

    #region UpdatePinByLongCode
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "UpdatePinByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion UpdatePinByLongCode

    //AddFriendByLongCode----------------------------

    #region AddFriendByLongCode
    public void AddFriendByLongCode(UserRegistrationBLL ur, string userMobileWhoSendFriendReq)
    {//Mahesh: Use second parameter mobile for only send sms only, because at run time mobile number of sender change.
        try
        {
            string sender = "";
            string joiner = "";
            bool JoinAll = false;
            string flagMob = ur.usrAltMobileNo;
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);

            if (status == 0)
            {
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitialByLc(ur);
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


                    }
                    string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + ur.usrAltMobileNo + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = cc.ExecuteDataset(sql1);

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
                else
                {
                    string sql3 = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql3);

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

                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();

                    ur.usrMobileNo = ur.usrAltMobileNo;

                    ur.usrFirstName = ur.frnrelFrnRelName;

                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
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
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = ur.frnrelFrnRelName;


                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u in come2mycity.com. U use it to send SMS.Dear " + myName + ",Password for ur First Login is " + myPassword + " for come2myCity.com";
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        smsStatus = "Y";
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + myMobileNo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(senderId);
                            cc.SendMessage1(myMobileNo, senderId, resJoinAll);
                            smsStatus = "Y";
                        }
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

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
            else
            {
                //NotRegisterMessageForLongCode(urUserRegBLLObj);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "AddFriendByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion AddFriendByLongCode

    //checkGr----------------------------------------

    #region checkGr
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
    #endregion checkGr

    //checPGr----------------------------------------

    #region checPGr
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
    #endregion checPGr

    //AddFriendByLongCodeF---------------------------

    #region AddFriendByLongCodeF
    public void AddFriendByLongCodeF(UserRegistrationBLL ur, string userMobileWhoSendFriendReq, int grid)
    {//Mahesh: Use second parameter mobile for only send sms only, because at run time mobile number of sender change.
        try
        {
            string sender = "";
            string joiner = "";
            bool JoinAll = false;
            string flagMob = ur.usrAltMobileNo;
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitialByLc(ur);
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
                        smsStatus = "Y";
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + SendTo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(sendFrom);
                            cc.SendMessage1(SendTo, sendFrom, resJoinAll);
                            smsStatus = "Y";
                        }
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
                        string SendTo = ur.usrAltMobileNo;
                        string sendFrom = ur.usrMobileNo;
                        string message = "Dear " + joiner.ToString() + " u already added " + sender.ToString() + " in come2myCity.com to send SMS." + cc.AddSMS(sendFrom);

                        cc.SendMessage1(SendTo, sendFrom, message);
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

                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();

                    ur.usrMobileNo = ur.usrAltMobileNo;

                    ur.usrFirstName = ur.frnrelFrnRelName;

                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
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
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = ur.frnrelFrnRelName;
                        string thisDir = Server.MapPath("~");

                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string newRespMsg = "Dear " + myName.ToString() + " I " + usrName.ToString() + "(" + senderId.ToString() + ") added  u on www.myct.in as a friend to send imp messages. Ur login password is " + myPassword.ToString() + " thanks.Via www.myct.in";
                        cc.SendMessageTra(senderId, myMobileNo, newRespMsg);

                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + myMobileNo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(senderId);
                            cc.SendMessage1(myMobileNo, senderId, resJoinAll);
                            smsStatus = "Y";
                        }
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
            else
            {
                //NotRegisterMessageForLongCode(urUserRegBLLObj);
            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "AddFriendByLongCodeF()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion AddFriendByLongCodeF

    //UpdateDOBByLongCode----------------------------

    #region UpdateDOBByLongCode
    public void UpdateDOBByLongCode(UserRegistrationBLL ur)
    {
        try
        {

            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
            ClsCommon.WriteLine(this.ToString(), "UpdateDOBByLongCode()", "Error: " + ex.ToString() + ex.StackTrace);
        }


    }
    #endregion UpdateDOBByLongCode

    //DeleteUserKeyWord------------------------------

    #region DeleteUserKeyWord
    public void DeleteUserKeyWord(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
            else
            {

            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "DeleteUserKeyWord()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion DeleteUserKeyWord

    //JoinAllKeyword---------------------------------

    #region JoinAllKeyword
    public void JoinAllKeyword(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
                    smsStatus = "Y";
                    cc.SendMessage1(senderId, mobileNo, smsDOB);
                    string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
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
    #endregion JoinAllKeyword

    //JoinGrKeyword-----------------------------------

    #region JoinGrKeyword
    public void JoinGrKeyword(UserRegistrationBLL ur, int grNo)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
            else
            {

            }
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "JoinGrKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion JoinGrKeyword

    //removeKewWord-----------------------------------

    #region removeKewWord
    public void removeKewWord(string urMo, string frMo, UserRegistrationBLL ur)
    {
        try
        {
            ur.usrMobileNo = urMo;
            ur.usrAltMobileNo = frMo;
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitialByLc(ur);
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
                string NewRespMsg = "Dear " + usr.ToString() + " " + fr.ToString() + " is removed from ur list thanks.via www.myct.in";
                smslength = NewRespMsg.Length;
                //cc.SendMessageTra(senderId, urMo, NewRespMsg);
                cc.SendMessageLongCodeSMS("LongCode", urMo, NewRespMsg, smslength);

            }
            smsStatus = "Y";
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = cc.ExecuteNonQuery(changeFlagSql);
        }
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "removeKewWord()", "Error: " + ex.ToString() + ex.StackTrace);
        }
    }
    #endregion removeKewWord

    //checkDigit--------------------------------------

    #region checkDigit
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
    #endregion checkDigit

    //UpdateEmailByLongCode---------------------------

    #region UpdateEmailByLongCode
    public void UpdateEmailByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(ur);
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
            smsStatus = "Y";
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
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
    #endregion UpdateEmailByLongCode

    //checkGroupKeyword-------------------------------

    #region checkGroupKeyword
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
    #endregion checkGroupKeyword

    //FillBalKeyword1---------------------------------

    #region FillBalKeyword1
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

            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                ur.usrMobileNo = to;
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial1(ur);
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

                                smslength = fromResp.Length;
                                cc.SendMessageLongCodeSMS("LongCode", from, fromResp, smslength);
                                smslength = toResp.Length;
                                cc.SendMessageLongCodeSMS("LongCode", to, toResp, smslength);
                                smsStatus = "Y";
                                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(ur.usrPKval);
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
    #endregion FillBalKeyword1

    //smsBalKeyword-----------------------------------

    #region smsBalKeyword
    public void smsBalKeyword(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial1(ur);
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
                smslength = newBalSmsTra.Length;
                cc.SendMessageLongCodeSMS("LongCode", ur.usrMobileNo, newBalSmsTra, smslength);
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
        catch (Exception ex)
        {
            ClsCommon.WriteLine(this.ToString(), "smsBalKeyword()", "Error: " + ex.ToString() + ex.StackTrace);
        }

    }
    #endregion smsBalKeyword

    //sendMailSMS-------------------------------------

    #region sendMailSMS
    public void sendMailSMS(UserRegistrationBLL ur)
    {
        try
        {
            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial1(ur);
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
                        smsStatus = "Y";

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
                            smsStatus = "Y";
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
                            smsStatus = "Y";
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
                            smsStatus = "Y";
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
                            smsStatus = "Y";
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
                        smsStatus = "Y";
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
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
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
                            smsStatus = "Y";
                        }
                        else
                        {
                            //string MyKey = "RAVIDASSIA";
                            RegisterByLongCodePINNew(ur, MyKey);
                            smsStatus = "Y";
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
                        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);


                        if (status == 0)
                        {
                            string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                            string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                            if (MyKey == "CG")
                                NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            else
                                NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                            cc.SendMessageTra(sender, usrMoNo, NewSmsResp, MyKey);
                            smsStatus = "Y";
                            RegisterByLongCodeNew(ur);

                        }
                        else
                        {

                            RegisterByLongCodeNew(ur);
                            RegisterByLongCodePINNew(ur, MyKey);
                            smsStatus = "Y";
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
                        smsStatus = "Y";

                    }
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
                        smsStatus = "Y";

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
                        smsStatus = "Y";

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
                        smsStatus = "Y";

                    }



                }

            }
            string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
    #endregion sendMailSMS

    //SaveBlog----------------------------------------

    #region SaveBlog
    public void SaveBlog(string kwd, string mono, string blog, UserRegistrationBLL ur)
    {
        try
        {
            string sqlSubGrNm = "select SubGroupName from KeywordDefinition where KeywordName='" + kwd.ToString() + "'";
            string subGrNm = Convert.ToString(cc.ExecuteScalar(sqlSubGrNm));
            string sqlGrId = "select GroupValueId from GroupValue where GroupValueName='" + subGrNm.ToString() + "'";
            int GrId = Convert.ToInt32(cc.ExecuteScalar(sqlGrId));
            string sqlBlogInsert = "insert into tblBlog(bgGrId,BgWriter,Bg) values (" + GrId + ",'" + mono.ToString() + "','" + blog.ToString() + "')";
            int i = cc.ExecuteNonQuery(sqlBlogInsert.ToString());
            if (i >= 0)
            {
                smsStatus = "Y";
                string changeFlagSql = "update come2mycity.test set FlagStatus = 0,smsStatus='" + smsStatus + "' where PK=" + Convert.ToInt32(urUserRegBLLObj.usrPKval);
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
    #endregion SaveBlog
}

