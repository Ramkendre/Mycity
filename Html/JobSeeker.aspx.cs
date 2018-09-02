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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data.SqlClient;



public partial class html_JobSeeker : System.Web.UI.Page
{
    JobSeekerdetailsBLL objBLLJobSeeker = new JobSeekerdetailsBLL();
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();
    DataTable dt = new DataTable();
 
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    int status;
    protected void Page_Load(object sender, EventArgs e)
    {
        MyLabel.Text = System.DateTime.Now.ToString();
         string UserIdSession = Convert.ToString(Session["User"]);
         if (UserIdSession == "")
         {
             Response.Redirect("../default.aspx");
         }
         else
         {
             if (!IsPostBack)
             {
                 detailsload();
                 GetResumeDetails();
                 //Bind_JobCategory();
                 Bind_Qualification();
                 validation();
                 LoadGridjobSeeker();
                 viewAppliedCandidate();
                 Bind_CompanyName();
                 Bind_Location();
                 Bind_Experience();
                 Bind_Salary();
                 fillLocation();
             }
            
         }
    }
    //---------ViewAppliedJobs-------------------------------------------------

    #region ViewApplied
    public void viewAppliedCandidate()
    {
        string userid = Session["User"].ToString();
        objBLLJobSeeker.Userid = userid;
        DataSet ds = objBLLJobSeeker.BLLViewAppliedJobs(objBLLJobSeeker);
        gvUserAppliedJob.DataSource = ds.Tables[0];
        gvUserAppliedJob.DataBind();

    }
    #endregion
    //protected void btnRefresh_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect();
    //}

    public void fillLocation()
    {
       
        DataSet ds = new DataSet();
        con.Open();
        SqlCommand cmd = new SqlCommand("Select [cityId],[cityName] FROM [Come2myCityDB].[come2mycity].[Citymaster_copy] order by [cityName] asc ", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        ddlLocaton.DataSource = ds.Tables[0];
        ddlLocaton.DataValueField = "cityId";
        ddlLocaton.DataTextField = "cityName";
        ddlLocaton.DataBind();
        ddlLocaton.Items.Add("---Select----");
        ddlLocaton.SelectedIndex = ddlLocaton.Items.Count - 1;
        ddlLocaton.Items[ddlLocaton.Items.Count - 1].Value = "";


    }
    public void Bind_Location()
    {
        DataSet ds = objBLLJobSeeker.BLLViewLocation(objBLLJobSeeker);
      
        ddlLocaton.DataSource = ds.Tables[0];
        ddlLocaton.DataTextField = "cityName";
        ddlLocaton.DataValueField = "city";
        ddlLocaton.DataBind();
        ddlLocaton.Items.Add("--Select--");
        ddlLocaton.SelectedIndex = ddlLocaton.Items.Count - 1;
    }
    public void Bind_Salary()
    {
        DataSet ds = objBLLJobSeeker.BLLViewSalary(objBLLJobSeeker);
        ddlExpectedSalary.DataSource = ds.Tables[0];
        ddlExpectedSalary.DataTextField = "salary";
        ddlExpectedSalary.DataValueField = "id";
        ddlExpectedSalary.DataBind();
        ddlExpectedSalary.Items.Add("--Select--");
        ddlExpectedSalary.SelectedIndex = ddlExpectedSalary.Items.Count - 1;

    }

    public void Bind_Experience()
    {
        DataSet ds = objBLLJobSeeker.BLLViewExperience(objBLLJobSeeker);
        ddlexperience.DataSource = ds.Tables[0];
        ddlexperience.DataTextField = "req_exp";
        ddlexperience.DataValueField = "id";
        ddlexperience.DataBind();
        ddlexperience.Items.Add("--Select--");
        ddlexperience.SelectedIndex = ddlexperience.Items.Count - 1;

    }

    public void Bind_CompanyName()
    {
        //DataSet ds = objBLLJobSeeker.BLLGetCompanyname(objBLLJobSeeker);
        //ddlCompanyName.DataSource = ds.Tables[0];
        //ddlCompanyName.DataValueField = "id";
        //ddlCompanyName.DataTextField = "companyname";
        //ddlCompanyName.DataBind();
        //ddlCompanyName.Items.Add("--Select--");
        //ddlCompanyName.SelectedIndex = ddlCompanyName.Items.Count - 1;
        string s = "select CID,NameOfComp from [Come2myCityDB].[come2mycity].[tbl_JCompReg]";
        DataSet ds = new DataSet();
        
        SqlDataAdapter da = new SqlDataAdapter(s,con);
        da.Fill(ds);
        ddlCompanyName.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ddlCompanyName.DataValueField = "CID";
            ddlCompanyName.DataTextField = "NameOfComp";
        }
        ddlCompanyName.DataBind();
        ddlCompanyName.Items.Add("--Select--");

        ddlCompanyName.Items.Insert(0, new ListItem("Select", "0"));
        ddlCompanyName.SelectedIndex = 0;

    }

