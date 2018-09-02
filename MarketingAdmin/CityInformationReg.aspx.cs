using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class MarketingAdmin_CityInformationReg : System.Web.UI.Page
{
    CityInformationBLL ctInfoBLLObj = new CityInformationBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int cityId = Convert.ToInt32(Convert.ToString(Session["UpdateCityId"]));
            ShowCityInformation(cityId);
        }
    }

    public void ShowCityInformation(int cityId)
    {
        try
        {
            DataTable dtCityInfoShowAll = ctInfoBLLObj.BLLGetCityInformationById(cityId);
            DataRow cityDataRow = dtCityInfoShowAll.Rows[0];


            myCityId.Text = Convert.ToString(cityDataRow["cityRId"]);
            myCityName.Text = Convert.ToString(cityDataRow["cityName"]);
            txtCityAbout.Text = Convert.ToString(cityDataRow["cityAbout"]);
            txtArea.Text = Convert.ToString(cityDataRow["cityArea"]);
            txtLongtitude.Text = Convert.ToString(cityDataRow["cityLongtitude"]);
            txtLatitude.Text = Convert.ToString(cityDataRow["cityLatitude"]);
            txtLanguage.Text = Convert.ToString(cityDataRow["cityLanguage"]);
            txtHeightFromSea.Text = Convert.ToString(cityDataRow["cityHeightFromSea"]);
            txtLiteracy.Text = Convert.ToString(cityDataRow["cityLiteracy"]);
            txtPopulation.Text = Convert.ToString(cityDataRow["cityPopulation"]);
            txtHistoricalImp.Text = Convert.ToString(cityDataRow["cityHistoricalImp"]);
            txtGeographicalImp.Text = Convert.ToString(cityDataRow["cityGeographicalImp"]);
            txtSocialImp.Text = Convert.ToString(cityDataRow["citySocialImp"]);
            txtRegionalImp.Text = Convert.ToString(cityDataRow["cityRegionalImp"]);
            txtPoliticalImp.Text = Convert.ToString(cityDataRow["cityPoliticalImp"]);
            txtByRail.Text = Convert.ToString(cityDataRow["cityByRailApro"]);
            txtByAir.Text = Convert.ToString(cityDataRow["cityByAirApro"]);
            txtByBus.Text = Convert.ToString(cityDataRow["cityByBusApro"]);


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateCityInformation();
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    public void UpdateCityInformation()
    {
        try
        {
            ctInfoBLLObj.cityRefId = Convert.ToInt32(Convert.ToString(myCityId.Text));
            ctInfoBLLObj.cityName = myCityName.Text;
            ctInfoBLLObj.cityAbout = txtCityAbout.Text;
            ctInfoBLLObj.cityArea = txtArea.Text;
            ctInfoBLLObj.cityLongtitude = txtLongtitude.Text;
            ctInfoBLLObj.cityLatitude = txtLatitude.Text;
            ctInfoBLLObj.cityLanguage = txtLanguage.Text;
            ctInfoBLLObj.cityHeightFromSea = txtHeightFromSea.Text;
            ctInfoBLLObj.cityLiteracy = txtLiteracy.Text;
            ctInfoBLLObj.cityPopulation = txtPopulation.Text;
            ctInfoBLLObj.cityHistoricalImp = txtHistoricalImp.Text;
            ctInfoBLLObj.cityGeographicalImp = txtGeographicalImp.Text;
            ctInfoBLLObj.citySocialImp = txtSocialImp.Text;
            ctInfoBLLObj.cityRegionalImp = txtRegionalImp.Text;
            ctInfoBLLObj.cityPoliticalImp = txtPoliticalImp.Text;
            ctInfoBLLObj.cityByRailApro = txtByRail.Text;
            ctInfoBLLObj.cityByAirApro = txtByAir.Text;
            ctInfoBLLObj.cityByBusApro = txtByBus.Text;

            int status=0;
            status = ctInfoBLLObj.BLLCityInformationUpdate(ctInfoBLLObj);
            if (status > 0)
            {
               

                Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('City Information Updated');window.location.href ='../MarketingAdmin/CityInformationDisplay.aspx';", true);
               
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('City Information Not  Updated')", true);
     
                
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
