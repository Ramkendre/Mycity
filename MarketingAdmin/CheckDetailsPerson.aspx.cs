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

public partial class MarketingAdmin_CheckDetailsPerson : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string FullName = "";
    string RegMobileUserId = "", SchoolCode="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = true;
        LoadData();
        TreeDemo();
        

    }
    protected void btnSchoolDetails_Click(object sender, EventArgs e)
    {
        ChkSchoolCode();
    }
    public void ChkSchoolCode()
    {
        clear();
        Panel2.Visible = true;
        Panel1.Visible = false;
        string Sql = "Select SchoolCode from UDISE_SchoolMaster where SchoolCode='" + txtSchoolCode.Text + "' ";
        lblSchoolCode.Text = Convert.ToString(cc.ExecuteScalar(Sql));
        if (lblSchoolCode.Text == "")
        {
            lblSchoolCode.Text = "Not Register";
        }
        else
        {
            Sql = "Select SchoolName from UDISE_SchoolMaster where SchoolCode='" + lblSchoolCode.Text + "'";
            lblSchoolName.Text = Convert.ToString(cc.ExecuteScalar(Sql));
            if (lblSchoolName.Text == "")
            {
                lblSchoolName.Text = "Not Register";
            }
        }
    }

    public void clear()
    {
        lblRoleName.Text = "";
        lblSchoolCode.Text = "";
        lblSchoolName.Text = "";
        lblPassword.Text = "";
        lblTeachMaster.Text = "";
    }

    public void LoadData()
    {
        try
        {
            clear();
            lblError.Text = "";
            if (txtMobileNo.Text == "")
            {

            }
            else
            {
                string Sql = "Select usrUserId from UserMaster where usrMobileNo='" + txtMobileNo.Text + "'";
                RegMobileUserId = Convert.ToString(cc.ExecuteScalar(Sql));
                if (RegMobileUserId != "")
                {
                    GetData(RegMobileUserId);
                    LblFullName.Text = FullName;

                    Sql = "Select RoleName from [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser where friendid='" + RegMobileUserId + "'";
                    lblRoleName.Text = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (lblRoleName.Text == "")
                    {
                        lblRoleName.Text = "Not Register";
                    }
                    
                    Sql = "Select SchoolCode from UDISE_TeacherMaster where junior_id='" + RegMobileUserId + "' and Class='' ";
                    SchoolCode = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (SchoolCode == "")
                    {

                        lblTeachMaster.Text = "No";
                        lblSchoolCode.Text = "Not Register";

                    }
                    else
                    {
                        lblTeachMaster.Text = "Yes";
                        Sql = "Select SchoolCode from UDISE_SchoolMaster where SchoolCode='" + SchoolCode + "' ";
                        lblSchoolCode.Text = Convert.ToString(cc.ExecuteScalar(Sql));
                        if (lblSchoolCode.Text == "")
                        {
                            lblSchoolCode.Text = "Not Register";
                        }
                        else
                        {
                            Sql = "Select SchoolName from UDISE_SchoolMaster where SchoolCode='" + lblSchoolCode.Text + "'";
                            lblSchoolName.Text = Convert.ToString(cc.ExecuteScalar(Sql));
                            if (lblSchoolName.Text == "")
                            {
                                lblSchoolName.Text = "Not Register";
                            }
                        }
                    }
                    Sql = "Select usrPassword from UserMaster where usrUserId='" + RegMobileUserId + "' ";
                    string Password = Convert.ToString(cc.ExecuteScalar(Sql));
                    if (Password != "")
                    {
                        lblPassword.Text = Convert.ToString(cc.DESDecrypt(Password));
                    }
                    else
                    {
                        lblPassword.Text = "Not Register";
                    }
                }
                else { lblError.Text = "This Mobile No is Not Register on Myct"; }

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

    }
    public void ClearLabel()
    {
        lblSecretary.Text = "";
        lblDeptySec.Text = "";
        lblDirectorEdu.Text = "";
        lblDeputyDir.Text = "";
        lblEducationOff.Text = "";
        lblDeputyOff.Text = "";
        lblBlockOff.Text = "";
        lblExtentionOff.Text = "";
        lblClusterHea.Text = "";
        lblHeadMas.Text = "";
    }

    public void TreeDemo()
    {
        ClearLabel();
        string Sql = "SELECT userid,roleid,rolename,friendid,doj,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 " +
                     " FROM [Come2myCityDB].[come2mycity].[AdminSubMarketingSubUser] where Friendid ='" + RegMobileUserId + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Secretary = Convert.ToString(ds.Tables[0].Rows[0]["reference_id2"]);
            if (Secretary != "")
            {
                GetData(Secretary);
                lblSecretary.Text = FullName;
            }
            string DeptySec = Convert.ToString(ds.Tables[0].Rows[0]["reference_id3"]);
            if (DeptySec != "")
            {
                GetData(DeptySec);
                lblDeptySec.Text = FullName;
            }
            string DirectorEdu = Convert.ToString(ds.Tables[0].Rows[0]["reference_id4"]);
            if (DirectorEdu != "")
            {
                GetData(DirectorEdu);
                lblDirectorEdu.Text = FullName;
            }
            string DeputyDir = Convert.ToString(ds.Tables[0].Rows[0]["reference_id5"]);
            if (DeputyDir != "")
            {
                GetData(DeputyDir);
                lblDeputyDir.Text = FullName;
            }
            string EducationOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id6"]);
            if (EducationOff != "")
            {
                GetData(EducationOff);
                lblEducationOff.Text = FullName;
            }
            string DeputyOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id7"]);
            if (DeputyOff != "")
            {
                GetData(DeputyOff);
                lblDeputyOff.Text = FullName;
            }
            string BlockOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id8"]);
            if (BlockOff != "")
            {
                GetData(BlockOff);
                lblBlockOff.Text = FullName;
            }
            string ExtentionOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id9"]);
            if (ExtentionOff != "")
            {
                GetData(ExtentionOff);
                lblExtentionOff.Text = FullName;
            }
            string ClusterHea = Convert.ToString(ds.Tables[0].Rows[0]["reference_id10"]);
            if (ClusterHea != "")
            {
                GetData(ClusterHea);
                lblClusterHea.Text = FullName;
            }
            string HeadMas = Convert.ToString(ds.Tables[0].Rows[0]["reference_id11"]);
            if (HeadMas != "")
            {
                GetData(HeadMas);
                lblHeadMas.Text = FullName;
            }
            string HeadName = Convert.ToString(ds.Tables[0].Rows[0]["Friendid"]);
            if (HeadMas != "")
            {
                GetData(HeadMas);
                lblHeadMas.Text = FullName;
            }
        }
    }
    public void GetData(string UserId)
    {
        FullName = "";
        string Sql = "Select usrFirstName, usrLastName from UserMaster where usrUserId='" + UserId + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string FirstName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
            string LastName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
            FullName = FirstName + " " + LastName;
        }
    }

    
}
