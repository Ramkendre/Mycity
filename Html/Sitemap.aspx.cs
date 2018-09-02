using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;

public partial class html_Sitemap : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string Address = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserIdSession = Convert.ToString(Session["User"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                btnGetCoordinates();
            }
        }
    }
    
    public void btnGetCoordinates()
    {
        Adress adrs = new Adress();
        string sql1 = "Select usrAddress from UserMaster where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
        Address = Convert.ToString(cc.ExecuteScalar(sql1));
       
        adrs.Address = Address;
        adrs.GeoCode();
        lblLattitude.Text = adrs.Latitude;
        lblLongtitude.Text = adrs.Longitude;
        AddControl();
    }
    public class Adress
    {
        public Adress()
        {
        }
        //Properties
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }

        //The Geocoding here i.e getting the latt/long of address
        public void GeoCode()
        {
            //to Read the Stream
            StreamReader sr = null;

            //The Google Maps API Either return JSON or XML. We are using XML Here
            //Saving the url of the Google API 
            string url = String.Format("http://maps.googleapis.com/maps/api/geocode/xml?address=" +
            this.Address + "&sensor=false");

            //to Send the request to Web Client 
            WebClient wc = new WebClient();
            try
            {
                sr = new StreamReader(wc.OpenRead(url));
            }
            catch (Exception ex)
            {
                throw new Exception("The Error Occured" + ex.Message);
            }

            try
            {
                XmlTextReader xmlReader = new XmlTextReader(sr);
                bool latread = false;
                bool longread = false;

                while (xmlReader.Read())
                {
                    xmlReader.MoveToElement();
                    switch (xmlReader.Name)
                    {
                        case "lat":

                            if (!latread)
                            {
                                xmlReader.Read();
                                this.Latitude = xmlReader.Value.ToString();
                                latread = true;

                            }
                            break;
                        case "lng":
                            if (!longread)
                            {
                                xmlReader.Read();
                                this.Longitude = xmlReader.Value.ToString();
                                longread = true;
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured" + ex.Message);
            }
        }
    }

    void AddControl()
    {
        try
        {
            lblLoc.Text = "";
            lblLat.Text = "";
            lblLng.Text = "";
            lblName.Text = "";

            string sql1 = "Select usrFirstName+' '+usrLastName as Name from UserMaster where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
            string Name = Convert.ToString(cc.ExecuteScalar(sql1));


            //Session["id"] += ds.Tables[0].Rows[i][0].ToString() + ",";

            lblLoc.Text += "Location " + (2) + "*";
            lblLat.Text += Convert.ToString(lblLattitude.Text) + "*";
            lblLng.Text += Convert.ToString(lblLongtitude.Text) + "*";
            lblName.Text += Convert.ToString(Name) + "*";

            //lblOwner.Text += Convert.ToString("dddd") + " " + Convert.ToString("rrrrrr") + "*";
            lblAddress.Text += Convert.ToString(Address) + "*";
            lblMobileNo.Text += Convert.ToString(Session["Mobile"]) + "*";

        }
        catch (Exception ex)
        { }

        ScriptManager.RegisterStartupScript(this, typeof(Page), "setPoint", "setPoint();", true);
    }
}



