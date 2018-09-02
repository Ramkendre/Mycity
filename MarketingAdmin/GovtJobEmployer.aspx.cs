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
using System.IO;

public partial class MarketingAdmin_GovtJobEmployer : System.Web.UI.Page
{
    clsJobPortal bllobjJobPortal = new clsJobPortal();
    CommonCode cc = new CommonCode();

    BLLCompanyDetails bllobjCompanyDetails = new BLLCompanyDetails();
    int status;
    string companyid = "";
    string filename = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Categorybind();
            // qualificationbind();
            state();
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            Bind_data();
            industry();
            Qualfication();
            gvJobdetailsshow();
            viewadvertisement();

        }
    }
    public void industry()
    {

        DataSet ds = bllobjCompanyDetails.BLLGetIndustrylist(bllobjCompanyDetails);
        ddlJobType.DataSource = ds.Tables[0];
        ddlJobType.DataTextField = "industryName";
        ddlJobType.DataValueField = "industryId";
        ddlJobType.DataBind();
        ddlJobType.Items.Add("--Select--");
        ddlJobType.Items[ddlJobType.Items.Count - 1].Value = "";
        ddlJobType.SelectedIndex = ddlJobType.Items.Count - 1;

    }

    public void Bind_data()
    {
        bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
        status = bllobjCompanyDetails.BLLCheckcompanyexist(bllobjCompanyDetails);
        if (status == 1)
        {
        }
        else
        {
            status = bllobjCompanyDetails.BLLCheckAdvertiseexist(bllobjCompanyDetails);
            if (status == 1)
            {
                DataSet ds = bllobjCompanyDetails.BLLViewCompanyDetailsonly(bllobjCompanyDetails);
                txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["companyname"]);
                txtCompanyName1.Text = Convert.ToString(ds.Tables[0].Rows[0]["companyname"]);
                ddlState.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["stateName"]);
                ddlDistrict.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["distName"]);
                ddlCity.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["cityName"]);
                txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                txtaddress1.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                txtContactPerson.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactperson"]);
                txtcontactnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactno"]);
                ddlCategory.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Functions"]);
                string companytype = Convert.ToString(ds.Tables[0].Rows[0]["companytype"]);
                if (companytype == "Government")
                {
                    rdbCompanyType.SelectedIndex = 0;
                }
                else
                {
                    rdbCompanyType.SelectedIndex = 1;
                }
                btnPostJob.Text = "Edit";
                btnSubmit1.Visible = true;
                txtCompanyName.Enabled = false;
                ddlState.Enabled = false;
                ddlDistrict.Enabled = false;
                ddlCity.Enabled = false;
                txtAddress.Enabled = false;
                txtcontactnumber.Enabled = false;
                txtContactPerson.Enabled = false;
                ddlCategory.Enabled = false;
                rdbCompanyType.Enabled = false;
            }
            //else
            //{
            //    DataSet ds = bllobjCompanyDetails.BLLViewCompanyDetailsonly(bllobjCompanyDetails);
            //    txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["companyname"]);
            //    ddlState.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["stateName"]);
            //    ddlDistrict.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["distName"]);
            //    ddlCity.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["cityName"]);
            //    txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
            //    txtContactPerson.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactperson"]);
            //    txtcontactnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["contactno"]);
            //    ddlCategory.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Functions"]);
            //    btnPostJob.Text = "Edit";
            //    btnSubmit1.Text = "Edit";
            //    DataSet ds1 = bllobjCompanyDetails.BLLViewCompanyAdvertisment(bllobjCompanyDetails);
            //    //btnSearch.Visible = false;
            //   // txtmobileNo.Text = Convert.ToString(ds1.Tables[0].Rows[0]["contactno"]);
            //    txtCompanyName1.Text = Convert.ToString(ds1.Tables[0].Rows[0]["companyname"]);
            //    txtaddress1.Text = Convert.ToString(ds1.Tables[0].Rows[0]["address"]);
            //    txtFrom.Text = Convert.ToString(ds1.Tables[0].Rows[0]["advertise_Fromdate"]);
            //    txtTo.Text = Convert.ToString(ds1.Tables[0].Rows[0]["advertise_Todate"]);
            //    string adv = Convert.ToString(ds1.Tables[0].Rows[0]["advertise_to"]);
            //    foreach (DataRow dr in ds1.Tables[0].Rows)
            //    {

            //        string Id = Convert.ToString(dr["advertise_to"]);
            //        string[] arr = Id.Split(',');
            //        foreach (string s in arr)
            //        {
            //            for (int i = 0; i < lstNewspaper.Items.Count; i++)
            //            {
            //                if (lstNewspaper.Items[i].Text == s.ToString())
            //                {
            //                    lstNewspaper.Items[i].Selected = true;
            //                }
            //            }
            //        }
            //    }
            //    txtCompanyName.Enabled = false;
            //    ddlState.Enabled = false;
            //    ddlDistrict.Enabled = false;
            //    ddlCity.Enabled = false;
            //    txtAddress.Enabled = false;
            //    txtcontactnumber.Enabled = false;
            //    txtContactPerson.Enabled = false;
            //    ddlCategory.Enabled = false;
            //  //  btnSearch.Visible = false;
            //   // txtmobileNo.Enabled = false;
            //    txtCompanyName1.Enabled = false;
            //    txtaddress1.Enabled = false;
            //    fileAdvertise.Enabled = false;
            //    txtFrom.Enabled = false;
            //    txtTo.Enabled = false;
            //    lstNewspaper.Enabled = false;


            //}




        }



    }

    public void viewadvertisement()
    {
        bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
        DataSet ds = bllobjCompanyDetails.BLLGetCompanyAdvt(bllobjCompanyDetails);
        gvViewAdvertise.DataSource = ds.Tables[0];
        gvViewAdvertise.DataBind();

    }
    public void Qualfication()
    {
        DataSet ds = bllobjCompanyDetails.BLLGetQuali(bllobjCompanyDetails);
        lstqualification.DataSource = ds.Tables[0];
        lstqualification.DataTextField = "qualificationName";
        lstqualification.DataValueField = "qualificationId";
        lstqualification.DataBind();

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


    protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


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

    private void cleartext()
    {
        txtCompanyName.Text = "";
        rdbCompanyType.SelectedItem.Value = "";
        state();
        ddlDistrict.Items.Add("--Select--");
        ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = "";
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        ddlCity.Items.Add("--Select--");
        ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";
        ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        ddlCategory.Items.Add("--Select--");
        ddlCategory.Items[ddlCategory.Items.Count - 1].Value = "";
        ddlCategory.SelectedIndex = ddlCategory.Items.Count - 1;
        txtAddress.Text = "";
        txtContactPerson.Text = "";
        txtcontactnumber.Text = "";

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
            bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
            DataSet ds = bllobjCompanyDetails.BLLViewCompanyDetailsonly(bllobjCompanyDetails);
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
            bllobjCompanyDetails.Companyid = id;
            bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
            bllobjCompanyDetails.Companyname = txtCompanyName.Text;
            bllobjCompanyDetails.State = Convert.ToInt32(ddlState.SelectedItem.Value);
            bllobjCompanyDetails.District = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
            bllobjCompanyDetails.City = Convert.ToInt32(ddlCity.SelectedItem.Value);
            bllobjCompanyDetails.Address = txtAddress.Text;
            bllobjCompanyDetails.Contactperson = txtContactPerson.Text;
            bllobjCompanyDetails.Contactno = txtcontactnumber.Text;
            bllobjCompanyDetails.Industrytype = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            bllobjCompanyDetails.Companytype = rdbCompanyType.SelectedItem.Text;
            status = bllobjCompanyDetails.BLLCompanyRegistrationInsert(bllobjCompanyDetails);
            if (status == 1)
            {

                Response.Write("<script>(alert)('Company is registered successfully')</script>");
                //cleartext();
                Bind_data();

            }
            else
            {
                Response.Write("<script>(alert)('Company is not registered ')</script>");
                //cleartext();
                Bind_data();

            }
        }
        catch (Exception ex)
        {
        }

        // Companyclear();

    }
    private void Update()
    {
        string Id = Session["MarketingUser"].ToString();

        bllobjCompanyDetails.State = Convert.ToInt32(ddlState.SelectedItem.Value);
        bllobjCompanyDetails.District = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
        bllobjCompanyDetails.City = Convert.ToInt32(ddlCity.SelectedItem.Value);
        bllobjCompanyDetails.Address = txtAddress.Text;
        // bllobjcompany.Industrytype = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        bllobjCompanyDetails.Userid = Id.ToString();
        status = bllobjCompanyDetails.BLLUpdateCompanyDetails(bllobjCompanyDetails);
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

    private void Companyclear()
    {
        txtCompanyName.Text = "";

        ddlState.SelectedIndex = -1;
        ddlDistrict.SelectedIndex = -1;
        ddlCity.SelectedIndex = -1;
        ddlCategory.SelectedIndex = -1;
        rdbCompanyType.SelectedIndex = -1;
        txtAddress.Text = "";
        txtContactPerson.Text = "";
        txtcontactnumber.Text = "";
        ddlCategory.SelectedIndex = -1;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCompany();
    }
    private void SearchCompany()
    {
        //bllobjCompanyDetails.Contactno = txtmobileNo.Text;
        status = bllobjCompanyDetails.BLLExistcompanyno(bllobjCompanyDetails);
        if (status == 1)
        {
            Response.Write("<script>(alert)('Contact No. is not exist')</script>");

        }
        else
        {
            DataSet ds = bllobjCompanyDetails.BLLGetCompanydetails(bllobjCompanyDetails);
            txtCompanyName1.Text = Convert.ToString(ds.Tables[0].Rows[0]["companyname"]);
            txtaddress1.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
            companyid = Convert.ToString(ds.Tables[0].Rows[0]["companyid"]);
            Session["companyid"] = companyid;
            fileAdvertise.Enabled = true;
            txtFrom.Enabled = true;
            txtTo.Enabled = true;
            lstNewspaper.Enabled = true;
            // btnSearch.Visible = false;
        }



    }

    private void listitem()
    {
        string Newspapername = "";
        for (int i = 0; i < lstNewspaper.Items.Count; i++)
        {
            if (lstNewspaper.Items[i].Selected == true)
            {
                Newspapername = Newspapername + "," + lstNewspaper.Items[i].Text;

            }
        }
        if (Newspapername.Length > 1)
        {
            Newspapername = Newspapername.Substring(1);
        }
        bllobjCompanyDetails.AdvertiseIn = Newspapername;
    }

    private void listitemqualification()
    {
        string Newspapername = "";
        for (int i = 0; i < lstqualification.Items.Count; i++)
        {
            if (lstqualification.Items[i].Selected == true)
            {
                Newspapername = Newspapername + "," + lstqualification.Items[i].Text;

            }
        }
        if (Newspapername.Length > 1)
        {
            Newspapername = Newspapername.Substring(1);
        }
        bllobjCompanyDetails.ReqQualification = Newspapername;

    }

    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
         bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
         string sql = "select id from companydetails where userid='" + bllobjCompanyDetails.Userid + "'";
         string cid = cc.ExecuteScalar(sql);
         bllobjCompanyDetails.Id = Convert.ToInt32(cid);
         bllobjCompanyDetails.AdvertiseFromdate = txtFrom.Text;
         bllobjCompanyDetails.AdvertiseTodate = txtTo.Text;
        listitem();
        fileupload();
       string advstatus = "Active";
        bllobjCompanyDetails.Jobstatus = advstatus;
            status = bllobjCompanyDetails.BLLAdvertiseInsert(bllobjCompanyDetails);
            if (status == 1)
            {
                Response.Write("<script>(alert)('Advertisement is inserted successfully')</script>");
                viewadvertisement();
            }
            else
            {
                Response.Write("<script>(alert)('Advertisement is not inserted')</script>");

            }

       
       

        




    }



    private void fileupload()
    {
        if (fileAdvertise.HasFile)
        {
            try
            {
                string path = "";
               string file = fileAdvertise.FileName;
               string id = Convert.ToString(bllobjCompanyDetails.Id);
               if (id != "")
                {
                    string thisDir = Server.MapPath("~/CompanyImage/");

                    System.IO.Directory.CreateDirectory(thisDir + id + "");

                    string newpa = "" + thisDir + id + "";

                    string newpath = Server.MapPath("~/CompanyImage/" + id + "");

                    path = newpath + "\\" + fileAdvertise.FileName;

                    string ePath = newpa;
                    string[] filename1 = Directory.GetFiles(ePath, "*");

                    foreach (string str in filename1)
                    {
                        File.Delete(str);
                    }
                    fileAdvertise.SaveAs(path);
                    bllobjCompanyDetails.Advfilename = file;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    private void Advertiseclear()
    {
        // txtmobileNo.Text = "";
        txtCompanyName1.Text = "";
        txtaddress1.Text = "";
        txtFrom.Text = "";
        txtTo.Text = "";
        lstNewspaper.Items.Clear();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // txtmobileNo.Text = "";
        txtCompanyName1.Text = "";
        txtaddress1.Text = "";
        txtFrom.Text = "";
        txtTo.Text = "";
        lstNewspaper.SelectedItem.Value = "";
    }
    protected void btnCancelCompany_Click(object sender, EventArgs e)
    {
        //txtCompanyName.Text = "";
        //state();
        //ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        //ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        //txtAddress.Text = "";
        //txtContactPerson.Text = "";
        //txtcontactnumber.Text = "";
        //Categorybind();
        Bind_data();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text.ToString());
        if (Id == "" || Id == null)
        {
            SubmitLatestJobRecruit();
            gridshow.Visible = true;
            gvJobdetailsshow();
            Response.Redirect("../MarketingAdmin/GovtJobEmployer.aspx");

        }
        else
        {
            updateLatestjob(Id);
        }



    }


    private void SubmitLatestJobRecruit()
    {
        try
        {
            listitemqualification();
            bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
            //bllobjcompany.Companyid = Session["companyid"].ToString();
            bllobjCompanyDetails.Jobtype = ddlJobType.SelectedItem.Text;
            bllobjCompanyDetails.Skills = txtSkills.Text;
            bllobjCompanyDetails.Jobdesignation = txtJobDesignation.Text;
            bllobjCompanyDetails.Noofemployee = Convert.ToInt32(txtNoOfEmpRequired.Text);
            bllobjCompanyDetails.Reqexp = ddlExpYear.SelectedItem.Value;
            bllobjCompanyDetails.Salary = ddlSalary.SelectedItem.Value;
            bllobjCompanyDetails.Currentdate = DateTime.Now.ToString();
            string job_status = "Active";
            bllobjCompanyDetails.Jobstatus = job_status;
            bllobjCompanyDetails.Validfrom = txtValidFrom.Text;
            bllobjCompanyDetails.Validto = txtValidTo.Text;

            status = bllobjCompanyDetails.BLLInsertLatestJobRecruit(bllobjCompanyDetails);
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
    private void gvJobdetailsshow()
    {
        DataSet ds = bllobjCompanyDetails.BLLGetLatestGovtJob(bllobjCompanyDetails);
        gvJobdetails.DataSource = ds.Tables[0];
        gvJobdetails.DataBind();

    }
    protected void gvJobdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id1 = Convert.ToString(e.CommandArgument);
        lblId.Text = Id1;
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
            bllobjCompanyDetails.Id = Convert.ToInt32(Id1);
            DataSet ds = bllobjCompanyDetails.BLLViewCompanyDetails(bllobjCompanyDetails);
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

        }
    }
    private void updateLatestjob(string id)
    {
        bllobjCompanyDetails.Userid = Session["MarketingUser"].ToString();
        bllobjCompanyDetails.Skills = txtSkills.Text;
        bllobjCompanyDetails.Jobdesignation = txtJobDesignation.Text;
        // listitem();
        listitemqualification();
        bllobjCompanyDetails.Noofemployee = Convert.ToInt32(txtNoOfEmpRequired.Text);
        bllobjCompanyDetails.Reqexp = ddlExpYear.SelectedItem.Text;
        bllobjCompanyDetails.Salary = ddlSalary.SelectedItem.Text;
        bllobjCompanyDetails.Jobstatus = ddlstatus.SelectedItem.Text;
        bllobjCompanyDetails.Id = Convert.ToInt32(id);
        status = bllobjCompanyDetails.BLLUpdateLatestGovtJobRecruit(bllobjCompanyDetails);
        if (status == 1)
        {
            Response.Write("<script>(alert)('Record updated successfully')</script>");
            //Bind_data();
        }
        else
        {
            Response.Write("<script>(alert)('Record not updated')</script>");
            //Bind_data();
        }

    }
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/GovtJobEmployer.aspx");


    }
}
