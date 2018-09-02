using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;

/// <summary>
/// Summary description for ezeeTestMarketing
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ezeeTestMarketing : System.Web.Services.WebService {

    public ezeeTestMarketing () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    CommonCode cc = new CommonCode();
    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public XmlDocument MarketingData(String RefralMobNo)
    {
        string s = string.Empty;
        string keyword = string.Empty;
        XmlDataDocument xmldata = new XmlDataDocument();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();


        //string str2 = "select [ID],[Parent_MobileNo],[Child_MobileNo],[ParentName],[ChildName],[ProjectName],[Role] FROM [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] where Parent_MobileNo='" + RefralMobNo + "'";
        string str2 = "select [ID],[Parent_MobileNo],[Child_MobileNo],[ParentName],[ChildName],[ProjectName],[Role] FROM [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] where Parent_MobileNo='" + RefralMobNo + "'";
         ds = cc.ExecuteDataset(str2);
       
       
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xmldata = new XmlDataDocument(ds);
                    XmlElement xmlele = xmldata.DocumentElement;
                    return xmldata;
                }
                else
                {
                    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
                    DataRow dr = dt.NewRow();
                    dr["NoRecord"] = "105";
                    dt.Rows.Add(dr);
                    
                    ds.Tables.Add(dt);
                    xmldata = new XmlDataDocument(ds);
                    XmlElement xmlelement = xmldata.DocumentElement;
                    return xmldata;
                }
         
        
    }
    
}

