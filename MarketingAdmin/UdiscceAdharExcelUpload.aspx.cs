using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

public partial class Student_UdiscceAdharExcelUpload : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string ConnPath = "", Sql;
   

    string schoolId, TeacherMobileNo, message, date, Empmobile;
    //myct1.SendEmail myctconnect = new myct1.SendEmail();
   
    // Import SendEmail of myct
  

    string pathOnly = string.Empty;
    string fileName = string.Empty;
    string conPath = "";
    OleDbConnection conn = null;
    DataSet tds = new DataSet();

    Excel.Application xlApp;
    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    Excel.Range range;

    SqlConnection dbCon = null;

    DataSet dsItem = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["SC_ID"]
        if (!IsPostBack)
        {
            string sql = "SELECT [ItemValueId],[ItemId],[col1] FROM [DBeZeeSchool].[dbo].[ItemValue] where col1!=''";
            getItems(sql);
        }
    }

    void getItems(string sql)
    {
        dbCon = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"].ToString());
        SqlDataAdapter da = new SqlDataAdapter(sql, dbCon);
        da.Fill(dsItem);
    }

    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;

        if (Path.GetExtension(path1) == ".xls")
        {
            conPath = "provider=Microsoft.Jet.OLEDB.4.0;data source="
                    + path1
                    + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";

            conn = new OleDbConnection(conPath);
            try
            {
                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
                tempDs = new DataSet();
                adapter.Fill(tempDs);
            }
            catch (Exception ex) { }
            conn.Close();
        }
        return tempDs;
    }

    string path1 = "";
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        insCount = dupli = 0;
        string strQuery = "SELECT SCHCD,AC_YEAR,[AADHAAR_MASTER$].STUDID,DOADMN,ADMNNUM,BPL_YN,DISADV_YN,FREEEDU_YN,INCLASS_C,INCLASS_P,CLS1STATUS,DAYSATTEND,MEDINSTR,DISABILITY,UNIFORMSET,TRNSPRT_YN,ESCORT_YN,HOSTELTYPE,FACILCWSN_P,FACILCWSN_C, " +
                   "TEXTBK_YN,SPLTRNG_YN,MIGRATE_C,MIGRATE_P,HOMELESSID,AADHAARID,STUDNAME,FATHNAME,MOTHNAME,HABITATION,DOBIRTH,GENDER,SOCIALCAT,MINORITYID,MOTHTOUNGE,ISACTIVE,AADHAARENROLMENTNO " +
                   "FROM [AADHAAR_MASTER$] inner join [AADHAAR_DETAILS$] on [AADHAAR_DETAILS$].STUDID = [AADHAAR_MASTER$].STUDID";

        dbCon = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"].ToString());

        try
        {
            if (databasefile.HasFile)
            {
                path1 = Server.MapPath("File_Upload");
                path1 = path1 + "\\" + databasefile.FileName;
                ViewState["path1"] = path1;

                if (File.Exists(path1))
                {
                    File.Delete(path1);
                    databasefile.SaveAs(path1);
                    tds = GetDataTable(strQuery);
                }
                else
                {
                    databasefile.SaveAs(path1);
                    tds = GetDataTable(strQuery);
                }

                existingAdnum(tds);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please Select Excel File (.xls) to Upload!');", true);

            if ((insCount) > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + insCount + " new records added successfully!');", true);
            if ((dupli) > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Excel contains " + dupli + " duplicate Admission No!');", true);
        }

        catch (Exception ex)
        {
            if (ex.Message.Contains("Input String"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Input String was not in Correct Format. \nPlease check Admission No Column of Excel File');", true);
                // MessageBox.Show("Input String was not in Correct Format. \n Check Admission No Column of Excel File");
            }
            else
            {
                //MessageBox.Show(ex.Message);
            }
        }
        finally
        {
        }
    }

    int count = 0;
    DataSet chkDs = null;
    string txtAdmnNo, txtStudName, txtFatherName, txtMomName, txtHabitation, txtAdhaar, txtDOB, txtDOA,
        txtDaysAttend, txtSchoolCode, txtStudIdConv, txtStudId, lblCounter, txtMotherTounge, txtIsActive, txtAdhaarEnrollNo, txtFacility_C,
        txtMIGRATE_C, txtMIGRATE_P, txtAcademicYear = "", txtTeacherId, txtDateTime;
    string cmbGender, cmbSocialCat, cmbReligion, cmbBPL, cmbDisadv, cmbCurrClass, cmbPrvClass, cmbClsStatus, cmbMediumInstr, cmbDisability,
        cmbRetAct, cmbFacility, cmbTextbook, cmbUniform, cmbTransport, cmbEscort, cmbHostel, cmbTraining, cmbHomeless;

    void existingAdnum(DataSet dsA)
    {        
        string MenuId = "";
        string schoolcode = "";
        string sql = "select UdiseAddmissionId from AddmissionMaster ";
        try
        {
            foreach (DataRow dr in dsA.Tables[0].Rows)
            {
                MenuId = MenuId + ",'" + dr["ADMNNUM"].ToString() + "'";
                schoolcode = schoolcode + ",'" + dr["SCHCD"].ToString() + "'";
            }
            if (MenuId.Length > 1)
            {
                MenuId = MenuId.Substring(1);
                schoolcode = schoolcode.Trim(',');
            }

            if (!(MenuId == null || MenuId == ""))
            {
                sql = sql + " where SchoolCode in("+schoolcode+") and  UdiseAddmissionId in (" + MenuId + ") order by UdiseAddmissionId asc";
            }

            SqlDataAdapter da = new SqlDataAdapter(sql, dbCon);
            chkDs = new DataSet();
            da.Fill(chkDs);

            if (chkDs.Tables[0].Rows.Count > 0)
            {
                Cache["chkDs"] = chkDs; //Cache the dataset.......

                DataRow dr = chkDs.Tables[0].NewRow();
                dr[0] = "--Select--";
                chkDs.Tables[0].Rows.InsertAt(dr, 0);

                ddlAdmission.DataSource = chkDs.Tables[0];
                ddlAdmission.DataTextField = "UdiseAddmissionId";
                ddlAdmission.DataValueField = "UdiseAddmissionId";
                ddlAdmission.DataBind();
                ddlAdmission.SelectedIndex = 0;
            }
            else
            {
                dbCon.Open();
                foreach (DataRow row in tds.Tables[0].Rows)
                {
                    try
                    {
                        BindExcelData(row);

                        count++;
                        if (txtAdmnNo == "")
                        {
                            int sheetNo = Convert.ToInt32(1);                 //Sheet No.

                            xlApp = new Excel.ApplicationClass();
                            xlWorkBook = xlApp.Workbooks.Open(path1, 0, true, 1, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetNo);

                            range = xlWorkSheet.UsedRange;

                            while (xlWorkSheet.Cells.Rows.Count >= 0)
                            {
                                txtAdmnNo = Convert.ToString(((Excel.Range)xlWorkSheet.Cells[count, 5]).Value2);
                                break;
                            }
                        }

                        if (txtAdmnNo == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Admission No. Not Provided for this record!');", true);
                            break;
                        }
                        else
                        {                            
                            insertFunction();
                        }
                    }
                    catch { }
                    finally
                    {
                        txtAdmnNo = "";
                    }
                }               
            }
        }
        catch (Exception ex)
        {
        }
        finally { dbCon.Close(); }
    }

    void BindExcelData(DataRow row)
    {
        # region Enumerate Each row

        txtSchoolCode = row["SCHCD"].ToString();  //schoolCode
        txtAcademicYear = row["AC_YEAR"].ToString();
        txtStudId = row["STUDID"].ToString();  //StudId as per excel

        txtAdmnNo = Convert.ToString(row["ADMNNUM"]);  //studName           

        if (txtSchoolCode.Length>0)
        {
            cmbCurrClass = row["INCLASS_C"].ToString();

            //loadCounter();  //studId converted to our software

            txtStudName = row["STUDNAME"].ToString();  //studName
            txtFatherName = row["FATHNAME"].ToString();  //studName
            txtMomName = row["MOTHNAME"].ToString();  //studName
            txtHabitation = row["HABITATION"].ToString();  //studName
            txtAdhaar = row["AADHAARID"].ToString();  //studName

            txtDOB = row["DOBIRTH"].ToString();  //DOB dd/mm/yyyy
            txtDOA = row["DOADMN"].ToString();  //DOA dd/mm/yyyy

            txtDaysAttend = row["DAYSATTEND"].ToString();  //studName

            # region ReplaceFieldValues

            string sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                   "where [ItemValue].[ItemId]='61' and [ItemValue].col1='"
                   + row["GENDER"].ToString() + "'";
            DataSet ds1 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                 "where [ItemValue].[ItemId]='62' and [ItemValue].col1='"
                 + row["SOCIALCAT"].ToString() + "'";
            DataSet ds2 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='63' and [ItemValue].col1='"
                + row["MINORITYID"].ToString() + "'";
            DataSet ds3 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='64' and [ItemValue].col1='"
                + row["BPL_YN"].ToString() + "'";
            DataSet ds4 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='65' and [ItemValue].col1='"
                + row["DISADV_YN"].ToString() + "'";
            DataSet ds5 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='71' and [ItemValue].col1='"
                + row["FREEEDU_YN"].ToString() + "'";
            DataSet ds6 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='66' and [ItemValue].col1='"
                + row["INCLASS_C"].ToString() + "'";
            DataSet ds7 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='67' and [ItemValue].col1='"
                + row["INCLASS_P"].ToString() + "'";
            DataSet ds8 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='68' and [ItemValue].col1='"
                + row["CLS1STATUS"].ToString() + "'";
            DataSet ds9 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='69' and [ItemValue].col1='"
                + row["MEDINSTR"].ToString() + "'";
            DataSet ds10 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='70' and [ItemValue].col1='"
                + row["DISABILITY"].ToString() + "'";
            DataSet ds11 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='72' and [ItemValue].col1='"
                + row["FACILCWSN_P"].ToString() + "'";
            DataSet ds12 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='73' and [ItemValue].col1='"
                + row["TEXTBK_YN"].ToString() + "'";
            DataSet ds13 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='74' and [ItemValue].col1='"
                + row["UNIFORMSET"].ToString() + "'";
            DataSet ds14 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='75' and [ItemValue].col1='"
                + row["TRNSPRT_YN"].ToString() + "'";
            DataSet ds15 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='76' and [ItemValue].col1='"
                + row["ESCORT_YN"].ToString() + "'";
            DataSet ds16 = cc.SchoolDataset(sql);

            sql = "Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='77' and [ItemValue].col1='"
                + row["HOSTELTYPE"].ToString() + "'";
            DataSet ds17 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='78' and [ItemValue].col1='"
                + row["SPLTRNG_YN"].ToString() + "'"; //training
            DataSet ds18 = cc.SchoolDataset(sql);

            sql = " Select [ItemValue].[ItemValueId] from [ItemValue] " +
                "where [ItemValue].[ItemId]='79' and [ItemValue].col1='"
                + row["HOMELESSID"].ToString() + "'";
            DataSet ds19 = cc.SchoolDataset(sql);

            if (ds1.Tables[0].Rows.Count >= 1)
                cmbGender = ds1.Tables[0].Rows[0][0].ToString();

            if (ds2.Tables[0].Rows.Count >= 1)
                cmbSocialCat = ds2.Tables[0].Rows[0][0].ToString();

            if (ds3.Tables[0].Rows.Count >= 1)
                cmbReligion = ds3.Tables[0].Rows[0][0].ToString();

            if (ds4.Tables[0].Rows.Count >= 1)
                cmbBPL = ds4.Tables[0].Rows[0][0].ToString();

            if (ds5.Tables[0].Rows.Count >= 1)
                cmbDisadv = ds5.Tables[0].Rows[0][0].ToString();

            if (ds6.Tables[0].Rows.Count >= 1)
                cmbRetAct = ds6.Tables[0].Rows[0][0].ToString();

            if (ds7.Tables[0].Rows.Count >= 1)
                cmbCurrClass = ds7.Tables[0].Rows[0][0].ToString();

            if (ds8.Tables[0].Rows.Count >= 1)
                cmbPrvClass = ds8.Tables[0].Rows[0][0].ToString();

            if (ds9.Tables[0].Rows.Count >= 1)
                cmbClsStatus = ds9.Tables[0].Rows[0][0].ToString();

            if (ds10.Tables[0].Rows.Count >= 1)
                cmbMediumInstr = ds10.Tables[0].Rows[0][0].ToString();

            if (ds11.Tables[0].Rows.Count >= 1)
                cmbDisability = ds11.Tables[0].Rows[0][0].ToString();

            if (ds12.Tables[0].Rows.Count >= 1)
                cmbFacility = ds12.Tables[0].Rows[0][0].ToString();

            if (ds13.Tables[0].Rows.Count >= 1)
                cmbTextbook = ds13.Tables[0].Rows[0][0].ToString();

            if (ds14.Tables[0].Rows.Count >= 1)
                cmbUniform = ds14.Tables[0].Rows[0][0].ToString();

            if (ds15.Tables[0].Rows.Count >= 1)
                cmbTransport = ds15.Tables[0].Rows[0][0].ToString();

            if (ds16.Tables[0].Rows.Count >= 1)
                cmbEscort = ds16.Tables[0].Rows[0][0].ToString();

            if (ds17.Tables[0].Rows.Count >= 1)
                cmbHostel = ds17.Tables[0].Rows[0][0].ToString();

            if (ds18.Tables[0].Rows.Count >= 1)
                cmbTraining = ds18.Tables[0].Rows[0][0].ToString();

            if (ds19.Tables[0].Rows.Count >= 1)
                cmbHomeless = ds19.Tables[0].Rows[0][0].ToString();


            # endregion

            txtMotherTounge = row["MOTHTOUNGE"].ToString();  //extra field
            txtIsActive = row["ISACTIVE"].ToString();  //extra field
            txtAdhaarEnrollNo = row["AADHAARENROLMENTNO"].ToString();  //extra field
            txtFacility_C = row["FACILCWSN_C"].ToString();  //extra field
            txtMIGRATE_C = row["MIGRATE_C"].ToString();  //extra field
            txtMIGRATE_P = row["MIGRATE_P"].ToString();  //extra field
        }
        else
        {
            //MessageBox.Show("School Code Different as Excel file Selected!");
            throw new Exception("School Code is Different !");
        }

        # endregion
    }

    SqlCommand cmd1 = new SqlCommand();
    int insCount = 0;
    int upCount = 0;
    int dupli = 0;
    void insertFunction()
    {
        try
        {
            string str = "select UdiseAddmissionId from AddmissionMaster where UdiseAddmissionId='" + Convert.ToInt32(txtAdmnNo) + "' and SchoolCode='" + Convert.ToString(txtSchoolCode) + "'";
            cmd1 = new SqlCommand(str, dbCon);
            if (Convert.ToString(cmd1.ExecuteScalar()) == "")
            {
                str = "insert into AddmissionMaster(StudentName,UdiseAddmissionId,FatherName,MotherName,HabitationName,AdhaarName,DOB,AddmissionDate" +
                                           ",Gender,Category,Religion,BelongToBPL,Dis_Group,Class,Pre_AcademicYear,CentreName,attendedDay,Medium,Disability" +
                                           ",RTE_Act,CWSN,FreeTestBook,UnifromSet,Transportfacility,Escortfacility,Hostelfacility,SpecialTraning,ChildIsHomeless,SchoolCode" +
                                           ",StudentId_Excel" +
                                           ",MotherToungeUdise,IsActive,Facility_C,Migrate_C,Migrate_P" +
                                           ",TeacherId,DateModified)";

                str += " values(@StudentName,@UdiseAddmissionId,@FatherName,@MotherName,@HabitationName,@AdhaarName,@DOB,@AddmissionDate" +
                                            ",@Gender,@Category,@Religion,@BelongToBPL,@Dis_Group,@Class,@Pre_AcademicYear,@previousSchoolStatus,@attendedDay,@Medium,@Disability" +
                                            ",@RTE_Act,@CWSN,@FreeTestBook,@UnifromSet,@Transportfacility,@Escortfacility,@Hostelfacility,@SpecialTraning,@ChildIsHomeless,@SchoolCode" +
                                            ",@StudentId_Excel" +
                                            ",@MotherToungeUdise,@IsActive,@Facility_C,@Migrate_C,@Migrate_P" +
                                            ",@TeacherId,@DateModified)";

                cmd1 = new SqlCommand(str, dbCon);
                cmd1.Parameters.AddWithValue("@UdiseAddmissionId", Convert.ToInt32(txtAdmnNo));
                cmd1.Parameters.AddWithValue("@StudentName", txtStudName);
                cmd1.Parameters.AddWithValue("@FatherName", txtFatherName);
                cmd1.Parameters.AddWithValue("@MotherName", txtMomName);
                cmd1.Parameters.AddWithValue("@HabitationName", txtHabitation);
                cmd1.Parameters.AddWithValue("@AdhaarName", txtAdhaar);

                cmd1.Parameters.AddWithValue("@DOB", txtDOB);
                cmd1.Parameters.AddWithValue("@AddmissionDate", txtDOA);

                cmd1.Parameters.AddWithValue("@Gender", cmbGender);
                //9                       
                cmd1.Parameters.AddWithValue("@Category", Convert.ToInt32(cmbSocialCat));
                cmd1.Parameters.AddWithValue("@Religion", Convert.ToInt32(cmbReligion));
                cmd1.Parameters.AddWithValue("@BelongToBPL", Convert.ToInt32(cmbBPL));
                cmd1.Parameters.AddWithValue("@Dis_Group", Convert.ToInt32(cmbDisadv));
                cmd1.Parameters.AddWithValue("@Class", Convert.ToInt32(cmbCurrClass));
                cmd1.Parameters.AddWithValue("@Pre_AcademicYear", Convert.ToInt32(cmbPrvClass));
                cmd1.Parameters.AddWithValue("@previousSchoolStatus", cmbClsStatus);
                cmd1.Parameters.AddWithValue("@attendedDay", Convert.ToInt32(txtDaysAttend));
                cmd1.Parameters.AddWithValue("@Medium", Convert.ToInt32(cmbMediumInstr));
                cmd1.Parameters.AddWithValue("@Disability", Convert.ToInt32(cmbDisability));
                //11
                cmd1.Parameters.AddWithValue("@RTE_Act", Convert.ToInt32(cmbRetAct));         //free education unaided
                cmd1.Parameters.AddWithValue("@CWSN", Convert.ToInt32(cmbFacility));
                cmd1.Parameters.AddWithValue("@FreeTestBook", Convert.ToInt32(cmbTextbook));
                cmd1.Parameters.AddWithValue("@UnifromSet", Convert.ToInt32(cmbUniform));
                cmd1.Parameters.AddWithValue("@Transportfacility", Convert.ToInt32(cmbTransport));
                cmd1.Parameters.AddWithValue("@Escortfacility", Convert.ToInt32(cmbEscort));
                cmd1.Parameters.AddWithValue("@Hostelfacility", Convert.ToInt32(cmbHostel));
                cmd1.Parameters.AddWithValue("@SpecialTraning", Convert.ToInt32(cmbTraining));
                cmd1.Parameters.AddWithValue("@ChildIsHomeless", Convert.ToInt32(cmbHomeless));

                cmd1.Parameters.AddWithValue("@SchoolCode", txtSchoolCode);
                //cmd1.Parameters.AddWithValue("@StudentCode", txtStudIdConv);        //generated by udise cce s/w
                cmd1.Parameters.AddWithValue("@StudentId_Excel", txtStudId);        //generated by udise excel file

                //cmd1.Parameters.AddWithValue("@FormNo", lblCounter);
                cmd1.Parameters.AddWithValue("@MotherToungeUdise", txtMotherTounge);
                //cmd1.Parameters.AddWithValue("@AdhaarName", txtIsActive);
                cmd1.Parameters.AddWithValue("@IsActive", txtIsActive);
                cmd1.Parameters.AddWithValue("@Facility_C", txtFacility_C);
                cmd1.Parameters.AddWithValue("@Migrate_C", txtMIGRATE_C);
                cmd1.Parameters.AddWithValue("@Migrate_P", txtMIGRATE_P);

                cmd1.Parameters.AddWithValue("@TeacherId", "");
                cmd1.Parameters.AddWithValue("@DateModified", "");
                //TodayDateTime()

                int i = cmd1.ExecuteNonQuery();


                if (i > 0)
                {
                    insCount++;
                }
            }
            else
                dupli++;
        }
        catch (Exception ex) { }
        finally
        {            
        }
    }

    void updateFunction()
    {
        try
        {
            //dbCon.Open();

            string str = "update AddmissionMaster set StudentName=@StudentName,FatherName=@FatherName,MotherName=@MotherName,HabitationName=@HabitationName,AdhaarName=@AdhaarName,DOB=@DOB,AddmissionDate=@AddmissionDate,Gender=@Gender" +
                ",Category=@Category,Religion=@Religion,BelongToBPL=@BelongToBPL,Dis_Group=@Dis_Group,Class=@Class,Pre_AcademicYear=@Pre_AcademicYear" +
                ",CentreName=@previousSchoolStatus,attendedDay=@attendedDay,Medium=@Medium" +
            ",Disability=@Disability,RTE_Act=@RTE_Act,CWSN=@CWSN,FreeTestBook=@FreeTestBook,UnifromSet=@UnifromSet,Transportfacility=@Transportfacility,Escortfacility=@Escortfacility,Hostelfacility=@Hostelfacility,SpecialTraning=@SpecialTraning,ChildIsHomeless=@ChildIsHomeless" +
            ",SchoolCode=@SchoolCode,StudentId_Excel=@StudentId_Excel,MotherToungeUdise=@MotherToungeUdise,IsActive=@IsActive,Facility_C=@Facility_C,Migrate_C=@Migrate_C,Migrate_P=@Migrate_P,TeacherId=@TeacherId,DateModified=@DateModified";
            str += " where UdiseAddmissionId=@UdiseAddmissionId";

            cmd1 = new SqlCommand(str, dbCon);
            cmd1.Parameters.AddWithValue("@UdiseAddmissionId", Convert.ToInt32(txtAdmnNo));
            cmd1.Parameters.AddWithValue("@StudentName", txtStudName);
            cmd1.Parameters.AddWithValue("@FatherName", txtFatherName);
            cmd1.Parameters.AddWithValue("@MotherName", txtMomName);
            cmd1.Parameters.AddWithValue("@HabitationName", txtHabitation);
            cmd1.Parameters.AddWithValue("@AdhaarName", txtAdhaar);

            cmd1.Parameters.AddWithValue("@DOB", txtDOB);
            cmd1.Parameters.AddWithValue("@AddmissionDate", txtDOA);

            cmd1.Parameters.AddWithValue("@Gender", cmbGender);
            //9                       
            cmd1.Parameters.AddWithValue("@Category", Convert.ToInt32(cmbSocialCat));
            cmd1.Parameters.AddWithValue("@Religion", Convert.ToInt32(cmbReligion));
            cmd1.Parameters.AddWithValue("@BelongToBPL", Convert.ToInt32(cmbBPL));
            cmd1.Parameters.AddWithValue("@Dis_Group", Convert.ToInt32(cmbDisadv));
            cmd1.Parameters.AddWithValue("@Class", Convert.ToInt32(cmbCurrClass));
            cmd1.Parameters.AddWithValue("@Pre_AcademicYear", Convert.ToInt32(cmbPrvClass));
            cmd1.Parameters.AddWithValue("@previousSchoolStatus", cmbClsStatus);
            cmd1.Parameters.AddWithValue("@attendedDay", Convert.ToInt32(txtDaysAttend));
            cmd1.Parameters.AddWithValue("@Medium", Convert.ToInt32(cmbMediumInstr));
            cmd1.Parameters.AddWithValue("@Disability", Convert.ToInt32(cmbDisability));
            //11
            cmd1.Parameters.AddWithValue("@RTE_Act", Convert.ToInt32(cmbRetAct));         //free education unaided
            cmd1.Parameters.AddWithValue("@CWSN", Convert.ToInt32(cmbFacility));
            cmd1.Parameters.AddWithValue("@FreeTestBook", Convert.ToInt32(cmbTextbook));
            cmd1.Parameters.AddWithValue("@UnifromSet", Convert.ToInt32(cmbUniform));
            cmd1.Parameters.AddWithValue("@Transportfacility", Convert.ToInt32(cmbTransport));
            cmd1.Parameters.AddWithValue("@Escortfacility", Convert.ToInt32(cmbEscort));
            cmd1.Parameters.AddWithValue("@Hostelfacility", Convert.ToInt32(cmbHostel));
            cmd1.Parameters.AddWithValue("@SpecialTraning", Convert.ToInt32(cmbTraining));
            cmd1.Parameters.AddWithValue("@ChildIsHomeless", Convert.ToInt32(cmbHomeless));

            cmd1.Parameters.AddWithValue("@SchoolCode", txtSchoolCode);
            //cmd1.Parameters.AddWithValue("@StudentCode", txtStudIdConv);        //generated by udise cce s/w
            cmd1.Parameters.AddWithValue("@StudentId_Excel", txtStudId);        //generated by udise excel file
            //cmd1.Parameters.AddWithValue("@FormNo", lblCounter);
            cmd1.Parameters.AddWithValue("@MotherToungeUdise", txtMotherTounge);
            //cmd1.Parameters.AddWithValue("@AdhaarName", txtIsActive);
            cmd1.Parameters.AddWithValue("@IsActive", txtIsActive);
            cmd1.Parameters.AddWithValue("@Facility_C", txtFacility_C);
            cmd1.Parameters.AddWithValue("@Migrate_C", txtMIGRATE_C);
            cmd1.Parameters.AddWithValue("@Migrate_P", txtMIGRATE_P);

            cmd1.Parameters.AddWithValue("@TeacherId", "");
            cmd1.Parameters.AddWithValue("@DateModified", "");
            //TodayDateTime()

            int i = cmd1.ExecuteNonQuery();
            if (i == 1)
            {
                upCount++;
            }
        }
        catch (Exception ex) { }
        finally
        {

        }
    }

    void clear()
    {
        txtAdmnNo = txtStudName = txtFatherName = txtMomName = txtHabitation = txtAdhaar = txtDOB = txtDOA =
        txtDaysAttend = txtSchoolCode = txtStudIdConv = txtStudId = lblCounter = txtMotherTounge = txtIsActive = txtAdhaarEnrollNo = txtFacility_C =
        txtMIGRATE_C = txtMIGRATE_P = txtTeacherId = txtDateTime = "";

        cmbGender = cmbSocialCat = cmbReligion = cmbBPL = cmbDisadv = cmbCurrClass = cmbPrvClass = cmbClsStatus = cmbMediumInstr = cmbDisability =
        cmbRetAct = cmbFacility = cmbTextbook = cmbUniform = cmbTransport = cmbEscort = cmbHostel = cmbTraining = cmbHomeless = "";
    }

    string studCode = "";
    //18 digit studcode =
    //11 digit for school Code + 2 digit for class + 1 for division + 1 for session + 3 for counter      
    void loadCounter()
    {
        try
        {
            string sql = "select max(FormNo) from AddmissionMaster where SchoolCode='" + tds.Tables[0].Rows[0]["SCHCD"].ToString() + "' and class='" + cmbCurrClass + "'";           //division not used due to excel upload problem
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, dbCon);
            da.Fill(ds);
            try
            {
                sql = ds.Tables[0].Rows[0][0].ToString();
                lblCounter = (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
                string[] classId = cmbCurrClass.Split('.'); // Master.MDIParent1._classText.Split('.');
                int divId = 0;  // arr[0] - 'A' + 1;

                if (lblCounter.Length == 1)
                    lblCounter = "00" + lblCounter;
                else if (lblCounter.Length == 2)
                    lblCounter = "0" + lblCounter;
                //"1" for session 2013-14
                //studCode = Main.Session["SC_ID"].ToString() + classId[0] + divId.ToString() + "1" + lblCounter.Text;

                studCode = classId[0] + divId.ToString() + "1" + lblCounter;
            }
            catch
            {
                lblCounter = "1";
                //lblRollNo.Text = "Roll No.:" + Session["SC_ID"].ToString().ToString() + Master.MDIParent1._classValue.ToString() + Master.MDIParent1._sectionValue.ToString() + "1" + lblCounter.Text;

                string[] classId = cmbCurrClass.Split('.'); //Master.MDIParent1._classText.Split('.');
                if (classId[0].Length == 1)
                    classId[0] = "0" + classId[0];

                //char[] arr = Master.MDIParent1._sectionText.ToCharArray();
                int divId = 0;  // arr[0] - 'A' + 1;

                if (lblCounter.Length == 1)
                    lblCounter = "00" + lblCounter;
                else if (lblCounter.Length == 2)
                    lblCounter = "0" + lblCounter;
                //"1" for session 2013-14
                //studCode = Session["SC_ID"].ToString() + classId[0] + divId.ToString() + "1" + lblCounter.Text;

                studCode =  classId[0] + divId.ToString() + "1" + lblCounter;
            }

            txtStudIdConv = studCode;

        }
        catch { }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        insCount = upCount = dupli = 0;
        path1 = Convert.ToString(ViewState["path1"]);
        btnAddNew.Enabled = false;
        int count = 0;

        string strQuery = "SELECT SCHCD,AC_YEAR,[AADHAAR_MASTER$].STUDID,DOADMN,ADMNNUM,BPL_YN,DISADV_YN,FREEEDU_YN,INCLASS_C,INCLASS_P,CLS1STATUS,DAYSATTEND,MEDINSTR,DISABILITY,UNIFORMSET,TRNSPRT_YN,ESCORT_YN,HOSTELTYPE,FACILCWSN_P,FACILCWSN_C, " +
                          "TEXTBK_YN,SPLTRNG_YN,MIGRATE_C,MIGRATE_P,HOMELESSID,AADHAARID,STUDNAME,FATHNAME,MOTHNAME,HABITATION,DOBIRTH,GENDER,SOCIALCAT,MINORITYID,MOTHTOUNGE,ISACTIVE,AADHAARENROLMENTNO " +
                          "FROM [AADHAAR_MASTER$] inner join [AADHAAR_DETAILS$] on [AADHAAR_DETAILS$].STUDID = [AADHAAR_MASTER$].STUDID";

        string MenuId = "";
        try
        {
            chkDs = (DataSet)Cache["chkDs"];
            if (chkDs.Tables[0].Rows[0][0].ToString().Contains("--Select--"))
                chkDs.Tables[0].Rows.RemoveAt(0);

            foreach (DataRow dr2 in chkDs.Tables[0].Rows)
            {
                MenuId = MenuId + ",'" + dr2["UdiseAddmissionId"].ToString() + "'";
            }
            if (MenuId.Length > 1)
            {
                MenuId = MenuId.Substring(1);
            }

            if (!(MenuId == null || MenuId == ""))
            {
                strQuery = strQuery + " where ADMNNUM not in (" + MenuId + ") order by ADMNNUM asc";
            }

            DataSet ExcelDs = GetDataTable(strQuery);

            if (ExcelDs.Tables[0].Rows.Count > 0)
            {
                dbCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
                dbCon.Open();
                foreach (DataRow row in ExcelDs.Tables[0].Rows)
                {
                    try
                    {
                        count++;
                        BindExcelData(row);
                        insertFunction();
                    }
                    catch { }
                    finally
                    {
                    }
                }
                dbCon.Close();
            }
            else
            {
            }

            if ((insCount) > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + insCount + " new records added successfully!');", true);
            if ((dupli) > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Excel contains " + dupli + " duplicate Admission No!');", true);

        }
        catch (Exception ex)
        { }
        finally
        {
            dbCon.Close();
            insCount = 0;
            btnAddNew.Enabled = true;
        }
    }

    protected void btnReplaceAll_Click(object sender, EventArgs e)
    {
        btnReplaceAll.Enabled = false;
        int count = 0;
        upCount = insCount = dupli = 0;
        dbCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

        try
        {
            chkDs = (DataSet)Cache["chkDs"];
            if (chkDs.Tables[0].Rows[0][0].ToString().Contains("--Select--"))
                chkDs.Tables[0].Rows.RemoveAt(0);

            path1 = Convert.ToString(ViewState["path1"]);
            string strQuery = "SELECT SCHCD,AC_YEAR,[AADHAAR_MASTER$].STUDID,DOADMN,ADMNNUM,BPL_YN,DISADV_YN,FREEEDU_YN,INCLASS_C,INCLASS_P,CLS1STATUS,DAYSATTEND,MEDINSTR,DISABILITY,UNIFORMSET,TRNSPRT_YN,ESCORT_YN,HOSTELTYPE,FACILCWSN_P,FACILCWSN_C, " +
    "TEXTBK_YN,SPLTRNG_YN,MIGRATE_C,MIGRATE_P,HOMELESSID,AADHAARID,STUDNAME,FATHNAME,MOTHNAME,HABITATION,DOBIRTH,GENDER,SOCIALCAT,MINORITYID,MOTHTOUNGE,ISACTIVE,AADHAARENROLMENTNO " +
    "FROM [AADHAAR_MASTER$] inner join [AADHAAR_DETAILS$] on [AADHAAR_DETAILS$].STUDID = [AADHAAR_MASTER$].STUDID";

            tds = GetDataTable(strQuery);

            dbCon.Open();
            foreach (DataRow row in tds.Tables[0].Rows)
            {
                try
                {
                    BindExcelData(row);
                    count++;

                    if (txtAdmnNo == "")
                    {
                        int sheetNo = Convert.ToInt32(1);                 //Sheet No.

                        xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                        xlWorkBook = xlApp.Workbooks.Open(path1, 0, true, 1, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetNo);

                        range = xlWorkSheet.UsedRange;

                        while (xlWorkSheet.Cells.Rows.Count >= 0)
                        {
                            txtAdmnNo = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[count, 5]).Value2);
                            break;
                        }
                    }

                    if (txtAdmnNo == "")
                    {
                        //MessageBox.Show("Admission No. Not Provided for this record!");
                        break;
                    }

                    if (chkDs.Tables[0].Select("UdiseAddmissionId=" + txtAdmnNo).Count() == 0)//[0]["UdiseAddmissionId"].ToString();
                        insertFunction();
                    else
                    {
                        //update existing record.....    
                        updateFunction();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message != "School Code is Different !")
                        insertFunction();
                }
                finally { txtAdmnNo = ""; }
            }

            if ((insCount + upCount) > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + insCount + " new records added successfully! and \n" + upCount + " records updated successfully!');", true);
            if ((dupli) > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Excel contains " + dupli + " duplicate Admission No!');", true);

            insCount = 0;
            upCount = 0;
        }
        catch (Exception ex)
        {
            dbCon.Close();
        }
        finally
        {
            dbCon.Close();
            btnReplaceAll.Enabled = true;
        }
    }
}
