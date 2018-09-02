using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Net;

public partial class BJS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string strMyUrl = "";
    string ipAddress, hostName;
    int pagehiter;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            strMyUrl = System.Web.HttpContext.Current.Request.Url.ToString();
            ipAddress = IpAddress();
            hostName = Dns.GetHostName();
            string s = DateTime.Now.ToString() + " | " + ipAddress + " | " + hostName + " | " + Request.Url.ToString();
            Addvisitor();
        }

    }
    private void downloadfile(string id)
    {

        string[] s = strMyUrl.Split(new char[] { '/' });
        string fileName = s[4] + ".pdf";
        string path = "~/downloadfileBJS/" + fileName;
        DirectoryInfo dia = new DirectoryInfo(Server.MapPath(path));
        fileDownload(fileName, dia.ToString(), id);



        
        


        // if (strMyUrl == "http://localhost:49810/myctin/BJS.aspx?jan13" || strMyUrl == "http://localhost:49810/myctin/BJS.aspx/jan13")

        //if (strMyUrl == "http://www.myct.in/BJS.aspx?jan13" || strMyUrl == "http://www.myct.in/BJS.aspx/jan13")
        //{
        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSJan2013.pdf"));

        //    fileDownload("BJSJan2013.pdf", di.ToString(), id);

        //}
        //// else if (strMyUrl == "http://localhost:49810/myctin/BJS.aspx?feb13" || strMyUrl == "http://localhost:49810/myctin/BJS.aspx/feb13")
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?feb13" || strMyUrl == "http://www.myct.in/BJS.aspx/feb13")
        //{
        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSFeb2013.pdf"));

        //    fileDownload("BJSFeb2013.pdf", di.ToString(), id);

        //}
        //// else if (strMyUrl == "http://localhost:57547/myctin/BJS.aspx?mar13" || strMyUrl == "http://localhost:57547/myctin/BJS.aspx/mar13")
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?mar13" || strMyUrl == "http://www.myct.in/BJS.aspx/mar13")
        //{
        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSMar2013.pdf"));

        //    fileDownload("BJSMar2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?apr13" || strMyUrl == "http://www.myct.in/BJS.aspx/apr13")
        //{
        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSApr2013.pdf"));

        //    fileDownload("BJSApr2013.pdf", di.ToString(), id);

        //}

        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?may13" || strMyUrl == "http://www.myct.in/BJS.aspx/may13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSMay2013.pdf"));

        //    fileDownload("BJSMay2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?jun13" || strMyUrl == "http://www.myct.in/BJS.aspx/jun13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSJun2013.pdf"));

        //    fileDownload("BJSJun2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?july13" || strMyUrl == "http://www.myct.in/BJS.aspx/july13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSJun2013.pdf"));

        //    fileDownload("BJSJuly2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?aug13" || strMyUrl == "http://www.myct.in/BJS.aspx/aug13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSAug2013.pdf"));

        //    fileDownload("BJSAug2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?sept13" || strMyUrl == "http://www.myct.in/BJS.aspx/sept13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSSept2013.pdf"));

        //    fileDownload("BJSSept2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?Oct13" || strMyUrl == "http://www.myct.in/BJS.aspx/Oct13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSOct2013.pdf"));

        //    fileDownload("BJSOct2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?Nov13" || strMyUrl == "http://www.myct.in/BJS.aspx/Nov13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSNov2013.pdf"));

        //    fileDownload("BJSNov2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?Dec13" || strMyUrl == "http://www.myct.in/BJS.aspx/Dec13")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSDec2013.pdf"));

        //    fileDownload("BJSDec2013.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?Jan14" || strMyUrl == "http://www.myct.in/BJS.aspx/Jan14")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSJan2014.pdf"));

        //    fileDownload("BJSJan2014.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?Feb14" || strMyUrl == "http://www.myct.in/BJS.aspx/Feb14")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSFeb2014.pdf"));

        //    fileDownload("BJSFeb2014.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?April20" || strMyUrl == "http://www.myct.in/BJS.aspx/April20")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSApril2014.pdf"));

        //    fileDownload("BJSApril2014.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?May20" || strMyUrl == "http://www.myct.in/BJS.aspx/May20")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSMay2014.pdf"));

        //    fileDownload("BJSMay2014.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?July20" || strMyUrl == "http://www.myct.in/BJS.aspx/July20")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSJuly2014.pdf"));

        //    fileDownload("BJSJuly2014.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?Aug20" || strMyUrl == "http://www.myct.in/BJS.aspx/Aug20")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSAug2014.pdf"));

        //    fileDownload("BJSAug2014.pdf", di.ToString(), id);

        //}
        //else if (strMyUrl == "http://www.myct.in/BJS.aspx?Dec20" || strMyUrl == "http://www.myct.in/BJS.aspx/Dec20")
        //{

        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileBJS/BJSDec2014.pdf"));

        //    fileDownload("BJSDec2014.pdf", di.ToString(), id);

        //}
        

        //else
        //{
        //    string sql = "select FileName from committeedetail where Committee_url='" + strMyUrl + "'";
        //    string filename = cc.ExecuteScalar(sql);
        //    DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfileSMT/" + filename + ""));
        //    fileDownload("'" + filename + "'", di.ToString(), id);
        //}
    }
    private void fileDownload(string fileName, string fileUrl, string id)
    {
        Page.Response.Clear();
        bool success = ResponseFile(Page.Request, Page.Response, fileName, fileUrl, 1024000);
        if (!success)
        {
            Response.Write("Downloading Error!");
        }
        else
        {
            string sql = "update VisitorIPDetails set status=1 where VisitorId='" + id + "'";
            int a = cc.ExecuteNonQuery(sql);
        }
        // Page.Response.End();

    }
    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {
        try
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);

            try
            {
                _Response.AddHeader("Accept-Ranges", "bytes");
                _Response.Buffer = false;
                long fileLength = myFile.Length;
                long startBytes = 0;

                int pack = 10240; //10K bytes
                int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
                if (_Request.Headers["Range"] != null)
                {
                    _Response.StatusCode = 206;
                    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                _Response.AddHeader("Connection", "Keep-Alive");
                _Response.ContentType = "application/octet-stream";
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

                for (int i = 0; i < maxCount; i++)
                {
                    if (_Response.IsClientConnected)
                    {
                        _Response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                // br.Close();
                //myFile.Close();
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    protected void Addvisitor()
    {

        try
        {
            string sql = "insert into VisitorIPDetails(HostName,VisitDateTime,IPAdd,RequestURL)" +
                       "values('" + hostName + "','" + DateTime.Now.ToString() + "','" + ipAddress + "','" + Request.Url.ToString() + "')";
            int a = cc.ExecuteNonQuery(sql);
            if (a > 0)
            {
                sql = "select top(1) VisitorId from VisitorIPDetails order by VisitorId desc";
                string Vid = cc.ExecuteScalar(sql);
                downloadfile(Vid);
            }



        }
        catch (Exception ex)
        {


        }

    }
    private string IpAddress()
    {
        string strIpAddress;
        strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        return strIpAddress;
    }
    //Add the Namespace

    //Get Visitor IP address method
    public string GetVisitorIpAddress()
    {
        string stringIpAddress;
        stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (stringIpAddress == null) //may be the HTTP_X_FORWARDED_FOR is null
        {
            stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR
        }
        return "Your ip is " + stringIpAddress;
    }
    //Get Lan Connected IP address method
    public string GetLanIPAddress()
    {
        //Get the Host Name
        string stringHostName = Dns.GetHostName();
        //Get The Ip Host Entry
        IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
        //Get The Ip Address From The Ip Host Entry Address List
        IPAddress[] arrIpAddress = ipHostEntries.AddressList;
        return arrIpAddress[arrIpAddress.Length - 1].ToString();
    }
}
