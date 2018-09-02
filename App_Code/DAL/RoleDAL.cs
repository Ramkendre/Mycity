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
public class RoleDAL
{

    public RoleDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DataSet ds = new DataSet();
    int status;




    public DataSet DALGetAllRole()
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
               
            {
                string Sql = "select b.roleid as id,b.rolename as name,b.RoleDescription as RoleDescription,a.rolename as UnderRole from [Come2myCityDB].[come2mycity].submenuPermission a,[Come2myCityDB].[come2mycity].submenuPermission b where a.Roleid =b.UnderRole order by  id  "; 

                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSelectUserDetails", par);
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text,Sql);
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