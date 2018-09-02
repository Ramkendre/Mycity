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
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class MyImg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        string id = Request.QueryString["usrAutoId"];
        //string sql = "select * from come2mycity.storeimage where usrAutoId=" + id;
        SqlCommand cmd = new SqlCommand("select * from storeimage where usrAutoId=" + id, con);
       // SqlCommand cmd = new SqlCommand(sql,con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            byte[] MyImg = (byte[])dr["image"];
            MemoryStream ms = new MemoryStream(MyImg);
            System.Drawing.Bitmap Image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(ms);
            Response.ContentType = "image/jpeg";
            int imgWidth = 0;
            int imgHeight = 0;
            imgWidth = Convert.ToInt32(Request.QueryString["width"]);
            imgHeight = Convert.ToInt32(Request.QueryString["Hight"]);

            System.Drawing.Bitmap thimage = ResizeImage(Image, imgWidth, imgHeight);
            if (thimage != null)
            {
                thimage.Save(Response.OutputStream, ImageFormat.Jpeg);
                thimage.Dispose();
            }
        }

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
