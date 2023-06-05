﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Weight.ascx.cs" Inherits="WebApplication1.Weight" %>

<div class="row">

    <div class="col-sm-2">
        <b>Gewicht in kg:</b>
    </div>
    
    <div class="col-sm-4">
        <asp:TextBox ID="Weight2" runat="server"></asp:TextBox>
    </div>

    <div class="col-sm-2">
        <asp:DropDownList ID="WeightUnit" runat="server">
            <asp:ListItem Text="kg" Value="1.0" Selected="true" />
            <asp:ListItem Text="lb" Value="2.20462" />
        </asp:DropDownList>
    </div>

    <div class="col-sm-4">
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ErrorMessage="Das Gewicht sollte zwischen 50kg und 200kg liegen"
            ControlToValidate="Weight2" MinimumValue="50" MaximumValue="200" Type="Double">
        </asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Bitte geben Sie das Gewicht ein" ControlToValidate="Weight2">
        </asp:RequiredFieldValidator>
    </div>

</div>
