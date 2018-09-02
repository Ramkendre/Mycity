using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_StateMaster : System.Web.UI.Page
{
    StateBLL stateBLLObj = new StateBLL();
    CountryBLL countryBLLObj = new CountryBLL();
    DataSet ds = new DataSet();
    int status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowAllState();
            ShowAllState1();
        }
    }


    //Populate the Grid with State Details
    private void ShowAllState()
    {
        try
        {
            DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
            gvState.DataSource = dtStateShowAll;
            gvState.DataBind();

           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    //Bind the Dropdown data in Country name
    private void ShowAllState1()
    {
        try
        {
           
            DataTable dtCountryShowAll = countryBLLObj.BLLShowAllCountry();
            ddlCountry.DataSource = dtCountryShowAll;
            ddlCountry.DataTextField = "countryName";
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataBind();
            ddlCountry.Items.Add("---Select---");
            ddlCountry.SelectedIndex = ddlCountry.Items.Count - 1;
            ddlCountry.Items[ddlCountry.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Add a new State If already state is present
    /// then update it
    /// </summary>
    public void StateInsertUpdate()
    {

        try 

        {
        stateBLLObj.stateName = Convert.ToString(txtStateName.Text);

        stateBLLObj.countryId = Convert.ToInt32(Convert.ToString(ddlCountry.SelectedValue));



        if (Convert.ToString(ViewState["stateId"]) == "")
        {

            status = stateBLLObj.BLLStateInsert(stateBLLObj);

            if (status > 0)
            {
                Response.Write("<script> alert('State Added')</script>");



               
            }
            else
            {
                Response.Write("<script> alert('State Not added')</script>");
                
            }
        }

        else
        {
            stateBLLObj.stateId = Convert.ToInt32(Convert.ToString(ViewState["stateId"]));
            status = stateBLLObj.BLLStateUpdate(stateBLLObj);

            if (status > 0)
            {
                Response.Write("<script> alert('State Updated')</script>");
               
            }
            else
            {
                Response.Write("<script> alert('State Exist')</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('State Exist')", true);
            }
        }
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
        ShowAllState();
        ShowAllState1();

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="st"></param>



    public void ClearField()
    {
        try
        {
        txtStateName.Text = "";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            


            StateInsertUpdate();
          
           
           
            ClearField();
            btnSubmit.Text = "Submit";
            lblCount.Text = "0";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }

    }
    protected void gvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
        gvState.PageIndex = e.NewPageIndex;
        ShowAllState();
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void gvState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            btnSubmit.Text = "Update";
            int id = gvState.SelectedIndex;
            ViewState["stateId"] = gvState.Rows[id].Cells[0].Text;
            txtStateName.Text = gvState.Rows[id].Cells[1].Text;
            ddlCountry.SelectedValue = gvState.Rows[id].Cells[3].Text;
            CommonCode cc = new CommonCode();
            lblCount.Text = Convert.ToString(cc.ExecuteScalar("Select Count(*) from StateMaster where CountryId="+ddlCountry.SelectedValue.ToString()+""));
          }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonCode cc = new CommonCode();
            lblCount.Text = Convert.ToString(cc.ExecuteScalar("Select Count(*) from StateMaster where CountryId="+ddlCountry.SelectedValue.ToString()+""));
        }
        catch (Exception ex)
        {
            lblCount.Text = "0";
        }
    }
}
