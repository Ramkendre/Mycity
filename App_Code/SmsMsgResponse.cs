using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SmsMsgResponse
/// </summary>
public class SmsMsgResponse
{
	public SmsMsgResponse()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string message { get; set; }

    public string jobid { get; set; }

    public string status { get; set; }
}