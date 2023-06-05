<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMI Rechner</title>
    <link href="~/styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form method="post" runat="server">
        
        <div class="row">
            <div class="col-sm-2">
                <b>Grösse in m:</b>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="Height" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Die Grösse sollte zwischen 1.2m und 2.5m liegen." ControlToValidate="Height" MinimumValue="1.2" MaximumValue="2.5" Type="Double"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bitte geben Sie die Grösse ein" ControlToValidate="Height"></asp:RequiredFieldValidator>
            </div>
        </div>

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



    </form>
</body>
</html>
