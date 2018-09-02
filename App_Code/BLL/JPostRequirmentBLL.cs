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
/// Summary description for JPostRequirmentBLL
/// </summary>
public class JPostRequirmentBLL
{
	public JPostRequirmentBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private Int16 PID;
    public Int16 PID1
    {
        get { return PID; }
        set { PID = value; }
    }
    private string CName;

    public string CName1
    {
        get { return CName; }
        set { CName = value; }
    }
    private string InSector;

    public string InSector1
    {
        get { return InSector; }
        set { InSector = value; }
    }
    private string JRole;

    public string JRole1
    {
        get { return JRole; }
        set { JRole = value; }
    }

    private String JRequirment;
    public String JRequirment1
    {
        set { JRequirment = value; }
        get { return JRequirment; }
    }
    private String Qualification;
    public String Qualification1
    {
        set { Qualification = value; }
        get { return Qualification; }
    }

    private String Skill;
    public String Skill1
    {
        set { Skill = value; }
        get { return Skill; }
    }
    private String VaccancyTill;
    public String VaccancyTill1
    {
        set { VaccancyTill = value; }
        get { return VaccancyTill; }
    }
    private String SalaryOffered;
    public String SalaryOffered1
    {
        set { SalaryOffered = value; }
        get { return SalaryOffered; }
    }
    private String FreExp;
    public String FreExp1
    {
        set { FreExp = value; }
        get { return FreExp; }
    }
    private String TrainingOffered;
    public String TrainingOffered1
    {
        set { TrainingOffered = value; }
        get { return TrainingOffered; }
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


    JPostRequirmentDAL objJPostReqDAL = new JPostRequirmentDAL();

    //public DataSet LoadgridBLL(BExpEntriesBLL objBExpEntriesBLL)
    //{
    //    return objBExpEntriesDAL.LoadGrid(objBExpEntriesBLL);

    //}
    public int AddRecordBLL(JPostRequirmentBLL objJPostReqBLL)
    {
        int k = objJPostReqDAL.AddRecord(objJPostReqBLL);
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
