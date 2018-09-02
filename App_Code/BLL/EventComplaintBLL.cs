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
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for EventComplaintBLL
/// </summary>
public class EventComplaintBLL
{
	public EventComplaintBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int CID;
    public int CID1
    {
        set { CID = value; }
        get { return CID; }
    }
    private string UsrMobileNo;
    public string UsrMobileNo1
    {
        set { UsrMobileNo = value; }
        get { return UsrMobileNo; }
    }
    private string CompType;
    public string CompType1
    {
        set { CompType = value; }
        get { return CompType; }
    }
    private string Date;
    public string Date1
    {
        set { Date = value; }
        get { return Date; }
    }
    private string CompSub;
    public string CompSub1
    {
        set {CompSub=value;}
        get {return CompSub;}
    }
    private string CompName;
    public string CompName1
    {
        set { CompName = value; }
        get { return CompName; }
    }
    private string CompDetails;
    public string CompDetails1
    {
        set { CompDetails = value; }
        get { return CompDetails; }
    }
    private string CompFDept;
       public string CompFDept1
       {
       set {CompFDept=value;}
           get{return CompFDept;}
       }
       private string MobileNo;
       public string MobileNo1
       {
           set { MobileNo = value; }
           get { return MobileNo; }
       }
       private string Address;
       public string Address1
       {
           set { Address = value; }
           get { return Address; }
       }
       private string UserId;
       public string UserId1
       {
           set { UserId = value; }
           get { return UserId; }
       }

    
       EventComplaintDAL objECDAL = new EventComplaintDAL();
       public DataSet LoadGridBLL(EventComplaintBLL objECBLL)
       {
           return objECDAL.LoadGrid(objECBLL);
       }
       public DataSet LoadGridBLL1(EventComplaintBLL objECBLL)
       {
           return objECDAL.LoadGrid1(objECBLL);
       }
       public int AddrecordBLL(EventComplaintBLL objECBLL)
       {
           int i = objECDAL.AddRecord(objECBLL);
           return i;
       }
       public void SelectBLL(EventComplaintBLL objECBLL)
       {
          objECDAL.SelectRecord(objECBLL);
       }

       public int UpdateBLL(EventComplaintBLL objECBLL)
       {
           int i = objECDAL.UpdateRecord(objECBLL);
           return i;
       }
}
