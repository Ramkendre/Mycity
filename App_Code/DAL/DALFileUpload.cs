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
/// Summary description for DALFileUpload
/// </summary>
public class DALFileUpload
{
    int status;
    CommonCode cc = new CommonCode();
    public DALFileUpload()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int DALinsertFileUpload(BLLFileUpload bllfile)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql1 = "insert into committeedetail(Committee_name,Committee_url,FileName,roleid,userid)values('" + bllfile.Commiteename + "','" + bllfile.Commiteeurl + "','" + bllfile.Filename + "','" + bllfile.Roleid + "','" + bllfile.Userid + "')";
                status = cc.ExecuteScalar1(sql1);
            }
            catch (Exception ex)
            {
            }
        }
        return status;
    }

    public int insertUserCommiteeUpdated(BLLFileUpload bllfile)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@Committee_name", bllfile.Commiteename);
                par[1] = new SqlParameter("@Committee_url", bllfile.Commiteeurl);
                par[2] = new SqlParameter("@FileName", bllfile.Filename);
                par[3] = new SqlParameter("@roleid", bllfile.Roleid);
                par[4] = new SqlParameter("Status", 6);

                par[4].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "InsertCommiteeRoleUpdate", par);
                status = (int)par[4].Value;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return status;

    }

}
