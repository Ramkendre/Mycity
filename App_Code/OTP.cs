using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class OTP
{
    CommonCode cc = new CommonCode();
    Random rand = new Random();
    string firstName = string.Empty;

    public OTP()
    {

    }

    public string SendOTP(string AppMobileNo, string deviceId, string key, string firstname)
    {

        //------IMEINo-Different And MobileNo,Keyword=Already Present-----------------
        //-------OTP When MobileNo alredy Present then-----------------

        Random rand = new Random();
        string passwordStr = rand.Next(1001, 9999).ToString();
        string d = "SELECT [IMEI_NO] FROM [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData] WHERE [IMEI_NO] = '" + deviceId + "' AND [ProjName] = '" + key + "'";
        DataSet ds = cc.ExecuteDataset(d);

        if (ds.Tables[0].Rows.Count == 0)
        {
            string sql = "INSERT INTO [Come2myCityDB].[dbo].[AllAppRegOTP] ([IEMINo],[MobileNo],[Keyword],[OTP]) VALUES ('" + deviceId + "','" + AppMobileNo + "','" + key + "','" + passwordStr + "')";
            int p = cc.ExecuteNonQuery(sql);
        }
        else
        {
            string str = "UPDATE [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData] SET [OTP]='" + passwordStr + "' WHERE [IMEI_NO]='" + deviceId + "' AND [ProjName]='" + key + "'";
        }

        string sql1 = "UPDATE [Come2myCityDB].[dbo].[AllAppRegOTP] SET [OTP]='" + passwordStr + "' WHERE [MobileNo]='" + AppMobileNo + "' AND [Keyword]='" + key + "'";
        int s1 = cc.ExecuteNonQuery(sql1);

        //----------Send SMS---------------------
        if (s1 != 0)
        {
            string myMobileNo = AppMobileNo;
            string OTPstr = passwordStr;
            string myName = firstname;
            string passwordMessage = "Welcome " + myName + ",for ur OTP Verification Login Username=" + myMobileNo + " & OTP is " + OTPstr + "  " + cc.AddSMS(myMobileNo);
            int smslength = passwordMessage.Length;
            cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
        }
        return passwordStr;
    }

    public string returnCurDate()
    {
        TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        string dt = indianTime.ToString("yyyy-MM-dd hh:mm:ss tt");
        return dt;
    }

    //public string InsertOtpSend(string usrMobile, string refMobile, string imeiNumber, string appKeyword)   Date:-28-04-2017 Old Method
    //{
    //    appKeyword = appKeyword.ToUpper();
    //    string otp = string.Empty;
    //    string refmobile = string.Empty;
    //    string imeinumber = string.Empty;
    //    string firstName = string.Empty;

    //    if (appKeyword == "IAYAPP" || appKeyword == "EVIDYALAYA" || appKeyword == "MYCTAPP" || appKeyword == "EZEEMUNICIPALCOUNCIL")
    //    {
    //        //string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [RefMobileNumber] = '" + refMobile + "' AND [IMEINumber] = '" + imeiNumber + "' AND [AppKeyword] = '" + appKeyword + "' ";
    //        string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "'";
    //        DataSet ds1 = cc.ExecuteDataset(sqlQuery1);

    //        if (ds1.Tables[0].Rows.Count > 0)
    //        {
    //            otp = ds1.Tables[0].Rows[0]["OTP"].ToString();
    //            refmobile = ds1.Tables[0].Rows[0]["RefMobileNumber"].ToString();
    //            imeinumber = ds1.Tables[0].Rows[0]["IMEINumber"].ToString();

    //            if (refMobile != refmobile)
    //            {
    //                Random rand = new Random();
    //                string otpstr = Convert.ToString(rand.Next(1001, 9999));
    //                otp = otpstr;

    //                string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [RefMobileNumber] = '" + refMobile + "',[OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
    //                cc.ExecuteNonQuery(sqlQuery2);

    //                string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
    //                int smslength = passwordMessage.Length;
    //                cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
    //                return "SEND";
    //            }

    //            if (imeiNumber != imeinumber)
    //            {
    //                Random rand = new Random();
    //                string otpstr = Convert.ToString(rand.Next(1001, 9999));
    //                otp = otpstr;

    //                string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IMEINumber] = '" + imeiNumber + "', [OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
    //                cc.ExecuteNonQuery(sqlQuery2);

    //                string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
    //                int smslength = passwordMessage.Length;
    //                cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
    //                return "SEND";
    //            }

    //            if (string.IsNullOrEmpty(otp) || otp == "0")
    //            {
    //                return "VERIFIED";
    //            }

    //            if (otp != null || otp != "" || otp != "0")
    //            {
    //                string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
    //                int smslength = passwordMessage.Length;
    //                cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
    //                return "SEND";
    //            }
    //        }
    //        else
    //        {
    //            Random rand = new Random();
    //            string otpstr = Convert.ToString(rand.Next(1001, 9999));
    //            otp = otpstr;

    //            string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0')";
    //            cc.ExecuteNonQuery(sqlQuery2);

    //            string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
    //            int smslength = passwordMessage.Length;
    //            cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
    //            return "SEND";
    //        }
    //    }
    //    return "0";
    //}

    public string CheckOtpAllApp(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string otpValue)
    {
        string otp = string.Empty;
        string returnString = "0";
        string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [RefMobileNumber] = '" + refMobile + "' AND [IMEINumber] = '" + imeiNumber + "' AND [AppKeyword] = '" + appKeyword + "' ";
        DataSet ds = cc.ExecuteDataset(sqlQuery1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            otp = ds.Tables[0].Rows[0]["OTP"].ToString();

            if (otp == otpValue)
            {
                string sqlQuery9 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                cc.ExecuteNonQuery(sqlQuery9);

                string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [OTP] = '',[IsActive]=1 WHERE [UserMobileNumber] = '" + usrMobile + "' AND [RefMobileNumber] = '" + refMobile + "' AND [IMEINumber] = '" + imeiNumber + "' AND [AppKeyword] = '" + appKeyword + "' ";
                cc.ExecuteNonQuery(sqlQuery2);
                returnString = "1";
                return returnString;
            }
        }
        else
        {
            return returnString;
        }
        return returnString;
    }


    public string CheckOtpAllAppRoleWise(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string otpValue)
    {
        string otp = string.Empty; string SQL = string.Empty;
        string returnString = "0"; int result = 0;
        try
        {
            string sql = "SELECT SNO,[UserMobileNumber] FROM [tblAllAppOTP] WHERE IMEINumber='" + imeiNumber + "' and AppKeyword='" + appKeyword + "'";
            DataSet DS = cc.ExecuteDataset(sql);
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                SQL = "UPDATE [tblAllAppOTP] SET [IsActive]=0 WHERE SNO=" + DS.Tables[0].Rows[i][0] + "";
                result = cc.ExecuteNonQuery(SQL);
            }

            string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "'  AND [IMEINumber] = '" + imeiNumber + "' AND [AppKeyword] = '" + appKeyword + "' "; //AND [RefMobileNumber] = '" + refMobile + "'
            DataSet ds = cc.ExecuteDataset(sqlQuery1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                otp = ds.Tables[0].Rows[0]["OTP"].ToString();
                if (otp == otpValue)
                {
                    string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [OTP] ='0',[IsActive]=1  WHERE [UserMobileNumber] = '" + usrMobile + "'  AND [IMEINumber] = '" + imeiNumber + "' AND [AppKeyword] = '" + appKeyword + "' "; //AND [RefMobileNumber] = '" + refMobile + "' [OTP] ='0'
                    cc.ExecuteNonQuery(sqlQuery2);
                    returnString = "1";
                    return returnString;
                }
            }
            else
            {
                return returnString;
            }
        }
        catch (Exception)
        {
            return returnString;
        }

        return returnString;
    }

    //  Created by new method Rajkumar palave
    public string InsertOtpSend(string usrMobile, string refMobile, string imeiNumber, string appKeyword)
    {
        appKeyword = appKeyword.ToUpper();
        string otp = string.Empty;
        string refmobile = string.Empty;
        string imeinumber = string.Empty;
        string firstName = string.Empty;
        string Status = string.Empty;

        if (appKeyword == "IAYAPP" || appKeyword == "EVIDYALAYA" || appKeyword == "MYCTAPP" || appKeyword == "EZEEMUNICIPALCOUNCIL" || appKeyword == "MYPALIKA" || appKeyword == "EZEEMARKETING" || appKeyword == "CLASSAPP")
        {
            #region MyPalika
            if (appKeyword == "MYPALIKA")
            {
                string SQL = "SELECT * FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] WHERE [UserMobile]='" + usrMobile.ToString() + "' AND [AppMobileNo]='" + refMobile + "' AND [IMEINumber]='" + imeiNumber + "'";
                DataSet ds = cc.ExecuteDataset(SQL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Status = ds.Tables[0].Rows[0]["isActive"].ToString();

                    if (Status == "Active")
                    {
                        Random rand = new Random();
                        string otpstr = Convert.ToString(rand.Next(1001, 9999));
                        otp = otpstr;

                        string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0')";
                        cc.ExecuteNonQuery(sqlQuery2);

                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                        return "SEND";
                    }
                    else
                    {
                        return "Status DeActivated !!!!";
                    }
                }
                string SQLQuery5 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "'";
                DataSet ds5 = cc.ExecuteDataset(SQLQuery5);
                if (ds5.Tables[0].Rows.Count > 0)
                {
                    otp = ds5.Tables[0].Rows[0]["OTP"].ToString();
                    refmobile = ds5.Tables[0].Rows[0]["RefMobileNumber"].ToString();
                    imeinumber = ds5.Tables[0].Rows[0]["IMEINumber"].ToString();

                    if (refMobile != refmobile)
                    {
                        Random objRandom = new Random();
                        string str = Convert.ToString(objRandom.Next(1001, 9999));
                        otp = str.ToString();
                        string SQLQuery4 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [RefMobileNumber] = '" + refMobile + "',[OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
                        DataSet ds4 = cc.ExecuteDataset(SQLQuery4);
                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                        return "SEND";
                    }
                    if (imeiNumber != imeinumber)
                    {
                        Random objRandom = new Random();
                        string strotp = Convert.ToString(objRandom.Next(1001, 9099));
                        string SQLQuery7 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IMEINumber] = '" + imeiNumber + "', [OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
                        DataSet ds7 = cc.ExecuteDataset(SQLQuery7);
                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                        return "SEND";
                    }
                    if (string.IsNullOrEmpty(otp) || otp == "0")
                    {
                        return "VERIFIED";
                    }
                    if (otp != null || otp == "" || otp == "0")
                    {
                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ") Wants to Join under you & his permission code is " + otp + " share it" + cc.AddSMS(refMobile);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                        return "SEND";
                    }

                }
                else
                {
                    Random rand = new Random();
                    string otpstr = Convert.ToString(rand.Next(1001, 9999));
                    otp = otpstr;

                    string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0')";
                    cc.ExecuteNonQuery(sqlQuery2);

                    string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                    int smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                    return "SEND";
                }

            }
            #endregion MyPalika

            else
            {
                //string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [RefMobileNumber] = '" + refMobile + "' AND [IMEINumber] = '" + imeiNumber + "' AND [AppKeyword] = '" + appKeyword + "' ";
                string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "'";
                DataSet ds1 = cc.ExecuteDataset(sqlQuery1);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    otp = ds1.Tables[0].Rows[0]["OTP"].ToString();
                    refmobile = ds1.Tables[0].Rows[0]["RefMobileNumber"].ToString();
                    imeinumber = ds1.Tables[0].Rows[0]["IMEINumber"].ToString();

                    if (refMobile != refmobile)
                    {
                        Random rand = new Random();
                        string otpstr = Convert.ToString(rand.Next(1001, 9999));
                        otp = otpstr;

                        string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [RefMobileNumber] = '" + refMobile + "',[OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
                        cc.ExecuteNonQuery(sqlQuery2);

                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ") wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                        return "SEND";
                    }

                    if (imeiNumber != imeinumber)
                    {
                        Random rand = new Random();
                        string otpstr = Convert.ToString(rand.Next(1001, 9999));
                        otp = otpstr;

                        string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IMEINumber] = '" + imeiNumber + "', [OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
                        cc.ExecuteNonQuery(sqlQuery2);

                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                        return "SEND";
                    }

                    if (string.IsNullOrEmpty(otp) || otp == "0")
                    {
                        return "VERIFIED";
                    }

                    if (otp != null || otp != "" || otp != "0")
                    {
                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                        return "SEND";
                    }
                }
                else
                {
                    Random rand = new Random();
                    string otpstr = Convert.ToString(rand.Next(1001, 9999));
                    otp = otpstr;

                    string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0')";
                    cc.ExecuteNonQuery(sqlQuery2);

                    string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                    int smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
                    return "SEND";
                }
            }
        }
        return "0";
    }

    public string CheckStatus(string status, string usrMobile, string refMobile, string imeiNumber, string appKeyword, string userType)
    {
        string returnStr = string.Empty;

        switch (status)
        {
            case "1":
                return "1";
                break;
            case "2":
                return "2";
                break;
            case "6":
                return "6";
                break;
            case "7":
                return "7";
                break;
            case "8":
                return "8";
                break;
            case "9":
                return "9";
                break;
            case "ERROR":
                return "ERROR";
                break;
            default:
                return returnStr = CommanOtpMethod(usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
        }
    }

    public string InsertOtpSendNew(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string userType)
    {
        appKeyword = appKeyword.ToUpper();
        string Status = string.Empty;
        string responseStr = string.Empty;

        switch (appKeyword)
        {
            case "MYPALIKA":
                Status = RoleWiseOtp(usrMobile, refMobile, imeiNumber, appKeyword, userType, "MYPALIKA");
                return responseStr = CheckStatus(Status, usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "MYPANCHAYAT":
                Status = RoleWiseOtp(usrMobile, refMobile, imeiNumber, appKeyword, userType, "MYPANCHAYAT");
                return responseStr = CheckStatus(Status, usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "EZEEMARKETING":
                return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "CLASSAPP":
                return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "MYCTAPP":
                return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "BACHATGAT":
                Status = RoleWiseOtpBachatGat(usrMobile, refMobile, imeiNumber, appKeyword, "0", "BACHATGAT");
                return responseStr = CheckStatus(Status, usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "EZEETEST":
                return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "MYCTSHOP":
                return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "EZEEMEMBER":
                return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            case "EZEEHOSTEL":
                return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
                break;
            default:
                return "0";
                break;
        }
        //return responseStr = CheckStatus("", usrMobile, refMobile, imeiNumber, appKeyword, userType);
    }

    public string CommanOtpMethod(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string userType)
    {
        int objcount;

        string sqlQuery1 = "SELECT [UserMobileNumber],[RefMobileNumber],[IMEINumber],[OTP],[IsActive],[AttemptCount] FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "'";
        DataSet ds1 = cc.ExecuteDataset(sqlQuery1);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            string sqlQuery2 = "SELECT [IsActive] FROM  [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "'";
            string checkStatus = Convert.ToString(cc.ExecuteScalar(sqlQuery2));

            string sqlQuery7 = "SELECT [AttemptCount] FROM  [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
            string attmptCount = Convert.ToString(cc.ExecuteScalar(sqlQuery7));

            if (attmptCount != "")
            {
                objcount = Convert.ToInt32(Convert.ToInt32(attmptCount) + 1);
            }
            else
            {
                objcount = Convert.ToInt32(Convert.ToInt32(0) + 1);
            }

            switch (checkStatus)
            {
                case "1":

                    string sqlQuery3 = "SELECT [IsActive] FROM  [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                    string OnKeywordCheckStatus = Convert.ToString(cc.ExecuteScalar(sqlQuery3));

                    switch (OnKeywordCheckStatus)
                    {
                        case "1":

                            UpdateCountAndStatus(usrMobile, imeiNumber, objcount, appKeyword);

                            //string sqlQuery9 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                            //cc.ExecuteNonQuery(sqlQuery9);

                            //string sqlQuery6 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=1,[AttemptCount]=" + objcount + ",[InsertDate]='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "'  WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                            //cc.ExecuteNonQuery(sqlQuery6);

                            return "2";
                            break;

                        case "0":
                            //string sqlQuery15 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                            //cc.ExecuteNonQuery(sqlQuery15);

                            //string sqlQuery16 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=1,[AttemptCount]=" + objcount + ",[InsertDate]='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "' WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                            //cc.ExecuteNonQuery(sqlQuery16);

                            UpdateCountAndStatus(usrMobile, imeiNumber, objcount, appKeyword);

                            return "2";
                            break;

                        default:

                            string sqlQuery20 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                            cc.ExecuteNonQuery(sqlQuery20);

                            string sqlQuery4 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','0','" + returnCurDate() + "'," + objcount + ",'1')";
                            cc.ExecuteNonQuery(sqlQuery4);

                            return "2";
                            break;
                    }
                    break;

                case "":
                    string otpstr = Convert.ToString(rand.Next(1001, 9999));

                    string sqlQuery5 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otpstr + "','" + returnCurDate() + "','1','0')";
                    cc.ExecuteNonQuery(sqlQuery5);

                    //string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ") wants to join under you & his permission code is " + otpstr + " share it " + cc.AddSMS(refMobile);
                    //int smslength = passwordMessage.Length;
                    //cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);

                    MessageSend(firstName, usrMobile, otpstr.ToString(), refMobile);

                    return "1";
                    break;

                default:
                    string sqlQuery12 = "SELECT [IsActive],[OTP] FROM  [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                    DataSet DS = cc.ExecuteDataset(sqlQuery12);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        switch (Convert.ToString(DS.Tables[0].Rows[0][0]))
                        {
                            case "1":
                                //string sqlQuery11 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                                //cc.ExecuteNonQuery(sqlQuery11);

                                //string sqlQuery8 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=1,[AttemptCount]=" + objcount + ",[InsertDate]='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "' WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                                //cc.ExecuteNonQuery(sqlQuery8);

                                UpdateCountAndStatus(usrMobile, imeiNumber, objcount, appKeyword);

                                return "2";
                                break;

                            case "0":
                                if (DS.Tables[0].Rows[0][1].ToString() == "0")
                                {
                                    //string sqlQuery17 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                                    //cc.ExecuteNonQuery(sqlQuery17);


                                    //string sqlQuery18 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=1,[AttemptCount]=" + objcount + ",[InsertDate]='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "' WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                                    //cc.ExecuteNonQuery(sqlQuery18);

                                    UpdateCountAndStatus(usrMobile, imeiNumber, objcount, appKeyword);

                                    return "2";
                                }
                                else
                                {
                                    string sqlQuery18 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [AttemptCount]=" + objcount + ",[InsertDate]='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "'  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "' AND [IMEINumber] = '" + imeiNumber + "'";
                                    cc.ExecuteNonQuery(sqlQuery18);

                                    //string pwdMsg = "Welcome " + firstName + "(" + usrMobile + ") wants to join under you & his permission code is " + DS.Tables[0].Rows[0][1].ToString() + " share it " + cc.AddSMS(refMobile);
                                    //int SmsLength = pwdMsg.Length;
                                    //cc.TransactionalSMSCountry("OnlineExam", refMobile, pwdMsg, SmsLength, 22);

                                    MessageSend(firstName, usrMobile, DS.Tables[0].Rows[0][1].ToString(), refMobile);

                                    return "3";
                                }
                                break;

                            default:    //DND
                                string sqlQuery14 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                                cc.ExecuteNonQuery(sqlQuery14);

                                string sqlQuery13 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','0','" + returnCurDate() + "','1','1')";
                                cc.ExecuteNonQuery(sqlQuery13);

                                return "2";
                                break;
                        }
                    }
                    else
                    {
                        string sqlQuery19 = "SELECT [OTP] FROM  [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [IMEINumber] = '" + imeiNumber + "' AND [UserMobileNumber] = '" + usrMobile + "'";
                        string existOtp = Convert.ToString(cc.ExecuteScalar(sqlQuery19));

                        string sqlQuery14 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword]='" + appKeyword + "'";
                        cc.ExecuteNonQuery(sqlQuery14);

                        string sqlQuery13 = string.Empty;
                        if (existOtp == "0")
                        {
                            sqlQuery13 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + existOtp.ToString() + "','" + returnCurDate() + "','" + objcount + "','0')";
                            cc.ExecuteNonQuery(sqlQuery13);

                            return "2";
                        }
                        else
                        {
                            sqlQuery13 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + existOtp.ToString() + "','" + returnCurDate() + "','" + objcount + "','0')";
                            cc.ExecuteNonQuery(sqlQuery13);

                            //string pwdMsg = "Welcome " + firstName + "(" + usrMobile + ") wants to join under you & his permission code is " + existOtp.ToString() + " share it " + cc.AddSMS(refMobile);
                            //int SmsLength = pwdMsg.Length;
                            //cc.TransactionalSMSCountry("OnlineExam", refMobile, pwdMsg, SmsLength, 22);

                            MessageSend(firstName, usrMobile, existOtp, refMobile);

                            return "3";
                        }
                    }
                    break;
            }
        }
        else
        {
            string otpstr = Convert.ToString(rand.Next(1001, 9999));

            string sqlQuery10 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otpstr + "','" + returnCurDate() + "','1','0')";
            cc.ExecuteNonQuery(sqlQuery10);

            //string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ") wants to join under you & his permission code is " + otpstr + " share it " + cc.AddSMS(refMobile);
            //int smslength = passwordMessage.Length;
            //cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);

            MessageSend(firstName, usrMobile, otpstr, refMobile);

            return "1";
        }
    }

    public void MessageSend(string fName, string userMob, string otp, string refMob)
    {
        string passwordMessage = "Welcome " + fName + "(" + refMob + ") wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMob);
        int smslength = passwordMessage.Length;
        cc.TransactionalSMSCountry("OnlineExam", userMob, passwordMessage, smslength, 22);
    }

    public void UpdateCountAndStatus(string userMob, string imeiNo, int count, string keyword)
    {
        string sqlQuery9 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=0  WHERE [UserMobileNumber] = '" + userMob + "' AND [AppKeyword]='" + keyword + "'";
        cc.ExecuteNonQuery(sqlQuery9);

        string sqlQuery6 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IsActive]=1,[AttemptCount]=" + count + ",[InsertDate]='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "'  WHERE [IMEINumber] = '" + imeiNo + "' AND [UserMobileNumber] = '" + userMob + "' AND [AppKeyword]='" + keyword + "'";
        cc.ExecuteNonQuery(sqlQuery6);
    }

    public string InsertOtpSendRoleWise(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string UserType)
    {
        appKeyword = appKeyword.ToUpper();
        string otp = string.Empty;
        string refmobile = string.Empty;
        string imeinumber = string.Empty;
        string firstName = string.Empty;
        string Status = string.Empty;
        string chkJuniuor = string.Empty;
        if (appKeyword == "IAYAPP" || appKeyword == "EVIDYALAYA" || appKeyword == "MYCTAPP" || appKeyword == "EZEEMUNICIPALCOUNCIL" || appKeyword == "MYPALIKA" || appKeyword == "MYPANCHAYAT")
        {
            #region MyPalika
            if (appKeyword == "MYPALIKA")
            {
                try
                {
                    if (UserType == "1" || UserType == "2")
                    {
                        string SQL = "SELECT [keyword],[isActive] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] WHERE [UserMobile]='" + usrMobile.ToString() + "' AND [AppMobileNo]='" + refMobile + "' ";//AND [IMEINumber]='" + imeiNumber + "'
                        DataSet ds = cc.ExecuteDataset(SQL);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            chkJuniuor = ds.Tables[0].Rows[0]["keyword"].ToString();
                            Status = ds.Tables[0].Rows[0]["isActive"].ToString();
                            if (chkJuniuor == "Junior" || chkJuniuor == "Member")
                            {
                                if (Status == "Active")
                                {
                                    string SQLQuery = "SELECT [OTP],[IMEINumber] FROM [Come2myCityDB].[dbo].[tblAllAppOTP] Where [UserMobileNumber]='" + usrMobile.ToString() + "' AND [AppKeyword]='" + appKeyword.ToString() + "' AND [IMEINumber]='" + imeiNumber.ToString() + "'";   //[RefMobileNumber]='" + refMobile.ToString() + "'   //Changes by ram kendre 11-05-2017 as per discussion Bhutada sir
                                    DataSet ds05 = cc.ExecuteDataset(SQLQuery);
                                    otp = ds05.Tables[0].Rows[0]["OTP"].ToString();
                                    imeinumber = ds05.Tables[0].Rows[0]["IMEINumber"].ToString();
                                    if (otp != null & imeinumber != null)
                                    {
                                        return "Verifed";
                                    }
                                    else
                                    {
                                        Random rand = new Random();
                                        string otpstr = Convert.ToString(rand.Next(1001, 9999));
                                        otp = otpstr;

                                        string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0','0')";
                                        cc.ExecuteNonQuery(sqlQuery2);

                                        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                                        int smslength = passwordMessage.Length;
                                        cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                                        return "SEND";
                                    }
                                }
                                else
                                {
                                    return "3";
                                }
                            }
                            else
                            {
                                return "User Is Not Junior";
                            }
                        }
                        else
                        {
                            return "0";
                        }
                    }
                    else
                    {
                        string SQLQuery = "SELECT [OTP],[IMEINumber] FROM [Come2myCityDB].[dbo].[tblAllAppOTP] Where [UserMobileNumber]='" + usrMobile.ToString() + "' AND [AppKeyword]='" + appKeyword.ToString() + "' AND [IMEINumber]='" + imeiNumber.ToString() + "'";   //[RefMobileNumber]='" + refMobile.ToString() + "'   //Changes by ram kendre 11-05-2017 as per discussion Bhutada sir
                        DataSet ds05 = cc.ExecuteDataset(SQLQuery);
                        otp = ds05.Tables[0].Rows[0]["OTP"].ToString();
                        imeinumber = ds05.Tables[0].Rows[0]["IMEINumber"].ToString();
                        if (otp != null & imeinumber != null)
                        {
                            return "Verifed";
                        }
                        else
                        {
                            Random rand = new Random();
                            string otpstr = Convert.ToString(rand.Next(1001, 9999));
                            otp = otpstr;

                            string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0','0')";
                            cc.ExecuteNonQuery(sqlQuery2);

                            string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                            int smslength = passwordMessage.Length;
                            cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                            return "SEND";
                        }
                    }


                    //string SQLQuery5 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "'";
                    //DataSet ds5 = cc.ExecuteDataset(SQLQuery5);
                    //if (ds5.Tables[0].Rows.Count > 0)
                    //{
                    //    otp = ds5.Tables[0].Rows[0]["OTP"].ToString();
                    //    refmobile = ds5.Tables[0].Rows[0]["RefMobileNumber"].ToString();
                    //    imeinumber = ds5.Tables[0].Rows[0]["IMEINumber"].ToString();
                    //    if (refMobile != refmobile)
                    //    {
                    //        Random objRandom = new Random();
                    //        string str = Convert.ToString(objRandom.Next(1001, 9999));
                    //        otp = str.ToString();
                    //        string SQLQuery4 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [RefMobileNumber] = '" + refMobile + "',[OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
                    //        DataSet ds4 = cc.ExecuteDataset(SQLQuery4);
                    //        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                    //        int smslength = passwordMessage.Length;
                    //        cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                    //        return "SEND";
                    //    }
                    //    if (imeiNumber != imeinumber)
                    //    {
                    //        Random objRandom = new Random();
                    //        string strotp = Convert.ToString(objRandom.Next(1001, 9099));
                    //        string SQLQuery7 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IMEINumber] = '" + imeiNumber + "', [OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
                    //        DataSet ds7 = cc.ExecuteDataset(SQLQuery7);
                    //        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                    //        int smslength = passwordMessage.Length;
                    //        cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                    //        return "SEND";
                    //    }
                    //    if (string.IsNullOrEmpty(otp) || otp == "0")
                    //    {
                    //        return "VERIFIED";
                    //    }
                    //    if (otp != null || otp == "" || otp == "0")
                    //    {
                    //        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ") Wants to Join under you & his permission code is " + otp + " share it" + cc.AddSMS(refMobile);
                    //        int smslength = passwordMessage.Length;
                    //        cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                    //        return "SEND";
                    //    }
                    //}
                    //else
                    //{
                    //    Random rand = new Random();
                    //    string otpstr = Convert.ToString(rand.Next(1001, 9999));
                    //    otp = otpstr;

                    //    string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0')";
                    //    cc.ExecuteNonQuery(sqlQuery2);

                    //    string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                    //    int smslength = passwordMessage.Length;
                    //    cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                    //    return "SEND";
                    //}
                }
                catch
                {
                    Random rand = new Random();
                    string otpstr = Convert.ToString(rand.Next(1001, 9999));
                    otp = otpstr;

                    string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0','0')";
                    cc.ExecuteNonQuery(sqlQuery2);

                    string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                    int smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                    return "SEND";
                }
            }
            #endregion MyPalika
            //
            else
            {
                string SQLQuery = "SELECT [OTP],[IMEINumber] FROM [Come2myCityDB].[dbo].[tblAllAppOTP] Where [UserMobileNumber]='" + usrMobile.ToString() + "' AND [AppKeyword]='" + appKeyword.ToString() + "' AND [IMEINumber]='" + imeiNumber.ToString() + "'";   //[RefMobileNumber]='" + refMobile.ToString() + "'   //Changes by ram kendre 11-05-2017 as per discussion Bhutada sir
                DataSet ds05 = cc.ExecuteDataset(SQLQuery);
                otp = ds05.Tables[0].Rows[0]["OTP"].ToString();
                imeinumber = ds05.Tables[0].Rows[0]["IMEINumber"].ToString();
                if (otp != null & imeinumber != null)
                {
                    return "Verifed";
                }
                else
                {
                    Random rand = new Random();
                    string otpstr = Convert.ToString(rand.Next(1001, 9999));
                    otp = otpstr;

                    string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0','0')";
                    cc.ExecuteNonQuery(sqlQuery2);

                    string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
                    int smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
                    return "SEND";
                }

            }
            //else
            //{
            //    string SQLQuery = "SELECT [OTP],[IMEINumber] FROM [Come2myCityDB].[dbo].[tblAllAppOTP] Where [UserMobileNumber]='" + usrMobile.ToString() + "' AND [AppKeyword]='" + appKeyword.ToString() + "' AND [IMEINumber]='" + imeiNumber.ToString() + "'";   //[RefMobileNumber]='" + refMobile.ToString() + "'   //Changes by ram kendre 11-05-2017 as per discussion Bhutada sir
            //    DataSet ds05 = cc.ExecuteDataset(SQLQuery);
            //    otp = ds05.Tables[0].Rows[0]["OTP"].ToString();
            //    imeinumber = ds05.Tables[0].Rows[0]["IMEINumber"].ToString();
            //    if (otp != null & imeinumber != null)
            //    {
            //        return "Verifed";
            //    }
            //    else
            //    {
            //        Random rand = new Random();
            //        string otpstr = Convert.ToString(rand.Next(1001, 9999));
            //        otp = otpstr;

            //        string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0')";
            //        cc.ExecuteNonQuery(sqlQuery2);

            //        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
            //        int smslength = passwordMessage.Length;
            //        cc.TransactionalSMSCountry("OnlineExam", usrMobile, passwordMessage, smslength, 22);
            //        return "SEND";
            //    }
            //}

            //string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [RefMobileNumber] = '" + refMobile + "' AND [IMEINumber] = '" + imeiNumber + "' AND [AppKeyword] = '" + appKeyword + "' ";
            //string sqlQuery1 = "SELECT * FROM [Come2myCityDB].[dbo].[tblAllAppOTP] WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "'";
            //DataSet ds1 = cc.ExecuteDataset(sqlQuery1);

            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //    otp = ds1.Tables[0].Rows[0]["OTP"].ToString();
            //    refmobile = ds1.Tables[0].Rows[0]["RefMobileNumber"].ToString();
            //    imeinumber = ds1.Tables[0].Rows[0]["IMEINumber"].ToString();

            //    if (refMobile != refmobile)
            //    {
            //        Random rand = new Random();
            //        string otpstr = Convert.ToString(rand.Next(1001, 9999));
            //        otp = otpstr;

            //        string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [RefMobileNumber] = '" + refMobile + "',[OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
            //        cc.ExecuteNonQuery(sqlQuery2);

            //        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
            //        int smslength = passwordMessage.Length;
            //        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
            //        return "SEND";
            //    }

            //    if (imeiNumber != imeinumber)
            //    {
            //        Random rand = new Random();
            //        string otpstr = Convert.ToString(rand.Next(1001, 9999));
            //        otp = otpstr;

            //        string sqlQuery2 = "UPDATE [Come2myCityDB].[dbo].[tblAllAppOTP] SET [IMEINumber] = '" + imeiNumber + "', [OTP] = '" + otp + "',[InsertDate] = '" + returnCurDate() + "' WHERE [UserMobileNumber] = '" + usrMobile + "' AND [AppKeyword] = '" + appKeyword + "' ";
            //        cc.ExecuteNonQuery(sqlQuery2);

            //        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
            //        int smslength = passwordMessage.Length;
            //        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
            //        return "SEND";
            //    }

            //    if (string.IsNullOrEmpty(otp) || otp == "0")
            //    {
            //        return "VERIFIED";
            //    }

            //    if (otp != null || otp != "" || otp != "0")
            //    {
            //        string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
            //        int smslength = passwordMessage.Length;
            //        cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
            //        return "SEND";
            //    }
            //}
            //else
            //{
            //    Random rand = new Random();
            //    string otpstr = Convert.ToString(rand.Next(1001, 9999));
            //    otp = otpstr;

            //    string sqlQuery2 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otp + "','" + returnCurDate() + "','0')";
            //    cc.ExecuteNonQuery(sqlQuery2);

            //    string passwordMessage = "Welcome " + firstName + "(" + usrMobile + ")wants to join under you & his permission code is " + otp + " share it " + cc.AddSMS(refMobile);
            //    int smslength = passwordMessage.Length;
            //    cc.TransactionalSMSCountry("OnlineExam", refMobile, passwordMessage, smslength, 22);
            //    return "SEND";
            //}
        }
        return "0";
    }

    public string RoleWiseOtp(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string UserType, string keyword)
    {
        appKeyword = appKeyword.ToUpper();
        string otp = string.Empty;
        string refmobile = string.Empty;
        string imeinumber = string.Empty;
        string firstName = string.Empty;
        string Status = string.Empty;
        string chkJuniuor = string.Empty; string SQL = string.Empty;
        try
        {
            if (UserType == "1" || UserType == "2")
            {
                if (keyword == "MYPALIKA")
                {
                    SQL = "SELECT [keyword],[isActive] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] WHERE [UserMobile]='" + usrMobile.ToString() + "' AND [AppMobileNo]='" + refMobile + "' ";    //AND [IMEINumber]='" + imeiNumber + "'
                }
                else if (keyword == "MYPANCHAYAT")
                {
                    SQL = "SELECT [keyword],[isActive] FROM [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances] WHERE [UserMobile]='" + usrMobile.ToString() + "' AND [AppMobileNo]='" + refMobile + "' ";
                }

                DataSet ds = cc.ExecuteDataset(SQL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chkJuniuor = ds.Tables[0].Rows[0]["keyword"].ToString();
                    Status = ds.Tables[0].Rows[0]["isActive"].ToString();
                    if (chkJuniuor == "Junior" || chkJuniuor == "Member")
                    {
                        if (Status == "Active")
                        {
                            string SQLQuery = "SELECT [OTP],[IMEINumber] FROM [Come2myCityDB].[dbo].[tblAllAppOTP] Where [UserMobileNumber]='" + usrMobile.ToString() + "' AND [AppKeyword]='" + appKeyword.ToString() + "' AND [IMEINumber]='" + imeiNumber.ToString() + "'";   //[RefMobileNumber]='" + refMobile.ToString() + "'   //Changes by ram kendre 11-05-2017 as per discussion Bhutada sir
                            DataSet ds05 = cc.ExecuteDataset(SQLQuery);
                            if (ds05.Tables[0].Rows.Count == 0)
                            {
                                string otpstr = Convert.ToString(rand.Next(1001, 9999));

                                string sqlQuery10 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otpstr + "','" + returnCurDate() + "','1','0')";
                                cc.ExecuteNonQuery(sqlQuery10);

                                MessageSend(firstName, usrMobile, otpstr, refMobile);

                                return "1";
                            }
                            else
                            {
                                otp = ds05.Tables[0].Rows[0]["OTP"].ToString();
                                imeinumber = ds05.Tables[0].Rows[0]["IMEINumber"].ToString();
                                if (otp == "0" & imeinumber != null)
                                {
                                    return "2"; //Verified
                                }
                                else
                                {
                                    return "8";  //Not Verified
                                }
                            }
                        }
                        else
                        {
                            return "6";   //DeActive
                        }
                    }
                    else
                    {
                        return "7";     //No Data
                    }
                }
                else
                {
                    return "9";  //User Is Not Junior Or Member
                }
            }
            else
            {
                return "00";  //ReSend Otp - 3
            }
        }
        catch
        {
            return "ERROR";
        }
        return "0";
    }

    public string RoleWiseOtpBachatGat(string usrMobile, string refMobile, string imeiNumber, string appKeyword, string UserType, string keyword)
    {
        appKeyword = appKeyword.ToUpper();
        string otp = string.Empty;
        string refmobile = string.Empty;
        string imeinumber = string.Empty;
        string firstName = string.Empty;
        string Status = string.Empty;
        string chkJuniuor = string.Empty; string SQL = string.Empty;
        string sql = string.Empty;
        try
        {
            if (usrMobile == refMobile)
            {
                return Status = CommanOtpMethod(usrMobile, refMobile, imeiNumber, appKeyword, "0");
            }
            else
            {
                sql = "SELECT usrUserId FROM UserMaster WHERE usrMobileNo='" + refMobile.ToString() + "'";
                string refusrId = Convert.ToString(cc.ExecuteScalar(sql));

                SQL = "SELECT [MobileNo] FROM [Come2myCityDB].[dbo].[tbl_BMRegistration] WHERE [UserId]='" + refusrId.ToString() + "'";
                DataSet ds = cc.ExecuteDataset(SQL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (usrMobile == ds.Tables[0].Rows[i]["MobileNo"].ToString())
                        {
                            string SQLQuery = "SELECT [OTP],[IMEINumber] FROM [Come2myCityDB].[dbo].[tblAllAppOTP] Where [UserMobileNumber]='" + usrMobile.ToString() + "' AND [AppKeyword]='" + appKeyword.ToString() + "' AND [IMEINumber]='" + imeiNumber.ToString() + "'";
                            DataSet ds05 = cc.ExecuteDataset(SQLQuery);
                            if (ds05.Tables[0].Rows.Count == 0)
                            {
                                string otpstr = Convert.ToString(rand.Next(1001, 9999));

                                string sqlQuery10 = "INSERT INTO [Come2myCityDB].[dbo].[tblAllAppOTP] ([UserMobileNumber],[RefMobileNumber],[IMEINumber],[AppKeyword],[OTP],[InsertDate],[AttemptCount],[IsActive]) VALUES ('" + usrMobile + "','" + refMobile + "','" + imeiNumber + "','" + appKeyword + "','" + otpstr + "','" + returnCurDate() + "','1','0')";
                                cc.ExecuteNonQuery(sqlQuery10);

                                MessageSend(firstName, usrMobile, otpstr, refMobile);

                                return "1";
                            }
                            else
                            {
                                otp = ds05.Tables[0].Rows[0]["OTP"].ToString();
                                imeinumber = ds05.Tables[0].Rows[0]["IMEINumber"].ToString();
                                if (otp == "0" & imeinumber != null)
                                {
                                    return "2"; //Verified
                                }
                                else
                                {
                                    return "8";  //Not Verified
                                }
                            }
                        }
                        //else
                        //{
                        //    return "7";  //User is not Added 
                        //}
                    }
                }
                else
                {
                    return "9";  //NO data 
                }
            }
        }
        catch
        {
            return "ERROR";
        }
        return "7";
    }
}
