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
/// Summary description for SendMsgBLL
/// </summary>
public class SendMsgBLL
{
    SendMsgDAL dalobj = new SendMsgDAL();
    int status;
	public SendMsgBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _pk;

    public int Pk
    {
        get { return _pk; }
        set { _pk = value; }
    }
    private string _Message;

    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }
    private string _mobile;
    public string mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }
    private DateTime _shortcode;

    public DateTime Shortcode
    {
        get { return _shortcode; }
        set { _shortcode = value; }
    }
    private string _data;

    public string Data
    {
        get { return _data; }
        set { _data = value; }
    }
    private int _Flagstatus;

    public int Flagstatus
    {
        get { return _Flagstatus; }
        set { _Flagstatus = value; }
    }
    private DateTime _SendDate;

    public DateTime SendDate
    {
        get { return _SendDate; }
        set { _SendDate = value; }
    }
    private int _nosentmessage;

    public int Nosentmessage
    {
        get { return _nosentmessage; }
        set { _nosentmessage = value; }
    }
    private string _smsStatus;

    public string SmsStatus
    {
        get { return _smsStatus; }
        set { _smsStatus = value; }
    }
    private string userid;

    public string Userid
    {
        get { return userid; }
        set { userid = value; }
    }

    public int BLLInsertLongcodeData(SendMsgBLL obj)
    {
        status = dalobj.DALInsertLongCodeData(obj);
        return status;
    }
    public int BLLGetLongCodeId(SendMsgBLL obj)
    {
        status = dalobj.DALGetLongCodeId(obj);
        return status;
    }

    public DataSet BLLGetUseridbyMobile(SendMsgBLL obj)
    {
        DataSet ds = dalobj.DALGetUseridbyMobile(obj);
        return ds;
    }

    public int BLLUserIdExist(SendMsgBLL obj)
    {
        status = dalobj.DALUserIdExist(obj);
        return status;
    }

    public DataSet BLLGetUserFname(SendMsgBLL obj)
    {
        DataSet ds = dalobj.DALGetUserFname(obj);
        return ds;
    }
}
