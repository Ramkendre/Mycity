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
/// Summary description for ItemCategoryDAL
/// </summary>
public class ItemCategoryDAL
{
    public ItemCategoryDAL()
    {
        //spItemCategoryAttributeSelect
        // TODO: Add constructor logic here
        //
    }

    public List<ItemCategoryBLL> DALShowAllItemCategory()
    {

        List<ItemCategoryBLL> icList = new List<ItemCategoryBLL>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spItemCategorySelect"))
                {
                    while (dr.Read())
                    {
                        ItemCategoryBLL ic = new ItemCategoryBLL();
                        ic.itemICId = Convert.ToString(dr["itemId"]);
                        ic.categoryICId = Convert.ToString(Convert.ToString(dr["categoryId"]));
                        ic.itemCategoryId = Convert.ToInt32(Convert.ToString(dr["itemCategoryId"]));
                        icList.Add(ic);
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

        return icList;
    }


    public int DALItemCategoryInsert(ItemCategoryBLL ic)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            int rowNo;
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@itemId", ic.itemICId);
                par[1] = new SqlParameter("@categoryId", ic.categoryICId);
                par[2] = new SqlParameter("@status", 100);
                par[2].Direction = ParameterDirection.Output;

                rowNo = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryInsert", par);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return rowNo;
        }


    }



    //Returns all category List by Item Id
    public List<ItemCategoryBLL> DALGetItemWiseCategory(ItemCategoryBLL ic)
    {

        List<ItemCategoryBLL> ctList = new List<ItemCategoryBLL>();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@itemId", ic.itemICId);
                par[1] = new SqlParameter("@status", 100);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spCategorySelectByItemId", par))
                {
                    int no = 0;
                    while (dr.Read())
                    {
                        no = no + 1;
                        ItemCategoryBLL ct = new ItemCategoryBLL();

                        ct.categoryICId = Convert.ToString(dr["categoryId"]);
                        ct.catName = Convert.ToString(dr["categoryName"]);

                        // ct.Active = Convert.ToString(dr["Active"]);
                        ctList.Add(ct);
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
        return ctList;
    }


    public static List<ItemBLL> DALGetAllAttribute(ItemCategoryBLL ic)
    {

        List<ItemBLL> ctList = new List<ItemBLL>();

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@categoryId", ic.categoryICId);
                par[1] = new SqlParameter("@Status", 11);
                par[1].Direction = ParameterDirection.Output;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spSelectAttributeByCategory", par))
                {
                    while (dr.Read())
                    {

                        ItemBLL itl = new ItemBLL();
                        itl.attributeId = Convert.ToInt32(Convert.ToString(dr["attributeId"]));
                        ctList.Add(itl);
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
        return ctList;
    }

}