    //-----------Post Job---------------------------------------------------------

    #region PostRequirement
    public void LoadGridjobSeeker()
    {
        DataSet ds = objBLLJobSeeker.LoadGrid(objBLLJobSeeker);
        gvLatestJobs.DataSource = ds;
        gvLatestJobs.DataBind();

    }
    #endregion

    private void Bind_Qualification()
    {
        string sql = "select qualificationId,qualificationName from UserQualification";
        DataSet ds = cc.ExecuteDataset(sql);

        //SqlDataAdapter da = new SqlDataAdapter(str, con);
        //da.Fill(ds);
        DDDLQualification.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ddl.DataTextField = "Name";
            DDDLQualification.DataValueField = "qualificationId";
            DDDLQualification.DataTextField = "qualificationName";

        }
        DDDLQualification.DataBind();
        DDDLQualification.Items.Add("Add New");
        DDDLQualification.Items.Add("---Select---");
        DDDLQualification.SelectedIndex = DDDLQualification.Items.Count - 1;
        DDDLQualification.Items[DDDLQualification.Items.Count - 1].Value = "";


        //DDDLQualification.DataSource = ds.Tables[0];
        //DDDLQualification.DataTextField = "qualificationName";
        //DDDLQualification.DataValueField = "qualificationId";
        //DDDLQualification.DataBind();
        //DDDLQualification.Items.Add("--Select--");
        //DDDLQualification.SelectedIndex = DDDLQualification.Items.Count - 1;
        string sql2 = "select brduniId,brduniName from UserBoardUniversity";
        DataSet dset = cc.ExecuteDataset(sql2);
        ddlUniversity.DataSource = dset.Tables[0];
        ddlUniversity.DataTextField = "brduniName";
        ddlUniversity.DataValueField = "brduniId";
        ddlUniversity.DataBind();
        ddlUniversity.Items.Add("--Select--");
        ddlUniversity.SelectedIndex = ddlUniversity.Items.Count - 1;
    }

    //private void Bind_JobCategory()
    //{
    //    string sql = "select Functions,FunctionId from Functions";
    //    DataSet ds = cc.ExecuteDataset(sql);
    //    ddlFunctionalArea.DataSource = ds.Tables[0];
    //    ddlFunctionalArea.DataTextField = "Functions";
    //    ddlFunctionalArea.DataValueField = "FunctionId";
       
    //    ddlFunctionalArea.DataBind();
    //    ddlFunctionalArea.Items.Add("--Select--");
    //    ddlFunctionalArea.SelectedIndex = ddlFunctionalArea.Items.Count - 1;
    //     //ddlFunctionalArea.Items[ddlFunctionalArea.Items.Count - 1].Value = "";


    //    string sql1 = "select industryId,industryName from UserIndustry";
    //    DataSet ds1 = cc.ExecuteDataset(sql1);
    //    ddlJobType.DataSource = ds1.Tables[0];
    //    ddlJobType.DataTextField = "industryName";
    //    ddlJobType.DataValueField = "industryId";
    //    ddlJobType.DataBind();
    //    ddlJobType.Items.Add("--Select--");
    //    ddlJobType.SelectedIndex = ddlJobType.Items.Count - 1;
    //    //ddlJobType.Items[ddlJobType.Items.Count-1].Value = "";
    //}

    #region GetResume
    public void GetResumeDetails()
    {
        try
        {
            string userid = Session["User"].ToString();
            SchoolDetails();
            Details12th();
            Graduate();
            PG();
            WorkExp();
            string sql = "select * from [Come2myCityDB].[come2mycity].[tbl_JSkill] where userid='" + userid + "'";
            DataSet ds3 = cc.ExecuteDataset(sql);
            gvKeySkill.DataSource = ds3.Tables[0];
            gvKeySkill.DataBind();
            string str8 = "select * from [Come2myCityDB].[come2mycity].[tbl_JProfile] where userid='" + userid + "'";
            DataSet ds = cc.ExecuteDataset(str8);
            gvResumeDetails.DataSource = ds.Tables[0];
            gvResumeDetails.DataBind();
            //gvJobCategory.DataSource = ds.Tables[0];
            //gvJobCategory.DataBind();
           
            //gvLocation.DataSource = ds.Tables[0];
            //gvLocation.DataBind();
            //string str = "select * from [Come2myCityDB].[come2mycity].[tbl_JEducation] where userid='" + userid + "' and Keyword='School'";
            //DataSet ds1 = cc.ExecuteDataset(str);
            //gvEducation.DataSource = ds1.Tables[0]; 
            //gvEducation.DataBind();
            
            
            
            txtKeySkill.Text = Convert.ToString(ds3.Tables[0].Rows[0]["Skill"]);
            txtresumetitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["RTitle"]);
           
            txtannualsalary.Text = Convert.ToString(ds.Tables[0].Rows[0]["annual_salary"]);
            //DDDLQualification.SelectedItem.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Qualification"]);
            string area = Convert.ToString(ds.Tables[0].Rows[0]["industry_type"]);
            //DDDLQualification.SelectedValue = Convert.ToString(ds1.Tables[0].Rows[0]["Qualification"]);

          






        }
        catch (Exception ex)
        { }

    }
    #endregion

    #region ProfileDetails
    public void SchoolDetails()
    {
        string userid = Session["User"].ToString();
        string str = "select * from [Come2myCityDB].[come2mycity].[tbl_JEducation] where userId='" + userid + "' and Keyword='School'";
        DataSet ds1 = cc.ExecuteDataset(str);
        gvEducation.DataSource = ds1.Tables[0];
        gvEducation.DataBind();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            txtMarks.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Marks"]);
            txtYrPassout.Text = Convert.ToString(ds1.Tables[0].Rows[0]["YearPassout"]);
            txtSpecialization.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Specialization"]);
            txtCollegeName.Text = Convert.ToString(ds1.Tables[0].Rows[0]["CollegeName"]);
            //DDDLQualification.SelectedItem.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Qualification"]);
            //DDDLQualification.SelectedIndex = 5;
        }

    }
    public void Details12th()
    {
        string userid = Session["User"].ToString();
        string a2 = "select * from [Come2myCityDB].[come2mycity].[tbl_JEducation] where userid='" + userid + "' and Keyword='12th'";
        DataSet ds2 = cc.ExecuteDataset(a2);
        gvEducation12th.DataSource = ds2.Tables[0];
        gvEducation12th.DataBind();
        if (ds2.Tables[0].Rows.Count > 0)
        {
            txtMarks1.Text = Convert.ToString(ds2.Tables[0].Rows[0]["Marks"]);
            txtYrPassout1.Text = Convert.ToString(ds2.Tables[0].Rows[0]["YearPassout"]);
            txtSpecialization1.Text = Convert.ToString(ds2.Tables[0].Rows[0]["Specialization"]);
            txtCollegeName1.Text = Convert.ToString(ds2.Tables[0].Rows[0]["CollegeName"]);
        }
    }
    public void Graduate()
    {
        string userid = Session["User"].ToString();
        string b2 = "select * from [Come2myCityDB].[come2mycity].[tbl_JEducation] where userid='" + userid + "' and Keyword='Graduate'";
        DataSet ds11 = cc.ExecuteDataset(b2);
        gvEducationGrad.DataSource = ds11.Tables[0];
        gvEducationGrad.DataBind();
        if (ds11.Tables[0].Rows.Count > 0)
        {
            txtMarksG.Text = Convert.ToString(ds11.Tables[0].Rows[0]["Marks"]);
            txtYrPassoutG.Text = Convert.ToString(ds11.Tables[0].Rows[0]["YearPassout"]);
            txtSpecializationG.Text = Convert.ToString(ds11.Tables[0].Rows[0]["Specialization"]);
            txtCollegeNameG.Text = Convert.ToString(ds11.Tables[0].Rows[0]["CollegeName"]);
        }
    }
    public void PG()
    {
        string userid = Session["User"].ToString();
        string st2 = "select * from [Come2myCityDB].[come2mycity].[tbl_JEducation] where userid='" + userid + "' and Keyword='PG'";
        DataSet ds4 = cc.ExecuteDataset(st2);
        gvEducationPGrad.DataSource = ds4.Tables[0];
        gvEducationPGrad.DataBind();
        if (ds4.Tables[0].Rows.Count > 0)
        {
            txtMarksPG.Text = Convert.ToString(ds4.Tables[0].Rows[0]["Marks"]);
            txtYrPassoutPG.Text = Convert.ToString(ds4.Tables[0].Rows[0]["YearPassout"]);
            txtSpecializationPG.Text = Convert.ToString(ds4.Tables[0].Rows[0]["Specialization"]);
            txtCollegeNamePG.Text = Convert.ToString(ds4.Tables[0].Rows[0]["CollegeName"]);
        }
    }
    public void WorkExp()
    { 
        string userid=Session["User"].ToString();
        string str1 = "select * from [Come2myCityDB].[come2mycity].[tbl_JWorkExp] where userid='" + userid + "'";
        DataSet ds10 = cc.ExecuteDataset(str1);
        gvWorkHistory.DataSource = ds10.Tables[0];
        gvWorkHistory.DataBind();
        txtFrmdate.Text = Convert.ToString(ds10.Tables[0].Rows[0]["FrmDate"]);
        txtTodate.Text = Convert.ToString(ds10.Tables[0].Rows[0]["ToDate"]);
        txtTExpYr.Text = Convert.ToString(ds10.Tables[0].Rows[0]["TotalExpYr"]);
        txtJobT.Text = Convert.ToString(ds10.Tables[0].Rows[0]["JTitle"]);
        txtCompName.Text = Convert.ToString(ds10.Tables[0].Rows[0]["CompName"]);
        txtannualsalary.Text = Convert.ToString(ds10.Tables[0].Rows[0]["Salary"]);
        txtFArea.Text = Convert.ToString(ds10.Tables[0].Rows[0]["FArea"]);
    }
    #endregion

    //------Contact Details----------------
    private void detailsload()//Contact Details
    {
        string mobileno = Convert.ToString(Session["Mobile"]);
        objBLLJobSeeker.UsrMobileNo = mobileno;
        lblMobileNo.Text = mobileno;
        DataSet ds = objBLLJobSeeker.BLLGetRecordbyno(objBLLJobSeeker);
        lblName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FullName"]);
        lblEmailId.Text = Convert.ToString(ds.Tables[0].Rows[0]["usrEmailid"]);


    }
    private void bindcandidatedetails()
    {

    }

    private void validation()
    {
        objBLLJobSeeker.Userid = Session["User"].ToString();
        status = objBLLJobSeeker.BLLGetstatus(objBLLJobSeeker);
        if (status == 1)
        {
            btnInsert.Visible = true;
            //btnInsert.Enabled = true;
            //btnUpdate.Visible = false;

        }
        else
        {
            btnUpdate.Visible = true;
            //btnUpdate.Enabled = true;
            //btnInsert.Visible = false;
        }

    }


    protected void btnInsert_click(object sender, EventArgs e)
    {
        string mobileno = Convert.ToString(Session["Mobile"]);
        string userid = Session["User"].ToString();
        objBLLJobSeeker.Userid = userid;
        objBLLJobSeeker.UsrMobileNo = mobileno;
        objBLLJobSeeker.KeySkill = txtKeySkill.Text;
        objBLLJobSeeker.Resume_title = txtresumetitle.Text;
        uploadResume();
        objBLLJobSeeker.Resume_name = Session["Resumefilename"].ToString();
        status = objBLLJobSeeker.BLLInitalInsertCandidate(objBLLJobSeeker);
        if (status == 1)
        {
            GetResumeDetails();
            Response.Write("<script>alert('Record Inserted Successfully')</script>");
        }
        else
        {
            GetResumeDetails();
            Response.Write("<script>alert('Record Not Inserted Successfully')</script>");
        }


    }

    #region UploadResume
    private void uploadResume()
    {
        string filename = "";

        string userid = Session["User"].ToString();
        //DateTime date = System.DateTime.Now;
        if (uploadresume.HasFile)
        {
            try
            {
                string path = "";

                filename = uploadresume.FileName;
                Session["Resumefilename"] = filename;
                if (userid != "")
                {


                    string thisDir = Server.MapPath("~/EmployeeResume/");



                    System.IO.Directory.CreateDirectory(thisDir + userid + "");


                    string newpa = "" + thisDir + userid + "";

                    string newpath = Server.MapPath("~/EmployeeResume/" + userid + "");

                    path = newpath + "\\" + uploadresume.FileName;


                    if (System.IO.Path.GetExtension(uploadresume.FileName).ToLower() != ".doc" && System.IO.Path.GetExtension(uploadresume.FileName).ToLower() != ".docx")
                    {
                        //lblError.Text = "The file must have an extension of .MP3,.FLV,.AVI,.XLS,.xlsx.PDF,.JPG,.JPEG,.png,.gif,.csv,.doc,.txt,.mp4,.wav";
                        return;
                    }

                    else
                    {

                        string ePath = newpa;
                        string[] filename1 = Directory.GetFiles(ePath, "*");




                        uploadresume.SaveAs(path);
                        string type = System.IO.Path.GetExtension(uploadresume.FileName);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
    }
#endregion

    #region UpdateResume

    private void UpdateResume()
    {
        string filename = "";

        string userid = Session["User"].ToString();
        //DateTime date = System.DateTime.Now;
        if (uploadresume.HasFile)
        {
            try
            {
                string path = "";

                filename = uploadresume.FileName;
                Session["Resumefilename"] = filename;
                if (userid != "")
                {


                    string thisDir = Server.MapPath("~/EmployeeResume/");



                    //System.IO.Directory.CreateDirectory(thisDir + userid + "");


                    string newpa = "" + thisDir + userid + "";
                    if (newpa != "")
                    {
                       // newpa = Server.MapPath("~/EmployeeResume/" + userid + "");
                        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/EmployeeResume/" + userid + ("/")));
                        foreach (FileInfo fi in di.GetFiles())
                        {
                            fi.Delete();
                        }
                       
                        //File.Delete(newpa);
                        System.IO.Directory.CreateDirectory(thisDir + userid + "");
                        string newpath = Server.MapPath("~/EmployeeResume/" + userid + "");

                        path = newpath + "\\" + uploadresume.FileName;


                        //if (System.IO.Path.GetExtension(uploadresume.FileName).ToLower() != ".doc" && System.IO.Path.GetExtension(uploadresume.FileName).ToLower() != ".docx")
                        //{
                        //    //lblError.Text = "The file must have an extension of .MP3,.FLV,.AVI,.XLS,.xlsx.PDF,.JPG,.JPEG,.png,.gif,.csv,.doc,.txt,.mp4,.wav";
                        //    //return;
                        //}

                        //else
                        //{

                            string ePath = newpa;
                            string[] filename1 = Directory.GetFiles(ePath, "*");




                            uploadresume.SaveAs(path);
                            string type = System.IO.Path.GetExtension(uploadresume.FileName);
                       // }

                    }
                    else
                    {
                        string thisDir1 = Server.MapPath("~/EmployeeResume/");



                        System.IO.Directory.CreateDirectory(thisDir1 + userid + "");


                        string newpa1 = "" + thisDir + userid + "";

                        string newpath = Server.MapPath("~/EmployeeResume/" + userid + "");

                        path = newpath + "\\" + uploadresume.FileName;


                        //if (System.IO.Path.GetExtension(uploadresume.FileName).ToLower() != ".doc" && System.IO.Path.GetExtension(uploadresume.FileName).ToLower() != ".docx")
                        //{
                        //    //lblError.Text = "The file must have an extension of .MP3,.FLV,.AVI,.XLS,.xlsx.PDF,.JPG,.JPEG,.png,.gif,.csv,.doc,.txt,.mp4,.wav";
                        //    //return;
                        //}

                        //else
                        //{

                            string ePath = newpa1;
                            string[] filename1 = Directory.GetFiles(ePath, "*");




                            uploadresume.SaveAs(path);
                            string type = System.IO.Path.GetExtension(uploadresume.FileName);
                      //  }

                    }

                    
                }
            }
            catch (Exception ex)
            { }
        }
    }
    #endregion

    //protected void btnUpdateJobCategory_click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string userid = Session["User"].ToString();
    //        objBLLJobSeeker.Userid = userid;
    //        objBLLJobSeeker.Industrytype = ddlFunctionalArea.SelectedItem.Text;
    //        objBLLJobSeeker.Jobtype = ddlJobType.SelectedItem.Text;
    //        objBLLJobSeeker.Designation = txtDesignation.Text;
    //        objBLLJobSeeker.Currentrole = txtCurremtRole.Text;
    //        status = objBLLJobSeeker.BLLUpdateJobCategory(objBLLJobSeeker);
    //        if (status == 1)
    //        {
    //            GetResumeDetails();
    //           // Response.Write("<script>alert('Record Updated Successfully')</script>");
    //        }
    //        else
    //        {
    //            GetResumeDetails();
    //            Response.Write("<script>alert('Record Not Updated')</script>");

    //        }




    //    }
    //    catch (Exception ex)
    //    { }
    //}



   
    protected void btnUpdateEducation_click(object sender, EventArgs e)
    {
        try
        {
            string str = "select * from [Come2myCityDB].[come2mycity].[tbl_JEducation] where Keyword='School'";
            ds = cc.ExecuteDataset(str);
            //DataSet ds = new DataSet();
            //gvEducation.DataSource = ds;
            //gvEducation.DataBind();

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            //DataRow dRowUserList = dtUserList.Rows[0];
            //objBLLJobSeeker.Marks1 = Convert.ToString(dr["Marks"]);
            objBLLJobSeeker.Marks1 = txtMarks.Text;
            objBLLJobSeeker.Specialization1 = txtSpecialization.Text;
            //txtMarks.Text = Convert.ToString(objBLLJobSeeker.Marks1);
            //txtSpecialization.Text = Convert.ToString(dr["Specialization"]);
            //txtInstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CollegeName"]);
            string userid = Session["User"].ToString();
            objBLLJobSeeker.Userid = userid;
            //objBLLJobSeeker.Specialization1 = Convert.ToString(txtSpecialization.Text);
            //objBLLJobSeeker.Marks1 = Convert.ToString(txtMarks.Text);
            objBLLJobSeeker.Qualification1 = DDDLQualification.SelectedItem.Text;
            objBLLJobSeeker.University1 = ddlUniversity.SelectedItem.Text;
            //objBLLJobSeeker.YearPassout1 = DDlPYear.SelectedItem.Text;
            //objBLLJobSeeker.Specialization1 = txtSpecialization.Text;
            objBLLJobSeeker.CollegeName1 = txtCollegeName.Text;
            //objBLLJobSeeker.Marks1 = txtMarks.Text;
            status = objBLLJobSeeker.BLLUpdateEducation(objBLLJobSeeker);
            if (status == 1)
            {
                GetResumeDetails();
            }
            else
            {
                GetResumeDetails();
                Response.Write("<script>alert('Record Not Updated')</script>");

            }


        }
        catch (Exception ex)
        {
        }
    }
    protected void btnUpdateEducation1_click(object sender, EventArgs e)
    {
    }

    //protected void btnUpdateLocation_click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string userid = Session["User"].ToString();
    //        objBLLJobSeeker.Userid = userid;
    //        objBLLJobSeeker.Preferredlocation = txtPreferredLocation.Text;
    //        objBLLJobSeeker.Currentlocation = txtCurrentLocation.Text;
    //        status = objBLLJobSeeker.BLLUpdateLocation(objBLLJobSeeker);
    //        if (status == 1)
    //        {
    //            GetResumeDetails();
    //        }
    //        else
    //        {
    //            GetResumeDetails();
    //            Response.Write("<script>alert('Record Not Updated')</script>");

    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    protected void btnUpdate_click(object sender, EventArgs e)
    {
        objBLLJobSeeker.Userid = Session["User"].ToString();
        objBLLJobSeeker.KeySkill = txtKeySkill.Text;
        objBLLJobSeeker.Resume_title = txtresumetitle.Text;
        UpdateResume();
        objBLLJobSeeker.Resume_name = Session["Resumefilename"].ToString();
        status = objBLLJobSeeker.BLLUpdateResume(objBLLJobSeeker);
        if (status == 1)
        {
            GetResumeDetails();
            Response.Write("<script>alert('Record Updated Successfully')</script>");
        }
        else
        {
            GetResumeDetails();
            Response.Write("<script>alert('Record Not Updated')</script>");
        }


    }

    protected void btnUpdateWorkHistory_click(object sender, EventArgs e)
    {
        try
        {
            string userid = Session["User"].ToString();
            objBLLJobSeeker.Userid = userid;
            objBLLJobSeeker.FrmDate1 = txtFrmdate.Text;
            objBLLJobSeeker.ToDate1 = txtTodate.Text;
            objBLLJobSeeker.ExperienceYr1 = txtTExpYr.Text;
            objBLLJobSeeker.JTitle1 = txtJobT.Text;
            objBLLJobSeeker.CompName1 = txtCompName.Text;
            objBLLJobSeeker.Salary1 = txtannualsalary.Text;
            objBLLJobSeeker.FArea1 = txtFArea.Text;
            objBLLJobSeeker.Annualsalary = txtannualsalary.Text;
            status = objBLLJobSeeker.BLLUpdateWorkHistory(objBLLJobSeeker);
            if (status == 1)
            {
                GetResumeDetails();
            }
            else
            {
                Response.Write("<script>alert('Record Not Updated')</script>");

            }
           


        }
        catch (Exception ex)
        {
        }
    }
   

    protected void lnkSearchByCompany_Click(object sender, EventArgs e)
    {
        divSearchByCompany.Visible = true;
        GridSearchByCompany.Visible = true;

        searchtype.Visible = false;
    }
    protected void lnkSearchByLocation_Click(object sender, EventArgs e)
    {
        divSearchByLocation.Visible = true;

        searchtype.Visible = false;
    }
    protected void lnkSearchBySkills_Click(object sender, EventArgs e)
    {
        divSearchBySkills.Visible = true;

        searchtype.Visible = false;
    }
    protected void lnkAdvanceSearch_Click(object sender, EventArgs e)
    {
        divAdvanceSearch.Visible = true;
        searchtype.Visible = false;
    }

    protected void btnSkills_Click(object sender, EventArgs e)
    {
        gridSearchbyskills.Visible = true;
        commondiv.Visible = true;
        string skills = txtSkills.Text;
        objBLLJobSeeker.KeySkill = skills;
        DataSet ds = objBLLJobSeeker.BLLCompanydetailsbySkills(objBLLJobSeeker);
        gvSearchBySkills.DataSource = ds.Tables[0];
        gvSearchBySkills.DataBind();

    }

    protected void btnSearchByCompany_Click(object sender, EventArgs e)
    {
        //GridSearchByCompany.Visible = true;
        //commondiv.Visible = true;
        //string Id=ddlCompanyName.SelectedItem.Value;
        //objBLLJobSeeker.Id = Convert.ToInt32(Id);
        //DataSet ds = objBLLJobSeeker.BLLCompanydetailsbyid(objBLLJobSeeker);
        //gvSearchByCompany.DataSource = ds.Tables[0];
        //gvSearchByCompany.DataBind();
        string str = "Select NameOfComp from [Come2myCityDB].[come2mycity].[tbl_JCompReg] where NameOfComp='" + ddlCompanyName.Text + "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        string c = Convert.ToString(ds.Tables[0].Rows[0]["NameOfComp"]);
        objBLLJobSeeker.NameOfComp1 = Convert.ToString(c);
        GridSearchByCompany.Visible = true;
        gvSearchByCompany.Visible = true;
        commondiv.Visible = true;
        ds = objBLLJobSeeker.BLLCompanydetailsbyid(objBLLJobSeeker);
        gvSearchByCompany.DataSource = ds.Tables[0];
        gvSearchByCompany.DataBind();


    }
#region searchAdvance
    protected void btnAdvanceSearch_Click(object sender, EventArgs e)
    {
        gridAdvanceSearch.Visible = true;
        commondiv.Visible = true;
        string skill = txtSkills1.Text;
        string experience = ddlexperience.SelectedItem.Text;
        string salary = ddlExpectedSalary.SelectedItem.Text;
        objBLLJobSeeker.KeySkill = skill;
        objBLLJobSeeker.Annualsalary = salary;
        objBLLJobSeeker.Req_exp = experience;
        DataSet ds = objBLLJobSeeker.BLLCompanydetailsbyAdvance(objBLLJobSeeker);
        gvAdvanceSearch.DataSource = ds.Tables[0];
        gvAdvanceSearch.DataBind();


    }
#endregion

    protected void btnback_Click(object sender, EventArgs e)
    {
        searchtype.Visible = true;
        divSearchByCompany.Visible = false;
        divSearchByLocation.Visible = false;
        divSearchBySkills.Visible = false;
        divAdvanceSearch.Visible = false;

        commondiv.Visible = false;

    }


    protected void btnSearchLocation_Click(object sender, EventArgs e)
    {
        string str = "Select cityName from [Come2myCityDB].[dbo].[CityMaster] where cityId='"+ddlLocaton.Text+"'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        string c = Convert.ToString(ds.Tables[0].Rows[0]["cityName"]);
        //string cstr = c.Substring();
        objBLLJobSeeker.City1 = Convert.ToString(c);
        gvSearchByLocation.Visible = true;
        commondiv.Visible = true;
        string id = ddlLocaton.SelectedItem.Value;
        objBLLJobSeeker.Id = Convert.ToInt32(id);
        ds=objBLLJobSeeker.BLLCompanydetailsbyLocation(objBLLJobSeeker);
        gvSearchByLocation.DataSource = ds.Tables[0];
        gvSearchByLocation.DataBind();


    }


    protected void lnkEditResume_Click(object sender, EventArgs e)
    {
        if (txtKeySkill.Text == "" && txtresumetitle.Text == "")
        {
            btnInsert.Visible = true;

        }
        else
        {
            btnUpdate.Visible = true;
        }
    }
    protected void gvLatestJobs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string PID = Convert.ToString(e.CommandArgument);
            lblId.Text = PID;
            if (Convert.ToString(e.CommandName) == "Apply")
            {
                string datetime = System.DateTime.Now.ToShortDateString();
                string sql = "select UserId from [Come2myCityDB].[come2mycity].[tbl_JPostReq] where PID='" + PID + "'";
                string userid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.UserId1 = Session["User"].ToString();
                objBLLJobSeeker.Applieddate = datetime;
                string s = "select CName from [Come2myCityDB].[come2mycity].[tbl_JPostReq] where PID='" + PID + "'";
                DataSet ds = cc.ExecuteDataset(s);
                string c = Convert.ToString(ds.Tables[0].Rows[0]["CName"]);
                sql = "select CID from [Come2myCityDB].[come2mycity].[tbl_JCompReg] where  NameOfComp='" + c + "'";
                objBLLJobSeeker.Companyid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.PID1 = Convert.ToInt32(PID);
                objBLLJobSeeker.UsrMobileNo = Session["Mobile"].ToString();
                status = objBLLJobSeeker.BLLInsertCandidateApplied(objBLLJobSeeker);
                if (status == 1)
                {
                    Response.Write("<script>(alert)('You have successfully applied')</script>");
                }
                else
                {
                    Response.Write("<script>(alert)('You have not applied')</script>");
                }

                //Response.Redirect("../html/JobSeeker.aspx");

            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void gvSearchByCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            if (Convert.ToString(e.CommandName) == "Apply")
            {
                string datetime = System.DateTime.Now.ToShortDateString();
                string sql = "select userid from latestjobemployer where id='" + Id + "'";
                string userid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Userid = Session["User"].ToString();
                objBLLJobSeeker.Applieddate = datetime;
                sql = "select companyid from companydetails where userid='" + userid + "'";
                objBLLJobSeeker.Companyid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Id = Convert.ToInt32(Id);
                objBLLJobSeeker.UsrMobileNo = Session["Mobile"].ToString();
                status = objBLLJobSeeker.BLLInsertCandidateApplied(objBLLJobSeeker);
                if (status == 1)
                {
                    Response.Write("<script>(alert)('You have successfully applied')</script>");
                }
                else
                {
                    Response.Write("<script>(alert)('You have not applied')</script>");
                }
            }


        }
        catch (Exception ex)
        {
        }
    }
    protected void gvSearchByLocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            if (Convert.ToString(e.CommandName) == "Apply")
            {
                string datetime = System.DateTime.Now.ToShortDateString();
                string sql = "select userid from latestjobemployer where id='" + Id + "'";
                string userid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Userid = Session["User"].ToString();
                objBLLJobSeeker.Applieddate = datetime;
                sql = "select companyid from companydetails where userid='" + userid + "'";
                objBLLJobSeeker.Companyid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Id = Convert.ToInt32(Id);
                objBLLJobSeeker.UsrMobileNo = Session["Mobile"].ToString();
                status = objBLLJobSeeker.BLLInsertCandidateApplied(objBLLJobSeeker);
                if (status == 1)
                {
                    Response.Write("<script>(alert)('You have successfully applied')</script>");
                }
                else
                {
                    Response.Write("<script>(alert)('You have not applied')</script>");
                }
            }


        }
        catch (Exception ex)
        {
        }

    }
    protected void gvSearchBySkills_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            if (Convert.ToString(e.CommandName) == "Apply")
            {
                string datetime = System.DateTime.Now.ToShortDateString();
                string sql = "select userid from latestjobemployer where id='" + Id + "'";
                string userid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Userid = Session["User"].ToString();
                objBLLJobSeeker.Applieddate = datetime;
                sql = "select companyid from companydetails where userid='" + userid + "'";
                objBLLJobSeeker.Companyid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Id = Convert.ToInt32(Id);
                objBLLJobSeeker.UsrMobileNo = Session["Mobile"].ToString();
                status = objBLLJobSeeker.BLLInsertCandidateApplied(objBLLJobSeeker);
                if (status == 1)
                {
                    Response.Write("<script>(alert)('You have successfully applied')</script>");
                }
                else
                {
                    Response.Write("<script>(alert)('You have not applied')</script>");
                }
            }


        }
        catch (Exception ex)
        {
        }


    }
    protected void gvAdvanceSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            if (Convert.ToString(e.CommandName) == "Apply")
            {
                string datetime = System.DateTime.Now.ToShortDateString();
                string sql = "select userid from latestjobemployer where id='" + Id + "'";
                string userid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Userid = Session["User"].ToString();
                objBLLJobSeeker.Applieddate = datetime;
                sql = "select companyid from companydetails where userid='" + userid + "'";
                objBLLJobSeeker.Companyid = cc.ExecuteScalar(sql);
                objBLLJobSeeker.Id = Convert.ToInt32(Id);
                objBLLJobSeeker.UsrMobileNo = Session["Mobile"].ToString();
                status = objBLLJobSeeker.BLLInsertCandidateApplied(objBLLJobSeeker);
                if (status == 1)
                {
                    Response.Write("<script>(alert)('You have successfully applied')</script>");
                }
                else
                {
                    Response.Write("<script>(alert)('You have not applied')</script>");
                }
            }


        }
        catch (Exception ex)
        {
        }


    }
    //protected void Timer1_Tick(object sender, EventArgs e)
    //{
    //    Label1.Text = "Grid Refreshed at: " + DateTime.Now.ToLongTimeString();
    //    viewAppliedCandidate();
    //}
}
