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


public class UserRegistrationDAL
{
    CommonCode cc = new CommonCode();
	DataSet ds = new DataSet();
    int status;
    public UserRegistrationDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet DALSendSMSByName(UserRegistrationBLL ur)
    {
        List<UserRegistrationBLL> urList = new List<UserRegistrationBLL>();
DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@last", ur.usrLastName);
                par[1] = new SqlParameter("@first", ur.usrFirstName);
                par[2] = new SqlParameter("@UserId", ur.usrUserId);

                
                
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spRetrieveByNameSendSms", par);

            }
            //try
            //{
            //    SqlParameter[] par = new SqlParameter[1];
            //    par[0] = new SqlParameter("@usrUserId", ur.usrUserId);

            //    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spRetrieveByNameSendSms", par);

            //}
            catch (Exception ex)
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
    public int DALInsertUserRegistrationInitial(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[18];

                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                par[2] = new SqlParameter("@usrAltMobileNo", ur.usrAltMobileNo);
                par[3] = new SqlParameter("@usrAddress", ur.usrAddress);
                par[4] = new SqlParameter("@usrPassword", ur.usrPassword);
                par[5] = new SqlParameter("@usrFirstName", ur.usrFirstName);
                par[6] = new SqlParameter("@usrLastName", ur.usrLastName);
                par[7] = new SqlParameter("@usrGender", ur.usrGender);
                par[8] = new SqlParameter("@usrCityId", ur.usrCityId);
                par[9] = new SqlParameter("@usrFriendGroup", ur.frnrelGroup);
                par[10]=new SqlParameter("@usrPIN",ur.usrPIN);
                par[11]=new SqlParameter("@usrDOB",ur.usrDOB);
                par[12]=new SqlParameter("@FaxNo",ur.FaxNo);
                par[13] = new SqlParameter("@usrPhoneNumber", ur.usrPhoneNo);
                par[14] = new SqlParameter("@OfficeNo", ur.OfficeNo);
                par[15] = new SqlParameter("@usrEmailId", ur.usrEmailId);
                par[16] = new SqlParameter("@StrDevId", ur.StrDevId);
                //par[16] = new SqlParameter("@UsrCreationDate", ur.UsrCreationDate);                
                par[17] = new SqlParameter("@Status", 18);
                par[17].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegistrationIntialInsert", par);
                status = (int)par[17].Value;

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

    public int DALInsertSpecificUserRegistrationInitial(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[36];

                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                par[2] = new SqlParameter("@usrAddress", ur.usrAddress);
                par[3] = new SqlParameter("@usrPassword", ur.usrPassword);
                par[4] = new SqlParameter("@usrFirstName", ur.usrFirstName);
                par[5] = new SqlParameter("@usrMiddleName", ur.usrMiddleName);
                par[6] = new SqlParameter("@usrLastName", ur.usrLastName);
                par[7] = new SqlParameter("@usrPIN", ur.usrPIN);
                par[8] = new SqlParameter("@usrDOB", ur.usrDOB);
                par[9] = new SqlParameter("@usrEmailId", ur.usrEmailId);
                par[10] = new SqlParameter("@usrCarrerInterest", ur.usrCarrerInterest);
                par[11] = new SqlParameter("@Age", ur.UsrAge);
                par[12] = new SqlParameter("@usrBestFeature", ur.usrBestFeature);
                par[13] = new SqlParameter("@usrBuild", ur.usrBuild);
                par[14] = new SqlParameter("@usrSocialDesignation", ur.UsrSocialDesignation);
                par[15] = new SqlParameter("@Religion", ur.Usrreligion);
                par[16] = new SqlParameter("@Caste", ur.Caste);
                par[17] = new SqlParameter("@Joingroup", ur.Joingroup);
                par[18] = new SqlParameter("@Marriagedt", ur.Marriagedt);
                par[19] = new SqlParameter("@JobPlace", ur.Jobplace);
                par[35] = new SqlParameter("@Status", 19);
                par[35].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegisterSpecificInitInsert", par);
                status = (int)par[17].Value;

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

    public int DALInsertSpecificUserRegistrationAndroid(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[34];

                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                par[2] = new SqlParameter("@usrAddress", ur.usrAddress);
                par[3] = new SqlParameter("@usrPassword", ur.usrPassword);
                par[4] = new SqlParameter("@usrFirstName", ur.usrFirstName);
                par[5] = new SqlParameter("@usrMiddleName", ur.usrMiddleName);
                par[6] = new SqlParameter("@usrLastName", ur.usrLastName);
                par[7] = new SqlParameter("@usrPIN", ur.usrPIN);
                par[8] = new SqlParameter("@usrDOB", ur.usrDOB);
                par[9] = new SqlParameter("@usrEmailId", ur.usrEmailId);
                par[10] = new SqlParameter("@usrCarrerInterest", ur.usrCarrerInterest);
                par[11] = new SqlParameter("@Age", ur.UsrAge);
                par[12] = new SqlParameter("@usrBestFeature", ur.usrBestFeature);
                par[13] = new SqlParameter("@usrBuild", ur.usrBuild);
                par[14] = new SqlParameter("@usrSocialDesignation", ur.UsrSocialDesignation);
                par[15] = new SqlParameter("@Religion", ur.Usrreligion);
                par[16] = new SqlParameter("@Caste", ur.Caste);
                par[17] = new SqlParameter("@Joingroup", ur.Joingroup);
                par[18] = new SqlParameter("@marriageDate", ur.Marriagedt);
                par[19] = new SqlParameter("@JobPlace", ur.Jobplace);
                par[20] = new SqlParameter("@votterlist", ur.Votterlist);
                par[21] = new SqlParameter("@wardno", ur.Wardno);
                par[22] = new SqlParameter("@NameVotterList", ur.Namevosotorlist);
                par[23] = new SqlParameter("@RationCard", ur.RationCard);
                par[24] = new SqlParameter("@OwnHouse", ur.OwnHouse);
                par[25] = new SqlParameter("@Pancard", ur.Pancard);
                par[26] = new SqlParameter("@SeniorCitizen", ur.SeniorCitizen);
                par[27] = new SqlParameter("@RailwayPass", ur.RailwayPass);
                par[28] = new SqlParameter("@Handicap", ur.Handicap);
                par[29] = new SqlParameter("@AdharNidhi", ur.AdharNidhi);
                par[30] = new SqlParameter("SanjayGandhiYojana", ur.SAnjayGandhiYojana);
                par[31] = new SqlParameter("@AnyScholorship", ur.Anyscholorship);
                par[32] = new SqlParameter("@usrHighestQualification", ur.usrHighestQualification); 
                par[33] = new SqlParameter("@Status", 33);
                par[33].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegisterSpecificInsertAndroid", par);
                status = (int)par[33].Value;

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


    public int DALGetUserRoleId(UserRegistrationBLL ur)
    {
        string id = "";
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select roleid from AdminSubMarketingSubUser right outer join UserMaster on friendid=usrUserId where usrMobileNo='" + ur.usrMobileNo + "'";
                 id = cc.ExecuteScalar(sql);
                 if (id == "" || id == null)
                 {
                     status = 0;
                 }
                 else
                 {
                     status = Convert.ToInt32(id);

                 }
                            
            }
            catch (Exception ex)
            { }
        }
        return status;



    }

   
    public int DALInsertUserRegistrationInitialNew(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[9];

                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                par[2] = new SqlParameter("@usrAddress", ur.usrAddress);
                par[3] = new SqlParameter("@usrPassword", ur.usrPassword);
                par[4] = new SqlParameter("@usrFirstName", ur.usrFirstName);
                par[5] = new SqlParameter("@usrLastName", ur.usrLastName);
                par[6] = new SqlParameter("@usrPIN", ur.usrPIN);
                par[7] = new SqlParameter("@usrEmailId", ur.usrEmailId);
                par[8] = new SqlParameter("@Status", 9);
                par[8].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegistrationIntialInsertNew", par);
                status = (int)par[8].Value;

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


    public int DALIsExistUser(UserRegistrationBLL ur)
    {


        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserRegistrationIsExist", par));
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
        return status;

    }

    public int DALIsExistUserByLc(UserRegistrationBLL ur)
    {


        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrMobileNo", ur.usrAltMobileNo);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserRegistrationIsExist", par));
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
        return status;

    }

