using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class MarketingAdmin_Category : System.Web.UI.Page
{
    CategoryBLL categoryBLLObj = new CategoryBLL();
    int status;
    DataTable dtCategory = new DataTable();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllCategory();
            FillDDLCategory();
            BindParentCategory();
        }
    }
    public void BindParentCategory()
    {
        string sql = "select [categoryId],[categoryName] from [Come2myCityDB].[dbo].[Category]";
        DataSet ds = cc.ExecuteDataset(sql);

        cmbCategory.DataSource = ds.Tables[0];
        cmbCategory.DataTextField = "categoryName";
        cmbCategory.DataValueField = "categoryId";
        cmbCategory.DataBind();

        //cmbCategory.Items.Add("---Select Parent---");
        //cmbCategory.Items.Add("---Select---");
        //cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;
        //cmbCategory.Items[cmbCategory.Items.Count - 1].Value = "";

        cmbCategory.Items.Insert(0, new ListItem("--Select--", "0"));
        cmbCategory.SelectedIndex = 0;
    }

    //Inserting a new category
    public void InsertCategory()
    {
        try
        {
            categoryBLLObj.categoryId = Convert.ToInt32(Convert.ToString(Request.QueryString["id"]));
            categoryBLLObj.categoryName = txtCategoryName.Text;

            if (ddlSelectParent.Text == "---Set Parent---")
            {
                categoryBLLObj.parentCategoryId = -1;
                categoryBLLObj.catLevel = 1;
            }
            else
            {
                categoryBLLObj.parentCategoryId = Convert.ToInt32(ddlSelectParent.SelectedValue);
                int level = categoryBLLObj.BLLGetSelectedCategoryLevel(categoryBLLObj);
                categoryBLLObj.catLevel = level + 1;
            }
            if (Convert.ToString(ViewState["categoryId"]) == "")
            {
                status = categoryBLLObj.BLLInsertCategory(categoryBLLObj);
                if (status == 1)
                {
                    Response.Write("<script>alert('Category Inserted')</script>");

                    clearAll();
                }
                else
                {
                    Response.Write("<script>alert('Category already present')</script>");
                }
            }
            else
            {
                categoryBLLObj.categoryId = Convert.ToInt32(Convert.ToString(ViewState["categoryId"]));

                status = categoryBLLObj.BLLUpdateCategory(categoryBLLObj);

                if (status == 1)
                {
                    Response.Write("<script>alert('Category Updated')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Category Not Updated Successfully')</script>");
                }
            }

        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }


    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        InsertCategory();
        FillDDLCategory();
        GetAllCategory();
        btnSaveCategory.Text = "Submit";
        clearAll();
    }

    //Displays all the category in the grid view
    public void GetAllCategory()
    {
        try
        {
            dtCategory = categoryBLLObj.BLLGetAllCategory();
            gvCategory.DataSource = dtCategory;
            gvCategory.DataBind();
            ViewState["CategoryData"] = dtCategory;
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    //Populate the Category in the drop down list
    public void FillDDLCategory()
    {
        try
        {
            DataTable dtCategoryAll = categoryBLLObj.BLLGetAllCategory();

            ddlSelectParent.DataSource = dtCategoryAll;
            ddlSelectParent.DataTextField = "categoryName";
            ddlSelectParent.DataValueField = "categoryId";
            ddlSelectParent.DataBind();


            ddlSelectParent.Items.Add("---Set Parent---");
            ddlSelectParent.Items.Add("---Select---");
            ddlSelectParent.SelectedIndex = ddlSelectParent.Items.Count - 1;
            ddlSelectParent.Items[ddlSelectParent.Items.Count - 1].Value = "";

            //ddlSelectParent.Items.Insert(1, new ListItem("--Set Parent--", "1"));
            //ddlSelectParent.SelectedIndex = 1;
            //ddlSelectParent.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlSelectParent.SelectedIndex = 0;
            

        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }

    }

    //Clear the textbox & drop down list
    public void clearAll()
    {
        txtCategoryName.Text = "";

    }



    //For Paging Purpose of gvCategory  
    protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategory.PageIndex = e.NewPageIndex;
        DataTable dtCategoryData = (DataTable)ViewState["CategoryData"];
        gvCategory.DataSource = dtCategoryData;
        gvCategory.DataBind();
    }

    public void AttributeGridSelection(int catId)
    {
        try
        {
            ViewState["categoryId"] = gvCategory.Rows[catId].Cells[0].Text;
            txtCategoryName.Text = gvCategory.Rows[catId].Cells[1].Text;
            if (gvCategory.Rows[catId].Cells[2].Text == "-1")
            {
                ddlSelectParent.SelectedItem.Text = "---Set Parent---";
            }
            else
            {
                ddlSelectParent.SelectedValue = gvCategory.Rows[catId].Cells[2].Text;
            }

        }
        catch (Exception ex)
        {

            string m = ex.Message;
        }
    }

    protected void gvCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSaveCategory.Text = "Update";

        int id = gvCategory.SelectedIndex;

        AttributeGridSelection(id);
    }

    //protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try{
    //    categoryBLLObj.categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

    //  DataTable dtShowCategoryById = categoryBLLObj.BLLGetSelectedCategory(categoryBLLObj);

    //    gvCategory.DataSource = dtShowCategoryById;
    //    gvCategory.DataBind();
    //    }
    //    catch
    //    {

    //    }
    //}

    protected void ddlSelectParent_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    public void Clear()
    {
        txtCategoryName.Text = "";
        txtSearchCategoryName.Text = "";
       // ddlSelectParent.SelectedItem.Text = "--Select--";
      //  cmbCategory.SelectedItem.Text = "--Select--";
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sql = string.Empty;
        DataSet ds = new DataSet();
        try
        {
            if (txtSearchCategoryName.Text != "")
            {
                sql = "select [categoryId],[categoryName],[parentCategoryId] from [Come2myCityDB].[dbo].[Category] where [categoryName] like '%"+ txtSearchCategoryName.Text +"%'";
              //  ds = cc.ExecuteDataset(sql);
            }
            else
            {
                if (cmbCategory.SelectedItem.Text == "---Select---")
                {
                    sql = "select [categoryId],[categoryName],[parentCategoryId] from [Come2myCityDB].[dbo].[Category]";
                    // ds = cc.ExecuteDataset(sql);
                }
                else if (cmbCategory.SelectedItem.Text == "---Select Parent---")
                {
                    sql = "select [categoryId],[categoryName],[parentCategoryId] from [Come2myCityDB].[dbo].[Category] Where [parentCategoryId]='-1'";
                    // ds = cc.ExecuteDataset(sql);
                }
                else
                {
                    sql = "select [categoryId],[categoryName],[parentCategoryId] from [Come2myCityDB].[dbo].[Category] where [parentCategoryId]='" + cmbCategory.SelectedValue + "'";
                    //ds = cc.ExecuteDataset(sql);
                }
            }
            ds = cc.ExecuteDataset(sql);
            gvCategory.DataSource = ds.Tables[0];
            gvCategory.DataBind();

            Clear();
        }
        catch
        {

        }
    }
}
