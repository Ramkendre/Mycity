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
/// Summary description for BExpEntriesBLL
/// </summary>
public class BExpEntriesBLL
{
	public BExpEntriesBLL()
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
    private string Date;

    public string Date1
    {
        get { return Date; }
        set { Date = value; }
    }
    private string VoucharNo;

    public string VoucharNo1
    {
        get { return VoucharNo; }
        set { VoucharNo = value; }
    }

    private String TypeOfExp;
    public String TypeOfExp1
    {
        set { TypeOfExp = value; }
        get { return TypeOfExp; }
    }
    private String Amount;
    public String Amount1
    {
        set { Amount = value; }
        get { return Amount; }
    }
    private String Description;
    public String Description1
    {
        set { Description = value; }
        get { return Description; }
    }
    private String Mode;
    public String Mode1
    {
        set { Mode = value; }
        get { return Mode; }
    }
    private String FYDateFr;
    public String FYDateFr1
    {
        set { FYDateFr = value; }
        get { return FYDateFr; }
    }
    private String FYDateTo;
    public String FYDateTo1
    {
        set { FYDateTo = value; }
        get { return FYDateTo; }
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

    BExpEntriesDAL objBExpEntriesDAL = new BExpEntriesDAL();

    public DataSet LoadgridBLL(BExpEntriesBLL objBExpEntriesBLL)
    {
        return objBExpEntriesDAL.LoadGrid(objBExpEntriesBLL);

    }
    public int AddRecordBLL(BExpEntriesBLL objBExpEntriesBLL)
    {
        int k = objBExpEntriesDAL.AddRecord(objBExpEntriesBLL);
        return k;
    }
    public int UpdateBLL(BExpEntriesBLL objBExpEntriesBLL)
    {
        int i = objBExpEntriesDAL.UpdateRecord(objBExpEntriesBLL);
        return i;
    }
    public void SelectBLL(BExpEntriesBLL objBExpEntriesBLL)
    {
        objBExpEntriesDAL.SelectRecord(objBExpEntriesBLL);
    }

}
