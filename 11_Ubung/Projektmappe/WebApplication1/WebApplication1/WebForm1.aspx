<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Src="~/Weight.ascx" TagPrefix="uc1" TagName="Weight" %>
<%@ Register Src="~/Height.ascx" TagPrefix="uc1" TagName="Height" %>
<%@ Register Src="~/BmiPicture.ascx" TagPrefix="uc1" TagName="BmiPicture" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMI Rechner</title>
    <link href="~/styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form method="post" runat="server">

        <uc1:Height runat="server" id="Height" />
        <uc1:Weight runat="server" ID="Weight" />

        <div class="row">
            <div class="col-sm-2">
                <b>berechneter BMI:</b>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="BmiResult" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-2">
                <asp:Button ID="CaluclateButton" runat="server" Text="BMI berechnen" OnClick="CalculateClick" />
            </div>
            <div class="col-sm-2">
                <asp:Button ID="ResetButton" runat="server" Text="Reset" OnClick="ResetClick" />
            </div>
        </div>

        <uc1:BmiPicture runat="server" id="BmiPicture" />

    </form>
</body>
</html>
