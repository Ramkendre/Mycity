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
/// Summary description for ProfileSetting1DAL
/// </summary>
public class ProfileSetting1DAL
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();
    int status;
	public ProfileSetting1DAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet DALGetUserFriendRelationById(ProfileSetting1BLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserFriendRelationById", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public DataSet DALGetUserFriendNameRelationById(ProfileSetting1BLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserFriendNameRelationById", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetUserGroup(ProfileSetting1BLL obj)
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

    public DataSet DALGetUserGroupTotal(ProfileSetting1BLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrUserid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserGroupTotal", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public int DALUserGroupNameUpdate(ProfileSetting1BLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter("@userid", obj.Userid);
            par[1] = new SqlParameter("@groupid", obj.Groupid);
            par[2] = new SqlParameter("@groupname", obj.GroupName);
            par[3] = new SqlParameter("@status", 1);
            par[3].Direction = ParameterDirection.Output;
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "UserGroupNameUpdate", par);

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
