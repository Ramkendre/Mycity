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
/// Summary description for CityInformationDAL
/// </summary>
public class CityInformationDAL
{
    DataSet ds = new DataSet();
    int status;
    public CityInformationDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable DALCityInformationSelectedById(int cityId)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@cityId", cityId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "getCityInfoById", par);

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


    public int DALUpdateCityInformation(CityInformationBLL cti)
    {
        int row;



        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[25];
                par[0] = new SqlParameter("@cityRId", cti.cityRefId);
                par[1] = new SqlParameter("@cityName", cti.cityName);
                par[2] = new SqlParameter("@cityAbout", cti.cityAbout);
                par[3] = new SqlParameter("@cityArea", cti.cityArea);
                par[4] = new SqlParameter("@cityLongtitude", cti.cityLongtitude);
                par[5] = new SqlParameter("@cityLatitude", cti.cityLatitude);
                par[6] = new SqlParameter("@cityHeightFromSea", cti.cityHeightFromSea);
                par[7] = new SqlParameter("@cityLanguage", cti.cityLanguage);
                par[8] = new SqlParameter("@cityLiteracy", cti.cityLiteracy);
                par[9] = new SqlParameter("@cityPopulation", cti.cityPopulation);
                par[10] = new SqlParameter("@cityHistoricalImp", cti.cityHistoricalImp);
                par[11] = new SqlParameter("@cityGeographicalImp", cti.cityGeographicalImp);
                par[12] = new SqlParameter("@citySocialImp", cti.citySocialImp);
                par[13] = new SqlParameter("@cityRegionalImp", cti.cityRegionalImp);
                par[14] = new SqlParameter("@cityPoliticalImp", cti.cityPoliticalImp);
                par[15] = new SqlParameter("@cityByRailApro", cti.cityByRailApro);
                par[16] = new SqlParameter("@cityByAirApro", cti.cityByAirApro);
                par[17] = new SqlParameter("@cityByBusApro", cti.cityByBusApro);
                par[18] = new SqlParameter("@Status", 11);
                par[18].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UpdateCityInfo", par);
                status = (int)par[18].Value;

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
