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
public class CityDAL
{
    DistrictDAL districtDALObj = new DistrictDAL();
    public CityDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DataSet ds = new DataSet();
    int status;


    public DataTable DALShowAllCity()
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCitySelect");


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


    public bool DALIsExistCityName(CityBLL ct)
    {

        bool flag = false;
        string row = "";

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@cityName", ct.cityName);
                par[1] = new SqlParameter("@Status", 100);
                par[1].Direction = ParameterDirection.Output;
                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "spCityNameIsExist", par));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            if (row != "")
            {
                flag = true;

            }
            return flag;
        }
    }


    public int DALInsertCity(CityBLL ct)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@cityName", ct.cityName);
                par[1] = new SqlParameter("@distId", ct.distId);
                par[2] = new SqlParameter("@stateId", ct.stateId);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spCityInsert", par);
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


    public bool DALIsExistCity(CityBLL ct)
    {


        string row = "";
        bool flag = false;


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@cityId", ct.cityId);
                par[1] = new SqlParameter("@cityName", ct.cityName);
                par[2] = new SqlParameter("@distId", ct.distId);
                par[3] = new SqlParameter("@stateId", ct.stateId);
                par[4] = new SqlParameter("@Status", 11);
                par[4].Direction = ParameterDirection.Output;

                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "spCityIsExist", par));

            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            if (row != "")
            {
                flag = true;
            }
            return flag;
        }
    }

    public int DALUpdateCity(CityBLL ct)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@cityId", ct.cityId);
                par[1] = new SqlParameter("@cityName", ct.cityName);
                par[2] = new SqlParameter("@distId", ct.distId);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spCityUpdate", par);
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


    public DataTable DALCitySelectedById(CityBLL ct)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@cityId", ct.cityId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCitySelectedById", par);

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




    //public int delete(CityBLL ct)
    //{
    //    conn.Open();
    //    int row;
    //    try
    //    {
    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //        {
    //            SqlParameter[] par = new SqlParameter[2];
    //            par[0] = new SqlParameter("@Id", ct.CityID);
    //            par[1] = new SqlParameter("@Status", 11);
    //            par[1].Direction = ParameterDirection.Output;
    //            row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "deleteCity", par);
    //        }
    //        return row;
    //    }
    //    catch (SqlException ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }

    //}


    public DataTable DALCitySelectedByDId(CityBLL ct, int i)
    {
        List<CityBLL> ctList = new List<CityBLL>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@distId", i);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCitySelectedByDistId", par);

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

    public DataTable DALCitySelectedSearch(CityBLL ct)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@cityName", ct.cityName);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCitySelectSearch", par);

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
