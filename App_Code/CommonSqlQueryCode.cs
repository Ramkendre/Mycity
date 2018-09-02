using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

public class CommonSqlQueryCode
{
    int status;
    //App_Code.Connection scon = new Connection();
    CommonCode ccr = new CommonCode();
    private string _usrPasssword;
    private string _usrMobileNo;
    private string _usrAltMobileNo;
    private string _usrFirstName;
    private string _usrMiddleName;
    private string _usrLastName;
    private int _usrCityId;
    private string _usrCityName;
    private string _usrUserId;
    private string _usrAddress;
    private string _usrGender;
    private string _usrPIN;
    private string _usrDOB;
    private string _FaxNo;
    private string _usrPhoneNo;
    private string _OfficeNo;
    private string _usrEmailId;
    private int _usrDistrictId;
    private int _usrStateId;

    private string _frnrelGroup;
    private string _frnrelRelation;
    private string _frnrelFrnRelName;
    private string _frnrelFriendId;
    private string _frnrelUserId;
    private string _senderid;

    public string Senderid
    {
        get { return _senderid; }
        set { _senderid = value; }
    }

    public string usrUserId
    {
        get { return _usrUserId; }
        set { _usrUserId = value; }
    }
    public string usrPasssword
    {
        get { return _usrPasssword; }
        set { _usrPasssword = value; }
    }
    public string usrMiddleName
    {
        get { return _usrMiddleName; }
        set { _usrMiddleName = value; }
    }
    public string usrAddress
    {
        get { return _usrAddress; }
        set { _usrAddress = value; }
    }
    public int usrStateId
    {
        get { return _usrStateId; }
        set { _usrStateId = value; }
    }
    public int usrDistrictId
    {
        get { return _usrDistrictId; }
        set { _usrDistrictId = value; }
    }
    public string usrGender
    {
        get { return _usrGender; }
        set { _usrGender = value; }
    }
    public string usrEmailId
    {
        get { return _usrEmailId; }
        set { _usrEmailId = value; }
    }
    public string FaxNo
    {
        get { return _FaxNo; }
        set { _FaxNo = value; }
    }
    public string usrPhoneNo
    {
        get { return _usrPhoneNo; }
        set { _usrPhoneNo = value; }
    }
    public string OfficeNo
    {
        get { return _OfficeNo; }
        set { _OfficeNo = value; }
    }
    public string usrMobileNo
    {
        get { return _usrMobileNo; }
        set { _usrMobileNo = value; }

    }
    public string usrDOB
    {
        get { return _usrDOB; }
        set { _usrDOB = value; }
    }
    public string usrPIN
    {
        get { return _usrPIN; }
        set { _usrPIN = value; }

    }
    public string usrAltMobileNo
    {
        get { return _usrAltMobileNo; }
        set { _usrAltMobileNo = value; }
    }
    public string usrFirstName
    {
        get { return _usrFirstName; }
        set { _usrFirstName = value; }
    }
    public string usrLastName
    {
        get { return _usrLastName; }
        set { _usrLastName = value; }

    }
    public int usrCityId
    {
        get { return _usrCityId; }
        set { _usrCityId = value; }
    }
    public string usrCityName
    {
        get { return _usrCityName; }
        set { _usrCityName = value; }
    }
    public string frnrelUserId
    {
        get { return _frnrelUserId; }
        set { _frnrelUserId = value; }
    }
    public string frnrelFriendId
    {
        get { return _frnrelFriendId; }
        set { _frnrelFriendId = value; }
    }
    public string frnrelFrnRelName
    {
        get { return _frnrelFrnRelName; }
        set { _frnrelFrnRelName = value; }
    }
    public string frnrelRelation
    {
        get { return _frnrelRelation; }
        set { _frnrelRelation = value; }
    }
    public string frnrelGroup
    {
        get { return _frnrelGroup; }
        set { _frnrelGroup = value; }
    }

    private string _FriRelId;

    public string FriRelId
    {
        get { return _FriRelId; }
        set { _FriRelId = value; }
    }

    private string _FR1;

