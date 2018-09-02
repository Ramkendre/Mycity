<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveAndroidLongcodeSMS.aspx.cs"
    Inherits="html_ReceiveAndroidLongcodeSMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AndroidLongCode SMS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="allRecordGrid" runat="server" AllowPaging="true" AutoGenerateColumns="False"
            PageSize="10" OnPageIndexChanging="allRecordGrid_PageIndexChanging1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p1" HeaderText="SIMNO">
                    <HeaderStyle HorizontalAlign="left" Width="20%" />
                    <ItemStyle HorizontalAlign="left" Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="p2" HeaderText="IMEINO">
                    <HeaderStyle HorizontalAlign="left" Width="20%" />
                    <ItemStyle HorizontalAlign="left" Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="p3" HeaderText="Keyword">
                    <HeaderStyle HorizontalAlign="left" Width="20%" />
                    <ItemStyle HorizontalAlign="left" Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="p4" HeaderText="MobileNo">
                    <HeaderStyle HorizontalAlign="left" Width="30%" />
                    <ItemStyle HorizontalAlign="left" Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="p5" HeaderText="p5">
                    <HeaderStyle HorizontalAlign="left" Width="30%" />
                    <ItemStyle HorizontalAlign="left" Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="p6" HeaderText="p6">
                    <HeaderStyle HorizontalAlign="left" Width="30%" />
                    <ItemStyle HorizontalAlign="left" Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="p7" HeaderText="p7">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p8" HeaderText="p8">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p9" HeaderText="p9">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p10" HeaderText="p10">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p11" HeaderText="p11">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p12" HeaderText="p12">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p13" HeaderText="p13">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p14" HeaderText="p14">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p15" HeaderText="p15">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p16" HeaderText="p16">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p17" HeaderText="p17">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p18" HeaderText="p18">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p19" HeaderText="p19">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p20" HeaderText="p20">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p21" HeaderText="p21">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p22" HeaderText="p22">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p23" HeaderText="p23">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p24" HeaderText="p24">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p25" HeaderText="p25">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p26" HeaderText="p26">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p27" HeaderText="p27">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p28" HeaderText="p28">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p29" HeaderText="p29">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p30" HeaderText="p30">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p31" HeaderText="p31">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p32" HeaderText="p32">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p33" HeaderText="p33">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p34" HeaderText="p34">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p35" HeaderText="p35">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p36" HeaderText="p36">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p37" HeaderText="p37">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p38" HeaderText="p38">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p39" HeaderText="p39">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p40" HeaderText="p40">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p41" HeaderText="p41">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p42" HeaderText="p42">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p43" HeaderText="p43">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="p44" HeaderText="p44">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="date" HeaderText="Date">
                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                    <ItemStyle HorizontalAlign="left" Width="10%" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
