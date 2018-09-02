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
/// Summary description for CountryDAL
/// </summary>
public class CountryDAL
{
    public CountryDAL()
    {

    }
    int status;
    DataSet ds = new DataSet();

    //For Adding New Country
    public int DALCountryInsert(CountryBLL cn)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@countryName", cn.countryName);
                par[1] = new SqlParameter("@status", 100);
                par[1].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spCountryInsert", par);
                status = (int)par[1].Value;
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

    public DataTable DALCountrySelectAll()
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCountrySelect");

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



    public DataTable DALCountrySelectedById(CountryBLL ct)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@countryId", ct.countryId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCountrySelectedById", par);

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




    public int DALCountryUpdate(CountryBLL ct)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@countryId", ct.countryId);
                par[1] = new SqlParameter("@countryName", ct.countryName);
                par[2] = new SqlParameter("@status", 11);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spCountryUpdate", par);

                status = (int)par[2].Value;

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
