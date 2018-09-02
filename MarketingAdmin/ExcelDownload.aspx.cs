using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MarketingAdmin_ExcelDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "Application/xlsx";
        //string filepath = Server.MapPath("~/MarketingExcel/marketingExcel.xlsx");



        Response.AppendHeader("Content-Disposition", "attachment; filename=marketingExcel.xlsx");

        Response.TransmitFile(Server.MapPath("~/MarketingExcel/marketingExcel.xlsx"));

        Response.End();
    }
}
