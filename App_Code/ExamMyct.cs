using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;

/// <summary>
/// Summary description for ExamMyct
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ExamMyct : System.Web.Services.WebService
{

    CommonCode cc = new CommonCode();
    public ExamMyct()
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
    public string GetRegisterRecord(string MobileNo, string Fname, string Lname, string address, string pincode, string status)
    {
        int i, smslength;
        string id = "";
        UserRegistrationBLL balobj = new UserRegistrationBLL();
        CommonCode cc = new CommonCode();
        balobj.usrFirstName = Fname;
        balobj.usrLastName = Lname;
        balobj.usrMobileNo = MobileNo;
        balobj.usrAddress = address;
        balobj.usrPIN = pincode;
        i = balobj.BLLIsExistUserRegistrationInitial(balobj);
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
                string passwordMessage = "Welcome " + myName + ", to www.exam.myct.in,for ur First Login Username=" + myMobileNo + " & Password is " + myPassword + "  " + cc.AddSMS(myMobileNo);
                smslength = passwordMessage.Length;
                cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);
            }
        }
        else
        {
            if (status == "1")
            {
                DataSet ds = new DataSet();
                ds = balobj.BLLGetUserIdPassword(balobj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string name = Convert.ToString(ds.Tables[0].Rows[0]["FullName"]);
                    string password = Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]);
                    password = cc.DESDecrypt(password);
                    id = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
                    string passwordMessage = "Welcome " + name + ", to www.exam.myct.in,Password for ur First Login is " + password + " " + cc.AddSMS(MobileNo);
                    smslength = passwordMessage.Length;
                    cc.TransactionalSMSCountry("OnlineExam", MobileNo, passwordMessage, smslength, 22);
                }
            }
        }
        return id;

    }


}

