using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class html_TransactionalReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserIdSession = Convert.ToString(Session["User"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                show();
            }
        }
    }

    #region TransactionalSMS

    protected void btnShow_Click(object sender, EventArgs e)
    {
        show();
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Exits();
    }

    private void show()
    {
        try
        {
            string Sql = "select * from SMSBalanceReport where ";
            if (ddlMonth.SelectedValue != "0")
            {
                Sql = Sql + " datePart(month,SMSBalanceReport.SendDate)= '" + ddlMonth.SelectedValue + "' and ";
            }
            if (ddlYear.SelectedValue != "0")
            {
                Sql = Sql + " datePart(Year,SMSBalanceReport.SendDate)='" + ddlYear.SelectedItem.Text + "' and";
            }
            Sql = Sql + " MobileNo='" + Convert.ToString(Session["Mobile"]) + "' order by Id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            GvBalence.DataSource = ds.Tables[0];
            GvBalence.DataBind();
        }
        catch (Exception ex)
        {

        }
    }


    public void Exits()
    {
        ddlMonth.SelectedIndex = 0;
        ddlYear.SelectedIndex = 0;
    }
    protected void GvBalence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvBalence.PageIndex = e.NewPageIndex;
        show();

    }
    //-----------------------------------Don't Delete This Function. It Is used to Excel Download File-----------------------------------------------

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnDwn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=BalenceTillReport.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GvBalence.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion TransactionalSMS
}
