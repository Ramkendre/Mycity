<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Sitemap.aspx.cs" Inherits="html_Sitemap" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/ecmascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false">
    </script>

    <script type="text/javascript">
        var map;
        function setPoint() {
            try {
                var Loc = document.getElementById("<%=lblLoc.ClientID%>").innerText.split('*');
                var nm = document.getElementById("<%=lblName.ClientID%>").innerText.split('*');
                var lat1 = document.getElementById("<%=lblLat.ClientID%>").innerText.split('*');
                var lng1 = document.getElementById("<%=lblLng.ClientID%>").innerText.split('*');

                //                var owner1 = document.getElementById("<%=lblOwner.ClientID%>").innerText.split('*');
                var addr1 = document.getElementById("<%=lblAddress.ClientID%>").innerText.split('*');
                var mob1 = document.getElementById("<%=lblMobileNo.ClientID%>").innerText.split('*');

                var mapProp = {
                    center: new google.maps.LatLng(18.5204303, 77.2249600),
                    zoom: 7,
                    panControl: true,
                    zoomControl: true,
                    mapTypeControl: true,
                    scaleControl: true,
                    streetViewControl: true,
                    overviewMapControl: true,
                    rotateControl: true,
                    mapTypeId: google.maps.MapTypeId.HYBRID
                };

                map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
                map.setZoom(6);

                var infowindow = new google.maps.InfoWindow();

                for (var i = 0; i < Loc.length - 1; i++) {

                    //                    var l = Loc[i];
                    var name = nm[i];
                    var lat = lat1[i];
                    var lng = lng1[i];
                    var latlngset = new google.maps.LatLng(lat, lng);


                    var content = '<div class="map-content"><span style=font-family:Cambria;font-size:18px;font-weight:600;">'
                     + name + '</span><br/><span style=font-family:Cambria;font-size:14px;font-weight:200;float: left;">Name: ' + nm[i] +
                     '<br />Address: ' + addr1[i] + '<br/>Mobile No: ' + mob1[i] + '</span></div>';
                    var marker = new google.maps.Marker({
                        map: map,
                        title: name,
                        position: latlngset
                    });

                    google.maps.event.addListener(marker, 'mouseover', (function(marker, content) {
                        return function() {
                            infowindow.setContent(content);
                            infowindow.open(map, marker);
                        }
                    })(marker, content));
                }
            } catch (err) { alert(err); }
        }

        google.maps.event.addDomListener(button, 'click', setPoint);           

    </script>

    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td>
                        <div>
                            Your Address Here Lattitude of Address
                            <asp:Label ID="lblLattitude" runat="server"></asp:Label><br />
                            Longtitude of Address
                            <asp:Label ID="lblLongtitude" runat="server">
                            </asp:Label>
                        </div>
                        <br />
                        <center>
                            <div id="view2" style="float: left; border: groove 1px black;">
                                <div id="googleMap" style="width: 600px; height: 350px;">
                                </div>
                            </div>
                        </center>
                        <div id="divId" style="display: none">
                            <asp:Label ID="lblLoc" runat="server" ForeColor="Black"></asp:Label>
                            <br />
                            <asp:Label ID="lblName" runat="server" ForeColor="White"></asp:Label>
                            <br />
                            <asp:Label ID="lblLat" runat="server" ForeColor="White"></asp:Label>
                            <br />
                            <asp:Label ID="lblLng" runat="server" ForeColor="White"></asp:Label>
                            <br />
                            <asp:Label ID="lblOwner" runat="server" ForeColor="White"></asp:Label>
                            <br />
                            <asp:Label ID="lblAddress" runat="server" ForeColor="White"></asp:Label>
                            <br />
                            <asp:Label ID="lblMobileNo" runat="server" ForeColor="White"></asp:Label>
                            <br />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
