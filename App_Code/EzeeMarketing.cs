using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for EzeeMarkeing
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EzeeMarkeing : System.Web.Services.WebService {

    CommonCode cc = new CommonCode();
    public EzeeMarkeing () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string AddCustDetails( string Adm_number,string Usr_Mobile, string Cust_Mobile, string F_name, string L_name, string Firm_Name, string Type, string Email)
    {
        string data ;

        string sql = "insert into [EzeeMarketingCustdetails] (Usr_mobile,Cust_mobile,F_name,L_name,Firm_name,C_Type,email,Adm_mobile) values ('" + Usr_Mobile + "','" + Cust_Mobile + "','" + F_name + "','" + L_name + "','" + Firm_Name + "','" + Type + "','" + Email + "','" + Adm_number + "')";
        data = cc.ExecuteScalar(sql);
        
        if (data != null)
        {
            return "1";
        }
        else
        {
            return "1";
        }

    }

    [WebMethod]
    public string AddFeedBack(string Adm_number, string usr_mobileNo, string Cust_mobileNo, string Feedback, string points, string Reminder_date)
    {
        string data;

        string sql1 = "insert into EzeeMarketing_FeedBack ([Usr_mobile],[Cust_mobile],[FeedBack_Desc],[Points],[ReminderDare],[Admin_Num]) values ('"+usr_mobileNo+"','"+Cust_mobileNo+"','"+Feedback+"','"+points+"','"+Reminder_date+"','"+Adm_number+"')";
        data = cc.ExecuteScalar(sql1);


        if (data != null)
        {
            return "1";
        }
        else
        {
            return "1";
        }
    }

    [WebMethod]
    public string AddOrderDetails(string Adm_number, string usr_mobileNo, string Cust_mobileNo, string Items)
    {
        string data;

        string sql1 = "insert into EzeeMarketing_addorder ([Usr_mobile],[Cust_mobile],[Items],[Adm_Mobile]) values ('" + usr_mobileNo + "','" + Cust_mobileNo + "','" + Items + "','" + Adm_number + "')";
        data = cc.ExecuteScalar(sql1);


        if (data != null)
        {
            return "1";
        }
        else
        {
            return "1";
        }
    }
}

