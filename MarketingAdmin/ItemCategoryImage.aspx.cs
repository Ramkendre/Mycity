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
public partial class MarketingAdmin_ItemCategoryImage : System.Web.UI.Page
{
    CategoryBLL categoryBLLObj = new CategoryBLL();
    ItemCategoryBLL icBLLObj = new ItemCategoryBLL();
    AttributeBLL attributeBLLObj = new AttributeBLL();
    ItemCategoryAttributeBLL icaBLLObj = new ItemCategoryAttributeBLL();
    ItemCategoryImageBLL iciBLLObj = new ItemCategoryImageBLL();
    CommonCode cc = new CommonCode();
    UISearchBLL usBLLObj = new UISearchBLL();
    ItemBLL itemBLLObj = new ItemBLL();


    string path = HttpContext.Current.Request.PhysicalApplicationPath + "Item_Resource\\";
    bool image1Ok = false;
    bool image2Ok = false;
    bool image3Ok = false;
    bool fileSaved = false;
    string rndImage;
    int status, imgId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
            BindItem();
            ddlSelectCategory.Enabled = false;
            ddlImageType.Enabled = false;
            // pnlAddItemImage.Visible = false;
        }
    }


    private void BindCategory()
    {
        try
        {

            DataTable dtCategory = categoryBLLObj.BLLGetCategoryWOParent();
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


    private void ShowItemImage()
    {
        try
        {
            usBLLObj.itemId = Convert.ToString(ddlSelectItem.SelectedValue);
            usBLLObj.categoryId = Convert.ToInt32(Convert.ToString(ddlSelectCategory.SelectedValue));


            DataTable dtItemImgList = usBLLObj.BLLItemDescriptionImageDisplay(usBLLObj);

            gvShowImage.DataSource = dtItemImgList;
            gvShowImage.DataBind();

            gvShowImageSet2.DataSource = dtItemImgList;
            gvShowImageSet2.DataBind();

            gvShowImageSet3.DataSource = dtItemImgList;
            gvShowImageSet3.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
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
    protected void ddlSelectCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlImageType.Enabled = true;
        ShowItemImage();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ItemImageUpload();
    }



    protected void gvShowImage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditImage")
        {
            string[] cmdArgs = Convert.ToString(e.CommandArgument).Split(',');

            // pnlAddItemImage.Visible = true;
            ViewState["updateImage"] = "1";
            ViewState["updateImageId"] = Convert.ToString(cmdArgs[0]);
            txtImageName.Text = Convert.ToString(cmdArgs[1]);
        }
    }




    protected void btnSubmitImageSet2_Click(object sender, EventArgs e)
    {
        ItemImageUpload();
    }



    public void ItemImageUpload()
    {
        iciBLLObj.itemId = Convert.ToString(ddlSelectItem.SelectedValue);
        iciBLLObj.categoryId = Convert.ToInt32(Convert.ToString(ddlSelectCategory.SelectedValue));
        iciBLLObj.imageSetType = Convert.ToInt32(ddlImageType.SelectedValue);


        status = iciBLLObj.BLLIsExistsMainItemCategoryImage(iciBLLObj);

        if (status > 0)
        {
            iciBLLObj.BLLIsExistsItemCategoryImage(iciBLLObj, out status, out imgId);

            iciBLLObj.imageId = imgId;

            if (status > 0)
            {
                if (Convert.ToString(ViewState["updateImage"]) == "1")
                {
                    iciBLLObj.imageId = Convert.ToInt32(Convert.ToString(ViewState["updateImageId"]));
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\Item_Resource\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\Item_Resource\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId);
                    }
                    System.Random round = new Random();
                    rndImage = Convert.ToString(round.Next(1, 9999));



                    if (iciBLLObj.imageSetType == 2)
                    {

                        iciBLLObj.image1 = uplImage7.FileName;
                        image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                        iciBLLObj.imageName = txtImageName3.Text;
                        iciBLLObj.imageDescription = txtImageDescription3.Text;

                        if (image1Ok == true)
                        {
                            uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                            iciBLLObj.image1 = rndImage + iciBLLObj.image1;
                            fileSaved = true;
                        }

                    }
                    else if (iciBLLObj.imageSetType == 1)
                    {
                        iciBLLObj.image1 = uplImage4.FileName;
                        iciBLLObj.image2 = uplImage5.FileName;
                        iciBLLObj.image3 = uplImage6.FileName;
                        image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                        image2Ok = cc.CheckImageExtension(iciBLLObj.image2);
                        image3Ok = cc.CheckImageExtension(iciBLLObj.image3);
                        iciBLLObj.imageName = txtImageName2.Text;
                        iciBLLObj.imageDescription = txImageDescription2.Text;

                        if (image1Ok == true && image2Ok == true && image3Ok == true)
                        {
                            uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                            iciBLLObj.image1 = rndImage + iciBLLObj.image1;

                            uplImage2.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image2);
                            iciBLLObj.image2 = rndImage + iciBLLObj.image2;

                            uplImage3.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image3);
                            iciBLLObj.image3 = rndImage + iciBLLObj.image3;
                            fileSaved = true;
                        }
                    }
                    else
                    {
                        iciBLLObj.image1 = uplImage1.FileName;
                        iciBLLObj.image2 = uplImage2.FileName;
                        iciBLLObj.image3 = uplImage3.FileName;
                        image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                        image2Ok = cc.CheckImageExtension(iciBLLObj.image2);
                        image3Ok = cc.CheckImageExtension(iciBLLObj.image3);
                        iciBLLObj.imageName = txtImageName.Text;
                        iciBLLObj.imageDescription = txtImageDesc.Text;
                        if (image1Ok == true && image2Ok == true && image3Ok == true)
                        {
                            uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                            iciBLLObj.image1 = rndImage + iciBLLObj.image1;

                            uplImage2.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image2);
                            iciBLLObj.image2 = rndImage + iciBLLObj.image2;

                            uplImage3.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image3);
                            iciBLLObj.image3 = rndImage + iciBLLObj.image3;
                            fileSaved = true;
                        }
                    }

                    if (fileSaved == true)
                    {
                        int k = iciBLLObj.BLLItemCategoryImageUpdate(iciBLLObj);

                        if (k > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' updated')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not updated')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Check File Exist Or not')", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Already Photo Uploaded Please update it')", true);
                }

            }
            else
            {
                //TODO : Implement The Feature of Alreaady Inserted  ==>Data to Updated


                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\Item_Resource\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId))
                {
                    System.IO.Directory.CreateDirectory(thisDir + "\\Item_Resource\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId);
                }
                System.Random round = new Random();
                rndImage = Convert.ToString(round.Next(1, 9999));

                if (iciBLLObj.imageSetType == 2)
                {

                    iciBLLObj.image1 = uplImage7.FileName;
                    image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                    iciBLLObj.imageName = txtImageName3.Text;
                    iciBLLObj.imageDescription = txtImageDescription3.Text;

                    if (image1Ok == true)
                    {
                        uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                        iciBLLObj.image1 = rndImage + iciBLLObj.image1;
                        fileSaved = true;
                    }

                }
                else if (iciBLLObj.imageSetType == 1)
                {
                    iciBLLObj.image1 = uplImage4.FileName;
                    iciBLLObj.image2 = uplImage5.FileName;
                    iciBLLObj.image3 = uplImage6.FileName;
                    image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                    image2Ok = cc.CheckImageExtension(iciBLLObj.image2);
                    image3Ok = cc.CheckImageExtension(iciBLLObj.image3);
                    iciBLLObj.imageName = txtImageName2.Text;
                    iciBLLObj.imageDescription = txImageDescription2.Text;

                    if (image1Ok == true && image2Ok == true && image3Ok == true)
                    {
                        uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                        iciBLLObj.image1 = rndImage + iciBLLObj.image1;

                        uplImage2.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image2);
                        iciBLLObj.image2 = rndImage + iciBLLObj.image2;

                        uplImage3.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image3);
                        iciBLLObj.image3 = rndImage + iciBLLObj.image3;
                        fileSaved = true;
                    }
                }
                else
                {
                    iciBLLObj.image1 = uplImage1.FileName;
                    iciBLLObj.image2 = uplImage2.FileName;
                    iciBLLObj.image3 = uplImage3.FileName;
                    iciBLLObj.imageName = txtImageName.Text;
                    iciBLLObj.imageDescription = txtImageDesc.Text;
                    if (image1Ok == true && image2Ok == true && image3Ok == true)
                    {
                        uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                        iciBLLObj.image1 = rndImage + iciBLLObj.image1;

                        uplImage2.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image2);
                        iciBLLObj.image2 = rndImage + iciBLLObj.image2;

                        uplImage3.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image3);
                        iciBLLObj.image3 = rndImage + iciBLLObj.image3;
                        fileSaved = true;
                    }
                }

                if (fileSaved == true)
                {
                    int kx = iciBLLObj.BLLItemCategoryImageUpdate(iciBLLObj);
                    if (kx > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' updated')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not updated')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Check File Exist Or not')", true);
                }
            }
        }
        else   //For total New Insert Image
        {
            iciBLLObj.imageSetType = mvwMain.ActiveViewIndex;

            string thisDir = Server.MapPath("~");
            if (!System.IO.Directory.Exists(thisDir + "\\Item_Resource\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId))
            {
                System.IO.Directory.CreateDirectory(thisDir + "\\Item_Resource\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId);
            }
            System.Random round = new Random();
            rndImage = Convert.ToString(round.Next(1, 9999));

            if (iciBLLObj.imageSetType == 2)
            {

                iciBLLObj.image1 = uplImage7.FileName;
                image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                iciBLLObj.imageName = txtImageName3.Text;
                iciBLLObj.imageDescription = txtImageDescription3.Text;

                if (image1Ok == true)
                {
                    uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                    iciBLLObj.image1 = rndImage + iciBLLObj.image1;
                    fileSaved = true;
                }

            }
            else if (iciBLLObj.imageSetType == 1)
            {
                iciBLLObj.image1 = uplImage4.FileName;
                iciBLLObj.image2 = uplImage5.FileName;
                iciBLLObj.image3 = uplImage6.FileName;
                image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                image2Ok = cc.CheckImageExtension(iciBLLObj.image2);
                image3Ok = cc.CheckImageExtension(iciBLLObj.image3);
                iciBLLObj.imageName = txtImageName2.Text;
                iciBLLObj.imageDescription = txImageDescription2.Text;

                if (image1Ok == true && image2Ok == true && image3Ok == true)
                {
                    uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                    iciBLLObj.image1 = rndImage + iciBLLObj.image1;

                    uplImage2.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image2);
                    iciBLLObj.image2 = rndImage + iciBLLObj.image2;

                    uplImage3.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image3);
                    iciBLLObj.image3 = rndImage + iciBLLObj.image3;
                    fileSaved = true;
                }
            }
            else
            {
                iciBLLObj.image1 = uplImage1.FileName;
                iciBLLObj.image2 = uplImage2.FileName;
                iciBLLObj.image3 = uplImage3.FileName;

                image1Ok = cc.CheckImageExtension(iciBLLObj.image1);
                image2Ok = cc.CheckImageExtension(iciBLLObj.image2);
                image3Ok = cc.CheckImageExtension(iciBLLObj.image3);

                iciBLLObj.imageName = txtImageName.Text;
                iciBLLObj.imageDescription = txtImageDesc.Text;
                if (image1Ok == true && image2Ok == true && image3Ok == true)
                {
                    uplImage1.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image1);
                    iciBLLObj.image1 = rndImage + iciBLLObj.image1;

                    uplImage2.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image2);
                    iciBLLObj.image2 = rndImage + iciBLLObj.image2;

                    uplImage3.PostedFile.SaveAs(path + "\\" + iciBLLObj.itemId + "\\" + iciBLLObj.categoryId + "\\" + rndImage + iciBLLObj.image3);
                    iciBLLObj.image3 = rndImage + iciBLLObj.image3;
                    fileSaved = true;
                }
            }

            if (fileSaved == true)
            {
                int j = iciBLLObj.BLLItemCategoryImageInsert(iciBLLObj);

                if (j > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo Uploaded')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo Not Uploaded')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Check File Exist Or not')", true);
            }


        }
    }




    protected void btnSubmitImageSet_Click(object sender, EventArgs e)
    {
        ImageSetType();
    }
    protected void ddlImageType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    private void ImageSetType()
    {
        try
        {
            iciBLLObj.itemId = Convert.ToString(ddlSelectItem.SelectedValue);
            iciBLLObj.categoryId = Convert.ToInt32(Convert.ToString(ddlSelectCategory.SelectedValue));
            iciBLLObj.imageSetType = Convert.ToInt32(ddlImageType.SelectedValue);

            status = iciBLLObj.BLLItemCategoryImageSet(iciBLLObj);
            if (status > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Image Type Set')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Image Not Type Set')", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvShowImageSet2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditImage")
        {
            string[] cmdArgs = Convert.ToString(e.CommandArgument).Split(',');

            // pnlAddItemImage.Visible = true;
            ViewState["updateImage"] = "1";
            ViewState["updateImageId"] = Convert.ToString(cmdArgs[0]);
            txtImageName2.Text = Convert.ToString(cmdArgs[1]);
        }
    }
    protected void gvShowImageSet3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditImage")
        {
            string[] cmdArgs = Convert.ToString(e.CommandArgument).Split(',');

           
            ViewState["updateImage"] = "1";
            ViewState["updateImageId"] = Convert.ToString(cmdArgs[0]);
            txtImageName3.Text = Convert.ToString(cmdArgs[1]);
        }
    }
    protected void btnSubmitImageSet3_Click(object sender, EventArgs e)
    {
        ItemImageUpload();
        BindCategory();
        BindItem();
        ddlSelectCategory.Enabled = false;
        ddlImageType.Enabled = false;
    }
    protected void lnkView1_Click(object sender, EventArgs e)
    {
        mvwMain.SetActiveView(vwImageSet1);
    }
    protected void lnkView2_Click(object sender, EventArgs e)
    {
        mvwMain.SetActiveView(vwImageSet2);
    }
    protected void lnkView3_Click(object sender, EventArgs e)
    {
        mvwMain.SetActiveView(vwImageSet3);
    }
}