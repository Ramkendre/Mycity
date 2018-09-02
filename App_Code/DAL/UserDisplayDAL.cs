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
/// Summary description for UserDisplayDAL
/// </summary>
public class UserDisplayDAL
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();
    int status;
	public UserDisplayDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet DALGetUserVisitors(UserDisplayBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserVisitors", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public int DALGetUserVisitorsUpdate(UserDisplayBLL obj)
    {

        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userid", obj.Userid);
            par[1] = new SqlParameter("@usrRecentVisitor", obj.Recentvisitor);
            par[2] = new SqlParameter("@status", 1);
            par[2].Direction = ParameterDirection.Output;
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "GetUserVisitorsUpdate", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return status;

    }

}
