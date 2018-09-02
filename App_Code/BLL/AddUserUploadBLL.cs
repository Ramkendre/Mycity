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
/// Summary description for AddUserUpload
/// </summary>
public class AddUserUploadBLL
{
	public AddUserUploadBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string _leaderid;

    public string Leaderid
    {
        get { return _leaderid; }
        set { _leaderid = value; }
    }
    private string _juniorid;

    public string Juniorid
    {
        get { return _juniorid; }
        set { _juniorid = value; }
    }
    private int _schoolcode;

    public int Schoolcode
    {
        get { return _schoolcode; }
        set { _schoolcode = value; }
    }
    private string _class;
    public string Class
    {
        get { return _class; }
        set { _class = value; }
    }
    private string _section;

    public string Section
    {
        get { return _section; }
        set { _section = value; }
    }


}
