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
/// Summary description for CityDAL
/// </summary>
public class UserDAL
{
    CommonCode cc = new CommonCode();

    public UserDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DataSet ds = new DataSet();
    int status;




    public DataSet DALShowUserDetails(UserBLL user)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@LoginId", user.LoginId);

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserDetailsSelect", par);
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

    public int UpdateOwnDetails(UserBLL user)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[6];
                par[0] = new SqlParameter("@LoginId", user.LoginId);
                par[1] = new SqlParameter("@UserName", user.UserName);
                par[2] = new SqlParameter("@Password", user.Password);
                par[3] = new SqlParameter("@ContactNo", user.ContactNo);
                par[4] = new SqlParameter("@Address", user.Address);
                par[5] = new SqlParameter("@Status", 0);

                par[5].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUserUpdateOWN", par);
                status = (int)par[5].Value;
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




    public int insertUser1(UserBLL user)
    {
        int Status;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[]
                {
                  new SqlParameter("@cityName", user.CityName),
                   new SqlParameter("@userRole", user.RoleName1),
                     new SqlParameter("@userMono", user.MONO),
                    new SqlParameter("@dob", user.Date),
                    new SqlParameter("@RoleId", user.RoleId1),
                     new SqlParameter("@uid", user.Id),
                   new SqlParameter("@District", user.District),
                    //par[7] = new SqlParameter("Status", 122);

                    //par[7].Direction = ParameterDirection.Output;
                };
                //string i = "select isnull(max(MID),0)+1 from come2mycity.MartketingSubuser";
                //DataSet ds = cc.ExecuteDataset(i);
                //string mid = ds.Tables[0].Rows[0][0].ToString();
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MkUserInsert", par);
                //string s = " insert into come2mycity.MartketingSubuser(MID,city,UseRole,MUMono,Doj,RoeId,Uid1,District)values('" + mid + "','" + user.CityName + "','" + user.RoleName1 + "','" + user.MONO + "','" + user.Date + "','" + user.RoleId1 + "','" + user.Id + "','" + user.District + "' )";
                 Status =1;
                //status = (int)par[7].Value;
                
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
        return Status;

    }
    public int updateUser1(UserBLL user)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try	
            {
                SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@id", user.MID),
                new SqlParameter("@cityName", user.CityName),
                new SqlParameter("@userRole", user.RoleName1),
                new SqlParameter("@userMono", user.MONO),
                new SqlParameter("@dob", user.Date),
                new SqlParameter("@RoleId", user.RoleId1),
                new SqlParameter("@District", user.District),
                 new SqlParameter("@uid", user.Id),

                //par[8] = new SqlParameter("Status", 122),

                //par[8].Direction = ParameterDirection.Output,
            };
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MkUserInsertUpdate", par);
                //status = (int)par[8].Value;
                status = 1;
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

    public int insertUserCommitee(UserBLL user)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@userid", user.Id);
                par[1] = new SqlParameter("@roleid", user.RoleId1);
                par[2] = new SqlParameter("@commitee_id", user.Committeeid);

                par[3] = new SqlParameter("Status", 5);

                par[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "InsertCommiteeRole", par);
                status = (int)par[3].Value;



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

    public int UpdateUserCommitee(UserBLL user)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@userid", user.Id);
                par[1] = new SqlParameter("@roleid", user.RoleId1);
                par[2] = new SqlParameter("@commitee_id", user.Committeeid);

                par[3] = new SqlParameter("@status", 5);

                par[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "InsertCommiteeRoleUpdate", par);
                status = (int)par[3].Value;


                //string insertquery = "update committeeRole set commitee_id='"+user.Committeeid+"' where userid='"+user.Id+"'";
                //a = cc.ExecuteScalar1(insertquery);
                // status = cc.ExecuteScalar1(insertquery);
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

    public int DALGetUserId(UserBLL user)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@userid", user.Id);
                par[1] = new SqlParameter("@status", 3);

                par[1].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserExistInCommitee", par);
                status = (int)par[1].Value;


                //string insertquery = "update committeeRole set commitee_id='"+user.Committeeid+"' where userid='"+user.Id+"'";
                //a = cc.ExecuteScalar1(insertquery);
                // status = cc.ExecuteScalar1(insertquery);
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