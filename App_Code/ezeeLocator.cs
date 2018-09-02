using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ezeeLocator
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ezeeLocator : System.Web.Services.WebService
{

    CommonCode cc = new CommonCode();
    public ezeeLocator()
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
    public string registerApp(string IMEINO, string SimSerialNo, string firstName, string lastName, string purpose,
        string RefNcpMobileNo, string EmergencyMobileNo_1, string EmergencyMobileNo_2, string EmergencyMobileNo_3, string address,
        string state, string district, string eMailId, string pincode, string passcode, string latitude, string longitude, string appType)
    {
        try
        {
            string sql = " insert into EmergencyAppReg ( IMEINO, SimSerialNo, firstName, lastName, purpose, RefNcpMobileNo, EmergencyMobileNo_1," +
                         " EmergencyMobileNo_2, EmergencyMobileNo_3, address, state, district, eMailId, pincode, passcode, latitude, longitude, appType) " +
                         " values(" + IMEINO + "," + SimSerialNo + ",'" + firstName + "','" + lastName + "','" + purpose + "'," + RefNcpMobileNo + "," + EmergencyMobileNo_1 + "," +
                         EmergencyMobileNo_2 + "," + EmergencyMobileNo_3 + ",'" + address + "'," + state + "," + district + ",'" + eMailId + "'," + pincode + "," + passcode + "," + latitude + "," + longitude + ",'" + appType + "') ";
            string k = Convert.ToString(cc.ExecuteNonQuery(sql));
            return k;
        }
        catch (Exception ex) { return "0"; }
        finally { }
    }

    [WebMethod]
    public string Help_Me(string IMEINO, string latitude, string longitude, string appType)
    {
        string k = "0";

        try
        {
            string Sqlchk = "Select helpId from HELP_ME where IMEINO='" + IMEINO + "'";
            string chk = Convert.ToString(cc.ExecuteScalar(Sqlchk));
            if (chk == "" || chk == null)
            {
                string sql = " insert into HELP_ME ( IMEINO, latitude, longitude, appType) " +
                         " values(" + IMEINO + ",'" + latitude + "','" + longitude + "','" + appType + "') ";

                k = Convert.ToString(cc.ExecuteNonQuery(sql));
                if (k == "" || k == null)
                {
                }
                else
                {
                    SendData(IMEINO);
                }

            }
            else
            {
                string sql = " Update  HELP_ME set latitude='" + latitude + "', longitude='" + longitude + "', appType='" + appType + "' where IMEINO='" + IMEINO + "'";
                k = Convert.ToString(cc.ExecuteNonQuery(sql));
                if (k == "" || k == null)
                {
                }
                else
                {
                    SendData(IMEINO);
                }
            }

        }
        catch (Exception ex) { }
        finally { }
        return k;
    }

    public void SendData(string IMEINO)
    {
        try
        {
            string SqlgetM = "Select firstName,lastName,  EmergencyMobileNo_1, EmergencyMobileNo_2, EmergencyMobileNo_3 from EmergencyAppReg where IMEINO='" + IMEINO + "'";
            DataSet ds = cc.ExecuteDataset(SqlgetM);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Fname = Convert.ToString(ds.Tables[0].Rows[0]["firstName"]);
                string Lname = Convert.ToString(ds.Tables[0].Rows[0]["lastName"]);
                string PersonalMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["lastName"]);
                string Mobile1 = Convert.ToString(ds.Tables[0].Rows[0]["EmergencyMobileNo_1"]);
                string Mobile2 = Convert.ToString(ds.Tables[0].Rows[0]["EmergencyMobileNo_2"]);
                string Mobile3 = Convert.ToString(ds.Tables[0].Rows[0]["EmergencyMobileNo_3"]);
                if (Mobile1 == "0")
                {
                    Mobile1 = "";
                }
                if (Mobile2 == "0")
                {
                    Mobile2 = "";
                }
                if (Mobile3 == "0")
                {
                    Mobile3 = "";
                }
                string Mobile = Mobile1 + "," + Mobile2 + "," + Mobile3;

                string Message = "Please Help your person " + Fname + " " + Lname + " www.myct.in";
                int smslength = Message.Length;
                // cc.SendMessageUvaSMS("Uva Jagar", myMobileNo, passwordMessage, smslength);

                cc.TransactionalSMSCountry("Emergency", Mobile, Message, smslength, 24);
            }
        }
        catch (Exception xe)
        { }
    }
}

