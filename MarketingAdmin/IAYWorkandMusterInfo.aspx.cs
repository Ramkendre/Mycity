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

public partial class MarketingAdmin_IAYWorkandMusterInfo : System.Web.UI.Page
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
                cmd.Parameters.AddWithValue("@DtoWorkStart", txtDoWorkStart.Text);
                cmd.Parameters.AddWithValue("@upldFirstPhoto", "0");
                cmd.Parameters.AddWithValue("@FirstMusterDt", txtFirstMusterDt.Text);
                cmd.Parameters.AddWithValue("@FirstMusterNo", txtFirstMusterNo.Text);
                cmd.Parameters.AddWithValue("@secondMusterDt", txtSecondMusterDt.Text);
                cmd.Parameters.AddWithValue("@SecondMusterNo", txtSecondMusterNo.Text);
                cmd.Parameters.AddWithValue("@LwrkCompleteDt", txtLwrkCompleteDt.Text);
                cmd.Parameters.AddWithValue("@upldSecondPhoto", "0");
                cmd.Parameters.AddWithValue("@ThirdMusterDt", txtThirdMusterDt.Text);
                cmd.Parameters.AddWithValue("@ThirdMusterNo", txtThirdMusterNo.Text);                
                cmd.Parameters.AddWithValue("@FourthMusterDt", txtFourthMusterDt.Text);
                cmd.Parameters.AddWithValue("@FourthMusterNo", txtFourthMusterNo.Text);
                cmd.Parameters.AddWithValue("@WorkCompleteDt", txtWorkCompleteDt.Text);
                cmd.Parameters.AddWithValue("@upldThirdPhoto", "0");
                cmd.Parameters.AddWithValue("@BPID", ddlBeneficiary.SelectedValue);
                cmd.Parameters.AddWithValue("@UserId", usrMobileNo1);

                cmd.CommandText = "uspIAYWorkandMusterInfo";
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
        string sqlQuery = "SELECT [IAYWMI_Id],[WMI_DTotWS],[WMI_UpldFirstPhoto],[WMI_FirstMusterDt],[WMI_FirstMusterNo],[WMI_SecondMusterDt],[WMI_SecondMusterNo],[WMI_LWCompleteDt],[WMI_UpldSecondPhoto],[WMI_ThirdMusterDt],[WMI_ThirdMusterNo],[WMI_FourthMusterDt],[WMI_FourthMusterNo],[WMI_WCompleteDt],[WMI_UpldThirdPhoto],[IAYP_Id],[CreatedBy],[CreatedDate] FROM [Come2myCityDB].[come2mycity].[tbl_IAYWorkMusterInfo]";
        DataTable dt = objStateDal.GetRecordsIAY(sqlQuery);

        if (dt.Rows.Count > 0)
        {
            gvMusterDetails.DataSource = dt;
            gvMusterDetails.DataBind();
        }
        else
        {
            gvMusterDetails.EmptyDataText = "NO RECORDS FOUND..!!!";
            gvMusterDetails.DataBind();
        }
    }
}
