using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for dalJobportal
/// </summary>
public class dalJobportal
{
    DataSet ds = new DataSet();

    int status;
	public dalJobportal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    public DataTable DALJobSelectByCategoryId(clsJobPortal Job, int Cid)
    {

        List<clsJobPortal> dtList = new List<clsJobPortal>();


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@Categoryid", Cid);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spJobSelectByCategoryId", par);

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

    public int BLLInsertPostResumeInfo(clsJobPortal objJobPortal)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[11];

                par[0] = new SqlParameter("@CategoryId", objJobPortal.Category);
                par[1] = new SqlParameter("@JobTypeId", objJobPortal.JobTypeId);
                par[2] = new SqlParameter("@ExpYear", objJobPortal.ExpYear);
                par[3] = new SqlParameter("@ExpMonths", objJobPortal.ExpMonths);
                par[4] = new SqlParameter("@Salary", objJobPortal.Salary);
                par[5] = new SqlParameter("@Stateid", objJobPortal.State);
                par[6] = new SqlParameter("@Distid", objJobPortal.Dist);
                par[7] = new SqlParameter("@Cityid", objJobPortal.Cityid);
                par[8] = new SqlParameter("@ResumeURL", objJobPortal.ResumeName);
                par[9] = new SqlParameter("@usrMobileNo", objJobPortal.usrMobileNo);
                par[10] = new SqlParameter("@Status", 11);
                par[10].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Insert_In_JobSearch", par);
                status = (int)par[10].Value;

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

    public int BLLInsertSearchJobInfo(clsJobPortal objJobPortal)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[10];

                par[0] = new SqlParameter("@CategoryId", objJobPortal.Category);
                par[1] = new SqlParameter("@JobTypeId", objJobPortal.JobTypeId);
                par[2] = new SqlParameter("@ExpYear", objJobPortal.ExpYear);
                par[3] = new SqlParameter("@ExpMonths", objJobPortal.ExpMonths);
                par[4] = new SqlParameter("@Salary", objJobPortal.Salary);
                par[5] = new SqlParameter("@Stateid", objJobPortal.State);
                par[6] = new SqlParameter("@Distid", objJobPortal.Dist);
                par[7] = new SqlParameter("@CityName", objJobPortal.CityName);
                par[8] = new SqlParameter("@usrMobileNo", objJobPortal.usrMobileNo);
                par[9] = new SqlParameter("@Status", 10);
                par[9].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Insert_In_SearchJobInfo", par);
                status = (int)par[9].Value;

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

    public int BLLInsertPostJobInfo(clsJobPortal objJobPortal)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[15];
               

                par[0] = new SqlParameter("@Category", objJobPortal.Category);

                par[1] = new SqlParameter("@JobTypeId", objJobPortal.JobTypeId);
                par[2] = new SqlParameter("@ExpYear", objJobPortal.ExpYear);
                par[3] = new SqlParameter("@ExpMonths", objJobPortal.ExpMonths);
                par[4] = new SqlParameter("@Salary", objJobPortal.Salary);
                par[5] = new SqlParameter("@State", objJobPortal.State);
                par[6] = new SqlParameter("@Dist", objJobPortal.Dist);
                par[7] = new SqlParameter("@Cityid", objJobPortal.Cityid);
                par[8] = new SqlParameter("@UserId", objJobPortal.UserId);
                par[9] = new SqlParameter("@Qualification",objJobPortal.Qualification);
                par[10] = new SqlParameter("@Designation", objJobPortal.Designation);
                par[11] = new SqlParameter("@CompanyName", objJobPortal.companyName);
                par[12] = new SqlParameter("@EmpRequired", objJobPortal.EmpRequired);
                
                par[13] = new SqlParameter("@pin", objJobPortal.Pincode);
                par[14] = new SqlParameter("@Status", 15);
                par[14].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Insert_JobpostInfo", par);
                status = (int)par[14].Value;
               
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









}