    public string FR1
    {
        get { return _FR1; }
        set { _FR1 = value; }
    }
    private string _FR2;

    public string FR2
    {
        get { return _FR2; }
        set { _FR2 = value; }
    }
    private string _FR3;

    public string FR3
    {
        get { return _FR3; }
        set { _FR3 = value; }
    }
    private string _FR4;

    public string FR4
    {
        get { return _FR4; }
        set { _FR4 = value; }
    }
    private string _FR5;

    public string FR5
    {
        get { return _FR5; }
        set { _FR5 = value; }
    }
    private string _FR6;

    public string FR6
    {
        get { return _FR6; }
        set { _FR6 = value; }
    }
    private string _FR7;

    public string FR7
    {
        get { return _FR7; }
        set { _FR7 = value; }
    }
    private string _FR8;

    public string FR8
    {
        get { return _FR8; }
        set { _FR8 = value; }
    }
    private string _FR9;

    public string FR9
    {
        get { return _FR9; }
        set { _FR9 = value; }
    }
    private string _FR10;

    public string FR10
    {
        get { return _FR10; }
        set { _FR10 = value; }
    }
    private string _FR11;

    public string FR11
    {
        get { return _FR11; }
        set { _FR11 = value; }
    }
    private string _FR12;

    public string FR12
    {
        get { return _FR12; }
        set { _FR12 = value; }
    }
    private string _FR13;

    public string FR13
    {
        get { return _FR13; }
        set { _FR13 = value; }
    }
    private string _FR14;

    public string FR14
    {
        get { return _FR14; }
        set { _FR14 = value; }
    }
    private string _FR15;

    public string FR15
    {
        get { return _FR15; }
        set { _FR15 = value; }
    }
    private string _FR16;

    public string FR16
    {
        get { return _FR16; }
        set { _FR16 = value; }
    }
    private string _FR17;

    public string FR17
    {
        get { return _FR17; }
        set { _FR17 = value; }
    }
    private string _FR18;

    public string FR18
    {
        get { return _FR18; }
        set { _FR18 = value; }
    }
    private string _FR19;

    public string FR19
    {
        get { return _FR19; }
        set { _FR19 = value; }
    }
    private string _FR20;

    public string FR20
    {
        get { return _FR20; }
        set { _FR20 = value; }
    }
    private string _FR21;

    public string FR21
    {
        get { return _FR21; }
        set { _FR21 = value; }
    }
    private string _FR22;

    public string FR22
    {
        get { return _FR22; }
        set { _FR22 = value; }
    }
    private string _FR23;

    public string FR23
    {
        get { return _FR23; }
        set { _FR23 = value; }
    }
    private string _FR24;

    public string FR24
    {
        get { return _FR24; }
        set { _FR24 = value; }
    }
    private string _FR25;

    public string FR25
    {
        get { return _FR25; }
        set { _FR25 = value; }
    }
    private string _FR26;

    public string FR26
    {
        get { return _FR26; }
        set { _FR26 = value; }
    }
    private string _FR27;

    public string FR27
    {
        get { return _FR27; }
        set { _FR27 = value; }
    }
    private string _FR28;

    public string FR28
    {
        get { return _FR28; }
        set { _FR28 = value; }
    }
    private string _FR29;

    public string FR29
    {
        get { return _FR29; }
        set { _FR29 = value; }
    }
    private string _FR30;

    public string FR30
    {
        get { return _FR30; }
        set { _FR30 = value; }
    }
    private string _frnrelPrefix;
    public string FrnrelPrefix
    {
        get { return _frnrelPrefix; }
        set { _frnrelPrefix = value; }
    }
    private string _frnrelinfix;

    public string Frnrelinfix
    {
        get { return _frnrelinfix; }
        set { _frnrelinfix = value; }
    }
    private string _frnrelpostfix;

    public string Frnrelpostfix
    {
        get { return _frnrelpostfix; }
        set { _frnrelpostfix = value; }
    }


