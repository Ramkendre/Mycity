using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_CountryMaster : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    CountryBLL countryBLLObj = new CountryBLL();
    int id = 0;
    int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GetAllCountry();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            CountryInsertUpdate();      //Add the country
            ClearInputBox();
            GetAllCountry();  //Get all the country
            btnSubmit.Text = "Submit";
           
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    public void CountryInsertUpdate()
    {

        countryBLLObj.countryName = Convert.ToString(txtCountryName.Text);
        string id = Convert.ToString(Session["MarketingUser"]);
        if (Convert.ToString(ViewState["countryId"]) == "")
        {

            status = countryBLLObj.BLLCountryInsert(countryBLLObj);

            if (status == 1)
            {
                Response.Write("<script>alert('Country  Added')</script>");
                string maxcntid = "select max(countryId) from CountryMaster";
                string id1c = cc.ExecuteScalar(maxcntid);
                string dateins = DateTime.UtcNow.Date.ToShortDateString();// System.DateTime.Now.Date.ToString();
                dateins = cc.ChangeDate(dateins);
                string insert = "update CountryMaster set insdate='" + dateins + "',userId='" + id + "' where countryId="+id1c.ToString()+"";

                cc.ExecuteNonQuery(insert);

            }
            else if (status == 0)
            {
                Response.Write("<script>alert('Country Not added')</script>");
            }
        }

        else
        {
            countryBLLObj.countryId = Convert.ToInt32(Convert.ToString(ViewState["countryId"]));
            status = countryBLLObj.BLLCountryUpdate(countryBLLObj);

            if (status > 0)
            {
                Response.Write("<script>alert('Country Updated')</script>");

                string cntid = Convert.ToString(ViewState["countryId"]);
                 string dateupd = DateTime.UtcNow.Date.ToShortDateString();


                 dateupd = cc.ChangeDate(dateupd);
                string update = "update CountryMaster set modydate='" + dateupd + "',userId='" + id + "' where countryId=" + cntid.ToString() + "";

                cc.ExecuteNonQuery(update);


            }
            else
            {
                Response.Write("<script>alertalert('Country Exist')</script>");
                
            }
        }

    }

    //Get All the country 
    private void GetAllCountry()
    {
        try
        {
        DataTable dtCountryShowAll = countryBLLObj.BLLShowAllCountry();

        gvCountry.DataSource = dtCountryShowAll;
        gvCountry.DataBind();
         }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }




    private void ClearInputBox()
    {
        txtCountryName.Text = "";

    }


    protected void gvCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            btnSubmit.Text = "Update";
            int id = gvCountry.SelectedIndex;
            ViewState["countryId"] = gvCountry.Rows[id].Cells[0].Text;
            txtCountryName.Text = gvCountry.Rows[id].Cells[1].Text;
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
}
