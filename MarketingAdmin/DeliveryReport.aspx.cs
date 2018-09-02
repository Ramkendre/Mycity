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
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using ClassCommon;
//using Word = Microsoft.Office.Interop.Word;

using System.Text.RegularExpressions;

public partial class SendMsg : System.Web.UI.Page
{
    //string path = "";
    //public static Object destName1 = "";
    //Object ConfirmConversions = false;
    //Object isVisible = false;
    //object missing = System.Reflection.Missing.Value;
    //object savefile = false;

    //Word._Document doc;
    //Word._Application app;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsgSent.Text = "Total Message Sent:";
        lblTotalAmt.Text = "Total Amount:";
        txtDate.Text = System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
        if (!IsPostBack)
        {
            DateRow1.Style["display"] = "none";
            DateRow2.Style["display"] = "none";
            DataRow3.Style["display"] = "none";
        }
                
            if (chkdate.Checked == false)
            {
                DateRow1.Style["display"] = "none";
                DateRow2.Style["display"] = "none";
            }
            if (chkMobile.Checked == false)
                DataRow3.Style["display"] = "none";

            dt = new DataTable("Outbox");
            dt.Columns.Add("msgId");
            dt.Columns.Add("mobileNo");
            dt.Columns.Add("status");
            dt.Columns.Add("recievedDate");
            dt.Columns.Add("callRate");
            dt.Columns.Add("message");
            dt.Columns.Add("SendDate");

