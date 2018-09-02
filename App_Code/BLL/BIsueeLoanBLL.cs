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
/// Summary description for BIsueeLoanBLL
/// </summary>
public class BIsueeLoanBLL
{
	public BIsueeLoanBLL()
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
    private string SMember;

    public string SMember1
    {
        get { return SMember; }
        set { SMember = value; }
    }
    private string PreBalance;

    public string PreBalance1
    {
        get { return PreBalance; }
        set { PreBalance = value; }
    }

    private String LoanAmt;
    public String LoanAmt1
    {
        set { LoanAmt = value; }
        get { return LoanAmt; }
    }
    private String DateOfIssue;
    public String DateOfIssue1
    {
        set { DateOfIssue = value; }
        get { return DateOfIssue; }
    }
    private String MInstalment;
    public String MInstalment1
    {
        set { MInstalment = value; }
        get { return MInstalment; }
    }
    private String DueDate;
    public String DueDate1
    {
        set { DueDate = value; }
        get { return DueDate; }
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

    BIsueeLoanDAL objBIsueeLoanDAL = new BIsueeLoanDAL();

    public DataSet LoadgridBLL(BIsueeLoanBLL objBIsueeLoanBLL)
    {
        return objBIsueeLoanDAL.LoadGrid(objBIsueeLoanBLL);

    }
    public int AddRecordBLL(BIsueeLoanBLL objBIsueeLoanBLL)
    {
        int k = objBIsueeLoanDAL.AddRecord(objBIsueeLoanBLL);
        return k;
    }
    public int Update(BIsueeLoanBLL objBIsueeLoanBLL)
    {
        int i = objBIsueeLoanDAL.UpdateRecord(objBIsueeLoanBLL);
        return i;
    }
    public void SelectRecord(BIsueeLoanBLL objBIsueeLoanBLL)
    {
        objBIsueeLoanDAL.Select(objBIsueeLoanBLL);
    }
}
