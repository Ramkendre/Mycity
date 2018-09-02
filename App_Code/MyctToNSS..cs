using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;


/// <summary>
/// Summary description for NSSToMyct
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]


public class MyctToNSS : System.Web.Services.WebService
{

    public MyctToNSS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public string GetRegisterRecord(string MobileNo, string Fname, string Lname, string address, string pincode)
    {
        int status, smslength;
        string id = "";
        UserRegistrationBLL balobj = new UserRegistrationBLL();
        CommonCode cc = new CommonCode();
        balobj.usrFirstName = Fname;
        balobj.usrLastName = Lname;
        balobj.usrMobileNo = MobileNo;
        balobj.usrAddress = address;
        balobj.usrPIN = pincode;
        status = balobj.BLLIsExistUserRegistrationInitial(balobj);
        if (status > 0)
        {
            balobj.usrUserId = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            balobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
            status = balobj.BLLInsertUserRegistrationInitial(balobj);
            if (status > 0)
            {
                id = balobj.usrUserId;
                string myMobileNo = balobj.usrMobileNo;
                string myPassword = cc.DESDecrypt(balobj.usrPassword);
                string myName = balobj.usrFirstName;
                string passwordMessage = "Welcome " + myName + ", to www.nss.myct.in,Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                smslength = passwordMessage.Length;
                //cc.SendMessageNssSMS("NSS", myMobileNo, passwordMessage, smslength);

                cc.TransactionalSMSCountry("NSS", myMobileNo, passwordMessage, smslength, 14);
            }
        }
        else
        {
            DataSet ds = new DataSet();
            ds = balobj.BLLGetUserIdPassword(balobj);
            string name = Convert.ToString(ds.Tables[0].Rows[0]["FullName"]);
            string password = Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]);
            password = cc.DESDecrypt(password);
            id = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
            string passwordMessage = "Welcome " + name + ", to www.nss.myct.in,Password is " + password + " " + cc.AddSMS(MobileNo);
            smslength = passwordMessage.Length;
            //cc.SendMessageNssSMS("NSS", MobileNo, passwordMessage, smslength);


        }
        return id;

    }

    [WebMethod]
    public string GetRegisterRecordUva(string MobileNo, string Fname, string Lname, string address, string pincode)
    {
        int status, smslength;
        string id = "";
        UserRegistrationBLL balobj = new UserRegistrationBLL();
        CommonCode cc = new CommonCode();
        balobj.usrFirstName = Fname;
        balobj.usrLastName = Lname;
        balobj.usrMobileNo = MobileNo;
        balobj.usrAddress = address;
        balobj.usrPIN = pincode;
        status = balobj.BLLIsExistUserRegistrationInitial(balobj);
        if (status > 0)
        {
            balobj.usrUserId = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            balobj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
            status = balobj.BLLInsertUserRegistrationInitial(balobj);
            if (status > 0)
            {
                id = balobj.usrUserId;
                string myMobileNo = balobj.usrMobileNo;
                string myPassword = cc.DESDecrypt(balobj.usrPassword);
                string myName = balobj.usrFirstName;
                string passwordMessage = "Welcome " + myName + ", to www.uva.myct.in,Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                smslength = passwordMessage.Length;
               // cc.SendMessageUvaSMS("Uva Jagar", myMobileNo, passwordMessage, smslength);

                cc.TransactionalSMSCountry("Uva Jagar", myMobileNo, passwordMessage, smslength, 20);
            }
        }
        else
        {
            DataSet ds = new DataSet();
            ds = balobj.BLLGetUserIdPassword(balobj);
            string name = Convert.ToString(ds.Tables[0].Rows[0]["FullName"]);
            string password = Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]);
            password = cc.DESDecrypt(password);
            id = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
            string passwordMessage = "Welcome " + name + ", to www.uva.myct.in,Password is " + password + " " + cc.AddSMS(MobileNo);
            smslength = passwordMessage.Length;
            //cc.SendMessageUvaSMS("Uva Jagar", MobileNo, passwordMessage, smslength);

            cc.TransactionalSMSCountry("Uva Jagar", MobileNo, passwordMessage, smslength, 20);
        }
        return id;

    }

    [WebMethod]
    public void GetPassword(string MobileNo)
    {
        UserRegistrationBLL balobj = new UserRegistrationBLL();
        DataTable dtUserInfoList;
        CommonCode cc = new CommonCode();
        int status, smslength;
        balobj.BLLUserPasswordRecovery(MobileNo, out dtUserInfoList, out status);
        if (status == 0)
        {

        }
        else
        {
            DataTable dtUserSMSInfoList = dtUserInfoList;
            DataRow dRowUserInfo = dtUserSMSInfoList.Rows[0];
            string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfo["usrPassword"]));
            string myName = Convert.ToString(dRowUserInfo["usrFullName"]);
            string Message = "Dear " + myName + " Password for Login is " + myPassword + " Thanks via www.myct.in";
            smslength = Message.Length;
            //cc.SendMessageNssSMS("NSS", MobileNo, Message, smslength);

            cc.TransactionalSMSCountry("NSS", MobileNo, Message, smslength, 20);

        }

    }

    [WebMethod]
    public DataTable UserLoginAuthenticate(string MobileNo, string Password)
    {
        DataSet ds = new DataSet();
        CommonCode cc = new CommonCode();
        UserRegistrationBLL balobj = new UserRegistrationBLL();
        balobj.usrMobileNo = MobileNo;
        int roleid = balobj.BLLGetUserRoleId(balobj);
        balobj.usrPassword = cc.DESEncrypt(Password);
        ds = cc.getLoginDetails(MobileNo, balobj.usrPassword);
        DataTable dt = ds.Tables[0];
        dt.Columns.Add("Roleid", typeof(Int32));
        foreach (DataRow dr in dt.Rows)
        {
            dr["Roleid"] = roleid;
            dt = dr.Table;
        }

        return dt;
    }








}

