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
/// Summary description for EventBirthDayBLL
/// </summary>
public class EventBirthDayBLL
{
    public EventBirthDayBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private Int16 BID;

    public Int16 BID1
    {
        get { return BID; }
        set { BID = value; }
    }
    private string NameOfPerson;

    public string NameOfPerson1
    {
        get { return NameOfPerson; }
        set { NameOfPerson = value; }
    }
    private string UserId;

    public string UserId1
    {
        get { return UserId; }
        set { UserId = value; }
    }

    private String Birthdate;
    public String Birthdate1
    {
        set { Birthdate = value; }
        get { return Birthdate; }
    }
     
    
    private string Time;

    public string Time1
    {
        get { return Time; }
        set { Time = value; }
    }
    private string Descp;

    public String Descp1
    {
        set { Descp = value; }
        get { return Descp; }
    }    
    private string BirthDate;

    public String BirthDate1
    {
        set { BirthDate = value; }
        get { return BirthDate; }
    }
    private string MobileNo;

    public string MobileNo1
    {
        get { return MobileNo; }
        set { MobileNo = value; }
    }
    private String Gender;
    public String Gender1
    {
        set { Gender = value; }
        get { return Gender; }
    }

    private String SMsg;
    public String SMsg1
    {
        set { SMsg = value; }
        get { return SMsg; }
    }
    private String MDescp;
    public String MDescp1
    {
        set { MDescp = value; }
        get { return MDescp; }
    }
    private string Status1;
    public string Status
    {
        set { Status1 = value; }
        get { return Status1; }
    }
    private string @Status2;
    public string Status4
    {
        set { Status2 = value; }
        get { return Status2; }
    }
    private string RemDate;
    public string RemDate1
    {
        set { RemDate =value;}
        get { return RemDate; }
    }
    //public string LastUTime;
    //public string LastUTime2
    //{
    //    set { LastUTime = value; }
    //    get { return LastUTime; }
    //}
    
    //private string @Status3;
    //public string Status5
    //{
    //    set { Status3 = value; }
    //    get { return Status3; }
    //}
    EventBirthDayDAL ovjEBD = new EventBirthDayDAL();

    public DataSet LoadgridBLL(EventBirthDayBLL objEBDB)
    {
        return ovjEBD.loadGrid(objEBDB);
        
    }
    public int AddRecordBLL(EventBirthDayBLL objEBDB)
    {
        int k = ovjEBD.AddRecord(objEBDB);
        return k;
    }
    public DataSet catchBdayBLL(EventBirthDayBLL objEBDB)
    {
        return ovjEBD.catchBDay(objEBDB);
       
    }
    public void Selectrecord(EventBirthDayBLL objEBDB)
    {
        ovjEBD.SelectRecord(objEBDB);
    }
    public int UpdateRecordBLL(EventBirthDayBLL objEBDB)
    {
        int k = ovjEBD.UpdateRecord(objEBDB);
        return k;
    }
}
