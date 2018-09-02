using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

public partial class MarketingAdmin_ItemCategory : System.Web.UI.Page
{
    CategoryBLL categoryBLLObj = new CategoryBLL();
    ItemCategoryBLL icBLLObj = new ItemCategoryBLL();
    AttributeBLL attributeBLLObj = new AttributeBLL();
    ItemCategoryAttributeBLL icaBLLObj = new ItemCategoryAttributeBLL();
    ItemBLL itemBLLObj = new ItemBLL();
    DataTable dtCategory = new DataTable();
    DataTable dtAttribute = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
            BindItem();
            ddlSelectCategory.Enabled = false;
        }
    }

    //Populate the Category in the dropdownlist
    private void BindCategory()
    {
        try
        {

            dtCategory = categoryBLLObj.BLLGetCategoryWOParent();
            ddlSelectCategory.DataSource = dtCategory;
            ddlSelectCategory.DataTextField = "categoryName";
            ddlSelectCategory.DataValueField = "categoryId";
            ddlSelectCategory.DataBind();
            ddlSelectCategory.Items.Add("---Select---");
            ddlSelectCategory.SelectedIndex = ddlSelectCategory.Items.Count - 1;
            ddlSelectCategory.Items[ddlSelectCategory.Items.Count - 1].Value = "";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Po9pulate the Item to the Drop Down List
    private void BindItem()
    {
        try
        {
            DataTable dtItemShowAll = itemBLLObj.BLLShowAllItem();
            ddlSelectItem.DataSource = dtItemShowAll;
            ddlSelectItem.DataTextField = "itemName";
            ddlSelectItem.DataValueField = "itemId";
            ddlSelectItem.DataBind();
            ddlSelectItem.Items.Add("---Select---");
            ddlSelectItem.SelectedIndex = ddlSelectItem.Items.Count - 1;
            ddlSelectItem.Items[ddlSelectItem.Items.Count - 1].Value = "";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //On Selecting the Item , Category Should be Loaded
    protected void ddlSelectItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlSelectCategory.Enabled = true;
            icBLLObj.itemICId = Convert.ToString(ddlSelectItem.SelectedValue);

            List<ItemCategoryBLL> icList = new List<ItemCategoryBLL>();
            icList = icBLLObj.BLLGetSelectedCityByItemId(icBLLObj);
            ddlSelectCategory.DataSource = icList;
            ddlSelectCategory.DataTextField = "catName";
            ddlSelectCategory.DataValueField = "categoryICId";
            ddlSelectCategory.DataBind();
            ddlSelectCategory.Items.Add("---Select---");
            ddlSelectCategory.SelectedIndex = ddlSelectCategory.Items.Count - 1;
            ddlSelectCategory.Items[ddlSelectCategory.Items.Count - 1].Value = "";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //On Selecting the Category, All the Attribute is displayed
    protected void ddlSelectCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowAllItemCategoryAttribute();
    }

    //Show all the Attribute for the Item & Category 
    private void ShowAllItemCategoryAttribute()
    {
        try
        {
            attributeBLLObj.categoryId = Convert.ToInt32(Convert.ToString(ddlSelectCategory.SelectedValue));
            attributeBLLObj.itemAId = Convert.ToString(ddlSelectItem.SelectedValue);

            dtAttribute = attributeBLLObj.BLLGetCategoryWiseAttribute(attributeBLLObj);


            dtlUpdateData.DataSource = dtAttribute;
            dtlUpdateData.DataBind();


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //ShowAllCategory();
    }


    //Update All the Data For that Item & Category
    protected void btnApply_Click(object sender, EventArgs e)
    {
        try
        {
            bool flag = false;

            Label lblFieldName = new Label();
            Label lblIcaId = new Label();
            Label lblAttributeId = new Label();
            TextBox txtFieldValue = new TextBox();

            foreach (DataListItem dtlItem in dtlUpdateData.Items)
            {
                txtFieldValue = (TextBox)dtlItem.FindControl("txtFieldValue");

                lblFieldName = (Label)dtlItem.FindControl("lblFieldName");
                lblIcaId = (Label)dtlItem.FindControl("lblIcaId");
                lblAttributeId = (Label)dtlItem.FindControl("lblattributeId");


                AjaxControlToolkit.FilteredTextBoxExtender fteText = new AjaxControlToolkit.FilteredTextBoxExtender();
                fteText.TargetControlID = "txtFieldValue";
               
                fteText.FilterType = AjaxControlToolkit.FilterTypes.Numbers;
                fteText.Enabled = true;
                

                icaBLLObj.attributeIdICA = Convert.ToInt32(Convert.ToString(lblAttributeId.Text));
                icaBLLObj.categoryIdICA = Convert.ToInt32(Convert.ToString(ddlSelectCategory.SelectedValue));
                icaBLLObj.itemIdICA = Convert.ToString(ddlSelectItem.SelectedValue);
                icaBLLObj.attributeValueICA = Convert.ToString(txtFieldValue.Text);
                icaBLLObj.icaId = Convert.ToInt32(Convert.ToString(lblIcaId.Text));
                flag = icaBLLObj.BLLIsExistItemCategoryAttribute(icaBLLObj);
                if (flag == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated')", true);
                }
                else
                {
                }

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated')", true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void dtlUpdateData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
