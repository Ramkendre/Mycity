using System;
using System.Data;
using System.Configuration;
using System.Collections .Generic ;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for NewsBLL
/// </summary>
public class NewsBLL
{

    private int _id;
    private string _Name;
    private string _News;
    private DateTime _date;
    private int _NewsPaperID;
    private string _NewsPaperName;
    private int _DistId;
    private string _DistName;

    NewsDAL NewsDLLobj = new NewsDAL();

	public NewsBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string NewsPaperName
    {
        get { return _NewsPaperName; }
        set { _NewsPaperName = value; }
    }
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public int NewsPaperId
    {
        get { return _NewsPaperID;}
        set { _NewsPaperID = value; }
    }
    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
    public string NewsFrom
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string News
    {
        get { return _News; }
        set { _News = value; }
    }
    public int DistId
    {
        get { return _DistId; }
        set { _DistId = value; }
    }
    public string DistName
    {
        get { return _DistName; }
        set { _DistName = value; }
    }

    public List<NewsBLL> getNewsDDL()
    {
        return NewsDLLobj.getNewsDDL();
    }
    public List<NewsBLL> getDistNames()
    {
        return NewsDLLobj.getDistNames();
    }
    public List<NewsBLL> getNewsData(NewsBLL ooo)
    {
        return NewsDLLobj.getNewsData(ooo );
    }
}
