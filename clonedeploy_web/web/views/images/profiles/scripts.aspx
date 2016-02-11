﻿<%@ Page Title="" Language="C#" MasterPageFile="~/views/images/profiles/profiles.master" AutoEventWireup="true" CodeFile="scripts.aspx.cs" Inherits="views_images_profiles_scripts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BreadcrumbSub2" Runat="Server">
      <li><a href="<%= ResolveUrl("~/views/images/profiles/general.aspx") %>?imageid=<%= Image.Id %>&profileid=<%= ImageProfile.Id %>&cat=profiles"><%= ImageProfile.Name %></a></li>
    <li>Scripts</li>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="SubHelp">
    <a href="<%= ResolveUrl("~/views/help/index.html") %>" class="submits help" target="_blank"></a>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ActionsRightSub">
    <asp:LinkButton ID="btnUpdateScripts" runat="server" OnClick="btnUpdateScripts_OnClick" Text="Update Script Options" CssClass="submits actions green" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubContent2" Runat="Server">
     <script type="text/javascript">
        $(document).ready(function() {
            $('#scripts').addClass("nav-current");
        });
    </script>
     <asp:GridView ID="gvScripts" runat="server" AllowSorting="True" DataKeyNames="Id" OnSorting="gridView_Sorting" AutoGenerateColumns="False" CssClass="Gridview" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:TemplateField>
                <HeaderStyle CssClass="chkboxwidth"></HeaderStyle>
                <ItemStyle CssClass="chkboxwidth"></ItemStyle>
                <HeaderTemplate>
                    Pre
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkPre" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <HeaderStyle CssClass="chkboxwidth"></HeaderStyle>
                <ItemStyle CssClass="chkboxwidth"></ItemStyle>
                <HeaderTemplate>
                    Post
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkPost" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/views/global/scripts/edit.aspx?cat=sub1&scriptid={0}" Text="View" ItemStyle-CssClass="chkboxwidth"/>
            <asp:BoundField DataField="Id" HeaderText="computerID" SortExpression="computerID" Visible="False"/>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-CssClass="width_200"></asp:BoundField>
             <asp:TemplateField ItemStyle-CssClass="width_100" HeaderText="Priority" SortExpression="Priority">
                                        <ItemTemplate>
                                            <div id="settings">
                                                <asp:TextBox ID="txtPriority" runat="server" CssClass="textbox_specs"/>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
            
          
         
            
        </Columns>
        <EmptyDataTemplate>
            No Scripts Found
        </EmptyDataTemplate>
    </asp:GridView>
    
 
</asp:Content>

