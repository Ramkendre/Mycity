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
/// Summary description for UserInfoDAL
/// </summary>
public class UserInfoDAL
{

    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();
    int status;
	public UserInfoDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet DALGetUserAutoId(UserInfoBLL obj)
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

    public DataSet DALGetUserImageId(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrAutoId", obj.UsrAutoid);
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

    public DataSet DALGetReligion(UserInfoBLL obj)
    {
        try
        {
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetReligion");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public DataSet DALGetCategory(UserInfoBLL obj)
    {
        try
        {
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetCategory");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public int DALUserImageInsert(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@image", obj.Image);
            par[1] = new SqlParameter("usrAutoId", obj.UsrAutoid);
            par[2] = new SqlParameter("@Status", 1);
            par[2].Direction = ParameterDirection.Output;
            status  = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "GetUserImageId", par);
            status = (int)par[2].Value;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();
        }
        return status;
    }
    public int DALUserImageUpdate(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@image", obj.Image);
            par[1] = new SqlParameter("usrAutoId", obj.UsrAutoid);
            par[2] = new SqlParameter("@Status", 1);
            par[2].Direction = ParameterDirection.Output;
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "", par);
            status = (int)par[2].Value;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();
        }
        return status;
    }
    public DataSet DALGetGroupRecord(UserInfoBLL obj)
    {
        try
        {
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetGroupRecord");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetUserGroup(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@userid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserGroup",par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public int DALUserGroupDelete(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userid", obj.Userid);
            par[1] = new SqlParameter("@GroupItemId", obj.Groupitemid);
            par[2] = new SqlParameter("@Status", 1);
            par[2].Direction = ParameterDirection.Output;
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "UserGroupDelete", par);
            status = (int)par[2].Value;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();
        }
        return status;
    }
    public int DALUserGroupInsert(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userid", obj.Userid);
            par[1] = new SqlParameter("@groupid", obj.Groupid);
            par[1] = new SqlParameter("@Status", 1);
            par[1].Direction = ParameterDirection.Output;
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "UserGroupInsert", par);
            status = (int)par[1].Value;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();
        }
        return status;
    }

    public DataSet DALGetUserConsumerNo(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@consumerno", obj.ConsumerNo);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetUserConsumer", par);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public int DALUserConsumerDelete(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userid", obj.Userid);
            par[1] = new SqlParameter("@Status", 1);
            par[1].Direction = ParameterDirection.Output;
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "UserConsumerDelete", par);
            status = (int)par[16].Value;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();
        }
        return status;
    }

    public int DALUserConsumerInsert(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@userid", obj.Userid);
            par[1] = new SqlParameter("@ConsumerNo", obj.ConsumerNo);
            par[1] = new SqlParameter("@Status", 1);
            par[1].Direction = ParameterDirection.Output;
            status = SqlHelper.ExecuteNonQuery(cn, CommandType.StoredProcedure, "UserConsumerInsert", par);
            status = (int)par[16].Value;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            cn.Close();
        }
        return status;
    }

    public DataSet DALGetSchoolRecord(UserInfoBLL obj)
    {
        try
        {

            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetSchoolRecord");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetClassRecord(UserInfoBLL obj)
    {
        try
        {

            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetClassRecord");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetSchoolbyId(UserInfoBLL obj)
    {
        try
        {

            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetSchoolbyId");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }
    public DataSet DALGetClassbyId(UserInfoBLL obj)
    {
        try
        {

            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetClasslbyId");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    public DataSet DALGetFamilyInfobyId(UserInfoBLL obj)
    {
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@userid", obj.Userid);
            ds = SqlHelper.ExecuteDataset(cn, CommandType.StoredProcedure, "GetFamilyInfobyId", par);
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
