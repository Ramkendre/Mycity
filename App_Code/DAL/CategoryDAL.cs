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
/// Summary description for CategoryDAL
/// </summary>
public class CategoryDAL
{
    public CategoryDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DataSet ds = new DataSet();
    int status;
    //For Inserting Category
    public int DALInsertCategory(CategoryBLL ct)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];

                par[0] = new SqlParameter("@categoryName", ct.categoryName);
                par[1] = new SqlParameter("@parentCategoryId", ct.parentCategoryId);
                par[2] = new SqlParameter("@catLevel", ct.catLevel);
                par[3] = new SqlParameter("@Status", 7);
                par[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spCategoryInsert", par);
                status = (int)par[3].Value;
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
    public int DALUpdateCategory(CategoryBLL ct)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@categoryId", ct.categoryId);
                par[1] = new SqlParameter("@categoryName", ct.categoryName);
                par[2] = new SqlParameter("@parentCategoryId", ct.parentCategoryId);
                par[3] = new SqlParameter("@catLevel", ct.catLevel);
                par[4] = new SqlParameter("@Status", 100);
                par[4].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spCategoryUpdate", par);
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

    //Returns all category Data Table
    public DataTable DALGetAllCategory()
    {


        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCategorySelectAll");

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
    public DataTable DALGetSelectedCategory(CategoryBLL ct)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@categoryId", ct.categoryId);
                par[1] = new SqlParameter("@Status", 100);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCategorySelectById", par);
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
        return ds.Tables[0];
    }

    //Gets Selected category & its Level
    public int DALGetSelectedCategoryLevel(CategoryBLL ct)
    {
        int catLevel = 0;
        List<CategoryBLL> ctList = new List<CategoryBLL>();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@categoryId", ct.parentCategoryId);
                par[1] = new SqlParameter("@Status", 100);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spGetSelectCategoryLevel", par))
                {
                    while (dr.Read())
                    {

                        catLevel = Convert.ToInt32(Convert.ToString(dr["catLevel"]));

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
        return catLevel;
    }

    public List<CategoryBLL> DALGetLeftCategoryMenu(int i, int j)
    {
        List<CategoryBLL> mnLst = new List<CategoryBLL>();
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@categoryId", i);
                par[1] = new SqlParameter("@cityId", j);
                par[2] = new SqlParameter("@status", 11);
                par[2].Direction = ParameterDirection.Output;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spGetLeftCategoryMenu", par))
                {
                    int no = 0;
                    while (dr.Read())
                    {
                        no = no + 1;
                        CategoryBLL ct = new CategoryBLL();
                        ct.srNo = no;
                        ct.categoryId = Convert.ToInt32(Convert.ToString(dr["categoryId"]));
                        ct.categoryName = Convert.ToString(dr["categoryName"]);
                        ct.parentCategoryId = Convert.ToInt32(Convert.ToString(dr["parentCategoryId"]));
                        ct.catLevel = Convert.ToInt32(Convert.ToString(dr["catLevel"]));
                        // ct.Active = Convert.ToString(dr["Active"]);
                        mnLst.Add(ct);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return mnLst;
    }

    public string DALGetMenuParent(string id)
    {
        string myId = id;

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@categoryParentId", myId);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spMenuGetParent", par))
                {
                    while (dr.Read())
                    {
                        myId = Convert.ToString(dr["parentCategoryId"]);
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

        return myId;
    }

    //Returns all category Data Table
    public DataTable DALGetAllCategoryWOParent()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCategorySelectAllWOParent");

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

    //Returns all category Data Table
    public DataTable DALGetAllCategoryParentForItem()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spCategorySelectAllForItem");

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
