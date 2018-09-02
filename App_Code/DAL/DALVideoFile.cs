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
/// Summary description for DALVideoFile
/// </summary>
public class DALVideoFile
{
    CommonCode cc = new CommonCode();
    int status;
	public DALVideoFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int DALInsertVideo(BLLVideoFile obj)
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@url", obj.Url);
                par[1] = new SqlParameter("@filename", obj.Filename);
                par[2] = new SqlParameter("@userid", obj.Userid);
                par[3] = new SqlParameter("@status", 5);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "VideoInsert", par);
                status = (int)par[3].Value;
            }
            catch (Exception ex)
            { }
            finally
            {
                cn.Close();
            }
        }
        return status;

    }
}
