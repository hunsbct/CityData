<%@ Page Title="" Language="C#" MasterPageFile="~/CityDataMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="CityData.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>City Data - Search</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function FadeAlert() { $(".alert-message").fadeTo(300, 1).delay(3000).fadeTo(300, 0); }

        function FadeAlertNoResults() { $(".alert-message-no-results").fadeTo(300, 1).delay(1500).fadeTo(300, 0); }
    </script>
    <div class="activity-div">
        <div class="title">Search Cities By Data Criteria</div>
        <div class="div-controls">
                <div class="div-ddl-attribute">
        <!-- TODO add more search types if time permits -->
                <asp:DropDownList ID="ddlSearchType" runat="server">
                    <asp:ListItem Value="Population">Population</asp:ListItem>
                    <asp:ListItem Value="MedianHouseholdIncome">Median Household Income</asp:ListItem>
                    <asp:ListItem Value="MedianHomeValue">Median Home Value</asp:ListItem>
                    <asp:ListItem Value="Median Male Age">Median Male Age</asp:ListItem>
                </asp:DropDownList>
                </div>
                <div class="div-ddl-comparison">
                    <asp:DropDownList ID="ddlComparison" runat="server">
                        <asp:ListItem Value="<">Less Than</asp:ListItem>
                        <asp:ListItem Value="=">Is</asp:ListItem>
                        <asp:ListItem Value=">">Greater Than</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="div-search-value">
                    <div class="input-group">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-filter"></span></div>
                                <asp:TextBox ID="txtSearchValue" runat="server" CssClass="form-control" placeholder="Search Value - Int" required="true" />
                    </div>
                </div>
                <div class="search-button">
                    <asp:Button ID="btnSearch" runat="server" class="btn main-btn" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="repeater">
            <!-- Opted to use a search repeater as the gridview replacement -->
            <asp:Repeater ID="rptSearchResults" runat="server">
                <HeaderTemplate>
                    <table class="search-table">
                        <tr>
                            <th scope="col">
                                City
                            </th>
                            <th scope="col">
                                State
                            </th>
                            <th scope="col">
                                Population
                            </th>
                            <th scope="col">
                                Median Household Income
                            </th>
                            <th scope="col">
                                Percent Homeowners
                            </th>
                            <th scope="col">
                                Percent Renters
                            </th>
                            <th scope="col">
                                Median Home Value
                            </th>
                            <th scope="col">
                                Median Male Age
                            </th>
                            <th scope="col">
                                Median Female Age
                            </th>
                            <th scope="col">
                                Unemployment Rate
                            </th>
                            <th scope="col">
                                Crime Index
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblCity" runat="server" style="font-weight: bold;" Text='<%# Eval("CityName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblPopulation" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblMedianHouseholdIncome" runat="server" Text='<%# Eval("MedianHouseholdIncome", "{0:C}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblPercentOwners" runat="server" Text='<%# Eval("PercentOwners") + "%" %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblPercentRenters" runat="server" Text='<%# Eval("PercentRenters") + "%" %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblMedianHomeValue" runat="server" Text='<%# Eval("MedianHomeValue", "{0:C}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblMedianMaleAge" runat="server" Text='<%# Eval("MedianMaleAge") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblMedianFemaleAge" runat="server" Text='<%# Eval("MedianFemaleAge") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblUnemploymentRate" runat="server" Text='<%# Eval("UnemploymentRate") + "%" %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCrimeIndex" runat="server" Text='<%# Eval("CrimeIndex") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </div>        
        <div class="alert-message">
            Something went wrong. Make sure the value that you entered is an integer.
        </div>              
        <div class="alert-message-no-results">
            No results.
        </div>
     </div>
    <!-- Add Bootstrap style to DDLs -->
    <script>
    $().ready(function(){
        $('#<%=ddlSearchType.ClientID%>').addClass("form-control");
        $('#<%=ddlComparison.ClientID%>').addClass("form-control");
    });
</script>
</asp:Content>