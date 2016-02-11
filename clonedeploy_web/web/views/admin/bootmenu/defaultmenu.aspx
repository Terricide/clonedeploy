﻿<%@ Page Title="" Language="C#" MasterPageFile="~/views/admin/bootmenu/bootmenu.master" AutoEventWireup="true" CodeFile="defaultmenu.aspx.cs" Inherits="views_admin_bootmenu_defaultmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreadcrumbSub2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubHelp" Runat="Server">
    <a href="<%= ResolveUrl("~/views/help/index.html") %>" class="submits help" target="_blank"></a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ActionsRightSub" Runat="Server">
    <asp:LinkButton ID="btnSubmitDefault" runat="server" Text="Create Boot Files" OnClick="btnSubmit_Click" CssClass="submits actions green" OnClientClick="get_shas();"/>
    <asp:LinkButton ID="btnSubmitDefaultProxy" runat="server" Text="Create Boot Files" OnClick="btnSubmit_Click" CssClass="submits actions green" OnClientClick="get_shas_proxy();"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SubContent2" Runat="Server">

<script type="text/javascript">
    $(document).ready(function() {
        $('#default').addClass("nav-current");
    });

    function get_shas_proxy() {
        $('#<%= consoleShaProxy.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtProxDebugPwd.ClientID %>').value));
        $('#<%= addcomputerShaProxy.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtProxAddPwd.ClientID %>').value));
        $('#<%= ondshaProxy.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtProxOndPwd.ClientID %>').value));
        $('#<%= diagshaProxy.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtProxDiagPwd.ClientID %>').value));  
    }
    function get_shas() {
        $('#<%= consoleSha.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtDebugPwd.ClientID %>').value));
        $('#<%= addcomputerSha.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtAddPwd.ClientID %>').value));
        $('#<%= ondsha.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtOndPwd.ClientID %>').value));
        $('#<%= diagsha.ClientID %>').val(syslinux_sha512(document.getElementById('<%= txtdiagPwd.ClientID %>').value));
    }
</script>

<asp:HiddenField ID="consoleSha" runat="server"/>
<asp:HiddenField ID="addcomputerSha" runat="server"/>
<asp:HiddenField ID="ondsha" runat="server"/>
<asp:HiddenField ID="diagsha" runat="server"/>
<asp:HiddenField ID="consoleShaProxy" runat="server"/>
<asp:HiddenField ID="addcomputerShaProxy" runat="server"/>
<asp:HiddenField ID="ondshaProxy" runat="server"/>
<asp:HiddenField ID="diagshaProxy" runat="server"/>



<div id="divStandardMode" runat="server" visible="false">
    <div id="bootPasswords" runat="server" visible="false" style="margin-top: 0;">

        <div class="size-4 column">
            Kernel:
        </div>
        <div class="size-5 column">
            <asp:DropDownList ID="ddlComputerKernel" runat="server" CssClass="ddlist">
            </asp:DropDownList>
        </div>
        <br class="clear"/>
        <div class="size-4 column">
            Boot Image:
        </div>
        <div class="size-5 column">
            <asp:DropDownList ID="ddlComputerBootImage" runat="server" CssClass="ddlist">
            </asp:DropDownList>
        </div>
        <br class="clear"/>
        <div id="passboxes" runat="server">
            <br/>
            <h4>Boot Menu Passwords - Optional</h4>
            <div class="size-4 column">
                Client Console Password:
            </div>
            <div class="size-5 column">
                <asp:TextBox ID="txtDebugPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
            </div>
            <br class="clear"/>
            <div class="size-4 column">
                Add Computer Password:
            </div>
            <div class="size-5 column">
                <asp:TextBox ID="txtAddPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
            </div>
            <br class="clear"/>
            <div class="size-4 column">
                On Demand Password:
            </div>
            <div class="size-5 column">
                <asp:TextBox ID="txtOndPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
            </div>
            <br class="clear"/>
            <div class="size-4 column">
                Diagnostics Password:
            </div>
            <div class="size-5 column">
                <asp:TextBox ID="txtdiagPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
            </div>
            <br class="clear"/>
        </div>
        <div id="ipxePassBoxes" runat="server" visible="false" style="margin-top: 0;">
            <br/>
            <h4>Boot Menu Passwords - Optional</h4>
            <div class="size-4 column">
                iPXE Requires Login?:
            </div>
            <div class="size-5 column">
                <asp:CheckBox ID="chkIpxeLogin" runat="server"></asp:CheckBox>
            </div>
            <br class="clear"/>
           
        </div>
        <div id="grubPassBoxes" runat="server" visible="false" style="margin-top: 0;">
            <br/>
            <h4>Boot Menu Passwords - Optional</h4>
            <div class="size-4 column">
                Username:
            </div>
            <div class="size-5 column">
                <asp:TextBox ID="txtGrubUsername" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <br class="clear"/>
            <div class="size-4 column">
                Password:
            </div>
            <div class="size-5 column">
                <asp:TextBox ID="txtGrubPassword" runat="server" CssClass="textbox" type="password"></asp:TextBox>
            </div>
            <br class="clear"/>
        </div>

    </div>

