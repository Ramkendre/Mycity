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

/// <summary>
/// Summary description for BLLConnection1
/// </summary>
public class BLLConnection1
{
    DALConnection1 conn = new DALConnection1();
	public BLLConnection1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet BLLGetMiscalRecord()
    {
        DataSet ds = conn.DALGetMiscalRecord();
        return ds;
    }
   }
