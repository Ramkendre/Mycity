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
/// Summary description for BLLVideoFile
/// </summary>
public class BLLVideoFile
{
    DALVideoFile objvideo = new DALVideoFile();
    int status;
	public BLLVideoFile()
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
    private string _filename;

    public string Filename
    {
        get { return _filename; }
        set { _filename = value; }
    }
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }

    public int BLLInsertVideo(BLLVideoFile ur)
    {
        status = objvideo.DALInsertVideo(ur);
        return status;
    }
}
