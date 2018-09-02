using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_CityMaster : System.Web.UI.Page
{
    CountryBLL countryBLLObj = new CountryBLL();
    CityBLL cityBLLObj = new CityBLL();
    StateBLL stateBLLObj = new StateBLL();
    DistrictBLL districtBLLObj = new DistrictBLL();
    int status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CityShowAll();
            FillDDLState();
            ddlDistrict.Enabled = false;
        }
    }



    private void CityShowAll()
    {
        try
        {
            DataTable dtCityShowAll = cityBLLObj.BLLShowAllCity();
            gvCity.DataSource = dtCityShowAll;
            gvCity.DataBind();
            ViewState["CityAll"] = dtCityShowAll;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    private void FillDDLState()
    {
        try
        {
            DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
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
            string msg = ex.Message;
        }
    }

    private void CityInsertUpdate()
    {
        try
        {
            cityBLLObj.cityName = Convert.ToString(txtCityName.Text);
            cityBLLObj.distId = Convert.ToInt32(Convert.ToString(ddlDistrict.SelectedValue));
            cityBLLObj.stateId = Convert.ToInt32(Convert.ToString(ddlState.SelectedValue));

            if (Convert.ToString(ViewState["cityId"]) == "")
            {

                status = cityBLLObj.BLLInsertCity(cityBLLObj);
                if (status > 0)
                {
                    Response.Write("<script>alert('City Added ')</script>");

                }
                else
                {
                    Response.Write("<script>alert('City not added ')</script>");
                }
            }

            else
            {
                cityBLLObj.cityId = Convert.ToInt32(Convert.ToString(ViewState["cityId"]));
                status = cityBLLObj.BLLUpdateCity(cityBLLObj);
                if (status > 0)
                {
                    Response.Write("<script>alert('City Updated ')</script>");

                }
                else
                {
                    Response.Write("<script>alert('City Not Updated ')</script>");
                }
            }
           
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
        CityInsertUpdate();
        CityShowAll();
        FillDDLState();
        FillDDLState1();
        CityClearField();

        btnSubmit.Text = "Submit";
        ddlDistrict.Enabled = false;
        }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }


    private void FillDDLState1()
    {
        try
        {
            ddlDistrict.Enabled = true;
            int i = Convert.ToInt32(Convert.ToString(ddlState.SelectedValue));

            DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);

            ddlDistrict.DataSource = dtDistrictSelectBySId;
            ddlDistrict.DataTextField = "distName";
            ddlDistrict.DataValueField = "distId";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Add("---Select---");
            ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
            ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = "";


        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDistrict.Enabled = true;
            int i = Convert.ToInt32(Convert.ToString(ddlState.SelectedValue));

            DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);

            ddlDistrict.DataSource = dtDistrictSelectBySId;
            ddlDistrict.DataTextField = "distName";
            ddlDistrict.DataValueField = "distId";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Add("---Select---");
            ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
            ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void CityClearField()
    {
        try{
        txtCityName.Text = "";
        lblCount.Text = "0";
        }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
    protected void gvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
           

        gvCity.PageIndex = e.NewPageIndex;
        // DataTable dtShowCity = (DataTable)ViewState["CityAll"];
        DataTable dtCityShowAll = cityBLLObj.BLLShowAllCity();
        gvCity.DataSource = dtCityShowAll;
        gvCity.DataBind();
         }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
    protected void gvCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = gvCity.SelectedIndex;
            ViewState["cityId"] = gvCity.Rows[id].Cells[0].Text;
            txtCityName.Text = gvCity.Rows[id].Cells[1].Text;
          
            ddlState.SelectedValue = gvCity.Rows[id].Cells[4].Text;
            FillDDLState1();
            ddlDistrict.SelectedValue = gvCity.Rows[id].Cells[3].Text;
            btnSubmit.Text = "Update";
        }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
    protected void btnSearchCity_Click(object sender, EventArgs e)
    {
        try
        {
        SearchCityDetails();
         }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }

    public void SearchCityDetails()
    {
        try
     {
        cityBLLObj.cityName = Convert.ToString(txtSearchCity.Text);

        DataTable dtSearchCity = cityBLLObj.BLLGetSelectedCitySearch(cityBLLObj);
        gvCity.DataSource = dtSearchCity;
        gvCity.DataBind();
        ViewState["CityAll"] = dtSearchCity;
         }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonCode cc = new CommonCode();
            lblCount.Text = Convert.ToString(cc.ExecuteScalar("Select Count(*) from CityMaster where DistId=" + ddlDistrict.SelectedValue.ToString() + ""));
        }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
}
