﻿using System;
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

public partial class NCP : System.Web.UI.Page
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
           
            downloadfile();
           
            ipAddress = IpAddress();
            hostName = Dns.GetHostName();
            string s = DateTime.Now.ToString() + " | " + ipAddress + " | " + hostName + " | " + Request.Url.ToString();
            Addvisitor();
        }

    }

    private void downloadfile()
    {

      // Download http://www.myct.in/NCP/down.aspx?crtevnt http://www.myct.in/NCP/down.aspx?ict http://www.myct.in/NCP/down.aspx?w7o10 & ur login pswd fr myct.in= xxxxx 
      //  if (strMyUrl == "http://localhost:50174/myctin/NCP.aspx?Win7&MS10")
        if (strMyUrl == "http://www.myct.in/NCP.aspx?crtevnt" || strMyUrl == "http://www.myct.in/ncp.aspx?crtevnt" || strMyUrl == "http://www.myct.in/NCP.aspx/crtevnt" || strMyUrl == "http://www.myct.in/ncp.aspx/crtevnt")
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/download files/current event.pdf"));

            fileDownload("current event.pdf", di.ToString());

        }
       // if (strMyUrl == "http://localhost:50174/myctin/NCP.aspx?Eevent")
        else  if (strMyUrl == "http://www.myct.in/NCP.aspx?ict" || strMyUrl == "http://www.myct.in/NCP.aspx/ict" || strMyUrl == "http://www.myct.in/ncp.aspx?ict" || strMyUrl == "http://www.myct.in/ncp.aspx/ict")
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/download files/ICT.pdf"));
            fileDownload("ICT.pdf", di.ToString());
        }
        // if (strMyUrl == "http://localhost:50174/myctin/NCP.aspx?ebook")
       else if (strMyUrl == "http://www.myct.in/NCP.aspx?w7o10" || strMyUrl == "http://www.myct.in/NCP.aspx/w7o10" || strMyUrl == "http://www.myct.in/ncp.aspx?w7o10" || strMyUrl == "http://www.myct.in/ncp.aspx/w7o10")
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/download files/Test3.pdf"));

            fileDownload("Test3.pdf", di.ToString());
        }
       // else if (strMyUrl == "http://localhost:50438/myctin/ncp.aspx/pressnote")
       else if (strMyUrl == "http://www.myct.in/ncp.aspx/pressnote")
        {
            string sql = "select filename from committeedetail where Id=33";
            string filename = cc.ExecuteScalar(sql);
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/download files/" + filename));
            fileDownload("'" + filename + "'", di.ToString());

        }
      else if (strMyUrl == "http://www.myct.in/ncp.aspx/videorelease")
        {
            string sql = "select filename from committeedetail where Id=35";
            string filename = cc.ExecuteScalar(sql);
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/download files/" + filename));

            fileDownload("'" + filename + "'", di.ToString());
        }
        else if (strMyUrl == "http://www.myct.in/ncp.aspx/ncpmagazine")
        {
            string sql = "select filename from committeedetail where Id=34";
            string filename = cc.ExecuteScalar(sql);
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/download files/" + filename));

            fileDownload("'" + filename + "'", di.ToString());
        }
    }
    private void fileDownload(string fileName, string fileUrl)
    {
        Page.Response.Clear();
        bool success = ResponseFile(Page.Request, Page.Response, fileName, fileUrl, 1024000);
        if (!success)
            Response.Write("Downloading Error!");
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
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);



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
