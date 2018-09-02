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

public partial class MarketingAdmin_SchoolAttendancePercentage : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    string schoolcode = "";
    string DateFormat = "";
    string userId = "";
    string roleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DateFormatStatus();// code to load principal
        if (!IsPostBack)
        {
            userId = Convert.ToString(Session["MarketingUser"]);
            roleId = Convert.ToString(Session["RoleId"]);
            ds = LoadHM(userId, roleId);

            LoadHMDetails(ds);
        }


    }

    // load HM details
    public void LoadHMDetails(DataSet ds)
    {
        int flag = 0;
        string Sql = "";
        string userid = "";
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataTable dti = new DataTable("MyTable");
        dti.Columns.Add(new DataColumn("mobile", typeof(string)));
        dti.Columns.Add(new DataColumn("FName", typeof(string)));
        dti.Columns.Add(new DataColumn("LName", typeof(string)));
        dti.Columns.Add(new DataColumn("SchoolCode", typeof(string)));
        dti.Columns.Add(new DataColumn("BoysAttendance", typeof(string)));
        dti.Columns.Add(new DataColumn("GirlAttendance", typeof(string)));
        dti.Columns.Add(new DataColumn("SchoolAttendance", typeof(string)));

        if (ds.Tables[0].Rows.Count >0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                flag = 0;
                userid = Convert.ToString(ds.Tables[0].Rows[i]["friendid"]);
                Sql = "select usrMobileNo,usrFirstName,usrLastName from UserMaster where usrUserId = N'" + userid + "'";
                Sql = Sql+" select SchoolCode from UDISE_TeacherMaster where junior_id = N'" + userid + "' and Class = N' ' and Section = N' '";
                ds1 = cc.ExecuteDataset(Sql);
                schoolcode = Convert.ToString(ds1.Tables[1].Rows[0]["SchoolCode"]);

                Sql = " select ISNULL(Sum(RegBoys),0) as RB,ISNULL(Sum(RegGirls),0) as RG,ISNULL(Sum(Present_B),0) as PB,ISNULL(Sum(Present_G),0) as PG from UDISE_StudentPresenty " +
                 " where SchoolCode=N'" + Convert.ToString(schoolcode) + "' and EntryDate=N'" + Convert.ToString(DateFormat) + "'";  //+ cc.DTInsert_Local(Convert.ToString(System.DateTime.Now)) + "

                ds2 = cc.ExecuteDataset(Sql);
                double RB = 0;
                double RG = 0;
                double PB = 0;
                double PG = 0;
                double ABAttendance = 0;
                double AGAttendance = 0;
                double SchoolAttendance = 0;
                if (Convert.ToDouble((ds2.Tables[0].Rows[0]["RB"])) != 0)
                {
                    RB = Convert.ToDouble(ds2.Tables[0].Rows[0]["RB"]);
                    RB = Math.Round(RB, 2);
                    flag = 1;
                }

                if (Convert.ToDouble((ds2.Tables[0].Rows[0]["RG"])) != 0)
                {
                    RG = Convert.ToDouble(ds2.Tables[0].Rows[0]["RG"]);
                    RG = Math.Round(RG, 2);
                    flag = 1;
                }

                if (Convert.ToDouble((ds2.Tables[0].Rows[0]["PB"])) != 0)
                {
                    PB = Convert.ToDouble(ds2.Tables[0].Rows[0]["PB"]);
                    PB = Math.Round(PB, 2);
                    flag = 1;
                }

                if (Convert.ToDouble((ds2.Tables[0].Rows[0]["PG"])) != 0)
                {
                    PG = Convert.ToDouble(ds2.Tables[0].Rows[0]["PG"]);
                    PG = Math.Round(PG, 2);
                    flag = 1;
                }

                if (flag == 1)
                {
                    ABAttendance = (PB / RB) * 100;
                    ABAttendance = Math.Round(ABAttendance, 2);
                    AGAttendance = (PG / RG) * 100;
                    AGAttendance = Math.Round(AGAttendance, 2);
                    SchoolAttendance = ((ABAttendance + AGAttendance) / 2);
                    SchoolAttendance = Math.Round(SchoolAttendance, 2);
                }
                else
                {
                }

                DataRow dr = dti.NewRow();
                dr["mobile"] = ds1.Tables[0].Rows[0]["usrMobileNo"];
                dr["FName"] = ds1.Tables[0].Rows[0]["usrFirstName"];
                dr["LName"] = ds1.Tables[0].Rows[0]["usrLastName"];
                dr["SchoolCode"] = Convert.ToString(schoolcode);
                dr["SchoolAttendance"] = Convert.ToString(SchoolAttendance);
                dr["BoysAttendance"] = Convert.ToString(ABAttendance);
                dr["GirlAttendance"] = Convert.ToString(AGAttendance);
                dti.Rows.Add(dr);
            }
        }
        ds1.Reset();
        ds1.Tables.Add(dti);

        gvToday.DataSource = ds1.Tables[0];
        gvToday.DataBind();

    }


    // method to load HM
    public DataSet LoadHM(string userId, string roleId)
    {
        string Sql = "";

        if (roleId.Equals("14"))
        {
            Sql = "select distinct [friendid],roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id2=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);
        }
        else if (roleId.Equals("15"))
        {
            Sql = "select distinct [friendid],roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id3=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        else if (roleId.Equals("16"))
        {
            Sql = "select distinct [friendid],roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id4=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        else if (roleId.Equals("17"))
        {
            Sql = "select distinct [friendid],roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id5=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        else if (roleId.Equals("18"))
        {
            Sql = "select distinct [friendid],roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id6=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        else if (roleId.Equals("19"))
        {
            Sql = "select distinct friendid,roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id7=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        else if (roleId.Equals("20"))
        {
            Sql = "select distinct friendid,roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id8=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        else if (roleId.Equals("21"))
        {
            Sql = "select distinct friendid,roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id9=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        else if (roleId.Equals("75"))
        {
            Sql = "select distinct friendid,roleid,rolename  from AdminSubMarketingSubUser as am where roleid=76 and reference_id10=N'" + Convert.ToString(Session["MarketingUser"]) + "'";
            ds = cc.ExecuteDataset(Sql);

        }
        return ds;
    }


    protected void gvToday_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string mobileId = Convert.ToString(e.CommandArgument);
        string Sql = "  select tm.SchoolCode from UDISE_TeacherMaster as tm " +
                    " inner join UserMaster as um on um.usrUserId=tm.junior_id " +
                    " where um.usrMobileNo=N'" + Convert.ToString(mobileId) + "'";
        string schoolcode = cc.ExecuteScalar(Sql);

        mobileId = cc.DESEncrypt(mobileId);
        schoolcode = cc.DESEncrypt(schoolcode);

        if ((mobileId != "" || mobileId != "null") && (schoolcode != "" || schoolcode != "null"))
        {
            if (Convert.ToString(e.CommandName) == "Show")
            {
                Response.Redirect("~/MarketingAdmin/SchoolAttendence.aspx?mn=" + mobileId + "&sc=" + schoolcode + "");

            }
        }
    }
    protected void gvToday_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvToday.PageIndex = e.NewPageIndex;
        LoadHMDetails(ds);

    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        int flag = 0;
        DataTable dti = new DataTable("MyTable");
        dti.Columns.Add(new DataColumn("mobile", typeof(string)));
        dti.Columns.Add(new DataColumn("FName", typeof(string)));
        dti.Columns.Add(new DataColumn("LName", typeof(string)));
        dti.Columns.Add(new DataColumn("SchoolCode", typeof(string)));
        dti.Columns.Add(new DataColumn("BoysAttendance", typeof(string)));
        dti.Columns.Add(new DataColumn("GirlAttendance", typeof(string)));
        dti.Columns.Add(new DataColumn("SchoolAttendance", typeof(string)));
        string mobile = Convert.ToString(txtmobile.Text);
        string schoolcode = Convert.ToString(txtschool.Text);
        if (mobile != "" || schoolcode != "")
        {
            string Sql = "  select tm.SchoolCode as SchoolCode,um.usrFirstName as FName,um.usrLastName as LName,um.usrMobileNo as mobile,asm.RoleName as Role from UDISE_TeacherMaster as tm " +
                        " inner join UserMaster as um on um.usrUserId=tm.junior_id " +
                        " inner join AdminSubMarketingSubUser as asm on asm.friendid=tm.junior_id " +
                        " where um.usrMobileNo=N'" + Convert.ToString(mobile) + "' or tm.SchoolCode=N'" + schoolcode + "' and tm.Roleid=76 ";
            ds = cc.ExecuteDataset(Sql);
            schoolcode = Convert.ToString(ds.Tables[0].Rows[0]["SchoolCode"]);
            mobile = Convert.ToString(ds.Tables[0].Rows[0]["mobile"]);

            Sql = " select ISNULL(Sum(RegBoys),0) as RB,ISNULL(Sum(RegGirls),0) as RG,ISNULL(Sum(Present_B),0) as PB,ISNULL(Sum(Present_G),0) as PG from UDISE_StudentPresenty " +
                " where SchoolCode=N'" + Convert.ToString(schoolcode) + "' and EntryDate=N'" + Convert.ToString(DateFormat) + "'";  //+ cc.DTInsert_Local(Convert.ToString(System.DateTime.Now)) + "

            ds1 = cc.ExecuteDataset(Sql);
            double RB = 0;
            double RG = 0;
            double PB = 0;
            double PG = 0;
            double ABAttendance = 0;
            double AGAttendance = 0;
            double SchoolAttendance = 0;

            if (Convert.ToDouble((ds1.Tables[0].Rows[0]["RB"])) != 0)
            {
                RB = Convert.ToDouble(ds1.Tables[0].Rows[0]["RB"]);
                RB = Math.Round(RB, 2);
                flag = 1;
            }

            if (Convert.ToDouble((ds1.Tables[0].Rows[0]["RG"])) != 0)
            {
                RG = Convert.ToDouble(ds1.Tables[0].Rows[0]["RG"]);
                RG = Math.Round(RG, 2);
                flag = 1;
            }

            if (Convert.ToDouble((ds1.Tables[0].Rows[0]["PB"])) != 0)
            {
                PB = Convert.ToDouble(ds1.Tables[0].Rows[0]["PB"]);
                PB = Math.Round(PB, 2);
                flag = 1;
            }

            if (Convert.ToDouble((ds1.Tables[0].Rows[0]["PG"])) != 0)
            {
                PG = Convert.ToDouble(ds1.Tables[0].Rows[0]["PG"]);
                PG = Math.Round(PG, 2);
                flag = 1;
            }
            if (flag == 1)
            {
                ABAttendance = (PB / RB) * 100;
                ABAttendance = Math.Round(ABAttendance, 2);
                AGAttendance = (PG / RG) * 100;
                AGAttendance = Math.Round(AGAttendance, 2);
                SchoolAttendance = ((ABAttendance + AGAttendance) / 2);
                SchoolAttendance = Math.Round(SchoolAttendance, 2);
            }
            else
            {

            }
            DataRow dr = dti.NewRow();
            dr["mobile"] = ds.Tables[0].Rows[0]["mobile"];
            dr["FName"] = ds.Tables[0].Rows[0]["FName"];
            dr["LName"] = ds.Tables[0].Rows[0]["LName"];
            dr["SchoolCode"] = Convert.ToString(schoolcode);
            dr["SchoolAttendance"] = Convert.ToString(SchoolAttendance + "%");
            dr["BoysAttendance"] = Convert.ToString(ABAttendance + "%");
            dr["GirlAttendance"] = Convert.ToString(AGAttendance + "%");

            dti.Rows.Add(dr);
            ds1.Reset();
            ds1.Tables.Add(dti);
            gvToday.DataSource = ds1.Tables[0];
            gvToday.DataBind();
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select miobile number or School Code')", true);
        }

    }


    //--------------------------------------------------------- Date Format--------------------------------------------------------------------------

    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
        lblDate.Text = SystemDate.ToString("dd'/'MM'/'yyyy''");
        // lblDate.Text = SystemDate.ToString("dd'/'MM'/'yyyy''");
    }

}
