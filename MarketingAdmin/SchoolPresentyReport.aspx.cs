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

public partial class MarketingAdmin_SchoolPresentyReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            TotalRegistor();
            ReportSchool();
        }
    }
    public void LoadGrid()
    {
        try
        {
            string Sql =  "SELECT UDISE_ArchiveSchoolPresenty.SchoolCode,UserMaster.usrMobileNo,usrFirstName,usrLastName"+
                          " ,avg([RegBoys]) as RegBoys,avg([Present_B])as PresentBoys,avg([RegGirls])as RegGirls,avg([Present_G])as PresentGirls FROM UDISE_ArchiveSchoolPresenty inner join UDISE_TeacherMaster on"+
                          " UDISE_ArchiveSchoolPresenty.SchoolCode=UDISE_TeacherMaster.SchoolCode inner join UserMaster on UDISE_TeacherMaster.junior_id= UserMaster.usrUserId"+
                          " where Class='' and Section=''GROUP BY UDISE_ArchiveSchoolPresenty.SchoolCode,UserMaster.usrMobileNo,usrFirstName,usrLastName"+
                          " order by UDISE_ArchiveSchoolPresenty.SchoolCode desc ";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
            }
            for (int i = 0; i < gvItem.Rows.Count; i++)
            {
                Label lblPerb = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerBoy");
                Label lblPerg = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerGirls");
                Label lblAllStud = (Label)gvItem.Rows[i].Cells[0].FindControl("lblAllStud");
                {
                    double RegisterBoy = Convert.ToDouble(gvItem.Rows[i].Cells[5].Text);
                    double RegisterGirls = Convert.ToDouble(gvItem.Rows[i].Cells[7].Text);

                    double PresentBoy = Convert.ToDouble(gvItem.Rows[i].Cells[6].Text);
                    double PresentGirls = Convert.ToDouble(gvItem.Rows[i].Cells[8].Text);

                    if (RegisterBoy == 0.0 && RegisterGirls == 0.0)
                    {
                        lblPerb.Text = "0%";
                        lblPerg.Text = "0%";
                        lblAllStud.Text = "0%";
                    }
                    else if (RegisterBoy == 0.0 && RegisterGirls != 0.0)
                    {
                        double k = 0.0;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                    else if (RegisterBoy != 0.0 && RegisterGirls == 0.0)
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = 0.0;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                    else
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    public void TotalRegistor()
    {
        string Sql = " Select count(*) from AdminSubMarketingSubUser where roleid=76 and mainrole=1 and Active=1 ";
        lblRegSchool.Text = Convert.ToString(cc.ExecuteScalar(Sql));

    }
    public void ReportSchool()
    {
        string Sql = "   Select count(Distinct(SchoolCode)) from [Come2MyCityDB].[dbo].[UDISE_StudentPresenty] ";
        lblReportSchool.Text = Convert.ToString(cc.ExecuteScalar(Sql));
    }
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
}
