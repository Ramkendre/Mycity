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

/// <summary>
/// Summary description for TestAdvertise
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TestAdvertise : System.Web.Services.WebService {

    CommonCode cc = new CommonCode();
    public TestAdvertise () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public XmlDocument AdvertiseDetails(string id, string var, string var2)
    {
        DataSet ds = new DataSet();
        XmlDataDocument xmldatadoc = new XmlDataDocument();
        try
        {
            string sql;
            sql = "select [NID],[NHeading],[NTopic],[NPaper],[DONR],[LDOA],[NFeesApp],[NInDetail],[NApplicablefor],[NState],[NDistrict],[NCity],[NImg],[status] FROM [Come2myCityDB].[come2mycity].[tblShowNews] where [NCurrentDate]>='" + var + "' and [NPrjname]='" + id + "' and [NTopic]='" + var2 + "' ";

            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmldatadoc = new XmlDataDocument(ds);
                XmlElement xmlelement = xmldatadoc.DocumentElement;
            }

        }
        catch (Exception ex)
        {
        }
        return xmldatadoc;
    }
    
}

