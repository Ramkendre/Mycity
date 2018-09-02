using System;
using System.Collections .Generic ;
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
/// Summary description for BlogBll
/// </summary>
public class BlogBll
{
	public BlogBll()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    BlogDAL blogDalObj = new BlogDAL();

    private int _bgId;
    private string _BgWriter;
    private string _Bg;
    private DateTime _BgDate;
    private int _aggri;
    private int _notAggri;
    private string _photo;

    public int bgId
    {
        get { return _bgId; }
        set { _bgId = value; }
    }

    public string BgWriter
    {
        get { return _BgWriter; }
        set { _BgWriter = value; }
    }
    public string Bg
    {
        get { return _Bg; }
        set { _Bg = value; }
    }
    public DateTime BgDate
    {
        get { return _BgDate; }
        set { _BgDate = value; }
    }

    public int aggri
    {
        get { return _aggri; }
        set { _aggri = value; }
    }

    public int notAggri
    {
        get { return _notAggri; }
        set { _notAggri = value; }
    }

    public string photo
    {
        get { return _photo; }
        set { _photo = value; }
    }

    public List<BlogBll> getBlogData(BlogBll obj)
    {
        return blogDalObj.getBlog(obj);
    
    }

}
