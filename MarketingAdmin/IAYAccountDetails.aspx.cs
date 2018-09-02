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

public partial class MarketingAdmin_IAYAccountDetails : System.Web.UI.Page
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
                cmd.Parameters.AddWithValue("@FirstInstallment", txtFirstInstallment.Text);
                cmd.Parameters.AddWithValue("@FirstInstallmentDt", txtFirstInstallmentDt.Text);
                cmd.Parameters.AddWithValue("@SecondInstallment", txtSecondInstallment.Text);
                cmd.Parameters.AddWithValue("@SecondInstallmentDt", txtSecondInstallmentDt.Text);
                cmd.Parameters.AddWithValue("@ThirdInstallment", txtThirdInstallment.Text);
                cmd.Parameters.AddWithValue("@ThirdInstallmentDt", txtThirdInstallmentDt.Text);
                cmd.Parameters.AddWithValue("@BPID", ddlBeneficiary.SelectedValue);
                cmd.Parameters.AddWithValue("@UserId", usrMobileNo1);

                cmd.CommandText = "uspIAYAccountData";
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
        string sqlQuery = "SELECT [IAYA_Id],[FirstInstallmentRs],[FirstInstallmentDt],[SecondInstallmentRs],[SecondInstallmentDt],[ThirdInstallmentRs],[ThirdInstallmentDt],[IAYP_Id],[CreatedBy],[CreatedDate] FROM [Come2myCityDB].[come2mycity].[tbl_IAYAccountDetails]";
        DataTable dt = objStateDal.GetRecordsIAY(sqlQuery);

        if (dt.Rows.Count > 0)
        {
            gvDispAccDetails.DataSource = dt;
            gvDispAccDetails.DataBind();
        }
        else
        {
            gvDispAccDetails.EmptyDataText = "NO RECORDS FOUND..!!!";
            gvDispAccDetails.DataBind();
        }
    }
}
