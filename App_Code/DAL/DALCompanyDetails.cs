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
/// Summary description for DALCompanyDetails
/// </summary>
public class DALCompanyDetails
{
    //BLLCompanyDetails bllCompanyobj = new BLLCompanyDetails();


    CommonCode cc = new CommonCode();
    int status;
    DataSet ds = new DataSet();
    public DALCompanyDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int DALInsertCompanyDetails(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                //SqlParameter[] par = new SqlParameter[11];
                //par[0] = new SqlParameter("@companyid", obj.Companyid);
                //par[1] = new SqlParameter("@companyname", obj.Companyname);
                //par[2] = new SqlParameter("@companytype", obj.Companytype);
                //par[3] = new SqlParameter("@state", obj.State);
                //par[4] = new SqlParameter("@district", obj.District);
                //par[5] = new SqlParameter("@city", obj.City);
                //par[6] = new SqlParameter("@address", obj.Address);
                //par[7] = new SqlParameter("@contactperson", obj.Contactperson);
                //par[8] = new SqlParameter("@contactno", obj.Contactno);
                //par[9] = new SqlParameter("@industry_type", obj.Industrytype);
                //par[10] = new SqlParameter("@status", 12);
                //par[10].Direction = ParameterDirection.Output;
                //SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spCompanyRegistrationInsert", par);
                //status = (int)par[10].Value;

                string sql = "insert into companydetails(companyid,companyname,companytype,state,district,city,address,contactperson,contactno,industry_type,userid) " +
                    " values('" + obj.Companyid + "','" + obj.Companyname + "','" + obj.Companytype + "','" + obj.State + "','" + obj.District + "','" + obj.City + "','" + obj.Address + "','" + obj.Contactperson + "', " +
                    " '" + obj.Contactno + "','" + obj.Industrytype + "','" + obj.Userid + "')";

                status = cc.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return status;
        }

    }
    public int DALUpdateCompanyDetails(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

              //  string sql = "update companydetails set state='" + obj.State + "',district='" + obj.District + "',city='" + obj.City + "',address='" + obj.Address + "',industry_type='" + obj.Industrytype + "' where userid='" + obj.Userid + "'";

                string sql = "update companydetails set state='" + obj.State + "',district='" + obj.District + "',city='" + obj.City + "',address='" + obj.Address + "' where userid='" + obj.Userid + "'";

                status = cc.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return status;
        }

    }


    public DataSet DALSearchbycompanyno(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "select companyid,companyname,address from companydetails where contactno='" + obj.Contactno + "' ";
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
    public int DALExistcompanyno(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "select companyid from companydetails where contactno='" + obj.Contactno + "' ";
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
    public DataSet DALViewAppliedcandidate(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql1 = "select companyid from companydetails where userid='" + obj.Userid + "' ";
                obj.Companyid = cc.ExecuteScalar(sql1);
                string sql = "select distinct JobSeekerApplied.userid as userid,usrFirstName+' '+usrLastName as userName,JobSeekerApplied.userMobileNo,JobSeekerDetails.graduate_course,JobSeekerDetails.resume_title " +
                            " from UserMaster inner join JobSeekerApplied" +
                            " on UserMaster.usrUserId =JobSeekerApplied.userid " +
                            " inner join JobSeekerDetails" +
                            " on JobSeekerApplied.userid =JobSeekerDetails.userid " +
                            " where JobSeekerApplied.company_id='" + obj.Companyid + "'";
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
    public DataSet DALViewCompanyDetails(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                // string sql1 = "select * from latestjobemployer inner join companydetails on companydetails.userid=latestjobemployer.userid  where companydetails.userid='" + obj.Userid + "'";
                string sql = "select stateName ,distName,cityName,companyname,companytype,address,contactperson,job_type,contactno,Functions,skills,job_designation,req_qualification,no_of_employee,req_exp,salary,job_status,valid_from,valid_to from companydetails " +
                    " inner join latestjobemployer on companydetails.userid =latestjobemployer.userid " +
                    " inner join  StateMaster on stateId= state inner join DistrictMaster on distId =district inner join CityMaster on cityId=city " +
                    " inner join Functions on FunctionId=industry_type  " +
                    " where companydetails.userid='" + obj.Userid + "' and latestjobemployer.id='"+obj.Id+"' ";
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
    public DataSet DALViewCompanyDetailsonly(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                //string sql1 = "select * from companydetails where companydetails.userid='" + obj.Userid + "'";
                // sql1 = sql1 + "select stateName ,distName,cityName from StateMaster inner join companydetails on stateId= state inner join DistrictMaster on distId =district inner join CityMaster on cityId=city";
                string sql = "select stateName ,distName,cityName,companyname,companytype,address,contactperson,contactno,Functions from companydetails " +
                " inner join  StateMaster on stateId= state inner join DistrictMaster on distId =district inner join CityMaster on cityId=city" +
                " inner join Functions on FunctionId=industry_type " +
                " where companydetails.userid='" + obj.Userid + "'";
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

    public DataSet DALViewCompanyAdvertisment(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                //string sql1 = "select * from companydetails where companydetails.userid='" + obj.Userid + "'";
                // sql1 = sql1 + "select stateName ,distName,cityName from StateMaster inner join companydetails on stateId= state inner join DistrictMaster on distId =district inner join CityMaster on cityId=city";
                string sql = "select companyname,contactno,address,contactperson,advertise_Fromdate,advertise_Todate,advertise_to from companydetails where userid='" + obj.Userid + "' ";
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
    public int DALCheckcompanyexist(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "select id from companydetails where userid='" + obj.Userid + "'";
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
    public int DALChecklatestjobexist(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {


                string sql = "select id from latestjobemployer where userid='" + obj.Userid + "'";
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
    public int DALCheckAdvertismentexist(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {


                string sql = "select adv_filename from companydetails where userid='" + obj.Userid + "'";
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

    public int DALInsertAdvertise(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql1 = "select companyid from companydetails where userid='" + obj.Userid + "'";
                string companyid = cc.ExecuteScalar(sql1);

                string sql = "select id from companyadvt where userid='" + obj.Userid + "'";
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                     sql = "insert into companyadvt(userid,companyid,advertise_from,advertise_to,advertise_in,adv_file,adv_status)" +
                        " values('" + obj.Userid + "','" + companyid + "','" + obj.AdvertiseFromdate + "','" + obj.AdvertiseTodate + "','" + obj.AdvertiseIn + "','" + obj.Advfilename + "','" + obj.Jobstatus + "')";
                    int a = cc.ExecuteNonQuery(sql);
                    status = 1;

                }
                else
                {
                    sql = "update companyadvt set adv_status='Deactive' where userid='" + obj.Userid + "'";
                    int a1 = cc.ExecuteNonQuery(sql);
                    sql = "insert into companyadvt(userid,companyid,advertise_from,advertise_to,advertise_in,adv_file,adv_status)" +
                        " values('" + obj.Userid + "','" + companyid + "','" + obj.AdvertiseFromdate + "','" + obj.AdvertiseTodate + "','" + obj.AdvertiseIn + "','" + obj.Advfilename + "','" + obj.Jobstatus + "')";
                    int a = cc.ExecuteNonQuery(sql);
                    status = 1;
                    
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
    public int DALUpdateAdvertisestatus(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "select id from companyadvt where userid='" + obj.Userid + "'";
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                    status = 0;

                }
                else
                {
                    sql = "update companyadvt set adv_status='Deactive' where userid='" + obj.Userid + "'";
                    status = cc.ExecuteNonQuery(sql);
                    status = 1;
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
    public DataSet DALSearchAllbycompanyid(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                // string sql = "select * from companydetails where contactno='" + obj.Contactno + "'";
                string sql = "select companyname,companytype,stateName,distName,cityName,address,contactno,contactperson,Functions from companydetails " +
                "inner join StateMaster on stateId =state inner join DistrictMaster on distId =district inner join CityMaster " +
                " on cityId = city inner join Functions on FunctionId=industry_type where companyid='" + obj.Companyid + "'";

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

    public int DALupdateCompanyProfile(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "update companydetails set companytype='" + obj.Companytype + "',address='" + obj.Address + "' where companyid='" + obj.Companyid + "'";
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

    public DataSet DALGetAdvInfo(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "select advertise_Fromdate+' to '+advertise_Todate as advertisedate, advertise_to,adv_filename from companydetails where companyid='" + obj.Companyid + "'";

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

    //public int DALupdateAdvertisement(BLLCompanyDetails obj)
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {

    //        try
    //        {
    //            string sql = "update companydetails set advertise_Fromdate='" + obj.AdvertiseFromdate + "',advertise_Todate='" + obj.AdvertiseTodate + "',advertise_to='" + obj.AdvertisedTo + "',adv_filename='" + obj.Advfilename + "' where companyid='" + obj.Companyid + "'";
    //            status = cc.ExecuteNonQuery(sql);

    //        }
    //        catch (SqlException ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    return status;
    //}


    public DataSet DALGetQualification(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "select qualificationName,qualificationId  from userQualification";

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

    public DataSet DALGetAdvertisment(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "select * from companyadvt where userid='" + obj.Userid + "' order by id desc";

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

    public DataSet DALGetIndustry(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                //string sql1 = "select industry_type from companydetails where userid='" + obj.Userid + "'";
                //string industry_type=cc.ExecuteScalar(sql1);


                //string sql="select rolename from companydetails as c "+
                //            "inner join functions as f "+
                //            "on c.industry_type=f.FunctionId "+
                //            "inner join  RoleName as r "+
                //            "on r.FunctionId  = f.FunctionId "+
                //            "where c.industry_type='"+obj.Industrytype+"'";
                string sql = "select * from UserIndustry";

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


    public int DALInsertLatestJobRecruit(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "select industry_type from companydetails where userid='" + obj.Userid + "'";
                string industrytype = cc.ExecuteScalar(sql);


                string sql1 = "insert into latestjobemployer(userid,industrytype,job_type,skills,job_designation,req_qualification,no_of_employee,req_exp,salary,form_name,register_date,job_status,valid_from,valid_to) " +
                    " values('" + obj.Userid + "', '" + industrytype + "','" + obj.Jobtype + "','" + obj.Skills + "','" + obj.Jobdesignation + "','" + obj.ReqQualification + "','" + obj.Noofemployee + "','" + obj.Reqexp + "','" + obj.Salary + "','" + obj.Formname + "','" + obj.Currentdate + "','"+obj.Jobstatus+"','"+obj.Validfrom+"','"+obj.Validto+"')";
                status = cc.ExecuteNonQuery(sql1);

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


    public int DALUpdateLatestJobRecruit(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql1 = "update latestjobemployer set skills='" + obj.Skills + "',job_designation='" + obj.Jobdesignation + "',req_qualification='" + obj.ReqQualification + "',no_of_employee='" + obj.Noofemployee + "',req_exp='" + obj.Reqexp + "',salary='" + obj.Salary + "',job_status='" + obj.Jobstatus + "' where userid='" + obj.Userid + "' and id='" + obj.Id + "'";
                status = cc.ExecuteNonQuery(sql1);

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

    public int DALUpdateLatestGovtJobRecruit(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql1 = "update latestjobemployer set skills='" + obj.Skills + "',job_designation='" + obj.Jobdesignation + "',req_qualification='" + obj.ReqQualification + "',no_of_employee='" + obj.Noofemployee + "',req_exp='" + obj.Reqexp + "',salary='" + obj.Salary + "',job_status='"+obj.Jobstatus+"' where userid='" + obj.Userid + "' and id='" + obj.Id + "'";
                status = cc.ExecuteNonQuery(sql1);

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


    public DataSet DALGetLatestJob(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "select id,job_type,job_designation,req_qualification,form_name,no_of_employee,req_exp,valid_from,valid_to,job_status from latestjobemployer where userid='" + obj.Userid + "' ";

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
    public DataSet DALGetLatestGovtJob(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "select id,job_type,job_designation,req_qualification,no_of_employee,req_exp,valid_from,valid_to,job_status from latestjobemployer where userid='"+obj.Userid+"' ";

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

    public int DALInsertCandidateReceipt(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                string sql = "insert into CompanyReceipt(contactno,feespaid,feesdated,candidatename) " +
                    " values('" + obj.Contactno + "','" + obj.Feespaid + "','" + obj.Feesdated + "','" + obj.Candidatename + "')";

                status = cc.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return status;
        }

    }

    public DataSet DALGetReceiptInfo(BLLCompanyDetails obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "select receiptid,contactno,feespaid,feesdated,candidatename from CompanyReceipt order by receiptid desc ";

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
