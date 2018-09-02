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
/// Summary description for AttributeDAL
/// </summary>
public class AttributeDAL
{
    public AttributeDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int status;
    DataSet ds = new DataSet();

    //Return List of all the attribute
    public DataTable DALGetAllAttribute()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spAttributeSelectAll");

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

    // Add Attribute to the Category
    public int DALInsertAttribute(AttributeBLL at)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@attributeName", at.attributeName);
                par[1] = new SqlParameter("@attributeValue", at.attributeValue);
                par[2] = new SqlParameter("@attributeType", at.attributeType);
                par[3] = new SqlParameter("@categoryId", at.categoryId);
                par[4] = new SqlParameter("@Status", 100);
                par[4].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spAttributeInsert", par);
                status = (int)par[4].Value;
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

    //For Updating Attribute
    public int DALUpdateAttribute(AttributeBLL at)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[6];
                par[0] = new SqlParameter("@attributeId", at.attributeId);
                par[1] = new SqlParameter("@attributeName", at.attributeName);
                par[2] = new SqlParameter("@attributeValue", at.attributeValue);
                par[3] = new SqlParameter("@attributeType", at.attributeType);
                par[4] = new SqlParameter("@categoryId", at.categoryId);
                par[5] = new SqlParameter("@Status", 100);
                par[5].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spAttributeUpdate", par);
                status = (int)par[5].Value;
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


    //Gets Selected category
    public DataTable DALGetSelectedAttribute(AttributeBLL at)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@attributeId", at.attributeId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spAttributeSelectById", par);

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


    //Returns all category List by Item Id
    public DataTable DALGetCategoryWiseAttribute(AttributeBLL at)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@categoryId", at.categoryId);
                par[1] = new SqlParameter("@itemId", at.itemAId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spItemCategoryAttributeSelect", par);

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

    public DataTable DALShowAttributeByCategoryId(AttributeBLL at)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@categoryId", at.categoryId);


                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spAttributeSelectByCategoryId", par);

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
