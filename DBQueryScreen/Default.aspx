<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 class="headertext">Training Hub</h1><br /><br />
 <div class="defaultWrapperTop">
<h2>
<asp:LinkButton ID="ViewProfile" CssClass="Btn" runat="server" Text="View or Edit Profile" onclick="ViewProfilePage"/>
<asp:LinkButton ID="LogTraining" CssClass="Btn" runat="server" Text="Log Training" OnClick="ViewEnterTrainingPage" />
</h2>
</div>
<div class="defaultWrapperBottom">
<h2>
<asp:LinkButton ID="ViewData" cssclass="Btn" runat="server" Text="View Data" />
<asp:LinkButton ID="Forums" cssclass="Btn" runat="server" Text="Visit Forums" />
</h2>
</div>
</asp:Content>

