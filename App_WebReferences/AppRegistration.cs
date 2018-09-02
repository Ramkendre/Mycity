using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ClassAppDetailsToEzeeTest;
using SendDataToezeeorder;

/// <summary>
/// Summary description for AppRegistration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AppRegistration : System.Web.Services.WebService
{
    getDataFromMYCT objgetDataEzeeTest = new getDataFromMYCT();

    #region WebserviceCbject

    //http://www.ezeedrug.in//DrugApps.asmx
    ezeedrug.DrugApps drug = new ezeedrug.DrugApps();
    myctDrug.DrugApps drugmyct = new myctDrug.DrugApps();

    onlineExam.ClassApp OnExam = new onlineExam.ClassApp();
    ClassAppDetailsToEzeeTest.InsertClassAppRegistration objclassapp = new InsertClassAppRegistration();
    SendDataToEzeeTest.InsertEzeeTestAppRegistration objeZeeTest = new SendDataToEzeeTest.InsertEzeeTestAppRegistration();
    SendDataToSchool.ConnectToCT objSchoolData = new SendDataToSchool.ConnectToCT();
    SendDataToezeeorder.InsertUploadedData objEzeeOrder = new SendDataToezeeorder.InsertUploadedData();

    #endregion WebserviceCbject

    OTP objOTPSend = new OTP();

    CommonCode cc = new CommonCode();
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();
    DataSet ds0 = new DataSet();
    public AppRegistration()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    //------------------------------------------------------User Registration To MYCT------------------------------------------------------------------

    #region RegToUserMaster
    public string RegToUserMaster(string MobileNo, string Fname, string Lname, string address, string pincode, string strDevId)
    {
        string uid = String.Empty;

        string str = "select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + MobileNo + "'  ";
        uid = cc.ExecuteScalar(str);
        if (uid == "" || uid == null)
        {
            string newUid = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            string Password = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            cmd.Parameters.AddWithValue("@usrMobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@usrFirstName", Fname);
            cmd.Parameters.AddWithValue("@usrLastName", Lname);
            cmd.Parameters.AddWithValue("@usrPassword", Password);
            cmd.Parameters.AddWithValue("@usrAddress", address);
            cmd.Parameters.AddWithValue("@usrPIN", pincode);
            cmd.Parameters.AddWithValue("@strDevId", strDevId);
            cmd.Parameters.AddWithValue("@usrUserId", newUid);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspUserMasterInsert";
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            int i = cmd.ExecuteNonQuery();
            //----------Send SMS---------------------
            if (i > 0)
            {

                string myMobileNo = MobileNo;
                string myPassword = cc.DESDecrypt(Password);
                string myName = Fname;
                string passwordMessage = "Welcome " + myName + ",for ur First Login for MyCt Password Username=" + myMobileNo + " & Password is " + myPassword + "  " + cc.AddSMS(myMobileNo);
                int smslength = passwordMessage.Length;
                cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

            }
            uid = newUid;
        }

        return uid;
    }
    #endregion

    //------------------------------------------------------All Android Apps Registration--------------------------------------------------------------

    #region ToAllAppReg
    public string RegToAllAppEzeeDrug(string AppMobileNo, string RefmobileNo, string strDevId, string strSimSerialNo, string keyword, string firstName, string lastName, string firmName,
                                       string address, string SchoolCode, string eMailId, string Role_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Taluka, string userType, string getuserId, string date, string DealerMobNo)
    {

        string otp = string.Empty;
        string eid = "select EzeeDrugAppId from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + AppMobileNo + "' and [keyword]='" + keyword + "'";
        ds = cc.ExecuteDataset(eid);

        string pass = "select usrPassword FROM [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + AppMobileNo + "'";
        DataSet ds0 = cc.ExecuteDataset(pass);
        string passw = ds0.Tables[0].Rows[0]["usrPassword"].ToString();
        string myPassword = cc.DESDecrypt(passw);
        if (ds.Tables[0].Rows.Count == 0 && keyword == "EZEETEST")
        {            
            #region Marketing
            //For Managing marketing Tree 
            //string deal = "INSERT INTO tbl_TreeDemOfMarketingSection([Parent_MobileNo],[Child_MobileNo],[ParentName],[ChildName],[ProjectName],[Role],[CurrentDate])VALUES('" + DealerMobNo + "','" + AppMobileNo + "','','" + firstName + "','" + keyword + "','Personal','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "')";
            //cc.ExecuteNonQuery(deal);
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Child_MobileNo", AppMobileNo);
            cmd.Parameters.AddWithValue("@ProjectName", keyword.ToUpper());
            cmd.Parameters.AddWithValue("@Parent_MobileNo", DealerMobNo);
            cmd.Parameters.AddWithValue("@ChildName", firstName);

            cmd.Connection = con;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertIntoEzeeMarkingForEzeeTest";

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            #endregion
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@appMobileNo", AppMobileNo);
            cmd.Parameters.AddWithValue("@keyword", keyword.ToUpper());
            cmd.Parameters.AddWithValue("@strDevId", strDevId);
            cmd.Parameters.AddWithValue("@strSimSerialNo", strSimSerialNo);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@firmName", firmName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@eMailId", eMailId);
            cmd.Parameters.AddWithValue("@typeOfUse_Id", Role_Id);
            cmd.Parameters.AddWithValue("@pincode", pincode);
            cmd.Parameters.AddWithValue("@passcode", passcode);
            cmd.Parameters.AddWithValue("@latitude", latitude);
            cmd.Parameters.AddWithValue("@longitude", longitude);
            cmd.Parameters.AddWithValue("@UserId", getuserId);
            cmd.Parameters.AddWithValue("@RefMobileNo", RefmobileNo);
            cmd.Parameters.AddWithValue("@State", state);
            cmd.Parameters.AddWithValue("@District", district);
            cmd.Parameters.AddWithValue("@Taluka", Taluka);
            cmd.Parameters.AddWithValue("@usertype", userType);
            cmd.Parameters.AddWithValue("@schoolcode", SchoolCode);
            cmd.Parameters.AddWithValue("@EntryDate", date);
            cmd.Parameters.AddWithValue("@passcodelimit", "10");
            cmd.Parameters.AddWithValue("@OTP", myPassword);
            cmd.Parameters.AddWithValue("@DealerMobNo", DealerMobNo);
            cmd.Connection = con;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspEzeeAllAppRegInsert";
                if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return "1";
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@appMobileNo", AppMobileNo);
            cmd.Parameters.AddWithValue("@keyword", keyword.ToUpper());
            cmd.Parameters.AddWithValue("@strDevId", strDevId);
            cmd.Parameters.AddWithValue("@strSimSerialNo", strSimSerialNo);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@firmName", firmName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@eMailId", eMailId);
            cmd.Parameters.AddWithValue("@typeOfUse_Id", Role_Id);
            cmd.Parameters.AddWithValue("@pincode", pincode);
            cmd.Parameters.AddWithValue("@passcode", passcode);
            cmd.Parameters.AddWithValue("@latitude", latitude);
            cmd.Parameters.AddWithValue("@longitude", longitude);
            cmd.Parameters.AddWithValue("@UserId", getuserId);
            cmd.Parameters.AddWithValue("@RefMobileNo", RefmobileNo);
            cmd.Parameters.AddWithValue("@State", state);
            cmd.Parameters.AddWithValue("@District", district);
            cmd.Parameters.AddWithValue("@Taluka", Taluka);
            cmd.Parameters.AddWithValue("@usertype", userType);
            cmd.Parameters.AddWithValue("@schoolcode", SchoolCode);
            cmd.Parameters.AddWithValue("@EntryDate", date);
            cmd.Parameters.AddWithValue("@passcodelimit", "10");
            cmd.Connection = con;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspEzeeAllAppRegInsert";
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return "1";
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }

        }

    }
    #endregion

    [WebMethod]
    public string Registration(string AppMobileNo, string RefmobileNo, string strDevId, string strSimSerialNo, string keyword, string firstName, string lastName, string firmName,
                                       string address, string SchoolCode, string eMailId, string Role_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Taluka, string userType, string DealerMobNo)
    {
        try
        {
            string str1 = string.Empty;
            string date = cc.DateFormatStatus();
            keyword = keyword.ToUpper();
            string getUserID = RegToUserMaster(AppMobileNo, firstName, lastName, address, pincode, strDevId);
            if (string.IsNullOrEmpty(getUserID)) { }
            else
            {
                str1 = RegToAllAppEzeeDrug(AppMobileNo, RefmobileNo, strDevId, strSimSerialNo, keyword, firstName, lastName, firmName, address, SchoolCode, eMailId, Role_Id, pincode, passcode, latitude, longitude, state, district, Taluka, userType, getUserID, date, DealerMobNo);
                string str = "select usrFirstName,usrLastName,usrMobileNo,usrAddress,usrPassword from UserMaster where usrUserId='" + getUserID + "'";
                ds = cc.ExecuteDataset(str);

                if (keyword == "EZEETEST")
                {
                    #region SendDataToEzeeTest
                    //send Data To EzeeTest Database                 
                    string fullName = ds.Tables[0].Rows[0]["usrFirstName"].ToString() + " " + ds.Tables[0].Rows[0]["usrLastName"].ToString();
                    string MobileNo = ds.Tables[0].Rows[0]["usrMobileNo"].ToString();
                    string Address = ds.Tables[0].Rows[0]["usrAddress"].ToString();
                    string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                    objeZeeTest.InsertEzeeTestRegistrationData(MobileNo, Password, fullName, Address);
                    return "1";
                    #endregion
                }
                else if (keyword == "EZEESCHOOLAPP")
                {
                    #region SendDataToEzeeSchool
                    string FullName = firstName + " " + lastName;
                    objSchoolData.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getUserID, Role_Id);
                    #endregion
                }
                else if (keyword == "EZEESTORM")
                {
                    #region SendDataToEzeeStorm
                    string FullName = firstName + " " + lastName;
                    objSchoolData.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getUserID, Role_Id);
                    return "1";
                    #endregion
                }
                else if (keyword == "CLASSAPP")
                {
                    #region SendDataToEzeeTest
                    string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                    objclassapp.InsertClassAppDetailsToeZeeTest(firstName, lastName, firmName, AppMobileNo, Password, address, eMailId, Role_Id, RefmobileNo, strDevId);
                    return "1";
                    #endregion
                }
                else if (keyword == "TRUEVOTER")
                {
                    #region OTP For Role is '2'
                    if (Role_Id == "2" || Role_Id == "3")//if Role Is '2'//
                    {
                        string otpEzee12 = "select OTP,[RefMobileNo],[RoleId],[MobileNo] from [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] where MobileNo='" + AppMobileNo + "' and Keyword='" + keyword + "'";
                        cmd.CommandText = otpEzee12;
                        DataSet ds3 = cc.ExecuteDataset(otpEzee12);
                        string mNo = string.Empty;
                        string RefMNo1 = string.Empty;
                        string RoleId1 = string.Empty;
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            mNo = Convert.ToString(ds3.Tables[0].Rows[0]["MobileNo"]);
                            RefMNo1 = Convert.ToString(ds3.Tables[0].Rows[0]["RefMobileNo"]);
                            RoleId1 = Convert.ToString(ds3.Tables[0].Rows[0]["RoleId"]);
                        }
                        if(ds3.Tables[0].Rows.Count == 0)
                        {
                            string myMobileNo = RefmobileNo;
                            Random rand = new Random();
                            string otpstr = Convert.ToString(rand.Next(1001, 9999));
                            string OTPstr = otpstr;
                            str1 = "Insert into [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter]([IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId],CurrentDate) values('" + strDevId + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "','" + RefmobileNo + "','" + Role_Id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "')";
                            int result = cc.ExecuteNonQuery(str1);
                            string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                            int smslength = passwordMessage.Length;
                            cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
                            return "1";
                        }
                        else if (RefmobileNo != RefMNo1 && AppMobileNo.ToString() == mNo.ToString())
                        {
                            string myMobileNo = RefmobileNo;
                            Random rand = new Random();
                            string otpstr = Convert.ToString(rand.Next(1001, 9999));
                            string OTPstr = otpstr;
                            str1 = "Update [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] set RefMobileNo='" + RefmobileNo + "',OTP='"+OTPstr+"' where MobileNo='" + AppMobileNo + "'";
                            int result = cc.ExecuteNonQuery(str1);
                            string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                            int smslength = passwordMessage.Length;
                            cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
                            return "1";
                        }
                        else if (RefmobileNo == RefMNo1 && AppMobileNo.ToString() == mNo.ToString())
                        { 
                            string myMobileNo = RefmobileNo;
                            string sq = "select OTP from AllAppRegOTPForTrueVoter where RefMobileNo='" + RefMNo1 + "' and MobileNo='" + AppMobileNo + "'";
                            DataSet ds1 = cc.ExecuteDataset(sq);
                            
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    string OTPstr = ds1.Tables[0].Rows[0]["OTP"].ToString();
                                    if (OTPstr == null || OTPstr == "0" || OTPstr == "")
                                    {}
                                    else
                                    {
                                        string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                                        int smslength = passwordMessage.Length;
                                        cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
                                    }
                                }
                          
                            return "1";
                        }
                    }

                    else
                    { return "1"; }
                    #endregion
                }
                else if (keyword == "EZEEORDER")
                {
                    #region SendDataToEzeeOder
                    string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                    objEzeeOrder.Registration(getUserID, Password, firmName, userType, firstName, lastName, AppMobileNo, RefmobileNo, eMailId, address,RefmobileNo, pincode, state, district, Taluka,address, passcode, longitude, latitude, strDevId, strSimSerialNo,Role_Id);
                    //remaining

                    #endregion
                }
                //else
                //{
                //    return "1";
                //}
            }
            return "1";
        }
        catch (Exception ex)
        {
            string str = ex.Message;
            return str;
            //return "0";
        }
        //return "1";
    }

    //-----------------------------------------------------Send OTP For First Time Registration----------------------------------------------------------------------------------------

    #region SendOTP
    [WebMethod]
    public string sendOTP(string AppMobileNo, string IEMINo, string keyword)
    {
        //-----------------------------------------------first chk MobileNo present in UserMaster-----------------------------------------------------------------------------------------------
        string str1 = string.Empty;
        string otpstr = string.Empty;
        string str = "select usrMobileNo from UserMaster where usrMobileNo='" + AppMobileNo + "'";
        ds = cc.ExecuteDataset(str);
        string count = ds.Tables[0].Rows.Count.ToString();

        if (count == "" || count == null || count == "0")
        {
            string c = "select [IEMINo],[MobileNo],[Keyword],[OTP] FROM [Come2myCityDB].[dbo].[AllAppRegOTP] where MobileNo='" + AppMobileNo + "' and IEMINo='" + IEMINo + "' and Keyword='" + keyword + "'";
            ds = cc.ExecuteDataset(c);
            string count1 = Convert.ToString(ds.Tables[0].Rows.Count);
            if (ds.Tables[0].Rows.Count > 0)
            {
                otpstr = Convert.ToString(ds.Tables[0].Rows[0]["OTP"]);
            }
            if (count1 == "" || count1 == null || count1 == "0")
            {
                Random rand = new Random();
                otpstr = Convert.ToString(rand.Next(1001, 9999));
                str1 = "Insert into [Come2myCityDB].[dbo].[AllAppRegOTP]([IEMINo],[MobileNo],[Keyword],[OTP]) values('" + IEMINo + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "')";
            }
            else
            {
                str1 = "update [Come2myCityDB].[dbo].[AllAppRegOTP] set OTP='" + otpstr + "' where [MobileNo]='" + AppMobileNo + "' and [Keyword]='" + keyword + "'";
            }

            int result = cc.ExecuteNonQuery(str1);
            //---------- Send SMS for OTP ---------------------
            if (result > 0)
            {

                string myMobileNo = AppMobileNo;
                string OTPstr = otpstr;
                //string myName = firstname;
                string passwordMessage = "Welcome , Your OTP Verification for App Registration ur Username=" + myMobileNo + " & OTP is " + OTPstr + "  " + cc.AddSMS(myMobileNo);
                int smslength = passwordMessage.Length;
                cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

            }
            return "SUCCESS";
        }
        else
        {
            string mobno = "select mobileNo,strDevId,firstName from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + AppMobileNo + "' and keyword='" + keyword + "'";
            ds0 = cc.ExecuteDataset(mobno);
            if (ds0.Tables[0].Rows.Count > 0)
            {
                //-------mobile No present userMasert but IEMI Changed

                string mobnoApp = Convert.ToString(ds0.Tables[0].Rows[0]["mobileNo"]);
                string iemiApp = Convert.ToString(ds0.Tables[0].Rows[0]["strDevId"]);
                string firstname = Convert.ToString(ds0.Tables[0].Rows[0]["firstName"]);
                if (iemiApp != IEMINo && mobnoApp == AppMobileNo && keyword == "EZEESCHOOLAPP" && keyword == "EZEEMUNICIPALCOUNCIL")
                {
                    //otp = objOTPSend.SendOTP(AppMobileNo, strDevId, keyword.ToUpper());
                    string otp = objOTPSend.SendOTP(AppMobileNo, IEMINo, keyword.ToUpper(), firstname);
                    return "SUCCESS";
                }
                else
                {
                    return "CONTINUE";
                }
            }
            else
            {
                //------mobile No present in usermaster but not in ezeeAllApp Table 
                string c = "select [IEMINo],[MobileNo],[Keyword],[OTP] FROM [Come2myCityDB].[dbo].[AllAppRegOTP] where MobileNo='" + AppMobileNo + "' and IEMINo='" + IEMINo + "' and Keyword='" + keyword + "'";
                ds = cc.ExecuteDataset(c);
                string count2 = Convert.ToString(ds.Tables[0].Rows.Count);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    otpstr = Convert.ToString(ds.Tables[0].Rows[0]["OTP"]);
                }
                if (count2 == "" || count2 == null || count2 == "0")
                {
                    Random rand = new Random();
                    otpstr = Convert.ToString(rand.Next(1001, 9999));
                    str1 = "Insert into [Come2myCityDB].[dbo].[AllAppRegOTP]([IEMINo],[MobileNo],[Keyword],[OTP]) values('" + IEMINo + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "')";
                }
                else
                {
                    str1 = "update [Come2myCityDB].[dbo].[AllAppRegOTP] set OTP='" + otpstr + "' where [MobileNo]='" + AppMobileNo + "' and [Keyword]='" + keyword + "'";
                }

                int result = cc.ExecuteNonQuery(str1);
                //---------- Send SMS for OTP ---------------------
                if (result > 0)
                {

                    string myMobileNo = AppMobileNo;
                    string OTPstr = otpstr;
                    //string myName = firstname;
                    string passwordMessage = "Welcome , Your OTP Verification for App Registration ur Username=" + myMobileNo + " & OTP is " + OTPstr + "  " + cc.AddSMS(myMobileNo);
                    int smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                }
                return "SUCCESS";
            }

        }


    }
    #endregion

    //-----------------------------------------------------OTP Registrations Check in IMEI_SMS_Table-----------------------------------------------------------------------------------

    #region CheckOTP
    [WebMethod]
    public string chkOTP(string AppMobileNo, string OTP, string keyword, string iemiNo)
    {
        cmd.Connection = con;
        string otpEzee1 = "select OTP from [Come2myCityDB].[dbo].[AllAppRegOTP] where MobileNo='" + AppMobileNo + "' and Keyword='" + keyword + "'";
        cmd.CommandText = otpEzee1;
        DataSet ds2 = cc.ExecuteDataset(otpEzee1);
        string otpEzee = Convert.ToString(ds2.Tables[0].Rows[0][0]);

        if (OTP.ToString() == otpEzee.ToString())
        {
            try
            {
                cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@appMobileNo", AppMobileNo);
                cmd.Parameters.AddWithValue("@keyword", keyword.ToUpper());
                cmd.Parameters.AddWithValue("@strDevId", iemiNo);



                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspEzeeAllAppRegUpdateOTP";

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }

            return "1";
        }
        else
        {

            return "0";
        }
    }
    #endregion

    //-----------------------------------------------------OTP Registrations Check in for TrueVoter-----------------------------------------------------------------------------------

    #region CheckOTPForTrueVoter
    [WebMethod]
    public string chkOTPForTrueVoter(string AppMobileNo, string OTP, string keyword, string iemiNo, string RefMobileNo)
    {
        cmd.Connection = con;
        string otpEzee1 = "select OTP from [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] where MobileNo='" + AppMobileNo + "' and Keyword='" + keyword + "' and [RefMobileNo]='" + RefMobileNo + "'";
        cmd.CommandText = otpEzee1;
        DataSet ds2 = cc.ExecuteDataset(otpEzee1);
        string otpEzee = Convert.ToString(ds2.Tables[0].Rows[0][0]);

        if (OTP.ToString() == otpEzee.ToString())
        {
            try
            {
                cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@appMobileNo", AppMobileNo);
                cmd.Parameters.AddWithValue("@keyword", keyword.ToUpper());
                cmd.Parameters.AddWithValue("@strDevId", iemiNo);
                cmd.Parameters.AddWithValue("@RefMobileNo", RefMobileNo);


                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspEzeeAllAppRegUpdateOTPForTrueVoter";

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }

            return "1";
        }
        else
        {

            return "0";
        }
    }
    #endregion
}