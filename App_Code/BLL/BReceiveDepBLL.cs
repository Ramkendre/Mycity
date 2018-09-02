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
/// Summary description for BReceiveDepBLL
/// </summary>
public class BReceiveDepBLL
{
	public BReceiveDepBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private Int16 ID;
    public Int16 ID1
    {
        get { return ID; }
        set { ID = value; }
    }
    private string MID;

    public string MID1
    {
        get { return MID; }
        set { MID = value; }
    }
    private string DepositeAmt;

    public string DepositeAmt1
    {
        get { return DepositeAmt; }
        set { DepositeAmt = value; }
    }

    private String PaymentType;
    public String PaymentType1
    {
        set { PaymentType = value; }
        get { return PaymentType; }
    }
    private String DepositPeriod;
    public String DepositPeriod1
    {
        set { DepositPeriod = value; }
        get { return DepositPeriod; }
    }
    private String Date;
    public String Date1
    {
        set { Date = value; }
        get { return Date; }
    }
    private String TentativeTime;
    public String TentativeTime1
    {
        set { TentativeTime = value; }
        get { return TentativeTime; }
    }
   
    private String UserId;
    public String UserId1
    {
        set { UserId = value; }
        get { return UserId; }
    }
    private String EntryDate;
    public String EntryDate1
    {
        set { EntryDate = value; }
        get { return EntryDate; }
    }

    BReceiveDepDAL objBReceiveDepDAL = new BReceiveDepDAL();

    public DataSet LoadgridBLL(BReceiveDepBLL objBReceiveDepBLL)
    {
        return objBReceiveDepDAL.LoadGrid(objBReceiveDepBLL);

    }
    public int AddRecordBLL(BReceiveDepBLL objBReceiveDepBLL)
    {
        int k = objBReceiveDepDAL.AddRecord(objBReceiveDepBLL);
        return k;
    }
    public int UpdateBLL(BReceiveDepBLL objBReceiveDepBLL)
    {
        int i = objBReceiveDepDAL.UpdateRecord(objBReceiveDepBLL);
        return i;
    }
    public void SelectBLL(BReceiveDepBLL objBReceiveDepBLL)
    {
        objBReceiveDepDAL.SelectRecord(objBReceiveDepBLL);
    }
}
