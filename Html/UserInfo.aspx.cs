using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

public partial class Html_UserInfo : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
    bool imageOk = false;
    DataSet ds = new DataSet();
    String path = HttpContext.Current.Request.PhysicalApplicationPath + "User_Resource\\";

    public string name;
    public string dob;
    public string city;
    public string recentVisitor;
    public string[] rvisitor;
    public string recentVisitorName;

    //CityBLL cityBLLObj = new CityBLL();
    //StateBLL stateBLLObj = new StateBLL();
    //DistrictBLL districtBLLObj = new DistrictBLL();
    public string uId = "";

    int status;

    public List<UserRegistrationBLL> urRecentList = new List<UserRegistrationBLL>();
    public List<UserRegistrationBLL> urRecentName = new List<UserRegistrationBLL>();


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
                try
                {
                    lblProfileName.Text = Convert.ToString(Session["UserFirstNameN"]) + " " + Session["UserLastNameN"] + " (Last Login:" + Convert.ToString(Session["lastLogin"]) + ")" + "";// ONLINE VISITORS:" + (Convert.ToInt32(Application["LoginUsers"])).ToString();
                    ImageLoad();
                    UserProfileHeaderInfo();
                    ShowContact();
                    ShowProfessionalInfo();
                    ShowSocialInfo();
                    ShowFamilyInfo();
                    LoadMemberOf();

                    LoadReligion();
                    LoadUserCategory();

                }
                catch (Exception ex)
                {
                    //Response.Redirect("../Default.aspx");
                }
            }
        }
    }
    #region FamilyInfo
    public void ShowFamilyInfo()
    {
        loadSchoolClass();
        //string usrId = Convert.ToString(Session["User"]);
        //string sql = "select usrFIlfptr,usrFIname1,usrFIname2,usrFIname3,usrFIgender1,usrFIgender2,usrFIgender3,";
        //sql += "usrFIschool1,usrFIschool2,usrFIschool3,usrFIclass1,usrFIclass2,usrFIclass3,";
        //sql += "usrFIrollNo1,usrFIrollNo2,usrFIrollNo3 from tblFamilyInfoMaster where usrUserId='" + usrId.ToString() + "'";
        //DataSet dsTable = new DataSet();
        //dsTable = cc.ExecuteDataset(sql);
        //gvFamilyInfo.DataSource = dsTable;
        //gvFamilyInfo.DataBind();
        List<UserRegistrationBLL> list = new List<UserRegistrationBLL>();
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        list = urUserRegBLLObj.GetUsrFamiInfo(urUserRegBLLObj);

        if (list.Count != 0)
        {

            try
            {
                //txtFIlfptr.Text = Convert.ToString("Mahesh");
                txtFIlfptr.Text = Convert.ToString(list[0].usrFIlfptr);
                txtFIname1.Text = Convert.ToString(list[0].usrFIname1);
                txtFIname2.Text = Convert.ToString(list[0].usrFIname2);
                txtFIname3.Text = Convert.ToString(list[0].usrFIname3);
                if (Convert.ToString(list[0].usrFIgender1) != "")
                    ddlFIgendet1.SelectedValue = Convert.ToString(list[0].usrFIgender1);
                if (Convert.ToString(list[0].usrFIgender2) != "")
                    ddlFIgender2.SelectedValue = Convert.ToString(list[0].usrFIgender2);
                if (Convert.ToString(list[0].usrFIgender3) != "")
                    ddlFIgender3.SelectedValue = Convert.ToString(list[0].usrFIgender3);
                if (Convert.ToString(list[0].usrFIschool1) != "")
                    ddlFIschool1.SelectedValue = Convert.ToString(list[0].usrFIschool1);
                if (Convert.ToString(list[0].usrFIschool2) != "")
                    ddlFIschool2.SelectedValue = Convert.ToString(list[0].usrFIschool2);
                if (Convert.ToString(list[0].usrFIschool3) != "")
                    ddlFIschool3.SelectedValue = Convert.ToString(list[0].usrFIschool3);
                if (Convert.ToString(list[0].usrFIclass1) != "")
                    ddlFIclass1.SelectedValue = Convert.ToString(list[0].usrFIclass1);
                if (Convert.ToString(list[0].usrFIclass2) != "")
                    ddlFIclass2.SelectedValue = Convert.ToString(list[0].usrFIclass2);
                if (Convert.ToString(list[0].usrFIclass3) != "")
                    ddlFIclass3.SelectedValue = Convert.ToString(list[0].usrFIclass3);
                txtFIrollNo1.Text = Convert.ToString(list[0].usrFIrollNo1);
                txtFIrollNo2.Text = Convert.ToString(list[0].usrFIrollNo2);
                txtFIrollNo3.Text = Convert.ToString(list[0].usrFIrollNo3);

                List<UserRegistrationBLL> listModify = new List<UserRegistrationBLL>();
                listModify = ListModification(list);
                gvFamilyInfo.DataSource = listModify;
                gvFamilyInfo.DataBind();

            }
            catch (Exception ttt)
            {
                throw ttt;
            }
        }
    }

    public List<UserRegistrationBLL> ListModification(List<UserRegistrationBLL> ll)
    {
        List<UserRegistrationBLL> listModifyRet = new List<UserRegistrationBLL>();
        listModifyRet = ll;
        if (Convert.ToString(listModifyRet[0].usrFIschool1) != "")
        {
            listModifyRet[0].usrFIschool1 = FindSchool(Convert.ToString(listModifyRet[0].usrFIschool1));
        }
        if (Convert.ToString(listModifyRet[0].usrFIschool2) != "")
        {
            listModifyRet[0].usrFIschool2 = FindSchool(Convert.ToString(listModifyRet[0].usrFIschool2));
        }
        if (Convert.ToString(listModifyRet[0].usrFIschool3) != "")
        {
            listModifyRet[0].usrFIschool3 = FindSchool(Convert.ToString(listModifyRet[0].usrFIschool3));
        }
        if (Convert.ToString(listModifyRet[0].usrFIclass1) != "")
        {
            listModifyRet[0].usrFIclass1 = FindClass(Convert.ToString(listModifyRet[0].usrFIclass1));
        }
        if (Convert.ToString(listModifyRet[0].usrFIclass2) != "")
        {
            listModifyRet[0].usrFIclass2 = FindClass(Convert.ToString(listModifyRet[0].usrFIclass2));
        }
        if (Convert.ToString(listModifyRet[0].usrFIclass3) != "")
        {
            listModifyRet[0].usrFIclass3 = FindClass(Convert.ToString(listModifyRet[0].usrFIclass3));
        }
        if (Convert.ToString(listModifyRet[0].usrFIgender1) != "")
        {
            if (Convert.ToString(listModifyRet[0].usrFIgender1) == "1")
            {
                listModifyRet[0].usrFIgender1 = "Male";
            }
            else
            {
                listModifyRet[0].usrFIgender1 = "Female";
            }
        }
        if (Convert.ToString(listModifyRet[0].usrFIgender2) != "")
        {
            if (Convert.ToString(listModifyRet[0].usrFIgender2) == "1")
            {
                listModifyRet[0].usrFIgender2 = "Male";
            }
            else
            {
                listModifyRet[0].usrFIgender2 = "Female";
            }
        }
        if (Convert.ToString(listModifyRet[0].usrFIgender3) != "")
        {
            if (Convert.ToString(listModifyRet[0].usrFIgender3) == "1")
            {
                listModifyRet[0].usrFIgender3 = "Male";
            }
            else
            {
                listModifyRet[0].usrFIgender3 = "Female";
            }
        }

        return listModifyRet;
    }
    public string FindSchool(string sid)
    {
        string schoolName = "";
        string sql = "select SchoolName from SchoolMaster where SchoolId=" + sid.ToString();
        schoolName = cc.ExecuteScalar(sql);

        return schoolName;
    }
    public string FindClass(string cid)
    {
        string className = "";
        string sql = "select ClassName from ClassMaster where ClassId=" + cid.ToString();
        className = cc.ExecuteScalar(sql);
        return className;
    }
    public void loadSchoolClass()
    {
        string sqlFillSchool = "select SchoolId,SchoolName from schoolMaster";
        DataSet dss = new DataSet();
        dss = cc.ExecuteDataset(sqlFillSchool);
        ddlFIschool1.DataSource = dss;
        ddlFIschool1.DataTextField = "SchoolName";
        ddlFIschool1.DataValueField = "SchoolId";
        ddlFIschool1.DataBind();
        ddlFIschool1.Items.Add("--Select--");
        ddlFIschool1.SelectedIndex = ddlFIschool1.Items.Count - 1;
        ddlFIschool1.Items[ddlFIschool1.Items.Count - 1].Value = "";

        ddlFIschool2.DataSource = dss;
        ddlFIschool2.DataTextField = "SchoolName";
        ddlFIschool2.DataValueField = "SchoolId";
        ddlFIschool2.DataBind();
        ddlFIschool2.Items.Add("--Select--");
        ddlFIschool2.SelectedIndex = ddlFIschool2.Items.Count - 1;
        ddlFIschool2.Items[ddlFIschool2.Items.Count - 1].Value = "";

        ddlFIschool3.DataSource = dss;
        ddlFIschool3.DataTextField = "SchoolName";
        ddlFIschool3.DataValueField = "SchoolId";
        ddlFIschool3.DataBind();
        ddlFIschool3.Items.Add("--Select--");
        ddlFIschool3.SelectedIndex = ddlFIschool3.Items.Count - 1;
        ddlFIschool3.Items[ddlFIschool3.Items.Count - 1].Value = "";

        string sqlClass = "select ClassId,ClassName from ClassMaster";
        DataSet ds = cc.ExecuteDataset(sqlClass);
        ddlFIclass1.DataSource = ds;
        ddlFIclass1.DataTextField = "ClassName";
        ddlFIclass1.DataValueField = "ClassId";
        ddlFIclass1.DataBind();
        ddlFIclass1.Items.Add("--Select--");
        ddlFIclass1.SelectedIndex = ddlFIclass1.Items.Count - 1;
        ddlFIclass1.Items[ddlFIclass1.Items.Count - 1].Value = "";

        ddlFIclass2.DataSource = ds;
        ddlFIclass2.DataTextField = "ClassName";
        ddlFIclass2.DataValueField = "ClassId";
        ddlFIclass2.DataBind();
        ddlFIclass2.Items.Add("--Select--");
        ddlFIclass2.SelectedIndex = ddlFIclass2.Items.Count - 1;
        ddlFIclass2.Items[ddlFIclass2.Items.Count - 1].Value = "";

        ddlFIclass3.DataSource = ds;
        ddlFIclass3.DataTextField = "ClassName";
        ddlFIclass3.DataValueField = "ClassId";
        ddlFIclass3.DataBind();
        ddlFIclass3.Items.Add("--Select--");
        ddlFIclass3.SelectedIndex = ddlFIclass3.Items.Count - 1;
        ddlFIclass3.Items[ddlFIclass3.Items.Count - 1].Value = "";

    }
    public void UpdateFamilyInfo()
    {
        urUserRegBLLObj.usrFIlfptr = txtFIlfptr.Text;
        urUserRegBLLObj.usrFIname1 = txtFIname1.Text;
        urUserRegBLLObj.usrFIname2 = txtFIname2.Text;
        urUserRegBLLObj.usrFIname3 = txtFIname3.Text;
        if (txtFIname1.Text == "")
        {
            urUserRegBLLObj.usrFIgender1 = "";
        }
        else
        {
            urUserRegBLLObj.usrFIgender1 = ddlFIgendet1.SelectedValue;
        }
        if (txtFIname2.Text == "")
        {
            urUserRegBLLObj.usrFIgender2 = "";
        }
        else
        {
            urUserRegBLLObj.usrFIgender2 = ddlFIgender2.SelectedValue;
        }
        if (txtFIname3.Text == "")
        {
            urUserRegBLLObj.usrFIgender3 = "";
        }
        else
        {
            urUserRegBLLObj.usrFIgender3 = ddlFIgender3.SelectedValue;
        }
        urUserRegBLLObj.usrFIschool1 = Convert.ToString(ddlFIschool1.SelectedValue);
        urUserRegBLLObj.usrFIschool2 = Convert.ToString(ddlFIschool2.SelectedValue);
        urUserRegBLLObj.usrFIschool3 = Convert.ToString(ddlFIschool3.SelectedValue);
        urUserRegBLLObj.usrFIclass1 = Convert.ToString(ddlFIclass1.SelectedValue);
        urUserRegBLLObj.usrFIclass2 = Convert.ToString(ddlFIclass2.SelectedValue);
        urUserRegBLLObj.usrFIclass3 = Convert.ToString(ddlFIclass3.SelectedValue);
        urUserRegBLLObj.usrFIrollNo1 = txtFIrollNo1.Text;
        urUserRegBLLObj.usrFIrollNo2 = txtFIrollNo2.Text;
        urUserRegBLLObj.usrFIrollNo3 = txtFIrollNo3.Text;
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        int up = urUserRegBLLObj.UpdateFamilyInfo(urUserRegBLLObj);
        //if (up > 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Family Information Updated Successfully.')", true);

        //}

    }
    public void InsertFamilyInfo()
    {
        urUserRegBLLObj.usrFIlfptr = txtFIlfptr.Text;
        urUserRegBLLObj.usrFIname1 = txtFIname1.Text;
        urUserRegBLLObj.usrFIname2 = txtFIname2.Text;
        urUserRegBLLObj.usrFIname3 = txtFIname3.Text;
        if (txtFIname1.Text == "")
        {
            urUserRegBLLObj.usrFIgender1 = "";
        }
        else
        {
            urUserRegBLLObj.usrFIgender1 = ddlFIgendet1.SelectedValue;
        }
        if (txtFIname2.Text == "")
        {
            urUserRegBLLObj.usrFIgender2 = "";
        }
        else
        {
            urUserRegBLLObj.usrFIgender2 = ddlFIgender2.SelectedValue;
        }
        if (txtFIname3.Text == "")
        {
            urUserRegBLLObj.usrFIgender3 = "";
        }
        else
        {
            urUserRegBLLObj.usrFIgender3 = ddlFIgender3.SelectedValue;
        }
        urUserRegBLLObj.usrFIschool1 = Convert.ToString(ddlFIschool1.SelectedValue);
        urUserRegBLLObj.usrFIschool2 = Convert.ToString(ddlFIschool2.SelectedValue);
        urUserRegBLLObj.usrFIschool3 = Convert.ToString(ddlFIschool3.SelectedValue);
        urUserRegBLLObj.usrFIclass1 = Convert.ToString(ddlFIclass1.SelectedValue);
        urUserRegBLLObj.usrFIclass2 = Convert.ToString(ddlFIclass2.SelectedValue);
        urUserRegBLLObj.usrFIclass3 = Convert.ToString(ddlFIclass3.SelectedValue);
        urUserRegBLLObj.usrFIrollNo1 = txtFIrollNo1.Text;
        urUserRegBLLObj.usrFIrollNo2 = txtFIrollNo2.Text;
        urUserRegBLLObj.usrFIrollNo3 = txtFIrollNo3.Text;
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        int upp = urUserRegBLLObj.InsertFamilyInfo(urUserRegBLLObj);
    }
    public void btnUpdateFamilyInfo_Click(object sender, EventArgs e)
    {
        string uidS = Convert.ToString(Session["User"]);
        string SQL = "select usrUserId from tblFamilyInfoMaster where usrUserId='" + uidS.ToString() + "'";
        string gen1 = cc.ExecuteScalar(SQL);
        if (gen1 == "")
        {
            InsertFamilyInfo();
            ShowFamilyInfo();
        }
        else
        {
            UpdateFamilyInfo();
            ShowFamilyInfo();
        }

    }
    #endregion

    public void LoadReligion()
    {
        try
        {
            string sql = "select * from Religion";
            DataSet ds = cc.ExecuteDataset(sql);
            ddlreligion.DataValueField = "Id";
            ddlreligion.DataTextField = "Religion";
            ddlreligion.Items.Add("--Select--");
            ddlreligion.DataSource = ds.Tables[0];
            ddlreligion.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    public void LoadUserCategory()
    {
        try
        {
            string sql = "select * from usrCategory";
            DataSet ds = cc.ExecuteDataset(sql);
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataTextField = "Category";
            ddlCategory.Items.Add("--Select--");
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    private void ImageLoad()
    {
        string sql = "select usrAutoId from usermaster where usrUserid='" + Session["User"].ToString() + "' ";
        string usrAutoId = cc.ExecuteScalar(sql);
        sql = "select id  from [Come2myCityDB].[come2mycity].storeimage where usrAutoId='" + usrAutoId + "' ";
        string id = cc.ExecuteScalar(sql);
        if (id == "" || id == null)
        {
            usrAutoId = "0";
            profileImage.ImageUrl = "../html/MyImg.aspx?usrAutoId='" + usrAutoId + "'&width=100&Hight=100";
        }
        else
        {
            profileImage.ImageUrl = "../html/MyImg.aspx?usrAutoId='" + usrAutoId + "'&width=100&Hight=100";
        }
    }

    #region UserProfile
    public List<UserRegistrationBLL> UserProfileHeaderInfo()
    {
        List<UserRegistrationBLL> upHeadList = new List<UserRegistrationBLL>();
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            ds = urUserRegBLLObj.BLLGetUserContactInfo(urUserRegBLLObj);
            DataRow dRowUserList = ds.Tables[0].Rows[0];

            // profileImage.ImageUrl = Convert.ToString(dRowUserList["usrProfilePhoto"]);


            name = Convert.ToString(dRowUserList["usrFullName"]);
            dob = Convert.ToString(dRowUserList["usrDOB"]);
            city = Convert.ToString(dRowUserList["usrCity"]);
            recentVisitor = Convert.ToString(dRowUserList["usrRecentVisitor"]);


            rvisitor = recentVisitor.Split(',');
            for (int j = 0; j < rvisitor.Length; j++)
            {
                if (rvisitor[j] != "")
                {

                    urUserRegBLLObj.usrUserId = rvisitor[j];
                    DataSet dsRecentUserInfo = urUserRegBLLObj.BLLGetUserContactInfo(urUserRegBLLObj);

                    for (int k = 0; k < dsRecentUserInfo.Tables[0].Rows.Count; k++)
                    {
                        DataRow dRowUserInfo = dsRecentUserInfo.Tables[0].Rows[k];
                        UserRegistrationBLL ur = new UserRegistrationBLL();
                        ur.usrRecentVisitorName = Convert.ToString(dRowUserInfo["usrFirstName"]);
                        ur.usrUserId = rvisitor[j];
                        upHeadList.Add(ur);
                    }

                }

            }

        }
        catch (Exception ex)
        {
            // throw ex;
        }
        return upHeadList;
    }
    #endregion

    #region UpdateContact
    public void ShowContact()
    {
        try
        {
            gvContactDisplay.DataSource = ds.Tables[0];
            gvContactDisplay.DataBind();

            try
            {

                DataTable dtUserList = ds.Tables[0];
                DataRow dRowUserList = dtUserList.Rows[0];
                DataSet Location = (DataSet)Session["Location"];

                txtFirstName.Text = Convert.ToString(dRowUserList["usrFirstName"]);
                txtMiddleName.Text = Convert.ToString(dRowUserList["usrMiddleName"]);
                txtLastName.Text = Convert.ToString(dRowUserList["usrLastName"]);
                txtAddress.Text = Convert.ToString(dRowUserList["usrAddress"]);
                txtUserArea.Text = Convert.ToString(dRowUserList["usrArea"]);

                cmbState.DataSource = Location.Tables[0];
                cmbState.DataTextField = "StateName";
                cmbState.DataValueField = "StateId";
                cmbState.DataBind();
                cmbState.Items.Add("--Select--");
                cmbState.Items[cmbState.Items.Count - 1].Value = " ";

                cmbState.SelectedValue = Convert.ToString(dRowUserList["usrStateId"]);
                if (cmbState.SelectedIndex != cmbState.Items.Count - 1)
                {
                    if (ds.Tables[1] != null)
                    {
                        DataRow[] dr = Location.Tables[1].Select("StateId=" + cmbState.SelectedValue.ToString() + "");
                        cmbDistrict.DataSource = getDataTable(dr);
                        cmbDistrict.DataTextField = "Name";
                        cmbDistrict.DataValueField = "Id";
                        cmbDistrict.DataBind();
                        cmbDistrict.Items.Add("--Select--");
                        cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = " ";
                        cmbDistrict.SelectedValue = Convert.ToString(dRowUserList["usrDistrictId"]);
                    }
                }

                if (cmbDistrict.SelectedIndex != cmbDistrict.Items.Count - 1)
                {
                    if (ds.Tables[2] != null)
                    {
                        DataRow[] dr = Location.Tables[2].Select("DistrictId=" + cmbDistrict.SelectedValue.ToString() + "");
                        cmbCity.DataSource = getDataTable(dr);
                        cmbCity.DataTextField = "Name";
                        cmbCity.DataValueField = "Id";
                        cmbCity.DataBind();
                        cmbCity.Items.Add("--Select--");
                        cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";
                        cmbCity.SelectedIndex = cmbCity.Items.Count - 1;
                        cmbCity.SelectedValue = Convert.ToString(dRowUserList["usrCityId"]);
                    }
                }

                txtPin.Text = Convert.ToString(dRowUserList["usrPIN"]);
                txtPhoneNumber.Text = Convert.ToString(dRowUserList["usrPhoneNo"]);
                txtMobileNumber.Text = Convert.ToString(dRowUserList["usrMobileNo"]);
                txtAltMobileNumber.Text = Convert.ToString(dRowUserList["usrAltMobileNo"]);
                txtDOB.Text = Convert.ToString(dRowUserList["usrDOB"]);

                txtPhoneOffice.Text = Convert.ToString(dRowUserList["OfficeNo"]);
                txtEmailId.Text = Convert.ToString(dRowUserList["usrEmailId"]);
                txtFaxNo.Text = Convert.ToString(dRowUserList["FaxNo"]);
                txtWebsite.Text = Convert.ToString(dRowUserList["Website"]);

            }
            catch (Exception ex)
            {
                //throw ex;
            }

        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    protected void cmbState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet Location = (DataSet)Session["Location"];
            if (cmbState.SelectedIndex != cmbState.Items.Count - 1)
            {
                if (Location.Tables[1] != null)
                {
                    DataRow[] dr = Location.Tables[1].Select("StateId=" + cmbState.SelectedValue.ToString() + "");
                    cmbDistrict.DataSource = getDataTable(dr);
                    cmbDistrict.DataTextField = "Name";
                    cmbDistrict.DataValueField = "Id";
                    cmbDistrict.DataBind();
                    cmbDistrict.Items.Add("--Select--");
                    cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = " ";
                    cmbDistrict.SelectedIndex = cmbDistrict.Items.Count - 1;
                }
            }
            else
            {
                cmbCity.Items.Clear();
                cmbDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        mdlContact.Show();
    }
    protected void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet Location = (DataSet)Session["Location"];
            if (cmbDistrict.SelectedIndex != cmbDistrict.Items.Count - 1)
            {
                if (Location.Tables[2] != null)
                {
                    DataRow[] dr = Location.Tables[2].Select("DistrictId=" + cmbDistrict.SelectedValue.ToString() + "");
                    cmbCity.DataSource = getDataTable(dr);
                    cmbCity.DataTextField = "Name";
                    cmbCity.DataValueField = "Id";
                    cmbCity.DataBind();
                    cmbCity.Items.Add("--Select--");
                    cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";
                    cmbCity.SelectedIndex = cmbCity.Items.Count - 1;
                }
            }
            else
            {
                cmbCity.Items.Clear();

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        mdlContact.Show();
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
    protected void txtUserArea_TextChanged(object sender, EventArgs e)
    {
        string[] id;
        try
        {
            string str = txtUserArea.Text.ToString();
            if (str.Contains(':'))
            {
                id = str.Split(':');

                txtUserArea.Text = id[1];
                ViewState["userAreaId"] = id[0];
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        mdlContact.Show();
    }
    private void UpdateContactInfo()
    {
        try
        {
            int j = 0;
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            urUserRegBLLObj.usrFirstName = txtFirstName.Text;
            urUserRegBLLObj.usrMiddleName = txtMiddleName.Text;
            urUserRegBLLObj.usrLastName = txtLastName.Text;
            urUserRegBLLObj.usrAddress = txtAddress.Text;
            urUserRegBLLObj.usrArea = txtUserArea.Text;
            urUserRegBLLObj.usrStateId = Convert.ToInt32(Convert.ToString(cmbState.SelectedValue));
            urUserRegBLLObj.usrDistrictId = Convert.ToInt32(Convert.ToString(cmbDistrict.SelectedValue));
            urUserRegBLLObj.usrCityId = Convert.ToInt32(Convert.ToString(cmbCity.SelectedValue));
            if (ViewState["userAreaId"] != null)
            {
                urUserRegBLLObj.usrAreaId = Convert.ToInt32(Convert.ToString(ViewState["userAreaId"]));
            }
            else
            {
                int id;
                urUserRegBLLObj.usrArea = txtUserArea.Text;
                //urUserRegBLLObj.usrCityId = Convert.ToInt32(Convert.ToString(Session["cityId"]));
                urUserRegBLLObj.BLLUserAreaInsert(urUserRegBLLObj, out id, out status);
                if (status == 0)
                {
                    urUserRegBLLObj.usrAreaId = id;
                }
                else
                {
                    urUserRegBLLObj.usrAreaId = id;
                }
            }
            urUserRegBLLObj.usrPIN = Convert.ToString(txtPin.Text);
            urUserRegBLLObj.usrPhoneNo = Convert.ToString(txtPhoneNumber.Text);
            urUserRegBLLObj.usrMobileNo = Convert.ToString(txtMobileNumber.Text);
            urUserRegBLLObj.usrAltMobileNo = Convert.ToString(txtAltMobileNumber.Text);
            urUserRegBLLObj.usrControlMobileNo = Convert.ToInt32(Convert.ToString(ddlControlMobile.SelectedValue));
            urUserRegBLLObj.usrDOB = Convert.ToString(txtDOB.Text);
            urUserRegBLLObj.usrEmailId = Convert.ToString(txtEmailId.Text);
            urUserRegBLLObj.OfficeNo = Convert.ToString(txtPhoneOffice.Text);
            urUserRegBLLObj.FaxNo = Convert.ToString(txtFaxNo.Text);
            urUserRegBLLObj.Website = Convert.ToString(txtWebsite.Text);
            j = urUserRegBLLObj.BLLUpdateUserRegistrationContact(urUserRegBLLObj);
            if (j > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Contact Information Updated')", true);
                // Response.Write("<script>alert('Updated.')</script>");
                Response.Redirect("UserInfo.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Contact Information Not Updated')", true);
                // Response.Write("<script>alert('Not Updated.')</script>");
            }
        }
        catch (Exception ex)
        {
            lblErrorContact.Visible = true;
            lblErrorContact.Text = "Cant update the contact";
            mdlContact.Show();
        }

    }
    protected void btnUpdateContact_Click(object sender, EventArgs e)
    {
        UpdateContactInfo();
    }
    #endregion

    #region Update Profession
    private void ShowProfessionalInfo()
    {
        try
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvProfessionalInfo.DataSource = ds.Tables[1];
                gvProfessionalInfo.DataBind();

                try
                {
                    DataTable dtUserList = ds.Tables[1];
                    DataRow dRowUserList = dtUserList.Rows[0];

                    DataSet dsQualificationIndustries = urUserRegBLLObj.BLLUserQualificationIndustriesShow();

                    DataTable dtUserQualification = dsQualificationIndustries.Tables[0];
                    cmbQualification.DataSource = dtUserQualification;
                    cmbQualification.DataTextField = "qualificationName";
                    cmbQualification.DataValueField = "qualificationId";
                    cmbQualification.DataBind();

                    DataTable dtUserIndustry = dsQualificationIndustries.Tables[1];
                    cmbIndustry.DataSource = dtUserIndustry;
                    cmbIndustry.DataTextField = "industryName";
                    cmbIndustry.DataValueField = "industryId";
                    cmbIndustry.DataBind();




                    cmbQualification.SelectedItem.Text = Convert.ToString(dRowUserList["usrHighestQualification"]);
                    txtBoardUniversity.Text = Convert.ToString(dRowUserList["usrBoardUniversity"]);
                    txtprofession.Text = Convert.ToString(dRowUserList["usrProfession"]);

                    cmbIndustry.SelectedItem.Text = Convert.ToString(dRowUserList["usrIndustry"]);
                    txtCompanyName.Text = Convert.ToString(dRowUserList["usrCompanyName"]);
                    txtCarrerSkill.Text = Convert.ToString(dRowUserList["usrCarrerSkill"]);
                    txtCarrerInterest.Text = Convert.ToString(dRowUserList["usrCarrerInterest"]);



                }
                catch (Exception ex)
                {
                    //   throw ex;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void updateProfessionalInfo()
    {
        try
        {
            int j = 0;
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);

            urUserRegBLLObj.usrHighestQualification = Convert.ToInt32(Convert.ToString(cmbQualification.SelectedValue));

            if (ViewState["BoardUniversityId"] != null)
            {
                urUserRegBLLObj.usrBoardUniversity = Convert.ToInt32(Convert.ToString(ViewState["BoardUniversityId"]));
            }
            else
            {
                int id;
                urUserRegBLLObj.usrBoardUniversityName = txtBoardUniversity.Text;
                urUserRegBLLObj.BLLUserBoardUniversityInsert(urUserRegBLLObj, out id, out status);
                if (status == 0)
                {
                    urUserRegBLLObj.usrBoardUniversity = id;
                }
                else
                {
                    urUserRegBLLObj.usrBoardUniversity = id;
                }
            }
            if (ViewState["ProfessionId"] != null)
            {
                urUserRegBLLObj.usrProfession = Convert.ToInt32(Convert.ToString(ViewState["ProfessionId"]));
            }
            else
            {
                int id;
                urUserRegBLLObj.usrProfessionName = txtprofession.Text;
                urUserRegBLLObj.BLLUserProfessionInsert(urUserRegBLLObj, out id, out status);
                if (status == 0)
                {
                    urUserRegBLLObj.usrProfession = id;
                }
                else
                {
                    urUserRegBLLObj.usrProfession = id;
                }
            }



            urUserRegBLLObj.usrIndustry = Convert.ToInt32(Convert.ToString(cmbIndustry.SelectedValue));

            urUserRegBLLObj.usrCompanyName = Convert.ToString(txtCompanyName.Text);
            urUserRegBLLObj.usrCarrerSkill = Convert.ToString(txtCarrerSkill.Text);
            urUserRegBLLObj.usrCarrerInterest = Convert.ToString(txtCarrerInterest.Text);


            j = urUserRegBLLObj.BLLUpdateUserRegistrationProfessional(urUserRegBLLObj);
            if (j > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Professional Information Updated')", true);

                Response.Redirect("UserInfo.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Professional Information Not Updated')", true);

            }


        }
        catch (Exception ex)
        {
            //throw ex;
            lblErrProfessional.Visible = true;
            lblErrProfessional.Text = "Cant update the record";
            mdlProfessional.Show();
        }
    }

    protected void btnUpdateProfessional_Click(object sender, EventArgs e)
    {
        updateProfessionalInfo();

    }
    protected void txtBoardUniversity_TextChanged(object sender, EventArgs e)
    {
        string[] id;
        try
        {
            string str = txtBoardUniversity.Text.ToString();
            if (str.Contains(':'))
            {
                id = str.Split(':');

                txtBoardUniversity.Text = id[1];
                ViewState["BoardUniversityId"] = id[0];
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        mdlProfessional.Show();

    }

    protected void txtprofession_TextChanged(object sender, EventArgs e)
    {
        string[] id;
        try
        {
            string str = txtprofession.Text.ToString();
            if (str.Contains(':'))
            {
                id = str.Split(':');

                txtprofession.Text = id[1];
                ViewState["ProfessionId"] = id[0];
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        mdlProfessional.Show();

    }
    #endregion

    #region Update Social

    private void ShowSocialInfo()
    {
        try
        {
            if (ds.Tables[2].Rows.Count > 0)
            {
                gvSocialInfo.DataSource = ds.Tables[2];
                gvSocialInfo.DataBind();

                try
                {

                    DataTable dtUserList = ds.Tables[2];
                    DataRow dRowUserList = dtUserList.Rows[0];

                    txtIdealMatch.Text = Convert.ToString(dRowUserList["usrIdealMatch"]);
                    txtBestFeature.Text = Convert.ToString(dRowUserList["usrBestFeature"]);
                    txtHeight.Text = Convert.ToString(dRowUserList["usrHeight"]);
                    txtBuild.Text = Convert.ToString(dRowUserList["usrBuild"]);
                    txtPoliticalView.Text = Convert.ToString(dRowUserList["usrPoliticalView"]);
                    txtBooks.Text = Convert.ToString(dRowUserList["usrBooks"]);
                    txtMusic.Text = Convert.ToString(dRowUserList["usrMusic"]);
                    txtMembershipSocial.Text = Convert.ToString(dRowUserList["usrMebSocial"]);
                    txtMembershipPolitical.Text = Convert.ToString(dRowUserList["usrMebPolitical"]);

                }
                catch (Exception ex)
                {
                    // throw ex;
                }

            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    private void UpdateSocialInfo()
    {
        try
        {
            int j = 0;
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            urUserRegBLLObj.usrIdealMatch = Convert.ToString(txtIdealMatch.Text);
            urUserRegBLLObj.usrBestFeature = Convert.ToString(txtBestFeature.Text);
            urUserRegBLLObj.usrHeight = Convert.ToString(txtHeight.Text);
            urUserRegBLLObj.usrBuild = Convert.ToString(txtBuild.Text);
            urUserRegBLLObj.usrPoliticalView = Convert.ToString(txtPoliticalView.Text);
            urUserRegBLLObj.usrBooks = Convert.ToString(txtBooks.Text);
            urUserRegBLLObj.usrMusic = Convert.ToString(txtMusic.Text);
            urUserRegBLLObj.Usrreligion = Convert.ToInt32(ddlreligion.SelectedItem.Value);
            urUserRegBLLObj.Usrcastecategory = Convert.ToInt32(ddlreligion.SelectedItem.Value);
            urUserRegBLLObj.Caste = Convert.ToString(txtCaste.Text);
            if (ViewState["MemberPoliticalId"] != null)
            {
                urUserRegBLLObj.usrMemebrshipPolitical = Convert.ToInt32(Convert.ToString(ViewState["MemberPoliticalId"]));
            }
            else
            {
                int id;
                urUserRegBLLObj.usrMembershipPoliticalText = txtMembershipPolitical.Text;
                urUserRegBLLObj.BLLUserMembershipPoliticalInsert(urUserRegBLLObj, out id, out status);
                if (status == 0)
                {
                    urUserRegBLLObj.usrMemebrshipPolitical = id;
                }
                else
                {
                    urUserRegBLLObj.usrMemebrshipPolitical = id;
                }
            }

            if (ViewState["MemberSocialId"] != null)
            {
                urUserRegBLLObj.usrMembershipSocial = Convert.ToInt32(Convert.ToString(ViewState["MemberSocialId"]));
            }
            else
            {
                int id;
                urUserRegBLLObj.usrMembershipSocialText = txtMembershipSocial.Text;
                urUserRegBLLObj.BLLUserMembershipSocialInsert(urUserRegBLLObj, out id, out status);
                if (status == 0)
                {
                    urUserRegBLLObj.usrMembershipSocial = id;
                }
                else
                {
                    urUserRegBLLObj.usrMembershipSocial = id;
                }
            }

            j = urUserRegBLLObj.BLLUpdateUserRegistrationSocial(urUserRegBLLObj);
            if (j > 0)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated')", true);
                //System.Windows.Forms.MessageBox.Show("social Information Updated", ":: Come2MyCity ::");
                //Response.Write("<script>alert('Updated.')</script>");
                //Response.Redirect("UserInfo.aspx");
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not Updated')", true);
                //  System.Windows.Forms.MessageBox.Show("social Information Not Updated", ":: Come2MyCity ::");
                Response.Write("<script>alert('Not Updated.')</script>");
            }


        }
        catch (Exception ex)
        {
            //throw ex;
            lblErrSocial.Visible = true;
            lblErrSocial.Text = "Cant update the record";
            mdlSocial.Show();
        }
        Response.Redirect("UserInfo.aspx");
    }


    protected void btnUpdateSocial_Click(object sender, EventArgs e)
    {
        UpdateSocialInfo();
        // ShowSocialInfo();
    }

    protected void txtMembershipSocial_TextChanged(object sender, EventArgs e)
    {
        string[] id;
        string str = txtMembershipSocial.Text;

        if (str.Contains(':'))
        {
            id = str.Split(':');
            txtMembershipSocial.Text = id[1];
            ViewState["MemberSocialId"] = id[0];
        }
        mdlSocial.Show();
    }

    protected void txtMembershipPolitical_TextChanged(object sender, EventArgs e)
    {
        string[] id;
        string str = txtMembershipPolitical.Text;
        if (str.Contains(':'))
        {
            id = str.Split(':');
            txtMembershipPolitical.Text = id[1];
            ViewState["MemberPoliticalId"] = id[0];
        }
        mdlSocial.Show();
    }

    #endregion
    #region changephoto
    private void ProfilePhotoUpdate()
    {
        try
        {
            //string strImageName = txtName.Text.ToString();

            string sql = "select usrAutoId from usermaster where usrUserid='" + Session["User"].ToString() + "' ";
            string usrAutoId = cc.ExecuteScalar(sql);

            if (photoUpload.PostedFile != null &&

                photoUpload.PostedFile.FileName != "")
            {

                byte[] imageSize = new byte

                              [photoUpload.PostedFile.ContentLength];

                HttpPostedFile uploadedImage = photoUpload.PostedFile;

                uploadedImage.InputStream.Read

                   (imageSize, 0, (int)photoUpload.PostedFile.ContentLength);


                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                int fileSize = photoUpload.PostedFile.ContentLength;
                if (fileSize < 560000)
                {
                    // string Filename = photoUpload.FileName;

                    SqlCommand cmd = new SqlCommand();

                    sql = "select id from storeimage where usrAutoId=" + usrAutoId;
                    string id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        cmd.CommandText = "insert into [Come2myCityDB].[come2mycity].storeimage(image,usrAutoId)values(@image,'" + usrAutoId + "') ";

                        cmd.CommandType = CommandType.Text;

                        cmd.Connection = con;

                    }
                    else
                    {
                        cmd.CommandText = "update [Come2myCityDB].[come2mycity].storeimage set image=@image where usrAutoId=" + usrAutoId;

                        cmd.CommandType = CommandType.Text;

                        cmd.Connection = con;
                    }

                    SqlParameter UploadedImage = new SqlParameter

                                  ("@image", SqlDbType.Image, imageSize.Length);

                    UploadedImage.Value = imageSize;

                    cmd.Parameters.Add(UploadedImage);

                    con.Open();

                    int result = cmd.ExecuteNonQuery();

                    con.Close();

                    if (result > 0)

                        Response.Write("<script>(alert)('FileUploaded Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>(alert)('Photo cannot upload, Plz save photo less than 500KB')</script>");
                }
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ProfilePhotoUpdate();
        Response.Redirect("UserInfo.aspx");
    }
    #endregion

    #region MemberOf
    private void LoadMemberOf()
    {
        DataSet mem = new DataSet();
        string Sql = " Select GroupValueId, GroupValueName  from GroupValue where GroupItemId=1 ";
        Sql = Sql + " Select GroupValueId , GroupValueName  from GroupValue where GroupItemId=2 ";
        Sql = Sql + " Select GroupValueId , GroupValueName  from GroupValue where GroupItemId=3 ";
        Sql = Sql + " Select GroupValueId , GroupValueName  from GroupValue where GroupItemId=4 ";
        Sql = Sql + " Select GroupValueId , GroupValueName  from GroupValue where GroupItemId=5 ";
        Sql = Sql + " Select GroupValueId , GroupValueName  from GroupValue where GroupItemId=6";
        Sql = Sql + " Select GroupValueId , GroupValueName  from GroupValue where GroupItemId=7 ";

        mem = cc.ExecuteDataset(Sql);

        LoadAllSocialGroup(mem);


        Sql = " SELECT distinct GroupValue.GroupValueId as Id, GroupValue.GroupValueName as Name " +
            " FROM    GroupValue INNER JOIN  UserGroup ON GroupValue.GroupValueId = UserGroup.GroupId " +
            " Where UserGroup.UserId='" + Session["User"] + "' and GroupValue.GroupItemId=1 ";
        Sql = Sql + " SELECT distinct GroupValue.GroupValueId as Id, GroupValue.GroupValueName as Name " +
            " FROM    GroupValue INNER JOIN  UserGroup ON GroupValue.GroupValueId = UserGroup.GroupId " +
            " Where UserGroup.UserId='" + Session["User"] + "' and GroupValue.GroupItemId=2 ";
        Sql = Sql + " SELECT distinct GroupValue.GroupValueId as Id, GroupValue.GroupValueName as Name " +
            " FROM    GroupValue INNER JOIN  UserGroup ON GroupValue.GroupValueId = UserGroup.GroupId " +
            " Where UserGroup.UserId='" + Session["User"] + "' and GroupValue.GroupItemId=3 ";
        Sql = Sql + " SELECT distinct GroupValue.GroupValueId as Id, GroupValue.GroupValueName as Name " +
            " FROM    GroupValue INNER JOIN  UserGroup ON GroupValue.GroupValueId = UserGroup.GroupId " +
            " Where UserGroup.UserId='" + Session["User"] + "' and GroupValue.GroupItemId=4 ";
        Sql = Sql + " SELECT distinct GroupValue.GroupValueId as Id, GroupValue.GroupValueName as Name " +
            " FROM    GroupValue INNER JOIN  UserGroup ON GroupValue.GroupValueId = UserGroup.GroupId " +
            " Where UserGroup.UserId='" + Session["User"] + "' and GroupValue.GroupItemId=5 ";
        Sql = Sql + " SELECT distinct GroupValue.GroupValueId as Id, GroupValue.GroupValueName as Name " +
            " FROM    GroupValue INNER JOIN  UserGroup ON GroupValue.GroupValueId = UserGroup.GroupId " +
            " Where UserGroup.UserId='" + Session["User"] + "' and GroupValue.GroupItemId=6 ";
        Sql = Sql + " SELECT distinct GroupValue.GroupValueId as Id, GroupValue.GroupValueName as Name " +
            " FROM    GroupValue INNER JOIN  UserGroup ON GroupValue.GroupValueId = UserGroup.GroupId " +
            " Where UserGroup.UserId='" + Session["User"] + "' and GroupValue.GroupItemId=7 ";
        Sql = Sql + " SELECT     ConsumerNo FROM         UserConsumer" +
            " Where UserId='" + Session["User"] + "' ";

        mem = cc.ExecuteDataset(Sql);
        LoadUserSocialGroup(mem);
    }
    private void LoadAllSocialGroup(DataSet mem)
    {
        lstSocial.Items.Clear();
        lstProfessional.Items.Clear();
        lstBussiness.Items.Clear();
        lstPolitical.Items.Clear();
        lstMemberOf.Items.Clear();
        lstNewsPaper.Items.Clear();
        lstChannel.Items.Clear();
        try
        {

            lstSocial.DataSource = mem.Tables[0];
            lstProfessional.DataSource = mem.Tables[1];
            lstBussiness.DataSource = mem.Tables[2];
            lstPolitical.DataSource = mem.Tables[3];
            lstMemberOf.DataSource = mem.Tables[4];
            lstNewsPaper.DataSource = mem.Tables[5];
            lstChannel.DataSource = mem.Tables[6];

            lstSocial.DataTextField = "GroupValueName";
            lstProfessional.DataTextField = "GroupValueName";
            lstBussiness.DataTextField = "GroupValueName";
            lstPolitical.DataTextField = "GroupValueName";
            lstMemberOf.DataTextField = "GroupValueName";
            lstNewsPaper.DataTextField = "GroupValueName";
            lstChannel.DataTextField = "GroupValueName";

            lstSocial.DataValueField = "GroupValueId";
            lstProfessional.DataValueField = "GroupValueId";
            lstBussiness.DataValueField = "GroupValueId";
            lstPolitical.DataValueField = "GroupValueId";
            lstMemberOf.DataValueField = "GroupValueId";
            lstNewsPaper.DataValueField = "GroupValueId";
            lstChannel.DataValueField = "GroupValueId";

            lstSocial.DataBind();
            lstProfessional.DataBind();
            lstBussiness.DataBind();
            lstPolitical.DataBind();
            lstMemberOf.DataBind();
            lstNewsPaper.DataBind();
            lstChannel.DataBind();
        }
        catch (Exception ex)
        { }
    }

    private void LoadUserSocialGroup(DataSet mem)
    {
        string Data = "";
        string Id = "";

        foreach (DataRow dr in mem.Tables[0].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["Name"]);
            Id = Convert.ToString(dr["Id"]);
            for (int i = 0; i < lstSocial.Items.Count; i++)
            {
                if (lstSocial.Items[i].Value == Id)
                {
                    lstSocial.Items[i].Selected = true;
                }
            }
        }
        if (Data.Length > 1)
        {
            lblSocial.Text = Data.Substring(1);
        }
        Data = "";
        foreach (DataRow dr in mem.Tables[1].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["Name"]);
            Id = Convert.ToString(dr["Id"]);
            for (int i = 0; i < lstProfessional.Items.Count; i++)
            {
                if (lstProfessional.Items[i].Value == Id)
                {
                    lstProfessional.Items[i].Selected = true;
                }
            }
        }
        if (Data.Length > 1)
        {
            lblProfessional.Text = Data.Substring(1);
        }
        Data = "";
        foreach (DataRow dr in mem.Tables[2].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["Name"]);
            Id = Convert.ToString(dr["Id"]);
            for (int i = 0; i < lstBussiness.Items.Count; i++)
            {
                if (lstBussiness.Items[i].Value == Id)
                {
                    lstBussiness.Items[i].Selected = true;
                }
            }
        }
        if (Data.Length > 1)
        {
            lblBussiness.Text = Data.Substring(1);
        }
        Data = "";
        foreach (DataRow dr in mem.Tables[3].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["Name"]);
            Id = Convert.ToString(dr["Id"]);
            for (int i = 0; i < lstPolitical.Items.Count; i++)
            {
                if (lstPolitical.Items[i].Value == Id)
                {
                    lstPolitical.Items[i].Selected = true;
                }
            }
        }
        if (Data.Length > 1)
        {
            lblPolitical.Text = Data.Substring(1);
        }
        Data = "";
        foreach (DataRow dr in mem.Tables[4].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["Name"]);
            Id = Convert.ToString(dr["Id"]);
            for (int i = 0; i < lstMemberOf.Items.Count; i++)
            {
                if (lstMemberOf.Items[i].Value == Id)
                {
                    lstMemberOf.Items[i].Selected = true;
                }
            }
        }
        if (Data.Length > 1)
        {
            lblMemberOf.Text = Data.Substring(1);
        }




        Data = "";
        foreach (DataRow dr in mem.Tables[5].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["Name"]);
            Id = Convert.ToString(dr["Id"]);
            for (int i = 0; i < lstMemberOf.Items.Count; i++)
            {
                if (lstNewsPaper.Items[i].Value == Id)
                {
                    lstNewsPaper.Items[i].Selected = true;
                }
            }
        }
        if (Data.Length > 1)
        {
            lblFNPaper.Text = Data.Substring(1);
        }

        Data = "";
        foreach (DataRow dr in mem.Tables[6].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["Name"]);
            Id = Convert.ToString(dr["Id"]);
            for (int i = 0; i < lstMemberOf.Items.Count; i++)
            {
                if (lstChannel.Items[i].Value == Id)
                {
                    lstChannel.Items[i].Selected = true;
                }
            }
        }
        if (Data.Length > 1)
        {

            lblFNChaneel.Text = Data.Substring(1);
        }


        Data = "";
        foreach (DataRow dr in mem.Tables[7].Rows)
        {
            Data = Data + ", " + Convert.ToString(dr["ConsumerNo"]);
            lstConsumerNo.Items.Add(Convert.ToString(dr["ConsumerNo"]));
        }
        if (Data.Length > 1)
        {
            lblConsumerNo.Text = Data.Substring(1);
        }

    }

    protected void btnSocialGroup_Click(object sender, EventArgs e)
    {
        string Sql = " Delete from userGroup where UserId='" + Session["User"] + "' and GroupId in " +
            "( Select GroupValueId from GroupValue where GroupItemId=1) ";
        foreach (ListItem lst in lstSocial.Items)
        {
            if (lst.Selected)
            {
                string id = lst.Value.ToString();
                Sql = Sql + " Insert into UserGroup (UserId,GroupId) Values ('" + Session["User"] + "'," + id + " )";
            }
        }

        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");
    }
    protected void btnProfessionalGroup_Click(object sender, EventArgs e)
    {
        string Sql = " Delete from userGroup where UserId='" + Session["User"] + "' and GroupId in " +
            "( Select GroupValueId from GroupValue where GroupItemId=2) ";
        foreach (ListItem lst in lstProfessional.Items)
        {
            if (lst.Selected)
            {
                string id = lst.Value.ToString();
                Sql = Sql + " Insert into UserGroup (UserId,GroupId) Values ('" + Session["User"] + "'," + id + " )";
            }
        }

        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");
    }
    protected void btnBussinessGroup_Click(object sender, EventArgs e)
    {
        string Sql = " Delete from userGroup where UserId='" + Session["User"] + "' and GroupId in " +
            "( Select GroupValueId from GroupValue where GroupItemId=3) ";
        foreach (ListItem lst in lstBussiness.Items)
        {
            if (lst.Selected)
            {
                string id = lst.Value.ToString();
                Sql = Sql + " Insert into UserGroup (UserId,GroupId) Values ('" + Session["User"] + "'," + id + " )";
            }
        }

        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");
    }
    protected void btnPoliticalGroup_Click(object sender, EventArgs e)
    {
        string Sql = " Delete from userGroup where UserId='" + Session["User"] + "' and GroupId in " +
            "( Select GroupValueId from GroupValue where GroupItemId=4) ";
        foreach (ListItem lst in lstPolitical.Items)
        {
            if (lst.Selected)
            {
                string id = lst.Value.ToString();
                Sql = Sql + " Insert into UserGroup (UserId,GroupId) Values ('" + Session["User"] + "'," + id + " )";
            }
        }

        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");
    }
    protected void btnMemberOf_Click(object sender, EventArgs e)
    {
        //For MemberOf
        string Sql = " Delete from userGroup where UserId='" + Session["User"] + "' and GroupId in " +
            "( Select GroupValueId from GroupValue where GroupItemId=5) ";
        foreach (ListItem lst in lstMemberOf.Items)
        {
            if (lst.Selected)
            {
                string id = lst.Value.ToString();
                Sql = Sql + " Insert into UserGroup (UserId,GroupId) Values ('" + Session["User"] + "'," + id + " )";
            }
        }

        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");
    }

    protected void btnPnlNWSUpdate_Click(object sender, EventArgs e)
    {
        //For NewsPaper
        string Sql = " Delete from userGroup where UserId='" + Session["User"] + "' and GroupId in " +
            "( Select GroupValueId from GroupValue where GroupItemId=6) ";
        foreach (ListItem lst in lstNewsPaper.Items)
        {
            if (lst.Selected)
            {
                string id = lst.Value.ToString();
                Sql = Sql + " Insert into UserGroup (UserId,GroupId) Values ('" + Session["User"] + "'," + id + " )";
            }
        }

        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");

    }
    protected void btnChannelUpdate_Click(object sender, EventArgs e)
    {
        //For Channel
        string Sql = " Delete from userGroup where UserId='" + Session["User"] + "' and GroupId in " +
            "( Select GroupValueId from GroupValue where GroupItemId=7) ";
        foreach (ListItem lst in lstChannel.Items)
        {
            if (lst.Selected)
            {
                string id = lst.Value.ToString();
                Sql = Sql + " Insert into UserGroup (UserId,GroupId) Values ('" + Session["User"] + "'," + id + " )";
            }
        }

        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtConsumerNo.Text != "")
        {
            string Sql = "Select ConsumerNo from UserConsumer where ConsumerNo='" + txtConsumerNo.Text.ToString() + "'";
            string Data = cc.ExecuteScalar(Sql);
            if (Data != "")
            {
                lblConsumerError.Visible = true;
                lblConsumerError.Text = "This no is already exist";
            }
            else
            {
                Sql = " Select ConsumerNo from ConsumerMaster where ConsumerNo='" + txtConsumerNo.Text.ToString() + "' ";
                Data = cc.ExecuteScalar(Sql);
                if (Data == "")
                {
                    lblConsumerError.Visible = true;
                    lblConsumerError.Text = "This no is not a consumer no";
                }
                else
                {
                    int flag = 0;
                    for (int i = 0; i <= lstConsumerNo.Items.Count - 1; i++)
                    {
                        if (lstConsumerNo.Items[i].Value.ToString() == txtConsumerNo.Text.ToString())
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        lstConsumerNo.Items.Add(txtConsumerNo.Text.ToString());
                    }
                }


            }
            txtConsumerNo.Text = "";
        }
        mdlConsumer.Show();
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            int i = lstConsumerNo.SelectedIndex;
            lstConsumerNo.Items.RemoveAt(i);
        }
        catch { }
        mdlConsumer.Show();
    }
    protected void btnAddConsumerNo_Click(object sender, EventArgs e)
    {
        //For Consumer No
        string Sql = "Delete from UserConsumer where UserId='" + Session["User"] + "'";
        foreach (ListItem lst in lstConsumerNo.Items)
        {

            string id = lst.Value.ToString();
            Sql = Sql + " Insert into UserConsumer (UserId,ConsumerNo) Values ('" + Session["User"] + "','" + id + "' )";

        }
        try
        {
            cc.ExecuteNonQuery(Sql);
        }
        catch { }

        Response.Redirect("UserInfo.aspx");
    }

    #endregion


    protected void gvProfessionalInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkSocialGroup_Click(object sender, EventArgs e)
    {

    }
    protected void lnkChangePhoto_Click(object sender, EventArgs e)
    {

    }
    protected void lnkProfileSettings_Click(object sender, EventArgs e)
    {

    }
    protected void gvContactDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
