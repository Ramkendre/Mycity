using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_PublishAdvertise : System.Web.UI.Page
{
    StateBLL stateBLLObj = new StateBLL();
    CityBLL cityBLLObj = new CityBLL();
    CategoryBLL categoryBLLObj = new CategoryBLL();
    ItemCategoryBLL icBLLObj = new ItemCategoryBLL();
    AdvertiseBLL advBLLObj = new AdvertiseBLL();
    PublishAvertiseBLL pubAdvBLLObj = new PublishAvertiseBLL();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillDLLs();
        }
    }
    protected void btnAddAdvertise_Click(object sender, EventArgs e)
    {
        Response.Redirect("Advertise.aspx");
    }

    public void fillDLLs()
    {
        DataTable dtCityShowAll = cityBLLObj.BLLShowAllCity();
        ddlCity.DataSource = dtCityShowAll;
        ddlCity.DataTextField = "cityName";
        ddlCity.DataValueField = "cityId";
        ddlCity.DataBind();
        ddlCity.Items.Add("---Select---");
        ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        ddlCity.Items[ddlCity.Items.Count - 1].Value = "";


        DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
        ddlState.DataSource = dtStateShowAll;
        ddlState.DataTextField = "stateName";
        ddlState.DataValueField = "stateId";
        ddlState.DataBind();
        ddlState.Items.Add("---Select---");
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
        ddlState.Items[ddlState.Items.Count - 1].Value = "";

        DataTable dtCategory = categoryBLLObj.BLLGetAllCategory();
        ddlSelectCategory.DataSource = dtCategory;
        ddlSelectCategory.DataTextField = "categoryName";
        ddlSelectCategory.DataValueField = "categoryId";
        ddlSelectCategory.DataBind();
        ddlSelectCategory.Items.Add("---Select---");
        ddlSelectCategory.SelectedIndex = ddlSelectCategory.Items.Count - 1;
        ddlSelectCategory.Items[ddlSelectCategory.Items.Count - 1].Value = "";

        DataTable dtAdvertiseSelect = advBLLObj.BLLAdvertiseShowAll();

        ddlAdvId.DataSource = dtAdvertiseSelect;
        ddlAdvId.DataTextField = "maxId";
        ddlAdvId.DataBind();
        ddlAdvId.Items.Add("---Select---");
        ddlAdvId.SelectedIndex = ddlAdvId.Items.Count - 1;
        ddlAdvId.Items[ddlAdvId.Items.Count - 1].Value = "";

        DataTable dtAdvertiseLocation = pubAdvBLLObj.BLLAdvertiseLocation();
        ddlLocation.DataSource = dtAdvertiseLocation;
        ddlLocation.DataTextField = "LocationName";
        ddlLocation.DataValueField = "LocId";
        ddlLocation.DataBind();
        ddlLocation.Items.Add("---Select---");
        ddlLocation.SelectedIndex = ddlLocation.Items.Count - 1;
        ddlLocation.Items[ddlLocation.Items.Count - 1].Value = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        pubAdvBLLObj.AdvId = Convert.ToInt32(ddlAdvId.SelectedItem.Text).ToString();
        pubAdvBLLObj.State = ddlState.SelectedItem.Text;
        pubAdvBLLObj.City = ddlCity.SelectedItem.Text;
        pubAdvBLLObj.Category = ddlSelectCategory.SelectedItem.Text;
        pubAdvBLLObj.LocationName = ddlLocation.SelectedItem.Text;
        pubAdvBLLObj.ValidFrom = Convert.ToDateTime(txtValidFrom.Text).ToString();
        pubAdvBLLObj.ValidTo = Convert.ToDateTime(txtValidTo.Text).ToString();
        pubAdvBLLObj.Active = ddlIsActive.SelectedItem.Text;
        string dt = cc.ChangeDate(DateTime.Now.ToShortDateString());
        if ((Convert.ToDateTime(pubAdvBLLObj.ValidFrom) >= Convert.ToDateTime(DateTime.Now.ToShortDateString())) && (Convert.ToDateTime(pubAdvBLLObj.ValidTo) >= Convert.ToDateTime(pubAdvBLLObj.ValidFrom)))
        {
            bool available = pubAdvBLLObj.BLLAdvtiseCheckIfExist(pubAdvBLLObj);
            if (available == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('The advertise at this location Already Exist...')", true);
            }
            else
            {
                int j = 0;
                j = pubAdvBLLObj.InsertPublishAddInfo(pubAdvBLLObj);
                if (j == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Failed To Publish...')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Published successfully..')", true);
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Error:Validfrom date should be greater than oe equal to current date and ValidTo date should be greater or equal to ValidFrom Date.')", true);

        }
    }

}
