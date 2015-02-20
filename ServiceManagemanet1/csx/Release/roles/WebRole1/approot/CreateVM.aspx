<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateVM.aspx.cs" Inherits="WebRole1.CreateVM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Images Name: </strong>&nbsp;&nbsp;
        <asp:DropDownList ID="ddImageList" runat="server" Height="16px" Width="825px">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>VM Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextVMName" runat="server" Width="260px"></asp:TextBox>
&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Instance Size:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddInstanceSize" runat="server" Height="18px" Width="318px">
            <asp:ListItem>-----Select-----</asp:ListItem>
            <asp:ListItem Value="ExtraSmall ">Extra Small (Shared core, 768 MB Memory) </asp:ListItem>
            <asp:ListItem Value="Small">Small (1 core, 1.75 GB Memory)</asp:ListItem>
            <asp:ListItem Value="Medium">Medium (2 cores, 3.5 GB Memory)</asp:ListItem>
        </asp:DropDownList>
        <br />
        </strong>
        <br />
        <br />
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data Disk:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextDataDisk" runat="server" Width="260px"></asp:TextBox>
&nbsp; (Ex. 200 GB. Max 500 GB)<br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:Button ID="BCreateVM" runat="server" style="font-weight: 700" Text="Create VM" OnClick="BCreateVM_Click" Width="155px" />
        <strong>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        </strong>
        <asp:TextBox ID="TextError" runat="server" Height="194px" TextMode="MultiLine" Width="756px"></asp:TextBox>
        <br />
    
    </div>
    </form>
</body>
</html>
