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

public partial class mah_assembly : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string strMyUrl = "";
    string ipAddress, hostName;
    int pagehiter;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //strMyUrl = "http://www.myct.in/mpcc.aspx?Id=2";
            strMyUrl = System.Web.HttpContext.Current.Request.Url.ToString();
            ipAddress = IpAddress();
            hostName = Dns.GetHostName();
            string s = DateTime.Now.ToString() + " | " + ipAddress + " | " + hostName + " | " + Request.Url.ToString();
            Addvisitor();
            downloadfile();
        }
    }

    //--------------------------------------------------------------------------DownLoad Link Document------

    public void downloadfile()
    {
        string[] Urlstr = strMyUrl.Split('?');
        string IdentyNo = Urlstr[1].ToString();

        if (IdentyNo == "" || IdentyNo == null)
        { }
        else
        {
            string sql = "select filename from committeedetail where " + IdentyNo + "";
            string filename = cc.ExecuteScalar(sql);
            if (filename == "" || filename == null)
            { }
            else
            {
                Response.Redirect("~/downloadfilesMLA/" + filename);
            }
        }
    }
 //----------------------------------------------------------------------------Add Link DownLoad Pc Details
    protected void Addvisitor()
    {
        try
        {
            string sql = "insert into VisitorIPDetails(HostName,VisitDateTime,IPAdd,RequestURL)" +
                       "values('" + hostName + "','" + DateTime.Now.ToString() + "','" + ipAddress + "','" + Request.Url.ToString() + "')";
            int k = cc.ExecuteNonQuery(sql);
        }
        catch (Exception ex)
        {
        }

    }

    //------------------------------------------------------------------------------Get Visitor IP address method
    private string IpAddress()
    {
        string strIpAddress;
        strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        return strIpAddress;
    }
    //Add the Namespace

    //-------------------------------------------------------------------------------Get Visitor IP address method
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
    //-------------------------------------------------------------------------------Get Lan Connected IP address method
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

//private void downloadfile()
//{


//    if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=1")
//    {
//        string sql = "select filename from committeedetail where Id=1";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=2")
//    {
//        string sql = "select filename from committeedetail where Id=2";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=3")
//    {
//        string sql = "select filename from committeedetail where Id=3";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=4")
//    {
//        string sql = "select filename from committeedetail where Id=4";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=5")
//    {
//        string sql = "select filename from committeedetail where Id=5";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=6")
//    {
//        string sql = "select filename from committeedetail where Id=6";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=7")
//    {
//        string sql = "select filename from committeedetail where Id=7";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=8")
//    {
//        string sql = "select filename from committeedetail where Id=8";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=9")
//    {
//        string sql = "select filename from committeedetail where Id=9";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=10")
//    {
//        string sql = "select filename from committeedetail where Id=10";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=11")
//    {
//        string sql = "select filename from committeedetail where Id=11";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=12")
//    {
//        string sql = "select filename from committeedetail where Id=12";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=13")
//    {
//        string sql = "select filename from committeedetail where Id=13";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=14")
//    {
//        string sql = "select filename from committeedetail where Id=14";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=15")
//    {
//        string sql = "select filename from committeedetail where Id=15";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=16")
//    {
//        string sql = "select filename from committeedetail where Id=16";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=17")
//    {
//        string sql = "select filename from committeedetail where Id=17";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=18")
//    {
//        string sql = "select filename from committeedetail where Id=18";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=19")
//    {
//        string sql = "select filename from committeedetail where Id=19";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMPCC/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=20")
//    {
//        string sql = "select filename from committeedetail where Id=20";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=21")
//    {
//        string sql = "select filename from committeedetail where Id=21";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=22")
//    {
//        string sql = "select filename from committeedetail where Id=22";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=23")
//    {
//        string sql = "select filename from committeedetail where Id=23";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=24")
//    {
//        string sql = "select filename from committeedetail where Id=24";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=25")
//    {
//        string sql = "select filename from committeedetail where Id=25";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=26")
//    {
//        string sql = "select filename from committeedetail where Id=26";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=27")
//    {
//        string sql = "select filename from committeedetail where Id=27";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=28")
//    {
//        string sql = "select filename from committeedetail where Id=28";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMPCC/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=29")
//    {
//        string sql = "select filename from committeedetail where Id=29";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=30")
//    {
//        string sql = "select filename from committeedetail where Id=30";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=31")
//    {
//        string sql = "select filename from committeedetail where Id=31";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=32")
//    {
//        string sql = "select filename from committeedetail where Id=32";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=33")
//    {
//        string sql = "select filename from committeedetail where Id=33";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=34")
//    {
//        string sql = "select filename from committeedetail where Id=34";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=35")
//    {
//        string sql = "select filename from committeedetail where Id=35";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=36")
//    {
//        string sql = "select filename from committeedetail where Id=36";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=37")
//    {
//        string sql = "select filename from committeedetail where Id=37";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=38")
//    {
//        string sql = "select filename from committeedetail where Id=38";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=39")
//    {
//        string sql = "select filename from committeedetail where Id=39";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    else if (strMyUrl == "http://www.myct.in/mpcc.aspx?Id=40")
//    {
//        string sql = "select filename from committeedetail where Id=40";
//        string filename = cc.ExecuteScalar(sql);
//        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename));

//        fileDownload("'" + filename + "'", di.ToString());

//    }
//    //string sql = "select Committee_name,FileName from committeedetail where Committee_url='" + strMyUrl.Trim() + "'";
//    //DataSet ds = cc.ExecuteDataset(sql);
//    //string committeename = Convert.ToString(ds.Tables[0].Rows[0]["Committee_name"]);
//    //string filename = Convert.ToString(ds.Tables[0].Rows[0]["FileName"]);
//    //DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/downloadfilesMLA/" + filename.Trim()));
//    //fileDownload("'" + filename + "'", di.ToString());


//}
//private void fileDownload(string fileName, string fileUrl)
//{
//    Page.Response.Clear();
//    bool success = ResponseFile(Page.Request, Page.Response, fileName, fileUrl, 1024000);
//    if (!success)
//        Response.Write("Downloading Error!");
//    // Page.Response.End();

//}
//public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
//{
//    try
//    {
//        FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//        BinaryReader br = new BinaryReader(myFile);

//        try
//        {
//            _Response.AddHeader("Accept-Ranges", "bytes");
//            _Response.Buffer = false;
//            long fileLength = myFile.Length;
//            long startBytes = 0;

//            int pack = 10240; //10K bytes
//            int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
//            if (_Request.Headers["Range"] != null)
//            {
//                _Response.StatusCode = 206;
//                string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
//                startBytes = Convert.ToInt64(range[1]);
//            }
//            _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
//            if (startBytes != 0)
//            {
//                _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
//            }
//            _Response.AddHeader("Connection", "Keep-Alive");
//            _Response.ContentType = "application/octet-stream";
//            _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

//            br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
//            int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

//            for (int i = 0; i < maxCount; i++)
//            {
//                if (_Response.IsClientConnected)
//                {
//                    _Response.BinaryWrite(br.ReadBytes(pack));
//                    Thread.Sleep(sleep);
//                }
//                else
//                {
//                    i = maxCount;
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            throw ex;
//            // return false;
//        }
//        finally
//        {
//            // br.Close();
//            //myFile.Close();
//        }
//    }
//    catch
//    {
//        return false;
//    }
//    return true;
//}