using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;

public partial class MarketingAdmin_IAYExcelUpload : System.Web.UI.Page
{
    
    string usrMobileNo1 = "9158696413";
    StateBLL stateBLLObj = new StateBLL();
    DistrictBLL districtBLLObj = new DistrictBLL();
    StateDAL objStateDal = new StateDAL();
    public string path;
    string conPath = string.Empty;
    OleDbConnection conn;
    CommonCode cc = new CommonCode();
    string excelSubject = "IAY";
    string firstName = "", lastName = "", mobileNumber = "",ApprovalDate="", adharNumber = "", bankName = "", bankAccNo = "", bankIFSC = "";
    int updateCount = 0, insertCount = 0;

    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            usrMobileNo1 = Convert.ToString(Session["MarketingUser"]);
            ShowAllState();
            BindGridDetails();
        }
    }

    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        path = Server.MapPath("IAYFilesUpload");
        path = path + "\\" + excelFileUpload.FileName;

        if (Path.GetExtension(path) == ".xls")
        {
            conPath = @"provider=Microsoft.Jet.OLEDB.4.0;data source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        }
        else
        {
            conPath = @"provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
        }

        conn = new OleDbConnection(conPath);

        try
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
            tempDs = new DataSet();
            adapter.Fill(tempDs);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('6 " + ex.Message + "');", true);
        }

        return tempDs;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string RLID = string.Empty;
            //string roleId = Session["RoleId"].ToString();
            //string sql = "Select RoleId from [Come2myCityDB].[come2mycity].[SubMenuPermission] where [UnderRole]='" + roleId + "' ";

            //string SQL = "select [usrUserId] from [Come2myCityDB].[dbo].[UserMaster] where [usrMobileNo]='" + Session["MobileNumber"].ToString() + "'";
            //DataSet ds = cc.ExecuteDataset(SQL);
            //string uid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
            //string sql = "select [RoeId] from [Come2myCityDB].[come2mycity].[MartketingSubuser] where  [Uid1]='"+ uid +"'";
            //DataSet DS = cc.ExecuteDataset(sql);
            //RLID = Convert.ToString(DS.Tables[0].Rows[0]["RoeId"]);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            //    {
            //       RLID = ds.Tables[0].Rows[r][0].ToString();

              //  if (RLID == "121" || RLID == "122")
              //{
                if (excelFileUpload.HasFile)
                { 
                    path = Server.MapPath("IAYFilesUpload");
                    path = path + "\\" + excelFileUpload.FileName;
                    string ab = excelFileUpload.FileName;

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        excelFileUpload.SaveAs(path);
                    }
                    else
                    {
                        excelFileUpload.SaveAs(path);
                    }

                    string strQuery = "SELECT * FROM [" + excelSubject + "$]";
                    DataSet dscount = GetDataTable(strQuery);
                    int count2 = Convert.ToInt32(dscount.Tables[0].Rows.Count);

                    if (count2 > 0)
                    {
                        for (int i = 0; i < count2; i++)
                        {
                            string srno = dscount.Tables[0].Rows[i]["SrNo"].ToString();
                            mobileNumber = dscount.Tables[0].Rows[i]["MobileNumber"].ToString();
                            firstName = dscount.Tables[0].Rows[i]["FirstName"].ToString();
                            ApprovalDate = dscount.Tables[0].Rows[i]["ApprovalDate"].ToString();
                            //lastName = dscount.Tables[0].Rows[i]["LastName"].ToString();
                            //adharNumber = dscount.Tables[0].Rows[i]["AadharNumber"].ToString();
                            //bankName = dscount.Tables[0].Rows[i]["BankName"].ToString();
                            //bankIFSC = dscount.Tables[0].Rows[i]["IFSCCode"].ToString();
                            //bankAccNo = dscount.Tables[0].Rows[i]["AccountNo"].ToString();

                            InsertIAYDetails();
                        }

                        if (cmd.Connection.State == ConnectionState.Open) { con.Close(); }
                        lblResult.Text = insertCount + " Record Added and " + updateCount + " Updated";
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        BindGridDetails();
                    }
                }
                //}
                //else
                //{
                //    lblResult.Text = "Please Choose Excel File to Upload.";
                //    lblResult.ForeColor = System.Drawing.Color.Red;
                //}
           // }
           
                //else
                //{
                //    lblResult.Text = "Please Choose Excel File to Upload.";
                //    lblResult.ForeColor = System.Drawing.Color.Red;
                //}

          //  }
            //else
            //{
                //lblResult.Text = "Not Permission to upload the Excel File.......";
                //lblResult.ForeColor = System.Drawing.Color.Red;
                //Page.ClientScript.RegisterStartupScript(typeof(Page), "Msg", "alert('Not Permission to upload Excel File!!!!!!')", true);
            //}

        }
        catch (Exception ex)
        {
            string errMsg = ex.Message;
            lblResult.Text = errMsg;
            lblResult.ForeColor = System.Drawing.Color.Red;
        }
    }

    public int InsertIAYDetails()
    {
        try
        {
            string sqlGet = "SELECT * FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] WHERE [PBMobileNo] = '" + mobileNumber + "'";
            cmd.CommandText = sqlGet;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                string sqlQuery = " UPDATE [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] SET [PBFirstName]=N'" + firstName + "',[PBLastName]='null',[PBAdharNo]='88956987485',[PBBankACNo]='665559988779',[PBBankName]='State Bank of India,Pune',[PBIFSC_Code]='SBI0000008',[PBStateId]=" + ddlState.SelectedValue + ",[PBDistrictId]=" + ddlDistrict.SelectedValue + ",[PBBlockId]=" + ddlBlock.SelectedValue + ",[PBCircleId]=" + ddlGramPanchayat.SelectedValue + ",[PBVillageId]=" + ddlVillage.SelectedValue + ",[PBApprovalDt]='" + ApprovalDate + "',[ModifiedBy]='" + usrMobileNo1 + "',[ModifiedDate]='" + System.DateTime.Now + "' WHERE [PBMobileNo]='" + mobileNumber + "'";

                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                if (cmd.Connection.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                updateCount++;
            }
            else
            {
                string sqlQuery = " INSERT INTO [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] ([PBMobileNo],[PBFirstName],[PBLastName],[PBAdharNo],[PBBankACNo],[PBBankName],[PBIFSC_Code],[PBStateId],[PBDistrictId],[PBBlockId],[PBCircleId],[PBVillageId],[PBApprovalDt],[CreatedBy],[CreatedDate],[PBGramPanchayatName],[PBVillageName]) " +
                                  " VALUES ('" + mobileNumber + "',N'" + firstName + "','null','88956987485','665559988779','State Bank of India,Pune','SBI0000008'," + ddlState.SelectedValue + "," + ddlDistrict.SelectedValue + "," + ddlBlock.SelectedValue + "," + ddlGramPanchayat.SelectedValue + "," + ddlVillage.SelectedValue + ",'" + ApprovalDate +"','" + usrMobileNo1 + "','" + System.DateTime.Now.ToString() + "','"+ ddlGramPanchayat.SelectedItem.Text +"','"+  ddlBlock.SelectedItem.Text +"') ";   //txtApprovalDate.Text

                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                if (cmd.Connection.State == ConnectionState.Closed) { con.Open(); }
                cmd.ExecuteNonQuery();
                insertCount++;
            }
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    private void ShowAllState()
    {
        try
        {
            string sql = "SELECT [stateId],[stateName] FROM [Come2myCityDB].[dbo].[StateMaster]";
            cmd.Connection = con;
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            DataTable dtStateShowAll = new DataTable();
            da.Fill(dtStateShowAll);
            //DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
            ddlState.DataSource = dtStateShowAll;
            ddlState.DataTextField = "stateName";
            ddlState.DataValueField = "stateId";
            ddlState.DataBind();
            ddlState.Items.Add("---Select---");
            ddlState.SelectedIndex = ddlState.Items.Count - 1;
            ddlState.Items[ddlState.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //try
        //{
        //    DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
        //    ddlState.DataSource = dtStateShowAll;
        //    ddlState.DataTextField = "stateName";
        //    ddlState.DataValueField = "stateId";
        //    ddlState.DataBind();
        //    ddlState.Items.Add("---Select---");
        //    ddlState.SelectedIndex = ddlState.Items.Count - 1;
        //    ddlState.Items[ddlState.Items.Count - 1].Value = "";
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ss = ddlState.SelectedItem.Text;
        int i = Int32.Parse(ddlState.SelectedValue);

        string sql = "SELECT [distId],[distName] FROM [Come2myCityDB].[dbo].[DistrictMaster] WHERE [stateId]=" + i + " ";
        cmd.Connection = con;
        cmd.CommandText = sql;
        da.SelectCommand = cmd;
        DataTable dtDistrictSelectBySId = new DataTable();
        da.Fill(dtDistrictSelectBySId);

        //DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);
       // DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);

        ddlDistrict.DataSource = dtDistrictSelectBySId;
        ddlDistrict.DataTextField = "distName";
        ddlDistrict.DataValueField = "distId";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Add("---Select---");
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = "";
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ss = ddlDistrict.SelectedItem.Text;
        int i = Int32.Parse(ddlDistrict.SelectedValue);
        string sql = "SELECT [cityId],[cityName] FROM [Come2myCityDB].[dbo].[CityMaster] WHERE [distId]=" + i + " ";
        cmd.Connection = con;
        cmd.CommandText = sql;
        da.SelectCommand = cmd;
        DataTable dtBlockSelectBySId = new DataTable();
        da.Fill(dtBlockSelectBySId);

        //DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);
        ddlBlock.DataSource = dtBlockSelectBySId;
        ddlBlock.DataTextField = "cityName";
        ddlBlock.DataValueField = "cityId";
        ddlBlock.DataBind();
        ddlBlock.Items.Add("---Select---");
        ddlBlock.SelectedIndex = ddlBlock.Items.Count - 1;
        ddlBlock.Items[ddlBlock.Items.Count - 1].Value = "";
    }

    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ss = ddlBlock.SelectedItem.Text;
        int i = Int32.Parse(ddlBlock.SelectedValue);
        string sql = "SELECT [TalukaId],[TalukaName] FROM [Come2myCityDB].[come2mycity].[TalukaMaster] WHERE [cityId]=" + i + " ";
        cmd.Connection = con;
        cmd.CommandText = sql;
        da.SelectCommand = cmd;
        DataTable dtGramPanchayatSelectBySId = new DataTable();
        da.Fill(dtGramPanchayatSelectBySId);

        //DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);
        ddlGramPanchayat.DataSource = dtGramPanchayatSelectBySId;
        ddlGramPanchayat.DataTextField = "TalukaName";
        ddlGramPanchayat.DataValueField = "TalukaId";
        ddlGramPanchayat.DataBind();
        ddlGramPanchayat.Items.Add("---Select---");
        ddlGramPanchayat.SelectedIndex = ddlGramPanchayat.Items.Count - 1;
        ddlGramPanchayat.Items[ddlGramPanchayat.Items.Count - 1].Value = "";

        DataTable dtVillageSelectBySId = new DataTable();
        da.Fill(dtVillageSelectBySId);
        ddlVillage.DataSource = dtVillageSelectBySId;
        ddlVillage.DataTextField = "TalukaName";
        ddlVillage.DataValueField = "TalukaId";
        ddlVillage.DataBind();
        ddlVillage.Items.Add("---Select---");
        ddlVillage.SelectedIndex = ddlVillage.Items.Count - 1;
        ddlVillage.Items[ddlVillage.Items.Count - 1].Value = "";
    }

    public void BindGridDetails()
    {
        string sqlQuery = "SELECT [IAYP_Id],[PBMobileNo],[PBFirstName],[PBLastName],[PBAdharNo],[PBBankACNo],[PBBankName],[PBIFSC_Code],[PBStateId],[PBDistrictId],[PBBlockId],[PBCircleId],[PBVillageId],[PBApprovalDt],[CreatedBy],[CreatedDate] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData] ORDER BY [IAYP_Id] DESC";
        DataTable dt = objStateDal.GetRecordsIAY(sqlQuery);

        if (dt.Rows.Count > 0)
        {
            gvPersonalDetails.DataSource = dt;
            gvPersonalDetails.DataBind();
        }
        else
        {
            gvPersonalDetails.EmptyDataText = "NO RECORDS FOUND..!!!";
            gvPersonalDetails.DataBind();
        }
    }
    protected void btnDownloadExcelSheet_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/IAYFileUploadFormat/IAYDataUploadFormated.xlsx");
    }
    protected void gvPersonalDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersonalDetails.PageIndex = e.NewPageIndex;
        BindGridDetails();
    }


   
}