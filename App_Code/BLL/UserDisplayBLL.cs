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
/// Summary description for UserDisplayBLL
/// </summary>
public class UserDisplayBLL
{
    UserDisplayDAL objdal = new UserDisplayDAL();
    int status;
	public UserDisplayBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    private string _recentvisitor;

    public string Recentvisitor
    {
        get { return _recentvisitor; }
        set { _recentvisitor = value; }
    }
    public DataSet BLLGetUserVisitors(UserDisplayBLL obj)
    {
        DataSet ds = objdal.DALGetUserVisitors(obj);
        return ds;
    }

    public int BLLGetUserVisitorsUpdate(UserDisplayBLL obj)
    {
        status = objdal.DALGetUserVisitorsUpdate(obj);
        return status;
    }
}
