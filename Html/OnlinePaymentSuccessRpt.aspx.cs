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

public partial class Html_OnlinePaymentSuccessRpt : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string newSql = "select top(100)[FirstName],[LastName],[MobileNumber],[EmailId],[ProductName],[Amount],[TransactionDate],[TransactionStatus],[ScrachCode] from [Come2myCityDB].[dbo].[PaymentInformation] order by TransactionDate desc ";

        ds = cc.ExecuteDataset(newSql);
        gvReport.DataSource = ds.Tables[0];
        gvReport.DataBind();
        ds.Clear();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        string newSql = "select top(100)[FirstName],[LastName],[MobileNumber],[EmailId],[ProductName],[Amount],[TransactionDate],[TransactionStatus],[ScrachCode] from [Come2myCityDB].[dbo].[PaymentInformation] where [MobileNumber] like '" + txtSearch.Text + "%'";

        ds = cc.ExecuteDataset(newSql);
        gvReport.DataSource = ds.Tables[0];
        gvReport.DataBind();
        ds.Clear();
    }

    protected void ddlsort_SelectedIndexChanged(object sender, EventArgs e)
    {
        string newSql = string.Empty;

        newSql = "select top(100)[FirstName],[LastName],[MobileNumber],[EmailId],[ProductName],[Amount],[TransactionDate],[TransactionStatus],[ScrachCode] from [Come2myCityDB].[dbo].[PaymentInformation] where [TransactionStatus]='" + ddlsort.SelectedItem.Text + "' and [MobileNumber] like '" + txtSearch.Text + "%'";

        ds = cc.ExecuteDataset(newSql);
        gvReport.DataSource = ds.Tables[0];
        gvReport.DataBind();
        ds.Clear();
    }
}
