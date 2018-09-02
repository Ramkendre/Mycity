using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Management;



/// <summary>
/// Summary description for BachatGat
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BachatGat : System.Web.Services.WebService
{

    CommonCode cc = new CommonCode();
    string[] s1;
    public BachatGat()
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
    public string InsertData(string Keyword, string BString, string usereNumber)
    {
        if (BString != "" && Keyword != null)
        {

            try
            {
                if (Keyword.Equals("CREATEGAT"))
                {
                    return CreateGat(BString, usereNumber);
                }
                if (Keyword.Equals("MEMREGISTRATION"))
                {
                    return MRegistration(BString, usereNumber);
                }
                else if (Keyword.Equals("EXPENDITURE"))
                {
                    return ExpEntries(BString, usereNumber);
                }
                else if (Keyword.Equals("ISSUELOAN"))
                {
                    return IssueLoan(BString, usereNumber);
                }
                else if (Keyword.Equals("RECEIVEDEPOSITE"))
                {
                    return ReceiveDeposite(BString, usereNumber);
                }
                else if (Keyword.Equals("INSTALMENT"))
                {
                    return SubInstalment(BString, usereNumber);
                }
                else if (Keyword.Equals("SETTING"))
                {
                    return Setting(BString, usereNumber);
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
    private string CreateGat(string Bstring, string LoginMobileNo)
    {
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 5)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@GatName", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MobileNo", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));

                cmd.CommandText = "uspBInsertCreateGat";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(GID) from [Come2myCityDB].[dbo].[tbl_BCreateGat] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@GID",stringArray[i]),
                    new SqlParameter("@GatName", stringArray[i + 1].ToString()),
                    new SqlParameter("@MobileNo", stringArray[i + 2].ToString()),
                    new SqlParameter("@EntryDate", stringArray[i + 3].ToString()),

                };
                //cmd.Parameters.AddRange(par);
                //cmd.CommandText = "[dbo].[uspUpdateBCreateGat]";
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (cmd.Connection.State == ConnectionState.Closed)
                //    cmd.Connection.Open();
                //result = cmd.ExecuteNonQuery();
                string str1 = "update [Come2myCityDB].[dbo].[tbl_BCreateGat] set [GatName]='" + stringArray[i + 1].ToString() + "',[MobileNo]='" + stringArray[i + 2].ToString() + "',[EntryDate]='" + stringArray[i + 3].ToString() + "' where GID='" + stringArray[i] + "' ";
                result = cc.ExecuteNonQuery(str1);
                string str = "select GID from [Come2myCityDB].[dbo].[tbl_BCreateGat] where GID='" + stringArray[i] + "'";
                string str7 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str7 + "*";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {


                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;



    }
    private string MRegistration(string Bstring, string LoginMobileNo)
    {
        DataSet ds = new DataSet();
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 12)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {

                string str = "select MobileNo from [Come2myCityDB].[dbo].[tbl_BMRegistration]";
                ds = cc.ExecuteDataset(str);
                for (int j = 0; j < ds.Tables[0].Rows.Count;j++)
                {
                    if (stringArray[i + 4].ToString() == Convert.ToString(ds.Tables[0].Rows[j]["MobileNo"]))
                    {
                        string s2 = (ds.Tables[0].Rows[j]["MobileNo"]).ToString();
                        s1 = new string[] { s2 };



                    }
                }
              
                 if (s1!=null && (stringArray[i + 4].ToString() == s1[0].ToString()))
                {
                    string st = "select MID from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='"+stringArray[i+4]+"' ";
                    string st1 = cc.ExecuteScalar(st);
                    nonInsertedValues1 += st1 + "*";
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@GID", stringArray[i + 1]));
                    cmd.Parameters.Add(new SqlParameter("@FName", stringArray[i + 2].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LName", stringArray[i + 3].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", stringArray[i + 4].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Post", stringArray[i + 5].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@DOJ", stringArray[i + 6].ToString()));
                    //cmd.Parameters.Add(new SqlParameter("@Status", stringArray[i + 7].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Subscription", stringArray[i + 7].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Deposite", stringArray[i + 8].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Loan", stringArray[i + 9].ToString()));


                    cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                    cmd.Parameters.Add(new SqlParameter("@EntryDate", stringArray[i + 10].ToString()));
                    cmd.CommandText = "[dbo].[uspBInsertMRegistration]";

                    //        cmd.CommandText = "INSERT INTO [Come2myCityDB].[dbo].[tbl_BMRegistration]([GID],[FName],[LName],[MobileNo],[Post],[DOJ],Subscription,[Deposite],Loan,[UserId],[EntryDate])"
                    //+"VALUES(@GID,@FName,@LName,@MobileNo,@Post,@DOJ,@Subscription,@Deposite,@Loan,'8888',@EntryDate)";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    //result = cmd.ExecuteNonQuery();
                    string res = cmd.ExecuteScalar().ToString();
                    if (res == "5")
                    {
                        nonInsertedValues1 += res + "*";
                    }
                    else
                    {
                        string q = "select max(MID) from [Come2myCityDB].[dbo].[tbl_BMRegistration] ";
                        string q1 = cc.ExecuteScalar(q);
                        nonInsertedValues1 += q1 + "*";
                    }
                }
            }

            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@MID", stringArray[i ]),
                new SqlParameter("@GID", stringArray[i + 1].ToString()),
                
                new SqlParameter("@FName", stringArray[i + 2].ToString()),
                new SqlParameter("@LName", stringArray[i + 3].ToString()),
                new SqlParameter("@MobileNo", stringArray[i + 4].ToString()),
                new SqlParameter("@Post", stringArray[i + 5].ToString()),
                new SqlParameter("@DOJ", stringArray[i + 6].ToString()),
                //cmd.Parameters.Add(new SqlParameter("@Status", stringArray[i + 7].ToString()));
                new SqlParameter("@Subscription", stringArray[i + 7].ToString()),
                new SqlParameter("@Deposite", stringArray[i + 8].ToString()),
                new SqlParameter("@Loan", stringArray[i + 9].ToString()), 
                new SqlParameter("@EntryDate",stringArray[i+10].ToString()),
                };
                //cmd.Parameters.AddRange(par);
                //cmd.CommandText = "uspUpdateBMemReg";
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (cmd.Connection.State == ConnectionState.Closed)
                //    cmd.Connection.Open();
                //result = cmd.ExecuteNonQuery();
                string str1 = "update [Come2myCityDB].[dbo].[tbl_BMRegistration] set [GID]='" + stringArray[i + 1].ToString() + "',[FName]='" + stringArray[i + 2].ToString() + "',[LName]='" + stringArray[i + 3].ToString() + "',[MobileNo]='" + stringArray[i + 4].ToString() + "',[Post]='" + stringArray[i + 5].ToString() + "',[DOJ]='" + stringArray[i + 6].ToString() + "',[Subscription]='" + stringArray[i + 7].ToString() + "',[Deposite]='" + stringArray[i + 8].ToString() + "',[Loan]='" + stringArray[i + 9].ToString() + "',[EntryDate]='" + stringArray[i + 10].ToString() + "' where MID='" + stringArray[i] + "' ";
                result = cc.ExecuteNonQuery(str1);
                string str = "select MID from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MID='" + stringArray[i] + "'";
                string str7 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str7 + "*";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {


                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;

    }
    private string ExpEntries(string Bstring, string LoginMobileNo)
    {
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 9)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {

                cmd.Parameters.Add(new SqlParameter("@Date", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@VoucharNo", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@TypeOfExp", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Amount", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Description", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Mode", stringArray[i + 6].ToString()));


                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", stringArray[i + 7].ToString()));


                cmd.CommandText = "uspBInsertExpEntries";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_BExpenditureE] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@ID",stringArray[i]),
                    new SqlParameter("@Date",stringArray[i+1]),new SqlParameter("@VoucharNo",stringArray[i+2]),
                    new SqlParameter("@TypeOfExp",stringArray[i+3]),new SqlParameter("@Amount",stringArray[i+4]),
                    new SqlParameter("@Description",stringArray[i+5]),new SqlParameter("@Mode",stringArray[i+6]),
                   
                     new SqlParameter("@LoginMobileNo",LoginMobileNo),
                     new SqlParameter("@CurrentDate",stringArray[i+10])   
                };
                //cmd.Parameters.AddRange(par);
                //cmd.CommandText = "[sp_UEDeath]";
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (cmd.Connection.State == ConnectionState.Closed)
                //    cmd.Connection.Open();
                //result = cmd.ExecuteNonQuery();
                string str1 = "update [Come2myCityDB].[dbo].[tbl_BExpenditureE] set [Date]='" + stringArray[i + 1].ToString() + "',[VoucharNo]='" + stringArray[i + 2].ToString() + "',[TypeOfExp]='" + stringArray[i + 3].ToString() + "',[Amount]='" + stringArray[i + 4].ToString() + "',[Description]='" + stringArray[i + 5].ToString() + "',[Mode]='" + stringArray[i + 6].ToString() + "' where ID='" + stringArray[i] + "' ";
                result = cc.ExecuteNonQuery(str1);
                string str = "select ID from [Come2myCityDB].[dbo].[tbl_BExpenditureE] where ID='" + stringArray[i] + "'";
                string str7 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str7 + "*";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {


                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    private string IssueLoan(string BString, string LoginMobileNo)
    {
        string[] stringArray = BString.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 8)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {

                cmd.Parameters.Add(new SqlParameter("@MID", stringArray[i + 1].ToString()));
                //cmd.Parameters.Add(new SqlParameter("@PreBalance", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoanAmt", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DateOfIssue", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MInstalment", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DueDate", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", stringArray[i + 6].ToString()));

                cmd.CommandText = "uspBInsertIssueLoan";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_BIssueLoan] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@ID",stringArray[i]),
                    new SqlParameter("@MID",stringArray[i+1]),
                    new SqlParameter("@LoanAmt",stringArray[i+2]),new SqlParameter("@DateOfIssue",stringArray[i+3]),
                    new SqlParameter("@MInstalment",stringArray[i+4]),new SqlParameter("@DueDate",stringArray[i+5]),
                    new SqlParameter("@LoginMobileNo",LoginMobileNo),
                     new SqlParameter("@EntryDate",stringArray[i+6])   
                };
                //cmd.Parameters.AddRange(par);
                //cmd.CommandText = "[sp_UEDeath]";
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (cmd.Connection.State == ConnectionState.Closed)
                //    cmd.Connection.Open();
                //result = cmd.ExecuteNonQuery();
                string str1 = "update [Come2myCityDB].[dbo].[tbl_BIssueLoan] set [MID]='" + stringArray[i + 1].ToString() + "',[LoanAmt]='" + stringArray[i + 2].ToString() + "',[DateOfIssue]='" + stringArray[i + 3].ToString() + "',[MInstalment]='" + stringArray[i + 4].ToString() + "',[DueDate]='" + stringArray[i + 5].ToString() + "',[EntryDate]='" + stringArray[i + 6].ToString() + "' where ID='" + stringArray[i] + "' ";
                result = cc.ExecuteNonQuery(str1);
                string str = "select ID from [Come2myCityDB].[dbo].[tbl_BIssueLoan] where ID='" + stringArray[i] + "'";
                string str7 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str7 + "*";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {


                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    private string ReceiveDeposite(string BString, string LoginMobileNo)
    {
        string[] stringArray = BString.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 8)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {

                cmd.Parameters.Add(new SqlParameter("@MID", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DepositeAmt", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PaymentType", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Date", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DepositPeriod", stringArray[i + 5].ToString()));



                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", stringArray[i + 6].ToString()));


                cmd.CommandText = "uspBInsertReceiveDeposite";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_BReceiveDeposite] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@ID",stringArray[i]),
                     new SqlParameter("@MID", stringArray[i + 1].ToString()),
                    new SqlParameter("@DepositeAmt", stringArray[i + 2].ToString()),
                    new SqlParameter("@PaymentType", stringArray[i + 3].ToString()),
                    new SqlParameter("@Date", stringArray[i + 4].ToString()),
                    new SqlParameter("@DepositPeriod", stringArray[i + 5].ToString()),
                    new SqlParameter("@EntryDate", stringArray[i + 7].ToString())   
                };
                cmd.Parameters.AddRange(par);
                cmd.CommandText = "uspUpdateBReceiveDep";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select ID from [Come2myCityDB].[dbo].[tbl_BReceiveDeposite] where ID='" + stringArray[i] + "'";
                string str7 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str7 + "*";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {


                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    private string SubInstalment(string BString, string LoginMobileNo)
    {
        string[] stringArray = BString.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 8)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {

                cmd.Parameters.Add(new SqlParameter("@MID", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@SubAmt", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LInstalment", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LIMonth", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Date", stringArray[i + 5].ToString()));



                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@EnteryDate", stringArray[i + 7].ToString()));


                cmd.CommandText = "uspBInsertSubInstalment";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_BSubInstalment] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@ID",stringArray[i]),
                    new SqlParameter("@MID",stringArray[i+1]),
                    new SqlParameter("@SubAmt",stringArray[i+2]),new SqlParameter("@LInstalment",stringArray[i+3]),
                    new SqlParameter("@LIMonth",stringArray[i+4]),new SqlParameter("@Date",stringArray[i+5]),
                    new SqlParameter("@LoginMobileNo",LoginMobileNo),
                     new SqlParameter("@EnteryDate",stringArray[i+6])   
                };
                //cmd.Parameters.AddRange(par);
                //cmd.CommandText = "[sp_UEDeath]";
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (cmd.Connection.State == ConnectionState.Closed)
                //    cmd.Connection.Open();
                //result = cmd.ExecuteNonQuery();
                string str1 = "update [Come2myCityDB].[dbo].[tbl_BSubInstalment] set [MID]='" + stringArray[i + 1].ToString() + "',[SubAmt]='" + stringArray[i + 2].ToString() + "',[LInstalment]='" + stringArray[i + 3].ToString() + "',[LIMonth]='" + stringArray[i + 4].ToString() + "',[Date]='" + stringArray[i + 5].ToString() + "',[EnteryDate]='" + stringArray[i + 6].ToString() + "' where ID='" + stringArray[i] + "' ";
                result = cc.ExecuteNonQuery(str1);

                string str = "select ID from [Come2myCityDB].[dbo].[tbl_BSubInstalment] where ID='" + stringArray[i] + "'";
                string str7 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str7 + "*";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {


                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    private string Setting(string BString, string LoginMobileNo)
    {
        string[] stringArray = BString.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 17)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {

                cmd.Parameters.Add(new SqlParameter("@MemberShipFee", stringArray[i + 1].ToString()));
                //cmd.Parameters.Add(new SqlParameter("@PreBalance", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DueDateSP", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PAmount", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@AdditionalAmt", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoanLimit", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@IntOnLoan", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@IntOnDeposit", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DueDays", stringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PIntRate", stringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@BankANo", stringArray[i + 10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@BankName", stringArray[i + 11].ToString()));
                cmd.Parameters.Add(new SqlParameter("@TypeOfExp", stringArray[i + 12].ToString()));
                cmd.Parameters.Add(new SqlParameter("@FYrOfExpYrFr", stringArray[i + 13].ToString()));
                cmd.Parameters.Add(new SqlParameter("@FYrOfExpYrFrM", stringArray[i + 14].ToString()));

                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", stringArray[i + 15].ToString()));

                cmd.CommandText = "uspBInsertSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_BSSGRuleSetting] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@MemberShipFee", stringArray[i + 1].ToString()),
                //cmd.Parameters.Add(new SqlParameter("@PreBalance", stringArray[i + 2].ToString()));
                new SqlParameter("@DueDateSP", stringArray[i + 2].ToString()),
                new SqlParameter("@PAmount", stringArray[i + 3].ToString()),
                new SqlParameter("@AdditionalAmt", stringArray[i + 4].ToString()),
                new SqlParameter("@LoanLimit", stringArray[i + 5].ToString()),
                new SqlParameter("@IntOnLoan", stringArray[i + 6].ToString()),
                new SqlParameter("@IntOnDeposit", stringArray[i + 7].ToString()),
                new SqlParameter("@DueDays", stringArray[i + 8].ToString()),
                new SqlParameter("@PIntRate", stringArray[i + 9].ToString()),
                new SqlParameter("@BankANo", stringArray[i + 10].ToString()),
                new SqlParameter("@BankName", stringArray[i + 11].ToString()),
                new SqlParameter("@TypeOfExp", stringArray[i + 12].ToString()),
                new SqlParameter("@FYrOfExpYrFr", stringArray[i + 13].ToString()),
                new SqlParameter("@FYrOfExpYrFrM", stringArray[i + 14].ToString()),
               
                new SqlParameter("@LoginMobileNo", LoginMobileNo),
                new SqlParameter("@EntryDate", stringArray[i + 15].ToString()), 
                };
                //cmd.Parameters.AddRange(par);
                //cmd.CommandText = "[sp_UEDeath]";
                //cmd.CommandType = CommandType.StoredProcedure;
                //if (cmd.Connection.State == ConnectionState.Closed)
                //    cmd.Connection.Open();
                //result = cmd.ExecuteNonQuery();
                string str1 = "update [Come2myCityDB].[dbo].[tbl_BIssueLoan] set [MemberShipFee]='" + stringArray[i + 1].ToString() + "',[DueDateSP]='" + stringArray[i + 2].ToString() + "',[PAmount]='" + stringArray[i + 3].ToString() + "',[AdditionalAmt]='" + stringArray[i + 4].ToString() + "',[LoanLimit]='" + stringArray[i + 5].ToString() + "',[IntOnLoan]='" + stringArray[i + 6].ToString() + "',[IntOnDeposit]='" + stringArray[i + 7].ToString() + "',[DueDays]='" + stringArray[i + 8].ToString() + "',[PIntRate]='" + stringArray[i + 9].ToString() + "',[BankANo]='" + stringArray[i + 10].ToString() + "',[BankName]='" + stringArray[i + 11].ToString() + "',[TypeOfExp]='" + stringArray[i + 12].ToString() + "',[FYrOfExpYrFr]='" + stringArray[i + 13].ToString() + "',[FYrOfExpYrFrM]='" + stringArray[i + 14].ToString() + "',[EntryDate]='" + stringArray[i + 15].ToString() + "' where ID='" + stringArray[i] + "' ";
                result = cc.ExecuteNonQuery(str1);
                string str = "select ID from [Come2myCityDB].[dbo].[tbl_BIssueLoan] where ID='" + stringArray[i] + "'";
                string str7 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str7 + "*";
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {


                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    [WebMethod]
    public string SendData(string Keyword, string LoginMobileNo)
    {

        int i;
        if (!string.IsNullOrEmpty(Keyword) && !string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                if (Keyword.Equals("CREATEGAT"))
                {
                    return CreateGatSend(LoginMobileNo);
                }
                else if (Keyword.Equals("MEMREGISTRATION"))
                {
                    return MRegSend(LoginMobileNo);
                }
                else if (Keyword.Equals("EXPENDITURE"))
                {
                    return ExpEntries(LoginMobileNo);
                }
                else if (Keyword.Equals("ISSUELOAN"))
                {
                    return IssueLoan(LoginMobileNo);
                }
                //else if (Keyword.Equals("RECEIVEDEPOSITE"))
                //{
                //    return ReceiveDeposite(LoginMobileNo);
                //}

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
    public string CreateGatSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {

            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str1);
                string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                string str = "SELECT [GID],[GatName],[MobileNo],[EntryDate],[UserId] from [Come2myCityDB].[come2mycity].[tbl_BCreateGat] where UserId='" + str2 + "' ";

                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    //string str4 = "Update tbl_EBirthday set Status1='1',Status2='0' where UserId='" + str2 + "' ";
                    //int i = cc.ExecuteNonQuery(str4);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;

                        for (int col = 0; col < 5; col++)
                        {
                            if (col != 4)
                            {

                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

                                //returnString += count++;
                            }

                        }
                        returnString += "#";

                    }
                    return returnString;
                }
                else
                {
                    return CommonCode.NO_RECORD_FOUND.ToString();
                }
            }

            catch (SqlException ex)
            {

                return ex.Number.ToString();

            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        else
            return CommonCode.WRONG_INPUT.ToString();

    }
    public string MRegSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {

            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str1);
                string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                string str = "SELECT [ID],[SSGName],[FName],[LName],[MobileNo],[Post],[DOJ],[Status],[UserId],[EntryDate] from [Come2myCityDB].[dbo].[tbl_BMRegistration] where UserId='" + str2 + "' ";

                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    //string str4 = "Update tbl_EBirthday set Status1='1',Status2='0' where UserId='" + str2 + "' ";
                    //int i = cc.ExecuteNonQuery(str4);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;

                        for (int col = 0; col < 9; col++)
                        {
                            if (col != 9)
                            {

                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

                                //returnString += count++;
                            }

                        }
                        returnString += "#";

                    }
                    return returnString;
                }
                else
                {
                    return CommonCode.NO_RECORD_FOUND.ToString();
                }
            }

            catch (SqlException ex)
            {

                return ex.Number.ToString();

            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        else
            return CommonCode.WRONG_INPUT.ToString();

    }
    public string ExpEntries(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();
            string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
            ds = cc.ExecuteDataset(str1);
            string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

            string sql = "SELECT [ID],[Date],[VoucharNo],[TypeOfExp],[Amount],[Description],[Mode],[UserId],[EntryDate] FROM [Come2myCityDB].[dbo].[tbl_BExpenditureE] where UserId='" + str2 + "' ";
            ds = cc.ExecuteDataset(sql);

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    returnString += count++;
                    for (int col = 0; col < 8; col++)
                    {
                        if (col != 8)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    //public string ExpEntries(string LoginMobileNo)
    //{
    //    try
    //    {
    //        string returnString = string.Empty;
    //        int count = 0;
    //        DataSet ds = new DataSet();
    //        string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
    //        ds = cc.ExecuteDataset(str1);
    //        string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

    //        string sql = "SELECT [ID],[Date],[VoucharNo],[TypeOfExp],[Amount],[Description],[Mode],[UserId],[EntryDate] FROM [Come2myCityDB].[dbo].[tbl_BExpenditureE] where UserId='" + str2 + "' ";
    //        ds = cc.ExecuteDataset(sql);

    //        if (ds != null && ds.Tables[0].Rows.Count != 0)
    //        {
    //            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
    //            {
    //                returnString += count++;
    //                for (int col = 0; col < 8; col++)
    //                {
    //                    if (col != 8)
    //                    {
    //                        returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
    //                    }
    //                    else
    //                    {
    //                        returnString += ds.Tables[0].Rows[row][col].ToString();

    //                    }
    //                }
    //                returnString += "#";
    //            }
    //            return returnString;

    //        }
    //        else
    //        {
    //            return CommonCode.NO_RECORD_FOUND.ToString();
    //        }
    //    }
    //    catch (SqlException ex)
    //    {
    //        return ex.Number.ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
    //    }
    //}
    public string IssueLoan(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();
            string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
            ds = cc.ExecuteDataset(str1);
            string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

            string sql = "SELECT [ID],[SMember],[PreBalance],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate],[UserId],[EntryDate] FROM [Come2myCityDB].[dbo].[tbl_BIssueLoan] where UserId='" + str2 + "' ";
            ds = cc.ExecuteDataset(sql);

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    returnString += count++;
                    for (int col = 0; col < 8; col++)
                    {
                        if (col != 8)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    [WebMethod]
    public string DownloadData(string Keyword, string LoginMobileNo)
    {
        int i;
        if (!string.IsNullOrEmpty(Keyword) && !string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                //if (Keyword.Equals("CREATEGAT"))
                //{
                //    return CreateGatSend(LoginMobileNo);
                //}
                //if (Keyword.Equals("MEMREGISTRATION"))
                //{
                //    return MRegSend(LoginMobileNo);
                //}
                //if (Keyword.Equals("EXPENDITURE"))
                //{
                //    return ExpEntriesDown(LoginMobileNo);
                //}
                if (Keyword.Equals("ISSUELOAN"))
                {
                    return IssueLoanDown(LoginMobileNo);
                }
                else if (Keyword.Equals("INSTALMENT"))
                {
                    return InstalmentDown(LoginMobileNo);
                }
                else if (Keyword.Equals("RECEIVEDEPOSITE"))
                {
                    return ReceiveDepositeDown(LoginMobileNo);
                }
                else if (Keyword.Equals("SETTING"))
                {
                    return Setting(LoginMobileNo);
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

    public string IssueLoanDown(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();

            string str =
                    " with Event as( " +
                    " select *from( " +
                    " (select MID as m from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='" + LoginMobileNo + "')as t " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_BIssueLoan] as t1 " +
                    " on " +
                    " t.m=t1.MID " +
                    " ) " +
                    " ) ";
            str += " SELECT [MID],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate],[Status] FROM Event where Status='0'";
            ds = cc.ExecuteDataset(str);
            string m = Convert.ToString(ds.Tables[0].Rows[0]["MID"]);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    string s1 = "update [Come2myCityDB].[dbo].[tbl_BIssueLoan] set Status='1' where MID='"+m+"' ";
                    int i = cc.ExecuteNonQuery(s1);
                    returnString += count++;
                    for (int col = 0; col < 5; col++)
                    {
                        if (col != 5)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    public string InstalmentDown(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();

            string str =
                    " with Event as( " +
                    " select *from( " +
                    " (select MID as m from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='" + LoginMobileNo + "')as t " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_BSubInstalment] as t1 " +
                    " on " +
                    " t.m=t1.MID " +
                    " ) " +
                    " ) ";
            str += " SELECT [MID],[SubAmt],[LInstalment],[LIMonth],[Date],[Status] FROM Event where Status='0'";
            ds = cc.ExecuteDataset(str);

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    string s2 = "update [Come2myCityDB].[dbo].[tbl_BSubInstalment] set Status='1'";
                    int i = cc.ExecuteNonQuery(s2);
                    returnString += count++;
                    for (int col = 0; col < 5; col++)
                    {
                        if (col != 5)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    public string ReceiveDepositeDown(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();

            string str =
                    " with Event as( " +
                    " select *from( " +
                    " (select MID as m from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='" + LoginMobileNo + "')as t " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_BReceiveDeposite] as t1 " +
                    " on " +
                    " t.m=t1.MID " +
                    " ) " +
                    " ) ";
            str += " SELECT [MID],[DepositeAmt],[PaymentType],[Date],[DepositPeriod],[Status] FROM Event where Status='0'";
            ds = cc.ExecuteDataset(str);

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    string s = "update [Come2myCityDB].[dbo].[tbl_BReceiveDeposite] set Status='1'";
                    int i = cc.ExecuteNonQuery(s);
                    returnString += count++;
                    for (int col = 0; col < 5; col++)
                    {
                        if (col != 5)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    public string Setting(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {

            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str1);
                string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                string str = "SELECT ID,[MemberShipFee],[DueDateSP],[PAmount],[AdditionalAmt],[LoanLimit],[IntOnLoan],[IntOnDeposit],[DueDays],[PIntRate],[BankANo],[BankName],[TypeOfExp],[FYrOfExpYrFr],[FYrOfExpYrFrM] from [Come2myCityDB].[dbo].[tbl_BSSGRuleSetting] where UserId='" + str2 + "' ";

                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    //string str4 = "Update tbl_EBirthday set Status1='1',Status2='0' where UserId='" + str2 + "' ";
                    //int i = cc.ExecuteNonQuery(str4);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;

                        for (int col = 0; col < 15; col++)
                        {
                            if (col != 15)
                            {

                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

                                //returnString += count++;
                            }

                        }
                        returnString += "#";

                    }
                    return returnString;
                }
                else
                {
                    return CommonCode.NO_RECORD_FOUND.ToString();
                }
            }

            catch (SqlException ex)
            {

                return ex.Number.ToString();

            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        else
            return CommonCode.WRONG_INPUT.ToString();

    }
    [WebMethod]
    public string DownloadDataAll(string Keyword, string LoginMobileNo)
    {
        int i;
        if (!string.IsNullOrEmpty(Keyword) && !string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                //if (Keyword.Equals("CREATEGAT"))
                //{
                //    return CreateGatSend(LoginMobileNo);
                //}
                //if (Keyword.Equals("MEMREGISTRATION"))
                //{
                //    return MRegSend(LoginMobileNo);
                //}
                //if (Keyword.Equals("EXPENDITURE"))
                //{
                //    return ExpEntriesDown(LoginMobileNo);
                //}
                if (Keyword.Equals("ISSUELOAN"))
                {
                    return IssueLoanDownAll(LoginMobileNo);
                }
                else if (Keyword.Equals("INSTALMENT"))
                {
                    return InstalmentDownAll(LoginMobileNo);
                }
                else if (Keyword.Equals("RECEIVEDEPOSITE"))
                {
                    return ReceiveDepositeDownAll(LoginMobileNo);
                }
                else if (Keyword.Equals("SETTING"))
                {
                    return SettingAll(LoginMobileNo);
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
    public string IssueLoanDownAll(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();

            string str =
                    " with Event as( " +
                    " select *from( " +
                    " (select MID as m from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='" + LoginMobileNo + "')as t " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_BIssueLoan] as t1 " +
                    " on " +
                    " t.m=t1.MID " +
                    " ) " +
                    " ) ";
            str += " SELECT [MID],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate],[Status] FROM Event";
            ds = cc.ExecuteDataset(str);
            string m = Convert.ToString(ds.Tables[0].Rows[0]["MID"]);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    returnString += count++;
                    for (int col = 0; col < 5; col++)
                    {
                        if (col != 5)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    public string InstalmentDownAll(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();

            string str =
                    " with Event as( " +
                    " select *from( " +
                    " (select MID as m from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='" + LoginMobileNo + "')as t " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_BSubInstalment] as t1 " +
                    " on " +
                    " t.m=t1.MID " +
                    " ) " +
                    " ) ";
            str += " SELECT [MID],[SubAmt],[LInstalment],[LIMonth],[Date],[Status] FROM Event";
            ds = cc.ExecuteDataset(str);

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    returnString += count++;
                    for (int col = 0; col < 5; col++)
                    {
                        if (col != 5)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    public string ReceiveDepositeDownAll(string LoginMobileNo)
    {
        try
        {
            string returnString = string.Empty;
            int count = 0;
            DataSet ds = new DataSet();

            string str =
                    " with Event as( " +
                    " select *from( " +
                    " (select MID as m from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='" + LoginMobileNo + "')as t " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_BReceiveDeposite] as t1 " +
                    " on " +
                    " t.m=t1.MID " +
                    " ) " +
                    " ) ";
            str += " SELECT [MID],[DepositeAmt],[PaymentType],[Date],[DepositPeriod],[Status] FROM Event";
            ds = cc.ExecuteDataset(str);

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    
                    returnString += count++;
                    for (int col = 0; col < 5; col++)
                    {
                        if (col != 5)
                        {
                            returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                        }
                        else
                        {
                            returnString += ds.Tables[0].Rows[row][col].ToString();

                        }
                    }
                    returnString += "#";
                }
                return returnString;

            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    public string SettingAll(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {

            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str1);
                string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                string str = "SELECT ID,[MemberShipFee],[DueDateSP],[PAmount],[AdditionalAmt],[LoanLimit],[IntOnLoan],[IntOnDeposit],[DueDays],[PIntRate],[BankANo],[BankName],[TypeOfExp],[FYrOfExpYrFr],[FYrOfExpYrFrM] from [Come2myCityDB].[dbo].[tbl_BSSGRuleSetting] where UserId='" + str2 + "' ";

                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    //string str4 = "Update tbl_EBirthday set Status1='1',Status2='0' where UserId='" + str2 + "' ";
                    //int i = cc.ExecuteNonQuery(str4);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;

                        for (int col = 0; col < 15; col++)
                        {
                            if (col != 15)
                            {

                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

                                //returnString += count++;
                            }

                        }
                        returnString += "#";

                    }
                    return returnString;
                }
                else
                {
                    return CommonCode.NO_RECORD_FOUND.ToString();
                }
            }

            catch (SqlException ex)
            {

                return ex.Number.ToString();

            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        else
            return CommonCode.WRONG_INPUT.ToString();

    }
}

