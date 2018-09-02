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
/// Summary description for DALConnection1
/// </summary>
public class DALConnection1
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
	public DALConnection1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet DALGetMiscalRecord()
    {
        DataSet ds;
        try
        {
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetMiscalRecord");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
        }
        return ds;
       
    }
}
