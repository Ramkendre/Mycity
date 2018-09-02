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
/// Summary description for EventMain1_IDBLL
/// </summary>
public class EventMain1_IDBLL
{
	public EventMain1_IDBLL()
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
    private int Sub_ID;
    public int Sub_ID1
    {
        set { Sub_ID = value; }
        get { return Sub_ID; }
    }
    private string Name;
    public string Name1
    {
        set { Name = value; }
        get { return Name; }
    }
    private string Description;
    public string Description1
    {
        set { Description = value; }
        get { return Description; }
    }
    private string User;
    public string User1
    {
        set { User = value; }
        get { return User; }
    }
    private string UserId;
    public string UserId1
    {
        set { UserId = value; }
        get { return UserId; }
    }
    EventMain1_IDDAL objEMain1_IDDAL = new EventMain1_IDDAL();
    public int AddrecordBLL(EventMain1_IDBLL objEMain1_IDBLL)
    {
        int i = objEMain1_IDDAL.AddRecord(objEMain1_IDBLL);
        return i;
    }
}
