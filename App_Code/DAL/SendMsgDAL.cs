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
/// Summary description for SendMsgDAL
/// </summary>
public class SendMsgDAL
{
    int status;
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();

	public SendMsgDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int DALInsertLongCodeData(SendMsgBLL obj)
    {
        try
        {
            SqlParameter [] par=new  SqlParameter[7];
            par[0]=new SqlParameter("@Message",obj.Message);
            par[1]=new SqlParameter("@mobile",obj.mobile);
            par[2]=new SqlParameter("@shortcode",obj.Shortcode);
            par[3]=new SqlParameter("@data",obj.Data);
            par[4]=new SqlParameter("@SendDate",obj.SendDate);
            par[5] = new SqlParameter("@smsStatus", obj.SmsStatus);
            par[6] = new SqlParameter("@status", 1);
            par[6].Direction = ParameterDirection.Output;
           SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "InsertLongCodeData", par);
           status = (int)par[6].Value;
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();

        }
        return status;
    }

    public int DALGetLongCodeId(SendMsgBLL obj)
    {
        try
        {
            string id = SqlHelper.ExecuteScalar(cn, CommandType.StoredProcedure, "GetLongCodeId").ToString();
            status = Convert.ToInt32(id);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return status;
    }


    public DataSet DALGetUseridbyMobile(SendMsgBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@usrMobileNo", obj.mobile);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUseridbyMobile", par);



        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public int DALUserIdExist(SendMsgBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[7];
            par[0] = new SqlParameter("@friendid", obj.Userid);
             par[6] = new SqlParameter("@status", 1);
            par[6].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "GetUserIdExist", par);
            status = (int)par[6].Value;
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();

        }
        return status;
    }

    

    public DataSet DALGetUserFname(SendMsgBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@usrMobileNo", obj.mobile);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserFname", par);

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
