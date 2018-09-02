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
/// Summary description for ItemDAL
/// </summary>
public class ItemDAL
{
    public ItemDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    int status1;
    DataSet ds = new DataSet();

    public int DALInsertItem(ItemBLL it)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[8];

                par[0] = new SqlParameter("@itemId", it.itemId);
                par[1] = new SqlParameter("@itemName", it.itemName);
                par[2] = new SqlParameter("@itemDescription", it.itemDescription);
                par[3] = new SqlParameter("@itemImage", it.itemImage);
                par[4] = new SqlParameter("@cityId", it.cityId);
                par[5] = new SqlParameter("@Active", it.itemActive);
                par[6] = new SqlParameter("@Status", 100);
                par[6].Direction = ParameterDirection.Output;

                SqlParameter[] para = new SqlParameter[3];
                para[0] = new SqlParameter("@CSV", it.categoryId);
                para[1] = new SqlParameter("@itemId", it.itemId);
                para[2] = new SqlParameter("@status", 11);


                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemInsert", par);
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemAttributeValueInsert", para);

                status = (int)par[6].Value;
                status = (int)para[2].Value;


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

    //For Updating category
    public int DALUpdateItem(ItemBLL it)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[7];
                par[0] = new SqlParameter("@itemId", it.itemId);
                par[1] = new SqlParameter("@itemName", it.itemName);
                par[2] = new SqlParameter("@itemDescription", it.itemDescription);
                par[3] = new SqlParameter("@itemImage", it.itemImage);
                par[4] = new SqlParameter("@active", it.itemActive);
                par[5] = new SqlParameter("@cityId", it.cityId);
                par[6] = new SqlParameter("@Status", 100);
                par[6].Direction = ParameterDirection.Output;


                SqlParameter[] para = new SqlParameter[3];
                para[0] = new SqlParameter("@CSV", it.categoryId);
                para[1] = new SqlParameter("@itemId", it.itemId);
                para[2] = new SqlParameter("@status", 11);


                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemUpdate", par);
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemAttributeValueInsert", para);
                status = (int)par[6].Value;
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


    //Returns all Item List
    public DataTable DALGetAllItem()
    {


        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spItemSelectAll");

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


    //Gets Selected category
    public DataTable DALGetSelectedItem(ItemBLL it)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@itemId", it.itemId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spItemSelectById", par);

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


}
