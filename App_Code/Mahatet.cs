using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
/// <summary>
/// Summary description for Mahatet
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Mahatet : System.Web.Services.WebService
{

    public Mahatet()
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
    public string GetRegisterToMahatet(string MobileNo, string Fname, string Lname, string address, string pincode, string EmailId)
    {
        int status, smslength;
        string id = "";
        try
        {
            UserRegistrationBLL balobj = new UserRegistrationBLL();
            CommonCode cc = new CommonCode();
            balobj.usrFirstName = Fname;
            balobj.usrLastName = Lname;
            balobj.usrMobileNo = MobileNo;
            balobj.usrAddress = address;
            balobj.usrPIN = pincode;
            balobj.usrEmailId = EmailId;
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
                    string passwordMessage = "Welcome " + myName + ", to www.mahatet.co.in,Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                    smslength = passwordMessage.Length;
                    //cc.SendMessageMahatetSMS("Mahatet", myMobileNo, passwordMessage, smslength);

                    cc.TransactionalSMSCountry("Mahatet", myMobileNo, passwordMessage, smslength, 20);
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
                string passwordMessage = "Welcome " + name + ", to www.mahatet.co.in,Password is " + password + " " + cc.AddSMS(MobileNo);
                smslength = passwordMessage.Length;
                //cc.SendMessageMahatetSMS("Mahatet", MobileNo, passwordMessage, smslength);

                cc.TransactionalSMSCountry("Mahatet", MobileNo, passwordMessage, smslength, 20);
            }
        }
        catch (Exception ex)
        { }
        // Insert into [Come2MyCityDB].[dbo].[sendercode](ProjectName,Code)values('Mahatet',20)
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
           
            //cc.SendMessageMahatetSMS("Mahatet", MobileNo, Message, smslength);

            cc.TransactionalSMSCountry("Mahatet", MobileNo, Message, smslength, 20);

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

