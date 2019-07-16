<%@ Page Title="" Language="C#" MasterPageFile="~/CityDataMaster.Master" AutoEventWireup="true" CodeBehind="ViewCity.aspx.cs" Inherits="CityData.ViewCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>City Data - View City</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
         function FadeInTable() { $(".div-view-city").fadeTo(750, 1); }

         function FadeOutTable() { $(".div-view-city").fadeTo(750, 0); }

         function HideTable() { $(".div-view-city").css("opacity", 0); }
     </script>
    <div class="activity-div">
        <div class="title">View Data By City</div>
        <div class="div-controls">
            <div class="ddl-state">
                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="ddl-city">
                <asp:DropDownList ID="ddlCity" runat="server" Visible="false"></asp:DropDownList>
            </div>
            <div class="div-btn-view">
                <asp:Button ID="btnSubmitCity" runat="server" AutoPostBack="false" CssClass="btn main-btn" Text="View Data" OnClick="btnSubmitCity_Click" Visible="false" />
            </div>
        </div>
        <div class="div-view-city">
            <div class="view-city-state-row">
                <asp:Label ID="lblViewCityName" runat="server" EnableViewState="true" ></asp:Label>
            </div>
            <div class="view-city-data-table">
                <table class="view-city-table" EnableViewState="true">
                    <tr>
                        <td class="datatitle">Population</td>
                        <td id="cellPop" runat="server"></td>
                        <td class="datatitle">Median Household Income</td>
                        <td id="cellMHI" runat="server"></td>
                        <td class="datatitle">Median Female Age</td>
                        <td id="cellMFA" runat="server"></td>
                    </tr>
                    <tr>
                        <td class="datatitle">Unemployment Rate</td>
                        <td id="cellUE" runat="server"></td>
                        <td class="datatitle">Median Home Value</td>
                        <td id="cellMHV" runat="server"></td>
                        <td class="datatitle">Median Male Age</td>
                        <td id="cellMMA" runat="server"></td>
                    </tr>
                    <tr>
                        <td class="datatitle">Crime Index</td>
                        <td id="cellCI" runat="server"></td>
                        <td class="datatitle">Percent Homeowners</td>
                        <td id="cellPH" runat="server"></td>
                        <td class="datatitle">Percent Property Renters</td>
                        <td id="cellPR" runat="server"></td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!-- Add Bootstrap style to DDLs -->
    <script>
    $().ready(function(){
        $('#<%=ddlCity.ClientID%>').addClass("form-control");
        $('#<%=ddlState.ClientID%>').addClass("form-control");
    });
</script>
</asp:Content>
