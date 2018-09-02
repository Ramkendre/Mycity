using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;


/// <summary>
/// Summary description for GetMembersAppsDetails
/// </summary>
public class GetMembersAppsDetails
{
    string p1 = "", p2 = "", p3 = "", p4 = "", p5 = "", p6 = "", p7 = "", p8 = "", p9 = "", p10 = "", p11 = "", p12 = "", p13 = "", p14 = "", p15 = "", p16 = "", p17 = "", p18 = "", p19 = "", frmMobileNo = "", p20 = "", p21 = "", p22 = "", p23 = "", p24 = "", p25 = "", p26 = "", p27 = "", p28 = "", p29 = "", p30 = "", p31 = "", p32 = "", p33 = "", p34 = "", p35 = "", p36 = "", p37 = "", p38 = "", p39 = "", p40 = "", p41 = "", p42 = "", p43 = "", p44 = "";
    int status;
    string date = "";
    string UserPassword = "";
    UserRegistrationBLL usrbalobj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
    AndroidLongCodeBLL androidobj = new AndroidLongCodeBLL();
    string Already = "", Appsstatus = "";
    @in.myct.telisamaj.www.GetRecordMyct andrdtoteli = new @in.myct.telisamaj.www.GetRecordMyct();

    public GetMembersAppsDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public XmlDocument geturl(string p1)
    {

        // try
        // {
        // p1 = Convert.ToString(Request.QueryString["p1"]);
        //    p36 = Get(p1);
        //    androidobj.P1 = p1;

        //    androidobj.P2 = p2;

        //    androidobj.P3 = p3;
        //    androidobj.P4 = p4;
        //    androidobj.P5 = p5;
        //    androidobj.P6 = p6;
        //    androidobj.P7 = p7;
        //    androidobj.P8 = p8;
        //    androidobj.P9 = p9;
        //    androidobj.P10 = p10;
        //    androidobj.P11 = p11;
        //    androidobj.P12 = p12;
        //    androidobj.P13 = p13;
        //    androidobj.P14 = p14;
        //    androidobj.P15 = p15;
        //    androidobj.P16 = p16;
        //    androidobj.P17 = p17;
        //    androidobj.P18 = p18;
        //    androidobj.P19 = p19;
        //    androidobj.P20 = p20;
        //    androidobj.P21 = p21;
        //    androidobj.P22 = p22;
        //    androidobj.P23 = p23;
        //    androidobj.P24 = p24;
        //    androidobj.P25 = p25;
        //    androidobj.P26 = p26;
        //    androidobj.P27 = p27;
        //    androidobj.P28 = p28;
        //    androidobj.P29 = p29;
        //    androidobj.P30 = p30;
        //    androidobj.P31 = p31;
        //    androidobj.P32 = p32;
        //    androidobj.P33 = p33;
        //    androidobj.P34 = p34;
        //    androidobj.P35 = p35;
        //    androidobj.P36 = p36;

        //    p3 = p3.ToUpper();

        //    if (p3 == "HEAD" || p3 == "MAIN")
        //    {
        //        string SQl = "select id from  androidlongcode  where p4='" + p4 + "'";
        //        Already = cc.ExecuteScalar(SQl);
        //    }
        //    else if (p3 == "MEMBER" || p3 == "FAMILY")
        //    {

        //        string SQl = "select id from  androidlongcode  where p4='" + p4 + "' and p6='" + p6 + "'";
        //        Already = cc.ExecuteScalar(SQl);

        //    }
        //    else if (p3 == "RELATIVE")
        //    {
        //        string SQl = "select id from  androidlongcode  where p4='" + p4 + "' and p5='" + p5 + "'";
        //        Already = cc.ExecuteScalar(SQl);
        //    }
        //    if (Already == "")
        //    {
        //        status = androidobj.BLLInsertAndroidData(androidobj);
        //        Appsstatus = Convert.ToString(status);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //return Appsstatus = Convert.ToString(ex);
        //}
        //if (Appsstatus != "0")
        //{
        //    return Appsstatus = "Done";
        //}
        //else
        //{
        //    return Appsstatus = "Error";

        //}

        string sql = "insert into androidlongcode(p36)" +
                                                            "values('" + p1 + "')";
        int status = cc.ExecuteNonQuery(sql); // add tecaher or Hm in Tecaher Master
        Appsstatus = Convert.ToString(status);
        XmlDocument xm = new XmlDocument();
        xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
        return xm;
    }

