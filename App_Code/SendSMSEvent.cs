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
using System.Collections.Generic;
using System.Net;
using System.IO;
/// <summary>
/// Summary description for SendSMSEvent
/// </summary>
public class SendSMSEvent
{
	public SendSMSEvent()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public string SendSMS(string User, string password, string Mobile_Number, string Message)
    {
        WebProxy objProxy1 = null;
        Mobile_Number = "91" + Mobile_Number;
        System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&mtype=N&DR=Y";

        //string functionReturnValue = null;
        //functionReturnValue = "";

        HttpWebRequest objWebRequest = null;
        HttpWebResponse objWebResponse = null;
        StreamWriter objStreamWriter = null;
        StreamReader objStreamReader = null;

        try
        {
            string stringResult = null;
            //http://api.smscountry.com/SMSCwebservice_bulk.aspx
            objWebRequest = (HttpWebRequest)WebRequest.Create("http://api.smscountry.com/SMSCwebservice_bulk.aspx?");
            objWebRequest.Method = "POST";

            if ((objProxy1 != null))
            {
                objWebRequest.Proxy = objProxy1;
            }

            // Use below code if you want to SETUP PROXY.
            //Parameters to pass: 1. ProxyAddress 2. Port
            //You can find both the parameters in Connection settings of your internet explorer.

            //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
            //myProxy.BypassProxyOnLocal = true;
            //wrGETURL.Proxy = myProxy;

            objWebRequest.ContentType = "application/x-www-form-urlencoded";

            objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
            objStreamWriter.Write(stringpost);
            objStreamWriter.Flush();
            objStreamWriter.Close();

            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
            objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
            stringResult = objStreamReader.ReadToEnd();

            objStreamReader.Close();
            return (stringResult);
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
        finally
        {

            if ((objStreamWriter != null))
            {
                objStreamWriter.Close();
            }
            if ((objStreamReader != null))
            {
                objStreamReader.Close();
            }
            objWebRequest = null;
            objWebResponse = null;
            objProxy1 = null;
        }
    }
    private void StreamReader(Stream stream)
    {
        throw new NotImplementedException();
    }


   

    }


