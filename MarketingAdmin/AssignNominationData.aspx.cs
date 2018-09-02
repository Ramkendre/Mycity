using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ClosedXML.Excel;

public partial class MarketingAdmin_AssignNominationData : System.Web.UI.Page
{
       string Sql = string.Empty;
       //SqlConnection conmyct = new SqlConnection("server=52.172.181.246,1433;Initial Catalog=TrueVoterDB;User id=truevoter;Password=myabhinavit@123;");
 SqlConnection conmyct = new SqlConnection("server=103.10.191.60;Initial Catalog=TrueVoterDB;User id=sa;Password=K17jyjo8/T+6z2v;");
        SqlCommand cmd = new SqlCommand(); DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        CommonCode cc=new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDistrict();
            }
        }

        public void BindGridView()
        {
            try
            {
                Sql = "select top 70 [Id],[FirstName],[MiddleName],[LastName],[RegMobileNo],[DistrictId],[DistrictName],[LocalBodyName],[pin],[formtype],[electrolDivision],[RegMobileNo],[Assign_Represenatative],[Address] from [SEC_TV].[dbo].[tblRegistrationSECNEW] where [DistrictId]='" + ddldistrict.SelectedValue + "' and [pin]='" + ddlpincode.SelectedValue + "' AND Assign_Represenatative IS NULL";
                da = new SqlDataAdapter(Sql, conmyct);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);

                AssignNominationGv.DataSource = ds1.Tables[0];
                AssignNominationGv.DataBind();

                lblCount.Text = ds1.Tables[0].Rows.Count.ToString();
                lbltotalCount.Visible = true;
                lblCount.Visible = true;
            }
            catch
            {

            }
        }

        public void BindGridView11()
        {
            try
            {
                Sql = "select top 70 [Id],[FirstName],[MiddleName],[LastName],[RegMobileNo],[DistrictId],[DistrictName],[LocalBodyName],[pin],[formtype],[electrolDivision],[RegMobileNo],[Assign_Represenatative],[Address] from [SEC_TV].[dbo].[tblRegistrationSECNEW] where [DistrictId]='" + ddldistrict.SelectedValue + "' and Assign_Represenatative='" + ddlRepresentative.SelectedValue + "'";
                da = new SqlDataAdapter(Sql, conmyct);
                DataSet ds11 = new DataSet();
                da.Fill(ds11);

                 GridView1.DataSource = ds11.Tables[0];
                  GridView1.DataBind();
            }
            catch
            {

            }
        }

        public void BindDistrict()
        {
            Sql = "Select [DistrictCode],[DistrictName] from [tblDistrictMapping]";
            da = new SqlDataAdapter(Sql, conmyct);
            da.Fill(ds);

            ddldistrict.DataSource = ds.Tables[0];
            ddldistrict.DataTextField = "DistrictName";
            ddldistrict.DataValueField = "DistrictCode";
            ddldistrict.DataBind();
            ddldistrict.Items.Add("--Select--");
            ddldistrict.SelectedIndex = ddldistrict.Items.Count - 1;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MsgSec msgsec = new MsgSec();
            string GvSno = string.Empty;
            try
            {
                if (ddldistrict.SelectedItem.Text == "--Select--")
                {
                    lblError.Text = "Please Select Class Name";
                    lblError.Visible = true;
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select District Name')</script>");
                }
                else if (ddlRepresentative.SelectedItem.Text == "--Select--")
                {
                    lblError.Text = "Please Select Type Of Exam Name";
                    lblError.Visible = true;
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Please Select Representative Name')</script>");
                }
                  DataSet dsmyct = new DataSet();
                
                 {
                     for (int i = 0; i < AssignNominationGv.Rows.Count; i++)
                     {
                         CheckBox chk = (CheckBox)AssignNominationGv.Rows[i].Cells[0].FindControl("ChkAssignNomination");

                         if (chk != null)
                         {
                             if (chk.Checked == true)
                             {
                                 GvSno +=  Convert.ToString(AssignNominationGv.DataKeys[i].Value) + "','";
                             }
                         }
                         chk.Checked = false;
                     }

                     if (GvSno == "")
                     {
                         ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select atleast one Record !!!');", true);
                     }
                     else
                     {
                         if (GvSno != "")
                         {
                             GvSno = GvSno.Substring(0, GvSno.Length - 2);
                         }

                         string SQL = "select [FirstName],[RegMobileNo],[LastName] from [SEC_TV].[dbo].[tblRegistrationSECNEW] where [RegMobileNo] IN('" + GvSno + ")";
                         da = new SqlDataAdapter(SQL, conmyct);
                         da.Fill(dsmyct);

                         string sql = "select [JuniorName],[JuniorMobNo] from [EzeeMarketingHierarchy] where [JuniorMobNo]='" + ddlRepresentative.SelectedValue + "'";
                         DataSet dss = new DataSet();
                         dss = cc.ExecuteDataset(sql);

                         Sql = "Update [SEC_TV].[dbo].[tblRegistrationSECNEW] set [Assign_Represenatative]='" + ddlRepresentative.SelectedValue + "' where [RegMobileNo] IN('" + GvSno + ")";
                         cmd = new SqlCommand(Sql, conmyct);
                         conmyct.Open();
                         cmd.ExecuteNonQuery();
                         conmyct.Close();

                         for (int i = 0; i < dsmyct.Tables[0].Rows.Count; i++)
                         {
                            string Msg = "Sir/Madam " + dsmyct.Tables[0].Rows[i]["FirstName"].ToString() + " "+" " + dsmyct.Tables[0].Rows[i]["LastName"].ToString() + " for installation of TRUE VOTER app and to get advantages of further facilities of the app ur area coordinator is " + dss.Tables[0].Rows[0]["JuniorName"].ToString() + " "+" " + dss.Tables[0].Rows[0]["JuniorMobNo"].ToString() + " u can call him for personal level onetime support";
                             msgsec.SMS_SEC(Convert.ToString(dsmyct.Tables[0].Rows[i]["RegMobileNo"]), Msg);
                         }

                         lblError.Text = "Assign Successfully";
                         lblError.Visible = true;

                         BindGridView();
                     }
                 }
            }
            catch
            {

            }
        }

        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sql = "Select [JuniorMobNo],[JuniorName],[usrMobileNo],[DistrictId] from [EzeeMarketingHierarchy] where [usrMobileNo]='" + Session["MobileNumber"].ToString() + "'";
            ds=cc.ExecuteDataset(Sql);
           
            ddlRepresentative.DataSource = ds.Tables[0];
            ddlRepresentative.DataTextField = "JuniorName";
            ddlRepresentative.DataValueField = "JuniorMobNo";
            ddlRepresentative.DataBind();
            ds.Clear();
            ddlRepresentative.Items.Add("--Select--");
            ddlRepresentative.SelectedIndex = ddlRepresentative.Items.Count - 1;

            Sql = "Select DISTINCT(pin) from [SEC_TV].[dbo].[tblRegistrationSECNEW] where [DistrictId]='" + ddldistrict.SelectedValue + "'";
            da = new SqlDataAdapter(Sql, conmyct);
            da.Fill(ds);
           
            ddlpincode.DataSource = ds.Tables[0];
            ddlpincode.DataTextField = "pin";
            ddlpincode.DataValueField = "pin";
            ddlpincode.DataBind();
            ddlpincode.Items.Add("--Select--");
            ddlpincode.SelectedIndex = ddlpincode.Items.Count - 1;
            
        }

        protected void ddlRepresentative_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sql = "Select [JuniorMobNo],[JuniorName] from [EzeeMarketingHierarchy] where [JuniorMobNo]='" + ddlRepresentative.SelectedValue + "'";
            ds = cc.ExecuteDataset(Sql);

            lbljrName.Text = ds.Tables[0].Rows[0]["JuniorMobNo"].ToString();
            lbljrName.Visible = true;

           BindGridView11();
        }

        protected void AssignNominationGv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AssignNominationGv.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

            string sql = string.Empty; DataSet dtset = new DataSet();
            try
            {

                string excelFileName = "NominationData.xls";

                sql = "select Top 1000 [Id],[FirstName],[MiddleName],[LastName],[RegMobileNo],[DistrictId],[DistrictName],[LocalBodyName],[pin],[formtype],[electrolDivision],[RegMobileNo],[Assign_Represenatative],[Address]" +
                      "from [SEC_TV].[dbo].[tblRegistrationSECNEW]  where [DistrictId]='" + ddldistrict.SelectedValue + "' and [Assign_Represenatative]='" + ddlRepresentative.SelectedValue + "'";
                da = new SqlDataAdapter(sql, conmyct);
                da.Fill(dtset);
                GridView1.DataSource = dtset.Tables[0];
                GridView1.DataBind();

                Response.AddHeader("content-disposition", "attachment; filename ='" + excelFileName + "'");
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);

                GridView1.RenderControl(hTextWriter);

                Response.Write(sWriter.ToString());
                Response.End();

            }
            catch
            {

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView11();
        }

        protected void ddlpincode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
}