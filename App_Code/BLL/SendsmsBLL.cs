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
/// Summary description for SendsmsBLL
/// </summary>
public class SendsmsBLL
{
    SendsmsDAL objdal = new SendsmsDAL();
    DataSet ds = new DataSet();
	public SendsmsBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    private string _usrMobile;

    public string UsrMobile
    {
        get { return _usrMobile; }
        set { _usrMobile = value; }
    }
    private string _groupid;

    public string Groupid
    {
        get { return _groupid; }
        set { _groupid = value; }
    }

    private string _fname;

    public string Fname
    {
        get { return _fname; }
        set { _fname = value; }
    }
    private string _lname;

    public string Lname
    {
        get { return _lname; }
        set { _lname = value; }
    }
    public DataSet BLLGetFriendGroupWise(SendsmsBLL obj)
    {
        ds = objdal.DALGetFriendGroupWise(obj);
        return ds;
    }
}
