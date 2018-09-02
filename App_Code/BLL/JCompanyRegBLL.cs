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
/// Summary description for JCompanyRegBLL
/// </summary>
public class JCompanyRegBLL
{
	public JCompanyRegBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  
    private Int16 CID;
    public Int16 CID1
    {
        get { return CID; }
        set { CID = value; }
    }
    private string NameOfComp;

    public string NameOfComp1
    {
        get { return NameOfComp; }
        set { NameOfComp = value; }
    }
    private string TypeOfUnit;

    public string TypeOfUnit1
    {
        get { return TypeOfUnit; }
        set { TypeOfUnit = value; }
    }

    private String DirectName;
    public String DirectName1
    {
        set { DirectName = value; }
        get { return DirectName; }
    }
    private String MobileNo;
    public String MobileNo1
    {
        set { MobileNo = value; }
        get { return MobileNo; }
    }
    private String EmailId;
    public String EmailId1
    {
        set { EmailId = value; }
        get { return EmailId; }
    }
    private String FAddress;
    public String FAddress1
    {
        set { FAddress = value; }
        get { return FAddress; }
    }
    private String State;
    public String State1
    {
        set { State = value; }
        get { return State; }
    }
    private String District;
    public String District1
    {
        set { District = value; }
        get { return District; }
    }

    private String Taluka;
    public String Taluka1
    {
        set { Taluka = value; }
        get { return Taluka; }
    }
    private String City;
    public String City1
    {
        set { City = value; }
        get { return City; }
    }
    private String Sectors;
    public String Sectors1
    {
        set { Sectors = value; }
        get { return Sectors; }
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

   
    JCompanyRegDAL objJCompanyRegDAL = new JCompanyRegDAL();

    //public DataSet LoadgridBLL(BExpEntriesBLL objBExpEntriesBLL)
    //{
    //    return objBExpEntriesDAL.LoadGrid(objBExpEntriesBLL);

    //}
    public int AddRecordBLL(JCompanyRegBLL objJCompanyRegBLL)
    {
        int k = objJCompanyRegDAL.AddRecord(objJCompanyRegBLL);
        return k;
    }
    //public int UpdateBLL(BExpEntriesBLL objBExpEntriesBLL)
    //{
    //    int i = objBExpEntriesDAL.UpdateRecord(objBExpEntriesBLL);
    //    return i;
    //}
    //public void SelectBLL(BExpEntriesBLL objBExpEntriesBLL)
    //{
    //    objBExpEntriesDAL.SelectRecord(objBExpEntriesBLL);
    //}
}