    public int DALIsExistUser1(UserRegistrationBLL ur)
    {


        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserRegistrationIsExist", par));
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
        return status;

    }
    public int DALInsertUID(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrBestFeature", ur.usrBestFeature);
                par[1] = new SqlParameter("@usrMobileno", ur.usrMobileNo);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserUIDInsert", par));
                status = (int)par[2].Value;

            }
            catch (Exception ex)
            { }
            return status;
        }
    }


    public int DALInsertVID(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrBuild", ur.usrBuild);
                par[1] = new SqlParameter("@usrMobileno", ur.usrMobileNo);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserVIDInsert", par));
                status = (int)par[2].Value;

            }
            catch (Exception ex)
            { }
            return status;
        }
    }

    public int DALInsertJob(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrCarrerInterest", ur.usrCarrerInterest);
                par[1] = new SqlParameter("@usrMobileno", ur.usrMobileNo);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserJOBInsert", par));
                status = (int)par[2].Value;

            }
            catch (Exception ex)
            { }
            return status;
        }

    }

    public int DALInsertPancard(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrPoliticalView", ur.usrPoliticalView);
                par[1] = new SqlParameter("@usrMobileno", ur.usrMobileNo);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserInsetrPan", par));
                status = (int)par[2].Value;

            }
            catch (Exception ex)
            { }
            return status;
        }

    }
    public int DALInsertDrivingLic(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrIdealMatch", ur.usrIdealMatch);
                par[1] = new SqlParameter("@usrMobileno", ur.usrMobileNo);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserInsertDrivingLic", par));
                status = (int)par[2].Value;

            }
            catch (Exception ex)
            { }
            return status;
        }

    }
    public int DALInsertAlternateNo(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrAltMobileNo", ur.usrAltMobileNo);
                par[1] = new SqlParameter("@usrMobileno", ur.usrMobileNo);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserInsertDrivingLic", par));
                status = (int)par[2].Value;

            }
            catch (Exception ex)
            { }
            return status;
        }

    }

    public int DALInsertGender(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrGender", ur.usrGender);
                par[1] = new SqlParameter("@usrMobileno", ur.usrMobileNo);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserGender", par));
                status = (int)par[2].Value;

            }
            catch (Exception ex)
            { }
            return status;
        }

    }
  


    public DataTable DALShowAllUser(UserRegistrationBLL urb)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@usrUserId", urb.usrUserId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserRegistrationSelectById", par);


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

    public int DALSearchMobileisExist(UserRegistrationBLL ur)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int flag = 0;
        try
        {



            string sql = "select usruserid from usermaster where usrMobileNo='" + ur.Customermobileno + "'";
            string newflag = cc.ExecuteScalar(sql);
            if (newflag.ToString() == "")
            //flag = Convert.ToInt32(cc.ExecuteScalar(sql));

            //if (flag > 0)
            //{
            //    flag = 1;
            //}
            //else
            //{
            //    flag = 0;
            //}
            {
                flag = 0;
            }
            else
            {
                flag = 1;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con1.Close();
        }
        return flag;


    }

       
    
    public int DALInsertBalanceTransfer(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[8];
                par[0] = new SqlParameter("@customername", ur.Customername);
                par[1] = new SqlParameter("@mobileno", ur.Customermobileno);
                par[2] = new SqlParameter("@transbal", ur.Transbal);
                par[3] = new SqlParameter("@prombal", ur.Prombal);
                par[4] = new SqlParameter("@validfrom", ur.Validfrom);
                par[5] = new SqlParameter("@validupto", ur.Validupto);
                par[6] = new SqlParameter("@FromMobileno", ur.Frmmobileno);
                par[7] = new SqlParameter("@status", 9);
                par[7].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "[come2mycity].[InsertBalance]", par));
                status = (int)par[7].Value;
              
                

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

    //public int DALLoginUserCheck(UIUserRegistrationBLL ur)
    //{


    //    using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
    //    {
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[3];
    //            par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
    //            par[1] = new SqlParameter("@usrPassword", ur.usrPassword);
    //            par[2] = new SqlParameter("@Status", 11);
    //            par[2].Direction = ParameterDirection.Output;

    //            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spLoginUserCheck", par);
    //            status = (int)par[2].Value;
    //        }
    //        catch (Exception ex)
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

    //public DataTable DALLoginUserDetails(UIUserRegistrationBLL ur)
    //{



    //    using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
    //    {
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[2];
    //            par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
    //            par[1] = new SqlParameter("@usrPassword", ur.usrPassword);

    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spLoginUserId", par);

    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    return ds.Tables[0];
    //}

    public DataTable DALUserRegistrationSMSInfo(string usrMobileNo)
    {
        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrMobileNo", usrMobileNo);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserRegistrationSMSInfo", par);
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

    public int DALUserRegistrationContactUpdate(UserRegistrationBLL ur)
    {
        int status;
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[19];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrFirstName", ur.usrFirstName);
                par[2] = new SqlParameter("@usrMiddleName", ur.usrMiddleName);
                par[3] = new SqlParameter("@usrLastName", ur.usrLastName);
                par[4] = new SqlParameter("@usrAddress", ur.usrAddress);
                par[5] = new SqlParameter("@usrArea", ur.usrArea);
                par[6] = new SqlParameter("@usrStateId", ur.usrStateId);
                par[7] = new SqlParameter("@usrDistrictId", ur.usrDistrictId);
                par[8] = new SqlParameter("@usrCityId", ur.usrCityId);
                par[9] = new SqlParameter("@usrPIN", ur.usrPIN);
                par[10] = new SqlParameter("@usrPhoneNumber", ur.usrPhoneNo);
                par[11] = new SqlParameter("@usrAltMobileNo", ur.usrAltMobileNo);
                par[12] = new SqlParameter("@usrDOB", ur.usrDOB);
                par[13] = new SqlParameter("@usrControlMobileNo", ur.usrControlMobileNo);
                
                par[14] = new SqlParameter("@usrEmailId", ur.usrEmailId);
                par[15] = new SqlParameter("@OfficeNo", ur.OfficeNo );
                par[16] = new SqlParameter("@FaxNo", ur.FaxNo );
                par[17] = new SqlParameter("@Website", ur.Website);
                
                par[18] = new SqlParameter("@Status", 11);
                par[18].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegistrationContactUpdate", par);

                status = (int)par[18].Value;
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

    public int DALUserRegistrationProfessionalUpdate(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[10];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrHighestQualification", ur.usrHighestQualification);
                par[2] = new SqlParameter("@usrBoardUniversity", ur.usrBoardUniversity);
                par[3] = new SqlParameter("@usrProfession", ur.usrProfession);
                par[4] = new SqlParameter("@usrIndustry", ur.usrIndustry);
                par[5] = new SqlParameter("@usrCompanyName", ur.usrCompanyName);
                par[6] = new SqlParameter("@usrCarrerSkill", ur.usrCarrerSkill);
                par[7] = new SqlParameter("@usrCarrerInterest", ur.usrCarrerInterest);
                par[8] = new SqlParameter("@Status", 11);
                par[8].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegistrationProfessionalUpdate", par);
                status = (int)par[8].Value;
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

    public int DALUserRegistrationSocialUpdate(UserRegistrationBLL ur)
    {
        int status;
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[14];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrIdealMatch", ur.usrIdealMatch);
                par[2] = new SqlParameter("@usrBestFeature", ur.usrBestFeature);
                par[3] = new SqlParameter("@usrHeight", ur.usrHeight);
                par[4] = new SqlParameter("@usrBuild", ur.usrBuild);
                par[5] = new SqlParameter("@usrPoliticalView", ur.usrPoliticalView);
                par[6] = new SqlParameter("@usrBooks", ur.usrBooks);
                par[7] = new SqlParameter("@usrMusic", ur.usrMusic);
                par[8] = new SqlParameter("@usrMemberSocial", ur.usrMembershipSocial);
                par[9] = new SqlParameter("@usrMemberPolitical", ur.usrMemebrshipPolitical);
                par[10] = new SqlParameter("@usrReligion", ur.Usrreligion);
                par[11] = new SqlParameter("@usrCaste", ur.Caste);
                par[12] = new SqlParameter("@usrCasteCategory", ur.Usrcastecategory);
                par[13] = new SqlParameter("@Status", 15);
                par[13].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegistrationSocialUpdate", par);

                status = (int)par[13].Value;
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

    public DataTable DALUserProfileInitialByName(UserRegistrationBLL urb)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@usrUserId", urb.usrUserId);
                par[1] = new SqlParameter("@usrFirstName", urb.usrFirstName);
                par[2] = new SqlParameter("@usrLastName", urb.usrLastName);
                par[3] = new SqlParameter("@usrCityId", urb.usrCityId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserSelectInitialByName", par);

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

    public DataTable DALUserProfileInitialByFName(UserRegistrationBLL urb)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@usrUserId", urb.usrUserId);
                par[1] = new SqlParameter("@usrFirstName", urb.usrFirstName);
                par[2] = new SqlParameter("@usrLastName", urb.usrLastName);
                par[3] = new SqlParameter("@usrCityId", urb.usrCityId);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserSelectInitialByFName", par);
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
   

    public DataTable DALUserProfileInitialByLName(UserRegistrationBLL urb)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@usrUserId", urb.usrUserId);
                par[1] = new SqlParameter("@usrFirstName", urb.usrFirstName);
                par[2] = new SqlParameter("@usrLastName", urb.usrLastName);
                par[3] = new SqlParameter("@usrCityId", urb.usrCityId);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserSelectInitialByLName", par);
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

    public int DALUserProfilePhotoUpdate(UserRegistrationBLL ur)
    {
        int rowNo;
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrProfilePhoto", ur.usrProfilePhoto);
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                rowNo = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUserProfilePhotoUpdate", par);
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
        return rowNo;
    }

    //public DataTable DALUserLoginDetailsByUserId(UIUserRegistrationBLL urb)
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {

    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[3];
    //            par[0] = new SqlParameter("@usrFirstName", urb.usrFirstName);
    //            par[1] = new SqlParameter("@usrLastName", urb.usrLastName);
    //            par[2] = new SqlParameter("@status", 11);
    //            par[2].Direction = ParameterDirection.Output;
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserLoginDetailsByUserId", par);

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
    //    return ds.Tables[0];
    //}

    public int DALUserRegistrationTermConditionCheck(UserRegistrationBLL ur)
    {
        int checkTermCond = 0;


        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@Status", 11);
                par[1].Direction = ParameterDirection.Output;

                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spUserRegistrationTermConditionCheck", par))
                {
                    while (dr.Read())
                    {

                        checkTermCond = Convert.ToInt32(Convert.ToString(dr["usrTermCond"]));
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
        return checkTermCond;
    }

    //public int DALUserRegistrationUpdateTermCond(UIUserRegistrationBLL ur)
    //{
    //    int rowNo;
    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[3];
    //            par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
    //            par[1] = new SqlParameter("@usrTermCond", ur.usrTermCond);
    //            par[2] = new SqlParameter("@Status", 11);
    //            par[2].Direction = ParameterDirection.Output;

    //            rowNo = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUserRegistrationTermCondUpdate", par);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }

    //    }
    //    return rowNo;
    //}

    public DataSet  DALShowUserContactInfo(UserRegistrationBLL urb)
    {
        List<UserRegistrationBLL> urList = new List<UserRegistrationBLL>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@usrUserId", urb.usrUserId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetUserInfoById", par);

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

    public DataSet DALGetIdPassword(UserRegistrationBLL ur)
    {
       
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetUserIdPasswordbyNo", par);
            }
            catch (Exception ex)
            { }
        }
        return ds;

    }

    //public DataTable DALShowUserProfessionalInfo(UIUserRegistrationBLL urb)
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[2];
    //            par[0] = new SqlParameter("@usrUserId", urb.usrUserId);

    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserProfessionalInfoSelectById", par);

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
    //    return ds.Tables[0];
    //}

    //public DataTable DALShowUserSocialInfo(UIUserRegistrationBLL urb)
    //{
    //    List<UIUserRegistrationBLL> urList = new List<UIUserRegistrationBLL>();

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {

    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[1];
    //            par[0] = new SqlParameter("@usrUserId", urb.usrUserId);

    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserSocialInfoSelectById", par);

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
    //    return ds.Tables[0];
    //}

    public int DALUserPasswordChange(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrOldPassword", ur.usrPassword);
                par[2] = new SqlParameter("@usrNewPassword", ur.usrChangePassword);
                par[3] = new SqlParameter("@Status", 4);
                par[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegistrationChangePassword", par);
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

    public int DALInsertUserFriendRelative(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[6];

                par[0] = new SqlParameter("@frnrelUserId", ur.frnrelUserId);
                par[1] = new SqlParameter("@frnrelFriendId", ur.frnrelFriendId);
                par[2] = new SqlParameter("@frnrelFrnRelName", ur.frnrelFrnRelName);
                par[3] = new SqlParameter("@frnrelRelation", ur.frnrelRelation);
                par[4] = new SqlParameter("@frnrelGroup", ur.JoinFlagProp );
                par[5] = new SqlParameter("@Status", 11);
                par[5].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelationInsert", par);
                status = (int)par[5].Value;
                DALInsertUserFriendRelativeAlt(ur.frnrelFriendId, ur.frnrelUserId, ur.frnrelFrnRelName, ur.frnrelRelation, ur.frnrelGroup);
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
    public int DALInsertUserFriendRelative1(UserRegistrationBLL ur,string frrelaio)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[6];

                par[0] = new SqlParameter("@frnrelUserId", ur.frnrelUserId);
                par[1] = new SqlParameter("@frnrelFriendId", ur.frnrelFriendId);
                par[2] = new SqlParameter("@frnrelFrnRelName", ur.frnrelFrnRelName);
                par[3] = new SqlParameter("@frnrelRelation", ur.frnrelRelation);
                par[4] = new SqlParameter("@frnrelGroup", ur.JoinFlagProp);
                par[5] = new SqlParameter("@Status", 11);
                par[5].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelationInsert", par);
                status = (int)par[5].Value;
                DALInsertUserFriendRelativeAlt(ur.frnrelFriendId, ur.frnrelUserId, ur.frnrelFrnRelName, ur.frnrelRelation, ur.frnrelGroup);
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

    public int DALInsertUserFriendRelativeAlt(string fuid,string frid,string  frnm,string rel,string gr)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[6];

                par[0] = new SqlParameter("@frnrelUserId", fuid);
                par[1] = new SqlParameter("@frnrelFriendId", frid);
                par[2] = new SqlParameter("@frnrelFrnRelName", frnm);
                par[3] = new SqlParameter("@frnrelRelation", rel);
                par[4] = new SqlParameter("@frnrelGroup", gr);
                par[5] = new SqlParameter("@Status", 11);
                par[5].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelationInsert", par);
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

    public int DALInsertUserFriendRelativeByLongCode(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[6];

                par[0] = new SqlParameter("@frnrelUserId", ur.usrMobileNo);
                par[1] = new SqlParameter("@frnrelFriendId", ur.frnrelFriendId);
                par[2] = new SqlParameter("@frnrelFrnRelName", ur.frnrelFrnRelName);
                par[3] = new SqlParameter("@frnrelRelation", ur.frnrelRelation);
                par[4] = new SqlParameter("@frnrelGroup", ur.frnrelGroup);
                par[5] = new SqlParameter("@Status", 11);
                par[5].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelationInsertByLongCode", par);
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

    //public int DALIsExistFriendRelative(UIUserRegistrationBLL ur)
    //{

    //    using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
    //    {
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[3];
    //            par[0] = new SqlParameter("@userId", ur.frnrelUserId);
    //            par[1] = new SqlParameter("@friendId", ur.frnrelFriendId);
    //            par[2] = new SqlParameter("@Status", 11);
    //            par[2].Direction = ParameterDirection.Output;

    //            Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "spFriendRelativeIsExist", par));
    //            status = (int)par[2].Value;
    //        }
    //        catch (Exception ex)
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

    public DataTable DALSelectAllFriendGroup(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GroupSelectbyuser",par);

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
    public DataTable DALGroup(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select GroupId,GroupName from usermaster where usrUserId='" + ur.usrUserId + "' ";
                ds = cc.ExecuteDataset(sql);


            }
            catch { }
            finally
            {
                con.Close();
            }
        }
        return ds.Tables[0];
    }

    public DataTable DALFriendRelativeSelectByMobileNo(UserRegistrationBLL urb)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrAltMobileNo", urb.usrAltMobileNo);
                par[1] = new SqlParameter("@usrMobileNo", urb.usrMobileNo);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "FriendRelativeSelectByMobileNo", par);

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


    public DataSet DALFriendRelativeShowAllById(UserRegistrationBLL urb)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@userId", urb.frnrelUserId);
                par[1] = new SqlParameter("@FriRelId", urb.frnrelFriendId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_FriendRelativeShowAllById", par);
                con.Close();
               

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

    public DataSet DALFriendRelativeSearchAllById(UserRegistrationBLL urb)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@userId", urb.usrUserId);
                par[1] = new SqlParameter("@FirstName", urb.usrFirstName);
                par[2] = new SqlParameter("@LastName", urb.usrLastName);
                par[3] = new SqlParameter("@MobileNo", urb.usrMobileNo);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_FetchFriendByNameMobileNo", par);
                con.Close();
                //try
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        string FriRelId = Convert.ToString(dr["FriRelId"]);
                //        string sql = "SELECT     FriendGroupMaster.friendGroupName as Name " +
                //   " FROM         FriendGroupRelation INNER JOIN  FriendGroupMaster ON " +
                //   " FriendGroupRelation.GroupId = FriendGroupMaster.friendGroupId where RelId=" + FriRelId + "";
                //        DataSet ds1 = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
                //        string Data = "";

                //        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                //        {
                //            Data = Data + ", " + Convert.ToString(dr1["Name"]);
                //        }
                //        if (Data.Length > 0)
                //        {
                //            Data = Data.Substring(1);
                //        }
                //        dr["FriRel"] = Data;
                //    }
                //}
                //catch { }

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
    //public DataTable DALFriendRelativeShowAllByName(UserRegistrationBLL urb)
    //{


    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {

    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[3];
    //            par[0] = new SqlParameter("@userId", urb.usrUserId);
    //            par[1] = new SqlParameter("@usrFirstName", urb.usrFirstName);
    //            par[2] = new SqlParameter("@usrLastName", urb.usrLastName);
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "FriendRelativeShowAllByName", par);
    //            con.Close();
    //            try
    //            {
    //                foreach (DataRow dr in ds.Tables[0].Rows)
    //                {
    //                    string FriRelId = Convert.ToString(dr["FriRelId"]);
    //                    string sql = "SELECT     FriendGroupMaster.friendGroupName as Name " +
    //               " FROM         FriendGroupRelation INNER JOIN  FriendGroupMaster ON " +
    //               " FriendGroupRelation.GroupId = FriendGroupMaster.friendGroupId where RelId=" + FriRelId + "";
    //                    DataSet ds1 = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
    //                    string Data = "";
    //                    foreach (DataRow dr1 in ds1.Tables[0].Rows)
    //                    {
    //                        Data = Data + ", " + Convert.ToString(dr1["Name"]);
    //                    }
    //                    if (Data.Length > 0)
    //                    {
    //                        Data = Data.Substring(1);
    //                    }
    //                    dr["FriRel"] = Data;
    //                }
    //            }
    //            catch { }

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
    //    return ds.Tables[0];
    //}

    public int DALFriendRelativeRemove(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@userId", ur.frnrelUserId);
                par[1] = new SqlParameter("@friendId", ur.frnrelFriendId);
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelativeRemove", par);
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

    //public int DALFriendRelativeRelationUpdate(UIUserRegistrationBLL ur)
    //{

    //    using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
    //    {
    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[5];
    //            par[0] = new SqlParameter("@userId", ur.frnrelUserId);
    //            par[1] = new SqlParameter("@friendId", ur.frnrelFriendId);
    //            par[2] = new SqlParameter("@relation", ur.frnrelRelation);
    //            par[3] = new SqlParameter("@group", ur.frnrelGroup);
    //            par[4] = new SqlParameter("@Status", 11);
    //            par[4].Direction = ParameterDirection.Output;

    //            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spFriendRelativeRelationUpdate", par);
    //            status = (int)par[4].Value;
    //        }
    //        catch (Exception ex)
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

    public int DALFriendRelativeIsViewProfile(UserRegistrationBLL ur)
    {

        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@userId", ur.frnrelUserId);
                par[1] = new SqlParameter("@friendId", ur.frnrelFriendId);
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "FriendRelativeIsViewProfile", par));
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

    public DataTable DALUserRecentVisitorShowId(string usrUserId)
    {


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@usrUserId", usrUserId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserRecentVisitorIdSelect", par);


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

    public int DALUserRecentVisitorUpdate(UserRegistrationBLL ur)
    {
        int rowNo;
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
                par[1] = new SqlParameter("@usrGuestId", ur.usrRecentVisitor);
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                rowNo = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRecentVisitorUpdate", par);
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
        return rowNo;
    }

    //public DataTable DALShowUserRcentVisitorName(UIUserRegistrationBLL urb)
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {

    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[2];
    //            par[0] = new SqlParameter("@usrUserId", urb.usrUserId);
    //            par[1] = new SqlParameter("@status", 11);
    //            par[1].Direction = ParameterDirection.Output;
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserRecentVisitorNameSelect", par);
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
    //    return ds.Tables[0];
    //}

    public void DALUserRegistrationPasswordRecovery(string usrMobileNo, out DataTable dtPasswordDetail, out int status)
    {
        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@usrMobileNo", usrMobileNo);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserRegistrationPasswordRecovery", par);

                status = (int)par[1].Value;
                dtPasswordDetail = ds.Tables[0];

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

    }

    public DataSet  DALUserQualificationIndustriesShow()
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
               // ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserQualificationIndustriesSelect");
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserQualificationIndustriesSelect");

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

    //public DataTable DALUserProfessionShow()
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserProfessionSelect");

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
    //    return ds.Tables[0];
    //}

    //public DataTable DALUserSocialMembershipShow()
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserSocialMembershipSelect");

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
    //    return ds.Tables[0];
    //}

    //public DataTable DALUserPoliticalMembershipShow()
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserPoliticalMembershipSelect");

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
    //    return ds.Tables[0];
    //}

    //public DataTable DALUserIndustryShow()
    //{
    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserIndustrySelect");

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
    //    return ds.Tables[0];
    //}

    //public DataTable DALUserAreaShow()
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserAreaSelect");
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
    //    return ds.Tables[0];
    //}

    //public DataTable DALUserSocialMembership()
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
    //    {
    //        try
    //        {
    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserAreaSelect");
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
    //    return ds.Tables[0];
    //}

    public void DALUserMembershipSocialInsert(UserRegistrationBLL ur, out int id, out int status)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];

                par[0] = new SqlParameter("@membershipSocialName", ur.usrMembershipSocialText);
                par[1] = new SqlParameter("@id", 1);
                par[1].Direction = ParameterDirection.Output;
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserMembershipSocialInsert", par);
                id = (int)par[1].Value;
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

    }

    public void DALUserMembershipPoliticalInsert(UserRegistrationBLL ur, out int id, out int status)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];

                par[0] = new SqlParameter("@membershipPoliticalName", ur.usrMembershipPoliticalText);
                par[1] = new SqlParameter("@id", 1);
                par[1].Direction = ParameterDirection.Output;
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserMembershipPoliticalInsert", par);
                id = (int)par[1].Value;
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

    }

    public void DALUserAreaInsert(UserRegistrationBLL ur, out int id, out int status)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];

                par[0] = new SqlParameter("@userAreaName", ur.usrArea);
                par[1] = new SqlParameter("@userCityId", ur.usrCityId);
                par[2] = new SqlParameter("@id", 1);
                par[2].Direction = ParameterDirection.Output;
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserAreaInsert", par);
                id = (int)par[2].Value;
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

    }

    public DataTable DALUserMobileSelectById(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@usrUserId", ur.usrUserId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UserRegistrationMobileSelectById", par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return ds.Tables[0];
    }

    public int DALUserRegistrationMobileNoUpdate(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@userId", ur.usrUserId);
                par[1] = new SqlParameter("@userMobileNo", ur.usrMobileNo);
                par[2] = new SqlParameter("@userPassword", ur.usrPassword);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserRegisteredMobileNoUpdate", par);
                status = (int)par[3].Value;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }

    public void DALUserBoardUniversityInsert(UserRegistrationBLL ur, out int id, out int status)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];

                par[0] = new SqlParameter("@brduniName", ur.usrBoardUniversityName);
                par[1] = new SqlParameter("@id", 1);
                par[1].Direction = ParameterDirection.Output;
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserBoardUniversityInsert", par);
                id = (int)par[1].Value;
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

    }

    public void DALUserProfessionInsert(UserRegistrationBLL ur, out int id, out int status)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];

                par[0] = new SqlParameter("@professionName", ur.usrProfessionName);
                par[1] = new SqlParameter("@id", 1);
                par[1].Direction = ParameterDirection.Output;
                par[2] = new SqlParameter("@Status", 11);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "UserProfessionInsert", par);
                id = (int)par[1].Value;
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

    }

    public int DALUpdateUserNameByLongCode(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@FName", ur.usrFirstName);
                par[2] = new SqlParameter("@LName", ur.usrLastName);
                par[3] = new SqlParameter("@status", 1);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUpdateUserNameByLongCode", par);
                status = (int)par[3].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }

    public int DALUpdateFirstNameByLongCode(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@FName", ur.usrFirstName);
                par[2] = new SqlParameter("@status", 1);
                par[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUpdateFirstNameByLongCode", par);
                status = (int)par[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }

    public int DALChangeMobileNoByLongCode(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@AltMobileNo", ur.usrAltMobileNo);
                par[2] = new SqlParameter("@password", ur.usrPassword);
                par[3] = new SqlParameter("@status", 1);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spChangeMobileNoByLongCode", par);
                status = (int)par[3].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }

    public int DALUpdateUserAddressByLongCode(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@Address", ur.usrAddress);
                par[2] = new SqlParameter("@status", 1);
                par[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUpdateUserAddressByLongCode", par);
                status = (int)par[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }

    public int DALUpdateAreaByLongCode(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@Area", ur.usrArea);
                par[2] = new SqlParameter("@status", 1);
                par[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUpdateUserAreaByLongCode", par);
                status = (int)par[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }
 
    public int DALUpdatePinByLongCode(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@Pin", ur.usrPIN );
                par[2] = new SqlParameter("@status", 1);
                par[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUpdateUserAreaByLongCode", par);
                status = (int)par[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }
    public int DALUpdatePinByLongCodePIN(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@Pin",Convert .ToString ( ur.usrPIN));
                par[2] = new SqlParameter("@cid", Convert.ToInt32(ur.usrCityId));
                par[3] = new SqlParameter("@status", 1);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUpdateUserAreaPinByLongCodePIN", par);
                status = (int)par[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }

    public int DALSendMessageToAllByLongCode(UserRegistrationBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@MobileNo", ur.usrMobileNo);
                par[1] = new SqlParameter("@Message", ur.frnrelSendMsg);
                par[2] = new SqlParameter("@status", 1);
                par[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spSendMessageToAllByLongCode", par);
                status = (int)par[2].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return status;
    }

    public List<UserRegistrationBLL> GetUsrFamInfoFun(UserRegistrationBLL ooo)
    {
        List<UserRegistrationBLL> ListObj = new List<UserRegistrationBLL>();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlDataReader dr;
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@usrUserId", ooo.usrUserId);
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspGetFamInfo", par);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserRegistrationBLL lstObj = new UserRegistrationBLL();
                        lstObj.usrFIlfptr = Convert.ToString(dr["usrFIlfptr"]);
                        lstObj.usrFIname1 = Convert.ToString(dr["usrFIname1"]);
                        lstObj.usrFIname2 = Convert.ToString(dr["usrFIname2"]);
                        lstObj.usrFIname3 = Convert.ToString(dr["usrFIname3"]);
                        lstObj.usrFIgender1 = Convert.ToString(dr["usrFIgender1"]);
                        lstObj.usrFIgender2 = Convert.ToString(dr["usrFIgender2"]);
                        lstObj.usrFIgender3 = Convert.ToString(dr["usrFIgender3"]);
                        lstObj.usrFIschool1 = Convert.ToString(dr["usrFIschool1"]);
                        lstObj.usrFIschool2 = Convert.ToString(dr["usrFIschool2"]);
                        lstObj.usrFIschool3 = Convert.ToString(dr["usrFIschool3"]);
                        lstObj.usrFIclass1 = Convert.ToString(dr["usrFIclass1"]);
                        lstObj.usrFIclass2 = Convert.ToString(dr["usrFIclass2"]);
                        lstObj.usrFIclass3 = Convert.ToString(dr["usrFIclass3"]);
                        lstObj.usrFIrollNo1 = Convert.ToString(dr["usrFIrollNo1"]);
                        lstObj.usrFIrollNo2 = Convert.ToString(dr["usrFIrollNo2"]);
                        lstObj.usrFIrollNo3 = Convert.ToString(dr["usrFIrollNo3"]);
                        ListObj.Add(lstObj);
                    }
                
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        return ListObj;
    }


    public int UpdateFamilyInfo(UserRegistrationBLL obj1)
    {
        int i = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[17];
                par[0] = new SqlParameter("@lfpte", obj1 .usrFIlfptr );
                par[1] = new SqlParameter("@name1", obj1 .usrFIname1 );
                par[2] = new SqlParameter("@name2", obj1 .usrFIname2 );
                par[3] = new SqlParameter("@name3",obj1 .usrFIname3 );
                par[4] = new SqlParameter("@gender1", obj1.usrFIgender1);
                par[5] = new SqlParameter("@gender2", obj1.usrFIgender2);
                par[6] = new SqlParameter("@gender3", obj1.usrFIgender3);
                par[7] = new SqlParameter("@school1", obj1.usrFIschool1);
                par[8] = new SqlParameter("@school2", obj1.usrFIschool2);
                par[9] = new SqlParameter("@school3", obj1.usrFIschool3);
                par[10] = new SqlParameter("@class1", obj1.usrFIclass1);
                par[11] = new SqlParameter("@class2", obj1.usrFIclass2);
                par[12] = new SqlParameter("@class3", obj1.usrFIclass3);
                par[13] = new SqlParameter("@rno1", obj1.usrFIrollNo1);
                par[14] = new SqlParameter("@rno2", obj1.usrFIrollNo2);
                par[15] = new SqlParameter("@rno3", obj1.usrFIrollNo3);
                par[16] = new SqlParameter("@user",obj1 .usrUserId );
                i = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspUpdateFamilyinfo", par);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        return i;
    }


    public int InsertFamilyInfo(UserRegistrationBLL obj1)
    {
        int i = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[17];
                par[0] = new SqlParameter("@lfpte", obj1.usrFIlfptr);
                par[1] = new SqlParameter("@name1", obj1.usrFIname1);
                par[2] = new SqlParameter("@name2", obj1.usrFIname2);
                par[3] = new SqlParameter("@name3", obj1.usrFIname3);
                par[4] = new SqlParameter("@gender1", obj1.usrFIgender1);
                par[5] = new SqlParameter("@gender2", obj1.usrFIgender2);
                par[6] = new SqlParameter("@gender3", obj1.usrFIgender3);
                par[7] = new SqlParameter("@school1", obj1.usrFIschool1);
                par[8] = new SqlParameter("@school2", obj1.usrFIschool2);
                par[9] = new SqlParameter("@school3", obj1.usrFIschool3);
                par[10] = new SqlParameter("@class1", obj1.usrFIclass1);
                par[11] = new SqlParameter("@class2", obj1.usrFIclass2);
                par[12] = new SqlParameter("@class3", obj1.usrFIclass3);
                par[13] = new SqlParameter("@rno1", obj1.usrFIrollNo1);
                par[14] = new SqlParameter("@rno2", obj1.usrFIrollNo2);
                par[15] = new SqlParameter("@rno3", obj1.usrFIrollNo3);
                par[16] = new SqlParameter("@user", obj1.usrUserId);
                i = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "uspInsertFamilyinfo", par);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        return i;
    }
    //public DataTable DALShowUserInfoForSMS(UIUserRegistrationBLL urb)
    //{
       

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {

    //        try
    //        {
    //            SqlParameter[] par = new SqlParameter[1];
    //            par[0] = new SqlParameter("@usrUserId", urb.frnrelFriendId);

    //            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spUserInfoForSMSSelect", par);

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
    //    return ds.Tables[0];
    //}

}
