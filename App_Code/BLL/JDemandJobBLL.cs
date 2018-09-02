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
/// Summary description for JDemandJobBLL
/// </summary>
public class JDemandJobBLL
{
	public JDemandJobBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    private Int16 DID;
    public Int16 DID1
    {
        get { return DID; }
        set { DID = value; }
    }
    private string Sector;

    public string Sector1
    {
        get { return Sector; }
        set { Sector = value; }
    }
    private string JRole;

    public string JRole1
    {
        get { return JRole; }
        set { JRole = value; }
    }

    private String Experience;
    public String Experience1
    {
        set { Experience = value; }
        get { return Experience; }
    }
    private String Salary;
    public String Salary1
    {
        set { Salary = value; }
        get { return Salary; }
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
    private String Date;
    public String Date1
    {
        set { Date = value; }
        get { return Date; }
    }
    private String IntrestedFor;
    public String IntrestedFor1
    {
        set { IntrestedFor = value; }
        get { return IntrestedFor; }
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


    JDemandJobDAL objJDemandJobDAL = new JDemandJobDAL();

    //public DataSet LoadgridBLL(BExpEntriesBLL objBExpEntriesBLL)
    //{
    //    return objBExpEntriesDAL.LoadGrid(objBExpEntriesBLL);

    //}
    public int AddRecordBLL(JDemandJobBLL objJDemandJobBLL)
    {
        int k = objJDemandJobDAL.AddRecord(objJDemandJobBLL);
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
