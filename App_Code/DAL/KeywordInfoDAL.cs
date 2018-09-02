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
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for KeywordInfoDAL
/// </summary>
public class KeywordInfoDAL
{
    int row;
    public KeywordInfoDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

    public int AddKeywordInfo(KeywordInfoBLL KBLL)
    {
        try
        {
            Conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[15];
                par[0] = new SqlParameter("@KeywordName", KBLL.KeywordName1);
                par[1] = new SqlParameter("@KeywordSyntax", KBLL.KeywordSyntax1);
                par[2] = new SqlParameter("@KeywordPurpose", KBLL.KeywordPurpose1);
                par[3] = new SqlParameter("@KeyDiscip", KBLL.KeyDiscip1);
                par[4] = new SqlParameter("@EntryDate", KBLL.EntryDate1);
                par[5] = new SqlParameter("@WebsiteGroup", KBLL.WebsiteGroup1);
                par[6] = new SqlParameter("@status", 11);
                par[6].Direction = ParameterDirection.Output;
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "KeyInfoInsert", par);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Conn.Close();
        }
        return row;
    }
    public int UpdateKeywordInfo(KeywordInfoBLL KBLL)
    {
        try
        {
            Conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[15];
                par[0] = new SqlParameter("@KeyId", KBLL.KeyId1);
                par[1] = new SqlParameter("@KeywordName", KBLL.KeywordName1);
                par[2] = new SqlParameter("@KeywordSyntax", KBLL.KeywordSyntax1);
                par[3] = new SqlParameter("@KeywordPurpose", KBLL.KeywordPurpose1);
                par[4] = new SqlParameter("@KeyDiscip", KBLL.KeyDiscip1);
                par[5] = new SqlParameter("@EntryDate", KBLL.EntryDate1);
                par[6] = new SqlParameter("@WebsiteGroup", KBLL.WebsiteGroup1);
                par[7] = new SqlParameter("@status", 11);
                par[7].Direction = ParameterDirection.Output;
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "KeyInfoUpdate", par);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Conn.Close();
        }
        return row;
    }
    public DataSet LoadKeywordInfo(KeywordInfoBLL KBLL)
    {
        DataSet ds = new DataSet();
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                con.Open();
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KeyInfoLoad");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
        return ds;
    }
    public void SelectKeywordInfo(KeywordInfoBLL KBLL)
    {
        SqlDataReader dr;
        try
        {
            Conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[15];
                par[0] = new SqlParameter("@KeyId", KBLL.KeyId1);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "KeyInfoSelectData", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    KBLL.KeywordName1 = Convert.ToString(dr["KeywordName"]);
                    KBLL.KeywordSyntax1 = Convert.ToString(dr["KeywordSyntax"]);
                    KBLL.KeywordPurpose1 = Convert.ToString(dr["KeywordPurpose"]);
                    KBLL.KeyDiscip1 = Convert.ToString(dr["KeyDiscip"]);
                    KBLL.EntryDate1 = Convert.ToString(dr["EntryDate"]);
                    KBLL.WebsiteGroup1 = Convert.ToString(dr["WebsiteGroup"]);
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Conn.Close();
        }
    }
}
