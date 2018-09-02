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
/// Summary description for DataCollectionBLL
/// </summary>
public class DataCollectionBLL
{
    DataCollectionDAL dalobjdatacollection = new DataCollectionDAL();
    int status;
    public DataCollectionBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string no_usefor;

    public string No_usefor
    {
        get { return no_usefor; }
        set { no_usefor = value; }
    }
    private string customer_contact;

    public string Customer_contact
    {
        get { return customer_contact; }
        set { customer_contact = value; }
    }
    private string _customername;

    public string Customername
    {
        get { return _customername; }
        set { _customername = value; }
    }
    private string _address;

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    private string _mobileno;

    public string Mobileno
    {
        get { return _mobileno; }
        set { _mobileno = value; }
    }
    private string _SIMno;

    public string SIMno
    {
        get { return _SIMno; }
        set { _SIMno = value; }
    }
    private string _regdate;

    public string Regdate
    {
        get { return _regdate; }
        set { _regdate = value; }
    }
    private string _IMEIMO;

    public string IMEIMO
    {
        get { return _IMEIMO; }
        set { _IMEIMO = value; }
    }

    private int _regid;

    public int Regid
    {
        get { return _regid; }
        set { _regid = value; }
    }

    private string _sendermobileno;

    public string Sendermobileno
    {
        get { return _sendermobileno; }
        set { _sendermobileno = value; }
    }
    private string _receiversimno;

    public string Receiversimno
    {
        get { return _receiversimno; }
        set { _receiversimno = value; }
    }
    private string _receiverIMEINO;

    public string ReceiverIMEINO
    {
        get { return _receiverIMEINO; }
        set { _receiverIMEINO = value; }
    }
    private string _message;

    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }
    private string _date;

    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }
    private string send_data;

    public string Send_data
    {
        get { return send_data; }
        set { send_data = value; }
    }
    private string _responseMsg;

    public string ResponseMsg
    {
        get { return _responseMsg; }
        set { _responseMsg = value; }
    }
    private string _mobileNumber;

    public string MobileNumber
    {
        get { return _mobileNumber; }
        set { _mobileNumber = value; }
    }
    private string _recordDate;

    public string RecordDate
    {
        get { return _recordDate; }
        set { _recordDate = value; }
    }

    private string MissCallType;

    public string MissCallType1
    {
        get { return MissCallType; }
        set { MissCallType = value; }
    }

    private string customer_contact1;

    public string Customer_contact1
    {
        get { return customer_contact1; }
        set { customer_contact1 = value; }
    }
    private string customer_contact2;

    public string Customer_contact2
    {
        get { return customer_contact2; }
        set { customer_contact2 = value; }
    }
    private string customer_contact3;

    public string Customer_contact3
    {
        get { return customer_contact3; }
        set { customer_contact3 = value; }
    }
    private string customer_contact4;

    public string Customer_contact4
    {
        get { return customer_contact4; }
        set { customer_contact4 = value; }
    }


    public int BLLInsertLongCodeRegistration(DataCollectionBLL obj)
    {
        status = dalobjdatacollection.DALInsertLongCodeRegistration(obj);
        return status;

    }
    public DataSet BLLGetLongCodeInfo(DataCollectionBLL obj)
    {
        DataSet dtgetdetails = dalobjdatacollection.DALGetLongCodeDetails(obj);
        return dtgetdetails;
    }

    public int BLLDeleteLongCode(DataCollectionBLL obj)
    {
        status = dalobjdatacollection.DALDeleteLongCode(obj);
        return status;
    }

    public int BLLUpdateLongCodeRegistration(DataCollectionBLL obj)
    {
        status = dalobjdatacollection.DALUpdateLongCodeRegistration(obj);
        return status;
    }
}
