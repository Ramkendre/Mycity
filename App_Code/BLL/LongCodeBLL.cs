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
/// Summary description for LongCodeBLL
/// </summary>
public class LongCodeBLL
{
    LongcodeDAL objdalLongcode = new LongcodeDAL();
	public LongCodeBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _sendercode;

    public int Sendercode
    {
        get { return _sendercode; }
        set { _sendercode = value; }
    }

    private string _frmdate;

    public string Frmdate
    {
        get { return _frmdate; }
        set { _frmdate = value; }
    }
    private string _todate;

    public string Todate
    {
        get { return _todate; }
        set { _todate = value; }
    }
    private string _mobileno;

    public string Mobileno
    {
        get { return _mobileno; }
        set { _mobileno = value; }
    }

    public DataSet BLLLongCodeReport(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALLongcodeReport(obj);
        return dt;
    }
    public DataSet BLLDARLongCodeReport(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALDARLongcodeReport(obj);
        return dt;
    }
    public DataSet BLLLongCodeReportAll(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALLongCodeReportAll(obj);
        return dt;
    }
    public DataSet BLLNSSLongCodeReport(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALNSSLongcodeReport(obj);
        return dt;
    }
    public DataSet BLLNSSLongCodeReportAll(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALNSSLongCodeReportAll(obj);
        return dt;
    }
    public DataSet BLLSMSReport(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALSMSReport(obj);
        return dt;
    }
    public DataSet BLLSMSReportByMobile(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALSMSReportByMobile(obj);
        return dt;
    }
    public string BLLSMSReportcount(LongCodeBLL obj)
    {
        string count = objdalLongcode.DALSMSReportCount(obj);
        return count;
    }

    public DataSet BLLSMSCode(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALSMSCode(obj);
        return dt;
    }
    public DataSet BLLgetsmsbyid(LongCodeBLL obj)
    {
        DataSet dt = objdalLongcode.DALgetsmsbyid(obj);
        return dt;
    }
    public string BLLgetsmsbyidcount(LongCodeBLL obj)
    {
        string count = objdalLongcode.DALgetsmsbyidCount(obj);
        return count;
    }
    public DataSet BLLgetlongcoderecord(LongCodeBLL obj)
    {
        DataSet ds=objdalLongcode.DALgetlongcoderecord(obj);
        return ds;
    }
}
