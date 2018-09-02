using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public partial class MethodInvokeWithJQuery : System.Web.UI.Page
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _mobileNo;
        private string _relation;
        private string _photoPath;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Relation
        {
            get { return _relation; }
            set { _relation = value; }
        }
        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }

        public string PhotoPath
        {
            get { return _photoPath; }
            set { _photoPath = value; }
        }
    }
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string personId = string.Empty;
        if (Request.QueryString["id"] != null)
            personId = Request.QueryString["id"].ToString();
        if (personId == "")
            personId = getPersonId();
        loadPerson(personId);
    }

    private string getPersonId()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        SqlCommand cmd = new SqlCommand("Select userId from heritage where cityUserId ='" + Session["User"].ToString() + "'", con);
        string PersonId = cmd.ExecuteScalar().ToString();
        con.Close();
        return PersonId;
    }

    public void loadPerson(string personId)
    {
        bool showMaleFemale = true; // Show males = teue, females = false.
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string sql = "SELECT TOP(1) userId,mobileNo, firstName, lastName,gender, partner, mather, father, son1, son2, son3 FROM heritage WHERE userId = '" + personId.ToString() + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            string sqlAll = "";
            string relatives = "";
            if (dr["gender"].ToString().Trim() == "Male")
            {
                malePersonImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                malepersonFirstName.Text = dr["firstName"].ToString();
                malepersonLastName.Text = dr["lastName"].ToString();
                malepersonMobileNo.Text = dr["mobileNo"].ToString();
                malePersonId.Text = dr["userId"].ToString();

                sqlAll = "";
                if (dr["partner"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["partner"].ToString();
                    relatives += "A,";
                }
                if (dr["mather"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["mather"].ToString();
                    relatives += "B,";
                }
                if (dr["father"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["father"].ToString();
                    relatives += "C,";
                }
                if (dr["son1"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["son1"].ToString();
                    relatives += "D,";
                }
                if (dr["son2"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["son2"].ToString();
                    relatives += "E,";
                }
                if (dr["son3"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["son3"].ToString();
                    relatives += "F";
                }
                malePersonId.Text = dr["userId"].ToString();
                loadMaleRelatives(sqlAll, relatives);
                showMaleFemale = true;
            }
            else
            {
                femalePersonImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                femalePersonFirstName.Text = dr["firstName"].ToString();
                femalePersonLastName.Text = dr["lastName"].ToString();
                femalePersonMobileNo.Text = dr["mobileNo"].ToString();
                femalePersonId.Text = dr["userId"].ToString();

                sqlAll = "";
                if (dr["partner"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["partner"].ToString();
                    relatives += "A,";
                }
                if (dr["mather"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["mather"].ToString();
                    relatives += "B,";
                }
                if (dr["father"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["father"].ToString();
                    relatives += "C,";
                }
                if (dr["son1"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["son1"].ToString();
                    relatives += "D,";
                }
                if (dr["son2"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["son2"].ToString();
                    relatives += "E,";
                }
                if (dr["son3"].ToString() != "")
                {
                    sqlAll += "SELECT mobileNo, firstName, lastName, userId FROM heritage WHERE userId = " + dr["son3"].ToString();
                    relatives += "F";
                }
                loadFemaleRelatives(sqlAll, relatives);
                showMaleFemale = false;
            }

            if (showMaleFemale == true)
                maleFemaleVisitor.CssClass = "show-males";
            else
                maleFemaleVisitor.CssClass = "show-females";

        }

    }

    public void loadMaleRelatives(string sql, string relatives)
    {
        if (relatives.Split(',').Length > 1)
        {
            DataSet ds = cc.ExecuteDataset(sql);
            if (relatives.Contains("A") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "A")].Rows) // Partner - male
                {
                    femalePersonImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    femalePersonFirstName.Text = dr["firstName"].ToString();
                    femalePersonLastName.Text = dr["lastName"].ToString();
                    femalePersonMobileNo.Text = dr["mobileNo"].ToString();
                    femalePersonId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("B") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "B")].Rows) // Mother
                {
                    personMotherFatherImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    personMotherFatherFirstName.Text = dr["firstName"].ToString();
                    personMotherFatherLastName.Text = dr["lastName"].ToString();
                    personMotherFatherMobileNo.Text = dr["mobileNo"].ToString();
                    personMotherFatherId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("C") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "C")].Rows) // Father
                {
                    personFatherImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    personFatherFirstName.Text = dr["firstName"].ToString();
                    personFatherLastName.Text = dr["lastName"].ToString();
                    personFatherMobileNo.Text = dr["mobileNo"].ToString();
                    personFatherId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("D") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "D")].Rows) // Son1
                {
                    son1Img.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    son1FirstName.Text = dr["firstName"].ToString();
                    son1LastName.Text = dr["lastName"].ToString();
                    son1MobileNo.Text = dr["mobileNo"].ToString();
                    sonfirstId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("E") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "E")].Rows) // Son2
                {
                    son2Img.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    son2FirstName.Text = dr["firstName"].ToString();
                    son2LastName.Text = dr["lastName"].ToString();
                    son2MobileNo.Text = dr["mobileNo"].ToString();
                    sonsecondId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("F") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "F")].Rows) // Son3
                {
                    son3Img.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    son3FirstName.Text = dr["firstName"].ToString();
                    son3LastName.Text = dr["lastName"].ToString();
                    son3MobileNo.Text = dr["mobileNo"].ToString();
                    sonthirdId.Text = dr["userId"].ToString();
                }
        }
    }

    public void loadFemaleRelatives(string sql, string relatives)
    {
        if (relatives.Split(',').Length > 1)
        {
            DataSet ds = cc.ExecuteDataset(sql);
            if (relatives.Contains("A") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "A")].Rows) // Partner - male
                {
                    malePersonImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    malepersonFirstName.Text = dr["firstName"].ToString();
                    malepersonLastName.Text = dr["lastName"].ToString();
                    malepersonMobileNo.Text = dr["mobileNo"].ToString();
                    malePersonId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("B") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "B")].Rows) // Mother
                {
                    personMotherImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    personMotherFirstName.Text = dr["firstName"].ToString();
                    personMotherLastName.Text = dr["lastName"].ToString();
                    personMotherMobileNo.Text = dr["mobileNo"].ToString();
                    personMotherId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("C") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "C")].Rows) // Father
                {
                    personMotherFatherImg.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    personMotherFatherFirstName.Text = dr["firstName"].ToString();
                    personMotherFatherLastName.Text = dr["lastName"].ToString();
                    personMotherFatherMobileNo.Text = dr["mobileNo"].ToString();
                    personMotherFatherId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("D") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "D")].Rows) // Son1
                {
                    son1Img.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    son1FirstName.Text = dr["firstName"].ToString();
                    son1LastName.Text = dr["lastName"].ToString();
                    son1MobileNo.Text = dr["mobileNo"].ToString();
                    sonfirstId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("E") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "E")].Rows) // Son2
                {
                    son2Img.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    son2FirstName.Text = dr["firstName"].ToString();
                    son2LastName.Text = dr["lastName"].ToString();
                    son2MobileNo.Text = dr["mobileNo"].ToString();
                    sonsecondId.Text = dr["userId"].ToString();
                }
            if (relatives.Contains("F") == true)
                foreach (DataRow dr in ds.Tables[getMyDataSetId(relatives, "F")].Rows) // Son3
                {
                    son3Img.ImageUrl = "MyImg.aspx?width=80&Hight=80&id=" + dr["userId"].ToString();
                    son3FirstName.Text = dr["firstName"].ToString();
                    son3LastName.Text = dr["lastName"].ToString();
                    son3MobileNo.Text = dr["mobileNo"].ToString();
                    sonthirdId.Text = dr["userId"].ToString();
                }
        }
    }

    private int getMyDataSetId(string relativesArrayString, string character)
    {
        int myDtPlace = 0;
        for (int count = 0; count < relativesArrayString.Split(',').Length; count++)
        {
            if (relativesArrayString.Split(',')[count].ToString() == character)
            {
                myDtPlace = count;
                break;
            }
        }
        return myDtPlace;
    }

    protected void btnYesClick_Click(object sender, EventArgs e)
    {
        addNewPerson();
    }

    public void addNewPerson()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        byte[] MyImg = AsyncFileUpload1.FileBytes;
        MemoryStream ms = new MemoryStream(MyImg);
        System.Drawing.Bitmap Image = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(ms);
        System.Drawing.Bitmap thimage = ResizeImage(Image, 80, 80);
        MemoryStream mm = new MemoryStream();
        thimage.Save(mm, ImageFormat.Jpeg);
        byte[] bImage = mm.ToArray();
        con.Open();
        using (SqlCommand cmd = new SqlCommand("INSERT INTO heritage(mobileNo,firstName,lastName,photo,gender) VALUES (@mobileNo,@firstName,@lastName,@photo,@gender)", con)) // ,partner,mather,father,son1,son2,son3-,@partner,@mather,@father,@son1,@son2,@son3
        {
            cmd.Parameters.AddWithValue("@mobileNo", txtMobileNo.Text);
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
            cmd.Parameters.Add("@photo", SqlDbType.Image, 8000).Value = bImage;
            cmd.ExecuteNonQuery();
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

    [WebMethod]
    public static string MethodWithNoParameter()
    {
        return "Message from server.";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strParam"></param>
    /// <returns></returns>
    [WebMethod]
    public static void deletePerson(string strParam)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        string sql = "delete from heritagePerson where mobileNo='" + strParam + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsonParam"></param>
    /// <returns></returns>
    [WebMethod]
    public static string addPerson(object jsonParam)
    {
        Person objPerson = GetPerson(jsonParam);
        string oldPath = objPerson.PhotoPath.ToString();
        string path = oldPath.Replace("\\", "/");
        string[] pathArr = path.Split('/');
        string finalPath = "../personImg/" + pathArr[pathArr.Length - 1];
        if (MethodInvokeWithJQuery.checkMobileUnique(objPerson.MobileNo.ToString()))
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            con.Open();
            string sql = "insert into heritagePerson(mobileNo,relation,firstName,lastName,photoPath) values('" + objPerson.MobileNo + "','" + objPerson.Relation + "','" + objPerson.FirstName + "','" + objPerson.LastName + "','" + objPerson.PhotoPath + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                return "Parameter sent to server from client side as follows:<br/>First Name => " +
                    objPerson.FirstName + "<br/>Last Name => " + objPerson.LastName + "<br/>Mobile No: => " + objPerson.MobileNo + "<br/> Relation:" + objPerson.Relation + "<br/>Photo Path:" + finalPath;
            }
            else
            {
                return "Error in storing record.";
            }
        }
        else
        {
            return "Error in storing record.";
        }
        return "";
    }

    [WebMethod]
    public static string updatePerson(object jsonParam)
    {
        Person objPerson = GetPerson(jsonParam);
        string oldPath = objPerson.PhotoPath.ToString();
        string path = oldPath.Replace("\\", "/");
        string[] pathArr = path.Split('/');
        string finalPath = "../personImg/" + pathArr[pathArr.Length - 1];
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        string sql = "update heritagePerson set relation='" + objPerson.Relation + "',firstName='" + objPerson.FirstName + "',lastName='" + objPerson.LastName + "',photoPath='" + objPerson.PhotoPath + "' where mobileNo='" + objPerson.MobileNo + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result > 0)
        {
            return "Parameter sent to server from client side as follows:<br/>First Name => " +
                objPerson.FirstName + "<br/>Last Name => " + objPerson.LastName + "<br/>Mobile No: => " + objPerson.MobileNo + "<br/> Relation:" + objPerson.Relation + "<br/>Photo Path:" + finalPath;
        }
        else
        {
            return "Error in storing record.";
        }
    }

    public static bool checkMobileUnique(string mobileNo)
    {
        bool flag = false;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        string sql = "select mobileNo from heritagePerson where mobileNo='" + mobileNo + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        string result = (string)cmd.ExecuteScalar();
        if (result == null)
        {
            return true;
        }
        con.Close();
        return flag;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Person"></param>
    /// <returns></returns>
    public static Person GetPerson(object Person)
    {
        Person objPerson = new Person();
        Dictionary<string, object> tmp = (Dictionary<string, object>)Person;

        object objFirstName = null;
        object objLastName = null;
        object objRelation = null;
        object objMobileNo = null;
        object objPhotoPath = null;

        tmp.TryGetValue("FirstName", out objFirstName);
        tmp.TryGetValue("LastName", out objLastName);
        tmp.TryGetValue("Relation", out objRelation);
        tmp.TryGetValue("MobileNo", out objMobileNo);
        tmp.TryGetValue("PhotoPath", out objPhotoPath);

        objPerson.FirstName = objFirstName.ToString();
        objPerson.LastName = objLastName.ToString();
        objPerson.Relation = objRelation.ToString();
        objPerson.MobileNo = objMobileNo.ToString();
        objPerson.PhotoPath = objPhotoPath.ToString();

        return objPerson;
    }
    protected void addNewPersonNew1_Click(object sender, EventArgs e)
    {

    }
}
