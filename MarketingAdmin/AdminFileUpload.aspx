<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AdminFileUpload.aspx.cs" Inherits="MarketingAdmin_AdminFileUpload"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" >
    function validate() 
    {
        var District = document.getElementById('<%=ddlDist.ClientID %>').value;
        var City=document.getElementById('<%=ddlCity.ClientID %>').value;

        if (District == "") 
        {
           var agree = confirm("This link will sent to selected state members, do you really want to select only state..?");

            if (agree)

                return true;

            else

                return false;

        }
        if (City == "") 
        {

            var agree = confirm("This link will sent to selected district members, do you really want to select only State & district..?");

            if (agree)

                return true;

            else

                return false;




        }
        if (District && City == "") {
            var agree = confirm("Do you really want to select only state?");

            if (agree)

                return true;

            else

                return false;

        
        }
    }
</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div style="height: 25px; width: 744px;"></div>
            <div align="left" style="width: 100%">
                <table>
                <tr>
                <td>
                    <asp:Label ID="lblgroup" runat="server" Text="Working for : "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblgroupname" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 199px" ></td>
                
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Text="Your Balance is:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBalance" runat="server" Text=""></asp:Label>
                </td>
                </tr>
               <%-- <tr>
                
                </tr>
                <tr></tr>--%>
                 </table>
            </div>
             <div style="height: 25px; width: 744px;"></div>
                <div  align="center">
                <table >
                    <tr>
                     <td>
                        <asp:Label ID="Label3" runat="server" Text="Select file to upload: "></asp:Label>
                    </td>
                        <td>
                            <asp:FileUpload ID="myFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                   
                        <td align="center" colspan="2">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" />
                        </td>
                        <td>
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                          <%-- <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>--%>
                        </td>
                    </tr>
                    </table>
                    </div>
           
           
            <div  align="center">
                <table>
                    <tr>
                        <td>
                            <div class="grid" style="width: 100%">
                                <div class="rounded">
                                    <div class="top-outer">
                                        <div class="top-inner">
                                            <div class="top">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                    <div class="mid-outer">
                                       <asp:Label ID="lblmsg" runat="server" Visible="False" Font-Bold="True" 
                                            ForeColor="Blue"></asp:Label>
                                        <div class="mid-inner">
                                            <div class="mid">
                                                <div class="pager">
                                             
                                                    <asp:GridView ID="GridUpload" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="5" CellSpacing="0" CssClass="datatable" EmptyDataText="Not uploaded any file"
                                                        GridLines="Both" PageSize="5" Width="100%" OnRowCommand="GridUpload_RowCommand"
                                                        DataKeyNames="actual_filename" 
                                                        OnPageIndexChanging="GridUpload_PageIndexChanging" 
                                                        onrowdeleting="GridUpload_RowDeleting"> 
                                                       
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Id" DataField="id" Visible="false">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Date" DataField="upload_date">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="FileName" DataField="actual_filename">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Link" DataField="url_link">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btndwnfrnd" runat="server" Text="Send Download link" CommandName="Download"
                                                                        CommandArgument='<%#Bind("id") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Bind("id") %>'
                                                                        CommandName="Delete" ImageUrl="~/resources1/images/close.gif" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                    </asp:GridView>
                                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="bottom-outer">
                                        <div class="bottom-inner">
                                            <div class="bottom">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
           
            <div id="divselectlevel" runat="server" visible="false" align="center">
                <table>
                    <tr>
                        <td style="width: 50%" align="left">
                            <asp:Label ID="Label5" runat="server" Text="Select State"></asp:Label>
                        </td>
                        <td style="width: 50%" align="left">
                            <asp:UpdatePanel ID="upState" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlState" AutoPostBack="true" runat="server" Width="200px"
                                        OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%" align="left">
                            <asp:Label ID="Label11" runat="server" Text="Select District"></asp:Label>
                        </td>
                        <td style="width: 50%" align="left">
                            <asp:UpdatePanel ID="upDistrict" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlDist" AutoPostBack="true" runat="server" Width="200px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%" align="left">
                            <asp:Label ID="Label6" runat="server" Text="Select City"></asp:Label>
                        </td>
                        <td style="width: 50%">
                            <asp:UpdatePanel ID="upCity" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCity" AutoPostBack="true" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
              <div id="divview" runat="server" visible="false">
             <div class="grid" style="width: 100%">
                                <div class="rounded">
                                    <div class="top-outer">
                                        <div class="top-inner">
                                            <div class="top">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                    <div class="mid-outer">
                                        <div class="mid-inner">
                                            <div class="mid">
                                                <div class="pager">
                                                
                                                    <asp:GridView ID="gvView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="5" CellSpacing="0" CssClass="datatable" EmptyDataText="Not uploaded any file"
                                                        GridLines="Both" PageSize="5" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Id" DataField="id" Visible="false">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="FirstName" DataField="usrFirstName">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="LastName" DataField="usrLastName">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="MobileNo" DataField="usrMobileNo">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            </Columns>
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                    </asp:GridView>
                                                    <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="bottom-outer">
                                        <div class="bottom-inner">
                                            <div class="bottom">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>
            <div id="divGroupname" align="center" runat="server" visible="false">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblfilename" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:Label ID="lbldownloadfrnd" runat="server"></asp:Label>--%>
                           <%-- <asp:Button ID="btnView" runat="server" Text="View" onclick="btnView_Click" />--%>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmitGroup" runat="server" Text=" Submit" OnClick="btnSubmitGroup_Click" OnClientClick="return validate()" />
                        </td>
                    </tr>
                    
                </table>
            </div>
           
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
         <%--   <asp:AsyncPostBackTrigger ControlID="GridUpload" EventName="">--%>
   <asp:PostBackTrigger ControlID="GridUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