</div>

<div id="divProxyDHCP" runat="server" visible="false">
    <div class="size-4 column">
        <h4>BIOS</h4>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        Kernel:
    </div>
    <div class="size-5 column">
        <asp:DropDownList ID="ddlBiosKernel" runat="server" CssClass="ddlist">
        </asp:DropDownList>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        Boot Image:
    </div>
    <div class="size-5 column">
        <asp:DropDownList ID="ddlBiosBootImage" runat="server" CssClass="ddlist">
        </asp:DropDownList>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        <h4>EFI 32</h4>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        Kernel:
    </div>
    <div class="size-5 column">
        <asp:DropDownList ID="ddlEfi32Kernel" runat="server" CssClass="ddlist">
        </asp:DropDownList>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        Boot Image:
    </div>
    <div class="size-5 column">
        <asp:DropDownList ID="ddlEfi32BootImage" runat="server" CssClass="ddlist">
        </asp:DropDownList>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        <h4>EFI64</h4>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        Kernel:
    </div>
    <div class="size-5 column">
        <asp:DropDownList ID="ddlEfi64Kernel" runat="server" CssClass="ddlist">
        </asp:DropDownList>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        Boot Image:
    </div>
    <div class="size-5 column">
        <asp:DropDownList ID="ddlEfi64BootImage" runat="server" CssClass="ddlist">
        </asp:DropDownList>
    </div>
    <br class="clear"/>
    <br/>
    <div id="proxyPassBoxes" runat="server" visible="false" style="margin-top: 20px;">
        <div class="size-1 column">
            Boot Menu Password Will Be Applied To Any Matching
        </div>
        <br class="clear"/>
        <br/>
        <h4>Syslinux Boot Menu Passwords - Optional</h4>

        <div class="size-4 column">
            Client Console Password:
        </div>
        <div class="size-5 column">
            <asp:TextBox ID="txtProxDebugPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
        </div>
        <br class="clear"/>
        <div class="size-4 column">
            Add Computer Password:
        </div>
        <div class="size-5 column">
            <asp:TextBox ID="txtProxAddPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
        </div>
        <br class="clear"/>
        <div class="size-4 column">
            On Demand Password:
        </div>
        <div class="size-5 column">
            <asp:TextBox ID="txtProxOndPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
        </div>
        <br class="clear"/>
        <div class="size-4 column">
            Diagnostics Password:
        </div>
        <div class="size-5 column">
            <asp:TextBox ID="txtProxDiagPwd" runat="server" CssClass="textbox" type="password"></asp:TextBox>
        </div>
        <br class="clear"/>
    </div>
     <div id="ipxeProxyPasses" runat="server" visible="false" style="margin-top: 0;">
        <br/>
        <h4>iPXE Boot Menu</h4>
        <div class="size-4 column">
            iPXE Requires Login?
        </div>
        <div class="size-5 column">
            <asp:CheckBox ID="chkIpxeProxy" runat="server"></asp:CheckBox>
        </div>
        <br class="clear"/>
      
    </div>
    <div id="grubProxyPasses" runat="server" visible="false" style="margin-top: 0;">
        <br/>
        <h4>Grub Boot Menu Passwords - Optional</h4>
        <div class="size-4 column">
            Username:
        </div>
        <div class="size-5 column">
            <asp:TextBox ID="txtGrubProxyUsername" runat="server" CssClass="textbox"></asp:TextBox>
        </div>
        <br class="clear"/>
        <div class="size-4 column">
            Password:
        </div>
        <div class="size-5 column">
            <asp:TextBox ID="txtGrubProxyPassword" runat="server" CssClass="textbox" type="password"></asp:TextBox>
        </div>
        <br class="clear"/>
    </div>
</div>
</asp:Content>