    public XmlDocument geturlrecords(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10,
        string p11, string p12, string p13, string p14, string p15, string p16, string p17, string p18, string p19, string DT, string p20, string p21,
        string p22, string p23, string p24, string p25, string p26, string p27, string p28, string p29, string p30, string p31, string p32, string p33,
        string p34, string p35, string p36, string p37, string p38, string p39, string p40, string p41, string p42, string p43, string p44)
    {
        try
        {
            //Head................Member...................Relative

            p1 = Get(p1);//Sim No......
            p2 = Get(p2);//IMEI no......
            p3 = Get(p3);//Keyword........Like Head, Member, Relative...
            p4 = Get(p4);//Head Mobile No...
            p5 = Get(p5);//Frist Name...............Relation..................Ralative MobileNo
            p6 = Get(p6);//Middle Name..............MobileNo..................FirstName
            p7 = Get(p7);//Last Name................FirstName.................LastName
            p8 = Get(p8);//Address..................Middle Name...............Relation
            p9 = Get(p9);//Word No..................Last Name.................Address
            p10 = Get(p10);//Pincode................Address...................Share Info
            p11 = Get(p11);//DOB....................Wordno....................Null
            p12 = Get(p12);//Age....................Pincode...................Null
            p13 = Get(p13);//JOb....................DOB.......................Null
            p14 = Get(p14);//Education..............Age.......................Null
            p15 = Get(p15);//Unique Id(Adhar).......Job.......................Null
            p16 = Get(p16);//Votter Id..............Education.................Null
            p17 = Get(p17);//Social Id..............Unique Id(Adhar)..........Null
            p18 = Get(p18);//Relision...............Votter Id.................Null
            p19 = Get(p19);//Category...............Social Id.................Null
            date = DT;//recived Date..............................................
            p20 = Get(p20);//Caste.................. Job Place................Null
            p21 = Get(p21);//Attached to............EmailId...................Null
            p22 = Get(p22);//Marriage Date..........Name in votter List ......Null
            p23 = Get(p23);//Job Place..............Name in Ration Card ......Null
            p24 = Get(p24);//Votter List Id.........Own House ................Null
            p25 = Get(p25);//Emailid................Pancard ..................Null
            p26 = Get(p26);//Name in Votter List....Senior Citizen ...........Null
            p27 = Get(p27);//Name in Ration Card....HandiCap .................Null
            p28 = Get(p28);//Own House..............Railway Pass .............Null
            p29 = Get(p29);//Pancard................Adharnidhi ...............Null
            p30 = Get(p30);//Senior Citizen.........s gandhi Yojana...........Null
            p31 = Get(p31);//Railway Pass...........Scholarship...............Null
            p32 = Get(p32);//Handicap...............Null......................Null
            p33 = Get(p33);//Addhar Nidhi...........Null......................Null
            p34 = Get(p34);//S Gandhi Yojana........Null......................Null
            p35 = Get(p35);//Scholarship............Null......................Null
            p36 = Get(p36);//Photo..................Photo.....................Null

            p37 = Get(p37);//Block..................
            p38 = Get(p38);//Flat No................
            p39 = Get(p39);//Gender.................
            p40 = Get(p40);//PersnalId..............
            p41 = Get(p41);//PartNo.................
            p42 = Get(p42);//Empty..................
            p43 = Get(p43);//Empty..................
            p44 = Get(p44);//Empty..................

            androidobj.P1 = p1;
            androidobj.P2 = p2;
            androidobj.P3 = p3;
            androidobj.P4 = p4;
            androidobj.P5 = p5;
            androidobj.P6 = p6;
            androidobj.P7 = p7;
            androidobj.P8 = p8;
            androidobj.P9 = p9;
            androidobj.P10 = p10;
            androidobj.P11 = p11;
            androidobj.P12 = p12;
            androidobj.P13 = p13;
            androidobj.P14 = p14;
            androidobj.P15 = p15;
            androidobj.P16 = p16;
            androidobj.P17 = p17;
            androidobj.P18 = p18;
            androidobj.P19 = p19;
            androidobj.P20 = p20;
            androidobj.P21 = p21;
            androidobj.P22 = p22;
            androidobj.P23 = p23;
            androidobj.P24 = p24;
            androidobj.P25 = p25;
            androidobj.P26 = p26;
            androidobj.P27 = p27;
            androidobj.P28 = p28;
            androidobj.P29 = p29;
            androidobj.P30 = p30;
            androidobj.P31 = p31;
            androidobj.P32 = p32;
            androidobj.P33 = p33;
            androidobj.P34 = p34;
            androidobj.P35 = p35;
            androidobj.P36 = p36;

            //------------------------------- Apartmenet Related parameter -----------------------------------

            androidobj.P37 = p37;
            androidobj.P38 = p38;
            androidobj.P39 = p39;
            androidobj.P40 = p40;
            androidobj.P41 = p41;
            androidobj.P42 = p42;
            androidobj.P43 = p43;
            androidobj.P44 = p44;

            androidobj.Date = date;
            p3 = p3.ToUpper();

            if (p36 == "0")
            {
                androidobj.P36 = "No";
            }
            else
            {
                androidobj.P36 = "Yes";
            }

            if (p3 == "HEAD" || p3 == "MAIN")
            {
                string SQl = "select id from  androidlongcode  where p4='" + p4 + "' and p1='" + p1 + "' and p2='" + p2 + "' and p3='" + p3 + "'";
                Already = Convert.ToString(cc.ExecuteScalar(SQl));

                if (Already == "" || Already == null)
                { }
                else
                {
                    //----------------------Update data-----------------------------------------------------------------,p36='" + p36 + "'
                    string Sql = "Update androidlongcode set p1='" + p1 + "',p2='" + p2 + "',p3='" + p3 + "',p4='" + p4 + "',p5='" + p5 + "',p6='" +
                      p6 + "',p7='" + p7 + "',p8='" + p8 + "',p9='" + p9 + "',p10='" + p10 + "',p11='" + p11 + "',p12='" + p12 + "',p13='" + p13 + "',p14='" +
                      p14 + "',p15='" + p15 + "',p16='" + p16 + "',p17='" + p17 + "',p18='" + p18 + "',p19='" + p19 + "',p20='" + p20 + "',p21='" + p21 + "',p22='" +
                      p22 + "',p23='" + p23 + "',p24='" + p24 + "',p25='" + p25 + "',p26='" + p26 + "',p27='" + p27 + "',p28='" + p28 + "',p29='" + p29 + "',p30='" +
                      p30 + "',p31='" + p31 + "',p32='" + p32 + "',p33='" + p33 + "',p34='" + p34 + "',p35='" + p35 + "',p37='" + p37 + "',p38='" +
                      p38 + "',p39='" + p39 + "',p40='" + p40 + "',p41='" + p41 + "',p42='" + p42 + "',p43='" + p43 + "',p44='" + p44 + "',date='" +
                      date + "' where  p4='" + p4 + "' and id=" + Already + "";
                    Appsstatus = Convert.ToString(cc.ExecuteNonQuery(Sql));
                    if (Appsstatus != "" || Appsstatus != null)
                    {
                        Sql = "Update EApps_MemberImage Set MemberImage='" + p36 + "' where AppsMem_Id=" + Already + "";
                        int k = cc.ExecuteNonQuery(Sql);
                    }
                }
            }
            else if (p3 == "MEMBER" || p3 == "FAMILY")
            {

                string SQl = "select id from  androidlongcode  where p4='" + p4 + "' and p6='" + p6 + "' and p1='" + p1 + "' and p2='" + p2 + "'";
                Already = Convert.ToString(cc.ExecuteScalar(SQl));
                if (Already == "" || Already == null)
                { }
                else
                {
                    //----------------------Update data-----------------------------------------------------------------,p36='" + p36 + "'
                    string Sql = "Update androidlongcode set p1='" + p1 + "',p2='" + p2 + "',p3='" + p3 + "',p4='" + p4 + "',p5='" + p5 + "',p6='" +
                      p6 + "',p7='" + p7 + "',p8='" + p8 + "',p9='" + p9 + "',p10='" + p10 + "',p11='" + p11 + "',p12='" + p12 + "',p13='" + p13 + "',p14='" +
                      p14 + "',p15='" + p15 + "',p16='" + p16 + "',p17='" + p17 + "',p18='" + p18 + "',p19='" + p19 + "',p20='" + p20 + "',p21='" + p21 + "',p22='" +
                      p22 + "',p23='" + p23 + "',p24='" + p24 + "',p25='" + p25 + "',p26='" + p26 + "',p27='" + p27 + "',p28='" + p28 + "',p29='" + p29 + "',p30='" +
                      p30 + "',p31='" + p31 + "',p32='" + p32 + "',p33='" + p33 + "',p34='" + p34 + "',p35='" + p35 + "',p37='" + p37 + "',p38='" +
                      p38 + "',p39='" + p39 + "',p40='" + p40 + "',p41='" + p41 + "',p42='" + p42 + "',p43='" + p43 + "',p44='" + p44 + "',date='" +
                      date + "' where  p4='" + p4 + "' and id=" + Already + "";
                    Appsstatus = Convert.ToString(cc.ExecuteNonQuery(Sql));
                    if (Appsstatus != "" || Appsstatus != null)
                    {
                        if (Appsstatus != "" || Appsstatus != null)
                        {
                            Sql = "Update EApps_MemberImage Set MemberImage='" + p36 + "' where AppsMem_Id=" + Already + "";
                            int k = cc.ExecuteNonQuery(Sql);
                        }
                    }
                }

            }
            else if (p3 == "RELATIVE")
            {
                string SQl = "select id from  androidlongcode  where p4='" + p4 + "' and p5='" + p5 + "' and p1='" + p1 + "' and p2='" + p2 + "'";
                Already = Convert.ToString(cc.ExecuteScalar(SQl));

                if (Already == "" || Already == null)
                { }
                else
                {
                    //----------------------Update data-----------------------------------------------------------------//,p36='" + p36 + "'
                    string Sql = "Update androidlongcode set p1='" + p1 + "',p2='" + p2 + "',p3='" + p3 + "',p4='" + p4 + "',p5='" + p5 + "',p6='" +
                      p6 + "',p7='" + p7 + "',p8='" + p8 + "',p9='" + p9 + "',p10='" + p10 + "',p11='" + p11 + "',p12='" + p12 + "',p13='" + p13 + "',p14='" +
                      p14 + "',p15='" + p15 + "',p16='" + p16 + "',p17='" + p17 + "',p18='" + p18 + "',p19='" + p19 + "',p20='" + p20 + "',p21='" + p21 + "',p22='" +
                      p22 + "',p23='" + p23 + "',p24='" + p24 + "',p25='" + p25 + "',p26='" + p26 + "',p27='" + p27 + "',p28='" + p28 + "',p29='" + p29 + "',p30='" +
                      p30 + "',p31='" + p31 + "',p32='" + p32 + "',p33='" + p33 + "',p34='" + p34 + "',p35='" + p35 + "',p37='" + p37 + "',p38='" +
                      p38 + "',p39='" + p39 + "',p40='" + p40 + "',p41='" + p41 + "',p42='" + p42 + "',p43='" + p43 + "',p44='" + p44 + "',date='" +
                      date + "' where  p4='" + p4 + "' and id=" + Already + "";
                    Appsstatus = Convert.ToString(cc.ExecuteNonQuery(Sql));
                }
            }
            if (Already == "")
            {

                if (p3 == "HEAD")
                {
                    string SqlHead = "Select p2 from androidlongcode where p4='" + p4 + "' and p3='Head'";
                    string IMEINo = Convert.ToString(cc.ExecuteScalar(SqlHead));
                    if (IMEINo == "" || IMEINo == null)
                    {
                        status = androidobj.BLLInsertAndroidData(androidobj);
                        Appsstatus = Convert.ToString(status);
                    }
                    else
                    {
                        Appsstatus = "1";
                        //SqlHead = "Update androidlongcode set p2='" + p2 + "' where p4='" + p4 + "' and p3='Head'";
                        //int l = cc.ExecuteNonQuery(SqlHead);
                    }
                }
                else if (p3 == "MEMBER")
                {
                    string SqlMember = "Select p2 from androidlongcode where p4='" + p4 + "' and p3='Member' and p6='" + p6 + "'";
                    string IMEINo = Convert.ToString(cc.ExecuteScalar(SqlMember));
                    if (IMEINo == "" || IMEINo == null)
                    {
                        status = androidobj.BLLInsertAndroidData(androidobj);
                        Appsstatus = Convert.ToString(status);
                    }
                    else
                    { Appsstatus = "1"; }
                }
                else if (p3 == "RELATIVE")
                {
                    string SqlRelative = "Select p2 from androidlongcode where p4='" + p4 + "' and p3='Relative' and p5='" + p5 + "'";
                    string IMEINo = Convert.ToString(cc.ExecuteScalar(SqlRelative));
                    if (IMEINo == "" || IMEINo == null)
                    {
                        status = androidobj.BLLInsertAndroidData(androidobj);
                        Appsstatus = Convert.ToString(status);
                    }
                    else
                    { Appsstatus = "1"; }
                }
                if (status > 0)
                {

                    if (p3 == "HEAD" || p3 == "MAIN")
                    {
                        androidobj.Simno = p1;
                        androidobj.Imeino = p2;
                        frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        string Sql = "Select AppMobileNo from Apart_RegEzeeDevice where IMEINo='" + p2 + "' and SIMNo='" + p1 + "'";
                        string LeaderMoible = Convert.ToString(cc.ExecuteScalar(Sql));
                        if ((frmMobileNo == "" || frmMobileNo == null) && (LeaderMoible == "" || LeaderMoible == null))
                        {
                        }
                        else
                        {
                            usrbalobj.usrMobileNo = p4;
                            usrbalobj.usrFirstName = p5;
                            usrbalobj.usrMiddleName = p6;
                            usrbalobj.usrLastName = p7;
                            usrbalobj.usrAddress = p8;
                            usrbalobj.Wardno = p9;
                            usrbalobj.usrPIN = p10;
                            usrbalobj.usrDOB = p11;
                            usrbalobj.UsrAge = Convert.ToInt32(p12);
                            usrbalobj.usrCarrerInterest = p13; //Job
                            usrbalobj.usrBestFeature = p15;  //UID
                            usrbalobj.usrBuild = p16;  //VID
                            usrbalobj.UsrSocialDesignation = p17; //Social Designation
                            usrbalobj.usrCategory = p19;  //Category
                            usrbalobj.Caste = p20;
                            usrbalobj.Joingroup = p21;
                            usrbalobj.Marriagedt = p22;
                            usrbalobj.Jobplace = p23;
                            usrbalobj.Votterlist = p24;
                            usrbalobj.usrEmailId = p25;
                            usrbalobj.Namevosotorlist = p26;
                            usrbalobj.RationCard = p27;
                            usrbalobj.OwnHouse = p28;
                            usrbalobj.Pancard = p29;
                            usrbalobj.SeniorCitizen = p30;
                            usrbalobj.RailwayPass = p31;
                            usrbalobj.Handicap = p32;
                            usrbalobj.AdharNidhi = p33;
                            usrbalobj.SAnjayGandhiYojana = p34;
                            usrbalobj.Anyscholorship = p35;

                            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + p4 + "'";
                            string getuserID = cc.ExecuteScalar(sqlget);
                            //status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                            if (getuserID == "" || getuserID == null)
                            {
                                usrbalobj.usrUserId = System.Guid.NewGuid().ToString();
                                Random rnd = new Random();
                                usrbalobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                                Sql = "Insert Into UserMaster(usrUserId,usrMobileNo,usrAddress,usrPassword,usrFirstName,usrMiddleName,usrLastName,usrPIN,usrDOB,usrEmailId,usrCarrerInterest,Age,usrBestFeature,usrBuild,usrCaste,usrSocialDesignation,wardno,marriageDate,jobplace,votterlist)" +
                                            "values( '" + usrbalobj.usrUserId + "','" + usrbalobj.usrMobileNo + "','" + usrbalobj.usrAddress + "','" + usrbalobj.usrPassword + "','" + usrbalobj.usrFirstName + "','" + usrbalobj.usrMiddleName + "','" + usrbalobj.usrLastName + "','" + usrbalobj.usrPIN + "','" + usrbalobj.usrDOB + "','" + usrbalobj.usrEmailId + "','" + usrbalobj.usrCarrerInterest + "','" +
                                            usrbalobj.UsrAge + "','" + usrbalobj.usrBestFeature + "','" + usrbalobj.usrBuild + "','" + usrbalobj.Caste + "','" + usrbalobj.UsrSocialDesignation + "','" + usrbalobj.Wardno + "','" + usrbalobj.Marriagedt + "','" + usrbalobj.Jobplace + "','" + usrbalobj.Votterlist + "')";
                                int i = cc.ExecuteNonQuery(Sql);
                                //status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
                                if (i == 1)
                                {
                                    //andrdtoteli.GetMessageAndroidHead(frmMobileNo, p4);
                                    string SqlLeaderId = "Select usrUserId from UserMaster where usrMobileNo='" + LeaderMoible + "'";
                                    string LeaderUserId = Convert.ToString(cc.ExecuteScalar(SqlLeaderId));
                                    if (LeaderUserId == "" || LeaderUserId == null)
                                    { }
                                    else
                                    {
                                        string SqlInsertHead = "insert Into Teli_HeadOfFamily(H_Id,Mobile,Leader_Id)values('" + usrbalobj.usrUserId + "','" + p4 + "','" + LeaderUserId + "')";
                                        int k = cc.ExecuteNonQuery(SqlInsertHead);
                                        if (k == 1)
                                        {
                                            string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
                                            string message = "Welcome " + p5 + ", Your Password is " + myPassword + " www.myct.in";
                                            int smslength = message.Length;
                                            //cc.SendMessageLongCodeSMS("AndroidLongCode", p4, message, smslength);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                //andrdtoteli.GetMessageAndroidHead(frmMobileNo, p4);
                                string SqlLeader = "Select usrUserId from UserMaster where usrMobileNo='" + LeaderMoible + "'";
                                string LeaderUser = Convert.ToString(cc.ExecuteScalar(SqlLeader));
                                if (LeaderUser == "" || LeaderUser == null)
                                { }
                                else
                                {
                                    Sql = "Select Id from Teli_HeadOfFamily where Mobile='" + p4 + "' and Leader_Id='" + LeaderUser + "'";
                                    string chkId = Convert.ToString(cc.ExecuteScalar(Sql));
                                    if (chkId != "" || chkId != null)
                                    {
                                        string SqlInsertHead = "insert Into Teli_HeadOfFamily(H_Id,Mobile,Leader_Id)values('" + getuserID + "','" + p4 + "','" + LeaderUser + "')";
                                        int k = cc.ExecuteNonQuery(SqlInsertHead);
                                        if (k == 1)
                                        { }
                                    }
                                }
                            }
                            if (p3 == "HEAD" || p3 == "MAIN")
                            {
                                Sql = "Select id from androidlongcode where p1='" + p1 + "' and p2='" + p2 + "' and p3='" + p3 + "' and p4='" + p4 + "'";
                                string HeadId = Convert.ToString(cc.ExecuteScalar(Sql));

                                string SqlHead = "Select usrAutoId from UserMaster where usrMobileNo='" + p4 + "'";
                                string HeadAutoId = Convert.ToString(cc.ExecuteScalar(SqlHead));

                                if (HeadId != "" || HeadId != null)
                                {
                                    Sql = "Insert Into EApps_MemberImage(MemberImage,usrAutoId,AppsMem_Id) Values('" + p36 + "'," + HeadAutoId + "," + HeadId + ")";
                                    int k = cc.ExecuteNonQuery(Sql);
                                }
                            }
                        }
                    }
                    else if (p3 == "MEMBER" || p3 == "FAMILY")
                    {
                        //androidobj.Simno = p1;
                        //androidobj.Imeino = p2;
                        //frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        //if (frmMobileNo == "" || frmMobileNo == null)
                        //{
                        //}
                        //else
                        //{
                        androidobj.Simno = p1;
                        androidobj.Imeino = p2;
                        frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        string Sql = "Select AppMobileNo from Apart_RegEzeeDevice where IMEINo='" + p2 + "' and SIMNo='" + p1 + "'";
                        string LeaderMoible = Convert.ToString(cc.ExecuteScalar(Sql));
                        if ((frmMobileNo == "" || frmMobileNo == null) && (LeaderMoible == "" || LeaderMoible == null))
                        {
                        }
                        else
                        {
                            string headmobile = p4;
                            usrbalobj.usrMobileNo = headmobile;
                            status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                            if (status > 0)
                            {
                                string message = "Sorry,This MobileNo " + headmobile + " is not member of www.myct.in, So plz register first..!! ";
                                int smslength = message.Length;
                                //cc.SendMessageLongCodeSMS("AndroidLongCode", headmobile, message, smslength);
                            }
                            else
                            {
                                string relation = p5;
                                usrbalobj.usrMobileNo = p6;
                                usrbalobj.usrFirstName = p7;
                                usrbalobj.usrMiddleName = p8;
                                usrbalobj.usrLastName = p9;
                                usrbalobj.usrAddress = p10;
                                usrbalobj.Wardno = p11;
                                usrbalobj.usrPIN = p12;
                                usrbalobj.usrDOB = p13;
                                usrbalobj.UsrAge = Convert.ToInt32(p14);
                                usrbalobj.usrCarrerInterest = p15;
                                usrbalobj.usrBestFeature = p17;
                                usrbalobj.usrBuild = p18;
                                usrbalobj.UsrSocialDesignation = p19;
                                usrbalobj.Jobplace = p20;
                                usrbalobj.usrEmailId = p21;
                                usrbalobj.Namevosotorlist = p22;
                                usrbalobj.RationCard = p23;
                                usrbalobj.OwnHouse = p24;
                                usrbalobj.Pancard = p25;
                                usrbalobj.SeniorCitizen = p26;
                                usrbalobj.RailwayPass = p27;
                                usrbalobj.Handicap = p28;
                                usrbalobj.AdharNidhi = p29;
                                usrbalobj.SAnjayGandhiYojana = p30;
                                usrbalobj.Anyscholorship = p31;

                                // status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                                string sqlget = "select usrUserid from usermaster where usrMobileNo='" + p6 + "'";
                                string getuserID = cc.ExecuteScalar(sqlget);

                                if (getuserID == "" || getuserID == null)
                                {
                                    usrbalobj.usrUserId = System.Guid.NewGuid().ToString();
                                    Random rnd = new Random();
                                    usrbalobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                                    string SqlInsert = "Insert Into UserMaster(usrUserId,usrMobileNo,usrAddress,usrPassword,usrFirstName,usrMiddleName,usrLastName,usrPIN,usrDOB,usrEmailId,usrCarrerInterest,Age,usrBestFeature,usrBuild,usrCaste,usrSocialDesignation,wardno,marriageDate,jobplace,votterlist)" +
                                            "values( '" + usrbalobj.usrUserId + "','" + usrbalobj.usrMobileNo + "','" + usrbalobj.usrAddress + "','" + usrbalobj.usrPassword + "','" + usrbalobj.usrFirstName + "','" + usrbalobj.usrMiddleName + "','" + usrbalobj.usrLastName + "','" + usrbalobj.usrPIN + "','" + usrbalobj.usrDOB + "','" + usrbalobj.usrEmailId + "','" + usrbalobj.usrCarrerInterest + "','" +
                                            usrbalobj.UsrAge + "','" + usrbalobj.usrBestFeature + "','" + usrbalobj.usrBuild + "','" + usrbalobj.Caste + "','" + usrbalobj.UsrSocialDesignation + "','" + usrbalobj.Wardno + "','" + usrbalobj.Marriagedt + "','" + usrbalobj.Jobplace + "','" + usrbalobj.Votterlist + "')";
                                    int i = cc.ExecuteNonQuery(SqlInsert);
                                    //status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
                                    if (i == 1)
                                    {
                                        string Sqlchk1 = "Select usrUserId from UserMaster where usrMobileNo='" + p4 + "'";
                                        string HeadUserId = Convert.ToString(cc.ExecuteScalar(Sqlchk1));
                                        string SqlLeaderId = "Select usrUserId from UserMaster where usrMobileNo='" + LeaderMoible + "'";
                                        string LeaderUserId = Convert.ToString(cc.ExecuteScalar(SqlLeaderId));

                                        if (LeaderUserId == "" || LeaderUserId == null)
                                        { }
                                        else
                                        {
                                            string SqlInsertHead = "insert Into Teli_FamilyMember(H_Id,FamilyId,Relation,Leader_Id)values('" + HeadUserId + "','" + usrbalobj.usrUserId + "','" + p5 + "','" + LeaderUserId + "')";
                                            int k = cc.ExecuteNonQuery(SqlInsertHead);
                                            if (k == 1)
                                            {
                                                string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
                                                string message = "Welcome " + p7 + ", Your Password is " + myPassword + " www.myct.in";
                                                int smslength = message.Length;
                                                //cc.SendMessageLongCodeSMS("AndroidLongCode", p5, message, smslength);
                                            }
                                        }


                                    }
                                    //status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
                                    //if (status > 0)
                                    //{
                                    //    string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
                                    //    string message = "Welcome " + p7 + ", Your Password is " + myPassword + ",";
                                    //    message = message + "Now Your " + p5 + " of " + headmobile + " in www.myct.in";
                                    //    int smslength = message.Length;
                                    //    //cc.SendMessageLongCodeSMS("AndroidLongCode", p6, message, smslength);
                                    //}
                                }
                                else
                                {
                                    string SqlHeadId = "Select usrUserId from UserMaster where usrMobileNo='" + p4 + "'";
                                    string HeadUserId = Convert.ToString(cc.ExecuteScalar(SqlHeadId));

                                    string SqlLeaderId = "Select usrUserId from UserMaster where usrMobileNo='" + LeaderMoible + "'";
                                    string LeaderUserId = Convert.ToString(cc.ExecuteScalar(SqlLeaderId));

                                    if (LeaderUserId == "" || LeaderUserId == null)
                                    { }
                                    else
                                    {
                                        Sql = "Select Id from Teli_FamilyMember where H_Id='" + HeadUserId + "' and Leader_Id='" + LeaderUserId + "' and FamilyId='" + getuserID + "'";
                                        string chkId = Convert.ToString(cc.ExecuteScalar(Sql));
                                        if (chkId != "" || chkId != null)
                                        {
                                            string SqlInsertHead = "insert Into Teli_FamilyMember(H_Id,FamilyId,Relation,Leader_Id)values('" + HeadUserId + "','" + getuserID + "','" + p5 + "','" + LeaderUserId + "')";
                                            int k = cc.ExecuteNonQuery(SqlInsertHead);
                                            if (k == 1)
                                            {
                                            }
                                        }
                                    }

                                    //cc.SendMessageLongCodeSMS("LongCode", p6, message, smslength);
                                }
                                if (p3 == "MEMBER" || p3 == "FAMILY")
                                {
                                    Sql = "select id from  androidlongcode  where p4='" + p4 + "' and p6='" + p6 + "' and p1='" + p1 + "' and p2='" + p2 + "'";
                                    string MemId = Convert.ToString(cc.ExecuteScalar(Sql));

                                    string SqlHead = "Select usrAutoId from UserMaster where usrMobileNo='" + p6 + "'";
                                    string MemAutoId = Convert.ToString(cc.ExecuteScalar(SqlHead));

                                    if (MemId != "" || MemId != null)
                                    {
                                        Sql = "Insert Into EApps_MemberImage(MemberImage,usrAutoId,AppsMem_Id) Values('" + p36 + "'," + MemAutoId + "," + MemId + ")";
                                        int k = cc.ExecuteNonQuery(Sql);
                                    }
                                }
                            }
                            // andrdtoteli.GetMessageAndroid(frmMobileNo, headmobile, p6, p5, p3);

                        }
                    }
                    else if (p3 == "RELATIVE")
                    {
                        //androidobj.Simno = p1;
                        //androidobj.Imeino = p2;
                        //frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        //if (frmMobileNo == "" || frmMobileNo == null)
                        //{
                        //}
                        //else
                        //{
                        androidobj.Simno = p1;
                        androidobj.Imeino = p2;
                        frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        string Sql = "Select AppMobileNo from Apart_RegEzeeDevice where IMEINo='" + p2 + "' and SIMNo='" + p1 + "'";
                        string LeaderMoible = Convert.ToString(cc.ExecuteScalar(Sql));
                        if ((frmMobileNo == "" || frmMobileNo == null) && (LeaderMoible == "" || LeaderMoible == null))
                        {
                        }
                        else
                        {
                            string headmobile = p4;
                            usrbalobj.usrMobileNo = headmobile;

                            status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                            if (status > 0)
                            {
                                string message = "Sorry,This MobileNo " + headmobile + " is not member of www.myct.in, So plz register first..!! ";
                                int smslength = message.Length;
                                //cc.SendMessageLongCodeSMS("LongCode", headmobile, message, smslength);

                            }
                            else
                            {
                                usrbalobj.usrMobileNo = p5;
                                usrbalobj.usrFirstName = p6;
                                usrbalobj.usrLastName = p7;
                                string relation = p8;
                                usrbalobj.usrAddress = p9;

                                string sqlget = "select usrUserid from usermaster where usrMobileNo='" + p5 + "'";
                                string getuserID = cc.ExecuteScalar(sqlget);
                                //status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                                if (getuserID == "" || getuserID == null)
                                {
                                    usrbalobj.usrUserId = System.Guid.NewGuid().ToString();
                                    Random rnd = new Random();
                                    usrbalobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                                    Sql = "Insert Into UserMaster(usrUserId,usrMobileNo,usrAddress,usrPassword,usrFirstName,usrLastName)" +
                                           "values( '" + usrbalobj.usrUserId + "','" + usrbalobj.usrMobileNo + "','" + usrbalobj.usrAddress + "','" + usrbalobj.usrPassword + "','" + usrbalobj.usrFirstName + "','" + usrbalobj.usrLastName + "')";

                                    int i = cc.ExecuteNonQuery(Sql);
                                    //status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
                                    if (status > 0)
                                    {
                                        string Sqlchk1 = "Select usrMobileNo ,usrUserId from UserMaster where usrMobileNo='" + p4 + "'";
                                        string HeadUserId = Convert.ToString(cc.ExecuteScalar(Sqlchk1));

                                        string SqlInsertHead = "insert Into Teli_Relative(H_Id,RelativeId,Relation)values('" + HeadUserId + "','" + usrbalobj.usrUserId + "','" + p8 + "')";
                                        int k = cc.ExecuteNonQuery(SqlInsertHead);
                                        if (k == 1)
                                        {
                                            string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
                                            string message = "Welcome " + p6 + ", Your Password is " + myPassword + ",";
                                            message = message + "Now Your " + p8 + "of " + headmobile + " in www.myct.in";
                                            int smslength = message.Length;
                                            //cc.SendMessageLongCodeSMS("LongCode", p5, message, smslength);
                                        }

                                    }
                                }
                                else
                                {
                                    string SqlHeadId = "Select usrUserId from UserMaster where usrMobileNo='" + p4 + "'";
                                    string HeadUserId = Convert.ToString(cc.ExecuteScalar(SqlHeadId));

                                    string SqlMemId = "Select usrUserId from UserMaster where usrMobileNo='" + p5 + "'";
                                    string RelUserId = Convert.ToString(cc.ExecuteScalar(SqlMemId));

                                    if (RelUserId == "" || RelUserId == null)
                                    { }
                                    else
                                    {
                                        Sql = "Select Id from Teli_Relative where H_Id='" + HeadUserId + "' and RelativeId='" + RelUserId + "'";
                                        string chkId = Convert.ToString(cc.ExecuteScalar(Sql));
                                        if (chkId != "" || chkId != null)
                                        {
                                            string SqlInsertHead = "insert Into Teli_Relative(H_Id,RelativeId,Relation)values('" + HeadUserId + "','" + getuserID + "','" + p8 + "')";
                                            int k = cc.ExecuteNonQuery(SqlInsertHead);
                                            if (k == 1)
                                            { }
                                        }
                                    }


                                    //string message = "Now Your " + p8 + " of " + headmobile + " in www.myct.in";
                                    //int smslength = message.Length;
                                    ////cc.SendMessageLongCodeSMS("LongCode", p5, message, smslength);
                                }
                            }
                            // andrdtoteli.GetMessageAndroid(frmMobileNo, headmobile, p5, p8, p3);

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        if (Appsstatus == "0" || Appsstatus == null)
        {
            Appsstatus = "Error";
            XmlDocument xm = new XmlDocument();
            xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
            return xm;

        }
        else
        {

            Appsstatus = "Done";
            XmlDocument xm = new XmlDocument();
            xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
            return xm;
        }

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
            character = (char)a1;
            text = character.ToString();
            myCollection.Add(text);
        }
        string resulr = String.Join("", myCollection.ToArray());
        return resulr;

    }

    private System.Drawing.Bitmap ResizeImage(System.Drawing.Bitmap ImagePath, int maxWidth, int maxHeight)
    {

        System.Drawing.Bitmap newImage = null;
        try
        {
            System.Drawing.Bitmap originalImage = ImagePath;// GetImageFromUrl(ImagePath);
            if (originalImage != null)
            {
                int newWidth = originalImage.Width;
                int newHeight = originalImage.Height;
                double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;

                if (originalImage.Width > originalImage.Height)
                {
                    if (aspectRatio <= 1 && originalImage.Width > maxWidth)
                    {
                        newWidth = maxWidth;
                        newHeight = (int)Math.Round(newWidth / aspectRatio);
                    }
                    else if (aspectRatio > 1 && originalImage.Height > maxHeight)
                    {
                        newHeight = maxHeight;
                        newWidth = (int)Math.Round(newHeight * aspectRatio);
                    }
                }
                else
                {
                    if (aspectRatio <= 1 && originalImage.Height > maxHeight)
                    {
                        newHeight = maxHeight;
                        newWidth = (int)Math.Round(newHeight * aspectRatio);
                    }
                    else if (aspectRatio > 1 && originalImage.Width > maxWidth)
                    {
                        newWidth = maxWidth;
                        newHeight = (int)Math.Round(newWidth / aspectRatio);
                    }
                }
                newImage = new System.Drawing.Bitmap(originalImage, newWidth, newHeight);
                //newImage = new System.Drawing.Bitmap(originalImage, 40, 40);
                newImage.SetResolution((float)newWidth, (float)newHeight);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
                originalImage.Dispose();
                g.Dispose();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
        return newImage;
    }



    //public XmlDocument ShareInfo(string HeadMobNO, string RelMobNo)
    //{
    //    HeadMobNO = Get(HeadMobNO);
    //    RelMobNo = Get(RelMobNo);
    //    DataSet ds;

    //    string Sql = "Select p10 from androidlongcode where p4='" + HeadMobNO + "' and p5='" + RelMobNo + "' and p3='Relative' ";//p4='" + RelMobNo + "'";
    //    Int16 YN = Convert.ToInt16(cc.ExecuteScalar(Sql));

    //    if (YN == 0)
    //    {
    //        Sql = "Select p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30 " +
    //        ",p31,p32,p33,p34,p35,p36,p37,p38,p39,p40,p41,p42,p43,p44,date,MemberImage from androidlongcode left join EApps_MemberImage on " +
    //        "androidlongcode.id= EApps_MemberImage.AppsMem_Id where p4='" + RelMobNo + "' and p3='Head'";
    //        // Sql = "Select * from androidlongcode where p4='" + RelMobNo + "' and p3='Head'";
    //        ds = cc.ExecuteDataset(Sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            xmldata = new XmlDataDocument(ds);
    //            xmlElement = xmldata.DocumentElement;
    //        }
    //        else
    //        {
    //            Sql = "Select p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30 " +
    //            ",p31,p32,p33,p34,p35,p36,p37,p38,p39,p40,p41,p42,p43,p44,date,MemberImage from androidlongcode left join EApps_MemberImage on " +
    //            "androidlongcode.id= EApps_MemberImage.AppsMem_Id where p6='" + RelMobNo + "' and p3='member'";
    //            // Sql = "Select * from androidlongcode where p6='" + RelMobNo + "' and p3='member'";
    //            ds = cc.ExecuteDataset(Sql);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                xmldata = new XmlDataDocument(ds);
    //                xmlElement = xmldata.DocumentElement;
    //            }
    //            else
    //            {
    //                Appsstatus = "Data not Found";
    //                XmlDocument xm = new XmlDocument();
    //                xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
    //                return xm;
    //            }

    //        }
    //    }
    //    else
    //    {
    //        Sql = "Select p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30 " +
    //            ",p31,p32,p33,p34,p35,p36,p37,p38,p39,p40,p41,p42,p43,p44,date,MemberImage from androidlongcode left join EApps_MemberImage on " +
    //            "androidlongcode.id= EApps_MemberImage.AppsMem_Id where p4='" + RelMobNo + "' and p3<>'Relative'"; //and MemberImage<>'' order by MemberImage desc";
    //        //Sql = "Select * from androidlongcode where p4='" + RelMobNo + "' and p3<>'Relative'";
    //        ds = cc.ExecuteDataset(Sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            xmldata = new XmlDataDocument(ds);
    //            xmlElement = xmldata.DocumentElement;
    //        }
    //        else
    //        {
    //            Appsstatus = "Data not Found";
    //            XmlDocument xm = new XmlDocument();
    //            xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
    //            return xm;
    //        }
    //    }
    //    return xmldata;

    //    //Appsstatus = "Ok I Recived";
    //    //XmlDocument xm = new XmlDocument();
    //    //xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
    //    //return xm;

    //}
    XmlDataDocument xmldata;
    XmlElement xmlElement;

    public XmlDocument ShareInfo(string HeadMobNO)
    {
        HeadMobNO = Get(HeadMobNO);
        string[] headNo = HeadMobNO.Split('/');
        HeadMobNO = headNo[0].ToString();
        string RelNo = headNo[1].ToString();
        //DataSet ds;

        //string Sql = "Select * from androidlongcode where p4='" + RelNo + "' and p5='" + HeadMobNO + "' ";//p4='" + RelMobNo + "'";
        //ds = cc.ExecuteDataset(Sql);

        //xmldata = new XmlDataDocument(ds);
        //xmlElement = xmldata.DocumentElement;
        //return xmldata;

        string RelMobNo = RelNo;
        DataSet ds;
        try
        {

            string Sql = "Select p10 from androidlongcode where p4='" + HeadMobNO + "' and p5='" + RelMobNo + "' and p3='Relative' ";//p4='" + RelMobNo + "'";
            Int16 YN = Convert.ToInt16(cc.ExecuteScalar(Sql));

            if (YN == 0)
            {
                Sql = "Select p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30 " +
                ",p31,p32,p33,p34,p35,p36,p37,p38,p39,p40,p41,p42,p43,p44,date,MemberImage from androidlongcode left join EApps_MemberImage on " +
                "androidlongcode.id= EApps_MemberImage.AppsMem_Id where p4='" + RelMobNo + "' and p3='Head'";
                // Sql = "Select * from androidlongcode where p4='" + RelMobNo + "' and p3='Head'";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xmldata = new XmlDataDocument(ds);
                    xmlElement = xmldata.DocumentElement;
                }
                else
                {
                    Sql = "Select p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30 " +
                    ",p31,p32,p33,p34,p35,p36,p37,p38,p39,p40,p41,p42,p43,p44,date,MemberImage from androidlongcode left join EApps_MemberImage on " +
                    "androidlongcode.id= EApps_MemberImage.AppsMem_Id where p6='" + RelMobNo + "' and p3='member'";
                    // Sql = "Select * from androidlongcode where p6='" + RelMobNo + "' and p3='member'";
                    ds = cc.ExecuteDataset(Sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        xmldata = new XmlDataDocument(ds);
                        xmlElement = xmldata.DocumentElement;
                    }
                    else
                    {
                        Appsstatus = "Data not Found";
                        XmlDocument xm = new XmlDocument();
                        xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
                        return xm;
                    }

                }
            }
            else
            {
                Sql = "Select p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30 " +
                    ",p31,p32,p33,p34,p35,p36,p37,p38,p39,p40,p41,p42,p43,p44,date,MemberImage from androidlongcode left join EApps_MemberImage on " +
                    "androidlongcode.id= EApps_MemberImage.AppsMem_Id where p4='" + RelMobNo + "' and p3<>'Relative'"; //and MemberImage<>'' order by MemberImage desc";
                //Sql = "Select * from androidlongcode where p4='" + RelMobNo + "' and p3<>'Relative'";
                ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xmldata = new XmlDataDocument(ds);
                    xmlElement = xmldata.DocumentElement;
                }
                else
                {
                    Appsstatus = "Data not Found";
                    XmlDocument xm = new XmlDocument();
                    xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
                    return xm;
                }
            }

        }
        catch (Exception ex)
        {
            Appsstatus = "Data not Found";
            XmlDocument xm = new XmlDocument();
            xm.LoadXml(string.Format("<root>{0}</root>", Appsstatus));
            return xm;
        }

        return xmldata;
    }

}

//public void UpdateAndroid(string AlreadyId)
//{

//string Sql = "Update androidlongcode set p1='" + p1 + "',p2='" + p2 + "',p3='" + p3 + "',p4='" + p4 + "',p5='" + p5 + "',p6='" +
//    p6 + "',p7='" + p7 + "',p8='" + p8 + "',p9='" + p9 + "',p10='" + p10 + "',p11='" + p11 + "',p12='" + p12 + "',p13='" + p13 + "',p14='" +
//    p14 + "',p15='" + p15 + "',p16='" + p16 + "',p17='" + p17 + "',p18='" + p18 + "',p19='" + p19 + "',p20='" + p20 + "',p21='" + p21 + "',p22='" +
//    p22 + "',p23='" + p23 + "',p24='" + p24 + "',p25='" + p25 + "',p26='" + p26 + "',p27='" + p27 + "',p28='" + p28 + "',p29='" + p29 + "',p30='" +
//    p30 + "',p31='" + p31 + "',p32='" + p32 + "',p33='" + p33 + "',p34='" + p34 + "',p35='" + p35 + "',p36='" + p36 + "',p37='" + p37 + "',p38='" +
//    p38 + "',p39='" + p39 + "',p40='" + p1 + "',p41='" + p41 + "',p42='" + p42 + "',p43='" + p43 + "',p44='" + p44 + "',date='" +
//    date + "' where  p4='" + p4 + "' and id=" + AlreadyId + "";
//Appsstatus = Convert.ToString(cc.ExecuteNonQuery(Sql));

//}


// Check image is not null. And store it into database.
//if (p36 != "" && status == 1)
//{
//    byte[] MyImg = Convert.FromBase64String(p36); // Convert image string to bytes array.
//    MemoryStream ms = new MemoryStream(MyImg);
//    System.Drawing.Bitmap Image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(ms);
//    int imgWidth = 100;
//    int imgHeight = 150;
//    System.Drawing.Bitmap thimage = ResizeImage(Image, imgWidth, imgHeight);
//    if (thimage != null)
//    {
//        string recordIdSql = "select IDENT_CURRENT('androidlongcode')";
//        string recordId = cc.ExecuteScalar(recordIdSql);

//        // Store thimage image to recordId id.
//    }
//}







//public void UserRegistration(string FName, string LastName, string Mobile)
//{
//    try
//    {
//        string userid = System.Guid.NewGuid().ToString();
//        Random rnd = new Random();
//        UserPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

//        string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword)" +
//                 " values('" + userid + "','" + FName + "','" + LastName + "','" + Mobile + "','" + UserPassword + "')";
//        int ID = cc.ExecuteNonQuery(Sql);
//        if (ID == 1)
//        {
//            // Apart_RegEzeeDevice();
//        }
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}


//if (Appsstatus != "" || Appsstatus != null)
//                   {
//                       usrbalobj.usrMobileNo = p4;
//                       usrbalobj.usrFirstName = p5;
//                       usrbalobj.usrMiddleName = p6;
//                       usrbalobj.usrLastName = p7;
//                       usrbalobj.usrAddress = p8;
//                       usrbalobj.Wardno = p9;
//                       usrbalobj.usrPIN = p10;
//                       usrbalobj.usrDOB = p11;
//                       usrbalobj.UsrAge = Convert.ToInt32(p12);
//                       usrbalobj.usrCarrerInterest = p13; //Job
//                       usrbalobj.usrBestFeature = p15;  //UID
//                       usrbalobj.usrBuild = p16;  //VID
//                       usrbalobj.UsrSocialDesignation = p17; //Social Designation
//                       usrbalobj.usrCategory = p19;  //Category
//                       usrbalobj.Caste = p20;
//                       usrbalobj.Joingroup = p21;
//                       usrbalobj.Marriagedt = p22;
//                       usrbalobj.Jobplace = p23;
//                       usrbalobj.Votterlist = p24;
//                       usrbalobj.usrEmailId = p25;
//                       usrbalobj.Namevosotorlist = p26;
//                       usrbalobj.RationCard = p27;
//                       usrbalobj.OwnHouse = p28;
//                       usrbalobj.Pancard = p29;
//                       usrbalobj.SeniorCitizen = p30;
//                       usrbalobj.RailwayPass = p31;
//                       usrbalobj.Handicap = p32;
//                       usrbalobj.AdharNidhi = p33;
//                       usrbalobj.SAnjayGandhiYojana = p34;
//                       usrbalobj.Anyscholorship = p35;

//                       string sqlget = "select usrUserid from usermaster where usrMobileNo='" + p4 + "'";
//                       string getuserID = cc.ExecuteScalar(sqlget);
//                       //status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
//                       if (getuserID == "" || getuserID == null)
//                       {
//                           Sql = "Update UserMaster Set usrMobileNo='"++"',  usrFirstName='"++"',   usrMiddleName='"++"',   usrLastName='"++"',   usrAddress='"++"',   Wardno='"++"',    usrPIN ='"++"',  usrDOB='"++"',   UsrAge='"++"',   usrCarrerInterest='"++"',   usrBestFeature ='"++"',  usrBuild='"++"',   UsrSocialDesignation ='"++"',  usrCategory ='"++"',  Caste ='"++"',  Joingroup='"++"',   Marriagedt='"++"',   Jobplace ='"++"', "
//                                 "Votterlist='"++"',   usrEmailId='"++"',   Namevosotorlist='"++"',   RationCard ='"++"',  OwnHouse='"++"',   Pancard ='"++"',  SeniorCitizen='"++"',   RailwayPass='"++"',   Handicap='"++"',   AdharNidhi='"++"',  "+
//                                 "SAnjayGandhiYojana='"++"',   Anyscholorship='"++"' where usrMobileNo='"++"' ";
//                           int i = cc.ExecuteNonQuery(Sql);
//                           //status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
//                           if (i == 1)
//                           {
//                               string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
//                               string message = "Welcome " + p5 + ", Your Password is " + myPassword + " www.myct.in";
//                               int smslength = message.Length;
//                               //cc.SendMessageLongCodeSMS("AndroidLongCode", p4, message, smslength);
//                           }

//                       }
//                   }