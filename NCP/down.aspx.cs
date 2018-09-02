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

public partial class smt_down : System.Web.UI.Page
{

    DataSet ds;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {


         
         //Response.ContentType = "image/jpg";

       
        string strMyUrl = System.Web.HttpContext.Current.Request.Url.ToString();
        //string strMyUrl = "http://www.myct.in/NCP/down.aspx?207935f2fd";

        string fetchsql = "select usr_url from frienddownloadlink where frnd_url='" + strMyUrl + "'";
         string a = cc.ExecuteScalar(fetchsql);
         string fetchsql2 = "select folderuserid,actual_filename from uploaddetails where url='" + a + "' ";
         DataSet ds = cc.ExecuteDataset(fetchsql2);
         string foldername = Convert.ToString(ds.Tables[0].Rows[0]["folderuserid"]);
         string actualfname = Convert.ToString(ds.Tables[0].Rows[0]["actual_filename"]);
         string[] newurl = strMyUrl.Split('?');
         string firsturl = newurl[0];
         string userResource = "User_Resource/";
         firsturl = firsturl + userResource + newurl[1];

        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/User_Resource/" + foldername + ("/")));
        string s6 = Server.MapPath("");
        int i = 0;
        foreach (FileInfo fi in di.GetFiles())
        {
            //if (System.IO.Path.GetExtension(di.Name).ToLower() != ".mp3" && System.IO.Path.GetExtension(di.Name).ToLower() != ".flv" && System.IO.Path.GetExtension(di.Name).ToLower() != ".avi" && System.IO.Path.GetExtension(di.Name).ToLower() != ".xlsx" && System.IO.Path.GetExtension(di.Name).ToLower() != ".pdf" && System.IO.Path.GetExtension(di.Name).ToLower() != ".jpg" && System.IO.Path.GetExtension(di.Name).ToLower() != ".png" && System.IO.Path.GetExtension(di.Name).ToLower() != ".gif" && System.IO.Path.GetExtension(di.Name).ToLower() != ".jpeg")
            if (System.IO.Path.GetExtension(di.Name).ToLower() != ".wav" && System.IO.Path.GetExtension(di.Name).ToLower() != ".mp4" && System.IO.Path.GetExtension(di.Name).ToLower() != ".txt" && System.IO.Path.GetExtension(di.Name).ToLower() != ".doc" && System.IO.Path.GetExtension(di.Name).ToLower() != ".xlsx" && System.IO.Path.GetExtension(di.Name).ToLower() != ".mp3" && System.IO.Path.GetExtension(di.Name).ToLower() != ".flv" && System.IO.Path.GetExtension(di.Name).ToLower() != ".avi" && System.IO.Path.GetExtension(di.Name).ToLower() != ".xls" && System.IO.Path.GetExtension(di.Name).ToLower() != ".pdf" && System.IO.Path.GetExtension(di.Name).ToLower() != ".jpg" && System.IO.Path.GetExtension(di.Name).ToLower() != ".png" && System.IO.Path.GetExtension(di.Name).ToLower() != ".gif" && System.IO.Path.GetExtension(di.Name).ToLower() != ".jpeg" && System.IO.Path.GetExtension(di.Name).ToLower() != ".csv")
            {
                string Sql = "insert into DownloadFile_Details(FileLink)values('" + di.FullName + "')";
                ds = cc.ExecuteDataset(Sql);
                if (fi.Name == actualfname)
                {
                    string sqlshow = "select flag from frienddownloadlink  where frnd_url='" + strMyUrl + "'";
                    string check = cc.ExecuteScalar(sqlshow);
                    if (check == "Active")
                    {
                        fileDownload(fi.Name, di.FullName + fi.Name);
                        string updatequery = "update frienddownloadlink set flag='Deactive' where frnd_url='" + strMyUrl + "'";
                        int deac = cc.ExecuteNonQuery(updatequery);
                       
                    }
                    else
                    {
                        Label1.Visible = true;
                        Label1.Text = "You have already downloaded this file !!";
                        //Response.Write("You have already downloaded this file");
                    }
                }
                

                //fileDownload(fi.Name, Server.MapPath("~/User_Resource/02db0deb-c7b9-4843-ae4e-5d59834af43b/" + fi.Name));

            }
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
}

