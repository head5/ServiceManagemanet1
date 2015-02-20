<%@ Page Title="" Language="C#" MasterPageFile="~/B_UI/Detail.Master" AutoEventWireup="true" CodeBehind="VMConfiguration.aspx.cs" Inherits="WebRole.B_UI.VMConfiguration" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>

<asp:Content ID="CntConfigVM" ContentPlaceHolderID="DetailContent" runat="server">
    <asp:Table runat="server" BorderWidth="1">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="4" BorderWidth="1">
                <h2><u>Configure Your VM&nbsp;</u></h2>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" BorderWidth="1">
                Expected VM Name:
            </asp:TableCell>
            <asp:TableCell ColumnSpan="3" BorderWidth="1">
                <asp:TextBox ID="txtVMName" runat="server" Width="250"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" BorderWidth="1">
                VM Instance Size:
            </asp:TableCell>
            <asp:TableCell BorderWidth="1">
                <asp:DropDownList ID="ddInstanceSizes" runat="server"><%--AutoPostBack="true"--%> 
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right" BorderWidth="1">
                Data Disk Size:
            </asp:TableCell>
            <asp:TableCell BorderWidth="1">
                <asp:TextBox ID="txtDataDiskSize" runat="server" Width="50"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4">
                <asp:ListBox ID="lstImages" runat="server"></asp:ListBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell BorderWidth="1"></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderWidth="1">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="65" OnClick="btnCancel_Click" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderWidth="1">
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="65" OnClick="btnClear_Click" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderWidth="1">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Request" Width="120" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
