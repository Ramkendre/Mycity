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

public partial class html_PromotionalReport : System.Web.UI.Page
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
                LoadData();
            }
        }
    }

    public void LoadData()
    {
        try
        {
            string Sql = "SELECT Top(100) Id ,SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,balance ,EntryDate " +
                         "FROM PromotionalSendSMSReport where SendFrom='" + Convert.ToString(Session["Mobile"]) + "'";
            if (ddlMonth.SelectedValue != "0")
            {
                Sql = Sql + " and datePart(month,PromotionalSendSMSReport.EntryDate)=" + ddlMonth.SelectedValue.ToString() + "";
            }
            if (ddlYear.SelectedValue != "0")
            {
                Sql = Sql + " and datePart(Year,PromotionalSendSMSReport.EntryDate)=" + ddlYear.SelectedItem.Text.ToString() + "";
            }
            Sql = Sql + " order by id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvBalence.DataSource = ds.Tables[0];
                GvBalence.DataBind();
            }
            foreach (GridViewRow row in GvBalence.Rows)
            {
                string Data = row.Cells[2].Text.ToString();
                Data = "Mobile List";
                row.Cells[2].Text = Data;
            }
            foreach (GridViewRow row in GvBalence.Rows)
            {
                string Data = row.Cells[8].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[8].Text = Data;
            }


        }
        catch (Exception ex)
        { }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //LoadData();
            if (ddlMonth.SelectedValue == "0")
            {
                Response.Write("<script>alert('Please select Month.....!')</script>");
            }
            else if (ddlYear.SelectedValue == "0")
            {
                Response.Write("<script>alert('Please select Year.....!')</script>");
            }
            else
            {
                string Sql = "SELECT Id ,SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,balance ,EntryDate " +
                            "FROM PromotionalSendSMSReport where SendFrom='" + Convert.ToString(Session["Mobile"]) + "'";

                if (ddlMonth.SelectedValue != "0")
                {
                    Sql = Sql + " and datePart(month,PromotionalSendSMSReport.EntryDate)=" + ddlMonth.SelectedValue.ToString() + "";
                }
                if (ddlYear.SelectedValue != "0")
                {
                    Sql = Sql + " and datePart(Year,PromotionalSendSMSReport.EntryDate)=" + ddlYear.SelectedItem.Text.ToString() + "";
                }
                Sql = Sql + " order by id desc";
                DataSet ds = cc.ExecuteDataset(Sql);
                GvBalence.DataSource = ds.Tables[0];
                GvBalence.DataBind();
                foreach (GridViewRow row in GvBalence.Rows)
                {
                    string Data = row.Cells[2].Text.ToString();
                    Data = "Mobile List";
                    row.Cells[2].Text = Data;
                }
                foreach (GridViewRow row in GvBalence.Rows)
                {
                    string Data = row.Cells[8].Text.ToString();
                    Data = DateSplit(Data);
                    row.Cells[8].Text = Data;
                }
            }

        }
        catch (Exception ex)
        { }
    }

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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Exits();
    }

    public void Exits()
    {
        ddlMonth.SelectedIndex = 0;
        ddlYear.SelectedIndex = 0;
    }
    protected void GvBalence_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvBalence.PageIndex = e.NewPageIndex;
        LoadData();
    }

    //------------------------------

    public string DateSplit(string data)
    {
        string[] dt = data.Split(' ');
        string[] Dts = dt[0].Split('/');
        data = Dts[1] + "-" + Dts[0] + "-" + Dts[2];
        return data;
    }

}
