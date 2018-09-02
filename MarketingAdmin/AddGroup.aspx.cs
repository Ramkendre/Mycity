using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MarketingAdmin_AddGroup : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();
    string GId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridbind();
        }
    }
    private void gridbind()
    {
        string Sql = " Select GroupId, GroupName from GroupItem ";
        try
        {
            ds = cc.ExecuteDataset(Sql);
            ddlGroup.DataSource = ds.Tables[0];
            ddlGroup.DataTextField = "GroupName";
            ddlGroup.DataValueField = "GroupId";
            ddlGroup.DataBind();
            ddlGroup.Items.Add("--Select--");
            ddlGroup.SelectedIndex = ddlGroup.Items.Count - 1;
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            string Id = e.CommandArgument.ToString();
            string sql = "Select * from GroupValue where GroupValueId=" + Id + "";
            DataSet ds = cc.ExecuteDataset(sql);
            txtGroupValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["GroupValueName"]);
            ddlGroup.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["GroupItemId"]);
            lblId.Text = Id;
            btnSubmit.Text = "Update";
        }
    }

    private void BindGrid()
    {
        try
        {
          GId = ddlGroup.SelectedValue.ToString();
            string Sql = " Select ROW_NUMBER() over (order by GroupValueName) as No,GroupValueId, GroupValueName from GroupValue where GroupItemId=" + GId + " order by GroupValueName ";

            ds = cc.ExecuteDataset(Sql);
            gvData.DataSource = ds.Tables[0];
            gvData.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtGroupValue.Text != "")
        {
            if (lblId.Text != "")
            {//Code for edit
                string Sql = "Select GroupValueId from GroupValue where GroupValueName='" + txtGroupValue.Text + "' and GroupValueId <>" + lblId.Text + " and GroupItemId=" + ddlGroup.SelectedValue.ToString() + "";
                string Data = cc.ExecuteScalar(Sql);
                if (Data != "")
                {
                    lblError.Visible = true;
                    lblError.Text = " Data is already exist ";
                }
                else
                {
                    Sql = "Update GroupValue set GroupValueName='" + txtGroupValue.Text + "', " +
                        " GroupItemId=" + ddlGroup.SelectedValue.ToString() + " where GroupValueId=" + lblId.Text.ToString() + "";
                    int tmp = cc.ExecuteNonQuery(Sql);
                    if (tmp > 0)
                    {
                        GId = ddlGroup.SelectedValue.ToString();
                        lblError.Visible = true;

                        BindGrid();
                        lblError.Text = " Record updated Successfully. ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record updated Successfully.')", true);
                        lblId.Text = "";
                        gridbind();
                        btnSubmit.Text = "Submit";
                        lblError.Text = "";
                    }
                    else
                    {
                        lblError.Visible = true;
                        gridbind();
                        lblError.Text = " Cant Update the record ";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Cant Update the record')", true);

                    }
                }
            }
            else
            {//Code for Add new
                if (ddlGroup.SelectedItem.Text == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz select Main Group')", true);

                }
                else
                {
                    string Sql = "Select GroupValueId from GroupValue where GroupValueName='" + txtGroupValue.Text + "' and GroupItemId=" + ddlGroup.SelectedValue.ToString() + "";
                    string Data = cc.ExecuteScalar(Sql);
                    if (Data != "")
                    {
                        lblError.Visible = true;
                        lblError.Text = " Data is already exist ";
                    }
                    else
                    {
                        Sql = "Insert into GroupValue ( GroupItemId, GroupValueName) Values " +
                            " (" + ddlGroup.SelectedValue.ToString() + ",'" + txtGroupValue.Text.ToString() + "')";
                        int tmp = cc.ExecuteNonQuery(Sql);
                        if (tmp > 0)
                        {
                            lblError.Visible = true;
                            lblError.Text = " Record Added Successfully. ";
                            gridbind();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Added Successfully.')", true);
                            lblId.Text = "";
                            lblError.Text = "";

                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = " Cant Add the record ";
                        }
                    }
                }
                BindGrid();
                txtGroupValue.Text = "";
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz select Main Group ')", true);
        }
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroup.SelectedIndex == ddlGroup.Items.Count - 1)
        {
            gvData.DataSource = null;
            gvData.DataBind();
        }
        else
        {
            BindGrid();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        gridbind();
        txtGroupValue.Text = "";
        gvData.DataSource = null;
        gvData.DataBind();
        btnSubmit.Text = "Submit";
        lblError.Text = "";
    }
}
