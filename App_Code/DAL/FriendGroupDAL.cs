using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using Microsoft.ApplicationBlocks.Data;



/// <summary>
/// Summary description for FriendGroupDAL
/// </summary>
public class FriendGroupDAL
{

    public FriendGroupDAL()
    {

    }
    int status;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();

    //For Adding New Country
    //public int DALFriendGroupInsert(FriendGroupBLL fg)
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
           
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[2];
    //            par[0] = new SqlParameter("@friendGroupName",fg.friendGroupName);
    //            par[1] = new SqlParameter("@status", 100);
    //            par[1].Direction = ParameterDirection.Output;

    //            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spFriendGroupInsert", par);
    //            status = (int)par[1].Value;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }            
    //    }
    //    return status;
    //}

    //public DataTable DALSelectAllFriendGroup(UserRegistrationBLL ur)
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[1];
    //            par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GroupSelectbyuser");

    //        }

    //        catch (SqlException ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    return ds.Tables[0];
    //}



    //public DataTable DALFriendGroupSelectedById(FriendGroupBLL fg)
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
              
    //            SqlParameter[] par = new SqlParameter[2];
    //            par[0] = new SqlParameter("@friendGroupId", fg.friendGroupId);

    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure,"spFriendGroupSelectedById", par);
                   
    //        }
    //        catch (SqlException ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    return ds.Tables[0];
    //}


    //public DataTable DALFriendGroupNameSelectedById(FriendGroupBLL fg)
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {

    //            SqlParameter[] par = new SqlParameter[2];
    //            par[0] = new SqlParameter("@friendGroupName", fg.friendGroupName);

    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spFriendGroupNameSelectedById", par);

    //        }
    //        catch (SqlException ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    return ds.Tables[0];
    //}



    //public int DALFriendGroupUpdate(FriendGroupBLL fg)
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {
            
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[3];
    //            par[0] = new SqlParameter("@friendGroupId", fg.friendGroupId);
    //            par[1] = new SqlParameter("@friendGroupName", fg.friendGroupName);
    //            par[2] = new SqlParameter("@status", 11);
    //            par[2].Direction = ParameterDirection.Output;

    //            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure,"spFriendGroupUpdate", par);
                
    //            status = (int)par[2].Value;

    //        }
    //        catch (SqlException ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    return status;
    //}

    public DataTable DALShowFriendGroupForUser(UserRegistrationBLL ur)
    {

        //Monali
        ArrayList a = new ArrayList();
        string[] arr;
        ArrayList groupNm = new ArrayList();
        string MyValue = "";

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {


                // Monali
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@userId", ur.usrUserId);


                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserFriendGroupSelect", par);
                DataTable dt = ds.Tables[0];
                
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
        return ds.Tables[0];



    }


    public DataTable DALShowFriendInGroup(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@groupId", ur.frnrelGroup);
                par[1] = new SqlParameter("@userId", ur.usrUserId);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserFriendInGroupShow", par);
                ds.Tables[0].Columns.Add("rowNumber");
                int i=0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    i++;
                    dr["rowNumber"] = i.ToString();
                }
                ds.AcceptChanges();

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
        return ds.Tables[0];
    }

}

