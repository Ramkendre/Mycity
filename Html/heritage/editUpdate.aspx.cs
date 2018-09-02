using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class editUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            if (updatePersonId.Text == "")
            {
                string id = Request.QueryString["id"].ToString();
                editPerson(id);
            }
        }

        if (Request.QueryString["addId"] != null)
        {
            string id = Request.QueryString["addId"].ToString();
            addPersonParentId.Text = id.ToString();
        }
    }

    public void editPerson(string id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string sql = "SELECT TOP(1) mobileNo, firstName, lastName,gender FROM heritage WHERE userId = '" + id.ToString() + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            txtFirstName.Text = dr["firstName"].ToString();
            txtLastName.Text = dr["lastName"].ToString();
            ddlGender.SelectedValue = dr["gender"].ToString().Trim();
            ddlGender.CssClass = "HideMe";
            txtMobileNo.Text = dr["mobileNo"].ToString();
            updatePersonId.Text = id.ToString();
        }
    }

    protected void btnYesClick_Click(object sender, EventArgs e)
    {
        if (updatePersonId.Text != "")
            editCurrentPerson(updatePersonId.Text);
        else
            addNewPerson(addPersonParentId.Text);
    }
    public void editCurrentPerson(string id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        byte[] MyImg = AsyncFileUpload1.FileBytes;
        byte[] bImage = new byte[1];
        if (MyImg != null)
        {
            MemoryStream ms = new MemoryStream(MyImg);
            System.Drawing.Bitmap Image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(ms);
            System.Drawing.Bitmap thimage = ResizeImage(Image, 80, 80);
            MemoryStream mm = new MemoryStream();
            thimage.Save(mm, ImageFormat.Jpeg);
            bImage = mm.ToArray();
        }
        con.Open();
        if (MyImg != null)
        {
            string sqlQuery = "update heritage set mobileNo = '" + txtMobileNo.Text + "',firstName = '" + txtFirstName.Text + "',lastName = '" + txtLastName.Text + "',photo = @photo,gender = '" + ddlGender.SelectedValue + "' where userId=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, con); // ,partner,mather,father,son1,son2,son3-,@partner,@mather,@father,@son1,@son2,@son3
            //cmd.Parameters.AddWithValue("@mobileNo", txtMobileNo.Text);
            //cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            //cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            //cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
            cmd.Parameters.Add("@photo", SqlDbType.Image, 8000).Value = bImage;
            int i = cmd.ExecuteNonQuery();
        }
        else {
            string sqlQuery = "update heritage set mobileNo = '" + txtMobileNo.Text + "',firstName = '" + txtFirstName.Text + "',lastName = '" + txtLastName.Text + "',gender = '" + ddlGender.SelectedValue + "' where userId=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, con); // ,partner,mather,father,son1,son2,son3-,@partner,@mather,@father,@son1,@son2,@son3
            //cmd.Parameters.AddWithValue("@mobileNo", txtMobileNo.Text);
            //cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            //cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            //cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
            //cmd.Parameters.Add("@photo", SqlDbType.Image, 8000).Value = bImage;
            int i = cmd.ExecuteNonQuery();
        }
        Response.Write("<script language='javascript'> { self.close() }</script>");
        //this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "", "Redirection()", true);
    }
    public void addNewPerson(string id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        byte[] MyImg = AsyncFileUpload1.FileBytes;
        byte[] bImage = new byte[1];
        if (MyImg != null)
        {
            MemoryStream ms = new MemoryStream(MyImg);
            System.Drawing.Bitmap Image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(ms);
            System.Drawing.Bitmap thimage = ResizeImage(Image, 80, 80);
            MemoryStream mm = new MemoryStream();
            thimage.Save(mm, ImageFormat.Jpeg);
            bImage = mm.ToArray();
        }
        con.Open();
        using (SqlCommand cmd = new SqlCommand("INSERT INTO heritage(mobileNo,firstName,lastName,photo,gender) VALUES (@mobileNo,@firstName,@lastName,@photo,@gender)", con)) // ,partner,mather,father,son1,son2,son3-,@partner,@mather,@father,@son1,@son2,@son3
        {
            cmd.Parameters.AddWithValue("@mobileNo", txtMobileNo.Text);
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
            //cmd.Parameters.Add("@partner", "No");
            //cmd.Parameters.Add("@mather", "No");
            //cmd.Parameters.Add("@father", txtMobileNo);
            //cmd.Parameters.Add("@son1", txtMobileNo);
            //cmd.Parameters.Add("@son2", txtMobileNo);
            //cmd.Parameters.Add("@son3", txtMobileNo);
            cmd.Parameters.Add("@photo", SqlDbType.Image, 8000).Value = bImage;
            cmd.ExecuteNonQuery();
            string relation = ddlRelation.SelectedValue.ToString();
            SqlCommand fetchLast = new SqlCommand("SELECT userId FROM heritage WHERE userId = IDENT_CURRENT('heritage')", con);
            string newRelationId = fetchLast.ExecuteScalar().ToString();
            string sqlQueryUpdate = "update heritage set " + getRelationVariable(relation) + "=" + newRelationId + " where userId = " + id;
            SqlCommand updateParentRecord = new SqlCommand(sqlQueryUpdate, con);
            updateParentRecord.ExecuteNonQuery();
            Response.Write("<script language='javascript'> { self.close() }</script>");
            // this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "", "Redirection()", true);
        }
    }

    private string getRelationVariable(string selectedRelationName)
    {
        string returnString = string.Empty;
        if (selectedRelationName == "Life_Partner")
            returnString = "partner";
        else if (selectedRelationName == "Mother")
            returnString = "mather";
        else if (selectedRelationName == "Father")
            returnString = "father";
        else if (selectedRelationName == "First_Son")
            returnString = "son1";
        else if (selectedRelationName == "Second_Son")
            returnString = "son2";
        else if (selectedRelationName == "Third_Son")
            returnString = "son3";
        return returnString;
    }

    private System.Drawing.Bitmap ResizeImage(System.Drawing.Bitmap ImagePath, int maxWidth, int maxHeight)
    {

        System.Drawing.Bitmap newImage = null;
        try
        {
            System.Drawing.Bitmap originalImage = ImagePath;// GetImageFromUrl(ImagePath);
            if (originalImage != null)
            {
                int newWidth = originalImage.Width;
                int newHeight = originalImage.Height;
                double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;

                if (originalImage.Width > originalImage.Height)
                {
                    if (aspectRatio <= 1 && originalImage.Width > maxWidth)
                    {
                        newWidth = maxWidth;
                        newHeight = (int)Math.Round(newWidth / aspectRatio);
                    }
                    else if (aspectRatio > 1 && originalImage.Height > maxHeight)
                    {
                        newHeight = maxHeight;
                        newWidth = (int)Math.Round(newHeight * aspectRatio);
                    }
                }
                else
                {
                    if (aspectRatio <= 1 && originalImage.Height > maxHeight)
                    {
                        newHeight = maxHeight;
                        newWidth = (int)Math.Round(newHeight * aspectRatio);
                    }
                    else if (aspectRatio > 1 && originalImage.Width > maxWidth)
                    {
                        newWidth = maxWidth;
                        newHeight = (int)Math.Round(newWidth / aspectRatio);
                    }
                }
                newImage = new System.Drawing.Bitmap(originalImage, newWidth, newHeight);
                //newImage = new System.Drawing.Bitmap(originalImage, 40, 40);
                newImage.SetResolution((float)newWidth, (float)newHeight);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
                originalImage.Dispose();
                g.Dispose();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
        return newImage;
    }
}
