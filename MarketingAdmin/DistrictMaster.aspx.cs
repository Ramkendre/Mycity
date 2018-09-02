using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_DistrictMaster : System.Web.UI.Page
{
    DistrictBLL districtBLLObj = new DistrictBLL();
    StateBLL stateBLLObj = new StateBLL();
    int status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowAllDistrict();
            FillDLLState();

        }
    }


    private void ShowAllDistrict()
    {
        try
        {
            DataTable dtDistrictShowAll = districtBLLObj.BLLDistrictShowAll();

            gvDistrict.DataSource = dtDistrictShowAll;
            gvDistrict.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillDLLState()
    {
        try
        {
            DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
            ddlState.DataSource = dtStateShowAll;
            ddlState.DataTextField = "stateName";
            ddlState.DataValueField = "stateId";
            ddlState.DataBind();
            ddlState.Items.Add("---Select---");
            ddlState.SelectedIndex = ddlState.Items.Count - 1;
            ddlState.Items[ddlState.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DistrictInsertUpdate();
            ShowAllDistrict();
            clear();
            btnSubmit.Text = "Submit";
            lblCount.Text = "0";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }

    }

    private void DistrictInsertUpdate()
    {
        try
        {




            districtBLLObj.distName = Convert.ToString(txtDistrictName.Text);
            districtBLLObj.stateId = Convert.ToInt32(Convert.ToString(ddlState.SelectedValue));

            if (Convert.ToString(ViewState["districtId"]) == "")
            {

                status = districtBLLObj.BLLDistrictInsert(districtBLLObj);

                if (status > 0)
                {
                    Response.Write("<script> alert('District Added')</script>");


                }
                else
                {
                    Response.Write("<script> alert('District  Not Added')</script>");
                    

                }
            }
            else
            {
                districtBLLObj.distId = Convert.ToInt32(Convert.ToString(ViewState["districtId"]));
                status = districtBLLObj.BLLDisrtictUpdate(districtBLLObj);
                if (status > 0)
                {
                    Response.Write("<script> alert('District  Updated')</script>");
                }
                else
                {
                    Response.Write("<script> alert('District Not  Updated')</script>");
                   
                }
                ShowAllDistrict();
                FillDLLState();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void clear()
    {
        try
        {
            txtDistrictName.Text = "";

        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void gvDistrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
       {
        gvDistrict.PageIndex = e.NewPageIndex;
        ShowAllDistrict();
        clear();
         }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
    protected void gvDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        btnSubmit.Text = "Update";
        int id = gvDistrict.SelectedIndex;
        ViewState["districtId"] = gvDistrict.Rows[id].Cells[0].Text;
        txtDistrictName.Text = gvDistrict.Rows[id].Cells[1].Text;
        ddlState.SelectedValue = gvDistrict.Rows[id].Cells[3].Text;
         CommonCode cc = new CommonCode();
         lblCount.Text = Convert.ToString(cc.ExecuteScalar("Select Count(*) from DistrictMaster where StateId=" + ddlState.SelectedValue.ToString() + ""));
       
         }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }


    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonCode cc = new CommonCode();
            lblCount.Text = Convert.ToString(cc.ExecuteScalar("Select Count(*) from DistrictMaster where StateId=" + ddlState.SelectedValue.ToString() + ""));
        }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
}
