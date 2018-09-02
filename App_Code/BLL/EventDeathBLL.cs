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
using System.Data.SqlClient;

/// <summary>
/// Summary description for EventDeathBLL
/// </summary>
public class EventDeathBLL
{
	public EventDeathBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int DID;
    public int DID1
    {
        set { DID = value; }
        get { return DID; }
    }
    private string NameOfAccused;
    public string NameOfAccused1
    {
        set { NameOfAccused = value; }
        get { return NameOfAccused; }
    }
    private string Date;
    public string Date1
    {
        set { Date = value; }
        get { return Date; }
    }
    private string Time;
    public string Time1
    {
        set { Time = value; }
        get { return Time; }
    }
    private string Location;
    public string Location1
    {
        set { Location = value; }
        get
        {
            return Location;
        }
    }
    private string SDescp;
    public string SDescp1
    {
        set { SDescp = value; }
        get { return SDescp; }
    }
    private string Relative;
    public string Relative1
    {
        set { Relative = value; }
        get { return Relative; }
    }
    private string Relation;
    public string Relation1
    {
        set { Relation = value; }
        get { return Relation; }
    }
    private string PVisit;
    public string PVisit1
    {
        set { PVisit = value; }
        get { return PVisit; }
    }
    private string MDescp;
    public string MDescp1
    {
        set { MDescp = value; }
        get { return MDescp; }
    }
    private string UserId;
    public string UserId1
    {
        set { UserId = value; }
        get { return UserId; }
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
    EventDeathDAL objEventDeathDAL = new EventDeathDAL();
    public DataSet loadgridBLL(EventDeathBLL objEventDeathBLL)
    {
        return objEventDeathDAL.loadgrid(objEventDeathBLL);
    }

    public int AddRecordBLL(EventDeathBLL objEventDeathBLL)
    {
        int i = objEventDeathDAL.AddRecord(objEventDeathBLL);
        return i;
    }
    public void SelectRecordBLL(EventDeathBLL objEventDeathBLL)
    {
       objEventDeathDAL.SelectRecord(objEventDeathBLL);
    }
    public int UpdateBLL(EventDeathBLL objEventDeathBLL)
    {
        int i=objEventDeathDAL.UpdateRecord(objEventDeathBLL);
        return i;
    }
}
