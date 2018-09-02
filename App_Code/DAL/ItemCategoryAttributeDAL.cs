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
/// Summary description for ItemCategoryAttributeDAL
/// </summary>
public class ItemCategoryAttributeDAL
{
    public ItemCategoryAttributeDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int DALInsertItemCategoryAttribute(ItemCategoryAttributeBLL ica)
    {
        int row;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@itemId", ica.itemIdICA);
                par[1] = new SqlParameter("@categoryId", ica.categoryIdICA);
                par[2] = new SqlParameter("@attributeId", ica.attributeIdICA);
                par[3] = new SqlParameter("@attributeValue", ica.attributeValueICA);
                par[4] = new SqlParameter("@Status", 11);
                par[4].Direction = ParameterDirection.Output;

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryAttributeInsert", par);
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
        return row;
    }


    public string DALIsExistItemCategoryAttribute(ItemCategoryAttributeBLL ica)
    {
        bool flag = false;
        string attValue = "";

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@itemId", ica.itemIdICA);
                par[1] = new SqlParameter("@categoryId", ica.categoryIdICA);
                par[2] = new SqlParameter("@attributeId", ica.attributeIdICA);
                //par[3] = new SqlParameter("@status", 100);
                //par[3].Direction = ParameterDirection.Output;

                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spItemCategoryAttributeIsExist", par))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            attValue = Convert.ToString(dr["attributeValue"]);
                        }
                    }
                }


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
        return attValue;
    }


    public int DALUpdateItemCategoryAttribute(ItemCategoryAttributeBLL ica)
    {
        int row;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[6];
                par[0] = new SqlParameter("@icaId", ica.icaId);
                par[1] = new SqlParameter("@itemId", ica.itemIdICA);
                par[2] = new SqlParameter("@categoryId", ica.categoryIdICA);
                par[3] = new SqlParameter("@attributeId", ica.attributeIdICA);
                par[4] = new SqlParameter("@attributeValue", ica.attributeValueICA);
                par[5] = new SqlParameter("@Status", 11);
                par[5].Direction = ParameterDirection.Output;

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryAttributeUpdate", par);
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
        return row;
    }

    public int DALInsertItemCategoryAttributeFirst(ItemCategoryBLL ic)
    {
        int row;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@itemId", ic.itemICId);
                par[1] = new SqlParameter("@categoryId", ic.categoryICId);
                par[2] = new SqlParameter("@attributeId", ic.attributeId);
                par[3] = new SqlParameter("@attributeValue", ic.attributeValue);
                par[4] = new SqlParameter("@Status", 11);
                par[4].Direction = ParameterDirection.Output;

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryAttributeInsert", par);
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
        return row;
    }

}
