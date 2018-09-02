using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SmsReportStatus : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridView();
    }

    public string returnCurDate()
    {
        TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        string dt = indianTime.ToString("d MMM yyyy");
        return dt;
    }

    public void BindGridView()
    {
        try
        {
            string newSql = "SELECT TOP (100)* FROM [longCodeasciiSmsReceve] WHERE [receivedDateTime] like '" + returnCurDate() + "%' AND [p1] = '89915309029902859651' AND [p2] = '352742064913669'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(newSql);
            Gv_Smsstatus.DataSource = ds.Tables[0];
            Gv_Smsstatus.DataBind();
        }
        catch
        {
            Response.Write("NO DATA AVAILABLE...!!!!");
        }
    }
    protected void Gv_Smsstatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Gv_Smsstatus.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        catch 
        {
        
        }
    }
}