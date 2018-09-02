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
/// Summary description for ItemCategoryImageDAL
/// </summary>
public class ItemCategoryImageDAL
{
    int status;
    public ItemCategoryImageDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int DALItemCategoryImageInsert(ItemCategoryImageBLL ici)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[9];
                par[0] = new SqlParameter("@imageSetType", ici.imageSetType);
                par[1] = new SqlParameter("@imageName", ici.imageName);
                par[2] = new SqlParameter("@imageDescription", ici.imageDescription);
                par[3] = new SqlParameter("@itemId", ici.itemId);
                par[4] = new SqlParameter("@categoryId", ici.categoryId);
                par[5] = new SqlParameter("@image1", ici.image1);
                par[6] = new SqlParameter("@image2", ici.image2);
                par[7] = new SqlParameter("@image3", ici.image3);
                par[8] = new SqlParameter("@Status", 11);
                par[8].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryImageInsert", par);
                status = (int)par[8].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        return status;
    }


    public void DALIsExistItemCategoryImage(ItemCategoryImageBLL ici, out int status, out int imgId)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@itemId", ici.itemId);
                par[1] = new SqlParameter("@categoryId", ici.categoryId);
                par[2] = new SqlParameter("@imageSetType", ici.imageSetType);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;
                par[4] = new SqlParameter("@imgId", 1);
                par[4].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryImageIfExists", par);
                status = (int)par[3].Value;
                imgId = (int)par[4].Value;
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

    }
    public int DALIsExistMainItemCategoryImage(ItemCategoryImageBLL ici)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@itemId", ici.itemId);
                par[1] = new SqlParameter("@categoryId", ici.categoryId);
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryImageIfExistsMain", par);
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

    public int DALItemCategoryImageUpdate(ItemCategoryImageBLL ici)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[10];
                par[0] = new SqlParameter("@imageId", ici.imageId);
                par[1] = new SqlParameter("@imageSetType", ici.imageSetType);
                par[2] = new SqlParameter("@imageName", ici.imageName);
                par[3] = new SqlParameter("@imageDescription", ici.imageDescription);
                par[4] = new SqlParameter("@itemId", ici.itemId);
                par[5] = new SqlParameter("@categoryId", ici.categoryId);
                par[6] = new SqlParameter("@image1", ici.image1);
                par[7] = new SqlParameter("@image2", ici.image2);
                par[8] = new SqlParameter("@image3", ici.image3);
                par[9] = new SqlParameter("@Status", 11);
                par[9].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryImageUpdate", par);
                status = (int)par[9].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }


    public int DALItemCategoryImageSet(ItemCategoryImageBLL ici)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[5];
                par[0] = new SqlParameter("@itemId", ici.itemId);
                par[1] = new SqlParameter("@categoryId", ici.categoryId);
                par[2] = new SqlParameter("@imageSetType", ici.imageSetType);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;


                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spItemCategoryImageTypeUpdate", par);
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
}
