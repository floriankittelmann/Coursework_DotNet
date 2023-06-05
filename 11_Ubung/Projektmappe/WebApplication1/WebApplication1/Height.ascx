<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Height.ascx.cs" Inherits="WebApplication1.WebUserControl1" %>
 <div class="row">
    <div class="col-sm-2">
        <b>Grösse in m:</b>
    </div>
    
    <div class="col-sm-4">
        <asp:TextBox ID="Height2" runat="server"></asp:TextBox>
    </div>

    <div class="col-sm-2">
        <asp:DropDownList ID="HeightUnit" runat="server" OnSelectedIndexChanged="HeightUnit_SelectedIndexChanged" AutoPostBack="True" CausesValidation="False">
            <asp:ListItem Text="m" Value="1.0" Selected="true" />
            <asp:ListItem Text="feet" Value="3.28084" />
        </asp:DropDownList>
    </div>

    <div class="col-sm-4">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Bitte geben Sie das Grösse ein" ControlToValidate="Height2">
        </asp:RequiredFieldValidator>
    </div>
</div>