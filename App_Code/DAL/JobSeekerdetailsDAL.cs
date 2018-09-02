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
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for JobSeekerdetailsDAL
/// </summary>
public class JobSeekerdetailsDAL
{
    CommonCode cc = new CommonCode();
    int status;
    DataSet ds = new DataSet();
    public JobSeekerdetailsDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet LoadGridJobSeeker(JobSeekerdetailsBLL obj)
    {
        DataSet ds = new DataSet();
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspJShowPostReq"))
                {

                }
            }
            return ds;
        }
        catch (SqlException ex)
        
        {
            throw ex;
        }

    }
    public DataSet DALViewAppliedJobs(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {


                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@uid", obj.Userid);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "ViewAppliedJobs", par);
                //ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "uspJShowPostReq", par);
                //string str =
                //    " with Event as( " +
                //    " select *from( " +
                //    " (SELECT [PID],[CName],[InSector],[JRole],[JRequirment],[VaccancyTill],[SalaryOffered],[FreExp],[TrainingOffered] from [Come2myCityDB].[come2mycity].[tbl_JPostReq]) as t1 " +
                //    " inner join " +
                //    " [Come2myCityDB].[come2mycity].[tbl_JCompReg] as t2 " +
                //    " on " +
                //    " t1.CName=t2.NameOfComp " +
                //    " inner join " +
                //    " come2mycity.JobSeekerApplied " +
                //    " on " +
                //    " t2.CID = come2mycity.JobSeekerApplied.company_id " +
                //    " where come2mycity.JobSeekerApplied.userid = '" + obj.Userid + "' " +
                //    " ) " +
                //    " ) ";
                //str += " select [CName],[InSector],[JRole],[JRequirment],[VaccancyTill],[SalaryOffered],[FreExp],[TrainingOffered] from Event";
                //ds = cc.ExecuteDataset(str);
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
        return ds;

    }

    public DataSet DALViewLocation(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {


                string sql = "select  city, cityName  from [Come2myCityDB].[come2mycity].[companydetails] inner join CityMaster  on city=cityId ";
                ds = cc.ExecuteDataset(sql);



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
        return ds;

    }
    public DataSet DALViewExperience(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {


                string sql = "select id, req_exp from [Come2myCityDB].[come2mycity].[latestjobemployer]";
                ds = cc.ExecuteDataset(sql);



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
        return ds;

    }
    public DataSet DALViewSalary(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {


                string sql = "select id,salary from [Come2myCityDB].[come2mycity].[latestjobemployer]";
                ds = cc.ExecuteDataset(sql);



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
        return ds;

    }
    public DataSet DALGetCompanyname(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                string sql = "select Id,companyname from [Come2myCityDB].[come2mycity].[companydetails]";
                ds = cc.ExecuteDataset(sql);



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
        return ds;

    }
    public DataSet DALGetCompanydetailsbyid(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@NameOfComp",obj.NameOfComp1)
                };
                //string sql = "select  distinct company_id,companyname,latestjobemployer.userid as userid,job_type,job_designation,address,cityname,req_qualification,req_exp,no_of_employee,salary,contactno,contactperson" +
                //            " from companydetails inner join latestjobemployer" +
                //            " on companydetails.userid =latestjobemployer.userid " +
                //            " inner join JobSeekerApplied" +
                //            " on companydetails.companyid = JobSeekerApplied.company_id " +
                //            " inner join CityMaster" +
                //            " on CityMaster.cityId=companydetails.city" +
                //            " where companydetails.id='"+obj.Id+"'";
                //string sql = "select latestjobemployer.id,companyid, companyname,job_type,job_designation,req_qualification,no_of_employee,salary,req_exp,address,contactno,contactperson,cityname from [Come2myCityDB].[come2mycity].[companydetails]s inner join [Come2myCityDB].[come2mycity].[latestjobemployer] on companydetails.userid = latestjobemployer.userid inner join CityMaster on CityMaster.cityId =companydetails.city where companydetails.id='" + obj.Id + "'";
                //ds = cc.ExecuteDataset(sql);
                string str =
                   " with Event as( " +
                   " select *from( " +
                   " (SELECT [CID],[NameOfComp],[TypeOfUnit],[DirectName],[MobileNo],[Role],[EmailId],[FAddress],[State],[District],[Taluka],[Sectors] FROM [Come2myCityDB].[come2mycity].[tbl_JCompReg] where NameOfComp='" + obj.NameOfComp1 + "')as t1 " +
                   " inner join " +
                   " [Come2myCityDB].[come2mycity].[tbl_JPostReq] as t2 " +

                   " on " +
                   " t1.NameOfComp=t2.CName " +
                   " ) " +
                   " ) ";
                str += " select CID,[NameOfComp],[JRole],Qualification,[JRequirment],[SalaryOffered],[MobileNo],VaccancyTill,[FreExp],[Taluka],City from Event";

                ds = cc.ExecuteDataset(str);
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
        return ds;

    }

    public DataSet DALGetCompanydetailsbylocation(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@City",obj.City1)
                };
                //string sql = "select  distinct company_id,latestjobemployer.id,companyname,latestjobemployer.userid as userid,job_type,job_designation,address,cityname,req_qualification,req_exp,no_of_employee,salary,contactno,contactperson" +
                //            " from [Come2myCityDB].[come2mycity].[companydetails] inner join [Come2myCityDB].[come2mycity].[latestjobemployer]" +
                //            " on companydetails.userid =latestjobemployer.userid " +
                //            " inner join JobSeekerApplied" +
                //            " on companydetails.companyid = JobSeekerApplied.company_id " +
                //            " inner join CityMaster" +
                //            " on CityMaster.cityId=companydetails.city" +
                //            " where companydetails.city='" + obj.Id + "'";
                string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [CID],[NameOfComp],[TypeOfUnit],[DirectName],[MobileNo],[Role],[EmailId],[FAddress],[State],[District],[Taluka],[City] as c,[Sectors] FROM [Come2myCityDB].[come2mycity].[tbl_JCompReg] where City like '" + obj.City1 + "%')as t1 " +
                    " inner join " +
                    " [Come2myCityDB].[come2mycity].[tbl_JPostReq] as t2 " +

                    " on " +
                    " t1.c=t2.City " +
                    " ) " +
                    " ) ";
                str += " select CID,[NameOfComp],[JRole],Qualification,[JRequirment],[SalaryOffered],[MobileNo],[FreExp],[Taluka],City from Event";
               
                ds = cc.ExecuteDataset(str);

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
        return ds;

    }
    public DataSet DALGetCompanydetailsbySkills(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select  distinct company_id,latestjobemployer.Id,companyname,latestjobemployer.userid as userid,job_type,job_designation,address,cityname,req_qualification,req_exp,no_of_employee,salary,contactno,contactperson" +
                            " from [Come2myCityDB].[come2mycity].[companydetails] inner join [Come2myCityDB].[come2mycity].[latestjobemployer]" +
                            " on companydetails.userid =latestjobemployer.userid " +
                            " inner join JobSeekerApplied" +
                            " on companydetails.companyid = JobSeekerApplied.company_id " +
                            " inner join CityMaster" +
                            " on CityMaster.cityId=companydetails.city" +
                            " where latestjobemployer.skills like'" + obj.KeySkill + "%'";
                ds = cc.ExecuteDataset(sql);

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
        return ds;

    }
    public DataSet DALGetCompanydetailsbyAdvance(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select  distinct company_id,latestjobemployer.Id,companyname,latestjobemployer.userid as userid,job_type,job_designation,address,cityname,req_qualification,req_exp,no_of_employee,salary,contactno,contactperson" +
                            " from [Come2myCityDB].[come2mycity].[companydetails] inner join [Come2myCityDB].[come2mycity].[latestjobemployer]" +
                            " on companydetails.userid =latestjobemployer.userid " +
                            " inner join JobSeekerApplied" +
                            " on companydetails.companyid = JobSeekerApplied.company_id " +
                            " inner join CityMaster" +
                            " on CityMaster.cityId=companydetails.city" +
                            " where latestjobemployer.skills='" + obj.KeySkill + "' or latestjobemployer.req_exp='" + obj.Req_exp + "' or latestjobemployer.salary='" + obj.Annualsalary + "' ";
                ds = cc.ExecuteDataset(sql);

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
        return ds;

    }

    public DataSet DALSearchbyNo(JobSeekerdetailsBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {


                string sql = "select usrFirstName+' '+usrLastName as FullName, usrEmailid from usermaster where usrMobileNo='" + obj.UsrMobileNo + "'";
                ds = cc.ExecuteDataset(sql);
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
        return ds;
    }

    public int IntialInsertCandidate(JobSeekerdetailsBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "insert into JobSeekerDetails(userid,usrMobileNo,resume_title,resume_name,myskill,designation,industry_type,job_type,current_role,work_exp, " +
                    " current_working,duration,annual_salary,preferred_location,current_location,graduate_course,specialized,Graduation_passout, " +
                    " graduate_university,postgraduation,pg_specialized,pg_passout,pg_university) " +
                    "values('" + obj.Userid + "','" + obj.UsrMobileNo + "','" + obj.Resume_title + "','" + obj.Resume_name + "','" + obj.KeySkill + "','','','','','','','','','','','','','','','','','','')";
                status = cc.ExecuteNonQuery(sql);

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
    public int DALGetstatus(JobSeekerdetailsBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "select id from JobSeekerDetails where userid='" + obj.Userid + "'";
                string id = cc.ExecuteScalar(sql);
                if (id == "")
                {
                    status = 1;
                }
                else
                {
                    status = 0;
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
        return status;
    }
    public int DALUpdateResume(JobSeekerdetailsBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "update JobSeekerDetails set resume_title='" + obj.Resume_title + "',resume_name='" + obj.Resume_name + "' where userid='" + obj.Userid + "'";
                status = cc.ExecuteNonQuery(sql);

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
    public int DALUpdateJobCategory(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "update come2mycity.JobSeekerDetails set industry_type='" + obj.Industrytype + "',job_type='" + obj.Jobtype + "' , designation='" + obj.Designation + "',current_role='" + obj.Currentrole + "' where userid='" + obj.Userid + "'";
                status = cc.ExecuteNonQuery(sql);

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
    public int DALUpdateWorkHistory(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "update JobSeekerDetails set work_exp='" + obj.Workexp + "',current_working='" + obj.Currentworking + "',annual_salary='" + obj.Annualsalary + "'  where userid='" + obj.Userid + "'";
                status = cc.ExecuteNonQuery(sql);

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
    public int DALUpdateLocation(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "update JobSeekerDetails set preferred_location='" + obj.Preferredlocation + "',current_location='" + obj.Currentlocation + "' where userid='" + obj.Userid + "'";
                status = cc.ExecuteNonQuery(sql);

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
    public int DALUpdateEducation(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                //string sql = "update JobSeekerDetails set graduate_course='" + obj.Graduatecourse + "',specialized='" + obj.Specialized + "',Graduation_passout='" + obj.Graduationpassout + "',graduate_university='" + obj.Graduateuniversity + "' where userid='" + obj.Userid + "'";
                string sql = "update [Come2myCityDB].[come2mycity].[tbl_JEducation] set Qualification='" + obj.Qualification1 + "',Specialization='" + obj.Specialization1 + "',CollegeName='" + obj.CollegeName1 + "',YearPassout='" + obj.YearPassout1 + "',University='" + obj.University1 + "',Marks='" + obj.Marks1 + "' where userid='" + obj.Userid + "' ";
                status = cc.ExecuteNonQuery(sql);

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
    public int DALInsertCandidateApplied(JobSeekerdetailsBLL obj)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "insert into JobSeekerApplied(userid,userMobileNo,company_id,applied_date,job_id)values('" + obj.UserId1 + "','" + obj.UsrMobileNo + "','" + obj.Companyid + "','" + obj.Applieddate + "','" + obj.Id + "')";
                status = cc.ExecuteNonQuery(sql);

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
    public DataSet LoadGridJobSeekerApplied(JobSeekerdetailsBLL obj)
    {
        DataSet ds = new DataSet();
        try
        {
            // conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "JobAppied"))
                {

                }
            }
            return ds;
        }
        catch (SqlException ex)
        {
            throw ex;
        }

    }

    public DataSet DALCandidateinitialDetails(JobSeekerdetailsBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "select usrMobileNo from usermaster where usrUserid='" + obj.Userid + "'";
                ds = cc.ExecuteDataset(sql);
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
        return ds;
    }

}
