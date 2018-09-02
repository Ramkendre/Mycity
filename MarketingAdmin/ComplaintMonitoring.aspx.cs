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

public partial class MarketingAdmin_ComplaintMonitoring : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCountry();
            loadMainGroup();
            txtFirstMP.Enabled = false;
            txtSecondMP.Enabled = false;
            txtThirdMP.Enabled = false;
        }
    }
    public void loadCountry()
    {
        string sql = "select countryId,countryName from CountryMaster";
        DataSet dtCountry = new DataSet();
        dtCountry = cc.ExecuteDataset(sql);
        ddlCountry.DataSource = dtCountry.Tables[0];
        ddlCountry.DataTextField = "countryName";
        ddlCountry.DataValueField = "countryId";
        ddlCountry.DataBind();
        ddlCountry.Items.Add("--Select--");
        ddlCountry.SelectedIndex = ddlCountry.Items.Count - 1;
        ddlCountry.Items[ddlCountry.Items.Count - 1].Value = "";
    }

    public void loadMainGroup()
    {
        string sql = "select GroupId,GroupName from GroupItem where GroupId in (6,7,8)";
        DataSet dtMainGroup = new DataSet();
        dtMainGroup = cc.ExecuteDataset(sql);
        ddlMainGroup.DataSource = dtMainGroup.Tables[0];
        ddlMainGroup.DataTextField = "GroupName";
        ddlMainGroup.DataValueField = "GroupId";
        ddlMainGroup.DataBind();
        ddlMainGroup.Items.Add("--Select--");
        ddlMainGroup.SelectedIndex = ddlMainGroup.Items.Count - 1;
        ddlMainGroup.Items[ddlMainGroup.Items.Count - 1].Value = "";
    }
    protected void ddlMainGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(Convert.ToString(ddlMainGroup.SelectedValue));
        string sql = "select GroupValueId,GroupValueName from GroupValue where GroupItemId=" + i.ToString() + "";
        DataSet dtSubGroup = new DataSet();
        dtSubGroup = cc.ExecuteDataset(sql);
        ddlSubGroup.DataSource = dtSubGroup.Tables[0];
        ddlSubGroup.DataTextField = "GroupValueName";
        ddlSubGroup.DataValueField = "GroupValueId";
        ddlSubGroup.DataBind();
        ddlSubGroup.Items.Add("--Select--");
        ddlSubGroup.SelectedIndex = ddlSubGroup.Items.Count - 1;
        ddlSubGroup.Items[ddlSubGroup.Items.Count - 1].Value = "";
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlCity = "select top 1 cityId from CityMaster";
        string strSubGroup = Convert.ToString(ddlSubGroup.SelectedValue);
        int SelectedSubGroupId = 0;
        if (strSubGroup != "")
            SelectedSubGroupId = Convert.ToInt32(strSubGroup);
        setEmailMP(sqlCity, SelectedSubGroupId,1);

        txtFirstMP.Enabled = true;
        txtSecondMP.Enabled = false;
        txtThirdMP.Enabled = false;
        int i = Convert.ToInt32(Convert.ToString(ddlCountry.SelectedValue));
        string sql = "select StateId,StateName from StateMaster where CountryId=" + i.ToString() + "";
        DataSet dtState = new DataSet();
        dtState = cc.ExecuteDataset(sql);
        ddlState.DataSource = dtState.Tables[0];
        ddlState.DataTextField = "StateName";
        ddlState.DataValueField = "StateId";
        ddlState.DataBind();
        ddlState.Items.Add("--Select--");
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
        ddlState.Items[ddlState.Items.Count - 1].Value = "";
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFirstMP.Enabled = false;
        txtSecondMP.Enabled = true;
        txtThirdMP.Enabled = false;

        string strState = Convert.ToString(ddlState.SelectedValue);
        int SelectedStateId = 0;
        if (strState != "")
            SelectedStateId = Convert.ToInt32(strState);

        string sqlCity = "select top 1 cityId from CityMaster where stateId = " + SelectedStateId.ToString() + "";
        string strSubGroup = Convert.ToString(ddlSubGroup.SelectedValue);
        int SelectedSubGroupId = 0;
        if (strSubGroup != "")
            SelectedSubGroupId = Convert.ToInt32(strSubGroup);
        setEmailMP(sqlCity, SelectedSubGroupId, 2);

        int i = Convert.ToInt32(Convert.ToString(ddlState.SelectedValue));
        string sql = "select distId,distName from DistrictMaster where stateId=" + i.ToString() + "";
        DataSet dtDist = new DataSet();
        dtDist = cc.ExecuteDataset(sql);
        ddlDist.DataSource = dtDist.Tables[0];
        ddlDist.DataTextField = "distName";
        ddlDist.DataValueField = "distId";
        ddlDist.DataBind();
        ddlDist.Items.Add("--Select--");
        ddlDist.SelectedIndex = ddlDist.Items.Count - 1;
        ddlDist.Items[ddlDist.Items.Count - 1].Value = "";
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFirstMP.Enabled = false;
        txtSecondMP.Enabled = false;
        txtThirdMP.Enabled = true;

        string strDist = Convert.ToString(ddlDist.SelectedValue);
        int SelectedDistId = 0;
        if (strDist != "")
            SelectedDistId = Convert.ToInt32(strDist);

        string sqlCity = "select top 1 cityId from CityMaster where distId = " + SelectedDistId.ToString() + "";
        string strSubGroup = Convert.ToString(ddlSubGroup.SelectedValue);
        int SelectedSubGroupId = 0;
        if (strSubGroup != "")
            SelectedSubGroupId = Convert.ToInt32(strSubGroup);
        setEmailMP(sqlCity, SelectedSubGroupId, 3);


        int i = Convert.ToInt32(Convert.ToString(ddlDist.SelectedValue));
        string sql = "select CityId,CityName from CityMaster where DistId=" + i.ToString() + "";
        DataSet dtCity = new DataSet();
        dtCity = cc.ExecuteDataset(sql);
        ddlCity.DataSource = dtCity.Tables[0];
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityId";
        ddlCity.DataBind();
        ddlCity.Items.Add("--Select--");
        ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        ddlCity.Items[ddlCity.Items.Count - 1].Value = "";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtEmailId.Text = "";
        txtFirstMP.Text = "";
        txtSecondMP.Text = "";
        txtThirdMP.Text = "";
    }

    public void setEmailMP(string sqlCity, int SelectedSubGroupId,int pid)
    {
        string cityId = cc.ExecuteScalar(sqlCity);
        string fetchMpEmail = "select EmailId,FirstMPerson,SecondMPerson,ThirdMPerson from tblEmailMonitoringMaster where CityId=" + cityId.ToString() + " and GroupValueId=" + SelectedSubGroupId .ToString()+ "";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(fetchMpEmail);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (pid == 1)
            {
                txtEmailId.Text = dr["EmailId"].ToString();
                txtFirstMP.Text = dr["FirstMPerson"].ToString();
                break;
            }
            else if (pid == 2)
            {
                txtEmailId.Text = dr["EmailId"].ToString();
                txtSecondMP.Text = dr["SecondMPerson"].ToString();
                break;
            }
            else if (pid == 3)
            {
                txtEmailId.Text = dr["EmailId"].ToString();
                txtThirdMP.Text = dr["ThirdMPerson"].ToString();
                break;
            }
            else {
                txtEmailId.Text = dr["EmailId"].ToString();
                txtFirstMP.Text = "";
                txtSecondMP.Text = "";
                txtThirdMP.Text = "";
                break;
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strCountry = Convert.ToString(ddlCountry.SelectedValue);

        int SelectedCountryId = 0;
        if (strCountry != "")
            SelectedCountryId = Convert.ToInt32(strCountry);
        string strState = Convert.ToString(ddlState.SelectedValue);
        int SelectedStateId = 0;
        if (strState != "")
            SelectedStateId = Convert.ToInt32(strState);
        string strDist = Convert.ToString(ddlDist.SelectedValue);
        int SelectedDistId = 0;
        if (strDist != "")
            SelectedDistId = Convert.ToInt32(strDist);
        string strCity = Convert.ToString(ddlCity.SelectedValue);
        int SelectedCityId = 0;
        if (strCity != "")
            SelectedCityId = Convert.ToInt32(strCity);
        string strSubGroup = Convert.ToString(ddlSubGroup.SelectedValue);
        int SelectedSubGroupId = 0;
        if (strSubGroup != "")
            SelectedSubGroupId = Convert.ToInt32(strSubGroup);
        if (SelectedSubGroupId > 0)
        {
            DataSet SelectedCityes = new DataSet();
            string FindCitySql = "";
            if (SelectedCityId > 0)
            {
                FindCitySql = "select cityId from CityMaster where cityId = " + SelectedCityId.ToString() + "";
            }
            else if (SelectedDistId > 0)
            {
                FindCitySql = "select cityId from CityMaster where distId = " + SelectedDistId.ToString() + "";
            }
            else if (SelectedStateId > 0)
            {
                FindCitySql = "select cityId from CityMaster where stateId = " + SelectedStateId.ToString() + "";
            }
            else if (SelectedCountryId > 0)
            {
                FindCitySql = "select cityId from CityMaster";
            }
            SelectedCityes = cc.ExecuteDataset(FindCitySql);
            string email = "", fmp = "", smp = "", tmp = "";
            email = txtEmailId.Text.ToString().Trim();
            fmp = txtFirstMP.Text.ToString().Trim();
            smp = txtSecondMP.Text.ToString().Trim();
            tmp = txtThirdMP.Text.ToString().Trim();
            int CountResult = 0;
            foreach (DataRow dr in SelectedCityes.Tables[0].Rows)
            {
                string findForUpdateSql = "select count(*) from tblEmailMonitoringMaster where CityId=" + dr["cityId"].ToString() + " and GroupValueId=" + SelectedSubGroupId.ToString() + "";
                int findCount = 0;
                string strfindCount = cc.ExecuteScalar(findForUpdateSql);
                if (strfindCount != "")
                    findCount = Convert.ToInt32(strfindCount);
                if (findCount > 0)
                {
                    string updateSql = "update tblEmailMonitoringMaster set EmailId='" + email.ToString() + "',FirstMPerson='" + fmp.ToString() + "',SecondMPerson='" + smp.ToString() + "',ThirdMPerson='" + tmp.ToString() + "' where CityId=" + dr["cityId"].ToString() + " and GroupValueId=" + SelectedSubGroupId.ToString() + "";
                    int result = cc.ExecuteNonQuery(updateSql);
                    CountResult = CountResult + result;
                }
                else
                {
                    string updateSql = "insert into tblEmailMonitoringMaster(CityId ,GroupValueId,EmailId,FirstMPerson,SecondMPerson,ThirdMPerson)";
                    updateSql += " values(" + dr["cityId"].ToString() + "," + SelectedSubGroupId.ToString() + ",'" + email.ToString() + "','" + fmp.ToString() + "','" + smp.ToString() + "','" + tmp.ToString() + "')";
                    int result = cc.ExecuteNonQuery(updateSql);
                    CountResult = CountResult + result;
                }
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('" + CountResult.ToString() + " Records Updated.')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Sub Group.')", true);

        }

    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strCity = Convert.ToString(ddlCity.SelectedValue);
        int SelectedCityId = 0;
        if (strCity != "")
            SelectedCityId = Convert.ToInt32(strCity);

        string sqlCity = "select top 1 cityId from CityMaster where cityId = " + SelectedCityId.ToString() + "";
        string strSubGroup = Convert.ToString(ddlSubGroup.SelectedValue);
        int SelectedSubGroupId = 0;
        if (strSubGroup != "")
            SelectedSubGroupId = Convert.ToInt32(strSubGroup);
        setEmailMP(sqlCity, SelectedSubGroupId, 3);
    }
}
