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
/// Summary description for LongcodeDAL
/// </summary>
public class LongcodeDAL
{
    CommonCode cc = new CommonCode();
    int status;
    DataSet ds = new DataSet();
    public LongcodeDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet DALLongcodeReport(LongCodeBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uvaLongCodeReport");

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
        return ds;

    }
    public DataSet DALDARLongcodeReport(LongCodeBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DARLongCodeReport");

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
        return ds;

    }

    public DataSet DALLongCodeReportAll(LongCodeBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uvaLongCodeReportAll");

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
        return ds;
    }
    public DataSet DALNSSLongcodeReport(LongCodeBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "NSSPuneLongCodeReport");

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
        return ds;

    }

    public DataSet DALNSSLongCodeReportAll(LongCodeBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "NSSPuneLongCodeReportAll");

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
        return ds;
    }
    public DataSet DALSMSReport(LongCodeBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                string sql = "select sendSMSstatus.ID,SendFrom,SendTo,sentMessage,sendDateTime,ProjectName,smslength from sendSMSstatus inner join sendercode on sendSMSstatus.sendercode =sendercode.id WHERE sendSMSstatus.SendTo='" + obj.Mobileno + "' and Convert(Date,EntryDate,103) BETWEEN '" + obj.Frmdate + "' AND  '" + obj.Todate + "' order by ID desc";
                ds = cc.ExecuteDataset(sql);

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
        return ds;
    }

    public DataSet DALSMSReportByMobile(LongCodeBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                string sql = "select sendSMSstatus.ID,SendFrom,SendTo,sentMessage,sendDateTime,ProjectName,smslength from sendSMSstatus inner join sendercode on sendSMSstatus.sendercode =sendercode.id WHERE SendTo='"+obj.Mobileno+"' and Convert(Date,sendDateTime,103) BETWEEN '" + obj.Frmdate + "' AND  '" + obj.Todate + "' order by ID desc";
                ds = cc.ExecuteDataset(sql);

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
        return ds;
    }

    public string DALSMSReportCount(LongCodeBLL obj)
    {
        string count;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                //string sql = "select top(500)sendSMSstatus.ID,SendFrom,SendTo,sentMessage,sendDateTime,ProjectName,smslength from sendSMSstatus inner join sendercode on sendSMSstatus.sendercode =sendercode.id order by sendSMSstatus.ID desc";

                string sql = "select Count(*)from sendSMSstatus WHERE Convert(Date,sendDateTime,103) BETWEEN '" + obj.Frmdate + "' AND  '" + obj.Todate + "'";
                count = cc.ExecuteScalar(sql);
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
        return count;
    }


    public DataSet DALSMSCode(LongCodeBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                // ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SendSMSReport");
                string sql = "select * from sendercode";
                ds = cc.ExecuteDataset(sql);

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
        return ds;
    }

    public DataSet DALgetsmsbyid(LongCodeBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                //string sql = "select top(500)sendSMSstatus.ID,SendFrom,SendTo,sentMessage,sendDateTime,ProjectName,smslength from sendSMSstatus inner join sendercode on sendSMSstatus.sendercode =sendercode.id where sendercode='"+obj.Sendercode+"' order by sendSMSstatus.ID desc ";
                string sql = "select sendSMSstatus.ID,SendFrom,SendTo,sentMessage,sendDateTime,ProjectName,smslength from sendSMSstatus inner join sendercode on sendSMSstatus.sendercode =sendercode.id WHERE Convert(Date,sendDateTime,103) BETWEEN '" + obj.Frmdate + "' AND  '" + obj.Todate + "' and sendercode='" + obj.Sendercode + "' order by ID desc";

                ds = cc.ExecuteDataset(sql);

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
        return ds;

    }
    public string DALgetsmsbyidCount(LongCodeBLL obj)
    {
        string count;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                //string sql = "select top(500)sendSMSstatus.ID,SendFrom,SendTo,sentMessage,sendDateTime,ProjectName,smslength from sendSMSstatus inner join sendercode on sendSMSstatus.sendercode =sendercode.id where sendercode='"+obj.Sendercode+"' order by sendSMSstatus.ID desc ";
                string sql = "select Count(*) from sendSMSstatus WHERE Convert(Date,sendDateTime,103) BETWEEN '" + obj.Frmdate + "' AND  '" + obj.Todate + "' and sendercode='" + obj.Sendercode + "'";

                count = cc.ExecuteScalar(sql);
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
        return count;

    }


    public DataSet DALgetlongcoderecord(LongCodeBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetLongCodeRecord");

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
        return ds;

    }

}
