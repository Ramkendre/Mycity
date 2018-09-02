using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MarketingAdmin_NewDistributeCouponCode : System.Web.UI.Page
{
    string sql = string.Empty;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

        }
    }

    public void BindGvDistributeCode()
    {
        try
        {
            sql = "SELECT [SrNo],[referenceMobNo],[CodeForName] FROM [tblScratchcodeTV] where referenceMobNo='" + txtAdminMobNo.Text.ToString() + "'";
            ds = cc.ExecuteDataset(sql);

            gvDistributeCode.DataSource = ds.Tables[0];
            gvDistributeCode.DataBind();
        }
        catch { }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@FromSrNo", txtFromSrNo.Text.ToString());
                cmd.Parameters.AddWithValue("@ToSrNo", txtToSrNo.Text.ToString());
                cmd.CommandText = "spGetDistributeCode";
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
                DateTime currentdate = System.DateTime.Now;
                DateTime datetime = currentdate.AddDays(30);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sql = "Update [tblScratchcodeTV] set [CodeFor]='" + ddlCodeFor.SelectedValue.ToString() + "',[CodeForName]='" + ddlCodeFor.SelectedItem.Text.ToString() + "',[referenceMobNo]='" + txtAdminMobNo.Text.ToString() + "', " +
                          " [RefAddedDate]='" + currentdate.ToString() + "',[ExpireDate]='" + datetime.ToString("dd/MM/yyyy hh:mm:ss tt") + "',[ProjectName]='" + ddlProjectName.SelectedValue + "',[Amount]='" + txtAmount.Text + "' " +
                          " where SrNo='" + ds.Tables[0].Rows[i]["SrNo"].ToString() + "'";
                    cc.ExecuteNonQuery(sql);
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Data Saved Sucessfully');", true);
            BindGvDistributeCode();
        }
        catch (Exception)
        {
            lblError.Visible =true;
            lblError.Text = "Oops Error!";
        }
    }

    protected void gvDistributeCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDistributeCode.PageIndex = e.NewPageIndex;
            BindGvDistributeCode();
        }
        catch (Exception)
        {
        }
    }
}