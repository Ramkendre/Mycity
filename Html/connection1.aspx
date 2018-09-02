<%@ Page Language="C#" AutoEventWireup="true" CodeFile="connection1.aspx.cs" Inherits="Html_connection1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
     <table class="tblSubFull2">
                        <tr>
                            <td>
    <div style=" height: 200px; border: 3px double #dddddd; ">
    <div border: 4px solid #dddddd;>
        <asp:GridView ID="allRecordGrid" runat="server" AllowPaging="true" AutoGenerateColumns="False" CssClass="gridview"
            PageSize="10" onpageindexchanging="allRecordGrid_PageIndexChanging">
            <Columns>
            <asp:BoundField DataField="cid" HeaderText="Id">
                <headerstyle horizontalalign="Center" width="10%"  BackColor="Aquamarine" BorderStyle="Groove"/>
                <itemstyle horizontalalign="Center" width="10%" BackColor="AliceBlue" />
            </asp:BoundField>
            <asp:BoundField DataField="mobileNumber" HeaderText="Mobile">
                <headerstyle horizontalalign="Center" width="25%" BackColor="Aquamarine" />
                <itemstyle horizontalalign="Center" width="20%" BackColor="AliceBlue" />
            </asp:BoundField>
            <asp:BoundField DataField="MIMENumber" HeaderText="IMEINO">
                <headerstyle horizontalalign="Center" width="25%"  BackColor="Aquamarine" />
                <itemstyle horizontalalign="Center" width="20%" BackColor="AliceBlue" />
            </asp:BoundField>
            <asp:BoundField DataField="p1" HeaderText="SIM No">
                <headerstyle horizontalalign="Center" width="25%"  BackColor="Aquamarine" />
                <itemstyle horizontalalign="Center" width="20%" BackColor="AliceBlue"/>
            </asp:BoundField>
           
             <asp:BoundField DataField="recordDate" HeaderText="Date">
                <headerstyle horizontalalign="Center" width="45%" BackColor="Aquamarine" />
                <itemstyle horizontalalign="Center" width="30%" BackColor="AliceBlue" />
            </asp:BoundField>
              <asp:BoundField DataField="p2" HeaderText="Sim Company">
                <headerstyle horizontalalign="Center" width="32%" BackColor="Aquamarine" />
                <itemstyle horizontalalign="Center" width="10%" BackColor="AliceBlue"/>
            </asp:BoundField>
                 <asp:BoundField DataField="Status" HeaderText="Status">
                <headerstyle horizontalalign="Center" width="32%" BackColor="Aquamarine" />
                <itemstyle horizontalalign="Center" width="10%" BackColor="AliceBlue"/>
            </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </div>
    </td>
                        </tr>
                    </table>
    </form>
</body>
</html>
