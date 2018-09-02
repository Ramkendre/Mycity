using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PWP
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PWP : System.Web.Services.WebService {


    CommonCode cc = new CommonCode();
    public PWP () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public XmlDocument PWPDetails(string var, string PWPtype)
    {
        DataSet ds = new DataSet();
        XmlDataDocument xmldatadoc = new XmlDataDocument();
        XmlDocument xmldoc = new XmlDocument();
        try
        {
            string sql = String.Empty;
            if (PWPtype == "1")
            {
                sql = "select [PWP_NID],[PWP_NHeading],[PWP_NDetails],[PWP_NStatus] FROM [Come2myCityDB].[come2mycity].[PWP_tblSportsNews] where [PWP_NEntryDate]>='" + var + "'";
            }
            else if (PWPtype == "2")
            {
                sql = "select [PWP_GID],[PWP_GHeading],[PWP_GDetails],[PWP_GStatus] FROM [Come2myCityDB].[come2mycity].[PWP_tblGameInfo] where [PWP_GEntryDate]>='" + var + "'";
            }
            else if (PWPtype == "3")
            {
                sql = "select [PWP_EID],[PWP_EHeading],[PWP_EDetails],[PWP_EStatus] FROM [Come2myCityDB].[come2mycity].[PWP_tblEvents] where [PWP_EEntryDate]>='" + var + "'";
            }
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmldatadoc = new XmlDataDocument(ds);
                XmlElement xmlelement = xmldatadoc.DocumentElement;
            }
            else
            {
                XmlWriter writer = xmldoc.CreateNavigator().AppendChild();
                writer.WriteStartDocument(true);

                writer.WriteStartElement("Error");
                writer.WriteString("No data");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                return xmldoc;
            }
        }
        catch (Exception ex)
        {
        }
        return xmldatadoc;
    }
    //[WebMethod]
    //public XmlDocument PWPDetails(string var, string PWPtype)
    //{
    //    DataSet ds = new DataSet();
    //    XmlDataDocument xmldatadoc = new XmlDataDocument();
    //    XmlDocument xmldoc = new XmlDocument();
    //    try
    //    {
    //        string sql = "";
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return xmldatadoc;
    //} 


 
    [WebMethod(Description = "PWPProfile")]

    public string PWPInsertData(string Keyword, string PWPString, string UserMobileNo)
    {
        int i;
        //if (!string.IsNullOrEmpty(eventString) && !string.IsNullOrEmpty(keyWord))

        if (PWPString != "" && Keyword != null)
        {
            try
            {
                if (Keyword.Equals("PLAYER"))
                {
                    return PWPlayer(PWPString, UserMobileNo);
                }
                else if (Keyword.Equals("COACH"))
                {
                    return PWPCoach(PWPString, UserMobileNo);
                }
                
                else if (Keyword.Equals("CLUB"))
                {
                    return PWPClub(PWPString, UserMobileNo);
                }
                else if (Keyword.Equals("SPECIALIST"))
                {
                    return PWPSpecialist(PWPString, UserMobileNo);
                }
                else if (Keyword.Equals("INFRASTRUCTURE"))
                {
                    return PWPInfrasture(PWPString, UserMobileNo);
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
    private string PWPlayer(string PWPString, string UserMobileNo)
    {
       
            int result;
            string[] StringArray = PWPString.Split(new char[] { '#', '*' });
            string nonInsertedValues = string.Empty;
            string nonInsertedValues1 = string.Empty;
            DataSet ds = new DataSet();
            for (int i = 1;i< StringArray.Length; i += 13)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
                cmd.Connection = con;
                if (StringArray[i].ToString() == "0")
                {
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 1].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@FName", StringArray[i + 2].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LName", StringArray[i + 3].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Remark", StringArray[i + 4].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Position", StringArray[i + 5].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Experience", StringArray[i + 6].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@TeamRep", StringArray[i + 7].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Summary", StringArray[i + 8].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Duration", StringArray[i + 9].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LinkPages", StringArray[i + 10].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", UserMobileNo));
                    cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 11].ToString()));

                    cmd.CommandText = "[come2mycity].[uspPWPInsertPlayer]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    result = cmd.ExecuteNonQuery();
                    string str = "select max(PID) from [Come2myCityDB].[come2mycity].[PWP_tblPlayerInfo]";
                    string str1 = cc.ExecuteScalar(str);
                    nonInsertedValues1 += str1 + "*";
                }
                else
                {
                    SqlParameter[] par = new SqlParameter[]
                    {
                        new SqlParameter("@PID",StringArray[i]),
                         new SqlParameter("@MobileNo", StringArray[i + 1].ToString()),
                         new SqlParameter("@FName", StringArray[i + 2].ToString()),
                         new SqlParameter("@LName", StringArray[i + 3].ToString()),
                         new SqlParameter("@Remark", StringArray[i + 4].ToString()),
                         new SqlParameter("@Position", StringArray[i + 5].ToString()),
                         new SqlParameter("@Experience", StringArray[i + 6].ToString()),
                         new SqlParameter("@TeamRep", StringArray[i + 7].ToString()),
                         new SqlParameter("@Summary", StringArray[i + 8].ToString()),
                         new SqlParameter("@Duration", StringArray[i + 9].ToString()),
                         new SqlParameter("@LinkPages", StringArray[i + 10].ToString()),
                         new SqlParameter("@LoginMobileNo", UserMobileNo),
                         new SqlParameter("@EntryDate", StringArray[i + 11].ToString()),

                    };
                    string str = "select usrUserId from UserMaster where usrMobile='"+UserMobileNo+"'";
                    ds = cc.ExecuteDataset(str);
                    string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                    string str1 = "update from [Come2myCityDB].[come2mycity].[PWP_tblPlayerInfo] set [MobileNo]='" + StringArray[i + 1].ToString() + "',[FName]='" + StringArray[i + 2].ToString() + "',[LName]='" + StringArray[i + 3].ToString() + "',[Remark]='" + StringArray[i + 4].ToString() + "',[Position]='" + StringArray[i + 5].ToString() + "',[Experience]='" + StringArray[i + 6].ToString() + "',[TeamRep]='" + StringArray[i + 7].ToString() + "',[Summary]='" + StringArray[i + 8].ToString() + "',[Duration]='" + StringArray[i + 9].ToString() + "',LinkPages='" + StringArray[i + 10].ToString() + "' where UserId='"+s+"' ";
                    result = cc.ExecuteNonQuery(str1);
                }

               
            }
                
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    
    }

    public string PWPCoach(string PWPString, string UserMobileNo)
    {
       
            DataSet ds = new DataSet();
            int result;
            string[] StringArray = PWPString.Split(new char[] { '#', '*' });
            string nonInsertedValues = string.Empty;
            string nonInsertedValues1 = string.Empty;
            for (int i = 1; i < StringArray.Length; i += 9)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
                cmd.Connection = con;
                if (StringArray[i].ToString() == "0")
                {
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 1].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@FName", StringArray[i + 2].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LName", StringArray[i + 3].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Experience", StringArray[i + 4].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@TeamRep", StringArray[i + 5].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Remark", StringArray[i + 6].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", UserMobileNo));
                    cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 7].ToString()));

                    cmd.CommandText = "uspPWPInsertCoach";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();

                    result = cmd.ExecuteNonQuery();
                    string str = "select Max(CID) from [Come2myCityDB].[come2mycity].[PWP_tblCoachInfo]";
                    string str1 = cc.ExecuteScalar(str);
                    nonInsertedValues1 += str1 + "*";
                }
                else
                {
                    SqlParameter[] par = new SqlParameter[]
                    {
                    new SqlParameter("@CID",StringArray[i]),
                    new SqlParameter("@MobileNo", StringArray[i + 1].ToString()),
                    new SqlParameter("@FName", StringArray[i + 2].ToString()),
                    new SqlParameter("@LName", StringArray[i + 3].ToString()),
                    new SqlParameter("@Experience", StringArray[i + 4].ToString()),
                    new SqlParameter("@TeamRep", StringArray[i + 5].ToString()),
                    new SqlParameter("@Remark", StringArray[i + 6].ToString()),
                    new SqlParameter("@LoginMobileNo", UserMobileNo),
                    new SqlParameter("@EntryDate", StringArray[i + 7].ToString()),
                    };

                    string str = "select usrUserId from UserMaster where usrMobile='"+UserMobileNo+"'";
                    ds = cc.ExecuteDataset(str);
                    string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                    string str1 = "update from [Come2myCityDB].[come2mycity].[PWP_tblCoachInfo] set [MobileNo]='" + StringArray[i + 1].ToString() + "',[FName]='" + StringArray[i + 2].ToString() + "',[LName]='" + StringArray[i + 3].ToString() + "',[Experience]='" + StringArray[i + 4].ToString() + "',[TeamRep]='" + StringArray[i + 5].ToString() + "',[Remark]='" + StringArray[i + 6].ToString() + "' where UserId='" + s + "'";
                    result = cc.ExecuteNonQuery(str1);
                }

              


            }



            if (string.IsNullOrEmpty(nonInsertedValues))
            {
                string s = CommonCode.OK.ToString() + "*";
                return s + nonInsertedValues1;
            }
            else
                return nonInsertedValues;
        }
    


    public string PWPClub(string PWPString, string UserMobileNo)
    {
        DataSet ds = new DataSet();
            int result;
            string[] StringArray = PWPString.Split(new char[]{'#','*'});
            string nonInsertedValues = string.Empty;
            string nonInsertedValues1 = string.Empty;
            for (int i = 1; i < StringArray.Length;i+=10 )
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
                cmd.Connection = con;
                if (StringArray[i].ToString() == "0")
                {
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 1].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@FName", StringArray[i + 2].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LName", StringArray[i + 3].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@TeamName", StringArray[i + 4].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@TContactDetails", StringArray[i + 5].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@TSummary", StringArray[i + 6].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@League", StringArray[i + 7].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", UserMobileNo));
                    cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 8].ToString()));

                    cmd.CommandText = "uspPWPInsertClub";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    result = cmd.ExecuteNonQuery();
                    string str = "select Max(CLID)from [Come2myCityDB].[come2mycity].[PWP_tblClub]";
                    string str1 = cc.ExecuteScalar(str);
                    nonInsertedValues1 += str1 + "*";
                }
                else
                {
                    SqlParameter[] par = new SqlParameter[]
                    {
                    new SqlParameter("@MobileNo", StringArray[i + 1].ToString()),
                    new SqlParameter("@FName", StringArray[i + 2].ToString()),
                    new SqlParameter("@LName", StringArray[i + 3].ToString()),
                    new SqlParameter("@TeamName", StringArray[i + 4].ToString()),
                    new SqlParameter("@TContactDetails", StringArray[i + 5].ToString()),
                    new SqlParameter("@TSummary", StringArray[i + 6].ToString()),
                    new SqlParameter("@League", StringArray[i + 7].ToString()),
                    new SqlParameter("@LoginMobileNo", UserMobileNo),
                    new SqlParameter("@EntryDate", StringArray[i + 8].ToString()),
                    };
                    string str = "select usrUserId from UserMaster where usrMobile='" + UserMobileNo + "'";
                    ds = cc.ExecuteDataset(str);
                    string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                    string str1 = "update from [Come2myCityDB].[come2mycity].[PWP_tblClub] set [MobileNo]='" + StringArray[i + 1].ToString() + "',[FName]='" + StringArray[i + 2].ToString() + "',[LName]='" + StringArray[i + 3].ToString() + "',[TeamName]='" + StringArray[i + 4].ToString() + "',[TContactDetails]='" + StringArray[i + 5].ToString() + "',[TSummary]='" + StringArray[i + 6].ToString() + "',League='"+StringArray[i+7].ToString()+"' where UserId='" + s + "'";
                    result = cc.ExecuteNonQuery(str1);
                    
                }
                

            }
       
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    public string PWPSpecialist(string PWPString, string UserMobileNo)
    {
       
            int result;
            string[] StringArray=PWPString.Split(new char[]{'#','*'});
            string nonInsertedValues = string.Empty;
            string nonInsertedValues1 = string.Empty;
            for (int i = 1; i < StringArray.Length;i+=8 )
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
                cmd.Connection = con;
                if(StringArray[i].ToString()=="0")
                {
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 1].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@FName", StringArray[i + 2].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LName", StringArray[i + 3].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@SExperience", StringArray[i + 4].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Remark", StringArray[i + 5].ToString()));
                   
                    cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", UserMobileNo));
                    cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 6].ToString()));

                    cmd.CommandText = "uspPWPInsertspecialist";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    result = cmd.ExecuteNonQuery();
                    string str = "select Max(SID) from [Come2myCityDB].[come2mycity].[PWP_tblSpecialist]";
                    string str1 = cc.ExecuteScalar(str);
                    nonInsertedValues1 += str1 + "*";
                }
               
            }
        
        
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    public string PWPInfrasture(string PWPString, string UserMobileNo)
    {
       
            int result;
            string[] StringArray = PWPString.Split(new char[] { '#', '*' });
            string nonInsertedValues = string.Empty;
            string nonInsertedValues1 = string.Empty;
            for (int i = 1; i < StringArray.Length; i+=9)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
                cmd.Connection = con;
                if (StringArray[i].ToString() == "0")
                {
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 1].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@FName", StringArray[i + 2].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LName", StringArray[i + 3].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@GroundName", StringArray[i + 4].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Location", StringArray[i + 5].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Remark", StringArray[i + 6].ToString()));

                    cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", UserMobileNo));
                    cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 7].ToString()));

                    cmd.CommandText = "uspPWPInsertInfrasture";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    result = cmd.ExecuteNonQuery();
                    string str = "select Max(IID)from [Come2myCityDB].[come2mycity].[PWP_tblInfrastructure]";
                    string str1 = cc.ExecuteScalar(str);
                    nonInsertedValues1 += str1 + "*";
                }
                
            }

       
       
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
}

