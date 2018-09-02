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
/// Summary description for EventMeetingBLL
/// </summary>
public class EventMeetingBLL
{
	public EventMeetingBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int ID;
    public int ID1
    {
        set { ID = value; }
        get { return ID; }
    }
    private string ETitle;
    public string ETitle1
    {
        set { ETitle = value; }
        get { return ETitle; }
    }
    private string MeetingType;
    public string MeetingType1
    {
        set { MeetingType = value; }
        get { return MeetingType; }
    }
    private string Location;
    public string Location1
    {
        set { Location = value; }
        get { return Location; }
    }
    private string FrmDate;
    public string FrmDate1
    {
        set { FrmDate = value; }
        get { return FrmDate; }
    }
    private string FrmTime;
    public string FrmTime1
    {
        set { FrmTime = value; }
        get { return FrmTime; }
    }
    private string UptoDate;
    public string UptoDate1
    {
        set { UptoDate = value; }
        get { return UptoDate; }
    }
    private string RemTime;
    public string RemTime1
    {
        set {RemTime=value;}
        get {return RemTime;}
    }
    private string Descp;
    public string Descp1
    {
        set {Descp=value; }
        get {return Descp;}
    }
    private string RepRemainder;
    public string RepRemainder1
    {
        set {RepRemainder=value;}
        get {return RepRemainder;}
    }
    private string UserId;
    public string UserId1
    {
        set {UserId=value;}
        get {return UserId;}
    }
    private string UptoTime;
    public string UptoTime1
    {
        set { UptoTime = value; }
        get { return UptoTime; }
    }
    private string RemDate;
    public string RemDate1
    {
        set { RemDate = value; }
        get { return RemDate; }
    }
    private string Status1;
    public string Status3
    {
        set { Status1 = value; }
        get { return Status1; }
    }

    private string Status2;
    public string Status4
    {
        set { Status2 = value; }
        get { return Status2; }
    }
    public string LastUTime;
    public string LastUTime2
    {
        set { LastUTime = value; }
        get { return LastUTime; }
    }
    
    EventMeetingDAL objEventMeetingDAL = new EventMeetingDAL();

    public DataSet LoadgridBLL(EventMeetingBLL objEventMeetingBLL)
    {
        return objEventMeetingDAL.LoadGrid(objEventMeetingBLL);
    }
    public int AddRecordBLL(EventMeetingBLL objEventMeetingBLL)
    {
        int i = objEventMeetingDAL.AddRecord(objEventMeetingBLL);
        return i;
    }
    public void SelectRecordBLL(EventMeetingBLL objEventMeetingBLL)
    {
        objEventMeetingDAL.SelectRecord(objEventMeetingBLL);
    
    }
    public int UpdateBLL(EventMeetingBLL objEventMeetingBLL)
    {
        int i = objEventMeetingDAL.UpdateRecord(objEventMeetingBLL);
        return i;
    }
       
    

}
