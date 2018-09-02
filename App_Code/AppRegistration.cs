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


/// <summary>
/// Summary description for AppRegistration
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class AppRegistration : System.Web.Services.WebService
{
    getDataFromMYCT objgetDataEzeeTest = new getDataFromMYCT();

    #region WEB SERVICES OBJECTS

    //http://www.ezeedrug.in//DrugApps.asmx
    ezeedrug.DrugApps drug = new ezeedrug.DrugApps();
    myctDrug.DrugApps drugmyct = new myctDrug.DrugApps();

    onlineExam.ClassApp OnExam = new onlineExam.ClassApp();
    ClassAppDetailsToEzeeTest.InsertClassAppRegistration objclassapp = new InsertClassAppRegistration();
    SendDataToEzeeTest.InsertEzeeTestAppRegistration objeZeeTest = new SendDataToEzeeTest.InsertEzeeTestAppRegistration();
    // SendDataToSchool.ConnectToCT objSchoolData = new SendDataToSchool.ConnectToCT();
    SendDataToezeeorder.InsertUploadedData objEzeeOrder = new SendDataToezeeorder.InsertUploadedData();
    SendDataToeZeeTransport.InserteZeeTransportRegData objEzeeTransport = new SendDataToeZeeTransport.InserteZeeTransportRegData();

    #endregion

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

    //------------------------------------------------------USER REGISTRATION TO MYCT------------------------------------------------------------------

    #region METHOD TO REGISTER USER MASTER TABLE

    public string RegToUserMaster(string MobileNo, string Fname, string Lname, string address, string pincode, string strDevId)
    {
        string uid = String.Empty;

        string str = "SELECT [usrUserId] FROM [Come2myCityDB].[dbo].[UserMaster] WHERE [usrMobileNo] = '" + MobileNo + "'  ";
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

    //------------------------------------------------------ALL ANDROID APPS REGISTRATION--------------------------------------------------------------

    #region REGISTRATION TO ALL APP EZEEDRUGAPPDETAILS TABLE IN MYCT

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

        #region MARKETING
        if (ds.Tables[0].Rows.Count == 0 && keyword == "EZEETEST" && DealerMobNo != "")
        {
            #region MARKETING

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
        else if (ds.Tables[0].Rows.Count > 0 && keyword == "EZEETEST" && DealerMobNo != "")
        {
            string str0 = "select DealerMobNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + AppMobileNo + "' and [keyword]='" + keyword + "'";
            DataSet ds1 = cc.ExecuteDataset(str0);
            string reffralMobNo = ds1.Tables[0].Rows[0]["DealerMobNo"].ToString();
            if (reffralMobNo.ToString() == "0" || reffralMobNo.ToString() == "NULL" || reffralMobNo.ToString() == "" || reffralMobNo.ToString() == null)
            {
                #region MARKETING

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
        }

        #endregion

        if (ds.Tables[0].Rows.Count == 0)
        {
            if (Role_Id == "3")
            {
                string Sqlmyct = "SELECT [EmpMobNo] FROM [Come2myCityDB].[dbo].[EzeeMarketing_AddEmpPermission] WHERE [AppMobNo]='" + RefmobileNo + "'";
                cmd = new SqlCommand(Sqlmyct, con);
                con.Open();
                string empno = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
                if (empno == string.Empty)
                {
                    return "3";
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
    }

    #endregion

    [WebMethod(Description = "METHOD FOR ALL APP REGISTRATION")]
    public string Registration(string AppMobileNo, string RefmobileNo, string strDevId, string strSimSerialNo, string keyword, string firstName,
                               string lastName, string firmName, string address, string SchoolCode, string eMailId, string Role_Id, string pincode,
                               string passcode, string latitude, string longitude, string state, string district, string Taluka, string userType,
                               string DealerMobNo)
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
                string str = "SELECT usrFirstName,usrLastName,usrMobileNo,usrAddress,usrPassword FROM UserMaster WHERE usrUserId = '" + getUserID + "'";
                ds = cc.ExecuteDataset(str);

                if (keyword == "EZEETEST")
                {
                    #region SEND DATA TO EZEETEST

                    //SEND DATA TO EZEETEST DATABASE

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
                    #region SEND DATA TO EZEESCHOOL
                    SendRegDataToEzeeSchool objSchoolData = new SendRegDataToEzeeSchool();

                    string FullName = firstName + " " + lastName;
                    objSchoolData.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getUserID, Role_Id);

                    #endregion
                }
                else if (keyword == "EZEESTORM")
                {
                    #region SEND DATA TO EZEESTORM
                    SendRegDataToEzeeSchool objSchoolData = new SendRegDataToEzeeSchool();

                    string FullName = firstName + " " + lastName;
                    objSchoolData.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getUserID, Role_Id);

                    return "1";

                    #endregion
                }
                else if (keyword == "CLASSAPP")
                {
                    #region SEND DATA TO EZEETEST

                    string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                    objclassapp.InsertClassAppDetailsToeZeeTest(firstName, lastName, firmName, AppMobileNo, Password, address, eMailId, Role_Id, RefmobileNo, strDevId);

                    //CHECK REFMOBNO IS ALREADY REG OR NOT AS WELL AS ROLE

                    string tyU = "SELECT [typeOfUse_Id] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] WHERE mobileNo='" + RefmobileNo + "' AND [keyword]='CLASSAPP'";
                    ds = cc.ExecuteDataset(tyU);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return "1*105";
                    }
                    else
                    {
                        return "1";
                    }

                    #endregion
                }
                else if (keyword == "TRUEVOTER")
                {
                    SendRegDataToTrueVoter objTrueReg = new SendRegDataToTrueVoter();
                    string regValue = string.Empty;

                    #region OTP FOR ALL ROLE VOTER, CANDIDATE AND OFFICER

                    string otpEzee12 = "SELECT OTP,[RefMobileNo],[RoleId],[MobileNo] FROM [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + keyword + "'";
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

                    if (ds3.Tables[0].Rows.Count == 0)
                    {
                        string myMobileNo = string.Empty;
                        if (Role_Id == "1" || Role_Id == "3")
                        {
                            myMobileNo = AppMobileNo;

                            Random rand = new Random();
                            string otpstr = Convert.ToString(rand.Next(1001, 9999));
                            string OTPstr = otpstr;
                            str1 = "INSERT INTO [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] ([IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId],CurrentDate) VALUES ('" + strDevId + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "','" + RefmobileNo + "','" + Role_Id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "')";
                            int result = cc.ExecuteNonQuery(str1);
                            string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ") your otp is " + OTPstr + " " + cc.AddSMS(myMobileNo);
                            int smslength = passwordMessage.Length;
                            cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                            regValue = objTrueReg.newRegistration(firstName, AppMobileNo, AppMobileNo, ds.Tables[0].Rows[0]["usrPassword"].ToString(), OTPstr, " ", lastName, latitude, longitude, eMailId, Role_Id, strDevId, RefmobileNo);

                            return "1";
                        }
                        else
                        {
                            myMobileNo = RefmobileNo;
                            Random rand = new Random();
                            string otpstr = Convert.ToString(rand.Next(1001, 9999));
                            string OTPstr = otpstr;
                            str1 = "INSERT INTO [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] ([IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId],CurrentDate) VALUES ('" + strDevId + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "','" + RefmobileNo + "','" + Role_Id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "')";
                            int result = cc.ExecuteNonQuery(str1);
                            string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                            int smslength = passwordMessage.Length;
                            cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                            regValue = objTrueReg.newRegistration(firstName, AppMobileNo, AppMobileNo, ds.Tables[0].Rows[0]["usrPassword"].ToString(), OTPstr, " ", lastName, latitude, longitude, eMailId, Role_Id, strDevId, RefmobileNo);

                            return "1";
                        }
                    }

                    else if (RefmobileNo != RefMNo1 && AppMobileNo.ToString() == mNo.ToString())
                    {
                        string myMobileNo = "";
                        if (Role_Id == "1" || Role_Id == "3")
                        {
                            myMobileNo = AppMobileNo;
                            Random rand = new Random();
                            string otpstr = Convert.ToString(rand.Next(1001, 9999));
                            string OTPstr = otpstr;
                            str1 = "UPDATE [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] SET [RefMobileNo]='" + RefmobileNo + "',[OTP]='" + OTPstr + "' WHERE [MobileNo]='" + AppMobileNo + "'";
                            int result = cc.ExecuteNonQuery(str1);
                            string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ") your otp is " + OTPstr + " " + cc.AddSMS(myMobileNo);
                            int smslength = passwordMessage.Length;
                            cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                            regValue = objTrueReg.newRegistration(firstName, AppMobileNo, AppMobileNo, ds.Tables[0].Rows[0]["usrPassword"].ToString(), OTPstr, " ", lastName, latitude, longitude, eMailId, Role_Id, strDevId, RefmobileNo);

                            return "1";
                        }
                        else
                        {
                            myMobileNo = RefmobileNo;
                            Random rand = new Random();
                            string otpstr = Convert.ToString(rand.Next(1001, 9999));
                            string OTPstr = otpstr;
                            str1 = "UPDATE [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] SET [RefMobileNo]='" + RefmobileNo + "',[OTP]='" + OTPstr + "' WHERE [MobileNo]='" + AppMobileNo + "'";
                            int result = cc.ExecuteNonQuery(str1);
                            string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                            int smslength = passwordMessage.Length;
                            cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                            regValue = objTrueReg.newRegistration(firstName, AppMobileNo, AppMobileNo, ds.Tables[0].Rows[0]["usrPassword"].ToString(), OTPstr, " ", lastName, latitude, longitude, eMailId, Role_Id, strDevId, RefmobileNo);

                            return "1";
                        }
                    }

                    else if (RefmobileNo == RefMNo1 && AppMobileNo.ToString() == mNo.ToString())
                    {
                        string myMobileNo = "";
                        string sq = "SELECT OTP FROM AllAppRegOTPForTrueVoter WHERE [RefMobileNo]='" + RefMNo1 + "' AND [MobileNo]='" + AppMobileNo + "'";
                        DataSet ds1 = cc.ExecuteDataset(sq);

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            string OTPstr = ds1.Tables[0].Rows[0]["OTP"].ToString();
                            if (OTPstr == null || OTPstr == "0" || OTPstr == "")
                            { }
                            else
                            {
                                if (Role_Id == "1" || Role_Id == "3")
                                {
                                    myMobileNo = AppMobileNo;
                                    string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ") your otp is " + OTPstr + " " + cc.AddSMS(myMobileNo);
                                    int smslength = passwordMessage.Length;
                                    cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
                                }
                                else
                                {
                                    myMobileNo = RefmobileNo;
                                    string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                                    int smslength = passwordMessage.Length;
                                    cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
                                }
                            }
                        }
                        return "1";
                    }

                    #endregion

                    #region OLD CODE

                    //Random otpGenerator = new Random();
                    //string otpNumber = otpGenerator.Next(10000, 99999).ToString();
                    //SendRegDataToTrueVoter objTrueReg = new SendRegDataToTrueVoter();
                    //string regValue = objTrueReg.newRegistration(firstName, AppMobileNo, AppMobileNo, ds.Tables[0].Rows[0]["usrPassword"].ToString(), otpNumber, " ", lastName, latitude, longitude, eMailId, Role_Id, strDevId, RefmobileNo);

                    //#region OTP For All Role '2'
                    //if (Role_Id == "2" || Role_Id == "3")//if Role Is '2'//
                    //{
                    //    string otpEzee12 = "SELECT OTP,[RefMobileNo],[RoleId],[MobileNo] FROM [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] WHERE MobileNo='" + AppMobileNo + "' and Keyword='" + keyword + "'";
                    //    cmd.CommandText = otpEzee12;
                    //    DataSet ds3 = cc.ExecuteDataset(otpEzee12);
                    //    string mNo = string.Empty;
                    //    string RefMNo1 = string.Empty;
                    //    string RoleId1 = string.Empty;

                    //    if (ds3.Tables[0].Rows.Count > 0)
                    //    {
                    //        mNo = Convert.ToString(ds3.Tables[0].Rows[0]["MobileNo"]);
                    //        RefMNo1 = Convert.ToString(ds3.Tables[0].Rows[0]["RefMobileNo"]);
                    //        RoleId1 = Convert.ToString(ds3.Tables[0].Rows[0]["RoleId"]);
                    //    }

                    //    if (ds3.Tables[0].Rows.Count == 0)
                    //    {
                    //        string myMobileNo = RefmobileNo;
                    //        Random rand = new Random();
                    //        string otpstr = Convert.ToString(rand.Next(1001, 9999));
                    //        string OTPstr = otpstr;
                    //        str1 = "INSERT INTO [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] ([IEMINo],[MobileNo],[Keyword],[OTP],[RefMobileNo],[RoleId],CurrentDate) VALUES ('" + strDevId + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "','" + RefmobileNo + "','" + Role_Id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "')";
                    //        int result = cc.ExecuteNonQuery(str1);
                    //        string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                    //        int smslength = passwordMessage.Length;
                    //        cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                    //        return "1";
                    //    }

                    //    else if (RefmobileNo != RefMNo1 && AppMobileNo.ToString() == mNo.ToString())
                    //    {
                    //        string myMobileNo = RefmobileNo;
                    //        Random rand = new Random();
                    //        string otpstr = Convert.ToString(rand.Next(1001, 9999));
                    //        string OTPstr = otpstr;
                    //        str1 = "Update [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] set RefMobileNo='" + RefmobileNo + "',OTP='" + OTPstr + "' where MobileNo='" + AppMobileNo + "'";
                    //        int result = cc.ExecuteNonQuery(str1);
                    //        string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                    //        int smslength = passwordMessage.Length;
                    //        cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                    //        return "1";
                    //    }

                    //    else if (RefmobileNo == RefMNo1 && AppMobileNo.ToString() == mNo.ToString())
                    //    {
                    //        string myMobileNo = RefmobileNo;
                    //        string sq = "select OTP from AllAppRegOTPForTrueVoter where RefMobileNo='" + RefMNo1 + "' and MobileNo='" + AppMobileNo + "'";
                    //        DataSet ds1 = cc.ExecuteDataset(sq);

                    //        if (ds1.Tables[0].Rows.Count > 0)
                    //        {
                    //            string OTPstr = ds1.Tables[0].Rows[0]["OTP"].ToString();
                    //            if (OTPstr == null || OTPstr == "0" || OTPstr == "")
                    //            { }
                    //            else
                    //            {
                    //                string passwordMessage = "Welcome , Mr. " + firstName + "(" + AppMobileNo + ")wants to join under you & his permission code is " + OTPstr + " share it " + cc.AddSMS(myMobileNo);
                    //                int smslength = passwordMessage.Length;
                    //                cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
                    //            }
                    //        }

                    //        return "1";
                    //    }
                    //}
                    //else
                    //{ return "1"; }

                    #endregion
                }
                else if (keyword == "EZEEORDER")
                {
                    #region SEND DATA TO EZEEODER

                    string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                    SendRegDataToEzeeOrder objRegEzeeOrder = new SendRegDataToEzeeOrder();

                    //objEzeeOrder.Registration(getUserID, Password, firmName, userType, firstName, lastName, AppMobileNo, RefmobileNo, eMailId, address, RefmobileNo, pincode, state, district, Taluka, address, passcode, longitude, latitude, strDevId, strSimSerialNo, Role_Id);
                    objRegEzeeOrder.Registration(getUserID, Password, firmName, userType, firstName, lastName, AppMobileNo, RefmobileNo, eMailId, address, RefmobileNo, pincode, state, district, Taluka, address, passcode, longitude, latitude, strDevId, strSimSerialNo, Role_Id);

                    #endregion
                }
                else if (keyword == "EZEETRANSPORT")
                {
                    #region SEND DATA TO EZEE_TRANSPORT

                    SendDataToLoadMe objSendDataloadme = new SendDataToLoadMe();
                    string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                    objSendDataloadme.InsertRegDetails(firstName, lastName, AppMobileNo, eMailId, Password, Convert.ToInt32(userType), RefmobileNo, getUserID, pincode, Convert.ToInt32(state), Convert.ToInt32(district), Convert.ToInt32(Taluka), address, strDevId, strSimSerialNo, longitude, latitude);
                    //objEzeeTransport.InsertRegDetails(firstName, lastName, AppMobileNo, eMailId, Password, Convert.ToInt32(userType), RefmobileNo, getUserID, pincode, Convert.ToInt32(state), Convert.ToInt32(district), Convert.ToInt32(Taluka), address, strDevId, strSimSerialNo, longitude, latitude);

                    #endregion
                }
                else if (keyword == "EVIDYALAYA")
                {
                    SendDataToOkcl objEvidyalaya = new SendDataToOkcl();
                    string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                    int a = objEvidyalaya.InsertDataToEvidyalaya(AppMobileNo, RefmobileNo, Password, strDevId, strSimSerialNo, firstName, lastName, address, eMailId, Convert.ToInt32(Role_Id), pincode, latitude, longitude, Convert.ToInt32(state), Convert.ToInt32(district), Convert.ToInt32(Taluka), getUserID);
                }
            }
            return "1";
        }
        catch (Exception ex)
        {
            string str = ex.Message;
            return str;
        }
    }

    //-----------------------------------------------------SEND OTP FOR FIRST TIME REGISTRATION----------------------------------------------------------------------------------------

    [WebMethod(Description = "NEW METHOD TO SEND OTP ALL APPLICATIONS")]
    public string InsertandSendOtp(string usrMobile, string refMobile, string imeiNumber, string appKeyword)
    {
        try
        {
            // string retStr = objOTPSend.InsertOtpSend(usrMobile, refMobile, imeiNumber, appKeyword);

            string retStr = objOTPSend.InsertOtpSendNew(usrMobile, refMobile, imeiNumber, appKeyword, "01");

           // string retStr = cc.API_PostMethod();
            // string retStr = cc.APIAddBalance();
             //string retStr = cc.API_SMSTransactional(usrMobile, refMobile, imeiNumber, 1,2);
            return retStr;
        }
        catch
        {
            return "ERROR";
        }
    }

    [WebMethod(Description = "NEW METHOD TO SEND OTP ALL APPLICATIONS ROLE WISE")]
    public string InsertandSendOtpRoleWise(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string UserType)
    {
        try
        {
            //string retStr = objOTPSend.InsertOtpSendRoleWise(usrMobile, refMobile, imeiNumber, appKeyword, UserType);
            string retStr = objOTPSend.InsertOtpSendNew(usrMobile, refMobile, imeiNumber, appKeyword, UserType);

            return retStr;
        }
        catch
        {
            return "ERROR";
        }
    }

    [WebMethod(Description = "METHOD TO ALL APPLICATIONS CHECK OTP")]
    public string CheckAllAppOtp(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string otpValue)
    {
        try
        {
            string retStr = objOTPSend.CheckOtpAllApp(usrMobile, refMobile, imeiNumber, appKeyword, otpValue);
            return retStr;
        }
        catch
        {
            return "ERROR";
        }
    }

    [WebMethod(Description = "METHOD TO ALL APPLICATIONS CHECK OTP")]
    public string CheckAllAppOtpRoleWise(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string otpValue)
    {
        try
        {
            //string retStr = objOTPSend.CheckOtpAllAppRoleWise(usrMobile, refMobile, imeiNumber, appKeyword, otpValue);
            string retStr = objOTPSend.CheckOtpAllApp(usrMobile, refMobile, imeiNumber, appKeyword, otpValue);
            return retStr;
        }
        catch
        {
            return "ERROR";
        }
    }

    #region METHOD TO SEND OTP

    //[WebMethod(Description = "METHOD TO SEND OTP")]
    public string sendOTP(string AppMobileNo, string IEMINo, string keyword)
    {
        //-----------------------------------------------FIRST CHK MOBILENO PRESENT IN USERMASTER-----------------------------------------------------------------------------------------------
        string str1 = string.Empty;
        string otpstr = string.Empty;
        string str = "SELECT [usrMobileNo] FROM [UserMaster] WHERE [usrMobileNo] = '" + AppMobileNo + "'";
        ds = cc.ExecuteDataset(str);

        string count = ds.Tables[0].Rows.Count.ToString();

        if (count == "" || count == null || count == "0") // IF MOBILE NUMBER IS NOT REGISTERED WITH MYCT ALL APP REGISTRATION
        {
            string c = "SELECT [IEMINo],[MobileNo],[Keyword],[OTP] FROM [Come2myCityDB].[dbo].[AllAppRegOTP] WHERE [MobileNo]='" + AppMobileNo + "' AND [IEMINo]='" + IEMINo + "' AND [Keyword]='" + keyword + "'";
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
                str1 = "INSERT INTO [Come2myCityDB].[dbo].[AllAppRegOTP] ([IEMINo],[MobileNo],[Keyword],[OTP]) VALUES ('" + IEMINo + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "')";
            }
            else
            {
                str1 = "UPDATE [Come2myCityDB].[dbo].[AllAppRegOTP] SET [OTP]='" + otpstr + "' WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + keyword + "'";
            }

            int result = cc.ExecuteNonQuery(str1);

            //---------- SEND SMS FOR OTP ---------------------
            if (result != 0)
            {
                string myMobileNo = AppMobileNo;
                string OTPstr = otpstr;

                string passwordMessage = "Welcome , Your OTP Verification for App Registration ur Username=" + myMobileNo + " & OTP is " + OTPstr + "  " + cc.AddSMS(myMobileNo);
                int smslength = passwordMessage.Length;
                cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
            }

            return "SUCCESS";
        }
        else
        {
            string mobno = "SELECT [mobileNo],[strDevId],[firstName] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] WHERE [mobileNo]='" + AppMobileNo + "' AND [keyword]='" + keyword + "'";
            ds0 = cc.ExecuteDataset(mobno);

            if (ds0.Tables[0].Rows.Count > 0)
            {
                //------- MOBILE NO PRESENT USERMASTER BUT IMEI CHANGED

                string mobnoApp = Convert.ToString(ds0.Tables[0].Rows[0]["mobileNo"]);
                string iemiApp = Convert.ToString(ds0.Tables[0].Rows[0]["strDevId"]);
                string firstname = Convert.ToString(ds0.Tables[0].Rows[0]["firstName"]);

                if (iemiApp != IEMINo && mobnoApp == AppMobileNo && keyword == "EZEESCHOOLAPP" && keyword == "EZEEMUNICIPALCOUNCIL")
                {
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
                //------ MOBILE NO PRESENT IN USERMASTER BUT NOT IN EZEEALLAPPDRUGDETAILS TABLE 
                string c = "SELECT [IEMINo],[MobileNo],[Keyword],[OTP] FROM [Come2myCityDB].[dbo].[AllAppRegOTP] WHERE [MobileNo]='" + AppMobileNo + "' AND [IEMINo]='" + IEMINo + "' AND [Keyword]='" + keyword + "'";
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
                    str1 = "INSERT INTO [Come2myCityDB].[dbo].[AllAppRegOTP] ([IEMINo],[MobileNo],[Keyword],[OTP]) VALUES ('" + IEMINo + "','" + AppMobileNo + "','" + keyword + "','" + otpstr + "')";
                }
                else
                {
                    str1 = "UPDATE [Come2myCityDB].[dbo].[AllAppRegOTP] SET [OTP]='" + otpstr + "' WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + keyword + "'";
                }

                int result = cc.ExecuteNonQuery(str1);

                //---------- SEND SMS FOR OTP ---------------------
                if (result != 0)
                {
                    string myMobileNo = AppMobileNo;
                    string OTPstr = otpstr;
                    string passwordMessage = "Welcome , Your OTP Verification for App Registration ur Username=" + myMobileNo + " & OTP is " + OTPstr + "  " + cc.AddSMS(myMobileNo);
                    int smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
                }

                return "SUCCESS";
            }
        }
    }

    #endregion

    //-----------------------------------------------------OTP REGISTRATIONS CHECK IN IMEI_SMS_TABLE-----------------------------------------------------------------------------------

    #region METHOD TO CHECK OTP

    //[WebMethod(Description = "METHOD TO CHECK OTP")]
    public string chkOTP(string AppMobileNo, string OTP, string keyword, string iemiNo)
    {
        cmd.Connection = con;
        string otpEzee1 = "SELECT OTP FROM [Come2myCityDB].[dbo].[AllAppRegOTP] WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + keyword + "'";
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

    //-----------------------------------------------------OTP REGISTRATIONS CHECK IN FOR TRUEVOTER-----------------------------------------------------------------------------------

    #region METHOD TO CHECK OTP FOR TRUEVOTER

    [WebMethod(Description = "METHOD TO CHECK OTP FOR TRUEVOTER")]
    public string chkOTPForTrueVoter(string AppMobileNo, string OTP, string keyword, string iemiNo, string RefMobileNo)
    {
        if (RefMobileNo == null || RefMobileNo == "")
        {
            RefMobileNo = "0";
        }
        OTP = EncryptDecrypt.DecodeAndDecrypt(OTP);
        cmd.Connection = con;
        string otpEzee1 = "SELECT [OTP] FROM [Come2myCityDB].[dbo].[AllAppRegOTPForTrueVoter] WHERE [MobileNo] = '" + AppMobileNo + "' AND [Keyword] = '" + keyword + "' AND [RefMobileNo]='" + RefMobileNo + "'";
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
                string otpVal = checkOtp(AppMobileNo, OTP);
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

    public string checkOtp(string mobileNo, string otp)
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
        SqlCommand sqlCommand = null;
        int Error = CommonCode.OK1;

        try
        {
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "[TrueVoterDB].[dbo].[uspCheckOTP]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter registrationSqlParameter = new SqlParameter("@regid", "");
            registrationSqlParameter.Direction = ParameterDirection.Output;
            registrationSqlParameter.SqlDbType = SqlDbType.NVarChar;
            registrationSqlParameter.Size = 20;

            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@mobileNo", mobileNo), new SqlParameter("@otp", otp), registrationSqlParameter };
            sqlCommand.Parameters.AddRange(sqlParameter);
            SqlParameter returnValue = sqlCommand.CreateParameter();
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnValue);

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

            if (Convert.ToString(returnValue.Value) == "1")
                return CommonCode.OK.ToString() + "*" + sqlCommand.Parameters["@regid"].Value.ToString();
            else if (Convert.ToString(returnValue.Value) == "4")
                return CommonCode.FAIL.ToString();
            else if (Convert.ToString(returnValue.Value) == "2")
                return CommonCode.WRONG_INPUT.ToString();
            else
                return Convert.ToString(returnValue.Value);
        }
        catch (SqlException sqlException)
        {
            return CommonCode.SQL_ERROR.ToString();
        }
        catch (Exception excepiton)
        {
            return CommonCode.ERROR.ToString();
        }
        finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
    }

    #endregion
}