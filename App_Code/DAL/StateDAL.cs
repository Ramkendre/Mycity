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

public class StateDAL
{
    public StateDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    DataSet ds = new DataSet();

    public int DALStateInsert(StateBLL st)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@stateName", st.stateName);
                par[1] = new SqlParameter("@countryId", st.countryId);
                par[2] = new SqlParameter("@status", 100);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStateInsert", par);

                status = (int)par[2].Value;
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


    public DataTable GetRecordsIAY(string query)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.Text, query);
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



    public DataTable DALStateShowAll()
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spStateSelect");
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

    public DataTable DALStateSelectBySId(StateBLL st)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@stateId", st.stateId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spStateSelectBySId", par);
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


    public DataTable DALStateSelectByCId(StateBLL st, int cid)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@countryId", cid);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spStateSelectByCId", par);
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

    public int DALStateUpdate(StateBLL st)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@stateId", st.stateId);
                par[1] = new SqlParameter("@stateName", st.stateName);
                par[2] = new SqlParameter("@countryId", st.countryId);
                par[3] = new SqlParameter("@status", 11);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStateUpdate", par);
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

    public bool DALIsExistState(StateBLL st)
    {
        string row = "";
        bool flag = false;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@stateId", st.stateId);
                par[1] = new SqlParameter("@stateName", st.stateName);
                par[2] = new SqlParameter("@counrtyId", st.countryId);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;
                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "spStateIsExistByIdName", par));
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

    public bool DALIsExistCountryName(StateBLL st)
    {
        bool flag = false;
        string row = "";

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@stateName", st.stateName);
                par[1] = new SqlParameter("@Status", 11);
                par[1].Direction = ParameterDirection.Output;
                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "spStateIsExistByName", par));
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

    public string DALStateSelectById(int id)
    {
        string name = "";

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@stateId", id);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spStateSelectBySId", par))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        name = Convert.ToString(dr["stateName"]);
                    }
                }
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
        return name;
    }

    public DataTable BLLHCStateShowAll()
    {
        DataTable dtState = new DataTable();
        DataColumn stateId = new DataColumn("stateId", typeof(Int32));
        DataColumn stateName = new DataColumn("stateName", typeof(string));
        dtState.Columns.Add(stateId);
        dtState.Columns.Add(stateName);
        try
        {
            dtState.Rows.Add(1, "Andra Pradesh");
            dtState.Rows.Add(2, "Arunachal Pradesh");
            dtState.Rows.Add(3, "Assam");
            dtState.Rows.Add(4, "Bihar");
            dtState.Rows.Add(5, "Chhattisgarh");
            dtState.Rows.Add(6, "Goa");
            dtState.Rows.Add(7, "Gujarat");
            dtState.Rows.Add(8, "Haryana");
            dtState.Rows.Add(9, "Himachal");
            dtState.Rows.Add(10, "Jammu and Kashmir");
            dtState.Rows.Add(11, "Jharkhand");
            dtState.Rows.Add(12, "Karnataka");
            dtState.Rows.Add(13, "Kerala");
            dtState.Rows.Add(14, "Madya Pradesh");
            dtState.Rows.Add(15, "Maharashtra");
            dtState.Rows.Add(16, "Manipur");
            dtState.Rows.Add(17, "Meghalaya");
            dtState.Rows.Add(18, "Mizoram");
            dtState.Rows.Add(19, "Nagaland");
            dtState.Rows.Add(20, "Orissa");
            dtState.Rows.Add(21, "Punjab");
            dtState.Rows.Add(22, "Rajasthan");
            dtState.Rows.Add(23, "Sikkim");
            dtState.Rows.Add(24, "Tamil Nadu");
            dtState.Rows.Add(25, "Tripura");
            dtState.Rows.Add(26, "Uttaranchal");
            dtState.Rows.Add(27, "Uttar Pradesh");
            dtState.Rows.Add(28, "West Bengal");
            dtState.Rows.Add(29, "Andaman and Nicobar");
            dtState.Rows.Add(30, "Chandigarh");
            dtState.Rows.Add(31, "Dadar and Nagar Haveli");
            dtState.Rows.Add(32, "Daman and Diu");
            dtState.Rows.Add(33, "Delhi");
            dtState.Rows.Add(34, "Lakshadeep");
            dtState.Rows.Add(35, "Pondicherry");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtState;
    }
}
