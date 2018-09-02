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

public partial class Html_Trial : System.Web.UI.Page
{
    CountryBLL countryBLLObj = new CountryBLL();
    CityBLL cityBLLObj = new CityBLL();
    StateBLL stateBLLObj = new StateBLL();
    DistrictBLL districtBLLObj = new DistrictBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
            DropDownList1.DataSource = dtStateShowAll;
            DropDownList1.DataTextField = "stateName";
            DropDownList1.DataValueField = "stateId";
            DropDownList1.DataBind();
            DropDownList1.Items.Add("---Select---");
            DropDownList1.SelectedIndex = DropDownList1.Items.Count - 1;
            DropDownList1.Items[DropDownList1.Items.Count - 1].Value = "";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ss = DropDownList1.SelectedValue.ToString();
        int i = Convert.ToInt32(Convert.ToString(DropDownList1.SelectedValue));

        DataTable dtDistrictSelectBySId = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, i);

        DropDownList2.DataSource = dtDistrictSelectBySId;
        DropDownList2.DataTextField = "distName";
        DropDownList2.DataValueField = "distId";
        DropDownList2.DataBind();
        DropDownList2.Items.Add("---Select---");
        DropDownList2.SelectedIndex = DropDownList2.Items.Count - 1;
        DropDownList2.Items[DropDownList2.Items.Count - 1].Value = "";

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dId = Convert.ToInt32(Convert.ToString(DropDownList2.SelectedValue));



        DataTable dtCityShowById = cityBLLObj.BLLGetSelectedCityByDId(cityBLLObj, dId);

        DropDownList3.DataSource = dtCityShowById;
        DropDownList3.DataTextField = "cityName";
        DropDownList3.DataValueField = "cityId";
        DropDownList3.DataBind();
        DropDownList3.Items.Add("---Select---");
        DropDownList3.SelectedIndex = DropDownList3.Items.Count - 1;
        DropDownList3.Items[DropDownList3.Items.Count - 1].Value = "";

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
