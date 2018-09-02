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

public partial class html_AndroidLongCode : System.Web.UI.Page
{
    string p1 = "", p2 = "", p3 = "", p4 = "", p5 = "", p6 = "", p7 = "", p8 = "", p9 = "", p10 = "", p11 = "", p12 = "", p13 = "", p14 = "", p15 = "", p16 = "", p17 = "", p18 = "", p19 = "", frmMobileNo = "", p20 = "", p21 = "", p22 = "", p23 = "", p24 = "", p25 = "", p26 = "", p27 = "", p28 = "", p29 = "", p30 = "", p31 = "", p32 = "", p33 = "", p34 = "", p35 = "", p36 = "";
    int status;
    UserRegistrationBLL usrbalobj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
    AndroidLongCodeBLL androidobj = new AndroidLongCodeBLL();
    string Already="";
    @in.myct.telisamaj.www.GetRecordMyct andrdtoteli = new @in.myct.telisamaj.www.GetRecordMyct();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            geturlrecords();
        }
        catch (Exception ex)
        {
        }

    }
    public void geturlrecords()
    {

        try
        {

            //p1 = Convert.ToString(Request.QueryString["p1"]);// SimSerialNo
            //p1 = Get(p1);
            //p2 = Convert.ToString(Request.QueryString["p2"]); //IMEI No
            //p2 = Get(p2);
            //p3 = Convert.ToString(Request.QueryString["p3"]);// Key_Word(Head,Member)
            //p3 = Get(p3);
            //p4 = Convert.ToString(Request.QueryString["p4"]);//mobileNo
            //p4 = Get(p4);
            //p5 = Convert.ToString(Request.QueryString["p5"]);//Firstname
            //p5 = Get(p5);
            //p6 = Convert.ToString(Request.QueryString["p6"]);//middlename
            //p6 = Get(p6);
            //p7 = Convert.ToString(Request.QueryString["p7"]); //last Name
            //p7 = Get(p7);
            //p8 = Convert.ToString(Request.QueryString["p8"]); // Address 
            //p8 = Get(p8);
            //p9 = Convert.ToString(Request.QueryString["p9"]); // Word No
            //p9 = Get(p9);
            //p10 = Convert.ToString(Request.QueryString["p10"]); // Pin Code
            //p10 = Get(p10);
            //p11 = Convert.ToString(Request.QueryString["p11"]); // DOB
            //p11 = Get(p11);
            //p12 = Convert.ToString(Request.QueryString["p12"]);// Age
            //p12 = Get(p12);
            //p13 = Convert.ToString(Request.QueryString["p13"]); // Job
            //p13 = Get(p13);
            //p14 = Convert.ToString(Request.QueryString["p14"]); //Education
            //p14 = Get(p14);
            //p15 = Convert.ToString(Request.QueryString["p15"]); // Aadhar No.
            //p15 = Get(p15);
            //p16 = Convert.ToString(Request.QueryString["p16"]); //  Votter ID
            //p16 = Get(p16);
            //p17 = Convert.ToString(Request.QueryString["p17"]); // Social ID
            //p17 = Get(p17);
            //p18 = Convert.ToString(Request.QueryString["p18"]);// Religion
            //p18 = Get(p18);
            //p19 = Convert.ToString(Request.QueryString["p19"]); // category
            //p19 = Get(p19);
            //string date = Convert.ToString(Request.QueryString["receivedDateTime"]); // date
            //p20 = Convert.ToString(Request.QueryString["p20"]); // caste  
            //p20 = Get(p20);
            //p21 = Convert.ToString(Request.QueryString["p21"]); // Attached to (Belong to party/Community)
            //p21 = Get(p21);
            //p22 = Convert.ToString(Request.QueryString["p22"]); // Marriage Date 
            //p22 = Get(p22);
            //p23 = Convert.ToString(Request.QueryString["p23"]);  // JobPalce 
            //p23 = Get(p23);
            //p24 = Convert.ToString(Request.QueryString["p24"]);  // Votter List No 
            //p24 = Get(p24);
            //p25 = Convert.ToString(Request.QueryString["p25"]);// Emain ID
            //p25 = Get(p25);
            //p26 = Convert.ToString(Request.QueryString["p26"]);// Name in Voter List
            //p26 = Get(p26);
            //p27 = Convert.ToString(Request.QueryString["p27"]); // name in ration Card
            //p27 = Get(p27);
            //p28 = Convert.ToString(Request.QueryString["p28"]); // Own House
            //p28 = Get(p28);
            //p29 = Convert.ToString(Request.QueryString["p29"]); //Pan card
            //p29 = Get(p29);
            //p30 = Convert.ToString(Request.QueryString["p30"]); // Senior Citizen
            //p30 = Get(p30);
            //p31 = Convert.ToString(Request.QueryString["p31"]);  // railway Pass
            //p31 = Get(p31);
            //p32 = Convert.ToString(Request.QueryString["p32"]); //Handicap
            //p32 = Get(p32);
            //p33 = Convert.ToString(Request.QueryString["p33"]); //Aadhar nidhi
            //p33 = Get(p33);
            //p34 = Convert.ToString(Request.QueryString["p34"]); // s.Gandhi Yojana
            //p34 = Get(p34);
            //p35 = Convert.ToString(Request.QueryString["p35"]); // Scholarship
            //p35 = Get(p35);
            //p36 = Convert.ToString(Request.QueryString["p36"]); // photo
            //p36 = Get(p36);
            

            p1 = Convert.ToString(Request.QueryString["p1"]);
            p1 = Get(p1);
            p2 = Convert.ToString(Request.QueryString["p2"]);
            p2 = Get(p2);
            p3 = Convert.ToString(Request.QueryString["p3"]);
            p3 = Get(p3);
            p4 = Convert.ToString(Request.QueryString["p4"]);
            p4 = Get(p4);
            p5 = Convert.ToString(Request.QueryString["p5"]);
            p5 = Get(p5);
            p6 = Convert.ToString(Request.QueryString["p6"]);
            p6 = Get(p6);
            p7 = Convert.ToString(Request.QueryString["p7"]);
            p7 = Get(p7);
            p8 = Convert.ToString(Request.QueryString["p8"]);
            p8 = Get(p8);
            p9 = Convert.ToString(Request.QueryString["p9"]);
            p9 = Get(p9);
            p10 = Convert.ToString(Request.QueryString["p10"]);
            p10 = Get(p10);
            p11 = Convert.ToString(Request.QueryString["p11"]);
            p11 = Get(p11);
            p12 = Convert.ToString(Request.QueryString["p12"]);
            p12 = Get(p12);
            p13 = Convert.ToString(Request.QueryString["p13"]);
            p13 = Get(p13);
            p14 = Convert.ToString(Request.QueryString["p14"]);
            p14 = Get(p14);
            p15 = Convert.ToString(Request.QueryString["p15"]);
            p15 = Get(p15);
            p16 = Convert.ToString(Request.QueryString["p16"]);
            p16 = Get(p16);
            p17 = Convert.ToString(Request.QueryString["p17"]);
            p17 = Get(p17);
            p18 = Convert.ToString(Request.QueryString["p18"]);
            p18 = Get(p18);
            p19 = Convert.ToString(Request.QueryString["p19"]);
            p19 = Get(p19);
            string date = Convert.ToString(Request.QueryString["receivedDateTime"]);
            p20 = Convert.ToString(Request.QueryString["p20"]);
            p20 = Get(p20);
            p21 = Convert.ToString(Request.QueryString["p21"]);
           p21 = Get(p21);
            p22 = Convert.ToString(Request.QueryString["p22"]);
           p22 = Get(p22);
            p23 = Convert.ToString(Request.QueryString["p23"]);
            p23 = Get(p23);
            p24 = Convert.ToString(Request.QueryString["p24"]);
           p24 = Get(p24);
            p25 = Convert.ToString(Request.QueryString["p25"]);
            p25 = Get(p25);
            p26 = Convert.ToString(Request.QueryString["p26"]);
            p26 = Get(p26);
            p27 = Convert.ToString(Request.QueryString["p27"]);
            p27 = Get(p27);
            p28 = Convert.ToString(Request.QueryString["p28"]);
            p28 = Get(p28);
            p29 = Convert.ToString(Request.QueryString["p29"]);
            p29 = Get(p29);
            p30 = Convert.ToString(Request.QueryString["p30"]);
            p30 = Get(p30);
            p31 = Convert.ToString(Request.QueryString["p31"]);
            p31 = Get(p31);
            p32 = Convert.ToString(Request.QueryString["p32"]);
            p32 = Get(p32);
            p33 = Convert.ToString(Request.QueryString["p33"]);
            p33 = Get(p33);
            p34 = Convert.ToString(Request.QueryString["p34"]);
            p34 = Get(p34);
            p35 = Convert.ToString(Request.QueryString["p35"]);
            p35 = Get(p35);
            p36 = Convert.ToString(Request.QueryString["p36"]);
            p36 = Get(p36);
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
            androidobj.Date = date;
            p3 = p3.ToUpper();
           
            if (p3 == "HEAD" || p3 == "MAIN")
            {
                string SQl = "select id from  androidlongcode  where ='" + p4 + "'";
                Already = cc.ExecuteScalar(SQl);
            }
            else if (p3 == "MEMBER" || p3 == "FAMILY")
            {

                string SQl = "select id from  androidlongcode  where p4='" + p4 + "' and p6='" + p6 + "'";
                Already = cc.ExecuteScalar(SQl);

            }
            else if (p3 == "RELATIVE")
            {
                string SQl = "select id from  androidlongcode  where p4='" + p4 + "' and p5='" + p5 + "'";
                Already = cc.ExecuteScalar(SQl);
            }
            if (Already == "")
            {
                status = androidobj.BLLInsertAndroidData(androidobj);
                if (status > 0)
                {
                   
                    if (p3 == "HEAD" || p3 == "MAIN")
                    {
                        androidobj.Simno = p1;
                        androidobj.Imeino = p2;
                        frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        if (frmMobileNo == "" || frmMobileNo == null)
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
                            //p9=wardno
                            usrbalobj.usrPIN = p10;
                            usrbalobj.usrDOB = p11;
                            usrbalobj.UsrAge = Convert.ToInt32(p12);
                            usrbalobj.usrCarrerInterest = p13; //Job
                            //p14=Education
                            // usrbalobj.usrHighestQualification = Convert.ToInt32(p14);   //Temp comment
                            usrbalobj.usrBestFeature = p15;  //UID
                            usrbalobj.usrBuild = p16;  //VID
                            usrbalobj.UsrSocialDesignation = p17; //Social Designation
                            //usrbalobj.Usrreligion = Convert.ToInt32(p18);  //Religion    //Temp comment
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


                            status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                            if (status > 0)
                            {
                                usrbalobj.usrUserId = System.Guid.NewGuid().ToString();
                                Random rnd = new Random();
                                usrbalobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                                status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
                                if (status > 0)
                                {
                                    string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
                                    string message = "Welcome " + p5 + ", Your Password is " + myPassword + " www.myct.in";
                                    int smslength = message.Length;
                                    //cc.SendMessageLongCodeSMS("AndroidLongCode", p4, message, smslength);


                                }

                            }

                            else
                            {

                            }
                            andrdtoteli.GetMessageAndroidHead(frmMobileNo, p4);
                            //androidlocal.GetMessageAndroid(frmMobileNo,nullvalue,p4, p3); 
                        }
                    }
                    else if (p3 == "MEMBER" || p3 == "FAMILY")
                    {
                        androidobj.Simno = p1;
                        androidobj.Imeino = p2;
                        frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        if (frmMobileNo == "" || frmMobileNo == null)
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
                                status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                                if (status > 0)
                                {
                                    usrbalobj.usrUserId = System.Guid.NewGuid().ToString();
                                    Random rnd = new Random();
                                    usrbalobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                                    status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
                                    if (status > 0)
                                    {
                                        string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
                                        string message = "Welcome " + p7 + ", Your Password is " + myPassword + ",";
                                        message = message + "Now Your " + p5 + " of " + headmobile + " in www.myct.in";
                                        int smslength = message.Length;
                                        //cc.SendMessageLongCodeSMS("AndroidLongCode", p6, message, smslength);


                                    }

                                }

                                else
                                {
                                    string message = "Now Your " + p5 + " of " + headmobile + " in www.myct.in";
                                    int smslength = message.Length;
                                    //cc.SendMessageLongCodeSMS("LongCode", p6, message, smslength);

                                }

                            }


                            andrdtoteli.GetMessageAndroid(frmMobileNo, headmobile, p6, p5, p3);
                            //androidlocal.GetMessageAndroid(frmMobileNo,headmobile, p6, p5);
                        }
                    }

                    else if (p3 == "RELATIVE")
                    {
                        androidobj.Simno = p1;
                        androidobj.Imeino = p2;
                        frmMobileNo = androidobj.BLLGetUseridAndroid(androidobj);
                        if (frmMobileNo == "" || frmMobileNo == null)
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
                                status = usrbalobj.BLLIsExistUserRegistrationInitial(usrbalobj);
                                if (status == 0)
                                {
                                    usrbalobj.usrUserId = System.Guid.NewGuid().ToString();
                                    Random rnd = new Random();
                                    usrbalobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                                    status = usrbalobj.BLLInsertSpecificUserRegistrationAndroid(usrbalobj);
                                    if (status > 0)
                                    {
                                        string myPassword = cc.DESDecrypt(usrbalobj.usrPassword);
                                        string message = "Welcome " + p6 + ", Your Password is " + myPassword + ",";
                                        message = message + "Now Your " + p8 + "of " + headmobile + " in www.myct.in";
                                        int smslength = message.Length;
                                        //cc.SendMessageLongCodeSMS("LongCode", p5, message, smslength);


                                    }

                                }
                                else
                                {
                                    string message = "Now Your " + p8 + " of " + headmobile + " in www.myct.in";
                                    int smslength = message.Length;
                                    //cc.SendMessageLongCodeSMS("LongCode", p5, message, smslength);

                                }



                            }
                            andrdtoteli.GetMessageAndroid(frmMobileNo, headmobile, p5, p8, p3);
                            //androidlocal.GetMessageAndroid(frmMobileNo,headmobile, p6, p5);

                        }
                    }



                }




            }
           
        }
        catch (Exception ex)
        {
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
}
