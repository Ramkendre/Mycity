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
/// Summary description for AddUserUploadDAL
/// </summary>
public class AddUserUploadDAL
{
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    int status;
	public AddUserUploadDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int BLLInsertUserJunior(AddUserUploadBLL ur)
    {
        try
        {
            SqlParameter[] par =new SqlParameter[6];
            par[0]=new SqlParameter("@leader_id",ur.Leaderid);
            par[1] = new SqlParameter("@junior_id", ur.Juniorid);
            par[2] = new SqlParameter("@Schoolcode", ur.Schoolcode);
            par[3] = new SqlParameter("@class", ur.Class);
            par[4] = new SqlParameter("@Section", ur.Section);
            par[5] = new SqlParameter("@status", 1);
            par[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "", par);
            status = (int)par[5].Value;


        }
        catch (Exception ex)
        { }
        finally
        {
            con.Close();
        }
        return status;
    }
}
