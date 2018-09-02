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
/// Summary description for BALMiscalRegistration
/// </summary>
public class BALMiscalRegistration
{
    DALMiscalRegistration dalmiscalreg = new DALMiscalRegistration();
    int status;
	public BALMiscalRegistration()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _id;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    private string _friendid;

    public string Friendid
    {
        get { return _friendid; }
        set { _friendid = value; }
    }
    private string _groupno;

    public string Groupno
    {
        get { return _groupno; }
        set { _groupno = value; }
    }

    private string _FriendName;

    public string FriendName
    {
        get { return _FriendName; }
        set { _FriendName = value; }
    }
    private string simno;

    public string Simno
    {
        get { return simno; }
        set { simno = value; }
    }
    private string _IMEINO;

    public string IMEINO
    {
        get { return _IMEINO; }
        set { _IMEINO = value; }
    }

    public int BALInsertMiscalRegistration(BALMiscalRegistration obj)
    {
        status = dalmiscalreg.DALInsertMiscalRegistration(obj);
        return status;

    }
    public int BALUpdateMiscalRegistration(BALMiscalRegistration obj)
    {
        status = dalmiscalreg.DALUpdateMiscalRegistration(obj);
        return status;

    }
    public int BALFriendIsExist(BALMiscalRegistration obj)
    {
        status = dalmiscalreg.DALFriendIsExist(obj);
        return status;
    }

    public DataSet BALGetAllMiscalReport(BALMiscalRegistration obj)
    {
        DataSet ds=dalmiscalreg.DALGetAllMiscalReport(obj);
        return ds;
    }
    public DataSet BALGetAllMessageReport(BALMiscalRegistration obj)
    {
        DataSet ds = dalmiscalreg.DALGetAllMessageReport(obj);
        return ds;
    }



    
}