    public int BLLTestUserFriendRelative(CommonSqlQueryCode ur)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int flag = 0;
        try
        {
                      
            string sql = "select FriRelId from friendRelationmaster where Userid='" + ur.frnrelUserId + "'and FriendId='" + ur.frnrelFriendId + "'";
            string newflag = ccr.ExecuteScalar(sql);
            if (newflag.ToString() != "")
                flag = Convert.ToInt32(ccr.ExecuteScalar(sql));

            if (flag > 0)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
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

    



    public int BLLInsertUserFriendRelative(CommonSqlQueryCode ur)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int flag;
        try
        {


            string sql = "  insert into FriendRelationMaster(UserId,FriendId,FriRelName,Relation,friendGroup,FriendPrefix,senderid,FR1,FR2," +
              "FR3,FR4,FR5,FR6,FR7,FR8,FR9,FR10,FR11,FR12,FR13,FR14,FR15,FR16,FR17,FR18," +
              " FR19,FR20,FR21,FR22,FR23,FR24,FR25,FR26,FR27,FR28,FR29,FR30) " +
              "values('" + ur.frnrelUserId + "','" + ur.frnrelFriendId + "',N'" + ur.usrFirstName + "" + ur.usrLastName + "',N'" + ur.frnrelRelation + "',N'" + ur.frnrelGroup + "','" + ur.FrnrelPrefix + "','" + ur.Senderid + "'," +
              "N'" + ur.FR1 + "',N'" + ur.FR2 + "',N'" + ur.FR3 + "',N'" + ur.FR4 + "',N'" + ur.FR5 + "',N'" + ur.FR6 + "',N'" + ur.FR7 + "',N'" + ur.FR8 + "'," +
              "N'" + ur.FR9 + "',N'" + ur.FR10 + "',N'" + ur.FR11 + "',N'" + ur.FR12 + "',N'" + ur.FR13 + "',N'" + ur.FR14 + "'," +
              "N'" + ur.FR15 + "',N'" + ur.FR16 + "',N'" + ur.FR17 + "',N'" + ur.FR18 + "',N'" + ur.FR19 + "',N'" + ur.FR20 + "',N'" + ur.FR21 + "'," +
              "N'" + ur.FR22 + "',N'" + ur.FR23 + "',N'" + ur.FR24 + "',N'" + ur.FR25 + "',N'" + ur.FR26 + "',N'" + ur.FR27 + "'," +
              "N'" + ur.FR28 + "',N'" + ur.FR29 + "',N'" + ur.FR30 + "')";




            flag = ccr.ExecuteNonQuery(sql);
            if (flag == 1)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
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

    public int BLLUpdateUserFriendRelative(CommonSqlQueryCode ur)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int flag;
        try
        {

            string sql = "update FriendRelationMaster set FR1='" + ur.FR1 + "',FR2='" + ur.FR2 + "'," +
                  "FR3='" + ur.FR3 + "',FR4='" + ur.FR4 + "',FR5='" + ur.FR5 + "',FR6='" + FR6 + "',FR7='" + ur.FR7 + "',FR8='" + ur.FR8 + "',FR9='" + ur.FR9 + "',FR10='" + ur.FR10 + "'," +
                  "FR11='" + ur.FR11 + "',FR12='" + ur.FR12 + "',FR13='" + ur.FR13 + "',FR14='" + ur.FR14 + "',FR15='" + ur.FR15 + "'," +
                  "FR16='" + ur.FR16 + "',FR17='" + ur.FR17 + "',FR18='" + ur.FR18 + "'," +
                  " FR19='" + ur.FR19 + "',FR20='" + ur.FR20 + "',FR21='" + ur.FR21 + "'," +
            "FR22='" + ur.FR22 + "',FR23='" + ur.FR23 + "',FR24='" + ur.FR24 + "',FR25='" + ur.FR25 + "',FR26='" + ur.FR26 + "',FR27='" + ur.FR27 + "',FR28='" + ur.FR28 + "',FR29='" + ur.FR29 + "',FR30='" + ur.FR30 + "'" +
            " where UserId='" + ur.frnrelUserId + "' and  FriendId='" + ur.frnrelFriendId + "' ";


            flag = ccr.ExecuteNonQuery(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return flag;

    }
    public int DALInsertUserFriendRelativeAlt(string fuid, string frid, string frnm, string rel, string gr)
    {
        int status = 0;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
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

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelationInsertNew", par);
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




    public int DALInsertUserRegistrationInitial(CommonSqlQueryCode ur)
    {
        SqlConnection cons2 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int status = 0;
        try
        {

            cons2.Open();
            //SqlParameter[] par = new SqlParameter[18];

            //par[0] = new SqlParameter("@usrUserId", ur.usrUserId);
            //par[1] = new SqlParameter("@usrMobileNo", ur.usrMobileNo);
            //par[2] = new SqlParameter("@usrAltMobileNo", ur.usrAltMobileNo);
            //par[3] = new SqlParameter("@usrAddress", ur.usrAddress);
            //par[4] = new SqlParameter("@usrPassword", ur.usrPasssword);
            //par[5] = new SqlParameter("@usrFirstName", ur.usrFirstName);
            //par[6] = new SqlParameter("@usrLastName", ur.usrLastName);
            //par[7] = new SqlParameter("@usrGender", ur.usrGender);
            //par[8] = new SqlParameter("@usrCityId", ur.usrCityId);
            //par[9] = new SqlParameter("@usrFriendGroup", ur.frnrelGroup);
            //par[10] = new SqlParameter("@usrPIN", ur.usrPIN);
            //par[11] = new SqlParameter("@usrDOB", ur.usrDOB);
            //par[12] = new SqlParameter("@FaxNo", ur.FaxNo);
            //par[13] = new SqlParameter("@usrPhoneNumber", ur.usrPhoneNo);
            //par[14] = new SqlParameter("@OfficeNo", ur.OfficeNo);
            //par[15] = new SqlParameter("@usrEmailId", ur.usrEmailId);
            //par[16] = new SqlParameter("@strDevId", "");
            //par[17] = new SqlParameter("@Status", 17);
            //par[17].Direction = ParameterDirection.Output;

            //SqlHelper.ExecuteNonQuery(cons2, CommandType.StoredProcedure, "UserRegistrationIntialInsert", par);
            //status = (int)par[17].Value;

            string str = "	insert into UserMaster(usrUserId,usrMobileNo,usrAddress,usrPassword,usrFirstName,usrLastName,usrCityId,usrGender,usrFriRelGroup)values('" + ur.usrUserId + "','" + ur.usrMobileNo + "',N'" + ur.usrAddress + "','" + ur.usrPasssword + "',N'" + ur.usrFirstName + "',N'" + ur.usrLastName + "','" + ur.usrCityId+ "','" + ur.usrGender + "','" + ur.frnrelGroup + "')";
            status = ccr.ExecuteNonQuery(str);


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cons2.Close();
        }


        return status;
    }
    public int BLLPrefixUpdate(CommonSqlQueryCode ur)
    {
        status = ur.DALuserPrefix(ur);
        return status;
    }
    public int DALuserPrefix(CommonSqlQueryCode ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[6];

                par[0] = new SqlParameter("@userId", ur.frnrelUserId);
                par[1] = new SqlParameter("@FriendPrefix", ur.FrnrelPrefix);
                par[2] = new SqlParameter("@FriendInfix", ur.Frnrelinfix);
                par[3] = new SqlParameter("@FriendPostfix", ur.Frnrelpostfix);
                par[4] = new SqlParameter("@FriRelId", ur.frnrelFriendId);
                par[5] = new SqlParameter("@status", 7);
                par[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelativePrefixUpdate", par);
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


    public int DALFriendRelationUpdatePrefix(CommonSqlQueryCode ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];

                par[0] = new SqlParameter("@frnrelUserId", ur.frnrelUserId);
                par[1] = new SqlParameter("@FriendPrefix", ur.FrnrelPrefix);
                par[2] = new SqlParameter("@frnrelFriendId", ur.frnrelFriendId);
                par[3] = new SqlParameter("@status", 7);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "FriendRelationUpdatePrefix", par);
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


}

