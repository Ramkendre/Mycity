using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Html_CityInfoPage : System.Web.UI.Page
{
    CityInformationBLL ctInfoBLLObj = new CityInformationBLL();
    public string ctAbout;
    public string ctLatitude;
    public string ctLongtitude;
    public string ctArea;
    public string ctHeightFromSea;
    public string ctLanguage;
    public string ctLiteracy;
    public string ctPopulation;
    public string ctHI;
    public string ctGI;
    public string ctSI;
    public string ctRI;
    public string ctPI;
    public string ctByRail;
    public string ctByAir;
    public string ctByBus;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //string cityId = Convert.ToString(Request.QueryString["cityId"]);
            string cityId = Convert.ToString(Session["City"]); 
            
        }
        try
        {
            ShowHomeCityInfo();
        }
        catch (Exception)
        { }
    }

    //Show City Information about City
    public void ShowHomeCityInfo()
    {
        try
        {
            int cityId = Convert.ToInt32(Convert.ToString(Session["City"]));
            DataTable dtCityInfoShowAll = ctInfoBLLObj.BLLGetCityInformationById(cityId);

            gvCityInfo.DataSource = dtCityInfoShowAll;
            gvCityInfo.DataBind();
            if (dtCityInfoShowAll.Rows.Count != 0)
            {
                DataRow dRowCity = dtCityInfoShowAll.Rows[0];
                Session["cityName"] = dRowCity["cityName"];
                ctAbout = Convert.ToString(dRowCity["cityAbout"]);
                ctLatitude = Convert.ToString(dRowCity["cityLatitude"]);
                ctLongtitude = Convert.ToString(dRowCity["cityLongtitude"]);
                ctArea = Convert.ToString(dRowCity["cityArea"]);
                ctHeightFromSea = Convert.ToString(dRowCity["cityHeightFromSea"]);
                ctLanguage = Convert.ToString(dRowCity["cityLanguage"]);
                ctLiteracy = Convert.ToString(dRowCity["cityLiteracy"]);
                ctPopulation = Convert.ToString(dRowCity["cityPopulation"]);
                ctHI = Convert.ToString(dRowCity["cityHistoricalImp"]);
                ctGI = Convert.ToString(dRowCity["cityGeographicalImp"]);
                ctSI = Convert.ToString(dRowCity["citySocialImp"]);
                ctRI = Convert.ToString(dRowCity["cityRegionalImp"]);
                ctPI = Convert.ToString(dRowCity["cityPoliticalImp"]);
                ctByRail = Convert.ToString(dRowCity["cityByRailApro"]);
                ctByAir = Convert.ToString(dRowCity["cityByAirApro"]);
                ctByBus = Convert.ToString(dRowCity["cityByBusApro"]);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
