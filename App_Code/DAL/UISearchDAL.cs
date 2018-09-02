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
/// Summary description for UISearchDAL
/// </summary>
public class UISearchDAL
{
    public UISearchDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DataSet ds = new DataSet();

    public DataTable DALCitySelectedById(UISearchBLL ct)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@cityId", ct.cityId);
                par[1] = new SqlParameter("@categoryId", ct.categoryId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spSearchItemSelectByCId", par);

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


    public DataTable DALItemDescriptionDisplay(UISearchBLL ct)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@itemId", ct.itemId);
                par[1] = new SqlParameter("@categoryId", ct.categoryId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spItemDescriptionSelect", par);


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



    public DataTable DALCategorySelectedByCity(UISearchBLL ui)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@cityId", ui.cityId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spSearchCategorySelectByCId", par);

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


    public DataTable DALItemSelectedByCategory(UISearchBLL usb)
    {

        List<UISearchBLL> usbList = new List<UISearchBLL>();


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@actegoryId", usb.categoryId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spSearchItemSelectByCategoryId", par);

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


    public DataTable DALItemDescriptionImageDisplay(UISearchBLL ub)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@itemId", ub.itemId);
                par[1] = new SqlParameter("@categoryId", ub.categoryId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spItemCategoryImageSelect", par);
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
