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

/// <summary>
/// Summary description for DownloadurlBLL
/// </summary>
public class DownloadurlBLL
{
    DownloadurlDAL dalobj = new DownloadurlDAL();
	public DownloadurlBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _url;

    public string Url
    {
        get { return _url; }
        set { _url = value; }
    }

    public DataSet BLLGetSpecificurl(DownloadurlBLL ur)
    {
        DataSet ds = dalobj.DALGetSpecificUrl(ur);
            return ds;
    }

    public DataSet BLLGetAllurl(DownloadurlBLL ur)
    {
        DataSet ds = dalobj.DALGetAllUrl(ur);
        return ds;
    }

    public DataSet BLLGetDownloadRecord(DownloadurlBLL ur)
    {
        DataSet ds = dalobj.DALGetURLRecord(ur);
            return ds;
    }
}
