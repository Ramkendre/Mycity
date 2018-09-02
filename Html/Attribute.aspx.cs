using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_Attribute : System.Web.UI.Page
{
    AttributeBLL attributeBLLObj = new AttributeBLL();
    CategoryBLL categoryBLLObj = new CategoryBLL();

    int status;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllAttribute();
            FillDDLAttribute();
        }
    }

    //Saving  the new attribute
    public void InsertAttribute()
    {
        try
        {

            attributeBLLObj.attributeName = txtAttributeName.Text;
            attributeBLLObj.attributeValue = txtAttributeValue.Text;

            attributeBLLObj.attributeType = ddlAttributeType.SelectedValue;

            attributeBLLObj.categoryId = Convert.ToInt32(Convert.ToString(ddlSelectCategory.SelectedValue));

            if (Convert.ToString(ViewState["attributeId"]) == "")
            {
                status = attributeBLLObj.BLLInsertCategoryAttribute(attributeBLLObj);

                if (status == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Attribute Added.')", true);
                    LoadAllAttribute();
                    ClearField();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Attribute Not Added.')", true);
                }

            }
            else
            {
                attributeBLLObj.attributeId = Convert.ToInt32(Convert.ToString(ViewState["attributeId"]));
                status = attributeBLLObj.BLLUpdateCategoryAttribute(attributeBLLObj);

                if (status == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Attribute Updated.')", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Attribute Not Updated.')", true);
                }
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }

        ViewState["AttributeData"] = "";
    }

    //Show all the attribute
    public void LoadAllAttribute()
    {
        try
        {

            DataTable dtAttributeShowAll = attributeBLLObj.BLLShowAllAttribute();


            gvAttribute.DataSource = dtAttributeShowAll;
            gvAttribute.DataBind();
            ViewState["AttributeData"] = dtAttributeShowAll;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Paging 
    protected void gvAttribute_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAttribute.PageIndex = e.NewPageIndex;
            DataTable dtAttributeData = (DataTable)ViewState["AttributeData"];
            gvAttribute.DataSource = dtAttributeData;
            gvAttribute.DataBind();
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    //Fill the dropdown with attribute
    public void FillDDLAttribute()
    {
        try
        {
            DataTable dtCategoryShowAll = categoryBLLObj.BLLGetCategoryWOParent();

            ddlSelectCategory.DataSource = dtCategoryShowAll;
            ddlSelectCategory.DataTextField = "categoryName";
            ddlSelectCategory.DataValueField = "categoryId";
            ddlSelectCategory.DataBind();

            ddlSelectCategory.Items.Add("---Select---");
            ddlSelectCategory.SelectedIndex = ddlSelectCategory.Items.Count - 1;
            ddlSelectCategory.Items[ddlSelectCategory.Items.Count - 1].Value = "";

            cmbCategory.DataSource = dtCategoryShowAll;
            cmbCategory.DataTextField = "categoryName";
            cmbCategory.DataValueField = "categoryId";
            cmbCategory.DataBind();

            cmbCategory.Items.Add("---Select---");
            cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;
            cmbCategory.Items[cmbCategory.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    //Saving the attribute
    protected void btnSaveAttribute_Click(object sender, EventArgs e)
    {
        InsertAttribute();
        ClearField();
        LoadAllAttribute();
        FillDDLAttribute();
        btnSaveAttribute.Text = "Submit";



    }

    //Clear all the attribute
    public void ClearField()
    {
        try
        {
            txtAttributeName.Text = "";
            txtAttributeValue.Text = "";
            ddlAttributeType.SelectedItem.Text = "Select Type";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Show the Selected Record 



    public void AttributeGridSelection(int atrId)
    {
        try
        {
            ViewState["attributeId"] = gvAttribute.Rows[atrId].Cells[0].Text;
            txtAttributeName.Text = gvAttribute.Rows[atrId].Cells[1].Text;
            txtAttributeValue.Text = gvAttribute.Rows[atrId].Cells[2].Text;
          
            ddlAttributeType.SelectedValue = gvAttribute.Rows[atrId].Cells[3].Text;
            ddlSelectCategory.SelectedValue = gvAttribute.Rows[atrId].Cells[4].Text;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void gvAttribute_SelectedIndexChanged(object sender, EventArgs e)
    {try
     {

        btnSaveAttribute.Text = "Update";
        int atrId = Convert.ToInt32(gvAttribute.SelectedIndex);

        AttributeGridSelection(atrId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        attributeBLLObj.categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
        DataTable dtAttributeShowAll = attributeBLLObj.BLLShowAttributeByCategoryId(attributeBLLObj);


        gvAttribute.DataSource = dtAttributeShowAll;
        gvAttribute.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
