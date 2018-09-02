<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftNavigation.ascx.cs"
    Inherits="UserControl_LeftNavigation" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data " %>
<div>
<div runat="server" id="pmenu">
    <%
        try
        {
            string parentMenu = this.GetParent();
            string[] arr = parentMenu.Split(',');
            List<CategoryBLL> lst = new List<CategoryBLL>();
            int j = Convert.ToInt32(Convert.ToString(Session["City"]));
            //lst = LeftCategoryMenu(1, j);
            lst = LeftCategoryMenu(-1, j);
            int[] intarrmenu = ReturnMenu(j);




            for (int i = 0; i < lst.Count; i++)
            {
                int cat1 = lst[i].categoryId;
                if (Array.IndexOf(intarrmenu, cat1) >= 0)
                {
             %>
        
    <a href="../html/SearchByCity.aspx?Id=<%=lst[i].categoryId %>">
        <%=lst[i].categoryName.ToString()%></a>
    <br />
    <%
           
        string firstmenu = Convert.ToString(lst[i].categoryId);
        if (checkMenuList(arr, firstmenu))
        {
            try
            {

                List<CategoryBLL> lst1 = new List<CategoryBLL>();
                lst1 = LeftCategoryMenu(Convert.ToInt32(lst[i].categoryId), j);

                for (int x = 0; x < lst1.Count; x++)
                {
                    int cat2 = lst1[x].categoryId;
                    if (Array.IndexOf(intarrmenu, cat2) >= 0)
                    {
    %>
    &nbsp; &nbsp; <a href="../html/SearchByCity.aspx?Id=<%=lst1[x].categoryId %>">
        <%=lst1[x].categoryName.ToString()%></a>
    <br />
    <%
        string secondmenu = Convert.ToString(lst1[x].categoryId);
        if (checkMenuList(arr, secondmenu))
        {
            try
            {
                List<CategoryBLL> lst2 = new List<CategoryBLL>();
                lst2 = LeftCategoryMenu(Convert.ToInt32(lst1[x].categoryId), j);
                for (int y = 0; y < lst2.Count; y++)
                {
                    int cat3 = lst2[y].categoryId;
                    if (Array.IndexOf(intarrmenu, cat3) >= 0)
                    {
    %>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../html/SearchByCity.aspx?Id=<%=lst2[y].categoryId %>">
        <%=lst2[y].categoryName.ToString()%></a>
    <br />
    <%
        }
                }//end of for Y


            }//End of Try
            catch (Exception ex) { string m = ex.Message; }
    %>
    <%
        } //End of for x
                    }
                }
            }
            catch (Exception ex) { string m = ex.Message; } %>
    <%}
                }
            }
        }
        catch (Exception ex) { string m = ex.Message; }%>
</div>

<div>
<%
    //if (lst.Count > 0)       
    {
    %>
  <%--<a href="../UI/DisplayInitialPoliticalProfile.aspx?pid=1">Political Person</a>
 <br />

  <asp:Panel ID="pmenu" runat="server" >
     <a href="" style="padding-left:12px;">MP</a><br />
     <a href="" style="padding-left:12px;">MLA</a><br />
     <a href="" style="padding-left:12px;">MM</a><br />
     <a href=""style="padding-left:12px;">MP</a><br />
   </asp:Panel>--%>
<%} %>
  
</div></div>
