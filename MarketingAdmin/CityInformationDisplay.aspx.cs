using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_CityInformationDisplay : System.Web.UI.Page
{
    CityInformationBLL ctInfoBLLObj = new CityInformationBLL();
    string cId;
    int cityId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ShowCityInformation();
        }
    }


    public void ShowCityInformation()
    {
        try
        {
            cId = Convert.ToString(Request.QueryString["Id"]);
            if (cId == "" || cId == null)
            {
                cityId = Convert.ToInt32(Convert.ToString(Session["UpdateCityId"]));
            }
            else
            {
                cityId = Convert.ToInt32(Convert.ToString(Request.QueryString["Id"]));
            }
            DataTable dtCityInfoShowAll = ctInfoBLLObj.BLLGetCityInformationById(cityId);
            gvCityInfoDisplay.DataSource = dtCityInfoShowAll;
            gvCityInfoDisplay.DataBind();


            if (dtCityInfoShowAll.Rows.Count > 0)
            {
                DataRow dRow = dtCityInfoShowAll.Rows[0];
                Session["UpdateCityId"] = Convert.ToString(dRow["cityRId"]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void gvCityInfoDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
