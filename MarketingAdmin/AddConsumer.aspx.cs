using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_AddConsumer : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();

    public int status;
    public string showMobile;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }
    }

    public void ShowContact(string userid)
    {
        try
        {
            urUserRegBLLObj.usrUserId = userid;
            ds = urUserRegBLLObj.BLLGetUserContactInfo(urUserRegBLLObj);

            gvContactDisplay.DataSource = ds.Tables[0];
            gvContactDisplay.DataBind();

            showMobile = Convert.ToString(ds.Tables[0].Rows[0]["usrControlMobileNo"]);
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtMobileNo.Text != "")
        {
            string Sql = "Select UsrUserId from UserMaster where usrMobileNo='" + txtMobileNo.Text.ToString() + "'";
            string UserId = Convert.ToString(cc.ExecuteScalar(Sql));
            if (UserId == "")
            {
                lblError.Text = "This Mobile no is not exist";
                lblError.Visible = true;
                ViewState["User"] = "";
            }
            else
            {
                ShowContact(UserId);
                lblError.Visible = false;
                ViewState["User"] = UserId;
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtConsumer.Text != "")
        {
            string Sql = "Select ConsumerNo from UserConsumer where ConsumerNo='" + txtConsumer.Text.ToString() + "'";
            string Data = cc.ExecuteScalar(Sql);
            if (Data != "")
            {
                lblConsumerError.Visible = true;
                lblConsumerError.Text = "This no is already exist";
            }
            else
            {
                Sql = "";
                //Data = cc.ExecuteScalar(Sql);
                Data = "1";
                if (Data == "")
                {
                    lblConsumerError.Visible = true;
                    lblConsumerError.Text = "This no is not a consumer no";
                }
                else
                {
                    int flag = 0;
                    for (int i = 0; i <= lstConsumer.Items.Count - 1; i++)
                    {
                        if (lstConsumer.Items[i].Value.ToString() == txtConsumer.Text.ToString())
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        lstConsumer.Items.Add(txtConsumer.Text.ToString());
                    }
                }


            }
            txtConsumer.Text = "";
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            int i = lstConsumer.SelectedIndex;
            lstConsumer.Items.RemoveAt(i);
        }
        catch { }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sql = "";
        string UserId = Convert.ToString(ViewState["User"]);
        if (UserId == "")
        {
            lblError.Visible = true;
            lblError.Text = " This Mobile no is not exist.";
        }
        else
        {
            foreach (ListItem lst in lstConsumer.Items)
            {

                string id = lst.Value.ToString();
                sql = sql + " Insert into MarketingRecord( UserId, MarketingId, RecordDate,Type) Values " +
                     " ('" + UserId + "','" + Session["User"] + "','" + System.DateTime.Now + "','C' ) ";

                sql = sql + " Insert into UserConsumer (UserId,ConsumerNo) Values ('" + UserId + "','" + id + "' )";
            }
            try
            {
                int flag = cc.ExecuteNonQuery(sql);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Consumer No Added')", true);
                Response.Redirect("AddConsumer.aspx");
            }
            catch { }
            ViewState["User"] = "";
        }
    }
}
