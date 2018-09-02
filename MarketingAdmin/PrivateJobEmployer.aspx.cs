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
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Net;

public partial class MarketingAdmin_PrivateJobEmployer : System.Web.UI.Page
{
    clsJobPortal bllobjJobPortal = new clsJobPortal();
    CommonCode cc = new CommonCode();

    BLLCompanyDetails bllobjcompany = new BLLCompanyDetails();
    int status;
    string companyid = "";
    string filename = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Categorybind();
            state();
            Qualfication();
            industry();
            state();
            gvJobdetailsshow();
            Bind_viewCandidate();
            Bind_data();

        }

    }

    public void Bind_data()
    {
        bllobjcompany.Userid = Session["MarketingUser"].ToString();
        status = bllobjcompany.BLLCheckcompanyexist(bllobjcompany);
        if (status == 1)
        {
        }
        else
        {
            status = bllobjcompany.BLLChecklatestjobexist(bllobjcompany);
            if (status == 1)
            {

                DataSet ds = bllobjcompany.BLLViewCompanyDetailsonly(bllobjcompany);
                txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["companyname"]);
                ddlState.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["stateName"]);
                ddlDistrict.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["distName"]);
                ddlCity.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["cityName"]);
                txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                txtContactPerson.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactperson"]);
                txtcontactnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactno"]);
                ddlCategory.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Functions"]);
                rdbCompanyType.SelectedIndex = 0;
                btnPostJob.Text = "Edit";
                btnSubmit.Visible = true;
                txtCompanyName.Enabled = false;
                ddlState.Enabled = false;
                ddlDistrict.Enabled = false;
                ddlCity.Enabled = false;
                txtAddress.Enabled = false;
                txtcontactnumber.Enabled = false;
                txtContactPerson.Enabled = false;
                ddlCategory.Enabled = false;

            }
           
        }



    }

    public void Bind_viewCandidate()
    {
        try
        {
            bllobjcompany.Userid = Session["MarketingUser"].ToString();

            DataSet ds = bllobjcompany.BLLGetAppliedCandidate(bllobjcompany);
            gvViewCandidate.DataSource = ds.Tables[0];
            gvViewCandidate.DataBind();


        }
        catch (Exception ex)
        {
        }
    }
    public void Qualfication()
    {
        DataSet ds = bllobjcompany.BLLGetQuali(bllobjcompany);
        lstqualification.DataSource = ds.Tables[0];
        lstqualification.DataTextField = "qualificationName";
        lstqualification.DataValueField = "qualificationId";
        lstqualification.DataBind();

    }

    public void industry()
    {
        // bllobjcompany.Userid = Session["MarketingUser"].ToString();
        //  bllobjcompany.Industrytype = Convert.ToInt32(Session["Industrytype"]);4
        DataSet ds = bllobjcompany.BLLGetIndustrylist(bllobjcompany);
        ddlJobType.DataSource = ds.Tables[0];
        ddlJobType.DataTextField = "industryName";
        ddlJobType.DataValueField = "industryId";
        ddlJobType.DataBind();
        ddlJobType.Items.Add("--Select--");
        ddlJobType.Items[ddlJobType.Items.Count - 1].Value = "";
        ddlJobType.SelectedIndex = ddlJobType.Items.Count - 1;

    }
    protected void btnSendDownloadlink_Click(object sender, EventArgs e)
    {
        senddownloadlink();
    }
    private void senddownloadlink()
    {
        try
        {

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text.ToString());
        if (Id == "" || Id == null)
        {
            SubmitLatestJobRecruit();
            gvJobdetailsshow();
            Response.Redirect("../MarketingAdmin/PrivateJobEmployer.aspx");
        }
        else
        {
            bllobjcompany.Userid = Session["MarketingUser"].ToString();
            bllobjcompany.Skills = txtSkills.Text;
            bllobjcompany.Jobdesignation = txtJobDesignation.Text;
            listitem();
            bllobjcompany.Noofemployee = Convert.ToInt32(txtNoOfEmpRequired.Text);
            bllobjcompany.Reqexp = ddlExpYear.SelectedItem.Text;
            bllobjcompany.Salary = ddlSalary.SelectedItem.Text;
            bllobjcompany.Jobstatus = ddlstatus.SelectedItem.Text;
            bllobjcompany.Id = Convert.ToInt32(Id);
            status = bllobjcompany.BLLUpdateLatestJobRecruit(bllobjcompany);
            if (status == 1)
            {
                Response.Write("<script>(alert)('Record updated successfully')</script>");
                Bind_data();
            }
            else
            {
                Response.Write("<script>(alert)('Record not updated')</script>");
                Bind_data();
            }
        }


    }
    private void SubmitLatestJobRecruit()
    {
        try
        {
            listitem();
            Applicationfileupload();
            bllobjcompany.Userid = Session["MarketingUser"].ToString();
            bllobjcompany.Jobtype = ddlJobType.SelectedItem.Text;
            bllobjcompany.Skills = txtSkills.Text;
            bllobjcompany.Jobdesignation = txtJobDesignation.Text;
            bllobjcompany.Noofemployee = Convert.ToInt32(txtNoOfEmpRequired.Text);
            bllobjcompany.Reqexp = ddlExpYear.SelectedItem.Value;
            bllobjcompany.Salary = ddlSalary.SelectedItem.Value;
            bllobjcompany.Formname = Session["filename"].ToString();
            bllobjcompany.Currentdate = DateTime.Now.ToString();
            string job_status = "Active";
            bllobjcompany.Jobstatus = job_status;
            bllobjcompany.Validfrom = txtValidFrom.Text;
            bllobjcompany.Validto = txtValidTo.Text;
            status = bllobjcompany.BLLInsertLatestJobRecruit(bllobjcompany);
            if (status == 1)
            {
                Response.Write("<script>(alert)('Latest Job Recruit is inserted successfully')</script>");
            }
            else
            {
                Response.Write("<script>(alert)('Latest Job Recruit is not inserted')</script>");

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }



    }
    private void Applicationfileupload()
    {
        if (AppFileupload.HasFile)
        {
            try
            {
                string path = "";
                Session["filename"] = AppFileupload.FileName;
                string userid = Session["MarketingUser"].ToString();
                if (userid != "")
                {
                    string thisDir = Server.MapPath("~/JobApplication/");

                    System.IO.Directory.CreateDirectory(thisDir + userid + "\\Application" + "");

                    string newpa = "" + thisDir + userid + "\\Application" + "";

                    string newpath = Server.MapPath("~/JobApplication/" + userid + "\\Application" + "");

                    path = newpath + "\\" + AppFileupload.FileName;

                    string ePath = newpa;

                    string[] filename1 = Directory.GetFiles(ePath, "*");

                    foreach (string str in filename1)
                    {
                        File.Delete(str);
                    }
                    AppFileupload.SaveAs(path);
                    bllobjcompany.Formname = AppFileupload.FileName;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    private void listitem()
    {
        string Qualification = "";

        for (int i = 0; i < lstqualification.Items.Count; i++)
        {
            if (lstqualification.Items[i].Selected == true)
            {
                Qualification = Qualification + "," + lstqualification.Items[i].Text;

            }
        }
        if (Qualification.Length > 1)
        {
            Qualification = Qualification.Substring(1);
        }
        bllobjcompany.ReqQualification = Qualification;
    }

    private void gvJobdetailsshow()
    {
        bllobjcompany.Userid = Session["MarketingUser"].ToString();
        DataSet ds = bllobjcompany.BLLGetLatestJob(bllobjcompany);
        gvJobdetails.DataSource = ds.Tables[0];
        gvJobdetails.DataBind();

    }
    protected void gvJobdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id1 = Convert.ToString(e.CommandArgument);
            lblId.Text = Id1;
            if (Convert.ToString(e.CommandName) == "Modify")
            {
                bllobjcompany.Userid = Session["MarketingUser"].ToString();
                bllobjcompany.Id = Convert.ToInt32(Id1);
                DataSet ds = bllobjcompany.BLLViewCompanyDetails(bllobjcompany);
                ddlJobType.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["job_type"]);
                txtSkills.Text = Convert.ToString(ds.Tables[0].Rows[0]["skills"]);
                txtJobDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["job_designation"]);
                txtValidFrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["valid_from"]);
                txtValidTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["valid_to"]);
                lblStatus.Visible = true;
                ddlstatus.Visible = true;
                ddlstatus.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["job_status"]);
                ddlExpYear.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["req_exp"]);
                ddlSalary.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["salary"]);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string Id = Convert.ToString(dr["req_qualification"]);
                    string[] arr = Id.Split(',');
                    foreach (string s in arr)
                    {
                        for (int i = 0; i < lstqualification.Items.Count; i++)
                        {
                            if (lstqualification.Items[i].Text == s.ToString())
                            {
                                lstqualification.Items[i].Selected = true;
                            }
                        }
                    }
                }

                txtNoOfEmpRequired.Text = Convert.ToString(ds.Tables[0].Rows[0]["no_of_employee"]);
                ddlExpYear.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["req_exp"]);
                btnSubmit.Text = "Update";
                ddlJobType.Enabled = false;
                txtValidFrom.Enabled = false;
                txtValidTo.Enabled = false;
                AppFileupload.Enabled = false;


            }
        }
        catch (Exception ex)
        {
        }

    }
    private void Categorybind()
    {
        try
        {


            DataSet ds = bllobjJobPortal.BLLLoadCategory(bllobjJobPortal);
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataTextField = "Functions";
            ddlCategory.DataValueField = "FunctionId";

            ddlCategory.DataBind();
            ddlCategory.Items.Add("--Select--");
            ddlCategory.Items[ddlCategory.Items.Count - 1].Value = "";
            ddlCategory.SelectedIndex = ddlCategory.Items.Count - 1;


        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    public void state()
    {
        try
        {

            Location loc = new Location();
            DataSet ds = loc.getAllLocation();
            Session["Location"] = ds;
            if (ds.Tables[0] != null)
            {

                ddlState.DataSource = ds.Tables[0];
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Add("--Select--");
                ddlState.Items[ddlState.Items.Count - 1].Value = " ";
                ddlDistrict.Items.Add("--Select--");
                ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
                ddlCity.Items.Add("--Select--");
                ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";

                ddlState.SelectedIndex = ddlState.Items.Count - 1;


            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    //public void state1()
    //{
    //    try
    //    {

    //        Location loc = new Location();
    //        DataSet ds = loc.getAllLocation();
    //        Session["Location"] = ds;
    //        if (ds.Tables[0] != null)
    //        {

    //            ddlstate1.DataSource = ds.Tables[0];
    //            ddlstate1.DataTextField = "StateName";
    //            ddlstate1.DataValueField = "StateId";
    //            ddlstate1.DataBind();
    //            ddlstate1.Items.Add("--Select--");
    //            ddlstate1.Items[ddlState.Items.Count - 1].Value = " ";
    //            ddlDistrict1.Items.Add("--Select--");
    //            ddlDistrict1.Items[ddlDistrict.Items.Count - 1].Value = " ";
    //            ddlCity1.Items.Add("--Select--");
    //            ddlCity1 .Items[ddlCity.Items.Count - 1].Value = " ";

    //            ddlState.SelectedIndex = ddlState.Items.Count - 1;


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //    }
    //}
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet Location = (DataSet)Session["Location"];
            if (ddlState.SelectedIndex != ddlState.Items.Count - 1)
            {
                if (Location.Tables[1] != null)
                {
                    DataRow[] dr = Location.Tables[1].Select("StateId=" + ddlState.SelectedValue.ToString() + "");
                    ddlDistrict.DataSource = getDataTable(dr);
                    ddlDistrict.DataTextField = "Name";
                    ddlDistrict.DataValueField = "Id";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Add("--Select--");
                    //ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
                }
            }
            else
            {
                ddlCity.Items.Clear();
                ddlDistrict.Items.Clear();
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
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet Location = (DataSet)Session["Location"];
            if (ddlDistrict.SelectedIndex != ddlDistrict.Items.Count - 1)
            {
                if (Location.Tables[2] != null)
                {
                    DataRow[] dr = Location.Tables[2].Select("DistrictId=" + ddlDistrict.SelectedValue.ToString() + "");
                    ddlCity.DataSource = getDataTable(dr);
                    ddlCity.DataTextField = "Name";
                    ddlCity.DataValueField = "Id";
                    ddlCity.DataBind();
                    ddlCity.Items.Add("--Select--");
                    ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";
                    ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
                }
            }
            else
            {
                ddlCity.Items.Clear();

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    protected void btnPostJob_Click(object sender, EventArgs e)
    {
        if (btnPostJob.Text == "Edit")
        {
            ddlState.Enabled = true;
            ddlDistrict.Enabled = true;
            ddlCity.Enabled = true;
            txtAddress.Enabled = true;
            //ddlCategory.Enabled = true;
            bllobjcompany.Userid = Session["MarketingUser"].ToString();
            DataSet ds = bllobjcompany.BLLViewCompanyDetailsonly(bllobjcompany);
            txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["companyname"]);
            ddlState.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["stateName"]);
            ddlDistrict.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["distName"]);
            ddlCity.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["cityName"]);
            txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
            txtContactPerson.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactperson"]);
            txtcontactnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactno"]);
            //ddlCategory.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Functions"]);
            btnPostJob.Text = "Update";

        }
        else if (btnPostJob.Text == "Update")
        {
            Update();
        }

        else
        {
            CompanyRegistrationInsert();
        }
    }

    private void CompanyRegistrationInsert()
    {
        try
        {
            string id = System.Guid.NewGuid().ToString();
            id = id.Remove(7);
            bllobjcompany.Companyid = id;

            bllobjcompany.Companyname = txtCompanyName.Text;
            bllobjcompany.Companytype = rdbCompanyType.SelectedItem.Text;
            bllobjcompany.State = Convert.ToInt32(ddlState.SelectedItem.Value);
            bllobjcompany.District = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
            bllobjcompany.City = Convert.ToInt32(ddlCity.SelectedItem.Value);
            bllobjcompany.Address = txtAddress.Text;
            bllobjcompany.Contactperson = txtContactPerson.Text;
            bllobjcompany.Contactno = txtcontactnumber.Text;
            bllobjcompany.Industrytype = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            Session["Industrytype"] = bllobjcompany.Industrytype;
            bllobjcompany.Userid = Session["MarketingUser"].ToString();

            status = bllobjcompany.BLLCompanyRegistrationInsert(bllobjcompany);
            if (status == 1)
            {

                Response.Write("<script>(alert)('Company is registered successfully')</script>");

            }
            else
            {
                Response.Write("<script>(alert)('Company is not registered ')</script>");

            }
        }
        catch (Exception ex)
        {
        }

        Companyclear();
        // Response.Redirect("../MarketingAdmin/PrivateJobEmployer.aspx");

    }

    private void Companyclear()
    {
        txtCompanyName.Text = "";
        state();
        Categorybind();
        //ddlState.SelectedIndex = -1;
        //ddlDistrict.SelectedIndex = -1;
        //ddlCity.SelectedIndex = -1;
        //ddlCategory.SelectedIndex = -1;
        // rdbCompanyType.SelectedIndex = -1;
        txtAddress.Text = "";
        txtContactPerson.Text = "";
        txtcontactnumber.Text = "";
        // ddlCategory.SelectedIndex = -1;
        ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;

    }
    protected void gvViewCandidate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId1.Text = Id;
        string sql = "select resume_name from JobSeekerDetails where userid='" + Id + "'";
        string resumename = cc.ExecuteScalar(sql);
        if (Convert.ToString(e.CommandName) == "Download")
        {
            string resume = "~/EmployeeResume/" + Id + "/" + resumename;
            DirectoryInfo di = new DirectoryInfo(Server.MapPath(resume));
            fileDownload("'" + resume + "'", di.ToString());
        }


    }
    private void fileDownload(string fileName, string fileUrl)
    {
        Page.Response.Clear();
        bool success = ResponseFile(Page.Request, Page.Response, fileName, fileUrl, 1024000);
        if (!success)
            Response.Write("Downloading Error!");
        // Page.Response.End();

    }
    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {
        try
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);

            try
            {
                _Response.AddHeader("Accept-Ranges", "bytes");
                _Response.Buffer = false;
                long fileLength = myFile.Length;
                long startBytes = 0;

                int pack = 10240; //10K bytes
                int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
                if (_Request.Headers["Range"] != null)
                {
                    _Response.StatusCode = 206;
                    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                _Response.AddHeader("Connection", "Keep-Alive");
                _Response.ContentType = "application/octet-stream";
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

                for (int i = 0; i < maxCount; i++)
                {
                    if (_Response.IsClientConnected)
                    {
                        _Response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                // br.Close();
                //myFile.Close();
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    protected void gvViewCandidate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    private void Update()
    {
        string Id = Session["MarketingUser"].ToString();

        bllobjcompany.State = Convert.ToInt32(ddlState.SelectedItem.Value);
        bllobjcompany.District = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
        bllobjcompany.City = Convert.ToInt32(ddlCity.SelectedItem.Value);
        bllobjcompany.Address = txtAddress.Text;
        // bllobjcompany.Industrytype = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        bllobjcompany.Userid = Id.ToString();
        status = bllobjcompany.BLLUpdateCompanyDetails(bllobjcompany);
        if (status == 1)
        {
            Response.Write("<script>(alert)('Record Updated Successfully')</script>");
            Bind_data();
        }
        else
        {
            Response.Write("<script>(alert)('Record Not Updated Successfully')</script>");
            Bind_data();
        }



    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCompanyName.Text = "";
        state();
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        txtAddress.Text = "";
        txtContactPerson.Text = "";
        txtcontactnumber.Text = "";
        //ddlCategory.SelectedIndex = ddlCategory.Items.Count - 1;
        Categorybind();
    }
    protected void btnEdit1_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        industry();
        txtSkills.Text = "";
        txtJobDesignation.Text = "";
        txtNoOfEmpRequired.Text = "";
       // ddlExpYear.SelectedIndex = ddlExpYear.Items.Count - 1;
        ddlExpYear.Items[ddlExpYear.Items.Count - 1].Value = "";
       // ddlSalary.SelectedIndex = ddlSalary.Items.Count - 1;
        ddlSalary.Items[ddlSalary.Items.Count - 1].Value = "";
        lstqualification.SelectedItem.Value = "";
     
    }
}
