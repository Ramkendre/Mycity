using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class html_ReceiveAndroidLongcodeSMS : System.Web.UI.Page
{
    LongCodeBLL balobj = new LongCodeBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            GetAndroidLongcode();
        }
        catch (Exception ex)
        {
        }

    }
    public void GetAndroidLongcode()
    {
        try
        {
            DataSet ds = balobj.BLLgetlongcoderecord(balobj);
            allRecordGrid.DataSource = ds.Tables[0];
            allRecordGrid.DataBind();
            foreach (GridViewRow row in allRecordGrid.Rows)
            {
                string Data = row.Cells[36].Text.ToString();
               
                if (Data == "0")
                {
                    row.Cells[36].Text = "No";
                }
                else
                {
                    row.Cells[36].Text = "Yes";
                }

            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void allRecordGrid_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        try
        {
            allRecordGrid.PageIndex = e.NewPageIndex;
            GetAndroidLongcode();
        }
        catch (Exception ex)
        {
        }

    }

    //private string Get(string url)
    //{

    //    string text = "";
    //    List<string> myCollection = new List<string>();
    //    int a1;
    //    char character;
    //    string[] a = url.Split(',');

    //    for (int i = 0; i < a.Length; i++)
    //    {

    //        a1 = Convert.ToInt32(a[i]);
    //        character = (char)a1;
    //        text = character.ToString();
    //        myCollection.Add(text);
    //    }
    //    string resulr = String.Join("", myCollection.ToArray());
    //    return resulr;

    //}
}
