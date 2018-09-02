using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for SendMsg
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SendMsg : System.Web.Services.WebService {
    UserRegistrationBLL urRegistBll = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
   
    public SendMsg () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod(Description = "Send TRansactional message.")]
    public bool SendMessageTransactional(string sender, string sendTo, string message)
    {
        bool Flag = false;
        //Flag = cc.SendMessageTra(sender, sendTo, message);
        return Flag;
    }

    [WebMethod(Description = "Send simpal message.")]
    public bool SendMessageWithoutTransactional(string sender, string sendTo, string message)
    {
        bool Flag = false;
        Flag = cc.SendMessage1(sender, sendTo, message);
        return Flag;
    }
    [WebMethod(Description = " RegistrationUser")]
    public bool RegisterUser(string TeacherMobileNo, string FirstName, string lastName, string Address, string PIN, string email)
    {
        bool Flag = false;
        string usrUserId = System.Guid.NewGuid().ToString();
        Random rnd = new Random();
        string usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

        string sql = "insert into UserMaster(usrUserId,usrMobileNo,usrAddress,usrPassword,usrFirstName,usrLastName,usrPIN,usrEmailId) " +
                     " values('" + usrUserId + "','" + TeacherMobileNo + "','" + Address + "','" + usrPassword.ToString() + "','" + FirstName + "','" + lastName + "','" + PIN + "','" + email + "')  ";
        int ststus = cc.ExecuteNonQuery(sql);
        if (ststus > 0)
        {
            Flag = true;
            return Flag;
        }
        else
        {
            Flag = false;
            return Flag;
        }
    }
}

