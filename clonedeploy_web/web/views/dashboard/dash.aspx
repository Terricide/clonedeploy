﻿<%@ Page Title="" Language="C#" MasterPageFile="~/views/Site.master" AutoEventWireup="true" Inherits="views.dashboard.Dashboard" CodeFile="dash.aspx.cs" ValidateRequest="false"%>



<asp:Content ID="Content1" ContentPlaceHolderID="SubNav" runat="Server">
    <h4 style="float: right; margin-right: 10px;">Clone Deploy 1.0.0</h4>
    </asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="Server">
    
    <p class="denied_text">
        <asp:Label ID="lblDenied" runat="server"></asp:Label>
    </p>
    
   
    

</asp:Content>