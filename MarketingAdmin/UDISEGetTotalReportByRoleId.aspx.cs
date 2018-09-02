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

public partial class MarketingAdmin_UDISEGetTotalReportByRoleId : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string RoleId = "", ReferenceId = "", SelectedValues = "", FullName = "", ShowData = "", ReferenceIdChk = "", ReferenceIdsel = "";
    int Count = 0, Countchk = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
        }
        TreeDemo();
    }
    public void LoadGrid()
    {
        string Sql = "SELECT distinct(MobileNo),UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName,AdminSubMarketingSubUser.rolename,UDISE_TotalByRole.TotalReporty,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G " +
                     "FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                     "UDISE_TotalByRole.RoleId=AdminSubMarketingSubUser.roleid where ReportId ='" + Convert.ToString(Session["MarketingUser"]) + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();

            for (int i = 0; i < gvItem.Rows.Count; i++)
            {
                Label lblPerb = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerBoy");
                Label lblPerg = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerGirls");
                Label lblAllStud = (Label)gvItem.Rows[i].Cells[0].FindControl("lblAllStud");
                {
                    double RegisterBoy = Convert.ToDouble(gvItem.Rows[i].Cells[7].Text);
                    double RegisterGirls = Convert.ToDouble(gvItem.Rows[i].Cells[8].Text);

                    double PresentBoy = Convert.ToDouble(gvItem.Rows[i].Cells[9].Text);
                    double PresentGirls = Convert.ToDouble(gvItem.Rows[i].Cells[10].Text);

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

            GridExcel.DataSource = ds.Tables[0];
            GridExcel.DataBind();
            for (int i = 0; i < GridExcel.Rows.Count; i++)
            {
                Label lblPerb1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblPerBoy1");
                Label lblPerg1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblPerGirls1");
                Label lblAllStud1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblAllStud1");
                {
                    double RegisterBoy = Convert.ToDouble(GridExcel.Rows[i].Cells[7].Text);
                    double RegisterGirls = Convert.ToDouble(GridExcel.Rows[i].Cells[8].Text);

                    double PresentBoy = Convert.ToDouble(GridExcel.Rows[i].Cells[9].Text);
                    double PresentGirls = Convert.ToDouble(GridExcel.Rows[i].Cells[10].Text);

                    if (RegisterBoy == 0.0 && RegisterGirls == 0.0)
                    {
                        lblPerb1.Text = "0%";
                        lblPerg1.Text = "0%";
                        lblAllStud1.Text = "0%";
                    }
                    else if (RegisterBoy == 0.0 && RegisterGirls != 0.0)
                    {
                        double k = 0.0;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb1.Text = Convert.ToInt16(k) + "%";
                        lblPerg1.Text = Convert.ToInt16(j) + "%";
                        lblAllStud1.Text = Convert.ToInt16(m) + "%";
                    }
                    else if (RegisterBoy != 0.0 && RegisterGirls == 0.0)
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = 0.0;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb1.Text = Convert.ToInt16(k) + "%";
                        lblPerg1.Text = Convert.ToInt16(j) + "%";
                        lblAllStud1.Text = Convert.ToInt16(m) + "%";
                    }
                    else
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb1.Text = Convert.ToInt16(k) + "%";
                        lblPerg1.Text = Convert.ToInt16(j) + "%";
                        lblAllStud1.Text = Convert.ToInt16(m) + "%";
                    }
                }
            }
        }

    }
    public void FindRoleId()
    {
        string Sql = "Select Roleid from AdminSubMarketingSubUser where friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";
        Count = Convert.ToInt16(cc.ExecuteScalar(Sql));
        if (Count == 14)
        {
            ReferenceId = "reference_id2";
        }
        else if (Count == 15)
        {
            ReferenceId = "reference_id3";
        }
        else if (Count == 16)
        {
            ReferenceId = "reference_id4";
        }
        else if (Count == 17)
        {
            ReferenceId = "reference_id5";
        }
        else if (Count == 18)
        {
            ReferenceId = "reference_id6";
        }
        else if (Count == 19)
        {
            ReferenceId = "reference_id7";
        }
        else if (Count == 20)
        {
            ReferenceId = "reference_id8";
        }
        else if (Count == 21)
        {
            ReferenceId = "reference_id9";
        }
        else if (Count == 75)
        {
            ReferenceId = "reference_id10";
        }
    }
    public void LoadGridByRole()
    {
        try
        {
            Countchk = Convert.ToInt16(ddlRoleName.SelectedValue);

            if (Countchk != 0)
            {
                FindRoleId();
                if (Countchk <= Count)
                {
                    Response.Write("<script>(alert)('Sorry ...You can't see senior report and Same level.')</script>");
                }
                else
                {
                    string Sql = " SELECT distinct(MobileNo),UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName,AdminSubMarketingSubUser.rolename,UDISE_TotalByRole.TotalReporty,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G" +
                                                          " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                                          " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                                          " where AdminSubMarketingSubUser." + ReferenceId + "='" + Convert.ToString(Session["MarketingUser"]) + "' and AdminSubMarketingSubUser.roleid=" + Convert.ToInt16(Countchk) + "";
                    DataSet ds = cc.ExecuteDataset(Sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvItem.DataSource = ds.Tables[0];
                        gvItem.DataBind();

                        for (int i = 0; i < gvItem.Rows.Count; i++)
                        {
                            Label lblPerb = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerBoy");
                            Label lblPerg = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerGirls");
                            Label lblAllStud = (Label)gvItem.Rows[i].Cells[0].FindControl("lblAllStud");
                            {
                                double RegisterBoy = Convert.ToDouble(gvItem.Rows[i].Cells[7].Text);
                                double RegisterGirls = Convert.ToDouble(gvItem.Rows[i].Cells[8].Text);

                                double PresentBoy = Convert.ToDouble(gvItem.Rows[i].Cells[9].Text);
                                double PresentGirls = Convert.ToDouble(gvItem.Rows[i].Cells[10].Text);

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
                        GridExcel.DataSource = ds.Tables[0];
                        GridExcel.DataBind();
                        for (int i = 0; i < GridExcel.Rows.Count; i++)
                        {
                            Label lblPerb1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblPerBoy1");
                            Label lblPerg1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblPerGirls1");
                            Label lblAllStud1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblAllStud1");
                            {
                                double RegisterBoy = Convert.ToDouble(GridExcel.Rows[i].Cells[7].Text);
                                double RegisterGirls = Convert.ToDouble(GridExcel.Rows[i].Cells[8].Text);

                                double PresentBoy = Convert.ToDouble(GridExcel.Rows[i].Cells[9].Text);
                                double PresentGirls = Convert.ToDouble(GridExcel.Rows[i].Cells[10].Text);

                                if (RegisterBoy == 0.0 && RegisterGirls == 0.0)
                                {
                                    lblPerb1.Text = "0%";
                                    lblPerg1.Text = "0%";
                                    lblAllStud1.Text = "0%";
                                }
                                else if (RegisterBoy == 0.0 && RegisterGirls != 0.0)
                                {
                                    double k = 0.0;
                                    double j = PresentGirls / RegisterGirls;
                                    j = j * 100;

                                    double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                                    m = m * 100;

                                    lblPerb1.Text = Convert.ToInt16(k) + "%";
                                    lblPerg1.Text = Convert.ToInt16(j) + "%";
                                    lblAllStud1.Text = Convert.ToInt16(m) + "%";
                                }
                                else if (RegisterBoy != 0.0 && RegisterGirls == 0.0)
                                {
                                    double k = PresentBoy / RegisterBoy;
                                    k = k * 100;
                                    double j = 0.0;

                                    double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                                    m = m * 100;

                                    lblPerb1.Text = Convert.ToInt16(k) + "%";
                                    lblPerg1.Text = Convert.ToInt16(j) + "%";
                                    lblAllStud1.Text = Convert.ToInt16(m) + "%";
                                }
                                else
                                {
                                    double k = PresentBoy / RegisterBoy;
                                    k = k * 100;
                                    double j = PresentGirls / RegisterGirls;
                                    j = j * 100;

                                    double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                                    m = m * 100;

                                    lblPerb1.Text = Convert.ToInt16(k) + "%";
                                    lblPerg1.Text = Convert.ToInt16(j) + "%";
                                    lblAllStud1.Text = Convert.ToInt16(m) + "%";
                                }
                            }
                        }
                    }
                    ClearLabel();
                    TreeDemo();
                }
            }
        }
        catch (Exception ex)
        { }
    }

    public void ClearLabel()
    {
        lblSecretary.Text = "";
        lblDeptySec.Text = "";
        lblDirectorEdu.Text = "";
        lblDeputyDir.Text = "";
        lblEducationOff.Text = "";
        lblDeputyOff.Text = "";
        lblBlockOff.Text = "";
        lblExtentionOff.Text = "";
        lblClusterHea.Text = "";
        lblHeadMas.Text = "";
    }

    protected void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoleName.SelectedValue == "0")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "14")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "15")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "16")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "17")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "18")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "19")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "20")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "21")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "75")
            {
                LoadGridByRole();
            }
            else if (ddlRoleName.SelectedValue == "76")
            {
                LoadGridByRole();
            }
        }
        catch (Exception ex)
        { }
    }

    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadGridByRole();
    }
    public void FindRoleIdref(string UserIdRef)
    {
        string Sql = "Select Roleid from AdminSubMarketingSubUser where userid='" + UserIdRef + "'";
        Count = Convert.ToInt16(cc.ExecuteScalar(Sql));
        if (Count == 14)
        {
            // ReferenceIdChk = "reference_id2";
        }
        else if (Count == 15)
        {
            ReferenceIdChk = "reference_id2";
        }
        else if (Count == 16)
        {
            ReferenceIdChk = "reference_id3";
        }
        else if (Count == 17)
        {
            ReferenceIdChk = "reference_id4";
        }
        else if (Count == 18)
        {
            ReferenceIdChk = "reference_id5";
        }
        else if (Count == 19)
        {
            ReferenceIdChk = "reference_id6";
        }
        else if (Count == 20)
        {
            ReferenceIdChk = "reference_id7";
        }
        else if (Count == 21)
        {
            ReferenceIdChk = "reference_id8";
        }
        else if (Count == 75)
        {
            ReferenceIdChk = "reference_id9";
        }
        else if (Count == 76)
        {
            ReferenceIdChk = "reference_id10";
        }
    }
    string Useridchk = "", MobileNochk = "";
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            string Id = Convert.ToString(e.CommandArgument);
            string Sql = "Select usrMobileNo,usrUserId from UserMaster where usrAutoId='" + Id + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Useridchk = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                MobileNochk = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);

                string SqlchkAdmin = "Select roleid from AdminSubMarketingSubUser where userid='" + Useridchk + "'";
                string RoleId = Convert.ToString(cc.ExecuteScalar(SqlchkAdmin));
                if (RoleId == "" || RoleId == null)
                { }
                else
                {
                    FindRoleIdref(Useridchk);
                    LoadGridByRoleShow(RoleId, Useridchk);
                    TreeDemoChk(Useridchk);
                }
            }
        }
    }

    public void LoadGridByRoleShow(string RoleId, string Underchk)
    {
        try
        {
            FindRoleId();
            string Sql = " SELECT distinct(MobileNo),UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName,AdminSubMarketingSubUser.rolename,UDISE_TotalByRole.TotalReporty,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G" +
                                       " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                       " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                       " where AdminSubMarketingSubUser." + ReferenceId + "='" + Convert.ToString(Session["MarketingUser"]) + "' and AdminSubMarketingSubUser." + ReferenceIdChk + "='" + Underchk + "' and AdminSubMarketingSubUser.roleid=" + RoleId + "";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();

                for (int i = 0; i < gvItem.Rows.Count; i++)
                {
                    Label lblPerb = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerBoy");
                    Label lblPerg = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerGirls");
                    Label lblAllStud = (Label)gvItem.Rows[i].Cells[0].FindControl("lblAllStud");
                    {
                        double RegisterBoy = Convert.ToDouble(gvItem.Rows[i].Cells[7].Text);
                        double RegisterGirls = Convert.ToDouble(gvItem.Rows[i].Cells[8].Text);

                        double PresentBoy = Convert.ToDouble(gvItem.Rows[i].Cells[9].Text);
                        double PresentGirls = Convert.ToDouble(gvItem.Rows[i].Cells[10].Text);

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

                GridExcel.DataSource = ds.Tables[0];
                GridExcel.DataBind();
                for (int i = 0; i < GridExcel.Rows.Count; i++)
                {
                    Label lblPerb1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblPerBoy1");
                    Label lblPerg1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblPerGirls1");
                    Label lblAllStud1 = (Label)GridExcel.Rows[i].Cells[0].FindControl("lblAllStud1");
                    {
                        double RegisterBoy = Convert.ToDouble(GridExcel.Rows[i].Cells[7].Text);
                        double RegisterGirls = Convert.ToDouble(GridExcel.Rows[i].Cells[8].Text);

                        double PresentBoy = Convert.ToDouble(GridExcel.Rows[i].Cells[9].Text);
                        double PresentGirls = Convert.ToDouble(GridExcel.Rows[i].Cells[10].Text);

                        if (RegisterBoy == 0.0 && RegisterGirls == 0.0)
                        {
                            lblPerb1.Text = "0%";
                            lblPerg1.Text = "0%";
                            lblAllStud1.Text = "0%";
                        }
                        else if (RegisterBoy == 0.0 && RegisterGirls != 0.0)
                        {
                            double k = 0.0;
                            double j = PresentGirls / RegisterGirls;
                            j = j * 100;

                            double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                            m = m * 100;

                            lblPerb1.Text = Convert.ToInt16(k) + "%";
                            lblPerg1.Text = Convert.ToInt16(j) + "%";
                            lblAllStud1.Text = Convert.ToInt16(m) + "%";
                        }
                        else if (RegisterBoy != 0.0 && RegisterGirls == 0.0)
                        {
                            double k = PresentBoy / RegisterBoy;
                            k = k * 100;
                            double j = 0.0;

                            double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                            m = m * 100;

                            lblPerb1.Text = Convert.ToInt16(k) + "%";
                            lblPerg1.Text = Convert.ToInt16(j) + "%";
                            lblAllStud1.Text = Convert.ToInt16(m) + "%";
                        }
                        else
                        {
                            double k = PresentBoy / RegisterBoy;
                            k = k * 100;
                            double j = PresentGirls / RegisterGirls;
                            j = j * 100;

                            double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                            m = m * 100;

                            lblPerb1.Text = Convert.ToInt16(k) + "%";
                            lblPerg1.Text = Convert.ToInt16(j) + "%";
                            lblAllStud1.Text = Convert.ToInt16(m) + "%";
                        }
                    }
                }
            }
           
        }
        catch (Exception ex)
        { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlRoleName.SelectedValue = "0";
        LoadGrid();
    }

    public void TreeDemo()
    {
        string Sql = "SELECT userid,roleid,rolename,friendid,doj,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 " +
                     " FROM AdminSubMarketingSubUser where userid ='" + Convert.ToString(Session["MarketingUser"]) + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Secretary = Convert.ToString(ds.Tables[0].Rows[0]["reference_id2"]);
            if (Secretary != "")
            {
                GetData(Secretary);
                lblSecretary.Text = FullName;
            }
            string DeptySec = Convert.ToString(ds.Tables[0].Rows[0]["reference_id3"]);
            if (DeptySec != "")
            {
                GetData(DeptySec);
                lblDeptySec.Text = FullName;
            }
            string DirectorEdu = Convert.ToString(ds.Tables[0].Rows[0]["reference_id4"]);
            if (DirectorEdu != "")
            {
                GetData(DirectorEdu);
                lblDirectorEdu.Text = FullName;
            }
            string DeputyDir = Convert.ToString(ds.Tables[0].Rows[0]["reference_id5"]);
            if (DeputyDir != "")
            {
                GetData(DeputyDir);
                lblDeputyDir.Text = FullName;
            }
            string EducationOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id6"]);
            if (EducationOff != "")
            {
                GetData(EducationOff);
                lblEducationOff.Text = FullName;
            }
            string DeputyOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id7"]);
            if (DeputyOff != "")
            {
                GetData(DeputyOff);
                lblDeputyOff.Text = FullName;
            }
            string BlockOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id8"]);
            if (BlockOff != "")
            {
                GetData(BlockOff);
                lblBlockOff.Text = FullName;
            }
            string ExtentionOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id9"]);
            if (ExtentionOff != "")
            {
                GetData(ExtentionOff);
                lblExtentionOff.Text = FullName;
            }
            string ClusterHea = Convert.ToString(ds.Tables[0].Rows[0]["reference_id10"]);
            if (ClusterHea != "")
            {
                GetData(ClusterHea);
                lblClusterHea.Text = FullName;
            }
            string HeadMas = Convert.ToString(ds.Tables[0].Rows[0]["reference_id11"]);
            if (HeadMas != "")
            {
                GetData(HeadMas);
                lblHeadMas.Text = FullName;
            }
        }
    }

    public void TreeDemoChk(string chkUserId)
    {
        string Sql = "SELECT userid,roleid,rolename,friendid,doj,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 " +
                     " FROM AdminSubMarketingSubUser where userid ='" + chkUserId + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Secretary = Convert.ToString(ds.Tables[0].Rows[0]["reference_id2"]);
            if (Secretary != "")
            {
                GetData(Secretary);
                lblSecretary.Text = FullName;
            }
            string DeptySec = Convert.ToString(ds.Tables[0].Rows[0]["reference_id3"]);
            if (DeptySec != "")
            {
                GetData(DeptySec);
                lblDeptySec.Text = FullName;
            }
            string DirectorEdu = Convert.ToString(ds.Tables[0].Rows[0]["reference_id4"]);
            if (DirectorEdu != "")
            {
                GetData(DirectorEdu);
                lblDirectorEdu.Text = FullName;
            }
            string DeputyDir = Convert.ToString(ds.Tables[0].Rows[0]["reference_id5"]);
            if (DeputyDir != "")
            {
                GetData(DeputyDir);
                lblDeputyDir.Text = FullName;
            }
            string EducationOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id6"]);
            if (EducationOff != "")
            {
                GetData(EducationOff);
                lblEducationOff.Text = FullName;
            }
            string DeputyOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id7"]);
            if (DeputyOff != "")
            {
                GetData(DeputyOff);
                lblDeputyOff.Text = FullName;
            }
            string BlockOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id8"]);
            if (BlockOff != "")
            {
                GetData(BlockOff);
                lblBlockOff.Text = FullName;
            }
            string ExtentionOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id9"]);
            if (ExtentionOff != "")
            {
                GetData(ExtentionOff);
                lblExtentionOff.Text = FullName;
            }
            string ClusterHea = Convert.ToString(ds.Tables[0].Rows[0]["reference_id10"]);
            if (ClusterHea != "")
            {
                GetData(ClusterHea);
                lblClusterHea.Text = FullName;
            }
            string HeadMas = Convert.ToString(ds.Tables[0].Rows[0]["reference_id11"]);
            if (HeadMas != "")
            {
                GetData(HeadMas);
                lblHeadMas.Text = FullName;
            }
        }
    }

    public void GetData(string UserId)
    {
        FullName = "";
        string Sql = "Select usrFirstName, usrLastName from UserMaster where usrUserId='" + UserId + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string FirstName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
            string LastName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
            FullName = FirstName + " " + LastName;
        }
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GridExcel.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception ex)
        { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
