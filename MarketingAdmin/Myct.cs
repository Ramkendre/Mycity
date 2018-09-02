using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Myct
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Myct : System.Web.Services.WebService
{

    CommonCode cc = new CommonCode();
    SqlCommand cmd = new SqlCommand();
    public Myct()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    

    #region Method For DropDown
    [WebMethod]
    public XmlDocument DownloadAllComboValue()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {

            string str = "select [categoryId],[categoryName],[parentCategoryId],[catLevel],[ImageStr] from [Come2myCityDB].[dbo].[Category]";
            DataSet ds1 = cc.ExecuteDataset(str);

            xmlData = new XmlDataDocument(ds1);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        catch (Exception ex)
        {

        }
        return xmlData;
    }
    #endregion

    #region Method For Download Item
    [WebMethod]
    public XmlDocument DownloadItem(string State,string CategoryId)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {
            string str = "select itemAutoId,[itemName],itemDescription,[Area],[Address],[Latitude],[Longitude] FROM [Come2myCityDB].[dbo].[Item] where [State]='" + State + "' and [categoryId]='" + CategoryId + "'";
            DataSet ds = cc.ExecuteDataset(str);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        catch(Exception ex)
        {
        
        }
        return xmlData;
    }
    #endregion

    [WebMethod]
    public string MRegDown(string categoryName)
    {
        string returnString = string.Empty;
        int count = 1;
        DataSet ds = new DataSet();

        string str = "select ImageStr FROM [Come2myCityDB].[dbo].[Category] where [categoryName]='" + categoryName + "'";
        ds = cc.ExecuteDataset(str);

            byte[] bytei = (byte[])ds.Tables[0].Rows[0][0];
            //string foo = Encoding.ASCII.GetString(bytei);
            string result = ds.Tables[0].Rows[0][0].ToString();
            return result;

    }

    #region Method For Download Image
    [WebMethod]
    public XmlDocument DownloadImage(string categoryName)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {
            string str = "select ImageStr FROM [Come2myCityDB].[dbo].[Category] where [categoryName]='" + categoryName + "'";
            DataSet ds = cc.ExecuteDataset(str);
            byte[] bytei = (byte[])ds.Tables[0].Rows[0][0];
            string foo = Encoding.ASCII.GetString(bytei);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        catch (Exception ex)
        {

        }
        return xmlData;
    }
    #endregion

    #region Method For Insert Profile
    [WebMethod]
    public string InsertData(string Keyword, string BString, string MobileNo)
    {
        if (BString != "" && Keyword != null)
        {

            try
            {
                if (Keyword.Equals("USER"))
                {
                    return Profile(BString, MobileNo);
                }
                else if (Keyword.Equals("AE"))
                {
                    return EntraUser(BString, MobileNo);
                }
               

                return null;
            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        else
        {

            return CommonCode.WRONG_INPUT.ToString();
        }

    }
    private string Profile(string Bstring, string MobileNo)
    {
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        string uid = System.Guid.NewGuid().ToString();
        string st = "select usrUserId from UserMaster where usrMobileNo='" + MobileNo + "'";
        uid = cc.ExecuteScalar(st);
        if (uid == "" || uid == null)
        {
            for (int i = 1; i < stringArray.Length; i += 13)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

                cmd.Parameters.Add(new SqlParameter("@usrFirstName", stringArray[i].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrLastName", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrMobileNo", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrEmailId", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrAddress", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrState", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@strDevId", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrDistrict", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrTaluka", stringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrCity", stringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrUserId", uid));


                cmd.CommandText = "uspMYCTUserMasterInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                //string str = "select max(GID) from [Come2myCityDB].[dbo].[tbl_BCreateGat] ";
                //string str1 = cc.ExecuteScalar(str);
                //nonInsertedValues1 += str1 + "*";


            }
        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString();
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;



    }
    public string EntraUser(string EString,string MobileNo)
    {
        string[] stringArray = EString.Split(new char[] {'#','*'});
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        string newUid = string.Empty;
        string uid = "select usrUserId from UserMaster where usrMobileNo='"+MobileNo+"'";
        string uid1 = cc.ExecuteScalar(uid);
        
            for (int i = 1; i < stringArray.Length; i += 29)
            {
                cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

                if (uid1 == "" || uid1 == null)
                {
                    newUid = System.Guid.NewGuid().ToString();

                cmd.Parameters.Add(new SqlParameter("@usrFirstName", stringArray[i].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrLastName", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrMobileNo", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrEmailId", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrAddress", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrState", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@strDevId", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrDistrict", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrTaluka", stringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrCity", stringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrUserId", newUid));


                cmd.CommandText = "uspMYCTUserMasterInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                }

                string itemid = System.Guid.NewGuid().ToString();
                cmd.Parameters.Add(new SqlParameter("@itemId", itemid));
                cmd.Parameters.Add(new SqlParameter("@itemName", stringArray[i + 10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@TypeOfFirm", stringArray[i + 11].ToString()));
                cmd.Parameters.Add(new SqlParameter("@GovOrganisation", stringArray[i + 12].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Area", stringArray[i + 13].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Specialities", stringArray[i + 14].ToString()));
                cmd.Parameters.Add(new SqlParameter("@VerifiedAgent", stringArray[i + 15].ToString()));
                cmd.Parameters.Add(new SqlParameter("@TypeOfUser", stringArray[i + 16].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Address", stringArray[i + 17].ToString()));
                cmd.Parameters.Add(new SqlParameter("@State", stringArray[i + 18].ToString()));
                cmd.Parameters.Add(new SqlParameter("@District", stringArray[i + 19].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Taluka", stringArray[i + 20].ToString()));
                cmd.Parameters.Add(new SqlParameter("@cityId", stringArray[i + 21].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Latitude", stringArray[i + 22].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Longitude", stringArray[i + 23].ToString()));
                cmd.Parameters.Add(new SqlParameter("@ImageString", stringArray[i + 24].ToString()));
                cmd.Parameters.Add(new SqlParameter("@categoryId", stringArray[i + 25].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Active", stringArray[i + 26].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UserMasterUid", newUid));


                cmd.CommandText = "uspMYCTUMAEInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
            }
        
            if (string.IsNullOrEmpty(nonInsertedValues))
            {
                string sql = CommonCode.OK.ToString();
                return sql + nonInsertedValues1;
            }
            else
                return nonInsertedValues;
        
    }
    
    #endregion
}

