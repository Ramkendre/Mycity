using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for PublishAdvertiseDAL
/// </summary>
public class PublishAdvertiseDAL
{
    public PublishAdvertiseDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DataSet ds = new DataSet();
    int status;

    public DataTable DALAdvertiseTypeSelect()
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spAdvertiseTypeSelect");

            }
            catch (Exception ex)
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

    public int DALPublishAdvertiseInsert(PublishAvertiseBLL pub)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[15];

                par[0] = new SqlParameter("@AdvId", pub.AdvId);
                par[1] = new SqlParameter("@State", pub.State);
                par[2] = new SqlParameter("@City", pub.City);
                par[3] = new SqlParameter("@Category", pub.Category);
                par[4] = new SqlParameter("@Location", pub.LocationName);
                par[5] = new SqlParameter("@ValidFrom", pub.ValidFrom);
                par[6] = new SqlParameter("@ValidTo", pub.ValidTo);
                par[7] = new SqlParameter("@Active", pub.Active);
                par[8] = new SqlParameter("@AgentName", pub.AgentName);
                par[9] = new SqlParameter("@ModifierName", pub.ModifierDate);
                par[10] = new SqlParameter("@Status", 100);
                par[10].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spPublishAdvertiseInsert", par);

                status = (int)par[10].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return status;
        }
    }

    public DataTable DALAdvertiseLocationSelect()
    {
        List<PublishAvertiseBLL> pubList = new List<PublishAvertiseBLL>();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spLocationSelectAll");
            }
            catch (Exception ex)
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

    public bool DALCheckIsExistAtLocation(PublishAvertiseBLL pub)
    {
        bool Available = true;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[10];
                par[0] = new SqlParameter("@State", pub.State);
                par[1] = new SqlParameter("@City", pub.City);
                par[2] = new SqlParameter("@Category", pub.Category);
                par[3] = new SqlParameter("@Location", pub.LocationName);
                par[4] = new SqlParameter("@ValidFrom", pub.ValidFrom);
                par[5] = new SqlParameter("@ValidTo", pub.ValidTo);
                par[6] = new SqlParameter("@Status", 100);
                par[6].Direction = ParameterDirection.Output;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spAdvertiseIsExists", par))
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            Available = false;
                        }
                    }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        return Available;
    }

}
