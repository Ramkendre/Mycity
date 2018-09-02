using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_Advertise : System.Web.UI.Page
{
    AdvertiseBLL advBLLObj = new AdvertiseBLL();
    PublishAvertiseBLL pubAdvBLLObj = new PublishAvertiseBLL();
    CommonCode cc = new CommonCode();
    static bool flag = false;
    string path = HttpContext.Current.Request.PhysicalApplicationPath + "Political_Resource\\";
    bool imageOk = false;
    bool fileSaved;
    string thisDir;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAdvGrid();
            FillAdvType();

        }
    }
    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        AdvertiseInsert();
    }

    public void AdvertiseInsert()
    {

        advBLLObj.Name = txtAddName.Text;
        advBLLObj.ValidFrom = Convert.ToDateTime(txtValidFrom.Text).ToString();
        advBLLObj.ValidTo = Convert.ToDateTime(txtValidTo.Text).ToString();
        advBLLObj.Active = ddlStatus.SelectedItem.Text;
        advBLLObj.Type = ddlType.SelectedItem.Text;
        GetImagePath();
        if (flag == false)
        {
            int j = 0;
            j = advBLLObj.BLLAdvertiseInsert(advBLLObj);
            if (j == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not added')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert(' Added')", true);
                FillAdvGrid();
            }
        }
        else
        {
            int j = 0;
            advBLLObj.AdvId = Convert.ToString(ViewState["advId"]);
            j = advBLLObj.BLLAdvertiseUpdate(advBLLObj);
            if (j == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not Updated')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated Successfully..')", true);
                FillAdvGrid();
                flag = false;
            }
        }
    }

    public void FillAdvGrid()
    {
        DataTable dtAdvShowAll = advBLLObj.BLLAdvertiseShowAll();

        gvAdvertise.DataSource = dtAdvShowAll;
        gvAdvertise.DataBind();

    }

    
    public void GetImagePath()
    {

        fileSaved = false;
        advBLLObj.AdvId = Convert.ToString(ViewState["advId"]);
        if (advBLLObj.AdvId == null)
        {
            advBLLObj.AdvId = System.Guid.NewGuid().ToString();
        }
        thisDir = Server.MapPath("~");


        if (!System.IO.Directory.Exists(thisDir + "\\Political_Resource\\" + advBLLObj.AdvId))
        {
            System.IO.Directory.CreateDirectory(thisDir + "\\Political_Resource\\" + advBLLObj.AdvId);
        }
        System.Random round = new Random();
        string rndImage = Convert.ToString(round.Next(1, 9999));

        if (FileUpload.HasFile)
        {
            advBLLObj.ImageURL = FileUpload.FileName;
            imageOk = cc.CheckImageExtension(advBLLObj.ImageURL);  //check for correct image extension
        }

        if (imageOk == true)
        {
            try
            {
                FileUpload.PostedFile.SaveAs(path + "\\" + advBLLObj.AdvId + "\\" + rndImage + advBLLObj.ImageURL);
                advBLLObj.ImageURL = rndImage + advBLLObj.ImageURL;
                fileSaved = true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }

    public void FillAdvType()
    {
        DataTable dtAdvertiseType = pubAdvBLLObj.BLLAdvertiseTypeSelect();
        ddlType.DataSource = dtAdvertiseType;
        ddlType.DataTextField = "TypeName";
        ddlType.DataValueField = "TypeId";
        ddlType.DataBind();
        ddlType.Items.Add("---Select---");
        ddlType.SelectedIndex = ddlType.Items.Count - 1;
        ddlType.Items[ddlType.Items.Count - 1].Value = "";
    }
    protected void gvAdvertise_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAdvertise.PageIndex = e.NewPageIndex;
        FillAdvGrid();
    }
    protected void gvAdvertise_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = gvAdvertise.SelectedIndex;

        txtAddName.Text = gvAdvertise.Rows[id].Cells[1].Text;
        txtValidFrom.Text = gvAdvertise.Rows[id].Cells[3].Text;
        txtValidTo.Text = gvAdvertise.Rows[id].Cells[4].Text;
    }
}
