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

public partial class MarketingAdmin_Item : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    CategoryBLL categoryBLLObj = new CategoryBLL();
    ItemBLL itemBLLObj = new ItemBLL();
    CityBLL cityBLLObj = new CityBLL();
    ItemCategoryBLL icBLLObj = new ItemCategoryBLL();
    ItemCategoryAttributeBLL icaBLLObj = new ItemCategoryAttributeBLL();
    StateBLL stateBLLObj = new StateBLL();
    DistrictBLL districtBLLObj = new DistrictBLL();
    string path = HttpContext.Current.Request.PhysicalApplicationPath + "Item_Resource\\";

    DataTable dtCategory = new DataTable();
    bool imageOk = false;
    int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowAllItem();
           
            FillChkList();
            LoadPlace();
            cmbDistrict.Enabled = false;
            cmbCity.Enabled = false;
            itemBLLObj.itemId = Convert.ToString(Request.QueryString["id"]);
            GetSelectedItem(itemBLLObj);
        }
    }

    //Add & Update the Item
    public void InsertItem()
    {

        bool fileSaved = false;
        string getCategory = "";
        for (int k = 0; k < chkLstCategory.Items.Count; k++)     //Get all the category to which item will be inserted
        {
            if (chkLstCategory.Items[k].Selected == true)
            {
                getCategory += Convert.ToString(chkLstCategory.Items[k].Value) + ",";
            }
        }
        if (cmbCity.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select City')", true);
        }
        else if (getCategory == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Category')", true);
        }
        else
        {
            try
            {
                itemBLLObj.itemName = txtItemName.Text;
                itemBLLObj.itemDescription = txtItemDescription.Text;
                itemBLLObj.cityId = Convert.ToInt32(Convert.ToString(cmbCity.SelectedValue));
                itemBLLObj.itemActive = 1;


                //for (int k = 0; k < chkLstCategory.Items.Count; k++)     //Get all the category to which item will be inserted
                //{
                //    if (chkLstCategory.Items[k].Selected == true)
                //    {
                //        getCategory += Convert.ToString(chkLstCategory.Items[k].Value) + ",";
                //    }
                //}

                int id = getCategory.Length;
                string categotyId = getCategory.Substring(0, id - 1);

                if (Convert.ToString(ViewState["EditImage"]) != "1")
                {
                    itemBLLObj.itemId = System.Guid.NewGuid().ToString();   //Creates a GUID as new Item Id
                    itemBLLObj.categoryId = categotyId;
                    string thisDir = Server.MapPath("~");

                    if (!System.IO.Directory.Exists(thisDir + "\\Item_Resource\\" + itemBLLObj.itemId))  //Creates a folder named that of GIUD(itemId)
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\Item_Resource\\" + itemBLLObj.itemId);
                    }
                    System.Random round = new Random();
                    string rndImage = Convert.ToString(round.Next(1, 9999));

                    if (uplSelectImage.HasFile)
                    {
                        itemBLLObj.itemImage = uplSelectImage.FileName;
                        imageOk = cc.CheckImageExtension(itemBLLObj.itemImage);  //check for correct image extension
                    }

                    if (imageOk == true)
                    {
                        try
                        {
                            uplSelectImage.PostedFile.SaveAs(path + "\\" + itemBLLObj.itemId + "\\" + rndImage + itemBLLObj.itemImage);
                            itemBLLObj.itemImage = rndImage + itemBLLObj.itemImage;
                            fileSaved = true;
                        }
                        catch (Exception ex)
                        {
                            throw ex;

                        }
                    }

                    status = itemBLLObj.BLLInsertItem(itemBLLObj);

                    if (status > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Inserted Successfully.')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Not Inserted.')", true);
                    }

                }
                else   //Update the Item
                {
                    itemBLLObj.itemId = Convert.ToString(ViewState["itemId"]);
                    itemBLLObj.itemDescription = txtItemDescription.Text;
                    itemBLLObj.itemName = txtItemName.Text;
                    itemBLLObj.categoryId = categotyId;
                    itemBLLObj.cityId = Convert.ToInt32(cmbCity.SelectedValue);

                    System.Random round = new Random();
                    string rndImage = Convert.ToString(round.Next(1, 9999));

                    if (uplSelectImage.HasFile)
                    {
                        itemBLLObj.itemImage = uplSelectImage.FileName;
                        imageOk = cc.CheckImageExtension(itemBLLObj.itemImage);  //check for correct image extension
                    }

                    if (imageOk == true)
                    {
                        try
                        {
                            uplSelectImage.PostedFile.SaveAs(path + "\\" + itemBLLObj.itemId + "\\" + rndImage + itemBLLObj.itemImage);
                            itemBLLObj.itemImage = rndImage + itemBLLObj.itemImage;
                            fileSaved = true;
                        }
                        catch (Exception ex)
                        {
                            throw ex;

                        }
                    }
                    status = itemBLLObj.BLLUpdateItem(itemBLLObj);
                    if (status > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Updated Successfully.')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Item Not Updated.')", true);
                    }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    //Inserts the Item category Attribute value by default
    public void InsertItemCategoryAttributeValue(ItemCategoryBLL it)
    {
        try
        {
            icBLLObj.BLLShowAttributeByCategory(it);
            List<ItemBLL> atList = icBLLObj.GetAllAttribute;   //Get all the attribute for that category
            for (int k = 0; k < atList.Count; k++)
            {
                icBLLObj.attributeId = atList[k].attributeId;
                icaBLLObj.BLLInsertItemCategoryAttributeFirst(icBLLObj);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    //Show all the item in the grid
    public void ShowAllItem()
    {
        try
        {
            DataTable dtItemShowAll = itemBLLObj.BLLShowAllItem();
            gvItem.DataSource = dtItemShowAll;
            gvItem.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    //Get Selected Item For updation
    public void GetSelectedItem(ItemBLL it)
    {
        try
        {
            itemBLLObj.BLLGetSelectedItem(it);
            txtItemName.Text = itemBLLObj.itemName;
            txtItemDescription.Text = itemBLLObj.itemDescription;
            cmbCity.SelectedValue = Convert.ToString(itemBLLObj.cityId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Save the Item   
    protected void btnSaveItem_Click(object sender, EventArgs e)
    {
        try
        {
        InsertItem();  //Add Or Update the Item
        ShowAllItem();
        FillChkList();
        LoadPlace();
        cmbDistrict.Enabled = false;
        cmbCity.Enabled = false;
            //Fill the grid with Item
        ItemClearField(); //Clear all the Field after insertion
         }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    //Clear all the field 
    private void ItemClearField()
    {
        try 
        {
        txtItemName.Text = "";
        txtItemDescription.Text = "";
         }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    //Fill the checkbox List  of the category
    private void FillChkList()
    {
        try
        {

            dtCategory = categoryBLLObj.BLLGetCategoryForItem();
            chkLstCategory.DataSource = dtCategory;
            chkLstCategory.DataTextField = "categoryName";
            chkLstCategory.DataValueField = "categoryId";
            chkLstCategory.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Paging for the Item Grid
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        gvItem.PageIndex = e.NewPageIndex;
        ShowAllItem(); 
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }


    public void ItemGridSelection(int id)
    {
        try
        {
        ViewState["EditImage"] = "1";
        ViewState["itemId"] = gvItem.Rows[id].Cells[0].Text;
        txtItemName.Text = gvItem.Rows[id].Cells[2].Text;
        txtItemDescription.Text = gvItem.Rows[id].Cells[3].Text;

        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = gvItem.SelectedIndex;
            ItemGridSelection(id);
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    private void LoadPlace()
    {
        try
        {
            // DataTable dtStateShowAll = stateBLLObj.BLLStateHCShowAll(); 
           // DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
            DataSet dtStateShowAll = cc.STDBind("0","0","0");
            cmbState.DataSource = dtStateShowAll;
            cmbState.DataTextField = "stateName";
            cmbState.DataValueField = "stateId";
            cmbState.DataBind();
            cmbState.Items.Add("---Select---");
            cmbState.SelectedIndex = cmbState.Items.Count - 1;
            cmbState.Items[cmbState.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void cmbState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cmbDistrict.Enabled = true;
            int sId = Convert.ToInt32(Convert.ToString(cmbState.SelectedValue));


          //  DataTable dtDisrtictShowById = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, sId);

            DataSet dtDisrtictShowById = cc.STDBind(Convert.ToString(sId),"0","0");

            // DataTable dtDistrictShowById = districtBLLObj.BLLDistrictHCShowAll(sId);
            cmbDistrict.DataSource = dtDisrtictShowById;
            cmbDistrict.DataTextField = "distName";
            cmbDistrict.DataValueField = "distId";
            cmbDistrict.DataBind();
            cmbDistrict.Items.Add("---Select---");
            cmbDistrict.SelectedIndex = cmbDistrict.Items.Count - 1;
            cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        cmbCity.Enabled = true;
        int dId = Convert.ToInt32(Convert.ToString(cmbDistrict.SelectedValue));



       // DataTable dtCityShowById = cityBLLObj.BLLGetSelectedCityByDId(cityBLLObj, dId);

        DataSet dtCityShowById = cc.STDBind("0", Convert.ToString(dId), "0");

        cmbCity.DataSource = dtCityShowById;
        cmbCity.DataTextField = "cityName";
        cmbCity.DataValueField = "cityId";
        cmbCity.DataBind();
        cmbCity.Items.Add("---Select---");
        cmbCity.SelectedIndex = cmbCity.Items.Count - 1;
        cmbCity.Items[cmbCity.Items.Count - 1].Value = "";
         }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
