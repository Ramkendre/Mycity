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
/// Summary description for EventCFollowUpBLL
/// </summary>
public class EventCFollowUpBLL
{
	public EventCFollowUpBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string CID;
    public string CID1
    {
        set { CID = value; }
        get { return CID; }
    }
    private string Date;
    public string Date1
    {
        set { Date = value; }
        get { return Date; }
    }
    private string Remark;
    public string Remark1
    {
        set { Remark = value; }
        get { return Remark; }
    }
    private string Status;
    public string Status1
    {
        set { Status = value; }
        get { return Status; }
    }
    private string Status2;
    public string Status3
    {
        set { Status2 = value; }
        get { return Status2; }
    }
    private string Status4;
    public string Status5
    {
        set { Status4 = value; }
        get { return Status5; }
    }
    private string UserId;
    public string UserId1
    {
        set { UserId = value; }
        get { return UserId; }
    }
    private string CurrentDate;
    public string CurrentDate1
    {
        set { CurrentDate = value; }
        get { return CurrentDate; }
    }
    EventCFollowUpDAL objCFDAL = new EventCFollowUpDAL();
    public DataSet LoadgridBLL(EventCFollowUpBLL objCFBLL)
    {
        return objCFDAL.LoadGrid(objCFBLL);

    }
    public int AddrecordBLL(EventCFollowUpBLL objCFBLL)
    {
        int i = objCFDAL.AddRecord(objCFBLL);
        return i;
    }
    //public void SelectBLL(EventCFollowUpBLL objCFBLL)
    //{ }
}
