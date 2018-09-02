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

public partial class MarketingAdmin_IAYTechnicalDetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string usrMobileNo1 = "9158696413";
    StateDAL objStateDal = new StateDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            usrMobileNo1 = Convert.ToString(Session["MarketingUser"]);
            BindGridDetails();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {        
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@assiEngName", txtlayoutbyAsstEng.Text);
                cmd.Parameters.AddWithValue("@layoutDt", txtLayoutDt.Text);
                cmd.Parameters.AddWithValue("@upldFirstPhoto", "0");
                cmd.Parameters.AddWithValue("@assiVisitDt", txtAsstEngVisitDt.Text);
                cmd.Parameters.AddWithValue("@upldSecondPhoto", "0");
                cmd.Parameters.AddWithValue("@comcerDt", txtCompletionCertDt.Text);
                cmd.Parameters.AddWithValue("@upldThirdPhoto", "0");
                cmd.Parameters.AddWithValue("@BPID", ddlBeneficiary.SelectedValue);
                cmd.Parameters.AddWithValue("@UserId", usrMobileNo1);

                cmd.CommandText = "uspIAYTechnicalData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                if (cmd.Connection.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                lblResult.Text = "Record Added Successfully...!!!";
                BindGridDetails();
            }
        }
    }

    public void BindGridDetails()
    {
        string sqlQuery = "SELECT [IAYT_Id],[Tech_LayoutAsstEngName],[Tech_LayoutDt],[Tech_UpldFirstPhoto],[Tech_DtAsstEngVisit],[Tech_UpldSecondPhoto],[Tech_CompleteCertDt],[Tech_UpldThirdPhoto],[IAYP_Id],[CreatedBy],[CreatedDate] FROM [Come2myCityDB].[come2mycity].[tbl_IAYTechnicalData]";
        DataTable dt = objStateDal.GetRecordsIAY(sqlQuery);

        if (dt.Rows.Count > 0)
        {
            gvTechnicalDetails.DataSource = dt;
            gvTechnicalDetails.DataBind();
        }
        else
        {
            gvTechnicalDetails.EmptyDataText = "NO RECORDS FOUND..!!!";
            gvTechnicalDetails.DataBind();
        }
    }
}
