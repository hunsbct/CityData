<%@ Page Title="" Language="C#" MasterPageFile="~/CityDataMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CityData.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>City Data - Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="activity-div">
        <p>Welcome to City Data!</p>
    </div>
    <!-- Hidden button to populate empty table as needed -->
    <asp:Button ID="insert" runat="server" Text="insert cities" OnClick="Insert_Click" Visible="false" />
</asp:Content>
