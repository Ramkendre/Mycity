using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_SearchByCity : System.Web.UI.Page
{
    CityBLL cityBLLObj = new CityBLL();
    UISearchBLL usBLLObj = new UISearchBLL();
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  usBLLObj.cityId = Convert.ToInt32(Convert.ToString(Session["cityId"]));
            try
            {
                string catId = Convert.ToString(Request.QueryString["Id"]);
                Session["categoryId"] = catId;
                //   LoadCategory(usBLLObj);

                cityBLLObj.cityId = Convert.ToInt32(Convert.ToString(Session["City"]));
                lblCurrLocation.Text = cc.ShowCityName(cityBLLObj);
                LoadGrid();
            }
            catch { }
          
        }
    }


    public void LoadGrid()
    {
        try
        {
            
          //  string catId = Convert.ToString(cmbCategory.SelectedValue);
            string catId = Convert.ToString(Request.QueryString["Id"]);
            if (catId == "")
            {
               
               usBLLObj.categoryId = 0;
              

               ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Select Category')", true);
            }
            else
            {
                usBLLObj.categoryId = Convert.ToInt32(catId);

                usBLLObj.cityId = Convert.ToInt32(Convert.ToString(Session["City"]));


               DataTable dtSearchItem = usBLLObj.BLLSearchItem(usBLLObj);
               


                gvDisplayItem.DataSource = dtSearchItem;
                gvDisplayItem.DataBind();
                
                //For Findout Extra Information about result

                lblNoOfRecord.Text = Convert.ToString(dtSearchItem.Rows.Count);

                  
               // lblMatchCategory.Text = cmbCategory.SelectedItem.Text;

                //Find the Current Location
              
                
            }

           
        }
        catch (Exception ex)
        {
           // throw ex;
        }

    }

   


   
   
    


    protected void gvDisplayItem_ItemCommand(object source, DataListCommandEventArgs e)
    {
       
    }
    //**code to send sms as well as email who have a search in specific category*******Deviloped by sidhesh***

    protected void gvDisplayItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DisplayDetails")
            {
                Session["itemId"] = Convert.ToString(e.CommandArgument);
              string  itemid = Convert.ToString(Session["itemId"]);

                string username=Convert.ToString(Session["UserFirstNameN"]);
                string UserMobile = Convert.ToString(Session["Mobile"]);
                string city = Convert.ToString(Session["CityNameN"]);


                string  categoryid=Convert.ToString(Session["categoryId"]);
                usBLLObj.itemId = Convert.ToString(Session["itemId"]);
                usBLLObj.categoryId = Convert.ToInt32(Convert.ToString(Session["categoryId"]));
                DataTable dtItemDescription = usBLLObj.BLLItemDescription(usBLLObj);

                string Name1 = Convert.ToString(dtItemDescription.Rows[0]["attributeValue"]);// itBLLObj.itemName;
                string Mobileno = Convert.ToString(dtItemDescription.Rows[3]["attributeValue"]);// itBLLObj.itemName;
                string Email = Convert.ToString(dtItemDescription.Rows[8]["attributeValue"]);// itBLLObj.itemName;

                string Name =Convert.ToString(dtItemDescription.Rows[2]["attributeValue"]);

                //****send sms to WHOSE SERCH INFORMATION****
                string sms = "Mr/Ms " + username + "Currently visited or seen  your Information. His/Her  City Name:=" + city + " And  Mobile no=" + UserMobile + " Plz  contact to that pearson.what he want...  ";
                cc.SendMessage1(Mobileno, Mobileno, sms);

                //****send sms to login user****
                string s = "You  have currently visited " + Name1 + " If you want contact him/her so his/her contact no=" + Mobileno + " And Email Id=" + Email + "";
                cc.SendMessage1(UserMobile, UserMobile, s);
                //****send Email to to WHOSE SERCH INFORMATION********
                cc.mailSendingSMSAsEmail(sms, Email, Name);   

                Response.Redirect("DisplayDetailsByCity.aspx");
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        

    }
    protected void gvDisplayItem_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
