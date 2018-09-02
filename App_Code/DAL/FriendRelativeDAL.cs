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
/// Summary description for FriendRelativeDAL
/// </summary>
public class FriendRelativeDAL
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings[""]);
    DataSet ds = new DataSet();
    int status;

	public FriendRelativeDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet DALGetUserFrndIdName(FriendRelativeBLL  obj)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserFrndIdName", par);

        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetUserAutoId(FriendRelativeBLL obj)
    {
       
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserAutoId", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetUserGroup(FriendRelativeBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserGroupName", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public DataSet DALspUserRegistrationMobileSelectById(FriendRelativeBLL obj)
    {
        try{
        SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "spUserRegistrationMobileSelectById", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetfrndinfo(FriendRelativeBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            par[1] = new SqlParameter("@usrFname",obj.Usrfname);
            par[2] = new SqlParameter("@usrLname", obj.Usrlname);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "Getfrndinfo", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALUserImageId(FriendRelativeBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrAutoId", obj.UsrAutoId);
      
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserImageId", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetUsrBasicInfobyMobile(FriendRelativeBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrMobileNo", obj.UsrMobile);

            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUsrBasicInfobyMobile", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public int DALUpdateFrndGroup(FriendRelativeBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@groupid", obj.Groupid);
            par[1] = new SqlParameter("@userid", obj.Userid);
            par[2] = new SqlParameter("@friendid", obj.Friendid);
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "UpdateFrndGroup", par);
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