            dstbl = new DataSet();
            dstbl.Tables.Add(dt);

    }
   

    DataSet dstbl = null;
    DataTable dt = null;
    Double totalRate = 0;    

    protected void btnGet_Click(object sender, EventArgs e)
    {
        string fromDate=txt_FormDate.Text;
        string toDate = txt_ToDate.Text;
        string str = "", str1 = "", str2 = "";
        string line = "";

        if (chkdate.Checked == false)
        {
            fromDate = System.DateTime.Now.ToString();
            fromDate = System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year + " 01:00:00";
            toDate = System.DateTime.Now.ToShortDateString();
            toDate = System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year + " 23:59:59";
            //str = "http://api.smscountry.com/smscwebservices_bulk_reports.aspx?user=ezeesoft&passwd=67893&fromdate=" + fromDate + " &todate=" + toDate + "";

            str = "http://api.smscountry.com/smscwebservices_bulk_reports.aspx?user=ezeesoft&passwd=92589&fromdate=" + fromDate + " &todate=" + toDate + "";

            WebClient web = new WebClient();
            System.IO.Stream stream = web.OpenRead(str);
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            line = reader.ReadToEnd();
        }
        else
        {
            fromDate = DTInsert_Local(fromDate);           
            toDate = DTInsert_Local(toDate);

            //str1 = "http://api.smscountry.com/smscwebservices_bulk_reports.aspx?user=ezeesoft&passwd=67893&fromdate=" + fromDate + " 00:01:01 &todate=" + fromDate + " 23:59:59";
            //str2 = "http://api.smscountry.com/smscwebservices_bulk_reports.aspx?user=ezeesoft&passwd=67893&fromdate=" + toDate + " 01:00:00 &todate=" + toDate + " 23:59:59";

            str1 = "http://api.smscountry.com/smscwebservices_bulk_reports.aspx?user=ezeesoft&passwd=92589&fromdate=" + fromDate + " 00:01:01 &todate=" + fromDate + " 23:59:59";
            str2 = "http://api.smscountry.com/smscwebservices_bulk_reports.aspx?user=ezeesoft&passwd=92589&fromdate=" + toDate + " 01:00:00 &todate=" + toDate + " 23:59:59";


            //WebClient web = new WebClient();
            //System.IO.Stream stream = web.OpenRead(str1);
            //System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            //line = reader.ReadToEnd();
            WebClient client = new WebClient();
            line = client.DownloadString(str1);


            string[] p1 = line.Split('#');

            //WebClient web2 = new WebClient();
            //System.IO.Stream stream2 = web.OpenRead(str2);
            //System.IO.StreamReader reader2 = new System.IO.StreamReader(stream2);
            //string line2 = reader2.ReadToEnd();
            

            WebClient client2 = new WebClient();
            string line2 = client2.DownloadString(str2);

            string[] p2 = line2.Split('#');
            line = line + "#" + line2;
            string[] lineData = line.Split('#');
        }
        try
        {           
            //while ((line = reader.ReadLine()) != null)
            {
                Function(line);
            }
        }
        catch(Exception ex)
        {
        }
        finally
        {
            displayGrid();
        }

        //displayGrid();

    # region comment search done _for getting web Contents
        //string url="C:\\Users\\OM\\Desktop

      //  WebClient client = new WebClient();
      //  string downloadString = client.DownloadString(str);

        //WebRequest request = WebRequest.Create(str);
        //WebResponse response = request.GetResponse();
        //Stream data3 = response.GetResponseStream();
        //string html = String.Empty;
        //using (StreamReader sr = new StreamReader(data3))
        //{
        //    html = sr.ReadToEnd();
        //}

      
      

        

        //while (sr.Peek() >= 0)
        //{
          
        //    //The output will look odd, because
        //    //only five characters are read at a time.
        //    Console.WriteLine(c);
        //}

        

        //using (StreamReader reader = new StreamReader(@"c:\index.html"))
        //{
        //    String line = "";
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        Console.WriteLine(line);
        //    }
        //}
      
   

        //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(str);
        //myRequest.Method = "GET";
        //WebResponse myResponse = myRequest.GetResponse();
        //StreamReader sr3 = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
        //string result = sr3.ReadLine();
        //sr3.Close();
        //myResponse.Close();


    #endregion

        # region comment Document(.docx)) Parsing
        //dstbl = new DataSet();

        //SqlDataAdapter Adap = new SqlDataAdapter();
        //SqlCommandBuilder Builder = new SqlCommandBuilder(Adap);

        //int rowIndex = 1;
        //string readLine = "";
        //string data = "", data2 = "";

        //doc = new Microsoft.Office.Interop.Word.Document();
        //app = new Microsoft.Office.Interop.Word.Application();

       
            //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        //    DataTable dt = new DataTable("Outbox");
        //    dt.Columns.Add("msgId");
        //    dt.Columns.Add("mobileNo");
        //    dt.Columns.Add("status");
        //    dt.Columns.Add("recievedDate");
        //    dt.Columns.Add("callRate");
        //    dt.Columns.Add("message");
        //    dt.Columns.Add("SendDate");
        //    dstbl.Tables.Add(dt);

        //    //Adap.Fill(dstbl,"Outbox");
        //    DataRow row = dstbl.Tables[0].NewRow();

        //    path = "D:\\Padmaraj MyCt\\21March\\myctin\\smsCountryApiData.docx";
        //    destName1 = path.ToString();
        //    app.Visible = false;
        //    doc = app.Documents.Open(ref destName1, ref missing, ref ConfirmConversions, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
        //Loop:
        //    while (rowIndex <= doc.Sentences.Count)
        //    {
        //        readLine = doc.Sentences[rowIndex].Text.ToString();

        //        if (readLine.Contains('#'))
        //        {
        //            string[] splitLine = readLine.Split('#');
        //            data += splitLine[0].ToString();
        //            data2 = splitLine[1].ToString();
        //            goto splitData;
        //        }
        //        else
        //        {
        //            data = readLine;
        //        }

        //        rowIndex++;
        //    }

        //splitData:
        //    {
        //        string[] splitData = data.Split('~');


        //        if (chkMobile.Checked == true)
        //        {                   
        //            if (splitData[1] == txt_MobileNo.Text)
        //            {
        //                row = dstbl.Tables[0].NewRow();
        //                row[0] = splitData[0].ToString();
        //                row[1] = splitData[1].ToString();
        //                row[2] = splitData[2].ToString();
        //                row[3] = splitData[3].ToString();
        //                row[4] = splitData[4].ToString();
        //                row[5] = splitData[5].ToString();
        //                row[6] = splitData[6].ToString();
        //                dstbl.Tables[0].Rows.Add(row);
        //                totalRate += Convert.ToSingle(row[4].ToString());
        //            }
                   
        //        }
        //        else
        //        {
        //            row = dstbl.Tables[0].NewRow();
        //            row[0] = splitData[0].ToString();
        //            row[1] = splitData[1].ToString();
        //            row[2] = splitData[2].ToString();
        //            row[3] = splitData[3].ToString();
        //            row[4] = splitData[4].ToString();
        //            row[5] = splitData[5].ToString();
        //            row[6] = splitData[6].ToString();
        //            dstbl.Tables[0].Rows.Add(row);
        //            totalRate += Convert.ToSingle(row[4].ToString());
        //        }


        //        rowIndex++;
        //        data = data2;
        //        goto Loop;
        //    }


       
            //((Word._Document)doc).Close(ref savefile, ref  missing, ref  missing);
            //((Word._Application)app).Quit(ref savefile, ref  missing, ref  missing);

        //displayGrid();
        # endregion
    }
    string data2 = "";
    protected void Function(String line)
    {
        string[] lineData = line.Split('#');
        
        try
        {
            foreach (string data in lineData)
            {
                string[] splitData = data.Split('~');
                data2 += data;
                splitData = data2.Split('~');
                if (splitData.Length != 7)
                {
                   
                    throw new Exception();
                }
               
                DataRow row = dstbl.Tables[0].NewRow();

                if (chkMobile.Checked == true)
                {
                    if (splitData[1] == txt_MobileNo.Text)
                    {
                        row = dstbl.Tables[0].NewRow();
                        row[0] = splitData[0].ToString();
                        row[1] = splitData[1].ToString();
                        row[2] = splitData[2].ToString();
                        row[3] = splitData[3].ToString();
                        row[4] = splitData[4].ToString();
                        row[5] = splitData[5].ToString();
                        row[6] = splitData[6].ToString();
                        dstbl.Tables[0].Rows.Add(row);
                        totalRate += Convert.ToDouble(row[4].ToString());
                    }

                }
                else
                {
                    row = dstbl.Tables[0].NewRow();
                    row[0] = splitData[0].ToString();
                    row[1] = splitData[1].ToString();
                    row[2] = splitData[2].ToString();
                    row[3] = splitData[3].ToString();
                    row[4] = splitData[4].ToString();
                    row[5] = splitData[5].ToString();
                    row[6] = splitData[6].ToString();
                    dstbl.Tables[0].Rows.Add(row);
                    totalRate += Convert.ToDouble(row[4].ToString());
                }
                data2 = "";
            }
           
        }
        catch { }
        finally
        {
            int totalMsg = dstbl.Tables[0].Rows.Count;
            lblMsgSent.Text += " " + totalMsg.ToString();
            lblTotalAmt.Text += " " + totalRate.ToString();            
        }
    }

    public string DTInsert_Local(string Date1)//07-11-2012//07/11/2012
    {
        string Date = "";
        string time = System.DateTime.Now.ToString();
        string[] tm = time.Split(' ');
        try
        {
            string[] tmp = Date1.Split(' ');

            tmp = tmp[0].Split('/');
            Date = tmp[1].ToString() + "/" + tmp[0].ToString() + "/" + tmp[2].ToString() + " ";// +tm[1];
        }
        catch (Exception ex)
        { }
        return Date;
    }





    public void displayGrid()
    {
        DataView myView = new DataView();

        myView = dstbl.Tables[0].DefaultView;

        myView.Sort = "msgId Desc";  // write Desc for sorting in descending order

        gridDelivery.DataSource = myView;
        gridDelivery.DataBind();
    }

    protected void chkdate_CheckedChanged(object sender, EventArgs e)
    {
        if (chkdate.Checked == true)
        {
            DateRow1.Style["display"] = "block";
            DateRow2.Style["display"] = "block";
        }
        else
        {
            DateRow1.Style["display"] = "none";
            DateRow2.Style["display"] = "none";
        }
    }
    protected void chkMobile_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMobile.Checked == true)
            DataRow3.Style["display"] = "block";
        else
            DataRow3.Style["display"] = "none";
    }
    protected void gridDelivery_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridDelivery.PageIndex = e.NewPageIndex;
        displayGrid();
    }
}