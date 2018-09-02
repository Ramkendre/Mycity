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
/// Summary description for EventMyctBLL
/// </summary>
public class EventMyctBLL
{
	public EventMyctBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    EventMyctDAL objEventMyctDAL = new EventMyctDAL();


    private int Id;

    public int Id1
    {
        get { return Id; }
        set { Id = value; }
    }
    private string BrideName;

    public string BrideName1
    {
        get { return BrideName; }
        set { BrideName = value; }
    }
    private string GroomName;

    public string GroomName1
    {
        get { return GroomName; }
        set { GroomName = value; }
    }
    private string InvitionFrom;

    public string InvitionFrom1
    {
        get { return InvitionFrom; }
        set { InvitionFrom = value; }
    }
    private string Date;

    public string Date1
    {
        get { return Date; }
        set { Date = value; }
    }
    private string Time;

    public string Time1
    {
        get { return Time; }
        set { Time = value; }
    }
    private string Location;

    public string Location1
    {
        get { return Location; }
        set { Location = value; }
    }
    private string PersonName;

    public string PersonName1
    {
        get { return PersonName; }
        set { PersonName = value; }
    }

    private string MobileNumber;

    public string MobileNumber1
    {
        get { return MobileNumber; }
        set { MobileNumber = value; }
    }
    private string PVisit;

    public string PVisit1
    {
        get { return PVisit; }
        set { PVisit = value; }
    }
    
    private string MyCt_UserId;

    public string MyCt_UserId1
    {
        get { return MyCt_UserId; }
        set { MyCt_UserId = value; }
    }

    private string MDescp;

    public string MDescp1
    {
        get { return MDescp; }
        set { MDescp = value; }
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
    private string RemDate;
    public string RemDate1
    {
        set { RemDate = value; }
        get { return RemDate; }
    }
    private string RemTime;
    public string RemTime1
    {
        set { RemTime = value; }
        get { return RemTime; }
    }
    public int AddrecordBll(EventMyctBLL objEventMyctBLL)
    {
        int i = objEventMyctDAL.Addrecord(objEventMyctBLL);
        return i;
    }
    public DataSet LoadgridBLL(EventMyctBLL objEventMyctBLL)
    {
        return objEventMyctDAL.loadgrid(objEventMyctBLL);
    }
    public int UpdaterecordBll(EventMyctBLL objEventMyctBLL)
    {
        int i = objEventMyctDAL.Updaterecord(objEventMyctBLL);
        return i;
    }
    //public int DeleterecordBll(EventMyctBLL objEventMyctBLL)
    //{
    //    int i = objEventMyctDAL.Deleterecord(objEventMyctBLL);
    //    return i;
    //}
    public void Selectrecord(EventMyctBLL objEventMyctBLL)
    {
        objEventMyctDAL.SelectRecord(objEventMyctBLL);
    }


    //---------------------------------------------------------------------------------------------------- Usermaster-----------------------
    private string usrUserId;

    public string UsrUserId
    {
        get { return usrUserId; }
        set { usrUserId = value; }
    }
    private string usrFirstName;

    public string UsrFirstName
    {
        get { return usrFirstName; }
        set { usrFirstName = value; }
    }
    private string usrMiddleName;

    public string UsrMiddleName
    {
        get { return usrMiddleName; }
        set { usrMiddleName = value; }
    }
    private string usrMobileNo;

    public string usrMobileNo1
    {
        get { return usrMobileNo; }
        set { usrMobileNo = value; }
    }
    private string usrLastName;

    public string UsrLastName
    {
        get { return usrLastName; }
        set { usrLastName = value; }
    }
    public void SelectUserRecord(EventMyctBLL objEventMyctBLL)
    {
        objEventMyctDAL.SelectUserMaster(objEventMyctBLL);
    }



}
