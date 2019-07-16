<%@ Page Title="" Language="C#" MasterPageFile="~/CityDataMaster.Master" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="CityData.AddCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>City Data - Add City</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
         function FadeInTxts() { $(".div-textboxes").fadeTo(300, 1); }

         function FadeOutTxts() { $(".div-textboxes").fadeTo(300, 0); }

         function FadeAlert() { $(".alert-message").fadeTo(300, 1).delay(3000).fadeTo(300, 0); }

         function FadeConfirm() { $(".confirm-message").fadeTo(300, 1).delay(3000).fadeTo(300, 0); }

         function FadeDuplicate() { $(".duplicate-message").fadeTo(300, 1).delay(3000).fadeTo(300, 0); }
     </script>
    <div class="activity-div-add-city">
        <div class="title">Add New City</div>
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
            <asp:Button ID="btnAddCity" runat="server" CssClass="btn main-btn" Text="Add City" OnClick="BtnAddCity_Click" />
        </div>
        <div class="alert-message"></div>
        <div class="confirm-message">City added successfully</div>
        <div class="duplicate-message">City already exists.</div>
    </div>
    <!--
    <asp:Label ID="lblInvalidData" runat="server" Visible="false" CssClass="warning-label" Text="One or more values entered is invalid. Please try again."></asp:Label>  
    <asp:Label ID="lblCityExists" runat="server" Visible="false" CssClass="warning-label" Text="This city/state pair already exists in the database."></asp:Label>
    <asp:Label ID="lblAddedCity" runat="server" Visible="false" CssClass="success-label" Text="City added successfully."></asp:Label> 
    -->
</asp:Content>

