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
/// Summary description for KeywordDAL
/// </summary>
public class KeywordDAL
{
    int status;
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();
	public KeywordDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int DALKeywordInsert(KeywordBLL kwb)
    {
       
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
            {

                 try
                 {
                     SqlParameter[] par = new SqlParameter[12];
                     par[0] = new SqlParameter("@kNAme", kwb.keywordName);
                     par[1] = new SqlParameter("@kDescription", kwb.keywordDescription);
                     par[2] = new SqlParameter("@kResponse", kwb.responseMsg);
                     par[3] = new SqlParameter("@kValidity", kwb.validUpto);
                     par[4] = new SqlParameter("@kcreation", kwb.keywordCreationDate);
                     par[5] = new SqlParameter("@kActive", kwb.Active);
                     par[6] = new SqlParameter("@kGroupName", kwb.groupid);
                     par[7] = new SqlParameter("@kSubGroupName", kwb.SubGroupid);
                     par[8] = new SqlParameter("@email",kwb .Email );
                     par[9] = new SqlParameter("@EmailSub", kwb.keyEmailSub );
                     par[10] = new SqlParameter("@EmailBody", kwb.keyEmailBody );
                     par[11] = new SqlParameter("@status", 1);
                     par[11].Direction = ParameterDirection.Output;
                     SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spKeywordInsert", par);
                     status = (int)par[11].Value;
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
    public int DALMiscalKeywordInsert(KeywordBLL kwb)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[13];
                par[0] = new SqlParameter("@KeywordName", kwb.keywordName);
                par[1] = new SqlParameter("@KeywordDescription", kwb.keywordDescription);
                par[2] = new SqlParameter("@ResponseMessage", kwb.responseMsg);
                par[3] = new SqlParameter("@EmailAddress", kwb.Email);
                par[4] = new SqlParameter("@EmailSubject", kwb.keyEmailSub);
                par[5] = new SqlParameter("@creationDate", kwb.keywordCreationDate);
                par[6] = new SqlParameter("@IMEINO", kwb.IMEINO);
                par[7] = new SqlParameter("@simno", kwb.Simno);
                par[8] = new SqlParameter("@Fwdmobileno", kwb.Fwdmobileno);
                par[9] = new SqlParameter("@Keyword_status", kwb.Keywordstatus);
                par[10] = new SqlParameter("@keywordfor", kwb.Keywordfor);
                par[11] = new SqlParameter("@userid", kwb.Userid);
                par[12] = new SqlParameter("@status", 1);
                par[12].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MiscalKeywordInsert", par);
                status = (int)par[12].Value;
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
    public int DALMiscalKeywordinLongCodeInsert(KeywordBLL kwb)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "insert into KeywordDefinition(keywordName,keywordDescription,responseMsg,Active,keywordCreationDate,email,EmailSub)"+
                    " values('"+kwb.keywordName+"','"+kwb.keywordDescription+"','"+kwb.responseMsg+"',1,'"+System.DateTime.Now+"','"+kwb.Email+"','"+kwb.keyEmailSub+"')";
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


    public int DALMiscalKeywordUpdate(KeywordBLL kwb)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@ResponseMessage", kwb.responseMsg);
                par[1] = new SqlParameter("@Id", kwb.Id);
                par[2] = new SqlParameter("@status", 4);
                par[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "MiscalKeywordUpdate", par);
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

    public int DALKeywordIsExist(KeywordBLL KB)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@Kname", KB.keywordName);
                par[1] = new SqlParameter("@status", 1);
                par[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spKeywordNameIsExist", par);
                status = (int)par[1].Value;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }
    public int DALMiscalKeywordIsExist(KeywordBLL KB)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select keywordId from KeywordDefinition where KeywordName='"+KB.keywordName+"'";
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                    SqlParameter[] par = new SqlParameter[4];
                    par[0] = new SqlParameter("@KeywordName", KB.keywordName);
                    par[1] = new SqlParameter("@IMEINO", KB.IMEINO);
                    par[2] = new SqlParameter("@Sim_no", KB.Simno);
                    par[3] = new SqlParameter("@status", 5);
                    par[3].Direction = ParameterDirection.Output;
                    SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "MiscalKeywordNameIsExist", par);
                    status = (int)par[3].Value;
                }
                else
                {
                    status = 0;
                }
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }
    public DataTable DALKeywordSelectAll()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spKeywordSelectAll");

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
    public DataTable DALMiscalKeywordSelectAll(KeywordBLL KB)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@IMEINO", KB.IMEINO);
                par[1] = new SqlParameter("@Sim_no", KB.Simno);
               
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MiscalKeywordSelectAll",par);

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
    public DataTable DALMiscalKeywordSelectAll2(KeywordBLL KB)
    {
        DataSet ds;
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select PersonalLongCodeKeywords.Id,PersonalLongCodeKeywords.KeywordName,PersonalLongCodeKeywords.KeywordDescription,PersonalLongCodeKeywords.ResponseMessage,PersonalLongCodeKeywords.creationDate from PersonalLongCodeKeywords"+

                    " where PersonalLongCodeKeywords.IMEINO='"+KB.IMEINO+"' and PersonalLongCodeKeywords.simno='"+KB.Simno+"' and Keyword_status ='Active'";

                 ds = cc.ExecuteDataset(sql);

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
    public int DALKeywordUpdate(KeywordBLL kbll)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[10];
                par[0] = new SqlParameter("@KeywordName", kbll.keywordName);
                par[1] = new SqlParameter("@Description",kbll.keywordDescription);
                par[2] = new SqlParameter("@ResponseMsg",kbll.responseMsg);
                par[3] = new SqlParameter("@Active",kbll.Active);
               
                par[6] = new SqlParameter("@email",kbll .Email );
                par[7] = new SqlParameter("@EmailSub", kbll.keyEmailSub );
                par[8] = new SqlParameter("@EmailBody", kbll.keyEmailBody);
                par[9] = new SqlParameter("@status",5);
                par[9].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spKeywordUpdate", par);
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
    public int DALKeywordUpdateDeactive(KeywordBLL kbll)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "update PersonalLongCodekeywords set keyword_status='DeActive' where Id='" + kbll.Id + "'";
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
        }
        return status;
    }

    public DataTable DALSelectAllGroup()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spSelectAllGroup");

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

    public DataTable DALSelectSubGroupById(int GID)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[1];
                par[0] = new SqlParameter("@GroupId", GID);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spSelectSubGroupById",par);

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
