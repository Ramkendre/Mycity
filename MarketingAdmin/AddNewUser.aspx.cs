using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Windows.Forms;

public partial class MarketingAdmin_AddNewUser : System.Web.UI.Page
{

    CategoryBLL categoryBLLObj = new CategoryBLL();
    ItemBLL itemBLLObj = new ItemBLL();
    ItemCategoryBLL icBLLObj = new ItemCategoryBLL();
    ItemCategoryAttributeBLL icaBLLObj = new ItemCategoryAttributeBLL();
    CityDAL dal = new CityDAL();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLObj = new FriendGroupBLL();
    public DataTable dtFriendGroup;
    BLLFileUpload objBLLFile = new BLLFileUpload();


    CityBLL cityBLLObj = new CityBLL();
    StateBLL stateBLLObj = new StateBLL();
    DistrictBLL districtBLLObj = new DistrictBLL();
    CommonCode cc = new CommonCode();
    public int status;
    UserBLL ubal = new UserBLL();
    KeywordBLL keywordBLLObj = new KeywordBLL();
    DataTable dtkeywordList = new DataTable();
    string KeywordName = "", CurrenctDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        string Id = Convert.ToString(Request.QueryString["id"]);
        if (!IsPostBack)
        {

            if (Convert.ToString(Session["MarketingUser"]) == "")
            {
                Response.Redirect("Login.aspx");

            }
            else
            {

                lblHeader.Text = "Add New User";
                staeclear();
                Load_Role();
                FillDDLGroup();
                GetCommitteeName();
                pnlSelectLocation.Visible = false;
                btnDelete.Visible = false;
                if (Id != "" && Id != null)
                {
                    btnDelete.Visible = true;
                    GetUserValue1(Id);
                }


            }
        }
        DateFormat();
    }
    public void DateFormat()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        CurrenctDate = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
    }
    public void GetCommitteeName()
    {
        try
        {
            string sql = "select Id,Committee_name from committeedetail where roleid=29";
            DataSet ds = cc.ExecuteDataset(sql);

            chkCommitee.DataValueField = "Id";
            chkCommitee.DataTextField = "Committee_name";
            chkCommitee.DataSource = ds.Tables[0];
            chkCommitee.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    public void staeclear()
    {
        try
        {
            ViewState["tbleid"] = "";
            ViewState["city1"] = "";
            ViewState["uid1"] = "";
            ViewState["rid"] = "";
            ViewState["User"] = "";
            ViewState["RoleName"] = "";
            ViewState["District"] = "";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    private void GetUserValue1(string Id)
    {
        lblHeader.Text = "Update User";
        btnSubmit.Text = "Update";
        string Sql = " select ms.city,ms.UseRole,ms.RoeId,ms.Uid1,ms.Doj,um.usrMobileNo,ms.District from MartketingSubuser ms inner join UserMaster um on ms.Uid1=um.usrUserId  where ms.MID=" + Id + "";
        try
        {

            DataSet ds = cc.ExecuteDataset(Sql);

            txtMobileNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);
            txtDOB.Text = Convert.ToString(ds.Tables[0].Rows[0]["Doj"]);
            ddlRole.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RoeId"]);
            ViewState["RoleName"] = Convert.ToString(ds.Tables[0].Rows[0]["UseRole"]);
            ViewState["city1"] = Convert.ToString(ds.Tables[0].Rows[0]["city"]);
            ViewState["uid1"] = Convert.ToString(ds.Tables[0].Rows[0]["Uid1"]);
            ViewState["rid"] = Convert.ToString(ds.Tables[0].Rows[0]["RoeId"]);
            ViewState["District"] = Convert.ToString(ds.Tables[0].Rows[0]["District"]);
        }
        catch (Exception ex)
        {

            string m = ex.Message;
        }
    }
    public void Load_Role()
    {
        try
        {
            int rid = Convert.ToInt16(Session["RoleId"]);
            string rname = Convert.ToString(Session["Role"]);
            string roleid = Convert.ToString(Session["RoleId"]);
            if (roleid == "1")
            {
                string Sql = "select RoleId, RoleName from [Come2myCityDB].[come2mycity].submenuPermission  order by RoleId";
                DataSet ds = cc.ExecuteDataset(Sql);
                ddlRole.DataSource = ds.Tables[0];
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";

                ddlRole.DataBind();
                ddlRole.Items.Add("--Select--");
                ddlRole.SelectedIndex = ddlRole.Items.Count - 1;
            }
            else
            {
                //string Sql = "Select RoleId, RoleName from Role where RoleId>" + rid + " order by RoleId";
                string Sql = "select RoleId, RoleName from [Come2myCityDB].[come2mycity].submenuPermission where UnderRole='" + roleid + "' order by RoleId";
                DataSet ds = cc.ExecuteDataset(Sql);
                ddlRole.DataSource = ds.Tables[0];
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";

                ddlRole.DataBind();
                ddlRole.Items.Add("--Select--");
                ddlRole.SelectedIndex = ddlRole.Items.Count - 1;
            }

        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    private void UserAdd()
    {
        string data = "";
        try
        {
            if (rdoCityLocation.SelectedItem.Value == "SC")
            {
                ubal.CityName = Convert.ToString(Session["CityNameN"]);
            }
            else if (rdoCityLocation.SelectedItem.Value == "DC")
            {
                if (cmbCity.SelectedValue != null)
                {
                    ubal.CityName = Convert.ToString(cmbCity.SelectedItem.Text);
                }
                else
                {
                    ubal.CityName = Convert.ToString(Session["CityNameN"]);
                }
                if (cmbDistrict.SelectedValue != null)
                {
                    ubal.District = Convert.ToString(cmbDistrict.SelectedItem.Text);
                }
                else
                {
                    ubal.District = Convert.ToString(Session["CityNameN"]);
                }
            }
            else if (rdoCityLocation.SelectedItem.Value == "DC")
            {
                if (cmbDistrict.SelectedValue != null)
                {
                    ubal.District = Convert.ToString(cmbDistrict.SelectedItem.Text);
                }
                else
                {
                    ubal.District = Convert.ToString(Session["CityNameN"]);
                }
            }
            if (ddlRole.SelectedValue == "34" || ddlRole.SelectedValue == "35" || ddlRole.SelectedValue == "36")
            {
                if (ddlmenselection.SelectedValue == "1")
                {
                    ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text) + "-Public";
                    ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);
                    string roleid = Convert.ToString(ubal.RoleId1);
                    ubal.RoleId1 = Convert.ToInt32(roleid);
                }
                else if (ddlmenselection.SelectedValue == "2")
                {
                    ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text) + "-Govt";
                    ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);
                    string roleid = Convert.ToString(ubal.RoleId1);
                    ubal.RoleId1 = Convert.ToInt32(roleid);
                }
            }
            else
            {
                ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text);
                ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);
            }
            /////////////////////////

            if (ubal.RoleId1 == 14 || ubal.RoleId1 == 15 || ubal.RoleId1 == 16 || ubal.RoleId1 == 17 || ubal.RoleId1 == 18 || ubal.RoleId1 == 19 || ubal.RoleId1 == 20 || ubal.RoleId1 == 21 || ubal.RoleId1 == 75 || ubal.RoleId1 == 76 || ubal.RoleId1 == 77)
            {
                Response.Write("<script>alert('You can not Add this member of Marketing Persons')</script>");
            }
            else
            {
                ubal.MONO = Convert.ToString(Session["Mobile"]);
                ubal.Date = Convert.ToString(cc.ChangeDate(txtDOB.Text));
                ubal.Id = Convert.ToString(ViewState["User"]);
                string sql11 = "select usrUserid,usrFirstName from usermaster where usrMobileNo='" + ubal.MONO + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql11);
                string usruserid = ds.Tables[0].Rows[0]["usrUserid"].ToString();

                //string usruserid = cc.ExecuteScalar(sql11);

                ///Add Here For EzeeTest Marketing Tree Managment when creating role as marketing person

                string gt = "select usrUserid,usrFirstName from usermaster where usrMobileNo='" + txtMobileNumber.Text + "'";
                DataSet ds0 = new DataSet();
                ds0 = cc.ExecuteDataset(gt);
                string usruserid1 = ds0.Tables[0].Rows[0]["usrUserid"].ToString();
                string usrFirstName = ds0.Tables[0].Rows[0]["usrFirstName"].ToString();
                string deal = "Update [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] set [Role]='" + ubal.RoleName1 + "',ParentName='" + usrFirstName + "' where [Parent_MobileNo]='" + txtMobileNumber.Text + "'";
                cc.ExecuteNonQuery(deal);

                string deal1 = "Update usermaster set [isMarketingPerson]='Y' where [usrMobileNo]='" + txtMobileNumber.Text + "'";
                cc.ExecuteNonQuery(deal1);

                status = ubal.insertUser(ubal);
                if (status > 0)
                {
                    if (ddlRole.SelectedValue == "29")
                    {


                        for (int i = 0; i < chkCommitee.Items.Count; i++)
                        {
                            if (chkCommitee.Items[i].Selected == true)
                            {
                                data = data + "," + chkCommitee.Items[i].Value;
                                //data = data + "," + chkCommitee.Items[i].Value; 
                            }
                        }
                        if (data.Length > 1)
                        {
                            data = data.Substring(1);
                        }

                        ubal.Id = Convert.ToString(ViewState["User"]);
                        ubal.Committeeid = data;
                        status = ubal.BLLinsertUserCommittee(ubal);

                        string AddJunior = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set Mainrole=0 where friendid='" + usruserid + "' ";
                        int Data1 = cc.ExecuteNonQuery(AddJunior);

                        string sql = "insert into [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser(userid,roleid,rolename,friendid,doj,reference_id1,Ref_Ways ,Active ,mainrole)" +
                            "values('" + usruserid + "','" + ubal.RoleId1 + "','" + ubal.RoleName1 + "','" + ubal.Id + "','" + CurrenctDate + "','" + usruserid + "','AddNewUser',1,1)";
                        string a = cc.ExecuteScalar(sql);
                    }
                    else if (ddlRole.SelectedValue == "28")
                    {
                        data = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31";
                        ubal.Id = Convert.ToString(ViewState["User"]);
                        ubal.Committeeid = data;
                        status = ubal.BLLinsertUserCommittee(ubal);

                        string AddJunior = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set Mainrole=0 where friendid='" + usruserid + "' ";
                        int Data1 = cc.ExecuteNonQuery(AddJunior);

                        string sql = "insert into [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser(userid,roleid,rolename,friendid,doj,reference_id1,Ref_Ways,Active ,mainrole)" +
                            "values('" + usruserid + "','" + ubal.RoleId1 + "','" + ubal.RoleName1 + "','" + ubal.Id + "','" + CurrenctDate + "','" + usruserid + "','AddNewUser',1,1)";
                        string a = cc.ExecuteScalar(sql);
                    }
                    else
                    {

                        string AddJunior = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set Mainrole=0 where friendid='" + usruserid + "' ";
                        int Data1 = cc.ExecuteNonQuery(AddJunior);

                        string sql = "insert into [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser(userid,roleid,rolename,friendid,doj,reference_id1,Ref_Ways,Active ,mainrole)" +
                            "values('" + usruserid + "','" + ubal.RoleId1 + "','" + ubal.RoleName1 + "','" + ubal.Id + "','" + CurrenctDate + "','" + usruserid + "','AddNewUser',1,1)";
                        int a = cc.ExecuteNonQuery(sql);
                    }
                    string Sql = "Update UserMaster set IsMarketingPerson='Y' where UsrUserId='" + Convert.ToString(ViewState["User"]) + "'";
                    cc.ExecuteNonQuery(Sql);

                    //Sql = "update [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] set='10' where mobileNo='" + Convert.ToString(Session["MobileNumber"]) + "'";
                    //cc.ExecuteNonQuery(Sql);

                    string query = "select id from [Come2myCityDB].[come2mycity].TreeDemo where userid='" + usruserid + "' and Roleid= 1";
                    string CheckTree = cc.ExecuteScalar(query); // Get leader ID already add in tree digrame
                    if (!(CheckTree == null || CheckTree == ""))
                    {
                        // string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' and id=" + CheckTree + " ";
                        string check_Available = "select parentid from [Come2myCityDB].[come2mycity].TreeDemo where userid='" + ubal.Id + "' and Roleid=" + ubal.RoleId1 + "";

                        string GetID = cc.ExecuteScalar(check_Available); // check leader ID & Juniour Is already define or Not
                        if (!(GetID == null || GetID == ""))
                        {
                            if (CheckTree == GetID)
                            {
                                //Not 
                            }
                            else
                            {
                                string Addtree = "insert into [Come2myCityDB].[come2mycity].TreeDemo(userid,parentid,RoleId)values('" + ubal.Id + "','" + CheckTree + "'," + ubal.RoleId1 + ")";
                                int b = cc.ExecuteNonQuery(Addtree); // add new juniour in tree digrame
                            }
                        }
                        else
                        {
                            string Addtree = "insert into [Come2myCityDB].[come2mycity].TreeDemo(userid,parentid,RoleId)values('" + ubal.Id + "','" + CheckTree + "'," + ubal.RoleId1 + ")";
                            int b = cc.ExecuteNonQuery(Addtree); // add new juniour in tree digrame
                        }
                    }

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Marketing Person Added Successfully')", true);
                    Response.Redirect("../MarketingAdmin/UserList.aspx");
                }

                else
                {
                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('This Marketing Person is already exist'); window.location.href ='../MarketingAdmin/UserList.aspx';", true);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Marketing Person is already exist')", true);

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            /////////////////////////////////////////////////////////////////
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetUserValue(string Id)
    {
        btnSubmit.Text = "Update";
        string Sql = " select ms.city,ms.UseRole,ms.RoeId,ms.Uid1,ms.Doj,um.usrMobileNo from MartketingSubuser ms inner join UserMaster um on ms.Uid1=um.usrUserId  where ms.MID=" + Id + "";
        try
        {

            DataSet ds = cc.ExecuteDataset(Sql);

            txtMobileNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);
            txtDOB.Text = Convert.ToString(ds.Tables[0].Rows[0]["Doj"]);
            ddlRole.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["UseRole"]);
            ViewState["city1"] = Convert.ToString(ds.Tables[0].Rows[0]["city"]);
            ViewState["uid1"] = Convert.ToString(ds.Tables[0].Rows[0]["Uid1"]);
            ViewState["rid"] = Convert.ToString(ds.Tables[0].Rows[0]["RoeId"]);

        }
        catch (Exception ex)
        {

            string m = ex.Message;
        }
    }
    private void UserUpdate(string Id)
    {

        string data = "";

        if (rdoCityLocation.SelectedItem.Value == "SC")
        {

            ubal.CityName = Convert.ToString(ViewState["city1"]);

        }
        else if (rdoCityLocation.SelectedItem.Value == "DC")
        {
            if (cmbCity.SelectedValue != null)
            {

                ubal.CityName = Convert.ToString(cmbCity.SelectedItem.Text);
            }
            else
            {

                ubal.CityName = Convert.ToString(ViewState["city1"]);

            }

        }
        /////////////////////////////////////////////
        if (ddlRole.SelectedValue == "34" || ddlRole.SelectedValue == "35" || ddlRole.SelectedValue == "36")
        {
            if (ddlmenselection.SelectedValue == "1")
            {
                ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text) + "-Public";
                ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);
                //string roleid = Convert.ToString(ubal.RoleId1);  //unusable code
                //ubal.RoleId1 = Convert.ToInt32(roleid);

            }
            else if (ddlmenselection.SelectedValue == "2")
            {
                ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text) + "-Govt";
                ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);
                //string roleid = Convert.ToString(ubal.RoleId1); //unusable code
                //ubal.RoleId1 = Convert.ToInt32(roleid);

            }

        }
        else
        {
            ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text);
            ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);

        }
        //ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text);
        /////////////////////////////////////////
        ubal.MONO = Convert.ToString(Session["Mobile"]);
        ubal.Date = Convert.ToString(cc.ChangeDate(txtDOB.Text));
        string rolename = Convert.ToString(ViewState["RoleName"]);
        string rolename1 = ddlRole.SelectedItem.Text;
        if (rolename1 == rolename)
        {
            ubal.RoleId1 = Convert.ToInt16(ViewState["rid"]);
        }
        else
        {
            ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);
        }
        ubal.Id = Convert.ToString(ViewState["uid1"]);
        ubal.MID = Convert.ToInt32(ViewState["tbleid"]);
        status = ubal.updateUser(ubal);
        if (status > 0)
        {

            if (ddlRole.SelectedValue == "29")
            {

                ubal.RoleName1 = Convert.ToString(ddlRole.SelectedItem.Text);
                ubal.MONO = Convert.ToString(Session["Mobile"]);
                ubal.Date = Convert.ToString(cc.ChangeDate(txtDOB.Text));
                ubal.RoleId1 = Convert.ToInt32(ddlRole.SelectedValue);
                for (int i = 0; i < chkCommitee.Items.Count; i++)
                {
                    if (chkCommitee.Items[i].Selected == true)
                    {
                        data = data + "," + chkCommitee.Items[i].Value;

                    }
                }
                if (data.Length > 1)
                {
                    data = data.Substring(1);
                }

                ubal.Id = Convert.ToString(ViewState["User"]);
                ubal.Committeeid = data;
                status = ubal.BLLGetUserId(ubal);
                if (status > 0)
                {
                    status = ubal.BLLUpdateUserCommittee(ubal);
                }
                else
                {

                    status = ubal.BLLinsertUserCommittee(ubal);
                }

            }
            else if (ddlRole.SelectedValue == "28")
            {
                data = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31";
                ubal.Id = Convert.ToString(ViewState["User"]);
                ubal.Committeeid = data;
                status = ubal.BLLGetUserId(ubal);
                if (status > 0)
                {
                    status = ubal.BLLUpdateUserCommittee(ubal);
                }
                else
                {

                    status = ubal.BLLinsertUserCommittee(ubal);
                }

            }
            else
            {

                // changes by poonam - 7 aug-2013 for update AdminSubMarketingSubUser this table

                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + Convert.ToString(Session["MobileNumber"]) + "'";
                string id = cc.ExecuteScalar(sql1);
                if (id != "")
                {
                    string sql = "Update AdminSubMarketingSubUser set userid='" + id + "' ,roleid='" + ddlRole.SelectedValue + "',rolename='" + ddlRole.SelectedItem.Text + "',reference_id1='" + id + "' where [friendid]='" + Convert.ToString(ViewState["User"]) + "' ";
                    int a = cc.ExecuteNonQuery(sql);
                    if (a == 1)
                    {
                        string Sql = "Update UserMaster set IsMarketingPerson='Y' where UsrUserId='" + Convert.ToString(ViewState["User"]) + "'";
                        cc.ExecuteNonQuery(Sql);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Marketing Person Updated Successfully')", true);
                        Response.Redirect("../MarketingAdmin/UserList.aspx");
                        //HttpContext.Current.ApplicationInstance.CompleteRequest();


                    }

                }
            }

        }
    }
    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int groupId = Convert.ToInt32(ddlGroupName.SelectedValue);
            fillDDLSubGroup(groupId);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlSubGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string sql = "select KeywordName from KeywordDefinition inner join GroupItem " +
            " on GroupItem.GroupId = KeywordDefinition.GroupName inner join GroupValue " +
            " on GroupValue.GroupValueId=KeywordDefinition.SubGroupName " +
            " where KeywordDefinition.GroupName ='" + ddlGroupName.SelectedValue + "' and KeywordDefinition.SubGroupName='" + ddlSubGroupName.SelectedValue + "'";
            KeywordName = cc.ExecuteScalar(sql);
            lblName.Visible = true;
            lblName.Text = KeywordName;

            //int groupId = Convert.ToInt32(ddlSubGroupName.SelectedValue);
        }
        catch (Exception ex)
        { }
    }
    public void FillDDLGroup()//
    {
        try
        {
            dtkeywordList = keywordBLLObj.BLLSelectAllGroup();

            ddlGroupName.DataSource = dtkeywordList;
            ddlGroupName.DataTextField = "GroupName";
            ddlGroupName.DataValueField = "GroupId";
            ddlGroupName.DataBind();
            ddlGroupName.Items.Add("---Select---");
            ddlSubGroupName.Items.Add("---Select---");
            ddlSubGroupName.Items[ddlSubGroupName.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void fillDDLSubGroup(int GroupId)
    {
        try
        {
            dtkeywordList = keywordBLLObj.BLLSelectSubGroupById(GroupId);
            ddlSubGroupName.DataSource = dtkeywordList;
            ddlSubGroupName.DataTextField = "GroupValueName";
            ddlSubGroupName.DataValueField = "GroupValueId";
            ddlSubGroupName.DataBind();
            ddlSubGroupName.Items.Add("---Select---");
            ddlSubGroupName.SelectedIndex = ddlSubGroupName.Items.Count - 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            // Validation();
            if (ddlRole.Text == "--Select--")
            {
                Response.Write("<script>alert('Select Role')</script>");

                ddlRole.Focus();
            }
            else
            {
                string enterMob = txtMobileNumber.Text;
                ViewState["Mobileno"] = enterMob;
                //string groupname = ddlgroupname.SelectedItem.Text;
                string Sql = "Select UsrUserId from UserMaster where usrMobileNo='" + txtMobileNumber.Text.ToString() + "'";
                string UserId = Convert.ToString(cc.ExecuteScalar(Sql));
                //string sql12 = "update UserMaster set JoinGroup='" + groupname + "' where usrUserid='" + UserId + "'";
                //int execute = cc.ExecuteNonQuery(sql12);
                string sql1 = "update usermaster set JoinGroup='" + KeywordName + "'where UsrUserId='" + UserId + "'";
                string execute = cc.ExecuteScalar(sql1);
                if (UserId == "")
                {
                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('This user has not Joined www.myct.in Firstly Join to this user and then Add as a Marketing Person'); window.location.href ='http://www.come2mycity.com';", true);  


                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This user has not Joined www.myct.in Firstly Join to this user and then Add as a Marketing Person')", true);
                }
                else
                {
                    string Id = Convert.ToString(Request.QueryString["id"]);
                    if (Id == "" || Id == null)
                    {
                        //Add
                        ViewState["User"] = UserId;
                        UserAdd();
                    }
                    else
                    {
                        //Update
                        ViewState["tbleid"] = Id;
                        ViewState["User"] = UserId;
                        UserUpdate(Id);
                        btnSubmit.Text = "Submit";
                        btnDelete.Visible = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string m1 = ex.Message;
        }
    }
    private void LoadState()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = (DataSet)Session["Location"];
            if (ds == null)
            {
                Location loc = new Location();
               // ds = loc.getAllLocation();
                ds = loc.GetAllLocation();
                Session["Location"] = ds;
            }
            if (ds.Tables[0] != null)
            {
                cmbState.DataSource = ds.Tables[0];
                cmbState.DataTextField = "StateName";
                cmbState.DataValueField = "StateId";
                cmbState.DataBind();
                cmbState.Items.Add("--Select--");
                cmbState.Items[cmbState.Items.Count - 1].Value = " ";
                cmbDistrict.Items.Add("--Select--");
                cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = " ";
                cmbDistrict.Enabled = false;
                cmbCity.Items.Add("--Select--");
                cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";
                cmbCity.Enabled = false;
                cmbState.SelectedIndex = cmbState.Items.Count - 1;
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    private DataTable getDataTable(DataRow[] dr1)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        try
        {
            foreach (DataRow dr in dr1)
            {
                DataRow ddr = dt.NewRow();
                ddr["Id"] = dr[0].ToString();
                ddr["Name"] = dr[1].ToString();
                dt.Rows.Add(ddr);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        return dt;
    }
    protected void cmbState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cmbDistrict.Enabled = true;
            int sId = Convert.ToInt32(Convert.ToString(cmbState.SelectedValue));

            DataTable dtDisrtictShowById = districtBLLObj.BLLGetSelectedDistrictBySId(districtBLLObj, sId);

            cmbDistrict.DataSource = dtDisrtictShowById;
            cmbDistrict.DataTextField = "distName";
            cmbDistrict.DataValueField = "distId";
            cmbDistrict.DataBind();
            cmbDistrict.Items.Add("---Select---");
            cmbDistrict.SelectedIndex = cmbDistrict.Items.Count - 1;
            cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }

    }
    protected void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cmbCity.Enabled = true;
            int dId = Convert.ToInt32(Convert.ToString(cmbDistrict.SelectedValue));



            DataTable dtCityShowById = cityBLLObj.BLLGetSelectedCityByDId(cityBLLObj, dId);

            cmbCity.DataSource = dtCityShowById;
            cmbCity.DataTextField = "cityName";
            cmbCity.DataValueField = "cityId";
            cmbCity.DataBind();
            cmbCity.Items.Add("---Select---");
            cmbCity.SelectedIndex = cmbCity.Items.Count - 1;
            cmbCity.Items[cmbCity.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    private void LoadPlace()
    {
        try
        {
            // DataTable dtStateShowAll = stateBLLObj.BLLStateHCShowAll(); 
            DataTable dtStateShowAll = stateBLLObj.BLLStateShowAll();
            cmbState.DataSource = dtStateShowAll;
            cmbState.DataTextField = "stateName";
            cmbState.DataValueField = "stateId";
            cmbState.DataBind();
            cmbState.Items.Add("---Select---");
            cmbState.SelectedIndex = cmbState.Items.Count - 1;
            cmbState.Items[cmbState.Items.Count - 1].Value = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdoCityLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdoCityLocation.SelectedValue == "DC")
            {
                pnlSelectLocation.Visible = true;
                LoadPlace();

                cmbDistrict.Enabled = false;
                cmbCity.Enabled = false;
            }
            else
            {
                pnlSelectLocation.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void txtMobileNumber_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../MarketingAdmin/UserList.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            string Userid = "select Uid1 from MartketingSubuser where MID=" + Id + "";
            string UID = cc.ExecuteScalar(Userid);

            string Sql = "Update UserMaster set IsMarketingPerson='N' where UsrUserId='" + UID + "'";
            cc.ExecuteNonQuery(Sql);
            int a = 0;
            string del = "Update  MartketingSubuser set Active=" + a + " where Uid1='" + UID + "'";
            cc.ExecuteNonQuery(del);

            //Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('This  Person is Now A Not Marketing Person, And Removed Succesfully!'); window.location.href ='../MarketingAdmin/UserList.aspx';", true);
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.Redirect("../MarketingAdmin/UserList.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedItem.Text == "Authority")
        {
            SubGroupname.Visible = true;
        }
        else if (ddlRole.SelectedValue == "29")
        {
            trCommittee.Visible = true;
        }
        else if (ddlRole.SelectedValue == "34" || ddlRole.SelectedValue == "35" || ddlRole.SelectedValue == "36")
        {
            trmenuselection.Visible = true;
        }
    }
}
