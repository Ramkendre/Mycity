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
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for SendsmsDAL
/// </summary>
public class SendsmsDAL
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings[""]);
    int status;
    DataSet ds = new DataSet();
	public SendsmsDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet DALGetFriendGroupWise(SendsmsBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@getid", obj.Groupid);
            par[1] = new SqlParameter("@userid", obj.Userid);
            par[2] = new SqlParameter("@fname", obj.Fname);
            par[3] = new SqlParameter("@lname", obj.Lname);


        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;

    }
}
