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
using System.Data.SqlClient;

public partial class MarketingAdmin_CoupanAllottmentList : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    SendSMSEvent sm = new SendSMSEvent();
    string roleid;
    string usrMobileNo1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            usrMobileNo1 = Convert.ToString(Session["MarketingUser"]);
            roleid = Convert.ToString(Session["RoleId"]);
            string DistrictId = Convert.ToString(Session["DistrictId"]);
        }
        catch (Exception ex)
        { }
        if (!Page.IsPostBack)
        {
            if (roleid == null || roleid == "")
            {
                Response.Redirect("~/MarketingAdmin/Login1.aspx");
                Session.Clear();
            }
            bindRole();

        }
        txtDateTime.Text = DateTime.Now.ToString();
        bindgrid();
        bindgridofPasscode();
        pnlpasscode.Visible = false;
        balanceviewrpt();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
    public void bindRole()
    {

        string sql;
        sql = "select [Roleid],[RoleName] from [Come2myCityDB].[come2mycity].[SubMenuPermission] where [UnderRole]='" + roleid + "'";
        DataSet ds = cc.ExecuteDataset(sql);

        ddlRoleList.DataSource = ds;
        ddlRoleList.DataTextField = "RoleName";
        ddlRoleList.DataValueField = "Roleid";
        ddlRoleList.DataBind();
        ddlRoleList.Items.Add("--Select--");
        ddlRoleList.SelectedIndex = ddlRoleList.Items.Count - 1;

    }
    protected void ddlRoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql;
        sql = "select [MID],[UserMaster].usrMobileNo from [Come2myCityDB].[come2mycity].[MartketingSubuser]" +
            " inner join [Come2myCityDB].[dbo].[UserMaster] on [UserMaster].[usrUserId]= MartketingSubuser.Uid1" +
            " where [RoeId]='" + ddlRoleList.SelectedValue + "'";
        DataSet ds = cc.ExecuteDataset(sql);

        ddlUserList.DataSource = ds;
        ddlUserList.DataTextField = "usrMobileNo";
        ddlUserList.DataValueField = "MID";
        ddlUserList.DataBind();
        ddlUserList.Items.Add("--Select--");
        ddlUserList.SelectedIndex = ddlUserList.Items.Count - 1;
    }
    protected void ddlUserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql;
        sql = "select [usrFirstName]+' '+[usrLastName] as fullname from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + ddlUserList.SelectedItem.Text + "' ";
        DataSet ds = cc.ExecuteDataset(sql);
        lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["fullname"]);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AddRecord();

    }
    protected void gvcodelist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvcodelist.PageIndex = e.NewPageIndex;
        gvcodelist.DataBind();
        bindgrid();
    }

    //--------------------------------End of View 1st --------------------------------------------
    public void PasscodeInfo()
    {
        string mobileNumber = txtmobileno.Text;
        string ProjectName = string.Empty;
        if (ddlProject.SelectedValue == "1" || ddlProject.SelectedValue == "3")
        {
            ProjectName = ddlProject.SelectedItem.Text;
        }
        else if (ddlTest.SelectedValue == "1" || ddlTest.SelectedValue == "2")
        {
            ProjectName = ddlTest.SelectedItem.Text;
        }
        else if (ddlTest.SelectedValue == "3")
        {
            ProjectName = ddlcompexam.SelectedItem.Text;
        }
        else if (ddlTest.SelectedValue == "4")
        {
            ProjectName = ddlScholarship.SelectedItem.Text;
        }
        else if (ddlTest.SelectedValue == "5")
        {
            ProjectName = ddlEnggEntrance.SelectedItem.Text;
        }
        else if (ddlTest.SelectedValue == "6")
        {
            ProjectName = ddlMedEntrance.SelectedItem.Text;
        }
        else if (ddlTest.SelectedValue == "7")
        {
            ProjectName = ddlCompCourses.SelectedItem.Text;
        }
        else if (ddlScholarship.SelectedValue == "1" || ddlScholarship.SelectedValue == "2" || ddlScholarship.SelectedValue == "3" || ddlScholarship.SelectedValue == "4")
        {
            ProjectName = ddlScholarship.SelectedItem.Text;
        }
        else if (ddlCompCourses.SelectedValue == "1" || ddlCompCourses.SelectedValue == "2" || ddlCompCourses.SelectedValue == "3" || ddlCompCourses.SelectedValue == "4")
        {
            ProjectName = ddlCompCourses.SelectedItem.Text;
        }
        string messageToSend = "Your Ammount " + txtamtReceived.Text + " has been received.Your passcode is " + lblPasscode.Text + " for " + ProjectName + "  www.myct.in";
        string s = sm.SendSMS("ezeesoft", "67893", mobileNumber, messageToSend);

    }
    public void AddRecord()
    {
        try
        {
            string sql;
            sql = "insert into [Come2myCityDB].[come2mycity].[tblCoupanAllottment] ([RoleId],[UsrName],[DOA],[RangeFrom],[RangeTo],[PName]) values" +
                "('" + ddlRoleList.SelectedValue + "','" + ddlUserList.SelectedItem.Text + "','" + txtDateTime.Text + "','" + txtSrnoFrom.Text + "','" + txtSrnoTo.Text + "','" + txtProjectName.Text + "')";
            int status = cc.ExecuteNonQuery(sql);
            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Successfully saved...!!!')", true);
                bindgrid();
            }
            Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void bindgrid()
    {
        try
        {
            string sql;
            sql = "select [SrNo],[RoleId],[UsrName],[DOA],[RangeFrom],[RangeTo],[PName] from [Come2myCityDB].[come2mycity].[tblCoupanAllottment]";
            DataSet ds = cc.ExecuteDataset(sql);

            gvcodelist.DataSource = ds;
            gvcodelist.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProject.SelectedValue == "2")
        {

            pnltest.Visible = true;
            //pnlamtReceived.Visible = true;
            //pnlRemark.Visible = true;
            ddlTest.SelectedIndex = 0;
        }
        else
        {

            pnlcompexam.Visible = false;
            pnltest.Visible = false;
            pnlscholarship.Visible = false;
            pnlamtReceived.Visible = true;
            pnlRemark.Visible = true;
        }
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedValue == "3")//Competative
        {
            //ddlTest.SelectedIndex = 0;
            pnlcompexam.Visible = true;
            pnlamtReceived.Visible = true;
            pnlRemark.Visible = true;
            pnltest.Visible = true;
            pnlscholarship.Visible = false;
            pnlEnggEntrance.Visible = false;
            pnlMedEntrance.Visible = false;
            ddlcompexam.SelectedIndex = 0;
            ddlMedEntrance.SelectedIndex = 0;
        }
        else if (ddlTest.SelectedValue == "4")//Scholarship
        {
            pnlscholarship.Visible = true;
            pnltest.Visible = true;
            pnlamtReceived.Visible = true;
            pnlRemark.Visible = true;
            pnlcompexam.Visible = false;
            pnlEnggEntrance.Visible = false;
            pnlMedEntrance.Visible = false;
            ddlScholarship.SelectedIndex = 0;
            ddlMedEntrance.SelectedIndex = 0;
        }
        else if (ddlTest.SelectedValue == "5")//EnggEntrance
        {
            pnlEnggEntrance.Visible = true;
            pnltest.Visible = true;
            pnlamtReceived.Visible = true;
            pnlRemark.Visible = true;
            pnlcompexam.Visible = false;
            pnlscholarship.Visible = false;
            pnlMedEntrance.Visible = false;
            ddlScholarship.SelectedIndex = 0;
            ddlEnggEntrance.SelectedIndex = 0;
            ddlMedEntrance.SelectedIndex = 0;
        }
        else if (ddlTest.SelectedValue == "6")//MedEntrance
        {
            pnlMedEntrance.Visible = true;
            pnltest.Visible = true;
            pnlamtReceived.Visible = true;
            pnlRemark.Visible = true;
            pnlscholarship.Visible = false;
            pnlcompexam.Visible = false;
            pnlEnggEntrance.Visible = false;
            ddlScholarship.SelectedIndex = 0;
            ddlEnggEntrance.SelectedIndex = 0;
            ddlMedEntrance.SelectedIndex = 0;
        }
        else if (ddlTest.SelectedValue == "7")//Computer Courses
        {
            pnlMedEntrance.Visible = false;
            pnltest.Visible = true;
            pnlamtReceived.Visible = true;
            pnlRemark.Visible = true;
            pnlscholarship.Visible = false;
            pnlcompexam.Visible = false;
            pnlEnggEntrance.Visible = false;
            pnlComputerCources.Visible = true;
            ddlCompCourses.SelectedIndex = 0;
            ddlEnggEntrance.SelectedIndex = 0;
            ddlMedEntrance.SelectedIndex = 0;
        }
        else
        {
            pnlcompexam.Visible = false;
            pnlscholarship.Visible = false;
            pnlEnggEntrance.Visible = false;
            pnlMedEntrance.Visible = false;
            pnlamtReceived.Visible = true;
            pnlRemark.Visible = true;
            pnlComputerCources.Visible = false;
        }
    }
    protected void btnSubmitPasscode_Click(object sender, EventArgs e)
    {
        if (usrMobileNo1 == "Admin")
        {
            Response.Write("<script>alert('Unauthorized User please login with valid number...!!!')</script>");
        }
        else
        {
            string dt = cc.DateFormatStatus();
            string sql = "select passcodelimit from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where UserId='" + usrMobileNo1 + "'";
            int passcodelimit1 = Convert.ToInt32(cc.ExecuteScalar(sql));
            if (passcodelimit1 > 0)
            {
                string str9 = " select imeiNo,ProjectName,SubPrjName,SubPrjName1,PasscodeValue,amtReceived,Remark from [Come2myCityDB].[come2mycity].[tblPasscodeInfo] where imeiNo='" + lblimeino.Text + "' and SubPrjName='" + ddlTest.SelectedItem.Text + "' and ProjectName='" + ddlProject.SelectedItem.Text + "' and UserType='" + ddlUserType.SelectedItem.Text + "' and " +
                                         " (SubPrjName1='" + ddlScholarship.SelectedItem.Text + "' OR SubPrjName1= '" + ddlcompexam.SelectedItem.Text + "' OR SubPrjName1='" + ddlEnggEntrance.SelectedItem.Text + "' OR SubPrjName1='" + ddlMedEntrance.SelectedItem.Text + "' OR SubPrjName1='" + ddlCompCourses.SelectedItem.Text + "')";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(str9);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Passcode Already Present')", true);
                    lblPasscode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PasscodeValue"]);
                    pnlpasscode.Visible = true;
                    Clear();
                }
                else
                {
                    submitpasscode();
                    passcodelimit1--;
                    sql = "update [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] set passcodelimit=" + passcodelimit1 + " where UserId='" + usrMobileNo1 + "'";
                    string s = cc.ExecuteScalar(sql);

                    sql = " insert into [Come2myCityDB].[come2mycity].[tblCpnAllottedbal_sheet]([bal_From],[bal_for_whom],[bal_debit],[tot_balance],[EntryDate]) " +
                               " values('" + usrMobileNo1 + "','" + txtmobileno.Text + "',1," + passcodelimit1 + ",'" + dt + "')";
                    int i = cc.ExecuteNonQuery(sql);
                    Clear();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your limit has expired...!!!')", true);
                Clear();
            }
        }
    }
    public void submitpasscode()
    {
        try
        {
            string dt = cc.DateFormatStatus();
            long imeifivedigit = 0;
            long imeino = 0;
            long passcode = 0;
            if (txtmobileno.Text == "0")
            {
                imeifivedigit = Convert.ToInt64(txtimeino.Text);
                imeino = Convert.ToInt64(txtimeino.Text.Trim());
            }
            else
            {
                imeifivedigit = Convert.ToInt64(lblimeino.Text);
                imeino = Convert.ToInt64(lblimeino.Text);
            }
            if (ddlProject.SelectedValue == "1" || ddlProject.SelectedValue == "3")
            {
                ddlTest.SelectedItem.Text = "";
                ddlScholarship.SelectedItem.Text = "";
                ddlcompexam.SelectedItem.Text = "";
                ddlEnggEntrance.SelectedItem.Text = "";
                ddlMedEntrance.SelectedItem.Text = "";
                ddlCompCourses.SelectedItem.Text = "";
            }
            if (ddlTest.SelectedValue == "1" || ddlTest.SelectedValue == "2")
            {
                ddlScholarship.SelectedItem.Text = "";
                ddlcompexam.SelectedItem.Text = "";
                ddlEnggEntrance.SelectedItem.Text = "";
                ddlMedEntrance.SelectedItem.Text = "";
                ddlCompCourses.SelectedItem.Text = "";
            }

            # region ezeedrug or school
            if (ddlProject.SelectedValue == "1" || ddlProject.SelectedValue == "3")//EzeeDrug or School
            {
                if (ddlUserType.SelectedValue == "4")
                {
                    passcode = (((imeifivedigit % 10000000) * 963) / 531) - 223;
                }
                else
                {
                    if (ddlUserType.SelectedValue == "1")
                    {
                        passcode = (((imeifivedigit % 100000) * 150) / 101) + 15;
                    }
                    else if (ddlUserType.SelectedValue == "2")
                    {
                        passcode = (((imeifivedigit % 100000) * 150) / 101) + 16;
                    }
                    else if (ddlUserType.SelectedValue == "3")
                    {
                        passcode = (((imeifivedigit % 100000) * 150) / 101) + 17;
                    }
                }
            }
            # endregion

            # region EzeeTest
            else if (ddlProject.SelectedValue == "2")
            {
                if (ddlUserType.SelectedValue == "4")
                {
                    passcode = (((imeifivedigit % 10000000) * 963) / 631) - 123;
                }
                else
                {
                    if (ddlTest.SelectedValue == "1")//MahaTET1 Marathi
                    {
                        #region MahTET1

                        if (ddlUserType.SelectedValue == "1")
                        {
                            passcode = (((imeifivedigit % 100000) * 159) / 103) + 15;
                        }
                        else if (ddlUserType.SelectedValue == "2")
                        {
                            passcode = (((imeifivedigit % 10000000) * 101) / 103) - 11;
                        }
                        else if (ddlUserType.SelectedValue == "3")
                        {
                            passcode = (((imeifivedigit % 10000000) * 401) / 103) - 201;
                        }
                        #endregion
                    }
                    else if (ddlTest.SelectedValue == "2")//MahaTET2 Marathi
                    {
                        #region MahaTET2

                        if (ddlUserType.SelectedValue == "1")
                        {
                            passcode = (((imeifivedigit % 10000000) * 169) / 165) - 16;
                        }
                        else if (ddlUserType.SelectedValue == "2")
                        {
                            passcode = (((imeifivedigit % 10000000) * 110) / 165) - 22;
                        }
                        else if (ddlUserType.SelectedValue == "3")
                        {
                            passcode = (((imeifivedigit % 10000000) * 410) / 165) - 202;
                        }
                        #endregion
                    }
                    if (ddlTest.SelectedValue == "8")//MahaTET1 English
                    {
                        #region MahTET1

                        if (ddlUserType.SelectedValue == "1")
                        {
                            passcode = (((imeifivedigit % 10000000) * 159) / 227) + 15;
                        }
                        else if (ddlUserType.SelectedValue == "2")
                        {
                            passcode = (((imeifivedigit % 10000000) * 101) / 227) - 11;
                        }
                        else if (ddlUserType.SelectedValue == "3")
                        {
                            passcode = (((imeifivedigit % 10000000) * 401) / 227) - 201;
                        }
                        #endregion
                    }
                    else if (ddlTest.SelectedValue == "9")//MahaTET2 English
                    {
                        #region MahaTET2

                        if (ddlUserType.SelectedValue == "1")
                        {
                            passcode = (((imeifivedigit % 10000000) * 169) / 228) - 16;
                        }
                        else if (ddlUserType.SelectedValue == "2")
                        {
                            passcode = (((imeifivedigit % 10000000) * 110) / 228) - 22;
                        }
                        else if (ddlUserType.SelectedValue == "3")
                        {
                            passcode = (((imeifivedigit % 10000000) * 410) / 228) - 202;
                        }
                        #endregion
                    }
                    else if (ddlTest.SelectedValue == "3")//Competative
                    {
                        #region Talathi Exam
                        if (ddlcompexam.SelectedValue == "5")//Talathi Exam
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 138) / 193) - 63;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 210) / 193) - 129;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 510) / 193) - 229;
                            }
                        }
                        #endregion

                        #region IBPS
                        else if (ddlcompexam.SelectedValue == "4")//IBPS
                        {

                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 149) / 94) - 73;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 261) / 94) - 53;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 561) / 94) - 279;
                            }
                        }
                        #endregion

                        #region IBPS ENGLISH
                        else if (ddlcompexam.SelectedValue == "6")//IBPS ENGLISH
                        {

                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 229) / 94) - 73;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 229) / 94) - 53;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 229) / 94) - 279;
                            }
                        }
                        #endregion

                        #region Police Bharati
                        else if (ddlcompexam.SelectedValue == "3")//Police Bharati
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 179) / 176) - 16;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 121) / 176) - 33;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 421) / 176) - 233;
                            }
                        }
                        #endregion

                        #region Postman
                        else if (ddlcompexam.SelectedValue == "2")//Postman Exam
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 148) / 192) - 84;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 201) / 191) - 119;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 501) / 191) - 309;
                            }
                        }
                        #endregion

                        #region MPSC
                        else if (ddlcompexam.SelectedValue == "1")//MPSC
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 185) / 95) - 73;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 190) / 95) - 109;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 490) / 95) - 209;
                            }
                        }
                        #endregion
                    }
                    else if (ddlTest.SelectedValue == "4")//Scholarship
                    {
                        #region 4th Marathi
                        if (ddlScholarship.SelectedValue == "1")//4th M
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 224) / 96) - 14;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 150) / 96) - 66;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 450) / 96) - 266;
                            }
                        }
                        #endregion

                        #region 4th English
                        else if (ddlScholarship.SelectedValue == "2")//4th E
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 188) / 96) - 61;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 130) / 188) - 44;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 430) / 188) - 244;
                            }
                        }
                        #endregion

                        #region 7th Marathi
                        else if (ddlScholarship.SelectedValue == "3")//7th Marathi
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 127) / 96) - 17;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 161) / 96) - 77;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 461) / 96) - 277;
                            }
                        }
                        #endregion

                        #region 7th English
                        else if (ddlScholarship.SelectedValue == "4")//7th English
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 289) / 96) - 62;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 141) / 189) - 55;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 441) / 189) - 255;
                            }
                        }
                        #endregion
                        #region Jawahar Navodaya
                        else if (ddlScholarship.SelectedValue == "5")//Jawahar Navodaya
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 149) / 224) - 83;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 261) / 224) - 63;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 561) / 224) - 289;
                            }
                        }
                        #endregion
                    }
                    else if (ddlTest.SelectedValue == "5")//EnggEntrance
                    {
                        # region JEE MAIN
                        if (ddlEnggEntrance.SelectedValue == "1")//JEE
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 119) / 98) - 19;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 170) / 98) - 88;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 470) / 98) - 288;
                            }
                        }
                        # endregion

                        # region PHYSICS
                        if (ddlEnggEntrance.SelectedValue == "2")//PHYSICS
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 119) / 98) - 19;

                                passcode = (((imeifivedigit % 10000000) * 137) / 209) - 26;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 170) / 98) - 88;
                                passcode = (((imeifivedigit % 10000000) * 181) / 209) - 99;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 481) / 209) - 299;
                            }
                        }
                        # endregion

                        # region CHEMISTRY
                        if (ddlEnggEntrance.SelectedValue == "3")//CHEMISTRY
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 119) / 98) - 19;

                                passcode = (((imeifivedigit % 10000000) * 137) / 210) - 26;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 170) / 98) - 88;
                                passcode = (((imeifivedigit % 10000000) * 181) / 210) - 99;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 481) / 210) - 299;
                            }
                        }
                        # endregion

                        # region MATHEMATICS
                        if (ddlEnggEntrance.SelectedValue == "4")//MATHEMATICS
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 119) / 98) - 19;

                                passcode = (((imeifivedigit % 10000000) * 137) / 211) - 26;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 170) / 98) - 88;
                                passcode = (((imeifivedigit % 10000000) * 181) / 211) - 99;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 481) / 211) - 299;
                            }
                        }
                        # endregion
                    }
                    else if (ddlTest.SelectedValue == "6")//MedicalEntrance
                    {
                        # region MH_CET
                        if (ddlMedEntrance.SelectedValue == "1")//MH-CET
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 137) / 99) - 26;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 181) / 99) - 99;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 481) / 99) - 299;
                            }
                        }
                        # endregion

                        # region PHYSICS
                        if (ddlMedEntrance.SelectedValue == "2")//PHYSICS
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 119) / 98) - 19;

                                passcode = (((imeifivedigit % 10000000) * 137) / 209) - 26;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 170) / 98) - 88;
                                passcode = (((imeifivedigit % 10000000) * 181) / 209) - 99;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 481) / 209) - 299;
                            }
                        }
                        # endregion

                        # region CHEMISTRY
                        if (ddlMedEntrance.SelectedValue == "3")//CHEMISTRY
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 119) / 98) - 19;

                                passcode = (((imeifivedigit % 10000000) * 137) / 210) - 26;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 170) / 98) - 88;
                                passcode = (((imeifivedigit % 10000000) * 181) / 210) - 99;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 481) / 210) - 299;
                            }
                        }
                        # endregion

                        # region BIOLOGY
                        if (ddlMedEntrance.SelectedValue == "4")//BIOLOGY
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 119) / 98) - 19;

                                passcode = (((imeifivedigit % 10000000) * 137) / 212) - 26;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                //passcode = (((imeifivedigit % 10000000) * 170) / 98) - 88;
                                passcode = (((imeifivedigit % 10000000) * 181) / 212) - 99;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 481) / 212) - 299;
                            }
                        }
                        # endregion
                    }
                    else if (ddlTest.SelectedValue == "7")//Computer Courses
                    {
                        #region Tally
                        if (ddlCompCourses.SelectedValue == "1")//Tally
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 108) / 111) - 33;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 241) / 111) - 33;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 541) / 111) - 259;
                            }
                        }
                        #endregion

                        #region DTP
                        else if (ddlCompCourses.SelectedValue == "2")
                        {

                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 129) / 112) - 23;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 551) / 112) - 43;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 550) / 112) - 269;
                            }
                        }
                        #endregion

                        #region CCC
                        else if (ddlCompCourses.SelectedValue == "3")
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 128) / 134) - 53;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 221) / 134) - 13;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 521) / 134) - 239;
                            }

                        }
                        #endregion

                        #region MS-CIT
                        else if (ddlCompCourses.SelectedValue == "4")
                        {
                            if (ddlUserType.SelectedValue == "1")
                            {
                                passcode = (((imeifivedigit % 10000000) * 118) / 163) - 43;
                            }
                            else if (ddlUserType.SelectedValue == "2")
                            {
                                passcode = (((imeifivedigit % 10000000) * 231) / 164) - 23;
                            }
                            else if (ddlUserType.SelectedValue == "3")
                            {
                                passcode = (((imeifivedigit % 10000000) * 530) / 163) - 249;
                            }

                        }
                        #endregion
                    }
                }
            }
            #endregion

            lblPasscode.Text = Convert.ToString(passcode);
            pnlpasscode.Visible = true;
            string confirmValue1 = Request.Form["confirm_value"];
            if (confirmValue1 == "Yes")
            {
                PasscodeInfo();
            }

            string subprjname = string.Empty;

            if (ddlTest.SelectedValue != "0")
                subprjname = ddlTest.SelectedItem.Text;

            string subprjname1 = string.Empty;

            if (ddlcompexam.SelectedValue != "0")
                subprjname1 = ddlcompexam.SelectedItem.Text;
            else if (ddlScholarship.SelectedValue != "0")
                subprjname1 = ddlScholarship.SelectedItem.Text;
            else if (ddlEnggEntrance.SelectedValue != "0")
                subprjname1 = ddlEnggEntrance.SelectedItem.Text;
            else if (ddlMedEntrance.SelectedValue != "0")
                subprjname1 = ddlMedEntrance.SelectedItem.Text;
            else if (ddlCompCourses.SelectedValue != "0")
                subprjname1 = ddlCompCourses.SelectedItem.Text;

            string sql = " insert into [Come2myCityDB].[come2mycity].[tblPasscodeInfo]([UserId],[mobileNo],[imeiNo],[ProjectName],[SubPrjName],[SubPrjName1],[PasscodeValue],[amtReceived],[Remark],[UserType],[EntryDate]) values" +
                  " ('" + usrMobileNo1 + "','" + txtmobileno.Text + "','" + imeino + "','" + ddlProject.SelectedItem.Text + "','" + subprjname + "','" + subprjname1 + "','" + lblPasscode.Text + "','" + txtamtReceived.Text + "','" + txtRemark.Text + "','" + ddlUserType.SelectedItem.Text + "','" + dt + "')";
            int status = cc.ExecuteNonQuery(sql);
            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Inserted...!!!')", true);
            }

            //Clear();
            bindgridofPasscode();
        }
        catch (Exception ex)
        {

        }
    }
    public void bindgridofPasscode()
    {
        try
        {
            string sql;
            if (usrMobileNo1.Equals("Admin"))
                sql = "select [SrNo],[mobileNo],[imeiNo],[ProjectName],[SubPrjName],[SubPrjName1],[PasscodeValue],[amtReceived],[Remark],[UserType] FROM [Come2myCityDB].[come2mycity].[tblPasscodeInfo] order by SrNo desc";
            else
                sql = "select [SrNo],[mobileNo],[imeiNo],[ProjectName],[SubPrjName],[SubPrjName1],[PasscodeValue],[amtReceived],[Remark],[UserType] FROM [Come2myCityDB].[come2mycity].[tblPasscodeInfo] where [UserId]='" + usrMobileNo1 + "' order by SrNo desc";
            DataSet ds = cc.ExecuteDataset(sql);

            gvpasscodelist.DataSource = ds;
            gvpasscodelist.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnBack2home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
    protected void txtmobileno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string sql;
            if (txtmobileno.Text == "0")
            {
                txtimeino.Visible = true;
            }
            else
            {
                sql = "select [strDevId] from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + txtmobileno.Text + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Imeino1 = Convert.ToString(ds.Tables[0].Rows[0]["strDevId"]);
                    lblimeino.Text = Imeino1;
                }
                else
                {
                    sql = "select [strDevId] from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + txtmobileno.Text + "' and strDevId Is Not Null";
                    ds = cc.ExecuteDataset(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Imeino1 = Convert.ToString(ds.Tables[0].Rows[0]["strDevId"]);
                        lblimeino.Text = Imeino1;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Type), "msg", "alert('Check the number or User not registered...!!!')", true);
                    }
                }
            }
            if (lblimeino.Text == null || lblimeino.Text == "0" || lblimeino.Text != lblimeino.Text)
            {
                lblimeino.Visible = false;
                txtimeino.Visible = true;
            }


        }
        catch (Exception ex)
        { }
    }
    public void Clear()
    {
        ddlRoleList.SelectedIndex = 0;
        ddlUserList.ClearSelection();
        txtDateTime.Text = "";
        txtSrnoFrom.Text = "";
        txtSrnoTo.Text = "";
        txtProjectName.Text = "";
        lblName.Text = "";
        txtamtReceived.Text = "";
        txtRemark.Text = "";
        txtimeino.Text = "";
        txtmobileno.Text = "";
        lblimeino.Text = "";
        ddlProject.SelectedIndex = 0;
        ddlTest.SelectedIndex = 0;
        ddlScholarship.SelectedIndex = 0;
        ddlcompexam.SelectedIndex = 0;
        ddlCompCourses.SelectedIndex = 0;
        ddlUserType.SelectedIndex = 0;
        pnlEnggEntrance.Visible = false;
        pnlcompexam.Visible = false;
        pnlMedEntrance.Visible = false;
        pnlRemark.Visible = false;
        pnlscholarship.Visible = false;
        pnltest.Visible = false;
        pnlamtReceived.Visible = false;
        pnlComputerCources.Visible = false;
    }

    protected void gvpasscodelist_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvpasscodelist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvpasscodelist.PageIndex = e.NewPageIndex;
        gvpasscodelist.DataBind();
        bindgridofPasscode();
    }

    //--------------------------------------End of View 2nd -------------------------------------------------

    public void viewgrid()
    {
        string str = " select * from(" +
                     "(select id,(substring (receivedSmsBody, 10,15)) as imei,(substring(receivedSmsBody, 1,8)) as keyword from [Come2myCityDB].[dbo].[longCodeasciiSmsReceve] where id>=96378 and receivedSmsBody like('eZee%'))as table1" +
                     "inner join" +
                     "(select [firstName],[lastName],[mobileNo],[address],District,keyword,strDevId from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [District]='" + Convert.ToString(Session["DistrictId"]) + "')  as table2 " +
                     "on imei=table2.[strDevId])";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        gvViewRecord.DataSource = ds;
        gvViewRecord.DataBind();

    }
    protected void lnkViewDistrictwiseRecord_Click(object sender, EventArgs e)
    {
        viewgrid();
    }
    protected void gvViewRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvViewRecord.PageIndex = e.NewPageIndex;
        gvViewRecord.DataBind();
        viewgrid();
    }

    protected void lnkAddbalance_Click(object sender, EventArgs e)
    {

    }
    protected void lnkBalReport_Click(object sender, EventArgs e)
    {

    }
    protected void btnSubmitBalance_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string dt = cc.DateFormatStatus();
        int passcodeCount = 0, passcodeCount1 = 0, passcountAmt = Convert.ToInt32(txtbalvalue.Text);
        string sql = "Select distinct(passcodelimit) FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where UserId='" + usrMobileNo1 + "'and passcodelimit is not null";
        sql += " Select distinct(passcodelimit) FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + txtmobNo.Text + "'and passcodelimit is not null";
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[1].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                passcodeCount = Convert.ToInt32(ds.Tables[0].Rows[i]["passcodelimit"]);
            }
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                passcodeCount1 = Convert.ToInt32(ds.Tables[1].Rows[i]["passcodelimit"]);
            }
            if (passcountAmt < passcodeCount)
            {
                passcodeCount = passcodeCount - passcountAmt;
                passcodeCount1 = passcodeCount1 + passcountAmt;

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspCoupanBalance";

                cmd.Parameters.AddWithValue("@passcodeCnt", passcodeCount);
                cmd.Parameters.AddWithValue("@passcodeCnt1", passcodeCount1);
                cmd.Parameters.AddWithValue("@passcntAmt", passcountAmt);
                cmd.Parameters.AddWithValue("@mobNo", txtmobNo.Text);
                cmd.Parameters.AddWithValue("@userid", usrMobileNo1);
                cmd.Parameters.AddWithValue("@date", dt);
                cmd.Parameters.Add("@out", SqlDbType.Int);
                cmd.Parameters["@out"].Direction = ParameterDirection.Output;

                if (cmd.Connection.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                string s = cmd.Parameters["@out"].Value.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Your balance is low..!!')", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User not registered..!!')", true);
        }
        txtmobNo.Text = "";
        txtbalvalue.Text = "";
    }

    //-----------------------------------End of View 3rd & 4th ---------------------------------------------
    public void balanceviewrpt()
    {
        string usrMobileNo11 = string.Empty;
        if (usrMobileNo1 == "Admin")
        {
            usrMobileNo1 = "6dde8c3d-1895-4904-b332-764f63206fc0";
        }
        string sql = "select firstName, lastName, passcodelimit from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where UserId='" + usrMobileNo1 + "'";
        DataSet ds = cc.ExecuteDataset(sql);

        lblOwnerName.Text = ds.Tables[0].Rows[0]["firstName"].ToString() + " " + ds.Tables[0].Rows[0]["lastName"].ToString();
        lbltotalBal.Text = ds.Tables[0].Rows[0]["passcodelimit"].ToString();

        sql = " select [bal_Id],[bal_for_whom],[bal_credit],[bal_debit],[tot_balance],[ProjectName],[SubPrjName],[SubPrjName1],[UserType],[amtReceived],[tblPasscodeInfo].[EntryDate] FROM [Come2myCityDB].[come2mycity].[tblCpnAllottedbal_sheet] " +
              " inner join [Come2myCityDB].[come2mycity].[tblPasscodeInfo] on [Come2myCityDB].[come2mycity].[tblPasscodeInfo].[mobileNo] = [Come2myCityDB].[come2mycity].[tblCpnAllottedbal_sheet].[bal_for_whom] where [bal_From]='" + usrMobileNo1 + "' order by [bal_Id] desc";
        ds = cc.ExecuteDataset(sql);

        gvbalancerpt.DataSource = ds;
        gvbalancerpt.DataBind();
    }
    protected void gvbalancerpt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvbalancerpt.PageIndex = e.NewPageIndex;
        gvbalancerpt.DataBind();
        balanceviewrpt();
    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedValue == "4")
        {
            pnltest.Visible = false;
        }
    }


    //--------------------------------------End of View 5th -------------------------------------------------
}
