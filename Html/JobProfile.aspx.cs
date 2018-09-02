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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

public partial class Html_JobProfile : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

        }
        else
        {
            //Bind_Qualification();
            MultiView1.Visible = true;
            //MultiView1.SetActiveView(View4);
            fillddl();
            fillDLL_QualificationV1();
        }
    }
    public void fillddl()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {

            string sql = "select qualificationId,qualificationName from UserQualification";
            
            DataSet ds = new DataSet();
            //SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            DDDLQualification.DataSource = ds;
            DDDLQualification.DataTextField = "qualificationName";
            DDDLQualification.DataValueField = "qualificationId";
            DDDLQualification.DataBind();
            DDDLQualification.Items.Add("Custom");
            DDDLQualification.Items.Insert(0, new ListItem("--Select--", "0"));
            DDDLQualification.SelectedIndex = 0;

            //DDDLQualification.DataSource = ds.Tables[0];
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DDDLQualification.DataTextField = "qualificationName";
            //    DDDLQualification.DataValueField = "qualificationId";

            //}
            //DDDLQualification.DataBind();
            //DDDLQualification.Items.Add("Add New");
            //DDDLQualification.Items.Add("---Select---");
            //DDDLQualification.SelectedIndex = DDDLQualification.Items.Count - 1;
            



        }
        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
            con.Open();
        }

    }
    public void fillDLL_QualificationV1()
    {
        string str = "select qualificationId,qualificationName from UserQualification";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        DDDLQualificationV1.DataSource = ds;
        DDDLQualificationV1.DataTextField = "qualificationName";
        DDDLQualificationV1.DataValueField = "qualificationId";
        DDDLQualificationV1.DataBind();
        DDDLQualificationV1.Items.Add("Custom");
        DDDLQualificationV1.Items.Insert(0,new ListItem("--Select--","0"));

    }
    public void Bind_Qualification()
    {
       
   
        string sql2 = "select brduniId,brduniName from UserBoardUniversity";
        DataSet dset = cc.ExecuteDataset(sql2);
        
        ddlUniversity.DataSource = dset.Tables[0];
        ddlUniversity.DataTextField = "brduniName";
        ddlUniversity.DataValueField = "brduniId";
        ddlUniversity.DataBind();
        ddlUniversity.Items.Add("--Select--");
        ddlUniversity.SelectedIndex = ddlUniversity.Items.Count - 1;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string str1 = string.Empty;
        int row1;
        string dt = cc.DateFormatStatus();
        
        string str2 = "insert into [Come2myCityDB].[come2mycity].[tbl_JWorkExp]([FrmDate],[ToDate],[TotalExpYr],[TotalExpM],[JTitle],[CompName],[Salary],[FArea],[UserId],[EntryDate])values('"+txtFrmdate.Text+"','"+txtTodate.Text+"','" + txtTExpYr.Text +
            "','"+txtWExpM.Text+"','"+txtJobT.Text+"','"+txtCompName.Text+"','"+txtSalary.Text+"','"+txtFArea.Text+"','"+Convert.ToString(Session["User"])+"','"+dt+"')";
        int row2 = cc.ExecuteNonQuery(str2);

        string str3 = "insert into [Come2myCityDB].[come2mycity].[tbl_JSkill]([Skill],[UserId])values('"+txtKeySkill.Text.Trim()+"'+'"+txtKeySkil2.Text.Trim()+"','"+Convert.ToString(Session["User"])+"')";
        int row3 = cc.ExecuteNonQuery(str3);

        uploadResume();
        string s=Session["Resumefilename"].ToString();

        string str4 = "insert into [Come2myCityDB].[come2mycity].[tbl_JProfile](RTitle,ResumeName,Course,UserId,EntryDate)values('" + txtRTitle.Text + "','" + s + "','"+txtCourse1.Text+"','" + Convert.ToString(Session["User"]) + "','" + dt + "')";
        int row9 = cc.ExecuteNonQuery(str4);
        


    }
    protected void DDDLQualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmbadd(DDDLQualification,txtQualification);
    }
    protected void DDDLQualificationV1_SelectedIndexChanged(object sender,EventArgs e)
    {
        cmbaddV1(DDDLQualificationV1,txtQualificationV1);
    }
    protected void txtQualification_TextChanged(object sender, EventArgs e)
    {
        txtChange(DDDLQualification, txtQualification);
    }
    protected void txtQualificationV1_OnTextChanged(object sender, EventArgs e)
    {
        txtChangeV1(DDDLQualificationV1,txtQualificationV1);
    }
    public void cmbadd(DropDownList dl,TextBox tx)
    {
        if(DDDLQualification.SelectedItem.Text=="Custom")
        {
            tx.Visible = true;
            tx.Focus();
            tx.Text = "";
            dl.Visible = false;
        }
    }
    public void cmbaddV1(DropDownList dl,TextBox tx)
    { 
        if(DDDLQualificationV1.SelectedItem.Text=="Custom")
        {
            tx.Visible = true;
            tx.Focus();
            tx.Text = "";
            dl.Visible = false;
        }
        
    }
    public void txtChangeV1(DropDownList ddl,TextBox tx)
    {
        string str1 = "insert into UserQualification(qualificationName)values('" + DDDLQualification.SelectedValue + "')";
        int row1 = cc.ExecuteNonQuery(str1);

        string str2 = "select qualificationId,qualificationName from UserQualification ";
        ds = cc.ExecuteDataset(str2);

      
        DDDLQualificationV1.DataSource = ds;
        DDDLQualificationV1.DataTextField = "qualificationName";
        DDDLQualificationV1.DataValueField = "qualificationId";
        DDDLQualificationV1.DataBind();
        DDDLQualificationV1.Items.Add("Custom");
        DDDLQualificationV1.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    public void txtChange(DropDownList ddl,TextBox tx)
    {
        string str = "insert into UserQualification(qualificationName)values('"+DDDLQualification.SelectedValue+"')";
        int row = cc.ExecuteNonQuery(str);

        string st = "select qualificationId,qualificationName from UserQualification ";
        ds = cc.ExecuteDataset(st);

        DDDLQualification.DataSource = ds;
        DDDLQualification.DataTextField = "qualificationName";
        DDDLQualification.DataValueField = "qualificationId";
        DDDLQualification.DataBind();

        DDDLQualification.Items.Insert(0,new ListItem("Select","0"));
        DDDLQualification.SelectedIndex = 0;

        ddl.Visible = true;
        tx.Visible = false;
    }
    protected void lnkBAddV1_Click(object sender, EventArgs e)
    {
        //MultiView1.Visible = true;
        //MultiView1.SetActiveView(View2);
        insertV1();
        clear();
    }
    protected void lnkBSubmitV1_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View1);
    }
    protected void lnkBSubmitV2_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View2);
    }
    protected void lnkBSubmitV3_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View3);
    }
    protected void lnkBSubmit_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View4);
    }
    public void insertV1()
    {
        string s;
        if(txtQualificationV1.Text!="")
        {
           s = txtQualificationV1.Text;
        }
        else 
        {
           s = DDDLQualificationV1.SelectedItem.Text;
        }
        string dt = cc.DateFormatStatus();
        string str = "insert into [Come2myCityDB].[come2mycity].[tbl_JEducation]([Qualification],[Specialization],[CollegeName],[YearPassout],[University],[Marks],[UserId],[EntryDate],[Keyword])values('" + s+
            "','" + DDLSpecializationV1.SelectedValue + "','" + txtInstNameV1.Text + "','" + txtYrPassoutV1.Text + "','" + ddlUniversityV1.SelectedValue + "','" + txtMarksV1.Text + "','" + Convert.ToString(Session["User"]) + "','" + dt + "','School')";
        int row = cc.ExecuteNonQuery(str);
        clear();
    }
    protected void lnkAddV2_Click(object sender, EventArgs e)
    {
        
        insertV2();
        clear();
    }
    public void insertV2()
    {
        string s1;
        if (txtQualificationV2.Text != "")
        {
            s1 = txtQualificationV2.Text;
        }
        else
        {
            s1 = DDDLQualificationV2.SelectedItem.Text;
        }
        string dt = cc.DateFormatStatus();
        string str = "insert into [Come2myCityDB].[come2mycity].[tbl_JEducation]([Qualification],[Specialization],[CollegeName],[YearPassout],[University],[Marks],[UserId],[EntryDate],[Keyword])values('" +s1 +
            "','" + DDLSpecializationV2.SelectedItem.Text + "','" + txtInstNameV2.Text + "','" + txtYrPassoutV2.Text + "','" + ddlUniversityV2.SelectedValue + "','" + txtMarksV2.Text + "','" + Convert.ToString(Session["User"]) + "','" + dt + "','12th')";
        int row1 = cc.ExecuteNonQuery(str);
        clear();
    }
    protected void lnkAddV3_Click(object sender, EventArgs e)
    {
        insertV3();
        clear();
    }
    public void insertV3()
    {
        //string s3;
        //if (txtQualificationV3.Text != "")
        //{
        //    s3 = txtQualificationV3.Text;
        //}
        //else
        //{
        //    s3 = DDDLQualificationV3.SelectedItem.Text;
        //}
        string dt = cc.DateFormatStatus();
        string str = "insert into [Come2myCityDB].[come2mycity].[tbl_JEducation]([Qualification],[DegName],[Specialization],[CollegeName],[YearPassout],[University],[Marks],[UserId],[EntryDate],[Keyword])values('" + txtQulif.Text +
            "','"+txtDName.Text+"','" + DDLSpecializationV3.SelectedValue + "','" + txtInstNameV3.Text + "','" + txtYrPassoutV3.Text + "','" + ddlUniversityV3.SelectedValue + "','" + txtMarksV3.Text + "','" + Convert.ToString(Session["User"]) + "','" + dt + "','Graduate')";
        int row2 = cc.ExecuteNonQuery(str);
        clear();
    }
     protected void lnkAddV4_Click(object sender, EventArgs e)
    {
        insertV4();
        clear();
    }
     protected void lnkAddS_Click(object sender, EventArgs e)
     { 
        
     }
     public void insertV4()
     {
         string s;
         if (txtQualification.Text != "")
         {
             s = txtQualification.Text;
         }
         else
         {
             s = DDDLQualification.SelectedItem.Text;
         }
         string dt = cc.DateFormatStatus();
         string str = "insert into [Come2myCityDB].[come2mycity].[tbl_JEducation]([Qualification],[DegName],[Specialization],[CollegeName],[YearPassout],[University],[Marks],[UserId],[EntryDate],[keyword])values('" + s +
           "','"+txtDName.Text+"','" + DDLSpecialization.SelectedValue + "','" + txtInstName.Text + "','" + txtYrPassout.Text + "','" + ddlUniversity.SelectedValue + "','" + txtMarks.Text + "','" + Convert.ToString(Session["User"]) + "','" + dt + "','PG')";
         int row = cc.ExecuteNonQuery(str);
         clear();
     }
    public void clear()
    {
        txtWExpM.Text = "";
        txtTExpYr.Text="";
        ddlUniversity.SelectedIndex = 0;
        
        DDLSpecialization.SelectedIndex = 0;
        
        ddlUniversity.SelectedIndex = 0;
        DDDLQualification.SelectedIndex = 0;
        txtInstName.Text = "";
        txtMarks.Text = "";
        CheckBoxList1.ClearSelection();
        txtYrPassoutV1.Text = "";
        txtInstNameV1.Text = "";
        txtMarksV1.Text = "";
        DDDLQualificationV1.SelectedIndex = 0;
        ddlUniversityV1.SelectedIndex = 0;
        DDLSpecializationV1.SelectedIndex = 0;
    }
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
    //protected void rbtnSchool_CheckedChanged(object sender, EventArgs e)
    //{
    //    //if (rbtnSchool.Checked == true)
    //    //{
    //    //    MultiView1.Visible = true;
    //    //    MultiView1.SetActiveView(View1);
    //    //    insertV1();
    //    //}
       
    //}
    //protected void rbtnCollege_CheckedChanged(object sender, EventArgs e)
    //{
    //    //if(rbtnCollege.Checked==true)
    //    //{
    //    //    MultiView1.Visible = true;
    //    //    MultiView1.SetActiveView(View2);
    //    //}
    //}
    //protected void rbtnGraduate_CheckedChanged(object sender, EventArgs e)
    //{
    //    //if(rbtnGraduate.Checked==true)
    //    //{
    //    //    MultiView1.Visible = true;
    //    //    MultiView1.SetActiveView(View3);
    //    //}
    //}
    //protected void rbtnPostGraduate_CheckedChanged(object sender, EventArgs e)
    //{
    //    //if(rbtnPostGraduate.Checked==true)
    //    //{
    //    //    MultiView1.Visible = true;
    //    //    MultiView1.SetActiveView(View4);
    //    //}
    //}

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckBoxList1.SelectedValue =="1" )
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View1);
        }
        else if(CheckBoxList1.SelectedValue=="2")
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View1);
            
            MultiView1.SetActiveView(View2);

        }
        else if(CheckBoxList1.SelectedValue=="3")
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View3);
        }
        else if(CheckBoxList1.SelectedValue=="4")
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(View4);
        }

    }
}
