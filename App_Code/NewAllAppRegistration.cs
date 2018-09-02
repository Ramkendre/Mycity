using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;

/// <summary>
/// Summary description for NewAllAppRegistration
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class NewAllAppRegistration : System.Web.Services.WebService {


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


    public NewAllAppRegistration () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public string NewRegistrationThroughDivices(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
                                      string RefmobileNo, string address, string Qualification, string Spatialization, string LadlineNo, string Favorite, string eMailId, string typeOfUse_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Village, string userType, string Taluka)
    {
        
        keyword = keyword.ToUpper();
        string Data = "0";
        DataSet ds = new DataSet();
        int i = 0;

        try
        {
            string getuserID = GetRegisterRecordNew(AppMobileNo, firstName, lastName, address, pincode, strDevId);
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
                    Data = "1";
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
        
    }
   
    public string GetRegisterRecordNew(string MobileNo, string Fname, string Lname, string address, string pincode, string strDevId)
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




    [WebMethod]
    public string gcmRegistration(string mobieNo, string regId)
    {
        try
        {
            CommonCode cc = new CommonCode();
            string sqlQuery = "update [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] set [GCM_Regid]='"+regId+"' where [mobileNo]='"+mobieNo+"'";
            cc.ExecuteScalar(sqlQuery);
            return "1";
           
        }
        catch (Exception ex)
        {
            return "0";
        }
    }

    [WebMethod]
    public string EzeeOrderRegistration(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
                                      string RefmobileNo, string address, string eMailId, string typeOfUse_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Village, string userType, string Taluka)
    {

        keyword = keyword.ToUpper();
        string Data = "0";
        DataSet ds = new DataSet();
        int i = 0;

        try
        {
            string getuserID = GetRegisterRecordNew(AppMobileNo, firstName, lastName, address, pincode, strDevId);
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
                    string Sql = "Insert Into EzeeDrugsAppDetail(keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Village, Taluka)" +
                                 "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + address + "','" + eMailId + "','" +
                                 typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + RefmobileNo + "','" + state + "','" + district + "','" + userType + "','" + Village + "','" + Taluka + "')";
                    i = cc.ExecuteNonQuery(Sql);
                    Data = "1";



                }
                #endregion newUser
                #region update
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string Sql = "Update EzeeDrugsAppDetail set strDevId = '" + strDevId + "', firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id='" + typeOfUse_Id + "',pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" + getuserID + "',RefMobileNo='" + RefmobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Village = '" + Village + "' where  EzeeDrugAppId=" + row[0] + "";
                        i = cc.ExecuteNonQuery(Sql);
                    }

                    Data = "1";


                }
                #endregion update
            }
        }
        catch (Exception ex)
        { Data = "Server error" + ex.Message; }

        return Data;
    }

    [WebMethod]
    public string BachatGatRegistration(string AppMobileNo, string keyword, string strDevId, string strSimSerialNo, string firstName, string lastName, string firmName,
                                      string RefmobileNo, string address, string eMailId, string typeOfUse_Id, string pincode, string passcode,
                                      string latitude, string longitude, string state, string district, string Village, string userType, string Taluka)
    {

        keyword = keyword.ToUpper();
        string Data = "0";
        DataSet ds = new DataSet();
        int i = 0;

        try
        {
            string getuserID = GetRegisterRecordNew(AppMobileNo, firstName, lastName, address, pincode, strDevId);
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
                    string Sql = "Insert Into EzeeDrugsAppDetail(keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,passcode,latitude,longitude,EntryDate,UserId,RefMobileNo ,State,District,usertype,Village, Taluka)" +
                                 "Values('" + keyword + "','" + strDevId + "','" + strSimSerialNo + "','" + firstName + "','" + lastName + "','" + firmName + "','" + AppMobileNo + "','" + address + "','" + eMailId + "','" +
                                 typeOfUse_Id + "','" + pincode + "','" + passcode + "','" + latitude + "','" + longitude + "','" + Convert.ToString(CurrenctDate) + "','" + getuserID + "','" + RefmobileNo + "','" + state + "','" + district + "','" + userType + "','" + Village + "','" + Taluka + "')";
                    i = cc.ExecuteNonQuery(Sql);
                    Data = "1";



                }
                #endregion newUser
                #region update
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string Sql = "Update EzeeDrugsAppDetail set strDevId = '" + strDevId + "', firstName='" + firstName + "',lastName='" + lastName + "',firmName='" + firmName + "',address='" + address + "',eMailId='" + eMailId + "',typeOfUse_Id='" + typeOfUse_Id + "',pincode='" + pincode + "',passcode='" + passcode + "',latitude='" + latitude + "',longitude='" + longitude + "',EntryDate='" + Convert.ToString(CurrenctDate) + "',UserId='" + getuserID + "',RefMobileNo='" + RefmobileNo + "' ,State='" + state + "',District='" + district + "',usertype='" + userType + "',Village = '" + Village + "' where  EzeeDrugAppId=" + row[0] + "";
                        i = cc.ExecuteNonQuery(Sql);
                    }

                    Data = "1";


                }
                #endregion update
            }
        }
        catch (Exception ex)
        { Data = "Server error" + ex.Message; }

        return Data;
    }
    
}

