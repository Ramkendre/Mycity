using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_DisplayDetailsByCity : System.Web.UI.Page
{
    UISearchBLL usBLLObj = new UISearchBLL();
    ItemBLL itBLLObj = new ItemBLL();
    public int imageSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //  usBLLObj.itemId = Convert.ToString(Request.QueryString["Id"]);
                usBLLObj.itemId = Convert.ToString(Session["itemId"]);
                itBLLObj.itemId = Convert.ToString(Session["itemId"]);
                if (Convert.ToString(Session["categoryId"]) == "")
                {
                    usBLLObj.categoryId = 0;
                }
                else
                {
                    usBLLObj.categoryId = Convert.ToInt32(Convert.ToString(Session["categoryId"]));
                }

                LoadItemDescription(usBLLObj);
            }
            catch { }
        }
    }

    public void LoadItemDescription(UISearchBLL usb)
    {
        DataTable dt=itBLLObj.BLLGetSelectedItem(itBLLObj);       
        lblItemName.Text = Convert.ToString( dt.Rows[0]["ItemName"]);// itBLLObj.itemName;
        lblItemDescription.Text = Convert.ToString(dt.Rows[0]["ItemDescription"]); //itBLLObj.itemDescription;
      

       DataTable dtItemDescription = usBLLObj.BLLItemDescription(usb);        
        gvItemDisplay.DataSource = dtItemDescription;
        gvItemDisplay.DataBind();
        Session["itemDiscription"] = dtItemDescription;
        
        DataTable dtItemDescriptionImage = usBLLObj.BLLItemDescriptionImageDisplay(usb);
       

        if (dtItemDescriptionImage.Rows.Count > 0)
        {
            DataRow dtRowImage = dtItemDescriptionImage.Rows[0];
            imageSet = Convert.ToInt32(Convert.ToString(dtRowImage["imageSet"]));

            if (imageSet == 0)
            {
                gvImageSet1.DataSource = dtItemDescriptionImage;
                gvImageSet1.DataBind();
            }
            else if (imageSet == 1)
            {
                gvImageSet2.DataSource = dtItemDescriptionImage;
                gvImageSet2.DataBind();
            }
            else if (imageSet == 2)
            {
                gvImageSet3.DataSource = dtItemDescriptionImage;
                gvImageSet3.DataBind();
            }
        }
        else
        {
            imageSet = 9;
        }

    }
    protected void gvItemDisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemDisplay.PageIndex = e.NewPageIndex;
        DataTable showItem = (DataTable)Session["itemDiscription"];
        gvItemDisplay.DataSource = showItem;
        gvItemDisplay.DataBind();
    }
}
