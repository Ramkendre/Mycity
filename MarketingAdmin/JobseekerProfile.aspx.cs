using System;
using System.Collections.Generic;
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
using System.IO;

public partial class MarketingAdmin_JobseekerProfile : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CTdll.PCommon pc = new CTdll.PCommon();
    CommonCode cc = new CommonCode();
    bool imageOk = false;
    DataSet ds = new DataSet();
    int status;
    public string name;
    public string dob;
    public string city;
    public string recentVisitor;
    public string[] rvisitor;
    public string recentVisitorName;
    string userid = "";
   // DataSet Location = new DataSet();
    String path = HttpContext.Current.Request.PhysicalApplicationPath + "User_Resource\\";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            state();
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string mobileNo = txtMobileNo.Text;
        urUserRegBLLObj.usrMobileNo = mobileNo;
        string sql="select usrUserId from usermaster where usrMobileNo='"+mobileNo+"'";
        userid = cc.ExecuteScalar(sql);
        Session["userid"] = userid;
        //string usrUserid = Session["userid"].ToString();
        status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
        if (status == 0)
        {
            UserInfo.Visible = true;
           // state();
            UserProfileHeaderInfo();
            ShowContact();
            ShowProfessionalInfo();
        }
        else
        {
            Response.Write("<script>(alert)('This number is not registered to www.myct.in')</script>");
        }

        

    }


    public void state()
    {
        try
            {
               
                Location loc = new Location();
                ds = loc.getAllLocation();
                Session["Location"] = ds;
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
                    cmbCity.Items.Add("--Select--");
                    cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";

                    cmbState.SelectedIndex = cmbState.Items.Count - 1;


                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

    
    public List<UserRegistrationBLL> UserProfileHeaderInfo()
    {
        List<UserRegistrationBLL> upHeadList = new List<UserRegistrationBLL>();
        try
        {


            urUserRegBLLObj.usrUserId = userid;
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
            urUserRegBLLObj.usrUserId = Session["userid"].ToString();
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
               // Response.Redirect("UserInfo.aspx");
               // Response.Redirect("../MarketingAdmin/JobSeekerProfile.aspx");
             
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
    //#endregion

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
            urUserRegBLLObj.usrUserId = Session["userid"].ToString();

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
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Professional Information Updated')", true);
                Response.Write("<script>(alert)('Professional Information Updated')</script>");

                Response.Redirect("../MarketingAdmin/JobseekerProfile.aspx");

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

    protected void gvProfessionalInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkProfileSettings_Click(object sender, EventArgs e)
    {

    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ProfilePhotoUpdate();
        Response.Redirect("JobseekerProfile.aspx");

    }
    private void ProfilePhotoUpdate()
    {
        try
        {
            if (photoUpload.HasFile)
            {
                urUserRegBLLObj.usrProfilePhoto = photoUpload.FileName;
                imageOk = cc.CheckImageExtension(urUserRegBLLObj.usrProfilePhoto);
            }

            if (imageOk == true)
            {
                string thisDir = Server.MapPath("~");

                //if (File.Exists(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\"+*+".jpg"))
                //{
                //    File.Delete(thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo\\");
                //}
                urUserRegBLLObj.usrUserId = Convert.ToString(Session["userid"]);
                string ePath = thisDir + "\\User_Resource\\" + urUserRegBLLObj.usrUserId + "\\Profile_Photo";
                string[] filename = Directory.GetFiles(ePath, "*");



                foreach (string str in filename)
                {
                    File.Delete(str);
                }




                string currentUserId = Convert.ToString(Session["userid"]);
                photoUpload.PostedFile.SaveAs(path + currentUserId + "\\Profile_Photo\\" + urUserRegBLLObj.usrProfilePhoto);

                urUserRegBLLObj.usrUserId = currentUserId;

                int j = urUserRegBLLObj.BLLUserProfilePhotoUpdate(urUserRegBLLObj);
                if (j > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo Uploaded')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo Not Uploaded')", true);
                }

            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
}
