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
/// Summary description for DownloadurlDAL
/// </summary>
public class DownloadurlDAL
{
	public DownloadurlDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet DALGetSpecificUrl(DownloadurlBLL ur)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds=new DataSet();
        try
        {
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetDownloadurl");

        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public DataSet DALGetAllUrl(DownloadurlBLL ur)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetAllDownloadurl");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public DataSet DALGetURLRecord(DownloadurlBLL ur)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@url", ur.Url);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetDownloadurlRecord", par);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();

        }
        return ds;
    }



}
