using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class UserControl_LeftNavigation : System.Web.UI.UserControl
{
    CategoryBLL catgoryBLLObj = new CategoryBLL();
    CommonCode cc = new CommonCode();
    SqlConnection myCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    public string MainMenu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string id = Convert.ToString(Request.QueryString["pid"]);

                if (id == null || id == "")
                {
                    //pmenu.Visible = false;
                }
                else
                {
                    //pmenu.Visible = true;
                }
            }
        }
        catch (Exception ex)
        { throw; }
    }

    
    public List<CategoryBLL> LeftCategoryMenu(int i,int j)
    {
        List<CategoryBLL> menuList;
        try
        {
            menuList = new List<CategoryBLL>();
            menuList = catgoryBLLObj.BLLGetLeftCategoryMenu(i,j);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return menuList;
    } 
    public string GetParent()
    {
        string menuId;
        string rId = Convert.ToString(Request.QueryString["Id"]);
        menuId = catgoryBLLObj.BLLGetMenuParent(rId);
        return menuId;
    }

    public bool checkMenuList(string[] arr, string value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].ToString() == value)
            {
                return true;
            }
        }
        return false;
    }

    public int[] ReturnMenu(int cityId)
    {
        int[] menu= new int[100];//= {2,3,4,5,7,8,9};
        //int  a= Array.IndexOf(menu, 6);
        int i = 0;
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT     categoryId, parentCategoryId FROM         Category " +
                     " WHERE     (categoryId IN(SELECT DISTINCT categoryId FROM          ItemCategory " +
                     " WHERE      (itemId IN (SELECT     itemId   FROM          Item " +
                                                         "WHERE      (cityId = "+cityId+")))))";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            int menuid=Convert.ToInt32(dr["categoryId"]);
            if(Array.IndexOf(menu,menuid)==-1)
            {
                menu[i] = menuid;
                i++;
            }

            int parentId = Convert.ToInt32(dr["parentCategoryId"]);
            if (parentId != -1)
            {
                if (Array.IndexOf(menu, parentId ) == -1)
                {
                    menu[i] = parentId;
                    i++;
                }
                parentId = getParent(parentId);
                if (parentId != -1)
                {
                    if (Array.IndexOf(menu, parentId) == -1)
                    {
                        menu[i] = parentId;
                        i++;
                    }
                    //parentId = getParent(parentId);
                }
            }
        }
        dr.Close();
        cmd.Dispose();
        con.Close();

        return menu;

        //List<string> lst = new List<string>();
       
    }

    private int  getParent(int menuid)
    {
        int parentid = 0;
        try
        {
            SqlConnection myCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            myCon.Open();
            SqlCommand cmd = myCon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select parentCategoryId FROM   Category where categoryId=" + menuid + "";
            parentid = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            myCon.Close();
        }
        catch (Exception ex)
        { }
        return parentid;
    }
}
