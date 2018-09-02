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

public partial class MarketingAdmin_UploadSchoolCode : System.Web.UI.Page
{

    CommonCode cc = new CommonCode();
    int status;
    int count = 1;
    string schoolcode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowRecord();
            SchoolCodeToatal();
        }
    }

    private void Addschoolcode()
    {
        try
        {
            if (File_schoolcode.HasFile)
            {
                string path = "";
                path = Server.MapPath("File_Upload");
                path = path + "\\" + File_schoolcode.FileName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                    File_schoolcode.SaveAs(path);
                }
                else
                {
                    File_schoolcode.SaveAs(path);
                }
                StreamReader sr = new StreamReader(path);
                string line = sr.ReadLine();
                // do
                //{

                while (line != null)
                {

                    line = sr.ReadLine();
                    string schoolName = "", mgmt = "", type = "", Lclasses = "", HClasses = "";

                    if (line != null)
                    {
                        string[] ArrLine = line.Split(',');
                        schoolcode = ArrLine[0];

                        if (schoolcode.Length == 11 && schoolcode != "")
                        {

                            schoolName = ArrLine[1];
                            mgmt = ArrLine[2];
                            type = ArrLine[3];
                            Lclasses = ArrLine[4];
                            HClasses = ArrLine[5];

                            AddUDISE_SCHOOL(schoolcode, schoolName, mgmt, type, Lclasses, HClasses);  //For EO

                        }
                        else
                        {
                            count = count + 1;
                            lblError.Visible = true;
                            lblError.Text = lblError.Text + "<br/> Please Enter Proper school Code - Error on Rows No " + count + " ";
                            break;
                        }

                    }
                    else
                    {
                        Response.Write("<script>(alert)('School Code Upload Succsessfully.')</script>");

                    }
                    count = count + 1;

                    //} while (line != null);
                }
            }
        }
        catch (Exception ex)
        {
            count = count + 1;
            lblError.Visible = true;
            lblError.Text = lblError.Text + "<br/> Please Enter Proper school Code - Error on Rows No " + count + " " + schoolcode + "  ";

        }
    }

    public void AddUDISE_SCHOOL(string SchoolCode, string SchoolName, string Mgmt, string Type, string ClassL, string ClassH)
    {
        try
        {
            string CheckCode = "select SchoolId from UDISE_SchoolMaster where SchoolCode='" + SchoolCode + "'";
            status = cc.ExecuteScalar1(CheckCode);
            if (!(status == null || status == 0))
            {
                string str = "Update  UDISE_SchoolMaster  set SchoolName='" + SchoolName + "',Management='" + Mgmt + "',SchoolType='" + Type + "',LowClass=" + ClassL + ", HighClass=" + ClassH + " where SchoolCode='" + SchoolCode + "'";
                status = cc.ExecuteNonQuery(str);

            }
            else
            {

                string str = "insert into UDISE_SchoolMaster " +
                        "(SchoolCode,SchoolName,Management,SchoolType,LowClass,HighClass)values" +
                        "('" + SchoolCode + "','" + SchoolName + "','" + Mgmt + "','" + Type + "'," + ClassL + "," + ClassH + ")";
                status = cc.ExecuteNonQuery(str);
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }
    protected void gvschoolcode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvschoolcode.PageIndex = e.NewPageIndex;
        ShowRecord();
    }
    protected void gvschoolcode_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnsave_Click1(object sender, EventArgs e)
    {
        Addschoolcode();
    }

    public void ShowRecord()
    {
        try
        {
            string SQl = "select * from UDISE_SchoolMaster ";
            DataSet ds = cc.ExecuteDataset(SQl);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvschoolcode.DataSource = ds.Tables[0];
                gvschoolcode.DataBind();
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void btndownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/File_Upload/School Code CSV Format.csv");
    }

    public void SchoolCodeToatal()
    {
        try
        {
            string Sql = "Select Count(*) from UDISE_SchoolMaster ";
            string TotalSchool = Convert.ToString(cc.ExecuteScalar(Sql));
            if (TotalSchool != "" || TotalSchool != null)
            {
                lblSchool.Text = Convert.ToString(TotalSchool);
            }

        }
        catch (Exception ex)
        { }
    }
}
