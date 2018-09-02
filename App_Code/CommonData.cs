using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace DAL
{
    public class CommonData
    {
        public int hour { get; set; }
        public int Minitue { get; set; }
        //private string smsUserName = "ezeesoft";
        //private string smsPassword = "67893";

        private string smsUserName = "odishaknowledge";
        private string smsPassword = "123456";

        private WebProxy objProxy1 = null;
        public CommonData()
        {
            hour = 13;
            Minitue = 02;
        }
        public void WriteError(Exception exception)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog.txt", true);
                sw.WriteLine("Exception : " + DateTime.Now.ToString() + " : " + exception.Source.Trim() + " : " + exception.Message.Trim());
                sw.Flush();
                sw.Close();
            }
            catch { }

        }
        public void WriteError(string message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog.txt", true);
                sw.WriteLine("Message : " + DateTime.Now.ToString() + " :" + message);
                sw.Flush();
                sw.Close();

            }
            catch { }
        }

        public string SendSMS(string Mobile_Number, string Message)
        {

            Mobile_Number = "91" + Mobile_Number;

            //Message += " www.myct.in";

           // System.Object stringpost = "User=" + smsUserName + "&passwd=" + smsPassword + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&mtype=N&DR=Y";
           System.Object stringpost = "username=" + smsUserName + "&pass=" + smsPassword + "&senderid=OKCLED&dest_mobileno=" + Mobile_Number + "&message=" + Message + "&msgType=TXT&response=Y";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;

                //objWebRequest = (HttpWebRequest)WebRequest.Create("http://api.smscountry.com/SMSCwebservice_bulk.aspx?");

                objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smsjust.com/sms/user/urlsms.php?");

                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

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
                WriteError(ex);
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
    }
}
