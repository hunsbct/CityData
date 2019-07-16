<%@ Page Title="" Language="C#" MasterPageFile="~/CityDataMaster.Master" AutoEventWireup="true" CodeBehind="UpdateCity.aspx.cs" Inherits="CityData.UpdateCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>City Data - Update City</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function FadeAlert() { $(".alert-message").fadeTo(300, 1).delay(3000).fadeTo(300, 0); }

        function FadeConfirm() { $(".confirm-message").fadeTo(300, 1).delay(3000).fadeTo(300, 0); }
    </script>
    <div class="activity-div">
        <div class="title">Update City Data</div>
        <div class="div-controls">
            <div class="ddl-state">
                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="ddl-city">
                <asp:DropDownList ID="ddlCity" runat="server" Visible="false" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="div-btn-view">
                <asp:Button ID="btnSubmitCity" runat="server" AutoPostBack="false" CssClass="btn main-btn" Text="View Data" OnClick="btnSubmitCity_Click" Visible="false" />
            </div>
        </div>
        <div class="div-textboxes">
            <div class="div-city-state">
                <div class="add-city-row-1a">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-map-marker"></span></div>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City - Text" required="true" />
                    </div>
                </div>
                <div class="add-city-row-1b">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-globe"></span></div>
                        <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="State - Text" required="true" />
                    </div>
                </div>
            </div>
            <div class="div-pop-med-income">
                <div class="add-city-row-2a">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
                        <asp:TextBox ID="txtPopulation" runat="server" CssClass="form-control" placeholder="Population - Integer" required="true" />
                    </div>
                </div>
                <div class="add-city-row-2b">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                        <asp:TextBox ID="txtMedianHouseholdIncome" runat="server" CssClass="form-control" placeholder="Median Household Income - Integer" required="true" />
                    </div>
                </div>
                <div class="add-city-row-2c">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-home"></span></div>
                        <asp:TextBox ID="txtPercentOwners" runat="server" CssClass="form-control" placeholder="Percentage of Homeowners - Decimal" required="true" />
                    </div>
                </div>
            </div>
            <div class="div-rent-homeval-maleage">
                <div class="add-city-row-3a">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-home"></span></div>
                        <asp:TextBox ID="txtPercentRenters" runat="server" CssClass="form-control" placeholder="Percentage of Renters - Decimal" required="true" />
                    </div>
                </div>
                <div class="add-city-row-3b">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-home"></span></div>
                        <asp:TextBox ID="txtMedianHomeValue" runat="server" CssClass="form-control" placeholder="Median Home Value - Integer" required="true" />
                    </div>
                </div>
                <div class="add-city-row-3c">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
                        <asp:TextBox ID="txtMedianMaleAge" runat="server" CssClass="form-control" placeholder="Median Male Age - Integer" required="true" />
                    </div>
                </div>
            </div>
            <div class="div-femage-unemployment-crime">
                <div class="add-city-row-4a">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
                        <asp:TextBox ID="txtMedianFemaleAge" runat="server" CssClass="form-control" placeholder="Median Female Age - Integer" required="true" />
                    </div>
                </div>
                <div class="add-city-row-4b">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-briefcase"></span></div>
                        <asp:TextBox ID="txtUnemploymentRate" runat="server" CssClass="form-control" placeholder="Unemployment Rate - Decimal" required="true" />
                    </div>
                </div>
                <div class="add-city-row-4c">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-alert"></span></div>
                        <asp:TextBox ID="txtCrimeIndex" runat="server" CssClass="form-control" placeholder="Crime Index - Decimal" required="true" />
                    </div>
                </div>
            </div>
        </div>
        <div class="btn-add-city">
            <asp:Button ID="btnUpdateCity" runat="server" CssClass="btn main-btn" Text="Update City" OnClick="btnUpdateCity_Click" Enabled="false" />
        </div>        
        <div class="alert-message"></div>
        <div class="confirm-message">City updated successfully</div>
    </div>
    <!-- Add Bootstrap style to DDLs -->
    <script>
    $().ready(function(){
        $('#<%=ddlCity.ClientID%>').addClass("form-control");
        $('#<%=ddlState.ClientID%>').addClass("form-control");
    });
</script>
</asp:Content>
