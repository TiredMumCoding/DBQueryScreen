<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewEditProfile.aspx.vb" Inherits="ViewEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1 class="headertext">View or Edit Profile</h1><br /><br />
 <div class="defaultWrapperTop" id="ViewEditProfileBtns" runat="server">
<h2>
<asp:LinkButton ID="ProfileView" CssClass="Btn" runat="server" Text="View Profile" OnClick="ViewProfile" />
<asp:LinkButton ID="ProfileEdit" CssClass="Btn" runat="server" Text="Edit Profile" OnClick="EditProfile"/>
</h2>
</div>
<div id="ViewProfileMarkup" runat="server">
<h2><asp:Label ID="VPFirstNameLabel" CssClass="displaytitlelabel" runat="server" Text="First Name: " />
<asp:Label ID="VPFirstNameDisplay" CssClass="displaydatalabel" runat="server" Text="test" /><br /><br />
<asp:Label ID="VPLastNameLabel" CssClass="displaytitlelabel" runat="server" Text="Last Name: " />
<asp:Label ID="VPLastNameDisplay" CssClass="displaydatalabel" runat="server" Text="test" /><br /><br />
<asp:Label id="VPEmailLabel" cssclass="displaytitlelabel" runat="server" Text="Email Address: "/>
<asp:Label ID="VPEmailDisplay" CssClass="displaydatalabel" runat="server" Text="test" /><br /><br />
<asp:Label id="VPAgeLabel" CssClass="displaytitlelabel" runat="server" Text="Age: "  />
<asp:Label ID="VPAgeDisplay" cssclass="displaydatalabel" runat="server" text="test"/><br /><br />
<asp:Label id="VPGenderLabel" CssClass="displaytitlelabel" runat="server" Text="Gender: "/>
<asp:Label ID="VPGenderDisplay" CssClass="displaydatalabel" runat="server" Text="test" /><br /><br />
<asp:Label id="VPHoursLabel" CssClass="displaytitlelabel" runat="server" Text="Workout Hours Per Week: "/>
<asp:Label ID="VPHoursDisplay" cssclass="displaydatalabel" runat="server" Text="test" /><br /><br />
<asp:Button ID="ViewEdit" runat="server" OnClick="EditProfile" Text="Edit Profile" /></h2>
<asp:Button ID="ViewBack" runat="server" OnClick="EditBackBtn" Text="Back" /></h2>
</div>
<div id="EditProfileMarkup" runat="server">
<h2><asp:Label id="EPFirstName" runat="server" Text="First Name: " CssClass="inputlabel"/>
<asp:TextBox ID="EPFirstNameTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="EPLastName" runat="server" Text="Last Name: " CssClass="inputlabel"/>
<asp:TextBox ID="EPLastNameTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="EPEmailLabel" runat="server" Text="Email Address: " CssClass="inputlabel"/>
<asp:TextBox ID="EPEmailTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="EPAge" runat="server" Text="Age: " CssClass="inputlabel"/>
<asp:TextBox ID="EPAgeTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="EPGender" runat="server" Text="Gender: " CssClass="inputlabel"/>
<asp:DropDownList ID="EPGenderList" runat="server">
    <asp:ListItem Text="Male" />
    <asp:ListItem Text="Female" />
</asp:DropDownList><br /><br />
<asp:Label id="EPHours" runat="server" Text="Workout Hours Per Week: " CssClass="inputlabel"/>
<asp:TextBox ID="EPHoursTextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:button ID="EditSubmit" runat="server" OnClick="EditSub" Text="Submit" />
<asp:Button ID="EditBack" runat="server" OnClick="EditBackBtn" Text="Back" /></h2>
</div>
<div id="EditErrorSection" runat="server">
<asp:Label ID="EditErrorLabel" runat="server" />
</div>
</asp:Content>

