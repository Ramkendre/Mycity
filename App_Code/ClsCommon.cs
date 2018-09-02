using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;


namespace ClassCommon
{



    public class ClsCommon
    {


        public static void WriteLine(string pageTitle, string methodName, string msg)
        {
            try
            {
                //Logger.Write("*****************************************************************************************************************************");
                String logMessage = "";
                logMessage = msg + ", " + DateTime.Now;
                logMessage += ", " + pageTitle;
                logMessage += ", " + methodName;
                
               
                String fileName = DateTime.Today.Month + "." + DateTime.Today.Day + "." + DateTime.Today.Year + ".csv";

                if (File.Exists(HttpContext.Current.Server.MapPath("..//Logs/" + fileName)))
                {
                    FileStream fs = File.Open(HttpContext.Current.Server.MapPath("..//Logs/" + fileName), FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(logMessage);
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    FileStream fs = File.Create(HttpContext.Current.Server.MapPath("..//Logs/" + fileName));
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(logMessage);
                    sw.Close();
                    fs.Close();
                }
            }
            catch
            {
            }
            finally { }
        }

      
    }

}

