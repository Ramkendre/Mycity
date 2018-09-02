using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

/// <summary>
/// Summary description for AllAppRegistration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AllAppRegistration : System.Web.Services.WebService
{
    getDataFromMYCT objgetDataEzeeTest = new getDataFromMYCT();
    #region WebserviceCbject
    //http://www.ezeedrug.in//DrugApps.asmx
    ezeedrug.DrugApps drug = new ezeedrug.DrugApps();
    myctDrug.DrugApps drugmyct = new myctDrug.DrugApps();
    come2myschool.ConnectToCT scID = new come2myschool.ConnectToCT();
    onlineExam.ClassApp OnExam = new onlineExam.ClassApp();

    CommonCode cc = new CommonCode();

    #endregion WebserviceCbject

    string CurrenctDate = "", UpperKeword = "";

    public AllAppRegistration()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        DateFromatCurrent();
    }

    #region DateFormat
    public void DateFromatCurrent()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        CurrenctDate = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
    }
    #endregion DateFormat

    [WebMethod]
    public string HelloWorld(string vinay)
    {
        return "Hello World";
    }

    //------------------------------------------------------User Registration To MYCT------------------------------------------------------------------

    #region GetRegistration
    public string GetRegisterRecord(string MobileNo, string Fname, string Lname, string address, string pincode, string strDevId)
    {
        int i, smslength;
        string id = "";
        DataSet ds = new DataSet();
        try
        {

            UserRegistrationBLL balobj = new UserRegistrationBLL();
            CommonCode cc = new CommonCode();
            balobj.usrFirstName = Fname;
            balobj.usrLastName = Lname;
            balobj.usrMobileNo = MobileNo;
            balobj.usrAddress = address;
            balobj.usrPIN = pincode;
            balobj.StrDevId = strDevId;
            i = balobj.BLLIsExistUserRegistrationInitial(balobj);//check user is exist or not if i = 0 then already exist 
            if (i > 0)
            {
                balobj.usrUserId = System.Guid.NewGuid().ToString();
                Random rnd = new Random();
                balobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                i = balobj.BLLInsertUserRegistrationInitial(balobj);
                if (i > 0)
                {
                    id = balobj.usrUserId;
                    string myMobileNo = balobj.usrMobileNo;
                    string myPassword = cc.DESDecrypt(balobj.usrPassword);
                    string myName = balobj.usrFirstName;
                    string passwordMessage = "Welcome " + myName + ",for ur First Login Username=" + myMobileNo + " & Password is " + myPassword + "  " + cc.AddSMS(myMobileNo);
                    smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

                    //------------------------------ For Dublicate IMEI number....................

                    string sql3 = "select [usrMobileNo] from usermaster where strDevId = '" + strDevId + "'";//takes all mobile number who have same IMEI number
                    ds = cc.ExecuteDataset(sql3);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row[0].Equals(MobileNo))
                        {
                        }
                        else
                        {
                            string sql = "update usermaster set StrDevId = '0' where [usrMobileNo] ='" + row[0] + "' ";
                            int j = cc.ExecuteNonQuery(sql);
                        }
                    }

                }
            }
            else
            {
                string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";//geting userid of user
                id = cc.ExecuteScalar(sqlget);

                string sql2 = "select strDevId from usermaster where usrUserid='" + id + "' ";
                string str = cc.ExecuteScalar(sql2);

                if (str == "" || str == null || str == "0")// If IMEI no is null
                {
                    string sql = "Update usermaster set StrDevId = '" + strDevId + "' where usrUserid ='" + id + "' ";//to add/update IMEI no's for old entries
                    int j = cc.ExecuteNonQuery(sql);
                }
                string sql3 = "select [usrMobileNo] from usermaster where strDevId = '" + str + "'";//takes all mobile number who have same IMEI number
                ds = cc.ExecuteDataset(sql3);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row[0].Equals(MobileNo))
                    {
                    }
                    else
                    {
                        string sql = "update usermaster set StrDevId = '0' where [usrMobileNo] ='" + row[0] + "' ";
                        int j = cc.ExecuteNonQuery(sql);
                    }
                }

            }

        }
        catch (Exception ex)
        { }
        return id;
    }
    #endregion GetRegistration

    //------------------------------------------------------All Android Apps Registration--------------------------------------------------------------

    [WebMethod(Description = "All Apps Registration Web Service")]
    public string ALLAppsRegistration(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
                                      string RefmobileNo, string address, string Qualification, string Spatialization, string LadlineNo, string Favorite, string eMailId, string typeOfUse_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Village, string userType, string Taluka)
    {
        #region AppsRegistration
        keyword = keyword.ToUpper();
        string Data = "0";
        DataSet ds = new DataSet();
        int i = 0;

        try
        {
            string getuserID = GetRegisterRecord(AppMobileNo, firstName, lastName, address, pincode, strDevId);
            if (String.IsNullOrEmpty(getuserID))
            {
            }
            else
            {

                //string Sqlchk = "Select EzeeDrugAppId from EzeeDrugsAppDetail where  mobileNo='" + AppMobileNo + "' and strSimSerialNo='" + strSimSerialNo + "' and strDevId='" + strDevId + "' and keyword='" + keyword + "'";

                //string sql5 = "select [mobileNo] from [EzeeDrugsAppDetail] where [strDevId] = '" + strDevId + "'";
                //ds = cc.ExecuteDataset(sql5);

                //foreach (DataRow row in ds.Tables[0].Rows)
                //{
                //    if (row[0] == AppMobileNo)
                //    {
                //    }
                //    else
                //    {
                //        string sql1 = "update EzeeDrugsAppDetail set [strDevId] = 0 where [mobileNo] = '"+row[0]+"' ";
                //        i = cc.ExecuteNonQuery(sql1);
                //    }
                //}


                string Sqlchk = "Select EzeeDrugAppId from EzeeDrugsAppDetail where  mobileNo='" + AppMobileNo + "'  and keyword='" + keyword + "'";//and strDevId = '" + strDevId + "' 
                ds = cc.ExecuteDataset(Sqlchk);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    string Sql = "Insert Into EzeeDrugsAppDetail(keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Qualification,LadlineNo,Favorite,Village,Spatialization, Taluka)" +
                                 "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + address + "','" + eMailId + "','" +
                                 typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + RefmobileNo + "','" + state + "','" + district + "','" + userType + "','" + Qualification + "','" + LadlineNo + "','" + Favorite + "','" + Village + "','" + Spatialization + "','" + Taluka + "')";
                    i = cc.ExecuteNonQuery(Sql);



                    string sql2 = "select * from [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData] where IMEI_NO='" + strDevId + "'";
                    ds = cc.ExecuteDataset(sql2);
                    string imeino = string.Empty;
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        string sql1 = "insert into [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData]([ProjName],[IMEI_NO],[SimSerialNo],[FirstName],[LastName],[FirmName],[WSMobileNo],[EmailID],[P1],[Pincode],[p2],[Latitude],[Longitude],[StateId],[DistrictId],[TalukaId],[p3],[p4],[RefMobileNo],[Passcode],[TypeOfUserId],[UserType],[SMS_WS],[Status],[UserId],[ReceivedDateTime])values " +
                             "('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + eMailId + "','','" + pincode + "','','" + latitude + "','" + longitude + "','" + state + "','" + district + "','" + Taluka + "','','','" + RefmobileNo + "','" + passcode + "','" + typeOfUse_Id + "','" + userType + "','WS','0','" + getuserID + "','" + Convert.ToString(CurrenctDate) + "')";
                        int j = cc.ExecuteNonQuery(sql1);
                    }
                    else
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["SMSMobileNo"]) == AppMobileNo)
                        {
                            string str = "update [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData] set [FirmName]='" + firmName + "',[RefMobileNo]='" + RefmobileNo + "',[Passcode]='" + passcode + "',[TypeOfUserId]= '" + typeOfUse_Id + "',[UserType]='" + userType + "',[UserId]='" + getuserID + "',[Status]='1',[ReceivedDateTime]='" + Convert.ToString(CurrenctDate) + "' where [IMEI_NO]='" + strDevId + "' and [ProjName]='" + keyword + "'";
                            int k = cc.ExecuteNonQuery(str);
                        }
                        else
                        {
                            string str = "update [Come2myCityDB].[come2mycity].[IMEI_SMS_WSData] set [FirmName]='" + firmName + "',[RefMobileNo]='" + RefmobileNo + "',[Passcode]='" + passcode + "',[TypeOfUserId]= '" + typeOfUse_Id + "',[UserType]='" + userType + "',[UserId]='" + getuserID + "',[Status]='0',[ReceivedDateTime]='" + Convert.ToString(CurrenctDate) + "' where [IMEI_NO]='" + strDevId + "' and [ProjName]='" + keyword + "'";
                            int k = cc.ExecuteNonQuery(str);
                        }
                    }

                    if (i == 1)
                    {
                        if (keyword == "EZEETEST")
                        {
                            string str = "select usrFirstName,usrLastName,usrMobileNo,usrAddress,usrPassword from UserMaster where usrUserId='" + getuserID + "'";
                            ds = cc.ExecuteDataset(str);
                            string fullName = ds.Tables[0].Rows[0]["usrFirstName"].ToString() + " " + ds.Tables[0].Rows[0]["usrLastName"].ToString();
                            string MobileNo = ds.Tables[0].Rows[0]["usrMobileNo"].ToString();
                            string Address = ds.Tables[0].Rows[0]["usrAddress"].ToString();
                            string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();
                            objgetDataEzeeTest.insertDatatoLogin(MobileNo, Password, fullName, Address);

                        }
                        else if (keyword == "EZEEDRUG")
                        {

                            int status;
                            status = drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
                            Data = Convert.ToString(status);
                            // drug.FirmRegistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                            // drugmyct.FirmRegistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                        }

                        else if (keyword == "EZEECLASS")
                        {
                            Data = "1";
                            OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, address, pincode, RefmobileNo);
                        }
                        else if (keyword == "EZEESCHOOLAPP")
                        {
                            Data = "1";
                            string FullName = firstName + " " + lastName;
                            scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getuserID);
                        }
                        else if (keyword == "MHVIDHANAPP")//use for the register the user
                        {
                            Data = "1";
                        }
                        else if (keyword == "EZEEMOBILE")//use for the register the user
                        {
                            Data = "1";
                        }
                        else if (keyword == "EzeeAdhar")
                        {
                            Data = "1";
                        }
                        else if (keyword == "EZEEJOB")
                        {
                            Data = "1";
                        }
                        else if (keyword == "PWP")
                        {
                            Data = "1";
                        }
                        else if (keyword == "BACHATGAT")
                        {
                            Data = "1";
                        }
                        else if(keyword == "CLASSAPP")
                        {
                            Data = "1";
                        }
                        else if (keyword == "TRUEVOTER")
                        {
                            string str1 = "select usrUserId from UserMaster where usrMobileNo='" + AppMobileNo + "'";
                            string result = cc.ExecuteScalar(str1);
                            string str =
                        " with Event as( " +
                        " select *from( " +
                        " (SELECT [firstName],[RefMobileNo] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefmobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                        " inner join " +
                        " [Come2myCityDB].[dbo].[UserMaster] as table2 " +

                       " on " +
                        " table1.uid=table2.[usrMobileNo] " +
                        " ) " +
                        " ) ";
                            str += " select distinct usrUserId from Event";
                            ds = cc.ExecuteDataset(str);
                            string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                            if (RefmobileNo != "" && RefmobileNo != null)
                            {
                                string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No],[Keyword])values('" + RefmobileNo + "','" + s + "','" + result + "','" + firstName + "','" + AppMobileNo + "','" + keyword + "')";
                                int result1 = cc.ExecuteNonQuery(str2);
                            }
                            else
                            {
                                string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No])values('NULL','NULL','" + result + "','" + firstName + "','" + AppMobileNo + "')";
                                int result1 = cc.ExecuteNonQuery(str2);

                            }


                            Data = "1";
                        }

                        else if (keyword == "EZEEPLANNER")
                        {

                            string str =
                        " with Event as( " +
                        " select *from( " +
                        " (SELECT [firstName],[RefMobileNo] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefmobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                        " inner join " +
                        " [Come2myCityDB].[dbo].[UserMaster] as table2 " +

                       " on " +
                        " table1.uid=table2.[usrMobileNo] " +
                        " ) " +
                        " ) ";
                            str += " select distinct usrUserId from Event";
                            ds = cc.ExecuteDataset(str);
                            string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                            if (RefmobileNo != "" && RefmobileNo != null && RefmobileNo != " ")
                            {
                                string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No],[Keyword])values('" + RefmobileNo + "','" + s + "','" + getuserID + "','" + firstName + "','" + AppMobileNo + "','" + keyword + "')";
                                int result1 = cc.ExecuteNonQuery(str2);
                            }
                            else
                            {
                                // string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No])values('NULL','NULL','" + result + "','" + firstName + "','" + AppMobileNo + "')";
                                string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([Child_ID],[Name],[Mobile_No],[Keyword])values('" + getuserID + "','" + firstName + "','" + AppMobileNo + "','" + keyword + "')";
                                int result1 = cc.ExecuteNonQuery(str2);

                            }

                            Data = "1";
                        }

                        Data = "1";

                    }
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string Sql = "Update EzeeDrugsAppDetail set strDevId = '" + strDevId + "', firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id='" + typeOfUse_Id + "',pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" + getuserID + "',RefMobileNo='" + RefmobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Qualification = '" + Qualification + "',LadlineNo = '" + LadlineNo + "',Favorite = '" + Favorite + "',Village = '" + Village + "',Spatialization = '" + Spatialization + "' where  EzeeDrugAppId=" + row[0] + "";
                        i = cc.ExecuteNonQuery(Sql);
                    }
                    if (i == 1)
                    {
                        if (keyword == "EZEEDRUG")
                        {
                            int status;

                            status = drug.FirmRegistration(strDevId, strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType, address, LadlineNo, Favorite, Qualification, Spatialization, Village);
                            Data = Convert.ToString(status);
                            //drug.FirmRegistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                            // drug.FirmRegistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                            // drugmyct.FirmRegistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, typeOfUse_Id, pincode, RefmobileNo, CurrenctDate, passcode, longitude, latitude, state, district, userType);
                        }
                        else if (keyword == "EZEECLASS")
                        {
                            Data = "1";
                            OnExam.classregistration(strSimSerialNo, firmName, firstName, lastName, AppMobileNo, eMailId, address, pincode, RefmobileNo);
                        }
                        else if (keyword == "EZEESCHOOLAPP")
                        {
                            Data = "1";
                            //int status;
                            string FullName = firstName + " " + lastName;
                            scID.SchoolAppRegistrationDetails(strDevId, strSimSerialNo, FullName, firmName, AppMobileNo, getuserID);

                        }
                        else if (keyword == "MHVIDHANAPP")//use for the register users
                        {
                            Data = "1";
                        }
                        else if (keyword == "EZEEMOBILE")//use for the register the user
                        {
                            Data = "1";
                        }
                        else if (keyword == "BACHATGAT")
                        {
                            Data = "1";
                        }
                        else if (keyword == "PWP")
                        {
                            Data = "1";
                        }
                        else if (keyword == "CLASSAPP")
                        {
                            Data = "1";
                        }
                        else if (keyword == "TRUEVOTER")
                        {
                            string str1 = "select usrUserId from UserMaster where usrMobileNo='" + AppMobileNo + "'";
                            string result = cc.ExecuteScalar(str1);
                            string str =
                        " with Event as( " +
                        " select *from( " +
                        " (SELECT [firstName],[RefMobileNo] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefmobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                        " inner join " +
                        " [Come2myCityDB].[dbo].[UserMaster] as table2 " +

                       " on " +
                        " table1.uid=table2.[usrMobileNo] " +
                        " ) " +
                        " ) ";
                            str += " select usrUserId from Event";
                            ds = cc.ExecuteDataset(str);
                            string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                            string str2 = "update [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] set RefMobileNo='" + RefmobileNo + "' where UserId='" + getuserID + "'";
                            int result1 = cc.ExecuteNonQuery(str2);
                            string sql = "select usrUserId from UserMaster where usrMobileNo='" + RefmobileNo + "'";
                            string sql1 = cc.ExecuteScalar(sql);
                            string str4 = "update [Come2myCityDB].[dbo].[tbl_TreeDemo] set SMobile_No='" + RefmobileNo + "',Senior_ID='" + sql1 + "' where Child_ID='" + getuserID + "'";
                            int result4 = cc.ExecuteNonQuery(str4);
                            Data = "1";
                        }
                        else if (keyword == "EZEEPLANNER")
                        {

                            string str =
                        " with Event as( " +
                        " select *from( " +
                        " (SELECT [firstName],[RefMobileNo] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefmobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                        " inner join " +
                        " [Come2myCityDB].[dbo].[UserMaster] as table2 " +

                       " on " +
                        " table1.uid=table2.[usrMobileNo] " +
                        " ) " +
                        " ) ";
                            str += " select usrUserId from Event";
                            ds = cc.ExecuteDataset(str);
                            string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                            string str2 = "update [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] set RefMobileNo='" + RefmobileNo + "' where UserId='" + getuserID + "'";
                            int result1 = cc.ExecuteNonQuery(str2);
                            string sql = "select usrUserId from UserMaster where usrMobileNo='" + RefmobileNo + "'";
                            string sql1 = cc.ExecuteScalar(sql);
                            string str4 = "update [Come2myCityDB].[dbo].[tbl_TreeDemo] set SMobile_No='" + RefmobileNo + "',Senior_ID='" + sql1 + "' where Child_ID='" + getuserID + "'";
                            int result4 = cc.ExecuteNonQuery(str4);
                            Data = "1";
                        }
                        // Data = "1";

                    }
                }
            }
        }
        catch (Exception ex)
        { }
        return Data;
        #endregion AppsRegistration
    }
    [WebMethod]
    public string EzeeTestRegistration(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
                                      string RefmobileNo, string address, string Qualification, string Spatialization, string LadlineNo, string Favorite, string eMailId, string typeOfUse_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Village, string userType, string Taluka)
    {
        #region AppsRegistration
        keyword = keyword.ToUpper();
        string Data = "0";
        DataSet ds = new DataSet();
        int i = 0;

        try
        {
            string getuserID = GetRegisterRecord(AppMobileNo, firstName, lastName, address, pincode, strDevId);
            if (String.IsNullOrEmpty(getuserID))
            {
            }
            else
            {
                string Sqlchk = "Select EzeeDrugAppId from EzeeDrugsAppDetail where  mobileNo='" + AppMobileNo + "'  and keyword='" + keyword + "'";//and strDevId = '" + strDevId + "' 
                ds = cc.ExecuteDataset(Sqlchk);

                #region newUser
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string Sql = "Insert Into EzeeDrugsAppDetail(keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Qualification,LadlineNo,Favorite,Village,Spatialization, Taluka)" +
                                 "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + address + "','" + eMailId + "','" +
                                 typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + RefmobileNo + "','" + state + "','" + district + "','" + userType + "','" + Qualification + "','" + LadlineNo + "','" + Favorite + "','" + Village + "','" + Spatialization + "','" + Taluka + "')";
                    i = cc.ExecuteNonQuery(Sql);

                    if (keyword == "EZEETEST")
                    {
                        string str = "select usrFirstName,usrLastName,usrMobileNo,usrAddress,usrPassword from UserMaster where usrUserId='" + getuserID + "'";
                        ds = cc.ExecuteDataset(str);
                        string fullName = ds.Tables[0].Rows[0]["usrFirstName"].ToString() + " " + ds.Tables[0].Rows[0]["usrLastName"].ToString();
                        string MobileNo = ds.Tables[0].Rows[0]["usrMobileNo"].ToString();
                        string Address = ds.Tables[0].Rows[0]["usrAddress"].ToString();
                        string Password = ds.Tables[0].Rows[0]["usrPassword"].ToString();

                    //   string SqlQuery = "Insert INTO [DBeZeeOnlineExam].[dbo].[Login](LoginId,UserName,Password,ContactNo,Address,DOJ,Role,CompanyId,Active,admintype,UserType,Category) Values " +
                    //" ('" + MobileNo + "',N'" + fullName + "',N'" + Password + "','" + MobileNo + "',N'" + Address + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','10','5164','1','1','1','--Select--') ";

                    //    cc.ExecuteNonQueryEzeeTest(SqlQuery);
                        objgetDataEzeeTest.insertDatatoLogin(MobileNo, Password, fullName, Address);

                    }
                    Data = "1";
                }
                #endregion newUser
                #region update
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string Sql = "Update EzeeDrugsAppDetail set strDevId = '" + strDevId + "', firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id='" + typeOfUse_Id + "',pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" + getuserID + "',RefMobileNo='" + RefmobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Qualification = '" + Qualification + "',LadlineNo = '" + LadlineNo + "',Favorite = '" + Favorite + "',Village = '" + Village + "',Spatialization = '" + Spatialization + "' where  EzeeDrugAppId=" + row[0] + "";
                        i = cc.ExecuteNonQuery(Sql);
                        Data = "1";
                    }
                }
                #endregion update
            }

        }
        catch (Exception ex)
        { Data = "Server error" + ex.Message; }

        return Data;
        #endregion AppsRegistration
    }
    [WebMethod]
    public string NewRegistration(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
                                      string RefmobileNo, string address, string Qualification, string Spatialization, string LadlineNo, string Favorite, string eMailId, string typeOfUse_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Village, string userType, string Taluka)
    {


        #region AppsRegistration
        keyword = keyword.ToUpper();
        string Data = "0";
        DataSet ds = new DataSet();
        int i = 0;

        try
        {
            string getuserID = GetRegisterRecord(AppMobileNo, firstName, lastName, address, pincode, strDevId);
            if (String.IsNullOrEmpty(getuserID))
            {
            }
            else
            {
                string Sqlchk = "Select EzeeDrugAppId from EzeeDrugsAppDetail where  mobileNo='" + AppMobileNo + "'  and keyword='" + keyword + "'";//and strDevId = '" + strDevId + "' 
                ds = cc.ExecuteDataset(Sqlchk);

                #region newUser
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string Sql = "Insert Into EzeeDrugsAppDetail(keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Qualification,LadlineNo,Favorite,Village,Spatialization, Taluka)" +
                                 "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + address + "','" + eMailId + "','" +
                                 typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + RefmobileNo + "','" + state + "','" + district + "','" + userType + "','" + Qualification + "','" + LadlineNo + "','" + Favorite + "','" + Village + "','" + Spatialization + "','" + Taluka + "')";
                    i = cc.ExecuteNonQuery(Sql);

                    if (RefmobileNo != "" && RefmobileNo != null && RefmobileNo != " ")
                    {
                        string sql = "select usrUserId from UserMaster where usrMobileNo='" + RefmobileNo + "'";
                        string refId = cc.ExecuteScalar(sql);
                        string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No],[Keyword])values('" + RefmobileNo + "','" + refId + "','" + getuserID + "','" + firstName + "','" + AppMobileNo + "','" + keyword + "')";
                        int result1 = cc.ExecuteNonQuery(str2);
                    }
                    else
                    {
                        string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No])values('0','0','" + getuserID + "','" + firstName + "','" + AppMobileNo + "')";
                        int result1 = cc.ExecuteNonQuery(str2);
                    }

                }
                #endregion newUser
                #region update
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string Sql = "Update EzeeDrugsAppDetail set strDevId = '" + strDevId + "', firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id='" + typeOfUse_Id + "',pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" + getuserID + "',RefMobileNo='" + RefmobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Qualification = '" + Qualification + "',LadlineNo = '" + LadlineNo + "',Favorite = '" + Favorite + "',Village = '" + Village + "',Spatialization = '" + Spatialization + "' where  EzeeDrugAppId=" + row[0] + "";
                        i = cc.ExecuteNonQuery(Sql);
                    }
                    if (i == 1)
                    {
                        if (keyword == "TRUEVOTER")
                        {
                            string sql = "select usrUserId from UserMaster where usrMobileNo='" + RefmobileNo + "'";
                            string refId = cc.ExecuteScalar(sql);


                            if (RefmobileNo != "" && RefmobileNo != null && RefmobileNo != " ")
                            {
                                string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No],[Keyword])values('" + RefmobileNo + "','" + refId + "','" + getuserID + "','" + firstName + "','" + AppMobileNo + "','" + keyword + "')";
                                int result1 = cc.ExecuteNonQuery(str2);
                            }
                            else
                            {
                                string str2 = "insert into [Come2myCityDB].[dbo].[tbl_TreeDemo]([SMobile_No],[Senior_ID],[Child_ID],[Name],[Mobile_No])values('0','0','" + getuserID + "','" + firstName + "','" + AppMobileNo + "')";
                                int result1 = cc.ExecuteNonQuery(str2);
                            }
                            Data = "1";
                        }
                    }
                }
                #endregion update
            }
        }
        catch (Exception ex)
        { Data = "Server error" + ex.Message; }

        return Data;
        #endregion AppsRegistration
    }
}

