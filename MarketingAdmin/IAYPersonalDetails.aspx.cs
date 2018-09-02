using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class MarketingAdmin_IAYPersonalDetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string usrMobileNo1 = "9158696413";
    StateBLL stateBLLObj = new StateBLL();
    DistrictBLL districtBLLObj = new DistrictBLL();
    StateDAL objStateDal = new StateDAL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //usrMobileNo1 = Convert.ToString(Session["MarketingUser"]);
            //ShowAllState();
            //BindGridDetails();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@BMobNo", txtBMobileNo.Text);
                cmd.Parameters.AddWithValue("@BFirstName", txtBFName.Text);
                cmd.Parameters.AddWithValue("@BLastName", txtBLName.Text);
                cmd.Parameters.AddWithValue("@BAdharNo", txtAdharNo.Text);
                cmd.Parameters.AddWithValue("@BBankAcno", txtBankAcno.Text);
                cmd.Parameters.AddWithValue("@BBankName", txtBankName.Text);
                cmd.Parameters.AddWithValue("@BIFSCCode", txtIFSCCode.Text);
                cmd.Parameters.AddWithValue("@BStateId", ddlState.SelectedValue);
                cmd.Parameters.AddWithValue("@BDistrictId", ddlDistrict.SelectedValue);
                cmd.Parameters.AddWithValue("@BBlockId", ddlBlock.SelectedValue);
                cmd.Parameters.AddWithValue("@BGramPanchayat", ddlGramPanchayat.SelectedValue);
                cmd.Parameters.AddWithValue("@BVillage", ddlVillage.SelectedValue); //1);
                cmd.Parameters.AddWithValue("@BApprovalDt", txtApprovalDate.Text);
                cmd.Parameters.AddWithValue("@UserId", usrMobileNo1);

                cmd.CommandText = "uspIAYPersonalData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                if (cmd.Connection.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                lblResult.Text = "Record Added Successfully...!!!";
                BindGridDetails();
            }
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
    }


    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ss = ddlState.SelectedItem.Text;
        int i = Int32.Parse(ddlState.SelectedValue);
        string sql = "SELECT [distId],[distName] FROM [Come2myCityDB].[dbo].[DistrictMaster] WHERE [stateId]="+ i +" ";
        cmd.Connection = con;
        cmd.CommandText = sql;
        da.SelectCommand = cmd;
        DataTable dtDistrictSelectBySId = new DataTable();
        da.Fill(dtDistrictSelectBySId);

        //DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);
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
        ddlBlock.Items[ddlDistrict.Items.Count - 1].Value = "";
    }

    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ss = ddlBlock.SelectedItem.Text;
        int i = Int32.Parse(ddlBlock.SelectedValue);
        string sql = "SELECT [cityId],[cityName] FROM [Come2myCityDB].[dbo].[CityMaster] WHERE [cityId]=" + i + " ";
        cmd.Connection = con;
        cmd.CommandText = sql;
        da.SelectCommand = cmd;
        DataTable dtGramPanchayatSelectBySId = new DataTable();
        da.Fill(dtGramPanchayatSelectBySId);

        //DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);
        ddlGramPanchayat.DataSource = dtGramPanchayatSelectBySId;
        ddlGramPanchayat.DataTextField = "cityName";
        ddlGramPanchayat.DataValueField = "cityId";
        ddlGramPanchayat.DataBind();
        ddlGramPanchayat.Items.Add("---Select---");
        ddlGramPanchayat.SelectedIndex = ddlGramPanchayat.Items.Count - 1;
        ddlGramPanchayat.Items[ddlDistrict.Items.Count - 1].Value = "";
    }

    protected void ddlGramPanchayat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ss = ddlGramPanchayat.SelectedItem.Text;
        int i = Int32.Parse(ddlGramPanchayat.SelectedValue);
        string sql = "SELECT [cityId],[cityName] FROM [Come2myCityDB].[dbo].[CityMaster] WHERE [distId]=" + i + " ";
        cmd.Connection = con;
        cmd.CommandText = sql;
        da.SelectCommand = cmd;
        DataTable dtVillageSelectBySId = new DataTable();
        da.Fill(dtVillageSelectBySId);

        //DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);
        ddlVillage.DataSource = dtVillageSelectBySId;
        ddlVillage.DataTextField = "cityName";
        ddlVillage.DataValueField = "cityId";
        ddlVillage.DataBind();
        ddlVillage.Items.Add("---Select---");
        ddlVillage.SelectedIndex = ddlVillage.Items.Count - 1;
        ddlVillage.Items[ddlDistrict.Items.Count - 1].Value = "";
    }
    public void BindGridDetails()
    {
        string sqlQuery = "SELECT [IAYP_Id],[PBMobileNo],[PBFirstName],[PBLastName],[PBAdharNo],[PBBankACNo],[PBBankName],[PBIFSC_Code],[PBStateId],[PBDistrictId],[PBBlockId],[PBCircleId],[PBVillageId],[PBApprovalDt],[CreatedBy],[CreatedDate] FROM [Come2myCityDB].[come2mycity].[tbl_IAYPersonalData]";
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

   
}
