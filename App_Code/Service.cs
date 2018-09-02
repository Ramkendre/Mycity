using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

// NOTE: If you change the class name "Service" here, you must also update the reference to "Service" in Web.config.
public class Service : IService
{


    
#region IService Members

public ReturnResponse  Register(Registration registration)
{
    try
    {
        SqlCommand sqlcommand = new SqlCommand();
        sqlcommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        sqlcommand.CommandText = "update [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] set [GCM_Regid]='" + registration.gcmRegId + "' where  mobileNo='" + registration.mobileNo + "' and [keyword]='" + registration.appKeyword + "'";
        if (sqlcommand.Connection.State == ConnectionState.Closed)
            sqlcommand.Connection.Open();
        sqlcommand.ExecuteNonQuery();
        return new ReturnResponse { status = "1" };
    }
    catch (Exception ex)
    { return new ReturnResponse { status = "0"+ex.InnerException }; }

}

#endregion


public ReturnResponse Demo()
{
    return new ReturnResponse { status = "1" };
}


}
