using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Location
/// </summary>
public class Location
{
	public Location()
	{
		
	}
    DataSet ds = new DataSet();
   

   public DataSet getAllLocation()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
              ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "getAllLocation");                

            }
            catch (SqlException ex)
            {
                ds = null;
            }
            finally
            {
                con.Close();
            }
        }
        return ds;
    }


   public DataSet GetAllLocation()
   {
       using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
       {

           try
           {
               ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DownloadGetAllLocation");

           }
           catch (SqlException ex)
           {
               ds = null;
           }
           finally
           {
               con.Close();
           }
       }
       return ds;
   }

   //public void sendEmail(string emlTo, string subject, string mailBody)
   //{
   //    MailMessage mail = new MailMessage();
   //    mail.To.Add(emlTo.ToString());
   //    mail.CC.Add("ezeesoftindia@gmail.com");
   //    //mail.To.Add("amit_jain_online@yahoo.com");
   //    mail.From = new MailAddress("myctsms@gmail.com");
   //    mail.Subject = subject.ToString();

   //    string Body = mailBody.ToString();
   //    mail.Body = Body;

   //    mail.IsBodyHtml = true;
   //    SmtpClient smtp = new SmtpClient();
   //    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
   //    smtp.Credentials = new System.Net.NetworkCredential
   //         ("myctsms@gmail.com", "myct@6789#");
   //    //Or your Smtp Email ID and Password
   //    smtp.EnableSsl = true;
   //    smtp.Send(mail);


   //}
   public void sendEmail(string eMailSend, string subject, string mailBody)
   {
       MailMessage mail = new MailMessage();
       mail.To.Add(eMailSend.ToString());
       //mail.To.Add("amit_jain_online@yahoo.com");
       mail.From = new MailAddress("myctsms@gmail.com");
       mail.Subject = subject.ToString();

       string Body = mailBody.ToString();
       mail.Body = Body;

       mail.IsBodyHtml = true;
       SmtpClient smtp = new SmtpClient();
       smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
       smtp.Credentials = new System.Net.NetworkCredential
            ("myctsms@gmail.com", "myct@6789#");
       //Or your Smtp Email ID and Password
       smtp.EnableSsl = true;
       smtp.Send(mail);


   }

   public void sendEmailMultiple(string eMailSend, string subject, string mailBody)
   {
       MailMessage mail = new MailMessage();
       mail.To.Add(eMailSend.ToString());
       //mail.To.Add("amit_jain_online@yahoo.com");
       mail.From = new MailAddress("myctsms@gmail.com");
       mail.Subject = subject.ToString();

       string Body = mailBody.ToString();
       mail.Body = Body;

       mail.IsBodyHtml = true;
       SmtpClient smtp = new SmtpClient();
       smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
       smtp.Credentials = new System.Net.NetworkCredential
            ("myctsms@gmail.com", "myct@6789#");
       //Or your Smtp Email ID and Password
       smtp.EnableSsl = true;
       smtp.Send(mail);


   }

   public void sendEmail(string eMailSend, string subject, string mailBody,string KeyWord)
   {
       if (KeyWord == "CG")
           mailBody = "\n\n आदरणीय मुख्यमंत्री महोदय मा कर्मा जयंती उत्सव के उपलक्ष में आप गुंडरदेही पधारे और छत्तीसगड के तथा साहू समाज के आधुनिक मोबाईल डिरेकट्री की शुरवात आपके हातो हुई इसलिये हम सब साहू समाज की ओरसे आपके आभारी है| बहोत बहोत धन्यवाद |  ..... www.myct.in";
       MailMessage mail = new MailMessage();
       mail.To.Add(eMailSend.ToString());
       mail.CC.Add("myctsms@gmail.com");
       //mail.To.Add("amit_jain_online@yahoo.com");
       mail.From = new MailAddress("myctsms@gmail.com");
       mail.Subject = subject.ToString();

       string Body = mailBody.ToString();
       mail.Body = Body;

       mail.IsBodyHtml = true;
       SmtpClient smtp = new SmtpClient();
       smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
       smtp.Credentials = new System.Net.NetworkCredential
            ("myctsms@gmail.com", "myct@6789#");
       //Or your Smtp Email ID and Password
       smtp.EnableSsl = true;
       smtp.Send(mail);


   }


}
