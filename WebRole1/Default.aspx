<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebRole1._Default" %>


<form id="form1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Height="205px" TextMode="MultiLine" Width="981px"></asp:TextBox>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GetImages" Width="125px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Setup Azure" Width="154px" />
&nbsp;&nbsp;
        <asp:Button ID="ButtoncreateVM" runat="server" PostBackUrl="~/CreateVM.aspx" Text="CreateVM" Width="162px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="927px">
        </asp:DropDownList>
    </p>
</form>
