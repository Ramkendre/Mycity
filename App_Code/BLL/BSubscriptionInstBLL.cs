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
/// Summary description for BSubscriptionInstBLL
/// </summary>
public class BSubscriptionInstBLL
{
	public BSubscriptionInstBLL()
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
    private string SubAmt;

    public string SubAmt1
    {
        get { return SubAmt; }
        set { SubAmt = value; }
    }

    private String LInstalment;
    public String LInstalment1
    {
        set { LInstalment = value; }
        get { return LInstalment; }
    }
    private String LIMonth;
    public String LIMonth1
    {
        set { LIMonth = value; }
        get { return LIMonth; }
    }
  
    private String Date;
    public String Date1
    {
        set { Date = value; }
        get { return Date; }
    }

    private String UserId;
    public String UserId1
    {
        set { UserId = value; }
        get { return UserId; }
    }
    private String EnteryDate;
    public String EnteryDate1
    {
        set { EnteryDate = value; }
        get { return EnteryDate; }
    }

    BSubscriptionInstDAL objBSubscriptionInstDAL = new BSubscriptionInstDAL();

    public DataSet LoadgridBLL(BSubscriptionInstBLL objBSubscriptionInstBLL)
    {
        return objBSubscriptionInstDAL.LoadGrid(objBSubscriptionInstBLL);

    }
    public int AddRecordBLL(BSubscriptionInstBLL objBSubscriptionInstBLL)
    {
        int k = objBSubscriptionInstDAL.AddRecord(objBSubscriptionInstBLL);
        return k;
    }
    public int UpdateBLL(BSubscriptionInstBLL objBSubscriptionInstBLL)
    {
        int i = objBSubscriptionInstDAL.UpdateRecord(objBSubscriptionInstBLL);
        return i;
    }

    public void SelectBLL(BSubscriptionInstBLL objBSubscriptionInstBLL)
    {
        objBSubscriptionInstDAL.SelectRecord(objBSubscriptionInstBLL);
    }
}

