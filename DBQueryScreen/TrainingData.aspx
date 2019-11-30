<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TrainingData.aspx.vb" Inherits="TrainingData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="MainTrainingData">
<h2><asp:Label id="MainDistanceLabel" runat="server" Text="Distance: " CssClass="inputlabel"/>
    <asp:dropdownlist ID="typelist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MainDistance" CssClass="inputtextbox">
        <asp:ListItem runat="server" text="Time Trial: 500m"></asp:ListItem>
        <asp:ListItem runat="server" text="Time Trial: 2500m"></asp:ListItem>
        <asp:ListItem runat="server" text="Time Trial: 5000m"></asp:ListItem>
        <asp:ListItem runat="server" text="Custom Distance"></asp:ListItem>
        <asp:ListItem runat="server" text="Intervals"></asp:ListItem>
    </asp:dropdownlist></h2>
</div>


 <div id="Intervals" runat="server">
 <div class ="TrainingDataWrapper">
 <h2 class="titletext">Use this form to enter Intervals (in meters)</h2>
<h3><div class="IntervalForm">
<asp:Label id="DistanceLabel" runat="server" Text="Distance: " CssClass="layer2inputlabel"/>
<asp:TextBox ID="DistanceTextBox" runat="server" textmode="Time" format="HH:mm"  cssclass="inputtextbox"/><br /><br />
<asp:Label id="SplitLabel" runat="server" Text="Time: " CssClass="layer2inputlabel "/>
<asp:TextBox ID="SplitTextBox" runat="server" CssClass="inputtextbox" /><br /><br />
</div><div id="intervalrepdiv" class="rep">
<table><asp:Repeater ID="intervalrep" runat="server">
 <HeaderTemplate><tr><td><asp:Label runat="server" Text="Distance" /></td> 
         <td><asp:Label runat="server" Text="Time"/></td>
        <td></td></tr>
    </HeaderTemplate>
    <ItemTemplate>
     <tr><td><asp:label runat=server text='<%# Eval("Distance")%>'/></td> 
    <td><asp:label runat=server text='<%# Eval("Split")%>'/></td>
    <td><asp:linkbutton runat=server text='<%# Eval("Delete")%>' CommandArgument='<%# Eval("Interval Number")%>' OnClick="DeleteInterval"/></td>
    </tr></ItemTemplate>
</asp:Repeater></table>
</div></div>
<asp:button ID="IntervalSubmit" runat="server" OnClick="IntervalSub" Text="Add to Intervals" /> </div></h3>


<h2><asp:Label id="CustomDistanceLabelHr" runat="server" Text="Custom Distance Hours: " CssClass="offsetlabel"/>
<asp:TextBox ID="CustomDistanceTextBoxHr" runat="server" cssclass="offsettextbox"/>
<asp:Label id="CustomDistanceLabelMin" runat="server" Text="Minutes: " CssClass="offsetlabel"/>
<asp:TextBox ID="CustomDistanceTextBoxMin" runat="server" cssclass="offsettextbox"/>
<asp:Label id="CustomDistanceLabelS" runat="server" Text="Seconds: " CssClass="offsetlabel"/>
<asp:TextBox ID="CustomDistanceTextS" runat="server" cssclass="offsettextbox"/><br /><br />

<asp:Label id="TotalTimeLabel" runat="server" Text="Overall Time: " CssClass="inputlabel"/>
<asp:TextBox ID="TotalTimeTextbox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="Av500Label" runat="server" Text="Average 500m: " CssClass="inputlabel"/>
<asp:TextBox ID="Av500TextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="Slow500Label" runat="server" Text="Slowest 500m: " CssClass="inputlabel"/>
<asp:TextBox ID="Slow500TextBox" runat="server" cssclass="inputtextbox"/><br /><br />
<asp:Label id="Fast500Label" runat="server" Text="Fastest 500m: " CssClass="inputlabel"/>
<asp:TextBox ID="Fast500TextBox" runat="server" cssclass="inputtextbox"/><br /><br /></h2>
<asp:button ID="TrainingSubmit" runat="server" OnClick="EnterTrainingSub" Text="Submit" />


</asp:Content>

