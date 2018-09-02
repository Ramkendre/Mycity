using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for VerifySMSBLL
/// </summary>
public class VerifySMSBLL
{
    private string _message;
    private string _mobileNo;
    private string _date;
    private int _flag;
    private int _pk;
    private string _SendFrom;
    private string _SendTo;
    private int _id;
    private string _SendSMS;
    private string _FlagCode;
    
    VerifySMSDAL objDLL = new VerifySMSDAL();

    int status;
	public VerifySMSBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string SendSMS
    {
        get { return _SendSMS; }
        set { _SendSMS = value; }
    }
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string FlagCode
    {
        get { return _FlagCode; }
        set { _FlagCode = value; }
    }
    public string SendFrom
    {
        get { return _SendFrom; }
        set { _SendFrom = value; }
    }
    public string SendTo
    {
        get { return _SendTo; }
        set { _SendTo = value; }
    }
    public string message
    {
        get { return _message; }
        set { _message = value; }
    }
    public string mobileNo
    {
        get { return _mobileNo; }
        set { _mobileNo = value; }
    }
    public string date
    {
        get { return _date; }
        set { _date = value; }
    }
    public int flag
    {
        get { return _flag; }
        set { _flag = value; }
    }
    public int pk
    {
        get { return _pk; }
        set { _pk = value; }
    }
    private string datefromdate;

    public string fromdate
    {
        get { return datefromdate; }
        set { datefromdate = value; }
    }
    private string dateToDate;

    public string ToDate
    {
        get { return dateToDate; }
        set { dateToDate = value; }
    }
    private string strCurrentDate;

public string CurrentDate
{
  get { return strCurrentDate; }
  set { strCurrentDate = value; }
}


    public List<VerifySMSBLL> getSMSHistory(VerifySMSBLL obj)
    {
        return objDLL.getSMSHistory(obj );
    
    }
    public List<VerifySMSBLL> getSendSMSHistory_currentDate(VerifySMSBLL obj)

    {
        return objDLL.getSendSMSHistory_CurrentDate(obj);
    }

    public DataSet getSMSHistory1(VerifySMSBLL obj)
    {
        DataSet ds = objDLL.getSMSHistoryCurrentdate(obj);
        return ds;

    }

    public List<VerifySMSBLL> getSMSHistory_ByDate(VerifySMSBLL obj)
    {
        return objDLL.getSMSHistory_ByDate(obj);

    }


    public List<VerifySMSBLL> getSendSMSHistory(VerifySMSBLL obj)
    {
        return objDLL.getSendSMSHistory(obj );
    }
}
