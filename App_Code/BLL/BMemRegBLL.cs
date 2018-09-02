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
/// Summary description for BMemRegBLL
/// </summary>
public class BMemRegBLL
{
	public BMemRegBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private Int16 MID;
    public Int16 MID1
    {
        get { return MID; }
        set { MID = value; }
    }
    //private string SSGName;

    //public string SSGName1
    //{
    //    get { return SSGName; }
    //    set { SSGName = value; }
    //}
    private string GID;
    public string GID1
    {
        get { return GID; }
        set { GID = value; }
    }
    private string FName;

    public string FName1
    {
        get { return FName; }
        set { FName = value; }
    }

    private String LName;
    public String LName1
    {
        set { LName = value; }
        get { return LName; }
    }
    private String MobileNo;
    public String MobileNo1
    {
        set { MobileNo = value; }
        get { return MobileNo; }
    }
    private String Post;
    public String Post1
    {
        set { Post = value; }
        get { return Post; }
    }
    private String DOJ;
    public String DOJ1
    {
        set { DOJ = value; }
        get { return DOJ; }
    }
    private String Subscription;
    public String Subscription1
    {
        set { Subscription = value; }
        get { return Subscription; }
    }
    private String Deposite;
    public String Deposite1
    {
        set { Deposite = value; }
        get { return Deposite; }
    }
    private String Loan;
    public String Loan1
    {
        set { Loan = value; }
        get { return Loan; }
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

    BMemRegDAL objBMRegDAL = new BMemRegDAL();

    public DataSet LoadgridBLL(BMemRegBLL objBMemRegBLL)
    {
        return objBMRegDAL.LoadGrid(objBMemRegBLL);

    }
    public int AddRecordBLL(BMemRegBLL objBMemRegBLL)
    {
        int k = objBMRegDAL.AddRecord(objBMemRegBLL);
        return k;
    }
    public int UpdateBLL(BMemRegBLL objBMemRegBLL)
    {
        int i = objBMRegDAL.UpdateRecord(objBMemRegBLL);
        return i;
    }
    public void SelectBLL(BMemRegBLL objBMemRegBLL)
    {
        objBMRegDAL.SelectRecord(objBMemRegBLL);
    }

}
