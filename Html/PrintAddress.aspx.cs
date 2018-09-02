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

public partial class html_PrintAddress : System.Web.UI.Page
{
    //PagedDataSource pgsource = new PagedDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datalistclear();
            //printselection();
            Datalistshow();
        }
    }

    private void Datalistshow()
    {
        DataTable dt = (DataTable)Session["SelectedRecords"];
        Datalist1.DataSource = dt;
        Datalist1.DataBind();
        //pgsource.AllowPaging = true;
    }

    private void Datalistclear()
    {
        Datalist1.DataSource = null;
        Datalist1.DataBind();
        //Session["SelectedRecords"] = "";
        //Session["page"] = "";
    }
    private void printselection()
    {
        Label2.Text = Session["page"].ToString();
    }
    
}
