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
/// Summary description for EventNewsBLL
/// </summary>
public class EventNewsBLL
{
	public EventNewsBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int NID;
    public int NID1
    {
        set { NID = value; }
        get { return NID; }
    }
    private string NewsHead;
    public string NewsHead1
    {
        set { NewsHead = value; }
        get { return NewsHead; }
    }
    private string NewsDetails;
    public string NewsDetails1
    {
        set { NewsDetails = value; }
        get { return NewsDetails; }
    }
    private string NPaper;
    public string NPaper1
    {
        set { NPaper = value; }
        get { return NPaper; }
    }
    private string Role;
    public string Role1
    {
        set { Role = value; }
        get { return Role; }
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
    private string TypeOfNews;
    public string TypeOfNews1
    {
        set { TypeOfNews = value; }
        get { return TypeOfNews; }
    }
    private string Location;
    public string Location1
    {
        set { Location = value; }
        get { return Location; }
    }
    private string Feedback;
    public string Feedback1
    {
        set { Feedback = value; }
        get { return Feedback; }
    }
    private string UserId;
    public string UserId1
    {
        set { UserId = value; }
        get { return UserId;
        }
    }
    private string usrMobileNo;
    public string usrMobileNo1
    {
        set { usrMobileNo1 = value; }
        get
        {
            return usrMobileNo1;
        }
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
    EventNewsDAL objEventNewsDAL=new EventNewsDAL();

    public DataSet LoadGridBLL(EventNewsBLL objEventNewsBLL)
    {
        return objEventNewsDAL.LoadGrid(objEventNewsBLL);
    }
    public DataSet LoadGridBLL1(EventNewsBLL objEventNewsBLL)
    {
        return objEventNewsDAL.LoadGrid(objEventNewsBLL);
    }
    public int AddRecordBLL(EventNewsBLL objEventNewsBLL)
    {
        int i = objEventNewsDAL.AddRecord(objEventNewsBLL);
        return i;
    }
    public void SelectRecordBLL(EventNewsBLL objEventNewsBLL)
    {
        objEventNewsDAL.SelectRecord(objEventNewsBLL);
    }
    public int UpdateBLL(EventNewsBLL objEventNewsBLL)
    {
        int i = objEventNewsDAL.UpdateRecord(objEventNewsBLL);
        return i;
    }
}

