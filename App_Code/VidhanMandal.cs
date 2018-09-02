using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Xml;

/// <summary>
/// Summary description for VidhanMandal
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class VidhanMandal : System.Web.Services.WebService
{
    CommonCode cc = new CommonCode();
    string ddd;
    string DateFormat = "";

    public VidhanMandal()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string MeetingSchedule(string VidhanManadal)
    {
        DateFormatStatus();
        string Sql = "Select Id, RoomNo,TimeDetails,EntryDate from committeedetail where EntryDate='" + DateFormat + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddd = ds.GetXml();
        }
        else
        {
            ddd = "No Data Found";
            XmlDocument xm = new XmlDocument();
            xm.LoadXml(string.Format("<root>{0}</root>", ddd));
            //  return xm;
        }
        return ddd;
    }


    [WebMethod]
    public XmlDocument AllDetails(string Programme)
    {
        DataSet ds = new DataSet();


        XmlDataDocument xmldatadoc = new XmlDataDocument();
        try
        {
            if (Programme == "0")
            {
                string sql1 = "SELECT ProgName ,ProgDescription,LastModifieddate FROM [Come2myCityDB].[dbo].[ProgrameDetails]";
                sql1 += "SELECT SName ,SDescription,VidhanMSType,LastModifieddate FROM [Come2myCityDB].[dbo].[SamitiDetails] ";
                sql1 += "SELECT VidhanDate ,VidhanDescr,Vidhanmandal,LastModifieddate FROM [Come2myCityDB].[dbo].[VidhanMandalDetails] order by VidhanDate";
                ds = cc.ExecuteDataset(sql1);
                if (ds != null)
                {
                    ds.Tables[0].TableName = "ProgrameDetails";
                    ds.Tables[1].TableName = "SamitiDetails";
                    ds.Tables[2].TableName = "VidhanMandalDetails";
                    xmldatadoc = new XmlDataDocument(ds);
                    XmlElement xmlelement = xmldatadoc.DocumentElement;
                }
            }

        }
        catch (Exception ex)
        {
        }
        return xmldatadoc;
    }

    [WebMethod(Description="DOWNLOAD NEWS AND SYLLABUS")]
    public XmlDocument AllNewsDetails(string id, string var, string newstype)
    {
        DataSet ds = new DataSet();
        XmlDataDocument xmldatadoc = new XmlDataDocument();
        try
        {
            string sql = string.Empty;

            if (newstype == "Job")
            {
                sql = "SELECT * FROM (SELECT TOP 50 [NID],[NHeading],[NTopic],[NPaper],[DONR],[LDOA],[NFeesApp],[NInDetail],[NApplicablefor],[NState],[NDistrict],[NCity],[NImg],[examid] FROM [Come2myCityDB].[come2mycity].[tblShowNews] WHERE ([NTopic]='Job' or [NTopic]='Exam') AND [NPrjname]='3' ORDER BY [NID] DESC) AS EMP ORDER BY [NID] ASC";
            }
            else if (newstype == "Syllabus")
            {
                sql = "SELECT * FROM (SELECT TOP 100 [NID],[NHeading],[NTopic],[NPaper],[DONR],[LDOA],[NFeesApp],[NInDetail],[NApplicablefor],[NState],[NDistrict],[NCity],[NImg],[examid] FROM [Come2myCityDB].[come2mycity].[tblShowNews] WHERE ([NTopic]='Syllabus' or [NTopic]='Eligibility') AND [NPrjname]='3' ORDER BY [NID] DESC) AS EMP ORDER BY [NID] ASC";
            }
            
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmldatadoc = new XmlDataDocument(ds);
                XmlElement xmlelement = xmldatadoc.DocumentElement;
            }
        }

        catch
        {
        }

        return xmldatadoc;
    }




    //public string VidhanMandalDetails(string Vidhanmandal)
    //{
    //[WebMethod]
    //public XmlDocument VidhanMandalDetails(string Vidhanmandal)
    //{
    //    DataSet ds = new DataSet();


    //    XmlDataDocument xmldatadoc = new XmlDataDocument();
    //    try
    //    {

    //        string sql1 = "SELECT VidhanDate ,VidhanDescr,Vidhanmandal,LastModifieddate FROM [Come2myCityDB].[dbo].[VidhanMandalDetails] Where Vidhanmandal = '" + Vidhanmandal + "'";
    //        ds = cc.ExecuteDataset(sql1);

    //        if (Vidhanmandal == "Vidhan Parishad")
    //        {
    //            Vidhanmandal = "VidhanParishad";
    //        }
    //        else if (Vidhanmandal == "Vidhan Sabha")
    //        {
    //            Vidhanmandal = "VidhanSabha";
    //        }

    //        ds.DataSetName = Vidhanmandal;

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //            xmldatadoc = new XmlDataDocument(ds);
    //            XmlElement xmlelement = xmldatadoc.DocumentElement;
    //        }
    //        //if (ds.Tables[0].Rows.Count > 0)
    //        //{

    //        //    ddd = ds.GetXml();
    //        //}
    //        //else
    //        //{
    //        //    ddd = "No Data Found";
    //        //    XmlDocument xm = new XmlDocument();
    //        //    xm.LoadXml(string.Format("<root>{0}</root>", ddd));
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    return xmldatadoc;
    //}

    //[WebMethod]
    //public XmlDocument SamitiDetails(string VidhanMSType)
    //{
    //    DataSet ds = new DataSet();


    //    XmlDataDocument xmldatadoc = new XmlDataDocument();
    //    try
    //    {

    //        string sql1 = "SELECT SName ,SDescription,VidhanMSType,LastModifieddate FROM [Come2myCityDB].[dbo].[SamitiDetails] Where VidhanMSType = '" + VidhanMSType + "'";
    //        ds = cc.ExecuteDataset(sql1);

    //        if (VidhanMSType == "Vidhan Parishad")
    //        {
    //            VidhanMSType = "VidhanParishad";
    //        }
    //        else if (VidhanMSType == "Vidhan Sabha")
    //        {
    //            VidhanMSType = "VidhanSabha";
    //        }

    //        ds.DataSetName = VidhanMSType;

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //            xmldatadoc = new XmlDataDocument(ds);
    //            XmlElement xmlelement = xmldatadoc.DocumentElement;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    return xmldatadoc;
    //}



    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 0; //add hours in time
        double m = 30; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
        string ds1 = Convert.ToString(DateFormat);
        return ds1;
    }

}

