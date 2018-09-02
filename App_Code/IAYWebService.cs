using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Collections.Generic;
using Newtonsoft.Json;
/// <summary>
/// Summary description for IAYWebService
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class IAYWebService : System.Web.Services.WebService
{

    public IAYWebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    string sqlQuery = string.Empty;
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    private static JsonSerializerSettings theJsonSerializerSettings = new JsonSerializerSettings();
    #region INSERT RECORD IAY

    [WebMethod(Description = "INSERT IAY PERSONAL DETAILS")]
    public int InsertPersonalDetails(string beneficiaryMobNo, string firstName, string lastName, string aadharNo, string bankAccNo, string bankName, string ifscCode, string approvalDate, string state, string district, string block, string gramPanchayat, string village, string userMobNo, string usrDistrictId, string usrBlockId, string usrGrampanchayatId)
    {
        try
        {
            //string sql = "select [IAYP_Id] from [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] where [PBMobileNo]='"+ beneficiaryMobNo +"'";
            //DataSet ds = cc.ExecuteDataset(sql);
            //string iay_Id = Convert.ToString(ds.Tables[0].Rows[0]["IAYP_Id"]);
            //if(iay_Id != "" && iay_Id == null)
            //{
            //    string SQL = "UPDATE [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] SET [PBFirstName]='"+ firstName +"',[PBLastName]='"+ lastName +"',[PBAdharNo]='"+ aadharNo +"',[PBBankACNo]='"+ bankAccNo +"',[PBBankName]='"+ bankName +"',[PBIFSC_Code]='"+ ifscCode +"',[PBStateId]='"+ state +"',[PBDistrictId]='"+ district +"',[PBGramPanchayatId]='"+ gramPanchayat +"',[PBVillageId]='"+ village +"',[PBApprovalDt]='"+ approvalDate +"',[CreatedBy]='"+ userMobNo +"',[CreatedDate]='"+ System.DateTime.Now +"' where [IAYP_Id]='"+ iay_Id +"'";
            //     cc.ExecuteNonQuery(SQL);
            //}
            // else
            //{
            sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] ([PBMobileNo],[PBFirstName],[PBLastName],[PBAdharNo],[PBBankACNo],[PBBankName],[PBIFSC_Code],[PBStateId],[PBDistrictId],[PBBlockId],[PBCircled],[PBVillageId],[PBApprovalDt],[CreatedBy],[CreatedDate],[usrDistrictId],[usrBlockId],[usrGrampanchayatId]) " +
                       "VALUES ('" + beneficiaryMobNo + "','" + firstName + "','" + lastName + "','" + aadharNo + "','" + bankAccNo + "','" + bankName + "','" + ifscCode + "','" + state + "','" + district + "','" + block + "','" + gramPanchayat + "','" + village + "','" + approvalDate + "','" + userMobNo + "','" + System.DateTime.Now + "','" + usrDistrictId + "','" + usrBlockId + "','" + usrGrampanchayatId + "')";
            cc.ExecuteNonQuery(sqlQuery);
            return 1;
            //}
        }
        catch
        {
            return 0;
        }
    }

    [WebMethod(Description = "INSERT IAY ACCOUNT DETAILS")]
    public int InsertAccountDetails(string firstInstallDate, string firstInstallAmt, string secInstallDate, string secInstallAmt, string thirdInstallDate, string thirdInstalAmt, string userMobNo, string beneficiaryMobNo)
    {
        string iayP_Id = string.Empty;
        string FrstInstlmntDt = string.Empty;
        string SndInstlmntDt = string.Empty;
        DataSet ds = new DataSet();
        try
        {
            string sqlQuery1 = "SELECT [IAYP_Id] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] WHERE [PBMobileNo] = '" + beneficiaryMobNo + "'";
            ds = cc.ExecuteDataset(sqlQuery1);
            iayP_Id = Convert.ToString(ds.Tables[0].Rows[0]["IAYP_Id"]);

            string SqlQry = "SELECT [FirstInstallmentDt],[SecondInstallmentDt],[ThirdInstallmentDt] FROM  [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] WHERE [IAYP_Id]='" + iayP_Id + "'";
            ds = cc.ExecuteDataset(SqlQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                FrstInstlmntDt = Convert.ToString(ds.Tables[0].Rows[0]["FirstInstallmentDt"]);
                SndInstlmntDt = Convert.ToString(ds.Tables[0].Rows[0]["SecondInstallmentDt"]);
            }

            if (FrstInstlmntDt == "")
            {
                sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] ([FirstInstallmentRs],[FirstInstallmentDt],[SecondInstallmentRs],[SecondInstallmentDt],[ThirdInstallmentRs],[ThirdInstallmentDt],[IAYP_Id],[CreatedBy],[CreatedDate],[BeneficiaryMobileNo]) " +
                           "VALUES ('" + firstInstallAmt + "','" + firstInstallDate + "','" + secInstallAmt + "','" + secInstallDate + "','" + thirdInstalAmt + "','" + thirdInstallDate + "','" + iayP_Id + "','" + userMobNo + "','" + System.DateTime.Now + "','" + beneficiaryMobNo + "')";   //ds.Tables[0].Rows[0][0].ToString()
                cc.ExecuteNonQuery(sqlQuery);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (FrstInstlmntDt != "" && SndInstlmntDt == "")
                {
                    string SQL = "UPDATE [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] SET [SecondInstallmentRs]='" + secInstallAmt + "',[SecondInstallmentDt]='" + secInstallDate + "',[ThirdInstallmentRs]='" + thirdInstalAmt + "',[ThirdInstallmentDt]='" + thirdInstallDate + "',[CreatedBy]='" + userMobNo + "',[CreatedDate]='" + System.DateTime.Now + "' where [IAYP_Id]='" + iayP_Id + "'";
                    cc.ExecuteNonQuery(SQL);
                }
                else if (FrstInstlmntDt != "" && SndInstlmntDt != "")
                {
                    string SQL = "UPDATE [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] SET [ThirdInstallmentRs]='" + thirdInstalAmt + "',[ThirdInstallmentDt]='" + thirdInstallDate + "',[CreatedBy]='" + userMobNo + "',[CreatedDate]='" + System.DateTime.Now + "' where [IAYP_Id]='" + iayP_Id + "'";
                    cc.ExecuteNonQuery(SQL);
                }
            }

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] ([FirstInstallmentRs],[FirstInstallmentDt],[SecondInstallmentRs],[SecondInstallmentDt],[ThirdInstallmentRs],[ThirdInstallmentDt],[IAYP_Id],[CreatedBy],[CreatedDate],[BeneficiaryMobileNo]) " +
            //               "VALUES ('" + firstInstallAmt + "','" + firstInstallDate + "','" + secInstallAmt + "','" + secInstallDate + "','" + thirdInstalAmt + "','" + thirdInstallDate + "','" + iayP_Id + "','" + userMobNo + "','" + System.DateTime.Now + "','" + beneficiaryMobNo + "')";   //ds.Tables[0].Rows[0][0].ToString()
            //    cc.ExecuteNonQuery(sqlQuery);
            //}
        }
        catch
        {
            return 0;
        }
        return 1;
    }

    [WebMethod(Description = "INSERT IAY TECHNICAL DETAILS BY ASSISTANT ENGINEER")]
    public int InsertTechDetailsAssistJE(string assistantJEName, string layoutDate, string visitDate, string completionDate, string userMobNo, string beneficiaryMobNo)
    {
        DataSet ds = new DataSet();
        string iayP_Id = string.Empty;
        string iayA_Id = string.Empty;
        string LyoutAsstEngName = string.Empty; string LyoutDt = string.Empty;
        string AsstEngVstDt = string.Empty; string CmptcrtDt = string.Empty;
        try
        {
            string sqlQuery1 = "SELECT [IAYP_Id] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] WHERE [PBMobileNo] = '" + beneficiaryMobNo + "'";
            ds = cc.ExecuteDataset(sqlQuery1);
            iayP_Id = Convert.ToString(ds.Tables[0].Rows[0]["IAYP_Id"]);

            string SQL = "SELECT [Tech_LayoutAsstEngName],[Tech_LayoutDt],[Tech_DtAsstEngVisit],[Tech_CompleteCertDt] FROM [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData] WHERE [IAYP_Id]='" + iayP_Id + "'";
            ds = cc.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                LyoutAsstEngName = Convert.ToString(ds.Tables[0].Rows[0]["Tech_LayoutAsstEngName"]); LyoutDt = Convert.ToString(ds.Tables[0].Rows[0]["Tech_LayoutDt"]);
                AsstEngVstDt = Convert.ToString(ds.Tables[0].Rows[0]["Tech_DtAsstEngVisit"]); CmptcrtDt = Convert.ToString(ds.Tables[0].Rows[0]["Tech_CompleteCertDt"]);
            }

            if (LyoutDt == "")
            {
                sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData] ([Tech_LayoutAsstEngName],[Tech_LayoutDt],[Tech_DtAsstEngVisit],[Tech_CompleteCertDt],[IAYP_Id],[CreatedBy],[CreatedDate],[BeneficiaryMobileNo]) " +
                           "VALUES ('" + assistantJEName + "','" + layoutDate + "','" + visitDate + "','" + completionDate + "','" + iayP_Id + "','" + userMobNo + "','" + System.DateTime.Now + "','" + beneficiaryMobNo + "')";
                cc.ExecuteNonQuery(sqlQuery);
            }
            else if (LyoutDt != "" && AsstEngVstDt == "")
            {
                string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData] SET [Tech_DtAsstEngVisit]='" + visitDate + "',[Tech_CompleteCertDt]='" + completionDate + "' where [IAYP_Id]='" + iayP_Id + "'";
                cc.ExecuteNonQuery(SqlUpDate);
            }
            else if (AsstEngVstDt != "" && CmptcrtDt == "")
            {
                string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData] SET [Tech_CompleteCertDt]='" + completionDate + "' where [IAYP_Id]='" + iayP_Id + "'";
                cc.ExecuteNonQuery(SqlUpDate);
            }

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData] ([Tech_LayoutAsstEngName],[Tech_LayoutDt],[Tech_DtAsstEngVisit],[Tech_CompleteCertDt],[IAYP_Id],[CreatedBy],[CreatedDate],[BeneficiaryMobileNo]) " +
            //               "VALUES ('" + assistantJEName + "','" + layoutDate + "','" + visitDate + "','" + completionDate + "','" + ds.Tables[0].Rows[0][0].ToString() + "','" + userMobNo + "','" + System.DateTime.Now + "','" + beneficiaryMobNo + "')";
            //    cc.ExecuteNonQuery(sqlQuery);
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}
        }
        catch
        {
            return 0;
        }
        return 1;
    }

    [WebMethod(Description = "INSERT DETAILS BY GRAMSEVAK MUSTER AND WORK INFORMATION")]
    public int InsertGramSevakDetails(string dateWorkStart, string firstMusterDt, string firstMusterNo, string secMusterDt, string secMusterNo, string lentalWorkComDt, string thirdMusterDt, string thirdMusterNo, string forthMusterDt, string forthMusterNo, string workComDt, string userMobNo, string beneficiaryMobNo)
    {
        DataSet ds = new DataSet();
        string iayA_Id = string.Empty;

        string StartWkDt = string.Empty; string FrstMstrDt = string.Empty; string FrstMstrNo = string.Empty;
        string ScndMstrDt = string.Empty; string ScndMstrNo = string.Empty; string LntLvlWrkDt = string.Empty;
        string ThrdMstrDt = string.Empty; string ThrdMstrNo = string.Empty; string FrthMstrDt = string.Empty;
        string FrthMstrNo = string.Empty; string WrkCmptDt = string.Empty;
        try
        {
            string sqlQuery1 = "SELECT [IAYP_Id] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] WHERE [PBMobileNo] = '" + beneficiaryMobNo + "'";
            ds = cc.ExecuteDataset(sqlQuery1);
            iayA_Id = Convert.ToString(ds.Tables[0].Rows[0]["IAYP_Id"]);

            string SQL = "SELECT [WMI_DTotWS],[WMI_UpldFirstPhoto],[WMI_FirstMusterDt],[WMI_FirstMusterNo],[WMI_SecondMusterDt],[WMI_SecondMusterNo],[WMI_LWCompleteDt],[WMI_UpldSecondPhoto],[WMI_ThirdMusterDt],[WMI_ThirdMusterNo],[WMI_FourthMusterDt],[WMI_FourthMusterNo],[WMI_WCompleteDt] FROM [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo]  WHERE [IAYP_Id]='" + iayA_Id + "'";
            ds = cc.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                StartWkDt = Convert.ToString(ds.Tables[0].Rows[0]["WMI_DTotWS"]); FrstMstrDt = Convert.ToString(ds.Tables[0].Rows[0]["WMI_FirstMusterDt"]);
                FrstMstrNo = Convert.ToString(ds.Tables[0].Rows[0]["WMI_FirstMusterNo"]); ScndMstrDt = Convert.ToString(ds.Tables[0].Rows[0]["WMI_SecondMusterDt"]);
                ScndMstrNo = Convert.ToString(ds.Tables[0].Rows[0]["WMI_SecondMusterNo"]); LntLvlWrkDt = Convert.ToString(ds.Tables[0].Rows[0]["WMI_LWCompleteDt"]);
                ThrdMstrDt = Convert.ToString(ds.Tables[0].Rows[0]["WMI_ThirdMusterDt"]); ThrdMstrNo = Convert.ToString(ds.Tables[0].Rows[0]["WMI_ThirdMusterNo"]);
                FrthMstrDt = Convert.ToString(ds.Tables[0].Rows[0]["WMI_FourthMusterDt"]); FrthMstrNo = Convert.ToString(ds.Tables[0].Rows[0]["WMI_FourthMusterNo"]);
                WrkCmptDt = Convert.ToString(ds.Tables[0].Rows[0]["WMI_WCompleteDt"]);
            }

            if (StartWkDt == "")
            {
                sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] ([WMI_DTotWS],[WMI_FirstMusterDt],[WMI_FirstMusterNo],[WMI_SecondMusterDt],[WMI_SecondMusterNo],[WMI_LWCompleteDt],[WMI_ThirdMusterDt],[WMI_ThirdMusterNo],[WMI_FourthMusterDt],[WMI_FourthMusterNo],[WMI_WCompleteDt],[IAYP_Id],[CreatedBy],[CreatedDate]),[BeneficiaryMobileNo]) " +
                         "VALUES ('" + dateWorkStart + "','" + firstMusterDt + "','" + firstMusterNo + "','" + secMusterDt + "','" + secMusterNo + "','" + lentalWorkComDt + "','" + thirdMusterDt + "','" + thirdMusterNo + "','" + forthMusterDt + "','" + forthMusterNo + "','" + workComDt + "','" + iayA_Id + "','" + userMobNo + "','" + System.DateTime.Now + "','" + beneficiaryMobNo + "')";
                cc.ExecuteNonQuery(sqlQuery);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (StartWkDt != "" && FrstMstrDt == "" && FrstMstrNo == "")
                {
                    string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] SET [WMI_FirstMusterDt]='" + firstMusterDt + "',[WMI_FirstMusterNo]='" + firstMusterNo + "',[WMI_SecondMusterDt]='" + secMusterDt + "',[WMI_SecondMusterNo]='" + secMusterNo + "',[WMI_LWCompleteDt]='" + lentalWorkComDt + "',[WMI_ThirdMusterDt]='" + thirdMusterDt + "',[WMI_ThirdMusterNo]='" + thirdMusterNo + "',[WMI_FourthMusterDt]='" + forthMusterDt + "',[WMI_FourthMusterNo]='" + forthMusterNo + "',[WMI_WCompleteDt]='" + workComDt + "' where [IAYP_Id]='" + iayA_Id + "'";
                    cc.ExecuteNonQuery(SqlUpDate);
                }
                else if (FrstMstrDt != "" && FrstMstrNo != "" && ScndMstrDt == "" && ScndMstrNo == "")
                {
                    string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] SET [WMI_SecondMusterDt]='" + secMusterDt + "',[WMI_SecondMusterNo]='" + secMusterNo + "',[WMI_LWCompleteDt]='" + lentalWorkComDt + "',[WMI_ThirdMusterDt]='" + thirdMusterDt + "',[WMI_ThirdMusterNo]='" + thirdMusterNo + "',[WMI_FourthMusterDt]='" + forthMusterDt + "',[WMI_FourthMusterNo]='" + forthMusterNo + "',[WMI_WCompleteDt]='" + workComDt + "' where [IAYP_Id]='" + iayA_Id + "'";
                    cc.ExecuteNonQuery(SqlUpDate);
                }
                else if (ScndMstrDt != "" && ScndMstrNo != "" && LntLvlWrkDt == "")
                {
                    string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] SET [WMI_LWCompleteDt]='" + lentalWorkComDt + "',[WMI_ThirdMusterDt]='" + thirdMusterDt + "',[WMI_ThirdMusterNo]='" + thirdMusterNo + "',[WMI_FourthMusterDt]='" + forthMusterDt + "',[WMI_FourthMusterNo]='" + forthMusterNo + "',[WMI_WCompleteDt]='" + workComDt + "' where [IAYP_Id]='" + iayA_Id + "'";
                    cc.ExecuteNonQuery(SqlUpDate);
                }
                else if (LntLvlWrkDt != "" && ThrdMstrDt == "" && ThrdMstrNo == "")
                {
                    string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] SET [WMI_ThirdMusterDt]='" + thirdMusterDt + "',[WMI_ThirdMusterNo]='" + thirdMusterNo + "',[WMI_FourthMusterDt]='" + forthMusterDt + "',[WMI_FourthMusterNo]='" + forthMusterNo + "',[WMI_WCompleteDt]='" + workComDt + "' where [IAYP_Id]='" + iayA_Id + "'";
                    cc.ExecuteNonQuery(SqlUpDate);
                }
                else if (ThrdMstrDt != "" && ThrdMstrNo != "" && FrthMstrDt == "" && FrthMstrNo == "")
                {
                    string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] SET [WMI_FourthMusterDt]='" + forthMusterDt + "',[WMI_FourthMusterNo]='" + forthMusterNo + "',[WMI_WCompleteDt]='" + workComDt + "' where [IAYP_Id]='" + iayA_Id + "'";
                    cc.ExecuteNonQuery(SqlUpDate);
                }
                else if (FrthMstrDt != "" && FrthMstrNo != "" && WrkCmptDt == "")
                {
                    string SqlUpDate = "Update [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] SET ,[WMI_WCompleteDt]='" + workComDt + "' where [IAYP_Id]='" + iayA_Id + "'";
                    cc.ExecuteNonQuery(SqlUpDate);
                }
            }

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] ([WMI_DTotWS],[WMI_FirstMusterDt],[WMI_FirstMusterNo],[WMI_SecondMusterDt],[WMI_SecondMusterNo],[WMI_LWCompleteDt],[WMI_ThirdMusterDt],[WMI_ThirdMusterNo],[WMI_FourthMusterDt],[WMI_FourthMusterNo],[WMI_WCompleteDt],[IAYP_Id],[CreatedBy],[CreatedDate],[BeneficiaryMobileNo]) " +
            //               "VALUES ('" + dateWorkStart + "','" + firstMusterDt + "','" + firstMusterNo + "','" + secMusterDt + "','" + secMusterNo + "','" + lentalWorkComDt + "','" + thirdMusterDt + "','" + thirdMusterNo + "','" + forthMusterDt + "','" + forthMusterNo + "','" + workComDt + "','" + ds.Tables[0].Rows[0][0].ToString() + "','" + userMobNo + "','" + System.DateTime.Now + "','" + beneficiaryMobNo + "')";
            //    cc.ExecuteNonQuery(sqlQuery);
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}
        }
        catch
        {
            return 0;
        }
        return 1;
    }

    [WebMethod(Description = "INSERT IAY IMAGE DETAILS")]
    public int InsertImageDetails(string beneficiaryMobNo, string imageRelTo, string actualImage, string takenBy, string refMobNo, string role, string date, string userMobNo)
    {
        DataSet ds = new DataSet();
        try
        {
            string sqlQuery1 = "SELECT [IAYP_Id] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] WHERE [PBMobileNo] = '" + beneficiaryMobNo + "'";
            ds = cc.ExecuteDataset(sqlQuery1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYImageDetails] ([BeneficiaryMobNo],[ImgRelatedTo],[ActualImage],[TakenByUser],[RefMobNo],[RoleId],[RoleName],[Date],[CreatedBy],[CreatedDate],[BeneficiaryMobileNo]) " +
                           "VALUES ('" + beneficiaryMobNo + "','" + imageRelTo + "','" + actualImage + "','" + takenBy + "','" + refMobNo + "','1','" + role + "','" + date + "','" + userMobNo + "','" + System.DateTime.Now + "','" + beneficiaryMobNo + "')";
                cc.ExecuteNonQuery(sqlQuery);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch
        {
            return 0;
        }
    }

    [WebMethod(Description = "INSERT IAY ASSIGN VILLAGES DETAILS")]
    public int InsertAssignVillages(string blockId, string CircleId, string VillageId, string officerRId, string officerMobNo, string CreatedBy, string createDate, string userRId, string modifyby, string modifyDate, string ImeiNo, string Keyword)
    {
        try
        {
            if (Keyword == "Circle")
            {
                int len = CircleId.Length - 1;
                CircleId = CircleId.Substring(0, len);
                string sql1 = "select [TalukaId],[TalukaName] from [Come2myCityDB].[come2mycity].[TalukaMaster] where [TalukaId] IN (" + CircleId + ")";
                DataSet ds1 = cc.ExecuteDataset(sql1);

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    string sqlQuery = "INSERT INTO [Come2myCityDB].[dbo].[tbl_IAYCircleVillageAssign] ([BlockId],[CircleId],[CircleName],[VillageId],[VillageName],[OfficerRoleId],[OfficerRoleName],[OfficerMobileNo] " +
                                      ",[CreatedBy],[CreatedDate],[IMEI],[UserId],[UserRoleName],[Keyword]) VALUES ('" + blockId + "','" + ds1.Tables[0].Rows[i]["TalukaId"] + "','" + ds1.Tables[0].Rows[i]["TalukaName"] + "','0','0','1','" + officerRId + "','" + officerMobNo + "','" + CreatedBy + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','0','1','" + userRId + "','" + Keyword + "')";
                    cc.ExecuteNonQuery(sqlQuery);
                }
            }
            else
            {
                int len = VillageId.Length - 1;
                VillageId = VillageId.Substring(0, len);
                string sql1 = "select [TalukaId],[TalukaName] from [Come2myCityDB].[come2mycity].[TalukaMaster] where [TalukaId] IN (" + VillageId + ")";
                sql1 += " select [TalukaId],[TalukaName] from [Come2myCityDB].[come2mycity].[TalukaMaster] where [TalukaId] IN (" + CircleId + ")";
                DataSet ds1 = cc.ExecuteDataset(sql1);

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    string sqlQuery = "INSERT INTO [Come2myCityDB].[dbo].[tbl_IAYCircleVillageAssign] ([BlockId],[CircleId],[CircleName],[VillageId],[VillageName],[OfficerRoleId],[OfficerRoleName],[OfficerMobileNo] " +
                                      ",[CreatedBy],[CreatedDate],[IMEI],[UserId],[UserRoleName],[Keyword]) VALUES ('" + blockId + "','" + ds1.Tables[1].Rows[0]["TalukaId"] + "','" + ds1.Tables[1].Rows[0]["TalukaName"] + "','" + ds1.Tables[0].Rows[i]["TalukaId"] + "','" + ds1.Tables[0].Rows[i]["TalukaName"] + "','1','" + officerRId + "','" + officerMobNo + "','" + CreatedBy + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','0','1','" + userRId + "','" + Keyword + "')";
                    cc.ExecuteNonQuery(sqlQuery);
                }
            }
            return 1;
        }
        catch
        {
            return 0;
        }
        //int result;
        //using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "[come2mycity].[spInsertAssignVillage]";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter[] par = new SqlParameter[]
        //{
        //    new SqlParameter("@blockId",blockId.ToString()),new SqlParameter("@CircleId",CircleId.ToString()),
        //    new SqlParameter("@VillageId",VillageId.ToString()),new SqlParameter("@officerRId",Convert.ToString(officerRId)),
        //    new SqlParameter("@officerMobNo",officerMobNo.ToString()),new SqlParameter("@CreatedBy",CreatedBy.ToString()),
        //    new SqlParameter("@createDate",System.DateTime.Now.ToString()),new SqlParameter("@userRId",Convert.ToString(userRId)),
        //    new SqlParameter("@modifyby",modifyby.ToString()),new SqlParameter("@modifyDate",modifyDate.ToString()),
        //    new SqlParameter("@ImeiNo",ImeiNo.ToString()),new SqlParameter("@Keyword",Keyword.ToString())
        //};
        //        cmd.Parameters.AddRange(par);
        //        if (cmd.Connection.State == ConnectionState.Closed)
        //            cmd.Connection.Open();
        //        result = cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        return 0;
        //    }
        //return 1;
    }

    [WebMethod(Description = "INSERT Gram Sevak Work Details")]
    public int InsertGramSevakWork(string workSubject, string workdetails, string date, string time, string latitude, string logitude, string usrMobNo, string ImeiNo, string GramSevakName, string BlockId)
    {
        int result;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[come2mycity].[spInsertGSWorkdetails]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@workSubject",workSubject.ToString()),
                new SqlParameter("@workdetails",workdetails.ToString()),
                new SqlParameter("@date",date.ToString()),
                new SqlParameter("@time",time.ToString()),
                new SqlParameter("@latitude",latitude.ToString()),
                new SqlParameter("@logitude",logitude.ToString()),
                new SqlParameter("@usrMobNo",usrMobNo.ToString()),
                new SqlParameter("@createdBy",usrMobNo.ToString()),
                new SqlParameter("@createdDate",System.DateTime.Now.ToString()),
                new SqlParameter("@ImeiNo",ImeiNo.ToString()),
                new SqlParameter("@GramsevakName",GramSevakName.ToString()),
                new SqlParameter("@BlockId",BlockId.ToString())
            };
                cmd.Parameters.AddRange(par);
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
        return 1;
    }

    [WebMethod(Description = "Insert Remark Details")]
    public int InsertRemark(string remark, string Benificiryid, string benificiryname, string usrMobNo, string usrRole, string blockId, string villageaid, string latitude, string longitude)
    {
        try
        {
            string sql = "insert into [Come2myCityDB].[come2mycity].[tbl_IAYRemark]([Remark],[BenificiaryId],[BenificiaryName],[userMobNo],[userRole],[CreatedBy],[CreatedDate],[Blockid],[Villageid],[Latitude],[Longitude]) values('" + remark + "','" + Benificiryid + "','" + benificiryname + "','" + usrMobNo + "','" + usrRole + "','" + usrMobNo + "','" + System.DateTime.Now + "','" + blockId + "','" + villageaid + "','" + latitude + "','" + longitude + "')";
            cc.ExecuteNonQuery(sql);
            return 1;
        }
        catch (Exception e)
        {
            return 0;
        }
    }

    [WebMethod(Description = "Insert IAY to assign circle and village")]
    public int InsertCircleAndVillages(string stateId, string districtId, string blockId, string circleId, string villageId, string usrMobNo)
    {
        string sqlUpdate = "", sqlupdate1 = "";
        try
        {
            if (villageId == "0")
            {
                sqlUpdate = "SELECT * FROM [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] WHERE [InsertedBy]='" + usrMobNo + "' AND [BlockId]='" + blockId + "'";
                DataSet dsUp = cc.ExecuteDataset(sqlUpdate);
                if (dsUp.Tables[0].Rows.Count > 0)
                {
                    sqlupdate1 = "Update [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] Set [StateId]='" + stateId + "',[DistrictId]='" + districtId + "',[BlockId]='" + blockId + "',[CircleId]='" + circleId + "',[VillageId]='" + villageId + "' Where [InsertedBy]='" + usrMobNo + "' and [BlockId]='" + blockId + "'";
                    cc.ExecuteNonQuery(sqlupdate1);
                }
                else
                {
                    string sql = "insert into [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] ([StateId],[DistrictId],[BlockId],[CircleId],[VillageId],[InsertedBy],[InsertedDate]) values (" + stateId + "," + districtId + "," + blockId + ",'" + circleId + "','" + villageId + "','" + usrMobNo + "','" + System.DateTime.Now + "')";
                    cc.ExecuteNonQuery(sql);
                }
            }
            else
            {
                sqlUpdate = "SELECT * FROM [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] WHERE [InsertedBy]='" + usrMobNo + "' AND [BlockId]='" + blockId + "' AND [CircleId]='" + circleId + "'";
                DataSet dsUp = cc.ExecuteDataset(sqlUpdate);
                if (dsUp.Tables[0].Rows.Count > 0)
                {
                    sqlupdate1 = "Update [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] Set [StateId]='" + stateId + "',[DistrictId]='" + districtId + "',[BlockId]='" + blockId + "',[CircleId]='" + circleId + "',[VillageId]='" + villageId + "' Where [InsertedBy]='" + usrMobNo + "' and  [BlockId]='" + blockId + "' and [CircleId]='" + circleId + "' ";
                    cc.ExecuteNonQuery(sqlupdate1);
                }
                else
                {
                    string sql = "insert into [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] ([StateId],[DistrictId],[BlockId],[CircleId],[VillageId],[InsertedBy],[InsertedDate]) values (" + stateId + "," + districtId + "," + blockId + ",'" + circleId + "','" + villageId + "','" + usrMobNo + "','" + System.DateTime.Now + "')";
                    cc.ExecuteNonQuery(sql);
                }
            }
        }
        catch
        {
            return 0;
        }
        return 1;
    }
    #endregion

    #region DownLoad IAY DATA
    [WebMethod(Description = "Download Personal Data Details")]
    public XmlDataDocument PersonalDataReport(string usrDistrictId, string usrBlockId, string usrGramPanchayatId, string userMobNo)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = "Select [PBMobileNo],[PBFirstName],[PBLastName],[PBAdharNo],[PBBankACNo],[PBBankName],[PBIFSC_Code],[PBStateId],[PBDistrictId],[PBBlockId],[PBCircleId],[PBVillageId],[PBApprovalDt],[CreatedBy] from [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] where [UsrDistrictId]=" + usrDistrictId + " and [UsrBlockId]=" + usrBlockId + " and [UsrGrampanchayatId]=" + usrGramPanchayatId + " and [CreatedBy]='" + userMobNo + "'";
            ds = cc.ExecuteDataset(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NewRecord"] = "106";
                dt.Rows.Add(dr);

                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }

    [WebMethod(Description = "Download Account Data Details")]
    public XmlDataDocument AccountDataReport(string usrDistrictId, string usrBlockId, string usrGramPanchayatId, string userMobNo)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        string p_Id = string.Empty;
        try
        {
            string Sql = "select [IAYP_Id] from [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] where [UsrDistrictId]=" + usrDistrictId + " and [UsrBlockId]=" + usrBlockId + " and [UsrGrampanchayatId]=" + usrGramPanchayatId + " and [CreatedBy]='" + userMobNo + "'";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    p_Id = p_Id + "," + ds.Tables[0].Rows[r][0].ToString();
                }
                p_Id = p_Id.Substring(1);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sql = "Select [FirstInstallmentRs],[FirstInstallmentDt],[SecondInstallmentRs],[SecondInstallmentDt],[ThirdInstallmentRs],[ThirdInstallmentDt],[BeneficiaryMobileNo],[CreatedBy] from [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] where [IAYP_Id] IN(" + p_Id + ")";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xmlData = new XmlDataDocument(ds);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NewRecord"] = "106";
                    dt.Rows.Add(dr);

                    ds.Tables.Add(dt);
                    xmlData = new XmlDataDocument(ds);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NewRecord"] = "106";
                dt.Rows.Add(dr);

                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;

        }
        return xmlData;
    }

    //public XmlDataDocument ImageDataReport()
    //{
    //    XmlDataDocument xmlData=new XmlDataDocument();
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        string sql = "Select [BeneficiaryMobNo],[ImgRelatedTo],[ActualImage],[TakenByUser],[RefMobNo],[RoleId] from [Come2myCityDB].[come2mycity].[tbl_IAYImageDetails]";
    //         ds = cc.ExecuteDataset(sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            xmlData = new XmlDataDocument(ds);
    //            XmlElement xmlEle = xmlData.DocumentElement;
    //        }
    //        else
    //        {
    //            DataTable dt = new DataTable();
    //            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
    //            DataRow dr = dt.NewRow();
    //            dr["NewRecord"] = "106";
    //            dt.Rows.Add(dr);

    //            ds.Tables.Add(dt);
    //            xmlData = new XmlDataDocument(ds);
    //            XmlElement xmlEle = xmlData.DocumentElement;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        DataTable dt = new DataTable();
    //        dt.Columns.Add(new DataColumn("Error", typeof(int)));
    //        DataRow dr = dt.NewRow();
    //        dr["Error"] = "105";
    //        dt.Rows.Add(dr);

    //        ds.Tables.Add(dt);
    //        xmlData = new XmlDataDocument(ds);
    //        XmlElement xmlEle = xmlData.DocumentElement;
    //    }
    //    return xmlData;
    //}

    [WebMethod(Description = "Download Techanical Data Details")]
    public XmlDataDocument TechanicalDataReport(string usrDistrictId, string usrBlockId, string usrGramPanchayatId, string userMobNo)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        string p_Id = string.Empty;
        try
        {
            string Sql = "select [IAYP_Id] from [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] where [UsrDistrictId]=" + usrDistrictId + " and [UsrBlockId]=" + usrBlockId + " and [UsrGrampanchayatId]=" + usrGramPanchayatId + " and [CreatedBy]='" + userMobNo + "'";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    p_Id = p_Id + "," + ds.Tables[0].Rows[r][0].ToString();
                }
                p_Id = p_Id.Substring(1);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sql = "Select [Tech_LayoutAsstEngName],[Tech_LayoutDt],[Tech_DtAsstEngVisit],[Tech_CompleteCertDt],[BeneficiaryMobileNo],[CreatedBy] from [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData] where [IAYP_Id] IN(" + p_Id + ")";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xmlData = new XmlDataDocument(ds);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NewRecord"] = "106";
                    dt.Rows.Add(dr);

                    ds.Tables.Add(dt);
                    xmlData = new XmlDataDocument(ds);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
            }
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }

    [WebMethod(Description = "Download WorkMuster Data Details")]
    public XmlDataDocument WorkMusterReport(string usrDistrictId, string usrBlockId, string usrGramPanchayatId, string userMobNo)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        string p_Id = string.Empty;
        try
        {
            string Sql = "select [IAYP_Id] from [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] where [UsrDistrictId]=" + usrDistrictId + " and [UsrBlockId]=" + usrBlockId + " and [UsrGramPanchayatId]=" + usrGramPanchayatId + " and [CreatedBy]='" + userMobNo + "'";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    p_Id = p_Id + "," + ds.Tables[0].Rows[r][0].ToString();
                }
                p_Id = p_Id.Substring(1);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sql = "Select [WMI_DTotWS],[WMI_FirstMusterDt],[WMI_FirstMusterNo],[WMI_SecondMusterDt],[WMI_SecondMusterNo],[WMI_LWCompleteDt],[WMI_ThirdMusterDt],[WMI_ThirdMusterNo],[WMI_FourthMusterDt],[WMI_FourthMusterNo],[WMI_WCompleteDt],[BeneficiaryMobileNo],[CreatedBy] from [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] where [IAYP_Id] IN(" + p_Id + ")";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xmlData = new XmlDataDocument(ds);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NewRecord"] = "106";
                    dt.Rows.Add(dr);

                    ds.Tables.Add(dt);
                    xmlData = new XmlDataDocument(ds);
                    XmlElement xmlEle = xmlData.DocumentElement;
                }
            }
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    #region DOWNLOAD To BENEFICIARY INFO
    [WebMethod(Description = "Download Beneficiary Data Details")]
    public XmlDataDocument DownloadBeneficiaryData(string DistrictId, string BlockId, string circleId, string VillageId)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = "SELECT [PBMobileNo],[PBFirstName],[PBApprovalDt],[PBDistrictId],[PBBlockId],[PBCircleId],[PBVillageId] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] WHERE [PBDistrictId]=" + DistrictId + " and [PBBlockId]=" + BlockId + " and [PBCircleId]=" + circleId + " and [PBVillageId]=" + VillageId + " ";
            ds = cc.ExecuteDataset(sql);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
            //return XmlData;
        }
        catch
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    #region Download Data for IAY GramPanchayat
    [WebMethod(Description = "Download Data for IAY")]
    public XmlDataDocument DownloadIAYData(string DistrictId, string BlockId)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = "SELECT [PBDistrictId],[PBBlockId],[PBCircled],[PBGramPanchayatName],[PBVillageId],[PBVillageName] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] WHERE [PBDistrictId]=" + DistrictId + " AND [PBBlockId]=" + BlockId + " ";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            return xmlData;
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
            //return xmlData;
        }
        return xmlData;
    }
    #endregion

    #region Download Villages to comman method Based On TalukaID
    [WebMethod(Description = "DownloadVillages")]
    public XmlDataDocument DownloadVillage(string BlocKId)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = "Select [TalukaId],[TalukaName],[CityId] from [Come2myCityDB].[come2mycity].[TalukaMaster] where [CityId]='" + BlocKId + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            // return xmlData;
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    #region Download GramsevakReport And this report see officer
    [WebMethod(Description = "Download Gramsevak Report in Details.")]
    public XmlDataDocument GramSevakWorkReport(string Keyword, string MobNo, string Blockid)
    {
        XmlDataDocument XmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = "select [mobileNo] from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [mobileNo]='" + MobNo + "'";
            DataSet Ds = new DataSet();
            Ds = cc.ExecuteDataset(sql);
            string officerMobNo = Convert.ToString(Ds.Tables[0].Rows[0]["mobileNo"]);
            if (Keyword == "B.D.O" && MobNo == officerMobNo)
            {
                string strsql = "select [GramsevakName],[WorkSubject],[WorkDetails],[Date],[Time],[latitude],[longitude],[userMobileNo],[BlockId] from [Come2myCityDB].[come2mycity].[tbl_IAYGWorkDetails] where [BlockId]='" + Blockid + "'";
                ds = cc.ExecuteDataset(strsql);
            }
            else if (Keyword == "Extension Officer" && MobNo == officerMobNo)
            {
                string strsql = "select [GramsevakName],[WorkSubject],[WorkDetails],[Date],[Time],[latitude],[longitude],[userMobileNo],[BlockId] from [Come2myCityDB].[come2mycity].[tbl_IAYGWorkDetails] where [BlockId]='" + Blockid + "'";
                ds = cc.ExecuteDataset(strsql);
            }
            else if (Keyword == "CEO" && MobNo == officerMobNo)
            {
                string strsql = "select [GramsevakName],[WorkSubject],[WorkDetails],[Date],[Time],[latitude],[longitude],[userMobileNo],[BlockId] from [Come2myCityDB].[come2mycity].[tbl_IAYGWorkDetails] where [BlockId]='" + Blockid + "'";
                ds = cc.ExecuteDataset(strsql);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                XmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = XmlData.DocumentElement;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("No Record", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["No Record"] = "106";
                dt.Rows.Add(dr);

                ds.Tables.Add(dt);
                XmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = XmlData.DocumentElement;
            }
            return XmlData;
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            XmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = XmlData.DocumentElement;
            return XmlData;
        }

    }
    #endregion

    #region METHOD FOR ASSIGN VILLAGES NAME DOWNLOAD TO UNDER OFFICER MOB NO
    [WebMethod(Description = "Download AssignVillages of officer Mob No")]
    public XmlDataDocument DownloadAssignVillages(string OffcierMobNo, string Keyword)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet Ds = new DataSet();
        string AssignVId = string.Empty;
        try
        {
            string sql = "SELECT [BlockId],[CircleId],[CircleName],[OfficerMobileNo],[Keyword] AS KeyWord,[VillageId],[VillageName] FROM [Come2myCityDB].[dbo].[tbl_IAYCircleVillageAssign] " +
                         "WHERE [OfficerMobileNo]='" + OffcierMobNo + "' AND [Keyword]='" + Keyword + "'";
            DataSet ds = cc.ExecuteDataset(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NoRecord"] = "106";
                dt.Rows.Add(dr);

                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            Ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(Ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    #region METHOD TO DOWNLOAD ASSIGN CIRCLES
    [WebMethod(Description = "Assign Circle Details")]
    public XmlDataDocument DownloadAssignCircle(string BID, string CID)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        string CidStr = string.Empty;
        try
        {
            if (BID != "" && CID == "0")
            {
                string sql = "select [DistrictId],[BlockId],[VillageId],[CircleId] from [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] where [BlockId]='" + BID + "'";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CidStr = Convert.ToString(ds.Tables[0].Rows[0]["CircleId"]);
                }
                int len = CidStr.Length - 1;
                CidStr = CidStr.Substring(0, len);

                string Sql = "select [TalukaId],[TalukaName] from [Come2myCityDB].[come2mycity].[TalukaMaster] where [TalukaId] IN(" + CidStr + ")";
                DataSet DS = cc.ExecuteDataset(Sql);

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("BlockId", typeof(string)));
                dt.Columns.Add(new DataColumn("VillageCircleId", typeof(string)));
                dt.Columns.Add(new DataColumn("CircleId", typeof(string)));
                dt.Columns.Add(new DataColumn("CircleName", typeof(string)));
                dt.Columns.Add(new DataColumn("Keyword", typeof(string)));

                int dscnt = DS.Tables[0].Rows.Count;
                int dsCount = ds.Tables[0].Rows.Count;

                for (int i = 0; i < dscnt; i++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[0]["DistrictId"].ToString(), ds.Tables[0].Rows[0]["BlockId"].ToString(), ds.Tables[0].Rows[0]["VillageId"].ToString(), DS.Tables[0].Rows[i]["TalukaId"].ToString(), DS.Tables[0].Rows[i]["TalukaName"].ToString(), "Circle");
                }

                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                string sql = "select [DistrictId],[BlockId],[VillageId],[CircleId] from [Come2myCityDB].[come2mycity].[tbl_IAYCircleAndVillages] where [BlockId]='" + BID + "' and [CircleId]='" + CID + "'";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CidStr = Convert.ToString(ds.Tables[0].Rows[0]["VillageId"]);
                }
                int len = CidStr.Length - 1;
                CidStr = CidStr.Substring(0, len);

                string Sql = "select [TalukaId],[TalukaName] from [Come2myCityDB].[come2mycity].[TalukaMaster] where [TalukaId] IN(" + CidStr + ")";
                DataSet DS = cc.ExecuteDataset(Sql);

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("BlockId", typeof(string)));
                dt.Columns.Add(new DataColumn("VillageCircleId", typeof(string)));
                dt.Columns.Add(new DataColumn("CircleId", typeof(string)));
                dt.Columns.Add(new DataColumn("CircleName", typeof(string)));
                dt.Columns.Add(new DataColumn("Keyword", typeof(string)));

                int dscnt = DS.Tables[0].Rows.Count;
                int dsCount = ds.Tables[0].Rows.Count;

                for (int i = 0; i < dscnt; i++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[0]["DistrictId"].ToString(), ds.Tables[0].Rows[0]["BlockId"].ToString(), ds.Tables[0].Rows[0]["CircleId"].ToString(), DS.Tables[0].Rows[i]["TalukaId"].ToString(), DS.Tables[0].Rows[i]["TalukaName"].ToString(), "Village");
                }
                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";

                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch (Exception e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
            return xmlData;
        }
        return xmlData;
    }
    #endregion

    #region METHOD TO DOWNLOAD ALL FIELD MASTER DETAILS
    [WebMethod]
    public XmlDataDocument DownloadReportFieldId()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = " SELECT [ID],[ItemName] FROM [Come2myCityDB].[come2mycity].[tbl_IAYFieldItmMaster]";
            ds = cc.ExecuteDataset(sql);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        catch
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
            return xmlData;
        }
        return xmlData;
    }
    #endregion

    #region METHOD TO DOWNLOAD REPORT DETAILS
    [WebMethod(Description = "Method to download Reports destails")]
    public XmlDataDocument DownloadReport(string Vid)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        DataSet Ds = new DataSet();
        DataTable dt = new DataTable();
        string P_Id = string.Empty;
        try
        {
            string sql = "select [IAYP_Id],[PBFirstName],[PBMobileNo],[PBVillageId],[PBCircleId],[PBBlockId],[PBApprovalDt] from [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] where [PBVillageId]='" + Vid + "'";
            ds = cc.ExecuteDataset(sql);
            //for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            //{
            //    P_Id = P_Id + "," + Convert.ToString(ds.Tables[0].Rows[r]["IAYP_Id"]);
            //}
            //P_Id = P_Id.Substring(1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string SqlQuery = "SELECT a.[FirstInstallmentDt],w.[WMI_DTotWS],w.[WMI_FirstMusterDt],w.[WMI_FirstMusterNo],w.[WMI_SecondMusterDt],w.[WMI_SecondMusterNo],w.[WMI_LWCompleteDt],t.[Tech_LayoutDt],a.[SecondInstallmentDt],w.[WMI_ThirdMusterDt],w.[WMI_ThirdMusterNo],w.[WMI_FourthMusterDt],w.[WMI_FourthMusterNo],w.[WMI_WCompleteDt],t.[Tech_DtAsstEngVisit],a.[ThirdInstallmentDt],t.[Tech_CompleteCertDt] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] as p INNER JOIN [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] as w ON p.[IAYP_Id] = w.[IAYP_Id] INNER JOIN [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] as a ON p.[IAYP_Id] = a.[IAYP_Id] INNER JOIN [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData] as t ON p.[IAYP_Id] = t.[IAYP_Id] WHERE p.[PBVillageId]=" + Vid + "";      //w.[IAYP_Id] IN (" + P_Id + ")";
                Ds = cc.ExecuteDataset(SqlQuery);

                dt.Columns.Add(new DataColumn("beneficiaryName", typeof(string)));
                dt.Columns.Add(new DataColumn("beneficiaryId", typeof(string)));
                dt.Columns.Add(new DataColumn("villageId", typeof(string)));
                dt.Columns.Add(new DataColumn("circleId", typeof(string)));
                dt.Columns.Add(new DataColumn("blockId", typeof(string)));
                dt.Columns.Add(new DataColumn("approvalDate", typeof(string)));

                dt.Columns.Add(new DataColumn("FirstInstallmentDate", typeof(string)));
                //dt.Columns.Add(new DataColumn("AsstJEMarkOutDate", typeof(string)));
                dt.Columns.Add(new DataColumn("WorkStartDate", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstMusterDate", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstMusterNo", typeof(string)));

                dt.Columns.Add(new DataColumn("SecondMusterDate", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondMusterNo", typeof(string)));
                dt.Columns.Add(new DataColumn("LentalLevelWorkComletionDate", typeof(string)));
                dt.Columns.Add(new DataColumn("AsstJELentalWorkVisitDate", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondInstallmentDate", typeof(string)));

                dt.Columns.Add(new DataColumn("ThirdMusterDate", typeof(string)));
                dt.Columns.Add(new DataColumn("ThirdMusterNo", typeof(string)));
                dt.Columns.Add(new DataColumn("FourthMusterDate", typeof(string)));
                dt.Columns.Add(new DataColumn("FourthMusterNo", typeof(string)));
                dt.Columns.Add(new DataColumn("WorkComletionDate", typeof(string)));
                dt.Columns.Add(new DataColumn("AsstJEVisitDate", typeof(string)));

                dt.Columns.Add(new DataColumn("ThirdInstallmentDate", typeof(string)));
                dt.Columns.Add(new DataColumn("ComletionCertificateUploadDate", typeof(string)));

                //dt.Columns.Add(new DataColumn("MarkOutPhotograph", typeof(string)));
                //dt.Columns.Add(new DataColumn("WorkStartPhoto", typeof(string)));
                //dt.Columns.Add(new DataColumn("GramsevakVisitLentalWorkPhoto", typeof(string)));
                //dt.Columns.Add(new DataColumn("GramsevakVisitWorkComPletionPhoto", typeof(string)));
                //dt.Columns.Add(new DataColumn("AsstJEVisictWorkCompletionPhoto", typeof(string)));

                int dsCount = ds.Tables[0].Rows.Count;
                int DSCount = Ds.Tables[0].Rows.Count;

                for (int i = 0; i < dsCount; i++)
                {
                    dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), Ds.Tables[0].Rows[i]["FirstInstallmentDt"].ToString(), Ds.Tables[0].Rows[i]["WMI_DTotWS"].ToString(), Ds.Tables[0].Rows[i]["WMI_FirstMusterDt"].ToString(), Ds.Tables[0].Rows[i]["WMI_FirstMusterNo"].ToString(), Ds.Tables[0].Rows[i]["WMI_SecondMusterDt"].ToString(), Ds.Tables[0].Rows[i]["WMI_SecondMusterNo"].ToString(), Ds.Tables[0].Rows[i]["WMI_LWCompleteDt"].ToString(), Ds.Tables[0].Rows[i]["Tech_LayoutDt"].ToString(), Ds.Tables[0].Rows[i]["SecondInstallmentDt"].ToString(), Ds.Tables[0].Rows[i]["WMI_ThirdMusterDt"].ToString(), Ds.Tables[0].Rows[i]["WMI_ThirdMusterNo"].ToString(), Ds.Tables[0].Rows[i]["WMI_FourthMusterDt"].ToString(), Ds.Tables[0].Rows[i]["WMI_FourthMusterNo"].ToString(), Ds.Tables[0].Rows[i]["WMI_WCompleteDt"].ToString(), Ds.Tables[0].Rows[i]["Tech_DtAsstEngVisit"].ToString(), Ds.Tables[0].Rows[i]["ThirdInstallmentDt"].ToString(), Ds.Tables[0].Rows[i]["Tech_CompleteCertDt"].ToString());
                }

                //  if (FieldId == "1")
                //{
                //for (int i = 0; i < dsCount; i++)
                //{
                //    dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), Ds.Tables[0].Rows[i]["FirstInstallmentDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL","NULL");
                //}
                //    }
                //        else if(FieldId == "2")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", Ds.Tables[0].Rows[i]["WMI_DTotWS"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "4")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_FirstMusterDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "5")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_FirstMusterNo"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "6")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_SecondMusterDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "7")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_SecondMusterNo"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "8")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_LWCompleteDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "9")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["Tech_LayoutDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "10")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["SecondInstallmentDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "11")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_ThirdMusterDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "12")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_ThirdMusterNo"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "13")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_FourthMusterDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "14")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_FourthMusterNo"].ToString(), "NULL", "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "15")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["WMI_WCompleteDt"].ToString(), "NULL", "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "16")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["Tech_DtAsstEngVisit"].ToString(), "NULL", "NULL");
                //            }
                //        }
                //        else if (FieldId == "17")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["ThirdInstallmentDt"].ToString(), "NULL");
                //            }
                //        }
                //        else if (FieldId == "18")
                //        {
                //            for (int i = 0; i < dsCount; i++)
                //            {
                //                dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBVillageId"].ToString(), ds.Tables[0].Rows[i]["PBCircleId"].ToString(), ds.Tables[0].Rows[i]["PBBlockId"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(), "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", "NULL", Ds.Tables[0].Rows[i]["Tech_CompleteCertDt"].ToString());
                //            }
                //        }
                //}
                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;

                //string sql = "select [IAYP_Id],[PBFirstName],[PBMobileNo],[PBApprovalDt],[PBBlockId],[PBCircleId],[PBVillageId] from [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] where [PBVillageId]='" + Vid + "'";
                //ds = cc.ExecuteDataset(sql);
                //for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                //{
                //    P_Id =P_Id + "," + Convert.ToString(ds.Tables[0].Rows[r]["IAYP_Id"]);
                //}
                //P_Id = P_Id.Substring(1);

                //if(ds.Tables[0].Rows.Count > 0)
                //{
                //    if(FieldId == "8")
                //    {
                //        string StrQuery = "select [FirstInstallmentRs],[FirstInstallmentDt],[CreatedBy] from [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] Where [IAYP_Id] IN (" + P_Id + ") Order by [IAYP_Id] ASC";
                //         Ds = cc.ExecuteDataset(StrQuery);
                //         DataTable dt = new DataTable();
                //         dt.Columns.Add(new DataColumn("PBFirstName", typeof(string)));
                //         dt.Columns.Add(new DataColumn("PBMobileNo", typeof(string)));
                //         dt.Columns.Add(new DataColumn("PBApprovalDt", typeof(string)));
                //         dt.Columns.Add(new DataColumn("InstallmentRs", typeof(string)));
                //         dt.Columns.Add(new DataColumn("InstallmentDt", typeof(string)));
                //         dt.Columns.Add(new DataColumn("CreatedBy", typeof(string)));

                //         int dsCount = ds.Tables[0].Rows.Count;
                //         int DSCount = Ds.Tables[0].Rows.Count;

                //         for (int i = 0; i < dsCount; i++)
                //        {
                //            dt.Rows.Add(ds.Tables[0].Rows[i]["PBFirstName"].ToString(), ds.Tables[0].Rows[i]["PBMobileNo"].ToString(), ds.Tables[0].Rows[i]["PBApprovalDt"].ToString(),Ds.Tables[0].Rows[i]["FirstInstallmentRs"].ToString(), Ds.Tables[0].Rows[i]["FirstInstallmentDt"].ToString(), Ds.Tables[0].Rows[i]["CreatedBy"].ToString());
                //        }
                //         ds.Tables.RemoveAt(0);
                //         ds.Tables.Add(dt);
                //         ds.Tables[0].TableName = "Table1";

                //         xmlData = new XmlDataDocument(ds);
                //         XmlElement xmlEle = xmlData.DocumentElement;
                //    }
                //    else if(FieldId == "9")
                //    {
                //        string StrQuery = "select [SecondInstallmentRs],[SecondInstallmentDt],[CreatedBy] from [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] Where [IAYP_Id] IN (" + P_Id + ")";
                //         Ds = cc.ExecuteDataset(StrQuery);
                //    }
                //    else if(FieldId == "10")
                //    {
                //        string StrQuery = "select [ThirdInstallmentRs],[ThirdInstallmentDt],[CreatedBy] from [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] Where [IAYP_Id] IN (" + P_Id + ")";
                //         Ds = cc.ExecuteDataset(StrQuery);
                //    }
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    #region  METHOD TO DOWNLOAD IAY REPORT DistrictWISE Block And Village Wise Count
    [WebMethod]
    public XmlDataDocument DownloadCountWiseReport(string DId, string BId, string VId)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        string BName = ""; string FstInstmnt = ""; string SndInstmnt = ""; string ThrdInsltmnt = ""; string fstmstr = ""; string SndMstr = ""; string Thrdmstr = ""; string FrthMstr = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspAbstractReportsIAY";
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@stateId",DId),
            new SqlParameter("@districtId",DId),
            new SqlParameter("@talukaId",BId),
            new SqlParameter("@villageId",VId),
        };
            cmd.Parameters.AddRange(parameter);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            if (DId != "0" && BId == "0" && VId == "0")
            {
                string sql = "Select [DistrictId],[TotalBeneficiary],[FirstInstallment],[SecondInstallment],[ThirdInstallment],[FirstMuster],[SecondMuster],[ThirdMuster],[FourthMuster] from [Come2myCityDB].[come2mycity].[tbl_IAYDistrictWiseReport] Where [DistrictId]=" + DId + " order by [snoId] DESC";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    BName = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);
                    FstInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["TotalBeneficiary"]);
                    SndInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["FirstInstallment"]);
                    ThrdInsltmnt = Convert.ToString(ds.Tables[0].Rows[0]["SecondInstallment"]);
                    fstmstr = Convert.ToString(ds.Tables[0].Rows[0]["ThirdInstallment"]);
                    SndMstr = Convert.ToString(ds.Tables[0].Rows[0]["FirstMuster"]);
                    Thrdmstr = Convert.ToString(ds.Tables[0].Rows[0]["SecondMuster"]);
                    FrthMstr = Convert.ToString(ds.Tables[0].Rows[0]["ThirdMuster"]);
                    FrthMstr = Convert.ToString(ds.Tables[0].Rows[0]["FourthMuster"]);
                }

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("BlockId", typeof(string)));
                dt.Columns.Add(new DataColumn("VillageId", typeof(string)));
                dt.Columns.Add(new DataColumn("TotalBeneficiary", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("ThirdInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("ThirdMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("FourthMaster", typeof(string)));

                dt.Rows.Add(ds.Tables[0].Rows[0]["DistrictId"].ToString(), "0", "0", ds.Tables[0].Rows[0]["TotalBeneficiary"].ToString(), ds.Tables[0].Rows[0]["FirstInstallment"].ToString(), ds.Tables[0].Rows[0]["SecondInstallment"].ToString(), ds.Tables[0].Rows[0]["ThirdInstallment"].ToString(), ds.Tables[0].Rows[0]["FirstMuster"].ToString(), ds.Tables[0].Rows[0]["SecondMuster"].ToString(), ds.Tables[0].Rows[0]["ThirdMuster"].ToString(), ds.Tables[0].Rows[0]["FourthMuster"].ToString());

                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
            }
            else if (DId != "0" && BId != "0" && VId == "0")
            {
                string sql = "Select [TakulaId],[TotalBeneficiary],[FirstInstallment],[SecondInstallment],[ThirdInstallment],[FirstMuster],[SecondMuster],[ThirdMuster],[FourthMuster] from [Come2myCityDB].[come2mycity].[tbl_IAYTalukaWiseReport] Where [TakulaId]=" + BId + " order by [SNoId] DESC";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    BName = Convert.ToString(ds.Tables[0].Rows[0]["TakulaId"]);
                    FstInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["TotalBeneficiary"]);
                    SndInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["FirstInstallment"]);
                    ThrdInsltmnt = Convert.ToString(ds.Tables[0].Rows[0]["SecondInstallment"]);
                    fstmstr = Convert.ToString(ds.Tables[0].Rows[0]["ThirdInstallment"]);
                    SndMstr = Convert.ToString(ds.Tables[0].Rows[0]["FirstMuster"]);
                    Thrdmstr = Convert.ToString(ds.Tables[0].Rows[0]["SecondMuster"]);
                    FrthMstr = Convert.ToString(ds.Tables[0].Rows[0]["ThirdMuster"]);
                    FrthMstr = Convert.ToString(ds.Tables[0].Rows[0]["FourthMuster"]);
                }
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("BlockId", typeof(string)));
                dt.Columns.Add(new DataColumn("VillageId", typeof(string)));
                dt.Columns.Add(new DataColumn("TotalBeneficiary", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("ThirdInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("ThirdMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("FourthMaster", typeof(string)));

                dt.Rows.Add("0", ds.Tables[0].Rows[0]["BlockId"].ToString(), "0", ds.Tables[0].Rows[0]["TotalBeneficiary"].ToString(), ds.Tables[0].Rows[0]["FirstInstallment"].ToString(), ds.Tables[0].Rows[0]["SecondInstallment"].ToString(), ds.Tables[0].Rows[0]["ThirdInstallment"].ToString(), ds.Tables[0].Rows[0]["FirstMuster"].ToString(), ds.Tables[0].Rows[0]["SecondMuster"].ToString(), ds.Tables[0].Rows[0]["ThirdMuster"].ToString(), ds.Tables[0].Rows[0]["FourthMuster"].ToString());

                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
            }
            else if (DId != "0" && BId != "0" && VId != "0")
            {
                string sql = "Select [VillageId],[TotalBeneficiary],[FirstInstallment],[SecondInstallment],[ThirdInstallment],[FirstMuster],[SecondMuster],[ThirdMuster],[FourthMuster] from [Come2myCityDB].[come2mycity].[tbl_IAYVillageWiseReport] Where [VillageId]=" + VId + " order by [SNOId] DESC";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    BName = Convert.ToString(ds.Tables[0].Rows[0]["VillageId"]);
                    FstInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["TotalBeneficiary"]);
                    SndInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["FirstInstallment"]);
                    ThrdInsltmnt = Convert.ToString(ds.Tables[0].Rows[0]["SecondInstallment"]);
                    fstmstr = Convert.ToString(ds.Tables[0].Rows[0]["ThirdInstallment"]);
                    SndMstr = Convert.ToString(ds.Tables[0].Rows[0]["FirstMuster"]);
                    Thrdmstr = Convert.ToString(ds.Tables[0].Rows[0]["SecondMuster"]);
                    FrthMstr = Convert.ToString(ds.Tables[0].Rows[0]["ThirdMuster"]);
                    FrthMstr = Convert.ToString(ds.Tables[0].Rows[0]["FourthMuster"]);
                }
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("DistrictId", typeof(string)));
                dt.Columns.Add(new DataColumn("BlockId", typeof(string)));
                dt.Columns.Add(new DataColumn("VillageId", typeof(string)));
                dt.Columns.Add(new DataColumn("TotalBeneficiary", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("ThirdInstallment", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("SecondMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("ThirdMaster", typeof(string)));
                dt.Columns.Add(new DataColumn("FourthMaster", typeof(string)));

                dt.Rows.Add("0", "0", ds.Tables[0].Rows[0]["VillageId"].ToString(), ds.Tables[0].Rows[0]["TotalBeneficiary"].ToString(), ds.Tables[0].Rows[0]["FirstInstallment"].ToString(), ds.Tables[0].Rows[0]["SecondInstallment"].ToString(), ds.Tables[0].Rows[0]["ThirdInstallment"].ToString(), ds.Tables[0].Rows[0]["FirstMuster"].ToString(), ds.Tables[0].Rows[0]["SecondMuster"].ToString(), ds.Tables[0].Rows[0]["ThirdMuster"].ToString(), ds.Tables[0].Rows[0]["FourthMuster"].ToString());

                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
            }
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
        }
        catch
        {

        }
        return xmlData;


        //string BName = ""; string FstInstmnt = ""; string SndInstmnt = ""; string ThrdInsltmnt = ""; string fstmstr = ""; string SndMstr = ""; string Thrdmstr = ""; string FrthMstr = "";
        //try
        //{
        //    string sql = "SELECT P.[PBMobileNo],P.[PBDistrictId],P.[PBBlockId],P.[PBVillageId],A.[FirstInstallmentDt],A.[SecondInstallmentDt],A.[ThirdInstallmentDt],W.[WMI_FirstMusterNo],W.[WMI_SecondMusterNo],W.[WMI_ThirdMusterNo],W.[WMI_FourthMusterNo] " +
        //                 "FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] P JOIN [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails] A ON P.[IAYP_Id] = A.[IAYP_Id] JOIN [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo] W ON P.[IAYP_Id] = W.[IAYP_Id] WHERE P.[PBDistrictId]=" + DId + " OR P.[PBBlockId]=" + BId + " OR P.[PBVillageId]=" + VId + " ";
        //    ds = cc.ExecuteDataset(sql);

        //    string did = Convert.ToString(ds.Tables[0].Rows[0]["PBDistrictId"]);
        //    string bid = Convert.ToString(ds.Tables[0].Rows[0]["PBBlockId"]);
        //    string vid = Convert.ToString(ds.Tables[0].Rows[0]["PBVillageId"]);

        //    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //{
        //        BName = Convert.ToString(ds.Tables[0].Rows[0]["PBMobileNo"]);
        //        FstInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["FirstInstallmentDt"]);
        //        SndInstmnt = Convert.ToString(ds.Tables[0].Rows[0]["SecondInstallmentDt"]);
        //        ThrdInsltmnt = Convert.ToString(ds.Tables[0].Rows[0]["ThirdInstallmentDt"]);
        //        fstmstr = Convert.ToString(ds.Tables[0].Rows[0]["WMI_FirstMusterNo"]);
        //        SndMstr = Convert.ToString(ds.Tables[0].Rows[0]["WMI_SecondMusterNo"]);
        //        Thrdmstr = Convert.ToString(ds.Tables[0].Rows[0]["WMI_ThirdMusterNo"]);
        //        FrthMstr = Convert.ToString(ds.Tables[0].Rows[0]["WMI_FourthMusterNo"]);
        //    //}
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        if (DId != "" && BId == "0" && VId == "0")
        //        {
        //            string SqlQry = "INSERT INTO([Come2myCityDB].[dbo].[tbl_IAYDistrictWiseReport])([DistrictId],[TotalBeneficiary],[FirstInstallment],[SecondInstallment],[ThirdInstallment],[FirstMaster],[SecondMaster],[ThirdMaster],[FourthMaster]) " +
        //                           "values('" + did + "','" + BName + "','" + FstInstmnt + "','" + SndInstmnt + "','" + ThrdInsltmnt + "','" + fstmstr + "','" + SndMstr + "','" + Thrdmstr + "','" + fstmstr + "')";
        //            cc.ExecuteNonQuery(SqlQry);

        //            string SQL = "SELECT [DistrictId],[TotalBeneficiary],[FirstInstallment],[SecondInstallment],[ThirdInstallment],[FirstMaster],[SecondMaster],[ThirdMaster],[FourthMaster] FROM [Come2myCityDB].[dbo].[tbl_IAYDistrictWiseReport] WHERE [DistrictId]=" + DId + " ORDER BY [snoId] DESC ";
        //            ds = cc.ExecuteDataset(SQL);

        //            DataTable dt = new DataTable();
        //            dt.Columns.Add(new DataColumn("DistrictId",typeof(string)));
        //            dt.Columns.Add(new DataColumn("BlockId", typeof(string)));
        //            dt.Columns.Add(new DataColumn("VillageId", typeof(string)));
        //            dt.Columns.Add(new DataColumn("TotalBeneficiary", typeof(string)));
        //            dt.Columns.Add(new DataColumn("FirstInstallment", typeof(string)));
        //            dt.Columns.Add(new DataColumn("SecondInstallment", typeof(string)));
        //            dt.Columns.Add(new DataColumn("ThirdInstallment", typeof(string)));
        //            dt.Columns.Add(new DataColumn("FirstMaster", typeof(string)));
        //            dt.Columns.Add(new DataColumn("SecondMaster", typeof(string)));
        //            dt.Columns.Add(new DataColumn("ThirdMaster", typeof(string)));
        //            dt.Columns.Add(new DataColumn("FourthMaster", typeof(string)));

        //            dt.Rows.Add(ds.Tables[0].Rows[0]["DistrictId"].ToString(), "0", "0", ds.Tables[0].Rows[0]["TotalBeneficiary"].ToString(), ds.Tables[0].Rows[0]["FirstInstallment"].ToString(), ds.Tables[0].Rows[0]["SecondInstallment"].ToString(), ds.Tables[0].Rows[0]["ThirdInstallment"].ToString(), ds.Tables[0].Rows[0]["FirstMaster"].ToString(), ds.Tables[0].Rows[0]["SecondMaster"].ToString(), ds.Tables[0].Rows[0]["ThirdMaster"].ToString(), ds.Tables[0].Rows[0]["FourthMaster"].ToString());

        //            ds.Tables.RemoveAt(0);
        //            ds.Tables.Add(dt);
        //            ds.Tables[0].TableName = "Table";

        //        }
        //        else if (DId == "0" && BId != "" && VId == "0")
        //        {
        //            string SqlQry = "INSERT INTO([Come2myCityDB].[dbo].[tbl_IAYDistrictWiseReport])([DistrictId],[TotalBeneficiary],[FirstInstallment],[SecondInstallment],[ThirdInstallment],[FirstMaster],[SecondMaster],[ThirdMaster],[FourthMaster]) " +
        //                             "values('" + did + "','" + BName + "','" + FstInstmnt + "','" + SndInstmnt + "','" + ThrdInsltmnt + "','" + fstmstr + "','" + SndMstr + "','" + Thrdmstr + "','" + fstmstr + "')";
        //            cc.ExecuteNonQuery(SqlQry);
        //        }
        //        else if (DId == "0" && BId == "0" && VId != "")
        //        {
        //            string SqlQry = "INSERT INTO([Come2myCityDB].[dbo].[tbl_IAYDistrictWiseReport])([DistrictId],[TotalBeneficiary],[FirstInstallment],[SecondInstallment],[ThirdInstallment],[FirstMaster],[SecondMaster],[ThirdMaster],[FourthMaster]) " +
        //                             "values('" + did + "','" + BName + "','" + FstInstmnt + "','" + SndInstmnt + "','" + ThrdInsltmnt + "','" + fstmstr + "','" + SndMstr + "','" + Thrdmstr + "','" + fstmstr + "')";
        //            cc.ExecuteNonQuery(SqlQry);
        //        }
        //    }

    }
    #endregion


    ////////////////////Added by rajkumar //////////

    [WebMethod(Description = "Method to download Benifiary Reports destails")]
    public XmlDataDocument DownloadBenifiaryReport(string Vid)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        DataSet Ds = new DataSet();
        DataTable dt = new DataTable();
        string P_Id = string.Empty;
        try
        {
            string sql = "select [IAYP_Id],[PBFirstName],[PBLastName],[PBMobileNo],[PBApprovalDt] from [tbl_IAYPersonalData] where [PBVillageId]='" + Vid + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement objXmlElement = xmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add(new DataColumn("No Record Found", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["No Record Found"] = "106";
                dt.Rows.Add(dr);

                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
        }
        catch
        {
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
            return xmlData;
        }
        return xmlData;
    }


    #region Add Junior and Download ,Update Status

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AddJunior(string jsonString)
    {
        string returnString = string.Empty;
        int result=0; string sql = string.Empty; 
        try
        {
            List<Addjunoir> lstjunior = new JavaScriptSerializer().Deserialize<List<Addjunoir>>(jsonString);
            foreach (Addjunoir addjunior in lstjunior)
            {
                //sql = "select [Id],[UserMobile] from [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances] where [AppMobileNo]='" + addjunior.APPMOBILENO.ToString() + "' and [UserMobile]='" + addjunior.USERMOBILE.ToString() + "'";
                //ds = cc.ExecuteDataset(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    sql = "Update [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances] set [UserMobile]='" + addjunior.USERMOBILE.ToString() + "',[isActive]='" + addjunior.ACTIVE.ToString() + "' where [Id]=" + ds.Tables[0].Rows[0][0] + "";
                //    cc.ExecuteNonQuery(sql);
                //    returnString = ds.Tables[0].Rows[0][0] + "*" + addjunior.id.ToString() + "#";
                //}
                //else
                //{
                //    sql = "insert into [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances]([UserMobile],[AppMobileNo],[IMEINumber],[CreateDate],[keyword],[UserName],[isActive]) " +
                //          "values('" + addjunior.USERMOBILE.ToString() + "','" + addjunior.APPMOBILENO.ToString() + "','" + addjunior.IMEI.ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + addjunior.TYPE.ToString() + "','" + addjunior.USERNAME.ToString() + "','" + addjunior.ACTIVE.ToString() + "')";
                //    result = cc.ExecuteNonQuery(sql);

                //    sql = "select max(Id) from [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances]";
                //    string serverid = cc.ExecuteScalar(sql);
                //    returnString += serverid + "*" + addjunior.id.ToString() + "#";
                //}
                
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "[come2mycity].[uspIAYAddJunior]";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@usermobile",addjunior.USERMOBILE);
                         command.Parameters.Add("@appmobileno",addjunior.APPMOBILENO);
                         command.Parameters.Add("@imei",addjunior.IMEI);
                         command.Parameters.Add("@type",addjunior.TYPE);
                         command.Parameters.Add("@username",addjunior.USERNAME);
                         command.Parameters.Add("@active",addjunior.ACTIVE);
                         command.Parameters.Add("@returnid", SqlDbType.VarChar, 250);
                         command.Parameters["@returnid"].Direction = ParameterDirection.Output;
                         connection.Open();
                         result = command.ExecuteNonQuery();
                         connection.Close();

                         returnString += Convert.ToString(command.Parameters["@returnid"].Value) + "*" + addjunior.id + "#";
                    }
                }
            }

        }
        catch {
            returnString = "105";
        }
        return returnString;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string DownloadAddJunoir(string AppMobileNo, string keyword)
    {
        string sql = string.Empty; List<Addjunoir> lstjunior = new List<Addjunoir>();
        string returnstring = string.Empty;

        try
        {
            sql = "select  [Id],[UserMobile],[AppMobileNo],[IMEINumber],[keyword],[UserName],[isActive] from [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances] where [AppMobileNo]='" + AppMobileNo.ToString() + "' and [keyword]='" + keyword.ToString() + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Addjunoir AddJunior = new Addjunoir();

                    //AddJunior.id = ds.Tables[0].Rows[i]["Id"].ToString();
                    //AddJunior.USERMOBILE = ds.Tables[0].Rows[i]["UserMobile"].ToString();
                    //AddJunior.APPMOBILENO = ds.Tables[0].Rows[i]["AppMobileNo"].ToString();
                    //AddJunior.IMEI = ds.Tables[0].Rows[i]["IMEINumber"].ToString();
                    //AddJunior.TYPE = ds.Tables[0].Rows[i]["keyword"].ToString();
                    //AddJunior.USERNAME = ds.Tables[0].Rows[i]["UserName"].ToString();
                    //AddJunior.ACTIVE = ds.Tables[0].Rows[i]["isActive"].ToString();

                    //lstjunior.Add(AddJunior);
                    lstjunior.Add(new Addjunoir()
                        {
                            id = ds.Tables[0].Rows[i]["Id"].ToString(),
                            USERMOBILE = ds.Tables[0].Rows[i]["UserMobile"].ToString(),
                            APPMOBILENO = ds.Tables[0].Rows[i]["AppMobileNo"].ToString(),
                            IMEI = ds.Tables[0].Rows[i]["IMEINumber"].ToString(),
                            TYPE = ds.Tables[0].Rows[i]["keyword"].ToString(),
                            USERNAME = ds.Tables[0].Rows[i]["UserName"].ToString(),
                            ACTIVE = ds.Tables[0].Rows[i]["isActive"].ToString()
                        });
                }
            }
            else
            {
                returnstring = "106";
            }
            returnstring = JsonConvert.SerializeObject(lstjunior, theJsonSerializerSettings);
        }
        catch
        {
            returnstring = "105";
        }

        return returnstring;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateStatus(string updtjsonString)
    {
        string returnstring = string.Empty;
        string serid = string.Empty;
        try
        {
            List<Addjunoir> lstjunior = new JavaScriptSerializer().Deserialize<List<Addjunoir>>(updtjsonString);
            foreach (Addjunoir adjunr in lstjunior)
            {
                string sql = "update [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances] set [isActive]='" + adjunr.ACTIVE.ToString() + "' where [Id]=" + adjunr.id.ToString() + " and [UserMobile]='" + adjunr.USERMOBILE.ToString() + "'";
                cc.ExecuteNonQuery(sql);

                string SQl = "select max(Id) from [Come2myCityDB].[come2mycity].[tbl_IAYAddRefferances] where [Id]=" + adjunr.id.ToString() + " and [UserMobile]='" + adjunr.USERMOBILE.ToString() + "'";
                serid = cc.ExecuteScalar(SQl);
                returnstring += serid + "#";
            }
        }
        catch
        {
            returnstring = "105";
        }
        return returnstring;
    }

    public class Addjunoir
    {
        public string id { get; set; }
        public string APPMOBILENO { get; set; }
        public string USERMOBILE { get; set; }
        public string IMEI { get; set; }
        public string ModifyDate { get; set; }
        public string TYPE { get; set; }
        public string USERNAME { get; set; }
        public string ACTIVE { get; set; }
        public string UpdatedBy { get; set; }

        public string NotFound { get; set; }
        public string Error { get; set; }
    }
    #endregion

}




