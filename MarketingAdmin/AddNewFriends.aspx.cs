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

public partial class MarketingAdmin_AddNewFriends : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    CommonSqlQueryCode cqc = new CommonSqlQueryCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLObj = new FriendGroupBLL();
    BALMiscalRegistration objMiscalreg = new BALMiscalRegistration();


    string Id = "";
   
    int status;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadState();
        Id = Convert.ToString(Request.QueryString["id"]);
        LoadGroup();

    }
    private void LoadGroup()
    {
          string sql = "select GroupNo from MiscalGroup";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string Gname = Convert.ToString(ds.Tables[0].Rows[0]["GroupNo"]);
                    string[] tmp = Gname.Split(',');
                    foreach (string s in tmp)
                    {
                        cmbFriendGroup.Items.Add(s);
                        cmbFriendGroup.ID.Insert(0, s);
                    }
                }
                
    }
    private void LoadState()
    {   
        DataSet ds = new DataSet();
        try
        {
            ds = (DataSet)Session["Location"];
            if (ds == null)
            {
                Location loc = new Location();
                ds = loc.getAllLocation();
                Session["Location"] = ds;
            }
            if (ds.Tables[0] != null)
            {

                cmbState.DataSource = ds.Tables[0];
                cmbState.DataTextField = "StateName";
                cmbState.DataValueField = "StateId";
                cmbState.DataBind();
                cmbState.Items.Add("--Select--");
                cmbState.Items[cmbState.Items.Count - 1].Value = " ";
                cmbDistrict.Items.Add("--Select--");
                cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = " ";
                cmbCity.Items.Add("--Select--");
                cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";

                cmbState.SelectedIndex = cmbState.Items.Count - 1;
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    protected void cmbState_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = (DataSet)Session["Location"];
            if (cmbState.SelectedIndex != cmbState.Items.Count - 1)
            {
                if (ds.Tables[1] != null)
                {
                    DataRow[] dr = ds.Tables[1].Select("StateId=" + cmbState.SelectedValue.ToString() + "");
                    cmbDistrict.DataSource = getDataTable(dr);
                    cmbDistrict.DataTextField = "Name";
                    cmbDistrict.DataValueField = "Id";
                    cmbDistrict.DataBind();
                    cmbDistrict.Items.Add("--Select--");
                    cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = " ";
                    cmbDistrict.SelectedIndex = cmbDistrict.Items.Count - 1;
                }
            }
            else
            {
                cmbCity.Items.Clear();
                cmbDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        
    }
    protected void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = (DataSet)Session["Location"];
            if (cmbDistrict.SelectedIndex != cmbDistrict.Items.Count - 1)
            {
                if (ds.Tables[2] != null)
                {
                    DataRow[] dr = ds.Tables[2].Select("DistrictId=" + cmbDistrict.SelectedValue.ToString() + "");
                    cmbCity.DataSource = getDataTable(dr);
                    cmbCity.DataTextField = "Name";
                    cmbCity.DataValueField = "Id";
                    cmbCity.DataBind();
                    cmbCity.Items.Add("--Select--");
                    cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";
                    cmbCity.SelectedIndex = cmbCity.Items.Count - 1;
                }
            }
            else
            {
                cmbCity.Items.Clear();

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        FriendRelativeAdd();
        clearAddFriend();
    }
    private void FriendRelativeAdd()
    {
        try
        {
          string senderId = "myctin";
            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
            string friendid = urUserRegBLLObj.usrUserId;
            
            urUserRegBLLObj.usrMobileNo = Convert.ToString(txtMobileNumber.Text);
            string mymobile = urUserRegBLLObj.usrMobileNo;
            urUserRegBLLObj.usrAddress = Convert.ToString(txtAddress.Text);
            urUserRegBLLObj.usrFirstName = Convert.ToString(txtFirstName.Text);
            urUserRegBLLObj.usrLastName = Convert.ToString(txtLastName.Text);

            if (rdoCityLocation.SelectedItem.Value == "SC")
            {
                urUserRegBLLObj.usrCityId = Convert.ToInt32(Session["City"]);
                
            }
            else if (rdoCityLocation.SelectedItem.Value == "DC")
            {
                pnlSelectLocation.Visible = true;
                if (cmbCity.SelectedValue != null)
                {
                    urUserRegBLLObj.usrCityId = Convert.ToInt32(Convert.ToString(cmbCity.SelectedValue));
                    

                }
                else
                {
                    urUserRegBLLObj.usrCityId = Convert.ToInt32(Session["City"]);

                }

            }


            string gr = cmbFriendGroup.SelectedItem.Text;


            Random rnd = new Random();
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
            string pass = cc.DESDecrypt(urUserRegBLLObj.usrPassword);

            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);

            if (status == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User already Exists...')", true);
            }
            else
              {
                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);

                if (status > 0)
                {

                    string passwordMessage = "Dear " + txtFirstName.Text + ", Password for ur First Login is " + pass + " " + cc.AddSMS(txtMobileNumber.Text);
                    cc.SendMessageTra(senderId, mymobile, passwordMessage);
                   
                    cqc.frnrelFriendId = friendid;
                    cqc.frnrelUserId = Session["MarketingUser"].ToString();
                    //cqc.FR1 = "1";    //Not to add in personal group
                    //cqc.BLLInsertUserFriendRelative(cqc);
                    objMiscalreg.Friendid = friendid;
                    objMiscalreg.FriendName = txtFirstName.Text + "" + txtLastName.Text;
                    objMiscalreg.Groupno = gr;
                    objMiscalreg.Userid = Session["MarketingUser"].ToString();
                    objMiscalreg.BALInsertMiscalRegistration(objMiscalreg);
                    Response.Redirect("../MarketingAdmin/ReportMiscal.aspx");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Not added')", true);
                }
            }

            clearAddFriend();
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }

    public void clearAddFriend()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMobileNumber.Text = "";
        txtRelation.Text = "";
        txtAddress.Text = "";

    }

    protected void btnBackContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/ReportMiscal.aspx");
    }
}
