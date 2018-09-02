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

public partial class MarketingAdmin_LongCodeRegistration : System.Web.UI.Page
{
    DataCollectionBLL bllobjdatacollection = new DataCollectionBLL();
    UserRegistrationBLL blluserregister = new UserRegistrationBLL();
    int status;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Longcodegridshow();
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Convert.ToString(lblId.Text.ToString());

            if (Id == "" || Id == null)
            {
                Insert();
            }
            else
            {

                UpdateRecord(Id);
            }
        }
        catch { }


    }
    private void Insert()
    {
        try
        {
            string mobileno = txtContactNo.Text;
            blluserregister.Customermobileno = mobileno.ToString();
            int status = blluserregister.BLLSearchUserExist(blluserregister);
            if (status == 1)
            {
                InsertLongCodeRegistration();
            }
            else
            {
                Response.Write("<script>(alert)('This number is not registered to myct, Plz register first..!!')</script>");
            }

        }
        catch (Exception ex)
        {

        }
    }
    private void clearAll()
    {

        txtCustomerName.Text = "";
        txtCustomeraddress.Text = "";
        txtmobileno.Text = "";
        txtsimno.Text = "";
        txtContactNo.Text = "";
        txtIMINo.Text = "";
        //txtMessage.Text = "";
        lblmisscalltype.Visible = false;
        txtContactNo2.Text = "";
        txtContactNo3.Text = "";
        txtContactNo4.Text = "";
        txtContactNo5.Text = "";
        lblId.Text = "";
    }

    private void InsertLongCodeRegistration()
    {
        try
        {
            if (rblText.SelectedItem.Text == "")
            {
                lblmisscalltype.Visible = true;
                Response.Write("<script>alert('Please Select Miss Call Type..!')</script>");
            }
            else
            {

                bllobjdatacollection.No_usefor = rdbUserfor.SelectedItem.Value;
                bllobjdatacollection.Customername = txtCustomerName.Text;
                bllobjdatacollection.Address = txtCustomeraddress.Text;
                bllobjdatacollection.Customer_contact = txtmobileno.Text;
                bllobjdatacollection.SIMno = txtsimno.Text;
                bllobjdatacollection.Mobileno = txtContactNo.Text;
                string sql = "select usrUserid from usermaster where usrMobileNo='" + txtContactNo.Text + "'";
                string userid = cc.ExecuteScalar(sql);
                bllobjdatacollection.IMEIMO = txtIMINo.Text;
                bllobjdatacollection.Send_data = ddlsenddata.SelectedValue;
                bllobjdatacollection.Regdate = DateTime.Now.ToString();
                bllobjdatacollection.MissCallType1 = Convert.ToString(rblText.SelectedItem.Text);
                //bllobjdatacollection.ResponseMsg = txtMessage.Text;
                bllobjdatacollection.Customer_contact1 = txtContactNo2.Text;
                bllobjdatacollection.Customer_contact2 = txtContactNo3.Text;
                bllobjdatacollection.Customer_contact3 = txtContactNo4.Text;
                bllobjdatacollection.Customer_contact4 = txtContactNo5.Text;

                status = bllobjdatacollection.BLLInsertLongCodeRegistration(bllobjdatacollection);

                if (status == 1)
                {
                    string sql1 = "update [Come2myCityDB].[come2mycity].LongCodeRegistration set UsrUserid='" + userid + "' where IMEINO='" + txtIMINo.Text + "' and Sim_no='" + txtsimno.Text + "' and mobileno='" + txtContactNo.Text + "'";
                    string a = cc.ExecuteScalar(sql1);
                    Longcodegridshow();
                    Response.Write("<script>alert('Record Inserted Successfully')</script>");

                }
                else
                {
                    Longcodegridshow();
                    Response.Write("<script>alert('Record Not Inserted ')</script>");
                }
                clearAll();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Longcodegridshow()
    {
        DataSet ds = bllobjdatacollection.BLLGetLongCodeInfo(bllobjdatacollection);
        gvLongCodeshow.DataSource = ds.Tables[0];
        gvLongCodeshow.DataBind();

    }
    protected void gvLongCodeshow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Delete")
        {
            string Sql = "Select Sim_no from [Come2myCityDB].[come2mycity].LongCodeRegistration where reg_id=" + Id + "";//ketan
            string SimNo = Convert.ToString(cc.ExecuteScalar(Sql));

            bllobjdatacollection.Regid = Convert.ToInt32(Id);
            status = bllobjdatacollection.BLLDeleteLongCode(bllobjdatacollection);
            if (status == 1)
            {
                Sql = "Update [Come2myCityDB].[come2mycity].MiscalResponse set Msg_Status='Deactive' where mobileno='" + SimNo + "'";//ketan
                int i = cc.ExecuteNonQuery(Sql);


                if (i > 1)
                {
                    Response.Write("<script>alert('Record deleted successfully')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Record not deleted ')</script>");
            }
            Longcodegridshow();
        }
        else if (Convert.ToString(e.CommandName) == "Edit")
        {
            string sql = "select * from LongCodeRegistration where reg_id='" + Id + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            rdbUserfor.SelectedItem.Value = Convert.ToString(ds.Tables[0].Rows[0]["no_usefor"]);
            txtCustomerName.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_name"]);
            txtCustomeraddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
            txtmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_contact"]);
            txtsimno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sim_no"]);
            txtContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
            txtIMINo.Text = Convert.ToString(ds.Tables[0].Rows[0]["IMEINO"]);
            ddlsenddata.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["send_data"]);
            //txtMessage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Response_Msg"]);
            rdbUserfor.Enabled = false;
            txtCustomerName.Enabled = false;
            txtCustomeraddress.Enabled = false;
            txtmobileno.Enabled = false;
            txtsimno.Enabled = false;
            txtContactNo.Enabled = false;
            txtIMINo.Enabled = false;
            ddlsenddata.Enabled = false;
        }
        else if (Convert.ToString(e.CommandName) == "Modify")
        {
            try
            {
                string Sql = "SELECT  customer_name,address,mobileno,Sim_no,IMEINO,customer_contact,no_usefor,send_data,MissCallType,customer_contact1, " +
                    "customer_contact2,customer_contact3,customer_contact4 FROM [Come2myCityDB].[come2mycity].LongCodeRegistration where reg_id='" + Id + "'";
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomerName.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_name"]);
                    txtCustomeraddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                    txtmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                    txtsimno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sim_no"]);
                    txtIMINo.Text = Convert.ToString(ds.Tables[0].Rows[0]["IMEINO"]);
                    txtContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_contact"]);
                    rdbUserfor.SelectedItem.Value = Convert.ToString(ds.Tables[0].Rows[0]["no_usefor"]);
                    ddlsenddata.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["send_data"]);
                    //Convert.ToString(ds.Tables[0].Rows[0]["Response_Msg"]);
                    string MisscallType = Convert.ToString(ds.Tables[0].Rows[0]["MissCallType"]);
                    if (MisscallType == "Single")
                    { rblText.SelectedValue = "1"; }
                    else { rblText.SelectedValue = "2"; }
                    txtContactNo2.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_contact1"]);
                    txtContactNo3.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_contact2"]);
                    txtContactNo4.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_contact3"]);
                    txtContactNo5.Text = Convert.ToString(ds.Tables[0].Rows[0]["customer_contact4"]);
                    btnSubmit.Text = "Modify";
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
    protected void gvLongCodeshow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLongCodeshow.PageIndex = e.NewPageIndex;
        Longcodegridshow();
    }
    protected void gvLongCodeshow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void ddlsenddata_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsenddata.SelectedValue == "2")
            {
                lblconnectschool.Visible = true;
                ddlschoollist.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }


    public void UpdateRecord(string Id)
    {
        try
        {
            string sql = "select usrUserid from usermaster where usrMobileNo='" + txtContactNo.Text + "'";
            string userid = cc.ExecuteScalar(sql);
            if (userid == "" || userid == null)
            {

            }
            else
            {
                string Sql = "Update LongCodeRegistration set customer_name='" + txtCustomerName.Text + "',address='" + txtCustomeraddress.Text + "',mobileno='" + txtmobileno.Text + "',Sim_no='" + txtsimno.Text + "',IMEINO='" + txtIMINo.Text + "',customer_contact='" +
                    txtContactNo.Text + "',no_usefor='" + rdbUserfor.SelectedItem.Value + "',send_data='" + ddlsenddata.SelectedValue + "',MissCallType='" + rblText.SelectedItem.Text + "',customer_contact1='" +
                    txtContactNo2.Text + "', customer_contact2='" + txtContactNo3.Text + "',customer_contact3='" + txtContactNo4.Text + "',customer_contact4='" + txtContactNo5.Text + "' where reg_id=" + Id + "";
                int k = cc.ExecuteNonQuery(Sql);
                if (k == 1)
                {
                    Response.Write("<script>alert('Record Updated successfully')</script>");
                    Longcodegridshow();
                    clearAll();
                }
            }

        }
        catch (Exception ex)
        { }
    }


    protected void gvLongCodeshow_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearAll();
    }
    protected void gvLongCodeshow_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=14");
    }
}
