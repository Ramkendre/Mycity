﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_MainMaster : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {

            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
    }

    
}
