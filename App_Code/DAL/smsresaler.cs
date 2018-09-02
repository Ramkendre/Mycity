using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>.
/// Summary description for smsresaler
/// </summary>
public class smsresaler
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Come2MyCityDBConnectionString"]);
	public smsresaler()
	{
		//
		// TODO: Add constructor logic here
		//
       

	}

   
}
