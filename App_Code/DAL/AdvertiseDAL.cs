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
/// Summary description for PublishAdvertiseBLL
/// </summary>
public class AdvertiseDAL
{
    public AdvertiseDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DataSet ds = new DataSet();
    int status;

    public int DALAdvertiseInsert(AdvertiseBLL ad)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[10];

                par[0] = new SqlParameter("@Name", ad.Name);
                par[1] = new SqlParameter("@ImageURL", ad.ImageURL);
                par[2] = new SqlParameter("@ValidFrom", ad.ValidFrom);
                par[3] = new SqlParameter("@ValidTo", ad.ValidTo);
                par[4] = new SqlParameter("@Active", ad.Active);
                par[5] = new SqlParameter("@AgentName", ad.AgentName);
                par[6] = new SqlParameter("@ModifierName", ad.ModifierName);
                par[7] = new SqlParameter("@AdvId", ad.AdvId);
                par[8] = new SqlParameter("Type", ad.Type);
                par[9] = new SqlParameter("@Status", 100);
                par[9].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spAdvertiseInsert", par);
                status = (int)par[9].Value;
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
        return status;
    }

    public DataTable DALAdvertiseShowAll()
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spAdvertiseSelectAll");

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

    public List<AdvertiseBLL> GetAdvertiseInfo(AdvertiseBLL adv)
    {
        SqlDataReader dr;
        List<AdvertiseBLL> advlist = new List<AdvertiseBLL>();


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@AdvId", adv.AdvId);
                par[1] = new SqlParameter("@Status", 1);
                par[1].Direction = ParameterDirection.Output;
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spSelectAddById", par);

                while (dr.Read())
                {
                    AdvertiseBLL ad = new AdvertiseBLL();
                    ad.AdvId = Convert.ToString(dr["AdvId"]);
                    ad.Name = Convert.ToString(dr["Name"]);
                    ad.ImageURL = Convert.ToString(dr["ImageURL"]);
                    ad.ValidFrom = Convert.ToDateTime(dr["ValidFrom"]).ToString();
                    ad.ValidTo = Convert.ToString(dr["ValidTo"]);
                    ad.Active = Convert.ToString(dr["Active"]);
                    ad.maxId = Convert.ToInt32(dr["maxId"].ToString());
                    advlist.Add(ad);
                }


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
        return advlist;
    }


    public int DALAdvertiseUpdate(AdvertiseBLL ad)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[9];

                par[0] = new SqlParameter("@Name", ad.Name);
                par[1] = new SqlParameter("@ImageURL", ad.ImageURL);
                par[2] = new SqlParameter("@ValidFrom", ad.ValidFrom);
                par[3] = new SqlParameter("@ValidTo", ad.ValidTo);
                par[4] = new SqlParameter("@Active", ad.Active);
                par[5] = new SqlParameter("@AgentName", ad.AgentName);
                par[6] = new SqlParameter("@ModifierName", ad.ModifierName);
                par[7] = new SqlParameter("@AdvId", ad.AdvId);
                par[8] = new SqlParameter("@Status", 1);
                par[8].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spAdvertiseUpdate", par);
                status = (int)par[8].Value;
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



}
